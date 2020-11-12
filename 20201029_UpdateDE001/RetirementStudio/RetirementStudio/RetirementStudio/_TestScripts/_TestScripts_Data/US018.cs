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
using System.Threading;


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


namespace RetirementStudio._TestScripts._TestScripts_Data
{
    /// <summary>
    /// Summary description for US018
    /// </summary>
    [CodedUITest]
    public class US018
    {

        public US018()
        {

            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 018 Create New_2000527_1709";
            Config.sPlanName = "QA US Benchmark 018 Create New Plan";
            //Config.sClientName = "QA US 018 US Upgrade Franklin";
            //Config.sPlanName = "QA US 018 US Upgrade Franklin Plan";
            Config.sDataCenter = "Franklin";
            //Config.sDataCenter = "Dallas";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;

           

            //_gLib._Report(_PassFailStep.Header, "Testing Starts at: " + DateTime.Now + "\t" + Environment.UserName);

            //_gLib._MsgBox("Warning!", "If you are running Existing or Re-opened Studio after crash, Please manually select the Client in Studio-> Home -> All Services -> "
            //    + Config.sClientName + Environment.NewLine + Environment.NewLine + "If you are running CreateNew without any crash, Please ignore this msg!"
            //    + Environment.NewLine + Environment.NewLine + "Click OK to keep testing!");

        }


        #region Report Output Directory

        string sOutput_Data2012 = "";
        string sOutput_Data2013 = "";

        string sOutput_Data2012_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_018_DataTest\20140206_QA3_Rebaseline\2012\";
        string sOutput_Data2013_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_018_DataTest\20140206_QA3_Rebaseline\2013\";

        string sReadFile_2012 = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\US018\Documentation - US New Benchmark - Data - for scripting.xls";
        string sTable_RetirementScale07_Male = "";
        string sMsgInfo = "";
        MyExcel _excelRead = new MyExcel();
        MyExcel _excelWrite = new MyExcel();
        string sWriteFile_2012 = "";
        string sWriteFile_2013 = "";


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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_018_DataTest\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    _gLib._CreateDirectory(sMainDir + sPostFix + "\\");
                    sOutput_Data2012 = _gLib._CreateDirectory(sMainDir + sPostFix + "\\2012\\");
                    sOutput_Data2013 = _gLib._CreateDirectory(sMainDir + sPostFix + "\\2013\\");
                    sWriteFile_2012 = sMainDir + sPostFix + "\\2012\\Data2012_Query.xlsx";
                    sWriteFile_2013 = sMainDir + sPostFix + "\\2013\\Data2013_Query.xlsx";

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

                string sMainDir = sDir + "US018_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutput_Data2012 = _gLib._CreateDirectory(sMainDir + "\\2012\\");
                sOutput_Data2013 = _gLib._CreateDirectory(sMainDir + "\\2013\\");


            }

            string sContent = "";
            sContent = sContent + "sOutput_Data2012 = @\"" + sOutput_Data2012 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutput_Data2013 = @\"" + sOutput_Data2013 + "\";" + Environment.NewLine;
            sContent = sContent + "sWriteFile_2012 = @\"" + sOutput_Data2012 + "Data2012_Query.xlsx\";" + Environment.NewLine;
            sContent = sContent + "sWriteFile_2013 = @\"" + sOutput_Data2013 + "Data2013_Query.xlsx\";" + Environment.NewLine;
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
        
        
        #endregion



        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_US018()
        {

 
            #region MultiThreads


            Thread thrd_Data2012 = new Thread(() => new US018().t_CompareRpt_Data2012(sOutput_Data2012));
            Thread thrd_Data2012_Val = new Thread(() => new US018().t_CompareRpt_Data2012_Val(sOutput_Data2012));
            Thread thrd_Data2013 = new Thread(() => new US018().t_CompareRpt_Data2013(sOutput_Data2013));


            #endregion


             
            _gLib._CheckScreenResolution(1366, 768);

            this.GenerateReportOuputDir();


            #region Create Client & Add Data2012


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
            dic.Add("ClientCode", "cora");
            dic.Add("FiscalYearEnd", "12/31");
            dic.Add("MeasurementDate", "09/30");
            dic.Add("Notes", "Client Owner: Cora Liu. Original client: *QA US Benchmark 018 Create New");
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
            dic.Add("Country", "United States of America");
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
            dic.Add("Name", "Data2012");
            dic.Add("EffectiveDate", "01/01/2012");
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
            dic.Add("ServiceToOpen", "Data2012");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            #endregion

            #region Data2012 - Current View & Upload Data & Import


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);

