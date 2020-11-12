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



namespace RetirementStudio._TestScripts_2019_Apr
{
    /// <summary>
    /// Summary description for _US017_DNT
    /// </summary>
    [CodedUITest]
    public class _US017_DNT
    {
        public _US017_DNT()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 017 Existing DNT";
            Config.sPlanName = "QA US Benchmark 017 Existing DNT Plan";
            Config.sPlanName2 = "QA US Benchmark 017 Existing DNT Plan 2";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;

        }


        #region Report Output Directory



        public string sOutputPlan1_NDT2017_DCOnly = "";
        public string sOutputPlan1_NDT2017_DBOnly = "";
        public string sOutputPlan1_NDT2017_DBandDCProspective = "";

        public string sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs = "";


        public string sOutputPlan1_NDT2017_DCOnly_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\NDT 2017\DC Only\7.4_20190412_Franklin\";
        public string sOutputPlan1_NDT2017_DBOnly_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\NDT 2017\DB Only\7.4_20190412_Franklin\";
        public string sOutputPlan1_NDT2017_DBandDCProspective_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\NDT 2017\DB and DC Prospective\7.4_20190412_Franklin\";

        public string sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\NDT 2016 EOY and 2017\run only NHCEs\7.4_20190412_Franklin\";



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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Existing\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputPlan1_NDT2017_DCOnly = _gLib._CreateDirectory(sMainDir + "NDT 2017\\DC Only\\" + sPostFix + "\\");
                    sOutputPlan1_NDT2017_DBOnly = _gLib._CreateDirectory(sMainDir + "NDT 2017\\DB Only\\" + sPostFix + "\\");
                    sOutputPlan1_NDT2017_DBandDCProspective = _gLib._CreateDirectory(sMainDir + "NDT 2017\\DB and DC Prospective\\" + sPostFix + "\\");

                    sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs = _gLib._CreateDirectory(sMainDir + "NDT 2016 EOY and 2017\\run only NHCEs\\" + sPostFix + "\\");



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

                string sMainDir = sDir + "US017_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputPlan1_NDT2017_DCOnly = _gLib._CreateDirectory(sMainDir + "\\Plan1_NDT2017\\DCOnly\\");
                sOutputPlan1_NDT2017_DBOnly = _gLib._CreateDirectory(sMainDir + "\\Plan1_NDT2017\\DBOnly\\");
                sOutputPlan1_NDT2017_DBandDCProspective = _gLib._CreateDirectory(sMainDir + "\\Plan2_NDT2017\\DBandDCProspective\\");

                sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs = _gLib._CreateDirectory(sMainDir + "\\Plan2_NDT2016EOYand2017\\runonlyNHCEs\\");


            }

            string sContent = "";
            sContent = sContent + "sOutputPlan1_NDT2017_DCOnly = @\"" + sOutputPlan1_NDT2017_DCOnly + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan1_NDT2017_DBOnly = @\"" + sOutputPlan1_NDT2017_DBOnly + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan1_NDT2017_DBandDCProspective = @\"" + sOutputPlan1_NDT2017_DBandDCProspective + "\";" + Environment.NewLine;

            sContent = sContent + "sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs = @\"" + sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs + "\";" + Environment.NewLine;



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
        public void _Test_US017_DNT()
        {



            #region MultiThreads

            Thread thrd_Plan1_NDT2017_DCOnly = new Thread(() => new _US017_DNT().t_CompareRpt_Plan1_NDT2017_DCOnly(sOutputPlan1_NDT2017_DCOnly));
            Thread thrd_Plan1_NDT2017_DBOnly = new Thread(() => new _US017_DNT().t_CompareRpt_Plan1_NDT2017_DBOnly(sOutputPlan1_NDT2017_DBOnly));
            Thread thrd_Plan1_NDT2017_DBandDCProspective = new Thread(() => new _US017_DNT().t_CompareRpt_Plan1_NDT2017_DBandDCProspective(sOutputPlan1_NDT2017_DBandDCProspective));

            #endregion


            this.GenerateReportOuputDir();


            #region Plan 1 - Funding - NDT 2017 - DC_Only Node

            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "NDT 2017");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("NDT 2017");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "105");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "3");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "3");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DCOnly, "Parameter Print", "RollForward", true, true);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DCOnly, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DCOnly, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DCOnly, "Coverage Test", "RollForward", false, true);

            //////_gLib._MsgBox("Manual Steps!", "Please manually download the only 3 General Test Excel reports : Summary; Current Testing for Each HCE; Current Testing Accrual Rates");

            pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan1_NDT2017_DCOnly, "General Test", "RollForward", false, true, true, false, false, true, false, false, dic);



            thrd_Plan1_NDT2017_DCOnly.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion

            #region Plan 1 - Funding - NDT 2017 - DB_Only Node


            pMain._SelectTab("NDT 2017");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "3");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "3");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "3");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBOnly, "Parameter Print", "RollForward", true, true);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBOnly, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBOnly, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBOnly, "Coverage Test", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBOnly, "General Test", "RollForward", false, true);


            thrd_Plan1_NDT2017_DBOnly.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion

            #region Plan 1 - Funding - NDT 2017 - DB_and_DC_Prospective Node



            pMain._SelectTab("NDT 2017");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "3");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "3");
            dic.Add("iPosX", "425");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "3");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "3");
            dic.Add("iPosX", "425");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "3");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "3");
            dic.Add("iPosX", "425");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBandDCProspective, "Parameter Print", "RollForward", true, true);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBandDCProspective, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBandDCProspective, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBandDCProspective, "Coverage Test", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBandDCProspective, "General Test", "RollForward", false, true);



            thrd_Plan1_NDT2017_DBandDCProspective.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("NDT 2017");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Plan 2 - Funding - NDT 2016 EOY and 2017 - run_only_NHCEs Node


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName2);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);


            _gLib._MsgBox("Manual Step!", "Please manually go to: " + Environment.NewLine
                + "  -> Plan2" + Environment.NewLine
                + "  -> FundingValuation" + Environment.NewLine
                + "  -> NDT 2016 EOY and 2017");


            pMain._SelectTab("NDT 2016 EOY and 2017");


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
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("SelectRecords", "$emp.HighlyCompensatedCode = 0");
            dic.Add("Validate", "Click");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("NDT 2016 EOY and 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2016 EOY and 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._Navigate("Plan Aggregation", "RollForward", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NoAggregation", "");
            dic.Add("SamePlansIncluded", "");
            dic.Add("PlansDiffer", "True");
            dic.Add("UpdateAggregation", "");
            dic.Add("Close", "");
            pOutputManager._PopVerify_PlanAggregation(dic);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2017");
            dic.Add("Level_4", "DB Only");
            pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);

            _gLib._MsgBox("", "check table Coverage was checked: " + Environment.NewLine
             + "Level_1 - " + dic["Level_1"] + Environment.NewLine
             + "Level_2 - " + dic["Level_2"] + Environment.NewLine
             + "Level_3 - " + dic["Level_3"] + Environment.NewLine
             + "Level_4 - " + dic["Level_4"]);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName2);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2016 EOY and 2017");
            dic.Add("Level_4", "DC Only");
            pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);

            _gLib._MsgBox("", "check table Coverage was checked: " + Environment.NewLine
             + "Level_1 - " + dic["Level_1"] + Environment.NewLine
             + "Level_2 - " + dic["Level_2"] + Environment.NewLine
             + "Level_3 - " + dic["Level_3"] + Environment.NewLine
             + "Level_4 - " + dic["Level_4"]);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2016");
            dic.Add("Level_4", "Copy of PFVS");
            pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);

            _gLib._MsgBox("", "check General table, following options was checked: " + Environment.NewLine
                + "Level_1 - " + dic["Level_1"] + Environment.NewLine
                + "Level_2 - " + dic["Level_2"] + Environment.NewLine
                + "Level_3 - " + dic["Level_3"] + Environment.NewLine
                + "Level_4 - " + dic["Level_4"]);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2017");
            dic.Add("Level_4", "Baseline");
            pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);

            _gLib._MsgBox("", "check General table, following options was checked: " + Environment.NewLine
              + "Level_1 - " + dic["Level_1"] + Environment.NewLine
              + "Level_2 - " + dic["Level_2"] + Environment.NewLine
              + "Level_3 - " + dic["Level_3"] + Environment.NewLine
              + "Level_4 - " + dic["Level_4"]);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2017");
            dic.Add("Level_4", "DC Only");
            pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);

            _gLib._MsgBox("", "check General table, following options was checked: " + Environment.NewLine
             + "Level_1 - " + dic["Level_1"] + Environment.NewLine
             + "Level_2 - " + dic["Level_2"] + Environment.NewLine
             + "Level_3 - " + dic["Level_3"] + Environment.NewLine
             + "Level_4 - " + dic["Level_4"]);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2017");
            dic.Add("Level_4", "DB Only");
            pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);

            _gLib._MsgBox("", "check General table, following options was checked: " + Environment.NewLine
             + "Level_1 - " + dic["Level_1"] + Environment.NewLine
             + "Level_2 - " + dic["Level_2"] + Environment.NewLine
             + "Level_3 - " + dic["Level_3"] + Environment.NewLine
             + "Level_4 - " + dic["Level_4"]);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2017");
            dic.Add("Level_4", "DB and DC Prospective");
            pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);

            _gLib._MsgBox("", "check General table, following options was checked: " + Environment.NewLine
             + "Level_1 - " + dic["Level_1"] + Environment.NewLine
             + "Level_2 - " + dic["Level_2"] + Environment.NewLine
             + "Level_3 - " + dic["Level_3"] + Environment.NewLine
             + "Level_4 - " + dic["Level_4"]);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName2);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2016 EOY and 2017");
            dic.Add("Level_4", "Baseline");
            pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);

            _gLib._MsgBox("", "check General table, following options was checked: " + Environment.NewLine
              + "Level_1 - " + dic["Level_1"] + Environment.NewLine
              + "Level_2 - " + dic["Level_2"] + Environment.NewLine
              + "Level_3 - " + dic["Level_3"] + Environment.NewLine
              + "Level_4 - " + dic["Level_4"]);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName2);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2016 EOY and 2017");
            dic.Add("Level_4", "DC Only");
            pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);

            _gLib._MsgBox("", "check General table, following options was checked: " + Environment.NewLine
              + "Level_1 - " + dic["Level_1"] + Environment.NewLine
              + "Level_2 - " + dic["Level_2"] + Environment.NewLine
              + "Level_3 - " + dic["Level_3"] + Environment.NewLine
              + "Level_4 - " + dic["Level_4"]);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName2);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2016 EOY and 2017");
            dic.Add("Level_4", "DB Only");
            pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);

            _gLib._MsgBox("", "check General table, following options was checked: " + Environment.NewLine
             + "Level_1 - " + dic["Level_1"] + Environment.NewLine
             + "Level_2 - " + dic["Level_2"] + Environment.NewLine
             + "Level_3 - " + dic["Level_3"] + Environment.NewLine
             + "Level_4 - " + dic["Level_4"]);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName2);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2016 EOY and 2017");
            dic.Add("Level_4", "run only NHCEs");
            pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);

            _gLib._MsgBox("", "check General table, following options was checked: " + Environment.NewLine
             + "Level_1 - " + dic["Level_1"] + Environment.NewLine
             + "Level_2 - " + dic["Level_2"] + Environment.NewLine
             + "Level_3 - " + dic["Level_3"] + Environment.NewLine
             + "Level_4 - " + dic["Level_4"]);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName2);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "update 2016");
            dic.Add("Level_4", "NDT");
            pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);

            _gLib._MsgBox("", "check General table, following options was checked: " + Environment.NewLine
               + "Level_1 - " + dic["Level_1"] + Environment.NewLine
               + "Level_2 - " + dic["Level_2"] + Environment.NewLine
               + "Level_3 - " + dic["Level_3"] + Environment.NewLine
               + "Level_4 - " + dic["Level_4"]);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UpdateAggregation", "Click");
            dic.Add("Close", "Click");
            pOutputManager._PopVerify_PlanAggregation(dic);


            pOutputManager._ExportReport_Others(sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "Parameter Print", "RollForward", true, true);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "Individual Output", "RollForward", false, true);
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("HighlyCompensated", "100");
            dic.Add("NonHighlyCompensated", "1,000");
            pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "Coverage Test", "RollForward", false, true, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CreateARateGroupForEachHCE", "");
            dic.Add("GroupRates", "");
            dic.Add("ForNormalAccrualRate", "");
            dic.Add("ForMostValuableAccrualRate", "");
            dic.Add("HighlyCompensated", "200");
            dic.Add("NonHighlyCompensated", "2,000");
            pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "General Test", "RollForward", false, true, dic);


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017_DNT", sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs_Prod, sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan2_NDT2016EOYand2017_runonlyNHCEs");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0, true);
            }


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("NDT 2016 EOY and 2017");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            _gLib._MsgBox("", "done");

        }



        void t_CompareRpt_Plan1_NDT2017_DCOnly(string sOutputPlan1_NDT2017_DCOnly)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017_DNT", sOutputPlan1_NDT2017_DCOnly_Prod, sOutputPlan1_NDT2017_DCOnly);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan1_NDT2017_DCOnly");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0, false);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0, false);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0, false);

                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Plan1_NDT2017_DBOnly(string sOutputPlan1_NDT2017_DBOnly)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017_DNT", sOutputPlan1_NDT2017_DBOnly_Prod, sOutputPlan1_NDT2017_DBOnly);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan1_NDT2017_DBOnly");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0);

                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Plan1_NDT2017_DBandDCProspective(string sOutputPlan1_NDT2017_DBandDCProspective)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017_DNT", sOutputPlan1_NDT2017_DBandDCProspective_Prod, sOutputPlan1_NDT2017_DBandDCProspective);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan1_NDT2017_DBandDCProspective");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0);

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
