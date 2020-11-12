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


namespace RetirementStudio._TestScripts_2020_Mar_Others
{
    /// <summary>
    /// Summary description for US008_DNT
    /// </summary>
    [CodedUITest]
    public class US008_DNT
    {
        public US008_DNT()
        {

            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 008 Existing DNT";
            Config.sPlanName = "QA US Benchmark 008 Existing DNT Plan";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }


        #region Report Output Directory



        //public string sOutputFunding_Conversion2011_Baseline = "";
        public string sOutputFunding_Valuation2012_Baseline = "";
        //public string sOutputFunding_Valuation2012_UpdateAssumptionDates = "";
        //public string sOutputFunding_Valuation2012_ForAFN2012 = "";
        //public string sOutputFunding_Valuation2012_ForAFTAPRange = "";
        public string sOutputFunding_Valuation2013_Baseline = "";
        //public string sOutputFunding_Valuation2013_UpdateInterestAndMortality = "";
        //public string sOutputFunding_Valuation2013_ForAFN2012 = "";
        //public string sOutputFunding_ForAFTAPRangeTest_Baseline = "";
        //public string sOutputAccounting_Conversion2011_Baseline = "";
        public string sOutputAccounting_FASVal2012_Baseline = "";


        //public string sOutputFunding_Conversion2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Conversion2011\Baseline\7.4_20190409_Franklin\";
        public string sOutputFunding_Valuation2012_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Valuation2012\Baseline\7.4_20190409_Franklin\";
        //public string sOutputFunding_Valuation2012_UpdateAssumptionDates_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Valuation2012\UpdateAssumptionDates\7.4_20190409_Franklin\";
        //public string sOutputFunding_Valuation2012_ForAFN2012_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Valuation2012\ForAFN2012\7.4_20190409_Franklin\";
        //public string sOutputFunding_Valuation2012_ForAFTAPRange_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Valuation2012\ForAFTAPRange\7.4_20190409_Franklin\";
        public string sOutputFunding_Valuation2013_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Valuation2013\Baseline\7.4_20190409_Franklin\";
        //public string sOutputFunding_Valuation2013_UpdateInterestAndMortality_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Valuation2013\UpdateInterestAndMortality\7.4_20190409_Franklin\";
        //public string sOutputFunding_Valuation2013_ForAFN2012_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Valuation2013\ForAFN2012\7.4_20190409_Franklin\";
        //public string sOutputFunding_ForAFTAPRangeTest_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\ForAFTAPRangeTest\Baseline\7.4_20190409_Franklin\";
        //public string sOutputAccounting_Conversion2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Accounting\Conversion2011\Baseline\7.4_20190409_Franklin\";
        public string sOutputAccounting_FASVal2012_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Accounting\FASVal2012\Baseline\7.4_20190409_Franklin\";


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

                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Existing\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    //sOutputFunding_Conversion2011_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\Conversion2011\\Baseline\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2012_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2012\\Baseline\\" + sPostFix + "\\");
                    //sOutputFunding_Valuation2012_UpdateAssumptionDates = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2012\\UpdateAssumptionDates\\" + sPostFix + "\\");
                    //sOutputFunding_Valuation2012_ForAFN2012 = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2012\\ForAFN2012\\" + sPostFix + "\\");
                    //sOutputFunding_Valuation2012_ForAFTAPRange = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2012\\ForAFTAPRange\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2013_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2013\\Baseline\\" + sPostFix + "\\");
                    //sOutputFunding_Valuation2013_UpdateInterestAndMortality = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2013\\UpdateInterestAndMortality\\" + sPostFix + "\\");
                    //sOutputFunding_Valuation2013_ForAFN2012 = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2013\\ForAFN2012\\" + sPostFix + "\\");
                    //sOutputFunding_ForAFTAPRangeTest_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\ForAFTAPRangeTest\\Baseline\\" + sPostFix + "\\");
                    //sOutputAccounting_Conversion2011_Baseline = _gLib._CreateDirectory(sMainDir + "Accounting\\Conversion2011\\Baseline\\" + sPostFix + "\\");
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

