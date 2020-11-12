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
using RetirementStudio._ThridParty;
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
using System.Threading;



namespace RetirementStudio._TestScripts._TestScripts_US
{


    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class US008_CN
    {
        public US008_CN()
        {
 
            Config.eEnv = _TestingEnv.Prod_US;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US 008 US Upgrade Franklin";
            Config.sPlanName = "QA US 008 US Upgrade Franklin Plan";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;


            //_gLib._Report(_PassFailStep.Header, "Testing Starts at: " + DateTime.Now + "\t" + Environment.UserName);

            //_gLib._MsgBox("Warning!", "If you are running Existing or Re-opened Studio after crash, Please manually select the Client in Studio-> Home -> All Services -> "
            //    + Config.sClientName + Environment.NewLine + Environment.NewLine + "If you are running CreateNew without any crash, Please ignore this msg!"
            //    + Environment.NewLine + Environment.NewLine + "Click OK to keep testing!");



        }



        #region Report Output Directory

        

        public string sOutputFunding_Conversion2011_Baseline = "";
        public string sOutputFunding_Valuation2012_Baseline = "";
        public string sOutputFunding_Valuation2012_UpdateAssumptionDates = "";
        public string sOutputFunding_Valuation2012_ForAFN2012 = "";
        public string sOutputFunding_Valuation2012_ForAFTAPRange = "";
        public string sOutputFunding_Valuation2013_Baseline = "";
        public string sOutputFunding_Valuation2013_UpdateInterestAndMortality = "";
        public string sOutputFunding_Valuation2013_ForAFN2012 = "";
        public string sOutputFunding_ForAFTAPRangeTest_Baseline = "";
        public string sOutputAccounting_Conversion2011_Baseline = "";
        public string sOutputAccounting_FASVal2012_Baseline = "";


        public string sOutputFunding_Conversion2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Conversion2011\Baseline\7.3.0.1_20190321_Franklin\";
        public string sOutputFunding_Valuation2012_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Valuation2012\Baseline\7.3.0.1_20190321_Franklin\";
        public string sOutputFunding_Valuation2012_UpdateAssumptionDates_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Valuation2012\UpdateAssumptionDates\7.3.0.1_20190321_Franklin\";
        public string sOutputFunding_Valuation2012_ForAFN2012_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Valuation2012\ForAFN2012\7.3.0.1_20190321_Franklin\";
        public string sOutputFunding_Valuation2012_ForAFTAPRange_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Valuation2012\ForAFTAPRange\7.3.0.1_20190321_Franklin\";
        public string sOutputFunding_Valuation2013_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Valuation2013\Baseline\7.3.0.1_20190321_Franklin\";
        public string sOutputFunding_Valuation2013_UpdateInterestAndMortality_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Valuation2013\UpdateInterestAndMortality\7.3.0.1_20190321_Franklin\";
        public string sOutputFunding_Valuation2013_ForAFN2012_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Valuation2013\ForAFN2012\7.3.0.1_20190321_Franklin\";
        public string sOutputFunding_ForAFTAPRangeTest_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\ForAFTAPRangeTest\Baseline\7.3.0.1_20190321_Franklin\";
        public string sOutputAccounting_Conversion2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Accounting\Conversion2011\Baseline\7.3.0.1_20190321_Franklin\";
        public string sOutputAccounting_FASVal2012_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Accounting\FASVal2012\Baseline\7.3.0.1_20190321_Franklin\";


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

                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Create New\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();
                    sOutputFunding_Conversion2011_Baseline                  =  _gLib._CreateDirectory(sMainDir + "Funding\\Conversion2011\\Baseline\\"+ sPostFix + "\\");
                    sOutputFunding_Valuation2012_Baseline                   = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2012\\Baseline\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2012_UpdateAssumptionDates      = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2012\\UpdateAssumptionDates\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2012_ForAFN2012                 = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2012\\ForAFN2012\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2012_ForAFTAPRange              = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2012\\ForAFTAPRange\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2013_Baseline                   = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2013\\Baseline\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2013_UpdateInterestAndMortality = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2013\\UpdateInterestAndMortality\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2013_ForAFN2012                 = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2013\\ForAFN2012\\" + sPostFix + "\\");
                    sOutputFunding_ForAFTAPRangeTest_Baseline               = _gLib._CreateDirectory(sMainDir + "Funding\\ForAFTAPRangeTest\\Baseline\\" + sPostFix + "\\");
                    sOutputAccounting_Conversion2011_Baseline               = _gLib._CreateDirectory(sMainDir + "Accounting\\Conversion2011\\Baseline\\" + sPostFix + "\\");
                    sOutputAccounting_FASVal2012_Baseline                   = _gLib._CreateDirectory(sMainDir + "Accounting\\FASVal2012\\Baseline\\" + sPostFix + "\\");

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

                string sUS008Dir = sDir + "US008_" + _gLib._ReturnDateStampYYYYMMDD();

                _gLib._CreateDirectory(sUS008Dir);
                sOutputFunding_Conversion2011_Baseline                  = _gLib._CreateDirectory(sUS008Dir + "\\Funding_Conversion2011_Baseline\\");
                sOutputFunding_Valuation2012_Baseline                   = _gLib._CreateDirectory(sUS008Dir + "\\Funding_Valuation2012_Baseline\\");
                sOutputFunding_Valuation2012_UpdateAssumptionDates      = _gLib._CreateDirectory(sUS008Dir + "\\Funding_Valuation2012_UpdateAssumptionDates\\");
                sOutputFunding_Valuation2012_ForAFN2012                 = _gLib._CreateDirectory(sUS008Dir + "\\Funding_Valuation2012_ForAFN2012\\");
                sOutputFunding_Valuation2012_ForAFTAPRange              = _gLib._CreateDirectory(sUS008Dir + "\\Funding_Valuation2012_ForAFTAPRange\\");
                sOutputFunding_Valuation2013_Baseline                   = _gLib._CreateDirectory(sUS008Dir + "\\Funding_Valuation2013_Baseline\\");
                sOutputFunding_Valuation2013_UpdateInterestAndMortality = _gLib._CreateDirectory(sUS008Dir + "\\Funding_Valuation2013_UpdateInterestAndMortality\\");
                sOutputFunding_Valuation2013_ForAFN2012                 = _gLib._CreateDirectory(sUS008Dir + "\\Funding_Valuation2013_ForAFN2012\\");
                sOutputFunding_ForAFTAPRangeTest_Baseline               = _gLib._CreateDirectory(sUS008Dir + "\\Funding_ForAFTAPRangeTest_Baseline\\");
                sOutputAccounting_Conversion2011_Baseline               = _gLib._CreateDirectory(sUS008Dir + "\\Accounting_Conversion2011_Baseline\\");
                sOutputAccounting_FASVal2012_Baseline                   = _gLib._CreateDirectory(sUS008Dir + "\\Accounting_FASVal2012_Baseline\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputFunding_Conversion2011_Baseline = @\"" + sOutputFunding_Conversion2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2012_Baseline = @\"" + sOutputFunding_Valuation2012_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2012_UpdateAssumptionDates = @\"" + sOutputFunding_Valuation2012_UpdateAssumptionDates + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2012_ForAFN2012 = @\"" + sOutputFunding_Valuation2012_ForAFN2012 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2012_ForAFN2012 = @\"" + sOutputFunding_Valuation2012_ForAFN2012 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2012_ForAFTAPRange = @\"" + sOutputFunding_Valuation2012_ForAFTAPRange + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2013_Baseline = @\"" + sOutputFunding_Valuation2013_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2013_UpdateInterestAndMortality = @\"" + sOutputFunding_Valuation2013_UpdateInterestAndMortality + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2013_ForAFN2012 = @\"" + sOutputFunding_Valuation2013_ForAFN2012 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_ForAFTAPRangeTest_Baseline = @\"" + sOutputFunding_ForAFTAPRangeTest_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Conversion2011_Baseline = @\"" + sOutputAccounting_Conversion2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_FASVal2012_Baseline = @\"" + sOutputAccounting_FASVal2012_Baseline + "\";" + Environment.NewLine;

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

        #endregion


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_US008_CN()
        {

            #region MultiThreads


            Thread thrd_Funding_Converson2011_Baseline = new Thread(() => new US008_CN().t_CompareRpt_Funding_Conversion2011_Baseline(sOutputFunding_Conversion2011_Baseline));
            Thread thrd_Funding_Valuation2012_Baseline = new Thread(() => new US008_CN().t_CompareRpt_Funding_Valuation2012_Baseline(sOutputFunding_Valuation2012_Baseline));
            Thread thrd_Funding_Valuation2012_UpdateAssumptionDates = new Thread(() => new US008_CN().t_CompareRpt_Funding_Valuation2012_UpdateAssumptionDates(sOutputFunding_Valuation2012_UpdateAssumptionDates));
            Thread thrd_Funding_Valuation2012_ForAFN2012 = new Thread(() => new US008_CN().t_CompareRpt_Funding_Valuation2012_ForAFN2012(sOutputFunding_Valuation2012_ForAFN2012));
            Thread thrd_Funding_Valuation2012_ForAFTAPRange = new Thread(() => new US008_CN().t_CompareRpt_Funding_Valuation2012_ForAFTAPRange(sOutputFunding_Valuation2012_ForAFTAPRange));
            Thread thrd_Funding_Valuation2013_Baseline = new Thread(() => new US008_CN().t_CompareRpt_Funding_Valuation2013_Baseline(sOutputFunding_Valuation2013_Baseline));
            Thread thrd_Funding_Valuation2013_UpdateInterestAndMortality = new Thread(() => new US008_CN().t_CompareRpt_Funding_Valuation2013_UpdateInterestAndMortality(sOutputFunding_Valuation2013_UpdateInterestAndMortality));
            Thread thrd_Funding_Valuation2013_ForAFN2012 = new Thread(() => new US008_CN().t_CompareRpt_Funding_Valuation2013_ForAFN2012(sOutputFunding_Valuation2013_ForAFN2012));
            Thread thrd_Accounting_Conversion2011_Baseline = new Thread(() => new US008_CN().t_CompareRpt_Accounting_Conversion2011_Baseline(sOutputAccounting_Conversion2011_Baseline));





            #endregion
             

            this.GenerateReportOuputDir();


            #region Client & Plan


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
            dic.Add("ClientCode", "US008Update");
            dic.Add("FiscalYearEnd", "12/31");
            dic.Add("MeasurementDate", "12/31");
            dic.Add("Notes", "Client Owner: Karen Lanctot. Original client: KJL - Updated US008");
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
            dic.Add("PlanYearBegin", "01/01");
            dic.Add("OK", "Click");
            pMain._PopVerify_PMTool_Plan(dic);


            pMain._SelectTab("Home");




            #endregion




            #region Data - Data 2011

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
            dic.Add("Name", "Data 2011");
            dic.Add("EffectiveDate", "01/01/2011");
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
            dic.Add("ServiceToOpen", "Data 2011");
            pMain._PopVerify_Home_RightPane(dic);



            dic.Clear();
            dic.Add("Level_1", "Data 2011");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "BenefitInPayment");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);



            pData._CV_ExpandPersonalInformation();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Service");
            dic.Add("Label", "BenService");
            dic.Add("DisplayName", "BenService");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "");
            dic.Add("DecimalPlaces", "4");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Service");
            dic.Add("Label", "BenServiceInc");
            dic.Add("DisplayName", "BenServiceInc");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "");
            dic.Add("DecimalPlaces", "4");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Service");
            dic.Add("Label", "VestService");
            dic.Add("DisplayName", "VestService");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "");
            dic.Add("DecimalPlaces", "4");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Pay");
            dic.Add("Label", "Salary");
            dic.Add("DisplayName", "Salary");
            dic.Add("HistoryLabels", "12");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "TestFlag");
            dic.Add("DisplayName", "TestFlag");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Integer");
            dic.Add("FieldLength", "1");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DC Information");
            dic.Add("Label", "TestLifeCode");
            dic.Add("DisplayName", "TestLifeCode");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Integer");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Data 2011");
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
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\DFL\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\US008\Data2011.xls");
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

            ////////dic.Clear();
            ////////dic.Add("PopVerify", "Verify");
            ////////dic.Add("ClickCell", "");
            ////////dic.Add("iRow", "2");
            ////////dic.Add("iCol", "1");
            ////////dic.Add("sRow", "");
            ////////dic.Add("sCol", "");
            ////////dic.Add("sData", "Data2011.xls");
            ////////pData._UD_RepositoryContents(dic);


            dic.Clear();
            dic.Add("Level_1", "Data 2011");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "ImportData");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);



            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "Excel file");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "Data2011.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            pData._SelectTab("Mapping");


            pData._IP_Mapping_Initialize("Personal Information", "DC Information", 1, 0, 1, "MembershipDateDC1");
            pData._IP_Mapping_Initialize("Personal Information", "Classification Codes", 1, 0, 1, "DivisionCode");
            pData._IP_Mapping_Initialize("Personal Information", "DB Information", 1, 0, 1, "MembershipDate1");
            pData._IP_Mapping_Initialize("Personal Information", "Beneficiary Information", 1, 0, 1, "Beneficiary1ID");
            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "EmployeeIDNumber");

            pData._IP_Mapping_Initialize("Personal Information", "Pay", 2, 6, 1, "Salary");
            pData._IP_Mapping_Initialize("Personal Information", "Salary", 3, 6, 1, "SalaryCurrentYear");
            pData._IP_Mapping_Initialize("Personal Information", "Service", 2, 6, 1, "BenService");


            pData._IP_Mapping_MapField("ParticipantStatus", "PARTSTAT(C)", 0, false);
            pData._IP_Mapping_MapField("PayStatus", "PAYSTAT(C)", 0, true);
            pData._IP_Mapping_MapField("HealthStatus", "HEALTHST(C)", 0, true);
            pData._IP_Mapping_MapField("AliveStatus", "ALIVEST(C)", 0, true);
            pData._IP_Mapping_MapField("BenService", "BENSRV", 3, true);
            pData._IP_Mapping_MapField("BenServiceInc", "BSRVFUT", 6, true);
            pData._IP_Mapping_MapField("VestService", "VSTSRV", 12, true);

            pData._IP_Mapping_MapField("SalaryPriorYear1", "VPAY0(S)", 1, true);
            pData._IP_Mapping_MapField("SalaryPriorYear2", "VPAY1(S)", 2, true);
            pData._IP_Mapping_MapField("SalaryPriorYear3", "VPAY2(S)", 4, true);
            pData._IP_Mapping_MapField("SalaryPriorYear4", "VPAY3(S)", 5, true);
            pData._IP_Mapping_MapField("SalaryPriorYear5", "VPAY4(S)", 6, true);
            pData._IP_Mapping_MapField("SalaryPriorYear6", "VPAY5(S)", 7, true);
            pData._IP_Mapping_MapField("SalaryPriorYear7", "VPAY6(S)", 8, true);
            pData._IP_Mapping_MapField("SalaryPriorYear8", "VPAY7(S)", 9, true);
            pData._IP_Mapping_MapField("SalaryPriorYear9", "VPAY8(S)", 10, true);
            pData._IP_Mapping_MapField("SalaryPriorYear10", "VPAY9(S)", 11, true);






            pData._IP_Mapping_MapField("Benefit1DB", "PBENA", 2, true);
            pData._IP_Mapping_MapField("AccruedBenefit1", "ACBENACA", 0, true);
            pData._IP_Mapping_MapField("BenefitInPayment", "PAYBEN", 2, true);
            pData._IP_Mapping_MapField("TestFlag", "ETEST", 8, true);
            pData._IP_Mapping_MapField("HourlyFlag", "ETEST", 8, true, 4);
            pData._IP_Mapping_MapField("TestLifeCode", "ETEST", 8, true, 15);



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
            dic.Add("Unique_NoMatch_Num", "135");
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
            dic.Add("New_Num", "135");
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
            dic.Add("Level_1", "Data 2011");
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



            dic.Clear();
            dic.Add("Level_1", "Data 2011");
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
            dic.Add("Level_3", "MemberSystemID");
            pData._TreeViewSelect_Snapshots(dic, false);

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
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ExitDate");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "TerminationDate1");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "DeathDate");
            pData._TreeViewSelect_Snapshots(dic, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "MaritalStatus");
            pData._TreeViewSelect_Snapshots(dic, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ImportName");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Salary");
            dic.Add("Level_5", "SalaryPriorYear11");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Salary");
            dic.Add("Level_5", "SalaryPriorYear12");
            pData._TreeViewSelect_Snapshots(dic, false);

            //////////////////dic.Clear();
            //////////////////dic.Add("Level_1", "Include all");
            //////////////////dic.Add("Level_2", "Personal Information");
            //////////////////dic.Add("Level_3", "Pay");
            //////////////////dic.Add("Level_4", "Salary");
            //////////////////dic.Add("Level_5", "SalaryPriorYear13");
            //////////////////pData._TreeViewSelect_Snapshots(dic, false);


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
            dic.Add("Level_3", "Beneficiary1Percent1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit1DB");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedBenefit1");
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
            dic.Add("Level_3", "TestFlag");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "BenefitInPayment");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "HourlyFlag");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "OrganizationCode");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Valuation Data");
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




            dic.Clear();
            dic.Add("Level_1", "Data 2011");
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
            dic.Add("Pay_C", "");
            dic.Add("Pay_P", "");
            dic.Add("AccruedBenefit_C", "");
            dic.Add("AccruedBenefit_P", "");
            dic.Add("CashBalanceBenefit_C", "");
            dic.Add("CashBalanceBenefit_P", "");
            dic.Add("BenefitService_C", "BenService_C");
            dic.Add("BenefitService_P", "");
            dic.Add("VestingService_C", "VestService_C");
            dic.Add("VestingService_P", "");
            dic.Add("Hours_C", "");
            dic.Add("Hours_P", "");
            dic.Add("InactiveBenefit_C", "");
            dic.Add("InactiveBenefit_P", "");
            dic.Add("StartDate_C", "");
            dic.Add("StartDate_P", "");
            dic.Add("HireDate_C", "");
            dic.Add("HireDate_P", "");
            dic.Add("MembershipDate_C", "MembershipDate1_C");
            dic.Add("MembershipDate_P", "#1#");
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
            dic.Add("PayChange_Max", "");
            dic.Add("PayRange_Min", "50,000");
            dic.Add("PayRange_Max", "200,000");
            dic.Add("AccruedBenefitChange_Min", "");
            dic.Add("AccruedBenefitChange_Max", "");
            dic.Add("AccruedBenefitRange_Min", "");
            dic.Add("AccruedBenefitRange_Max", "");
            dic.Add("InactiveBenefitChange_Min", "");
            dic.Add("InactiveBenefitChange_Max", "");
            dic.Add("InactiveBenefitRange_Min", "0");
            dic.Add("InactiveBenefitRange_Max", "1,000");
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
            dic.Add("VestingServiceRange_Min", "");
            dic.Add("VestingServiceRange_Max", "");
            dic.Add("BenefitServiceForNewAct_Max", "1");
            dic.Add("VestServiceForNewAct_Max", "1");
            dic.Add("AgeForNewAct_Min", "");
            dic.Add("AgeForNewAct_Max", "");
            dic.Add("AgeForNewRetirees_Min", "");
            dic.Add("YearsRequiredForVesting", "");
            dic.Add("BirthDate_Threshold", "");
            dic.Add("HireDate_Threshold", "");
            dic.Add("MembershipDate_Threshold", "");
            dic.Add("StartDate_Threshold", "");
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


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "Click");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);

            pMain._Home_ToolbarClick_Top(true);




            ////////////////dic.Clear();
            ////////////////dic.Add("Level_1", "Data 2011");
            ////////////////dic.Add("Level_2", "Status Matrix");
            ////////////////pData._TreeViewSelect(dic);


            ////////////////dic.Clear();
            ////////////////dic.Add("PopVerify", "Pop");
            ////////////////dic.Add("CreateMatrix", "Click");
            ////////////////pData._PopVerify_StatusMatrix(dic);

            ////////////////pMain._Home_ToolbarClick_Top(true);




            dic.Clear();
            dic.Add("Level_1", "Data 2011");
            dic.Add("Level_2", "Reports");
            dic.Add("MenuItem", "Add new report");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "");
            dic.Add("StatusMatrix", "");
            dic.Add("StatusMatrix_Filter", "");
            dic.Add("ReportName", "AllChecks");
            dic.Add("GenerateReport", "Click");
            pData._PopVerify_Reports(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_RP_ReportGenerated_Popup(dic);


            dic.Clear();
            dic.Add("Level_1", "Data 2011");
            dic.Add("Level_2", "Reports");
            dic.Add("MenuItem", "Add new report");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "");
            dic.Add("StatusMatrix", "Click");
            dic.Add("StatusMatrix_Filter", "");
            dic.Add("ReportName", "StatusMatrix");
            ////////////dic.Add("GenerateReport", "Click");
            pData._PopVerify_Reports(dic);


            ////////////dic.Clear();
            ////////////dic.Add("PopVerify", "Pop");
            ////////////dic.Add("OK", "Click");
            ////////////pData._PopVerify_RP_ReportGenerated_Popup(dic);


            pMain._Home_ToolbarClick_Top(true);

            //////////dic.Clear();
            //////////dic.Add("Level_1", "Data 2011");
            //////////dic.Add("Level_2", "Output Manager");
            //////////pData._TreeViewSelect(dic);

            //////////pData._SelectTab("Data Output Manager");

            //////////pData._OM_ExportReport_SubReports(sOutputFunding_Conversion2011_Baseline, "Reports Summary", "AllChecks", 130, 1, false);

            //////////pData._OM_ExportReport_SubReports(sOutputFunding_Conversion2011_Baseline, "Reports Summary", "StatusMatrix", 130, 2, false);
            //////////pMain._Home_ToolbarClick_Top(true);
            //////////pData._SelectTab("Data Output Manager");
            //////////pMain._Home_ToolbarClick_Top(true);
            pData._SelectTab("Data 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Data - Data 2012

            pMain._SelectTab("Home");


            ////////////////dic.Clear();
            ////////////////dic.Add("Level_1", Config.sClientName);
            ////////////////dic.Add("Level_2", Config.sPlanName);
            ////////////////dic.Add("Level_3", "ParticipantData");
            ////////////////pMain._HomeTreeViewSelect(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Data 2012");
            dic.Add("EffectiveDate", "01/01/2012");
            dic.Add("Parent", "Data 2011");
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
            dic.Add("ServiceToOpen", "Data 2012");
            pMain._PopVerify_Home_RightPane(dic);




            dic.Clear();
            dic.Add("Level_1", "Data 2012");
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
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\DFL\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\US008\Data2012.xls");
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

            ////////dic.Clear();
            ////////dic.Add("PopVerify", "Verify");
            ////////dic.Add("ClickCell", "");
            ////////dic.Add("iRow", "3");
            ////////dic.Add("iCol", "1");
            ////////dic.Add("sRow", "");
            ////////dic.Add("sCol", "");
            ////////dic.Add("sData", "Data2012.xls");
            ////////pData._UD_RepositoryContents(dic);




            dic.Clear();
            dic.Add("Level_1", "Data 2012");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "ImportData");
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
            dic.Add("FileName", "Data2012.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            pData._SelectTab("Mapping");

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
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "10");
            dic.Add("Unique_UniqueMatch_Num", "125");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "0");
            dic.Add("Duplicate_UniqueMatch_Num", "0");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
            dic.Add("Warehouse_NoMatch_Num", "10");
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
            dic.Add("PopVerify", "Verify");
            dic.Add("Matched_Num", "125");
            dic.Add("New_Num", "10");
            dic.Add("Ignored_Num", "0");
            dic.Add("Gone_Num", "10");
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
            dic.Add("Level_1", "Data 2012");
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
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);



            dic.Clear();
            dic.Add("Level_1", "Data 2012");
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "Valuation Data");
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


            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Data 2012");
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
            dic.Add("Pay_C", "");
            dic.Add("Pay_P", "");
            dic.Add("AccruedBenefit_C", "");
            dic.Add("AccruedBenefit_P", "");
            dic.Add("CashBalanceBenefit_C", "");
            dic.Add("CashBalanceBenefit_P", "");
            dic.Add("BenefitService_C", "#1#");
            dic.Add("BenefitService_P", "BenService_P");
            dic.Add("VestingService_C", "#1#");
            dic.Add("VestingService_P", "VestService_P");
            dic.Add("Hours_C", "");
            dic.Add("Hours_P", "");
            dic.Add("InactiveBenefit_C", "");
            dic.Add("InactiveBenefit_P", "");
            dic.Add("StartDate_C", "");
            dic.Add("StartDate_P", "");
            dic.Add("HireDate_C", "");
            dic.Add("HireDate_P", "");
            dic.Add("MembershipDate_C", "");
            dic.Add("MembershipDate_P", "#1#");
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
            dic.Add("PayChange_Max", "5");
            dic.Add("PayRange_Min", "");
            dic.Add("PayRange_Max", "");
            dic.Add("AccruedBenefitChange_Min", "");
            dic.Add("AccruedBenefitChange_Max", "");
            dic.Add("AccruedBenefitRange_Min", "");
            dic.Add("AccruedBenefitRange_Max", "");
            dic.Add("InactiveBenefitChange_Min", "");
            dic.Add("InactiveBenefitChange_Max", "");
            dic.Add("InactiveBenefitRange_Min", "");
            dic.Add("InactiveBenefitRange_Max", "");
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
            dic.Add("VestingServiceRange_Min", "");
            dic.Add("VestingServiceRange_Max", "");
            dic.Add("BenefitServiceForNewAct_Max", "");
            dic.Add("VestServiceForNewAct_Max", "");
            dic.Add("AgeForNewAct_Min", "");
            dic.Add("AgeForNewAct_Max", "");
            dic.Add("AgeForNewRetirees_Min", "");
            dic.Add("YearsRequiredForVesting", "5");
            dic.Add("BirthDate_Threshold", "");
            dic.Add("HireDate_Threshold", "");
            dic.Add("MembershipDate_Threshold", "");
            dic.Add("StartDate_Threshold", "");
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


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "Click");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Data 2012");
            dic.Add("Level_2", "Status Matrix");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CreateMatrix", "Click");
            pData._PopVerify_StatusMatrix(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Data 2012");
            dic.Add("Level_2", "Reports");
            dic.Add("Level_3", "AllChecks");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "");
            dic.Add("StatusMatrix", "");
            dic.Add("StatusMatrix_Filter", "");
            dic.Add("ReportName", "");
            dic.Add("GenerateReport", "Click");
            pData._PopVerify_Reports(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_RP_ReportGenerated_Popup(dic);


            dic.Clear();
            dic.Add("Level_1", "Data 2012");
            dic.Add("Level_2", "Reports");
            dic.Add("Level_3", "StatusMatrix");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "");
            dic.Add("StatusMatrix", "");
            dic.Add("StatusMatrix_Filter", "");
            dic.Add("ReportName", "");
            dic.Add("GenerateReport", "Click");
            pData._PopVerify_Reports(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_RP_ReportGenerated_Popup(dic);

            //////////////pMain._Home_ToolbarClick_Top(true);

            //////////////dic.Clear();
            //////////////dic.Add("Level_1", "Data 2012");
            //////////////dic.Add("Level_2", "Output Manager");
            //////////////pData._TreeViewSelect(dic);

            //////////////pData._SelectTab("Data Output Manager");

            //////////////pData._OM_ExportReport_SubReports(sOutputFunding_Valuation2012_Baseline, "Reports Summary", "AllChecks", 130, 1, false);

            //////////////pData._OM_ExportReport_SubReports(sOutputFunding_Valuation2012_Baseline, "Reports Summary", "StatusMatrix", 130, 2, false);

            //////////////pData._SelectTab("Data Output Manager");
            //////////////pMain._Home_ToolbarClick_Top(true);
            pData._SelectTab("Data 2012");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Data - Data 2013

            //////////////////dic.Clear();
            //////////////////dic.Add("Level_1", Config.sClientName);
            //////////////////dic.Add("Level_2", Config.sPlanName);
            //////////////////dic.Add("Level_3", "ParticipantData");
            //////////////////pMain._HomeTreeViewSelect(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Data 2013");
            dic.Add("EffectiveDate", "01/01/2013");
            dic.Add("Parent", "Data 2012");
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
            dic.Add("ServiceToOpen", "Data 2013");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("Level_1", "Data 2013");
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
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\DFL\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\US008\Data2013.xls");
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
            dic.Add("Level_1", "Data 2013");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "ImportData");
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
            dic.Add("FileName", "Data2013.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            pData._SelectTab("Mapping");


            pData._IP_Mapping_Initialize("Personal Information", "DC Information", 1, 0, 1, "MembershipDateDC1");
            pData._IP_Mapping_Initialize("Personal Information", "Classification Codes", 1, 0, 1, "DivisionCode");
            pData._IP_Mapping_Initialize("Personal Information", "DB Information", 1, 0, 1, "MembershipDate1");
            pData._IP_Mapping_Initialize("Personal Information", "Beneficiary Information", 1, 0, 1, "Beneficiary1ID");
            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "EmployeeIDNumber");
            pData._IP_Mapping_Initialize("Personal Information", "Pay", 2, 11, 1, "Salary");
            pData._IP_Mapping_Initialize("Personal Information", "Salary", 3, 11, 1, "SalaryCurrentYear");
            pData._IP_Mapping_Initialize("Personal Information", "Service", 2, 11, 1, "BenService");


            pData._IP_Mapping_MapField("BenService", "BenefitServiceAmt", 4, false);
            pData._IP_Mapping_MapField("BenServiceInc", "ServiceIncrement", 0, true);
            pData._IP_Mapping_MapField("VestService", "VestingServiceAmt", 0, true);
            pData._IP_Mapping_MapField("SalaryPriorYear1", "Pay2009", 0, true);
            pData._IP_Mapping_MapField("AccruedBenefit1", "AccruedBenefitOnValdate", 0, true);

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
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "1");
            dic.Add("Unique_UniqueMatch_Num", "129");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "0");
            dic.Add("Duplicate_UniqueMatch_Num", "0");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
            ////////dic.Add("Warehouse_NoMatch_Num", "16");
            dic.Add("Warehouse_NoMatch_Num", "6");
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
            dic.Add("iStartNum", "");
            dic.Add("sColumn", "BirthDate");
            dic.Add("sData", "6/6/1987");
            pData._IP_Matching_MatchingResults_Select(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "");
            dic.Add("Unique_UniqueMatch", "");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "");
            dic.Add("AcceptAllRecordsAs_What", "");
            dic.Add("AcceptSelectedRecordsAs_What", "Unmatched");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Are you sure that you want to accept selected records with a status of Unmatched");
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
            dic.Add("Message", "Selected records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);


            dic.Clear();
            dic.Add("iStartNum", "");
            dic.Add("sColumn", "BirthDate");
            dic.Add("sData", "8/11/1986");
            pData._IP_Matching_MatchingResults_Select(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "");
            dic.Add("Unique_UniqueMatch", "");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "");
            dic.Add("AcceptAllRecordsAs_What", "");
            dic.Add("AcceptSelectedRecordsAs_What", "Unmatched");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Are you sure that you want to accept selected records with a status of Unmatched");
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
            dic.Add("Message", "Selected records have been accepted");
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
            dic.Add("Warehouse_NoMatch", "");
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
            dic.Add("PopVerify", "Verify");
            dic.Add("Matched_Num", "129");
            dic.Add("New_Num", "1");
            dic.Add("Ignored_Num", "0");
            //////////dic.Add("Gone_Num", "14");
            dic.Add("Gone_Num", "4");
            dic.Add("Leaver_Num", "0");
            dic.Add("Unmatched_Num", "2");
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
            dic.Add("Level_1", "Data 2013");
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
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);



            dic.Clear();
            dic.Add("Level_1", "Data 2013");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "Set Status for Unmatched");
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
            dic.Add("Level_3", "USC");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(MatchStatus=\"Unmatched\",\"XNvt\", USC_C)");
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
            dic.Add("Level_1", "Data 2013");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "Calculate BenefitInPayment");
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
            dic.Add("DerivedField", "BenefitInPayment");
            dic.Add("DerivedField_SearchFromIndex", "10");
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
            dic.Add("Level_3", "USC");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

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
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(USC_C=\"Act\", 0, IF(USC_C=\"RetBene\",Beneficiary1Percent1_C*Benefit1DB_C/100,Benefit1DB_C))");
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
            dic.Add("Level_1", "Data 2013");
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
            dic.Add("Pay_C", "");
            dic.Add("Pay_P", "SalaryCurrentYear_P");
            dic.Add("AccruedBenefit_C", "");
            dic.Add("AccruedBenefit_P", "");
            dic.Add("CashBalanceBenefit_C", "");
            dic.Add("CashBalanceBenefit_P", "");
            dic.Add("BenefitService_C", "");
            dic.Add("BenefitService_P", "BenService_P");
            dic.Add("VestingService_C", "VestService_C");
            dic.Add("VestingService_P", "VestService_P");
            dic.Add("Hours_C", "");
            dic.Add("Hours_P", "");
            dic.Add("InactiveBenefit_C", "");
            dic.Add("InactiveBenefit_P", "");
            dic.Add("StartDate_C", "");
            dic.Add("StartDate_P", "");
            dic.Add("HireDate_C", "");
            dic.Add("HireDate_P", "");
            dic.Add("MembershipDate_C", "MembershipDate1_C");
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
            dic.Add("PayChange_Min", "");
            dic.Add("PayChange_Max", "");
            dic.Add("PayRange_Min", "");
            dic.Add("PayRange_Max", "");
            dic.Add("AccruedBenefitChange_Min", "");
            dic.Add("AccruedBenefitChange_Max", "");
            dic.Add("AccruedBenefitRange_Min", "");
            dic.Add("AccruedBenefitRange_Max", "");
            dic.Add("InactiveBenefitChange_Min", "");
            dic.Add("InactiveBenefitChange_Max", "");
            dic.Add("InactiveBenefitRange_Min", "");
            dic.Add("InactiveBenefitRange_Max", "");
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
            dic.Add("VestingServiceRange_Min", "");
            dic.Add("VestingServiceRange_Max", "");
            dic.Add("BenefitServiceForNewAct_Max", "");
            dic.Add("VestServiceForNewAct_Max", "");
            dic.Add("AgeForNewAct_Min", "");
            dic.Add("AgeForNewAct_Max", "");
            dic.Add("AgeForNewRetirees_Min", "");
            dic.Add("YearsRequiredForVesting", "5");
            dic.Add("BirthDate_Threshold", "");
            dic.Add("HireDate_Threshold", "");
            dic.Add("MembershipDate_Threshold", "");
            dic.Add("StartDate_Threshold", "");
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


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "Click");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Data 2013");
            dic.Add("Level_2", "Status Matrix");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CreateMatrix", "Click");
            pData._PopVerify_StatusMatrix(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Data 2013");
            dic.Add("Level_2", "Reports");
            dic.Add("Level_3", "AllChecks");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "");
            dic.Add("StatusMatrix", "");
            dic.Add("StatusMatrix_Filter", "");
            dic.Add("ReportName", "");
            dic.Add("GenerateReport", "Click");
            pData._PopVerify_Reports(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_RP_ReportGenerated_Popup(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Data 2013");
            dic.Add("Level_2", "Reports");
            dic.Add("Level_3", "StatusMatrix");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "");
            dic.Add("StatusMatrix", "");
            dic.Add("StatusMatrix_Filter", "");
            dic.Add("ReportName", "");
            dic.Add("GenerateReport", "Click");
            pData._PopVerify_Reports(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_RP_ReportGenerated_Popup(dic);


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Data 2013");
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "Valuation Data");
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

            //////////////////pMain._Home_ToolbarClick_Top(true);

            //////////////////dic.Clear();
            //////////////////dic.Add("Level_1", "Data 2013");
            //////////////////dic.Add("Level_2", "Output Manager");
            //////////////////pData._TreeViewSelect(dic);

            //////////////////pData._SelectTab("Data Output Manager");

            //////////////////pData._OM_ExportReport_SubReports(sOutputFunding_Valuation2013_Baseline, "Reports Summary", "AllChecks", 130, 1, false);

            //////////////////pData._OM_ExportReport_SubReports(sOutputFunding_Valuation2013_Baseline, "Reports Summary", "StatusMatrix", 130, 2, false);

            //////////////////pData._SelectTab("Data Output Manager");
            //////////////////pMain._Home_ToolbarClick_Top(true);
            pData._SelectTab("Data 2013");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);





            #endregion







            #region FundingValuation - Conversion 2011 - Baseline


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
            dic.Add("Name", "Conversion 2011");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "2011");
            dic.Add("FirstYearPlanUnderPPA", "2008");
            dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Conversion 2011");
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
            dic.Add("SnapshotName", "Valuation Data");
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



            pMain._SelectTab("Conversion 2011");

            dic.Clear();
            dic.Add("MenuItem_1", "File");
            dic.Add("MenuItem_2", "Import Tables");
            pMain._MenuSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("GRSServer", "Deerfield");
            dic.Add("LoginID", "user1");
            dic.Add("Password", "user1");
            dic.Add("OK", "Click");
            pParticipantDataSet._PopVerify_GRSLogin(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", "L281 - QA US Benchmark 008 Data Source");
            dic.Add("OK", "Click");
            pParticipantDataSet._PopVerify_GRSClientForTableImport(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectAll", "Click");
            dic.Add("Import", "Click");
            dic.Add("NumOfTablesImported", "6");
            pParticipantDataSet._PopVerify_SourceTable(dic);

            pMain._Home_ToolbarClick_Top(true);





            pMain._SelectTab("Conversion 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("MenuItem", "Add New Liability Type/Projection Folder");
            pAssumptions._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "FAS35Int");
            dic.Add("EAN", "");
            dic.Add("FAS35PVAB", "True");
            dic.Add("FAS35PVVB", "True");
            dic.Add("Nondiscrimination", "");
            dic.Add("PBGCARPVVB", "");
            dic.Add("PBGCNARPVVB", "");
            dic.Add("PBGCPlanTerm", "");
            dic.Add("PPAARMax", "");
            dic.Add("PPAARMin", "");
            dic.Add("PPAARPVVB", "");
            dic.Add("PPANARMax", "");
            dic.Add("PPANARMin", "");
            dic.Add("PPANARPVVB", "");
            dic.Add("Projection", "");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "FAS35Int");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "8.5");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("MenuItem", "Add New Liability Type/Projection Folder");
            pAssumptions._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "PBGCInt");
            dic.Add("EAN", "");
            dic.Add("FAS35PVAB", "");
            dic.Add("FAS35PVVB", "");
            dic.Add("Nondiscrimination", "");
            dic.Add("PBGCARPVVB", "True");
            dic.Add("PBGCNARPVVB", "True");
            dic.Add("PBGCPlanTerm", "True");
            dic.Add("PPAARMax", "");
            dic.Add("PPAARMin", "");
            dic.Add("PPAARPVVB", "");
            dic.Add("PPANARMax", "");
            dic.Add("PPANARMin", "");
            dic.Add("PPANARPVVB", "");
            dic.Add("Projection", "");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "PBGCInt");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "Click");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("Rate", "PBGC 3-segment rates");
            dic.Add("AsOfDate", "09/01/2010");
            pInterestRate._PopVerify_PrescribedRates(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AllOthers");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "Click");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "09/01/2010");
            pInterestRate._PopVerify_PrescribedRates(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
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
            dic.Add("txtRate", "5.5");
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
            dic.Add("txtPercentMarried_M", "80.0");
            dic.Add("txtPercentMarried_F", "80.0");
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
            dic.Add("PrescribedRates", "Click");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("DisabledVsHealthy", "True");
            dic.Add("MemberVsSpouse", "");
            pMortalityDecrement._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "50.00");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pMain._Home_ToolbarClick_Top(true);





            pMain._SelectTab("Conversion 2011");

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
            dic.Add("ProvidedInDataField", "BenService");
            dic.Add("RoundingRule", "");
            dic.Add("V", "Click");
            dic.Add("C", "");
            dic.Add("T", "");
            dic.Add("txtServiceIncrement", "");
            dic.Add("cboServiceIncrement", "BenServiceInc");
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
            dic.Add("ProvidedInDataField", "VestService");
            dic.Add("RoundingRule", "");
            dic.Add("V", "");
            dic.Add("C", "");
            dic.Add("T", "");
            dic.Add("txtServiceIncrement", "");
            dic.Add("cboServiceIncrement", "");
            pService._PopVerify_ServiceAtValuationDate(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "RetElig");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "RetElig");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$Age>= 65");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "VestedNotRetire");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "VestedNotRetire");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$VestingService>=5 and $Age<65");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "PayProjection1");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "PayProjection1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataFieldContainingPayHistory", "Salary");
            dic.Add("PayIncreaseAssumption", "PayIncrease1");
            dic.Add("UseOnlyDataFields", "");
            dic.Add("rdValuationYearPlus", "");
            dic.Add("txtValuationYearPlus", "");
            dic.Add("rdSpecifiedYear", "");
            dic.Add("txtSpecifiedYear", "");
            dic.Add("ApplyEGTRRALimits", "False");
            pPayoutProjection._PopVerify_History(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("MenuItem", "Add Pay Average");
            pAssumptions._TreeViewRightSelect(dic, "PayAverage1");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("Level_3", "PayAverage1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "PayProjection1");
            dic.Add("AveragingMethod", "");
            dic.Add("M", "");
            dic.Add("RoundingForYearOfHire", "");
            dic.Add("DecimalPlacesForYearOfHire", "");
            dic.Add("Include", "");
            dic.Add("DropForCalculations", "");
            dic.Add("DropForCalculationAndPeriodConsidered", "");
            pPayAverage._PopVerify_Standard(dic);


            pMain._Home_ToolbarClick_Top(true);





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
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "RetElig");
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
            dic.Add("RetWithdrawDis", "NHG3464");
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
            dic.Add("RetWithdrawDis", "NHG2319");
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
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "RetElig");
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
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "_Disability");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "DI1006");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);


            pMain._Home_ToolbarClick_Top(true);






            pMain._SelectTab("Provisions");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "AccruedBenefit");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("Level_4", "AccruedBenefit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max((0.01 * 6600.00 + 0.015*($PayAverage1 - 6600.00))* $BenefitService, $emp.AccruedBenefit1)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            dic.Add("MenuItem", "Add Vesting");
            pAssumptions._TreeViewRightSelect(dic, "Vesting1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            dic.Add("Level_3", "Vesting1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VestingServiceDefinition", "VestingService");
            dic.Add("AddRow", "");
            pVesting._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("YearsOfService", "5");
            dic.Add("VestingPercentage", "100.0");
            pVesting._ServiceTable(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("MenuItem", "Add Actuarial Equivalence");
            pAssumptions._TreeViewRightSelect(dic, "ActuarialEquivalence1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("Level_3", "ActuarialEquivalence1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("txtInterestRate", "7.5");
            dic.Add("Mortality", "PPA2010CMF");
            pActuarialEquivalence._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("MenuItem", "Add Conversion Factors");
            pAssumptions._TreeViewRightSelect(dic, "LAtoJS50");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("Level_3", "LAtoJS50");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "Click");
            dic.Add("PresentValueFactor", "");
            dic.Add("TabularOrConstantFactor", "");
            dic.Add("CustomCode", "");
            pConversionFactors._PopVerify_Main(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType_From", "");
            dic.Add("MortalityInDeferralPeriod_From", "Member only mortality");
            dic.Add("ActuarialEquivalence_From", "ActuarialEquivalence1");
            dic.Add("ApplySpouseAgeDifference_From", "");
            dic.Add("FormOfPaymentType_To", "Joint and survivor");
            dic.Add("MortalityInDeferralPeriod_To", "Joint life mortality");
            dic.Add("ActuarialEquivalence_To", "ActuarialEquivalence1");
            dic.Add("ApplySpouseAgeDifference_To", "");
            dic.Add("btnGuaranteePeriod_From_V", "");
            dic.Add("GuaranteePeriod_From_cbo", "");
            dic.Add("btnGuaranteePeriod_From_C", "Click");
            dic.Add("GuaranteePeriod_From_txt", "");
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
            dic.Add("BenefitCommenceAge_From_txt", "15");
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
            dic.Add("btnBenefitCommenceAge_To_V", "");
            dic.Add("BenefitCommenceAge_To_cbo", "");
            dic.Add("btnBenefitCommenceAge_To_C", "Click");
            dic.Add("BenefitCommenceAge_To_txt", "15");
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
            pAssumptions._TreeViewRightSelect(dic, "InactCVF");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("Level_3", "InactCVF");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("PresentValueFactor", "");
            dic.Add("TabularOrConstantFactor", "True");
            dic.Add("CustomCode", "");
            pConversionFactors._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("T", "");
            dic.Add("C", "Click");
            dic.Add("txtTabularOrConstantFactor_M", "0.8811");
            dic.Add("txtTabularOrConstantFactor_F", "0.9143");
            dic.Add("cboTabularOrConstantFactor", "");
            pConversionFactors._PopVerify_TabularOrConstantFactor(dic);


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "Life");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "Life");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


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




            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "SPLife");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "SPLife");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Spouse's");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "Click");
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
            pAssumptions._TreeViewRightSelect(dic, "ForInactives");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "ForInactives");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
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
            dic.Add("Level_3", "ForInactives");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Joint and survivor");
            dic.Add("MortalityInReferralPeriod", "Joint life mortality");
            dic.Add("btnGuaranteePeriod_V", "Click");
            dic.Add("GuaranteePeriod_cbo", "YearsCertain1");
            dic.Add("btnGuaranteePeriod_C", "");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            dic.Add("btnSurvivorPercentOrAmount_V", "Click");
            dic.Add("SurvivorPercentOrAmount_cbo", "Beneficiary1Percent1");
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
            dic.Add("LocalEligibility", "Click");
            dic.Add("txtLocalEligibility", "JS");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.PaymentForm1=\"J&S\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



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
            dic.Add("btnGuaranteePeriod_C", "Click");
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
            pAssumptions._TreeViewRightSelect(dic, "InactDID");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "InactDID");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Spouse's annuity for death in deferral");
            dic.Add("MortalityInReferralPeriod", "");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "Click");
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
            pAssumptions._TreeViewRightSelect(dic, "JS50");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "JS50");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Joint and survivor");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "Click");
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


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "415 Limits");
            dic.Add("MenuItem", "Add 415 Limits");
            pAssumptions._TreeViewRightSelect(dic, "LifeLimit");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "415 Limits");
            dic.Add("Level_3", "LifeLimit");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DeterminLimitBasedOn", "Specific year");
            dic.Add("DeterminLimitBasedOn_Year", "2008");
            dic.Add("IncreaseAppliesUntil", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("EarlyRetirementFator", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("PlanNormalFormOfPayment", "Life");
            dic.Add("ConversionFactorNormalFromToStraightLife", "");
            dic.Add("btnPlanNormalFromStopAge_V", "");
            dic.Add("PlanNormalFromStopAge_cbo", "");
            dic.Add("btnPlanNormalFromStopAge_C", "");
            dic.Add("PlanNormalFromStopAge_txt", "");
            dic.Add("PlanActuarialEquivalence", "");
            dic.Add("415LimitFormOfPayement", "Life");
            dic.Add("ConversionFactorNormalFromTo415Limit", "");
            dic.Add("btn415LimitFormStopAge_V", "");
            dic.Add("415LimitFormStopAge_cbo", "");
            dic.Add("btn415LimitFormStopAge_C", "");
            dic.Add("415LimitFormStopAge_txt", "");
            dic.Add("ParticipationService", "VestingService");
            dic.Add("MandatoryEmployeeContribution", "");
            dic.Add("ProjectedPayForAlternative", "PayProjection1");
            dic.Add("EmploymentService", "$Service");
            p415Limits._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "415 Limits");
            dic.Add("MenuItem", "Add 415 Limits");
            pAssumptions._TreeViewRightSelect(dic, "SPLimit");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "415 Limits");
            dic.Add("Level_3", "SPLimit");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DeterminLimitBasedOn", "Specific year");
            dic.Add("DeterminLimitBasedOn_Year", "2008");
            dic.Add("IncreaseAppliesUntil", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("EarlyRetirementFator", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("PlanNormalFormOfPayment", "Life");
            dic.Add("ConversionFactorNormalFromToStraightLife", "");
            dic.Add("btnPlanNormalFromStopAge_V", "");
            dic.Add("PlanNormalFromStopAge_cbo", "");
            dic.Add("btnPlanNormalFromStopAge_C", "");
            dic.Add("PlanNormalFromStopAge_txt", "");
            dic.Add("PlanActuarialEquivalence", "ActuarialEquivalence1");
            dic.Add("415LimitFormOfPayement", "SPLife");
            dic.Add("ConversionFactorNormalFromTo415Limit", "LAtoJS50");
            dic.Add("btn415LimitFormStopAge_V", "");
            dic.Add("415LimitFormStopAge_cbo", "");
            dic.Add("btn415LimitFormStopAge_C", "");
            dic.Add("415LimitFormStopAge_txt", "");
            dic.Add("ParticipationService", "VestingService");
            dic.Add("MandatoryEmployeeContribution", "");
            dic.Add("ProjectedPayForAlternative", "PayProjection1");
            dic.Add("EmploymentService", "$Service");
            p415Limits._PopVerify_Standard(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "RetLiab");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "RetLiab");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
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
            dic.Add("FormOfPayment", "Life");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Retirement");
            dic.Add("ExcludePercentMarried", "True");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "RetLiab");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");



            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "RetElig");
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
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "True");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "AccruedBenefit");
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
            dic.Add("ConversionFactor_Married", "LAtoJS50");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "JS50");
            dic.Add("FormOfPayment_Single", "Life");
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
            pAssumptions._TreeViewRightSelect(dic, "WthLiab");


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WthLiab");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "Vesting1");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "Life");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ExcludePercentMarried", "True");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);




            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WthLiab");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");



            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "VestedNotRetire");
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
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "True");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "AccruedBenefit");
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
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "LAtoJS50");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "JS50");
            dic.Add("FormOfPayment_Single", "Life");
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
            pAssumptions._TreeViewRightSelect(dic, "DisLiab");


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "DisLiab");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "True");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "AccruedBenefit");
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
            dic.Add("VestingDefinition", "Vesting1");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "LAtoJS50");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "JS50");
            dic.Add("FormOfPayment_Single", "Life");
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
            pAssumptions._TreeViewRightSelect(dic, "DthLiab");


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "DthLiab");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "Click");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "AccruedBenefit");
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
            dic.Add("VestingDefinition", "Vesting1");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "LAtoJS50");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "SPLife");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "SPLimit");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Death");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            pMain._Home_ToolbarClick_Top(true);





            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "InacLiab");


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "InacLiab");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "Click");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "All inactives");
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
            dic.Add("FormOfPayment", "ForInactives");
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
            pAssumptions._TreeViewRightSelect(dic, "WthDIDLiab");


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WthDIDLiab");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("VestingDefinition", "Vesting1");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "LAtoJS50");
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
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WthDIDLiab");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");


            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "VestedNotRetire");
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
            dic.Add("SingleFormulaBenefit", "AccruedBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "LAtoJS50");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "SpouseDID");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "SPLimit");
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
            pAssumptions._TreeViewRightSelect(dic, "DisDIDLiab");


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "DisDIDLiab");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "AccruedBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("VestingDefinition", "Vesting1");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "LAtoJS50");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "SpouseDID");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "SPLimit");
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
            pAssumptions._TreeViewRightSelect(dic, "InactDIDLiab");


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "InactDIDLiab");
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
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "InactCVF");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "InactDID");
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



            pMain._SelectTab("Conversion 2011");

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
            dic.Add("CostMethod", "Projected Unit Credit No Prorate");
            dic.Add("ServiceForServiceProrate", "");
            dic.Add("CompareToAccrue", "True");
            dic.Add("AllowNegativeNormalCost", "");
            dic.Add("btnStartAge_V", "");
            dic.Add("StartAge_cbo", "");
            dic.Add("btnStartAge_C", "");
            dic.Add("StartAge_txt", "");
            dic.Add("UsePresentValueOfFutureSalary", "");
            dic.Add("UsePresentValueOfFutureService", "");
            dic.Add("ProjectedPayToUseForCoveredPay", "PayProjection1");
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


            pMethods._ResultsForStatisticsForExpected_Grid(1, "AccruedBenefit", true);
            pMethods._ResultsForStatisticsForExpected_Grid(2, "PayAverage1", true);
            pMethods._ResultsForStatisticsForExpected_Grid(3, "VestingService", true);



            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Description", "Accrued Benefit");
            dic.Add("Variable", "AccruedBenefit");
            dic.Add("Age_cbo", "$ValAge");
            dic.Add("Age_txt", "");
            pMethods._AdditionalValuesToOutput_Grid(dic);


            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Description", "Vesting Service");
            dic.Add("Variable", "VestingService");
            dic.Add("Age_cbo", "$ValAge");
            dic.Add("Age_txt", "");
            pMethods._AdditionalValuesToOutput_Grid(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Description", "Projected Benefit");
            dic.Add("Variable", "AccruedBenefit");
            dic.Add("Age_cbo", "$FullRetAge");
            dic.Add("Age_txt", "");
            pMethods._AdditionalValuesToOutput_Grid(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            pMain._SelectTab("Conversion 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/26/1944\"  and $emp.HireDate1=\"6/2/1996\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12/26/1956\"  and $emp.HireDate1=\"7/25/1997\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"6/6/1982\"  and $emp.HireDate1=\"7/9/2004\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"1/7/1987\"  and $emp.HireDate1=\"8/21/2009\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"3/14/1966\"  and $emp.HireDate1=\"11/10/1986\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"6/30/1924\"  and $emp.HireDate1=\"6/20/1980\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12/14/1940\"  and $emp.HireDate1=\"8/22/1999\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"11/11/1932\"  and $emp.HireDate1=\"12/17/1978\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/18/1934\"  and $emp.HireDate1=\"1/15/1984\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"5/15/1963\"  and $emp.HireDate1=\"9/14/2001\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"5/7/1984\"  and $emp.HireDate1=\"2/23/2008\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"4/15/1954\"  and $emp.HireDate1=\"4/30/1977\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"8/2/1974\"  and $emp.HireDate1=\"6/23/2000\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/23/1980\"  and $emp.HireDate1=\"6/1/2008\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);



            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




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
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "BenefitInPayment");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "True");
            dic.Add("FAS35PresentValueOfVestedBenefits", "True");
            dic.Add("PPAAtRiskLiabilityForMinimum", "False");
            dic.Add("PPAAtRiskLiabilityForMaximum", "False");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "False");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "False");
            dic.Add("EntryAgeNormal", "False");
            dic.Add("PayoutProjectionCustomGroup", "HourlyFlag");
            dic.Add("RunValuation", "Click");
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





            pMain._SelectTab("Conversion 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Conversion2011_Baseline, "Liability Summary", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Conversion2011_Baseline, "Conversion Diagnostic", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Test Case List", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Parameter Print", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Payout Projection", "Conversion", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Conversion2011_Baseline, "Liability Summary", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Conversion2011_Baseline, "Conversion Diagnostic", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Test Case List", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Detailed Results by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Payout Projection", "Conversion", false, true);
            }

            thrd_Funding_Converson2011_Baseline.Start();



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Conversion 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion




            #region Assets 2011 & 2012


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AssetData");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("WorkspaceName", "Assets2011");
            pMain._Assets_AddWorkSpace(dic);

            dic.Clear();
            dic.Add("Level_1", "Data Entry");
            dic.Add("Level_2", "General Information");
            pAssets._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TrustPeriodStartDate", "01/01/2011");
            dic.Add("TrustPeriodEndDate", "12/31/2011");
            dic.Add("Restated", "");
            dic.Add("NotRestated", "True");
            dic.Add("Audited", "True");
            dic.Add("Unaudited", "");
            dic.Add("Piror2YearsOfNHCE", "");
            pAssets._PopVerify_GerneralInformation(dic);


            dic.Clear();
            dic.Add("Level_1", "Data Entry");
            dic.Add("Level_2", "Summary of Market Value");
            pAssets._TreeViewSelect(dic);


            //////_gLib._MsgBoxYesNo("Continue Testing?", "Below codes will fail because Asset Category NOT exist in ComboBox, user have to type in!!! Please check with Karen!");


            dic.Clear();
            dic.Add("iAssetCategory", "1");
            dic.Add("sAssetCategory", "Common Corporate Stocks");
            dic.Add("Value", "5,060,171.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_Add(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "2");
            dic.Add("sAssetCategory", "Other Corporate Bonds");
            dic.Add("Value", "1,323,795.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_Add(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "3");
            dic.Add("sAssetCategory", "Other Receivables");
            dic.Add("Value", "408.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_Add(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "4");
            dic.Add("sAssetCategory", "Interest Bearing Cash");
            dic.Add("Value", "64,894.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_Add(dic);


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
            dic.Add("Date", "7/1/2011");
            dic.Add("Category", "Cash");
            dic.Add("Amount", "900,000.00");
            dic.Add("OK", "Click");
            pAssets._RMV_EmployerContributions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "5,928,702.00");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("InvestEarnings_Interest", "27,324.00");
            dic.Add("InvestEarnings_Dividends", "69,648.00");
            dic.Add("InvestEarnings_Unrealized", "-283,181.00");
            dic.Add("Disburse_BenefitPayments", "193,225.00");
            dic.Add("CreateAssetSnapshot", "Click");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pAssets._PopVerify_AssetSnapshotProperties(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AssetData");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("WorkspaceName", "Assets2012");
            pMain._Assets_AddWorkSpace(dic);

            dic.Clear();
            dic.Add("Level_1", "Data Entry");
            dic.Add("Level_2", "General Information");
            pAssets._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TrustPeriodStartDate", "01/01/2012");
            dic.Add("TrustPeriodEndDate", "12/31/2012");
            dic.Add("Restated", "");
            dic.Add("NotRestated", "True");
            dic.Add("Audited", "True");
            dic.Add("Unaudited", "");
            dic.Add("Piror2YearsOfNHCE", "");
            dic.Add("iSelectAssetSnapshot", "1");
            pAssets._PopVerify_GerneralInformation(dic);


            dic.Clear();
            dic.Add("Level_1", "Data Entry");
            dic.Add("Level_2", "Summary of Market Value");
            pAssets._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "1");
            dic.Add("sAssetCategory", "Common Corporate Stocks");
            dic.Add("Value", "6,214,573.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "2");
            dic.Add("sAssetCategory", "Other Corporate Bonds");
            dic.Add("Value", "1,257,894.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "3");
            dic.Add("sAssetCategory", "Other Receivables");
            dic.Add("Value", "501.75");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "4");
            dic.Add("sAssetCategory", "Interest Bearing Cash");
            dic.Add("Value", "72,154.89");
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
            dic.Add("Date", "7/1/2012");
            dic.Add("Category", "Cash");
            dic.Add("Amount", "902,456.00");
            dic.Add("OK", "Click");
            pAssets._RMV_EmployerContributions(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("InvestEarnings_Interest", "");
            dic.Add("InvestEarnings_Dividends", "");
            dic.Add("InvestEarnings_Unrealized", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "Click");
            dic.Add("Disburse_BenefitPayments", "");
            dic.Add("CreateAssetSnapshot", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "7/1/2012");
            dic.Add("Category", "Directly to Participants or Beneficiaries");
            dic.Add("Amount", "195,743.23");
            dic.Add("OK", "Click");
            pAssets._RMV_BenefitPayments(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("InvestEarnings_Interest", "26,475.25");
            dic.Add("InvestEarnings_Dividends", "70,987.12");
            dic.Add("InvestEarnings_Unrealized", "291,680.50");
            dic.Add("Disburse_BenefitPayments", "");
            dic.Add("CreateAssetSnapshot", "Click");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pAssets._PopVerify_AssetSnapshotProperties(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);





            #endregion



            #region Valuation 2012 - Baseline


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
            dic.Add("Name", "Valuation 2012");
            dic.Add("Parent", "Conversion 2011");
            dic.Add("ParentFinalValuationSet", "Baseline");
            dic.Add("PlanYearBeginningIn", "2012");
            dic.Add("FirstYearPlanUnderPPA", "2008");
            dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2012");
            pMain._PopVerify_Home_RightPane(dic);








            pMain._SelectTab("Valuation 2012");

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
            dic.Add("FundingInformation_AddNew", "True");
            dic.Add("FundingInformation_Name", "RollForwardFundingCalculator");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._ValuationNodeProperties_ChangeReasons_Initialize();


            dic.Clear();
            dic.Add("LiabilityType", "PPA");
            dic.Add("ReasonforChange", "Baseline");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "PBGC");
            dic.Add("ReasonforChange", "Baseline");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "FAS 35");
            dic.Add("ReasonforChange", "Baseline");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "EAN");
            dic.Add("ReasonforChange", "Baseline");
            dic.Add("OK", "Click");
            pMain._ValuationNodeProperties_ChangeReasons(dic);


            pMain._SelectTab("Valuation 2012");

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
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Valuation Data");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "True");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "Click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);





            pParticipantDataSet._Initialzie();

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "ParticipantStatus");
            pParticipantDataSet._Navigate(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "ParticipantStatus");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "PayStatus");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);



            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "HealthStatus");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "AliveStatus");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "ExitDate");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);



            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "TerminationDate1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "DeathDate");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "MaritalStatus");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            pParticipantDataSet._ExpandOrCollapseFirstLevel("Personal Information");

            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "MembershipDate1");
            pParticipantDataSet._Navigate(dic, true);


            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "MembershipDate1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "ContribRate1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "ContribsWInterest1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "ContribsWOInterest1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "BenefitInPayment");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "True");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "TestFlag");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "True");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            pParticipantDataSet._ExpandOrCollapseFirstLevel("DB Information");




            dic.Clear();
            dic.Add("Level_1", "DC Information");
            dic.Add("Level_2", "EeAccountBalance1");
            pParticipantDataSet._Navigate(dic, true);


            dic.Clear();
            dic.Add("Level_1", "DC Information");
            dic.Add("Level_2", "EeAccountBalance1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "DC Information");
            dic.Add("Level_2", "EeContribRate1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "DC Information");
            dic.Add("Level_2", "ErAccountBalance1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "DC Information");
            dic.Add("Level_2", "ErContribRate1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            pParticipantDataSet._ExpandOrCollapseFirstLevel("DC Information");


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BenService");
            pParticipantDataSet._Navigate(dic, true, false, true, false);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BenService");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "True");
            dic.Add("sComparisonType", "Absolute");
            dic.Add("bALL", "");
            dic.Add("bACT", "True");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "True");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BenServiceInc");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "False");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "");
            dic.Add("bACT", "True");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "VestService");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "True");
            dic.Add("sComparisonType", "Absolute");
            dic.Add("bALL", "");
            dic.Add("bACT", "True");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            pParticipantDataSet._ExpandOrCollapseFirstLevel("Personal Information");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("CompareData", "");
            dic.Add("ImportDataandApplyMapping", "Click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._SelectTab("Participant DataSet");


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/26/1944\"  and $emp.HireDate1=\"6/2/1996\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12/26/1956\"  and $emp.HireDate1=\"7/25/1997\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"6/6/1982\"  and $emp.HireDate1=\"7/9/2004\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"1/7/1987\"  and $emp.HireDate1=\"8/21/2009\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"3/14/1966\"  and $emp.HireDate1=\"11/10/1986\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"6/30/1924\"  and $emp.HireDate1=\"6/20/1980\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12/14/1940\"  and $emp.HireDate1=\"8/22/1999\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"11/11/1932\"  and $emp.HireDate1=\"12/17/1978\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/18/1934\"  and $emp.HireDate1=\"1/15/1984\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"5/15/1963\"  and $emp.HireDate1=\"9/14/2001\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"5/7/1984\"  and $emp.HireDate1=\"2/23/2008\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"4/15/1954\"  and $emp.HireDate1=\"4/30/1977\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"8/2/1974\"  and $emp.HireDate1=\"6/23/2000\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/23/1980\"  and $emp.HireDate1=\"6/1/2008\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);



            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            dic.Clear();
            dic.Add("MenuItem_1", "Asset Snapshots");
            pMain._MenuSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pParticipantDataSet._PopVerify_AssetSnapshot(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Funding Information");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Contributions");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Category", "");
            dic.Add("PlanYear", "2010");
            dic.Add("TaxYear", "2010");
            dic.Add("MinimumRequiredContribution", "Yes");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "");
            pFundingInformation._Contributions_Employer(dic);

            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Actuarial Value of Assets");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "General Parameters");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanYearBeginDate", "01/01/2012");
            dic.Add("PlanYearEndDate", "12/31/2012");
            dic.Add("CurrentYareNumOfParcipants", "131");
            dic.Add("YearsForShortfallAmortization", "");
            pFundingInformation._PopVerify_GI_GeneralInformation(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VoluntaryCOB", "0");
            dic.Add("ApplyCalculated_Yes", "True");
            dic.Add("ApplyCalculated_No", "");
            dic.Add("ClientDecision_Yes", "");
            dic.Add("ClientDecision_No", "True");
            dic.Add("ClientDecision_Unknown", "");
            dic.Add("PBGCAgreement_Yes", "");
            dic.Add("PBGCAgreement_No", "True");
            dic.Add("PBGCAgreement_Unknown", "");
            pFundingInformation._PopVerify_GI_CarryoverBalance(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VoluntaryCOB", "0");
            dic.Add("ApplyCalculated_Yes", "True");
            dic.Add("ApplyCalculated_No", "");
            dic.Add("ClientDecision_Yes", "");
            dic.Add("ClientDecision_No", "True");
            dic.Add("ClientDecision_Unknown", "");
            dic.Add("PBGCAgreement_Yes", "");
            dic.Add("PBGCAgreement_No", "True");
            dic.Add("PBGCAgreement_Unknown", "");
            pFundingInformation._PopVerify_GI_PrefundingBalance(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanSponsor_Yes", "");
            dic.Add("PlanSponsor_No", "True");
            dic.Add("PlanSponsor_Unknown", "");
            dic.Add("IncreaseDueToPlanAmendment", "0");
            dic.Add("ExemptFrom_Yes", "");
            dic.Add("ExemptFrom_No", "True");
            dic.Add("ExemptFrom_Unknown", "");
            dic.Add("IncreaseDueToShutdown", "0");
            dic.Add("OriginalPlanEffectiveDate", "01/01/1978");
            dic.Add("PlanWasFrozen_Yes", "");
            dic.Add("PlanWasFrozen_No", "True");
            dic.Add("PlanWasFrozen_Unknown", "");
            pFundingInformation._PopVerify_GI_BenefitRestriction(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CompanyName", "");
            dic.Add("Telephone", "212-555-1234");
            dic.Add("AddressLine1", "123 Main Street");
            dic.Add("AddressLine2", "Deerfield, IL 60015");
            dic.Add("AddressLine3", "");
            dic.Add("Signer1Name", "Singer One");
            dic.Add("Signer1Credential", "Super Singer");
            dic.Add("Signer2Name", "Singer Two");
            dic.Add("Signer2Credential", "Special Singer");
            dic.Add("PeerReviewName", "Peer Reviewer");
            dic.Add("PeerReviewCredentials", "Super Reviewer");
            pFundingInformation._PopVerify_GI_ActuarialReport(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Prior Year Results");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SummaryView", "");
            dic.Add("DetailView", "True");
            dic.Add("TabName", "Preliminary Results and PBGC Premiums");
            pFundingInformation._PopVerify_PriorYearResults_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OriginalPlanEffectDate", "01/01/1978");
            dic.Add("BeginningOfPlanYear", "01/01/2011");
            dic.Add("EndOfPlanYear", "12/31/2011");
            dic.Add("ValuationDate", "01/01/2011");
            dic.Add("ValuationYear", "2012");
            dic.Add("PlanTotallyFrozen", "");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_PlanDates(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InactivesInPayStatus", "10");
            dic.Add("InactivesDeferredStatus", "62");
            dic.Add("VestedStatus", "35");
            dic.Add("NonVestedStatus", "18");
            dic.Add("Total", "125");
            dic.Add("TotalPlanParticipants", "125");
            dic.Add("NumOfParticipants", "125");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_Data(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PirorYearNum", "130");
            dic.Add("Prong1Determination", "75.16");
            dic.Add("Prong1Threshold", "65.00");
            dic.Add("Prong2Determination", "75.16");
            dic.Add("Prong2Threshold", "70.00");
            dic.Add("PlanIsAtRisk", "");
            dic.Add("IncludesExpenseLoad", "");
            dic.Add("ConsecutiveYears", "");
            dic.Add("FTReflects", "");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_AtRiskDetermination(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InPayStatus", "1,968,365");
            dic.Add("DeferredStatus", "2,831,941");
            dic.Add("VestedActives", "2,789,008");
            dic.Add("NonVestedActives", "16,512");
            dic.Add("Total", "7,605,826");
            dic.Add("NormalCost", "353,826");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_FTD_NotAtRisk(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InPayStatus", "");
            dic.Add("DeferredStatus", "");
            dic.Add("VestedActives", "");
            dic.Add("NonVestedActives", "");
            dic.Add("Total", "");
            dic.Add("NormalCost", "353,826");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_FTD_Final(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InPayStatus", "1,968,365");
            dic.Add("DeferredStatus", "2,831,941");
            dic.Add("VestedActives", "2,789,008");
            dic.Add("NonVestedActives", "16,512");
            dic.Add("Total", "7,605,826");
            dic.Add("Discounted", "");
            dic.Add("Expected", "");
            dic.Add("DiscountedExpected", "");
            dic.Add("NormalCost", "353,826");
            dic.Add("TotalNormalCost", "");
            dic.Add("EffectiveInterestRate", "6.44");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_FTD_FundingTarget(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NotAtRiskLiability", "9,516,552");
            dic.Add("ExpenseLoad", "");
            dic.Add("AtRiskLiabilityNoExpense", "");
            dic.Add("AtRiskLiabilityWithExpense", "");
            dic.Add("FinalAtRisk", "");
            dic.Add("FundingTarget", "9,516,552");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_MDC(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PBGCFlatRate_ParticipantCount", "125");
            dic.Add("PBGCFlatRate_PerParticipant", "33");
            dic.Add("PBGCFlatRate_FlatRatePremium", "4,125");
            dic.Add("NotAtRisk_InPayStatus", "2,193,447");
            dic.Add("NotAtRisk_DeferredStatus", "3,418,800");
            dic.Add("NotAtRisk_VestedActives", "3,381,352");
            dic.Add("NotAtRisk_Total", "8,993,599");
            dic.Add("ExpenseLoad_InPayStatus", "");
            dic.Add("ExpenseLoad_DeferredStatus", "");
            dic.Add("ExpenseLoad_VestedActives", "");
            dic.Add("ExpenseLoad_Total", "");
            dic.Add("AtRiskNoExpense_InPayStatus", "");
            dic.Add("AtRiskNoExpense_DeferredStatus", "");
            dic.Add("AtRiskNoExpense_VestedActives", "");
            dic.Add("AtRiskNoExpense_Total", "");
            dic.Add("AtRiskWithExpense_InPayStatus", "");
            dic.Add("AtRiskWithExpense_DeferredStatus", "");
            dic.Add("AtRiskWithExpense_VestedActives", "");
            dic.Add("AtRiskWithExpense_Total", "");
            dic.Add("FinalAtRisk_InPayStatus", "");
            dic.Add("FinalAtRisk_DeferredStatus", "");
            dic.Add("FinalAtRisk_VestedActives", "");
            dic.Add("FinalAtRisk_Total", "");
            dic.Add("PBGCTarget_InpayStatus", "2,193,447");
            dic.Add("PBGCTarget_DeferredStatus", "3,418,800");
            dic.Add("PBGCTarget_VestedActives", "3,381,352");
            dic.Add("PBGCTarget_Total", "8,993,599");
            dic.Add("PBGCTarget_MVofAssets", "6,449,268");
            dic.Add("PBGCVariable_Unfunded", "1,811,000");
            dic.Add("PBGCVariable_9Per1000", "16,299");
            dic.Add("PBGCVariable_NumOfEE", "125");
            dic.Add("PBGCVariable_ParticipantCount", "125");
            dic.Add("PBGCVariable_PerParticipant", "");
            dic.Add("PBGCVariable_PBGCVariable", "16,299");
            dic.Add("PBGCVariable_CombinedPBGC", "20,424");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_PGBCPremiums(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BalanceAtBegining", "");
            dic.Add("PortionUsed", "");
            dic.Add("InterestUsing", "");
            dic.Add("BalanceAtBOY", "");
            dic.Add("VoluntaryReduction", "100,000");
            dic.Add("DeemedWaivers", "60,279");
            dic.Add("BOYBalance", "");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_CarryoverBalance(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Liability_Actuarial", "7,684,952");
            dic.Add("Liability_NormalCost", "");
            dic.Add("Liability_Interest", "");
            dic.Add("Benefits_BenefitPayments", "");
            dic.Add("Benefits_Administrative", "");
            dic.Add("Benefits_EmployeeContrib", "");
            dic.Add("Benefits_Total", "");
            dic.Add("Benefits_ExpectedActuarial", "");
            dic.Add("Benefits_LiabilityGL", "");
            dic.Add("Asset_ActuarialAsset", "5,771,417");
            dic.Add("Asset_InterestOnActuarial", "333,572");
            dic.Add("Asset_ContributionsMade", "");
            dic.Add("Asset_InterestOnContrib", "");
            dic.Add("Asset_ExpectedActuarial", "");
            dic.Add("Asset_ActuarialAssetGL", "");
            dic.Add("Asset_ActuarialGL", "");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_DevelopmentOfExperienceGL(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SummaryView", "");
            dic.Add("DetailView", "");
            dic.Add("TabName", "FTAPs, Benefit Restrictions, and At-Risk Determination");
            pFundingInformation._PopVerify_PriorYearResults_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVOfAssets", "6,449,268");
            dic.Add("90ofMarketValue", "");
            dic.Add("110ofMarketValue", "");
            dic.Add("PreliminaryActuarial", "");
            dic.Add("ActuarialValue", "6,449,268");
            dic.Add("AVAPFB", "6,449,268");
            dic.Add("AVACOBPFB", "6,449,268");
            dic.Add("Prior2YearsNHC", "");
            dic.Add("AVANHCPurchase", "6,449,268");
            dic.Add("AVACOBPFBNHCPurchase", "6,449,268");
            dic.Add("NARFundLiabNHCPurchase", "7,855,033");
            pFundingInformation_FTAPs._PopVerify_AssetNumbers(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FTAP", "80.51");
            dic.Add("FTAP_PFB", "82.10");
            dic.Add("FTAP_Exempt", "82.10");
            dic.Add("FTAP_AtRisk", "80.51");
            dic.Add("FTAP_SB_PFB", "82.10");
            dic.Add("FTAP_SB_NoPFB", "82.10");
            pFundingInformation_FTAPs._PopVerify_FTAPs(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ElectionToUse", "");
            dic.Add("ShortfallFunded", "");
            dic.Add("EligibleForTransition", "");
            dic.Add("ExemptFrom2007AFC", "Yes");
            dic.Add("2008", "82.10");
            dic.Add("2009", "");
            dic.Add("2010", "");
            dic.Add("IsPlanExempt", "");
            pFundingInformation_FTAPs._PopVerify_ShortfallBaseExemption(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CurrentYearTop25", "");
            dic.Add("CurrentYear401", "");
            dic.Add("CanUseCOB", "82.10");
            dic.Add("QuarterlyContrib", "82.10");
            dic.Add("PBGC4010", "80.51");
            pFundingInformation_FTAPs._PopVerify_OtherFTAPChecks(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Prong1", "70.00");
            dic.Add("Prong2", "70.00");
            dic.Add("PlanIsAtRiskNextYear", "");
            dic.Add("PlanAtRiskPriorYear1", "");
            dic.Add("PlanAtRiskPriorYear2", "");
            dic.Add("NumOfYears", "");
            dic.Add("ExpenseLoad", "");
            dic.Add("NextYearConsecutive", "");
            dic.Add("FTNextYear", "");
            pFundingInformation_FTAPs._PopVerify_AtRiskDeterminatinForFollowingYear(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AFTAPBefore", "79.23");
            dic.Add("IncreaseTo60", "");
            dic.Add("IncreaseTo80", "60,279");
            dic.Add("RequiredCredit", "60,279");
            dic.Add("FinalAFTAP_TotalWaiver", "");
            dic.Add("FinalAFTAP_FinalAFTAP", "82.10");
            pFundingInformation_FTAPs._PopVerify_PreliminaryAFTAPCalcuations(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CurrentYear_TreatPlan", "");
            dic.Add("CurrentYear_In3Months", "75.14");
            dic.Add("CurrentYear_In6Months", "65.14");
            dic.Add("CurrentYear_After9Months", "");
            dic.Add("NextYear_In3Months", "82.10");
            dic.Add("NextYear_In6Months", "72.10");
            dic.Add("NextYear_After9Months", "");
            pFundingInformation_FTAPs._PopVerify_PresumedCurrentNextYear(dic);


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SummaryView", "");
            dic.Add("DetailView", "");
            dic.Add("TabName", "Shortfall");
            pFundingInformation._PopVerify_PriorYearResults_Main(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("COBAfter", "-125,545");
            dic.Add("PFBAfter", "");
            dic.Add("NetAssets", "6,323,723");
            dic.Add("FundingShortfall", "1,531,280");
            dic.Add("TransitionPercent", "");
            dic.Add("TransitionFundingTarget", "");
            dic.Add("TransitionFundingShortfall", "");
            pFundingInformation_Shortfall._PopVerify_NetAssets(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NewBaseAmount", "777,335");
            dic.Add("YearsForShortfall", "");
            dic.Add("AmortizationFactor", "5.98032");
            dic.Add("ShortfallAmortizationInstallment", "129,982");
            dic.Add("TotalSAI", "");
            dic.Add("ShortfallAmortizationCharge", "150,975");
            pFundingInformation_Shortfall._PopVerify_PVOfPriorYearsFundingWaiverBases(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CY", "2.06");
            dic.Add("CY1", "2.06");
            dic.Add("CY2", "2.06");
            dic.Add("CY3", "2.06");
            dic.Add("CY4", "2.06");
            dic.Add("CY5", "5.25");
            dic.Add("CY6", "5.25");
            dic.Add("CY7", "5.25");
            dic.Add("CY8", "5.25");
            dic.Add("CY9", "5.25");
            pFundingInformation_Shortfall._PopVerify_InterestRatesByYear(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CY", "0.97982");
            dic.Add("CY1", "0.96004");
            dic.Add("CY2", "0.94066");
            dic.Add("CY3", "0.92167");
            dic.Add("CY4", "0.90307");
            dic.Add("CY5", "0.77426");
            dic.Add("CY6", "0.73564");
            dic.Add("CY7", "0.69895");
            dic.Add("CY8", "0.66408");
            dic.Add("CY9", "0.63095");
            pFundingInformation_Shortfall._PopVerify_DiscountFactors(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Year1", "0.00000");
            dic.Add("Year2", "1.94959");
            dic.Add("Year3", "2.85128");
            dic.Add("Year4", "3.70751");
            dic.Add("Year5", "4.52075");
            dic.Add("Year6", "5.27136");
            dic.Add("Year7", "5.98032");
            dic.Add("Year8", "0.00000");
            dic.Add("Year9", "0.00000");
            dic.Add("Year10", "0.00000");
            pFundingInformation_Shortfall._PopVerify_AmortizationFactors(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SummaryView", "");
            dic.Add("DetailView", "");
            dic.Add("TabName", "Contribution Summary");
            pFundingInformation._PopVerify_PriorYearResults_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TargetNormalCost", "502,063");
            dic.Add("FullFundingLimit", "1,903,361");
            dic.Add("MininumBefore", "523,056");
            dic.Add("PriorYearFunded", "");
            dic.Add("COBUsed", "");
            dic.Add("PFBUsed", "");
            dic.Add("MinimumAfter", "523,056");
            dic.Add("MinimumAtEOY", "533,291");
            dic.Add("MinimumAtLast", "556,437");
            pFundingInformation_ContributionSummary._PopVerify_MinimumRequiredContribution(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Cushion_50ofFunding", "3,927,502");
            dic.Add("Cushion_FTIncrease", "1,661,549");
            dic.Add("Cushion_DeductionLimit", "7,366,867");
            dic.Add("Alternate_DeductionLimit", "");
            dic.Add("Alternate_MaximumDeductible", "7,366,867");
            dic.Add("Interest_EarlierOf", "");
            dic.Add("Interest_Fractional", "");
            dic.Add("Interest_InterestTo", "");
            dic.Add("Interest_MaximumDeductible", "");
            pFundingInformation_ContributionSummary._PopVerify_MaximumDeductibleContribution(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FundingShortfall", "");
            dic.Add("AmountPriorMRC", "698,429");
            dic.Add("AmountCurrentMRC", "451,857");
            dic.Add("QuaterlyAmount", "");
            dic.Add("ShortfallCurrentYear", "Yes");
            dic.Add("QuaterlyAmountNextYear", "125,516");
            dic.Add("ContribtionDates_FinalPayment", "09/15/2012");
            pFundingInformation_ContributionSummary._PopVerify_QuaterlyContributionRequirement(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

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
            dic.Add("GL_PPANAR_Min", "True");
            dic.Add("GL_PPANAR_Max", "True");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "BenefitInPayment");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "True");
            dic.Add("FAS35PresentValueOfVestedBenefits", "True");
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "HourlyFlag");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_Baseline, "Individual Checking Template", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Age Service Matrix", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Data Matching Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Combined Status Code Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Gain / Loss Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Decrement Age", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_Baseline, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_Baseline, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_Baseline, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_Baseline, "Payout Projection", "RollForward", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_Baseline, "Individual Checking Template", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Age Service Matrix", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_Baseline, "Data Comparison", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Data Matching Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Combined Status Code Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Decrement Age", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_Baseline, "Liability Comparison", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_Baseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_Baseline, "Payout Projection", "RollForward", false, true);
            }


            thrd_Funding_Valuation2012_Baseline.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            #endregion



            #region Valuation 2012 - Update Assumption Dates

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Update Assumption Dates");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "Update Assumption Dates Assumptions");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "True");
            dic.Add("Provisions_Name", "Update Assumption Dates Provisions");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._ValuationNodeProperties_ChangeReasons_Initialize();


            dic.Clear();
            dic.Add("LiabilityType", "PPA");
            dic.Add("ReasonforChange", "Other assumption changes");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "PBGC");
            dic.Add("ReasonforChange", "Other assumption changes");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "FAS 35");
            dic.Add("ReasonforChange", "Change in actuarial assumptions");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "EAN");
            dic.Add("ReasonforChange", "Other assumption changes");
            dic.Add("OK", "Click");
            pMain._ValuationNodeProperties_ChangeReasons(dic);



            pMain._SelectTab("Valuation 2012");

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
            dic.Add("Level_3", "PBGCInt");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "09/01/2011");
            pInterestRate._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AllOthers");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "09/01/2011");
            pInterestRate._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "_Death");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2012");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);



            ////////////////_gLib._MsgBox("warining!", "Please manually check if As Of Date is <01/01/2012>!");

            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab("Valuation 2012");

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
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("Level_3", "ActuarialEquivalence1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("txtInterestRate", "");
            dic.Add("Mortality", "PPA2011CMF");
            pActuarialEquivalence._PopVerify_SameStructureForAllPeriods(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

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
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "BenefitInPayment");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "True");
            dic.Add("FAS35PresentValueOfVestedBenefits", "True");
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "HourlyFlag");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2012");

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
            pMain._PopVerify_FundingCalculationRunCompleted(dic);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "ASC 960 Reconciliation");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Yes", "");
            dic.Add("No", "");
            dic.Add("Message", "ASC 960 reconciliation run completed.");
            dic.Add("OK", "");
            pMain._PopVerify_Home_Confrim(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "");
            dic.Add("No", "");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_Home_Confrim(dic);


            pMain._SelectTab("Valuation 2012");

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
            dic.Add("Setup", "Click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "Click");
            dic.Add("AddAll", "Click");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "HourlyFlag");
            dic.Add("OK", "Click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Funding Calculator Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Reconciliation to Baseline with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Liabilities Detailed Results with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "ASC 960 Reconciliation", "RollForward", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Funding Calculator Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_UpdateAssumptionDates, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Reconciliation to Baseline with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Liabilities Detailed Results with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Funding Calculator", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "ASC 960 Reconciliation", "RollForward", false, true);
            }


            pMain._SelectTab("Valuation 2012");

            pMain._GenerateNewReport(sOutputFunding_Valuation2012_UpdateAssumptionDates, "PPA Funding Valuation Report", 3);
            pMain._GenerateNewReport(sOutputFunding_Valuation2012_UpdateAssumptionDates, "ASC 960 Letter", 3);


            thrd_Funding_Valuation2012_UpdateAssumptionDates.Start();


            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Valuation 2012");

            #endregion


            #region Valuation 2012 - For AFN 2012

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "For AFN 2012");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "For AFN 2012 Assumptions");
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


            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AllOthers");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2012");
            pInterestRate._PopVerify_PrescribedRates(dic);



            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
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
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "BenefitInPayment");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "True");
            dic.Add("FAS35PresentValueOfVestedBenefits", "True");
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_ForAFN2012, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFN2012, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFN2012, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFN2012, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFN2012, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_ForAFN2012, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_ForAFN2012, "Liabilities Detailed Results", "RollForward", true, true);

            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_ForAFN2012, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFN2012, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFN2012, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFN2012, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_ForAFN2012, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_ForAFN2012, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_ForAFN2012, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_ForAFN2012, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            }


            thrd_Funding_Valuation2012_ForAFN2012.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            #endregion


            #region Valuation 2012 - For AFTAP Range

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "For AFTAP Range");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "For AFTAP Range Assumptions");
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


            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AllOthers");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2013");
            pInterestRate._PopVerify_PrescribedRates(dic);



            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "True");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "BenefitInPayment");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "False");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "False");
            dic.Add("FAS35PresentValueOfVestedBenefits", "False");
            dic.Add("PPAAtRiskLiabilityForMinimum", "True");
            dic.Add("PPAAtRiskLiabilityForMaximum", "True");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "False");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "False");
            dic.Add("EntryAgeNormal", "False");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");



            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_ForAFTAPRange, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFTAPRange, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFTAPRange, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFTAPRange, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFTAPRange, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_ForAFTAPRange, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_ForAFTAPRange, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_ForAFTAPRange, "Liability Scenario", "RollForward", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_ForAFTAPRange, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFTAPRange, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFTAPRange, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFTAPRange, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_ForAFTAPRange, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_ForAFTAPRange, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_ForAFTAPRange, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_ForAFTAPRange, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_ForAFTAPRange, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_ForAFTAPRange, "Liability Scenario by Plan Def", "RollForward", false, true);
            }


            thrd_Funding_Valuation2012_ForAFTAPRange.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion



            #region Valuation 2013 - Baseline


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
            dic.Add("Name", "Valuation 2013");
            dic.Add("Parent", "Valuation 2012");
            dic.Add("ParentFinalValuationSet", "Update Assumption Dates");
            dic.Add("PlanYearBeginningIn", "2013");
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
            dic.Add("ServiceToOpen", "Valuation 2013");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Valuation 2013");

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
            dic.Add("FundingInformation_AddNew", "True");
            dic.Add("FundingInformation_Name", "RollForwardFundingCalculator");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._ValuationNodeProperties_ChangeReasons_Initialize();


            dic.Clear();
            dic.Add("LiabilityType", "PPA");
            dic.Add("ReasonforChange", "Baseline");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "PBGC");
            dic.Add("ReasonforChange", "Baseline");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "FAS 35");
            dic.Add("ReasonforChange", "Baseline");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "EAN");
            dic.Add("ReasonforChange", "Baseline");
            dic.Add("OK", "Click");
            pMain._ValuationNodeProperties_ChangeReasons(dic);


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
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Valuation Data");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "True");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "Click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);



            //////////pParticipantDataSet._Initialzie();


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





            pMain._SelectTab("Valuation 2013");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/26/1944\"  and $emp.HireDate1=\"6/2/1996\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12/26/1956\"  and $emp.HireDate1=\"7/25/1997\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"6/6/1982\"  and $emp.HireDate1=\"7/9/2004\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"1/7/1987\"  and $emp.HireDate1=\"8/21/2009\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"3/14/1966\"  and $emp.HireDate1=\"11/10/1986\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"6/30/1924\"  and $emp.HireDate1=\"6/20/1980\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12/14/1940\"  and $emp.HireDate1=\"8/22/1999\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"11/11/1932\"  and $emp.HireDate1=\"12/17/1978\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/18/1934\"  and $emp.HireDate1=\"1/15/1984\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"5/15/1963\"  and $emp.HireDate1=\"9/14/2001\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"5/7/1984\"  and $emp.HireDate1=\"2/23/2008\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"4/15/1954\"  and $emp.HireDate1=\"4/30/1977\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"8/2/1974\"  and $emp.HireDate1=\"6/23/2000\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/23/1980\"  and $emp.HireDate1=\"6/1/2008\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);



            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2013");

            dic.Clear();
            dic.Add("MenuItem_1", "Asset Snapshots");
            pMain._MenuSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pParticipantDataSet._PopVerify_AssetSnapshot(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Funding Information");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Contributions");
            pFundingInformation._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Category", "");
            dic.Add("PlanYear", "2012");
            dic.Add("TaxYear", "2012");
            dic.Add("Year2013", "True");
            dic.Add("MinimumRequiredContribution", "Yes");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "");
            pFundingInformation._Contributions_Employer(dic);


            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Actuarial Value of Assets");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "General Parameters");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanYearBeginDate", "01/01/2013");
            dic.Add("PlanYearEndDate", "12/31/2013");
            dic.Add("CurrentYareNumOfParcipants", "130");
            dic.Add("YearsForShortfallAmortization", "");
            pFundingInformation._PopVerify_GI_GeneralInformation(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VoluntaryCOB", "0");
            dic.Add("ApplyCalculated_Yes", "");
            dic.Add("ApplyCalculated_No", "True");
            dic.Add("ClientDecision_Yes", "True");
            dic.Add("ClientDecision_No", "");
            dic.Add("ClientDecision_Unknown", "");
            dic.Add("PBGCAgreement_Yes", "True");
            dic.Add("PBGCAgreement_No", "");
            dic.Add("PBGCAgreement_Unknown", "");
            pFundingInformation._PopVerify_GI_CarryoverBalance(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VoluntaryCOB", "0");
            dic.Add("ApplyCalculated_Yes", "");
            dic.Add("ApplyCalculated_No", "True");
            dic.Add("ClientDecision_Yes", "");
            dic.Add("ClientDecision_No", "True");
            dic.Add("ClientDecision_Unknown", "");
            dic.Add("PBGCAgreement_Yes", "");
            dic.Add("PBGCAgreement_No", "True");
            dic.Add("PBGCAgreement_Unknown", "");
            pFundingInformation._PopVerify_GI_PrefundingBalance(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanSponsor_Yes", "");
            dic.Add("PlanSponsor_No", "True");
            dic.Add("PlanSponsor_Unknown", "");
            dic.Add("IncreaseDueToPlanAmendment", "0");
            dic.Add("ExemptFrom_Yes", "");
            dic.Add("ExemptFrom_No", "True");
            dic.Add("ExemptFrom_Unknown", "");
            dic.Add("IncreaseDueToShutdown", "0");
            dic.Add("OriginalPlanEffectiveDate", "");
            dic.Add("PlanWasFrozen_Yes", "");
            dic.Add("PlanWasFrozen_No", "True");
            dic.Add("PlanWasFrozen_Unknown", "");
            pFundingInformation._PopVerify_GI_BenefitRestriction(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            pMain._SelectTab("Valuation 2013");

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
            dic.Add("GL_PPANAR_Min", "True");
            dic.Add("GL_PPANAR_Max", "True");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "BenefitInPayment");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "True");
            dic.Add("FAS35PresentValueOfVestedBenefits", "True");
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "HourlyFlag");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2013");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_Baseline, "Individual Checking Template", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Age Service Matrix", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Data Matching Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Gain / Loss Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Decrement Age", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_Baseline, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_Baseline, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_Baseline, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_Baseline, "Payout Projection", "RollForward", true, true);
            }



            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_Baseline, "Individual Checking Template", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Age Service Matrix", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_Baseline, "Data Comparison", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Data Matching Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Decrement Age", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_Baseline, "Liability Comparison", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_Baseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_Baseline, "Payout Projection", "RollForward", false, true);
            }

            thrd_Funding_Valuation2013_Baseline.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            #region Valuation 2013 - Update Interest and Mortality

            pMain._SelectTab("Valuation 2013");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Update Interest and Mortality");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
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
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);



            pMain._ValuationNodeProperties_ChangeReasons_Initialize();


            dic.Clear();
            dic.Add("LiabilityType", "PPA");
            dic.Add("ReasonforChange", "Other assumption changes");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "PBGC");
            dic.Add("ReasonforChange", "Other assumption changes");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "FAS 35");
            dic.Add("ReasonforChange", "Change in actuarial assumptions");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "EAN");
            dic.Add("ReasonforChange", "Other assumption changes");
            dic.Add("OK", "Click");
            pMain._ValuationNodeProperties_ChangeReasons(dic);



            pMain._SelectTab("Valuation 2013");



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
            dic.Add("Level_3", "AllOthers");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2013");
            pInterestRate._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "_Death");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2013");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2013");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2013");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);




            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            pMain._SelectTab("Valuation 2013");

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
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "BenefitInPayment");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "True");
            dic.Add("FAS35PresentValueOfVestedBenefits", "True");
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "HourlyFlag");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);



            pMain._SelectTab("Valuation 2013");

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
            pMain._PopVerify_FundingCalculationRunCompleted(dic);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "ASC 960 Reconciliation");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Yes", "");
            dic.Add("No", "");
            dic.Add("Message", "ASC 960 reconciliation run completed.");
            dic.Add("OK", "");
            pMain._PopVerify_Home_Confrim(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "");
            dic.Add("No", "");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_Home_Confrim(dic);


            pMain._SelectTab("Valuation 2013");



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
            dic.Add("Setup", "Click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "Click");
            dic.Add("AddAll", "Click");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "HourlyFlag");
            dic.Add("OK", "Click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);




            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Funding Calculator Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Reconciliation to Baseline with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Liabilities Detailed Results with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "ASC 960 Reconciliation", "RollForward", true, true);
            }



            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Funding Calculator Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Reconciliation to Baseline with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Liabilities Detailed Results with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Funding Calculator", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "ASC 960 Reconciliation", "RollForward", false, true);

            }

            pMain._SelectTab("Valuation 2013");

            pMain._GenerateNewReport(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "PPA Funding Valuation Report", 3);
            pMain._GenerateNewReport(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "ASC 960 Letter", 3);


            thrd_Funding_Valuation2013_UpdateInterestAndMortality.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);





            #endregion


            #region Valuation 2013 - For AFN 2012



            pMain._SelectTab("Valuation 2013");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "For AFN 2012");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "For AFN 2012 Assumptions");
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

            pMain._SelectTab("Valuation 2013");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AllOthers");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2012");
            pInterestRate._PopVerify_PrescribedRates(dic);



            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2013");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
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
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "BenefitInPayment");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "False");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "False");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "False");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "False");
            dic.Add("FAS35PresentValueOfVestedBenefits", "False");
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2013");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_ForAFN2012, "Liability Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_ForAFN2012, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_ForAFN2012, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_ForAFN2012, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_ForAFN2012, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_ForAFN2012, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_ForAFN2012, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_ForAFN2012, "Liabilities Detailed Results", "RollForward", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_ForAFN2012, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_ForAFN2012, "Liability Scenario by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_ForAFN2012, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_ForAFN2012, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_ForAFN2012, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_ForAFN2012, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_ForAFN2012, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_ForAFN2012, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_ForAFN2012, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_ForAFN2012, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            }

            thrd_Funding_Valuation2013_ForAFN2012.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2013");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Funding Valuation - For AFTAP Range Test

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
            dic.Add("Name", "For AFTAP Range Test");
            dic.Add("Parent", "Valuation 2012");
            dic.Add("ParentFinalValuationSet", "Update Assumption Dates");
            dic.Add("PlanYearBeginningIn", "2013");
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
            dic.Add("ServiceToOpen", "For AFTAP Range Test");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("For AFTAP Range Test");


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
            dic.Add("FundingInformation_AddNew", "True");
            dic.Add("FundingInformation_Name", "RollForwardFundingCalculator");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            pMain._SelectTab("For AFTAP Range Test");


            dic.Clear();
            dic.Add("MenuItem_1", "Asset Snapshots");
            pMain._MenuSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pParticipantDataSet._PopVerify_AssetSnapshot(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Funding Information");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "General Parameters");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanYearBeginDate", "01/01/2013");
            dic.Add("PlanYearEndDate", "12/31/2013");
            dic.Add("CurrentYareNumOfParcipants", "135");
            dic.Add("YearsForShortfallAmortization", "");
            pFundingInformation._PopVerify_GI_GeneralInformation(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VoluntaryCOB", "0");
            dic.Add("ApplyCalculated_Yes", "");
            dic.Add("ApplyCalculated_No", "True");
            dic.Add("ClientDecision_Yes", "");
            dic.Add("ClientDecision_No", "True");
            dic.Add("ClientDecision_Unknown", "");
            dic.Add("PBGCAgreement_Yes", "");
            dic.Add("PBGCAgreement_No", "True");
            dic.Add("PBGCAgreement_Unknown", "");
            pFundingInformation._PopVerify_GI_CarryoverBalance(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VoluntaryCOB", "0");
            dic.Add("ApplyCalculated_Yes", "");
            dic.Add("ApplyCalculated_No", "True");
            dic.Add("ClientDecision_Yes", "");
            dic.Add("ClientDecision_No", "True");
            dic.Add("ClientDecision_Unknown", "");
            dic.Add("PBGCAgreement_Yes", "");
            dic.Add("PBGCAgreement_No", "True");
            dic.Add("PBGCAgreement_Unknown", "");
            pFundingInformation._PopVerify_GI_PrefundingBalance(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanSponsor_Yes", "");
            dic.Add("PlanSponsor_No", "True");
            dic.Add("PlanSponsor_Unknown", "");
            dic.Add("IncreaseDueToPlanAmendment", "0");
            dic.Add("ExemptFrom_Yes", "");
            dic.Add("ExemptFrom_No", "True");
            dic.Add("ExemptFrom_Unknown", "");
            dic.Add("IncreaseDueToShutdown", "890");
            dic.Add("OriginalPlanEffectiveDate", "");
            dic.Add("PlanWasFrozen_Yes", "");
            dic.Add("PlanWasFrozen_No", "True");
            dic.Add("PlanWasFrozen_Unknown", "");
            pFundingInformation._PopVerify_GI_BenefitRestriction(dic);


            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Estimated Liabilities");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UseEstimatedLiabilities", "True");
            dic.Add("FundingService", "Valuation 2012");
            dic.Add("ValuationNode", "For AFTAP Range");
            dic.Add("EstimatedGL", "1.00");
            dic.Add("KnownWorkforceChanges", "2.00");
            dic.Add("Other", "0.50");
            pFundingInformation._PopVerify_EstimatedLiabilities(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("For AFTAP Range Test");

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2012");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Valuation 2012");



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liabilities for Funding");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Liabilities for Funding");

            dic.Clear();
            dic.Add("Level_1", "Funding Liabilities");
            dic.Add("Level_2", "Liability Results - General");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Funding Liabilities");
            dic.Add("Level_2", "Liability Results - Not-At-Risk");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Funding Liabilities");
            dic.Add("Level_2", "Liability Results - At-Risk");
            pFundingInformation._TreeViewSelect(dic);

            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "For AFTAP Range Test");
            pMain._PopVerify_Home_RightPane(dic);



            pMain._SelectTab("For AFTAP Range Test");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Funding Information");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Funding Information");


            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Estimated Liabilities");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UseEstimatedLiabilities", "");
            dic.Add("FundingService", "Valuation 2012");
            dic.Add("ValuationNode", "#1#");
            dic.Add("EstimatedGL", "");
            dic.Add("KnownWorkforceChanges", "");
            dic.Add("Other", "");
            pFundingInformation._PopVerify_EstimatedLiabilities(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UseEstimatedLiabilities", "");
            dic.Add("FundingService", "");
            dic.Add("ValuationNode", "For AFTAP Range");
            dic.Add("EstimatedGL", "");
            dic.Add("KnownWorkforceChanges", "");
            dic.Add("Other", "");
            pFundingInformation._PopVerify_EstimatedLiabilities(dic);

            pMain._SelectTab("Funding Information");

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("For AFTAP Range Test");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
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
            pMain._PopVerify_FundingCalculationRunCompleted(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(sOutputFunding_ForAFTAPRangeTest_Baseline, "Funding Calculator", "RollForward", false, true);


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("For AFTAP Range Test");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            #region Accounting Valuation - Conversion 2011 - Baseline

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
            dic.Add("Name", "Conversion 2011");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "2011");
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
            dic.Add("ServiceToOpen", "Conversion 2011");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Conversion 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Data");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Participant DataSet");



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
            dic.Add("SnapshotName", "Valuation Data");
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







            pMain._SelectTab("Conversion 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
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
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "7.0");
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
            dic.Add("txtRate", "5.5");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumption");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnPayLimitIncrease_V", "");
            dic.Add("btnPayLimitIncrease_Percent", "Click");
            dic.Add("btnPayLimitIncrease_T", "");
            dic.Add("PayLimitIncrease_V_cbo", "");
            dic.Add("PayLimitIncrease_txt", "2.0");
            dic.Add("PayLimitIncrease_T_cbo", "");
            dic.Add("btn415LimitIncrease_V", "");
            dic.Add("btn415LimitIncrease_Percent", "Click");
            dic.Add("btn415LimitIncrease_T", "");
            dic.Add("415LimitIncrease_V_cbo", "");
            dic.Add("415LimitIncrease_txt", "2.0");
            dic.Add("415LimitIncrease_T_cbo", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "80.0");
            dic.Add("txtPercentMarried_F", "80.0");
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
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("DisabledVsHealthy", "True");
            dic.Add("MemberVsSpouse", "");
            pMortalityDecrement._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "RP07CN");
            dic.Add("Mortality_Setback_M", "");
            dic.Add("Mortality_Setback_F", "");
            dic.Add("Disabled", "GA83");
            dic.Add("Disabled_Setback_M", "8");
            dic.Add("Disabled_Setback_F", "8");
            dic.Add("Disabled_Setback_combo", "Age");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "NHG3464");
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
            dic.Add("RetWithdrawDis", "NHG2319");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "_Disability");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "DI1006");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab("Conversion 2011");

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
            dic.Add("ProvidedInDataField", "BenService");
            dic.Add("RoundingRule", "");
            dic.Add("V", "Click");
            dic.Add("C", "");
            dic.Add("T", "");
            dic.Add("txtServiceIncrement", "");
            dic.Add("cboServiceIncrement", "BenServiceInc");
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
            dic.Add("ProvidedInDataField", "VestService");
            dic.Add("RoundingRule", "");
            dic.Add("V", "");
            dic.Add("C", "");
            dic.Add("T", "");
            dic.Add("txtServiceIncrement", "");
            dic.Add("cboServiceIncrement", "");
            pService._PopVerify_ServiceAtValuationDate(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "RetElig");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "RetElig");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$Age>= 65");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "VestedNotRetire");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "VestedNotRetire");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$VestingService>=5 and $Age<65");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "PayProjection1");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "PayProjection1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataFieldContainingPayHistory", "Salary");
            dic.Add("PayIncreaseAssumption", "PayIncrease1");
            dic.Add("UseOnlyDataFields", "");
            dic.Add("rdValuationYearPlus", "");
            dic.Add("txtValuationYearPlus", "");
            dic.Add("rdSpecifiedYear", "");
            dic.Add("txtSpecifiedYear", "");
            dic.Add("ApplyEGTRRALimits", "False");
            pPayoutProjection._PopVerify_History(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("MenuItem", "Add Pay Average");
            pAssumptions._TreeViewRightSelect(dic, "PayAverage1");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("Level_3", "PayAverage1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "PayProjection1");
            dic.Add("AveragingMethod", "");
            dic.Add("M", "");
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
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "AccruedBenefit");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("Level_4", "AccruedBenefit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max((0.01 * 6600.00 + 0.015*($PayAverage1 - 6600.00))* $BenefitService, $emp.AccruedBenefit1)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            dic.Add("MenuItem", "Add Vesting");
            pAssumptions._TreeViewRightSelect(dic, "Vesting1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            dic.Add("Level_3", "Vesting1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VestingServiceDefinition", "VestingService");
            dic.Add("AddRow", "");
            pVesting._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("YearsOfService", "5");
            dic.Add("VestingPercentage", "100.0");
            pVesting._ServiceTable(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("MenuItem", "Add Actuarial Equivalence");
            pAssumptions._TreeViewRightSelect(dic, "ActuarialEquivalence1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("Level_3", "ActuarialEquivalence1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("txtInterestRate", "7.5");
            dic.Add("Mortality", "PPA2010CMF");
            pActuarialEquivalence._PopVerify_SameStructureForAllPeriods(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("MenuItem", "Add Conversion Factors");
            pAssumptions._TreeViewRightSelect(dic, "LAtoJS50");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("Level_3", "LAtoJS50");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "Click");
            dic.Add("PresentValueFactor", "");
            dic.Add("TabularOrConstantFactor", "");
            dic.Add("CustomCode", "");
            pConversionFactors._PopVerify_Main(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType_From", "");
            dic.Add("MortalityInDeferralPeriod_From", "Member only mortality");
            dic.Add("ActuarialEquivalence_From", "ActuarialEquivalence1");
            dic.Add("ApplySpouseAgeDifference_From", "");
            dic.Add("FormOfPaymentType_To", "Joint and survivor");
            dic.Add("MortalityInDeferralPeriod_To", "Joint life mortality");
            dic.Add("ActuarialEquivalence_To", "ActuarialEquivalence1");
            dic.Add("ApplySpouseAgeDifference_To", "");
            dic.Add("btnGuaranteePeriod_From_V", "");
            dic.Add("GuaranteePeriod_From_cbo", "");
            dic.Add("btnGuaranteePeriod_From_C", "Click");
            dic.Add("GuaranteePeriod_From_txt", "");
            dic.Add("btnSurvivorPercentage_From_V", "");
            dic.Add("SurvivorPercentage_From_cbo", "");
            dic.Add("btnSurvivorPercentage_From_Percent", "Click");
            dic.Add("SurvivorPercentage_From_txt", "");
            dic.Add("btnPopupAmount_From_V", "");
            dic.Add("PopupAmount_From_cbo", "");
            dic.Add("btnPopupAmount_From_C", "Click");
            dic.Add("PopupAmount_From_txt", "");
            dic.Add("btnBenefitCommenceAge_From_V", "");
            dic.Add("BenefitCommenceAge_From_cbo", "");
            dic.Add("btnBenefitCommenceAge_From_C", "Click");
            dic.Add("BenefitCommenceAge_From_txt", "15");
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
            dic.Add("btnBenefitCommenceAge_To_V", "");
            dic.Add("BenefitCommenceAge_To_cbo", "");
            dic.Add("btnBenefitCommenceAge_To_C", "Click");
            dic.Add("BenefitCommenceAge_To_txt", "15");
            dic.Add("btnBenefitStopAge_To_V", "");
            dic.Add("BenefitStopAge_To_cbo", "");
            dic.Add("btnBenefitStopAge_To_C", "");
            dic.Add("BenefitStopAge_To_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_To_V", "");
            dic.Add("NumberOfPaymentsPerYear_To_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_To_C", "");
            dic.Add("NumberOfPaymentsPerYear_To_txt", "");
            pConversionFactors._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("MenuItem", "Add Conversion Factors");
            pAssumptions._TreeViewRightSelect(dic, "InactCVF");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("Level_3", "InactCVF");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("PresentValueFactor", "");
            dic.Add("TabularOrConstantFactor", "Click");
            dic.Add("CustomCode", "");
            pConversionFactors._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("T", "");
            dic.Add("C", "Click");
            dic.Add("txtTabularOrConstantFactor_M", "0.8811");
            dic.Add("txtTabularOrConstantFactor_F", "0.9143");
            dic.Add("cboTabularOrConstantFactor", "");
            pConversionFactors._PopVerify_TabularOrConstantFactor(dic);


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "Life");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "Life");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


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


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "SPLife");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "SPLife");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Spouse's");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "Click");
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
            pAssumptions._TreeViewRightSelect(dic, "ForInactives");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "ForInactives");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
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
            dic.Add("Level_3", "ForInactives");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Joint and survivor");
            dic.Add("MortalityInReferralPeriod", "Joint life mortality");
            dic.Add("btnGuaranteePeriod_V", "Click");
            dic.Add("GuaranteePeriod_cbo", "YearsCertain1");
            dic.Add("btnGuaranteePeriod_C", "");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            dic.Add("btnSurvivorPercentOrAmount_V", "Click");
            dic.Add("SurvivorPercentOrAmount_cbo", "Beneficiary1Percent1");
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
            dic.Add("LocalEligibility", "Click");
            dic.Add("txtLocalEligibility", "JS");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.PaymentForm1=\"J&S\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);





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
            dic.Add("btnGuaranteePeriod_C", "Click");
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
            pAssumptions._TreeViewRightSelect(dic, "InactDID");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "InactDID");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Spouse's annuity for death in deferral");
            dic.Add("MortalityInReferralPeriod", "");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "Click");
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
            pAssumptions._TreeViewRightSelect(dic, "JS50");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "JS50");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Joint and survivor");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "Click");
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


            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "415 Limits");
            dic.Add("MenuItem", "Add 415 Limits");
            pAssumptions._TreeViewRightSelect(dic, "LifeLimit");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "415 Limits");
            dic.Add("Level_3", "LifeLimit");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DeterminLimitBasedOn", "Specific year");
            dic.Add("DeterminLimitBasedOn_Year", "2008");
            dic.Add("IncreaseAppliesUntil", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("EarlyRetirementFator", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("PlanNormalFormOfPayment", "Life");
            dic.Add("ConversionFactorNormalFromToStraightLife", "");
            dic.Add("btnPlanNormalFromStopAge_V", "");
            dic.Add("PlanNormalFromStopAge_cbo", "");
            dic.Add("btnPlanNormalFromStopAge_C", "");
            dic.Add("PlanNormalFromStopAge_txt", "");
            dic.Add("PlanActuarialEquivalence", "");
            dic.Add("415LimitFormOfPayement", "Life");
            dic.Add("ConversionFactorNormalFromTo", "");
            dic.Add("btn415LimitFormStopAge_V", "");
            dic.Add("415LimitFormStopAge_cbo", "");
            dic.Add("btn415LimitFormStopAge_C", "");
            dic.Add("415LimitFormStopAge_txt", "");
            dic.Add("ParticipationService", "VestingService");
            dic.Add("MandatoryEmployeeContribution", "");
            dic.Add("ProjectedPayForAlternative", "PayProjection1");
            dic.Add("EmploymentService", "$Service");
            p415Limits._PopVerify_Standard(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "415 Limits");
            dic.Add("MenuItem", "Add 415 Limits");
            pAssumptions._TreeViewRightSelect(dic, "SPLimit");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "415 Limits");
            dic.Add("Level_3", "SPLimit");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DeterminLimitBasedOn", "Specific year");
            dic.Add("DeterminLimitBasedOn_Year", "2008");
            dic.Add("IncreaseAppliesUntil", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("EarlyRetirementFator", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("PlanNormalFormOfPayment", "Life");
            dic.Add("ConversionFactorNormalFromToStraightLife", "");
            dic.Add("btnPlanNormalFromStopAge_V", "");
            dic.Add("PlanNormalFromStopAge_cbo", "");
            dic.Add("btnPlanNormalFromStopAge_C", "");
            dic.Add("PlanNormalFromStopAge_txt", "");
            dic.Add("PlanActuarialEquivalence", "ActuarialEquivalence1");
            dic.Add("415LimitFormOfPayement", "SPLife");
            dic.Add("ConversionFactorNormalFromTo415Limit", "LAtoJS50");
            dic.Add("btn415LimitFormStopAge_V", "");
            dic.Add("415LimitFormStopAge_cbo", "");
            dic.Add("btn415LimitFormStopAge_C", "");
            dic.Add("415LimitFormStopAge_txt", "");
            dic.Add("ParticipationService", "VestingService");
            dic.Add("MandatoryEmployeeContribution", "");
            dic.Add("ProjectedPayForAlternative", "PayProjection1");
            dic.Add("EmploymentService", "$Service");
            p415Limits._PopVerify_Standard(dic);

            pMain._Home_ToolbarClick_Top(true);




            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "RetLiab");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "RetLiab");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
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
            dic.Add("FormOfPayment", "Life");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Retirement");
            dic.Add("ExcludePercentMarried", "True");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "RetLiab");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");



            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "RetElig");
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
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "True");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "AccruedBenefit");
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
            dic.Add("ConversionFactor_Married", "LAtoJS50");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "JS50");
            dic.Add("FormOfPayment_Single", "Life");
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
            pAssumptions._TreeViewRightSelect(dic, "WthLiab");


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WthLiab");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "Vesting1");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "Life");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ExcludePercentMarried", "True");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);




            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WthLiab");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");



            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "VestedNotRetire");
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
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "True");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "AccruedBenefit");
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
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "LAtoJS50");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "JS50");
            dic.Add("FormOfPayment_Single", "Life");
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
            pAssumptions._TreeViewRightSelect(dic, "DisLiab");


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "DisLiab");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "True");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "AccruedBenefit");
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
            dic.Add("VestingDefinition", "Vesting1");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "LAtoJS50");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "JS50");
            dic.Add("FormOfPayment_Single", "Life");
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
            pAssumptions._TreeViewRightSelect(dic, "DthLiab");


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "DthLiab");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "Click");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "AccruedBenefit");
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
            dic.Add("VestingDefinition", "Vesting1");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "LAtoJS50");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "SPLife");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "SPLimit");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Death");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "InacLiab");


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "InacLiab");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "Click");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "All inactives");
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
            dic.Add("FormOfPayment", "ForInactives");
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
            pAssumptions._TreeViewRightSelect(dic, "WthDIDLiab");


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WthDIDLiab");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("VestingDefinition", "Vesting1");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "LAtoJS50");
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
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WthDIDLiab");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");


            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "VestedNotRetire");
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
            dic.Add("SingleFormulaBenefit", "AccruedBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "LAtoJS50");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "SpouseDID");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "SPLimit");
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
            pAssumptions._TreeViewRightSelect(dic, "DisDIDLiab");


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "DisDIDLiab");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "AccruedBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("VestingDefinition", "Vesting1");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "LAtoJS50");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "SpouseDID");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "SPLimit");
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
            pAssumptions._TreeViewRightSelect(dic, "InactDIDLiab");


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "InactDIDLiab");
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
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "InactCVF");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "InactDID");
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


            pMain._SelectTab("Conversion 2011");

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
            dic.Add("ProjectedpayToUse", "PayProjection1");
            dic.Add("AccumulationToUse", "");
            dic.Add("IncludeExitYearValue", "");
            dic.Add("CalculatePresentValueOfFuture", "");
            dic.Add("CalculatePresentValueOfFuture_txt", "");
            dic.Add("VestingToUseForAgeFirstVested", "Vesting1");
            dic.Add("AverageWorkingLifeTime", "True");
            dic.Add("AverageLifeTime", "True");
            dic.Add("AverageWorkingLifeTimeToVesting", "True");
            dic.Add("AverageWorkingLifeTimeForBenefitingEE", "");
            pMethods._PopVerify_Methods_Accounting(dic);

            pMethods._ResultsForStatisticsForExpected_Grid(1, "BenefitService", false);
            pMethods._ResultsForStatisticsForExpected_Grid(2, "AccruedBenefit", false);
            pMethods._ResultsForStatisticsForExpected_Grid(3, "PayAverage1", false);




            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Description", "Projected Benefit");
            dic.Add("Variable", "AccruedBenefit");
            dic.Add("Age_cbo", "$FullRetAge");
            dic.Add("Age_txt", "");
            dic.Add("bFunding", "False");
            pMethods._AdditionalValuesToOutput_Grid(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Description", "Projected Service");
            dic.Add("Variable", "BenefitService");
            dic.Add("Age_cbo", "$FullRetAge");
            dic.Add("Age_txt", "");
            dic.Add("bFunding", "False");
            pMethods._AdditionalValuesToOutput_Grid(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Conversion 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/26/1944\"  and $emp.HireDate1=\"6/2/1996\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12/26/1956\"  and $emp.HireDate1=\"7/25/1997\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"6/6/1982\"  and $emp.HireDate1=\"7/9/2004\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"1/7/1987\"  and $emp.HireDate1=\"8/21/2009\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"3/14/1966\"  and $emp.HireDate1=\"11/10/1986\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"6/30/1924\"  and $emp.HireDate1=\"6/20/1980\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12/14/1940\"  and $emp.HireDate1=\"8/22/1999\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"11/11/1932\"  and $emp.HireDate1=\"12/17/1978\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/18/1934\"  and $emp.HireDate1=\"1/15/1984\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"5/15/1963\"  and $emp.HireDate1=\"9/14/2001\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"5/7/1984\"  and $emp.HireDate1=\"2/23/2008\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"4/15/1954\"  and $emp.HireDate1=\"4/30/1977\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"8/2/1974\"  and $emp.HireDate1=\"6/23/2000\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/23/1980\"  and $emp.HireDate1=\"6/1/2008\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);



            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Conversion 2011");

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
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "BenefitInPayment");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "HourlyFlag");
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


            pMain._SelectTab("Conversion 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011_Baseline, "Liability Summary", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_Conversion2011_Baseline, "Liability Summary", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "Member Statistics", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_Conversion2011_Baseline, "Conversion Diagnostic", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "Test Case List", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "Detailed Results", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "Valuation Summary", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011_Baseline, "Individual Output", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011_Baseline, "Parameter Print", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011_Baseline, "Test Cases", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011_Baseline, "Payout Projection", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "FAS Expected Benefit Pmts", "Conversion", true, false);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011_Baseline, "Liability Summary", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_Conversion2011_Baseline, "Liability Summary", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "Member Statistics", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_Conversion2011_Baseline, "Conversion Diagnostic", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "Test Case List", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "Detailed Results", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "Detailed Results by Plan Def", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "Valuation Summary", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011_Baseline, "Individual Output", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011_Baseline, "IOE", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011_Baseline, "Payout Projection", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "FAS Expected Benefit Pmts", "Conversion", false, false);
            }


            thrd_Accounting_Conversion2011_Baseline.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Conversion 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion




            #region Accounting Valuation - FAS Val 2012 - Baseline

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
            dic.Add("Name", "FAS Val 2012");
            dic.Add("Parent", "Conversion 2011");
            dic.Add("ParentFinalValuationSet", "Baseline");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "2012");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "FAS Val 2012");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("FAS Val 2012");




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
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._ValuationNodeProperties_ChangeReasons_Initialize();


            dic.Clear();
            dic.Add("LiabilityType", "All Accounting Liability Types");
            dic.Add("ReasonforChange", "Baseline");
            dic.Add("OK", "Click");
            pMain._ValuationNodeProperties_ChangeReasons(dic);



            pMain._SelectTab("FAS Val 2012");

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
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Valuation Data");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "True");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "Click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);





            pParticipantDataSet._Initialzie();

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "ParticipantStatus");
            pParticipantDataSet._Navigate(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "ParticipantStatus");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "PayStatus");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);



            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "HealthStatus");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "AliveStatus");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "ExitDate");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);



            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "TerminationDate1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "DeathDate");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "MaritalStatus");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            pParticipantDataSet._ExpandOrCollapseFirstLevel("Personal Information");

            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "MembershipDate1");
            pParticipantDataSet._Navigate(dic, true);


            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "MembershipDate1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "ContribRate1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "ContribsWInterest1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "ContribsWOInterest1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "BenefitInPayment");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "True");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "TestFlag");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "True");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            pParticipantDataSet._ExpandOrCollapseFirstLevel("DB Information");




            dic.Clear();
            dic.Add("Level_1", "DC Information");
            dic.Add("Level_2", "EeAccountBalance1");
            pParticipantDataSet._Navigate(dic, true);


            dic.Clear();
            dic.Add("Level_1", "DC Information");
            dic.Add("Level_2", "EeAccountBalance1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "DC Information");
            dic.Add("Level_2", "EeContribRate1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "DC Information");
            dic.Add("Level_2", "ErAccountBalance1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "DC Information");
            dic.Add("Level_2", "ErContribRate1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            pParticipantDataSet._ExpandOrCollapseFirstLevel("DC Information");


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BenService");
            pParticipantDataSet._Navigate(dic, true, false, true, false);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BenService");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "True");
            dic.Add("sComparisonType", "Absolute");
            dic.Add("bALL", "");
            dic.Add("bACT", "True");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "True");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BenServiceInc");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "False");
            dic.Add("sComparisonType", "Absolute");
            dic.Add("bALL", "");
            dic.Add("bACT", "True");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "VestService");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "True");
            dic.Add("sComparisonType", "Absolute");
            dic.Add("bALL", "");
            dic.Add("bACT", "True");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            pParticipantDataSet._ExpandOrCollapseFirstLevel("Personal Information");



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



            pMain._SelectTab("FAS Val 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/26/1944\"  and $emp.HireDate1=\"6/2/1996\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12/26/1956\"  and $emp.HireDate1=\"7/25/1997\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"6/6/1982\"  and $emp.HireDate1=\"7/9/2004\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"1/7/1987\"  and $emp.HireDate1=\"8/21/2009\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"3/14/1966\"  and $emp.HireDate1=\"11/10/1986\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"6/30/1924\"  and $emp.HireDate1=\"6/20/1980\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12/14/1940\"  and $emp.HireDate1=\"8/22/1999\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"11/11/1932\"  and $emp.HireDate1=\"12/17/1978\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/18/1934\"  and $emp.HireDate1=\"1/15/1984\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"5/15/1963\"  and $emp.HireDate1=\"9/14/2001\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"5/7/1984\"  and $emp.HireDate1=\"2/23/2008\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"4/15/1954\"  and $emp.HireDate1=\"4/30/1977\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"8/2/1974\"  and $emp.HireDate1=\"6/23/2000\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/23/1980\"  and $emp.HireDate1=\"6/1/2008\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);



            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab("FAS Val 2012");

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
            dic.Add("Acc_GL_PBO", "True");
            dic.Add("Acc_GL_ABO", "True");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "BenefitInPayment");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "HourlyFlag");
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
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("FAS Val 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(sOutputAccounting_FASVal2012_Baseline, "Reconciliation to Prior Year", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Detailed Results", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Status Reconciliation", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Member Statistics", "RollForward", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Individual Checking Template", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Age Service Matrix", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Data Matching Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Combined Status Code Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Gain / Loss Status Reconciliation", "RollForward", true, false);
                pOutputManager._ExportReport_SubReports(sOutputAccounting_FASVal2012_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, false);
                pOutputManager._ExportReport_SubReports(sOutputAccounting_FASVal2012_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Decrement Age", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Valuation Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Individual Output", "RollForward", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Parameter Print", "RollForward", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Test Cases", "RollForward", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Payout Projection", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "FAS Expected Benefit Pmts", "RollForward", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Liability Set for Globe Export", "RollForward", true, false);
            }
            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(sOutputAccounting_FASVal2012_Baseline, "Reconciliation to Prior Year", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(sOutputAccounting_FASVal2012_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Detailed Results", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Detailed Results by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Status Reconciliation", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Member Statistics", "RollForward", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Individual Checking Template", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Age Service Matrix", "RollForward", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Data Comparison", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Data Matching Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Combined Status Code Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(sOutputAccounting_FASVal2012_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(sOutputAccounting_FASVal2012_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Decrement Age", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(sOutputAccounting_FASVal2012_Baseline, "Gain / Loss Participant Listing", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(sOutputAccounting_FASVal2012_Baseline, "Liability Comparison", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Valuation Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Individual Output", "RollForward", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "IOE", "RollForward", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Payout Projection", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Liability Set for Globe Export", "RollForward", false, false);
            }



            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US008CN", sOutputAccounting_FASVal2012_Baseline_Prod, sOutputAccounting_FASVal2012_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting_FASVal2012_Baseline");
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_ABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_PBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_ABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DataComparison.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossStatusReconciliation.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_ABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_ABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PBO.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_ABO.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityComparison_PBO.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityComparison_ABO.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport.xlsx", 4, 0, 0, 0, true);
            }






            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("FAS Val 2012");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);





            #endregion



            _gLib._MsgBoxYesNo("Congratulations!", "Finnally, you are done with US008!");


        }



        void t_CompareRpt_Funding_Conversion2011_Baseline(string sOutputFunding_Conversion2011_Baseline)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US008CN", sOutputFunding_Conversion2011_Baseline_Prod, sOutputFunding_Conversion2011_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_Conversion2011_Baseline");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_ActiveMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_DeferredMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_Pensioners.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByNone.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByStatusCodes.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByCustom_Gender.xlsx", 4, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("TestCaseList.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        void t_CompareRpt_Funding_Valuation2012_Baseline(string sOutputFunding_Valuation2012_Baseline)
        {
            
            if (Config.bCompareReports)
            {

                CompareReportsLib _compareReportsLib = new CompareReportsLib("US008CN", sOutputFunding_Valuation2012_Baseline_Prod, sOutputFunding_Valuation2012_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Valuation2012_Baseline");
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataComparison.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossStatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityComparison_PPANARMin.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityComparison_PPANARMax.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }



        }
        
        void t_CompareRpt_Funding_Valuation2012_UpdateAssumptionDates(string sOutputFunding_Valuation2012_UpdateAssumptionDates)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US008CN", sOutputFunding_Valuation2012_UpdateAssumptionDates_Prod, sOutputFunding_Valuation2012_UpdateAssumptionDates);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_Valuation2012_UpdateAssumptionDates");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultswithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsByPlanDefwithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ASC960Reconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FundingCalculatorScenario.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }


        }

        void t_CompareRpt_Funding_Valuation2012_ForAFN2012(string sOutputFunding_Valuation2012_ForAFN2012)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US008CN", sOutputFunding_Valuation2012_ForAFN2012_Prod, sOutputFunding_Valuation2012_ForAFN2012);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_Valuation2012_ForAFN2012");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }

        }
        
        void t_CompareRpt_Funding_Valuation2012_ForAFTAPRange(string sOutputFunding_Valuation2012_ForAFTAPRange)
        {
            
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US008CN", sOutputFunding_Valuation2012_ForAFTAPRange_Prod, sOutputFunding_Valuation2012_ForAFTAPRange);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_Valuation2012_ForAFTAPRange");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPAARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPAARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPAARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPAARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPAARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPAARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPAARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPAARMin.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }


        }
        
        void t_CompareRpt_Funding_Valuation2013_Baseline(string sOutputFunding_Valuation2013_Baseline)
        {


            if (Config.bCompareReports)
            {

                CompareReportsLib _compareReportsLib = new CompareReportsLib("US008CN", sOutputFunding_Valuation2013_Baseline_Prod, sOutputFunding_Valuation2013_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Valuation2013_Baseline");
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataComparison.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossStatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityComparison_PPANARMin.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityComparison_PPANARMax.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }



        }
        
        void t_CompareRpt_Funding_Valuation2013_UpdateInterestAndMortality(string sOutputFunding_Valuation2013_UpdateInterestAndMortality)
        {



            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US008CN", sOutputFunding_Valuation2013_UpdateInterestAndMortality_Prod, sOutputFunding_Valuation2013_UpdateInterestAndMortality);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_Valuation2013_UpdateInterestAndMortality");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultswithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsByPlanDefwithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ASC960Reconciliation.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }


        


        }
        
        void t_CompareRpt_Funding_Valuation2013_ForAFN2012(string sOutputFunding_Valuation2013_ForAFN2012)
        {


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US008CN", sOutputFunding_Valuation2013_ForAFN2012_Prod, sOutputFunding_Valuation2013_ForAFN2012);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_Valuation2013_ForAFN2012");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }




        }
        
        void t_CompareRpt_Accounting_Conversion2011_Baseline(string sOutputAccounting_Conversion2011_Baseline)
        {


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US008CN", sOutputAccounting_Conversion2011_Baseline_Prod, sOutputAccounting_Conversion2011_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting_Conversion2011_Baseline");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_ActiveMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_DeferredMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_Pensioners.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByNone.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByStatusCodes.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByCustom_Gender.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }


        }
        


        #region HideByWebber

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

        #endregion
    }
}
