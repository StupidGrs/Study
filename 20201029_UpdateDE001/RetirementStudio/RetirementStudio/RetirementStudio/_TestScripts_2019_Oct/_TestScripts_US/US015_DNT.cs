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
using System.Management;


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

namespace RetirementStudio._TestScripts_2019_Oct_US
{
    /// <summary>
    /// Summary description for US015_DNT
    /// </summary>
    [CodedUITest]
    public class US015_DNT
    {
        public US015_DNT()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 015 Existing DNT";
            Config.sPlanName = "QA US Benchmark 015 Existing DNT Plan";

            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }

        #region Report Output Directory


        public string sOutputFunding_Converson2010 = "";
        public string sOutputFunding_Valuation2011_LevelpopulationandMultipleDx = "";
        public string sOutputFunding_Valuation2011_ChangeprovisionsforFV = "";
        public string sOutputAccounting_Conversion2010 = "";
        public string sOutputAccounting_Accounting2011_NEswithtestcriteria = "";


        public string sOutputFunding_Converson2010_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Conversion 2010\7.5_20191110_Franklin\";
        public string sOutputFunding_Valuation2011_LevelpopulationandMultipleDx_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Level population and Multiple Dx\7.5_20191110_Franklin\";
        public string sOutputFunding_Valuation2011_ChangeprovisionsforFV_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Change provisions for FV\7.4_20190417_Franklin\";
        public string sOutputAccounting_Conversion2010_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Accounting\Conversion 2010\7.4_20190417_Franklin\";
        public string sOutputAccounting_Accounting2011_NEswithtestcriteria_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Accounting\Accounting 2011\NEs with test criteria\7.4_20190417_Franklin\";


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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Existing\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);


                    sOutputFunding_Converson2010 = _gLib._CreateDirectory(sMainDir + "Funding\\Conversion 2010\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2011_LevelpopulationandMultipleDx = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation 2011\\Level population and Multiple Dx\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2011_ChangeprovisionsforFV = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation 2011\\Change provisions for FV\\" + sPostFix + "\\");
                    sOutputAccounting_Conversion2010 = _gLib._CreateDirectory(sMainDir + "Accounting\\Conversion 2010\\" + sPostFix + "\\");
                    sOutputAccounting_Accounting2011_NEswithtestcriteria = _gLib._CreateDirectory(sMainDir + "Accounting\\Accounting 2011\\NEs with test criteria\\" + sPostFix + "\\");
                }

            } 


            string sContent = "";
            sContent = sContent + "sOutputFunding_Converson2010 = @\"" + sOutputFunding_Converson2010 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2011_LevelpopulationandMultipleDx = @\"" + sOutputFunding_Valuation2011_LevelpopulationandMultipleDx + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2011_ChangeprovisionsforFV = @\"" + sOutputFunding_Valuation2011_ChangeprovisionsforFV + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Conversion2010 = @\"" + sOutputAccounting_Conversion2010 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Accounting2011_NEswithtestcriteria = @\"" + sOutputAccounting_Accounting2011_NEswithtestcriteria + "\";" + Environment.NewLine;


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
        public void test_US015_DNT()
        {

         

            #region MultiThreads

            Thread thrd_Converson2010 = new Thread(() => new US015_DNT().t_CompareRpt_Converson2010(sOutputFunding_Converson2010));
            Thread thrd_Valuation2011_LevelpopulationandMultipleDx = new Thread(() => new US015_DNT().t_CompareRpt_Valuation2011_LevelpopulationandMultipleDx(sOutputFunding_Valuation2011_LevelpopulationandMultipleDx));
            Thread thrd_Valuation2011_ChangeprovisionsforFV = new Thread(() => new US015_DNT().t_CompareRpt_Valuation2011_ChangeprovisionsforFV(sOutputFunding_Valuation2011_ChangeprovisionsforFV));
            Thread thrd_Accounting_Conversion2010 = new Thread(() => new US015_DNT().t_CompareRpt_Accounting_Conversion2010(sOutputAccounting_Conversion2010));
            Thread thrd_Accounting2011_NEswithtestcriteria = new Thread(() => new US015_DNT().t_CompareRpt_Accounting2011_NEswithtestcriteria(sOutputAccounting_Accounting2011_NEswithtestcriteria));

            #endregion


            this.GenerateReportOuputDir();


            #region sOutputFunding_Converson2010

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Conversion 2010");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Conversion 2010");


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
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
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

            pMain._SelectTab("Conversion 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Conversion 2010");


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


            pMain._SelectTab("Conversion 2010");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Conversion 2010");


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
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "True");
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

            pMain._SelectTab("Conversion 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Conversion 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Converson2010, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Converson2010, "Test Cases", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Converson2010, "Liability Summary", "Conversion", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputFunding_Converson2010, "Liability Summary", "Conversion", false, true, 0);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Converson2010, "Member Statistics", "Conversion", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputFunding_Converson2010, "Conversion Diagnostic", "Conversion", false, true, 0);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Converson2010, "Test Case List", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Converson2010, "Detailed Results", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Converson2010, "Detailed Results by Plan Def", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Converson2010, "Valuation Summary", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Converson2010, "Individual Output", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Converson2010, "IOE", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Converson2010, "Payout Projection", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Converson2010, "Future Valuation Population Projection", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Converson2010, "Future Valuation Summary", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Converson2010, "Future Valuation Liabilities by Group", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Converson2010, "Future Valuation Liabilities by Year", "Conversion", false, true);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputFunding_Converson2010, "Conversion", false, true);


            thrd_Converson2010.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Conversion 2010");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion



            #region sOutputFunding_Valuation2011_LevelpopulationandMultipleDx

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2011");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
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
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "True");
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

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_LevelpopulationandMultipleDx, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_LevelpopulationandMultipleDx, "Future Valuation Population Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_LevelpopulationandMultipleDx, "Future Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_LevelpopulationandMultipleDx, "Future Valuation Liabilities by Group", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_LevelpopulationandMultipleDx, "Future Valuation Liabilities by Year", "RollForward", false, true);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputFunding_Valuation2011_LevelpopulationandMultipleDx, "RollForward", false, true);

            thrd_Valuation2011_LevelpopulationandMultipleDx.Start();





            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");
            pMain._Home_ToolbarClick_Top(true);



            #endregion



            #region sOutputFunding_Valuation2011_ChangeprovisionsforFV


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "2");
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
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "True");
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

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_ChangeprovisionsforFV, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_ChangeprovisionsforFV, "Future Valuation Population Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_ChangeprovisionsforFV, "Future Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_ChangeprovisionsforFV, "Future Valuation Liabilities by Group", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_ChangeprovisionsforFV, "Future Valuation Liabilities by Year", "RollForward", false, true);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputFunding_Valuation2011_ChangeprovisionsforFV, "RollForward", false, true);

            thrd_Valuation2011_ChangeprovisionsforFV.Start();




            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion



            #region sOutputAccounting_Conversion2010

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Conversion 2010");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Conversion 2010");


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
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
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
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Conversion 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Conversion 2010");


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


            pMain._SelectTab("Conversion 2010");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Conversion 2010");


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
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "True");
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

            pMain._SelectTab("Conversion 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Conversion 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Conversion2010, "Parameter Print", "Conversion", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Conversion2010, "Test Cases", "Conversion", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Conversion2010, "Liability Summary", "Conversion", false, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputAccounting_Conversion2010, "Liability Summary", "Conversion", false, false, 0);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Conversion2010, "Member Statistics", "Conversion", false, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputAccounting_Conversion2010, "Conversion Diagnostic", "Conversion", false, false, 0);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Conversion2010, "Conversion Diagnostic", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Conversion2010, "Test Case List", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Conversion2010, "Detailed Results", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Conversion2010, "Detailed Results by Plan Def", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Conversion2010, "Valuation Summary", "Conversion", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Conversion2010, "Individual Output", "Conversion", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Conversion2010, "IOE", "Conversion", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Conversion2010, "Payout Projection", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Conversion2010, "FAS Expected Benefit Pmts", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Conversion2010, "Future Valuation Population Projection", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Conversion2010, "Future Valuation Summary", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Conversion2010, "Future Valuation Liabilities by Group", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Conversion2010, "Future Valuation Liabilities by Year", "Conversion", false, false);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputAccounting_Conversion2010, "Conversion", false, false);



            thrd_Accounting_Conversion2010.Start();



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Conversion 2010");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion



            #region sOutputAccounting_Accounting2011_NEswithtestcriteria

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Accounting 2011");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);


            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
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
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "True");
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

            pMain._SelectTab("Accounting 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Accounting 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_NEswithtestcriteria, "Future Valuation Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_NEswithtestcriteria, "Future Valuation Population Projection", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_NEswithtestcriteria, "Future Valuation Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_NEswithtestcriteria, "Future Valuation Liabilities by Group", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_NEswithtestcriteria, "Future Valuation Liabilities by Year", "RollForward", false, false);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputAccounting_Accounting2011_NEswithtestcriteria, "RollForward", false, false);


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015DNT", sOutputAccounting_Accounting2011_NEswithtestcriteria_Prod, sOutputAccounting_Accounting2011_NEswithtestcriteria);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputAccounting_Accounting2011_NEswithtestcriteria");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" }, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" }, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" }, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" }, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2017.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2018.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2026.xlsx", 4, 0, 0, 0, true);
            }


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Accounting 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion



            _gLib._MsgBox("Congratulations!", "Finished!");
        }



        public void t_CompareRpt_Converson2010(string sOutputFunding_Converson2010)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015DNT", sOutputFunding_Converson2010_Prod, sOutputFunding_Converson2010);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Converson2010");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_ActiveMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_DeferredMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_Pensioners.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByNone.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByStatusCodes.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByCustom_Gender.xlsx", 4, 0, 0, 0);
                ////////_compareReportsLib.CompareExcel_Exact("TestCaseList.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2010.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }


        }

        public void t_CompareRpt_Valuation2011_LevelpopulationandMultipleDx(string sOutputFunding_Valuation2011_LevelpopulationandMultipleDx)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015DNT", sOutputFunding_Valuation2011_LevelpopulationandMultipleDx_Prod, sOutputFunding_Valuation2011_LevelpopulationandMultipleDx);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_LevelpopulationandMultipleDx");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2017.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2018.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2019.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2020.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2022.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2026.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                Config.bThreadFinsihed = true;

            }

        }

        public void t_CompareRpt_Valuation2011_ChangeprovisionsforFV(string sOutputFunding_Valuation2011_ChangeprovisionsforFV)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015DNT", sOutputFunding_Valuation2011_ChangeprovisionsforFV_Prod, sOutputFunding_Valuation2011_ChangeprovisionsforFV);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_ChangeprovisionsforFV");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                Config.bThreadFinsihed = true;

            }
        }

        public void t_CompareRpt_Accounting_Conversion2010(string sOutputAccounting_Conversion2010)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015DNT", sOutputAccounting_Conversion2010_Prod, sOutputAccounting_Conversion2010);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputAccounting_Conversion2010");


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
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2010.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2020.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2030.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                Config.bThreadFinsihed = true;

            }

        }

        public void t_CompareRpt_Accounting2011_NEswithtestcriteria(string sOutputAccounting_Accounting2011_NEswithtestcriteria)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015DNT", sOutputAccounting_Accounting2011_NEswithtestcriteria_Prod, sOutputAccounting_Accounting2011_NEswithtestcriteria);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputAccounting_Accounting2011_NEswithtestcriteria");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2017.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2018.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2026.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
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
