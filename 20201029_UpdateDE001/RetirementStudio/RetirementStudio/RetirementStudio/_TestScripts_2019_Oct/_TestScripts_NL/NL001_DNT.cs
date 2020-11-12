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


namespace RetirementStudio._TestScripts_2019_Oct_NL
{
    /// <summary>
    /// Summary description for NL001_DNT
    /// </summary>
    [CodedUITest]
    public class NL001_DNT
    {

        public NL001_DNT()
        {

            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.NL;
            Config.sClientName = "QA NL Benchmark 001 Existing DNT";
            Config.sPlanName = "QA NL Benchmark 001 Existing DNT Plan";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;

            //_gLib._Report(_PassFailStep.Header, "Testing Starts at: " + DateTime.Now + "\t" + Environment.UserName);

            //_gLib._MsgBox("Warning!", "If you are running Existing or Re-opened Studio after crash, Please manually select the Client in Studio-> Home -> All Services -> "
            //    + Config.sClientName + Environment.NewLine + Environment.NewLine + "If you are running CreateNew without any crash, Please ignore this msg!"
            //    + Environment.NewLine + Environment.NewLine + "Click OK to keep testing!");


        }

        #region Report Output Directory

        public string sOutputFunding_Fnd2011Cnv = "";
        public string sOutputFunding_Fnd2012RF_Baseline = "";
        public string sOutputFunding_Fnd2012RF_FndChld1 = "";
        public string sOutputAccounting_Acct2011Cnv = "";

        public string sOutputFunding_Fnd2011Cnv_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_001\Production\Funding\Fnd2011Cnv\7.5_20191113_E\";
        public string sOutputFunding_Fnd2012RF_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_001\Production\Funding\Fnd2012RF\Baseline\7.5_20191113_E\";
        public string sOutputFunding_Fnd2012RF_FndChld1_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_001\Production\Funding\Fnd2012RF\FndChld1\7.5_20191113_E\";
        public string sOutputAccounting_Acct2011Cnv_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_001\Production\Accounting\Acct2011Cnv\7.5_20191113_E\";


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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_001\Existing\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputFunding_Fnd2011Cnv = _gLib._CreateDirectory(sMainDir + "Funding\\Fnd2011Cnv\\" + sPostFix + "\\");
                    sOutputFunding_Fnd2012RF_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\Fnd2012RF\\Baseline\\" + sPostFix + "\\");
                    sOutputFunding_Fnd2012RF_FndChld1 = _gLib._CreateDirectory(sMainDir + "Funding\\Fnd2012RF\\FndChld1\\" + sPostFix + "\\");
                    sOutputAccounting_Acct2011Cnv = _gLib._CreateDirectory(sMainDir + "Accounting\\Acct2011Cnv\\" + sPostFix + "\\");

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

