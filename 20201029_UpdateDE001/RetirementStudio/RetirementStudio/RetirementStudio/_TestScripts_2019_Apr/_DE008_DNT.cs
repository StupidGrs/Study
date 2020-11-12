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
    public class _DE008_DNT
    {
        public _DE008_DNT()
        {
            Config.eEnv = _TestingEnv.QA2;
            Config.eCountry = _Country.DE;
            Config.sClientName = "QA DE Benchmark 008 Existing DNT";
            Config.sPlanName = "QA DE Benchmark 008 Existing DNT Plan";
            Config.sProductionVerison = "7.4.1";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }


        #region Report Output Directory

        public string sOutputPension_Conversion2009 = "";
        public string sOutputPension_Stichtag2010_Baseline = "";
        public string sOutputPension_Stichtag2010_PreliminaryAssumptions = "";
        public string sOutputPension_Stichtag2011_Baseline = "";
        public string sOutputPension_Stichtag2011_InterestSensitivityMINUS = "";
        public string sOutputPension_Stichtag2011_InterestSensitivityPLUS = "";

        public string sOutputPension_Conversion2009_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Production\Conversion2009\7.3.2_20181130_B\";
        public string sOutputPension_Stichtag2010_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Production\Stichtag2010\Baseline\7.3.2_20181130_B\";
        public string sOutputPension_Stichtag2010_PreliminaryAssumptions_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Production\Stichtag2010\PreliminaryAssumptions\7.3.2_20181130_B\";
        public string sOutputPension_Stichtag2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Existing DNT\Val\Stichtag 2011\Baseline\000_7.4_Baseline\";
        public string sOutputPension_Stichtag2011_InterestSensitivityMINUS_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Existing DNT\Val\Stichtag 2011\Interest Sensitivity MINUS0.5%\000_7.4_Baseline\";
        public string sOutputPension_Stichtag2011_InterestSensitivityPLUS_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Existing DNT\Val\Stichtag 2011\Interest Sensitivity PLUS0.5%\000_7.4_Baseline\";


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


                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Existing DNT\Val\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputPension_Conversion2009 = _gLib._CreateDirectory(sMainDir + "Conversion 2009\\" + sPostFix + "\\");
                    sOutputPension_Stichtag2010_Baseline = _gLib._CreateDirectory(sMainDir + "Stichtag 2010\\Baseline\\" + sPostFix + "\\");
                    sOutputPension_Stichtag2010_PreliminaryAssumptions = _gLib._CreateDirectory(sMainDir + "Stichtag 2010\\Preliminary Assumptions\\" + sPostFix + "\\");
                    sOutputPension_Stichtag2011_Baseline = _gLib._CreateDirectory(sMainDir + "Stichtag 2011\\Baseline\\" + sPostFix + "\\");
                    sOutputPension_Stichtag2011_InterestSensitivityMINUS = _gLib._CreateDirectory(sMainDir + "Stichtag 2011\\Interest Sensitivity MINUS0.5%\\" + sPostFix + "\\");
                    sOutputPension_Stichtag2011_InterestSensitivityPLUS = _gLib._CreateDirectory(sMainDir + "Stichtag 2011\\Interest Sensitivity PLUS0.5%\\" + sPostFix + "\\");
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

                ////sDir = sDir + "\\_TestLog\\";

                string sMainDir = sDir + "DE008_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputPension_Conversion2009 = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Conversion2009\\");
                sOutputPension_Stichtag2010_Baseline = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Stichtag2010_Baseline\\");
                sOutputPension_Stichtag2010_PreliminaryAssumptions = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Stichtag2010_PreliminaryAssumptions\\");
                sOutputPension_Stichtag2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Stichtag2011_Baseline\\");
                sOutputPension_Stichtag2011_InterestSensitivityMINUS = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Stichtag2011_InterestSensitivityMINUS\\");
                sOutputPension_Stichtag2011_InterestSensitivityPLUS = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Stichtag2011_InterestSensitivityPLUS\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputPension_Conversion2009 = @\"" + sOutputPension_Conversion2009 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Stichtag2010_Baseline = @\"" + sOutputPension_Stichtag2010_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Stichtag2010_PreliminaryAssumptions = @\"" + sOutputPension_Stichtag2010_PreliminaryAssumptions + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Stichtag2011_Baseline = @\"" + sOutputPension_Stichtag2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Stichtag2011_InterestSensitivityMINUS = @\"" + sOutputPension_Stichtag2011_InterestSensitivityMINUS + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Stichtag2011_InterestSensitivityPLUS = @\"" + sOutputPension_Stichtag2011_InterestSensitivityPLUS + "\";" + Environment.NewLine;
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
        public void _test_DE008_DNT()
        {



            //sOutputPension_Conversion2009 = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Existing DNT\Val\Conversion 2009\";
            //sOutputPension_Stichtag2010_Baseline = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Existing DNT\Val\Stichtag 2010\Baseline\";
            //sOutputPension_Stichtag2010_PreliminaryAssumptions = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Existing DNT\Val\Stichtag 2010\Preliminary Assumptions\";
            sOutputPension_Stichtag2011_Baseline = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Existing DNT\Val\Stichtag 2011\Baseline\20190806_QA1\";
            sOutputPension_Stichtag2011_InterestSensitivityPLUS = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Existing DNT\Val\Stichtag 2011\Interest Sensitivity PLUS0.5%\20190806_QA1\";
            sOutputPension_Stichtag2011_InterestSensitivityMINUS = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Existing DNT\Val\Stichtag 2011\Interest Sensitivity MINUS0.5%\20190806_QA1\";

            //sOutputPension_Stichtag2011_InterestSensitivityMINUS_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Existing DNT\Val\Stichtag 2011\Interest Sensitivity MINUS0.5%\20190723_QA1\";




            //this.GenerateReportOuputDir();
            pMain._SetLanguageAndRegional();


            #region MultiThreads
            
            Thread thrd_Conversion2009 = new Thread(() => new _DE008_DNT().t_CompareRpt_Conversion2009(sOutputPension_Conversion2009));
            Thread thrd_Stichtag2010_Baseline = new Thread(() => new _DE008_DNT().t_CompareRpt_Stichtag2010_Baseline(sOutputPension_Stichtag2010_Baseline));
            Thread thrd_Stichtag2010_PreliminaryAssumptions = new Thread(() => new _DE008_DNT().t_CompareRpt_Stichtag2010_PreliminaryAssumptions(sOutputPension_Stichtag2010_PreliminaryAssumptions));
            Thread thrd_Stichtag2011_Baseline = new Thread(() => new _DE008_DNT().t_CompareRpt_Stichtag2011_Baseline(sOutputPension_Stichtag2011_Baseline));
            Thread thrd_Stichtag2011_InterestSensitivityPLUS = new Thread(() => new _DE008_DNT().t_CompareRpt_Stichtag2011_InterestSensitivityPLUS(sOutputPension_Stichtag2011_InterestSensitivityPLUS));
            Thread thrd_Stichtag2011_InterestSensitivityMINUS = new Thread(() => new _DE008_DNT().t_CompareRpt_Stichtag2011_InterestSensitivityMINUS(sOutputPension_Stichtag2011_InterestSensitivityMINUS));

            #endregion



            #region PensionValuation - Stichta2011 - Baseline

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "PensionValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Stichtag 2011");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Stichtag 2011");

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
            dic.Add("Pay", "PayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "true");
            dic.Add("UseReportBreaks", "True");
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


            pMain._SelectTab("Stichtag 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "");
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
            dic.Add("ShowSubtotalBreaks", "SubDivisionCode");
            dic.Add("OK", "Click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Test Cases", "Conversion", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Reconciliation to Prior Year with Breaks", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Reconciliation to Prior Year by Plan Def with Breaks", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Detailed Results", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Detailed Results with Breaks", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Detailed Results by Plan Def", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Detailed Results by Plan Def with Breaks", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Member Statistics", "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Member Statistics", "RollForward", true, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Status Reconciliation", "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Individual Checking Template", "RollForward", true, true, 0, new string[4] { "EZ05", "EZ20", "FAG", "VKAP" });
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Valuation Summary", "RollForward", true, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Valuation Summary for Excel Export", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Parameter Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Individual Output", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Payout Projection", "RollForward", true, true);
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Payout Projection", "RollForward", true, true, dic);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Direct Promise", "RollForward", true, true);

            thrd_Stichtag2011_Baseline.Start();

            pMain._SelectTab("Stichtag 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(false);
            _gLib._MsgBoxYesNo("Stichta2011 - Baseline", "Finished");

            #endregion


            #region PensionValuation - Stichta2011 - Interest Sensitivity PLUS0.5%

            pMain._SelectTab("Stichtag 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
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
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "False");
            dic.Add("UseReportBreaks", "True");
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

            pMain._SelectTab("Stichtag 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Stichtag 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "");
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
            dic.Add("ShowSubtotalBreaks", "SubDivisionCode");
            dic.Add("OK", "Click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Test Cases", "Conversion", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Valuation Summary", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Valuation Summary for Excel Export", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Individual Output", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "IOE", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Payout Projection", "RollForward", true, true);
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Payout Projection", "RollForward", true, true, dic);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
            _gLib._MsgBox("Caution", "Click the link: \"Reconciliation to Baseline\"");
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Reconciliation to Baseline", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Reconciliation to Baseline with Breaks", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Reconciliation to Baseline by Plan Def", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Liabilities Detailed Results", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Liabilities Detailed Results with Breaks", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Liabilities Detailed Results by Plan Def", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", true, true);

            thrd_Stichtag2011_InterestSensitivityPLUS.Start();

            pMain._SelectTab("Stichtag 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(false);
            _gLib._MsgBoxYesNo("Stichta2011 - Interest Sensitivity PLUS0.5%", "Finished");
            
            #endregion

            
            #region PensionValuation - Stichta2011 - Interest Sensitivity MINUS0.5%

            pMain._SelectTab("Stichtag 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
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
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "True");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "");
            dic.Add("InternationalAccountingPBO", "");
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


            pMain._SelectTab("Stichtag 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Stichtag 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "");
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
            dic.Add("ShowSubtotalBreaks", "SubDivisionCode");
            dic.Add("OK", "Click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Test Cases", "Conversion", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Valuation Summary", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Valuation Summary for Excel Export", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Parameter Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Individual Output", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "IOE", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liability Scenario", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liability Scenario with Breaks", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liability Scenario by Plan Def", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liability Scenario by Plan Def with Breaks", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Payout Projection", "RollForward", true, true);
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Payout Projection", "RollForward", true, true, dic);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
            _gLib._MsgBox("Caution", "Click the link: \"Reconciliation to Baseline\"");
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Reconciliation to Baseline with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liabilities Detailed Results with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, true);

            //thrd_Stichtag2011_InterestSensitivityMINUS.Start();

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE008DNT", sOutputPension_Stichtag2011_InterestSensitivityMINUS_Prod, sOutputPension_Stichtag2011_InterestSensitivityMINUS);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Stichtag2011_InterestSensitivityMINUS");

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 4, new int[0, 0] { }, new string[1] { "Tabellenblatt2" }, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 4, new int[0, 0] { }, new string[1] { "Tabellenblatt3" }, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_KugelfischerPlan.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_VersorgungskapitalPlan.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_KugelfischerPlan.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultswithBreaks.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDefwithBreaks.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                Config.bThreadFinsihed = true;
            }

            pMain._SelectTab("Stichtag 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);
            _gLib._MsgBoxYesNo("Stichta2011 - Interest Sensitivity MINUS0.5%", "Finished");

            #endregion


            #region  PensionValuations - Conversion 2009

            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Conversion2009, "Parameter Print", "Conversion", true, true);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Conversion2009, "Test Cases", "Conversion", true, true);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Conversion2009, "Liability Summary", "Conversion", true, true);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2009, "Member Statistics", "Conversion", true, true);
            //pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Conversion2009, "Member Statistics", "Conversion", true, false, 0, new string[3] { "IDEXEuropeGmbH_KugelfischerPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Conversion2009, "Conversion Diagnostic", "Conversion", true, true);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2009, "Test Case List", "Conversion", true, true);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2009, "Detailed Results", "Conversion", true, true);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2009, "Detailed Results by Plan Def", "Conversion", true, true);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2009, "Valuation Summary", "Conversion", true, true);
            //pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Conversion2009, "Valuation Summary", "Conversion", true, false, 0, new string[3] { "IDEXEuropeGmbH_KugelfischerPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2009, "Valuation Summary for Excel Export", "Conversion", true, true);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Conversion2009, "Parameter Summary", "Conversion", true, true);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Conversion2009, "Individual Output", "Conversion", true, true);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Conversion2009, "IOE", "Conversion", true, true);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Conversion2009, "Payout Projection", "Conversion", true, true);
            //dic.Clear();
            //dic.Add("Group_ReportBreak", "True");
            //pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Conversion2009, "Payout Projection", "Conversion", true, true, dic);

            //thrd_Conversion2009.Start();

            //pMain._SelectTab("Conversion 2009");
            //pMain._Home_ToolbarClick_Top(true);
            //pMain._Home_ToolbarClick_Top(false);
            //_gLib._MsgBoxYesNo("Conversion 2009", "Finished");

            #endregion


            #region PensionValuations - Stichtag 2010 - Baseline

            //pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Parameter Print", "RollForward", true, true);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Test Cases", "Conversion", true, true);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Reconciliation to Prior Year with Breaks", "RollForward", true, true);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", true, true);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Reconciliation to Prior Year by Plan Def with Breaks", "RollForward", true, true);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Detailed Results", "RollForward", true, true);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Detailed Results with Breaks", "RollForward", true, true);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Detailed Results by Plan Def", "RollForward", true, true);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Detailed Results by Plan Def with Breaks", "RollForward", true, true);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Member Statistics", "RollForward", true, true);
            //pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Member Statistics", "RollForward", true, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
            //pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Status Reconciliation", "RollForward", true, true);
            //pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Individual Checking Template", "RollForward", true, true, 0, new string[4] { "EZ05", "EZ20", "FAG", "VKAP" });
            //pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Valuation Summary", "RollForward", true, true);
            //pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Valuation Summary", "RollForward", true, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
            //pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Valuation Summary for Excel Export", "RollForward", true, true);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Individual Output", "RollForward", true, true);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "IOE", "RollForward", true, true);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Payout Projection", "RollForward", true, true);
            //dic.Clear();
            //dic.Add("Group_ReportBreak", "True");
            //pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Payout Projection", "RollForward", true, true, dic);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "FAS Expected Benefit Pmts", "RollForward", true, true);
            //pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
            //pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Valuation Summary", "RollForward", true, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
            //pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Parameter Summary", "RollForward", true, true);
            //pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Liability Set for Globe Export", "RollForward", true, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });

            //thrd_Stichtag2010_Baseline.Start();

            //pMain._SelectTab("Stichtag 2010");
            //pMain._Home_ToolbarClick_Top(true);
            //pMain._Home_ToolbarClick_Top(false);
            //_gLib._MsgBoxYesNo("Stichtag 2010 - Baseline", "Finished");

            #endregion


            #region PensionValuations - Stichtag 2010 - Preliminary Assumptions

            //pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Parameter Print", "RollForward", true, true);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Test Cases", "Conversion", true, true);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Scenario", "RollForward", true, true);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Scenario with Breaks", "RollForward", true, true);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Scenario by Plan Def", "RollForward", true, true);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Scenario by Plan Def with Breaks", "RollForward", true, true);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Valuation Summary", "RollForward", true, true);
            //pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Valuation Summary", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
            //pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Valuation Summary for Excel Export", "RollForward", true, true);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Parameter Summary", "RollForward", true, true);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Individual Output", "RollForward", true, true);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "IOE", "RollForward", true, true);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Payout Projection", "RollForward", true, true);
            //dic.Clear();
            //dic.Add("Group_ReportBreak", "True");
            //pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Payout Projection", "RollForward", true, true, dic);
            //pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Valuation Summary", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
            //pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
            //pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Set for Globe Export", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Reconciliation to Baseline", "RollForward", true, true);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Reconciliation to Baseline with Breaks", "RollForward", true, true);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Reconciliation to Baseline by Plan Def", "RollForward", true, true);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", true, true);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liabilities Detailed Results", "RollForward", true, true);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liabilities Detailed Results with Breaks", "RollForward", true, true);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liabilities Detailed Results by Plan Def", "RollForward", true, true);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", true, true);

            //thrd_Stichtag2010_PreliminaryAssumptions.Start();

            //pMain._SelectTab("Stichtag 2010");
            //pMain._Home_ToolbarClick_Top(true);
            //pMain._Home_ToolbarClick_Top(false);
            //_gLib._MsgBoxYesNo("Stichtag 2010 - Preliminary Assumptions", "Finished");

            #endregion

            
            _gLib._MsgBox("All", "finished ! !");


            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.

        }


        public void t_CompareRpt_Conversion2009(string sOutputPension_Conversion2009)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE008DNT", sOutputPension_Conversion2009_Prod, sOutputPension_Conversion2009);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Conversion2009");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_IDEXEuropeGmbH_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_LukasHydraulikGmbH_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_LukasHydraulikGmbH_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_IDEXEuropeGmbH_KugelfischerPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_LukasHydraulikGmbH_KugelfischerPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_LukasHydraulikGmbH_VersorgungskapitalPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                //////////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }

        }

        public void t_CompareRpt_Stichtag2010_Baseline(string sOutputPension_Stichtag2010_Baseline)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE008DNT", sOutputPension_Stichtag2010_Baseline_Prod, sOutputPension_Stichtag2010_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Stichtag2010_Baseline");

                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearWithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearWithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearWithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearWithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDefwithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDefwithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDefwithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDefwithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsWithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDefwithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_IDEXEuropeGmbH_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_IDEXEuropeGmbH_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_LukasHydraulikGmbH_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_LukasHydraulikGmbH_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_EZ05.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_EZ05.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_EZ05.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_EZ20.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_EZ20.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_EZ20.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_FAG.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_FAG.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_FAG.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_VKAP.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_VKAP.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_VKAP.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_IDEXEuropeGmbH_KugelfischerPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_IDEXEuropeGmbH_VersorgungskapitalPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_LukasHydraulikGmbH_KugelfischerPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_LukasHydraulikGmbH_VersorgungskapitalPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_IDEXEuropeGmbH_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_IDEXEuropeGmbH_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_LukasHydraulikGmbH_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_LukasHydraulikGmbH_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        public void t_CompareRpt_Stichtag2010_PreliminaryAssumptions(string sOutputPension_Stichtag2010_PreliminaryAssumptions)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE008DNT", sOutputPension_Stichtag2010_PreliminaryAssumptions_Prod, sOutputPension_Stichtag2010_PreliminaryAssumptions);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Stichtag2010_PreliminaryAssumptions");

                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_KugelfischerPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_VersorgungskapitalPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                //////////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultswithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDefwithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        public void t_CompareRpt_Stichtag2011_Baseline(string sOutputPension_Stichtag2011_Baseline)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE008DNT", sOutputPension_Stichtag2011_Baseline_Prod, sOutputPension_Stichtag2011_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Stichtag2011_Baseline");

                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearWithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearWithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearWithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearWithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDefwithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDefwithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDefwithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDefwithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsWithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDefwithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_IDEXEuropeGmbH_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_IDEXEuropeGmbH_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_LukasHydraulikGmbH_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_LukasHydraulikGmbH_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_EZ05.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_EZ05.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_EZ05.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_EZ20.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_EZ20.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_EZ20.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_FAG.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_FAG.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_FAG.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_VKAP.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_VKAP.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_VKAP.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_IDEXEuropeGmbH_KugelfischerPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_IDEXEuropeGmbH_VersorgungskapitalPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_LukasHydraulikGmbH_KugelfischerPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_LukasHydraulikGmbH_VersorgungskapitalPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_IDEXEuropeGmbH_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_IDEXEuropeGmbH_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_LukasHydraulikGmbH_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_LukasHydraulikGmbH_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        public void t_CompareRpt_Stichtag2011_InterestSensitivityPLUS(string sOutputPension_Stichtag2011_InterestSensitivityPLUS)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE008DNT", sOutputPension_Stichtag2011_InterestSensitivityPLUS_Prod, sOutputPension_Stichtag2011_InterestSensitivityPLUS);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Stichtag2011_InterestSensitivityPLUS");

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_KugelfischerPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_VersorgungskapitalPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselinewithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselinewithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselinewithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselinewithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselinebyPlanDefwithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselinebyPlanDefwithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselinebyPlanDefwithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselinebyPlanDefwithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsByPlanDef.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultswithBreaks.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDefwithBreaks.xlsx", 11, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        public void t_CompareRpt_Stichtag2011_InterestSensitivityMINUS(string sOutputPension_Stichtag2011_InterestSensitivityMINUS)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE008DNT", sOutputPension_Stichtag2011_InterestSensitivityMINUS_Prod, sOutputPension_Stichtag2011_InterestSensitivityMINUS);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Stichtag2011_InterestSensitivityMINUS");

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 4, new int[0, 0] { }, new string[1] { "Tabellenblatt2" }, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 4, new int[0, 0] { }, new string[1] { "Tabellenblatt3" }, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_KugelfischerPlan.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_VersorgungskapitalPlan.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_KugelfischerPlan.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultswithBreaks.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDefwithBreaks.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
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
