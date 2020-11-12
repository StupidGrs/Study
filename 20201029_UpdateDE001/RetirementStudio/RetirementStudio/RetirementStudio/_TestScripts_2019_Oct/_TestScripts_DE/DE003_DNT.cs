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



namespace RetirementStudio._TestScripts_2019_Oct_DE
{
    /// <summary>
    /// Summary description for DE003_DNT
    /// </summary>
    [CodedUITest]
    public class DE003_DNT
    {
        public DE003_DNT()
        {

            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.DE;
            Config.sClientName = "QA DE Benchmark 003 Existing DNT";
            Config.sPlanName = "QA DE Benchmark 003 Existing DNT Plan";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }


        #region Report Output Directory


        public string sOutputPension_Conversion2008 = "";
        public string sOutputPension_Pension2009_Baseline = "";
        public string sOutputPension_Pension2009_UseMNTelFromSystem = "";
        public string sOutputPension_Pension2009_InterestSensitivity56 = "";
        public string sOutputPension_Pension2009_InterestSensitivity66 = "";
        public string sOutputPension_Pension2009_PaySensitivity25 = "";
        public string sOutputPension_Pension2009_PaySensitivity35 = "";
        public string sOutputPension_Pension2009_PensionSensitivity15 = "";
        public string sOutputPension_Pension2009_PensionSensitivity25 = "";
        public string sOutputJubilee_Conversion2008 = "";
        public string sOutputJubilee_Jubilee2009 = "";


        public string sOutputPension_Conversion2008_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_003\Production\Val\Pension\Conversion2008\7.2_20180318_B\";
        public string sOutputPension_Pension2009_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_003\Production\Val\Pension\Valuation2009\Baseline\7.2_20180318_B\";
        public string sOutputPension_Pension2009_UseMNTelFromSystem_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_003\Production\Val\Pension\Valuation2009\Use MNTel from system\7.2_20180318_B\";
        public string sOutputPension_Pension2009_InterestSensitivity56_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_003\Production\Val\Pension\Valuation2009\InterestSensitivity 5.6%\7.2_20180318_B\";
        public string sOutputPension_Pension2009_InterestSensitivity66_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_003\Production\Val\Pension\Valuation2009\InterestSensitivity 6.6%\7.2_20180318_B\";
        public string sOutputPension_Pension2009_PaySensitivity25_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_003\Production\Val\Pension\Valuation2009\PaySensitivity 2.5%\7.2_20180318_B\";
        public string sOutputPension_Pension2009_PaySensitivity35_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_003\Production\Val\Pension\Valuation2009\PaySensitivity 3.5%\7.2_20180318_B\";
        public string sOutputPension_Pension2009_PensionSensitivity15_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_003\Production\Val\Pension\Valuation2009\PensionSensitivity 1.5%\7.2_20180318_B\";
        public string sOutputPension_Pension2009_PensionSensitivity25_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_003\Production\Val\Pension\Valuation2009\PensionSensitivity 2.5%\7.2_20180318_B\";
        public string sOutputJubilee_Conversion2008_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_003\Production\Val\Jubilee\Conversion2008\7.2_20180318_B\";
        public string sOutputJubilee_Jubilee2009_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_003\Production\Val\Jubilee\Jubilee2009\7.2_20180318_B\";


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

                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_003\Existing\Val\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputPension_Conversion2008 = _gLib._CreateDirectory(sMainDir + "Pension\\Conversion2008\\" + sPostFix + "\\");
                    sOutputPension_Pension2009_Baseline = _gLib._CreateDirectory(sMainDir + "Pension\\Valuation2009\\Baseline\\" + sPostFix + "\\");
                    sOutputPension_Pension2009_UseMNTelFromSystem = _gLib._CreateDirectory(sMainDir + "Pension\\Valuation2009\\Use MNTel from system\\" + sPostFix + "\\");
                    sOutputPension_Pension2009_InterestSensitivity56 = _gLib._CreateDirectory(sMainDir + "Pension\\Valuation2009\\InterestSensitivity 5.6%\\" + sPostFix + "\\");
                    sOutputPension_Pension2009_InterestSensitivity66 = _gLib._CreateDirectory(sMainDir + "Pension\\Valuation2009\\InterestSensitivity 6.6%\\" + sPostFix + "\\");
                    sOutputPension_Pension2009_PaySensitivity25 = _gLib._CreateDirectory(sMainDir + "Pension\\Valuation2009\\PaySensitivity 2.5%\\" + sPostFix + "\\");
                    sOutputPension_Pension2009_PaySensitivity35 = _gLib._CreateDirectory(sMainDir + "Pension\\Valuation2009\\PaySensitivity 3.5%\\" + sPostFix + "\\");
                    sOutputPension_Pension2009_PensionSensitivity15 = _gLib._CreateDirectory(sMainDir + "Pension\\Valuation2009\\PensionSensitivity 1.5%\\" + sPostFix + "\\");
                    sOutputPension_Pension2009_PensionSensitivity25 = _gLib._CreateDirectory(sMainDir + "Pension\\Valuation2009\\PensionSensitivity 2.5%\\" + sPostFix + "\\");
                    sOutputJubilee_Conversion2008 = _gLib._CreateDirectory(sMainDir + "Jubilee\\Conversion2008\\" + sPostFix + "\\");
                    sOutputJubilee_Jubilee2009 = _gLib._CreateDirectory(sMainDir + "Jubilee\\Jubilee2009\\" + sPostFix + "\\");


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

