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


namespace RetirementStudio._TestScripts_2020_Mar_Others
{
    /// Summary description for CA001_DNT
    /// </summary>
    [CodedUITest]
    public class CA001_DNT
    {
        public CA001_DNT()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.CA;
            Config.sClientName = "QA CA Benchmark 001 Existing DNT";
            Config.sPlanName = "QA CA Benchmark 001 Existing DNT Plan";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }


        #region Report Output Directory


        public string sOutputFunding_Funding2011_Baseline = "";
        //////public string sOutputFunding_Funding2011_NewValuation = "";
        public string sOutputFunding_WindUpGL2011 = "";
        public string sOutputAccounting_Accounting2008 = "";

        public string sOutputFunding_Funding2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_CA_Benchmark_1\Production\Funding2011\Baseline\7.5_20191216\";
        //////public string sOutputFunding_Funding2011_NewValuation_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_CA_Benchmark_1\Production\Funding2011\NewValuation\7.5_20191216\";
        public string sOutputFunding_WindUpGL2011_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_CA_Benchmark_1\Production\WindUpGL2011\7.5_20191216\";
        public string sOutputAccounting_Accounting2008_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_CA_Benchmark_1\Production\Accounting2008\7.5_20191216\";


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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_CA_Benchmark_1\Existing\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputFunding_Funding2011_Baseline = _gLib._CreateDirectory(sMainDir + "Funding2011\\Baseline\\" + sPostFix + "\\");
                    ////sOutputFunding_Funding2011_NewValuation = _gLib._CreateDirectory(sMainDir + "Funding2011\\NewValuation\\" + sPostFix + "\\");
                    sOutputFunding_WindUpGL2011 = _gLib._CreateDirectory(sMainDir + "WindUpGL2011\\" + sPostFix + "\\");
                    sOutputAccounting_Accounting2008 = _gLib._CreateDirectory(sMainDir + "Accounting2008\\" + sPostFix + "\\");
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

                string sMainDir = sDir + "CA001_" + _gLib._ReturnDateStampYYYYMMDD();

                ////////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputFunding_Funding2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\Funding2011\\Baseline\\");

