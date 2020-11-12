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
using RetirementStudio._UIMaps.BenefitElectionsClasses;
using RetirementStudio._UIMaps.FlatAmountAccumulationClasses;
using RetirementStudio._UIMaps.FutureValuationOptionClasses;


namespace RetirementStudio._TestScripts_2019_Oct_US
{
    /// <summary>
    /// Summary description for US019_DNT
    /// </summary>
    [CodedUITest]
    public class US019_DNT
    {
        public US019_DNT()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 019 Existing DNT";
            Config.sPlanName = "QA US Benchmark 019 Existing DNT Plan";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;


        }


        #region Report Output Directory


        public string sFunding2017 = "";
        public string sFunding2018_OptOutPrescribedMort = "";
        public string sFunding2018_FutureValRun = "";
        public string sAccounting2017 = "";
        public string sAccounting2018_FutureValRun = "";


        public string sFunding2017_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_019_PPA\Production\Funding\1.1.2017 Funding Valuation\Baseline\7.2_20180515_Franklin\";
        public string sFunding2018_OptOutPrescribedMort_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_019_PPA\Production\Funding\1.1.2018 Funding Valuation\OptOut_Prescribed Mort\7.2_20180515_Franklin\";
        public string sFunding2018_FutureValRun_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_019_PPA\Production\Funding\1.1.2018 Funding Valuation\Future Val Run\7.2_20180515_Franklin\";
        public string sAccounting2017_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_019_PPA\Production\Accounting\1.1.2017 Accounting Valuation\Baseline\7.2_20180515_Franklin\";
        public string sAccounting2018_FutureValRun_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_019_PPA\Production\Accounting\1.1.2018 Accounting Valuation\Future Val Run\7.2_20180515_Franklin\";


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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_019_PPA\Existing\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);


                    sFunding2017 = _gLib._CreateDirectory(sMainDir + "Funding\\1.1.2017 Funding Valuation\\Baseline\\" + sPostFix + "\\");
                    sFunding2018_OptOutPrescribedMort = _gLib._CreateDirectory(sMainDir + "Funding\\1.1.2018 Funding Valuation\\OptOut_Prescribed Mort\\" + sPostFix + "\\");
                    sFunding2018_FutureValRun = _gLib._CreateDirectory(sMainDir + "Funding\\1.1.2018 Funding Valuation\\Future Val Run\\" + sPostFix + "\\");
                    sAccounting2017 = _gLib._CreateDirectory(sMainDir + "Accounting\\1.1.2017 Accounting Valuation\\Baseline\\" + sPostFix + "\\");
                    sAccounting2018_FutureValRun = _gLib._CreateDirectory(sMainDir + "Accounting\\1.1.2018 Accounting Valuation\\Future Val Run\\" + sPostFix + "\\");

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

                /// this is for VS2015 folder structure
                sDir = sDir + "\\" + Config._ReturnProjectName() + "\\_Reports\\";

                //////sDir = sDir + "\\_TestLog\\";

                string sMainDir = sDir + "US019_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sFunding2017 = _gLib._CreateDirectory(sMainDir + "\\Funding_1.1.2017 Funding Valuation_Baseline\\");
                sFunding2018_OptOutPrescribedMort = _gLib._CreateDirectory(sMainDir + "\\Funding_1.1.2018FundingValuation_OptOut_PrescribedMort\\");
                sFunding2018_FutureValRun = _gLib._CreateDirectory(sMainDir + "\\Funding_1.1.2018FundingValuation_FutureValRun\\\\");
                sAccounting2017 = _gLib._CreateDirectory(sMainDir + "\\Accounting_1.1.2017AccountingValuation_Baseline\\");
                sAccounting2018_FutureValRun = _gLib._CreateDirectory(sMainDir + "\\Accounting_1.1.2018AccountingValuation_FutureValRun\\");

            }

            string sContent = "";
            sContent = sContent + "sFunding2017 = @\"" + sFunding2017 + "\";" + Environment.NewLine;
            sContent = sContent + "sFunding2018_OptOutPrescribedMort = @\"" + sFunding2018_OptOutPrescribedMort + "\";" + Environment.NewLine;
            sContent = sContent + "sFunding2018_FutureValRun = @\"" + sFunding2018_FutureValRun + "\";" + Environment.NewLine;
            sContent = sContent + "sAccounting2017 = @\"" + sAccounting2017 + "\";" + Environment.NewLine;
            sContent = sContent + "sAccounting2018_FutureValRun = @\"" + sAccounting2018_FutureValRun + "\";" + Environment.NewLine;

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

        public BenefitElections pBenefitElections = new BenefitElections();
        public FlatAmountAccumulation pFlatAmountAccumulation = new FlatAmountAccumulation();
        public FutureValuationOption pFutureValuationOption = new FutureValuationOption();

        #endregion



        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_US019_DNT()
        {

            #region MultiThreads


            Thread thrd_Funding2017 = new Thread(() => new US019_DNT().t_CompareRpt_Funding2017(sFunding2017));
            Thread thrd_Funding2018_FutureValRun = new Thread(() => new US019_DNT().t_CompareRpt_Funding2018_FutureValRun(sFunding2018_FutureValRun));
            Thread thrd_Accounting2017 = new Thread(() => new US019_DNT().t_CompareRpt_Accounting2017(sAccounting2017));

            #endregion



            this.GenerateReportOuputDir();

            #region 1.1.2017 Funding Valuation


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "1.1.2017 Funding Valuation");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("1.1.2017 Funding Valuation");


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
            dic.Add("Service", "$Service");
            dic.Add("Pay", "N/A");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "DivisionCode");
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
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("1.1.2017 Funding Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");

            pMain._SelectTab("1.1.2017 Funding Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "N/A");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "True");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "true");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "true");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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

            pMain._SelectTab("1.1.2017 Funding Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");

            pMain._SelectTab("1.1.2017 Funding Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sFunding2017, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sFunding2017, "Test Cases", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sFunding2017, "Liability Summary", "Conversion", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sFunding2017, "Liability Summary", "Conversion", false, true, 0);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding2017, "Member Statistics", "Conversion", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sFunding2017, "Conversion Diagnostic", "Conversion", false, true, 0);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding2017, "Test Case List", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding2017, "Detailed Results", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding2017, "Detailed Results by Plan Def", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding2017, "Valuation Summary", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sFunding2017, "Individual Output", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sFunding2017, "IOE", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sFunding2017, "Payout Projection", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding2017, "Future Valuation Population Projection", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding2017, "Future Valuation Summary", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding2017, "Future Valuation Liabilities by Group", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding2017, "Future Valuation Liabilities by Year", "Conversion", false, true);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sFunding2017, "Conversion", false, true);


            thrd_Funding2017.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("1.1.2017 Funding Valuation");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion

            #region 1.1.2018 Funding Valuation - Future Val Run node

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "1.1.2018 Funding Valuation");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("1.1.2018 Funding Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");

            pMain._SelectTab("1.1.2018 Funding Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "N/A");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "True");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "true");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "true");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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

            pMain._SelectTab("1.1.2018 Funding Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");

            pMain._SelectTab("1.1.2018 Funding Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_Others_PDF_EXCEL(sFunding2018_FutureValRun, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding2018_FutureValRun, "Future Valuation Population Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding2018_FutureValRun, "Future Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding2018_FutureValRun, "Future Valuation Liabilities by Group", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sFunding2018_FutureValRun, "Future Valuation Liabilities by Year", "RollForward", false, true);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sFunding2018_FutureValRun, "RollForward", false, true);


            thrd_Funding2018_FutureValRun.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("1.1.2018 Funding Valuation");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region 1.1.2017 Accounting Valuation


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "1.1.2017 Accounting Valuation");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("1.1.2017 Accounting Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");

            pMain._SelectTab("1.1.2017 Accounting Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "N/A");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "True");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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

            pMain._SelectTab("1.1.2017 Accounting Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");

            pMain._SelectTab("1.1.2017 Accounting Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccounting2017, "Future Valuation Parameter Print", "Conversion", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccounting2017, "Future Valuation Population Projection", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccounting2017, "Future Valuation Summary", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccounting2017, "Future Valuation Liabilities by Group", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccounting2017, "Future Valuation Liabilities by Year", "Conversion", false, false);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sAccounting2017, "Conversion", false, false);

            thrd_Accounting2017.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("1.1.2017 Accounting Valuation");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region 1.1.2018 Accounting Valuation


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "1.1.2018 Accounting Valuation");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("1.1.2018 Accounting Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");

            pMain._SelectTab("1.1.2018 Accounting Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "N/A");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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

            pMain._SelectTab("1.1.2018 Accounting Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");

            pMain._SelectTab("1.1.2018 Accounting Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccounting2018_FutureValRun, "Future Valuation Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccounting2018_FutureValRun, "Future Valuation Population Projection", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccounting2018_FutureValRun, "Future Valuation Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccounting2018_FutureValRun, "Future Valuation Liabilities by Group", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccounting2018_FutureValRun, "Future Valuation Liabilities by Year", "RollForward", false, false);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sAccounting2018_FutureValRun, "RollForward", false, false);


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US019DNT", sAccounting2018_FutureValRun_Prod, sAccounting2018_FutureValRun);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sAccounting2018_FutureValRun");

                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2018.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2019.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2020.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2022.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2023.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2024.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2025.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2026.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2027.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2028.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2033.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2038.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, 0, 0, 0);

            }


            #endregion


            _gLib._MsgBox("Congratulations!", "Finnally, you are done with US019!");


        }


        void t_CompareRpt_Funding2017(string sFunding2017)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US019DNT", sFunding2017_Prod, sFunding2017);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sFunding2017");

                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2017.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2018.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2019.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2020.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2022.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2023.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2024.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2025.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2026.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2027.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2032.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2037.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Funding2018_FutureValRun(string sFunding2018_FutureValRun)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US019DNT", sFunding2018_FutureValRun_Prod, sFunding2018_FutureValRun);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sFunding2018_FutureValRun");

                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2018.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2019.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2020.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2022.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2023.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2024.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2025.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2026.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2027.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2028.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2033.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2038.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Accounting2017(string sAccounting2017)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US019DNT", sAccounting2017_Prod, sAccounting2017);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sAccounting2017");

                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2017.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2018.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2019.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2020.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2022.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2023.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2024.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2025.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2026.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2027.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2032.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2037.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, 0, 0, 0);
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
