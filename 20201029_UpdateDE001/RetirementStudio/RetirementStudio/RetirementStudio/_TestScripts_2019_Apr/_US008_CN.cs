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



namespace RetirementStudio._TestScripts_2019_Apr
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class _US008_CN
    {
        public _US008_CN()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 008 Existing DNT";
            Config.sPlanName = "QA US Benchmark 008 Existing DNT Plan";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = false;
        }

        public string sService_Funding_Valuation2013 = "Valuation2013_1";
        public string sService_Funding_ForAFTAPRangeTest = "ForAFTAPRangeTest_1";
        public string sService_Accounting_FASVal2012 = "FASVal2012_1";

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
                    sOutputFunding_Conversion2011_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\Conversion2011\\Baseline\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2012_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2012\\Baseline\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2012_UpdateAssumptionDates = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2012\\UpdateAssumptionDates\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2012_ForAFN2012 = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2012\\ForAFN2012\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2012_ForAFTAPRange = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2012\\ForAFTAPRange\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2013_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2013\\Baseline\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2013_UpdateInterestAndMortality = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2013\\UpdateInterestAndMortality\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2013_ForAFN2012 = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2013\\ForAFN2012\\" + sPostFix + "\\");
                    sOutputFunding_ForAFTAPRangeTest_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\ForAFTAPRangeTest\\Baseline\\" + sPostFix + "\\");
                    sOutputAccounting_Conversion2011_Baseline = _gLib._CreateDirectory(sMainDir + "Accounting\\Conversion2011\\Baseline\\" + sPostFix + "\\");
                    sOutputAccounting_FASVal2012_Baseline = _gLib._CreateDirectory(sMainDir + "Accounting\\FASVal2012\\Baseline\\" + sPostFix + "\\");

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
                sOutputFunding_Conversion2011_Baseline = _gLib._CreateDirectory(sUS008Dir + "\\Funding_Conversion2011_Baseline\\");
                sOutputFunding_Valuation2012_Baseline = _gLib._CreateDirectory(sUS008Dir + "\\Funding_Valuation2012_Baseline\\");
                sOutputFunding_Valuation2012_UpdateAssumptionDates = _gLib._CreateDirectory(sUS008Dir + "\\Funding_Valuation2012_UpdateAssumptionDates\\");
                sOutputFunding_Valuation2012_ForAFN2012 = _gLib._CreateDirectory(sUS008Dir + "\\Funding_Valuation2012_ForAFN2012\\");
                sOutputFunding_Valuation2012_ForAFTAPRange = _gLib._CreateDirectory(sUS008Dir + "\\Funding_Valuation2012_ForAFTAPRange\\");
                sOutputFunding_Valuation2013_Baseline = _gLib._CreateDirectory(sUS008Dir + "\\Funding_Valuation2013_Baseline\\");
                sOutputFunding_Valuation2013_UpdateInterestAndMortality = _gLib._CreateDirectory(sUS008Dir + "\\Funding_Valuation2013_UpdateInterestAndMortality\\");
                sOutputFunding_Valuation2013_ForAFN2012 = _gLib._CreateDirectory(sUS008Dir + "\\Funding_Valuation2013_ForAFN2012\\");
                sOutputFunding_ForAFTAPRangeTest_Baseline = _gLib._CreateDirectory(sUS008Dir + "\\Funding_ForAFTAPRangeTest_Baseline\\");
                sOutputAccounting_Conversion2011_Baseline = _gLib._CreateDirectory(sUS008Dir + "\\Accounting_Conversion2011_Baseline\\");
                sOutputAccounting_FASVal2012_Baseline = _gLib._CreateDirectory(sUS008Dir + "\\Accounting_FASVal2012_Baseline\\");

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
        public void _test_US008_CN()
        {
            

            #region MultiThreads

            Thread thrd_Funding_Valuation2013_Baseline = new Thread(() => new _US008_CN().t_CompareRpt_Funding_Valuation2013_Baseline(sOutputFunding_Valuation2013_Baseline));
            Thread thrd_Funding_Valuation2013_UpdateInterestAndMortality = new Thread(() => new _US008_CN().t_CompareRpt_Funding_Valuation2013_UpdateInterestAndMortality(sOutputFunding_Valuation2013_UpdateInterestAndMortality));
            Thread thrd_Accounting_Conversion2011_Baseline = new Thread(() => new _US008_CN().t_CompareRpt_Accounting_Conversion2011_Baseline(sOutputAccounting_Conversion2011_Baseline));

            #endregion


            sOutputFunding_Valuation2013_Baseline = "";
            sOutputFunding_Valuation2013_UpdateInterestAndMortality = "";
            sOutputFunding_Valuation2013_ForAFN2012 = "";
            sOutputAccounting_FASVal2012_Baseline = "";



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
            dic.Add("Name", sService_Funding_Valuation2013);
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
            dic.Add("ServiceToOpen", sService_Funding_Valuation2013);
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab(sService_Funding_Valuation2013);

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





            pMain._SelectTab(sService_Funding_Valuation2013);

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


            pMain._SelectTab(sService_Funding_Valuation2013);

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




            pMain._SelectTab(sService_Funding_Valuation2013);

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


            pMain._SelectTab(sService_Funding_Valuation2013);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Detailed Results", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Status Reconciliation", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Member Statistics", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Individual Checking Template", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Age Service Matrix", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Data Matching Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Gain / Loss Status Reconciliation", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Decrement Age", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Individual Output", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Payout Projection", "RollForward", true, true);
            


            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Data Comparison", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Liability Comparison", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "IOE", "RollForward", false, true);


            thrd_Funding_Valuation2013_Baseline.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            #region Valuation 2013 - Update Interest and Mortality

            pMain._SelectTab(sService_Funding_Valuation2013);


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



            pMain._SelectTab(sService_Funding_Valuation2013);



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




            pMain._SelectTab(sService_Funding_Valuation2013);

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



            pMain._SelectTab(sService_Funding_Valuation2013);

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


            pMain._SelectTab(sService_Funding_Valuation2013);



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





            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Funding Calculator Scenario", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Individual Output", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Payout Projection", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Reconciliation to Baseline", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Reconciliation to Baseline with Breaks", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Liabilities Detailed Results", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Liabilities Detailed Results with Breaks", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "ASC 960 Reconciliation", "RollForward", true, true);


            pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Funding Calculator", "RollForward", false, true);


            pMain._SelectTab(sService_Funding_Valuation2013);

            pMain._GenerateNewReport(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "PPA Funding Valuation Report", 3);
            pMain._GenerateNewReport(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "ASC 960 Letter", 3);


            thrd_Funding_Valuation2013_UpdateInterestAndMortality.Start();

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
            dic.Add("Name", sService_Funding_ForAFTAPRangeTest);
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
            dic.Add("ServiceToOpen", sService_Funding_ForAFTAPRangeTest);
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab(sService_Funding_ForAFTAPRangeTest);


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

            pMain._SelectTab(sService_Funding_ForAFTAPRangeTest);


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


            pMain._SelectTab(sService_Funding_ForAFTAPRangeTest);

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
            dic.Add("ServiceToOpen", sService_Funding_ForAFTAPRangeTest);
            pMain._PopVerify_Home_RightPane(dic);



            pMain._SelectTab(sService_Funding_ForAFTAPRangeTest);

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


            pMain._SelectTab(sService_Funding_ForAFTAPRangeTest);

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

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_ForAFTAPRangeTest_Baseline, "Funding Calculator", "RollForward", false, true);


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab(sService_Funding_ForAFTAPRangeTest);
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
            dic.Add("Name", sService_Accounting_FASVal2012);
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
            dic.Add("ServiceToOpen", sService_Accounting_FASVal2012);
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab(sService_Accounting_FASVal2012);




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



            pMain._SelectTab(sService_Accounting_FASVal2012);

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



            pMain._SelectTab(sService_Accounting_FASVal2012);


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



            pMain._SelectTab(sService_Accounting_FASVal2012);

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

            pMain._SelectTab(sService_Accounting_FASVal2012);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Reconciliation to Prior Year", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Detailed Results", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Status Reconciliation", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Member Statistics", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Individual Checking Template", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Age Service Matrix", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Data Matching Summary", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Combined Status Code Summary", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Gain / Loss Status Reconciliation", "RollForward", true, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Decrement Age", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Valuation Summary", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Individual Output", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Test Cases", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Payout Projection", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "FAS Expected Benefit Pmts", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Liability Set for Globe Export", "RollForward", true, false);


            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Detailed Results by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Data Comparison", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Gain / Loss Participant Listing", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Liability Comparison", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "IOE", "RollForward", false, false);


            

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab(sService_Accounting_FASVal2012);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);





            #endregion



            _gLib._MsgBoxYesNo("Congratulations!", "Finnally, you are done with US008!");






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
        





        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.




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
