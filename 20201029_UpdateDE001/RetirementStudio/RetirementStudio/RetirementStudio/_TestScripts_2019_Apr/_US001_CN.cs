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
using RetirementStudio._UIMaps.AgeClasses;
using RetirementStudio._UIMaps.SocialSecurityCoveredCompFormulaClasses;
using RetirementStudio._UIMaps.SocialSecurityPIAFormulaClasses;
using RetirementStudio._UIMaps.EmployeeContributionsFormulaClasses;


namespace RetirementStudio._TestScripts_2019_Apr
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class _US001_CN
    {
        public _US001_CN()
        {
            Config.eEnv = _TestingEnv.QA2;
            Config.eCountry = _Country.US;
            //Config.sClientName = "QA US Benchmark 001 Create New";
            //Config.sPlanName = "QA US Benchmark 001 Create New Plan";
            Config.sClientName = "QA US Benchmark 001 Existing DNT";
            Config.sPlanName = "QA US Benchmark 001 Plan Existing DNT";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = false;
        }



        #region Report Output Directory



        public string sOutputBaseline = "";
        public string sOutputUS003 = "";
        public string sOutputUS004 = "";
        public string sOutputUS002 = "";

        public string sOutputBaseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_001_Saks_PIA_1_ReduceBen\Production\PIA_1\6.9_20160911_Franklin\Baseline\";
        public string sOutputUS003_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_001_Saks_PIA_1_ReduceBen\Production\PIA_1\6.9_20160911_Franklin\US003\";
        public string sOutputUS004_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_001_Saks_PIA_1_ReduceBen\Production\PIA_1\6.9_20160911_Franklin\US004\";
        public string sOutputUS002_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_001_Saks_PIA_1_ReduceBen\Production\PIA_1\6.9_20160911_Franklin\US002\";

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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_001_Saks_PIA_1_ReduceBen\Create New\PIA_1\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);


                    sOutputBaseline = _gLib._CreateDirectory(sMainDir + "Baseline\\" + sPostFix + "\\");
                    sOutputUS003 = _gLib._CreateDirectory(sMainDir + "US003\\" + sPostFix + "\\");
                    sOutputUS004 = _gLib._CreateDirectory(sMainDir + "US004\\" + sPostFix + "\\");
                    sOutputUS002 = _gLib._CreateDirectory(sMainDir + "US002\\" + sPostFix + "\\");

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

                string sMainDir = sDir + "US001_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputBaseline = _gLib._CreateDirectory(sMainDir + "\\Baseline\\");
                sOutputUS003 = _gLib._CreateDirectory(sMainDir + "\\US003\\");
                sOutputUS004 = _gLib._CreateDirectory(sMainDir + "\\US004\\");
                sOutputUS002 = _gLib._CreateDirectory(sMainDir + "\\US002\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputBaseline = @\"" + sOutputBaseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputUS003 = @\"" + sOutputUS003 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputUS004 = @\"" + sOutputUS004 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputUS002 = @\"" + sOutputUS002 + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);

        }


        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();
        public Age pAge = new Age();
        public SocialSecurityCoveredCompFormula pSocialSecurityCoveredCompFormula = new SocialSecurityCoveredCompFormula();
        public SocialSecurityPIAFormula pSocialSecurityPIAFormula = new SocialSecurityPIAFormula();
        public EmployeeContributionsFormula pEmployeeContributionsFormula = new EmployeeContributionsFormula();

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

        #endregion


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void _test_US001_CN()
        {

            sOutputUS002 = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_001_Saks_PIA_1_ReduceBen\Create New\PIA_1\US002\";

            string sNewNode_US002 = "US 002-" + _gLib._ReturnDateStampYYYYMMDD();

            //this.GenerateReportOuputDir();



            #region Add PIA_1 US 002

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "PIA_1");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("PIA_1");

            ////////////////////_gLib._MsgBoxYesNo("", "Right select \"Add Valuation Node\" on Node \"US 004\"");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", sNewNode_US002);
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "True");
            dic.Add("Provisions_Name", "US 002 Provisions-" + _gLib._ReturnDateStampYYYYMMDD());
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            _gLib._MsgBoxYesNo("", "Right select \"Provisions - Edit Parameters\" on Node " + sNewNode_US002);

            ////////////////////dic.Clear();
            ////////////////////dic.Add("iMaxRowNum", "");
            ////////////////////dic.Add("iMaxColNum", "");
            ////////////////////dic.Add("iSelectRowNum", "4");
            ////////////////////dic.Add("iSelectColNum", "2");
            ////////////////////dic.Add("MenuItem_1", "Provisions");
            ////////////////////dic.Add("MenuItem_2", "Edit Parameters");
            ////////////////////pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Social Security PIA Formula");
            dic.Add("Level_4", "PIARetLevel");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BenefitType", "");
            dic.Add("FixedAge", "");
            dic.Add("SSNRA", "true");
            dic.Add("ProjectedPay", "");
            dic.Add("UseZeroEarningsBefore", "");
            pSocialSecurityPIAFormula._PopVerify_Main(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Social Security PIA Formula");
            dic.Add("Level_4", "PIARetZero");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BenefitType", "");
            dic.Add("FixedAge", "");
            dic.Add("SSNRA", "true");
            dic.Add("ProjectedPay", "");
            dic.Add("UseZeroEarningsBefore", "");
            pSocialSecurityPIAFormula._PopVerify_Main(dic);




            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Social Security PIA Formula");
            dic.Add("Level_4", "PIARetLeveLY");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BenefitType", "");
            dic.Add("FixedAge", "");
            dic.Add("SSNRA", "true");
            dic.Add("ProjectedPay", "");
            dic.Add("UseZeroEarningsBefore", "");
            pSocialSecurityPIAFormula._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Social Security PIA Formula");
            dic.Add("Level_4", "PIADisability");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BenefitType", "");
            dic.Add("FixedAge", "");
            dic.Add("SSNRA", "true");
            dic.Add("ProjectedPay", "");
            dic.Add("UseZeroEarningsBefore", "");
            pSocialSecurityPIAFormula._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Social Security PIA Formula");
            dic.Add("Level_4", "PIADeath");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BenefitType", "");
            dic.Add("FixedAge", "");
            dic.Add("SSNRA", "true");
            dic.Add("ProjectedPay", "");
            dic.Add("UseZeroEarningsBefore", "");
            pSocialSecurityPIAFormula._PopVerify_Main(dic);



            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region PIA_1 US 002 Report

            pMain._SelectTab("PIA_1");

            _gLib._MsgBoxYesNo("", "Right select \"Run - Liabilities\" on Node " + sNewNode_US002);

            ////////////////////dic.Clear();
            ////////////////////dic.Add("iMaxRowNum", "");
            ////////////////////dic.Add("iMaxColNum", "");
            ////////////////////dic.Add("iSelectRowNum", "4");
            ////////////////////dic.Add("iSelectColNum", "2");
            ////////////////////dic.Add("MenuItem_1", "Run");
            ////////////////////dic.Add("MenuItem_2", "Liabilities");
            ////////////////////pMain._FlowTreeRightSelect(dic);


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
            dic.Add("Service", "$Service");
            dic.Add("Pay", "NewPayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "CustomDeath");
            dic.Add("Pension", "");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "True");
            dic.Add("FAS35PresentValueOfVestedBenefits", "True");
            dic.Add("PPAAtRiskLiabilityForMinimum", "False");
            dic.Add("PPAAtRiskLiabilityForMaximum", "False");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "False");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "False");
            dic.Add("EntryAgeNormal", "False");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            _gLib._MsgBoxYesNo("", "Right select \"View Run Status\" on Node " + sNewNode_US002);

            //////////////////////dic.Clear();
            //////////////////////dic.Add("iMaxRowNum", "");
            //////////////////////dic.Add("iMaxColNum", "");
            //////////////////////dic.Add("iSelectRowNum", "4");
            //////////////////////dic.Add("iSelectColNum", "2");
            //////////////////////dic.Add("MenuItem_1", "View Run Status");
            //////////////////////pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("PIA_1");

            _gLib._MsgBoxYesNo("", "Right select \"View Output\" on Node " + sNewNode_US002);

            //////////////////////dic.Clear();
            //////////////////////dic.Add("iMaxRowNum", "");
            //////////////////////dic.Add("iMaxColNum", "");
            //////////////////////dic.Add("iSelectRowNum", "4");
            //////////////////////dic.Add("iSelectColNum", "2");
            //////////////////////dic.Add("MenuItem_1", "View Output");
            //////////////////////pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputUS002, "Valuation Summary", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputUS002, "Individual Output", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputUS002, "IOE", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputUS002, "Parameter Print", "Conversion", true, true);
            //////////////////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputUS002, "Test Cases", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputUS002, "Payout Projection", "Conversion", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputUS002, "Liabilities Detailed Results", "Conversion", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputUS002, "Liabilities Detailed Results by Plan Def", "Conversion", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputUS002, "Reconciliation to Baseline", "Conversion", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputUS002, "Reconciliation to Baseline by Plan Def", "Conversion", true, true);

            #endregion


            #region PIA_1 US 002 Compare

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US001CN", sOutputUS002_Prod, sOutputUS002);
                _compareReportsLib._Report(_PassFailStep.Description, "", "US002");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_FAS35PVAB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_FAS35PVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PBGCNARPVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMin.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARPVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0, true);
            }

            #endregion


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);
            _gLib._MsgBoxYesNo("", "Finished");





            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
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
