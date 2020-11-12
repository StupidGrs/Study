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
using RetirementStudio._UIMaps.PayCreditClasses;
using RetirementStudio._UIMaps.CashBalanceClasses;
using RetirementStudio._UIMaps.PBGCPlanTerminationDefinitionClasses;
using RetirementStudio._UIMaps.PBGCDollarMaxClasses;
using RetirementStudio._UIMaps.IndividualOuputFieldDefinitionClasses;

namespace RetirementStudio._TestScripts._TestScripts_US
{
    /// <summary>
    /// Summary description for CodedUITest2
    /// </summary>
    [CodedUITest]
    public class _US012_CN
    {
        public _US012_CN()
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


        //public string sConversion = "";
        //public string s2008Valuatoin_Baseline = "";
        //public string s2008Valuatoin_PPAAssumptions = "";
        //public string s2008Valuatoin_BurnCOB = "";
        //public string sPlanTerminationSetup_ForBaseline = "";
        //public string sPlanTerminationSetup_HMLRetAge = "";
        //public string sPlanTerminationSetup_HighRetAge = "";
        //public string sPlanTerminationSetup_EarliestRetAge = "";
        //public string sPlanTerminationSetup_PBGC_Fields = "";
        public string sPlanTerminationSetup_PBGC_4044 = "";
        public string sAccountingConversion = "";
        public string sNode_Funding_PlanTerSetup_PBGC4044 = "";
        public string sService_Accounting_Conversion = "";
        public string sService_Funding_PlanTerSetup_PBGC = "";

        //public string sConversion_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_12_Knight\Production\Funding Valuation\Conversion\6.9_20160919_Franklin\";
        //public string s2008Valuatoin_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_12_Knight\Production\Funding Valuation\2008 Valuation\Baseline\6.9_20160919_Franklin\";
        //public string s2008Valuatoin_PPAAssumptions_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_12_Knight\Production\Funding Valuation\2008 Valuation\PPA Assumptions\6.9_20160919_Franklin\";
        //public string s2008Valuatoin_BurnCOB_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_12_Knight\Production\Funding Valuation\2008 Valuation\Burn COB\6.9_20160919_Franklin\";

        //public string sPlanTerminationSetup_ForBaseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_12_Knight\Production\Funding Valuation\Plan Termination Setup\For Baseline\6.9_20160919_Franklin\";
        //public string sPlanTerminationSetup_HMLRetAge_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_12_Knight\Production\Funding Valuation\Plan Termination Setup\HML Ret Age\6.9_20160919_Franklin\";
        //public string sPlanTerminationSetup_HighRetAge_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_12_Knight\Production\Funding Valuation\Plan Termination Setup\High Ret Age\6.9_20160919_Franklin\";
        //public string sPlanTerminationSetup_EarliestRetAge_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_12_Knight\Production\Funding Valuation\Plan Termination Setup\Earliest Ret Age\6.9_20160919_Franklin\";
        //public string sPlanTerminationSetup_PBGC_Fields_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_12_Knight\Production\Funding Valuation\Plan Termination Setup\PBGC_Fields\6.9_20160919_Franklin\";
        public string sPlanTerminationSetup_PBGC_4044_Prod = @"\\mercer.com\US_Data\Shared\DFL\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_12_Knight\Existing\Funding Valuation\Plan Termination Setup\PBGC_4044\20190221_QA1\";
        public string sAccountingConversion_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_12_Knight\Production\Accounting Valuation\Conversion\7.4_20190416_Franklin\";

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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_12_Knight\CreateNew\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);


                    //sConversion = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\Conversion\\" + sPostFix + "\\");
                    //s2008Valuatoin_Baseline = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\2008 Valuation\\Baseline\\" + sPostFix + "\\");
                    //s2008Valuatoin_PPAAssumptions = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\2008 Valuation\\PPA Assumptions\\" + sPostFix + "\\");
                    //s2008Valuatoin_BurnCOB = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\2008 Valuation\\Burn COB\\" + sPostFix + "\\");


                    //sPlanTerminationSetup_ForBaseline = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\Plan Termination Setup\\For Baseline\\" + sPostFix + "\\");
                    //sPlanTerminationSetup_HMLRetAge = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\Plan Termination Setup\\HML Ret Age\\" + sPostFix + "\\");
                    //sPlanTerminationSetup_HighRetAge = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\Plan Termination Setup\\High Ret Age\\" + sPostFix + "\\");
                    //sPlanTerminationSetup_EarliestRetAge = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\Plan Termination Setup\\Earliest Ret Age\\" + sPostFix + "\\");
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
                //sConversion = _gLib._CreateDirectory(sMainDir + "\\Conversion\\");
                //s2008Valuatoin_Baseline = _gLib._CreateDirectory(sMainDir + "\\s2008Valuatoin_Baseline\\");
                //s2008Valuatoin_PPAAssumptions = _gLib._CreateDirectory(sMainDir + "\\s2008Valuatoin_PPAAssumptions\\");
                //s2008Valuatoin_BurnCOB = _gLib._CreateDirectory(sMainDir + "\\2008Valuatoin_BurnCOB\\");