                string sMainDir = sDir + "DE003_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputPension_Conversion2008 = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Conversion2008\\");
                sOutputPension_Pension2009_Baseline = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Pension2009_Baseline\\");
                sOutputPension_Pension2009_UseMNTelFromSystem = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Pension2009_UseMNTelFromSystem\\");
                sOutputPension_Pension2009_InterestSensitivity56 = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Pension2009_InterestSensitivity56\\");
                sOutputPension_Pension2009_InterestSensitivity66 = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Pension2009_InterestSensitivity66\\");
                sOutputPension_Pension2009_PaySensitivity25 = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Pension2009_PaySensitivity25\\");
                sOutputPension_Pension2009_PaySensitivity35 = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Pension2009_PaySensitivity35\\");
                sOutputPension_Pension2009_PensionSensitivity15 = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Pension2009_PensionSensitivity15\\");
                sOutputPension_Pension2009_PensionSensitivity25 = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Pension2009_PensionSensitivity25\\");
                sOutputJubilee_Conversion2008 = _gLib._CreateDirectory(sMainDir + "\\sOutputJubilee_Conversion2008\\");
                sOutputJubilee_Jubilee2009 = _gLib._CreateDirectory(sMainDir + "\\sOutputJubilee_Jubilee2009\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputPension_Conversion2008 = @\"" + sOutputPension_Conversion2008 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Pension2009_Baseline = @\"" + sOutputPension_Pension2009_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Pension2009_UseMNTelFromSystem = @\"" + sOutputPension_Pension2009_UseMNTelFromSystem + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Pension2009_InterestSensitivity56 = @\"" + sOutputPension_Pension2009_InterestSensitivity56 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Pension2009_InterestSensitivity66 = @\"" + sOutputPension_Pension2009_InterestSensitivity66 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Pension2009_PaySensitivity25 = @\"" + sOutputPension_Pension2009_PaySensitivity25 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Pension2009_PaySensitivity35 = @\"" + sOutputPension_Pension2009_PaySensitivity35 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Pension2009_PensionSensitivity15 = @\"" + sOutputPension_Pension2009_PensionSensitivity15 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Pension2009_PensionSensitivity25 = @\"" + sOutputPension_Pension2009_PensionSensitivity25 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Conversion2008 = @\"" + sOutputJubilee_Conversion2008 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Jubilee2009 = @\"" + sOutputJubilee_Jubilee2009 + "\";" + Environment.NewLine;
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
        public void test_DE003_DNT()
        {


            #region MultiThreads

            Thread Thrd_Conversion2008 = new Thread(() => new DE003_DNT().t_CompareRpt_Conversion2008(sOutputPension_Conversion2008));
            Thread Thrd_Pension2009_PensionSensitivity15 = new Thread(() => new DE003_DNT().t_CompareRpt_Pension2009_PensionSensitivity15(sOutputPension_Pension2009_PensionSensitivity15));
            Thread Thrd_Jubilee_Conversion2008 = new Thread(() => new DE003_DNT().t_CompareRpt_Jubilee_Conversion2008(sOutputJubilee_Conversion2008));

            #endregion


            this.GenerateReportOuputDir();


            #region sOutputPension_Conversion2008

            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "PensionValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Conversion 2008");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Conversion 2008");

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
            dic.Add("ApplyWithdrawalAdjustment", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "True");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "NetPayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "False");
            dic.Add("UseReportBreaks", "False");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "Pen1");
            dic.Add("SelectVOs_VO2", "Pen2");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Conversion 2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Conversion 2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Conversion2008, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Conversion2008, "Parameter Summary", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Conversion2008, "Test Cases", "Conversion", true, true);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Conversion2008, "Liability Summary", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2008, "Member Statistics", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Conversion2008, "Conversion Diagnostic", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2008, "Test Case List", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2008, "Detailed Results", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2008, "Detailed Results by Plan Def", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2008, "Valuation Summary", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2008, "Valuation Summary for Excel Export", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Conversion2008, "Individual Output", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Conversion2008, "IOE", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Conversion2008, "Payout Projection", "Conversion", false, true);

            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Conversion2008, "Member Statistics", "Conversion", false, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Conversion2008, "Valuation Summary", "Conversion", false, true, 0, new string[1] { "ALL" });
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Conversion2008, "Payout Projection", "Conversion", false, true, dic);


            Thrd_Conversion2008.Start();

            pMain._SelectTab("Conversion 2008");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region sOutputPension_Pension2009_PensionSensitivity15

            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Pension 2009");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Pension 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "734");
            dic.Add("iPosY", "208");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "True");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "NetPayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "False");
            dic.Add("UseReportBreaks", "False");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "True");
            dic.Add("SelectVOs_VO1", "");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Pension 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "734");
            dic.Add("iPosY", "208");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Pension 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "734");
            dic.Add("iPosY", "208");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Output Manager");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "True");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "Click");
            dic.Add("AddAll", "");
            dic.Add("Node", "Baseline");
            dic.Add("Add", "Click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PensionSensitivity1.5%");
            dic.Add("Add", "Click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PensionSensitivity2.5%");
            dic.Add("Add", "Click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "Click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009_PensionSensitivity15, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009_PensionSensitivity15, "Parameter Summary", "RollForward", true, true);
            ////pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009_PensionSensitivity15, "Test Cases", "Conversion", true, true);

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009_PensionSensitivity15, "Liability Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009_PensionSensitivity15, "Liability Scenario by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009_PensionSensitivity15, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009_PensionSensitivity15, "Valuation Summary for Excel Export", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009_PensionSensitivity15, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009_PensionSensitivity15, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009_PensionSensitivity15, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009_PensionSensitivity15, "FAS Expected Benefit Pmts", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009_PensionSensitivity15, "Valuation Summary", "RollForward", false, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009_PensionSensitivity15, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009_PensionSensitivity15, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[1] { "ALL" });
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009_PensionSensitivity15, "Payout Projection", "RollForward", false, true, dic);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009_PensionSensitivity15, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009_PensionSensitivity15, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009_PensionSensitivity15, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009_PensionSensitivity15, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);


            Thrd_Pension2009_PensionSensitivity15.Start();

            pMain._SelectTab("Pension 2009");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region sOutputJubilee_Conversion2008

            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "JubileeValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Conversion 2008");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Conversion 2008");


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
            dic.Add("ApplyWithdrawalAdjustment", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "False");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "JubiPayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "False");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "Jub1");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Conversion 2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Conversion 2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputJubilee_Conversion2008, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputJubilee_Conversion2008, "Parameter Summary", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Conversion2008, "Test Cases", "Conversion", true, true);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputJubilee_Conversion2008, "Liability Summary", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputJubilee_Conversion2008, "Member Statistics", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputJubilee_Conversion2008, "Conversion Diagnostic", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputJubilee_Conversion2008, "Test Case List", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputJubilee_Conversion2008, "Detailed Results", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputJubilee_Conversion2008, "Detailed Results by Plan Def", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputJubilee_Conversion2008, "Valuation Summary", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputJubilee_Conversion2008, "Valuation Summary for Excel Export", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputJubilee_Conversion2008, "Individual Output", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputJubilee_Conversion2008, "IOE", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Conversion2008, "Payout Projection", "Conversion", false, true);

            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Conversion2008, "Member Statistics", "Conversion", false, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Conversion2008, "Valuation Summary", "Conversion", false, true, 0, new string[1] { "ALL" });
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputJubilee_Conversion2008, "Payout Projection", "Conversion", false, true, dic);


            Thrd_Jubilee_Conversion2008.Start();

            pMain._SelectTab("Conversion 2008");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion



            #region sOutputJubilee_Jubilee2009


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Jubilee 2009");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Jubilee 2009");

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
            dic.Add("ApplyWithdrawalAdjustment", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "True");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "JubiPayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "False");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "Jub1");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Jubilee 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Jubilee 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009, "Parameter Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009, "Test Cases", "Conversion", true, true);

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009, "Reconciliation to Prior Year", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009, "Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009, "Member Statistics", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009, "Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009, "Individual Checking Template", "RollForward", false, true, 0, new string[1] { "Jub1" });
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009, "Valuation Summary for Excel Export", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009, "Member Statistics", "RollForward", false, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009, "Valuation Summary", "RollForward", false, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009, "Liability Set for Globe Export", "RollForward", false, false, 0, new string[1] { "ALL" });
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009, "Payout Projection", "RollForward", false, true, dic);


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE003DNT", sOutputJubilee_Jubilee2009_Prod, sOutputJubilee_Jubilee2009);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputJubilee_Jubilee2009");
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_ALL.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" }, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" }, true);

                _compareReportsLib.CompareExcel_Exact("ValuationSummary_ALL.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                //////////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0 ,true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_ALL.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport.xlsx", 4, 0, 0, 0, true);

            }


            pMain._SelectTab("Jubilee 2009");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            _gLib._MsgBox("Congratulations!", "Finished!");

        }


        public void t_CompareRpt_Conversion2008(string sOutputPension_Conversion2008)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE003DNT", sOutputPension_Conversion2008_Prod, sOutputPension_Conversion2008);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Conversion2008");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_ALL.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" });

                _compareReportsLib.CompareExcel_Exact("ValuationSummary_ALL.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                //////////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        public void t_CompareRpt_Pension2009_PensionSensitivity15(string sOutputPension_Pension2009_PensionSensitivity15)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE003DNT", sOutputPension_Pension2009_PensionSensitivity15_Prod, sOutputPension_Pension2009_PensionSensitivity15);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Pension2009_PensionSensitivity15");

                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" });

                _compareReportsLib.CompareExcel_Exact("ValuationSummary_ALL.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                //////////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_ALL.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        public void t_CompareRpt_Jubilee_Conversion2008(string sOutputJubilee_Conversion2008)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE003DNT", sOutputJubilee_Conversion2008_Prod, sOutputJubilee_Conversion2008);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputJubilee_Conversion2008");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_ALL.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" });

                _compareReportsLib.CompareExcel_Exact("ValuationSummary_ALL.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                //////////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
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
