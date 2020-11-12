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
using RetirementStudio._UIMaps.GMPAdjustmentFactorsClasses;
using RetirementStudio._UIMaps.CommunicationFactorsClasses;
using RetirementStudio._UIMaps.TranchedBenefitClasses;
using RetirementStudio._UIMaps.TranchedBenefitPlanDefinitionClasses;
using RetirementStudio._UIMaps.NonTranchedBenefitPlanDefinitionClasses;
using RetirementStudio._UIMaps.Methods_UKClasses;
using RetirementStudio._UIMaps.CostOfLivingAdjustments_UKClasses;
using RetirementStudio._UIMaps.CommutationClasses;
using RetirementStudio._UIMaps.PayCreditClasses;
using RetirementStudio._UIMaps.CareerAverageEarmingsFormulaClasses;
using RetirementStudio._UIMaps.CommutationFormulaClasses;
using System.Threading;


namespace RetirementStudio._TestScripts_2020_Mar_UK
{
    /// <summary>
    /// Summary description for UK007_CN
    /// </summary>
    [CodedUITest]
    public class UK007_CN
    {
        public UK007_CN()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.UK;
            Config.sClientName = "QA UK Benchmark 007 Existing DNT Small";
            Config.sPlanName = "QA UK Benchmark 007 Existing DNT Plan Small";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;


        }



        public Boolean bSmall_Data = true;
        //public Boolean bSmall_Data = false;

        public string sDataFile_Large = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\UK007\Data2017.xlsx";
        public string sDataFile_Small = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\UK007\Data2017_Small.xlsx";
        public string sDataFileName_Large = "Data2017.xlsx";
        public string sDataFileName_Small = "Data2017_Small.xlsx";

        public string sUnique_NoMatch_Num_Large = "111882";
        public string sUnique_NoMatch_Num_Small = "100";

        public string sDataFile, sDataFileName, sUnique_NoMatch_Num;


        #region Report Output Directory


        public string sOutputFunding_Conversion = "";
        public string sOutputFunding_Valuation2009_Baseline = "";
        public string sOutputFunding_Valuation2009_WithAltFunding = "";
        public string sOutputAccounting_Accounting2008 = "";

        public string sOutputFunding_Conversion_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_006\Production\Funding\Conversion\6.8_20160315_B\";
        public string sOutputFunding_Valuation2009_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_006\Production\Funding\Valuation 2009\Baseline\6.8_20160315_B\";
        public string sOutputFunding_Valuation2009_WithAltFunding_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_006\Production\Funding\Valuation 2009\With Alt Funding\6.8_20160315_B\";
        public string sOutputAccounting_Accounting2008_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_006\Production\Accounting\Accounting2008\6.8_20160315_B\";



        

        public void GenerateReportOuputDir()
        {




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

                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_006\Create New\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputFunding_Conversion = _gLib._CreateDirectory(sMainDir + "Funding\\Conversion\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2009_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation 2009\\Baseline\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2009_WithAltFunding = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation 2009\\With Alt Funding\\" + sPostFix + "\\");
                    sOutputAccounting_Accounting2008 = _gLib._CreateDirectory(sMainDir + "Accounting\\Accounting2008\\" + sPostFix + "\\");

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
                ///sDir = sDir + "\\" + Config._ReturnProjectName() + "\\_Reports\\";

                sDir = sDir + "\\_TestLog\\";

                string sMainDir = sDir + "UK006_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputFunding_Conversion = _gLib._CreateDirectory(sMainDir + "\\sOutputFunding_Conversion\\");
                sOutputFunding_Valuation2009_Baseline = _gLib._CreateDirectory(sMainDir + "\\sOutputFunding_Valuation2009_Baseline\\");
                sOutputFunding_Valuation2009_WithAltFunding = _gLib._CreateDirectory(sMainDir + "\\sOutputFunding_Valuation2009_WithAltFunding\\");
                sOutputAccounting_Accounting2008 = _gLib._CreateDirectory(sMainDir + "\\sOutputAccounting_Accounting2008\\");
            }

