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
using System.Diagnostics;


namespace RetirementStudio._TestScripts_2019_cloud._TestScripts_US
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class US017_Cloud
    {
        public US017_Cloud()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 017 Cloud";
            Config.sPlanName = "QA US Benchmark 017 Cloud Plan";
            Config.sPlanName2 = "QA US Benchmark 017 Cloud Plan 2";
            Config.sProductionVerison = "7.6";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
            //_gLib._Report(_PassFailStep.Header, "Testing Starts at: " + DateTime.Now + "\t" + Environment.UserName);
        }


        #region Report Output Directory
        
        public string sOutputPlan1_NDT2016_Baseline = "";
        public string sOutputPlan1_NDT2017_Baseline = "";
        public string sOutputPlan1_NDT2017_DCOnly = "";
        public string sOutputPlan1_NDT2017_DBOnly = "";
        public string sOutputPlan1_NDT2017_DBandDCProspective = "";
        
        public string sOutputPlan2_conversion2016_Baseline = "";
        public string sOutputPlan2_update2016_updatevaldate = "";
        public string sOutputPlan2_update2016_NDT = "";
        public string sOutputPlan2_NDT2016EOYand2017_Baseline = "";
        public string sOutputPlan2_NDT2016EOYand2017_DCOnly = "";
        public string sOutputPlan2_NDT2016EOYand2017_DBOnly = "";
        public string sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs = "";
        
        public string sOutputPlan1_NDT2016_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Existing\NDT 2016\Copy of PFVS\20191110_QA1_Cloud\";
        public string sOutputPlan1_NDT2017_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Existing\NDT 2017\Baseline\20191110_QA1_Cloud\";
        public string sOutputPlan1_NDT2017_DCOnly_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Existing\NDT 2017\DC Only\20191110_QA1_Cloud\";
        public string sOutputPlan1_NDT2017_DBOnly_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Existing\NDT 2017\DB Only\20191110_QA1_Cloud\";
        public string sOutputPlan1_NDT2017_DBandDCProspective_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Existing\NDT 2017\DB and DC Prospective\20191110_QA1_Cloud\";

        public string sOutputPlan2_conversion2016_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Existing\conversion 2016\Copy of PFVS\20191110_QA1_Cloud\";
        public string sOutputPlan2_update2016_updatevaldate_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Existing\update 2016\update val date\20191110_QA1_Cloud\";
        public string sOutputPlan2_update2016_NDT_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Existing\update 2016\NDT\20191110_QA1_Cloud\";
        public string sOutputPlan2_NDT2016EOYand2017_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Existing\NDT 2016 EOY and 2017\Baseline\20191110_QA1_Cloud\";
        public string sOutputPlan2_NDT2016EOYand2017_DCOnly_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Existing\NDT 2016 EOY and 2017\DC Only\20191110_QA1_Cloud\";
        public string sOutputPlan2_NDT2016EOYand2017_DBOnly_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Existing\NDT 2016 EOY and 2017\DB Only\20191110_QA1_Cloud\";
        public string sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Existing\NDT 2016 EOY and 2017\run only NHCEs\20191110_QA1_Cloud\";


        public void GenerateReportOuputDir()
        {

            pMain._SetLanguageAndRegional();

            _BenchmarkUser sCurrentUser = _gLib._ReturnCurrentUser();
            if (sCurrentUser.ToString() == "Others")
            {
                _gLib._MsgBox("Warning !!!", "Your are NOT allowed to create folders in \\mercer.com\\US_Data\\Shared\\Dfl\\Data1\\RSS\\SQA drive, Please contact Cindy or Webber if you have to!");
                Environment.Exit(0);
            }
            else
            {
                string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Existing\";
                string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString() + "_Cloud";

                //////sPostFix = sPostFix + "_Franklin";

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);


                sOutputPlan1_NDT2016_Baseline = _gLib._CreateDirectory(sMainDir + "NDT 2016\\Copy of PFVS\\" + sPostFix + "\\");
                sOutputPlan1_NDT2017_Baseline = _gLib._CreateDirectory(sMainDir + "NDT 2017\\Baseline\\" + sPostFix + "\\");
                sOutputPlan1_NDT2017_DCOnly = _gLib._CreateDirectory(sMainDir + "NDT 2017\\DC Only\\" + sPostFix + "\\");
                sOutputPlan1_NDT2017_DBOnly = _gLib._CreateDirectory(sMainDir + "NDT 2017\\DB Only\\" + sPostFix + "\\");
                sOutputPlan1_NDT2017_DBandDCProspective = _gLib._CreateDirectory(sMainDir + "NDT 2017\\DB and DC Prospective\\" + sPostFix + "\\");
                sOutputPlan2_conversion2016_Baseline = _gLib._CreateDirectory(sMainDir + "conversion 2016\\Copy of PFVS\\" + sPostFix + "\\");
                sOutputPlan2_update2016_updatevaldate = _gLib._CreateDirectory(sMainDir + "update 2016\\update val date\\" + sPostFix + "\\");
                sOutputPlan2_update2016_NDT = _gLib._CreateDirectory(sMainDir + "update 2016\\NDT\\" + sPostFix + "\\");
                sOutputPlan2_NDT2016EOYand2017_Baseline = _gLib._CreateDirectory(sMainDir + "NDT 2016 EOY and 2017\\Baseline\\" + sPostFix + "\\");
                sOutputPlan2_NDT2016EOYand2017_DCOnly = _gLib._CreateDirectory(sMainDir + "NDT 2016 EOY and 2017\\DC Only\\" + sPostFix + "\\");
                sOutputPlan2_NDT2016EOYand2017_DBOnly = _gLib._CreateDirectory(sMainDir + "NDT 2016 EOY and 2017\\DB Only\\" + sPostFix + "\\");
                sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs = _gLib._CreateDirectory(sMainDir + "NDT 2016 EOY and 2017\\run only NHCEs\\" + sPostFix + "\\");



            }


            string sContent = "";
            sContent = sContent + "sOutputPlan1_NDT2016_Baseline = @\"" + sOutputPlan1_NDT2016_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan1_NDT2017_Baseline = @\"" + sOutputPlan1_NDT2017_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan1_NDT2017_DCOnly = @\"" + sOutputPlan1_NDT2017_DCOnly + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan1_NDT2017_DBOnly = @\"" + sOutputPlan1_NDT2017_DBOnly + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan1_NDT2017_DBandDCProspective = @\"" + sOutputPlan1_NDT2017_DBandDCProspective + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan2_conversion2016_Baseline = @\"" + sOutputPlan2_conversion2016_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan2_update2016_updatevaldate = @\"" + sOutputPlan2_update2016_updatevaldate + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan2_update2016_NDT = @\"" + sOutputPlan2_update2016_NDT + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan2_NDT2016EOYand2017_Baseline = @\"" + sOutputPlan2_NDT2016EOYand2017_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan2_NDT2016EOYand2017_DCOnly = @\"" + sOutputPlan2_NDT2016EOYand2017_DCOnly + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan2_NDT2016EOYand2017_DBOnly = @\"" + sOutputPlan2_NDT2016EOYand2017_DBOnly + "\";" + Environment.NewLine;
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
        public void _test_US017_Cloud()
        {


            #region MultiThreads
            
            Thread thrd_Plan1_NDT2016_Baseline = new Thread(() => new US017_Cloud().t_CompareRpt_Plan1_NDT2016_Baseline(sOutputPlan1_NDT2016_Baseline));
            Thread thrd_Plan1_NDT2017_Baseline = new Thread(() => new US017_Cloud().t_CompareRpt_Plan1_NDT2017_Baseline(sOutputPlan1_NDT2017_Baseline));
            Thread thrd_Plan1_NDT2017_DCOnly = new Thread(() => new US017_Cloud().t_CompareRpt_Plan1_NDT2017_DCOnly(sOutputPlan1_NDT2017_DCOnly));
            Thread thrd_Plan1_NDT2017_DBOnly = new Thread(() => new US017_Cloud().t_CompareRpt_Plan1_NDT2017_DBOnly(sOutputPlan1_NDT2017_DBOnly));
            Thread thrd_Plan1_NDT2017_DBandDCProspective = new Thread(() => new US017_Cloud().t_CompareRpt_Plan1_NDT2017_DBandDCProspective(sOutputPlan1_NDT2017_DBandDCProspective));
            Thread thrd_Plan2_conversion2016_Baseline = new Thread(() => new US017_Cloud().t_CompareRpt_Plan2_conversion2016_Baseline(sOutputPlan2_conversion2016_Baseline));
            Thread thrd_Plan2_update2016_updatevaldate = new Thread(() => new US017_Cloud().t_CompareRpt_Plan2_update2016_updatevaldate(sOutputPlan2_update2016_updatevaldate));
            Thread thrd_Plan2_update2016_NDT = new Thread(() => new US017_Cloud().t_CompareRpt_Plan2_update2016_NDT(sOutputPlan2_update2016_NDT));
            Thread thrd_Plan2_NDT2016EOYand2017_Baseline = new Thread(() => new US017_Cloud().t_CompareRpt_Plan2_NDT2016EOYand2017_Baseline(sOutputPlan2_NDT2016EOYand2017_Baseline));
            Thread thrd_Plan2_NDT2016EOYand2017_DCOnly = new Thread(() => new US017_Cloud().t_CompareRpt_Plan2_NDT2016EOYand2017_DCOnly(sOutputPlan2_NDT2016EOYand2017_DCOnly));
            Thread thrd_Plan2_NDT2016EOYand2017_DBOnly = new Thread(() => new US017_Cloud().t_CompareRpt_Plan2_NDT2016EOYand2017_DBOnly(sOutputPlan2_NDT2016EOYand2017_DBOnly));
            
            #endregion


            this.GenerateReportOuputDir();


            #region Plan 1 - Funding - NDT 2016 - Baseline

            //////////pMain._SelectTab("Home");


            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sClientName);
            //////////dic.Add("Level_2", Config.sPlanName);
            //////////dic.Add("Level_3", "FundingValuations");
            //////////pMain._HomeTreeViewSelect(0, dic);


            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("AddServiceInstance", "");
            //////////dic.Add("ServiceToOpen", "NDT 2016");
            //////////pMain._PopVerify_Home_RightPane(dic);


            //////////pMain._SelectTab("NDT 2016");


            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "Run");
            //////////dic.Add("MenuItem_2", "Liabilities");
            //////////pMain._FlowTreeRightSelect(dic);


            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("GL_GoingConcern", "");
            //////////dic.Add("PayoutProjection", "");
            //////////dic.Add("IncludeIOE", "True");
            //////////dic.Add("GenerateParameterPrint", "True");
            //////////dic.Add("GenerateTestCaseOutput", "True");
            //////////dic.Add("IncludeGainLossResult", "");
            //////////dic.Add("RunValuation", "Click");
            //////////pMain._PopVerify_RunOptions(dic);

            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("OK", "Click");
            //////////pMain._PopVerify_EnterpriseRunSubmitted(dic);


            //////////pMain._SelectTab("NDT 2016");

            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "View Run Status");
            //////////pMain._FlowTreeRightSelect(dic);

            //////////pMain._EnterpriseRun("Group Job Successfully Complete", true);

            //////////pMain._SelectTab("NDT 2016");

            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "View Output");
            //////////pMain._FlowTreeRightSelect(dic);


            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2016_Baseline, "Parameter Print", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2016_Baseline, "Individual Output", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2016_Baseline, "IOE", "Conversion", false, true);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2016_Baseline, "Test Cases", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2016_Baseline, "Coverage Test", "Conversion", true, true);
            //////////////////_gLib._MsgBox("Manual Steps!", "Please manually download the only 3 General Test PDF reports : Summary; Current and Prior Testing Rate for each HCE; Current and Prior Testing Accrual Rates");
            //////////pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan1_NDT2016_Baseline, "General Test", "Conversion", true, true, false, true, false, false, true, false, dic);
            //////////pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan1_NDT2016_Baseline, "General Test", "Conversion", false, true, false, true, false, false, true, false, dic);


            //////////thrd_Plan1_NDT2016_Baseline.Start();


            //////////pMain._SelectTab("Output Manager");
            //////////pMain._Home_ToolbarClick_Top(true);
            //////////pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region Plan 1 - Funding - NDT 2017 - Baseline Node

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


            _gLib._MsgBox("Manual Step", "please manually expand the Tree View zone as all nodes included.");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "271");
            dic.Add("iPosY", "88");
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
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", "271");
            dic.Add("iPosY", "88");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", "271");
            dic.Add("iPosY", "88");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_Baseline, "Individual Output", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_Baseline, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_Baseline, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_Baseline, "Coverage Test", "RollForward", true, true);
            //_gLib._MsgBox("Manual Steps!", "Please manually download the only 5 General Test PDF reports : Summary; Current Testing forEach HCE; Current and Prior Testing Rate for each HCE; Current Testing Accrual Rates; Current and Prior Testing Accrual Rates");
            pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan1_NDT2017_Baseline, "General Test", "RollForward", true, true, true, true, false, true, true, false, dic);
            pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan1_NDT2017_Baseline, "General Test", "RollForward", false, true, true, true, false, true, true, false, dic);


            thrd_Plan1_NDT2017_Baseline.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion
            
            #region Plan 1 - Funding - NDT 2017 - DC_Only Node

            pMain._SelectTab("NDT 2017");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", "108");
            dic.Add("iPosY", "154");
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
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", "108");
            dic.Add("iPosY", "154");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", "108");
            dic.Add("iPosY", "154");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DCOnly, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DCOnly, "Individual Output", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DCOnly, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DCOnly, "Coverage Test", "RollForward", true, true);
            //_gLib._MsgBox("Manual Steps!", "Please manually download the only 3 General Test PDF reports : Summary; Current Testing fo rEach HCE; Current Testing Accrual Rates");
            pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan1_NDT2017_DCOnly, "General Test", "RollForward", true, true, true, false, false, true, false, false, dic);
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
            dic.Add("iMaxColNum", "0");
            dic.Add("iPosX", "219");
            dic.Add("iPosY", "157");
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
            dic.Add("iMaxColNum", "0");
            dic.Add("iPosX", "219");
            dic.Add("iPosY", "157");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "0");
            dic.Add("iPosX", "219");
            dic.Add("iPosY", "157");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBOnly, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBOnly, "Individual Output", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBOnly, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBOnly, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBOnly, "Coverage Test", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBOnly, "General Test", "RollForward", true, true);


            thrd_Plan1_NDT2017_DBOnly.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion
            
            #region Plan 1 - Funding - NDT 2017 - DB_and_DC_Prospective Node

            pMain._SelectTab("NDT 2017");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
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
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "425");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "425");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBandDCProspective, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBandDCProspective, "Individual Output", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBandDCProspective, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBandDCProspective, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBandDCProspective, "Coverage Test", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBandDCProspective, "General Test", "RollForward", true, true);


            thrd_Plan1_NDT2017_DBandDCProspective.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("NDT 2017");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion
            

            #region Plan 2 - Funding - conversion 2016 - Baseline

            //////////pMain._SelectTab("Home");


            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sClientName);
            //////////dic.Add("Level_2", Config.sPlanName2);
            //////////dic.Add("Level_3", "FundingValuations");
            //////////pMain._HomeTreeViewSelect(0, dic);

            //////////_gLib._MsgBox("Manual Step!", "Please manually select on Plan2_FundingValuation in Home page tree view!");



            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("AddServiceInstance", "");
            //////////dic.Add("ServiceToOpen", "conversion 2016");
            //////////pMain._PopVerify_Home_RightPane(dic);


            //////////pMain._SelectTab("conversion 2016");


            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "Run");
            //////////dic.Add("MenuItem_2", "Liabilities");
            //////////pMain._FlowTreeRightSelect(dic);

            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("GL_PPANAR_Min", "");
            //////////dic.Add("GL_PPANAR_Max", "");
            //////////dic.Add("GL_EAN", "");
            //////////dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            //////////dic.Add("PayoutProjection", "True");
            //////////dic.Add("IncludeIOE", "True");
            //////////dic.Add("GenerateParameterPrint", "True");
            //////////dic.Add("GenerateTestCaseOutput", "");
            //////////dic.Add("IncludeGainLossResult", "");
            //////////dic.Add("Service", "$Service");
            //////////dic.Add("Pay", "SalPriorYear1");
            //////////dic.Add("CurrentYear", "");
            //////////dic.Add("PriorYear", "Click");
            //////////dic.Add("CashBanlance", "CashBalAccount");
            //////////dic.Add("Pension", "PVinact");
            //////////dic.Add("AllLiabilityTypes", "");
            //////////dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            //////////dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            //////////dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            //////////dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "True");
            //////////dic.Add("FAS35PresentValueOfAccumulatedBenefits", "True");
            //////////dic.Add("FAS35PresentValueOfVestedBenefits", "True");
            //////////dic.Add("PPAAtRiskLiabilityForMinimum", "False");
            //////////dic.Add("PPAAtRiskLiabilityForMaximum", "False");
            //////////dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "False");
            //////////dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "False");
            //////////dic.Add("EntryAgeNormal", "False");
            //////////dic.Add("PayoutProjectionCustomGroup", "");
            //////////dic.Add("RunValuation", "Click");
            //////////pMain._PopVerify_RunOptions(dic);


            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("OK", "Click");
            //////////pMain._PopVerify_EnterpriseRunSubmitted(dic);


            //////////pMain._SelectTab("conversion 2016");

            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "View Run Status");
            //////////pMain._FlowTreeRightSelect(dic);

            //////////pMain._EnterpriseRun("Group Job Successfully Complete with 7 NP", true);


            //////////pMain._SelectTab("conversion 2016");

            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "View Output");
            //////////pMain._FlowTreeRightSelect(dic);


            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_conversion2016_Baseline, "Liability Summary", "Conversion", true, true);
            //////////pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputPlan2_conversion2016_Baseline, "Liability Summary", "Conversion", true, true, 0);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPlan2_conversion2016_Baseline, "Member Statistics", "Conversion", true, true);
            //////////pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputPlan2_conversion2016_Baseline, "Conversion Diagnostic", "Conversion", true, true, 0);
            ////////////////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPlan2_conversion2016_Baseline, "Test Case List", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPlan2_conversion2016_Baseline, "Detailed Results", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPlan2_conversion2016_Baseline, "Detailed Results by Plan Def", "Conversion", false, true);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPlan2_conversion2016_Baseline, "Valuation Summary", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_conversion2016_Baseline, "Individual Output", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_conversion2016_Baseline, "IOE", "Conversion", false, true);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_conversion2016_Baseline, "Parameter Print", "Conversion", true, true);
            ////////////////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_conversion2016_Baseline, "Test Cases", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_conversion2016_Baseline, "Payout Projection", "Conversion", true, true);


            //////////thrd_Plan2_conversion2016_Baseline.Start();

            //////////pMain._SelectTab("Output Manager");
            //////////pMain._Home_ToolbarClick_Top(true);
            //////////pMain._Home_ToolbarClick_Top(false);

            //////////pMain._SelectTab("conversion 2016");
            //////////pMain._Home_ToolbarClick_Top(true);
            //////////pMain._Home_ToolbarClick_Top(false);


            #endregion
            

            #region Plan 2 - Funding - update 2016 - update_val_date Node

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName2);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            _gLib._MsgBox("Manual Step!", "Please manually select on Plan2_FundingValuation in Home page tree view!");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "update 2016");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("update 2016");


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
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "SalPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "Click");
            dic.Add("CashBanlance", "CashBalAccount");
            dic.Add("Pension", "PVinact");
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
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("update 2016");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete with 7 NP", true);


            pMain._SelectTab("update 2016");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputPlan2_update2016_updatevaldate, "Liability Scenario", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputPlan2_update2016_updatevaldate, "Liability Scenario by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPlan2_update2016_updatevaldate, "Valuation Summary", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_update2016_updatevaldate, "Individual Output", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_update2016_updatevaldate, "IOE", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_update2016_updatevaldate, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_update2016_updatevaldate, "Payout Projection", "Conversion", true, true);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_update2016_updatevaldate, "Age Service Matrix", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputPlan2_update2016_updatevaldate, "Reconciliation to Baseline", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputPlan2_update2016_updatevaldate, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPlan2_update2016_updatevaldate, "Liabilities Detailed Results", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPlan2_update2016_updatevaldate, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_update2016_updatevaldate, "Liability Set for FSM Export", "RollForward", true, false);


            thrd_Plan2_update2016_updatevaldate.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion
            
            #region Plan 2 - Funding - update 2016 - NDT Node

            pMain._SelectTab("update 2016");


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
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("SelectRecords", "$emp.SalPriorYear1 > 1");
            dic.Add("Validate", "Click");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("update 2016");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);   //#116431 related to this node


            pMain._SelectTab("update 2016");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            //////////pOutputManager._Navigate("Plan Aggregation", "RollForward", true);

            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("NoAggregation", "");
            //////////dic.Add("SamePlansIncluded", "True");
            //////////dic.Add("PlansDiffer", "");
            //////////dic.Add("UpdateAggregation", "");
            //////////dic.Add("Close", "");
            //////////pOutputManager._PopVerify_PlanAggregation(dic);


            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sPlanName);
            //////////dic.Add("Level_2", "FundingValuations");
            //////////dic.Add("Level_3", "NDT 2016");
            //////////dic.Add("Level_4", "Copy of PFVS");
            //////////pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);


            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sPlanName2);
            //////////dic.Add("Level_2", "FundingValuations");
            //////////dic.Add("Level_3", "update 2016");
            //////////dic.Add("Level_4", "NDT");
            //////////pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);


            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("UpdateAggregation", "Click");
            //////////dic.Add("Close", "Click");
            //////////pOutputManager._PopVerify_PlanAggregation(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_update2016_NDT, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_update2016_NDT, "Individual Output", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_update2016_NDT, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_update2016_NDT, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPlan2_update2016_NDT, "Coverage Test", "RollForward", true, true, dic);
            //////////_gLib._MsgBox("Manual Steps!", "Please manually open General Summary report tab then check off the check box \"CreateARateGroupForEachHCE\"");
            //////////_gLib._MsgBox("Manual Steps!", "Please manually download the only 4 General Test PDF reports : Summary; Current Testing Accrual Rates; Current and Prior Testing Accrual Rates; Current, Prior and Future Testing Accrual Rates");
            dic.Clear();
            dic.Add("CreateARateGroupForEachHCE", "False");
            dic.Add("GroupRates", "True");
            dic.Add("ForNormalAccrualRate", "");
            dic.Add("ForMostValuableAccrualRate", "");
            dic.Add("HighlyCompensated", "");
            dic.Add("NonHighlyCompensated", "");
            pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_update2016_NDT, "General Test", "RollForward", true, true, false, false, false, true, true, true, dic);
            pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_update2016_NDT, "General Test", "RollForward", false, true, false, false, false, true, true, true, dic);
            

            thrd_Plan2_update2016_NDT.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion
            
            
            #region Plan 2 - Funding - NDT 2016 EOY and 2017 - Baseline Node

            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName2);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);


            _gLib._MsgBox("Manual Step!", "Please manually select on Plan2_FundingValuation in Home page tree view!");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "NDT 2016 EOY and 2017");
            pMain._PopVerify_Home_RightPane(dic);



            pMain._SelectTab("NDT 2016 EOY and 2017");


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
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("SelectRecords", "$emp.DivisionCode != \"D\" and $emp.DivisionCode != \"S\"");
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
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2016 EOY and 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            //////////pOutputManager._Navigate("Plan Aggregation", "RollForward", true);

            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("NoAggregation", "");
            //////////dic.Add("SamePlansIncluded", "True");
            //////////dic.Add("PlansDiffer", "");
            //////////dic.Add("UpdateAggregation", "");
            //////////dic.Add("Close", "");
            //////////pOutputManager._PopVerify_PlanAggregation(dic);


            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sPlanName);
            //////////dic.Add("Level_2", "FundingValuations");
            //////////dic.Add("Level_3", "NDT 2017");
            //////////dic.Add("Level_4", "Baseline");
            //////////pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);


            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sPlanName2);
            //////////dic.Add("Level_2", "FundingValuations");
            //////////dic.Add("Level_3", "NDT 2016 EOY and 2017");
            //////////dic.Add("Level_4", "Baseline");
            //////////pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);


            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("UpdateAggregation", "Click");
            //////////dic.Add("Close", "Click");
            //////////pOutputManager._PopVerify_PlanAggregation(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_Baseline, "Individual Output", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_Baseline, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_Baseline, "Coverage Test", "RollForward", true, true, dic);
            ////////_gLib._MsgBox("Manual Steps!", "Please manually open General Summary report tab then check off the check box \"CreateARateGroupForEachHCE\"");
            ////////_gLib._MsgBox("Manual Steps!", "Please manually download the only 4 General Test PDF reports : Summary; Current Testing Accrual Rates; Current and Prior Testing Accrual Rates; Current, Prior and Future Testing Accrual Rates");
            dic.Clear();
            dic.Add("CreateARateGroupForEachHCE", "False");
            dic.Add("GroupRates", "True");
            dic.Add("ForNormalAccrualRate", "");
            dic.Add("ForMostValuableAccrualRate", "");
            dic.Add("HighlyCompensated", "");
            dic.Add("NonHighlyCompensated", "");
            pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_NDT2016EOYand2017_Baseline, "General Test", "RollForward", true, true, false, false, false, true, true, true, dic);
            pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_NDT2016EOYand2017_Baseline, "General Test", "RollForward", false, true, false, false, false, true, true, true, dic);


            thrd_Plan2_NDT2016EOYand2017_Baseline.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion
            
            #region Plan 2 - Funding - NDT 2016 EOY and 2017 - DC_Only Node

            pMain._SelectTab("NDT 2016 EOY and 2017");


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


            pMain._SelectTab("NDT 2016 EOY and 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2016 EOY and 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            //////////pOutputManager._Navigate("Plan Aggregation", "RollForward", true);

            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("NoAggregation", "");
            //////////dic.Add("SamePlansIncluded", "True");
            //////////dic.Add("PlansDiffer", "");
            //////////dic.Add("UpdateAggregation", "");
            //////////dic.Add("Close", "");
            //////////pOutputManager._PopVerify_PlanAggregation(dic);


            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sPlanName);
            //////////dic.Add("Level_2", "FundingValuations");
            //////////dic.Add("Level_3", "NDT 2017");
            //////////dic.Add("Level_4", "DC Only");
            //////////pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);


            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sPlanName2);
            //////////dic.Add("Level_2", "FundingValuations");
            //////////dic.Add("Level_3", "NDT 2016 EOY and 2017");
            //////////dic.Add("Level_4", "DC Only");
            //////////pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);


            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("UpdateAggregation", "Click");
            //////////dic.Add("Close", "Click");
            //////////pOutputManager._PopVerify_PlanAggregation(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_DCOnly, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_DCOnly, "Individual Output", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_DCOnly, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_DCOnly, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_DCOnly, "Coverage Test", "RollForward", true, true, dic);
            ////////_gLib._MsgBox("Manual Steps!", "Please manually download the only 3 General Test PDF reports : Summary; Current Testing for each HCE; Current Testing Accrual Rates");
            pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_NDT2016EOYand2017_DCOnly, "General Test", "RollForward", true, true, true, false, false, true, false, false, dic);
            pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_NDT2016EOYand2017_DCOnly, "General Test", "RollForward", false, true, true, false, false, true, false, false, dic);


            thrd_Plan2_NDT2016EOYand2017_DCOnly.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion
            
            #region Plan 2 - Funding - NDT 2016 EOY and 2017 - DB_Only Node

            pMain._SelectTab("NDT 2016 EOY and 2017");


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


            pMain._SelectTab("NDT 2016 EOY and 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2016 EOY and 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            //////////pOutputManager._Navigate("Plan Aggregation", "RollForward", true);

            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("NoAggregation", "");
            //////////dic.Add("SamePlansIncluded", "True");
            //////////dic.Add("PlansDiffer", "");
            //////////dic.Add("UpdateAggregation", "");
            //////////dic.Add("Close", "");
            //////////pOutputManager._PopVerify_PlanAggregation(dic);


            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sPlanName);
            //////////dic.Add("Level_2", "FundingValuations");
            //////////dic.Add("Level_3", "NDT 2017");
            //////////dic.Add("Level_4", "DB Only");
            //////////pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);


            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sPlanName2);
            //////////dic.Add("Level_2", "FundingValuations");
            //////////dic.Add("Level_3", "NDT 2016 EOY and 2017");
            //////////dic.Add("Level_4", "DB Only");
            //////////pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);


            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("UpdateAggregation", "Click");
            //////////dic.Add("Close", "Click");
            //////////pOutputManager._PopVerify_PlanAggregation(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_DBOnly, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_DBOnly, "Individual Output", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_DBOnly, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_DBOnly, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_DBOnly, "Coverage Test", "RollForward", true, true, dic);
            ////////_gLib._MsgBox("Manual Steps!", "Please manually open General Summary report tab then check off the check box \"CreateARateGroupForEachHCE\"");
            ////////_gLib._MsgBox("Manual Steps!", "Please manually download the only 4 General Test PDF reports : Summary; Current Testing Accrual Rates; Current and Prior Testing Accrual Rates; Current, Prior and Future Testing Accrual Rates");
            dic.Clear();
            dic.Add("CreateARateGroupForEachHCE", "False");
            dic.Add("GroupRates", "True");
            dic.Add("ForNormalAccrualRate", "");
            dic.Add("ForMostValuableAccrualRate", "");
            dic.Add("HighlyCompensated", "");
            dic.Add("NonHighlyCompensated", "");
            pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_NDT2016EOYand2017_DBOnly, "General Test", "RollForward", true, true, false, false, false, true, true, true, dic);
            pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_NDT2016EOYand2017_DBOnly, "General Test", "RollForward", false, true, false, false, false, true, true, true, dic);


            thrd_Plan2_NDT2016EOYand2017_DBOnly.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);
            

            #endregion
            
            #region Plan 2 - Funding - NDT 2016 EOY and 2017 - run_only_NHCEs Node

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


            //////////pOutputManager._Navigate("Plan Aggregation", "RollForward", true);

            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("NoAggregation", "");
            //////////dic.Add("SamePlansIncluded", "");
            //////////dic.Add("PlansDiffer", "True");
            //////////dic.Add("UpdateAggregation", "");
            //////////dic.Add("Close", "");
            //////////pOutputManager._PopVerify_PlanAggregation(dic);


            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sPlanName);
            //////////dic.Add("Level_2", "FundingValuations");
            //////////dic.Add("Level_3", "NDT 2017");
            //////////dic.Add("Level_4", "DB Only");
            //////////pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);

            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sPlanName2);
            //////////dic.Add("Level_2", "FundingValuations");
            //////////dic.Add("Level_3", "NDT 2016 EOY and 2017");
            //////////dic.Add("Level_4", "DC Only");
            //////////pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);

            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sPlanName);
            //////////dic.Add("Level_2", "FundingValuations");
            //////////dic.Add("Level_3", "NDT 2016");
            //////////dic.Add("Level_4", "Copy of PFVS");
            //////////pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);

            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sPlanName);
            //////////dic.Add("Level_2", "FundingValuations");
            //////////dic.Add("Level_3", "NDT 2017");
            //////////dic.Add("Level_4", "Baseline");
            //////////pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);

            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sPlanName);
            //////////dic.Add("Level_2", "FundingValuations");
            //////////dic.Add("Level_3", "NDT 2017");
            //////////dic.Add("Level_4", "DC Only");
            //////////pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);

            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sPlanName);
            //////////dic.Add("Level_2", "FundingValuations");
            //////////dic.Add("Level_3", "NDT 2017");
            //////////dic.Add("Level_4", "DB Only");
            //////////pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);

            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sPlanName);
            //////////dic.Add("Level_2", "FundingValuations");
            //////////dic.Add("Level_3", "NDT 2017");
            //////////dic.Add("Level_4", "DB and DC Prospective");
            //////////pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);

            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sPlanName2);
            //////////dic.Add("Level_2", "FundingValuations");
            //////////dic.Add("Level_3", "NDT 2016 EOY and 2017");
            //////////dic.Add("Level_4", "Baseline");
            //////////pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);


            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sPlanName2);
            //////////dic.Add("Level_2", "FundingValuations");
            //////////dic.Add("Level_3", "NDT 2016 EOY and 2017");
            //////////dic.Add("Level_4", "DC Only");
            //////////pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);


            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sPlanName2);
            //////////dic.Add("Level_2", "FundingValuations");
            //////////dic.Add("Level_3", "NDT 2016 EOY and 2017");
            //////////dic.Add("Level_4", "DB Only");
            //////////pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);


            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sPlanName2);
            //////////dic.Add("Level_2", "FundingValuations");
            //////////dic.Add("Level_3", "NDT 2016 EOY and 2017");
            //////////dic.Add("Level_4", "run only NHCEs");
            //////////pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);


            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sPlanName2);
            //////////dic.Add("Level_2", "FundingValuations");
            //////////dic.Add("Level_3", "update 2016");
            //////////dic.Add("Level_4", "NDT");
            //////////pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);


            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("UpdateAggregation", "Click");
            //////////dic.Add("Close", "Click");
            //////////pOutputManager._PopVerify_PlanAggregation(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "Individual Output", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "IOE", "RollForward", false, true);
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("HighlyCompensated", "100");
            dic.Add("NonHighlyCompensated", "1,000");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "Coverage Test", "RollForward", true, true, dic);
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CreateARateGroupForEachHCE", "");
            dic.Add("GroupRates", "");
            dic.Add("ForNormalAccrualRate", "");
            dic.Add("ForMostValuableAccrualRate", "");
            dic.Add("HighlyCompensated", "200");
            dic.Add("NonHighlyCompensated", "2,000");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "General Test", "RollForward", true, true, dic);


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017Cloud", sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs_Prod, sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan2_NDT2016EOYand2017_runonlyNHCEs");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0);
            }


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("NDT 2016 EOY and 2017");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            _gLib._MsgBox("Congratulations!", "Finished!");


            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }
        

        void t_CompareRpt_Plan1_NDT2016_Baseline(string sOutputPlan1_NDT2016_Baseline)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017Cloud", sOutputPlan1_NDT2016_Baseline_Prod, sOutputPlan1_NDT2016_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan1_NDT2016_Baseline");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0, true);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        void t_CompareRpt_Plan1_NDT2017_Baseline(string sOutputPlan1_NDT2017_Baseline)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017Cloud", sOutputPlan1_NDT2017_Baseline_Prod, sOutputPlan1_NDT2017_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan1_NDT2017_Baseline");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        void t_CompareRpt_Plan1_NDT2017_DCOnly(string sOutputPlan1_NDT2017_DCOnly)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017Cloud", sOutputPlan1_NDT2017_DCOnly_Prod, sOutputPlan1_NDT2017_DCOnly);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan1_NDT2017_DCOnly");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0, true);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0, true);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        void t_CompareRpt_Plan1_NDT2017_DBOnly(string sOutputPlan1_NDT2017_DBOnly)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017Cloud", sOutputPlan1_NDT2017_DBOnly_Prod, sOutputPlan1_NDT2017_DBOnly);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan1_NDT2017_DBOnly");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
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
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017Cloud", sOutputPlan1_NDT2017_DBandDCProspective_Prod, sOutputPlan1_NDT2017_DBandDCProspective);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan1_NDT2017_DBandDCProspective");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
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

        void t_CompareRpt_Plan2_conversion2016_Baseline(string sOutputPlan2_conversion2016_Baseline)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017Cloud", sOutputPlan2_conversion2016_Baseline_Prod, sOutputPlan2_conversion2016_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan2_conversion2016_CopyofPFV");
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
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        void t_CompareRpt_Plan2_update2016_updatevaldate(string sOutputPlan2_update2016_updatevaldate)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017Cloud", sOutputPlan2_update2016_updatevaldate_Prod, sOutputPlan2_update2016_updatevaldate);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan2_update2016_updatevaldate");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix_2.xlsx", 4, 0, 0, 0);
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
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforFSMExport.xls", 4, 0, 0, 0, true);
                Config.bThreadFinsihed = true;
            }
        }

        void t_CompareRpt_Plan2_update2016_NDT(string sOutputPlan2_update2016_NDT)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017Cloud", sOutputPlan2_update2016_NDT_Prod, sOutputPlan2_update2016_NDT);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan2_update2016_NDT");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0, true);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0, true);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        void t_CompareRpt_Plan2_NDT2016EOYand2017_Baseline(string sOutputPlan2_NDT2016EOYand2017_Baseline)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017Cloud", sOutputPlan2_NDT2016EOYand2017_Baseline_Prod, sOutputPlan2_NDT2016EOYand2017_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan2_NDT2016EOYand2017_Baseline");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0, true);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0, true);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        void t_CompareRpt_Plan2_NDT2016EOYand2017_DCOnly(string sOutputPlan2_NDT2016EOYand2017_DCOnly)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017Cloud", sOutputPlan2_NDT2016EOYand2017_DCOnly_Prod, sOutputPlan2_NDT2016EOYand2017_DCOnly);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan2_NDT2016EOYand2017_DCOnly");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0, true);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0, true);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        void t_CompareRpt_Plan2_NDT2016EOYand2017_DBOnly(string sOutputPlan2_NDT2016EOYand2017_DBOnly)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017Cloud", sOutputPlan2_NDT2016EOYand2017_DBOnly_Prod, sOutputPlan2_NDT2016EOYand2017_DBOnly);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan2_NDT2016EOYand2017_DBOnly");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0, true);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0, true);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
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
    }
}
