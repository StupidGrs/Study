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
using RetirementStudio._UIMaps.FromToAgeClasses;
using RetirementStudio._UIMaps.EligibilitiesClasses;
using RetirementStudio._UIMaps.SpecialEligibilitiesClasses;
using RetirementStudio._UIMaps.PayoutProjectionClasses;
using RetirementStudio._UIMaps.PayAverageClasses;
using RetirementStudio._UIMaps.VestingClasses;
using RetirementStudio._UIMaps.UnitFormulaClasses;
using RetirementStudio._UIMaps.CostOfLivingAdjustmentsClasses;
using RetirementStudio._UIMaps.EarlyRetirementFactorClasses;
using RetirementStudio._UIMaps.ActuarialEquivalenceClasses;
using RetirementStudio._UIMaps.ConversionFactorsClasses;
using RetirementStudio._UIMaps.FormOfPaymentClasses;
using RetirementStudio._UIMaps.Item415LimitsClasses;
using RetirementStudio._UIMaps.AdjustmentsClasses;
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
using RetirementStudio._UIMaps.FAEFormulaClasses;


namespace RetirementStudio._TestScripts_2019_cloud._TestScripts_US
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class US010_Cloud
    {
        public US010_Cloud()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 010 Cloud";
            Config.sPlanName = "QA US Benchmark 010 Cloud Plan";
            Config.sProductionVerison = "7.6";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;

            //_gLib._Report(_PassFailStep.Header, "Testing Starts at: " + DateTime.Now + "\t" + Environment.UserName);
        }


        #region Report Output Directory
        
        public string sOutputFunding_July2006Valuation = "";
        public string sOutputFunding_July2007Valuation = "";
        public string sOutputAccounting_July2006FASVal = "";
        public string sOutputAccounting_July2007FASVal = "";
        
        public string sOutputFunding_July2006Valuation_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_010_Drummond\Existing\July 2006 Valuation\000_7.5_Baseline\";
        public string sOutputFunding_July2007Valuation_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_010_Drummond\Existing\July 2007 Valuation\000_7.5_Baseline\";
        public string sOutputAccounting_July2006FASVal_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_010_Drummond\Existing\July 2006 FAS Val\000_7.5_Baseline\";
        public string sOutputAccounting_July2007FASVal_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_010_Drummond\Existing\July 2007 FAS Val\000_7.5_Baseline\";


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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_010_Drummond\Existing\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString() + "_Cloud";

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputFunding_July2006Valuation = _gLib._CreateDirectory(sMainDir + "July 2006 Valuation\\" + sPostFix + "\\");
                    sOutputFunding_July2007Valuation = _gLib._CreateDirectory(sMainDir + "July 2007 Valuation\\" + sPostFix + "\\");
                    sOutputAccounting_July2006FASVal = _gLib._CreateDirectory(sMainDir + "July 2006 FAS Val\\" + sPostFix + "\\");
                    sOutputAccounting_July2007FASVal = _gLib._CreateDirectory(sMainDir + "July 2007 FAS Val\\" + sPostFix + "\\");

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

                string sMainDir = sDir + "US010_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputFunding_July2006Valuation = _gLib._CreateDirectory(sMainDir + "\\Funding_July2006Valuation\\");
                sOutputFunding_July2007Valuation = _gLib._CreateDirectory(sMainDir + "\\Funding_July2007Valuation\\");
                sOutputAccounting_July2006FASVal = _gLib._CreateDirectory(sMainDir + "\\Accounting_July2006FASVal\\");
                sOutputAccounting_July2007FASVal = _gLib._CreateDirectory(sMainDir + "\\Accounting_July2007FASVal\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputFunding_July2006Valuation = @\"" + sOutputFunding_July2006Valuation + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_July2007Valuation = @\"" + sOutputFunding_July2007Valuation + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_July2006FASVal = @\"" + sOutputAccounting_July2006FASVal + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_July2007FASVal = @\"" + sOutputAccounting_July2007FASVal + "\";" + Environment.NewLine;

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
        public FromToAge pFromToAge = new FromToAge();
        public SpecialEligibilities pSpecialEligibilities = new SpecialEligibilities();
        public Eligibilities pEligibilities = new Eligibilities();
        public PayoutProjection pPayoutProjection = new PayoutProjection();
        public PayAverage pPayAverage = new PayAverage();
        public Vesting pVesting = new Vesting();
        public UnitFormula pUnitFormula = new UnitFormula();
        public ActuarialEquivalence pActuarialEquivalence = new ActuarialEquivalence();
        public CostOfLivingAdjustments pCostOfLivingAdjustments = new CostOfLivingAdjustments();
        public EarlyRetirementFactor pEarlyRetirementFactor = new EarlyRetirementFactor();
        public ConversionFactors pConversionFactors = new ConversionFactors();
        public FormOfPayment pFormOfPayment = new FormOfPayment();
        public Item415Limits p415Limits = new Item415Limits();
        public Adjustments pAdjustments = new Adjustments();
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
        public FAEFormula pFAEFormula = new FAEFormula();

        #endregion


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void _test_US010_Cloud()
        {

            #region MultiThreads
            
            Thread thrd_Funding_July2006Valuation = new Thread(() => new US010_Cloud().t_CompareRpt_Funding_July2006Valuation(sOutputFunding_July2006Valuation));
            Thread thrd_Funding_July2007Valuation = new Thread(() => new US010_Cloud().t_CompareRpt_Funding_July2007Valuation(sOutputFunding_July2007Valuation));
            Thread thrd_Accounting_July2006FASVal = new Thread(() => new US010_Cloud().t_CompareRpt_Accounting_July2006FASVal(sOutputAccounting_July2006FASVal));
            
            #endregion


            this.GenerateReportOuputDir();


            #region sOutputFunding_July2006Valuation


            //////////pMain._SelectTab("Home");

            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sClientName);
            //////////dic.Add("Level_2", Config.sPlanName);
            //////////dic.Add("Level_3", "FundingValuations");
            //////////pMain._HomeTreeViewSelect(0, dic);

            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("AddServiceInstance", "");
            //////////dic.Add("ServiceToOpen", "July 2006 Valuation");
            //////////pMain._PopVerify_Home_RightPane(dic);

            //////////pMain._SelectTab("July 2006 Valuation");


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
            //////////dic.Add("GenerateTestCaseOutput", "True");
            //////////dic.Add("IncludeGainLossResult", "");
            //////////dic.Add("Service", "CreditedService");
            //////////dic.Add("Pay", "N/A");
            //////////dic.Add("CurrentYear", "");
            //////////dic.Add("PriorYear", "True");
            //////////dic.Add("CashBanlance", "N/A");
            //////////dic.Add("Pension", "Beneficiary1Percent1");
            //////////dic.Add("AllLiabilityTypes", "");
            //////////dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            //////////dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            //////////dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            //////////dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "True");
            //////////dic.Add("FAS35PresentValueOfAccumulatedBenefits", "True");
            //////////dic.Add("FAS35PresentValueOfVestedBenefits", "True");
            //////////dic.Add("PPAAtRiskLiabilityForMinimum", "");
            //////////dic.Add("PPAAtRiskLiabilityForMaximum", "");
            //////////dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            //////////dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            //////////dic.Add("EntryAgeNormal", "");
            //////////dic.Add("PayoutProjectionCustomGroup", "");
            //////////dic.Add("RunValuation", "Click");
            //////////pMain._PopVerify_RunOptions(dic);


            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("OK", "Click");
            //////////pMain._PopVerify_EnterpriseRunSubmitted(dic);


            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "View Run Status");
            //////////pMain._FlowTreeRightSelect(dic);


            //////////pMain._EnterpriseRun("Group Job Successfully Complete", true);


            //////////pMain._SelectTab("July 2006 Valuation");

            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "View Output");
            //////////pMain._FlowTreeRightSelect(dic);


            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2006Valuation, "Liability Summary", "Conversion", true, true);
            //////////pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputFunding_July2006Valuation, "Liability Summary", "Conversion", true, true, 0);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2006Valuation, "Member Statistics", "Conversion", true, true);
            //////////pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputFunding_July2006Valuation, "Conversion Diagnostic", "Conversion", true, true, 0);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2006Valuation, "Test Case List", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2006Valuation, "Detailed Results", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2006Valuation, "Detailed Results by Plan Def", "Conversion", false, true);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2006Valuation, "Valuation Summary", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2006Valuation, "Individual Output", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2006Valuation, "IOE", "Conversion", false, true);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2006Valuation, "Parameter Print", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2006Valuation, "Test Cases", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2006Valuation, "Payout Projection", "Conversion", true, true);


            //////////thrd_Funding_July2006Valuation.Start();

            //////////pMain._SelectTab("Output Manager");
            //////////pMain._Home_ToolbarClick_Top(true);
            //////////pMain._Home_ToolbarClick_Top(false);

            //////////pMain._SelectTab("July 2006 Valuation");
            //////////pMain._Home_ToolbarClick_Top(true);
            //////////pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region sOutputFunding_July2007Valuation

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "July 2007 Valuation");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("July 2007 Valuation");


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
            dic.Add("Pay", "N/A");
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


            pMain._SelectTab("July 2007 Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_July2007Valuation, "Reconciliation to Prior Year", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_July2007Valuation, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Detailed Results", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Status Reconciliation", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Member Statistics", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2007Valuation, "Individual Checking Template", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Age Service Matrix", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Data Matching Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Combined Status Code Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Gain / Loss Status Reconciliation", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_July2007Valuation, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_July2007Valuation, "Active Decrement Gain / Loss Detail", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Decrement Age", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_July2007Valuation, "Gain / Loss Participant Listing", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2007Valuation, "Individual Output", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2007Valuation, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2007Valuation, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2007Valuation, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2007Valuation, "Payout Projection", "RollForward", true, true);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2007Valuation, "Age Service Matrix", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Liability Set for FSM Export", "RollForward", true, false);


            thrd_Funding_July2007Valuation.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("July 2007 Valuation");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);
            

            #endregion


            #region sOutputAccounting_July2006FASVal


            //////////pMain._SelectTab("Home");

            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sClientName);
            //////////dic.Add("Level_2", Config.sPlanName);
            //////////dic.Add("Level_3", "AccountingValuations");
            //////////pMain._HomeTreeViewSelect(0, dic);

            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("AddServiceInstance", "");
            //////////dic.Add("ServiceToOpen", "July 2006 FAS Val");
            //////////pMain._PopVerify_Home_RightPane(dic);

            //////////pMain._SelectTab("July 2006 FAS Val");

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
            //////////dic.Add("GenerateTestCaseOutput", "True");
            //////////dic.Add("IncludeGainLossResult", "");
            //////////dic.Add("Service", "$Service");
            //////////dic.Add("Pay", "N/A");
            //////////dic.Add("CurrentYear", "True");
            //////////dic.Add("PriorYear", "");
            //////////dic.Add("CashBanlance", "N/A");
            //////////dic.Add("Pension", "Benefit1DB");
            //////////dic.Add("AllLiabilityTypes", "");
            //////////dic.Add("Acc_ProjectedBenefitObligation", "True");
            //////////dic.Add("Acc_AccumulatedBenefitObligation", "True");
            //////////dic.Add("PayoutProjectionCustomGroup", "");
            //////////dic.Add("RunValuation", "Click");
            //////////dic.Add("OK", "");
            //////////pMain._PopVerify_RunOptions(dic);


            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("OK", "Click");
            //////////pMain._PopVerify_EnterpriseRunSubmitted(dic);


            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "View Run Status");
            //////////pMain._FlowTreeRightSelect(dic);


            //////////pMain._EnterpriseRun("Group Job Successfully Complete", true);

            //////////pMain._SelectTab("July 2006 FAS Val");

            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "View Output");
            //////////pMain._FlowTreeRightSelect(dic);


            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Liability Summary", "Conversion", true, false);
            //////////pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Liability Summary", "Conversion", true, false, 0);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Member Statistics", "Conversion", true, false);
            //////////pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Conversion Diagnostic", "Conversion", true, false, 0);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Conversion Diagnostic", "Conversion", true, false);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Test Case List", "Conversion", true, false);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Detailed Results", "Conversion", true, false);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Detailed Results by Plan Def", "Conversion", false, false);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Valuation Summary", "Conversion", true, false);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Individual Output", "Conversion", true, false);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2006FASVal, "IOE", "Conversion", false, false);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Parameter Print", "Conversion", true, false);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Test Cases", "Conversion", true, false);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Payout Projection", "Conversion", true, false);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2006FASVal, "FAS Expected Benefit Pmts", "Conversion", true, false);


            //////////thrd_Accounting_July2006FASVal.Start();


            //////////pMain._SelectTab("Output Manager");
            //////////pMain._Home_ToolbarClick_Top(true);
            //////////pMain._Home_ToolbarClick_Top(false);

            //////////pMain._SelectTab("July 2006 FAS Val");
            //////////pMain._Home_ToolbarClick_Top(true);
            //////////pMain._Home_ToolbarClick_Top(false);
            

            #endregion
            

            #region sOutputAccounting_July2007FASVal


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "July 2007 FAS Val");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("July 2007 FAS Val");

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
            dic.Add("Pay", "N/A");
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

            pMain._SelectTab("July 2007 FAS Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Reconciliation to Prior Year", "RollForward", true, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Reconciliation to Prior Year by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Detailed Results", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Detailed Results by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Status Reconciliation", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Member Statistics", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Individual Checking Template", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Age Service Matrix", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Data Matching Summary", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Combined Status Code Summary", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Gain / Loss Status Reconciliation", "RollForward", true, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Active Decrement Gain / Loss Detail", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Decrement Age", "RollForward", true, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Gain / Loss Participant Listing", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Valuation Summary", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Individual Output", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2007FASVal, "IOE", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Test Cases", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Payout Projection", "RollForward", true, false);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Age Service Matrix", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "FAS Expected Benefit Pmts", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Liability Set for Globe Export", "RollForward", true, false);
                

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("July 2007 FAS Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Parameter Print");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ParameterPrint_Standalone(sOutputAccounting_July2007FASVal);


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US010Cloud", sOutputAccounting_July2007FASVal_Cloud, sOutputAccounting_July2007FASVal);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting_July2007FASVal");
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
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossStatusReconciliation.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_ABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_ABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PBO.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_ABO.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx_2", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport.xlsx", 4, 0, 0, 0, true);
            }


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }


        void t_CompareRpt_Funding_July2006Valuation(string sOutputFunding_July2006Valuation)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US010Cloud", sOutputFunding_July2006Valuation_Cloud, sOutputFunding_July2006Valuation);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_July2006Valuation");
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
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        void t_CompareRpt_Funding_July2007Valuation(string sOutputFunding_July2007Valuation)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US010Cloud", sOutputFunding_July2007Valuation_Cloud, sOutputFunding_July2007Valuation);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_July2007Valuation");
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
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix_2.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforFSMExport.xlsx", 4, 0, 0, 0, true);
                Config.bThreadFinsihed = true;
            }
        }

        void t_CompareRpt_Accounting_July2006FASVal(string sOutputAccounting_July2006FASVal)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US010Cloud", sOutputAccounting_July2006FASVal_Cloud, sOutputAccounting_July2006FASVal);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting_July2006FASVal");
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