                //////sOutputFunding_Funding2011_NewValuation = _gLib._CreateDirectory(sMainDir + "\\Funding2011\\NewValuation\\");
                sOutputFunding_WindUpGL2011 = _gLib._CreateDirectory(sMainDir + "\\WindUpGL2011\\");
                sOutputAccounting_Accounting2008 = _gLib._CreateDirectory(sMainDir + "\\Accounting2008\\");


            }



            string sContent = "";
            sContent = sContent + "sOutputFunding_Funding2011_Baseline = @\"" + sOutputFunding_Funding2011_Baseline + "\";" + Environment.NewLine;

            //////sContent = sContent + "sOutputFunding_Funding2011_NewValuation = @\"" + sOutputFunding_Funding2011_NewValuation + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_WindUpGL2011 = @\"" + sOutputFunding_WindUpGL2011 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Accounting2008 = @\"" + sOutputAccounting_Accounting2008 + "\";" + Environment.NewLine;

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
        public void test_CA001_DNT()
        {

            #region MultiThreads

            Thread thrd_Funding2011_Baseline = new Thread(() => new CA001_DNT().t_CompareRpt_Funding_Funding2011_Baseline(sOutputFunding_Funding2011_Baseline));
            Thread thrd_Funding_WindUpGL2011 = new Thread(() => new CA001_DNT().t_CompareRpt_Funding_WindUpGL2011(sOutputFunding_WindUpGL2011));


            #endregion


            this.GenerateReportOuputDir();


            #region sOutputFunding_Funding2011_Baseline

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Funding2011");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Funding2011");

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
            dic.Add("GL_GoingConcern", "True");
            dic.Add("GL_Solvency", "True");
            dic.Add("PayoutProjection", "false");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "true");
            dic.Add("CalcIncreCostSolvencyWindup", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "ProjectedPay");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "ContribsWInterest1");
            dic.Add("Pension", "AccruedBenefit1");
            dic.Add("AllLiabilityTypes", "false");
            dic.Add("GoingConcernLiability", "True");
            dic.Add("SolvencyLiability", "True");
            dic.Add("WindUpLiability", "false");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("Funding2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete with 1 NP", true);


            pMain._SelectTab("Funding2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Valuation Summary", "RollForward", true, true);

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Member Statistics", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Age Service Matrix", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Data Matching Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Combined Status Code Summary", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Decrement Age", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "IOE", "RollForward", false, true);
         

            thrd_Funding2011_Baseline.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Funding2011");
            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region Funding - WindUpGL2011


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "WindUpGL 2011");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("WindUpGL 2011");

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
            dic.Add("GL_GoingConcern", "True");
            dic.Add("GL_WindUp", "True");
            dic.Add("PayoutProjection", "false");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("CalcIncreCostSolvencyWindup", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "ProjectedPay");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "ContribsWInterest1");
            dic.Add("Pension", "AccruedBenefit1");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "True");
            dic.Add("SolvencyLiability", "false");
            dic.Add("WindUpLiability", "true");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("WindUpGL 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete with 1 NP", true);


            pMain._SelectTab("WindUpGL 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Parameter Print", "RollForward", true, true);

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Reconciliation to Prior Year", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Member Statistics", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Age Service Matrix", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Data Matching Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Combined Status Code Summary", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Gain / Loss Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Decrement Age", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Gain / Loss Participant Listing", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "IOE", "RollForward", false, true);


            thrd_Funding_WindUpGL2011.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("WindUpGL 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region sOutputAccounting_Accounting2008

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Accounting2008");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Accounting2008");


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
            dic.Add("Service", "Credited");
            dic.Add("Pay", "ProjectedPay");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "EEContributions");
            dic.Add("Pension", "AccruedBenefit1");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "");
            dic.Add("SolvencyLiability", "");
            dic.Add("WindUpLiability", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Accounting2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Accounting2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2008, "Parameter Print", "Conversion", true, false);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2008, "Liability Summary", "Conversion", false, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputAccounting_Accounting2008, "Liability Summary", "Conversion", false, false, 0);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2008, "Member Statistics", "Conversion", false, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputAccounting_Accounting2008, "Conversion Diagnostic", "Conversion", false, false, 0);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2008, "Conversion Diagnostic", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2008, "Test Case List", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2008, "Detailed Results", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2008, "Detailed Results by Plan Def", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2008, "Valuation Summary", "Conversion", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2008, "Individual Output", "Conversion", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2008, "IOE", "Conversion", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2008, "Payout Projection", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2008, "FAS Expected Benefit Pmts", "Conversion", false, false);


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("CA001DNT", sOutputAccounting_Accounting2008_Prod, sOutputAccounting_Accounting2008);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting_Accounting2008");
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

            pMain._SelectTab("Accounting2008");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            _gLib._MsgBox("Congratulations!", "Finished!");

        }


    
        void t_CompareRpt_Funding_Funding2011_Baseline(string sOutputFunding_Funding2011_Baseline)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("CA001DNT", sOutputFunding_Funding2011_Baseline_Prod, sOutputFunding_Funding2011_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_Funding2011_Baseline");

                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearByPlanDef_GoningConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearByPlanDef_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainlossStatusReconciliation_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainlossStatusReconciliation_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainlossSummaryOfLiabilityReconciliation_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainlossSummaryOfLiabilityReconciliation_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;

            }

        }

        void t_CompareRpt_Funding_WindUpGL2011(string sOutputFunding_WindUpGL2011)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("CA001DNT", sOutputFunding_WindUpGL2011_Prod, sOutputFunding_WindUpGL2011);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_WindUpGL2011");
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYear_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYear_Windup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_Windup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsByPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainlossStatusReconciliation_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainlossStatusReconciliation_Windup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryOfLiabilityReconciliation_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryOfLiabilityReconciliation_Windup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_Windup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_Windup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
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
