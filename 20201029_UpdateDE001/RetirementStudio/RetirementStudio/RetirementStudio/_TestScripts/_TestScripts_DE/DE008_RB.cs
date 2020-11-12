﻿using System;
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


namespace RetirementStudio._TestScripts._TestScripts_DE
{
    /// <summary>
    /// Summary description for DE008_RB
    /// </summary>
    [CodedUITest]
    public class DE008_RB
    {

        public DE008_RB()
        {

            Config.eEnv = _TestingEnv.Prod_EU;
            Config.eCountry = _Country.DE;
            Config.sClientName = "QA DE Benchmark 008 E";
            Config.sPlanName = "Alle - QA DE Benchmark 008 E";
            Config.sProductionVerison = "6.9.1";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = false;

        }


        #region Report Output Directory



        public string sOutputPension_Conversion2009 = "";
        public string sOutputPension_Stichtag2010_Baseline = "";
        public string sOutputPension_Stichtag2010_PreliminaryAssumptions = "";
        public string sOutputPension_Stichtag2011_Baseline = "";
        public string sOutputPension_Stichtag2011_InterestSensitivityMINUS = "";
        public string sOutputPension_Stichtag2011_InterestSensitivityPLUS = "";
        


        public void GenerateReportOuputDir()
        {
            pMain._SetLanguageAndRegional();
            _BenchmarkUser sCurrentUser = _gLib._ReturnCurrentUser();
            if (sCurrentUser.ToString() == "Others")
            {
                _gLib._MsgBox("Warning !!!", "Your are NOT allowed to create folders in \\mercer.com\\US_Data\\Shared\\Dfl\\Data1\\RSS\\SQA drive, Please contact Cindy or Webber if you have to!");
                Environment.Exit(0);
            }
            else
            {
                string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Production\";
                string sPostFix = Config.sProductionVerison + "_" + _gLib._ReturnDateStampYYYYMMDD();

                sPostFix = sPostFix + "_E";

                _gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                sOutputPension_Conversion2009 = _gLib._CreateDirectory(sMainDir + "Conversion2009\\" + sPostFix + "\\");
                sOutputPension_Stichtag2010_Baseline = _gLib._CreateDirectory(sMainDir + "Stichtag2010\\Baseline\\" + sPostFix + "\\");
                sOutputPension_Stichtag2010_PreliminaryAssumptions = _gLib._CreateDirectory(sMainDir + "Stichtag2010\\PreliminaryAssumptions\\" + sPostFix + "\\");
                sOutputPension_Stichtag2011_Baseline = _gLib._CreateDirectory(sMainDir + "Stichtag2011\\Baseline\\" + sPostFix + "\\");
                sOutputPension_Stichtag2011_InterestSensitivityMINUS = _gLib._CreateDirectory(sMainDir + "Stichtag2011\\InterestSensitivityMINUS\\" + sPostFix + "\\");
                sOutputPension_Stichtag2011_InterestSensitivityPLUS = _gLib._CreateDirectory(sMainDir + "Stichtag2011\\InterestSensitivityPLUS\\" + sPostFix + "\\");
            }


            string sContent = "";
            sContent = sContent + "sOutputPension_Conversion2009 = @\"" + sOutputPension_Conversion2009 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Stichtag2010_Baseline = @\"" + sOutputPension_Stichtag2010_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Stichtag2010_PreliminaryAssumptions = @\"" + sOutputPension_Stichtag2010_PreliminaryAssumptions + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Stichtag2011_Baseline = @\"" + sOutputPension_Stichtag2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Stichtag2011_InterestSensitivityMINUS = @\"" + sOutputPension_Stichtag2011_InterestSensitivityMINUS + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Stichtag2011_InterestSensitivityPLUS = @\"" + sOutputPension_Stichtag2011_InterestSensitivityPLUS + "\";" + Environment.NewLine;
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
        public void test_DE008_RB()
        {
          

            this.GenerateReportOuputDir();


            
            #region sOutputPension_Conversion2009


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "PensionValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Conversion 2009");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Conversion 2009");

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
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "True");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "True");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "True");
            dic.Add("SelectVOs_VO1", "");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Conversion 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Conversion 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "Parameter Summary", "Conversion", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Conversion2009, "Test Cases", "Conversion", true, true);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "Conversion Diagnostic", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Test Case List", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Valuation Summary for Excel Export", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Conversion2009, "Payout Projection", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2009, "Member Statistics", "Conversion", true, false, 0, new string[3] { "IDEXEuropeGmbH_KugelfischerPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2009, "Valuation Summary", "Conversion", true, false, 0, new string[3] { "IDEXEuropeGmbH_KugelfischerPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Conversion2009, "Payout Projection", "Conversion", true, true, dic);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "Conversion Diagnostic", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Test Case List", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Detailed Results by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Valuation Summary for Excel Export", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Conversion2009, "Payout Projection", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2009, "Member Statistics", "Conversion", false, true, 0, new string[3] { "IDEXEuropeGmbH_KugelfischerPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2009, "Valuation Summary", "Conversion", false, true, 0, new string[3] { "IDEXEuropeGmbH_KugelfischerPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Conversion2009, "Payout Projection", "Conversion", false, true, dic);

            }



            pMain._SelectTab("Conversion 2009");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region sOutputPension_Stichtag2010_Baseline


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Stichtag 2010");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Stichtag 2010");

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
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "True");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "False");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "True");
            dic.Add("SelectVOs_VO1", "");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Stichtag 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Stichtag 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial Report");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            pMain._PopVerify_ActuarialReport(dic);

            pMain._SelectTab("Stichtag 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Parameter Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Test Cases", "Conversion", true, true);
            //////pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Direct Promise", "RollForward", true, true);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Reconciliation to Prior Year with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Detailed Results with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Individual Checking Template", "RollForward", true, true, 0, new string[4] { "EZ05", "EZ20", "FAG", "VKAP" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "FAS Expected Benefit Pmts", "RollForward", true, true);

                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Member Statistics", "RollForward", true, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Valuation Summary", "RollForward", true, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                ////////    pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Liability Set for Globe Export", "RollForward", true, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Payout Projection", "RollForward", true, true, dic);

            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Reconciliation to Prior Year with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Reconciliation to Prior Year by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Detailed Results with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Detailed Results by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Individual Checking Template", "RollForward", false, true, 0, new string[4] { "EZ05", "EZ20", "FAG", "VKAP" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Member Statistics", "RollForward", false, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Valuation Summary", "RollForward", false, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                ////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Payout Projection", "RollForward", false, true, dic);

            }


            pMain._SelectTab("Stichtag 2010");
            pMain._Home_ToolbarClick_Top(true);




            #endregion


            #region sOutputPension_Stichtag2010_PreliminaryAssumptions


            pMain._SelectTab("Stichtag 2010");


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
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "True");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "False");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "True");
            dic.Add("SelectVOs_VO1", "");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Stichtag 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Stichtag 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Parameter Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Test Cases", "Conversion", true, true);



            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Scenario with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Valuation Summary", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                ////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Set for Globe Export", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Payout Projection", "RollForward", true, true, dic);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Reconciliation to Baseline with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liabilities Detailed Results with Breaks", "RollForward", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Scenario with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Scenario by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Scenario by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Valuation Summary", "RollForward", false, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                ////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Payout Projection", "RollForward", false, true, dic);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Reconciliation to Baseline with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liabilities Detailed Results with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, true);

            }


            pMain._SelectTab("Stichtag 2010");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region sOutputPension_Stichtag2011_Baseline


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Stichtag 2011");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Stichtag 2011");

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
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "True");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "True");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "True");
            dic.Add("SelectVOs_VO1", "");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Stichtag 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Stichtag 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial Report");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            pMain._PopVerify_ActuarialReport(dic);


            pMain._SelectTab("Stichtag 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Parameter Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Test Cases", "Conversion", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Direct Promise", "RollForward", true, true);

            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Reconciliation to Prior Year with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Detailed Results with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Individual Checking Template", "RollForward", true, true, 0, new string[4] { "EZ05", "EZ20", "FAG", "VKAP" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Individual Output", "RollForward", true, true);

                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "FAS Expected Benefit Pmts", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Member Statistics", "RollForward", true, true, 0, new string[2] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Valuation Summary", "RollForward", true, true, 0, new string[2] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[2] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan" });
                //////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Liability Set for Globe Export", "RollForward", true, true, 0, new string[1] { "ALL" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Payout Projection", "RollForward", true, true, dic);

            }




            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Reconciliation to Prior Year with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Reconciliation to Prior Year by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Detailed Results with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Detailed Results by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Individual Checking Template", "RollForward", false, true, 0, new string[4] { "EZ05", "EZ20", "FAG", "VKAP" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Member Statistics", "RollForward", false, true, 0, new string[2] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Valuation Summary", "RollForward", false, true, 0, new string[2] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[2] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan" });
                //////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[1] { "ALL" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Payout Projection", "RollForward", false, true, dic);

            }


            pMain._SelectTab("Stichtag 2011");
            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region sOutputPension_Stichtag2011_InterestSensitivityPLUS


            pMain._SelectTab("Stichtag 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "True");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "False");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "True");
            dic.Add("SelectVOs_VO1", "");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Stichtag 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Stichtag 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Parameter Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Test Cases", "Conversion", true, true);



            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Valuation Summary", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Payout Projection", "RollForward", true, true, dic);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Reconciliation to Baseline with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Liabilities Detailed Results with Breaks", "RollForward", true, true);
            }




            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Valuation Summary", "RollForward", false, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Payout Projection", "RollForward", false, true, dic);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Reconciliation to Baseline with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Liabilities Detailed Results with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, true);

            }


            pMain._SelectTab("Stichtag 2011");
            pMain._Home_ToolbarClick_Top(true);



            #endregion


            #region sOutputPension_Stichtag2011_InterestSensitivityMINUS


            pMain._SelectTab("Stichtag 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "True");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "True");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "");
            dic.Add("InternationalAccountingPBO", "");
            dic.Add("SelectVOs_AllVOs", "True");
            dic.Add("SelectVOs_VO1", "");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Stichtag 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Stichtag 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Parameter Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Test Cases", "Conversion", true, true);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liability Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liability Scenario with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Valuation Summary", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Payout Projection", "RollForward", true, true, dic);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Reconciliation to Baseline with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liabilities Detailed Results with Breaks", "RollForward", true, true);
            }



            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liability Scenario with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liability Scenario by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liability Scenario by Plan Def with Breaks", "RollForward", false, true);

                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Valuation Summary", "RollForward", false, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Payout Projection", "RollForward", false, true, dic);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Reconciliation to Baseline with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liabilities Detailed Results with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, true);

            }


            pMain._SelectTab("Stichtag 2011");
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
