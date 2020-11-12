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




namespace RetirementStudio._TestScripts_2019_Oct_US
{
    /// <summary>
    /// Summary description for US007_DNT
    /// </summary>
    [CodedUITest]
    public class US007_DNT
    {
        public US007_DNT()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 007 Existing DNT";
            Config.sPlanName = "QA US Benchmark 007 Existing DNT Plan";

            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;


            //////////_gLib._Report(_PassFailStep.Header, "Testing Starts at: " + DateTime.Now + "\t" + Environment.UserName);

            ////////_gLib._MsgBox("Warning!", "If you are running Existing or Re-opened Studio after crash, Please manually select the Client in Studio-> Home -> All Services -> "
            ////////    + Config.sClientName + Environment.NewLine + Environment.NewLine + "If you are running CreateNew without any crash, Please ignore this msg!"
            ////////    + Environment.NewLine + Environment.NewLine + "Click OK to keep testing!");


        }

        #region Report Output Directory



        public string sOutputFunding2005 = "";
        public string sOutputFunding2006 = "";
        public string sOutputAccounting2005 = "";
        public string sOutputAccounting2006 = "";


        public string sOutputFunding2005_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_007_Keihin\Production\Funding 2005\7.2_20180502_Franklin\";
        public string sOutputFunding2006_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_007_Keihin\Existing\Funding 2006\000_7.4_Baseline\";
        //public string sOutputFunding2006_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_007_Keihin\Production\Funding 2006\7.2_20180502_Franklin\";
        public string sOutputAccounting2005_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_007_Keihin\Production\2005 Accounting\7.2_20180502_Franklin\";
        public string sOutputAccounting2006_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_007_Keihin\Existing\2006 Accounting\000_7.4_Baseline\";
        //public string sOutputAccounting2006_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_007_Keihin\Production\2006 Accounting\7.2_20180502_Franklin\";


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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_007_Keihin\Existing\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputFunding2005 = _gLib._CreateDirectory(sMainDir + "Funding 2005\\" + sPostFix + "\\");
                    sOutputFunding2006 = _gLib._CreateDirectory(sMainDir + "Funding 2006\\" + sPostFix + "\\");
                    sOutputAccounting2005 = _gLib._CreateDirectory(sMainDir + "2005 Accounting\\" + sPostFix + "\\");
                    sOutputAccounting2006 = _gLib._CreateDirectory(sMainDir + "2006 Accounting\\" + sPostFix + "\\");

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

                string sMainDir = sDir + "US007_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputFunding2005 = _gLib._CreateDirectory(sMainDir + "\\Funding2005\\");
                sOutputFunding2006 = _gLib._CreateDirectory(sMainDir + "\\Funding2006\\");
                sOutputAccounting2005 = _gLib._CreateDirectory(sMainDir + "\\Accounting2005\\");
                sOutputAccounting2006 = _gLib._CreateDirectory(sMainDir + "\\Accounting2006\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputFunding2005 = @\"" + sOutputFunding2005 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding2006 = @\"" + sOutputFunding2006 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting2005 = @\"" + sOutputAccounting2005 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting2006 = @\"" + sOutputAccounting2006 + "\";" + Environment.NewLine;

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
        public void test_US007_DNT()
        {
 

            #region MultiThreads


            Thread thrd_Funding2005 = new Thread(() => new US007_DNT().t_CompareRpt_Funding2005(sOutputFunding2005));
            Thread thrd_Funding2006 = new Thread(() => new US007_DNT().t_CompareRpt_Funding2006(sOutputFunding2006));
            Thread thrd_Accounting2005 = new Thread(() => new US007_DNT().t_CompareRpt_Accounting2005(sOutputAccounting2005));



            #endregion


            this.GenerateReportOuputDir();


            #region Funding 2006


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Funding 2006");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Funding 2006");


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
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "NewPayProjection1");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "N/A");
            dic.Add("Pension", "Benefit1DB");
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
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Funding 2006");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding2006, "Reconciliation to Prior Year", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding2006, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding2006, "Detailed Results", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding2006, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding2006, "Status Reconciliation", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding2006, "Member Statistics", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding2006, "Individual Checking Template", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding2006, "Age Service Matrix", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding2006, "Data Matching Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding2006, "Combined Status Code Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding2006, "Gain / Loss Status Reconciliation", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding2006, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding2006, "Active Decrement Gain / Loss Detail", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding2006, "Decrement Age", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding2006, "Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding2006, "Individual Output", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding2006, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding2006, "Gain / Loss Participant Listing", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding2006, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding2006, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding2006, "Payout Projection", "RollForward", true, true);


            thrd_Funding2006.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Funding 2006");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            #endregion



            #region Accounting 2006



            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect(0, dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "2006 Accounting");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("2006 Accounting");

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
            dic.Add("Service", "$Service");
            dic.Add("Pay", "NewPayProjection1");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
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


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("2006 Accounting");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting2006, "Reconciliation to Prior Year", "RollForward", true, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting2006, "Reconciliation to Prior Year by Plan Def", "RollForward", false, false);

            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting2006, "Detailed Results", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting2006, "Detailed Results by Plan Def", "RollForward", false, false);

            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting2006, "Status Reconciliation", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting2006, "Member Statistics", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting2006, "Individual Checking Template", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting2006, "Age Service Matrix", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting2006, "Data Matching Summary", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting2006, "Combined Status Code Summary", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting2006, "Gain / Loss Status Reconciliation", "RollForward", true, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting2006, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting2006, "Gain / Loss Participant Listing", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting2006, "Active Decrement Gain / Loss Detail", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting2006, "Decrement Age", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting2006, "Valuation Summary", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting2006, "Individual Output", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting2006, "IOE", "RollForward", false, false);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting2006, "Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting2006, "Test Cases", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting2006, "Payout Projection", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting2006, "FAS Expected Benefit Pmts", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting2006, "Liability Set for Globe Export", "RollForward", true, false);


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US007DNT", sOutputAccounting2006_Prod, sOutputAccounting2006);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting2006");
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
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossStatusReconciliation.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_ABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_ABO.xlsx", 4, 0, 0, 0, true);
                //    _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PBO.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_ABO.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport.xlsx", 4, 0, 0, 0, true);
            }


            pMain._SelectTab("2006 Accounting");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            _gLib._MsgBox("Congratulations!", "Finished!");

        }




        void t_CompareRpt_Funding2005(string sOutputFunding2005)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US007DNT", sOutputFunding2005_Prod, sOutputFunding2005);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding2005");
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
                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Funding2006(string sOutputFunding2006)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US007DNT", sOutputFunding2006_Prod, sOutputFunding2006);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding2006");
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
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossStatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }



        }

        void t_CompareRpt_Accounting2005(string sOutputAccounting2005)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US007DNT", sOutputAccounting2005_Prod, sOutputAccounting2005);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting2005");
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