            string sContent = "";
            sContent = sContent + "sOutputFunding_Conversion = @\"" + sOutputFunding_Conversion + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2009_Baseline = @\"" + sOutputFunding_Valuation2009_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2009_WithAltFunding = @\"" + sOutputFunding_Valuation2009_WithAltFunding + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Accounting2008 = @\"" + sOutputAccounting_Accounting2008 + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);


        }


        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();

        public CommutationFormula pCommutationFormula = new CommutationFormula();
        public CareerAverageEarmingsFormula pCareerAverageEarmingsFormula = new CareerAverageEarmingsFormula();
        public PayCredit pPayCredit = new PayCredit();
        public CostOfLivingAdjustments_UK pCostOfLivingAdjustments_UK = new CostOfLivingAdjustments_UK();
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
        public GMPAdjustmentFactors pGMPAdjustmentFactors = new GMPAdjustmentFactors();
        public CommunicationFactors pCommunicationFactors = new CommunicationFactors();
        public TranchedBenefit pTranchedBenefit = new TranchedBenefit();
        public TranchedBenefitPlanDefinition pTranchedBenefitPlanDefinition = new TranchedBenefitPlanDefinition();
        public NonTranchedBenefitPlanDefinition pNonTranchedBenefitPlanDefinition = new NonTranchedBenefitPlanDefinition();
        public Methods_UK pMethods_UK = new Methods_UK();
        public Commutation pCommutation = new Commutation();


        #endregion



        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_UK007_CN()
        {



            _gLib._MsgBox("Warning!", "You are going to run test with bSmallData = " + bSmall_Data.ToString() + " with Client name as: " + Config.sClientName);


            #region Create Client and VO

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
            dic.Add("ClientCode", "UK2DCashFlow");
            dic.Add("FiscalYearEnd", "12/31");
            dic.Add("MeasurementDate", "09/30");
            dic.Add("Notes", "UK Test Client: DO NOT TOUCH BENCHMARK CLIENT. Original client: ZZZ_UK_2D_Cashflows");
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
            dic.Add("PlanYearBegin", "01/01");
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

            _gLib._MsgBox("Manually Execution Steps", "Please select on the client => plan name "
                + Config.sClientName + "==>" + Config.sPlanName + "in the Home page");

            dic.Clear();
            dic.Add("EnterShortName", "AllMembers");
            dic.Add("ConfirmShortName", "AllMembers");
            dic.Add("LongName", "AllMembers");
            pMain._ts_CreateNewBenefitSet(dic);




            #endregion


            #region Data2017


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
            dic.Add("Name", "Data2017");
            dic.Add("EffectiveDate", "31/03/2017");
            dic.Add("Parent", "");
            dic.Add("RSC", "");
            dic.Add("Shared", "");
            dic.Add("GeneralUse", "");
            dic.Add("Conversion", "true");
            dic.Add("CopyDataService", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_DataServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Data2017");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);





            dic.Clear();
            dic.Add("Level_1", "Data2017");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EditSelection", "");
            dic.Add("AddSingleLabel", "");
            dic.Add("AddMultipleLabels", "Click");
            pData._PopVerify_CurrentView(dic);



            _gLib._KillProcessByName("EXCEL");
            MyExcel _excel = new MyExcel(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\UK007\CurrentViewLables.xls", true);
            _excel.OpenExcelFile(1);

            int iTotalRow = _excel.getTotalRowCount();
            int iTotalCol = _excel.getTotalColumnCount();
            string sContents = "";
            for (int i = 2; i <= iTotalRow; i++)
            {
                string sRow = "";
                for (int j = 1; j <= iTotalCol; j++)
                    sRow = sRow + _excel.getOneCellValue(i, j) + "\t";

                sContents = sContents + sRow + Environment.NewLine;
            }
            _excel.CloseExcelApplication();

            Clipboard.Clear();
            Clipboard.SetText(sContents);

            _fp._ClickFirstRow(pData.wCV_AddLabels.wFPGrid.grid, 5, 15);
            _gLib._SendKeysUDWin("FPGrid", pData.wCV_AddLabels.wFPGrid.grid, "v", 0, ModifierKeys.Control, false);

            _gLib._SendKeysUDWin("FPGrid", pData.wCV_AddLabels.wFPGrid.grid, "{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}");

            int iTotalRow_Act = _fp._ReturnSelectRowIndex(pData.wCV_AddLabels.wFPGrid.grid) + 1;

            if (iTotalRow != iTotalRow_Act)
            {
                _gLib._Report(_PassFailStep.Fail, "Going to add <" + (iTotalRow - 1).ToString() + "> labels. Actual <" + (iTotalRow_Act + 1).ToString() + "> labels added! ");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Going to add <" + (iTotalRow - 1).ToString() + "> labels. Actual <" + (iTotalRow_Act + 1).ToString() + "> labels added! ");
            }


            _gLib._SetSyncUDWin("OK", pData.wCV_AddLabels.wOK.btnOK, "Click", 0);

            pMain._SelectTab("Data2017");

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Data2017");


            dic.Clear();
            dic.Add("Level_1", "Data2017");
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
            dic.Add("FileName", sDataFile);
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

            pMain._SelectTab("Data2017");


            dic.Clear();
            dic.Add("Level_1", "Data2017");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            pData._SelectTab("Select File");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "All_Members");
            dic.Add("FileType", "Excel file");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", sDataFileName);
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

            pData._SelectTab("Matching");

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", sUnique_NoMatch_Num);
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

            pData._SelectTab("Matching");



            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Matched_Num", "0");
            dic.Add("New_Num", sUnique_NoMatch_Num);
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



            pData._SelectTab("Matching");

            dic.Clear();
            dic.Add("Level_1", "Data2017");
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "ImportData");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "EmployeeIDNumber");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "BirthDate");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "HireDate1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Gender");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "USC");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "TerminationDate1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "DeathDate");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Health");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "UniqueID1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "UniqueID2");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "CAYIndicator");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Service");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Service");
            pData._TreeViewSelect_Snapshots(dic, true);



            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "BeneficiaryIDNumber");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1BirthDate");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1Gender");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1Benefit1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1StartDate1");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "MembershipDate1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "GMPPre88");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "GMPTotal");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "GMPPost88");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit1DB");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "StartDate1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "YearsCertain1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "LumpSumDeathBenefit1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "ContRatePost2014");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedPre14CRDPension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedPre14TPDPension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedPre14Age65Pension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedCARECRDPension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedCARETPDPension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedCARENPDPension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedCARECRDPension5050");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedCARETPDPension5050");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedCARENPDPension5050");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "TVINArmedForcesCAREPen");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "TVINCivilCAREPen");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "TVINFireCAREPen");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "TVINNHSCAREPen");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "TVINPoliceCAREPen");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "TVINTeachersCAREPen");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AddedYearsCRDPen");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AddedYears65Pen");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "ARCSPre12Pen");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "ARCSPost12Pen");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "EAPSPre12Pen");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "EAPSPost12Pen");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "APCPen");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "TotalPensionDebit");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedLumpSum");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedCRDLumpSum");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Accrued65LumpSum");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "TotalLumpSumDebit");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "TotalPartnerPension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "PartnerPensionPre2014");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedCRDPension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedTPDPension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedPost2014Pension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedPost2014Pension5050");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "TotalCurrentPension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "FundedCAY");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "UnfundedCAY");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "SpouseFundedCAY");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "TotalAccruedPension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedTPDLumpSum");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "PartnerPensionPost2014");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "TV1Pension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "TV2Pension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "TV3Pension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "CAREPensionAtDOL");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Pre2014CurrentPension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Post2014CurrentPension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Post2014CurrentPension5050");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedPre2014Pension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "TotalAccruedPensionPostComm");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "CurrentCAYPension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "CurrentCAYPartnerPension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "CAYLumpSum");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Pre08CashAtDOR");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "TotalCashAtDOR");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "SpouseProportion");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "TotalOtherPension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Post14Pen");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "SpouseUnfundedCAY");
            pData._TreeViewSelect_Snapshots(dic, true);



            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "BenefitSetShortName");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "OrganizationCode");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "UnitCode");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "Post2014NPA");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "CurrentStatus");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "Scheme5050");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "CriticalRetAge");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "TaperedRetAge");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "APCRetAge");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "Pre2008NPA");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "Post2008NPA");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "BasisFlag");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "MercerUniqueID");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "ExitMode");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "DependantType");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "PTIndicator");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "RetGroup");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "CriticalRetDate");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "TaperedRetDate");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "PensionType");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "AgeJoining");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "Size");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "AgeAtVal");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "SPA");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "ResetPay");
            pData._TreeViewSelect_Snapshots(dic, true);



            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "Click");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_SP_Snapshots_Popup(dic);

            pMain._SelectTab("Data2017");

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Home");



            #endregion


            #region Valuation & Import Data

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
            dic.Add("Name", "31.3.2017Valuation");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearEndingIn_DE", "2017");
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
            dic.Add("ServiceToOpen", "31.3.2017Valuation");
            dic.Add("CheckPopup", "False");
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
            dic.Add("DataEffectiveDate", "31/03/2017");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "ImportData");
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


            #region Baseline - Assumptions

            pMain._SelectTab("31.3.2017Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");

            pMain._SelectTab("Funding");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("MenuItem", "Use Alternative Basis Folders");
            pAssumptions._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Funding");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "4.5");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AltFund1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "5.15");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AltFund2");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "4.5");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AltFund3");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "4.5");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "CPIInflationAssumption");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CPIInflationAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2.4");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "Post88GMP");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "Post88GMP");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("VIcon", "Click");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "CPIInflationAssumption");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "RPIInflationAssumption");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "RPIInflationAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3.1");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "NHSrevaluation");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "NHSrevaluation");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("VIcon", "Click");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "CPIInflationAssumption");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("YieldCurve", "");
            dic.Add("Adjustments", "true");
            dic.Add("ForwardDuration", "");
            dic.Add("AsOfDate", "");
            dic.Add("Adjustment1Operator_cbo", "+");
            dic.Add("Adjustment1_c", "");
            dic.Add("Adjustment2Operator_cbo", "");
            dic.Add("Adjustment2_p", "");
            dic.Add("Adjustment3Operator_cbo", "");
            dic.Add("Adjustment3_c", "");
            dic.Add("ForwardDuration_txt", "");
            pInterestRate._PopVerify_YieldCurve_NL(dic);

            _gLib._MsgBox("Manual interaction", "Please click button % of Adjustment 1 and set 1.5 to its editbox");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "TeachersRevaluation");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "TeachersRevaluation");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("VIcon", "Click");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "CPIInflationAssumption");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("YieldCurve", "");
            dic.Add("Adjustments", "true");
            dic.Add("ForwardDuration", "");
            dic.Add("AsOfDate", "");
            dic.Add("Adjustment1Operator_cbo", "+");
            dic.Add("Adjustment1_c", "");
            dic.Add("Adjustment2Operator_cbo", "");
            dic.Add("Adjustment2_p", "");
            dic.Add("Adjustment3Operator_cbo", "");
            dic.Add("Adjustment3_c", "");
            dic.Add("ForwardDuration_txt", "");
            pInterestRate._PopVerify_YieldCurve_NL(dic);

            _gLib._MsgBox("Manual interaction", "Please click button % of Adjustment 1 and set 1.6 to its editbox");




            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "PoliceRevaluation");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "PoliceRevaluation");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("VIcon", "Click");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "CPIInflationAssumption");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("YieldCurve", "");
            dic.Add("Adjustments", "true");
            dic.Add("ForwardDuration", "");
            dic.Add("AsOfDate", "");
            dic.Add("Adjustment1Operator_cbo", "+");
            dic.Add("Adjustment1_c", "");
            dic.Add("Adjustment2Operator_cbo", "");
            dic.Add("Adjustment2_p", "");
            dic.Add("Adjustment3Operator_cbo", "");
            dic.Add("Adjustment3_c", "");
            dic.Add("ForwardDuration_txt", "");
            pInterestRate._PopVerify_YieldCurve_NL(dic);

            _gLib._MsgBox("Manual interaction", "Please click button % of Adjustment 1 and set 1.25 to its editbox");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("MenuItem", "Add Pay Increase");
            pAssumptions._TreeViewRightSelect(dic, "SalaryIncreaseAssumption");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryIncreaseAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustment", "true");
            dic.Add("btnV", "click");
            dic.Add("btnPercent", "");
            dic.Add("btnT", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "CPIInflationAssumption");
            dic.Add("Adjustment1_P", "");
            dic.Add("Adjustment1_txt_P", "");
            pPayIncrease._PopVerify_Adjustment(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("YieldCurve", "");
            dic.Add("Adjustments", "true");
            dic.Add("ForwardDuration", "");
            dic.Add("AsOfDate", "");
            dic.Add("Adjustment1Operator_cbo", "+");
            dic.Add("Adjustment1_c", "1.5");
            dic.Add("Adjustment2Operator_cbo", "");
            dic.Add("Adjustment2_p", "");
            dic.Add("Adjustment3Operator_cbo", "");
            dic.Add("Adjustment3_c", "");
            dic.Add("ForwardDuration_txt", "");
            pInterestRate._PopVerify_YieldCurve_NL(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("MenuItem", "Add Pay Increase");
            pAssumptions._TreeViewRightSelect(dic, "FireAndArmedForcesRevaluation");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "FireAndArmedForcesRevaluation");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustment", "");
            dic.Add("btnV", "click");
            dic.Add("btnPercent", "");
            dic.Add("btnT", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "SalaryIncreaseAssumption");
            dic.Add("Adjustment1_P", "");
            dic.Add("Adjustment1_txt_P", "");
            pPayIncrease._PopVerify_Adjustment(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("MenuItem", "Add Pay Increase");
            pAssumptions._TreeViewRightSelect(dic, "CPIRevaluationForDebts");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "CPIRevaluationForDebts");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustment", "");
            dic.Add("btnV", "click");
            dic.Add("btnPercent", "");
            dic.Add("btnT", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "CPIInflationAssumption");
            dic.Add("Adjustment1_P", "");
            dic.Add("Adjustment1_txt_P", "");
            pPayIncrease._PopVerify_Adjustment(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            pAssumptions._Collapse(dic);

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
            dic.Add("CPIRate_V", "Click");
            dic.Add("CPIRate_P", "");
            dic.Add("CPIRate_T", "");
            dic.Add("CPIRate_cbo_V", "CPIInflationAssumption");
            dic.Add("CPIRate_txt", "");
            dic.Add("CPIRate_cbo_T", "");
            dic.Add("RPIRate_V", "Click");
            dic.Add("RPIRate_P", "");
            dic.Add("RPIRate_T", "");
            dic.Add("RPIRate_cbo_V", "RPIInflationAssumption");
            dic.Add("RPIRate_txt", "");
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
            dic.Add("SalCapInc_txt", "");
            dic.Add("S148Inc_txt", "3.9");
            dic.Add("LimmGMPRate_txt", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_UK(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "Click");
            dic.Add("cboPercentMarried", "PropMarried_2011Cen_MarriedCohab");
            dic.Add("txtPercentMarried_M", "95.00");
            dic.Add("txtPercentMarried_F", "80.00");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "-3");
            dic.Add("txtDifferenceInSpouseAge_F", "3");
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
            dic.Add("PrePostCommencement", "True");
            dic.Add("PreDecrementPostCommencement", "");
            dic.Add("UnisexMortality", "");
            dic.Add("ProjectedStaticMortalit", "");
            dic.Add("GenerationalMortality", "");
            dic.Add("DisabledVsHealthy", "true");
            dic.Add("MemberVsSpouse", "true");
            pMortalityDecrement._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDecrement", "");
            dic.Add("PreCommencement", "DML08_CMI_2015_1_5pc_LGPS");
            dic.Add("PostCommencement", "SPA07_CMI_2015_1_75pc");
            dic.Add("PreDecrement_SetBack_M", "");
            dic.Add("PreDecrement_SetBack_F", "");
            dic.Add("PreDecrement_Weighting_M", "");
            dic.Add("PreDecrement_Weighting_F", "");
            dic.Add("PreCommencement_SetBack_M", "");
            dic.Add("PreCommencement_SetBack_F", "");
            dic.Add("PreCommencement_Weighting_M", "80");
            dic.Add("PreCommencement_Weighting_F", "50");
            dic.Add("PostCommencement_SetBack_M", "");
            dic.Add("PostCommencement_SetBack_F", "");
            dic.Add("PostCommencement_Weighting_M", "94");
            dic.Add("PostCommencement_Weighting_F", "81");
            pMortalityDecrement._PrePostCommencement(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "");
            dic.Add("Mortality_Setback_M", "");
            dic.Add("Mortality_Setback_F", "");
            dic.Add("Mortality_Setback_M_NL", "");
            dic.Add("Mortality_Setback_F_NL", "");
            dic.Add("Disabled", "SPA07_CMI_2015_1_75pc");
            dic.Add("Disabled_Setback_M", "4");
            dic.Add("Disabled_Setback_F", "4");
            dic.Add("Disabled_Weighting_M", "94");
            dic.Add("Disabled_Weighting_F", "81");
            dic.Add("Disabled_Setback_M_NL", "");
            dic.Add("Disabled_Setback_F_NL", "");
            dic.Add("ProjectionScale", "");
            dic.Add("ProjectToYear", "");
            dic.Add("Spouse", "SDA07_CMI_2015_1_5pc_LGPS");
            dic.Add("Spouse_Weighting_M", "102");
            dic.Add("Spouse_Weighting_F", "92");
            dic.Add("ProportionMale", "");
            dic.Add("ProportionFeMale", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);








            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "CurrentFemaleDependant");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("PrePostCommencement", "");
            dic.Add("PreDecrementPostCommencement", "");
            dic.Add("UnisexMortality", "");
            dic.Add("ProjectedStaticMortalit", "");
            dic.Add("GenerationalMortality", "");
            dic.Add("DisabledVsHealthy", "");
            dic.Add("MemberVsSpouse", "");
            pMortalityDecrement._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "SDA07_CMI_2015_1_5pc_LGPS");
            dic.Add("Mortality_Setback_M", "");
            dic.Add("Mortality_Setback_F", "");
            dic.Add("Mortality_Weighting_M", "115");
            dic.Add("Mortality_Weighting_F", "96");
            dic.Add("Mortality_Setback_M_NL", "");
            dic.Add("Mortality_Setback_F_NL", "");
            dic.Add("Disabled", "");
            dic.Add("Disabled_Setback_M", "");
            dic.Add("Disabled_Setback_F", "");
            dic.Add("Disabled_Weighting_M", "");
            dic.Add("Disabled_Weighting_F", "");
            dic.Add("Disabled_Setback_M_NL", "");
            dic.Add("Disabled_Setback_F_NL", "");
            dic.Add("ProjectionScale", "");
            dic.Add("ProjectToYear", "");
            dic.Add("Spouse", "");
            dic.Add("Spouse_Weighting_M", "");
            dic.Add("Spouse_Weighting_F", "");
            dic.Add("ProportionMale", "");
            dic.Add("ProportionFeMale", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "Click");
            dic.Add("txtLocalEligibility", "CurrentFemaleDependant");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"F\" and $emp.USC=\"RetBene\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);





            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "CurrentMaleDependants");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("PrePostCommencement", "");
            dic.Add("PreDecrementPostCommencement", "");
            dic.Add("UnisexMortality", "");
            dic.Add("ProjectedStaticMortalit", "");
            dic.Add("GenerationalMortality", "");
            dic.Add("DisabledVsHealthy", "");
            dic.Add("MemberVsSpouse", "");
            pMortalityDecrement._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "SPA07_CMI_2015_1_75pc");
            dic.Add("Mortality_Setback_M", "");
            dic.Add("Mortality_Setback_F", "");
            dic.Add("Mortality_Weighting_M", "115");
            dic.Add("Mortality_Weighting_F", "96");
            dic.Add("Mortality_Setback_M_NL", "");
            dic.Add("Mortality_Setback_F_NL", "");
            dic.Add("Disabled", "");
            dic.Add("Disabled_Setback_M", "");
            dic.Add("Disabled_Setback_F", "");
            dic.Add("Disabled_Weighting_M", "");
            dic.Add("Disabled_Weighting_F", "");
            dic.Add("Disabled_Setback_M_NL", "");
            dic.Add("Disabled_Setback_F_NL", "");
            dic.Add("ProjectionScale", "");
            dic.Add("ProjectToYear", "");
            dic.Add("Spouse", "");
            dic.Add("Spouse_Weighting_M", "");
            dic.Add("Spouse_Weighting_F", "");
            dic.Add("ProportionMale", "");
            dic.Add("ProportionFeMale", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "Click");
            dic.Add("txtLocalEligibility", "CurrentMaleDependants");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"M\" and $emp.USC=\"RetBene\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);




            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "FemalePenMembers");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("PrePostCommencement", "");
            dic.Add("PreDecrementPostCommencement", "");
            dic.Add("UnisexMortality", "");
            dic.Add("ProjectedStaticMortalit", "");
            dic.Add("GenerationalMortality", "");
            dic.Add("DisabledVsHealthy", "true");
            dic.Add("MemberVsSpouse", "true");
            pMortalityDecrement._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "SPA07_CMI_2015_1_5pc_System");
            dic.Add("Mortality_Setback_M", "");
            dic.Add("Mortality_Setback_F", "");
            dic.Add("Mortality_Weighting_M", "93");
            dic.Add("Mortality_Weighting_F", "85");
            dic.Add("Mortality_Setback_M_NL", "");
            dic.Add("Mortality_Setback_F_NL", "");
            dic.Add("Disabled", "SPA07_CMI_2015_1_5pc_System");
            dic.Add("Disabled_Setback_M", "3");
            dic.Add("Disabled_Setback_F", "3");
            dic.Add("Disabled_Weighting_M", "93");
            dic.Add("Disabled_Weighting_F", "85");
            dic.Add("Disabled_Setback_M_NL", "");
            dic.Add("Disabled_Setback_F_NL", "");
            dic.Add("ProjectionScale", "");
            dic.Add("ProjectToYear", "");
            dic.Add("Spouse", "SPA07_CMI_2015_1_75pc");
            dic.Add("Spouse_Weighting_M", "110");
            dic.Add("Spouse_Weighting_F", "100");
            dic.Add("ProportionMale", "");
            dic.Add("ProportionFeMale", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "Click");
            dic.Add("txtLocalEligibility", "FemalePenMembers");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"F\" and ($emp.USC=\"Ret\" or $emp.USC=\"RetDis\")");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);




            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "MalePenMembers");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("PrePostCommencement", "");
            dic.Add("PreDecrementPostCommencement", "");
            dic.Add("UnisexMortality", "");
            dic.Add("ProjectedStaticMortalit", "");
            dic.Add("GenerationalMortality", "");
            dic.Add("DisabledVsHealthy", "true");
            dic.Add("MemberVsSpouse", "true");
            pMortalityDecrement._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "SPA07_CMI_2015_1_75pc");
            dic.Add("Mortality_Setback_M", "");
            dic.Add("Mortality_Setback_F", "");
            dic.Add("Mortality_Weighting_M", "93");
            dic.Add("Mortality_Weighting_F", "85");
            dic.Add("Mortality_Setback_M_NL", "");
            dic.Add("Mortality_Setback_F_NL", "");
            dic.Add("Disabled", "SPA07_CMI_2015_1_75pc");
            dic.Add("Disabled_Setback_M", "3");
            dic.Add("Disabled_Setback_F", "3");
            dic.Add("Disabled_Weighting_M", "93");
            dic.Add("Disabled_Weighting_F", "85");
            dic.Add("Disabled_Setback_M_NL", "");
            dic.Add("Disabled_Setback_F_NL", "");
            dic.Add("ProjectionScale", "");
            dic.Add("ProjectToYear", "");
            dic.Add("Spouse", "SDA07_CMI_2015_1_5pc_LGPS");
            dic.Add("Spouse_Weighting_M", "110");
            dic.Add("Spouse_Weighting_F", "100");
            dic.Add("ProportionMale", "");
            dic.Add("ProportionFeMale", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "Click");
            dic.Add("txtLocalEligibility", "MalePenMembers");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"M\" and ($emp.USC=\"Ret\" or $emp.USC=\"RetDis\")");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);





            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "FemaleDefMembers");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("PrePostCommencement", "true");
            dic.Add("PreDecrementPostCommencement", "");
            dic.Add("UnisexMortality", "");
            dic.Add("ProjectedStaticMortalit", "");
            dic.Add("GenerationalMortality", "");
            dic.Add("DisabledVsHealthy", "true");
            dic.Add("MemberVsSpouse", "true");
            pMortalityDecrement._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDecrement", "");
            dic.Add("PreCommencement", "DML08_CMI_2015_1_5pc_LGPS");
            dic.Add("PostCommencement", "SPA07_CMI_2015_1_5pc_System");
            dic.Add("PreDecrement_SetBack_M", "");
            dic.Add("PreDecrement_SetBack_F", "");
            dic.Add("PreDecrement_Weighting_M", "");
            dic.Add("PreDecrement_Weighting_F", "");
            dic.Add("PreCommencement_SetBack_M", "");
            dic.Add("PreCommencement_SetBack_F", "");
            dic.Add("PreCommencement_Weighting_M", "80");
            dic.Add("PreCommencement_Weighting_F", "50");
            dic.Add("PostCommencement_SetBack_M", "");
            dic.Add("PostCommencement_SetBack_F", "");
            dic.Add("PostCommencement_Weighting_M", "120");
            dic.Add("PostCommencement_Weighting_F", "93");
            pMortalityDecrement._PrePostCommencement(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "");
            dic.Add("Mortality_Setback_M", "");
            dic.Add("Mortality_Setback_F", "");
            dic.Add("Mortality_Setback_M_NL", "");
            dic.Add("Mortality_Setback_F_NL", "");
            dic.Add("Disabled", "SPA07_CMI_2015_1_5pc_System");
            dic.Add("Disabled_Setback_M", "4");
            dic.Add("Disabled_Setback_F", "4");
            dic.Add("Disabled_Weighting_M", "120");
            dic.Add("Disabled_Weighting_F", "93");
            dic.Add("Disabled_Setback_M_NL", "");
            dic.Add("Disabled_Setback_F_NL", "");
            dic.Add("ProjectionScale", "");
            dic.Add("ProjectToYear", "");
            dic.Add("Spouse", "SPA07_CMI_2015_1_75pc");
            dic.Add("Spouse_Weighting_M", "102");
            dic.Add("Spouse_Weighting_F", "92");
            dic.Add("ProportionMale", "");
            dic.Add("ProportionFeMale", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);




            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "Click");
            dic.Add("txtLocalEligibility", "FemaleDefMembers");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"F\" and $emp.USC=\"Def\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);




            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "MaleDefMembers");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("PrePostCommencement", "true");
            dic.Add("PreDecrementPostCommencement", "");
            dic.Add("UnisexMortality", "");
            dic.Add("ProjectedStaticMortalit", "");
            dic.Add("GenerationalMortality", "");
            dic.Add("DisabledVsHealthy", "true");
            dic.Add("MemberVsSpouse", "true");
            pMortalityDecrement._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDecrement", "");
            dic.Add("PreCommencement", "DML08_CMI_2015_1_5pc_LGPS");
            dic.Add("PostCommencement", "SPA07_CMI_2015_1_75pc");
            dic.Add("PreDecrement_SetBack_M", "");
            dic.Add("PreDecrement_SetBack_F", "");
            dic.Add("PreDecrement_Weighting_M", "");
            dic.Add("PreDecrement_Weighting_F", "");
            dic.Add("PreCommencement_SetBack_M", "");
            dic.Add("PreCommencement_SetBack_F", "");
            dic.Add("PreCommencement_Weighting_M", "80");
            dic.Add("PreCommencement_Weighting_F", "50");
            dic.Add("PostCommencement_SetBack_M", "");
            dic.Add("PostCommencement_SetBack_F", "");
            dic.Add("PostCommencement_Weighting_M", "120");
            dic.Add("PostCommencement_Weighting_F", "93");
            pMortalityDecrement._PrePostCommencement(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "");
            dic.Add("Mortality_Setback_M", "");
            dic.Add("Mortality_Setback_F", "");
            dic.Add("Mortality_Setback_M_NL", "");
            dic.Add("Mortality_Setback_F_NL", "");
            dic.Add("Disabled", "SPA07_CMI_2015_1_75pc");
            dic.Add("Disabled_Setback_M", "4");
            dic.Add("Disabled_Setback_F", "4");
            dic.Add("Disabled_Weighting_M", "120");
            dic.Add("Disabled_Weighting_F", "93");
            dic.Add("Disabled_Setback_M_NL", "");
            dic.Add("Disabled_Setback_F_NL", "");
            dic.Add("ProjectionScale", "");
            dic.Add("ProjectToYear", "");
            dic.Add("Spouse", "SDA07_CMI_2015_1_5pc_LGPS");
            dic.Add("Spouse_Weighting_M", "102");
            dic.Add("Spouse_Weighting_F", "92");
            dic.Add("ProportionMale", "");
            dic.Add("ProportionFeMale", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);




            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "Click");
            dic.Add("txtLocalEligibility", "MaleDefMembers");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"M\" and $emp.USC=\"Def\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);





            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "FemaleActMembers");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("PrePostCommencement", "True");
            dic.Add("PreDecrementPostCommencement", "");
            dic.Add("UnisexMortality", "");
            dic.Add("ProjectedStaticMortalit", "");
            dic.Add("GenerationalMortality", "");
            dic.Add("DisabledVsHealthy", "true");
            dic.Add("MemberVsSpouse", "true");
            pMortalityDecrement._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDecrement", "");
            dic.Add("PreCommencement", "DML08_CMI_2015_1_5pc_LGPS");
            dic.Add("PostCommencement", "SPA07_CMI_2015_1_5pc_System");
            dic.Add("PreDecrement_SetBack_M", "");
            dic.Add("PreDecrement_SetBack_F", "");
            dic.Add("PreDecrement_Weighting_M", "");
            dic.Add("PreDecrement_Weighting_F", "");
            dic.Add("PreCommencement_SetBack_M", "");
            dic.Add("PreCommencement_SetBack_F", "");
            dic.Add("PreCommencement_Weighting_M", "80");
            dic.Add("PreCommencement_Weighting_F", "50");
            dic.Add("PostCommencement_SetBack_M", "");
            dic.Add("PostCommencement_SetBack_F", "");
            dic.Add("PostCommencement_Weighting_M", "94");
            dic.Add("PostCommencement_Weighting_F", "81");
            pMortalityDecrement._PrePostCommencement(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "");
            dic.Add("Mortality_Setback_M", "");
            dic.Add("Mortality_Setback_F", "");
            dic.Add("Mortality_Setback_M_NL", "");
            dic.Add("Mortality_Setback_F_NL", "");
            dic.Add("Disabled", "SPA07_CMI_2015_1_5pc_System");
            dic.Add("Disabled_Setback_M", "4");
            dic.Add("Disabled_Setback_F", "4");
            dic.Add("Disabled_Weighting_M", "94");
            dic.Add("Disabled_Weighting_F", "81");
            dic.Add("Disabled_Setback_M_NL", "");
            dic.Add("Disabled_Setback_F_NL", "");
            dic.Add("ProjectionScale", "");
            dic.Add("ProjectToYear", "");
            dic.Add("Spouse", "SPA07_CMI_2015_1_75pc");
            dic.Add("Spouse_Weighting_M", "102");
            dic.Add("Spouse_Weighting_F", "92");
            dic.Add("ProportionMale", "");
            dic.Add("ProportionFeMale", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "Click");
            dic.Add("txtLocalEligibility", "FemaleActMembers");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"F\" and $emp.USC=\"Act\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "MaleActMembers");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("PrePostCommencement", "True");
            dic.Add("PreDecrementPostCommencement", "");
            dic.Add("UnisexMortality", "");
            dic.Add("ProjectedStaticMortalit", "");
            dic.Add("GenerationalMortality", "");
            dic.Add("DisabledVsHealthy", "true");
            dic.Add("MemberVsSpouse", "true");
            pMortalityDecrement._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDecrement", "");
            dic.Add("PreCommencement", "DML08_CMI_2015_1_5pc_LGPS");
            dic.Add("PostCommencement", "SPA07_CMI_2015_1_75pc");
            dic.Add("PreDecrement_SetBack_M", "");
            dic.Add("PreDecrement_SetBack_F", "");
            dic.Add("PreDecrement_Weighting_M", "");
            dic.Add("PreDecrement_Weighting_F", "");
            dic.Add("PreCommencement_SetBack_M", "");
            dic.Add("PreCommencement_SetBack_F", "");
            dic.Add("PreCommencement_Weighting_M", "80");
            dic.Add("PreCommencement_Weighting_F", "50");
            dic.Add("PostCommencement_SetBack_M", "");
            dic.Add("PostCommencement_SetBack_F", "");
            dic.Add("PostCommencement_Weighting_M", "94");
            dic.Add("PostCommencement_Weighting_F", "81");
            pMortalityDecrement._PrePostCommencement(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "");
            dic.Add("Mortality_Setback_M", "");
            dic.Add("Mortality_Setback_F", "");
            dic.Add("Mortality_Setback_M_NL", "");
            dic.Add("Mortality_Setback_F_NL", "");
            dic.Add("Disabled", "SPA07_CMI_2015_1_75pc");
            dic.Add("Disabled_Setback_M", "4");
            dic.Add("Disabled_Setback_F", "4");
            dic.Add("Disabled_Weighting_M", "94");
            dic.Add("Disabled_Weighting_F", "81");
            dic.Add("Disabled_Setback_M_NL", "");
            dic.Add("Disabled_Setback_F_NL", "");
            dic.Add("ProjectionScale", "");
            dic.Add("ProjectToYear", "");
            dic.Add("Spouse", "SDA07_CMI_2015_1_5pc_LGPS");
            dic.Add("Spouse_Weighting_M", "102");
            dic.Add("Spouse_Weighting_F", "92");
            dic.Add("ProportionMale", "");
            dic.Add("ProportionFeMale", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "Click");
            dic.Add("txtLocalEligibility", "MaleActMembers");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"M\" and $emp.USC=\"Act\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("MenuItem", "Use Alternative Basis Folders");
            pAssumptions._TreeViewRightSelect(dic, "");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "Funding");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERORET");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "Funding");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "OverCRA");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "FIXRET");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "Click");
            dic.Add("txtLocalEligibility", "OverCRA");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$Age>=$emp.CriticalRetAge");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "Funding");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NotCRA65");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "LGPS_2013_RetirementDecrement");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "Click");
            dic.Add("txtLocalEligibility", "NotCRA65");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.CriticalRetAge<>65");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "AltFund1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERORET");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "AltFund1");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "OverCRA");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "FIXRET");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "Click");
            dic.Add("txtLocalEligibility", "OverCRA");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$Age>=$emp.CriticalRetAge");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "AltFund1");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NotCRA65");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "LGPS_2013_RetirementDecrement");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "Click");
            dic.Add("txtLocalEligibility", "NotCRA65");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.CriticalRetAge<>65");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "AltFund1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERORET");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "AltFund2");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "OverCRA");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "FIXRET");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "Click");
            dic.Add("txtLocalEligibility", "OverCRA");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$Age>=$emp.CriticalRetAge");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "AltFund2");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NotCRA65");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "LGPS_2013_RetirementDecrement");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "Click");
            dic.Add("txtLocalEligibility", "NotCRA65");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.CriticalRetAge<>65");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "AltFund3");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERORET");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "AltFund3");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "OverCRA");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "FIXRET");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "Click");
            dic.Add("txtLocalEligibility", "OverCRA");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$Age>=$emp.CriticalRetAge");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "AltFund3");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NotCRA65");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "LGPS_2013_RetirementDecrement");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "Click");
            dic.Add("txtLocalEligibility", "NotCRA65");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.CriticalRetAge<>65");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Other", "");
            dic.Add("Adjustments", "true");
            dic.Add("RetWithdrawDis", "LGPS_2010_Withdrawal");
            dic.Add("Service", "");
            dic.Add("AdjustmentOperator", "*");
            dic.Add("Adjustment_C", "");
            dic.Add("Adjustment_P", "");
            dic.Add("Adjustment_T", "");
            dic.Add("Adjustment_txt", "1.5");
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
            dic.Add("Other", "");
            dic.Add("Adjustments", "true");
            dic.Add("RetWithdrawDis", "LGPS_2013_IllHealth");
            dic.Add("Service", "");
            dic.Add("AdjustmentOperator", "*");
            dic.Add("Adjustment_C", "");
            dic.Add("Adjustment_P", "");
            dic.Add("Adjustment_T", "");
            dic.Add("Adjustment_txt", "0.9");
            dic.Add("Adjustment_Tcbo", "");
            dic.Add("Adjustment_Tcbo_extend", "");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Commutation");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PctOfCommutation", "50");
            pCommutation._PopVerify_Commutation(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);






            #endregion


            #region Baseline - Provisions - TrancheDefinition


            pMain._SelectTab("31.3.2017Valuation");

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
            dic.Add("Level_2", "Pension Increase Label");
            dic.Add("MenuItem", "Add Pension Increase Label");
            pAssumptions._TreeViewRightSelect(dic, "RevalCPI");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pension Increase Label");
            dic.Add("MenuItem", "Add Pension Increase Label");
            pAssumptions._TreeViewRightSelect(dic, "RevalSection148");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pension Increase Label");
            dic.Add("MenuItem", "Add Pension Increase Label");
            pAssumptions._TreeViewRightSelect(dic, "PensionIncFixed0");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pension Increase Label");
            dic.Add("MenuItem", "Add Pension Increase Label");
            pAssumptions._TreeViewRightSelect(dic, "PensionIncCPICapped3");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pension Increase Label");
            dic.Add("MenuItem", "Add Pension Increase Label");
            pAssumptions._TreeViewRightSelect(dic, "PensionIncCPI");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "FutureQualService");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "FutureQualService");
            dic.Add("Level_5", "Default");
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
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("Date", "$ValDate");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProvidedInDataField", "");
            dic.Add("ServiceEndsAt_V", "");
            dic.Add("ServiceEndsAt_C", "Click");
            dic.Add("ServiceEndsAt_cbo", "");
            dic.Add("ServiceEndsAt_txt", "");
            dic.Add("MaximumService_UseServiceCap", "");
            dic.Add("FixedDate_UseServiceCap", "31/03/2016");
            dic.Add("Date_UseServiceCap", "");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncrement_V", "");
            dic.Add("ServiceIncrement_C", "");
            dic.Add("ServiceIncrement_cbo", "");
            dic.Add("ServiceIncrement_txt", "");
            pService._PopVerify_ServiceAtValuationDate_UseServiceCap(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Pre2008ReckServ");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "Pre2008ReckServ");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.Pre2008Service");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Post2008ReckServ");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "Post2008ReckServ");
            dic.Add("Level_5", "Default");
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
            dic.Add("Function", "$emp.Post2008Service");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);




            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "DummyTrancheService");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "DummyTrancheService");
            dic.Add("MenuItem", "Add New Liability Type Folder");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "Pre2008");
            dic.Add("Solvency", "");
            dic.Add("Funding", "True");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "DummyTrancheService");
            dic.Add("Level_5", "Pre2008");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("Date", "BirthDate");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "DummyTrancheService");
            dic.Add("Level_5", "AllOthers");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "");
            dic.Add("ServiceStarts_FixedDate", "01/04/2008");
            dic.Add("Date", "#1#");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Post2014DummyQServ");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "Post2014DummyQServ");
            dic.Add("Level_5", "Default");
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
            dic.Add("CalculateExactServiceAtReitermentAge_UK", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "");
            dic.Add("ServiceStarts_FixedDate", "31/03/2016");
            dic.Add("Date", "MembershipDate1");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "Post2014DummyQServ");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Member5050");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "True");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            dic.Add("ForInternationalAccounting_DE", "");
            dic.Add("ForTrade_DE", "");
            dic.Add("CalculateExactServiceAtReitermentAge_UK", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "Click");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "");
            dic.Add("ServiceStarts_FixedDate", "31/03/2016");
            dic.Add("Date", "MembershipDate1");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "Click");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "0.5");
            pService._PopVerify_RulesBasedService(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Scheme5050=\"Y\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);




            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Post2014IllHealthServ");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "Post2014IllHealthServ");
            dic.Add("Level_5", "Default");
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
            dic.Add("Function", "(Max($emp.Post2014NPA, 65)-($Age[$ExitAge]+($ExactValAge-$ValAge)))*0.9");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Post2014DISServ");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "Post2014DISServ");
            dic.Add("Level_5", "Default");
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
            dic.Add("Function", "(Max($emp.Post2014NPA, 65)-($Age[$ExitAge]+($ExactValAge-$ValAge)))");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            pAssumptions._SelectTab("Provisions");




            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            pAssumptions._TreeViewSelect(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active_Service", "DummyTrancheService");
            dic.Add("Deferred_Service", "DummyTrancheService");
            dic.Add("Deferred_ApplyTrancheSplits", "");
            dic.Add("Pensioner_Service", "DummyTrancheService");
            dic.Add("Pensioner_ApplyTrancheSplits", "");
            pTrancheDefinition._PopVerify_Main(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            dic.Add("Level_4", "Pre1990");
            dic.Add("MenuItem", "Rename");
            pAssumptions._TreeViewRightSelect(dic, "Pre14CRAPenstion");



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            pAssumptions._TreeViewSelect(dic, true);



            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", 1, "Pre14CRAPenstion", "Edit Tranche");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "True");
            dic.Add("Pensioner", "");
            dic.Add("StartDate", "");
            dic.Add("EndDate", "31/03/2008");
            dic.Add("GMPApplies", "True");
            dic.Add("Active_PPFTranche", "#1#");
            dic.Add("Active_MalePPF_V", "");
            dic.Add("Active_MalePPF_C", "");
            dic.Add("Active_FemalePPF_V", "");
            dic.Add("Active_FemalePPF_C", "");
            dic.Add("Active_MaleSolvency_V", "");
            dic.Add("Active_MaleSolvency_C", "");
            dic.Add("Active_FemaleSolvency_V", "");
            dic.Add("Active_FemaleSolvency_C", "");
            dic.Add("Active_FullySalaryRelated", "");
            dic.Add("Active_MalePPF_cbo", "");
            dic.Add("Active_MalePPF_txt", "");
            dic.Add("Active_FemalePPF_cbo", "");
            dic.Add("Active_FemalePPF_txt", "");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "");
            dic.Add("Def_PPFTranche", "#1#");
            dic.Add("Def_MalePPF_V", "");
            dic.Add("Def_MalePPF_C", "");
            dic.Add("Def_FemalePPF_V", "");
            dic.Add("Def_FemalePPF_C", "");
            dic.Add("Def_MaleSolvency_V", "");
            dic.Add("Def_MaleSolvency_C", "");
            dic.Add("Def_FemaleSolvency_V", "");
            dic.Add("Def_FemaleSolvency_C", "");
            dic.Add("Def_MalePPF_cbo", "");
            dic.Add("Def_MalePPF_txt", "");
            dic.Add("Def_FemalePPF_cbo", "");
            dic.Add("Def_FemalePPF_txt", "");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "");
            dic.Add("Pen_PPFTranche", "");
            dic.Add("Pen_MalePPF_V", "");
            dic.Add("Pen_MalePPF_C", "");
            dic.Add("Pen_FemalePPF_V", "");
            dic.Add("Pen_FemalePPF_C", "");
            dic.Add("Pen_MaleSolvency_V", "");
            dic.Add("Pen_MaleSolvency_C", "");
            dic.Add("Pen_FemaleSolvency_V", "");
            dic.Add("Pen_FemaleSolvency_C", "");
            dic.Add("Pen_MalePPF_cbo", "");
            dic.Add("Pen_MalePPF_txt", "");
            dic.Add("Pen_FemalePPF_cbo", "");
            dic.Add("Pen_FemalePPF_txt", "");
            dic.Add("Pen_MaleSolvency_cbo", "");
            dic.Add("Pen_MaleSolvency_txt", "");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);




            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            dic.Add("Level_4", "Pst1990Pre1997");
            dic.Add("MenuItem", "Rename");
            pAssumptions._TreeViewRightSelect(dic, "Pre14TPAPenstion");


            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", 2, "Pre14TPAPenstion", "Edit Tranche");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "True");
            dic.Add("Pensioner", "");
            dic.Add("StartDate", "01/04/2008");
            dic.Add("EndDate", "31/03/2012");
            dic.Add("GMPApplies", "false");
            dic.Add("Active_PPFTranche", "#1#");
            dic.Add("Active_MalePPF_V", "");
            dic.Add("Active_MalePPF_C", "");
            dic.Add("Active_FemalePPF_V", "");
            dic.Add("Active_FemalePPF_C", "");
            dic.Add("Active_MaleSolvency_V", "");
            dic.Add("Active_MaleSolvency_C", "");
            dic.Add("Active_FemaleSolvency_V", "");
            dic.Add("Active_FemaleSolvency_C", "");
            dic.Add("Active_FullySalaryRelated", "");
            dic.Add("Active_MalePPF_cbo", "");
            dic.Add("Active_MalePPF_txt", "");
            dic.Add("Active_FemalePPF_cbo", "");
            dic.Add("Active_FemalePPF_txt", "");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "");
            dic.Add("Def_PPFTranche", "#1#");
            dic.Add("Def_MalePPF_V", "");
            dic.Add("Def_MalePPF_C", "");
            dic.Add("Def_FemalePPF_V", "");
            dic.Add("Def_FemalePPF_C", "");
            dic.Add("Def_MaleSolvency_V", "");
            dic.Add("Def_MaleSolvency_C", "");
            dic.Add("Def_FemaleSolvency_V", "");
            dic.Add("Def_FemaleSolvency_C", "");
            dic.Add("Def_MalePPF_cbo", "");
            dic.Add("Def_MalePPF_txt", "");
            dic.Add("Def_FemalePPF_cbo", "");
            dic.Add("Def_FemalePPF_txt", "");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "");
            dic.Add("Pen_PPFTranche", "");
            dic.Add("Pen_MalePPF_V", "");
            dic.Add("Pen_MalePPF_C", "");
            dic.Add("Pen_FemalePPF_V", "");
            dic.Add("Pen_FemalePPF_C", "");
            dic.Add("Pen_MaleSolvency_V", "");
            dic.Add("Pen_MaleSolvency_C", "");
            dic.Add("Pen_FemaleSolvency_V", "");
            dic.Add("Pen_FemaleSolvency_C", "");
            dic.Add("Pen_MalePPF_cbo", "");
            dic.Add("Pen_MalePPF_txt", "");
            dic.Add("Pen_FemalePPF_cbo", "");
            dic.Add("Pen_FemalePPF_txt", "");
            dic.Add("Pen_MaleSolvency_cbo", "");
            dic.Add("Pen_MaleSolvency_txt", "");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);





            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            dic.Add("Level_4", "Pst1997Pre2005");
            dic.Add("MenuItem", "Rename");
            pAssumptions._TreeViewRightSelect(dic, "Pre14Age65Penstion");


            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", 2, "Pre14Age65Penstion", "Edit Tranche");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "True");
            dic.Add("Pensioner", "False");
            dic.Add("StartDate", "01/04/2012");
            dic.Add("EndDate", "29/03/2014");
            dic.Add("GMPApplies", "false");
            dic.Add("Active_PPFTranche", "#1#");
            dic.Add("Active_MalePPF_V", "");
            dic.Add("Active_MalePPF_C", "");
            dic.Add("Active_FemalePPF_V", "");
            dic.Add("Active_FemalePPF_C", "");
            dic.Add("Active_MaleSolvency_V", "");
            dic.Add("Active_MaleSolvency_C", "");
            dic.Add("Active_FemaleSolvency_V", "");
            dic.Add("Active_FemaleSolvency_C", "");
            dic.Add("Active_FullySalaryRelated", "");
            dic.Add("Active_MalePPF_cbo", "");
            dic.Add("Active_MalePPF_txt", "");
            dic.Add("Active_FemalePPF_cbo", "");
            dic.Add("Active_FemalePPF_txt", "");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "");
            dic.Add("Def_PPFTranche", "#1#");
            dic.Add("Def_MalePPF_V", "");
            dic.Add("Def_MalePPF_C", "");
            dic.Add("Def_FemalePPF_V", "");
            dic.Add("Def_FemalePPF_C", "");
            dic.Add("Def_MaleSolvency_V", "");
            dic.Add("Def_MaleSolvency_C", "");
            dic.Add("Def_FemaleSolvency_V", "");
            dic.Add("Def_FemaleSolvency_C", "");
            dic.Add("Def_MalePPF_cbo", "");
            dic.Add("Def_MalePPF_txt", "");
            dic.Add("Def_FemalePPF_cbo", "");
            dic.Add("Def_FemalePPF_txt", "");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "");
            dic.Add("Pen_PPFTranche", "");
            dic.Add("Pen_MalePPF_V", "");
            dic.Add("Pen_MalePPF_C", "");
            dic.Add("Pen_FemalePPF_V", "");
            dic.Add("Pen_FemalePPF_C", "");
            dic.Add("Pen_MaleSolvency_V", "");
            dic.Add("Pen_MaleSolvency_C", "");
            dic.Add("Pen_FemaleSolvency_V", "");
            dic.Add("Pen_FemaleSolvency_C", "");
            dic.Add("Pen_MalePPF_cbo", "");
            dic.Add("Pen_MalePPF_txt", "");
            dic.Add("Pen_FemalePPF_cbo", "");
            dic.Add("Pen_FemalePPF_txt", "");
            dic.Add("Pen_MaleSolvency_cbo", "");
            dic.Add("Pen_MaleSolvency_txt", "");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            dic.Add("Level_4", "Pst2005Pre2009");
            dic.Add("MenuItem", "Rename");
            pAssumptions._TreeViewRightSelect(dic, "PensionDebits");


            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", 2, "PensionDebits", "Edit Tranche");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "True");
            dic.Add("Pensioner", "False");
            dic.Add("StartDate", "30/03/2014");
            dic.Add("EndDate", "31/03/2014");
            dic.Add("GMPApplies", "false");
            dic.Add("Active_PPFTranche", "#1#");
            dic.Add("Active_MalePPF_V", "");
            dic.Add("Active_MalePPF_C", "");
            dic.Add("Active_FemalePPF_V", "");
            dic.Add("Active_FemalePPF_C", "");
            dic.Add("Active_MaleSolvency_V", "");
            dic.Add("Active_MaleSolvency_C", "");
            dic.Add("Active_FemaleSolvency_V", "");
            dic.Add("Active_FemaleSolvency_C", "");
            dic.Add("Active_FullySalaryRelated", "");
            dic.Add("Active_MalePPF_cbo", "");
            dic.Add("Active_MalePPF_txt", "");
            dic.Add("Active_FemalePPF_cbo", "");
            dic.Add("Active_FemalePPF_txt", "");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "");
            dic.Add("Def_PPFTranche", "#1#");
            dic.Add("Def_MalePPF_V", "");
            dic.Add("Def_MalePPF_C", "");
            dic.Add("Def_FemalePPF_V", "");
            dic.Add("Def_FemalePPF_C", "");
            dic.Add("Def_MaleSolvency_V", "");
            dic.Add("Def_MaleSolvency_C", "");
            dic.Add("Def_FemaleSolvency_V", "");
            dic.Add("Def_FemaleSolvency_C", "");
            dic.Add("Def_MalePPF_cbo", "");
            dic.Add("Def_MalePPF_txt", "");
            dic.Add("Def_FemalePPF_cbo", "");
            dic.Add("Def_FemalePPF_txt", "");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "");
            dic.Add("Pen_PPFTranche", "");
            dic.Add("Pen_MalePPF_V", "");
            dic.Add("Pen_MalePPF_C", "");
            dic.Add("Pen_FemalePPF_V", "");
            dic.Add("Pen_FemalePPF_C", "");
            dic.Add("Pen_MaleSolvency_V", "");
            dic.Add("Pen_MaleSolvency_C", "");
            dic.Add("Pen_FemaleSolvency_V", "");
            dic.Add("Pen_FemaleSolvency_C", "");
            dic.Add("Pen_MalePPF_cbo", "");
            dic.Add("Pen_MalePPF_txt", "");
            dic.Add("Pen_FemalePPF_cbo", "");
            dic.Add("Pen_FemalePPF_txt", "");
            dic.Add("Pen_MaleSolvency_cbo", "");
            dic.Add("Pen_MaleSolvency_txt", "");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);






            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            dic.Add("Level_4", "Pst2009");
            dic.Add("MenuItem", "Rename");
            pAssumptions._TreeViewRightSelect(dic, "ArmedForcesSchemePension");


            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", 3, "ArmedForcesSchemePension", "Edit Tranche");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "False");
            dic.Add("Pensioner", "False");
            dic.Add("StartDate", "01/04/2014");
            dic.Add("EndDate", "02/04/2014");
            dic.Add("GMPApplies", "false");
            dic.Add("Active_PPFTranche", "#1#");
            dic.Add("Active_MalePPF_V", "");
            dic.Add("Active_MalePPF_C", "");
            dic.Add("Active_FemalePPF_V", "");
            dic.Add("Active_FemalePPF_C", "");
            dic.Add("Active_MaleSolvency_V", "");
            dic.Add("Active_MaleSolvency_C", "");
            dic.Add("Active_FemaleSolvency_V", "");
            dic.Add("Active_FemaleSolvency_C", "");
            dic.Add("Active_FullySalaryRelated", "");
            dic.Add("Active_MalePPF_cbo", "");
            dic.Add("Active_MalePPF_txt", "");
            dic.Add("Active_FemalePPF_cbo", "");
            dic.Add("Active_FemalePPF_txt", "");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "");
            dic.Add("Def_PPFTranche", "");
            dic.Add("Def_MalePPF_V", "");
            dic.Add("Def_MalePPF_C", "");
            dic.Add("Def_FemalePPF_V", "");
            dic.Add("Def_FemalePPF_C", "");
            dic.Add("Def_MaleSolvency_V", "");
            dic.Add("Def_MaleSolvency_C", "");
            dic.Add("Def_FemaleSolvency_V", "");
            dic.Add("Def_FemaleSolvency_C", "");
            dic.Add("Def_MalePPF_cbo", "");
            dic.Add("Def_MalePPF_txt", "");
            dic.Add("Def_FemalePPF_cbo", "");
            dic.Add("Def_FemalePPF_txt", "");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "");
            dic.Add("Pen_PPFTranche", "");
            dic.Add("Pen_MalePPF_V", "");
            dic.Add("Pen_MalePPF_C", "");
            dic.Add("Pen_FemalePPF_V", "");
            dic.Add("Pen_FemalePPF_C", "");
            dic.Add("Pen_MaleSolvency_V", "");
            dic.Add("Pen_MaleSolvency_C", "");
            dic.Add("Pen_FemaleSolvency_V", "");
            dic.Add("Pen_FemaleSolvency_C", "");
            dic.Add("Pen_MalePPF_cbo", "");
            dic.Add("Pen_MalePPF_txt", "");
            dic.Add("Pen_FemalePPF_cbo", "");
            dic.Add("Pen_FemalePPF_txt", "");
            dic.Add("Pen_MaleSolvency_cbo", "");
            dic.Add("Pen_MaleSolvency_txt", "");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);





            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            dic.Add("Level_4", "Pre1997");
            dic.Add("MenuItem", "Rename");
            pAssumptions._TreeViewRightSelect(dic, "CivilServiceSchemePension");


            pTrancheDefinition._DefinitionFPGrid_RightSelect("Pensioner", 1, "CivilServiceSchemePension", "Edit Tranche");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "False");
            dic.Add("Pensioner", "False");
            dic.Add("StartDate", "03/04/2014");
            dic.Add("EndDate", "04/04/2014");
            dic.Add("GMPApplies", "false");
            dic.Add("Active_PPFTranche", "#1#");
            dic.Add("Active_MalePPF_V", "");
            dic.Add("Active_MalePPF_C", "");
            dic.Add("Active_FemalePPF_V", "");
            dic.Add("Active_FemalePPF_C", "");
            dic.Add("Active_MaleSolvency_V", "");
            dic.Add("Active_MaleSolvency_C", "");
            dic.Add("Active_FemaleSolvency_V", "");
            dic.Add("Active_FemaleSolvency_C", "");
            dic.Add("Active_FullySalaryRelated", "");
            dic.Add("Active_MalePPF_cbo", "");
            dic.Add("Active_MalePPF_txt", "");
            dic.Add("Active_FemalePPF_cbo", "");
            dic.Add("Active_FemalePPF_txt", "");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "");
            dic.Add("Def_PPFTranche", "");
            dic.Add("Def_MalePPF_V", "");
            dic.Add("Def_MalePPF_C", "");
            dic.Add("Def_FemalePPF_V", "");
            dic.Add("Def_FemalePPF_C", "");
            dic.Add("Def_MaleSolvency_V", "");
            dic.Add("Def_MaleSolvency_C", "");
            dic.Add("Def_FemaleSolvency_V", "");
            dic.Add("Def_FemaleSolvency_C", "");
            dic.Add("Def_MalePPF_cbo", "");
            dic.Add("Def_MalePPF_txt", "");
            dic.Add("Def_FemalePPF_cbo", "");
            dic.Add("Def_FemalePPF_txt", "");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "");
            dic.Add("Pen_PPFTranche", "");
            dic.Add("Pen_MalePPF_V", "");
            dic.Add("Pen_MalePPF_C", "");
            dic.Add("Pen_FemalePPF_V", "");
            dic.Add("Pen_FemalePPF_C", "");
            dic.Add("Pen_MaleSolvency_V", "");
            dic.Add("Pen_MaleSolvency_C", "");
            dic.Add("Pen_FemaleSolvency_V", "");
            dic.Add("Pen_FemaleSolvency_C", "");
            dic.Add("Pen_MalePPF_cbo", "");
            dic.Add("Pen_MalePPF_txt", "");
            dic.Add("Pen_FemalePPF_cbo", "");
            dic.Add("Pen_FemalePPF_txt", "");
            dic.Add("Pen_MaleSolvency_cbo", "");
            dic.Add("Pen_MaleSolvency_txt", "");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);





            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", "Add new Tranche");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "FirefighterSchemePension");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "");
            dic.Add("StartDate", "05/04/2014");
            dic.Add("EndDate", "06/04/2014");
            dic.Add("GMPApplies", "false");
            dic.Add("Active_PPFTranche", "");
            dic.Add("Active_MalePPF_V", "");
            dic.Add("Active_MalePPF_C", "");
            dic.Add("Active_FemalePPF_V", "");
            dic.Add("Active_FemalePPF_C", "");
            dic.Add("Active_MaleSolvency_V", "");
            dic.Add("Active_MaleSolvency_C", "");
            dic.Add("Active_FemaleSolvency_V", "");
            dic.Add("Active_FemaleSolvency_C", "");
            dic.Add("Active_FullySalaryRelated", "");
            dic.Add("Active_MalePPF_cbo", "");
            dic.Add("Active_MalePPF_txt", "");
            dic.Add("Active_FemalePPF_cbo", "");
            dic.Add("Active_FemalePPF_txt", "");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "");
            dic.Add("Def_PPFTranche", "");
            dic.Add("Def_MalePPF_V", "");
            dic.Add("Def_MalePPF_C", "");
            dic.Add("Def_FemalePPF_V", "");
            dic.Add("Def_FemalePPF_C", "");
            dic.Add("Def_MaleSolvency_V", "");
            dic.Add("Def_MaleSolvency_C", "");
            dic.Add("Def_FemaleSolvency_V", "");
            dic.Add("Def_FemaleSolvency_C", "");
            dic.Add("Def_MalePPF_cbo", "");
            dic.Add("Def_MalePPF_txt", "");
            dic.Add("Def_FemalePPF_cbo", "");
            dic.Add("Def_FemalePPF_txt", "");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "");
            dic.Add("Pen_PPFTranche", "");
            dic.Add("Pen_MalePPF_V", "");
            dic.Add("Pen_MalePPF_C", "");
            dic.Add("Pen_FemalePPF_V", "");
            dic.Add("Pen_FemalePPF_C", "");
            dic.Add("Pen_MaleSolvency_V", "");
            dic.Add("Pen_MaleSolvency_C", "");
            dic.Add("Pen_FemaleSolvency_V", "");
            dic.Add("Pen_FemaleSolvency_C", "");
            dic.Add("Pen_MalePPF_cbo", "");
            dic.Add("Pen_MalePPF_txt", "");
            dic.Add("Pen_FemalePPF_cbo", "");
            dic.Add("Pen_FemalePPF_txt", "");
            dic.Add("Pen_MaleSolvency_cbo", "");
            dic.Add("Pen_MaleSolvency_txt", "");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);





            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", "Add new Tranche");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "NHSSchemePension");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "");
            dic.Add("StartDate", "07/04/2014");
            dic.Add("EndDate", "08/04/2014");
            dic.Add("GMPApplies", "false");
            dic.Add("Active_PPFTranche", "");
            dic.Add("Active_MalePPF_V", "");
            dic.Add("Active_MalePPF_C", "");
            dic.Add("Active_FemalePPF_V", "");
            dic.Add("Active_FemalePPF_C", "");
            dic.Add("Active_MaleSolvency_V", "");
            dic.Add("Active_MaleSolvency_C", "");
            dic.Add("Active_FemaleSolvency_V", "");
            dic.Add("Active_FemaleSolvency_C", "");
            dic.Add("Active_FullySalaryRelated", "");
            dic.Add("Active_MalePPF_cbo", "");
            dic.Add("Active_MalePPF_txt", "");
            dic.Add("Active_FemalePPF_cbo", "");
            dic.Add("Active_FemalePPF_txt", "");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "");
            dic.Add("Def_PPFTranche", "");
            dic.Add("Def_MalePPF_V", "");
            dic.Add("Def_MalePPF_C", "");
            dic.Add("Def_FemalePPF_V", "");
            dic.Add("Def_FemalePPF_C", "");
            dic.Add("Def_MaleSolvency_V", "");
            dic.Add("Def_MaleSolvency_C", "");
            dic.Add("Def_FemaleSolvency_V", "");
            dic.Add("Def_FemaleSolvency_C", "");
            dic.Add("Def_MalePPF_cbo", "");
            dic.Add("Def_MalePPF_txt", "");
            dic.Add("Def_FemalePPF_cbo", "");
            dic.Add("Def_FemalePPF_txt", "");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "");
            dic.Add("Pen_PPFTranche", "");
            dic.Add("Pen_MalePPF_V", "");
            dic.Add("Pen_MalePPF_C", "");
            dic.Add("Pen_FemalePPF_V", "");
            dic.Add("Pen_FemalePPF_C", "");
            dic.Add("Pen_MaleSolvency_V", "");
            dic.Add("Pen_MaleSolvency_C", "");
            dic.Add("Pen_FemaleSolvency_V", "");
            dic.Add("Pen_FemaleSolvency_C", "");
            dic.Add("Pen_MalePPF_cbo", "");
            dic.Add("Pen_MalePPF_txt", "");
            dic.Add("Pen_FemalePPF_cbo", "");
            dic.Add("Pen_FemalePPF_txt", "");
            dic.Add("Pen_MaleSolvency_cbo", "");
            dic.Add("Pen_MaleSolvency_txt", "");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);



            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", "Add new Tranche");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "PoliceSchemePension");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "");
            dic.Add("StartDate", "09/04/2014");
            dic.Add("EndDate", "10/04/2014");
            dic.Add("GMPApplies", "false");
            dic.Add("Active_PPFTranche", "");
            dic.Add("Active_MalePPF_V", "");
            dic.Add("Active_MalePPF_C", "");
            dic.Add("Active_FemalePPF_V", "");
            dic.Add("Active_FemalePPF_C", "");
            dic.Add("Active_MaleSolvency_V", "");
            dic.Add("Active_MaleSolvency_C", "");
            dic.Add("Active_FemaleSolvency_V", "");
            dic.Add("Active_FemaleSolvency_C", "");
            dic.Add("Active_FullySalaryRelated", "");
            dic.Add("Active_MalePPF_cbo", "");
            dic.Add("Active_MalePPF_txt", "");
            dic.Add("Active_FemalePPF_cbo", "");
            dic.Add("Active_FemalePPF_txt", "");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "");
            dic.Add("Def_PPFTranche", "");
            dic.Add("Def_MalePPF_V", "");
            dic.Add("Def_MalePPF_C", "");
            dic.Add("Def_FemalePPF_V", "");
            dic.Add("Def_FemalePPF_C", "");
            dic.Add("Def_MaleSolvency_V", "");
            dic.Add("Def_MaleSolvency_C", "");
            dic.Add("Def_FemaleSolvency_V", "");
            dic.Add("Def_FemaleSolvency_C", "");
            dic.Add("Def_MalePPF_cbo", "");
            dic.Add("Def_MalePPF_txt", "");
            dic.Add("Def_FemalePPF_cbo", "");
            dic.Add("Def_FemalePPF_txt", "");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "");
            dic.Add("Pen_PPFTranche", "");
            dic.Add("Pen_MalePPF_V", "");
            dic.Add("Pen_MalePPF_C", "");
            dic.Add("Pen_FemalePPF_V", "");
            dic.Add("Pen_FemalePPF_C", "");
            dic.Add("Pen_MaleSolvency_V", "");
            dic.Add("Pen_MaleSolvency_C", "");
            dic.Add("Pen_FemaleSolvency_V", "");
            dic.Add("Pen_FemaleSolvency_C", "");
            dic.Add("Pen_MalePPF_cbo", "");
            dic.Add("Pen_MalePPF_txt", "");
            dic.Add("Pen_FemalePPF_cbo", "");
            dic.Add("Pen_FemalePPF_txt", "");
            dic.Add("Pen_MaleSolvency_cbo", "");
            dic.Add("Pen_MaleSolvency_txt", "");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);


            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", "Add new Tranche");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "TeachersSchemePension");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "");
            dic.Add("StartDate", "11/04/2014");
            dic.Add("EndDate", "12/04/2014");
            dic.Add("GMPApplies", "false");
            dic.Add("Active_PPFTranche", "");
            dic.Add("Active_MalePPF_V", "");
            dic.Add("Active_MalePPF_C", "");
            dic.Add("Active_FemalePPF_V", "");
            dic.Add("Active_FemalePPF_C", "");
            dic.Add("Active_MaleSolvency_V", "");
            dic.Add("Active_MaleSolvency_C", "");
            dic.Add("Active_FemaleSolvency_V", "");
            dic.Add("Active_FemaleSolvency_C", "");
            dic.Add("Active_FullySalaryRelated", "");
            dic.Add("Active_MalePPF_cbo", "");
            dic.Add("Active_MalePPF_txt", "");
            dic.Add("Active_FemalePPF_cbo", "");
            dic.Add("Active_FemalePPF_txt", "");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "");
            dic.Add("Def_PPFTranche", "");
            dic.Add("Def_MalePPF_V", "");
            dic.Add("Def_MalePPF_C", "");
            dic.Add("Def_FemalePPF_V", "");
            dic.Add("Def_FemalePPF_C", "");
            dic.Add("Def_MaleSolvency_V", "");
            dic.Add("Def_MaleSolvency_C", "");
            dic.Add("Def_FemaleSolvency_V", "");
            dic.Add("Def_FemaleSolvency_C", "");
            dic.Add("Def_MalePPF_cbo", "");
            dic.Add("Def_MalePPF_txt", "");
            dic.Add("Def_FemalePPF_cbo", "");
            dic.Add("Def_FemalePPF_txt", "");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "");
            dic.Add("Pen_PPFTranche", "");
            dic.Add("Pen_MalePPF_V", "");
            dic.Add("Pen_MalePPF_C", "");
            dic.Add("Pen_FemalePPF_V", "");
            dic.Add("Pen_FemalePPF_C", "");
            dic.Add("Pen_MaleSolvency_V", "");
            dic.Add("Pen_MaleSolvency_C", "");
            dic.Add("Pen_FemaleSolvency_V", "");
            dic.Add("Pen_FemaleSolvency_C", "");
            dic.Add("Pen_MalePPF_cbo", "");
            dic.Add("Pen_MalePPF_txt", "");
            dic.Add("Pen_FemalePPF_cbo", "");
            dic.Add("Pen_FemalePPF_txt", "");
            dic.Add("Pen_MaleSolvency_cbo", "");
            dic.Add("Pen_MaleSolvency_txt", "");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);



            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", "Add new Tranche");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "ARCpensionLessDebt");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "");
            dic.Add("StartDate", "13/04/2014");
            dic.Add("EndDate", "14/04/2014");
            dic.Add("GMPApplies", "false");
            dic.Add("Active_PPFTranche", "");
            dic.Add("Active_MalePPF_V", "");
            dic.Add("Active_MalePPF_C", "");
            dic.Add("Active_FemalePPF_V", "");
            dic.Add("Active_FemalePPF_C", "");
            dic.Add("Active_MaleSolvency_V", "");
            dic.Add("Active_MaleSolvency_C", "");
            dic.Add("Active_FemaleSolvency_V", "");
            dic.Add("Active_FemaleSolvency_C", "");
            dic.Add("Active_FullySalaryRelated", "");
            dic.Add("Active_MalePPF_cbo", "");
            dic.Add("Active_MalePPF_txt", "");
            dic.Add("Active_FemalePPF_cbo", "");
            dic.Add("Active_FemalePPF_txt", "");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "");
            dic.Add("Def_PPFTranche", "");
            dic.Add("Def_MalePPF_V", "");
            dic.Add("Def_MalePPF_C", "");
            dic.Add("Def_FemalePPF_V", "");
            dic.Add("Def_FemalePPF_C", "");
            dic.Add("Def_MaleSolvency_V", "");
            dic.Add("Def_MaleSolvency_C", "");
            dic.Add("Def_FemaleSolvency_V", "");
            dic.Add("Def_FemaleSolvency_C", "");
            dic.Add("Def_MalePPF_cbo", "");
            dic.Add("Def_MalePPF_txt", "");
            dic.Add("Def_FemalePPF_cbo", "");
            dic.Add("Def_FemalePPF_txt", "");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "");
            dic.Add("Pen_PPFTranche", "");
            dic.Add("Pen_MalePPF_V", "");
            dic.Add("Pen_MalePPF_C", "");
            dic.Add("Pen_FemalePPF_V", "");
            dic.Add("Pen_FemalePPF_C", "");
            dic.Add("Pen_MaleSolvency_V", "");
            dic.Add("Pen_MaleSolvency_C", "");
            dic.Add("Pen_FemaleSolvency_V", "");
            dic.Add("Pen_FemaleSolvency_C", "");
            dic.Add("Pen_MalePPF_cbo", "");
            dic.Add("Pen_MalePPF_txt", "");
            dic.Add("Pen_FemalePPF_cbo", "");
            dic.Add("Pen_FemalePPF_txt", "");
            dic.Add("Pen_MaleSolvency_cbo", "");
            dic.Add("Pen_MaleSolvency_txt", "");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);





            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", "Add new Tranche");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "EAPpension");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "");
            dic.Add("StartDate", "15/04/2014");
            dic.Add("EndDate", "16/04/2014");
            dic.Add("GMPApplies", "false");
            dic.Add("Active_PPFTranche", "");
            dic.Add("Active_MalePPF_V", "");
            dic.Add("Active_MalePPF_C", "");
            dic.Add("Active_FemalePPF_V", "");
            dic.Add("Active_FemalePPF_C", "");
            dic.Add("Active_MaleSolvency_V", "");
            dic.Add("Active_MaleSolvency_C", "");
            dic.Add("Active_FemaleSolvency_V", "");
            dic.Add("Active_FemaleSolvency_C", "");
            dic.Add("Active_FullySalaryRelated", "");
            dic.Add("Active_MalePPF_cbo", "");
            dic.Add("Active_MalePPF_txt", "");
            dic.Add("Active_FemalePPF_cbo", "");
            dic.Add("Active_FemalePPF_txt", "");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "");
            dic.Add("Def_PPFTranche", "");
            dic.Add("Def_MalePPF_V", "");
            dic.Add("Def_MalePPF_C", "");
            dic.Add("Def_FemalePPF_V", "");
            dic.Add("Def_FemalePPF_C", "");
            dic.Add("Def_MaleSolvency_V", "");
            dic.Add("Def_MaleSolvency_C", "");
            dic.Add("Def_FemaleSolvency_V", "");
            dic.Add("Def_FemaleSolvency_C", "");
            dic.Add("Def_MalePPF_cbo", "");
            dic.Add("Def_MalePPF_txt", "");
            dic.Add("Def_FemalePPF_cbo", "");
            dic.Add("Def_FemalePPF_txt", "");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "");
            dic.Add("Pen_PPFTranche", "");
            dic.Add("Pen_MalePPF_V", "");
            dic.Add("Pen_MalePPF_C", "");
            dic.Add("Pen_FemalePPF_V", "");
            dic.Add("Pen_FemalePPF_C", "");
            dic.Add("Pen_MaleSolvency_V", "");
            dic.Add("Pen_MaleSolvency_C", "");
            dic.Add("Pen_FemaleSolvency_V", "");
            dic.Add("Pen_FemaleSolvency_C", "");
            dic.Add("Pen_MalePPF_cbo", "");
            dic.Add("Pen_MalePPF_txt", "");
            dic.Add("Pen_FemalePPF_cbo", "");
            dic.Add("Pen_FemalePPF_txt", "");
            dic.Add("Pen_MaleSolvency_cbo", "");
            dic.Add("Pen_MaleSolvency_txt", "");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);




            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", "Add new Tranche");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "APCpension");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "");
            dic.Add("StartDate", "17/04/2014");
            dic.Add("EndDate", "18/04/2014");
            dic.Add("GMPApplies", "false");
            dic.Add("Active_PPFTranche", "");
            dic.Add("Active_MalePPF_V", "");
            dic.Add("Active_MalePPF_C", "");
            dic.Add("Active_FemalePPF_V", "");
            dic.Add("Active_FemalePPF_C", "");
            dic.Add("Active_MaleSolvency_V", "");
            dic.Add("Active_MaleSolvency_C", "");
            dic.Add("Active_FemaleSolvency_V", "");
            dic.Add("Active_FemaleSolvency_C", "");
            dic.Add("Active_FullySalaryRelated", "");
            dic.Add("Active_MalePPF_cbo", "");
            dic.Add("Active_MalePPF_txt", "");
            dic.Add("Active_FemalePPF_cbo", "");
            dic.Add("Active_FemalePPF_txt", "");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "");
            dic.Add("Def_PPFTranche", "");
            dic.Add("Def_MalePPF_V", "");
            dic.Add("Def_MalePPF_C", "");
            dic.Add("Def_FemalePPF_V", "");
            dic.Add("Def_FemalePPF_C", "");
            dic.Add("Def_MaleSolvency_V", "");
            dic.Add("Def_MaleSolvency_C", "");
            dic.Add("Def_FemaleSolvency_V", "");
            dic.Add("Def_FemaleSolvency_C", "");
            dic.Add("Def_MalePPF_cbo", "");
            dic.Add("Def_MalePPF_txt", "");
            dic.Add("Def_FemalePPF_cbo", "");
            dic.Add("Def_FemalePPF_txt", "");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "");
            dic.Add("Pen_PPFTranche", "");
            dic.Add("Pen_MalePPF_V", "");
            dic.Add("Pen_MalePPF_C", "");
            dic.Add("Pen_FemalePPF_V", "");
            dic.Add("Pen_FemalePPF_C", "");
            dic.Add("Pen_MaleSolvency_V", "");
            dic.Add("Pen_MaleSolvency_C", "");
            dic.Add("Pen_FemaleSolvency_V", "");
            dic.Add("Pen_FemaleSolvency_C", "");
            dic.Add("Pen_MalePPF_cbo", "");
            dic.Add("Pen_MalePPF_txt", "");
            dic.Add("Pen_FemalePPF_cbo", "");
            dic.Add("Pen_FemalePPF_txt", "");
            dic.Add("Pen_MaleSolvency_cbo", "");
            dic.Add("Pen_MaleSolvency_txt", "");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);



            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", "Add new Tranche");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Post2014CAREpension");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "");
            dic.Add("StartDate", "19/04/2014");
            dic.Add("EndDate", "");
            dic.Add("GMPApplies", "false");
            dic.Add("Active_PPFTranche", "");
            dic.Add("Active_MalePPF_V", "");
            dic.Add("Active_MalePPF_C", "");
            dic.Add("Active_FemalePPF_V", "");
            dic.Add("Active_FemalePPF_C", "");
            dic.Add("Active_MaleSolvency_V", "");
            dic.Add("Active_MaleSolvency_C", "");
            dic.Add("Active_FemaleSolvency_V", "");
            dic.Add("Active_FemaleSolvency_C", "");
            dic.Add("Active_FullySalaryRelated", "");
            dic.Add("Active_MalePPF_cbo", "");
            dic.Add("Active_MalePPF_txt", "");
            dic.Add("Active_FemalePPF_cbo", "");
            dic.Add("Active_FemalePPF_txt", "");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "");
            dic.Add("Def_PPFTranche", "");
            dic.Add("Def_MalePPF_V", "");
            dic.Add("Def_MalePPF_C", "");
            dic.Add("Def_FemalePPF_V", "");
            dic.Add("Def_FemalePPF_C", "");
            dic.Add("Def_MaleSolvency_V", "");
            dic.Add("Def_MaleSolvency_C", "");
            dic.Add("Def_FemaleSolvency_V", "");
            dic.Add("Def_FemaleSolvency_C", "");
            dic.Add("Def_MalePPF_cbo", "");
            dic.Add("Def_MalePPF_txt", "");
            dic.Add("Def_FemalePPF_cbo", "");
            dic.Add("Def_FemalePPF_txt", "");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "");
            dic.Add("Pen_PPFTranche", "");
            dic.Add("Pen_MalePPF_V", "");
            dic.Add("Pen_MalePPF_C", "");
            dic.Add("Pen_FemalePPF_V", "");
            dic.Add("Pen_FemalePPF_C", "");
            dic.Add("Pen_MaleSolvency_V", "");
            dic.Add("Pen_MaleSolvency_C", "");
            dic.Add("Pen_FemaleSolvency_V", "");
            dic.Add("Pen_FemaleSolvency_C", "");
            dic.Add("Pen_MalePPF_cbo", "");
            dic.Add("Pen_MalePPF_txt", "");
            dic.Add("Pen_FemalePPF_cbo", "");
            dic.Add("Pen_FemalePPF_txt", "");
            dic.Add("Pen_MaleSolvency_cbo", "");
            dic.Add("Pen_MaleSolvency_txt", "");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);



            pTrancheDefinition._DefinitionFPGrid_RightSelect("Deferred", "Add new Tranche");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Pst2014CAREpension");
            dic.Add("Actives", "");
            dic.Add("Deferred", "True");
            dic.Add("Pensioner", "");
            dic.Add("StartDate", "01/04/2014");
            dic.Add("EndDate", "");
            dic.Add("GMPApplies", "false");
            dic.Add("Active_PPFTranche", "");
            dic.Add("Active_MalePPF_V", "");
            dic.Add("Active_MalePPF_C", "");
            dic.Add("Active_FemalePPF_V", "");
            dic.Add("Active_FemalePPF_C", "");
            dic.Add("Active_MaleSolvency_V", "");
            dic.Add("Active_MaleSolvency_C", "");
            dic.Add("Active_FemaleSolvency_V", "");
            dic.Add("Active_FemaleSolvency_C", "");
            dic.Add("Active_FullySalaryRelated", "");
            dic.Add("Active_MalePPF_cbo", "");
            dic.Add("Active_MalePPF_txt", "");
            dic.Add("Active_FemalePPF_cbo", "");
            dic.Add("Active_FemalePPF_txt", "");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "");
            dic.Add("Def_PPFTranche", "");
            dic.Add("Def_MalePPF_V", "");
            dic.Add("Def_MalePPF_C", "");
            dic.Add("Def_FemalePPF_V", "");
            dic.Add("Def_FemalePPF_C", "");
            dic.Add("Def_MaleSolvency_V", "");
            dic.Add("Def_MaleSolvency_C", "");
            dic.Add("Def_FemaleSolvency_V", "");
            dic.Add("Def_FemaleSolvency_C", "");
            dic.Add("Def_MalePPF_cbo", "");
            dic.Add("Def_MalePPF_txt", "");
            dic.Add("Def_FemalePPF_cbo", "");
            dic.Add("Def_FemalePPF_txt", "");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "");
            dic.Add("Pen_PPFTranche", "");
            dic.Add("Pen_MalePPF_V", "");
            dic.Add("Pen_MalePPF_C", "");
            dic.Add("Pen_FemalePPF_V", "");
            dic.Add("Pen_FemalePPF_C", "");
            dic.Add("Pen_MaleSolvency_V", "");
            dic.Add("Pen_MaleSolvency_C", "");
            dic.Add("Pen_FemaleSolvency_V", "");
            dic.Add("Pen_FemaleSolvency_C", "");
            dic.Add("Pen_MalePPF_cbo", "");
            dic.Add("Pen_MalePPF_txt", "");
            dic.Add("Pen_FemalePPF_cbo", "");
            dic.Add("Pen_FemalePPF_txt", "");
            dic.Add("Pen_MaleSolvency_cbo", "");
            dic.Add("Pen_MaleSolvency_txt", "");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);








            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            dic.Add("Level_4", "Pst2005");
            dic.Add("MenuItem", "Rename");
            pAssumptions._TreeViewRightSelect(dic, "AllService");


            pTrancheDefinition._DefinitionFPGrid_RightSelect("Pensioner", 1, "AllService", "Edit Tranche");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("Actives", "");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "True");
            dic.Add("StartDate", "{Delete}");
            dic.Add("EndDate", "");
            dic.Add("GMPApplies", "True");
            dic.Add("Active_PPFTranche", "");
            dic.Add("Active_MalePPF_V", "");
            dic.Add("Active_MalePPF_C", "");
            dic.Add("Active_FemalePPF_V", "");
            dic.Add("Active_FemalePPF_C", "");
            dic.Add("Active_MaleSolvency_V", "");
            dic.Add("Active_MaleSolvency_C", "");
            dic.Add("Active_FemaleSolvency_V", "");
            dic.Add("Active_FemaleSolvency_C", "");
            dic.Add("Active_FullySalaryRelated", "");
            dic.Add("Active_MalePPF_cbo", "");
            dic.Add("Active_MalePPF_txt", "");
            dic.Add("Active_FemalePPF_cbo", "");
            dic.Add("Active_FemalePPF_txt", "");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "");
            dic.Add("Def_PPFTranche", "");
            dic.Add("Def_MalePPF_V", "");
            dic.Add("Def_MalePPF_C", "");
            dic.Add("Def_FemalePPF_V", "");
            dic.Add("Def_FemalePPF_C", "");
            dic.Add("Def_MaleSolvency_V", "");
            dic.Add("Def_MaleSolvency_C", "");
            dic.Add("Def_FemaleSolvency_V", "");
            dic.Add("Def_FemaleSolvency_C", "");
            dic.Add("Def_MalePPF_cbo", "");
            dic.Add("Def_MalePPF_txt", "");
            dic.Add("Def_FemalePPF_cbo", "");
            dic.Add("Def_FemalePPF_txt", "");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "");
            dic.Add("Pen_PPFTranche", "#1#");
            dic.Add("Pen_MalePPF_V", "");
            dic.Add("Pen_MalePPF_C", "");
            dic.Add("Pen_FemalePPF_V", "");
            dic.Add("Pen_FemalePPF_C", "");
            dic.Add("Pen_MaleSolvency_V", "");
            dic.Add("Pen_MaleSolvency_C", "");
            dic.Add("Pen_FemaleSolvency_V", "");
            dic.Add("Pen_FemaleSolvency_C", "");
            dic.Add("Pen_MalePPF_cbo", "");
            dic.Add("Pen_MalePPF_txt", "");
            dic.Add("Pen_FemalePPF_cbo", "");
            dic.Add("Pen_FemalePPF_txt", "");
            dic.Add("Pen_MaleSolvency_cbo", "");
            dic.Add("Pen_MaleSolvency_txt", "");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            pAssumptions._Collapse(dic);


            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");



            #endregion

            #region Baseline - Provision - From/To Age, Pay Projection, Pay Average

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "CeaseChildrensPensions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "From/To Age");
            dic.Add("Level_4", "CeaseChildrensPensions");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "120");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "From/To Age");
            dic.Add("Level_4", "CeaseChildrensPensions");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "StopChildrensPension");

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "21");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.CurrentStatus=\"KID\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "PUStopAge");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "From/To Age");
            dic.Add("Level_4", "PUStopAge");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$ValAge+1+$FutValOffset");
            dic.Add("Validate", "Click");
            dic.Add("isInputName", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "LumpSumRetAge");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "From/To Age");
            dic.Add("Level_4", "LumpSumRetAge");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max($ValAge,$emp.CriticalRetAge)");
            dic.Add("Validate", "Click");
            dic.Add("isInputName", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "From/To Age");
            dic.Add("Level_4", "LumpSumRetAge");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Age65Member");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max($ValAge, 65)");
            dic.Add("Validate", "Click");
            dic.Add("isInputName", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Accrued65LumpSum>0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "FTEPayProjection");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Pay Projection");
            dic.Add("Level_4", "FTEPayProjection");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "True");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "");
            dic.Add("CustomCode", "");
            dic.Add("IgnoreYearWithHoursLess", "");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "False");
            dic.Add("ApplyPayLimitAfterDeduction", "");
            dic.Add("ApplySalaryMinimum", "");
            dic.Add("LegislatedPayLimitDefinition", "False");
            pPayoutProjection._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataFieldContainingPayHistory", "FTEPayPre2014");
            dic.Add("PayIncreaseAssumption", "SalaryIncreaseAssumption");
            dic.Add("UseOnlyDataFields", "");
            dic.Add("rdValuationYearPlus", "");
            dic.Add("txtValuationYearPlus", "");
            dic.Add("rdSpecifiedYear", "");
            dic.Add("txtSpecifiedYear", "");
            dic.Add("ApplyEGTRRALimits", "");
            pPayoutProjection._PopVerify_History(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "ActualSalaryProjection");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Pay Projection");
            dic.Add("Level_4", "ActualSalaryProjection");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "True");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "");
            dic.Add("CustomCode", "");
            dic.Add("IgnoreYearWithHoursLess", "");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "False");
            dic.Add("ApplyPayLimitAfterDeduction", "");
            dic.Add("ApplySalaryMinimum", "");
            dic.Add("LegislatedPayLimitDefinition", "False");
            pPayoutProjection._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataFieldContainingPayHistory", "TotalPost2014Pay");
            dic.Add("PayIncreaseAssumption", "SalaryIncreaseAssumption");
            dic.Add("UseOnlyDataFields", "");
            dic.Add("rdValuationYearPlus", "");
            dic.Add("txtValuationYearPlus", "");
            dic.Add("rdSpecifiedYear", "");
            dic.Add("txtSpecifiedYear", "");
            dic.Add("ApplyEGTRRALimits", "");
            pPayoutProjection._PopVerify_History(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "EmployeeSalaryProjection");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Pay Projection");
            dic.Add("Level_4", "EmployeeSalaryProjection");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "true");
            dic.Add("CustomCode", "");
            dic.Add("IgnoreYearWithHoursLess", "");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "False");
            dic.Add("ApplyPayLimitAfterDeduction", "");
            dic.Add("ApplySalaryMinimum", "");
            dic.Add("LegislatedPayLimitDefinition", "False");
            pPayoutProjection._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Function", "$ActualSalaryProjection*$emp.ContRatePost2014");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "FTEPayProjectionCPI");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Pay Projection");
            dic.Add("Level_4", "FTEPayProjectionCPI");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "True");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "");
            dic.Add("CustomCode", "");
            dic.Add("IgnoreYearWithHoursLess", "");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "False");
            dic.Add("ApplyPayLimitAfterDeduction", "");
            dic.Add("ApplySalaryMinimum", "");
            dic.Add("LegislatedPayLimitDefinition", "False");
            pPayoutProjection._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataFieldContainingPayHistory", "FTEPayPre2014");
            dic.Add("PayIncreaseAssumption", "CPIRevaluationForDebts");
            dic.Add("UseOnlyDataFields", "");
            dic.Add("rdValuationYearPlus", "");
            dic.Add("txtValuationYearPlus", "");
            dic.Add("rdSpecifiedYear", "");
            dic.Add("txtSpecifiedYear", "");
            dic.Add("ApplyEGTRRALimits", "");
            pPayoutProjection._PopVerify_History(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Pay Average");
            dic.Add("MenuItem", "Add Pay Average");
            pAssumptions._TreeViewRightSelect(dic, "FTEPayAverage");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Pay Average");
            dic.Add("Level_4", "FTEPayAverage");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("ApplyPayLimitBeforeAveraging", "false");
            dic.Add("ApplyeDeductionBeforeAveraging", "false");
            dic.Add("AdjustmentPeriod", "false");
            dic.Add("ApplyLegislatedSalaryCap", "false");
            dic.Add("ApplyPayAverageFreezeDefinition", "");
            dic.Add("ApplyAverageAtFutureAge", "");
            dic.Add("UseDtaItemForSolvencyAndPPF", "false");
            pPayAverage._PopVerify_Main_UK(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "FTEPayProjection");
            dic.Add("AveragingMethod", "Final M years");
            dic.Add("M", "1");
            dic.Add("N", "");
            dic.Add("RoundingForYearOfHire", "Full year");
            dic.Add("DecimalPlacesForYearOfHire", "");
            dic.Add("Include", "true");
            dic.Add("DropForCalculations", "");
            dic.Add("DropForCalculationAndPeriodConsidered", "");
            dic.Add("AdjustmentPeriodMonths", "");
            dic.Add("AdjustmentMethod", "");
            dic.Add("FreezePayAverageAtAge_V", "");
            dic.Add("FreezePayAverageAtAge_C", "");
            dic.Add("FreezePayAverageAtAge_cbo", "");
            dic.Add("LimitAmount_txt", "");
            dic.Add("AnualLimitIncrease_txt", "");
            dic.Add("PayAveragefromdata_cbo", "");
            dic.Add("FinalSalaryFromData", "");
            dic.Add("ProjectFPS", "");
            dic.Add("PayIncreaseAssumptionForProjection", "");
            pPayAverage._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Pay Average");
            dic.Add("MenuItem", "Add Pay Average");
            pAssumptions._TreeViewRightSelect(dic, "ActualSalaryAverage");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Pay Average");
            dic.Add("Level_4", "ActualSalaryAverage");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("ApplyPayLimitBeforeAveraging", "false");
            dic.Add("ApplyeDeductionBeforeAveraging", "false");
            dic.Add("AdjustmentPeriod", "false");
            dic.Add("ApplyLegislatedSalaryCap", "false");
            dic.Add("ApplyPayAverageFreezeDefinition", "");
            dic.Add("ApplyAverageAtFutureAge", "");
            dic.Add("UseDtaItemForSolvencyAndPPF", "false");
            pPayAverage._PopVerify_Main_UK(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "ActualSalaryProjection");
            dic.Add("AveragingMethod", "Final M years");
            dic.Add("M", "1");
            dic.Add("N", "");
            dic.Add("RoundingForYearOfHire", "Full year");
            dic.Add("DecimalPlacesForYearOfHire", "");
            dic.Add("Include", "true");
            dic.Add("DropForCalculations", "");
            dic.Add("DropForCalculationAndPeriodConsidered", "");
            dic.Add("AdjustmentPeriodMonths", "");
            dic.Add("AdjustmentMethod", "");
            dic.Add("FreezePayAverageAtAge_V", "");
            dic.Add("FreezePayAverageAtAge_C", "");
            dic.Add("FreezePayAverageAtAge_cbo", "");
            dic.Add("LimitAmount_txt", "");
            dic.Add("AnualLimitIncrease_txt", "");
            dic.Add("PayAveragefromdata_cbo", "");
            dic.Add("FinalSalaryFromData", "");
            dic.Add("ProjectFPS", "");
            dic.Add("PayIncreaseAssumptionForProjection", "");
            pPayAverage._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Pay Average");
            dic.Add("MenuItem", "Add Pay Average");
            pAssumptions._TreeViewRightSelect(dic, "EmployeeSalaryAverage");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Pay Average");
            dic.Add("Level_4", "EmployeeSalaryAverage");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("ApplyPayLimitBeforeAveraging", "false");
            dic.Add("ApplyeDeductionBeforeAveraging", "false");
            dic.Add("AdjustmentPeriod", "false");
            dic.Add("ApplyLegislatedSalaryCap", "false");
            dic.Add("ApplyPayAverageFreezeDefinition", "");
            dic.Add("ApplyAverageAtFutureAge", "");
            dic.Add("UseDtaItemForSolvencyAndPPF", "false");
            pPayAverage._PopVerify_Main_UK(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "EmployeeSalaryProjection");
            dic.Add("AveragingMethod", "");
            dic.Add("M", "1");
            dic.Add("N", "");
            dic.Add("RoundingForYearOfHire", "");
            dic.Add("DecimalPlacesForYearOfHire", "");
            dic.Add("Include", "true");
            dic.Add("DropForCalculations", "");
            dic.Add("DropForCalculationAndPeriodConsidered", "");
            dic.Add("AdjustmentPeriodMonths", "");
            dic.Add("AdjustmentMethod", "");
            dic.Add("FreezePayAverageAtAge_V", "");
            dic.Add("FreezePayAverageAtAge_C", "");
            dic.Add("FreezePayAverageAtAge_cbo", "");
            dic.Add("LimitAmount_txt", "");
            dic.Add("AnualLimitIncrease_txt", "");
            dic.Add("PayAveragefromdata_cbo", "");
            dic.Add("FinalSalaryFromData", "");
            dic.Add("ProjectFPS", "");
            dic.Add("PayIncreaseAssumptionForProjection", "");
            pPayAverage._PopVerify_Standard(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "From/To Age");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Pay Projection");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Pay Average");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            #endregion

            #region Baseline - Provision - Custom Formula A & FAE Formula

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "ZeroPay");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula A");
            dic.Add("Level_5", "ZeroPay");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "Fixed10000");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula A");
            dic.Add("Level_5", "Fixed10000");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "Fixed1000");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula A");
            dic.Add("Level_5", "Fixed1000");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "1000");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula A");
            pAssumptions._Collapse(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "DISLS");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "DISLS");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "3*$ActualSalaryProjection");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "DISLS");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "RetBene");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
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
            dic.Add("EligibilityCondition", "$emp.USC=\"RetBene\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "CombineARCpension");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "CombineARCpension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.ARCSPre12Pen+$emp.ARCSPost12Pen");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "CombineEAPpension");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "CombineEAPpension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.EAPSPre12Pen+$emp.EAPSPost12Pen");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "TotalPre14CRApension");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "TotalPre14CRApension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "($emp.AccruedPre14CRDPension+$emp.AddedYearsCRDPen)*$FTEPayAverage/$emp.FTEPayPre2014PriorYear1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "TotalPre14CRApension");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NoPay");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
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
            dic.Add("EligibilityCondition", "$emp.FTEPayPre2014PriorYear1=0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);






            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "TotalPre14Age65pension");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "TotalPre14Age65pension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "($emp.AccruedPre14Age65Pension+$emp.AddedYears65Pen)*$FTEPayAverage/$emp.FTEPayPre2014PriorYear1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "TotalPre14Age65pension");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NoPay");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
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
            dic.Add("EligibilityCondition", "$emp.FTEPayPre2014PriorYear1=0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "TotalCAREpension");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "TotalCAREpension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccruedCARECRDPension+$emp.AccruedCARECRDPension5050+$emp.AccruedCARENPDPension+$emp.AccruedCARENPDPension5050+$emp.AccruedCARETPDPension+$emp.AccruedCARETPDPension5050");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "TotalPre14TPDpension");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "TotalPre14TPDpension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "($emp.AccruedPre14TPDPension)*$FTEPayAverage/$emp.FTEPayPre2014PriorYear1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "TotalPre14TPDpension");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NoPay");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
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
            dic.Add("EligibilityCondition", "$emp.FTEPayPre2014PriorYear1=0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);






            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "TotalPre08LumpSum");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "TotalPre08LumpSum");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccruedLumpSum*$FTEPayAverage/$emp.FTEPayPre2014PriorYear1-$emp.TotalLumpSumDebit*$FTEPayProjectionCPI/$emp.FTEPayPre2014PriorYear1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "TotalPre08LumpSum");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NoPay");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
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
            dic.Add("EligibilityCondition", "$emp.FTEPayPre2014PriorYear1=0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "DISLS");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "CombineARCpension");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "CombineEAPpension");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "TotalPre14CRApension");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "TotalPre14Age65pension");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "TotalCAREpension");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "TotalPre14TPDpension");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "TotalPre08LumpSum");
            pAssumptions._Collapse(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "DIDLSCRA");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "DIDLSCRA");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$TotalPre14CRApension*5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "DIDLSTPD");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "DIDLSTPD");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$TotalPre14TPDpension*5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);





            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "DefDIDLSCRA");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "DefDIDLSCRA");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccruedCRDPension*5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "DefDIDLSCRA");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Pre2008Leavers");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccruedCRDPension*3");
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
            dic.Add("EligibilityCondition", "$emp.TerminationDate1<ToDate(2008,4,1)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "DefDIDLSAge65");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "DefDIDLSAge65");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccruedPre14Age65Pension*5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "DefDIDLSAge65");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Pre2008Leavers");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccruedPre14Age65Pension*3");
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
            dic.Add("EligibilityCondition", "$emp.TerminationDate1<ToDate(2008,4,1)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "DefDIDLSTPD");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "DefDIDLSTPD");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccruedTPDPension*5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            pAssumptions._Collapse(dic);


            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");



            #endregion

            #region Baseline - Provision - Employee Contributions Formula & Career Average Earnings Formula

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("MenuItem", "Add Employee Contributions Formula");
            pAssumptions._TreeViewRightSelect(dic, "EmployeeContsAA");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "EmployeeContsAA");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "click");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "Post2014NPA");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "Semi-Annually");
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
            dic.Add("ProjectedPay", "EmployeeSalaryProjection");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.01");



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("MenuItem", "Add Employee Contributions Formula");
            pAssumptions._TreeViewRightSelect(dic, "EmployeeContsPU");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "EmployeeContsPU");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "click");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "PUStopAge");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "Semi-Annually");
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
            dic.Add("ProjectedPay", "EmployeeSalaryProjection");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.01");



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("MenuItem", "Add Employee Contributions Formula");
            pAssumptions._TreeViewRightSelect(dic, "AA1pcPay");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "AA1pcPay");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "click");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "Post2014NPA");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "Semi-Annually");
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
            dic.Add("ProjectedPay", "ActualSalaryProjection");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.01");



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("MenuItem", "Add Employee Contributions Formula");
            pAssumptions._TreeViewRightSelect(dic, "PU1pcPay");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "PU1pcPay");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "click");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "PUStopAge");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "Semi-Annually");
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
            dic.Add("ProjectedPay", "ActualSalaryProjection");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.01");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            pAssumptions._Collapse(dic);










            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("MenuItem", "Add Career Average Earnings Formula");
            pAssumptions._TreeViewRightSelect(dic, "Post2014CARE");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("Level_5", "Post2014CARE");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "ActualSalaryProjection");
            dic.Add("ServiceBasedOn", "Post2014DummyQServ");
            pPayCredit._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_Rate_V_NL", "click");
            dic.Add("Revaluation_Rate_cbo_NL", "CPIInflationAssumption");
            dic.Add("Revaluation_Rate_cbo", "");
            dic.Add("Revaluation_Rate_txt", "");
            dic.Add("StartingAmountAsOfAmount", "");
            dic.Add("StrartingAccruedAmount_V", "click");
            dic.Add("StrartingAccruedAmount_C", "");
            dic.Add("StrartingAccruedAmount_cbo", "TotalCAREpension");
            dic.Add("StrartingAccruedAmount_txt", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_txt", "");
            dic.Add("RateTiersBaseOn", "");
            pCareerAverageEarmingsFormula._Formula(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.020408");



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("MenuItem", "Add Career Average Earnings Formula");
            pAssumptions._TreeViewRightSelect(dic, "ArmedForcesPension");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("Level_5", "ArmedForcesPension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "ZeroPay");
            dic.Add("ServiceBasedOn", "FutureQualService");
            pPayCredit._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_Rate_V_NL", "click");
            dic.Add("Revaluation_Rate_cbo_NL", "FireAndArmedForcesRevaluation");
            dic.Add("Revaluation_Rate_cbo", "");
            dic.Add("Revaluation_Rate_txt", "");
            dic.Add("StartingAmountAsOfAmount", "");
            dic.Add("StrartingAccruedAmount_V", "click");
            dic.Add("StrartingAccruedAmount_C", "");
            dic.Add("StrartingAccruedAmount_cbo", "TVINArmedForcesCAREPen");
            dic.Add("StrartingAccruedAmount_txt", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_txt", "");
            dic.Add("RateTiersBaseOn", "");
            pCareerAverageEarmingsFormula._Formula(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.1");



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("MenuItem", "Add Career Average Earnings Formula");
            pAssumptions._TreeViewRightSelect(dic, "CivilServicePension");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("Level_5", "CivilServicePension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "ZeroPay");
            dic.Add("ServiceBasedOn", "FutureQualService");
            pPayCredit._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_Rate_V_NL", "click");
            dic.Add("Revaluation_Rate_cbo_NL", "CPIInflationAssumption");
            dic.Add("Revaluation_Rate_cbo", "");
            dic.Add("Revaluation_Rate_txt", "");
            dic.Add("StartingAmountAsOfAmount", "");
            dic.Add("StrartingAccruedAmount_V", "click");
            dic.Add("StrartingAccruedAmount_C", "");
            dic.Add("StrartingAccruedAmount_cbo", "TVINCivilCAREPen");
            dic.Add("StrartingAccruedAmount_txt", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_txt", "");
            dic.Add("RateTiersBaseOn", "");
            pCareerAverageEarmingsFormula._Formula(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.1");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("MenuItem", "Add Career Average Earnings Formula");
            pAssumptions._TreeViewRightSelect(dic, "FirePension");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("Level_5", "FirePension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "ZeroPay");
            dic.Add("ServiceBasedOn", "FutureQualService");
            pPayCredit._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_Rate_V_NL", "click");
            dic.Add("Revaluation_Rate_cbo_NL", "FireAndArmedForcesRevaluation");
            dic.Add("Revaluation_Rate_cbo", "");
            dic.Add("Revaluation_Rate_txt", "");
            dic.Add("StartingAmountAsOfAmount", "");
            dic.Add("StrartingAccruedAmount_V", "click");
            dic.Add("StrartingAccruedAmount_C", "");
            dic.Add("StrartingAccruedAmount_cbo", "TVINFireCAREPen");
            dic.Add("StrartingAccruedAmount_txt", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_txt", "");
            dic.Add("RateTiersBaseOn", "");
            pCareerAverageEarmingsFormula._Formula(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.1");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("MenuItem", "Add Career Average Earnings Formula");
            pAssumptions._TreeViewRightSelect(dic, "NHSPension");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("Level_5", "NHSPension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "ZeroPay");
            dic.Add("ServiceBasedOn", "FutureQualService");
            pPayCredit._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_Rate_V_NL", "click");
            dic.Add("Revaluation_Rate_cbo_NL", "NHSrevaluation");
            dic.Add("Revaluation_Rate_cbo", "");
            dic.Add("Revaluation_Rate_txt", "");
            dic.Add("StartingAmountAsOfAmount", "");
            dic.Add("StrartingAccruedAmount_V", "click");
            dic.Add("StrartingAccruedAmount_C", "");
            dic.Add("StrartingAccruedAmount_cbo", "TVINNHSCAREPen");
            dic.Add("StrartingAccruedAmount_txt", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_txt", "");
            dic.Add("RateTiersBaseOn", "");
            pCareerAverageEarmingsFormula._Formula(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.1");




            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("MenuItem", "Add Career Average Earnings Formula");
            pAssumptions._TreeViewRightSelect(dic, "PolicePension");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("Level_5", "PolicePension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "ZeroPay");
            dic.Add("ServiceBasedOn", "FutureQualService");
            pPayCredit._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_Rate_V_NL", "click");
            dic.Add("Revaluation_Rate_cbo_NL", "PoliceRevaluation");
            dic.Add("Revaluation_Rate_cbo", "");
            dic.Add("Revaluation_Rate_txt", "");
            dic.Add("StartingAmountAsOfAmount", "");
            dic.Add("StrartingAccruedAmount_V", "click");
            dic.Add("StrartingAccruedAmount_C", "");
            dic.Add("StrartingAccruedAmount_cbo", "TVINPoliceCAREPen");
            dic.Add("StrartingAccruedAmount_txt", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_txt", "");
            dic.Add("RateTiersBaseOn", "");
            pCareerAverageEarmingsFormula._Formula(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.1");


            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("MenuItem", "Add Career Average Earnings Formula");
            pAssumptions._TreeViewRightSelect(dic, "TeachersPension");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("Level_5", "TeachersPension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "ZeroPay");
            dic.Add("ServiceBasedOn", "$Service");
            pPayCredit._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_Rate_V_NL", "click");
            dic.Add("Revaluation_Rate_cbo_NL", "TeachersRevaluation");
            dic.Add("Revaluation_Rate_cbo", "");
            dic.Add("Revaluation_Rate_txt", "");
            dic.Add("StartingAmountAsOfAmount", "");
            dic.Add("StrartingAccruedAmount_V", "click");
            dic.Add("StrartingAccruedAmount_C", "");
            dic.Add("StrartingAccruedAmount_cbo", "TVINTeachersCAREPen");
            dic.Add("StrartingAccruedAmount_txt", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_txt", "");
            dic.Add("RateTiersBaseOn", "");
            pCareerAverageEarmingsFormula._Formula(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.1");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("MenuItem", "Add Career Average Earnings Formula");
            pAssumptions._TreeViewRightSelect(dic, "TotalARCPensionLessDebt");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("Level_5", "TotalARCPensionLessDebt");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "ZeroPay");
            dic.Add("ServiceBasedOn", "FutureQualService");
            pPayCredit._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_Rate_V_NL", "click");
            dic.Add("Revaluation_Rate_cbo_NL", "CPIInflationAssumption");
            dic.Add("Revaluation_Rate_cbo", "");
            dic.Add("Revaluation_Rate_txt", "");
            dic.Add("StartingAmountAsOfAmount", "");
            dic.Add("StrartingAccruedAmount_V", "click");
            dic.Add("StrartingAccruedAmount_C", "");
            dic.Add("StrartingAccruedAmount_cbo", "CombineARCpension");
            dic.Add("StrartingAccruedAmount_txt", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_txt", "");
            dic.Add("RateTiersBaseOn", "");
            pCareerAverageEarmingsFormula._Formula(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.1");



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("MenuItem", "Add Career Average Earnings Formula");
            pAssumptions._TreeViewRightSelect(dic, "TotalEAPpension");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("Level_5", "TotalEAPpension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "ZeroPay");
            dic.Add("ServiceBasedOn", "FutureQualService");
            pPayCredit._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_Rate_V_NL", "click");
            dic.Add("Revaluation_Rate_cbo_NL", "CPIInflationAssumption");
            dic.Add("Revaluation_Rate_cbo", "");
            dic.Add("Revaluation_Rate_txt", "");
            dic.Add("StartingAmountAsOfAmount", "");
            dic.Add("StrartingAccruedAmount_V", "click");
            dic.Add("StrartingAccruedAmount_C", "");
            dic.Add("StrartingAccruedAmount_cbo", "CombineEAPpension");
            dic.Add("StrartingAccruedAmount_txt", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_txt", "");
            dic.Add("RateTiersBaseOn", "");
            pCareerAverageEarmingsFormula._Formula(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.1");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("MenuItem", "Add Career Average Earnings Formula");
            pAssumptions._TreeViewRightSelect(dic, "TotalAPCpension");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("Level_5", "TotalAPCpension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "ZeroPay");
            dic.Add("ServiceBasedOn", "FutureQualService");
            pPayCredit._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_Rate_V_NL", "");
            dic.Add("Revaluation_Rate_cbo_NL", "");
            dic.Add("Revaluation_Rate_cbo", "");
            dic.Add("Revaluation_Rate_txt", "");
            dic.Add("StartingAmountAsOfAmount", "");
            dic.Add("StrartingAccruedAmount_V", "click");
            dic.Add("StrartingAccruedAmount_C", "");
            dic.Add("StrartingAccruedAmount_cbo", "APCPen");
            dic.Add("StrartingAccruedAmount_txt", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_txt", "");
            dic.Add("RateTiersBaseOn", "");
            pCareerAverageEarmingsFormula._Formula(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.1");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("MenuItem", "Add Career Average Earnings Formula");
            pAssumptions._TreeViewRightSelect(dic, "PensionDebit");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("Level_5", "PensionDebit");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "ZeroPay");
            dic.Add("ServiceBasedOn", "FutureQualService");
            pPayCredit._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_Rate_V_NL", "click");
            dic.Add("Revaluation_Rate_cbo_NL", "CPIInflationAssumption");
            dic.Add("Revaluation_Rate_cbo", "");
            dic.Add("Revaluation_Rate_txt", "");
            dic.Add("StartingAmountAsOfAmount", "");
            dic.Add("StrartingAccruedAmount_V", "click");
            dic.Add("StrartingAccruedAmount_C", "");
            dic.Add("StrartingAccruedAmount_cbo", "TotalPensionDebit");
            dic.Add("StrartingAccruedAmount_txt", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_txt", "");
            dic.Add("RateTiersBaseOn", "");
            pCareerAverageEarmingsFormula._Formula(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.1");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            pAssumptions._Collapse(dic);


            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");





            #endregion

            #region Baseline - Provision - Custom Formula B

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "PensionerSpPen");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "PensionerSpPen");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.TotalPartnerPension");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "PensionerSpPen");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "CurrentSpouse");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.Beneficiary1Benefit1");
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
            dic.Add("EligibilityCondition", "$emp.USC=\"RetBene\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);





            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "Post2014IHPension");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "Post2014IHPension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$Post2014CARE[$ExitAge]+($Post2014IllHealthServ/49*$ActualSalaryProjection[$ExitAge])");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "Post2014IHPension");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "RetBene");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
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
            dic.Add("EligibilityCondition", "$emp.USC=\"RetBene\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);




            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "Post2014DISPension");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "Post2014DISPension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$Post2014CARE[$ExitAge]+($Post2014DISServ/49*$ActualSalaryProjection[$ExitAge])");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "Post2014DISPension");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "RetBene");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
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
            dic.Add("EligibilityCondition", "$emp.USC=\"RetBene\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);




            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "ActPre2014SpouseProportion");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "ActPre2014SpouseProportion");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Min(Max(0.375,($emp.PartnerPensionPre2014-0.375*($emp.AccruedPre14TPDPension+$emp.AccruedPre14Age65Pension))/$emp.AccruedPre14CRDPension),0.5)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "ActPre2014SpouseProportion");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Post14member");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0.5");
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
            dic.Add("EligibilityCondition", "$emp.AccruedPre14CRDPension=0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "DefPost2014Pension");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "DefPost2014Pension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccruedPost2014Pension+$emp.AccruedPost2014Pension5050");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);




            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "DIDLSPost2014");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "DIDLSPost2014");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "5*($Post2014CARE+$ArmedForcesPension+$CivilServicePension+$FirePension+$NHSPension+$PolicePension+$TeachersPension)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "DIDLSAge65");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "DIDLSAge65");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "($TotalPre14Age65pension+$TotalARCPensionLessDebt+$TotalEAPpension)*5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);






            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "DefDIDLSPost14");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "DefDIDLSPost14");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$DefPost2014Pension*5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "TotalDefAccruedPensionCRA");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "TotalDefAccruedPensionCRA");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccruedCRDPension");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "TotalDefAccruedPensionAge65");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "TotalDefAccruedPensionAge65");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccruedPre14Age65Pension");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "DefAge65SpousesProportion");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "DefAge65SpousesProportion");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Min(Max(0.375,($emp.AccruedPre14Age65Pension-$emp.Accrued65LumpSum/3*0.375+$emp.Accrued65LumpSum/3*0.5)/$emp.AccruedPre14Age65Pension),0.5)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "DefAge65SpousesProportion");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "AvoidErrors");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
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
            dic.Add("EligibilityCondition", "$emp.AccruedPre14Age65Pension=0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);







            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "DefCRASpousesProportion");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "DefCRASpousesProportion");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Min(Max(0.375,($emp.AccruedCRDPension-$emp.AccruedCRDLumpSum/3*0.375+$emp.AccruedCRDLumpSum/3*0.5)/$emp.AccruedCRDPension),0.5)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "DefCRASpousesProportion");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "AvoidErrors");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
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
            dic.Add("EligibilityCondition", "$emp.AccruedCRDPension=0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "DefSpCRAPen");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "DefSpCRAPen");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$DefCRASpousesProportion*$TotalDefAccruedPensionCRA");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "DefSpTPDPen");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "DefSpTPDPen");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccruedTPDPension*0.37");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "DefSpAge65Pen");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "DefSpAge65Pen");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$TotalDefAccruedPensionAge65*$DefAge65SpousesProportion");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "DefSpPost2014Pen");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "DefSpPost2014Pen");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$DefPost2014Pension*0.30625");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "DefSpPensionDebit");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "DefSpPensionDebit");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.TotalPensionDebit*0.375");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            pAssumptions._Collapse(dic);


            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");





            #endregion

            #region Baseline - Provision - COLA, Early Retirement Factors

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "COLA");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "COLA");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StatutoryCPI", "");
            dic.Add("StatutoryRPI", "");
            dic.Add("WholeDPRevaluation", "true");
            pCostOfLivingAdjustments_UK._PopVerify_Main(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("WholeDPRevaluation_Checked", "true");
            dic.Add("Revaluation_DeferredPension", "true");
            dic.Add("Revaluation_Rate_V", "click");
            dic.Add("Revaluation_Rate_P", "");
            dic.Add("Revaluation_Rate_T", "");
            dic.Add("Revaluation_Rate_V_cbo", "CPIInflationAssumption");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Revaluation_CumulativeMax", "");
            dic.Add("Revaluation_PensionIncrease", "RevalCPI");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "click");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "01/01/2010");
            dic.Add("Increase_Ends_YearsFrom", "");
            dic.Add("Increase_Ends_Date_V", "");
            dic.Add("Increase_Ends_Date_D", "click");
            dic.Add("Increase_Ends_Date_V_cbo", "");
            dic.Add("Increase_Ends_Date_D_txt", "");
            dic.Add("Increase_Amount_Rate_V", "click");
            dic.Add("Increase_Amount_Rate_P", "");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "CPIInflationAssumption");
            dic.Add("Increase_Amount_Rate_P_txt", "");
            dic.Add("Increase_Amount_Rate_T_cbo", "");
            dic.Add("Increase_Pension", "PensionIncCPI");
            pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic);


            _gLib._MsgBox("Manual interaction", "Please click button V of <Statutory rate> and select CPIInflationAssumption");





            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("MenuItem", "Add Early Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "Post2014PenERF");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("Level_4", "Post2014PenERF");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "Click");
            dic.Add("Button_C", "");
            dic.Add("AgeAtWhichReductionEnds_cbo", "Post2014NPA");
            dic.Add("AgeAtWhichReductionEnds_txt", "");
            pEarlyRetirementFactor._PopVerify_AgeYearInterval(dic);


            pEarlyRetirementFactor._TBL_ReductionDefinition(1, "1", "5.2", false, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(2, "1", "4.9", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(3, "1", "4.5", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(4, "1", "4.2", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(5, "1", "3.9", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(6, "1", "3.7", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(7, "1", "3.4", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(8, "1", "3.2", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(9, "1", "3.1", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(10, "1", "2.8", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(11, "1", "3.3", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(12, "1", "3.3", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(13, "1", "3.1", true, true);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("Level_4", "Post2014PenERF");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Females");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "Click");
            dic.Add("Button_C", "");
            dic.Add("AgeAtWhichReductionEnds_cbo", "Post2014NPA");
            dic.Add("AgeAtWhichReductionEnds_txt", "");
            pEarlyRetirementFactor._PopVerify_AgeYearInterval(dic);


            pEarlyRetirementFactor._TBL_ReductionDefinition(1, "1", "5.2", false, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(2, "1", "4.9", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(3, "1", "4.5", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(4, "1", "4.2", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(5, "1", "3.9", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(6, "1", "3.7", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(7, "1", "3.4", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(8, "1", "3.2", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(9, "1", "3.1", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(10, "1", "2.8", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(11, "1", "3.3", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(12, "1", "3.3", true, true);
            pEarlyRetirementFactor._TBL_ReductionDefinition(13, "1", "3.1", true, true);

            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"F\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("MenuItem", "Add Early Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "Pre2008LsERF");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("Level_4", "Pre2008LsERF");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AgeInterval", "");
            dic.Add("YearInterval", "True");
            dic.Add("TabularOrActuarially", "");
            dic.Add("CustomCode", "");
            pEarlyRetirementFactor._PopVerify_Main(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "Click");
            dic.Add("Button_C", "");
            dic.Add("AgeAtWhichReductionEnds_cbo", "CriticalRetAge");
            dic.Add("AgeAtWhichReductionEnds_txt", "");
            pEarlyRetirementFactor._PopVerify_AgeYearInterval(dic);


            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(1, "1", "2.9", false);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(2, "1", "2.8", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(3, "1", "2.8", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(4, "1", "2.7", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(5, "1", "2.5", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(6, "1", "2.6", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(7, "1", "2.4", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(8, "1", "2.4", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(9, "1", "2.3", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(10, "1", "2.2", true);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("Level_4", "Pre2008LsERF");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Age65LS");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AgeInterval", "");
            dic.Add("YearInterval", "True");
            dic.Add("TabularOrActuarially", "");
            dic.Add("CustomCode", "");
            pEarlyRetirementFactor._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "");
            dic.Add("Button_C", "Click");
            dic.Add("AgeAtWhichReductionEnds_cbo", "");
            dic.Add("AgeAtWhichReductionEnds_txt", "65");
            pEarlyRetirementFactor._PopVerify_AgeYearInterval(dic);


            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(1, "1", "2.9", false);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(2, "1", "2.8", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(3, "1", "2.8", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(4, "1", "2.7", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(5, "1", "2.5", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(6, "1", "2.6", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(7, "1", "2.4", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(8, "1", "2.4", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(9, "1", "2.3", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(10, "1", "2.2", true);

            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Accrued65LumpSum>0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);






            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("MenuItem", "Add Early Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "CRApenERF");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("Level_4", "CRApenERF");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AgeInterval", "");
            dic.Add("YearInterval", "True");
            dic.Add("TabularOrActuarially", "");
            dic.Add("CustomCode", "");
            pEarlyRetirementFactor._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "Click");
            dic.Add("Button_C", "");
            dic.Add("AgeAtWhichReductionEnds_cbo", "CriticalRetAge");
            dic.Add("AgeAtWhichReductionEnds_txt", "");
            pEarlyRetirementFactor._PopVerify_AgeYearInterval(dic);


            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(1, "1", "5.6", false);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(2, "1", "5.2", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(3, "1", "4.7", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(4, "1", "4.5", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(5, "1", "4.0", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(6, "1", "3.8", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(7, "1", "3.6", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(8, "1", "3.3", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(9, "1", "3.0", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(10, "1", "2.9", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(11, "1", "3.6", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(12, "1", "3.4", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(13, "1", "3.3", true);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("Level_4", "CRApenERF");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Females");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AgeInterval", "");
            dic.Add("YearInterval", "True");
            dic.Add("TabularOrActuarially", "");
            dic.Add("CustomCode", "");
            pEarlyRetirementFactor._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "Click");
            dic.Add("Button_C", "");
            dic.Add("AgeAtWhichReductionEnds_cbo", "CriticalRetAge");
            dic.Add("AgeAtWhichReductionEnds_txt", "");
            pEarlyRetirementFactor._PopVerify_AgeYearInterval(dic);


            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(1, "1", "5.2", false);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(2, "1", "4.9", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(3, "1", "4.5", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(4, "1", "4.2", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(5, "1", "3.9", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(6, "1", "3.7", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(7, "1", "3.4", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(8, "1", "3.2", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(9, "1", "3.1", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(10, "1", "2.8", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(11, "1", "3.3", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(12, "1", "3.3", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(13, "1", "3.1", true);

            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"F\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);




            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("MenuItem", "Add Early Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "TPApenERF");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("Level_4", "TPApenERF");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AgeInterval", "");
            dic.Add("YearInterval", "True");
            dic.Add("TabularOrActuarially", "");
            dic.Add("CustomCode", "");
            pEarlyRetirementFactor._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "Click");
            dic.Add("Button_C", "");
            dic.Add("AgeAtWhichReductionEnds_cbo", "TaperedRetAge");
            dic.Add("AgeAtWhichReductionEnds_txt", "");
            pEarlyRetirementFactor._PopVerify_AgeYearInterval(dic);


            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(1, "1", "5.6", false);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(2, "1", "5.2", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(3, "1", "4.7", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(4, "1", "4.5", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(5, "1", "4.0", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(6, "1", "3.8", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(7, "1", "3.6", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(8, "1", "3.3", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(9, "1", "3.0", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(10, "1", "2.9", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(11, "1", "3.6", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(12, "1", "3.4", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(13, "1", "3.3", true);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("Level_4", "TPApenERF");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Females");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AgeInterval", "");
            dic.Add("YearInterval", "True");
            dic.Add("TabularOrActuarially", "");
            dic.Add("CustomCode", "");
            pEarlyRetirementFactor._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "Click");
            dic.Add("Button_C", "");
            dic.Add("AgeAtWhichReductionEnds_cbo", "TaperedRetAge");
            dic.Add("AgeAtWhichReductionEnds_txt", "");
            pEarlyRetirementFactor._PopVerify_AgeYearInterval(dic);


            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(1, "1", "5.2", false);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(2, "1", "4.9", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(3, "1", "4.5", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(4, "1", "4.2", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(5, "1", "3.9", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(6, "1", "3.7", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(7, "1", "3.4", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(8, "1", "3.2", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(9, "1", "3.1", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(10, "1", "2.8", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(11, "1", "3.3", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(12, "1", "3.3", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(13, "1", "3.1", true);

            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"F\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("MenuItem", "Add Early Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "Age65penERF");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("Level_4", "Age65penERF");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AgeInterval", "");
            dic.Add("YearInterval", "True");
            dic.Add("TabularOrActuarially", "");
            dic.Add("CustomCode", "");
            pEarlyRetirementFactor._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "");
            dic.Add("Button_C", "Click");
            dic.Add("AgeAtWhichReductionEnds_cbo", "");
            dic.Add("AgeAtWhichReductionEnds_txt", "65");
            pEarlyRetirementFactor._PopVerify_AgeYearInterval(dic);


            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(1, "1", "5.6", false);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(2, "1", "5.2", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(3, "1", "4.7", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(4, "1", "4.5", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(5, "1", "4.0", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(6, "1", "3.8", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(7, "1", "3.6", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(8, "1", "3.3", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(9, "1", "3.0", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(10, "1", "2.9", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(11, "1", "3.6", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(12, "1", "3.4", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(13, "1", "3.3", true);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("Level_4", "Age65penERF");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Females");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AgeInterval", "");
            dic.Add("YearInterval", "True");
            dic.Add("TabularOrActuarially", "");
            dic.Add("CustomCode", "");
            pEarlyRetirementFactor._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "");
            dic.Add("Button_C", "Click");
            dic.Add("AgeAtWhichReductionEnds_cbo", "");
            dic.Add("AgeAtWhichReductionEnds_txt", "65");
            pEarlyRetirementFactor._PopVerify_AgeYearInterval(dic);


            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(1, "1", "5.2", false);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(2, "1", "4.9", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(3, "1", "4.5", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(4, "1", "4.2", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(5, "1", "3.9", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(6, "1", "3.7", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(7, "1", "3.4", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(8, "1", "3.2", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(9, "1", "3.1", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(10, "1", "2.8", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(11, "1", "3.3", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(12, "1", "3.3", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(13, "1", "3.1", true);

            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"F\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);




            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("MenuItem", "Add Early Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "APCpenERF");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("Level_4", "APCpenERF");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AgeInterval", "");
            dic.Add("YearInterval", "True");
            dic.Add("TabularOrActuarially", "");
            dic.Add("CustomCode", "");
            pEarlyRetirementFactor._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "Click");
            dic.Add("Button_C", "");
            dic.Add("AgeAtWhichReductionEnds_cbo", "APCRetAge");
            dic.Add("AgeAtWhichReductionEnds_txt", "");
            pEarlyRetirementFactor._PopVerify_AgeYearInterval(dic);


            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(1, "1", "5.6", false);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(2, "1", "5.2", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(3, "1", "4.7", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(4, "1", "4.5", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(5, "1", "4.0", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(6, "1", "3.8", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(7, "1", "3.6", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(8, "1", "3.3", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(9, "1", "3.0", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(10, "1", "2.9", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(11, "1", "3.6", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(12, "1", "3.4", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(13, "1", "3.3", true);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("Level_4", "APCpenERF");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Females");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AgeInterval", "");
            dic.Add("YearInterval", "True");
            dic.Add("TabularOrActuarially", "");
            dic.Add("CustomCode", "");
            pEarlyRetirementFactor._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "Click");
            dic.Add("Button_C", "");
            dic.Add("AgeAtWhichReductionEnds_cbo", "APCRetAge");
            dic.Add("AgeAtWhichReductionEnds_txt", "");
            pEarlyRetirementFactor._PopVerify_AgeYearInterval(dic);


            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(1, "1", "5.2", false);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(2, "1", "4.9", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(3, "1", "4.5", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(4, "1", "4.2", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(5, "1", "3.9", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(6, "1", "3.7", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(7, "1", "3.4", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(8, "1", "3.2", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(9, "1", "3.1", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(10, "1", "2.8", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(11, "1", "3.3", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(12, "1", "3.3", true);
            pEarlyRetirementFactor._TBL_ReductionDefinition_YearInterval_UK(13, "1", "3.1", true);

            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"F\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);




            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            pAssumptions._Collapse(dic);


            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");






            #endregion


            #region Baseline - Provision -  GMP, Commutation

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "GMP Adjustment Factors");
            dic.Add("MenuItem", "Add GMP Adjustment Factors");
            pAssumptions._TreeViewRightSelect(dic, "GMPAdjustmentFactors");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "GMP Adjustment Factors");
            dic.Add("Level_4", "GMPAdjustmentFactors");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Act_FromValuation_S148Increases", "");
            dic.Add("Act_FromValuation_FixedRateAt", "");
            dic.Add("Act_FromValuation_FixedRateAt_V", "Click");
            dic.Add("Act_FromValuation_FixedRateAt_D", "");
            dic.Add("Act_FromValuation_PensionIncrease", "RevalSection148");
            dic.Add("Act_FromValuation_FixedRateAt_V_cbo", "");
            dic.Add("Act_FromValuation_FixedRateAt_D_txt", "");
            dic.Add("Act_FromDate_S148Increases", "click");
            dic.Add("Act_FromDate_FixedRateAt", "");
            dic.Add("Act_FromDate_FixedRateAt_V", "Click");
            dic.Add("Act_FromDate_FixedRateAt_D", "");
            dic.Add("Act_FromDate_PensionIncrease", "RevalSection148");
            dic.Add("Act_FromDate_FixedRateAt_V_cbo", "");
            dic.Add("Act_FromDate_FixedRateAt_D_txt", "");
            dic.Add("Inact_S148Increases", "Click");
            dic.Add("Inact_FixedRateAtDateOfLeaving", "");
            dic.Add("Inact_FixedRateAt", "");
            dic.Add("Inact_FixedDateAt_V", "Click");
            dic.Add("Inact_FixedDateAt_D", "");
            dic.Add("Inact_LimitedRate", "");
            dic.Add("Inact_PensionIncrease", "RevalSection148");
            dic.Add("Inact_FixedDateAt_V_cbo", "");
            dic.Add("Inact_FixedDateAt_D_txt", "");
            dic.Add("Increase_Pre88GMP_V", "");
            dic.Add("Increase_Pre88GMP_P", "Click");
            dic.Add("Increase_Pre88GMP_T", "");
            dic.Add("Increase_Post88GMP_V", "Click");
            dic.Add("Increase_Post88GMP_P", "");
            dic.Add("Increase_Post88GMP_T", "");
            dic.Add("Increase_Pre88GMPPension", "PensionIncFixed0");
            dic.Add("Increase_Post88GMPPension", "PensionIncCPICapped3");
            dic.Add("Increase_Pre88GMP_V_cbo", "");
            dic.Add("Increase_Pre88GMP_P_txt", "");
            dic.Add("Increase_Pre88GMP_T_cbo", "");
            dic.Add("Increase_Post88GMP_V_cbo", "Post88GMP");
            dic.Add("Increase_Post88GMP_P_txt", "");
            dic.Add("Increase_Post88GMP_T_cbo", "");
            pGMPAdjustmentFactors._PopVerify_GMPAdjustmentFactors(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "GMP Adjustment Factors");
            dic.Add("Level_4", "GMPAdjustmentFactors");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "FemaleCPI");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Act_FromValuation_S148Increases", "");
            dic.Add("Act_FromValuation_FixedRateAt", "");
            dic.Add("Act_FromValuation_FixedRateAt_V", "Click");
            dic.Add("Act_FromValuation_FixedRateAt_D", "");
            dic.Add("Act_FromValuation_PensionIncrease", "RevalSection148");
            dic.Add("Act_FromValuation_FixedRateAt_V_cbo", "");
            dic.Add("Act_FromValuation_FixedRateAt_D_txt", "");
            dic.Add("Act_FromDate_S148Increases", "click");
            dic.Add("Act_FromDate_FixedRateAt", "");
            dic.Add("Act_FromDate_FixedRateAt_V", "Click");
            dic.Add("Act_FromDate_FixedRateAt_D", "");
            dic.Add("Act_FromDate_PensionIncrease", "RevalSection148");
            dic.Add("Act_FromDate_FixedRateAt_V_cbo", "");
            dic.Add("Act_FromDate_FixedRateAt_D_txt", "");
            dic.Add("Inact_S148Increases", "Click");
            dic.Add("Inact_FixedRateAtDateOfLeaving", "");
            dic.Add("Inact_FixedRateAt", "");
            dic.Add("Inact_FixedDateAt_V", "Click");
            dic.Add("Inact_FixedDateAt_D", "");
            dic.Add("Inact_LimitedRate", "");
            dic.Add("Inact_PensionIncrease", "RevalSection148");
            dic.Add("Inact_FixedDateAt_V_cbo", "");
            dic.Add("Inact_FixedDateAt_D_txt", "");
            dic.Add("Increase_Pre88GMP_V", "Click");
            dic.Add("Increase_Pre88GMP_P", "");
            dic.Add("Increase_Pre88GMP_T", "");
            dic.Add("Increase_Post88GMP_V", "Click");
            dic.Add("Increase_Post88GMP_P", "");
            dic.Add("Increase_Post88GMP_T", "");
            dic.Add("Increase_Pre88GMPPension", "PensionIncCPI");
            dic.Add("Increase_Post88GMPPension", "PensionIncCPI");
            dic.Add("Increase_Pre88GMP_V_cbo", "CPIInflationAssumption");
            dic.Add("Increase_Pre88GMP_P_txt", "");
            dic.Add("Increase_Pre88GMP_T_cbo", "");
            dic.Add("Increase_Post88GMP_V_cbo", "CPIInflationAssumption");
            dic.Add("Increase_Post88GMP_P_txt", "");
            dic.Add("Increase_Post88GMP_T_cbo", "");
            pGMPAdjustmentFactors._PopVerify_GMPAdjustmentFactors(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"F\" and $emp.BirthDate>\"04/05/1951\" and $emp.BirthDate<\"12/06/1953\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "GMP Adjustment Factors");
            dic.Add("Level_4", "GMPAdjustmentFactors");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "MaleCPI");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Act_FromValuation_S148Increases", "");
            dic.Add("Act_FromValuation_FixedRateAt", "");
            dic.Add("Act_FromValuation_FixedRateAt_V", "Click");
            dic.Add("Act_FromValuation_FixedRateAt_D", "");
            dic.Add("Act_FromValuation_PensionIncrease", "RevalSection148");
            dic.Add("Act_FromValuation_FixedRateAt_V_cbo", "");
            dic.Add("Act_FromValuation_FixedRateAt_D_txt", "");
            dic.Add("Act_FromDate_S148Increases", "click");
            dic.Add("Act_FromDate_FixedRateAt", "");
            dic.Add("Act_FromDate_FixedRateAt_V", "Click");
            dic.Add("Act_FromDate_FixedRateAt_D", "");
            dic.Add("Act_FromDate_PensionIncrease", "RevalSection148");
            dic.Add("Act_FromDate_FixedRateAt_V_cbo", "");
            dic.Add("Act_FromDate_FixedRateAt_D_txt", "");
            dic.Add("Inact_S148Increases", "Click");
            dic.Add("Inact_FixedRateAtDateOfLeaving", "");
            dic.Add("Inact_FixedRateAt", "");
            dic.Add("Inact_FixedDateAt_V", "Click");
            dic.Add("Inact_FixedDateAt_D", "");
            dic.Add("Inact_LimitedRate", "");
            dic.Add("Inact_PensionIncrease", "RevalSection148");
            dic.Add("Inact_FixedDateAt_V_cbo", "");
            dic.Add("Inact_FixedDateAt_D_txt", "");
            dic.Add("Increase_Pre88GMP_V", "Click");
            dic.Add("Increase_Pre88GMP_P", "");
            dic.Add("Increase_Pre88GMP_T", "");
            dic.Add("Increase_Post88GMP_V", "Click");
            dic.Add("Increase_Post88GMP_P", "");
            dic.Add("Increase_Post88GMP_T", "");
            dic.Add("Increase_Pre88GMPPension", "PensionIncCPI");
            dic.Add("Increase_Post88GMPPension", "PensionIncCPI");
            dic.Add("Increase_Pre88GMP_V_cbo", "CPIInflationAssumption");
            dic.Add("Increase_Pre88GMP_P_txt", "");
            dic.Add("Increase_Pre88GMP_T_cbo", "");
            dic.Add("Increase_Post88GMP_V_cbo", "CPIInflationAssumption");
            dic.Add("Increase_Post88GMP_P_txt", "");
            dic.Add("Increase_Post88GMP_T_cbo", "");
            pGMPAdjustmentFactors._PopVerify_GMPAdjustmentFactors(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"M\" and $emp.BirthDate>\"04/05/1951\" and $emp.BirthDate<\"12/06/1953\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "GMP Adjustment Factors");
            pAssumptions._Collapse(dic);



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


            ////////////////////////////////dic.Clear();
            ////////////////////////////////dic.Add("PopVerify", "Pop");
            ////////////////////////////////dic.Add("Male_C", "Click");
            ////////////////////////////////dic.Add("Male_T", "");
            ////////////////////////////////dic.Add("Male_C_txt", "12.0");
            ////////////////////////////////dic.Add("Male_T_cbo", "");
            ////////////////////////////////dic.Add("Female_C", "Click");
            ////////////////////////////////dic.Add("Female_T", "");
            ////////////////////////////////dic.Add("Female_C_txt", "12.0");
            ////////////////////////////////dic.Add("Female_T_cbo", "");
            ////////////////////////////////pCommunicationFactors._PopVerify_CommunicationFactors(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Commutation Factors");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Commutation Formula");
            dic.Add("MenuItem", "Add Commutation Formula");
            pAssumptions._TreeViewRightSelect(dic, "Pre2014Commutation");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Commutation Formula");
            dic.Add("Level_4", "Pre2014Commutation");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max((($emp.AccruedPre14CRDPension-$emp.AccruedLumpSum/3)*0.5446+($emp.AccruedLumpSum/3)*0.1964)/$emp.AccruedPre14CRDPension,0.1964)*12*$emp.AccruedPre14CRDPension*$FTEPayAverage/$emp.FTEPayPre2014PriorYear1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Commutation Formula");
            dic.Add("Level_4", "Pre2014Commutation");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Post14members");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0.1964");
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
            dic.Add("EligibilityCondition", "$emp.AccruedPre14CRDPension=0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Commutation Formula");
            dic.Add("MenuItem", "Add Commutation Formula");
            pAssumptions._TreeViewRightSelect(dic, "Post2014Commutation");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Commutation Formula");
            dic.Add("Level_4", "Post2014Commutation");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PercnetOfPension", "Click");
            dic.Add("LumpSumIs", "60.00");
            pCommutationFormula._Main(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Commutation Formula");
            dic.Add("MenuItem", "Add Commutation Formula");
            pAssumptions._TreeViewRightSelect(dic, "Pst2008Commutation");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Commutation Formula");
            dic.Add("Level_4", "Pst2008Commutation");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PercnetOfPension", "Click");
            dic.Add("LumpSumIs", "54.46");
            pCommutationFormula._Main(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Commutation Formula");
            dic.Add("MenuItem", "Add Commutation Formula");
            pAssumptions._TreeViewRightSelect(dic, "DefCRACommutation");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Commutation Formula");
            dic.Add("Level_4", "DefCRACommutation");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Min(Max((($emp.AccruedCRDPension-$emp.AccruedCRDLumpSum/3)*0.5446+($emp.AccruedCRDLumpSum/3)*0.1964)/$emp.AccruedCRDPension,0.1964),0.5446)*12*$emp.AccruedCRDPension");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Commutation Formula");
            dic.Add("Level_4", "DefCRACommutation");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "AvoidErrors");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
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
            dic.Add("EligibilityCondition", "$emp.AccruedCRDPension=0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Commutation Formula");
            dic.Add("MenuItem", "Add Commutation Formula");
            pAssumptions._TreeViewRightSelect(dic, "DefAge65Commutation");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Commutation Formula");
            dic.Add("Level_4", "DefAge65Commutation");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Min(Max((($emp.AccruedPre14Age65Pension-$emp.Accrued65LumpSum/3)*0.5446+($emp.Accrued65LumpSum/3)*0.1964)/$emp.AccruedPre14Age65Pension,0.1964),0.5446)*12*$emp.AccruedPre14Age65Pension");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Commutation Formula");
            dic.Add("Level_4", "DefAge65Commutation");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "AvoidErrors");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
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
            dic.Add("EligibilityCondition", "$emp.AccruedPre14Age65Pension=0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Commutation Formula");
            pAssumptions._Collapse(dic);




            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");





            #endregion

            #region Baseline - Provision - Form of Payment, Adjustment

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "SingleLife");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("Level_4", "SingleLife");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Straight life");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "Click");
            dic.Add("GuaranteePeriod_txt", "10");
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
            dic.Add("Level_4", "SingleLife");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "CurrentSpouse");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
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


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.USC=\"RetBene\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);






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
            dic.Add("btnGuaranteePeriod_C", "Click");
            dic.Add("GuaranteePeriod_txt", "0");
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
            pAssumptions._TreeViewRightSelect(dic, "SpousesImmediate");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("Level_4", "SpousesImmediate");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Spouse's");
            dic.Add("MortalityInReferralPeriod", "Joint life mortality");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "Click");
            dic.Add("GuaranteePeriod_txt", "0");
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
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
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
            pAssumptions._TreeViewRightSelect(dic, "LSDID");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("Level_4", "LSDID");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Insurance benefit");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
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
            pAssumptions._Collapse(dic);




            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("MenuItem", "Add Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "ChildPenForDIDDISIH");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("Level_4", "ChildPenForDIDDISIH");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LoadingFactor_V", "");
            dic.Add("LoadingFactor_C", "Click");
            dic.Add("LoadingFactor_T", "");
            dic.Add("LoadingFactor_cboV", "");
            dic.Add("LoadingFactor_txt", "1.1");
            dic.Add("LoadingFactor_cboT", "");
            dic.Add("ApplyTo", "");
            pAdjustments._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("MenuItem", "Add Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "PensionDebitFactor");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("Level_4", "PensionDebitFactor");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LoadingFactor_V", "");
            dic.Add("LoadingFactor_C", "Click");
            dic.Add("LoadingFactor_T", "");
            dic.Add("LoadingFactor_cboV", "");
            dic.Add("LoadingFactor_txt", "-1.0");
            dic.Add("LoadingFactor_cboT", "");
            dic.Add("ApplyTo", "");
            pAdjustments._PopVerify_Main(dic);




            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            pAssumptions._Collapse(dic);



            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");





            #endregion




            #region Baseline - Provision - Tranched Benefit - ActStandardRet

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "ActStandardRet");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActStandardRet");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "Click");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            dic.Add("CommutationAmtByTranche", "true");
            pTranchedBenefit._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("iCol", "1"); // Pre14CRAPension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed10000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "CRApenERF");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactors");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "ActPre2014SpouseProportion");
            dic.Add("CommutationAmount", "Pre2014Commutation");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2"); // Pre14TPAPension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "TPApenERF");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "37.5000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Pst2008Commutation");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "3"); //Pre14Age65Pension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "Age65penERF");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "37.5000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Pst2008Commutation");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "4"); // PensionDebits
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "Post2014PenERF");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "PensionDebitFactor");
            dic.Add("SpousePercent_txt", "37.5000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "5"); // ArmedForcesSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "Post2014PenERF");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "6"); // CivilServiceSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "Post2014PenERF");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "7"); // FirefighterSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "Post2014PenERF");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "8"); // NHSSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "Post2014PenERF");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "9"); // PoliceSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "Post2014PenERF");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "10"); //TeachersSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "Post2014PenERF");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "11"); // ARCpensionLessDebt
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "Age65penERF");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Pst2008Commutation");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "12"); // EAPpension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "Age65penERF");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Pst2008Commutation");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "13"); // APCpension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "APCpenERF");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "14"); // Post2014CAREpension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed10000");
            dic.Add("DefineAccruedBenefitSeparately", "true");
            dic.Add("AccruedBaseAmount", "Fixed1000");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "Post2014PenERF");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActStandardRet");
            pAssumptions._Collapse(dic);



            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");





            #endregion

            #region Baseline - Provision - Tranched Benefit - ActWithdrawal

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "ActWithdrawal");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActWithdrawal");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "Click");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            dic.Add("CommutationAmtByTranche", "true");
            pTranchedBenefit._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("iCol", "1"); // Pre14CRAPension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed10000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "CriticalRetAge");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactors");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "ActPre2014SpouseProportion");
            dic.Add("CommutationAmount", "Pre2014Commutation");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2"); // Pre14TPAPension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "TaperedRetAge");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "37.5000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Pst2008Commutation");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "3"); //Pre14Age65Pension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "37.5000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Pst2008Commutation");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "4"); // PensionDebits
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "PensionDebitFactor");
            dic.Add("SpousePercent_txt", "37.5000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "5"); // ArmedForcesSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "Post2014NPA");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "6"); // CivilServiceSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "Post2014NPA");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "7"); // FirefighterSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "Post2014NPA");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "8"); // NHSSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "Post2014NPA");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "9"); // PoliceSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "Post2014NPA");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "10"); //TeachersSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "Post2014NPA");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "11"); // ARCpensionLessDebt
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Pst2008Commutation");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "12"); // EAPpension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Pst2008Commutation");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "13"); // APCpension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "APCRetAge");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "14"); // Post2014CAREpension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed10000");
            dic.Add("DefineAccruedBenefitSeparately", "true");
            dic.Add("AccruedBaseAmount", "Fixed1000");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "Post2014NPA");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActWithdrawal");
            pAssumptions._Collapse(dic);



            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");





            #endregion



            #region Baseline - Provision - Tranched Benefit - ActWithdrawalDID

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "ActWithdrawalDID");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActWithdrawalDID");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "Click");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            dic.Add("CommutationAmtByTranche", "");
            pTranchedBenefit._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("iCol", "1"); // Pre14CRAPension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed10000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "CriticalRetAge");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactors");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "ActPre2014SpouseProportion");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2"); // Pre14TPAPension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "TaperedRetAge");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "37.5000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "3"); //Pre14Age65Pension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "37.5000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "4"); // PensionDebits
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "PensionDebitFactor");
            dic.Add("SpousePercent_txt", "37.5000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "5"); // ArmedForcesSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "Post2014NPA");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "6"); // CivilServiceSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "Post2014NPA");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "7"); // FirefighterSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "Post2014NPA");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "8"); // NHSSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "Post2014NPA");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "9"); // PoliceSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "Post2014NPA");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "10"); //TeachersSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "Post2014NPA");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "11"); // ARCpensionLessDebt
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "12"); // EAPpension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "13"); // APCpension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "APCRetAge");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "14"); // Post2014CAREpension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed10000");
            dic.Add("DefineAccruedBenefitSeparately", "true");
            dic.Add("AccruedBaseAmount", "Fixed1000");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "Post2014NPA");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActWithdrawalDID");
            pAssumptions._Collapse(dic);



            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");





            #endregion

            #region Baseline - Provision - Tranched Benefit - ActIH

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "ActIH");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActIH");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "Click");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            dic.Add("CommutationAmtByTranche", "true");
            pTranchedBenefit._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("iCol", "1"); // Pre14CRAPension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed10000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactors");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Pre2014Commutation");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2"); // Pre14TPAPension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Pst2008Commutation");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "3"); //Pre14Age65Pension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Pst2008Commutation");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "4"); // PensionDebits
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "PensionDebitFactor");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "5"); // ArmedForcesSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "6"); // CivilServiceSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "7"); // FirefighterSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "8"); // NHSSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "9"); // PoliceSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "10"); //TeachersSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "11"); // ARCpensionLessDebt
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Pst2008Commutation");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "12"); // EAPpension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Pst2008Commutation");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "13"); // APCpension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "14"); // Post2014CAREpension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed10000");
            dic.Add("DefineAccruedBenefitSeparately", "true");
            dic.Add("AccruedBaseAmount", "Fixed1000");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Active(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActIH");
            pAssumptions._Collapse(dic);



            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");





            #endregion



            #region Baseline - Provision - Tranched Benefit - ActIHDAR

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "ActIHDAR");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActIHDAR");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "Click");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            dic.Add("CommutationAmtByTranche", "");
            pTranchedBenefit._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("iCol", "1"); // Pre14CRAPension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed10000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactors");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "ActPre2014SpouseProportion");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2"); // Pre14TPAPension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "37.5000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "3"); //Pre14Age65Pension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "37.5000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "4"); // PensionDebits
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "PensionDebitFactor");
            dic.Add("SpousePercent_txt", "37.5000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "5"); // ArmedForcesSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "6"); // CivilServiceSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "7"); // FirefighterSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "8"); // NHSSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "9"); // PoliceSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "10"); //TeachersSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "11"); // ARCpensionLessDebt
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "12"); // EAPpension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "13"); // APCpension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "14"); // Post2014CAREpension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed10000");
            dic.Add("DefineAccruedBenefitSeparately", "true");
            dic.Add("AccruedBaseAmount", "Fixed1000");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActIHDAR");
            pAssumptions._Collapse(dic);



            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");





            #endregion

            #region Baseline - Provision - Tranched Benefit - ActDis

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "ActDis");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActDis");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "Click");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            dic.Add("CommutationAmtByTranche", "");
            pTranchedBenefit._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("iCol", "1"); // Pre14CRAPension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed10000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactors");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "ActPre2014SpouseProportion");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2"); // Pre14TPAPension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "37.5000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "3"); //Pre14Age65Pension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "37.5000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "4"); // PensionDebits
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "PensionDebitFactor");
            dic.Add("SpousePercent_txt", "37.5000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "5"); // ArmedForcesSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "6"); // CivilServiceSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "7"); // FirefighterSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "8"); // NHSSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "9"); // PoliceSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "10"); //TeachersSchemePension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "11"); // ARCpensionLessDebt
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "12"); // EAPpension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "13"); // APCpension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed1000");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "14"); // Post2014CAREpension
            dic.Add("iCol_Total", "14");
            dic.Add("BaseAmount", "Fixed10000");
            dic.Add("DefineAccruedBenefitSeparately", "true");
            dic.Add("AccruedBaseAmount", "Fixed1000");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Active(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActDis");
            pAssumptions._Collapse(dic);



            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");





            #endregion

            #region Baseline - Provision - Tranched Benefit - DefStandardRet

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "DefStandardRet");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "DefStandardRet");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "");
            dic.Add("Deferred", "Click");
            dic.Add("Pensioner", "");
            dic.Add("BaseAmountRevaluing", "false");
            dic.Add("BaseAmountNonRevaluing", "false");
            dic.Add("RevalueNonRevaluing", "false");
            dic.Add("CommutationAmtByTranche", "true");
            pTranchedBenefit._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("iCol", "1"); // Pre14CRAPension
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmountRevaluing", "Fixed10000");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "CriticalRetAge");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactors");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "DefCRASpousesProportion");
            dic.Add("CommutationAmount", "DefCRACommutation");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "2"); // Pre14TPAPension
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmountRevaluing", "Fixed1000");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "TaperedRetAge");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "37.5000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Pst2008Commutation");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "3"); // Pre14Age65Pension
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmountRevaluing", "Fixed1000");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "DefAge65SpousesProportion");
            dic.Add("CommutationAmount", "DefAge65Commutation");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "4"); // PensionDebits
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmountRevaluing", "Fixed1000");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "PensionDebitFactor");
            dic.Add("SpousePercent_txt", "37.5000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Deferred(dic);


            dic.Clear();
            dic.Add("iCol", "5"); // Pst2014CAREpension
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmountRevaluing", "Fixed1000");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "Post2014NPA");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "30.6250%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "Post2014Commutation");
            pTranchedBenefit._TBL_Deferred(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "DefStandardRet");
            pAssumptions._Collapse(dic);



            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");





            #endregion

            #region Baseline - Provision - Tranched Benefit - DefDid

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "DefDid");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "DefDid");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "");
            dic.Add("Deferred", "Click");
            dic.Add("Pensioner", "");
            dic.Add("BaseAmountRevaluing", "false");
            dic.Add("BaseAmountNonRevaluing", "false");
            dic.Add("RevalueNonRevaluing", "false");
            dic.Add("CommutationAmtByTranche", "");
            pTranchedBenefit._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("iCol", "1"); // Pre14CRAPension
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmountRevaluing", "Fixed10000");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "CriticalRetAge");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactors");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "100.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "2"); // Pre14TPAPension
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmountRevaluing", "Fixed1000");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "TaperedRetAge");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "100.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Deferred(dic);


            dic.Clear();
            dic.Add("iCol", "3"); // Pre14Age65Pension
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmountRevaluing", "Fixed1000");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "100.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "4"); // PensionDebits
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmountRevaluing", "Fixed1000");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "PensionDebitFactor");
            dic.Add("SpousePercent_txt", "100.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Deferred(dic);


            dic.Clear();
            dic.Add("iCol", "5"); // Pst2014CAREpension
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmountRevaluing", "Fixed1000");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "Post2014NPA");
            dic.Add("RevaluationInDeferment", "COLA");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "ChildPenForDIDDISIH");
            dic.Add("SpousePercent_txt", "100.0000%");
            dic.Add("SpousePercent_cbo", "");
            dic.Add("CommutationAmount", "");
            pTranchedBenefit._TBL_Deferred(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "DefDid");
            pAssumptions._Collapse(dic);



            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");





            #endregion

            #region Baseline - Provision - Tranched Benefit - PenStandard & PenDAR

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "PenStandard");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "PenStandard");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "Click");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            dic.Add("CommutationAmtByTranche", "");
            pTranchedBenefit._PopVerify_Main(dic);



            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("BaseAmount", "Fixed10000");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "CeaseChildrensPensions");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "0.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Pensioner(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "PenDAR");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "PenDAR");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "Click");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            dic.Add("CommutationAmtByTranche", "");
            pTranchedBenefit._PopVerify_Main(dic);



            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("BaseAmount", "Fixed10000");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "CeaseChildrensPensions");
            dic.Add("IncreasesInPayment", "COLA");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Pensioner(dic);




            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            pAssumptions._Collapse(dic);


            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");





            #endregion




            #region Baseline  - Benefit Definition  - Tranched Benefit Plan Definition

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "ActRetPen");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "ActRetPen");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("TranchedBenefit", "ActStandardRet");
            dic.Add("FormOfPayment", "SingleLife");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "SalaryIncreaseAssumption");
            dic.Add("Decrement", "Retirement");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "ActRetSpDAR");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "ActRetSpDAR");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("TranchedBenefit", "ActStandardRet");
            dic.Add("FormOfPayment", "Reversionary");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "SalaryIncreaseAssumption");
            dic.Add("Decrement", "Retirement");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "ActWithPen");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "ActWithPen");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("TranchedBenefit", "ActWithdrawal");
            dic.Add("FormOfPayment", "SingleLife");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "SalaryIncreaseAssumption");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "ActWithSpDAR");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "ActWithSpDAR");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("TranchedBenefit", "ActWithdrawal");
            dic.Add("FormOfPayment", "Reversionary");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "SalaryIncreaseAssumption");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "ActWithSpDID");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "ActWithSpDID");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("TranchedBenefit", "ActWithdrawalDID");
            dic.Add("FormOfPayment", "SpousesDID");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "SalaryIncreaseAssumption");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "ActIHPen");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "ActIHPen");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("TranchedBenefit", "ActIH");
            dic.Add("FormOfPayment", "SingleLife");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "SalaryIncreaseAssumption");
            dic.Add("Decrement", "Disability");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "ActIHSpDAR");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "ActIHSpDAR");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("TranchedBenefit", "ActIHDAR");
            dic.Add("FormOfPayment", "Reversionary");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "SalaryIncreaseAssumption");
            dic.Add("Decrement", "Disability");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "ActDeathSpDIS");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "ActDeathSpDIS");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("TranchedBenefit", "ActDis");
            dic.Add("FormOfPayment", "SpousesImmediate");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "SalaryIncreaseAssumption");
            dic.Add("Decrement", "Death");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "DefRetPen");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "DefRetPen");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("TranchedBenefit", "DefStandardRet");
            dic.Add("FormOfPayment", "SingleLife");
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
            pAssumptions._TreeViewRightSelect(dic, "DefSpDAR");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "DefSpDAR");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("TranchedBenefit", "DefStandardRet");
            dic.Add("FormOfPayment", "Reversionary");
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
            pAssumptions._TreeViewRightSelect(dic, "DefSpDID");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "DefSpDID");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("TranchedBenefit", "DefDid");
            dic.Add("FormOfPayment", "SpousesDID");
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
            pAssumptions._TreeViewRightSelect(dic, "PenPen");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "PenPen");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Pensioners");
            dic.Add("TranchedBenefit", "PenStandard");
            dic.Add("FormOfPayment", "SingleLife");
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
            pAssumptions._TreeViewRightSelect(dic, "PenSpDAR");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "PenSpDAR");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Pensioners");
            dic.Add("TranchedBenefit", "PenStandard");
            dic.Add("FormOfPayment", "Reversionary");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            pAssumptions._Collapse(dic);



            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");


            #endregion

            #region Baseline  - Benefit Definition  - Non-Tranched Benefit Plan Definition

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "ActRetPre2008LS");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "ActRetPre2008LS");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "");
            dic.Add("ParticipantType", "");
            dic.Add("NonTranchedBenefit", "TotalPre08LumpSum");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "COLA");
            dic.Add("EarlyRetirement", "Pre2008LsERF");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "LumpSum");
            dic.Add("Decrement", "Retirement");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "click");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "Click");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "Click");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "ActWithPre2008LS");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "ActWithPre2008LS");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "");
            dic.Add("ParticipantType", "");
            dic.Add("NonTranchedBenefit", "TotalPre08LumpSum");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "Click");
            dic.Add("BenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_V_cbo", "LumpSumRetAge");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "COLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "LumpSum");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "click");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "Click");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "Click");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "ActIHPre2008Ls");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "ActIHPre2008Ls");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "");
            dic.Add("ParticipantType", "");
            dic.Add("NonTranchedBenefit", "TotalPre08LumpSum");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "COLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "LumpSum");
            dic.Add("Decrement", "Disability");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "click");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "Click");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "Click");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "ActDISLS");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "ActDISLS");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "");
            dic.Add("ParticipantType", "");
            dic.Add("NonTranchedBenefit", "DISLS");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "COLA");
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
            dic.Add("StartAgeForPost_C", "click");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "Click");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "Click");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "ActWithDIDCRALS");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "ActWithDIDCRALS");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "");
            dic.Add("ParticipantType", "");
            dic.Add("NonTranchedBenefit", "DIDLSCRA");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "Click");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("BenefitStopAge_V_cbo", "CriticalRetAge");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "COLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "LSDID");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "click");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "Click");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "Click");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "ActWithDIDTPDLS");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "ActWithDIDTPDLS");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "");
            dic.Add("ParticipantType", "");
            dic.Add("NonTranchedBenefit", "DIDLSTPD");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "Click");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("BenefitStopAge_V_cbo", "TaperedRetAge");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "COLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "LSDID");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "click");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "Click");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "Click");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "ActWithDIDAge65LS");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "ActWithDIDAge65LS");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "");
            dic.Add("ParticipantType", "");
            dic.Add("NonTranchedBenefit", "DIDLSAge65");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "65");
            dic.Add("CostOfLivingAdjustment", "COLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "LSDID");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "click");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "Click");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "Click");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "ActWithDIDPst2014LS");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "ActWithDIDPst2014LS");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "");
            dic.Add("ParticipantType", "");
            dic.Add("NonTranchedBenefit", "DIDLSPost2014");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "Click");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("BenefitStopAge_V_cbo", "Post2014NPA");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "COLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "LSDID");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "click");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "Click");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "Click");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "DefRetPre2008LS");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "DefRetPre2008LS");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("NonTranchedBenefit", "AccruedLumpSum");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "Click");
            dic.Add("BenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_V_cbo", "LumpSumRetAge");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "COLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "LumpSum");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "click");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "Click");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "Click");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "DefDIDCRALS");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "DefDIDCRALS");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("NonTranchedBenefit", "DefDIDLSCRA");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "Click");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("BenefitStopAge_V_cbo", "CriticalRetAge");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "COLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "LSDID");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "click");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "Click");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "Click");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "DefDIDTPDLS");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "DefDIDTPDLS");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("NonTranchedBenefit", "DefDIDLSTPD");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "Click");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("BenefitStopAge_V_cbo", "TaperedRetAge");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "COLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "LSDID");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "click");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "Click");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "Click");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "DefDIDAge65LS");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "DefDIDAge65LS");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("NonTranchedBenefit", "DefDIDLSAge65");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "65");
            dic.Add("CostOfLivingAdjustment", "COLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "LSDID");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "click");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "Click");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "Click");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);




            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "DefDIDPost2014LS");



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "DefDIDPost2014LS");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("NonTranchedBenefit", "DefDIDLSPost14");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "Click");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("BenefitStopAge_V_cbo", "Post2014NPA");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "COLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "LSDID");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "click");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "Click");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "Click");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);





            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            pAssumptions._Collapse(dic);



            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");


            #endregion



            #region Baseline - Methods

            pMain._SelectTab("31.3.2017Valuation");

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
            dic.Add("CostMethod", "Projected Unit Credit No Prorate");
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
            dic.Add("PopVerify", "Pop");
            dic.Add("AllowNegativeNormalCost", "");
            dic.Add("NormalCostForCYTermination_UK", "false");
            pMethods._PopVerify_Methods_Funding_GoningConcern(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("GMPAdjustment", "GMPAdjustmentFactors");
            pMethods_UK._GMPAdjustmentsToUse_Grid(dic);



            string sMsgInfo = "Grid: Adjust cost method defaults to use for a selected formula:";
            sMsgInfo = sMsgInfo + Environment.NewLine + "Benefit Set    " + "   Formula            " + "          PUC Override   ";
            sMsgInfo = sMsgInfo + Environment.NewLine + "AllMembers    " + "EmployeeConstAA    " + "Traditional Unit Credit   ";
            sMsgInfo = sMsgInfo + Environment.NewLine + "AllMembers    " + "Post2014CARE    " + "       Traditional Unit Credit   ";

            _gLib._MsgBox("Manual Interaction", sMsgInfo);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("PayProjection", "ActualSalaryProjection");
            dic.Add("EmployeeContribution", "AA1pcPay");
            dic.Add("StopPVFuture", "");
            pMethods_UK._AdditionalCalcuationRequest_Grid(dic);



            sMsgInfo = "Grid: Additional calculation requests:";
            sMsgInfo = sMsgInfo + Environment.NewLine + "Please select AllMembers in column <Benefit Set>";
            sMsgInfo = sMsgInfo + Environment.NewLine + "Please check on ActualSalaryProjection in column <Pay projection to use...>";
            sMsgInfo = sMsgInfo + Environment.NewLine + "Please check on all items under <Emoloyee contribution to use...>";
            sMsgInfo = sMsgInfo + Environment.NewLine + "AA1pcPay, EmployeeConstAA, EmployeeConstPU, PU1pcPay";


            _gLib._MsgBox("Manual Interaction", sMsgInfo);


            sMsgInfo = "PleaseUncheck <Beginning of the year PV.....>";
            sMsgInfo = sMsgInfo + Environment.NewLine + "Please check on <Aclculate present value future....>";
            sMsgInfo = sMsgInfo + Environment.NewLine + "And set its number to 12";


            _gLib._MsgBox("Manual Interaction", sMsgInfo);



            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);






            #endregion


            #region Baseline - Test Case

            pMain._SelectTab("31.3.2017Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.EmployeeIDNumber = \"A00000001\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);



            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("31.3.2017Valuation");



            #endregion




            #region Baseline - Run Liabilities - All

            pMain._SelectTab("31.3.2017Valuation");


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
            dic.Add("PayoutProjection", "");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("2DPayoutProjection", "True");
            dic.Add("Pay", "Actual5050PayPost2014CurrentYear");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("Major", "BenefitSetShortName");
            dic.Add("Intermediate", "Gender");
            dic.Add("Minor", "");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "True");
            dic.Add("AltFunding1", "False");
            dic.Add("AltFunding2", "False");
            dic.Add("AltFunding3", "False");
            dic.Add("Solvency", "False");
            dic.Add("PPFS179", "False");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "AllMembers");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectRecords", "");
            dic.Add("Validate", "");
            dic.Add("RunValuation", "");
            pMain._PopVerify_RunOptions(dic);


            _gLib._MsgBoxYesNo("Are you sure?", "Are you sure to submit this HUGE (110,000+ EE) ER run? ");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("31.3.2017Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);



            #endregion


            #region Defs and Pens - Run Liabilities

            pMain._SelectTab("31.3.2017Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Defs and Pens");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
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
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);



            pMain._SelectTab("31.3.2017Valuation");



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
            dic.Add("PayoutProjection", "");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("2DPayoutProjection", "True");
            dic.Add("Pay", "Actual5050PayPost2014CurrentYear");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("Major", "BenefitSetShortName");
            dic.Add("Intermediate", "Gender");
            dic.Add("Minor", "");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "True");
            dic.Add("AltFunding1", "False");
            dic.Add("AltFunding2", "False");
            dic.Add("AltFunding3", "False");
            dic.Add("Solvency", "False");
            dic.Add("PPFS179", "False");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "AllMembers");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectRecords", "$emp.USC<>\"Act\"");
            dic.Add("Validate", "Click");
            dic.Add("RunValuation", "");
            pMain._PopVerify_RunOptions(dic);


            _gLib._MsgBoxYesNo("Are you sure?", "Are you sure to submit this HUGE (110,000+ EE) ER run? ");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("31.3.2017Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);



            #endregion


            #region Active Males - Run Liabilitie

            pMain._SelectTab("31.3.2017Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Active Males");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
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
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);



            pMain._SelectTab("31.3.2017Valuation");



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
            dic.Add("PayoutProjection", "");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("2DPayoutProjection", "True");
            dic.Add("Pay", "Actual5050PayPost2014CurrentYear");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("Major", "BenefitSetShortName");
            dic.Add("Intermediate", "Gender");
            dic.Add("Minor", "");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "True");
            dic.Add("AltFunding1", "False");
            dic.Add("AltFunding2", "False");
            dic.Add("AltFunding3", "False");
            dic.Add("Solvency", "False");
            dic.Add("PPFS179", "False");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "AllMembers");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectRecords", "$emp.USC<>\"Act\" and $emp.Gender=\"M\"");
            dic.Add("Validate", "Click");
            dic.Add("RunValuation", "");
            pMain._PopVerify_RunOptions(dic);


            _gLib._MsgBoxYesNo("Are you sure?", "Are you sure to submit this HUGE (110,000+ EE) ER run? ");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("31.3.2017Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);



            #endregion


            _gLib._MsgBox("Congratulations", "Completed");
        }



        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {

            if (bSmall_Data)
            {
                sDataFile = sDataFile_Small;
                sDataFileName = sDataFileName_Small;
                sUnique_NoMatch_Num = sUnique_NoMatch_Num_Small;
            }
            else{
                sDataFile = sDataFile_Large;
                sDataFileName = sDataFileName_Large;
                sUnique_NoMatch_Num = sUnique_NoMatch_Num_Large;
            }
                

        }


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