            pData._CV_AddMultipleLabels(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\US018\CurrentViewMultipleLabels.xls");


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Data2012");
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
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\US018\Hogwarts Raw Data 2012.xls");
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
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);


            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "2012 import raw data");
            dic.Add("FileType", "Excel file");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "HogwartsRawData2012.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            pData._SelectTab("Columns");

            pData._IP_Columns_Rename("Status @ 1/1/2012", "USC");
            pData._IP_Columns_Rename("Hire Date", "HireDate1");
            pData._IP_Columns_Rename("Term Date", "TerminationDate1");
            pData._IP_Columns_Rename("Level", "BenefitLevel");
            pData._IP_Columns_Rename("Actual Salary 2011", "SalaryPriorYear1");
            pData._IP_Columns_Rename("Actual Salary 2010", "SalaryPriorYear2");
            pData._IP_Columns_Rename("Actual Salary 2009", "SalaryPriorYear3");
            pData._IP_Columns_Rename("Actual Salary 2008", "SalaryPriorYear4");
            pData._IP_Columns_Rename("Actual Salary 2007", "SalaryPriorYear5");
            //////////////////////////pData._IP_Columns_Rename("Actual Salary _2011", "SalaryPriorYear1");
            //////////////////////////pData._IP_Columns_Rename("Actual Salary _2010", "SalaryPriorYear2");
            //////////////////////////pData._IP_Columns_Rename("Actual Salary _2009", "SalaryPriorYear3");
            //////////////////////////pData._IP_Columns_Rename("Actual Salary _2008", "SalaryPriorYear4");
            //////////////////////////pData._IP_Columns_Rename("Actual Salary _2007", "SalaryPriorYear5");
            pData._IP_Columns_Rename("Form of Payment", "PaymentForm1");

            //////////_gLib._MsgBox("Work around in Columns", "Because of bug, need to revert code once bug fixed.");


            pData._SelectTab("Mapping");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_Mapping(dic);

            pData._IP_Mapping_Initialize("Personal Information", "Client Data", 1, 0, 1, "ClientEmployeeIDNumber");
            pData._IP_Mapping_Initialize("Personal Information", "Retiree Medical", 1, 0, 1, "DentalCoverageFlag");
            pData._IP_Mapping_Initialize("Personal Information", "Accounting Results", 1, 0, 1, "GRSAccountingAL");
            pData._IP_Mapping_Initialize("Personal Information", "Funding Results", 1, 0, 1, "GRSFundingAL");
            pData._IP_Mapping_Initialize("Personal Information", "DC Information", 1, 0, 1, "MembershipDateDC1");
            pData._IP_Mapping_Initialize("Personal Information", "Classification Codes", 1, 0, 1, "DivisionCode");
            pData._IP_Mapping_Initialize("Personal Information", "DB Information", 1, 0, 1, "MembershipDate1");
            pData._IP_Mapping_Initialize("Personal Information", "Beneficiary Information", 1, 0, 1, "Beneficiary1ID");
            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "EmployeeIDNumber");

            pData._IP_Mapping_Initialize("Personal Information", "Pay", 2, 7, 1, "Salary");
            pData._IP_Mapping_Initialize("Personal Information", "Salary", 3, 7, 1, "SalaryCurrentYear");
            pData._IP_Mapping_Initialize("Personal Information", "Service", 2, 7, 1, "BenefitServiceAtValDate");


            //////////pData._IP_Mapping_Initialize("Personal Information", "Pay", 2, 7, 1);
            //////////pData._IP_Mapping_Initialize("Personal Information", "Salary", 3, 7, 1);
            //////////pData._IP_Mapping_Initialize("Personal Information", "Service", 2, 7, 1);

            pData._IP_Mapping_MapField("USC", "USC", 0, false, 6);
            pData._IP_Mapping_ClickEdit("USC", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_Transformation(1, 1, "Active");
            pData._IP_Mapping_Transformation(1, 2, "Act");

            pData._IP_Mapping_Transformation(2, 1, "Termination");
            pData._IP_Mapping_Transformation(2, 2, "Def");

            pData._IP_Mapping_Transformation(3, 1, "Pensioner");
            pData._IP_Mapping_Transformation(3, 2, "Ret");

            pData._IP_Mapping_Transformation(4, 1, "Beneficiary");
            pData._IP_Mapping_Transformation(4, 2, "RetBene");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_MapField("ExcludedService", "LOA Offset", 0, true, 11);
            pData._IP_Mapping_MapField("Beneficiary1BirthDate", "Beneficiary BirthDate", 0, true, 12);
            pData._IP_Mapping_MapField("Benefit1DB", "Annual Pension", 0, true, 11);
            pData._IP_Mapping_MapField("ClientEmployeeIDNumber", "EmployeeIDNumber", 0, true, 48);
            pData._IP_Mapping_MapField("ClientName", "Name", 0, true);


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Work Fields");
            dic.Add("Label", "PaymentFromDescription");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Text");
            dic.Add("FieldLength", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "2012 import raw data");
            pData._TreeViewSelect(dic);

            ////_gLib._MsgBox("Need Manual Interaction!", "Please manually expand <Work Fields> and click OK to keep testing!");
            pData._IP_ExpandMainCategory_FromEnd("Work Fields", 2, "PaymentFromDescription");

            pData._IP_Mapping_MapField("PaymentFromDescription", "PaymentForm1", 0, true);

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
            dic.Add("DerivedField", "EmployeeIDNumber");
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
            dic.Add("Level_2", "Client Data");
            dic.Add("Level_3", "ClientEmployeeIDNumber");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ClientEmployeeIDNumber");
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
            dic.Add("DerivedField", "Name");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_2", "Client Data");
            dic.Add("Level_3", "ClientName");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ClientName");
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
            dic.Add("Unique_NoMatch_Num", "76");
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
            dic.Add("New_Num", "76");
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

            ////////_gLib._MsgBox("Need Manual Interaction!", "Please close and re-open the service. " + Environment.NewLine + Environment.NewLine + "Click OK to keep testing!");

            pMain._Home_ToolbarClick_Top(false);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Data2012");
            pMain._PopVerify_Home_RightPane(dic);


            #endregion

            #region Data2012 - Checks



            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Checks");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("CheckName", "All");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "Click");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NewGroupName", "Conversion Checks");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_Checks_AddCustomGroup(dic);



            dic.Clear();
            dic.Add("CheckName", "Conversion Checks");
            dic.Add("iSearchDownNum", "58");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "Click");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Pay is under 30K or over 100K");
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
            dic.Add("Level_4", "Salary");
            dic.Add("Level_5", "SalaryPriorYear1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=OR(SalaryPriorYear1_C<30000, SalaryPriorYear1_C>100000)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            ////////_gLib._MsgBox("Need Manual Interaction!", "Please manually expand <Conversion Checks> and click OK to keep testing!");
            pData._CK_ExpandGroup_FromEnd("Conversion Checks", 1, "Pay is under 30K or over 100K");

            dic.Clear();
            dic.Add("CheckName", "Pay is under 30K or over 100K");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "Click");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, true, true, false);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "True");
            dic.Add("CustomExpression_Formula", "=OR(IsAct, YEAR(TerminationDate1_C)>=2011)");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_CK_EditFilter(dic);


            dic.Clear();
            dic.Add("CheckName", "Pay is under 30K or over 100K");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "Click");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, false, false, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, false, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "EmployeeIDNumber");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Name");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Salary");
            dic.Add("Level_5", "SalaryCurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, false, true);

            dic.Clear();
            dic.Add("CheckName", "Pay is under 30K or over 100K");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "Click");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, false, false, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("QueryWording", "Pay is under 30K or over 100K. Please review the salary information and provide correct valueif applicable");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_CK_QueryInstructions(dic);


            dic.Clear();
            dic.Add("CheckName", "Pay is under 30K or over 100K");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "Click");
            pData._CK_CheckGrip(dic, false, false, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Salary");
            dic.Add("Level_5", "SalaryPriorYear1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            pData._CK_CheckGrip_SendKeys("{Home}{Up}{Up}");


            dic.Clear();
            dic.Add("CheckName", "Conversion Checks");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "Click");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Spouse Age Difference over 20 years");
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
            dic.Add("Level_3", "BirthDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1BirthDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ABS(YEAR(Beneficiary1BirthDate_C)-YEAR(BirthDate_C))>20");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("CheckName", "Spouse Age Difference over 20 years");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "Click");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, true, true, false);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Is Inact");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_CK_EditFilter(dic);


            dic.Clear();
            dic.Add("CheckName", "Spouse Age Difference over 20 years");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "Click");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, false, false, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, false, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "EmployeeIDNumber");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Name");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "BirthDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1BirthDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("CheckName", "Spouse Age Difference over 20 years");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "Click");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, false, false, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("QueryWording", "Spouse Age Difference over 20 years. Please review the birth dates for member and spouse and provide revised value if applicable");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_CK_QueryInstructions(dic);


            dic.Clear();
            dic.Add("CheckName", "Spouse Age Difference over 20 years");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "Click");
            pData._CK_CheckGrip(dic, false, false, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "BirthDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1BirthDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            pData._CK_CheckGrip_SendKeys("{Home}{Up}{Up}");


            dic.Clear();
            dic.Add("CheckName", "Conversion Checks");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "Click");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Member Age under 16 or over 80");
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
            dic.Add("Level_3", "BirthDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "6");
            dic.Add("sData", "Age");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=YEAR(EffectiveDate)-YEAR(E2)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "5");
            dic.Add("sData", "");
            dic.Add("sFormula", "=OR(G1<16, G1>80)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
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
            dic.Add("CheckName", "Member Age under 16 or over 80");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "Click");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, true, true, false);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Is Valued");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_CK_EditFilter(dic);


            dic.Clear();
            dic.Add("CheckName", "Member Age under 16 or over 80");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "Click");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, false, false, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, false, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "EmployeeIDNumber");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Name");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "BirthDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "USC");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("CheckName", "Member Age under 16 or over 80");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "Click");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, false, false, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("QueryWording", "Member Age under 16 or over 80. Please review the status and birthdate and provide correct value if applicable");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_CK_QueryInstructions(dic);


            dic.Clear();
            dic.Add("CheckName", "Member Age under 16 or over 80");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "Click");
            pData._CK_CheckGrip(dic, false, false, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "BirthDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "USC");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            pData._CK_CheckGrip_SendKeys("{Home}{Up}{Up}{Up}{Up}");




            dic.Clear();
            dic.Add("CheckName", "Conversion Checks");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "Click");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Missing Hire Date");
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
            dic.Add("Level_3", "HireDate1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ISBLANK(HireDate1_C)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("CheckName", "Missing Hire Date");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "Click");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, true, true, false);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Is Act");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_CK_EditFilter(dic);


            dic.Clear();
            dic.Add("CheckName", "Missing Hire Date");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "Click");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, false, false, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, false, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "EmployeeIDNumber");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Name");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "BirthDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "HireDate1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Gender");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "USC");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("CheckName", "Missing Hire Date");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "Click");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, false, false, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("QueryWording", "Missing Hire Date for the following active members. Please  provide their hiredate");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_CK_QueryInstructions(dic);


            dic.Clear();
            dic.Add("CheckName", "Missing Hire Date");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "Click");
            pData._CK_CheckGrip(dic, false, false, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "HireDate1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            pData._CK_CheckGrip_SendKeys("{Home}{Up}{Up}{Up}{Up}{Up}");



            dic.Clear();
            dic.Add("CheckName", "Conversion Checks");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "Click");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Missing Form Of Payment");
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
            dic.Add("Level_2", "Work Fields");
            dic.Add("Level_3", "PaymentFromDescription");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ISBLANK(PaymentFromDescription_C)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("CheckName", "Missing Form Of Payment");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "Click");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, true, true, false);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Is Inact");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_CK_EditFilter(dic);


            dic.Clear();
            dic.Add("CheckName", "Missing Form Of Payment");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "Click");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, false, false, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, false, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "EmployeeIDNumber");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Name");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "BirthDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "HireDate1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Gender");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "USC");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PaymentFromDescription");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("CheckName", "Missing Form Of Payment");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "Click");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, false, false, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("QueryWording", "Missing Form Of Payment for the following pensioners. Please  provide their actual payment form");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_CK_QueryInstructions(dic);


            dic.Clear();
            dic.Add("CheckName", "Missing Form Of Payment");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "Click");
            pData._CK_CheckGrip(dic, false, false, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Work Fields");
            dic.Add("Level_3", "PaymentFromDescription");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            pData._CK_CheckGrip_SendKeys("{Home}{Up}{Up}{Up}{Up}{Up}{Up}{Up}{Up}{Up}{Up}{Up}{Up}{Up}{Up}{Up}");


            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "Click");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);



            dic.Clear();
            dic.Add("CheckName", "Pay is under 30K or over 100K");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);


            ////////////////////////_gLib._MsgBox("Conversion Checks => Pay is under 30K or over 100K", "Please Click failed Number <23> in this Check and click OK to keep testing!");

            pData._CK_CheckGrip_ClickLink_Fail("Data2012", "Conversion Checks => Pay is under 30K or over 100K", "23");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            dic.Add("AllQuery", "True");
            dic.Add("AllPlug", "");
            dic.Add("AllOK", "");
            dic.Add("Notes", "");
            pData._PopVerify_Checks(dic);


            dic.Clear();
            dic.Add("sColumn", "EmployeeIDNumber");
            dic.Add("sData", "641562271");
            dic.Add("iStartNum", "20");
            dic.Add("bReverseSearch", "True");
            dic.Add("Query", "");
            dic.Add("Plug", "True");
            dic.Add("Ok", "");
            pData._CK_CheckResults_SetFlag(dic);

            dic.Clear();
            dic.Add("sColumn", "EmployeeIDNumber");
            dic.Add("sData", "727071279");
            dic.Add("iStartNum", "21");
            dic.Add("bReverseSearch", "True");
            dic.Add("Query", "");
            dic.Add("Plug", "True");
            dic.Add("Ok", "");
            pData._CK_CheckResults_SetFlag(dic);

            dic.Clear();
            dic.Add("sColumn", "EmployeeIDNumber");
            dic.Add("sData", "778776719");
            dic.Add("Query", "");
            dic.Add("Plug", "");
            dic.Add("Ok", "True");
            pData._CK_CheckResults_SetFlag(dic);

            dic.Clear();
            dic.Add("sColumn", "EmployeeIDNumber");
            dic.Add("sData", "314327834");
            dic.Add("Query", "");
            dic.Add("Plug", "");
            dic.Add("Ok", "True");
            pData._CK_CheckResults_SetFlag(dic);

            dic.Clear();
            dic.Add("sColumn", "EmployeeIDNumber");
            dic.Add("sData", "808979891");
            dic.Add("Query", "");
            dic.Add("Plug", "");
            dic.Add("Ok", "True");
            pData._CK_CheckResults_SetFlag(dic);

            dic.Clear();
            dic.Add("sColumn", "EmployeeIDNumber");
            dic.Add("sData", "665464784");
            dic.Add("Query", "");
            dic.Add("Plug", "");
            dic.Add("Ok", "True");
            pData._CK_CheckResults_SetFlag(dic);

            dic.Clear();
            dic.Add("sColumn", "EmployeeIDNumber");
            dic.Add("sData", "333229824");
            dic.Add("Query", "");
            dic.Add("Plug", "");
            dic.Add("Ok", "True");
            pData._CK_CheckResults_SetFlag(dic);

            dic.Clear();
            dic.Add("sColumn", "EmployeeIDNumber");
            dic.Add("sData", "869486266");
            dic.Add("Query", "");
            dic.Add("Plug", "");
            dic.Add("Ok", "True");
            pData._CK_CheckResults_SetFlag(dic);

            dic.Clear();
            dic.Add("sColumn", "EmployeeIDNumber");
            dic.Add("sData", "485045801");
            dic.Add("Query", "");
            dic.Add("Plug", "");
            dic.Add("Ok", "True");
            pData._CK_CheckResults_SetFlag(dic);

            dic.Clear();
            dic.Add("sColumn", "EmployeeIDNumber");
            dic.Add("sData", "600557954");
            dic.Add("iStartNum", "22");
            dic.Add("bReverseSearch", "True");
            dic.Add("Query", "");
            dic.Add("Plug", "");
            dic.Add("Ok", "True");
            pData._CK_CheckResults_SetFlag(dic);



            dic.Clear();
            dic.Add("CheckName", "Spouse Age Difference over 20 years");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);



            //////////////////////_gLib._MsgBox("Conversion Checks => Spouse Age Difference over 20 years", "Please Click failed Number <2> in this Check and click OK to keep testing!");

            pData._CK_CheckGrip_ClickLink_Fail("Data2012", "Conversion Checks => Spouse Age Difference over 20 years", "2");



            dic.Clear();
            dic.Add("sColumn", "EmployeeIDNumber");
            dic.Add("sData", "330929586");
            dic.Add("bReverseSearch", "");
            dic.Add("Query", "True");
            dic.Add("Plug", "");
            dic.Add("Ok", "");
            pData._CK_CheckResults_SetFlag(dic);

            dic.Clear();
            dic.Add("sColumn", "EmployeeIDNumber");
            dic.Add("sData", "298226141");
            dic.Add("bReverseSearch", "");
            dic.Add("Query", "");
            dic.Add("Plug", "True");
            dic.Add("Ok", "");
            pData._CK_CheckResults_SetFlag(dic);



            dic.Clear();
            dic.Add("CheckName", "Member Age under 16 or over 80");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);


            ////////////////////////////_gLib._MsgBox("Conversion Checks => Member Age under 16 or over 80", "Please Click failed Number <7> in this Check and click OK to keep testing!");

            pData._CK_CheckGrip_ClickLink_Fail("Data2012", "Conversion Checks => Member Age under 16 or over 80", "7");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            dic.Add("AllQuery", "");
            dic.Add("AllPlug", "");
            dic.Add("AllOK", "True");
            dic.Add("Notes", "");
            pData._PopVerify_Checks(dic);



            dic.Clear();
            dic.Add("CheckName", "Missing Form Of Payment");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);


            //////////////////////_gLib._MsgBox("Conversion Checks => Missing From of Payment", "Please Click failed Number <11> in this Check and click OK to keep testing!");

            pData._CK_CheckGrip_ClickLink_Fail("Data2012", "Conversion Checks => Missing From of Payment", "11");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            dic.Add("AllQuery", "");
            dic.Add("AllPlug", "");
            dic.Add("AllOK", "True");
            dic.Add("Notes", "");
            pData._PopVerify_Checks(dic);



            pMain._Home_ToolbarClick_Top(true);




            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Reports");
            dic.Add("MenuItem", "Add new report");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "All");
            dic.Add("StatusMatrix", "");
            dic.Add("StatusMatrix_Filter", "");
            dic.Add("ReportName", "All Check Results 2012");
            dic.Add("GenerateReport", "Click");
            pData._PopVerify_Reports(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_RP_ReportGenerated_Popup(dic);

            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Reports");
            dic.Add("MenuItem", "Add new report");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "Query");
            dic.Add("StatusMatrix", "");
            dic.Add("StatusMatrix_Filter", "");
            dic.Add("ReportName", "Query 2012");
            dic.Add("GenerateReport", "Click");
            pData._PopVerify_Reports(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_RP_ReportGenerated_Popup(dic);


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Reports");
            dic.Add("MenuItem", "Add new report");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "Plug");
            dic.Add("StatusMatrix", "");
            dic.Add("StatusMatrix_Filter", "");
            dic.Add("ReportName", "Plug 2012");
            dic.Add("GenerateReport", "Click");
            pData._PopVerify_Reports(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_RP_ReportGenerated_Popup(dic);


            pData._SelectTab("Data2012");


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Data2012");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Output Manager");
            pData._TreeViewSelect(dic);


            pData._OM_ExportReport_SubReports(sOutput_Data2012, "Reports Summary", "Data2012_Query", 130, 2, false);


            _gLib._KillProcessByName("EXCEL");
            _excelRead = new MyExcel(sReadFile_2012, true);
            _excelWrite = new MyExcel(sWriteFile_2012, true);
            _excelRead.OpenExcelFile("Query Answer for 2012");
            _excelWrite.OpenExcelFile("Conversion Checks");

            for (int i = 9; i <= 21; i++)
            {
                _excelWrite.setOneCellValue(i, 8, _excelRead.getOneCellValue(i, 8));
                _excelWrite.setOneCellValue(i, 9, _excelRead.getOneCellValue(i, 9));
            }

            _excelWrite.setOneCellValue(28, 6, _excelRead.getOneCellValue(28, 6));
            _excelWrite.setOneCellValue(28, 7, _excelRead.getOneCellValue(28, 7));

            _excelRead.CloseExcelApplication();
            _excelWrite.SaveExcel();
            _excelWrite.CloseExcelApplication();

            pData._SelectTab("Data2012");

            dic.Clear();
            dic.Add("Level_1", "Data2012");
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
            dic.Add("FileName", sWriteFile_2012);
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
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Simple Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Query Answer 1");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "Data2012_Query.xlsx");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            dic.Add("Process", "Click");
            pData._PopVerify_SimpleImport(dic);



            #endregion

            #region Data2012 - Batch Update


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Batch Update");
            dic.Add("MenuItem", "Add new batch update");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "1. Plug Salary Rate for 2012 new hire");
            dic.Add("SelectFieldstoDisplay", "Click");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Salary");
            dic.Add("Level_5", "SalaryPriorYear1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "True");
            dic.Add("CustomExpression_Formula", "=YEAR(HireDate1_C)=2012");
            dic.Add("CustomExpression_Accept", "Click");
            dic.Add("Apply", "Click");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);

            pData._BU_FPGrid("641562271", 3, "38713.51", 4, "annualized 2012 pay rate");
            pData._BU_FPGrid("727071279", 3, "41653.75", 4, "annualized 2012 pay rate");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "True");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_BatchUpdate(dic);



            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Batch Update");
            dic.Add("MenuItem", "Add new batch update");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "2. Correct Salary History for George Weasley");
            dic.Add("SelectFieldstoDisplay", "Click");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Salary");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Salary");
            dic.Add("Level_5", "SalaryCurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, false, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "True");
            dic.Add("CustomExpression_Formula", "=EmployeeIDNumber_C=548652492");
            dic.Add("CustomExpression_Accept", "Click");
            dic.Add("Apply", "Click");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);

            pData._BU_FPGrid("548652492", 3, "1783237.12", 4, "1756772.11");
            pData._BU_FPGrid("548652492", 5, "1717906.05", 6, "1657579.01");
            pData._BU_FPGrid("548652492", 7, "1594025.39", 8, "Overstated by 100K for all 5 years");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "True");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_BatchUpdate(dic);



            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Batch Update");
            dic.Add("MenuItem", "Add new batch update");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "3. Correct Spouse DOB (year)");
            dic.Add("SelectFieldstoDisplay", "Click");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1BirthDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "True");
            dic.Add("CustomExpression_Formula", "=EmployeeIDNumber_C=298226141");
            dic.Add("CustomExpression_Accept", "Click");
            dic.Add("Apply", "Click");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);

            pData._BU_FPGrid("298226141", 3, "5/10/1957", 4, "should be May 10 1957 (not 2057)");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "True");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_BatchUpdate(dic);


            #endregion

            #region Data2012 - Derivation Groups

            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "1. Set 12 digits ID for Beneficiary");
            dic.Add("Filter", "Is Ret Bene");
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
            dic.Add("DerivedField", "Beneficiary1ID");
            dic.Add("DerivedField_SearchFromIndex", "4");
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
            dic.Add("Level_3", "EmployeeIDNumber");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=EmployeeIDNumber_C");
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
            dic.Add("DerivedField", "EmployeeIDNumber");
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
            dic.Add("Level_3", "EmployeeIDNumber");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=VALUE(900&EmployeeIDNumber_C)");
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
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Filters");
            pData._TreeViewSelect(dic);

            pData._FL_Grid("Custom", 53, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Tier1Member");
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
            dic.Add("Level_3", "BenefitLevel");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=BenefitLevel_C=\"Tier1\"");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            pMain._Home_ToolbarClick_Top(true);




            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "2. Date Calc for Act/Def");
            dic.Add("Filter", "Is Act or Is Def");
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
            dic.Add("DerivedField", "MembershipDate1");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "Date");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service - Months");
            dic.Add("sData", "1");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "24");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Age Rounding");
            dic.Add("sData", "First of Month");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "25");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service Rounding");
            dic.Add("sData", "First of Month");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "26");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Rule of Rounding");
            dic.Add("sData", "First of Month");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "28");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service Field");
            dic.Add("sData", "HireDate1_C");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
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
            dic.Add("DerivedField", "StartDate1");
            dic.Add("DerivedField_SearchFromIndex", "10");
            dic.Add("Type", "Date");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Tier1Member");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Fixed age");
            dic.Add("sData", "65");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service - Years");
            dic.Add("sData", "2");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "24");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Age Rounding");
            dic.Add("sData", "First of Next Month");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "25");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service Rounding");
            dic.Add("sData", "First of Next Month");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "26");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Rule of Rounding");
            dic.Add("sData", "First of Next Month");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "28");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service Field");
            dic.Add("sData", "HireDate1_C");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
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
            dic.Add("DerivedField", "StartDate1");
            dic.Add("DerivedField_SearchFromIndex", "10");
            dic.Add("Type", "Date");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "True");
            dic.Add("CustomExpression_Formula", "=NOT(Tier1Member)");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service - Years");
            dic.Add("sData", "30");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "24");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Age Rounding");
            dic.Add("sData", "First of Next Month");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "25");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service Rounding");
            dic.Add("sData", "First of Next Month");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "26");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Rule of Rounding");
            dic.Add("sData", "First of Next Month");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "28");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service Field");
            dic.Add("sData", "MembershipDate1_C");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
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
            dic.Add("SelectFieldsForPreview", "Click");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "BirthDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

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
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "UnreducedAge");
            dic.Add("DisplayName", "UnreducedAge");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Integer");
            dic.Add("FieldLength", "2");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);



            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "(7)2. Date Calc for Act/Def");
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
            dic.Add("iRow", "4");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "UnreducedAge");
            dic.Add("DerivedField_SearchFromIndex", "4");
            dic.Add("Type", "Age");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Calculation Date is:");
            dic.Add("sData", "Date Field");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Date Field");
            dic.Add("sData", "StartDate1_C");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
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
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "3. Service Calc");
            dic.Add("Filter", "Is Act");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);



            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "BenefitServiceAtValDate");
            dic.Add("DerivedField_SearchFromIndex", "12");
            dic.Add("Type", "Service");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service starts at");
            dic.Add("sData", "Date Field");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Date Field");
            dic.Add("sData", "MembershipDate1_C");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service ends at");
            dic.Add("sData", "Date Field");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Date Field");
            dic.Add("sData", "EffectiveDate_C");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "10");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Rounding Rule");
            dic.Add("sData", "Completed Months");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
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
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "BenefitServiceAtValDate");
            dic.Add("DerivedField_SearchFromIndex", "12");
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
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "BenefitServiceAtValDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "ExcludedService");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "True");
            dic.Add("CustomExpression_Formula", "=ExcludedService_C>0");
            dic.Add("Formula", "=BenefitServiceATValDate_C - ExcludedService_C");
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
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);




            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);

            pData._CV_ExpandPersonalInformation();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Service");
            dic.Add("Label", "VestingServiceAtValDate");
            dic.Add("DisplayName", "VestingServiceAtValDate");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "7");
            dic.Add("DecimalPlaces", "4");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "3. Service Calc");
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
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "VestingServiceAtValDate");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "Service");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service starts at");
            dic.Add("sData", "Date Field");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Date Field");
            dic.Add("sData", "HireDate1_C");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
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
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Service");
            dic.Add("Label", "YOHService");
            dic.Add("DisplayName", "YOHService");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "7");
            dic.Add("DecimalPlaces", "4");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);



            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "4. Annualize Salary");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "YOHService");
            dic.Add("DerivedField_SearchFromIndex", "2");
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
            dic.Add("Level_3", "HireDate1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "6");
            dic.Add("sData", "Year of Hire");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "6");
            dic.Add("sData", "Last day of Hire Year");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "7");
            dic.Add("sData", "=YEAR(E2)");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            dic.Add("bVerify", "false");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "7");
            dic.Add("sData", "=DATE(G1,12,31)");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            dic.Add("bVerify", "false");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "5");
            dic.Add("sData", "");
            dic.Add("sFormula", "=(G2-E2)/365.25");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
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
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "SalaryPriorYear1");
            dic.Add("DerivedField_SearchFromIndex", "3");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

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
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "SalaryPriorYear2");
            dic.Add("DerivedField_SearchFromIndex", "4");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

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
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "SalaryPriorYear3");
            dic.Add("DerivedField_SearchFromIndex", "5");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);


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
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "5");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "SalaryPriorYear4");
            dic.Add("DerivedField_SearchFromIndex", "6");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

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
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "6");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "SalaryPriorYear5");
            dic.Add("DerivedField_SearchFromIndex", "7");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
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
            dic.Add("Level_4", "Salary");
            dic.Add("Level_5", "SalaryPriorYear1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "YOHService");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "True");
            dic.Add("CustomExpression_Formula", "=AND(SalaryPriorYear1_C>0, YEAR(HireDate1_C)=2011)");
            dic.Add("Formula", "=SalaryPriorYear1_C/YOHService_C");
            dic.Add("Previous", "");
            dic.Add("Next", "Click");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);


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
            dic.Add("Level_4", "Salary");
            dic.Add("Level_5", "SalaryPriorYear2");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "YOHService");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "True");
            dic.Add("CustomExpression_Formula", "=AND(SalaryPriorYear2_C>0, YEAR(HireDate1_C)=2010)");
            dic.Add("Formula", "=SalaryPriorYear2_C/YOHService_C");
            dic.Add("Previous", "");
            dic.Add("Next", "Click");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);


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
            dic.Add("Level_4", "Salary");
            dic.Add("Level_5", "SalaryPriorYear3");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "YOHService");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "True");
            dic.Add("CustomExpression_Formula", "=AND(SalaryPriorYear3_C>0, YEAR(HireDate1_C)=2009)");
            dic.Add("Formula", "=SalaryPriorYear3_C/YOHService_C");
            dic.Add("Previous", "");
            dic.Add("Next", "Click");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);


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
            dic.Add("Level_4", "Salary");
            dic.Add("Level_5", "SalaryPriorYear4");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "YOHService");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "True");
            dic.Add("CustomExpression_Formula", "=AND(SalaryPriorYear4_C>0, YEAR(HireDate1_C)=2008)");
            dic.Add("Formula", "=SalaryPriorYear4_C/YOHService_C");
            dic.Add("Previous", "");
            dic.Add("Next", "Click");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);



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
            dic.Add("Level_4", "Salary");
            dic.Add("Level_5", "SalaryPriorYear5");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "YOHService");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "True");
            dic.Add("CustomExpression_Formula", "=AND(SalaryPriorYear5_C>0, YEAR(HireDate1_C)=2007)");
            dic.Add("Formula", "=SalaryPriorYear5_C/YOHService_C");
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
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Batch Update");
            dic.Add("MenuItem", "Add new batch update");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "4. Fix Term Date");
            dic.Add("SelectFieldstoDisplay", "Click");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "TerminationDate1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "True");
            dic.Add("CustomExpression_Formula", "=AND(TerminationDate1_C<HireDate1_C, NOT(ISBLANK(TerminationDate1_C)))");
            dic.Add("CustomExpression_Accept", "Click");
            dic.Add("Apply", "Click");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);


            pData._BU_FPGrid("64915822", 3, "10/15/1989", 4, "fix term date");
            pData._BU_FPGrid("951194859", 3, "2/1/2011", 4, "fix term date");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "True");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_BatchUpdate(dic);


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "5. Pensioner Calc");
            dic.Add("Filter", "Is Ret");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "StartDate1");
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
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "TerminationDate1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "6");
            dic.Add("sData", "YOT");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "6");
            dic.Add("sData", "MOT");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "6");
            dic.Add("sData", "DOT");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=YEAR(E2)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "False");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=MONTH(E2)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "False");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=DAY(E2)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "False");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "8");
            dic.Add("sData", "");
            dic.Add("sFormula", "=IF(G2=12, G1+1, G1)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "False");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "8");
            dic.Add("sData", "");
            dic.Add("sFormula", "=IF(G2=12, 1, G2+1)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "False");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "8");
            dic.Add("sData", "");
            dic.Add("sFormula", "=1");
            dic.Add("sRange", "");
            dic.Add("bVerify", "False");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "9");
            dic.Add("sData", "YOS");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "9");
            dic.Add("sData", "MOS");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "9");
            dic.Add("sData", "DOS");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "5");
            dic.Add("sData", "");
            dic.Add("sFormula", "=DATE(H1, H2, H3)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
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
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "PaymentForm1");
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
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Work Fields");
            dic.Add("Level_3", "PaymentFromDescription");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(LEFT(PaymentFromDescription_C,1)=\"J\", \"J&S\", \"LA\")");
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
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "YearsCertain1");
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
            dic.Add("Level_2", "Work Fields");
            dic.Add("Level_3", "PaymentFromDescription");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "True");
            dic.Add("CustomExpression_Formula", "=PaymentForm1_C=\"LA\"");
            dic.Add("Formula", "=MID(PaymentFromDescription_C,24,2)");
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
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Beneficiary1Percent1");
            dic.Add("DerivedField_SearchFromIndex", "8");
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
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Work Fields");
            dic.Add("Level_3", "PaymentFromDescription");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "6");
            dic.Add("sData", "Length");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "6");
            dic.Add("sData", "Revised");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "6");
            dic.Add("sData", "Value");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LEN(E2)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "False");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LEFT(E2,G1-1)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "False");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=VALUE(RIGHT(G2,3))");
            dic.Add("sRange", "");
            dic.Add("bVerify", "False");
            pData._DG_DerivationDefinition_Grid(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "5");
            dic.Add("sData", "");
            dic.Add("sFormula", "=IF(G3>100,66.67,G3)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "False");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "True");
            dic.Add("CustomExpression_Formula", "=PaymentForm1_C=\"J&S\"");
            dic.Add("Formula", "");
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
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            //////_gLib._MsgBox("Need manually interaction", "Check field 'Beneficiary1Percent1' for EE Augusta LongBottom, if it shows 23 means good to go ahead!");




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
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            dic.Clear();
            dic.Add("iRow", "5");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Beneficiary1Percent1");
            dic.Add("DerivedField_SearchFromIndex", "8");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "True");
            dic.Add("CustomExpression_Formula", "=Beneficiary1Percent1_C=23");
            dic.Add("Formula", "=66+2/3");
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
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            dic.Clear();
            dic.Add("iRow", "6");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Beneficiary1Benefit1");
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
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1Percent1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

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
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "True");
            dic.Add("CustomExpression_Formula", "=OR(EmployeeIDNumber_C=900330929586, EmployeeIDNumber_C=900710369511, EmployeeIDNumber_C=900265522694)");
            dic.Add("Formula", "=Benefit1DB_C*Beneficiary1Percent1_C/100");
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
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Batch Update");
            dic.Add("MenuItem", "Add new batch update");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "5. RetBene Start Date");
            dic.Add("SelectFieldstoDisplay", "Click");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "StartDate1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "True");
            dic.Add("CustomExpression_Formula", "=OR(EmployeeIDNumber_C=900330929586, EmployeeIDNumber_C=900710369511, EmployeeIDNumber_C=900265522694)");
            dic.Add("CustomExpression_Accept", "Click");
            dic.Add("Apply", "Click");
            dic.Add("Plug", "True");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "True");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);

            pData._BU_FPGrid("900265522694", 3, "12/1/1992", 4, "Plug beneficiary start date");
            pData._BU_FPGrid("900330929586", 3, "1/1/2011", 4, "Plug beneficiary start date");
            pData._BU_FPGrid("900710369511", 3, "6/1/1990", 4, "Plug beneficiary start date");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "True");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_BatchUpdate(dic);

            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Conversion Data");
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
            dic.Add("Level_3", "Name");
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
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "BenefitServiceAtValDate");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "VestingServiceAtValDate");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Salary");
            dic.Add("Level_5", "SalaryPriorYear1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Salary");
            dic.Add("Level_5", "SalaryPriorYear2");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Salary");
            dic.Add("Level_5", "SalaryPriorYear3");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Salary");
            dic.Add("Level_5", "SalaryPriorYear4");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Salary");
            dic.Add("Level_5", "SalaryPriorYear5");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1ID");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1BirthDate");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1Benefit1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "MembershipDate1");
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
            dic.Add("Level_3", "PaymentForm1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "YearsCertain1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "UnreducedAge");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "BenefitLevel");
            pData._TreeViewSelect_Snapshots(dic, true);



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



            #region Accounting2012


            pMain._SelectTab("Home");

            dic.Clear();
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
            dic.Add("ConversionService", "");
            dic.Add("Name", "Accounting 1/1/2012");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "2012");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            dic.Add("Check_FundingCalculatorNotRunComplete", "False");
            pMain._PopVerify_Home_ServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Accounting 1/1/2012");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Accounting 1/1/2012");


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
            dic.Add("Snapshot", "True");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Conversion Data");
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




            pMain._SelectTab("Accounting 1/1/2012");

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
            dic.Add("txtRate", "5.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            pAssumptions._TreeViewSelect(dic);

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
            dic.Add("txtRate", "3.0");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "100.0");
            dic.Add("txtPercentMarried_F", "100.0");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "-3");
            dic.Add("txtDifferenceInSpouseAge_F", "3");
            dic.Add("cboDifferenceInSpouseAge", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "_Death");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "Click");
            dic.Add("DisabledVsHealthy", "");
            dic.Add("MemberVsSpouse", "");
            pMortalityDecrement._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "RP00CW");
            dic.Add("Mortality_Setback_M", "");
            dic.Add("Mortality_Setback_F", "");
            dic.Add("Disabled", "");
            dic.Add("Disabled_Setback_M", "");
            dic.Add("Disabled_Setback_F", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Accounting 1/1/2012");

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
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "BenefitService");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BenefitService");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "Click");
            dic.Add("RulesBasedService", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            pService._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProvidedInDataField", "BenefitServiceAtValDate");
            dic.Add("RoundingRule", "Completed months");
            dic.Add("V", "");
            dic.Add("C", "");
            dic.Add("T", "");
            dic.Add("txtServiceIncrement", "");
            dic.Add("cboServiceIncrement", "");
            pService._PopVerify_ServiceAtValuationDate(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "VestingService");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "VestingService");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "Click");
            dic.Add("RulesBasedService", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            pService._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProvidedInDataField", "VestingServiceAtValDate");
            dic.Add("RoundingRule", "");
            dic.Add("V", "");
            dic.Add("C", "");
            dic.Add("T", "");
            dic.Add("txtServiceIncrement", "");
            dic.Add("cboServiceIncrement", "");
            pService._PopVerify_ServiceAtValuationDate(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "UnreducedRetAge");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "UnreducedRetAge");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.UnreducedAge");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "EarlyRetAge");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "EarlyRetAge");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "55");
            dic.Add("YearOfService", "5");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "VestingService");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable(dic);

            dic.Clear();
            dic.Add("Comparison", "Earlier of");
            dic.Add("FromToAge", "UnreducedRetAge");
            pFromToAge._Standard_CompareAboveResultsTable(dic);




            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "RetirementEligible");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "RetirementEligible");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$Age>= $EarlyRetAge");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "VestedNotRetElig");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "VestedNotRetElig");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$VestingService>=3 and Not($RetirementEligible)");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "SalaryProjection");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "SalaryProjection");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataFieldContainingPayHistory", "Salary");
            dic.Add("PayIncreaseAssumption", "PayIncrease");
            dic.Add("UseOnlyDataFields", "");
            dic.Add("rdValuationYearPlus", "");
            dic.Add("txtValuationYearPlus", "");
            dic.Add("rdSpecifiedYear", "");
            dic.Add("txtSpecifiedYear", "");
            dic.Add("ApplyEGTRRALimits", "");
            pPayoutProjection._PopVerify_History(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("MenuItem", "Add Pay Average");
            pAssumptions._TreeViewRightSelect(dic, "FAE5");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("Level_3", "FAE5");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "SalaryProjection");
            dic.Add("AveragingMethod", "");
            dic.Add("M", "");
            dic.Add("RoundingForYearOfHire", "");
            dic.Add("DecimalPlacesForYearOfHire", "");
            dic.Add("Include", "");
            dic.Add("DropForCalculations", "");
            dic.Add("DropForCalculationAndPeriodConsidered", "");
            pPayAverage._PopVerify_Standard(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("MenuItem", "Add Pay Average");
            pAssumptions._TreeViewRightSelect(dic, "FAE3");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("Level_3", "FAE3");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "SalaryProjection");
            dic.Add("AveragingMethod", "");
            dic.Add("M", "3");
            dic.Add("RoundingForYearOfHire", "");
            dic.Add("DecimalPlacesForYearOfHire", "");
            dic.Add("Include", "");
            dic.Add("DropForCalculations", "");
            dic.Add("DropForCalculationAndPeriodConsidered", "");
            pPayAverage._PopVerify_Standard(dic);


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "FAEBenefit");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "FAE Formula");
            dic.Add("Level_4", "FAEBenefit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FAE5");
            dic.Add("Service", "BenefitService");
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

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.015");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "FAE Formula");
            dic.Add("Level_4", "FAEBenefit");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Tier2");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FAE3");
            dic.Add("Service", "BenefitService");
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


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.0175");

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.BenefitLevel=\"Tier2\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            dic.Add("MenuItem", "Add Vesting");
            pAssumptions._TreeViewRightSelect(dic, "Vesting");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            dic.Add("Level_3", "Vesting");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VestingServiceDefinition", "VestingService");
            dic.Add("AddRow", "");
            pVesting._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("YearsOfService", "3");
            dic.Add("VestingPercentage", "100.0");
            pVesting._ServiceTable(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("MenuItem", "Add Actuarial Equivalence");
            pAssumptions._TreeViewRightSelect(dic, "ValuationBasis");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("Level_3", "ValuationBasis");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValuationInterest", "True");
            dic.Add("ValuationMortality", "True");
            dic.Add("ValuationCOLA", "");
            dic.Add("ValuationSpouseAgeDiff", "");
            pActuarialEquivalence._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Early Retirement Factors");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Early Retirement Factors");
            dic.Add("MenuItem", "Add Early Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "ERF");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Early Retirement Factors");
            dic.Add("Level_3", "ERF");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AgeInterval", "True");
            dic.Add("YearInterval", "");
            dic.Add("TabularOrActuarially", "");
            dic.Add("CustomCode", "");
            pEarlyRetirementFactor._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "Click");
            dic.Add("Button_C", "");
            dic.Add("AgeAtWhichReductionEnds_cbo", "UnreducedAge");
            dic.Add("AgeAtWhichReductionEnds_txt", "");
            pEarlyRetirementFactor._PopVerify_AgeYearInterval(dic);

            pEarlyRetirementFactor._TBL_ReductionDefinition(1, "55", "3.0");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("MenuItem", "Add Conversion Factors");
            pAssumptions._TreeViewRightSelect(dic, "ConvertLA10toJs60");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("Level_3", "ConvertLA10toJs60");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType_From", "");
            dic.Add("FormOfPaymentType_To", "Joint and survivor");
            dic.Add("MortalityInDeferralPeriod_From", "Member only mortality");
            dic.Add("MortalityInDeferralPeriod_To", "Member only mortality");
            dic.Add("ActuarialEquivalence_From", "ValuationBasis");
            dic.Add("ActuarialEquivalence_To", "ValuationBasis");
            dic.Add("ApplySpouseAgeDifference_From", "True");
            dic.Add("ApplySpouseAgeDifference_To", "True");
            dic.Add("btnGuaranteePeriod_From_V", "");
            dic.Add("GuaranteePeriod_From_cbo", "");
            dic.Add("btnGuaranteePeriod_From_C", "Click");
            dic.Add("GuaranteePeriod_From_txt", "10");
            dic.Add("btnSurvivorPercentage_From_V", "");
            dic.Add("SurvivorPercentage_From_cbo", "");
            dic.Add("btnSurvivorPercentage_From_Percent", "");
            dic.Add("SurvivorPercentage_From_txt", "");
            dic.Add("btnPopupAmount_From_V", "");
            dic.Add("PopupAmount_From_cbo", "");
            dic.Add("btnPopupAmount_From_C", "Click");
            dic.Add("PopupAmount_From_txt", "");
            dic.Add("btnBenefitCommenceAge_From_V", "");
            dic.Add("BenefitCommenceAge_From_cbo", "");
            dic.Add("btnBenefitCommenceAge_From_C", "Click");
            dic.Add("BenefitCommenceAge_From_txt", "0");
            dic.Add("btnBenefitStopAge_From_V", "");
            dic.Add("BenefitStopAge_From_cbo", "");
            dic.Add("btnBenefitStopAge_From_C", "Click");
            dic.Add("BenefitStopAge_From_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_From_V", "");
            dic.Add("NumberOfPaymentsPerYear_From_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_From_C", "Click");
            dic.Add("NumberOfPaymentsPerYear_From_txt", "");
            dic.Add("btnGuaranteePeriod_To_V", "");
            dic.Add("GuaranteePeriod_To_cbo", "");
            dic.Add("btnGuaranteePeriod_To_C", "Click");
            dic.Add("GuaranteePeriod_To_txt", "");
            dic.Add("btnSurvivorPercentage_To_V", "");
            dic.Add("SurvivorPercentage_To_cbo", "");
            dic.Add("btnSurvivorPercentage_To_Percent", "Click");
            dic.Add("SurvivorPercentage_To_txt", "60.0");
            dic.Add("btnPopupAmount_To_V", "");
            dic.Add("PopupAmount_To_cbo", "");
            dic.Add("btnPopupAmount_To_C", "Click");
            dic.Add("PopupAmount_To_txt", "");
            dic.Add("btnBenefitCommenceAge_To_V", "");
            dic.Add("BenefitCommenceAge_To_cbo", "");
            dic.Add("btnBenefitCommenceAge_To_C", "Click");
            dic.Add("BenefitCommenceAge_To_txt", "0");
            dic.Add("btnBenefitStopAge_To_V", "");
            dic.Add("BenefitStopAge_To_cbo", "");
            dic.Add("btnBenefitStopAge_To_C", "Click");
            dic.Add("BenefitStopAge_To_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_To_V", "");
            dic.Add("NumberOfPaymentsPerYear_To_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_To_C", "Click");
            dic.Add("NumberOfPaymentsPerYear_To_txt", "");
            pConversionFactors._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("MenuItem", "Add Conversion Factors");
            pAssumptions._TreeViewRightSelect(dic, "ConvertToJs50");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("Level_3", "ConvertToJs50");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType_From", "");
            dic.Add("FormOfPaymentType_To", "Joint and survivor");
            dic.Add("MortalityInDeferralPeriod_From", "Member only mortality");
            dic.Add("MortalityInDeferralPeriod_To", "Member only mortality");
            dic.Add("ActuarialEquivalence_From", "ValuationBasis");
            dic.Add("ActuarialEquivalence_To", "ValuationBasis");
            dic.Add("ApplySpouseAgeDifference_From", "True");
            dic.Add("ApplySpouseAgeDifference_To", "True");
            dic.Add("btnGuaranteePeriod_From_V", "");
            dic.Add("GuaranteePeriod_From_cbo", "");
            dic.Add("btnGuaranteePeriod_From_C", "Click");
            dic.Add("GuaranteePeriod_From_txt", "10");
            dic.Add("btnSurvivorPercentage_From_V", "");
            dic.Add("SurvivorPercentage_From_cbo", "");
            dic.Add("btnSurvivorPercentage_From_Percent", "");
            dic.Add("SurvivorPercentage_From_txt", "");
            dic.Add("btnPopupAmount_From_V", "");
            dic.Add("PopupAmount_From_cbo", "");
            dic.Add("btnPopupAmount_From_C", "Click");
            dic.Add("PopupAmount_From_txt", "");
            dic.Add("btnBenefitCommenceAge_From_V", "Click");
            dic.Add("BenefitCommenceAge_From_cbo", "UnreducedAge");
            dic.Add("btnBenefitCommenceAge_From_C", "");
            dic.Add("BenefitCommenceAge_From_txt", "");
            dic.Add("btnBenefitStopAge_From_V", "");
            dic.Add("BenefitStopAge_From_cbo", "");
            dic.Add("btnBenefitStopAge_From_C", "Click");
            dic.Add("BenefitStopAge_From_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_From_V", "");
            dic.Add("NumberOfPaymentsPerYear_From_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_From_C", "Click");
            dic.Add("NumberOfPaymentsPerYear_From_txt", "");
            dic.Add("btnGuaranteePeriod_To_V", "");
            dic.Add("GuaranteePeriod_To_cbo", "");
            dic.Add("btnGuaranteePeriod_To_C", "Click");
            dic.Add("GuaranteePeriod_To_txt", "");
            dic.Add("btnSurvivorPercentage_To_V", "");
            dic.Add("SurvivorPercentage_To_cbo", "");
            dic.Add("btnSurvivorPercentage_To_Percent", "Click");
            dic.Add("SurvivorPercentage_To_txt", "50.0");
            dic.Add("btnPopupAmount_To_V", "");
            dic.Add("PopupAmount_To_cbo", "");
            dic.Add("btnPopupAmount_To_C", "Click");
            dic.Add("PopupAmount_To_txt", "");
            dic.Add("btnBenefitCommenceAge_To_V", "Click");
            dic.Add("BenefitCommenceAge_To_cbo", "UnreducedAge");
            dic.Add("btnBenefitCommenceAge_To_C", "");
            dic.Add("BenefitCommenceAge_To_txt", "");
            dic.Add("btnBenefitStopAge_To_V", "");
            dic.Add("BenefitStopAge_To_cbo", "");
            dic.Add("btnBenefitStopAge_To_C", "Click");
            dic.Add("BenefitStopAge_To_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_To_V", "");
            dic.Add("NumberOfPaymentsPerYear_To_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_To_C", "Click");
            dic.Add("NumberOfPaymentsPerYear_To_txt", "");
            pConversionFactors._PopVerify_Standard(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "JS60");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "JS60");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Joint and survivor");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            dic.Add("btnSurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "Click");
            dic.Add("SurvivorPercentOrAmount_txt", "60.0");
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
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "LA10");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "LA10");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "");
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
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "SpouseDID");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "SpouseDID");
            dic.Add("Level_4", "Default");
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
            dic.Add("btnSurvivorPercentOrAmount_Percent", "Click");
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
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "SpousesAnnuity");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "SpousesAnnuity");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Spouse's");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            dic.Add("btnSurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "Click");
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
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "InPayFOP");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "InPayFOP");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "");
            dic.Add("MortalityInReferralPeriod", "");
            dic.Add("btnGuaranteePeriod_V", "Click");
            dic.Add("GuaranteePeriod_cbo", "YearsCertain1");
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
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "InPayFOP");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "InPayFOP");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Joint and survivor");
            dic.Add("MortalityInReferralPeriod", "");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            dic.Add("btnSurvivorPercentOrAmount_V", "Click");
            dic.Add("SurvivorPercentOrAmount_cbo", "Beneficiary1Benefit1");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "");
            dic.Add("SurvivorPercentOrAmount_txt", "");
            dic.Add("cboSurvivorPercentOrAmount_PercentOrAmount", "Amount");
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
            dic.Add("LocalEligibility", "True");
            dic.Add("txtLocalEligibility", "JS");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.PaymentForm1=\"J&S\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Accounting 1/1/2012");


            sTable_RetirementScale07_Male = "";
            sTable_RetirementScale07_Male = sTable_RetirementScale07_Male + "0.100000" + Environment.NewLine;
            sTable_RetirementScale07_Male = sTable_RetirementScale07_Male + "0.050000" + Environment.NewLine;
            sTable_RetirementScale07_Male = sTable_RetirementScale07_Male + "0.050000" + Environment.NewLine;
            sTable_RetirementScale07_Male = sTable_RetirementScale07_Male + "0.050000" + Environment.NewLine;
            sTable_RetirementScale07_Male = sTable_RetirementScale07_Male + "0.150000" + Environment.NewLine;
            sTable_RetirementScale07_Male = sTable_RetirementScale07_Male + "0.275000" + Environment.NewLine;
            sTable_RetirementScale07_Male = sTable_RetirementScale07_Male + "0.150000" + Environment.NewLine;
            sTable_RetirementScale07_Male = sTable_RetirementScale07_Male + "0.150000" + Environment.NewLine;
            sTable_RetirementScale07_Male = sTable_RetirementScale07_Male + "0.150000" + Environment.NewLine;
            sTable_RetirementScale07_Male = sTable_RetirementScale07_Male + "0.150000" + Environment.NewLine;
            sTable_RetirementScale07_Male = sTable_RetirementScale07_Male + "1.000000" + Environment.NewLine;


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "RetirementScale07");
            dic.Add("Type", "Retirement Decrements");
            dic.Add("Description", "Copy from Canadian Sample Client");
            dic.Add("Ultimate", "");
            dic.Add("Generational", "");
            dic.Add("TwoDimensional", "");
            dic.Add("Index1_Index", "Age");
            dic.Add("Index1_From", "55");
            dic.Add("Index1_To", "65");
            dic.Add("Extend", "");
            dic.Add("Zero", "");
            dic.Add("SameRatesUsed", "");
            dic.Add("Format", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("OK", "Click");
            dic.Add("sMaleRates", sTable_RetirementScale07_Male);
            dic.Add("sFemaleRates", sTable_RetirementScale07_Male);
            pMain._ts_AddTable(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Assumptions");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "True");
            dic.Add("cboPreDefinedEligibility", "RetirementEligible");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pAssumptions._SelectTab("Parameters");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "RetirementScale07");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "TERM05");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "True");
            dic.Add("cboPreDefinedEligibility", "RetirementEligible");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pAssumptions._SelectTab("Parameters");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZEROWTH");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Benefit Elections");
            dic.Add("MenuItem", "Add Benefit Elections");
            pAssumptions._TreeViewRightSelect(dic, "ElectJS");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Benefit Elections");
            dic.Add("Level_3", "ElectJS");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "");
            dic.Add("Button_Percent", "");
            dic.Add("Button_T", "");
            dic.Add("ElectionPercentage_cbo", "");
            dic.Add("ElectionPercentage_txt", "70.0");
            pBenefitElections._PopVerify_BenefitElections(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Benefit Elections");
            dic.Add("MenuItem", "Add Benefit Elections");
            pAssumptions._TreeViewRightSelect(dic, "ElectLA");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Benefit Elections");
            dic.Add("Level_3", "ElectLA");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "");
            dic.Add("Button_Percent", "");
            dic.Add("Button_T", "");
            dic.Add("ElectionPercentage_cbo", "");
            dic.Add("ElectionPercentage_txt", "30.0");
            pBenefitElections._PopVerify_BenefitElections(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Provisions");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PVRet_JS");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVRet_JS");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "Click");
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
            dic.Add("FormOfPayment", "JS60");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "ElectJS");
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
            dic.Add("Level_3", "PVRet_JS");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");



            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "True");
            dic.Add("cboPreDefinedEligibility", "RetirementEligible");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            pAssumptions._SelectTab("Parameters");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "FAEBenefit");
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
            dic.Add("EarlyRetirementFactor", "ERF");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "ConvertLA10toJs60");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "JS60");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "ElectJS");
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
            pAssumptions._TreeViewRightSelect(dic, "PVRet_LA");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVRet_LA");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "Click");
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
            dic.Add("FormOfPayment", "JS60");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "ElectLA");
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
            dic.Add("Level_3", "PVRet_LA");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");



            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "True");
            dic.Add("cboPreDefinedEligibility", "RetirementEligible");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            pAssumptions._SelectTab("Parameters");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "FAEBenefit");
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
            dic.Add("EarlyRetirementFactor", "ERF");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "LA10");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "ElectLA");
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
            pAssumptions._TreeViewRightSelect(dic, "PVWth_JS");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVWth_JS");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "Click");
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
            dic.Add("FormOfPayment", "JS60");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "ElectJS");
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
            dic.Add("Level_3", "PVWth_JS");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");



            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "True");
            dic.Add("cboPreDefinedEligibility", "VestedNotRetElig");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            pAssumptions._SelectTab("Parameters");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "FAEBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "Click");
            dic.Add("BenefitCommenceAge_cbo", "UnreducedAge");
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
            dic.Add("ConversionFactor", "ConvertLA10toJs60");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "JS60");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "ElectJS");
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
            pAssumptions._TreeViewRightSelect(dic, "PVWth_LA");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVWth_LA");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "Click");
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
            dic.Add("FormOfPayment", "LA10");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "ElectLA");
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
            dic.Add("Level_3", "PVWth_LA");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");



            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "True");
            dic.Add("cboPreDefinedEligibility", "VestedNotRetElig");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            pAssumptions._SelectTab("Parameters");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "FAEBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "Click");
            dic.Add("BenefitCommenceAge_cbo", "UnreducedAge");
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
            dic.Add("FormOfPayment", "LA10");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "ElectLA");
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
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PVWithdrawalDID");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVWithdrawalDID");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "Click");
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
            dic.Add("FormOfPayment", "JS60");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "ElectJS");
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
            dic.Add("Level_3", "PVWithdrawalDID");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");



            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "True");
            dic.Add("cboPreDefinedEligibility", "VestedNotRetElig");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            pAssumptions._SelectTab("Parameters");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "FAEBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "Click");
            dic.Add("BenefitCommenceAge_cbo", "UnreducedAge");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "Click");
            dic.Add("BenefitStopAge_cbo", "UnreducedAge");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "ConvertToJs50");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "SpouseDID");
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
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PVDth");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVDth");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "FAEBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "Click");
            dic.Add("BenefitCommenceAge_cbo", "UnreducedAge");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "Vesting");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "ConvertToJs50");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "SpousesAnnuity");
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
            pAssumptions._TreeViewRightSelect(dic, "PVInPay");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVInPay");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "In pay inactives");
            dic.Add("SingleFormulaBenefit", "Benefit1DB");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "Click");
            dic.Add("BenefitCommenceAge_cbo", "StartDate1");
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
            dic.Add("FormOfPayment", "InPayFOP");
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
            pAssumptions._TreeViewRightSelect(dic, "PVDeferred_JS");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVDeferred_JS");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "Deferred inactives");
            dic.Add("SingleFormulaBenefit", "Benefit1DB");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "Click");
            dic.Add("BenefitCommenceAge_cbo", "UnreducedRetAge");
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
            dic.Add("ConversionFactor", "ConvertLA10toJs60");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "JS60");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "ElectJS");
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
            pAssumptions._TreeViewRightSelect(dic, "PVDeferred_LA");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVDeferred_LA");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "Deferred inactives");
            dic.Add("SingleFormulaBenefit", "Benefit1DB");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "Click");
            dic.Add("BenefitCommenceAge_cbo", "UnreducedRetAge");
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
            dic.Add("FormOfPayment", "LA10");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "ElectLA");
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
            pAssumptions._TreeViewRightSelect(dic, "PVDeferredDID");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVDeferredDID");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "Deferred inactives");
            dic.Add("SingleFormulaBenefit", "Benefit1DB");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "Click");
            dic.Add("BenefitCommenceAge_cbo", "UnreducedRetAge");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "Click");
            dic.Add("BenefitStopAge_cbo", "UnreducedRetAge");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "ConvertToJs50");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "SpouseDID");
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


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Accounting 1/1/2012");

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);






            #endregion

            #region Data2012 - Undo-Redo

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "ParticipantData");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Data2012");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Undo");
            pData._TreeViewSelect(dic);

            pData._ts_Undo("PostMatchDerivations for 2. Date Calc for Act/Def", 0, "Fix Start Date for Tier 2 Members");


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "2. Date Calc for Act/Def");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Fixed age");
            dic.Add("sData", "61");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service - Years");
            dic.Add("sData", "10");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "9");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service - Years");
            dic.Add("sData", "30");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
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
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "3. Service Calc");
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


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "4. Annualize Salary");
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


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Batch Update");
            dic.Add("Level_3", "4. Fix Term Date");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_BatchUpdate(dic);

            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Undo");
            pData._TreeViewSelect(dic);

            pData._ts_Undo("BatchUpdate for 4. Fix Term Date", 0, "workaround because of bug here");


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Batch Update");
            dic.Add("Level_3", "4. Fix Term Date");
            dic.Add("MenuItem", "Remove Batch Update");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            pData._PopVerify_BU_DeleteBatchUpdate_Popup(dic);

            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Batch Update");
            dic.Add("Level_3", "5. RetBene Start Date");
            dic.Add("MenuItem", "Remove Batch Update");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            pData._PopVerify_BU_DeleteBatchUpdate_Popup(dic);



            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Batch Update");
            dic.Add("MenuItem", "Add new batch update");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "4. Fix Term Date");
            dic.Add("SelectFieldstoDisplay", "Click");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "TerminationDate1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "True");
            dic.Add("CustomExpression_Formula", "=AND(TerminationDate1_C<HireDate1_C, NOT(ISBLANK(TerminationDate1_C)))");
            dic.Add("CustomExpression_Accept", "Click");
            dic.Add("Apply", "Click");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);


            pData._BU_FPGrid("64915822", 3, "10/15/1989", 4, "fix term date");
            pData._BU_FPGrid("951194859", 3, "2/1/2011", 4, "fix term date");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "True");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_BatchUpdate(dic);


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "5. Pensioner Calc");
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




            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Batch Update");
            dic.Add("MenuItem", "Add new batch update");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "5. RetBene Start Date");
            dic.Add("SelectFieldstoDisplay", "Click");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "StartDate1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "True");
            dic.Add("CustomExpression_Formula", "=OR(EmployeeIDNumber_C=900330929586, EmployeeIDNumber_C=900710369511, EmployeeIDNumber_C=900265522694)");
            dic.Add("CustomExpression_Accept", "Click");
            dic.Add("Apply", "Click");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);


            pData._BU_FPGrid("900265522694", 3, "12/1/1992", 4, "Plug beneficiary start date");
            pData._BU_FPGrid("900330929586", 3, "1/1/2011", 4, "Plug beneficiary start date");
            pData._BU_FPGrid("900710369511", 3, "6/1/1990", 4, "Plug beneficiary start date");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "True");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_BatchUpdate(dic);


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "Conversion Data");
            pData._TreeViewSelect(dic);

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
            dic.Add("Yes", "click");
            pData._PopVerify_SP_RePublishSnapshot_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_SP_Snapshots_Popup(dic);


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "ForExtractOnly");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "MemberSystemID");
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
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Work Fields");
            pData._TreeViewSelect_Snapshots(dic, true);

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


            pData._ts_SP_CreateExtract(sOutput_Data2012 + "Data2012_SnapshotExtract.xlsx");


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "(13)Conversion Data");
            dic.Add("MenuItem", "Run Summary Reports");
            pData._TreeViewRightSelect(dic);

            if (_gLib._Exists("Save", pData.wOM_DataService_Popup, 3, 1, false))
                _gLib._SetSyncUDWin("Yes", pData.wOM_DataService_Popup.wYes.btnYes, "Click", 0);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Service", "BenefitServiceAtValDate");
            dic.Add("Pay", "SalaryPriorYear1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("ApplyPctContinuedtoPen", "");
            dic.Add("CashBalance", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_SP_DataSummaryReportsParam(dic);

            pMain._SelectTab("Data2012");



            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Output Manager");
            pData._TreeViewSelect(dic);

            pMain._SelectTab("Data Output Manager");





            if (Config.bDownloadReports_PDF)
            {
                pData._OM_ExportReport_Common(sOutput_Data2012, "Current View", true);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Import Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Simple Import Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Filter Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Derivations Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Checks Results Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Plugs Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Corrections Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Batch Update Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Snapshot Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Reports Summary", true);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Derivations Summary", "Data2012_DerivationSummary_Set12DigitsIDForBeneficiary", 130, 1, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Derivations Summary", "Data2012_DerivationSummary_DateCalcForActDef", 130, 2, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Derivations Summary", "Data2012_DerivationSummary_ServiceCalc", 130, 3, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Derivations Summary", "Data2012_DerivationSummary_AnnualizeSalary", 130, 4, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Derivations Summary", "Data2012_DerivationSummary_PensionerCalc", 130, 5, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Import Summary", "Data2012_ImportSummary", 130, 1, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Snapshot Summary", "DataSummary", 130, 2, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pData._OM_ExportReport_Common(sOutput_Data2012, "Current View", false);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Import Summary", false);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Simple Import Summary", false);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Filter Summary", false, true);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Derivations Summary", false);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Checks Results Summary", false);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Plugs Summary", false);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Corrections Summary", false);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Batch Update Summary", false);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Snapshot Summary", false);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Reports Summary", false);

                //_gLib._MsgBox("Warning!", "Need further investingation for Data Subreports downloading naviation!");
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Derivations Summary", "Data2012_DerivationSummary_Set12DigitsIDForBeneficiary", 130, 1, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Derivations Summary", "Data2012_DerivationSummary_DateCalcForActDef", 130, 2, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Derivations Summary", "Data2012_DerivationSummary_ServiceCalc", 130, 3, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Derivations Summary", "Data2012_DerivationSummary_AnnualizeSalary", 130, 4, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Derivations Summary", "Data2012_DerivationSummary_PensionerCalc", 130, 5, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Simple Import Summary", "Data2012_SimpleImportSummary_SimpleImportDetail", 130, 1, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Batch Update Summary", "Data2012_BatchUpdateSummary_PlugSalaryRateFor2012NewHire", 130, 1, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Batch Update Summary", "Data2012_BatchUpdateSummary_CorrectSalaryHistoryForGeorgeWeasley", 130, 2, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Batch Update Summary", "Data2012_BatchUpdateSummary_CorrectSpouseDOB", 130, 3, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Batch Update Summary", "Data2012_BatchUpdateSummary_FixTermDate", 130, 4, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Batch Update Summary", "Data2012_BatchUpdateSummary_RetBeneStartDate", 130, 5, false);

                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Import Summary", "Data2012_ImportSummary", 130, 1, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Snapshot Summary", "DataSummary", 130, 2, false);

                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Reports Summary", "Data2012_Checks", 130, 1, false);
                //////////////////pData._OM_ExportReport_SubReports(sOutput_Data2012, "Reports Summary", "Data2012_Plug", 130, 3, false);
            }


            thrd_Data2012.Start();


            pMain._SelectTab("Data2012");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);





            #endregion
             
            #region Accounting2012 - ReRun


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Accounting 1/1/2012");
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
            dic.Add("Snapshot", "True");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Conversion Data");
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


            pMain._SelectTab("Accounting 1/1/2012");

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
            dic.Add("ProjectedpayToUse", "SalaryProjection");
            dic.Add("AccumulationToUse", "");
            dic.Add("IncludeExitYearValue", "");
            dic.Add("CalculatePresentValueOfFuture", "");
            dic.Add("CalculatePresentValueOfFuture_txt", "");
            dic.Add("VestingToUseForAgeFirstVested", "Vesting");
            dic.Add("AverageWorkingLifeTime", "True");
            dic.Add("AverageLifeTime", "True");
            dic.Add("AverageWorkingLifeTimeToVesting", "True");
            dic.Add("AverageWorkingLifeTimeForBenefitingEE", "");
            pMethods._PopVerify_Methods_Accounting(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Accounting 1/1/2012");

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
            dic.Add("PayoutProjection", "False");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "SalaryProjection");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "N/A");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
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


            pMain._SelectTab("Accounting 1/1/2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Common(sOutput_Data2012, "Valuation Summary", "Conversion", true, false);
            pOutputManager._ExportReport_Common(sOutput_Data2012, "Valuation Summary", "Conversion", false, false);
            pOutputManager._ExportReport_Others(sOutput_Data2012, "IOE", "Conversion", false, false);
            pOutputManager._ExportReport_Others(sOutput_Data2012, "Parameter Print", "Conversion", true, false);


            thrd_Data2012_Val.Start();


            pMain._SelectTab("Accounting 1/1/2012");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion

            _gLib._MsgBoxYesNo("Congratulations!", "Finnally, you are done with US018!");

            #region Data2013


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
            dic.Add("Name", "Data2013");
            dic.Add("EffectiveDate", "01/01/2013");
            dic.Add("Parent", "Data2012");
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
            dic.Add("ServiceToOpen", "Data2013");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("Level_1", "Data2013");
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
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\US018\Hogwarts Raw Data 2013.xls");
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
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "2012 import raw data");
            pData._TreeViewSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "2013 import 2012 data change");
            dic.Add("FileType", "Excel file");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "HogwartsRawData2013.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("SingleTabPerRecordFile_cbo", "Data 2013 - Data Change Only");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            pData._SelectTab("Mapping");


            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "EmployeeIDNumber");
            pData._IP_Mapping_Initialize("Personal Information", "Pay", 2, 1, 1, "Salary");

            pData._IP_Mapping_Initialize("Personal Information", "Salary", 3, 1, 1, "SalaryCurrentYear");


            ////////pData._IP_Mapping_MapField("SalaryPriorYear1", "Annualized Salary _2012", 1, true);
            pData._IP_Mapping_MapField("SalaryPriorYear1", "Annualized Salary 2012", 1, true);

            //////////////_gLib._MsgBox("Warning!", "Bug exists here, need to revert mapping code back once bug fixed.");


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
            dic.Add("iRow", "2");
            dic.Add("Apply", "False");
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
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "2013 import 2012 data change");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "2013 import membership movement");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("SingleTabPerRecordFile_cbo", "");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "HogwartsRawData2013.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("SingleTabPerRecordFile_cbo", "Data 2013 - Movement Only");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            pData._SelectTab("Mapping");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_Mapping(dic);




            pData._IP_Mapping_Initialize("Personal Information", "Client Data", 1, 0, 1, "ClientEmployeeIDNumber");
            pData._IP_Mapping_Initialize("Personal Information", "Retiree Medical", 1, 0, 1, "DentalCoverageFlag");
            pData._IP_Mapping_Initialize("Personal Information", "Accounting Results", 1, 0, 1, "GRSAccountingAL");
            pData._IP_Mapping_Initialize("Personal Information", "Funding Results", 1, 0, 1, "GRSFundingAL");
            pData._IP_Mapping_Initialize("Personal Information", "DC Information", 1, 0, 1, "MembershipDateDC1");
            pData._IP_Mapping_Initialize("Personal Information", "Classification Codes", 1, 0, 1, "DivisionCode");
            pData._IP_Mapping_Initialize("Personal Information", "DB Information", 1, 0, 1, "MembershipDate1");
            pData._IP_Mapping_Initialize("Personal Information", "Beneficiary Information", 1, 0, 1, "Beneficiary1ID");
            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "EmployeeIDNumber");

            pData._IP_Mapping_MapField("HireDate1", "Hire Date", 0, false, 4);
            pData._IP_Mapping_MapField("USC", "Status @ 1/1/2013", 2, true, 1);
            pData._IP_Mapping_MapField("TerminationDate1", "Term Date", 0, true, 6);
            pData._IP_Mapping_MapField("BenefitLevel", "Level", 0, true, 50);
            pData._IP_Mapping_MapField("ClientEmployeeIDNumber", "EmployeeIDNumber", 0, true, 20);
            pData._IP_Mapping_MapField("ClientName", "Name", 0, true, 1);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_Mapping(dic);


            pData._IP_Mapping_ClickEdit("USC", false);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_Transformation(1, 1, "Active");
            pData._IP_Mapping_Transformation(1, 2, "Act");

            pData._IP_Mapping_Transformation(2, 1, "Termination");
            pData._IP_Mapping_Transformation(2, 2, "Def");

            pData._IP_Mapping_Transformation(3, 1, "Pensioner");
            pData._IP_Mapping_Transformation(3, 2, "Ret");

            pData._IP_Mapping_Transformation(4, 1, "Beneficiary");
            pData._IP_Mapping_Transformation(4, 2, "RetBene");

            pData._IP_Mapping_Transformation(5, 1, "Non-vested");
            pData._IP_Mapping_Transformation(5, 2, "XNvt");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("OK", "Click");
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
            dic.Add("DerivedField", "EmployeeIDNumber");
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
            dic.Add("Level_2", "Client Data");
            dic.Add("Level_3", "ClientEmployeeIDNumber");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ClientEmployeeIDNumber");
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
            dic.Add("DerivedField", "Name");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_2", "Client Data");
            dic.Add("Level_3", "ClientName");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ClientName");
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
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "2013 import 2012 data change");
            pData._TreeViewSelect(dic);

            pData._SelectTab("Matching");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "8");
            dic.Add("Unique_UniqueMatch_Num", "67");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "0");
            dic.Add("Duplicate_UniqueMatch_Num", "12");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
            dic.Add("Warehouse_NoMatch_Num", "3");
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
            dic.Add("Unique_NoMatch", "");
            dic.Add("Unique_UniqueMatch", "");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "Click");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "");
            dic.Add("AcceptAllRecordsAs_What", "Unmerged");
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
            dic.Add("Unique_NoMatch", "");
            dic.Add("Unique_UniqueMatch", "");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "Click");
            dic.Add("AcceptAllRecordsAs_What", "");
            dic.Add("AcceptSelectedRecordsAs_What", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "Click");
            dic.Add("FindMatches", "");
            pData._PopVerify_IP_Matching(dic);


            dic.Clear();
            dic.Add("sDataFileRecords", "330929586");
            dic.Add("sWarehouseRecords", "900330929586");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "710369511");
            dic.Add("sWarehouseRecords", "900710369511");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "265522694");
            dic.Add("sWarehouseRecords", "900265522694");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("Close", "Click");
            pData._IP_MatchManually(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "5");
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
            dic.Add("SaveToWarehouse", "");
            dic.Add("MergeDuplicates", "Click");
            pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic);

            pData._SelectTab("Unmerged Duplicates");

            sMsgInfo = "For below 4 EEID in the middle table:" + "   226718605    " + "336830205  " + "604158342  " + "664264667  ";
            sMsgInfo = sMsgInfo + Environment.NewLine + "Highlight  and right-click the record with more data, select <Accept Record>";
            sMsgInfo = sMsgInfo + Environment.NewLine + "In the other row, Left Click on the cell for SalaryPriorYear1 (which should be non-blank), right click and select <Accept Field>";
            sMsgInfo = sMsgInfo + Environment.NewLine + "Then Click on the [Accept Final Record]";
            sMsgInfo = sMsgInfo + Environment.NewLine + Environment.NewLine + "For below 2 EEID in the middle table:" + "   495246873    " + "877887143  ";
            sMsgInfo = sMsgInfo + Environment.NewLine + "Highlight  and right-click the record with more data, select <Accept Record>";
            sMsgInfo = sMsgInfo + Environment.NewLine + Environment.NewLine + "Save to Warehouse";

            _gLib._MsgBox("Need Manual Interaction", sMsgInfo);


            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Filters");
            pData._TreeViewSelect(dic);

            pData._FL_Grid("Inact with Joint Form of Payment", 2, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("sData", "J&S");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            pData._FL_Grid("Joint Form Of Payment", 15, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("sData", "J&S");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            pData._FL_Grid("New Ret with Joint Form of Payment", 28, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("sData", "J&S");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            pData._FL_Grid("Still Ret with Contingent Form", 40, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("sData", "J&S");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Checks");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "Click");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Pay_C", "SalaryPriorYear1_C");
            dic.Add("Pay_P", "SalaryPriorYear1_P");
            dic.Add("AccruedBenefit_C", "#1#");
            dic.Add("AccruedBenefit_P", "#1#");
            dic.Add("CashBalanceBenefit_C", "");
            dic.Add("CashBalanceBenefit_P", "");
            dic.Add("BenefitService_C", "BenefitServiceAtValDate_C");
            dic.Add("BenefitService_P", "BenefitServiceAtValDate_P");
            dic.Add("VestingService_C", "VestingServiceAtValDate_C");
            dic.Add("VestingService_P", "VestingServiceAtValDate_P");
            dic.Add("Hours_C", "");
            dic.Add("Hours_P", "");
            dic.Add("InactiveBenefit_C", "");
            dic.Add("InactiveBenefit_P", "");
            dic.Add("StartDate_C", "");
            dic.Add("StartDate_P", "");
            dic.Add("HireDate_C", "");
            dic.Add("HireDate_P", "");
            dic.Add("MembershipDate_C", "");
            dic.Add("MembershipDate_P", "");
            dic.Add("TerminationDate_C", "");
            dic.Add("PaymentForm_C", "");
            dic.Add("PaymentForm_P", "");
            dic.Add("YearsCertain_C", "");
            dic.Add("YearsCertain_P", "");
            dic.Add("BeneficiaryPercent_C", "");
            dic.Add("BeneficiaryPercent_P", "");
            dic.Add("OK", "");
            pData._PopVerify_CK_StandardInputs_Part1(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayChange_Min", "0");
            dic.Add("PayChange_Max", "10");
            dic.Add("PayRange_Min", "20,000");
            dic.Add("PayRange_Max", "200,000");
            dic.Add("AccruedBenefitChange_Min", "");
            dic.Add("AccruedBenefitChange_Max", "");
            dic.Add("AccruedBenefitRange_Min", "");
            dic.Add("AccruedBenefitRange_Max", "");
            dic.Add("InactiveBenefitChange_Min", "0");
            dic.Add("InactiveBenefitChange_Max", "0");
            dic.Add("InactiveBenefitRange_Min", "500");
            dic.Add("InactiveBenefitRange_Max", "40,000");
            dic.Add("CashBalanceChange_Act_Min", "");
            dic.Add("CashBalanceChange_Act_Max", "");
            dic.Add("CashBalanceChange_InAct_Min", "");
            dic.Add("CashBalanceChange_InAct_Max", "");
            dic.Add("CashBalanceRange_Min", "");
            dic.Add("CashBalanceRange_Max", "");
            dic.Add("HoursRange_Min", "");
            dic.Add("HoursRange_Max", "");
            dic.Add("BenefitServiceRange_Min", "");
            dic.Add("BenefitServiceRange_Max", "");
            dic.Add("VestingServiceRange_Min", "0");
            dic.Add("VestingServiceRange_Max", "1");
            dic.Add("BenefitServiceForNewAct_Max", "1");
            dic.Add("VestServiceForNewAct_Max", "1");
            dic.Add("AgeForNewAct_Min", "");
            dic.Add("AgeForNewAct_Max", "");
            dic.Add("AgeForNewRetirees_Min", "");
            dic.Add("YearsRequiredForVesting", "3");
            dic.Add("BirthDate_Threshold", "0");
            dic.Add("HireDate_Threshold", "0");
            dic.Add("MembershipDate_Threshold", "0");
            dic.Add("StartDate_Threshold", "0");
            dic.Add("OK", "Click");
            pData._PopVerify_CK_StandardInputs_Part2(dic);



            dic.Clear();
            dic.Add("CheckName", "All");
            dic.Add("Include", "True");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);


            dic.Clear();
            dic.Add("CheckName", "All");
            dic.Add("Include", "True");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);


            dic.Clear();
            dic.Add("CheckName", "All");
            dic.Add("Include", "True");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, true);


            dic.Clear();
            dic.Add("CheckName", "Status Checks");
            dic.Add("iSearchDownNum", "42");
            dic.Add("Include", "False");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, true, true, true);



            dic.Clear();
            dic.Add("CheckName", "Retirement date after valuation date");
            dic.Add("iSearchDownNum", "5");
            dic.Add("Include", "True");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, true, true, true);

            dic.Clear();
            dic.Add("CheckName", "Termination date after valuation date");
            dic.Add("iSearchDownNum", "1");
            dic.Add("Include", "True");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, true, true, true);

            dic.Clear();
            dic.Add("CheckName", "Hire date after valuation date");
            dic.Add("iSearchDownNum", "1");
            dic.Add("Include", "True");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, true, true, true);

            dic.Clear();
            dic.Add("CheckName", "Membership date after valuation date");
            dic.Add("iSearchDownNum", "1");
            dic.Add("Include", "True");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, true, true, true);


            dic.Clear();
            dic.Add("CheckName", "Unreasonable age for new entrants");
            dic.Add("iSearchDownNum", "1");
            dic.Add("Include", "True");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, true, true, true);


            dic.Clear();
            dic.Add("CheckName", "Unreasonable age for new retirees");
            dic.Add("iSearchDownNum", "1");
            dic.Add("Include", "True");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, true, true, true);

            dic.Clear();
            dic.Add("CheckName", "New non-vested term, appears vested (hiredate)");
            dic.Add("iSearchDownNum", "2");
            dic.Add("Include", "True");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, true, true, true);


            dic.Clear();
            dic.Add("CheckName", "Conversion Checks");
            dic.Add("iSearchDownNum", "4");
            dic.Add("Include", "False");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            dic.Add("LabelsToDisplay", "");
            dic.Add("QueryInstructions", "");
            dic.Add("CorrectFields", "");
            pData._CK_CheckGrip(dic, true, true, true);


            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "Click");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);

            dic.Clear();
            dic.Add("CheckName", "Invalid or no beneficiary gender, new beneficiary");
            dic.Add("iSearchDownNum", "3");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, false, false);


            ////////////////////_gLib._MsgBox("New Beneficiary Checks => Invalid or no beneficiary gender, new beneficiary", "Please Click failed Number <1> in this Check and click OK to keep testing!");

            pData._CK_CheckGrip_ClickLink_Fail("Data2013", "New Beneficiary Checks => Invalid or no beneficiary gender, new beneficiary", "1", 4);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            dic.Add("AllQuery", "");
            dic.Add("AllPlug", "");
            dic.Add("AllOK", "True");
            dic.Add("Notes", "");
            pData._PopVerify_Checks(dic);



            dic.Clear();
            dic.Add("CheckName", "Invalid or no pay");
            dic.Add("iSearchDownNum", "9");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);


            //////////////////_gLib._MsgBox("Earnings and Accrued Benefit Checks => Invalid or no pay", "Please Click failed Number <5> in this Check and click OK to keep testing!");

            pData._CK_CheckGrip_ClickLink_Fail("Data2013", "Earnings and Accrued Benefit Checks => Invalid or no pay", "5");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            dic.Add("AllQuery", "");
            dic.Add("AllPlug", "True");
            dic.Add("AllOK", "");
            dic.Add("Notes", "Plug with Batch Update");
            pData._PopVerify_Checks(dic);


            dic.Clear();
            dic.Add("CheckName", "Invalid or no pension amount, new inactive");
            dic.Add("iSearchDownNum", "14");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);


            //////////////////////_gLib._MsgBox("New Inactive Checks => Invalid or no pension amount, new inactive", "Please Click failed Number <3> in this Check and click OK to keep testing!");

            pData._CK_CheckGrip_ClickLink_Fail("Data2013", "New Inactive Checks => Invalid or no pension amount, new inactive", "3");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            dic.Add("AllQuery", "True");
            dic.Add("AllPlug", "");
            dic.Add("AllOK", "");
            dic.Add("Notes", "");
            pData._PopVerify_Checks(dic);


            dic.Clear();
            dic.Add("CheckName", "Invalid or no retirement date, in pay inactive");
            dic.Add("iSearchDownNum", "1");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);


            //////////////////////////_gLib._MsgBox("New Inactive Checks => Invalid or no retirement date, in pay inactive", "Please Click failed Number <1> in this Check and click OK to keep testing!");

            pData._CK_CheckGrip_ClickLink_Fail("Data2013", "New Inactive Checks => Invalid or no retirement date, in pay inactive", "1");




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            dic.Add("AllQuery", "");
            dic.Add("AllPlug", "True");
            dic.Add("AllOK", "");
            dic.Add("Notes", "");
            pData._PopVerify_Checks(dic);


            dic.Clear();
            dic.Add("CheckName", "No form of payment, new inactive");
            dic.Add("iSearchDownNum", "4");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);


            //////////////////////_gLib._MsgBox("New Inactive Checks => No form of payment, new inactive", "Please Click failed Number <3> in this Check and click OK to keep testing!");

            pData._CK_CheckGrip_ClickLink_Fail("Data2013", "New Inactive Checks => No form of payment, new inactive", "3");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            dic.Add("AllQuery", "True");
            dic.Add("AllPlug", "");
            dic.Add("AllOK", "");
            dic.Add("Notes", "");
            pData._PopVerify_Checks(dic);


            dic.Clear();
            dic.Add("CheckName", "Invalid or no Membership Date");
            dic.Add("iSearchDownNum", "9");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);


            //////////////////////_gLib._MsgBox("Service Checks => Invalid or no Membership Date", "Please Click failed Number <5> in this Check and click OK to keep testing!");

            pData._CK_CheckGrip_ClickLink_Fail("Data2013", "Service Checks => Invalid or no Membership Date", "5");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            dic.Add("AllQuery", "");
            dic.Add("AllPlug", "");
            dic.Add("AllOK", "True");
            dic.Add("Notes", "calculate this");
            pData._PopVerify_Checks(dic);


            dic.Clear();
            dic.Add("CheckName", "Membership date after valuation date");
            dic.Add("iSearchDownNum", "11");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);


            ////////////////////////_gLib._MsgBox("Status Checks => Membership date after valuation date", "Please Click failed Number <5> in this Check and click OK to keep testing!");

            pData._CK_CheckGrip_ClickLink_Fail("Data2013", "Status Checks => Membership date after valuation date", "5");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            dic.Add("AllQuery", "");
            dic.Add("AllPlug", "");
            dic.Add("AllOK", "True");
            dic.Add("Notes", "missing");
            pData._PopVerify_Checks(dic);



            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Reports");
            dic.Add("Level_3", "All Check Results 2012");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "");
            dic.Add("StatusMatrix", "");
            dic.Add("StatusMatrix_Filter", "");
            dic.Add("ReportName", "All Check Results 2013");
            dic.Add("GenerateReport", "Click");
            pData._PopVerify_Reports(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_RP_ReportGenerated_Popup(dic);


            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Reports");
            dic.Add("Level_3", "Query 2012");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "");
            dic.Add("StatusMatrix", "");
            dic.Add("StatusMatrix_Filter", "");
            dic.Add("ReportName", "Query 2013");
            dic.Add("GenerateReport", "Click");
            pData._PopVerify_Reports(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_RP_ReportGenerated_Popup(dic);


            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Reports");
            dic.Add("Level_3", "Plug 2012");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "");
            dic.Add("StatusMatrix", "");
            dic.Add("StatusMatrix_Filter", "");
            dic.Add("ReportName", "Plug 2013");
            dic.Add("GenerateReport", "Click");
            pData._PopVerify_Reports(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_RP_ReportGenerated_Popup(dic);

            pData._SelectTab("Data2013");


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Data2013");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Output Manager");
            pData._TreeViewSelect(dic);

            pMain._SelectTab("Data Output Manager");

            pData._OM_ExportReport_SubReports(sOutput_Data2013, "Reports Summary", "Data2013_Query", 130, 2, false);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Data2013");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            sWriteFile_2013 = sOutput_Data2013 + "Data2013_Query.xlsx";

            _gLib._KillProcessByName("EXCEL");
            _excelRead = new MyExcel(sReadFile_2012, true);
            _excelWrite = new MyExcel(sWriteFile_2013, true);
            _excelRead.OpenExcelFile("Query Answer for 2013");
            _excelWrite.OpenExcelFile("New Inactive Checks");

            for (int i = 9; i <= 11; i++)
            {
                _excelWrite.setOneCellValue(i, 7, _excelRead.getOneCellValue(i, 7));
                _excelWrite.setOneCellValue(i, 8, _excelRead.getOneCellValue(i, 8));
            }

            for (int i = 18; i <= 20; i++)
            {
                _excelWrite.setOneCellValue(i, 9, _excelRead.getOneCellValue(i, 9));
                _excelWrite.setOneCellValue(i, 10, _excelRead.getOneCellValue(i, 10));
                _excelWrite.setOneCellValue(i, 11, _excelRead.getOneCellValue(i, 11));
                _excelWrite.setOneCellValue(i, 12, _excelRead.getOneCellValue(i, 12));
            }


            _excelRead.CloseExcelApplication();
            _excelWrite.SaveExcel();
            _excelWrite.CloseExcelApplication();


            pMain._SelectTab("Data2013");


            dic.Clear();
            dic.Add("Level_1", "Data2013");
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
            dic.Add("FileName", sWriteFile_2013);
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
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Simple Imports");
            dic.Add("Level_3", "Query Answer 1");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "Data2013_Query.xlsx");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            dic.Add("Process", "Click");
            pData._PopVerify_SimpleImport(dic);


            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Batch Update");
            dic.Add("Level_3", "1. Plug Salary Rate for 2012 new hire");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "1. Plug Salary Rate for New Hire");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "True");
            dic.Add("StandardorCustomFilter_cbo", "New Act");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "Click");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);

            pData._BU_FPGrid("93949036", 3, "61250.12", 4, "new hire salary plug");
            pData._BU_FPGrid("729455764", 3, "55600.87", 4, "new hire salary plug");
            pData._BU_FPGrid("916884621", 3, "44340.03", 4, "new hire salary plug");
            pData._BU_FPGrid("918999426", 3, "43370.06", 4, "new hire salary plug");
            pData._BU_FPGrid("943304808", 3, "38630.22", 4, "new hire salary plug");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_BatchUpdate(dic);

            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Batch Update");
            dic.Add("Level_3", "2. Correct Salary History for George Weasley");
            dic.Add("MenuItem", "Remove Batch Update");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            pData._PopVerify_BU_DeleteBatchUpdate_Popup(dic);

            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Batch Update");
            dic.Add("Level_3", "3. Correct Spouse DOB (year)");
            dic.Add("MenuItem", "Remove Batch Update");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            pData._PopVerify_BU_DeleteBatchUpdate_Popup(dic);

            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Batch Update");
            dic.Add("Level_3", "4. Fix Term Date");
            dic.Add("MenuItem", "Remove Batch Update");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            pData._PopVerify_BU_DeleteBatchUpdate_Popup(dic);

            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Batch Update");
            dic.Add("Level_3", "5. RetBene Start Date");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "2. Plug Start Date");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "True");
            dic.Add("StandardorCustomFilter_cbo", "New Ret");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "Click");
            dic.Add("Plug", "True");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);


            pData._BU_FPGrid("226718605", 3, "10/1/2012", 4, "month after term date");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_BatchUpdate(dic);


            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "1. Set 12 digits ID for Beneficiary");
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


            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "2. Date Calc for Act/Def");
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

            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "3. Service Calc");
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
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Fixed date");
            dic.Add("sData", "1/1/2013");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
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
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "4. Annualize Salary");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "4. Annualize Salary - DO NOT USE");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "4. Annualize Salary - DO NOT USE");
            dic.Add("MenuItem", "Move Down");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "5. Pensioner Calc");
            pData._TreeViewSelect(dic);

            for (int i = 1; i <= 5; i++)
            {
                dic.Clear();
                dic.Add("iRow", i.ToString());
                dic.Add("Apply", "False");
                dic.Add("DerivedField", "");
                dic.Add("DerivedField_SearchFromIndex", "");
                dic.Add("Type", "");
                dic.Add("Edit", "");
                pData._DG_DerivationGrid(dic);
            }



            dic.Clear();
            dic.Add("iRow", "6");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "True");
            dic.Add("Filter", "Is Ret Bene");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
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
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "Conversion Data");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Baseline Data 2013");
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

            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "ForExtractOnly");
            pData._TreeViewSelect(dic);

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

            pData._ts_SP_CreateExtract(sOutput_Data2013 + "Data2013_SnapshotExtract.xlsx");


            pData._SelectTab("Data2013");

            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "(9)Baseline Data 2013");
            dic.Add("MenuItem", "Run Summary Reports");
            pData._TreeViewRightSelect(dic);

            if (_gLib._Exists("Save", pData.wOM_DataService_Popup, 3, 1, false))
                _gLib._SetSyncUDWin("Yes", pData.wOM_DataService_Popup.wYes.btnYes, "Click", 0);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Service", "BenefitServiceAtValDate");
            dic.Add("Pay", "SalaryPriorYear1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("ApplyPctContinuedtoPen", "");
            dic.Add("CashBalance", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_SP_DataSummaryReportsParam(dic);

            pMain._SelectTab("Data2013");




            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Data2013");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Output Manager");
            pData._TreeViewSelect(dic);

            pMain._SelectTab("Data Output Manager");


            if (Config.bDownloadReports_PDF)
            {
                pData._OM_ExportReport_Common(sOutput_Data2013, "Prior View", true);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Current View", true);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Import Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Simple Import Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Filter Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Derivations Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Checks Results Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Plugs Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Batch Update Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Snapshot Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Reports Summary", true);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_Set12DigitsIDForBeneficiary", 130, 1, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_DateCalcForActDef", 130, 2, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_ServiceCalc", 130, 3, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_AnnualizeSalary", 130, 5, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_PensionerCalc", 130, 4, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Import Summary", "Data2013_ImportSummary", 130, 1, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Snapshot Summary", "DataSummary", 130, 2, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pData._OM_ExportReport_Common(sOutput_Data2013, "Prior View", false);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Current View", false);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Import Summary", false);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Simple Import Summary", false);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Filter Summary", false, true);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Derivations Summary", false);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Checks Results Summary", false);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Plugs Summary", false);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Batch Update Summary", false);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Snapshot Summary", false);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Reports Summary", false);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_Set12DigitsIDForBeneficiary", 130, 1, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_DateCalcForActDef", 130, 2, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_ServiceCalc", 130, 3, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_AnnualizeSalary", 130, 5, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_PensionerCalc", 130, 4, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Simple Import Summary", "Data2013_SimpleImportSummary_SimpleImportDetail", 130, 1, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Batch Update Summary", "Data2013_BatchUpdateSummary_PlugSalaryRateNewHire", 130, 1, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Batch Update Summary", "Data2013_BatchUpdateSummary_PlugStartDate", 130, 2, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Snapshot Summary", "DataSummary", 130, 2, false);
                ////////////////////////pData._OM_ExportReport_SubReports(sOutput_Data2013, "Reports Summary", "Data2013_Checks", 130, 1, false);
                ////////////////////////pData._OM_ExportReport_SubReports(sOutput_Data2013, "Reports Summary", "Data2013_Plug", 130, 3, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Import Summary", "Data2013_ImportSummary", 130, 1, false);
            }


            thrd_Data2013.Start();


            pMain._SelectTab("Data Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Data2013");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            #endregion

            #region Accounting2013


            pMain._SelectTab("Home");

            dic.Clear();
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
            dic.Add("ConversionService", "");
            dic.Add("Name", "Accounting 1/1/2013");
            dic.Add("Parent", "Accounting 1/1/2012");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "2013");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            dic.Add("Check_FundingCalculatorNotRunComplete", "False");
            pMain._PopVerify_Home_ServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Accounting 1/1/2013");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Accounting 1/1/2013");


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

            pMain._SelectTab("Accounting 1/1/2013");

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
            dic.Add("Snapshot", "True");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("CompareData", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Baseline Data 2013");
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
            dic.Add("CompareData", "False");
            dic.Add("ImportDataandApplyMapping", "Click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._SelectTab("Participant DataSet");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Accounting 1/1/2013");

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
            dic.Add("PayoutProjection", "False");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "SalaryProjection");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "N/A");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Accounting 1/1/2013");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Accounting 1/1/2013");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Common(sOutput_Data2013, "Valuation Summary", "RollForward", true, false);
            pOutputManager._ExportReport_Common(sOutput_Data2013, "Valuation Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Others(sOutput_Data2013, "IOE", "RollForward", false, false);

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US018", sOutput_Data2013_Prod, sOutput_Data2013);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Valuation2013");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 14, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0, true);
            }

            pMain._SelectTab("Accounting 1/1/2013");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);





            #endregion



            _gLib._MsgBoxYesNo("Congratulations!", "Finnally, you are done with US018!");



        }





        void t_CompareRpt_Data2012(string sOutput_Data2012)
        {


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US018", sOutput_Data2012_Prod, sOutput_Data2012);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Data2012");
                _compareReportsLib.CompareExcel_Exact("CurrentView.xlsx", 9, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ImportSummary.xlsx", 7, new int[1, 2] { { 11, 6 } }, new string[1] { "rptDataCheckingImportSummary" });
                _compareReportsLib.CompareExcel_Exact("Data2012_ImportSummary_DataFileMapping.xlsx", 9, 0, 0, 25, new int[1, 2] { { 13, 23 } }, new string[0] { }, new string[1] { "rptDataImportMapping" });
                _compareReportsLib.CompareExcel_Exact("Data2012_ImportSummary_DataFileMatching.xlsx", 9, new int[1, 2] { { 11, 33 } }, new string[1] { "rptDataImportMatching" });
                _compareReportsLib.CompareExcel_Exact("Data2012_ImportSummary_PMD.xlsx", 7, new int[4, 2] { { 12, 13 }, { 12, 14 }, { 13, 13 }, { 13, 14 } }, new string[1] { "rptDataImportPreMatching" });
                _compareReportsLib.CompareExcel_Exact("SimpleImportSummary.xlsx", 7, new int[2, 2] { { 11, 3 }, { 11, 7 } }, new string[1] { "rptDataCheckingSimpleImportSumm" });
                _compareReportsLib.CompareExcel_Exact("Data2012_SimpleImportSummary_SimpleImportDetail.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FilterSummary.xlsx", 9, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DerivationsSummary.xlsx", 9, new int[10, 2] { { 11, 3 }, { 12, 3 }, { 13, 3 }, { 14, 3 }, { 15, 3 }, { 11, 4 }, { 12, 4 }, { 13, 4 }, { 14, 4 }, { 15, 4 } }, new string[1] { "rptDataCheckingDerivationSummar" });
                _compareReportsLib.CompareExcel_Exact("Data2012_DerivationSummary_AnnualizeSalary.xlsx", 8, new int[18, 2] { { 15, 6 }, { 16, 6 }, { 17, 6 }, { 18, 6 }, { 19, 6 }, { 20, 6 }
                    ,{ 15, 13 }, { 16, 13 }, { 17, 13 }, { 18, 13 }, { 19, 13 }, { 20, 13 }
                    ,{ 15, 14 }, { 16, 14}, { 17, 14 }, { 18, 14 }, { 19, 14 }, { 20, 14 } }, new string[1] { "rptDataCheckingDerivationsSumma" });
                _compareReportsLib.CompareExcel_Exact("Data2012_DerivationSummary_DateCalcForActDef.xlsx", 8, new int[12, 2] { { 15, 6 }, { 16, 6 }, { 17, 6 }, { 18, 6 }
                    ,{ 15, 13 }, { 16, 13 }, { 17, 13 }, { 18, 13 }, { 15, 14 }, { 16, 14}, { 17, 14 }, { 18, 14 }}, new string[1] { "rptDataCheckingDerivationsSumma" });
                _compareReportsLib.CompareExcel_Exact("Data2012_DerivationSummary_PensionerCalc.xlsx", 8, new int[18, 2] { { 15, 6 }, { 16, 6 }, { 17, 6 }, { 18, 6 }, { 19, 6 }, { 20, 6 }
                    ,{ 15, 13 }, { 16, 13 }, { 17, 13 }, { 18, 13 }, { 19, 13 }, { 20, 13 }
                    ,{ 15, 14 }, { 16, 14}, { 17, 14 }, { 18, 14 }, { 19, 14 }, { 20, 14 } }, new string[1] { "rptDataCheckingDerivationsSumma" });
                _compareReportsLib.CompareExcel_Exact("Data2012_DerivationSummary_ServiceCalc.xlsx", 8, new int[9, 2] { { 15, 6 }, { 16, 6 }, { 17, 6 }, { 15, 13 }, { 16, 13 }, { 17, 13 }
                    , { 15, 14 }, { 16, 14}, { 17, 14 }}, new string[1] { "rptDataCheckingDerivationsSumma" });
                _compareReportsLib.CompareExcel_Exact("Data2012_DerivationSummary_Set12DigitsIDForBeneficiary.xlsx", 8, new int[6, 2] { { 15, 6 }, { 16, 6 }, { 15, 13 }, { 16, 13 }
                    , { 15, 14 }, { 16, 14}}, new string[1] { "rptDataCheckingDerivationsSumma" });
                _compareReportsLib.CompareExcel_Exact("ChecksResultsSummary.xlsx", 8, new int[12, 2] { { 12, 5 }, { 14, 5 }, { 15, 5 }, { 16, 5 }, { 17, 5 }, { 18, 5 }
                    ,{ 12, 6 }, { 14, 6 }, { 15, 6 }, { 16, 6 }, { 17, 6 }, { 18, 6 } }, new string[1] { "rptDataCheckingResultsSummary" });

                _compareReportsLib.CompareExcel_Exact("PlugsSummary.xlsx", 9, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CorrectionsSummary.xlsx", 9, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("BatchUpdateSummary.xlsx", 8, new int[10, 2] { { 11, 3 }, { 12, 3 }, { 13, 3 }, { 14, 3 }, { 15, 3 }
                    ,{ 11, 5 }, { 12, 5 }, { 13, 5 }, { 14, 5 }, { 15, 5 } }, new string[1] { "rptDataCheckingBatchUpdateSumma" });

                _compareReportsLib.CompareExcel_Exact("Data2012_BatchUpdateSummary_CorrectSalaryHistoryForGeorgeWeasley.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("Data2012_BatchUpdateSummary_CorrectSpouseDOB.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("Data2012_BatchUpdateSummary_FixTermDate.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("Data2012_BatchUpdateSummary_PlugSalaryRateFor2012NewHire.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("Data2012_BatchUpdateSummary_RetBeneStartDate.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("SnapshotSummary.xlsx", 8, new int[6, 2] { { 12, 3 }, { 13, 3 }, { 12, 4 }, { 13, 4 }, { 12, 5 }, { 13, 5 } }, new string[1] { "rptDataCheckingSnapshotSummary" });
                _compareReportsLib.CompareExcel_Exact("Data2012_SnapshotExtract.xlsx", 7, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("Data2012_Checks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("Data2012_Query.xlsx", 4, new string[1] { "@Import" });
                _compareReportsLib.CompareExcel_Exact("Data2012_Plug.xlsx", 4, new string[1] { "@Import" });

                _compareReportsLib.CompareExcel_Exact("DataSummary_MemberStatisticsReport.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataSummary_StatusReconciliation-DataReports.xlsx", 6, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataSummary_AgeServiceMatrix.xlsx", 6, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataSummary_InactiveBenefitSummarybyAgeReport.xlsx", 7, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }




        }
        
        void t_CompareRpt_Data2012_Val(string sOutput_Data2012)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US018", sOutput_Data2012_Prod, sOutput_Data2012);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting2012");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 14, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }


        }
        
        void t_CompareRpt_Data2013(string sOutput_Data2013)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US018", sOutput_Data2013_Prod, sOutput_Data2013);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Data2013_Part_1");
                _compareReportsLib.CompareExcel_Exact("PriorView.xlsx", 9, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CurrentView.xlsx", 9, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ImportSummary.xlsx", 7, new int[2, 2] { { 11, 6 }, { 12, 6 } }, new string[1] { "rptDataCheckingImportSummary" });
                _compareReportsLib.CompareExcel_Exact("Data2013_ImportSummary_DataFileMapping.xlsx", 9, 0, 0, 25, new int[1, 2] { { 13, 23 } }, new string[0] { }, new string[1] { "rptDataImportMapping" });
                _compareReportsLib.CompareExcel_Exact("Data2013_ImportSummary_DataFileMatching.xlsx", 9, new int[1, 2] { { 11, 33 } }, new string[1] { "rptDataImportMatching" });
                _compareReportsLib.CompareExcel_Exact("Data2013_ImportSummary_PMD.xlsx", 7, new int[4, 2] { { 12, 13 }, { 12, 14 }, { 13, 13 }, { 13, 14 } }, new string[1] { "rptDataImportPreMatching" });
                _compareReportsLib.CompareExcel_Exact("SimpleImportSummary.xlsx", 7, new int[2, 2] { { 11, 3 }, { 11, 7 } }, new string[1] { "rptDataCheckingSimpleImportSumm" });
                _compareReportsLib.CompareExcel_Exact("Data2013_SimpleImportSummary_SimpleImportDetail.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FilterSummary.xlsx", 9, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DerivationsSummary.xlsx", 9, new int[10, 2] { { 11, 3 }, { 12, 3 }, { 13, 3 }, { 14, 3 }, { 15, 3 }, { 11, 4 }, { 12, 4 }, { 13, 4 }, { 14, 4 }, { 15, 4 } }, new string[1] { "rptDataCheckingDerivationSummar" });
                _compareReportsLib.CompareExcel_Exact("Data2013_DerivationSummary_AnnualizeSalary.xlsx", 8, new int[18, 2] { { 15, 6 }, { 16, 6 }, { 17, 6 }, { 18, 6 }, { 19, 6 }, { 20, 6 }
                    ,{ 15, 13 }, { 16, 13 }, { 17, 13 }, { 18, 13 }, { 19, 13 }, { 20, 13 }
                    ,{ 15, 14 }, { 16, 14}, { 17, 14 }, { 18, 14 }, { 19, 14 }, { 20, 14 } }, new string[1] { "rptDataCheckingDerivationsSumma" });
                _compareReportsLib.CompareExcel_Exact("Data2013_DerivationSummary_DateCalcForActDef.xlsx", 8, new int[12, 2] { { 15, 6 }, { 16, 6 }, { 17, 6 }, { 18, 6 }
                    ,{ 15, 13 }, { 16, 13 }, { 17, 13 }, { 18, 13 }, { 15, 14 }, { 16, 14}, { 17, 14 }, { 18, 14 }}, new string[1] { "rptDataCheckingDerivationsSumma" });
               
                 Config.bThreadFinsihed = true;

            }



            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US018", sOutput_Data2013_Prod, sOutput_Data2013);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Data2013_Part_2");

               _compareReportsLib.CompareExcel_Exact("Data2013_DerivationSummary_PensionerCalc.xlsx", 8, new int[18, 2] { { 15, 6 }, { 16, 6 }, { 17, 6 }, { 18, 6 }, { 19, 6 }, { 20, 6 }
                    ,{ 15, 13 }, { 16, 13 }, { 17, 13 }, { 18, 13 }, { 19, 13 }, { 20, 13 }
                    ,{ 15, 14 }, { 16, 14}, { 17, 14 }, { 18, 14 }, { 19, 14 }, { 20, 14 } }, new string[1] { "rptDataCheckingDerivationsSumma" });
                _compareReportsLib.CompareExcel_Exact("Data2013_DerivationSummary_ServiceCalc.xlsx", 8, new int[9, 2] { { 15, 6 }, { 16, 6 }, { 17, 6 }, { 15, 13 }, { 16, 13 }, { 17, 13 }
                    , { 15, 14 }, { 16, 14}, { 17, 14 }}, new string[1] { "rptDataCheckingDerivationsSumma" });
                _compareReportsLib.CompareExcel_Exact("Data2013_DerivationSummary_Set12DigitsIDForBeneficiary.xlsx", 8, new int[6, 2] { { 15, 6 }, { 16, 6 }, { 15, 13 }, { 16, 13 }
                    , { 15, 14 }, { 16, 14}}, new string[1] { "rptDataCheckingDerivationsSumma" });

                _compareReportsLib.CompareExcel_Exact("ChecksResultsSummary.xlsx", 8, 0, 0, 4, new int[0, 2] { }, new string[0] { }, new string[1] { "rptDataCheckingResultsSummary" });
                _compareReportsLib.CompareExcel_Exact("ChecksResultsSummary.xlsx", 8, 0, 7, 0, new int[0, 2] { }, new string[0] { }, new string[1] { "rptDataCheckingResultsSummary" });

                _compareReportsLib.CompareExcel_Exact("PlugsSummary.xlsx", 9, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("BatchUpdateSummary.xlsx", 8, new int[4, 2] { { 11, 3 }, { 11, 5 }, { 12, 3 }, { 12, 5 } }, new string[1] { "rptDataCheckingBatchUpdateSumma" });
                _compareReportsLib.CompareExcel_Exact("Data2013_BatchUpdateSummary_PlugSalaryRateNewHire.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("Data2013_BatchUpdateSummary_PlugStartDate.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("SnapshotSummary.xlsx", 8, new int[6, 2] { { 12, 3 }, { 13, 3 }, { 12, 4 }, { 13, 4 }, { 12, 5 }, { 13, 5 } }, new string[1] { "rptDataCheckingSnapshotSummary" });
                _compareReportsLib.CompareExcel_Exact("Data2013_SnapshotExtract.xlsx", 7, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("Data2013_Checks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("Data2013_Query.xlsx", 4, new string[1] { "@Import" });
                _compareReportsLib.CompareExcel_Exact("Data2013_Plug.xlsx", 4, new string[1] { "@Import" });

                _compareReportsLib.CompareExcel_Exact("DataSummary_MemberStatisticsReport.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataSummary_StatusReconciliation-DataReports.xlsx", 6, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataSummary_AgeServiceMatrix.xlsx", 6, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataSummary_InactiveBenefitSummarybyAgeReport.xlsx", 7, 0, 0, 0);
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
        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }
        private UIMap map;
    }
}
