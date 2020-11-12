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
using RetirementStudio._UIMaps.FromToAgeClasses;
using RetirementStudio._UIMaps.EarlyRetirementFactorClasses;
using RetirementStudio._UIMaps.SpecialEligibilitiesClasses;


namespace RetirementStudio._TestScripts_2019_Apr
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class _US016_CN
    {
        public _US016_CN()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 016 Existing DNT";
            Config.sPlanName = "QA US Benchmark 016 Existing DNT Plan";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }


        #region Report Output Directory

        public string sFunding_Val2013 = "";
        public string sFunding_Val2014_Baseline = "";
        public string sFunding_Val2014_FinalResults = "";


        public string sFunding_Val2013_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_016_At_Risk\Production\Val 2013\6.9_20160918_Franklin\";
        //public string sFunding_Val2014_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_016_At_Risk\Production\Val 2014\Baseline\6.9_20160918_Franklin\";
        //public string sFunding_Val2014_FinalResults_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_016_At_Risk\Production\Val 2014\Final Results\6.9_20160918_Franklin\";
        public string sFunding_Val2014_Baseline_Prod = @"R:\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_016_At_Risk\ExistingDNT\VAL\Val 2014\Baseline\000_7.4_Baseline\";
        public string sFunding_Val2014_FinalResults_Prod = @"R:\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_016_At_Risk\ExistingDNT\VAL\Val 2014\FinalResults\000_7.4_Baseline\";

        String sTable_GA513070 = "";
        String sTable_GA517030 = "";


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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_016_At_Risk\CreateNew\VAL\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sFunding_Val2013 = _gLib._CreateDirectory(sMainDir + "Val 2013\\" + sPostFix + "\\");
                    sFunding_Val2014_Baseline = _gLib._CreateDirectory(sMainDir + "Val 2014\\Baseline\\" + sPostFix + "\\");
                    sFunding_Val2014_FinalResults = _gLib._CreateDirectory(sMainDir + "Val 2014\\FinalResults\\" + sPostFix + "\\");

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

                string sMainDir = sDir + "US016_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sFunding_Val2013 = _gLib._CreateDirectory(sMainDir + "\\sFunding_Val2013\\");
                sFunding_Val2014_Baseline = _gLib._CreateDirectory(sMainDir + "\\sFunding_AtRisk2010_Baseline\\");
                sFunding_Val2014_FinalResults = _gLib._CreateDirectory(sMainDir + "\\sFunding_Val2014_FinalResults\\");

            }

            string sContent = "";
            sContent = sContent + "sFunding_Val2013 = @\"" + sFunding_Val2013 + "\";" + Environment.NewLine;
            sContent = sContent + "sFunding_Val2014_Baseline = @\"" + sFunding_Val2014_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sFunding_Val2014_FinalResults = @\"" + sFunding_Val2014_FinalResults + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);

        }
        
        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();

        public SpecialEligibilities pSpecialEligibilities = new SpecialEligibilities();
        public EarlyRetirementFactor pEarlyRetirementFactor = new EarlyRetirementFactor();
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
        public FromToAge pFromToAge = new FromToAge();


        #endregion


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void _test_US016_CN()
        {

            sFunding_Val2014_Baseline = @"R:\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_016_At_Risk\CreateNew\VAL\Val 2014\Baseline\20190711_QA1\";
            sFunding_Val2014_FinalResults = @"R:\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_016_At_Risk\CreateNew\VAL\Val 2014\FinalResults\20190711_QA1\";
            
            sFunding_Val2014_Baseline_Prod = @"R:\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_016_At_Risk\ExistingDNT\VAL\Val 2014\Baseline\000_7.4_Baseline\";
            sFunding_Val2014_FinalResults_Prod = @"R:\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_016_At_Risk\ExistingDNT\VAL\Val 2014\FinalResults\000_7.4_Baseline\";


            string sServiceVal2014 = "Val 2014-" + _gLib._ReturnDateStampYYYYMMDD();


            pMain._SetLanguageAndRegional();


            #region MultiThreads

            //Thread thrd_Funding_Val2013 = new Thread(() => new US016_CN().t_CompareRpt_Funding_Val2013(sFunding_Val2013));
            Thread thrd_Funding_Val2014_Baseline = new Thread(() => new _US016_CN().t_CompareRpt_Funding_Val2014_Baseline(sFunding_Val2014_Baseline));

            #endregion


            #region sFunding_Val2014_Baseline

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", sServiceVal2014);
            dic.Add("Parent", "Val 2013");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "2014");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", sServiceVal2014);
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab(sServiceVal2014);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Roll Forward");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "True");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "");
            dic.Add("Provisions_Name", "");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            pMain._ValuationNodeProperties_ChangeReasons_Initialize();

            dic.Clear();
            dic.Add("LiabilityType", "PPA");
            dic.Add("ReasonforChange", "Baseline");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "PBGC");
            dic.Add("ReasonforChange", "Baseline");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "FAS 35");
            dic.Add("ReasonforChange", "Baseline");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab(sServiceVal2014);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Data");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Participant DataSet");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "True");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "ValuationData");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "True");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "Click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("CompareData", "False");
            dic.Add("ImportDataandApplyMapping", "Click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab(sServiceVal2014);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/24/1969\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"7/30/1941\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab(sServiceVal2014);

            pMain._Home_ToolbarClick_Top(true);

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
            dic.Add("Service", "BenefitService");
            dic.Add("Pay", "PensionEarningsPriorYear1");
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
            dic.Add("PPAAtRiskLiabilityForMinimum", "True");
            dic.Add("PPAAtRiskLiabilityForMaximum", "True");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("EntryAgeNormal", "False");
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

            pMain._SelectTab(sServiceVal2014);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sFunding_Val2014_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sFunding_Val2014_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding_Val2014_Baseline, "Detailed Results", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding_Val2014_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding_Val2014_Baseline, "Status Reconciliation", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding_Val2014_Baseline, "Member Statistics", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sFunding_Val2014_Baseline, "Individual Checking Template", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding_Val2014_Baseline, "Age Service Matrix", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding_Val2014_Baseline, "Data Matching Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding_Val2014_Baseline, "Combined Status Code Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding_Val2014_Baseline, "Gain / Loss Status Reconciliation", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sFunding_Val2014_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sFunding_Val2014_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding_Val2014_Baseline, "Decrement Age", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sFunding_Val2014_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding_Val2014_Baseline, "Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sFunding_Val2014_Baseline, "Individual Output", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sFunding_Val2014_Baseline, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sFunding_Val2014_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sFunding_Val2014_Baseline, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sFunding_Val2014_Baseline, "Payout Projection", "RollForward", true, true);



            thrd_Funding_Val2014_Baseline.Start();


            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region sFunding_Val2014_FinalResults

            pMain._SelectTab(sServiceVal2014);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            pMain._ValuationNodeProperties_ChangeReasons_Initialize();

            dic.Clear();
            dic.Add("LiabilityType", "PPA");
            dic.Add("ReasonforChange", "Other assumption changes");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "PBGC");
            dic.Add("ReasonforChange", "Other assumption changes");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "FAS 35");
            dic.Add("ReasonforChange", "Change in actuarial assumptions");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Final Results");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "True");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "Final Results Assumptions");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "True");
            dic.Add("Provisions_Name", "Final Results Provisions");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Data");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("CompareData", "");
            dic.Add("ImportDataandApplyMapping", "Click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "FAS35Int");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "6.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "PBGCInt");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "Click");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2014");
            pInterestRate._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AllOthers");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "Click");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("Rate", "PPA 3-segment rates");
            dic.Add("AsOfDate", "11/01/2013");
            pInterestRate._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "_Death");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "True");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("DisabledVsHealthy", "");
            dic.Add("MemberVsSpouse", "");
            pMortalityDecrement._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2014");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);

            pMain._SelectTab(sServiceVal2014);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("Level_3", "PlanAE");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("txtInterestRate", "");
            dic.Add("Mortality", "PPA2014CMF");
            pActuarialEquivalence._PopVerify_SameStructureForAllPeriods(dic);

            pMain._SelectTab(sServiceVal2014);
            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("MenuItem_1", "Asset Snapshots");
            pMain._MenuSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pParticipantDataSet._PopVerify_AssetSnapshot(dic);

            pMain._Home_ToolbarClick_Top(true);

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
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "BenefitService");
            dic.Add("Pay", "PensionEarningsPriorYear1");
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
            dic.Add("PPAAtRiskLiabilityForMinimum", "True");
            dic.Add("PPAAtRiskLiabilityForMaximum", "True");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            #endregion


            #region sFunding_Val2014_FinalResults - Funding Infornation & reports

            pMain._SelectTab(sServiceVal2014);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Funding Information");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Funding Information");

            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Contributions");
            pAssumptions._TreeViewSelect(dic);



            for (int iRow = 1; iRow <= 6; iRow++)
            {
                dic.Clear();
                dic.Add("iRow", iRow.ToString());
                dic.Add("Category", "");
                dic.Add("PlanYear", "2013");
                dic.Add("TaxYear", "");
                dic.Add("MinimumRequiredContribution", "Yes");
                dic.Add("ContributedByPBGC", "Yes");
                dic.Add("DeductedButNotIncluded", "");
                dic.Add("IncludedButNotDeducted", "");
                dic.Add("IncludeInPrefundingCreditBalance", "No");
                pFundingInformation._Contributions_Employer(dic);
            }



            dic.Clear();
            dic.Add("iRow", "7");
            dic.Add("Date", "03/15/2014");
            dic.Add("Category", "Cash");
            dic.Add("Amount", "6,500,000");
            dic.Add("PlanYear", "2013");
            dic.Add("TaxYear", "2013");
            dic.Add("MinimumRequiredContribution", "Yes");
            dic.Add("ContributedByPBGC", "Yes");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "No");
            dic.Add("IncludeInPrefundingCreditBalance", "No");
            pFundingInformation._Contributions_Employer(dic);


            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "General Parameters");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanYearBeginDate", "01/01/2014");
            dic.Add("PlanYearEndDate", "12/31/2014");
            dic.Add("CurrentYareNumOfParcipants", "525");
            dic.Add("YearsForShortfallAmortization", "");
            pFundingInformation._PopVerify_GI_GeneralInformation(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VoluntaryCOB", "0");
            dic.Add("ApplyCalculated_Yes", "");
            dic.Add("ApplyCalculated_No", "");
            dic.Add("ClientDecision_Yes", "true");
            dic.Add("ClientDecision_No", "");
            dic.Add("ClientDecision_Unknown", "");
            dic.Add("PBGCAgreement_Yes", "true");
            dic.Add("PBGCAgreement_No", "");
            dic.Add("PBGCAgreement_Unknown", "");
            pFundingInformation._PopVerify_GI_CarryoverBalance(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VoluntaryCOB", "0");
            dic.Add("ApplyCalculated_Yes", "");
            dic.Add("ApplyCalculated_No", "");
            dic.Add("ClientDecision_Yes", "true");
            dic.Add("ClientDecision_No", "");
            dic.Add("ClientDecision_Unknown", "");
            dic.Add("PBGCAgreement_Yes", "true");
            dic.Add("PBGCAgreement_No", "");
            dic.Add("PBGCAgreement_Unknown", "");
            pFundingInformation._PopVerify_GI_PrefundingBalance(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanSponsor_Yes", "");
            dic.Add("PlanSponsor_No", "true");
            dic.Add("PlanSponsor_Unknown", "");
            dic.Add("IncreaseDueToPlanAmendment", "0");
            dic.Add("ExemptFrom_Yes", "true");
            dic.Add("ExemptFrom_No", "");
            dic.Add("ExemptFrom_Unknown", "");
            dic.Add("IncreaseDueToShutdown", "0");
            dic.Add("OriginalPlanEffectiveDate", "01/01/1976");
            dic.Add("PlanWasFrozen_Yes", "");
            dic.Add("PlanWasFrozen_No", "true");
            dic.Add("PlanWasFrozen_Unknown", "");
            pFundingInformation._PopVerify_GI_BenefitRestriction(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CompanyName", "");
            dic.Add("Telephone", "8473177517");
            dic.Add("AddressLine1", "540 Lake Cook Road");
            dic.Add("AddressLine2", "Suite 600");
            dic.Add("AddressLine3", "Deerfield,IL 60015");
            dic.Add("Signer1Name", "Cynthia Geske");
            dic.Add("Signer1Credential", "Benchmarker Extraordinaire");
            dic.Add("Signer2Name", "Karen Lanctot");
            dic.Add("Signer2Credential", "Lowly Workerbee");
            dic.Add("PeerReviewName", "No Idea");
            dic.Add("PeerReviewCredentials", "Not Important");
            dic.Add("RoundingScalingOptions_Thousands69470000", "");
            pFundingInformation._PopVerify_GI_ActuarialReport(dic);


            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Prior Year Results");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SummaryView", "True");
            dic.Add("DetailView", "");
            dic.Add("TabName", "");
            pFundingInformation._PopVerify_PriorYearResults_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EIR2YearsAge", "5.05");
            dic.Add("EIR3YearsAge", "5.75");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_MiniumnContribution(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SummaryView", "");
            dic.Add("DetailView", "True");
            dic.Add("TabName", "");
            pFundingInformation._PopVerify_PriorYearResults_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OriginalPlanEffectDate", "01/01/1976");
            dic.Add("BeginningOfPlanYear", "01/01/2013");
            dic.Add("EndOfPlanYear", "12/31/2013");
            dic.Add("ValuationDate", "01/01/2013");
            dic.Add("ValuationYear", "2013");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_PlanDates(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("OriginalPlanEffectDate", "01/01/1976");
            dic.Add("BeginningOfPlanYear", "01/01/2013");
            dic.Add("EndOfPlanYear", "12/31/2013");
            dic.Add("ValuationDate", "01/01/2013");
            dic.Add("ValuationYear", "2013");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_PlanDates(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InactivesInPayStatus", "12");
            dic.Add("InactivesDeferredStatus", "63");
            dic.Add("VestedStatus", "");
            dic.Add("NonVestedStatus", "56");
            dic.Add("Total", "131");
            dic.Add("TotalPlanParticipants", "129");
            dic.Add("NumOfParticipants", "538");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_Data(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PirorYearNum", "538");
            dic.Add("Prong1Determination", "59.60");
            dic.Add("Prong1Threshold", "70.00");
            dic.Add("Prong2Determination", "6.24");
            dic.Add("Prong2Threshold", "65.00");
            dic.Add("PlanIsAtRisk", "Yes");
            dic.Add("IncludesExpenseLoad", "");
            dic.Add("ConsecutiveYears", "1");
            dic.Add("FTReflects", "20.00");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_AtRiskDetermination(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InPayStatus", "1,994,350");
            dic.Add("DeferredStatus", "2,847,031");
            dic.Add("VestedActives", "5,341,651");
            dic.Add("NonVestedActives", "879,778");
            dic.Add("Total", "11,062,810");
            dic.Add("NormalCost", "710,082");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_FTD_NotAtRisk(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ARNoExpenseRetiredAndBeneficiries", "19,963,762");
            dic.Add("ARNoExpenseTermVested", "49,335,776");
            dic.Add("ARNoExpenseVestedActives", "38,593,888");
            dic.Add("ARNoExpenseNonVestedActives", "20,439,982");
            dic.Add("ARNoExpenseTotal", "128,333,408");
            dic.Add("ARNoExpenseFundingNC", "6,620,822");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_FTD_AtRiskNoexpenseLoad(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ARApplicableRetiredAndBeneficiries", "19,963,762");
            dic.Add("ARApplicableTermVested", "49,335,776");
            dic.Add("ARApplicableVestedActives", "38,593,888");
            dic.Add("ARApplicableNonVestedActives", "20,439,982");
            dic.Add("ARApplicableTotal", "128,333,408");
            dic.Add("ARApplicableFundingNC", "6,620,822");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_FTD_AtRiskApplicable(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InPayStatus", "19,963,762");
            dic.Add("DeferredStatus", "49,335,776");
            dic.Add("VestedActives", "38,593,888");
            dic.Add("NonVestedActives", "20,439,982");
            dic.Add("Total", "128,333,408");
            dic.Add("NormalCost", "6,620,822");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_FTD_Final(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InPayStatus", "5,588,232");
            dic.Add("DeferredStatus", "12,144,780");
            dic.Add("VestedActives", "11,992,098");
            dic.Add("NonVestedActives", "4,791,819");
            dic.Add("Total", "34,516,929");
            dic.Add("Discounted", "");
            dic.Add("Expected", "");
            dic.Add("DiscountedExpected", "");
            dic.Add("NormalCost", "1,892,230");
            dic.Add("TotalNormalCost", "1,892,230");
            dic.Add("EffectiveInterestRate", "6.57");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_FTD_FundingTarget(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NotAtRiskLiability", "13,592,266");
            dic.Add("ExpenseLoad", "");
            dic.Add("AtRiskLiabilityNoExpense", "140,856,250");
            dic.Add("AtRiskLiabilityWithExpense", "140,856,250");
            dic.Add("FinalAtRisk", "140,856,250");
            dic.Add("FundingTarget", "39,045,063");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_MDC(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PBGCFlatRate_ParticipantCount", "129");
            dic.Add("PBGCFlatRate_PerParticipant", "34");
            dic.Add("PBGCFlatRate_FlatRatePremium", "4,386");
            dic.Add("NotAtRisk_InPayStatus", "1,912,319");
            dic.Add("NotAtRisk_DeferredStatus", "2,839,417");
            dic.Add("NotAtRisk_VestedActives", "5,274,609");
            dic.Add("NotAtRisk_Total", "10,026,345");
            ////////dic.Add("ExpenseLoad_InPayStatus", "19,963,762");
            ////////dic.Add("ExpenseLoad_DeferredStatus", "49,335,776");
            ////////dic.Add("ExpenseLoad_VestedActives", "38,593,888");
            ////////dic.Add("ExpenseLoad_Total", "107,893,426");
            dic.Add("AtRiskNoExpense_InPayStatus", "19,963,762");
            dic.Add("AtRiskNoExpense_DeferredStatus", "49,335,776");
            dic.Add("AtRiskNoExpense_VestedActives", "38,593,888");
            dic.Add("AtRiskNoExpense_Total", "107,893,426");
            dic.Add("AtRiskWithExpense_InPayStatus", "19,963,762");
            dic.Add("AtRiskWithExpense_DeferredStatus", "49,335,776");
            dic.Add("AtRiskWithExpense_VestedActives", "38,593,888");
            dic.Add("AtRiskWithExpense_Total", "107,893,426");
            dic.Add("FinalAtRisk_InPayStatus", "19,963,762");
            dic.Add("FinalAtRisk_DeferredStatus", "49,335,776");
            dic.Add("FinalAtRisk_VestedActives", "38,593,888");
            dic.Add("FinalAtRisk_Total", "107,893,426");
            dic.Add("PBGCTarget_InpayStatus", "5,522,608");
            dic.Add("PBGCTarget_DeferredStatus", "12,138,689");
            dic.Add("PBGCTarget_VestedActives", "11,938,465");
            dic.Add("PBGCTarget_Total", "29,599,762");
            dic.Add("PBGCTarget_MVofAssets", "5,384,275");
            dic.Add("PBGCVariable_Unfunded", "24,216,000");
            dic.Add("PBGCVariable_9Per1000", "217,944");
            dic.Add("PBGCVariable_NumOfEE", "538");
            dic.Add("PBGCVariable_ParticipantCount", "129");
            dic.Add("PBGCVariable_PerParticipant", "");
            dic.Add("PBGCVariable_PBGCVariable", "217,944");
            dic.Add("PBGCVariable_CombinedPBGC", "222,330");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_PGBCPremiums(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Liability_Actuarial", "10,820,270");
            dic.Add("Liability_NormalCost", "726,774");
            dic.Add("Liability_Interest", "715,917");
            dic.Add("Benefits_BenefitPayments", "199,801");
            dic.Add("Benefits_Administrative", "");
            dic.Add("Benefits_EmployeeContrib", "");
            dic.Add("Benefits_Total", "199,801");
            dic.Add("Benefits_ExpectedActuarial", "12,063,160");
            dic.Add("Benefits_LiabilityGL", "1,000,350");
            dic.Add("Asset_ActuarialAsset", "6,449,268");
            dic.Add("Asset_InterestOnActuarial", "399,855");
            dic.Add("Asset_ContributionsMade", "613,736");
            dic.Add("Asset_InterestOnContrib", "15,461");
            dic.Add("Asset_ExpectedActuarial", "7,278,519");
            dic.Add("Asset_ActuarialAssetGL", "-1,894,244");
            dic.Add("Asset_ActuarialGL", "-893,894");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_DevelopmentOfExperienceGL(dic);

            pMain._Home_ToolbarClick_Top(true);


            pAssumptions._SelectTab("FTAPs, Benefit Restrictions, and At-Risk Determination");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVOfAssets", "5,384,275");
            dic.Add("90ofMarketValue", "4,845,848");
            dic.Add("110ofMarketValue", "5,922,702");
            dic.Add("PreliminaryActuarial", "5,384,275");
            dic.Add("ActuarialValue", "5,384,275");
            dic.Add("AVAPFB", "5,384,275");
            dic.Add("AVACOBPFB", "5,284,275");
            dic.Add("Prior2YearsNHC", "");
            dic.Add("AVANHCPurchase", "5,384,275");
            dic.Add("AVACOBPFBNHCPurchase", "5,384,275");
            dic.Add("NARFundLiabNHCPurchase", "11,062,810");
            pFundingInformation_FTAPs._PopVerify_AssetNumbers(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FTAP", "48.67");
            dic.Add("FTAP_PFB", "48.67");
            dic.Add("FTAP_Exempt", "48.67");
            dic.Add("FTAP_AtRisk", "4.19");
            dic.Add("FTAP_SB_PFB", "15.59");
            dic.Add("FTAP_SB_NoPFB", "15.59");
            pFundingInformation_FTAPs._PopVerify_FTAPs(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ElectionToUse", "Yes");
            dic.Add("ShortfallFunded", "");
            dic.Add("EligibleForTransition", "Yes");
            dic.Add("ExemptFrom2007AFC", "Yes");
            dic.Add("2008", "15.59");
            dic.Add("2009", "");
            dic.Add("2010", "");
            dic.Add("IsPlanExempt", "");
            pFundingInformation_FTAPs._PopVerify_ShortfallBaseExemption(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CurrentYearTop25", "15.59");
            dic.Add("CurrentYear401", "14.78");
            dic.Add("CanUseCOB", "");
            dic.Add("QuarterlyContrib", "15.59");
            dic.Add("PBGC4010", "");
            pFundingInformation_FTAPs._PopVerify_OtherFTAPChecks(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Prong1", "75.00");
            dic.Add("Prong2", "70.00");
            dic.Add("PlanIsAtRiskNextYear", "Yes");
            dic.Add("PlanAtRiskPriorYear1", "");
            dic.Add("PlanAtRiskPriorYear2", "");
            dic.Add("NumOfYears", "1");
            dic.Add("ExpenseLoad", "");
            dic.Add("NextYearConsecutive", "2");
            dic.Add("FTNextYear", "40.00");
            pFundingInformation_FTAPs._PopVerify_AtRiskDeterminatinForFollowingYear(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FullyFundedFTAPExempt92Percent", ".596");
            dic.Add("FullyFundedFTAPExempt94Percent", ".4867");
            dic.Add("FullyFundedFTAPExempt96Percent", ".4867");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_FullyFunded(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AFTAPBefore", "48.67");
            dic.Add("IncreaseTo60", "1,253,411");
            dic.Add("IncreaseTo80", "3,465,973");
            dic.Add("RequiredCredit", "");
            dic.Add("FinalAFTAP_TotalWaiver", "");
            dic.Add("FinalAFTAP_FinalAFTAP", "48.67");
            pFundingInformation_FTAPs._PopVerify_PreliminaryAFTAPCalcuations(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FullyFundedCYExemption", "100.00");
            dic.Add("FullyFundedFTAPCYFTAP_Exempt", "48.67");
            dic.Add("ShutDownAmountNeededTo60Percent", "1,253,411");
            dic.Add("PlanAmendmentNeededTo80Percent", "3,465,973");
            dic.Add("LimitationFundingCharge", "1,253,411");
            dic.Add("AddtitionalFundingToAvoid", "1,253,411");
            pFundingInformation_FTAPs._PopVerify_BenefitRestributionsDeterminations(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AcceleratedDistributionAllowed", "None");
            dic.Add("AddtitionalFundingDoRestrictions", "Yes");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_FullyFunded(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CurrentYear_TreatPlan", "Yes");
            dic.Add("CurrentYear_In3Months", "59.60");
            dic.Add("CurrentYear_In6Months", "59.60");
            dic.Add("CurrentYear_After9Months", "");
            dic.Add("NextYear_In3Months", "48.67");
            dic.Add("NextYear_In6Months", "48.67");
            dic.Add("NextYear_After9Months", "");
            pFundingInformation_FTAPs._PopVerify_PresumedCurrentNextYear(dic);

            pMain._Home_ToolbarClick_Top(true);


            pAssumptions._SelectTab("Shortfall");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("COBAfter", "");
            dic.Add("PFBAfter", "");
            dic.Add("NetAssets", "5,384,275");
            dic.Add("FundingShortfall", "29,132,654");
            dic.Add("TransitionPercent", "94.32");
            dic.Add("TransitionFundingTarget", "27,061,638");
            dic.Add("TransitionFundingShortfall", "");
            pFundingInformation_Shortfall._PopVerify_NetAssets(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NewBaseAmount", "27,061,638");
            dic.Add("YearsForShortfall", "7");
            dic.Add("AmortizationFactor", "5.93863");
            dic.Add("ShortfallAmortizationInstallment", "4,556,882");
            dic.Add("TotalSAI", "586,153");
            dic.Add("ShortfallAmortizationCharge", "5,143,035");
            pFundingInformation_Shortfall._PopVerify_PVOfPriorYearsFundingWaiverBases(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CY", "5.32");
            dic.Add("CY1", "5.32");
            dic.Add("CY2", "5.32");
            dic.Add("CY3", "5.32");
            dic.Add("CY4", "5.32");
            dic.Add("CY5", "6.45");
            dic.Add("CY6", "6.45");
            dic.Add("CY7", "6.45");
            dic.Add("CY8", "6.45");
            dic.Add("CY9", "6.45");
            pFundingInformation_Shortfall._PopVerify_InterestRatesByYear(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CY", "1.00000");
            dic.Add("CY1", "0.94949");
            dic.Add("CY2", "0.90153");
            dic.Add("CY3", "0.85599");
            dic.Add("CY4", "0.81275");
            dic.Add("CY5", "0.73160");
            dic.Add("CY6", "0.68727");
            dic.Add("CY7", "0.64563");
            dic.Add("CY8", "0.60651");
            dic.Add("CY9", "0.56976");
            pFundingInformation_Shortfall._PopVerify_DiscountFactors(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Year1", "1.00000");
            dic.Add("Year2", "1.94949");
            dic.Add("Year3", "2.85102");
            dic.Add("Year4", "3.70701");
            dic.Add("Year5", "4.51976");
            dic.Add("Year6", "5.25136");
            dic.Add("Year7", "5.93863");
            dic.Add("Year8", "6.58426");
            dic.Add("Year9", "7.19077");
            dic.Add("Year10", "7.76053");
            pFundingInformation_Shortfall._PopVerify_AmortizationFactors(dic);

            pMain._Home_ToolbarClick_Top(true);


            pAssumptions._SelectTab("Contribution Summary");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TargetNormalCost", "7,035,265");
            dic.Add("FullFundingLimit", "31,024,884");
            dic.Add("MininumBefore", "7,035,265");
            dic.Add("PriorYearFunded", "Yes");
            dic.Add("COBUsed", "");
            dic.Add("PFBUsed", "");
            dic.Add("MinimumAfter", "7,035,265");
            dic.Add("MinimumAtEOY", "7,497,482");
            dic.Add("MinimumAtLast", "7,841,036");
            pFundingInformation_ContributionSummary._PopVerify_MinimumRequiredContribution(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Cushion_50ofFunding", "17,258,465");
            dic.Add("Cushion_FTIncrease", "4,528,134");
            dic.Add("Cushion_DeductionLimit", "52,811,483");
            dic.Add("Alternate_DeductionLimit", "129,569,955");
            dic.Add("Alternate_MaximumDeductible", "52,811,483");
            dic.Add("Interest_EarlierOf", "12/31/2013");
            dic.Add("Interest_Fractional", "1.000000");
            dic.Add("Interest_InterestTo", "9,208");
            dic.Add("Interest_MaximumDeductible", "52,820,691");
            pFundingInformation_ContributionSummary._PopVerify_MaximumDeductibleContribution(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Cushion_50ofFunding", "17,258,465");
            dic.Add("Cushion_FTIncrease", "4,528,134");
            dic.Add("Cushion_DeductionLimit", "52,811,483");
            dic.Add("Alternate_DeductionLimit", "129,569,955");
            dic.Add("Alternate_MaximumDeductible", "52,811,483");
            dic.Add("Interest_EarlierOf", "12/31/2013");
            dic.Add("Interest_Fractional", "1.000000");
            dic.Add("Interest_InterestTo", "9,208");
            dic.Add("Interest_MaximumDeductible", "52,820,691");
            pFundingInformation_ContributionSummary._PopVerify_MaximumDeductibleContribution(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FundingShortfall", "4,371,002");
            dic.Add("AmountPriorMRC", "1,312,927");
            dic.Add("AmountCurrentMRC", "6,331,739");
            dic.Add("QuaterlyAmount", "328,232");
            dic.Add("ShortfallCurrentYear", "Yes");
            dic.Add("QuaterlyAmountNextYear", "1,758,816");
            dic.Add("ContribtionDates_FinalPayment", "09/15/2014");
            pFundingInformation_ContributionSummary._PopVerify_QuaterlyContributionRequirement(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FirstQuaterly", "04/15/2013");
            dic.Add("SecondQuaterly", "07/15/2013");
            dic.Add("ThirdQuaterly", "10/15/2013");
            dic.Add("FourthQuaterly", "01/15/2014");
            dic.Add("FinalPaymeny", "");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_ContributionDates(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FundingShortfall", "");
            dic.Add("AmountPriorMRC", "");
            dic.Add("AmountCurrentMRC", "");
            dic.Add("QuaterlyAmount", "");
            dic.Add("ShortfallCurrentYear", "");
            dic.Add("QuaterlyAmountNextYear", "");
            dic.Add("ContribtionDates_FinalPayment", "");
            dic.Add("YearAndDaysFourthQuterly_Years", "1");
            dic.Add("YearAndDaysFinalPayment_Years", "1");
            dic.Add("YearAndDaysFirstQuaterly_Days", "104");
            dic.Add("YearAndDaysSecondQuaterly_Days", "195");
            dic.Add("YearAndDaysThirdQuaterly_Days", "287");
            dic.Add("YearAndDaysFourthQuaterly_Days", "14");
            dic.Add("YearAndDaysFinalPayment_Days", "257");
            dic.Add("YearAndDaysRemainingAmount", "6,437,778");
            dic.Add("DiscountedContributionFirstQuaterly", "322,335");
            dic.Add("DiscountedContributionSecondQuaterly", "317,261");
            dic.Add("DiscountedContributionThirdQuaterly", "312,213");
            dic.Add("DiscountedContributionFourthQuaterly", "307,246");
            dic.Add("DiscountedContributionFinalPayment", "5,776,210");
            dic.Add("CYContributionsFirstQuaterly", "328,232");
            dic.Add("CYContributionsSecondQuaterly", "328,232");
            dic.Add("CYContributionsThirdQuaterly", "328,232");
            dic.Add("CYContributionsFourthQuaterly", "328,232");
            dic.Add("CYContributionsFinalPayment", "6,437,778");
            pFundingInformation_ContributionSummary._PopVerify_QuaterlyContributionRequirement(dic);


            pMain._Home_ToolbarClick_Top(true);



            pMain._SelectTab(sServiceVal2014);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Funding Calculations");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_FundingCalculationRunCompleted(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "ASC 960 Reconciliation");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Yes", "");
            dic.Add("No", "");
            dic.Add("Message", "ASC 960 reconciliation run completed.");
            dic.Add("OK", "");
            pMain._PopVerify_Home_Confrim(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "");
            dic.Add("No", "");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_Home_Confrim(dic);


            pMain._SelectTab(sServiceVal2014);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_Others_PDF_EXCEL(sFunding_Val2014_FinalResults, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding_Val2014_FinalResults, "Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding_Val2014_FinalResults, "Funding Calculator Scenario", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sFunding_Val2014_FinalResults, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sFunding_Val2014_FinalResults, "Liability Scenario", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sFunding_Val2014_FinalResults, "Liability Scenario by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sFunding_Val2014_FinalResults, "Individual Output", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sFunding_Val2014_FinalResults, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sFunding_Val2014_FinalResults, "Payout Projection", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sFunding_Val2014_FinalResults, "Reconciliation to Baseline", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sFunding_Val2014_FinalResults, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding_Val2014_FinalResults, "Liabilities Detailed Results", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding_Val2014_FinalResults, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding_Val2014_FinalResults, "ASC 960 Reconciliation", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sFunding_Val2014_FinalResults, "Funding Calculator", "RollForward", false, true);



            pMain._SelectTab(sServiceVal2014);

            pMain._GenerateNewReport(sFunding_Val2014_FinalResults, "PPA Funding Valuation Report", 3);
            pMain._GenerateNewReport(sFunding_Val2014_FinalResults, "ASC 960 Letter", 3);

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US016CN", sFunding_Val2014_FinalResults_Prod, sFunding_Val2014_FinalResults);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sFunding_Val2014_FinalResults");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_FAS35PVAB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_FAS35PVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PBGCARPVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PBGCNARPVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPAARMax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPAARMin.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPAARPVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMin.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARPVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBGCARPVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPAARMax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPAARMin.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPAARPVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_FAS35PVAB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_FAS35PVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PBGCARPVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PBGCNARPVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPAARMax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPAARMin.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPAARPVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARMax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARMin.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARPVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PBGCARPVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPAARMax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPAARMin.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPAARPVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPANARMax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ASC960Reconciliation.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FundingCalculatorScenario.xlsx", 4, 0, 0, 0, true);
            }

            pMain._SelectTab(sServiceVal2014);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }


        void t_CompareRpt_Funding_Val2014_Baseline(string sFunding_Val2014_Baseline)
        {


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US016CN", sFunding_Val2014_Baseline_Prod, sFunding_Val2014_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sFunding_Val2014_Baseline");

                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PBGCARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPAARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPAARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPAARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_PBGCARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_PPAARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_PPAARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_PPAARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsByPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossStatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
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