                //sPlanTerminationSetup_ForBaseline = _gLib._CreateDirectory(sMainDir + "\\sPlanTerminationSetup_ForBaseline\\");
                //sPlanTerminationSetup_HMLRetAge = _gLib._CreateDirectory(sMainDir + "\\sPlanTerminationSetup_HMLRetAge\\");
                //sPlanTerminationSetup_HighRetAge = _gLib._CreateDirectory(sMainDir + "\\sPlanTerminationSetup_HighRetAge\\");
                //sPlanTerminationSetup_EarliestRetAge = _gLib._CreateDirectory(sMainDir + "\\sPlanTerminationSetup_EarliestRetAge\\");
                //sPlanTerminationSetup_PBGC_Fields = _gLib._CreateDirectory(sMainDir + "\\PlanTerminationSetup_PBGC_Fields\\");
                sPlanTerminationSetup_PBGC_4044 = _gLib._CreateDirectory(sMainDir + "\\PlanTerminationSetup_PBGC_4044\\");
                sAccountingConversion = _gLib._CreateDirectory(sMainDir + "\\AccountingConversion\\");

            }

            string sContent = "";
            //sContent = sContent + "sConversion = @\"" + sConversion + "\";" + Environment.NewLine;
            //sContent = sContent + "s2008Valuatoin_Baseline = @\"" + s2008Valuatoin_Baseline + "\";" + Environment.NewLine;
            //sContent = sContent + "s2008Valuatoin_PPAAssumptions = @\"" + s2008Valuatoin_PPAAssumptions + "\";" + Environment.NewLine;
            //sContent = sContent + "s2008Valuatoin_BurnCOB = @\"" + s2008Valuatoin_BurnCOB + "\";" + Environment.NewLine;
            //sContent = sContent + "sPlanTerminationSetup_ForBaseline = @\"" + sPlanTerminationSetup_ForBaseline + "\";" + Environment.NewLine;
            //sContent = sContent + "sPlanTerminationSetup_HMLRetAge = @\"" + sPlanTerminationSetup_HMLRetAge + "\";" + Environment.NewLine;
            //sContent = sContent + "sPlanTerminationSetup_HighRetAge = @\"" + sPlanTerminationSetup_HighRetAge + "\";" + Environment.NewLine;
            //sContent = sContent + "sPlanTerminationSetup_EarliestRetAge = @\"" + sPlanTerminationSetup_EarliestRetAge + "\";" + Environment.NewLine;
            //sContent = sContent + "sPlanTerminationSetup_PBGC_Fields = @\"" + sPlanTerminationSetup_PBGC_Fields + "\";" + Environment.NewLine;
            sContent = sContent + "sPlanTerminationSetup_PBGC_4044 = @\"" + sPlanTerminationSetup_PBGC_4044 + "\";" + Environment.NewLine;
            sContent = sContent + "sAccountingConversion = @\"" + sAccountingConversion + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);

        }


        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();

        public PBGCPlanTerminationDefinition pPBGCPlanTerminationDefinition = new PBGCPlanTerminationDefinition();
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
        public PayCredit pPayCredit = new PayCredit();
        public CashBalance pCashBalance = new CashBalance();
        public PBGCDollarMax pPBGCDollarMax = new PBGCDollarMax();
        public IndividualOuputFieldDefinition pIndividualOuputFieldDefinition = new IndividualOuputFieldDefinition();



        #endregion
        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void _test_US012_CN()
        {


            sNode_Funding_PlanTerSetup_PBGC4044 = "PBGC_4044-20190821";
            sService_Accounting_Conversion = "Conversion-20190821";
            sService_Funding_PlanTerSetup_PBGC = "PBGC-20190821";

            this.GenerateReportOuputDir();


            #region sPlanTerminationSetup_PBGC_4044


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
            dic.Add("Name", sService_Funding_PlanTerSetup_PBGC);
            dic.Add("Parent", "Plan Termination Setup");
            dic.Add("ParentFinalValuationSet", "PBGC_Fields");
            dic.Add("PlanYearBeginningIn", "2008");
            dic.Add("FirstYearPlanUnderPPA", "2008");
            dic.Add("RSC", "");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", sService_Funding_PlanTerSetup_PBGC);
            pMain._PopVerify_Home_RightPane(dic);



            pMain._SelectTab(sService_Funding_PlanTerSetup_PBGC);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "PBGC_4044");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "True");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "True");
            dic.Add("Provisions_Name", "");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab(sService_Funding_PlanTerSetup_PBGC);



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Methods");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Funding", "");
            dic.Add("PBGCTermLiability", "");
            dic.Add("NondiscriminationTesting", "");
            dic.Add("BenefitExclusions_DthLiab", "");
            dic.Add("BenefitExclusions_InacLiab", "");
            dic.Add("BenefitExclusions_InactDIDLiab", "");
            dic.Add("BenefitExclusions_RetLiab", "");
            dic.Add("BenefitExclusions_WthDIDLiab", "");
            dic.Add("BenefitExclusions_WthLiab", "");
            dic.Add("CostMethod", "");
            dic.Add("PBGC4044Calculation", "True");
            dic.Add("UseRetirementDecrements", "True");
            dic.Add("ServiceForServiceProrate", "");
            dic.Add("CompareToAccrue", "");
            dic.Add("AllowNegativeNormalCost", "");
            dic.Add("btnStartAge_V", "");
            dic.Add("StartAge_cbo", "");
            dic.Add("btnStartAge_C", "");
            dic.Add("StartAge_txt", "");
            dic.Add("UsePresentValueOfFutureSalary", "");
            dic.Add("UsePresentValueOfFutureService", "");
            dic.Add("ProjectedPayToUseForCoveredPay", "");
            dic.Add("AccumulationToUseForExpected", "");
            dic.Add("IncludePVFutureSalaryService", "");
            dic.Add("btnStopPVFuture_V", "");
            dic.Add("StopPVFuture_cbo", "");
            dic.Add("btnStopPVFuture_C", "");
            dic.Add("StopPVFuture_txt", "");
            dic.Add("BeginningOfTheYearPVFuture", "");
            dic.Add("CalculatePresentValueOfFuture", "");
            dic.Add("CalculatePresentValueOfFuture_txt", "");
            pMethods._PopVerify_Methods(dic);


            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab(sService_Funding_PlanTerSetup_PBGC);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "TERM11");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "_Disability");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Other", "");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "DIS851");
            dic.Add("Service", "");
            dic.Add("AdjustmentOperator", "");
            dic.Add("Adjustment_C", "");
            dic.Add("Adjustment_P", "");
            dic.Add("Adjustment_T", "");
            dic.Add("Adjustment_txt", "");
            dic.Add("Adjustment_Tcbo", "");
            dic.Add("Adjustment_Tcbo_extend", "");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);


            pMain._Home_ToolbarClick_Top(true);




            pMain._SelectTab(sService_Funding_PlanTerSetup_PBGC);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Provisions");



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "PBGC Dollar Max");
            dic.Add("MenuItem", "Add PBGC Dollar Max");
            pAssumptions._TreeViewRightSelect(dic, "PBGCDollarMax1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "PBGC Dollar Max");
            dic.Add("Level_3", "PBGCDollarMax1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("UserDefinedFOPAdjustment", "");
            dic.Add("CustomCode", "");
            pPBGCDollarMax._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IgnoreAgeAdjustment", "");
            dic.Add("LawYear_ValuationYearPlus", "True");
            dic.Add("LawYear_ValuationYearsPlus_txt", "");
            dic.Add("LawYear_SpecifiedYear", "");
            dic.Add("LawYear_SpecifiedYear_txt", "");
            dic.Add("FOP_FormOfPayment", "Single life");
            dic.Add("FOP_GuaranteePeriod_txt", "3");
            dic.Add("FOP_SurvivorPercent_txt", "");
            pPBGCDollarMax._PopVerify_Standard(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "PBGC Dollar Max");
            dic.Add("MenuItem", "Add PBGC Dollar Max");
            pAssumptions._TreeViewRightSelect(dic, "PBGCDollarMax2");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "PBGC Dollar Max");
            dic.Add("Level_3", "PBGCDollarMax2");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("UserDefinedFOPAdjustment", "");
            dic.Add("CustomCode", "");
            pPBGCDollarMax._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IgnoreAgeAdjustment", "");
            dic.Add("LawYear_ValuationYearPlus", "True");
            dic.Add("LawYear_ValuationYearsPlus_txt", "");
            dic.Add("LawYear_SpecifiedYear", "");
            dic.Add("LawYear_SpecifiedYear_txt", "");
            dic.Add("FOP_FormOfPayment", "Joint and survivor");
            dic.Add("FOP_GuaranteePeriod_txt", "");
            dic.Add("FOP_SurvivorPercent_txt", "");
            pPBGCDollarMax._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "PBGC Dollar Max");
            dic.Add("MenuItem", "Add PBGC Dollar Max");
            pAssumptions._TreeViewRightSelect(dic, "PBGCDollarMax3");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "PBGC Dollar Max");
            dic.Add("Level_3", "PBGCDollarMax3");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("UserDefinedFOPAdjustment", "True");
            dic.Add("CustomCode", "");
            pPBGCDollarMax._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IgnoreAgeAdjustment", "True");
            dic.Add("LawYear_ValuationYearPlus", "");
            dic.Add("LawYear_ValuationYearsPlus_txt", "");
            dic.Add("LawYear_SpecifiedYear", "True");
            dic.Add("LawYear_SpecifiedYear_txt", "");
            dic.Add("FOP_FormOfPayment", "");
            dic.Add("FOP_GuaranteePeriod_txt", "");
            dic.Add("FOP_SurvivorPercent_txt", "");
            dic.Add("User_DefinedFormOfPaymentAdjustment_txt", "0.75");
            pPBGCDollarMax._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "PBGC Dollar Max");
            dic.Add("MenuItem", "Add PBGC Dollar Max");
            pAssumptions._TreeViewRightSelect(dic, "PBGCDollarMax4");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "PBGC Dollar Max");
            dic.Add("Level_3", "PBGCDollarMax4");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("UserDefinedFOPAdjustment", "");
            dic.Add("CustomCode", "True");
            pPBGCDollarMax._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "1234");
            dic.Add("Validate", "Click");
            dic.Add("isInputName", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Adjustments");
            dic.Add("Level_3", "GetFGMin");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LoadingFactor_V", "");
            dic.Add("LoadingFactor_C", "Click");
            dic.Add("LoadingFactor_T", "");
            dic.Add("LoadingFactor_cboV", "");
            dic.Add("LoadingFactor_txt", "1.0");
            dic.Add("LoadingFactor_cboT", "");
            dic.Add("ApplyTo", "Present value");
            pAdjustments._PopVerify_Main(dic);

            pMain._Home_ToolbarClick_Top(true);




            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "InactiveBenefits");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PBGC4044Calculations", "True");
            dic.Add("PBGC4044_BenefitBelongsInPBGC", "True");
            dic.Add("PBGC4044_PriorityCategory", "PC0");
            dic.Add("PBGC4044_BenefitCommenceAge", "True");
            dic.Add("PBGC4044_AgeAtValYear3", "");
            dic.Add("PBGC4044_ApplyPBGCMaxBenefit", "True");
            dic.Add("PBGC4044_PBGCMaxBenefit", "PBGCDollarMax4");
            dic.Add("PBGC4044_ApplyMinBenefit", "True");
            dic.Add("PBGC4044_MinBenefit", "AccruedBenefit1");
            pPlanDefinition._PopVerify_PBGC4044Parameters(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "AnnForRetAge");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("PBGC4044Calculations", "True");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "GfErf");
            dic.Add("LateRetirementFactor", "LRF");
            dic.Add("AdjustmentFactor", "GetFGMin");
            dic.Add("ConversionFactor", "DefLAtoLS");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "LifeOnly");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Disability");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("PBGC4044Calculations", "");
            dic.Add("PBGC4044_BenefitBelongsInPBGC", "True");
            dic.Add("PBGC4044_PriorityCategory", "PC1");
            dic.Add("PBGC4044_BenefitCommenceAge", "");
            dic.Add("PBGC4044_AgeAtValYear3", "True");
            dic.Add("PBGC4044_ApplyPBGCMaxBenefit", "True");
            dic.Add("PBGC4044_PBGCMaxBenefit", "PBGCDollarMax1");
            dic.Add("PBGC4044_ApplyMinBenefit", "");
            dic.Add("PBGC4044_MinBenefit", "");
            pPlanDefinition._PopVerify_PBGC4044Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "CashBalAnn");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("PBGC4044Calculations", "True");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "ImmLStoLA");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "LifeOnly");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("PBGC4044Calculations", "");
            dic.Add("PBGC4044_BenefitBelongsInPBGC", "True");
            dic.Add("PBGC4044_PriorityCategory", "PC2");
            dic.Add("PBGC4044_BenefitCommenceAge", "True");
            dic.Add("PBGC4044_AgeAtValYear3", "");
            dic.Add("PBGC4044_ApplyPBGCMaxBenefit", "True");
            dic.Add("PBGC4044_PBGCMaxBenefit", "PBGCDollarMax2");
            dic.Add("PBGC4044_ApplyMinBenefit", "");
            dic.Add("PBGC4044_MinBenefit", "");
            pPlanDefinition._PopVerify_PBGC4044Parameters(dic);




            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "BenForRetAge");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("PBGC4044Calculations", "True");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "LifeOnly");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Death");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("PBGC4044Calculations", "");
            dic.Add("PBGC4044_BenefitBelongsInPBGC", "True");
            dic.Add("PBGC4044_PriorityCategory", "PC3");
            dic.Add("PBGC4044_BenefitCommenceAge", "True");
            dic.Add("PBGC4044_AgeAtValYear3", "");
            dic.Add("PBGC4044_ApplyPBGCMaxBenefit", "True");
            dic.Add("PBGC4044_PBGCMaxBenefit", "PBGCDollarMax3");
            dic.Add("PBGC4044_ApplyMinBenefit", "");
            dic.Add("PBGC4044_MinBenefit", "");
            pPlanDefinition._PopVerify_PBGC4044Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "GfMin");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("PBGC4044Calculations", "True");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "#1#");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "LumpSum");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("PBGC4044Calculations", "");
            dic.Add("PBGC4044_BenefitBelongsInPBGC", "True");
            dic.Add("PBGC4044_PriorityCategory", "PC4");
            dic.Add("PBGC4044_BenefitCommenceAge", "True");
            dic.Add("PBGC4044_AgeAtValYear3", "");
            dic.Add("PBGC4044_ApplyPBGCMaxBenefit", "");
            dic.Add("PBGC4044_PBGCMaxBenefit", "");
            dic.Add("PBGC4044_ApplyMinBenefit", "True");
            dic.Add("PBGC4044_MinBenefit", "AccruedBenefit1");
            dic.Add("PBGC4044_ApplyPhaseIn", "True");
            dic.Add("PBGC4044_BenefitValYear1", "");
            dic.Add("PBGC4044_BenefitValYear2", "");
            dic.Add("PBGC4044_BenefitValYear3", "");
            dic.Add("PBGC4044_BenefitValYear4", "AccruedBenefit1");
            dic.Add("PBGC4044_BenefitValYear5", "PayCredits");
            pPlanDefinition._PopVerify_PBGC4044Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "GfMin_(PC4)");
            dic.Add("Level_4", "GfErElig");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("PBGC4044Calculations", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "LifeOnly");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);




            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "ActiveRetire");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("PBGC4044Calculations", "True");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("PBGC4044Calculations", "");
            dic.Add("PBGC4044_BenefitBelongsInPBGC", "True");
            dic.Add("PBGC4044_PriorityCategory", "PC5");
            dic.Add("PBGC4044_BenefitCommenceAge", "True");
            dic.Add("PBGC4044_AgeAtValYear3", "");
            dic.Add("PBGC4044_ApplyPBGCMaxBenefit", "");
            dic.Add("PBGC4044_PBGCMaxBenefit", "");
            dic.Add("PBGC4044_ApplyMinBenefit", "True");
            dic.Add("PBGC4044_MinBenefit", "CashBalAnn");
            dic.Add("PBGC4044_ApplyPhaseIn", "");
            dic.Add("PBGC4044_BenefitValYear1", "");
            dic.Add("PBGC4044_BenefitValYear2", "");
            dic.Add("PBGC4044_BenefitValYear3", "");
            dic.Add("PBGC4044_BenefitValYear4", "");
            dic.Add("PBGC4044_BenefitValYear5", "");
            pPlanDefinition._PopVerify_PBGC4044Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "ActiveRetire_(PC5)");
            dic.Add("Level_4", "RetElig");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("PBGC4044Calculations", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "LumpSum");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("PBGC4044Calculations", "");
            dic.Add("PBGC4044_BenefitBelongsInPBGC", "");
            dic.Add("PBGC4044_PriorityCategory", "");
            dic.Add("PBGC4044_BenefitCommenceAge", "");
            dic.Add("PBGC4044_AgeAtValYear3", "");
            dic.Add("PBGC4044_ApplyPBGCMaxBenefit", "");
            dic.Add("PBGC4044_PBGCMaxBenefit", "");
            dic.Add("PBGC4044_ApplyMinBenefit", "True");
            dic.Add("PBGC4044_MinBenefit", "CashBalAnn");
            dic.Add("PBGC4044_ApplyPhaseIn", "");
            dic.Add("PBGC4044_BenefitValYear1", "");
            dic.Add("PBGC4044_BenefitValYear2", "");
            dic.Add("PBGC4044_BenefitValYear3", "");
            dic.Add("PBGC4044_BenefitValYear4", "");
            dic.Add("PBGC4044_BenefitValYear5", "");
            pPlanDefinition._PopVerify_PBGC4044Parameters(dic);





            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "ActiveTeam");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("PBGC4044Calculations", "True");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "PlanErf180360");
            dic.Add("LateRetirementFactor", "LRF");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "DefLAtoLS");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "LumpSum");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("PBGC4044Calculations", "");
            dic.Add("PBGC4044_BenefitBelongsInPBGC", "True");
            dic.Add("PBGC4044_PriorityCategory", "PC6");
            dic.Add("PBGC4044_BenefitCommenceAge", "");
            dic.Add("PBGC4044_AgeAtValYear3", "True");
            dic.Add("PBGC4044_ApplyPBGCMaxBenefit", "True");
            dic.Add("PBGC4044_PBGCMaxBenefit", "PBGCDollarMax4");
            dic.Add("PBGC4044_ApplyMinBenefit", "");
            dic.Add("PBGC4044_MinBenefit", "");
            dic.Add("PBGC4044_ApplyPhaseIn", "");
            dic.Add("PBGC4044_BenefitValYear1", "");
            dic.Add("PBGC4044_BenefitValYear2", "");
            dic.Add("PBGC4044_BenefitValYear3", "");
            dic.Add("PBGC4044_BenefitValYear4", "");
            dic.Add("PBGC4044_BenefitValYear5", "");
            pPlanDefinition._PopVerify_PBGC4044Parameters(dic);





            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "ActiveDeath");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("PBGC4044Calculations", "True");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            pMain._Home_ToolbarClick_Top(true);






            pMain._SelectTab(sService_Funding_PlanTerSetup_PBGC);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Individual Output");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "Click");
            dic.Add("RemoveRow", "");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pIndividualOuputFieldDefinition._PopVerify_IndividualOuputFieldDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("VOShortName", "");
            dic.Add("OutputLabel", "PBGCDollarMax1");
            dic.Add("Index_V", "Click");
            dic.Add("Index", "$ValAge");
            pIndividualOuputFieldDefinition._Table(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "Click");
            dic.Add("RemoveRow", "");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pIndividualOuputFieldDefinition._PopVerify_IndividualOuputFieldDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("VOShortName", "");
            dic.Add("OutputLabel", "PBGCDollarMax2");
            dic.Add("Index_V", "Click");
            dic.Add("Index", "$FullRetAge");
            pIndividualOuputFieldDefinition._Table(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "Click");
            dic.Add("RemoveRow", "");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pIndividualOuputFieldDefinition._PopVerify_IndividualOuputFieldDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("VOShortName", "");
            dic.Add("OutputLabel", "PBGCDollarMax3");
            dic.Add("Index_V", "");
            dic.Add("Index", "");
            dic.Add("Index_C", "Click");
            dic.Add("Index_txt", "60");
            pIndividualOuputFieldDefinition._Table(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "Click");
            dic.Add("RemoveRow", "");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pIndividualOuputFieldDefinition._PopVerify_IndividualOuputFieldDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("VOShortName", "");
            dic.Add("OutputLabel", "PBGCDollarMax4");
            dic.Add("Index_V", "Click");
            dic.Add("Index", "Rule65NoGrow");
            pIndividualOuputFieldDefinition._Table(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "");
            dic.Add("RemoveRow", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pIndividualOuputFieldDefinition._PopVerify_IndividualOuputFieldDefinition(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab(sService_Funding_PlanTerSetup_PBGC);


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

            pMain._SelectTab(sService_Funding_PlanTerSetup_PBGC);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab(sService_Funding_PlanTerSetup_PBGC);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_Others_PDF_EXCEL(sPlanTerminationSetup_PBGC_4044, "Parameter Print", "RollForward", true, true);


            pOutputManager._ExportReport_Common_PDF_EXCEL(sPlanTerminationSetup_PBGC_4044, "PBGC 4044 Liabilities by Plan Def", "RollForward", false, true);


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
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US012CN", sPlanTerminationSetup_PBGC_4044_Prod, sPlanTerminationSetup_PBGC_4044);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sPlanTerminationSetup_PBGC_4044");

                _compareReportsLib.CompareExcel_Exact("PBGC4044LiabilitiesbyPlanDef.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);

                Config.bThreadFinsihed = true;

            }

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab(sService_Funding_PlanTerSetup_PBGC);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion



            #region sAccountingConversion

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "true");
            dic.Add("Name", sService_Accounting_Conversion);
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "2007");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", sService_Accounting_Conversion);
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab(sService_Accounting_Conversion);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Data");
            dic.Add("MenuItem_2", "Copy Data...");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceType", "FundingValuations");
            dic.Add("ServiceInstance", "Conversion");
            dic.Add("iItemIndex", "1");
            dic.Add("OK", "Click");
            pMain._PopVerify_CopyParticipantDataSet(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", sService_Accounting_Conversion);
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Copy Provisions...");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", "");
            dic.Add("Plan", "");
            dic.Add("ServiceType", "FundingValuations");
            dic.Add("ServiceInstance", "Conversion");
            dic.Add("iTableItemIndex", "1");
            dic.Add("CopyAllParameters", "");
            dic.Add("CopyParameterChanges", "");
            dic.Add("OK", "click");
            pMain._PopVerify_CopyProvisionSet(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", sService_Accounting_Conversion);
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "6.41");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "Cbint");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "Cbint");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "5.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("MenuItem", "Add Pay Increase");
            pAssumptions._TreeViewRightSelect(dic, "SX");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SX");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "Click");
            dic.Add("btnT", "");
            dic.Add("txtRate", "4.5");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumption");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnPayLimitIncrease_V", "");
            dic.Add("btnPayLimitIncrease_Percent", "Click");
            dic.Add("btnPayLimitIncrease_T", "");
            dic.Add("PayLimitIncrease_V_cbo", "");
            dic.Add("PayLimitIncrease_txt", "3.0");
            dic.Add("PayLimitIncrease_T_cbo", "");
            dic.Add("btn415LimitIncrease_V", "");
            dic.Add("btn415LimitIncrease_Percent", "Click");
            dic.Add("btn415LimitIncrease_T", "");
            dic.Add("415LimitIncrease_V_cbo", "");
            dic.Add("415LimitIncrease_txt", "3.0");
            dic.Add("415LimitIncrease_T_cbo", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "_Death");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "RP07CW");
            dic.Add("Mortality_Setback_M", "");
            dic.Add("Mortality_Setback_F", "");
            dic.Add("Disabled", "");
            dic.Add("Disabled_Setback_M", "");
            dic.Add("Disabled_Setback_F", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "NEWRET2");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "RetElig");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pAssumptions._SelectTab("Parameters");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "NEWRET2");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pMain._Home_ToolbarClick_Top(true);




            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("Level_4", "RetElig");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "NEWRET2");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "TERM08");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "RetElig");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab(sService_Accounting_Conversion);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Provisions");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("Level_3", "ImmLAtoLS");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType_From", "");
            dic.Add("MortalityInDeferralPeriod_From", "");
            dic.Add("ActuarialEquivalence_From", "");
            dic.Add("ApplySpouseAgeDifference_From", "");
            dic.Add("FormOfPaymentType_To", "");
            dic.Add("MortalityInDeferralPeriod_To", "");
            dic.Add("ActuarialEquivalence_To", "");
            dic.Add("ApplySpouseAgeDifference_To", "");
            dic.Add("btnGuaranteePeriod_From_V", "");
            dic.Add("GuaranteePeriod_From_cbo", "");
            dic.Add("btnGuaranteePeriod_From_C", "Click");
            dic.Add("GuaranteePeriod_From_txt", "");
            dic.Add("btnSurvivorPercentage_From_V", "");
            dic.Add("SurvivorPercentage_From_cbo", "");
            dic.Add("btnSurvivorPercentage_From_Percent", "Click");
            dic.Add("SurvivorPercentage_From_txt", "");
            dic.Add("btnPopupAmount_From_V", "");
            dic.Add("PopupAmount_From_cbo", "");
            dic.Add("btnPopupAmount_From_C", "Click");
            dic.Add("PopupAmount_From_txt", "");
            dic.Add("btnBenefitCommenceAge_From_V", "");
            dic.Add("BenefitCommenceAge_From_cbo", "");
            dic.Add("btnBenefitCommenceAge_From_C", "Click");
            dic.Add("BenefitCommenceAge_From_txt", "55");
            dic.Add("btnBenefitStopAge_From_V", "");
            dic.Add("BenefitStopAge_From_cbo", "");
            dic.Add("btnBenefitStopAge_From_C", "Click");
            dic.Add("BenefitStopAge_From_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_From_V", "");
            dic.Add("NumberOfPaymentsPerYear_From_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_From_C", "Click");
            dic.Add("NumberOfPaymentsPerYear_From_txt", "");
            dic.Add("btnGuaranteePeriod_To_V", "");
            dic.Add("GuaranteePeriod_To_cbo", "");
            dic.Add("btnGuaranteePeriod_To_C", "Click");
            dic.Add("GuaranteePeriod_To_txt", "");
            dic.Add("btnSurvivorPercentage_To_V", "");
            dic.Add("SurvivorPercentage_To_cbo", "");
            dic.Add("btnSurvivorPercentage_To_Percent", "Click");
            dic.Add("SurvivorPercentage_To_txt", "");
            dic.Add("btnPopupAmount_To_V", "");
            dic.Add("PopupAmount_To_cbo", "");
            dic.Add("btnPopupAmount_To_C", "Click");
            dic.Add("PopupAmount_To_txt", "");
            dic.Add("btnBenefitCommenceAge_To_V", "");
            dic.Add("BenefitCommenceAge_To_cbo", "");
            dic.Add("btnBenefitCommenceAge_To_C", "Click");
            dic.Add("BenefitCommenceAge_To_txt", "21");
            dic.Add("btnBenefitStopAge_To_V", "");
            dic.Add("BenefitStopAge_To_cbo", "");
            dic.Add("btnBenefitStopAge_To_C", "");
            dic.Add("BenefitStopAge_To_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_To_V", "");
            dic.Add("NumberOfPaymentsPerYear_To_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_To_C", "");
            dic.Add("NumberOfPaymentsPerYear_To_txt", "");
            pConversionFactors._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "415 Limits");
            dic.Add("MenuItem", "Add 415 Limits");
            pAssumptions._TreeViewRightSelect(dic, "LS415");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "415 Limits");
            dic.Add("Level_3", "LS415");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DeterminLimitBasedOn", "");
            dic.Add("DeterminLimitBasedOn_Year", "");
            dic.Add("IncreaseAppliesUntil", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "55");
            dic.Add("EarlyRetirementFator", "PlanErf180360");
            dic.Add("LateRetirementFactor", "LRF");
            dic.Add("PlanNormalFormOfPayment", "LifeOnly");
            dic.Add("ConversionFactorNormalFromToStraightLife", "");
            dic.Add("btnPlanNormalFromStopAge_V", "");
            dic.Add("PlanNormalFromStopAge_cbo", "");
            dic.Add("btnPlanNormalFromStopAge_C", "");
            dic.Add("PlanNormalFromStopAge_txt", "");
            dic.Add("PlanActuarialEquivalence", "LS417e");
            dic.Add("415LimitFormOfPayement", "LumpSum");
            dic.Add("ConversionFactorNormalFromTo415Limit", "ImmLAtoLS");
            dic.Add("btn415LimitFormStopAge_V", "");
            dic.Add("415LimitFormStopAge_cbo", "");
            dic.Add("btn415LimitFormStopAge_C", "");
            dic.Add("415LimitFormStopAge_txt", "");
            dic.Add("ParticipationService", "$Service");
            dic.Add("MandatoryEmployeeContribution", "");
            dic.Add("ProjectedPayForAlternative", "SalPrj");
            dic.Add("EmploymentService", "SVC");
            p415Limits._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Adjustments");
            dic.Add("Level_3", "GetFGMin");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LoadingFactor_V", "");
            dic.Add("LoadingFactor_C", "");
            dic.Add("LoadingFactor_T", "");
            dic.Add("LoadingFactor_cboV", "");
            dic.Add("LoadingFactor_txt", "");
            dic.Add("LoadingFactor_cboT", "");
            dic.Add("ApplyTo", "Benefit after 415 application");
            pAdjustments._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "GfMin");
            dic.Add("Level_4", "GfErElig");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "55");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            dic.Add("MenuItem", "Add Vesting");
            pAssumptions._TreeViewRightSelect(dic, "ImmediateVesting");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            dic.Add("Level_3", "ImmediateVesting");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("YearsOfService", "0");
            dic.Add("VestingPercentage", "100.0");
            pVesting._ServiceTable(dic);

            pMain._SelectTab(sService_Accounting_Conversion);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Methods");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "Projected Unit Credit No Prorate");
            dic.Add("ServiceForServiceProrate", "");
            dic.Add("CompareToAccrue", "True");
            dic.Add("AllowNegativeNormalCost", "");
            dic.Add("ProjectedpayToUse", "");
            dic.Add("AccumulationToUse", "");
            dic.Add("IncludeExitYearValue", "");
            dic.Add("CalculatePresentValueOfFuture", "");
            dic.Add("CalculatePresentValueOfFuture_txt", "");
            dic.Add("VestingToUseForAgeFirstVested", "ImmediateVesting");
            dic.Add("AverageWorkingLifeTime", "");
            dic.Add("AverageLifeTime", "True");
            dic.Add("AverageWorkingLifeTimeToVesting", "");
            dic.Add("AverageWorkingLifeTimeForBenefitingEE", "");
            pMethods._PopVerify_Methods_Accounting(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("Formula", "CashBal");
            dic.Add("PUCOverrides", "Projected Unit Credit Service Prorate");
            dic.Add("TUCOverrides", "");
            dic.Add("ServiceForProrate", "SVC");
            dic.Add("SpecialAttribute", "Cash Balance Benefit");
            dic.Add("TransitionBalance", "");
            pMethods._MethodOverrieds_Formula(dic);
            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab(sService_Accounting_Conversion);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"11/6/1943\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"11/4/1961\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab(sService_Accounting_Conversion);

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
            dic.Add("PriorYear", "Click");
            dic.Add("CashBanlance", "N/A");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab(sService_Accounting_Conversion);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab(sService_Accounting_Conversion);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccountingConversion, "Valuation Summary", "Conversion", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccountingConversion, "Liability Summary", "Conversion", true, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sAccountingConversion, "Liability Summary", "Conversion", true, false, 0);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccountingConversion, "Member Statistics", "Conversion", true, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sAccountingConversion, "Conversion Diagnostic", "Conversion", true, false, 0);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccountingConversion, "Conversion Diagnostic", "Conversion", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccountingConversion, "Test Case List", "Conversion", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccountingConversion, "Detailed Results", "Conversion", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccountingConversion, "Individual Output", "Conversion", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccountingConversion, "Parameter Print", "Conversion", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccountingConversion, "Test Cases", "Conversion", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccountingConversion, "Payout Projection", "Conversion", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccountingConversion, "FAS Expected Benefit Pmts", "Conversion", true, false);

            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccountingConversion, "Detailed Results by Plan Def", "Conversion", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccountingConversion, "IOE", "Conversion", false, false);


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US012CN", sAccountingConversion_Prod, sAccountingConversion);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sAccountingConversion");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_ActiveMembers.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_DeferredMembers.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_Pensioners.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByNone.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByStatusCodes.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByCustom_Gender.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
            }


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion

            


            _gLib._MsgBox("Congratulations!", "Finished!");

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