                string sMainDir = sDir + "NL001_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputFunding_Fnd2011Cnv = _gLib._CreateDirectory(sMainDir + "\\sOutputFunding_Fnd2011Cnv\\");
                sOutputFunding_Fnd2012RF_Baseline = _gLib._CreateDirectory(sMainDir + "\\sOutputFunding_Fnd2012RF_Baseline\\");
                sOutputFunding_Fnd2012RF_FndChld1 = _gLib._CreateDirectory(sMainDir + "\\sOutputFunding_Fnd2012RF_FndChld1\\");
                sOutputAccounting_Acct2011Cnv = _gLib._CreateDirectory(sMainDir + "\\sOutputAccounting_Acct2011Cnv\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputFunding_Fnd2011Cnv = @\"" + sOutputFunding_Fnd2011Cnv + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Fnd2012RF_Baseline = @\"" + sOutputFunding_Fnd2012RF_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Fnd2012RF_FndChld1 = @\"" + sOutputFunding_Fnd2012RF_FndChld1 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Acct2011Cnv = @\"" + sOutputAccounting_Acct2011Cnv + "\";" + Environment.NewLine;

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
        public void test_NL001_DNT()
        {
            sOutputFunding_Fnd2011Cnv = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_001\Existing\Funding\Fnd2011Cnv\20191117_QA1\";
            sOutputFunding_Fnd2012RF_Baseline = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_001\Existing\Funding\Fnd2012RF\Baseline\20191117_QA1\";
            sOutputFunding_Fnd2012RF_FndChld1 = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_001\Existing\Funding\Fnd2012RF\FndChld1\20191117_QA1\";
            sOutputAccounting_Acct2011Cnv = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_001\Existing\Accounting\Acct2011Cnv\20191117_QA1\";


            #region MultiThreads

            Thread thrd_Fnd2011Cnv = new Thread(() => new NL001_DNT().t_CompareRpt_Fnd2011Cnv(sOutputFunding_Fnd2011Cnv));
            Thread thrd_Fnd2012RF_FndChld1 = new Thread(() => new NL001_DNT().t_CompareRpt_Fnd2012RF_FndChld1(sOutputFunding_Fnd2012RF_FndChld1));

            #endregion


            this.GenerateReportOuputDir();


            #region sOutputFunding_Fnd2011Cnv


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Fnd2011Cnv");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Fnd2011Cnv");

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
            dic.Add("Pay", "PProj2");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "True");
            dic.Add("SolvencyLiability", "True");
            dic.Add("WindUpLiability", "");
            dic.Add("PayoutProjectionCustomGroup", "Gender");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Fnd2011Cnv");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Fnd2011Cnv");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Fnd2011Cnv, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Fnd2011Cnv, "Test Cases", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Fnd2011Cnv, "Liability Summary", "Conversion", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputFunding_Fnd2011Cnv, "Liability Summary", "Conversion", false, true, 0);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Fnd2011Cnv, "Member Statistics", "Conversion", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputFunding_Fnd2011Cnv, "Conversion Diagnostic", "Conversion", false, true, 0);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Fnd2011Cnv, "Test Case List", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Fnd2011Cnv, "Detailed Results", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Fnd2011Cnv, "Detailed Results by Plan Def", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Fnd2011Cnv, "Valuation Summary", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Fnd2011Cnv, "Individual Output", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Fnd2011Cnv, "IOE", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Fnd2011Cnv, "Payout Projection", "Conversion", false, true);


            thrd_Fnd2011Cnv.Start();


            pMain._SelectTab("Fnd2011Cnv");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region sOutputFunding_Fnd2012RF_FndChld1


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Fnd2012RF");
            pMain._PopVerify_Home_RightPane(dic);
            pMain._SelectTab("Fnd2012RF");


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
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "PProj2");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "True");
            dic.Add("SolvencyLiability", "True");
            dic.Add("WindUpLiability", "");
            dic.Add("PayoutProjectionCustomGroup", "Gender");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Fnd2012RF");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Fnd2012RF");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Fnd2012RF_FndChld1, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Fnd2012RF_FndChld1, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Fnd2012RF_FndChld1, "Liability Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Fnd2012RF_FndChld1, "Liability Scenario with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Fnd2012RF_FndChld1, "Liability Scenario by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Fnd2012RF_FndChld1, "Liability Scenario by Plan Def with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Fnd2012RF_FndChld1, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Fnd2012RF_FndChld1, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Fnd2012RF_FndChld1, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Fnd2012RF_FndChld1, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Fnd2012RF_FndChld1, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Fnd2012RF_FndChld1, "Reconciliation to Baseline with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Fnd2012RF_FndChld1, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Fnd2012RF_FndChld1, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Fnd2012RF_FndChld1, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Fnd2012RF_FndChld1, "Liabilities Detailed Results with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Fnd2012RF_FndChld1, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Fnd2012RF_FndChld1, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, true);


            thrd_Fnd2012RF_FndChld1.Start();

            pMain._SelectTab("Fnd2012RF");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region sOutputAccounting_Acct2011Cnv


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Acct2011Cnv");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Acct2011Cnv");


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
            dic.Add("Pay", "PProj1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "");
            dic.Add("SolvencyLiability", "");
            dic.Add("WindUpLiability", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "Gender");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Acct2011Cnv");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Acct2011Cnv");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Acct2011Cnv, "Parameter Print", "Conversion", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Acct2011Cnv, "Test Cases", "Conversion", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Acct2011Cnv, "Liability Summary", "Conversion", false, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputAccounting_Acct2011Cnv, "Liability Summary", "Conversion", false, false, 0);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Acct2011Cnv, "Member Statistics", "Conversion", false, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputAccounting_Acct2011Cnv, "Conversion Diagnostic", "Conversion", false, false, 0);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Acct2011Cnv, "Conversion Diagnostic", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Acct2011Cnv, "Test Case List", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Acct2011Cnv, "Detailed Results", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Acct2011Cnv, "Detailed Results by Plan Def", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Acct2011Cnv, "Valuation Summary", "Conversion", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Acct2011Cnv, "Individual Output", "Conversion", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Acct2011Cnv, "IOE", "Conversion", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Acct2011Cnv, "Payout Projection", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Acct2011Cnv, "FAS Expected Benefit Pmts", "Conversion", false, false);


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("NL001DNT", sOutputAccounting_Acct2011Cnv_Prod, sOutputAccounting_Acct2011Cnv);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputAccounting_Acct2011Cnv");
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


            pMain._SelectTab("Acct2011Cnv");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            _gLib._MsgBox("Congratulations!", "Finished!");

        }


        public void t_CompareRpt_Fnd2011Cnv(string sOutputFunding_Fnd2011Cnv)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("NL001DNT", sOutputFunding_Fnd2011Cnv_Prod, sOutputFunding_Fnd2011Cnv);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Fnd2011Cnv");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_ActiveMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_DeferredMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_Pensioners.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByNone.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByStatusCodes.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByCustom_Gender.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("TestCaseList.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        public void t_CompareRpt_Fnd2012RF_FndChld1(string sOutputFunding_Fnd2012RF_FndChld1)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("NL001DNT", sOutputFunding_Fnd2012RF_FndChld1_Prod, sOutputFunding_Fnd2012RF_FndChld1);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Fnd2012RF_FndChld1");
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultswithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDefwithBreaks.xlsx", 4, 0, 0, 0);
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
