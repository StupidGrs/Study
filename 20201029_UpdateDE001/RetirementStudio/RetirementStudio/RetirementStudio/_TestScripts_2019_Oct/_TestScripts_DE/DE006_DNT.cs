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
    /// Summary description for DE006_DNT
    /// </summary>
    [CodedUITest]
    public class DE006_DNT
    {
        public DE006_DNT()
        {

            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.DE;
            Config.sClientName = "QA DE Benchmark 006 Existing DNT";
            Config.sPlanName = "QA DE Benchmark 006 Existing DNT Plan";            
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }


        #region Report Output Directory


        public string sOutputPension_Conversion2010 = "";
        public string sOutputPension_Pensionen2011_Baseline = "";
        public string sOutputPension_Pensionen2011_NewValuation = "";
        public string sOutputPension_Pensionen2011_CheckSensitivitysInIFRSRepor = "";
        public string sOutputJubilee_Conversion2010 = "";
        public string sOutputJubilee_Jubi2011_Baseline = "";
        public string sOutputJubilee_Jubi2011_NewValuation = "";

        public string sOutputPension_Conversion2010_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_006\Production\Pension\Conversion 2010\7.2_20180312_E\";
        public string sOutputPension_Pensionen2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_006\Production\Pension\Pension 2011\Baseline\7.2_20180312_E\";
        public string sOutputPension_Pensionen2011_NewValuation_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_006\Production\Pension\Pension 2011\New Valuation\7.2_20180312_E\";
        public string sOutputJubilee_Conversion2010_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_006\Production\Jubilee\Conversion 2010\7.2_20180312_E\";
        public string sOutputJubilee_Jubi2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_006\Production\Jubilee\Jubi 2011\Baseline\7.2_20180312_E\";
        public string sOutputJubilee_Jubi2011_NewValuation_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_006\Production\Jubilee\Jubi 2011\New Valuation\7.2_20180312_E\";

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

                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_006\Existing\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputPension_Conversion2010 = _gLib._CreateDirectory(sMainDir + "Pension\\Conversion 2010\\" + sPostFix + "\\");
                    sOutputPension_Pensionen2011_Baseline = _gLib._CreateDirectory(sMainDir + "Pension\\Pensionen 2011\\Baseline\\" + sPostFix + "\\");
                    sOutputPension_Pensionen2011_NewValuation = _gLib._CreateDirectory(sMainDir + "Pension\\Pensionen 2011\\New Valuation\\" + sPostFix + "\\");
                    sOutputPension_Pensionen2011_CheckSensitivitysInIFRSRepor = _gLib._CreateDirectory(sMainDir + "Pension\\Pensionen 2011\\Checking Sensitivitys in IFRS Repor\\" + sPostFix + "\\");
                    sOutputJubilee_Conversion2010 = _gLib._CreateDirectory(sMainDir + "Jubilee\\Conversion 2010\\" + sPostFix + "\\");
                    sOutputJubilee_Jubi2011_Baseline = _gLib._CreateDirectory(sMainDir + "Jubilee\\Jubi_2011\\Baseline\\" + sPostFix + "\\");
                    sOutputJubilee_Jubi2011_NewValuation = _gLib._CreateDirectory(sMainDir + "Jubilee\\Jubi_2011\\New Valuation\\" + sPostFix + "\\");
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

                string sMainDir = sDir + "DE006_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputPension_Conversion2010 = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Conversion2010\\");
                sOutputPension_Pensionen2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Pensionen2011_Baseline\\");
                sOutputPension_Pensionen2011_NewValuation = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Pensionen2011_NewValuation\\");
                sOutputJubilee_Conversion2010 = _gLib._CreateDirectory(sMainDir + "\\sOutputJubilee_Conversion2010\\");
                sOutputJubilee_Jubi2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\sOutputJubilee_Jubi2011_Baseline\\");
                sOutputJubilee_Jubi2011_NewValuation = _gLib._CreateDirectory(sMainDir + "\\sOutputJubilee_Jubi2011_NewValuation\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputPension_Conversion2010 = @\"" + sOutputPension_Conversion2010 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Pensionen2011_Baseline = @\"" + sOutputPension_Pensionen2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Pensionen2011_NewValuation = @\"" + sOutputPension_Pensionen2011_NewValuation + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Pensionen2011_CheckSensitivitysInIFRSRepor = @\"" + sOutputPension_Pensionen2011_CheckSensitivitysInIFRSRepor + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Conversion2010 = @\"" + sOutputJubilee_Conversion2010 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Jubi2011_Baseline = @\"" + sOutputJubilee_Jubi2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Jubi2011_NewValuation = @\"" + sOutputJubilee_Jubi2011_NewValuation + "\";" + Environment.NewLine;
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
        public void test_DE006_DNT()
        {



            #region MultiThreads

            Thread thrd_Conversion2010 = new Thread(() => new DE006_DNT().t_CompareRpt_Conversion2010(sOutputPension_Conversion2010));
            Thread thrd_Pensionen2011_NewValuation = new Thread(() => new DE006_DNT().t_CompareRpt_Pensionen2011_NewValuation(sOutputPension_Pensionen2011_NewValuation));
            Thread thrd_Jubi2010 = new Thread(() => new DE006_DNT().t_CompareRpt_Jubi2010(sOutputJubilee_Conversion2010));
         
            #endregion


            this.GenerateReportOuputDir();


            #region sOutputPension_Conversion2010


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
            dic.Add("ServiceToOpen", "Conversion 2010");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Conversion 2010");

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
            dic.Add("Pay", "Pay1CurrentYear");
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

            pMain._SelectTab("Conversion 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Conversion 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Conversion2010, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Conversion2010, "Parameter Summary", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Conversion2010, "Test Cases", "Conversion", true, true);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Conversion2010, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2010, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Conversion2010, "Conversion Diagnostic", "Conversion", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2010, "Test Case List", "Conversion", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2010, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2010, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2010, "Valuation Summary for Excel Export", "Conversion", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Conversion2010, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Conversion2010, "Payout Projection", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Conversion2010, "Member Statistics", "Conversion", true, false, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Conversion2010, "Valuation Summary", "Conversion", true, false, 0, new string[1] { "ALL" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Conversion2010, "Payout Projection", "Conversion", true, true, dic);

            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Conversion2010, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2010, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Conversion2010, "Conversion Diagnostic", "Conversion", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2010, "Test Case List", "Conversion", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2010, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2010, "Detailed Results by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2010, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPension_Conversion2010, "Valuation Summary for Excel Export", "Conversion", false, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Conversion2010, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Conversion2010, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Conversion2010, "Payout Projection", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Conversion2010, "Member Statistics", "Conversion", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Conversion2010, "Valuation Summary", "Conversion", false, true, 0, new string[1] { "ALL" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Conversion2010, "Payout Projection", "Conversion", false, true, dic);

            }

            thrd_Conversion2010.Start();

            pMain._SelectTab("Conversion 2010");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region sOutputPension_Pensionen2011_NewValuation

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Pensionen 2011");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Pensionen 2011");

            _gLib._MsgBox("", "Pls set the menu screen as maximum, and make the screen is in the most right");


            dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "3");
            //////////dic.Add("iSelectColNum", "1");
            dic.Add("iPosX", "331");
            dic.Add("iPosY", "151");
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
            dic.Add("Pay", "Pay1CurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "False");
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
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "3");
            //////////dic.Add("iSelectColNum", "1");
            dic.Add("iPosX", "331");
            dic.Add("iPosY", "151");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "3");
            //////////dic.Add("iSelectColNum", "1");
            dic.Add("iPosX", "331");
            dic.Add("iPosY", "151");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial Report");
            pMain._FlowTreeRightSelect(dic);

            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("Yes", "Click");
            //////pMain._PopVerify_ActuarialReport(dic);

            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "3");
            //////////dic.Add("iSelectColNum", "1");
            dic.Add("iPosX", "331");
            dic.Add("iPosY", "151");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Parameter Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Test Cases", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Direct Promise", "RollForward", true, true);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Liability Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Valuation Summary", "RollForward", true, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Liability Set for Globe Export", "RollForward", true, true, 0, new string[1] { "ALL" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Payout Projection", "RollForward", true, true, dic);
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Liabilities Detailed Results", "RollForward", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Liability Scenario by Plan Def", "RollForward", false, true);

                pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Valuation Summary", "RollForward", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[1] { "ALL" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Payout Projection", "RollForward", false, true, dic);
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);

            }

            thrd_Pensionen2011_NewValuation.Start();

            pMain._SelectTab("Pensionen 2011");
            pMain._Home_ToolbarClick_Top(true);



            #endregion


            #region Pension Valuation RF - Pensionen 2011 - Check Sensitivitys in IFRS Repor


            pMain._SelectTab("Pensionen 2011");


            dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "2");
            //////////dic.Add("iSelectRowNum", "3");
            //////////dic.Add("iSelectColNum", "2");
            dic.Add("iPosX", "804");
            dic.Add("iPosY", "151");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "Pay1CurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "False");
            dic.Add("InternationalAccountingPBO", "False");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "2");
            //////////dic.Add("iSelectRowNum", "3");
            //////////dic.Add("iSelectColNum", "2");
            dic.Add("iPosX", "804");
            dic.Add("iPosY", "151");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "Val Liab");



            pMain._SelectTab("Pensionen 2011");


            dic.Clear();
            //////////////////dic.Add("iMaxRowNum", "");
            //////////////////dic.Add("iMaxColNum", "2");
            //////////////////dic.Add("iSelectRowNum", "3");
            //////////////////dic.Add("iSelectColNum", "2");
            dic.Add("iPosX", "804");
            dic.Add("iPosY", "151");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Batch Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "true");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "true");
            dic.Add("GenerateTestCaseOutput", "true");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "Pay1CurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectNodes", "click");
            dic.Add("RunValuation", "");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "338");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "469");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "601");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "738");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "860");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "1000");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "1136");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "1245");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            _gLib._MsgBox("", "please check all the nodes under <Check Sensitivity ... > was selected");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "");
            dic.Add("iY", "");
            dic.Add("OK", "click");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);



            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            dic.Add("iPosX", "204");
            dic.Add("iPosY", "205");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);



            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            dic.Add("iPosX", "1160");
            dic.Add("iPosY", "205");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Pensionen 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            ////////////////////dic.Add("iMaxColNum", "2");
            ////////////////////dic.Add("iSelectRowNum", "3");
            ////////////////////dic.Add("iSelectColNum", "2");
            dic.Add("iPosX", "804");
            dic.Add("iPosY", "151");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial Report");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            //////////////////dic.Add("iMaxColNum", "2");
            //////////////////dic.Add("iSelectRowNum", "3");
            //////////////////dic.Add("iSelectColNum", "2");
            dic.Add("iPosX", "804");
            dic.Add("iPosY", "151");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            //////////////pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_CheckSensitivitysInIFRSRepor, "Direct Promise", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_CheckSensitivitysInIFRSRepor, "IFRS", "RollForward", true, true, true);


            pMain._SelectTab("Pensionen 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            #region sOutputJubilee_Conversion2010

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
            dic.Add("ServiceToOpen", "Conversion 2010");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Conversion 2010");


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
            dic.Add("Pay", "N/A");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "False");
            dic.Add("InternationalAccountingPBO", "False");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "Jubi");
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

            pMain._SelectTab("Conversion 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Conversion 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputJubilee_Conversion2010, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputJubilee_Conversion2010, "Parameter Summary", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Conversion2010, "Test Cases", "Conversion", true, true);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputJubilee_Conversion2010, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputJubilee_Conversion2010, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputJubilee_Conversion2010, "Conversion Diagnostic", "Conversion", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputJubilee_Conversion2010, "Test Case List", "Conversion", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputJubilee_Conversion2010, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputJubilee_Conversion2010, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputJubilee_Conversion2010, "Valuation Summary for Excel Export", "Conversion", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputJubilee_Conversion2010, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Conversion2010, "Payout Projection", "Conversion", true, true);

                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Conversion2010, "Member Statistics", "Conversion", true, false, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Conversion2010, "Valuation Summary", "Conversion", true, false, 0, new string[1] { "ALL" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputJubilee_Conversion2010, "Payout Projection", "Conversion", true, true, dic);

            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputJubilee_Conversion2010, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputJubilee_Conversion2010, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputJubilee_Conversion2010, "Conversion Diagnostic", "Conversion", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputJubilee_Conversion2010, "Test Case List", "Conversion", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputJubilee_Conversion2010, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputJubilee_Conversion2010, "Detailed Results by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputJubilee_Conversion2010, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputJubilee_Conversion2010, "Valuation Summary for Excel Export", "Conversion", false, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputJubilee_Conversion2010, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputJubilee_Conversion2010, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Conversion2010, "Payout Projection", "Conversion", false, true);

                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Conversion2010, "Member Statistics", "Conversion", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Conversion2010, "Valuation Summary", "Conversion", false, true, 0, new string[1] { "ALL" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputJubilee_Conversion2010, "Payout Projection", "Conversion", false, true, dic);

            }

            thrd_Jubi2010.Start();


            pMain._SelectTab("Conversion 2010");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region sOutputJubilee_Jubi2011_NewValuation


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Jubi_2011");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Jubi_2011");

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
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "True");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PayJubiCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "true");
            dic.Add("InternationalAccountingPBO", "true");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "Jubi");
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

            pMain._SelectTab("Jubi_2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Jubi_2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial Report");
            pMain._FlowTreeRightSelect(dic);

            ////////dic.Clear();
            ////////dic.Add("PopVerify", "Pop");
            ////////dic.Add("Yes", "Click");
            ////////pMain._PopVerify_ActuarialReport(dic);

            pMain._SelectTab("Jubi_2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Valuation Summary", "RollForward", true, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Parameter Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Test Cases", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Jubilee", "RollForward", true, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "IFRS", "RollForward", true, false, true);

            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Liability Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Liability Set for Globe Export", "RollForward", true, false, 0, new string[1] { "ALL" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Payout Projection", "RollForward", true, false, dic);
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Reconciliation to Baseline", "RollForward", true, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Liabilities Detailed Results", "RollForward", true, false);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Liability Scenario by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Valuation Summary", "RollForward", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Liability Set for Globe Export", "RollForward", false, false, 0, new string[1] { "ALL" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Payout Projection", "RollForward", false, true, dic);
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Reconciliation to Baseline", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Liabilities Detailed Results", "RollForward", false, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);

            }


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE006DNT", sOutputJubilee_Jubi2011_NewValuation_Prod, sOutputJubilee_Jubi2011_NewValuation);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputJubilee_Jubi2011_NewValuation");

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_ALL.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);

            }


            pMain._SelectTab("Jubi_2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            _gLib._MsgBox("Congratulations!", "Finished!");

        }



        public void t_CompareRpt_Conversion2010(string sOutputPension_Conversion2010)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE006DNT", sOutputPension_Conversion2010_Prod, sOutputPension_Conversion2010);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Conversion2010");
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

        public void t_CompareRpt_Pensionen2011_NewValuation(string sOutputPension_Pensionen2011_NewValuation)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE006DNT", sOutputPension_Pensionen2011_NewValuation_Prod, sOutputPension_Pensionen2011_NewValuation);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Pensionen2011_NewValuation");

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0);
                ////////_compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" });
                //////// _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_ALL.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                //////////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_ALL.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }

        }

        public void t_CompareRpt_Jubi2010(string sOutputJubilee_Conversion2010)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE006DNT", sOutputJubilee_Conversion2010_Prod, sOutputJubilee_Conversion2010);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputJubilee_Conversion2010");
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
