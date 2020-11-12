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
using RetirementStudio._UIMaps.ServiceSelectionClasses;


// CA Screens
using RetirementStudio._UIMaps.DefinedBenefitLimitIncreaseClasses;


// DE Screens
using RetirementStudio._UIMaps.AssumedRetirementAgeClasses;
using RetirementStudio._UIMaps.ContractualRetirementAgeClasses;
using RetirementStudio._UIMaps.JubileeBenefitClasses;
using RetirementStudio._UIMaps.PlanDefinition_DEClasses;


namespace RetirementStudio._TestScripts_NL
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class NL003_CN
    {
        public NL003_CN()
        {

            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.NL;
            Config.sClientName = "QA NL Benchmark 003 Create New";
            Config.sPlanName = "QA NL Benchmark 003 Create New Plan";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;

        }


        #region Report Output Directory

        public string sAccounting_Valuation2009 = "";
        public string sAccounting_Valuation2009_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_003\Production\6.9.1_20160928_B\";

        String sTable_SALSC05 = "";
        String sTable_QB0005_Male = "";
        String sTable_QB0005_FeMale = "";
        String sTable_WDL2005 = "";
        String sTable_UKV2007IV_Male = "";
        String sTable_UKV2007IV_FeMale = "";


        public void GenerateReportOuputDir()
        {
            pMain._SetLanguageAndRegional();
            //////if (MessageBox.Show("Click <Yes> to save in R: drive OR <No> to save in Local", "Please choose where to put your reports!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //////{
            _BenchmarkUser sCurrentUser = _gLib._ReturnCurrentUser();
            if (sCurrentUser.ToString() == "Others")
            {
                _gLib._MsgBox("Warning !!!", "Your are NOT allowed to create folders in \\mercer.com\\US_Data\\Shared\\Dfl\\Data1\\RSS\\SQA drive, Please contact Cindy or Webber if you have to!");
                Environment.Exit(0);
            }
            else
            {
                string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_003\CreateNew\Valuation 2009\";
                string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                ////////////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                sAccounting_Valuation2009 = _gLib._CreateDirectory(sMainDir + sPostFix + "\\");

            }

            ////////////////////////}
            ////////////////////////else
            ////////////////////////{
            ////////////////////////    // get the main reports directory
            ////////////////////////    string sDir = Directory.GetCurrentDirectory();
            ////////////////////////    for (int i = 0; i < 3; i++)
            ////////////////////////    {
            ////////////////////////        DirectoryInfo info = Directory.GetParent(sDir);
            ////////////////////////        sDir = info.FullName;
            ////////////////////////    }

            ////////////////////////    /// this is for VS2012 folder structure
            ////////////////////////    sDir = sDir + "\\" + Config._ReturnProjectName() + "\\_Reports\\";

            ////////////////////////    ////////sDir = sDir + "\\_TestLog\\";

            ////////////////////////    string sMainDir = sDir + "NL003_" + _gLib._ReturnDateStampYYYYMMDD();

            ////////////////////////    ////////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

            ////////////////////////    _gLib._CreateDirectory(sMainDir);
            ////////////////////////    sAccounting_Valuation2009 = _gLib._CreateDirectory(sMainDir + "\\sAccounting_Valuation2009\\");

            ////////////////////////}

            string sContent = "";
            sContent = sContent + "sAccounting_Valuation2009 = @\"" + sAccounting_Valuation2009 + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);


        }


        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();
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
        public ServiceSelection pServiceSelection = new ServiceSelection();


        #endregion


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_NL003_CN()
        {

            this.GenerateReportOuputDir();


            #region Data2009


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
            dic.Add("ClientCode", "0000");
            dic.Add("FiscalYearEnd", "12/31");
            dic.Add("MeasurementDate", "12/31");
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
            dic.Add("PlanYearBegin", "01/01");
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
            dic.Add("Name", "Data2009");
            dic.Add("EffectiveDate", "1-1-2009");
            dic.Add("Parent", "");
            dic.Add("RSC", "");
            dic.Add("Shared", "");
            dic.Add("GeneralUse", "True");
            dic.Add("Conversion", "");
            dic.Add("CopyDataService", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_DataServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Data2009");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("Level_1", "Data2009");
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
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\NL003\Schiphol jubileum - input 2009 - Fixed FLO.xls");
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

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Data2009");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);

            pData._CV_ExpandPersonalInformation();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Personal Information");
            dic.Add("Label", "IngangsleeftijdFLO");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
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
            dic.Add("Category", "Pay");
            dic.Add("Label", "Pay1");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "0");
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
            dic.Add("Category", "Hours");
            dic.Add("Label", "Hours1");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "0");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, false);



            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Data2009");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Import2009");
            dic.Add("FileType", "Excel file");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "Schipholjubileuminput2009FixedFLO.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._SelectTab("Mapping");

            pData._IP_Mapping_Initialize("Personal Information", "Classification Codes", 1, 0, 1, "OrganizationCode");
            pData._IP_Mapping_Initialize("Personal Information", "DB Information", 1, 0, 1, "MembershipDate1");
            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "EmployeeIDNumber");


            pData._IP_Mapping_Initialize("Personal Information", "Hours", 2, 0, 1, "Hours1");
            pData._IP_Mapping_Initialize("Personal Information", "Hours1", 3, 0, 1, "Hours1CurrentYear");

            pData._IP_Mapping_Initialize("Personal Information", "Pay", 2, 0, 1, "Pay1");
            pData._IP_Mapping_Initialize("Personal Information", "Pay1", 3, 0, 1, "Pay1CurrentYear");


            pData._IP_Mapping_MapField("EmployeeIDNumber", "personeelsnr#", 0, false);
            pData._IP_Mapping_MapField("Name", "werknemer", 0, true);
            pData._IP_Mapping_MapField("BirthDate", "geboortedatum", 0, true);

            pData._IP_Mapping_MapField("HireDate1", "datum in dienst", 0, true);
            pData._IP_Mapping_MapField("Pay1CurrentYear", "totaal bruto jaarsalaris", 10, true);
            pData._IP_Mapping_MapField("Hours1CurrentYear", "uren", 0, true);

            pData._IP_Mapping_MapField("IngangsleeftijdFLO", "FLO", 0, true);
            pData._IP_Mapping_MapField("PTCurrent", "deeltijdfactor", 10, true);
            pData._IP_Mapping_MapField("SERPFlag", "Boventallig?", 10, true);


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
            dic.Add("DerivedField", "Gender");
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
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Formula", "=\"M\"");
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
            dic.Add("DerivedField", "ParticipantStatus");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInpuFtFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=\"AC\"");
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
            dic.Add("DerivedField", "HealthStatus");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInpuFtFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=\"H\"");
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
            dic.Add("DerivedField", "AliveStatus");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInpuFtFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=\"XY\"");
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
            dic.Add("DerivedField", "PayStatus");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInpuFtFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=\"DEF\"");
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
            dic.Add("Unique_NoMatch_Num", "2063");
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
            dic.Add("Level_1", "Data2009");
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
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("SelectSampleRecords_Formula", "");
            dic.Add("SelectSampleRecords_Accept", "");
            dic.Add("SelectSampleRecords_Apply", "");
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
            dic.Add("SelectInpuFtFields", "");
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


            dic.Clear();
            dic.Add("Level_1", "Data2009");
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
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
            dic.Add("SnapshotName", "Import2009");
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


            #region Valuation 2009 - Participant Data

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
            dic.Add("Name", "Valuation 2009");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "2009");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "");
            dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "Click");
            dic.Add("SelectAllVO", "");
            dic.Add("DeselectAll", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2009");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Valuation 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Valuation Node Properties");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "");
            dic.Add("LiabilityValuationDate", "31-12-2009");
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
            dic.Add("DataEffectiveDate", "01-01-2009");
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
            dic.Add("SnapshotName", "Import2009");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "");
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


            pMain._SelectTab("Valuation 2009");

            sTable_SALSC05 = sTable_SALSC05 + "0,000000" + Environment.NewLine;

            for (int iAge = 16; iAge <= 34; iAge++)
                sTable_SALSC05 = sTable_SALSC05 + "0,050000" + Environment.NewLine;

            for (int iAge = 35; iAge <= 45; iAge++)
                sTable_SALSC05 = sTable_SALSC05 + "0,040000" + Environment.NewLine;

            for (int iAge = 46; iAge <= 54; iAge++)
                sTable_SALSC05 = sTable_SALSC05 + "0,030000" + Environment.NewLine;

            for (int iAge = 55; iAge <= 75; iAge++)
                sTable_SALSC05 = sTable_SALSC05 + "0,020000" + Environment.NewLine;

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "SALSC05");
            dic.Add("Type", "Salary Scale");
            dic.Add("Description", "");
            dic.Add("Ultimate", "");
            dic.Add("Generational", "");
            dic.Add("TwoDimensional", "");
            dic.Add("Index1_Index", "");
            dic.Add("Index1_From", "");
            dic.Add("Index1_To", "");
            dic.Add("Extend", "");
            dic.Add("Zero", "");
            dic.Add("SameRatesUsed", "True");
            dic.Add("Format", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("OK", "Click");
            dic.Add("sUnisexRates", sTable_SALSC05);
            dic.Add("sMaleRates", "");
            dic.Add("sFemaleRates", "");
            pMain._ts_AddTable(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Valuation 2009");


            sTable_QB0005_Male = sTable_QB0005_Male + "0,00022063" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00027492" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00034821" + Environment.NewLine;

            sTable_QB0005_Male = sTable_QB0005_Male + "0,00042106" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00049602" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00055988" + Environment.NewLine;

            sTable_QB0005_Male = sTable_QB0005_Male + "0,00059696" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00059055" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00059686" + Environment.NewLine;

            sTable_QB0005_Male = sTable_QB0005_Male + "0,00057890" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00056921" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00057318" + Environment.NewLine;

            sTable_QB0005_Male = sTable_QB0005_Male + "0,00057848" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00059515" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00061377" + Environment.NewLine;

            sTable_QB0005_Male = sTable_QB0005_Male + "0,00062501" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00066067" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00068836" + Environment.NewLine;

            sTable_QB0005_Male = sTable_QB0005_Male + "0,00072598" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00075940" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00079748" + Environment.NewLine;

            sTable_QB0005_Male = sTable_QB0005_Male + "0,00085024" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00090955" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00098947" + Environment.NewLine;

            sTable_QB0005_Male = sTable_QB0005_Male + "0,00106562" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00116709" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00129843" + Environment.NewLine;

            sTable_QB0005_Male = sTable_QB0005_Male + "0,00145911" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00160391" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00179222" + Environment.NewLine;

            sTable_QB0005_Male = sTable_QB0005_Male + "0,00198459" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00221269" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00243562" + Environment.NewLine;

            sTable_QB0005_Male = sTable_QB0005_Male + "0,00268338" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00296512" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00330713" + Environment.NewLine;

            sTable_QB0005_Male = sTable_QB0005_Male + "0,00365145" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00405502" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00442668" + Environment.NewLine;

            sTable_QB0005_Male = sTable_QB0005_Male + "0,00489015" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00541247" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00595729" + Environment.NewLine;

            sTable_QB0005_Male = sTable_QB0005_Male + "0,00659476" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00730072" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00803272" + Environment.NewLine;

            sTable_QB0005_Male = sTable_QB0005_Male + "0,00890102" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,00981554" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,01087560" + Environment.NewLine;

            sTable_QB0005_Male = sTable_QB0005_Male + "0,01202858" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,01335922" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,01492572" + Environment.NewLine;

            sTable_QB0005_Male = sTable_QB0005_Male + "0,01664809" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,01862399" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,02077602" + Environment.NewLine;

            sTable_QB0005_Male = sTable_QB0005_Male + "0,02311913" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,02591606" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,02897898" + Environment.NewLine;

            sTable_QB0005_Male = sTable_QB0005_Male + "0,03227344" + Environment.NewLine;
            sTable_QB0005_Male = sTable_QB0005_Male + "0,03594699" + Environment.NewLine;




            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00044336" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00048533" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00053485" + Environment.NewLine;

            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00059457" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00065237" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00071555" + Environment.NewLine;

            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00079977" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00088082" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00098851" + Environment.NewLine;

            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00110383" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00123540" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00139722" + Environment.NewLine;

            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00158633" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00179503" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00200921" + Environment.NewLine;

            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00220214" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00243376" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00262669" + Environment.NewLine;

            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00284290" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00302689" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00323798" + Environment.NewLine;

            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00350761" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00380565" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00410286" + Environment.NewLine;

            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00441427" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00477248" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00518400" + Environment.NewLine;

            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00560949" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00608859" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00652723" + Environment.NewLine;

            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00709972" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00772058" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00841340" + Environment.NewLine;

            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,00918219" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,01010860" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,01122645" + Environment.NewLine;

            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,01246569" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,01389084" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,01550835" + Environment.NewLine;

            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,01726711" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,01930439" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,02148018" + Environment.NewLine;
            sTable_QB0005_FeMale = sTable_QB0005_FeMale + "0,02408104" + Environment.NewLine;


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "QB0005");
            dic.Add("Type", "Death Decrements");
            dic.Add("Description", "");
            dic.Add("Ultimate", "");
            dic.Add("Generational", "");
            dic.Add("TwoDimensional", "");
            dic.Add("Index1_Index", "");
            dic.Add("Index1_From", "17");
            dic.Add("Index1_To", "120");
            dic.Add("Extend", "Click");
            dic.Add("Zero", "");
            dic.Add("SameRatesUsed", "false");
            dic.Add("Format", "");
            dic.Add("DecimalPlaces", "8");
            dic.Add("OK", "Click");
            dic.Add("sUnisexRates", "");
            dic.Add("sMaleRates", sTable_QB0005_Male);
            dic.Add("sFemaleRates", sTable_QB0005_FeMale);
            pMain._ts_AddTable(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Valuation 2009");


            sTable_WDL2005 = sTable_WDL2005 + "0,00000" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,00000" + Environment.NewLine;

            for (int i = 17; i <= 25; i++)
                sTable_WDL2005 = sTable_WDL2005 + "0,04200" + Environment.NewLine;

            sTable_WDL2005 = sTable_WDL2005 + "0,04000" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,03800" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,03600" + Environment.NewLine;

            sTable_WDL2005 = sTable_WDL2005 + "0,03400" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,03200" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,03000" + Environment.NewLine;

            sTable_WDL2005 = sTable_WDL2005 + "0,02800" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,02600" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,02400" + Environment.NewLine;

            sTable_WDL2005 = sTable_WDL2005 + "0,02000" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,02000" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,01900" + Environment.NewLine;

            sTable_WDL2005 = sTable_WDL2005 + "0,01800" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,01700" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,01600" + Environment.NewLine;

            sTable_WDL2005 = sTable_WDL2005 + "0,01500" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,01400" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,01300" + Environment.NewLine;

            sTable_WDL2005 = sTable_WDL2005 + "0,01200" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,01100" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,01000" + Environment.NewLine;

            sTable_WDL2005 = sTable_WDL2005 + "0,01000" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,00900" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,00900" + Environment.NewLine;

            sTable_WDL2005 = sTable_WDL2005 + "0,00800" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,00700" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,00600" + Environment.NewLine;

            sTable_WDL2005 = sTable_WDL2005 + "0,00500" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,00400" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,00300" + Environment.NewLine;

            sTable_WDL2005 = sTable_WDL2005 + "0,00300" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,00200" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,00200" + Environment.NewLine;

            sTable_WDL2005 = sTable_WDL2005 + "0,00100" + Environment.NewLine;
            sTable_WDL2005 = sTable_WDL2005 + "0,00100" + Environment.NewLine;

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "WDL2005");
            dic.Add("Type", "Withdrawal Decrements");
            dic.Add("Description", "");
            dic.Add("Ultimate", "");
            dic.Add("Generational", "");
            dic.Add("TwoDimensional", "");
            dic.Add("Index1_Index", "");
            dic.Add("Index1_From", "15");
            dic.Add("Index1_To", "120");
            dic.Add("Extend", "");
            dic.Add("Zero", "true");
            dic.Add("SameRatesUsed", "True");
            dic.Add("Format", "");
            dic.Add("DecimalPlaces", "5");
            dic.Add("OK", "Click");
            dic.Add("sUnisexRates", sTable_WDL2005);
            dic.Add("sMaleRates", "");
            dic.Add("sFemaleRates", "");
            pMain._ts_AddTable(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Valuation 2009");


            for (int i = 15; i <= 22; i++)
                sTable_UKV2007IV_Male = sTable_UKV2007IV_Male + "0,00062000" + Environment.NewLine;

            for (int i = 23; i <= 32; i++)
                sTable_UKV2007IV_Male = sTable_UKV2007IV_Male + "0,00121000" + Environment.NewLine;

            for (int i = 33; i <= 42; i++)
                sTable_UKV2007IV_Male = sTable_UKV2007IV_Male + "0,00170000" + Environment.NewLine;

            for (int i = 43; i <= 52; i++)
                sTable_UKV2007IV_Male = sTable_UKV2007IV_Male + "0,00313000" + Environment.NewLine;

            for (int i = 53; i <= 58; i++)
                sTable_UKV2007IV_Male = sTable_UKV2007IV_Male + "0,00342000" + Environment.NewLine;

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "UKV2007IV");
            dic.Add("Type", "Disability Decrements");
            dic.Add("Description", "");
            dic.Add("Ultimate", "");
            dic.Add("Generational", "");
            dic.Add("TwoDimensional", "");
            dic.Add("Index1_Index", "");
            dic.Add("Index1_From", "15");
            dic.Add("Index1_To", "120");
            dic.Add("Extend", "true");
            dic.Add("Zero", "");
            dic.Add("SameRatesUsed", "false");
            dic.Add("Format", "");
            dic.Add("DecimalPlaces", "8");
            dic.Add("OK", "Click");
            dic.Add("sUnisexRates", "");
            dic.Add("sMaleRates", sTable_UKV2007IV_Male);
            dic.Add("sFemaleRates", "");
            pMain._ts_AddTable(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Valuation 2009 - Assumption & Provision

            pMain._SelectTab("Valuation 2009");

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
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "5,0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


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
            dic.Add("btnT", "Click");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "SALSC05");
            pPayIncrease._PopVerify_PayIncrease(dic);

            pMain._Home_ToolbarClick_Top(true);



            pMain._SelectTab("Valuation 2009");

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
            pAssumptions._TreeViewRightSelect(dic, "ExactAge");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Age");
            dic.Add("Level_3", "ExactAge");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Age");
            dic.Add("MenuItem", "Add Age");
            pAssumptions._TreeViewRightSelect(dic, "PensionAge");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Age");
            dic.Add("Level_3", "PensionAge");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "IF($emp.IngangsleeftijdFLO>0)"
                + Environment.NewLine + "$emp.IngangsleeftijdFLO " + Environment.NewLine + "Else 65");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "BSDJ");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BSDJ");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IRUK", "True");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "Click");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("MaximumService_UseServiceCap", "40");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "Click");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "65");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "");
            dic.Add("RoundingPeriod", "");
            dic.Add("RoundingMethod", "");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "Click");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "1,0");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "ServiceAtValidate");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "ServiceAtValidate");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IRUK", "True");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "Click");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("MaximumService_UseServiceCap", "40");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "Click");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "65");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "");
            dic.Add("RoundingPeriod", "");
            dic.Add("RoundingMethod", "");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "Click");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "0,0");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);




            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "Pensioenleeftijd");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "Pensioenleeftijd");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "Click");
            dic.Add("UseServiceCa", "");
            dic.Add("ForInternationalAccounting_DE", "");
            dic.Add("ForTrade_DE", "");
            dic.Add("CalculateExactServiceAtReitermentAge_UK", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "");
            dic.Add("Expression", "If ($ExactAge<$ValAge) " + Environment.NewLine + "ToInt($PensionAge) " + Environment.NewLine + "Else ToInt($PensionAge)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


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
            dic.Add("Formula", "$emp.ParticipantStatus = \"AC\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "ActivesUnder65");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "ActivesUnder65");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.ParticipantStatus = \"AC\" and $Age<$Pensioenleeftijd");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Deferreds");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Deferreds");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.ParticipantStatus = \"IN\" and $emp.PayStatus=\"DEF\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "ActivesBornAfter1955");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "ActivesBornAfter1955");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.ParticipantStatus = \"AC\" and $emp.BirthDate>ToDate(1956,1,1)");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "ExactHireAgePlus10STAge");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "ExactHireAgePlus10STAge");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$ExactHireAge+10<$ExactValAge");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "ExactHireAgePlus20STAge");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "ExactHireAgePlus20STAge");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$ExactHireAge+20<$ExactValAge");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "ExactHireAgePlus30STAge");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "ExactHireAgePlus30STAge");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$ExactHireAge+30<$ExactValAge");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "ExactHireAgePlus40STAge");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "ExactHireAgePlus40STAge");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$ExactHireAge+40<$ExactValAge");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "ActivesInServiceMoreThan10Year");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "ActivesInServiceMoreThan10Year");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$BSDJ>10 And NOT ($ActivesBornAfter1955)");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            pAssumptions._Collapse(dic);


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "SalaryIncrease");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "SalaryIncrease");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "");
            dic.Add("PresentYear", "Click");
            dic.Add("FunctionOfOtherProjections", "");
            dic.Add("CustomCode", "");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "False");
            dic.Add("LegislatedPayLimitDefinition", "");
            pPayoutProjection._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UseCurrentYearPayRateFrom", "Pay1CurrentYear");
            dic.Add("PayIncreaseAssumption", "PayIncrease1");
            pPayoutProjection._PopVerify_PresentYear(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service Selection");
            dic.Add("MenuItem", "Add Service Selection");
            pAssumptions._TreeViewRightSelect(dic, "ServiceAtAge65");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service Selection");
            dic.Add("Level_3", "ServiceAtAge65");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("BaseServiceProjection", "BSDJ");
            dic.Add("V", "");
            dic.Add("C", "");
            dic.Add("SelectServiceAtAge_cbo", "");
            dic.Add("SelectServiceAtAge_txt", "");
            pServiceSelection._PopVerify_ServiceSelection(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Valuation 2009");


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
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "QB0005");
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
            dic.Add("cboPreDefinedEligibility", "ActivesUnder65");
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
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "WDL2005");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "ActivesUnder65");
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
            dic.Add("RetWithdrawDis", "UKV2007IV");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "ActivesUnder65");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Benefit Elections");
            dic.Add("MenuItem", "Add Benefit Elections");
            pAssumptions._TreeViewRightSelect(dic, "NewBenefitElections1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Benefit Elections");
            dic.Add("Level_3", "NewBenefitElections1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Valuation 2009");


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
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "AwardAtAge65");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("Level_4", "AwardAtAge65");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "If ($Age=$Pensioenleeftijd) "
                + Environment.NewLine + "$SalaryIncrease*0.08 " + Environment.NewLine + "Else 0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("Level_4", "AwardAtAge65");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("Level_4", "AwardAtAge65");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "IF($Age=$Pensioenleeftijd) "
                + Environment.NewLine + "$SalaryIncrease*0.16 " + Environment.NewLine + "Else 0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "ActivesInServiceMoreThan10Year");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("Level_4", "AwardAtAge65");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("Level_4", "AwardAtAge65");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

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
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "ActivesBornAfter1955");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("MenuItem", "Add Jubilee Benefit");
            pAssumptions._TreeViewRightSelect(dic, "Jubilee_10_year_award");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("Level_4", "Jubilee_10_year_award");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Eligibility_Years", "10,00");
            dic.Add("Benefit_PayProjection", "SalaryIncrease");
            dic.Add("Benefit_PercentOfPay", "2,00");
            dic.Add("Benefit_ServiceForProration", "BSDJ");
            dic.Add("Benefit_PartTimeFactor", "PTCurrent");
            pJubileeBenefit._PopVerify_SalaryRelated(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("Level_4", "Jubilee_10_year_award");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("Level_4", "Jubilee_10_year_award");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FixedAmount", "true");
            dic.Add("Eligibility_Years", "10,00");
            dic.Add("Benefit_ServiceForProration", "BSDJ");
            pJubileeBenefit._PopVerify_FixedAmount_NL(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "ExactHireAgePlus10STAge");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("MenuItem", "Add Jubilee Benefit");
            pAssumptions._TreeViewRightSelect(dic, "Jubilee_20_year_award");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("Level_4", "Jubilee_20_year_award");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Eligibility_Years", "20,00");
            dic.Add("Benefit_PayProjection", "SalaryIncrease");
            dic.Add("Benefit_PercentOfPay", "4,00");
            dic.Add("Benefit_ServiceForProration", "BSDJ");
            dic.Add("Benefit_PartTimeFactor", "PTCurrent");
            pJubileeBenefit._PopVerify_SalaryRelated(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("Level_4", "Jubilee_20_year_award");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("Level_4", "Jubilee_20_year_award");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FixedAmount", "true");
            dic.Add("Eligibility_Years", "20,00");
            dic.Add("Benefit_ServiceForProration", "BSDJ");
            pJubileeBenefit._PopVerify_FixedAmount_NL(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "ExactHireAgePlus20STAge");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("MenuItem", "Add Jubilee Benefit");
            pAssumptions._TreeViewRightSelect(dic, "Jubilee_30_year_award");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("Level_4", "Jubilee_30_year_award");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Eligibility_Years", "30,00");
            dic.Add("Benefit_PayProjection", "SalaryIncrease");
            dic.Add("Benefit_PercentOfPay", "8,00");
            dic.Add("Benefit_ServiceForProration", "BSDJ");
            dic.Add("Benefit_PartTimeFactor", "PTCurrent");
            pJubileeBenefit._PopVerify_SalaryRelated(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("Level_4", "Jubilee_30_year_award");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("Level_4", "Jubilee_30_year_award");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FixedAmount", "true");
            dic.Add("Eligibility_Years", "30,00");
            dic.Add("Benefit_ServiceForProration", "BSDJ");
            pJubileeBenefit._PopVerify_FixedAmount_NL(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "ExactHireAgePlus30STAge");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("MenuItem", "Add Jubilee Benefit");
            pAssumptions._TreeViewRightSelect(dic, "Jubilee_40_year_award");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("Level_4", "Jubilee_40_year_award");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Eligibility_Years", "40,00");
            dic.Add("Benefit_PayProjection", "SalaryIncrease");
            dic.Add("Benefit_PercentOfPay", "8,00");
            dic.Add("Benefit_ServiceForProration", "BSDJ");
            dic.Add("Benefit_PartTimeFactor", "PTCurrent");
            pJubileeBenefit._PopVerify_SalaryRelated(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("Level_4", "Jubilee_40_year_award");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("Level_4", "Jubilee_40_year_award");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FixedAmount", "true");
            dic.Add("Eligibility_Years", "40,00");
            dic.Add("Benefit_ServiceForProration", "BSDJ");
            pJubileeBenefit._PopVerify_FixedAmount_NL(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "ExactHireAgePlus40STAge");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("MenuItem", "Add Jubilee Benefit");
            pAssumptions._TreeViewRightSelect(dic, "Jubilee_at_PensionAge");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("Level_4", "Jubilee_at_PensionAge");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FixedAmount", "true");
            dic.Add("Eligibility_Years", "65,00");
            dic.Add("Eligibility_From", "BirthDate");
            dic.Add("Benefit_ServiceForProration", "BSDJ");
            pJubileeBenefit._PopVerify_FixedAmount_NL(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("Level_4", "Jubilee_at_PensionAge");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("Level_4", "Jubilee_at_PensionAge");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Eligibility_Years", "65,00");
            dic.Add("Eligibility_From", "BirthDate");
            dic.Add("Benefit_PayProjection", "SalaryIncrease");
            dic.Add("Benefit_PercentOfPay", "16,00");
            dic.Add("Benefit_ServiceForProration", "BSDJ");
            dic.Add("Benefit_PartTimeFactor", "PTCurrent");
            pJubileeBenefit._PopVerify_SalaryRelated(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "ActivesInServiceMoreThan10Year");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("Level_4", "Jubilee_at_PensionAge");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("Level_4", "Jubilee_at_PensionAge");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FixedAmount", "true");
            dic.Add("Eligibility_Years", "65,00");
            dic.Add("Eligibility_From", "BirthDate");
            dic.Add("Benefit_ServiceForProration", "BSDJ");
            pJubileeBenefit._PopVerify_FixedAmount_NL(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "ActivesBornAfter1955");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("MenuItem", "Add Jubilee Benefit");
            pAssumptions._TreeViewRightSelect(dic, "Jubilee_Zero_Benefit");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Jubilee Benefit");
            dic.Add("Level_4", "Jubilee_Zero_Benefit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FixedAmount", "true");
            dic.Add("Eligibility_Years", "10,00");
            dic.Add("Eligibility_From", "");
            dic.Add("Benefit_ServiceForProration", "BSDJ");
            pJubileeBenefit._PopVerify_FixedAmount_NL(dic);


            pMain._Home_ToolbarClick_Top(true);


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
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "Lumpsum");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "Lumpsum");
            dic.Add("Level_4", "Default");
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
            dic.Add("Level_1", "Provisions");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Active_10_year_award");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Active_10_year_award");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "Jubilee_10_year_award");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "Click");
            dic.Add("BenefitStopAge_cbo", "Pensioenleeftijd");
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
            dic.Add("FormOfPayment", "Lumpsum");
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
            pAssumptions._TreeViewRightSelect(dic, "Active_20_year_award");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Active_20_year_award");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "Jubilee_20_year_award");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "Click");
            dic.Add("BenefitStopAge_cbo", "Pensioenleeftijd");
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
            dic.Add("FormOfPayment", "Lumpsum");
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
            pAssumptions._TreeViewRightSelect(dic, "Active_30_year_award");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Active_30_year_award");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "Jubilee_30_year_award");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "Click");
            dic.Add("BenefitStopAge_cbo", "Pensioenleeftijd");
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
            dic.Add("FormOfPayment", "Lumpsum");
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
            pAssumptions._TreeViewRightSelect(dic, "Active_40_year_award");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Active_40_year_award");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "Jubilee_40_year_award");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "Click");
            dic.Add("BenefitStopAge_cbo", "Pensioenleeftijd");
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
            dic.Add("FormOfPayment", "Lumpsum");
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
            pAssumptions._TreeViewRightSelect(dic, "Active_award_PensionAge");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Active_award_PensionAge");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "AwardAtAge65");
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
            dic.Add("FormOfPayment", "Lumpsum");
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

            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region Valuation 2009 - Run Test Case & reports

            pMain._SelectTab("Valuation 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"7/31/1969\" And $emp.HireDate1=\"8/20/1994\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Valuation 2009");

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
            dic.Add("ServiceForServiceProrate", "BSDJ");
            dic.Add("CompareToAccrue", "false");
            dic.Add("AllowNegativeNormalCost", "");
            dic.Add("ProjectedpayToUse", "");
            dic.Add("ProjectedpayToUse_CA", "");
            dic.Add("AccumulationToUse", "");
            dic.Add("IncludeExitYearValue", "True");
            dic.Add("CalculatePresentValueOfFuture", "");
            dic.Add("CalculatePresentValueOfFuture_txt", "");
            dic.Add("VestingToUseForAgeFirstVested", "ImmediateVesting");
            dic.Add("AverageWorkingLifeTime", "");
            dic.Add("AverageLifeTime", "");
            dic.Add("AverageWorkingLifeTimeToVesting", "");
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


            pMain._SelectTab("Valuation 2009");


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
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "Pay1CurrentYear");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "Click");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "#1#");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "");
            dic.Add("SolvencyLiability", "");
            dic.Add("WindUpLiability", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Valuation 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "Click");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "");
            pOutputManager._PopVerify_OutputManager(dic);

            pOutputManager._ExportReport_Common(sAccounting_Valuation2009, "Valuation Summary", "Conversion", true, false);
            pOutputManager._ExportReport_Others(sAccounting_Valuation2009, "Parameter Print", "Conversion", true, false);
            pOutputManager._ExportReport_Others(sAccounting_Valuation2009, "Test Cases", "Conversion", true, false);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sAccounting_Valuation2009, "Liability Summary", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sAccounting_Valuation2009, "Liability Summary", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Common(sAccounting_Valuation2009, "Member Statistics", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sAccounting_Valuation2009, "Conversion Diagnostic", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Others(sAccounting_Valuation2009, "Conversion Diagnostic", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sAccounting_Valuation2009, "Test Case List", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sAccounting_Valuation2009, "Detailed Results", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sAccounting_Valuation2009, "Individual Output", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sAccounting_Valuation2009, "Payout Projection", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sAccounting_Valuation2009, "FAS Expected Benefit Pmts", "Conversion", true, false);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sAccounting_Valuation2009, "Liability Summary", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sAccounting_Valuation2009, "Liability Summary", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Common(sAccounting_Valuation2009, "Member Statistics", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sAccounting_Valuation2009, "Conversion Diagnostic", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Others(sAccounting_Valuation2009, "Conversion Diagnostic", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sAccounting_Valuation2009, "Test Case List", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sAccounting_Valuation2009, "Detailed Results", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sAccounting_Valuation2009, "Detailed Results by Plan Def", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sAccounting_Valuation2009, "Valuation Summary", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sAccounting_Valuation2009, "Individual Output", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sAccounting_Valuation2009, "IOE", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sAccounting_Valuation2009, "Payout Projection", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sAccounting_Valuation2009, "FAS Expected Benefit Pmts", "Conversion", false, false);
            }


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("NL003CN", sAccounting_Valuation2009_Prod, sAccounting_Valuation2009);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sAccounting_Valuation2009");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_ActiveMembers.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_DeferredMembers.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_Pensioners.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByNone.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByStatusCodes.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByCustom_Gender.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("TestCaseList.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0, true);
            }

            pMain._SelectTab("Valuation 2009");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            _gLib._MsgBox("Congratulations!", "Finished!");


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