                string sMainDir = sDir + "US008_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                ////sOutputFunding_Conversion2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\Funding_Conversion2011_Baseline\\");
                sOutputFunding_Valuation2012_Baseline = _gLib._CreateDirectory(sMainDir + "\\Funding_Valuation2012_Baseline\\");
                ////sOutputFunding_Valuation2012_UpdateAssumptionDates = _gLib._CreateDirectory(sMainDir + "\\Funding_Valuation2012_UpdateAssumptionDates\\");
                ////sOutputFunding_Valuation2012_ForAFN2012 = _gLib._CreateDirectory(sMainDir + "\\Funding_Valuation2012_ForAFN2012\\");
                ////sOutputFunding_Valuation2012_ForAFTAPRange = _gLib._CreateDirectory(sMainDir + "\\Funding_Valuation2012_ForAFTAPRange\\");
                sOutputFunding_Valuation2013_Baseline = _gLib._CreateDirectory(sMainDir + "\\Funding_Valuation2013_Baseline\\");
                ////sOutputFunding_Valuation2013_UpdateInterestAndMortality = _gLib._CreateDirectory(sMainDir + "\\Funding_Valuation2013_UpdateInterestAndMortality\\");
                ////sOutputFunding_Valuation2013_ForAFN2012 = _gLib._CreateDirectory(sMainDir + "\\Funding_Valuation2013_ForAFN2012\\");
                ////sOutputFunding_ForAFTAPRangeTest_Baseline = _gLib._CreateDirectory(sMainDir + "\\Funding_ForAFTAPRangeTest_Baseline\\");
                ////sOutputAccounting_Conversion2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\Accounting_Conversion2011_Baseline\\");
                sOutputAccounting_FASVal2012_Baseline = _gLib._CreateDirectory(sMainDir + "\\Accounting_FASVal2012_Baseline\\");

            }

            string sContent = "";
            ////sContent = sContent + "sOutputFunding_Conversion2011_Baseline = @\"" + sOutputFunding_Conversion2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2012_Baseline = @\"" + sOutputFunding_Valuation2012_Baseline + "\";" + Environment.NewLine;
            ////sContent = sContent + "sOutputFunding_Valuation2012_UpdateAssumptionDates = @\"" + sOutputFunding_Valuation2012_UpdateAssumptionDates + "\";" + Environment.NewLine;
            ////sContent = sContent + "sOutputFunding_Valuation2012_ForAFN2012 = @\"" + sOutputFunding_Valuation2012_ForAFN2012 + "\";" + Environment.NewLine;
            ////sContent = sContent + "sOutputFunding_Valuation2012_ForAFN2012 = @\"" + sOutputFunding_Valuation2012_ForAFN2012 + "\";" + Environment.NewLine;
            ////sContent = sContent + "sOutputFunding_Valuation2012_ForAFTAPRange = @\"" + sOutputFunding_Valuation2012_ForAFTAPRange + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2013_Baseline = @\"" + sOutputFunding_Valuation2013_Baseline + "\";" + Environment.NewLine;
            ////sContent = sContent + "sOutputFunding_Valuation2013_UpdateInterestAndMortality = @\"" + sOutputFunding_Valuation2013_UpdateInterestAndMortality + "\";" + Environment.NewLine;
            ////sContent = sContent + "sOutputFunding_Valuation2013_ForAFN2012 = @\"" + sOutputFunding_Valuation2013_ForAFN2012 + "\";" + Environment.NewLine;
            ////sContent = sContent + "sOutputFunding_ForAFTAPRangeTest_Baseline = @\"" + sOutputFunding_ForAFTAPRangeTest_Baseline + "\";" + Environment.NewLine;
            ////sContent = sContent + "sOutputAccounting_Conversion2011_Baseline = @\"" + sOutputAccounting_Conversion2011_Baseline + "\";" + Environment.NewLine;
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
        public void test_US008_DNT()
        {

            #region MultiThreads

            Thread thrd_Funding_Valuation2012_Baseline = new Thread(() => new US008_DNT().t_CompareRpt_Funding_Valuation2012_Baseline(sOutputFunding_Valuation2012_Baseline));
            Thread thrd_Funding_Valuation2013_Baseline = new Thread(() => new US008_DNT().t_CompareRpt_Funding_Valuation2013_Baseline(sOutputFunding_Valuation2013_Baseline));
  

            #endregion


            this.GenerateReportOuputDir();

            #region sOutputFunding_Valuation2012_Baseline

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2012");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Valuation 2012");

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

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Member Statistics", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Individual Checking Template", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Age Service Matrix", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Data Comparison", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Data Matching Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Combined Status Code Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Decrement Age", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Liability Comparison", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Payout Projection", "RollForward", false, true);

            thrd_Funding_Valuation2012_Baseline.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region sOutputFunding_Valuation2013_Baseline

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2013");
            pMain._PopVerify_Home_RightPane(dic);



            pMain._SelectTab("Valuation 2013");

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


            pMain._SelectTab("Valuation 2013");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Member Statistics", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Individual Checking Template", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Age Service Matrix", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Data Comparison", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Data Matching Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Decrement Age", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Liability Comparison", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Payout Projection", "RollForward", false, true);

            thrd_Funding_Valuation2013_Baseline.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion

     
            #region sOutputAccounting_FASVal2012_Baseline


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "FAS Val 2012");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("FAS Val 2012");

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

            pMain._SelectTab("FAS Val 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("FAS Val 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Test Cases", "RollForward", true, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Reconciliation to Prior Year", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Detailed Results", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Detailed Results by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Status Reconciliation", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Member Statistics", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Individual Checking Template", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Age Service Matrix", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Data Comparison", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Data Matching Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Combined Status Code Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Decrement Age", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Gain / Loss Participant Listing", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Liability Comparison", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Valuation Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Individual Output", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "IOE", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Payout Projection", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Liability Set for Globe Export", "RollForward", false, false);





            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US008DNT", sOutputAccounting_FASVal2012_Baseline_Prod, sOutputAccounting_FASVal2012_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting_FASVal2012_Baseline");
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
                _compareReportsLib.CompareExcel_Exact("DataComparison.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossStatusReconciliation.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_ABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_ABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PBO.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_ABO.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityComparison_PBO.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityComparison_ABO.xlsx", 0, 0, 0, 0, true);

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport.xlsx", 4, 0, 0, 0, true);
            }



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("FAS Val 2012");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            _gLib._MsgBox("Congratulations!", "Finished!");

        }



        void t_CompareRpt_Funding_Valuation2012_Baseline(string sOutputFunding_Valuation2012_Baseline)
        {

            if (Config.bCompareReports)
            {

                CompareReportsLib _compareReportsLib = new CompareReportsLib("US008DNT", sOutputFunding_Valuation2012_Baseline_Prod, sOutputFunding_Valuation2012_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Valuation2012_Baseline");
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
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }



        }

        void t_CompareRpt_Funding_Valuation2013_Baseline(string sOutputFunding_Valuation2013_Baseline)
        {


            if (Config.bCompareReports)
            {

                CompareReportsLib _compareReportsLib = new CompareReportsLib("US008DNT", sOutputFunding_Valuation2013_Baseline_Prod, sOutputFunding_Valuation2013_Baseline);
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
