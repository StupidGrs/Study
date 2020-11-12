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

namespace RetirementStudio._TestScripts._TestScripts_US
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class _US012_DNT
    {
        public _US012_DNT()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 012 Existing DNT";
            Config.sPlanName = "QA US Benchmark 012 Existing DNT";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }

        #region Report Output Directory



        public string sConversion = "";
        public string s2008Valuatoin_BurnCOB = "";
        //public string sPlanTerminationSetup_PBGC_Fields = "";
        public string sPlanTerminationSetup_PBGC_4044 = "";
        public string sAccountingConversion = "";

        public string sConversion_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_12_Knight\Production\Funding Valuation\Conversion\7.4_20190416_Franklin\";
        public string s2008Valuatoin_BurnCOB_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_12_Knight\Production\Funding Valuation\2008 Valuation\Burn COB\7.4_20190416_Franklin\";
        //public string sPlanTerminationSetup_PBGC_Fields_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_12_Knight\Production\Funding Valuation\Plan Termination Setup\PBGC_Fields\7.4_20190416_Franklin\";
        public string sPlanTerminationSetup_PBGC_4044_Prod = @"\\mercer.com\US_Data\Shared\DFL\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_12_Knight\Existing\Funding Valuation\Plan Termination Setup\PBGC_4044\20190221_QA1\";
        //public string sAccountingConversion_Prod = @"\\mercer.com\US_Data\Shared\DFL\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_12_Knight\Existing\Accounting Valuation\Conversion\20190221_QA1\";
        public string sAccountingConversion_Prod = @"\\mercer.com\US_Data\Shared\DFL\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_12_Knight\Production\Accounting Valuation\Conversion\7.4_20190416_Franklin\";


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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_12_Knight\Existing\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);


                    sConversion = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\Conversion\\" + sPostFix + "\\");
                    s2008Valuatoin_BurnCOB = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\2008 Valuation\\Burn COB\\" + sPostFix + "\\");
                    //sPlanTerminationSetup_PBGC_Fields = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\Plan Termination Setup\\PBGC_Fields\\" + sPostFix + "\\");
                    sPlanTerminationSetup_PBGC_4044 = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\Plan Termination Setup\\PBGC_4044\\" + sPostFix + "\\");
                    sAccountingConversion = _gLib._CreateDirectory(sMainDir + "Accounting Valuation\\Conversion\\" + sPostFix + "\\");

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

                string sMainDir = sDir + "US012_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sConversion = _gLib._CreateDirectory(sMainDir + "\\Conversion\\");
                s2008Valuatoin_BurnCOB = _gLib._CreateDirectory(sMainDir + "\\2008Valuatoin_BurnCOB\\");
                //sPlanTerminationSetup_PBGC_Fields = _gLib._CreateDirectory(sMainDir + "\\PlanTerminationSetup_PBGC_Fields\\");
                sAccountingConversion = _gLib._CreateDirectory(sMainDir + "\\AccountingConversion\\");

            }

            string sContent = "";
            sContent = sContent + "sConversion = @\"" + sConversion + "\";" + Environment.NewLine;
            sContent = sContent + "s2008Valuatoin_BurnCOB = @\"" + s2008Valuatoin_BurnCOB + "\";" + Environment.NewLine;
            //sContent = sContent + "sPlanTerminationSetup_PBGC_Fields = @\"" + sPlanTerminationSetup_PBGC_Fields + "\";" + Environment.NewLine;
            sContent = sContent + "sAccountingConversion = @\"" + sAccountingConversion + "\";" + Environment.NewLine;

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
        public void CodedUITestMethod1()
        {


            this.GenerateReportOuputDir();


            #region sPlanTerminationSetup_PBGC_4044


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Plan Termination Setup");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Plan Termination Setup");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "7");
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
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "SalPrj");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Plan Termination Setup");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);



            pMain._SelectTab("Plan Termination Setup");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_Others_PDF_EXCEL(sPlanTerminationSetup_PBGC_4044, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sPlanTerminationSetup_PBGC_4044, "PBGC 4044 Liabilities by Plan Def", "RollForward", true, true);



            pOutputManager._Navigate(Config.eCountry, "IOE", "RollForward", true);
            pOutputManager._SelectTab("Individual Output");
            _gLib._SetSyncUDWin("Group - None", pOutputManager.wRetirementStudio.wGroup_None.rdNone, "True", 0);
            _gLib._SetSyncUDWin("Process", pOutputManager.wRetirementStudio.wProcess.btnProcess, "Click", 0);
            if (_gLib._Exists("NewIOEParameters1", pOutputManager.wRetirementStudio.tvNaviTree.tviIndividualOutput.tviNewIOEParameters1, Config.iTimeout / 30, false))
                _gLib._SetSyncUDWin("NewIOEParameters1", pOutputManager.wRetirementStudio.tvNaviTree.tviIndividualOutput.tviNewIOEParameters1, "Click", 0);
            else
            {
                dic.Clear();
                dic.Add("Level_1", "Individual Output");
                _gLib._TreeViewSelectWin(0, pOutputManager.wRetirementStudio.tvNaviTree, dic);

                dic.Clear();
                dic.Add("Level_1", "Individual Output");
                dic.Add("MenuItem", "Add IOE Parameters");
                _gLib._TreeViewRightSelectWin(0, pOutputManager.wRetirementStudio.tvNaviTree.tviIndividualOutput, dic, false);
            }

            dic.Clear();
            dic.Add("Level_1", "PBGC_Plan_Term");
            dic.Add("Level_2", "Provision Output Fields");
            dic.Add("Level_3", "PBGC Dollar Max");
            pOutputManager._TreeViewSelect_IOE(dic, true);

            _gLib._SetSyncUDWin("Export", pOutputManager.wRetirementStudio.wExport.btnExport, "Click", 0);

            pOutputManager._SaveAs(sPlanTerminationSetup_PBGC_4044 + "IOE.xls");
            _gLib._SetSyncUDWin("OK", pOutputManager.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
            _gLib._FileExists(sPlanTerminationSetup_PBGC_4044 + "IOE.xlsx", Config.iTimeout, true);

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US012DNT", sPlanTerminationSetup_PBGC_4044_Prod, sPlanTerminationSetup_PBGC_4044);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sPlanTerminationSetup_PBGC_4044");

                _compareReportsLib.CompareExcel_Exact("PBGC4044LiabilitiesbyPlanDef.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);

                Config.bThreadFinsihed = true;
            }


            pMain._SelectTab("Plan Termination Setup");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region sAccountingConversion

            //_gLib._MsgBox("", "Please run Accounting>Conversion liability");

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Conversion");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Conversion");

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
            dic.Add("Service", "SVC");
            dic.Add("Pay", "SalPrj");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
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

            pMain._SelectTab("Conversion");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Conversion");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccountingConversion, "Liability Summary", "Conversion", true, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sAccountingConversion, "Liability Summary", "Conversion", true, false, 0);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccountingConversion, "Member Statistics", "Conversion", true, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sAccountingConversion, "Conversion Diagnostic", "Conversion", true, false, 0);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccountingConversion, "Conversion Diagnostic", "Conversion", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccountingConversion, "Detailed Results", "Conversion", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccountingConversion, "Valuation Summary", "Conversion", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccountingConversion, "Individual Output", "Conversion", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccountingConversion, "Parameter Print", "Conversion", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccountingConversion, "Payout Projection", "Conversion", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccountingConversion, "FAS Expected Benefit Pmts", "Conversion", true, false);

            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccountingConversion, "Detailed Results by Plan Def", "Conversion", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccountingConversion, "IOE", "Conversion", false, false);



            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US012DNT", sAccountingConversion_Prod, sAccountingConversion);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sAccountingConversion");

                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_ActiveMembers.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_DeferredMembers.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_Pensioners.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByNone.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByStatusCodes.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByCustom_Gender.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0, true);
            }


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Conversion");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion

            _gLib._MsgBox("", "done");
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
