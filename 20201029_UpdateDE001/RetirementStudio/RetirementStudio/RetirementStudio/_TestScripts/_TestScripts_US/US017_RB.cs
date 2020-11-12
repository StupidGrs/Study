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



namespace RetirementStudio._TestScripts._TestScripts_US
{
    /// <summary>
    /// Summary description for US017_RB
    /// </summary>
    [CodedUITest]
    public class US017_RB
    {
        public US017_RB()
        {
            Config.eEnv = _TestingEnv.Prod_US;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 017";
            Config.sPlanName = "QA US Benchmark 017 Plan";
            Config.sPlanName2 = "QA US Benchmark 017 Plan 2";
            //////Config.sClientName = "QA US Benchmark 017 D";
            //////Config.sPlanName = "QA US Benchmark 017 D Plan";
            //////Config.sPlanName2 = "QA US Benchmark 017 D Plan 2";
            Config.sProductionVerison = "7.2";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = false;

            //_gLib._Report(_PassFailStep.Header, "Testing Starts at: " + DateTime.Now + "\t" + Environment.UserName);

        }


        #region Report Output Directory




        public string sOutputPlan1_RetroNDT2011 = "";
        public string sOutputPlan2_Conversion2008 = "";
        public string sOutputPlan2_ProspectiveNDTRF = "";

        public string sOutputPlan2_ProspectiveNDTRF_NDTSSNRA = "";
        public string sOutputPlan2_ProspectiveNDTRF_NDTContributions = "";


        public string sOutputPlan1_NDT2016_CopyofPFVS = "";
        public string sOutputPlan1_NDT2017_Baseline = "";
        public string sOutputPlan1_NDT2017_DCOnly = "";
        public string sOutputPlan1_NDT2017_DBOnly = "";
        public string sOutputPlan1_NDT2017_DBandDCProspective = "";


        public string sOutputPlan2_conversion2016_CopyofPFVS = "";
        public string sOutputPlan2_update2016_updatevaldate = "";
        public string sOutputPlan2_update2016_NDT = "";
        public string sOutputPlan2_NDT2016EOYand2017_Baseline = "";
        public string sOutputPlan2_NDT2016EOYand2017_DCOnly = "";
        public string sOutputPlan2_NDT2016EOYand2017_DBOnly = "";
        public string sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs = "";

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
                string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\";
                string sPostFix = Config.sProductionVerison + "_" + _gLib._ReturnDateStampYYYYMMDD();

                sPostFix = sPostFix + "_Franklin";

                _gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                sOutputPlan1_RetroNDT2011 = _gLib._CreateDirectory(sMainDir + "Retro NDT 2011\\" + sPostFix + "\\");
                sOutputPlan2_Conversion2008 = _gLib._CreateDirectory(sMainDir + "Conversion 2008\\" + sPostFix + "\\");
                sOutputPlan2_ProspectiveNDTRF = _gLib._CreateDirectory(sMainDir + "Prospective NDT RF\\NDT\\" + sPostFix + "\\");
                sOutputPlan2_ProspectiveNDTRF_NDTSSNRA = _gLib._CreateDirectory(sMainDir + "Prospective NDT RF\\NDT_SSNRA\\" + sPostFix + "\\");
                sOutputPlan2_ProspectiveNDTRF_NDTContributions = _gLib._CreateDirectory(sMainDir + "Prospective NDT RF\\NDT_Contributions\\" + sPostFix + "\\");
                sOutputPlan1_NDT2016_CopyofPFVS = _gLib._CreateDirectory(sMainDir + "NDT 2016\\Copy of PFVS\\" + sPostFix + "\\");
                sOutputPlan1_NDT2017_Baseline = _gLib._CreateDirectory(sMainDir + "NDT 2017\\Baseline\\" + sPostFix + "\\");
                sOutputPlan1_NDT2017_DCOnly = _gLib._CreateDirectory(sMainDir + "NDT 2017\\DC Only\\" + sPostFix + "\\");
                sOutputPlan1_NDT2017_DBOnly = _gLib._CreateDirectory(sMainDir + "NDT 2017\\DB Only\\" + sPostFix + "\\");
                sOutputPlan1_NDT2017_DBandDCProspective = _gLib._CreateDirectory(sMainDir + "NDT 2017\\DB and DC Prospective\\" + sPostFix + "\\");
                sOutputPlan2_conversion2016_CopyofPFVS = _gLib._CreateDirectory(sMainDir + "conversion 2016\\Copy of PFVS\\" + sPostFix + "\\");
                sOutputPlan2_update2016_updatevaldate = _gLib._CreateDirectory(sMainDir + "update 2016\\update val date\\" + sPostFix + "\\");
                sOutputPlan2_update2016_NDT = _gLib._CreateDirectory(sMainDir + "update 2016\\NDT\\" + sPostFix + "\\");
                sOutputPlan2_NDT2016EOYand2017_Baseline = _gLib._CreateDirectory(sMainDir + "NDT 2016 EOY and 2017\\Baseline\\" + sPostFix + "\\");
                sOutputPlan2_NDT2016EOYand2017_DCOnly = _gLib._CreateDirectory(sMainDir + "NDT 2016 EOY and 2017\\DC Only\\" + sPostFix + "\\");
                sOutputPlan2_NDT2016EOYand2017_DBOnly = _gLib._CreateDirectory(sMainDir + "NDT 2016 EOY and 2017\\DB Only\\" + sPostFix + "\\");
                sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs = _gLib._CreateDirectory(sMainDir + "NDT 2016 EOY and 2017\\run only NHCEs\\" + sPostFix + "\\");



            }


            string sContent = "";
            sContent = sContent + "sOutputPlan1_RetroNDT2011 = @\"" + sOutputPlan1_RetroNDT2011 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan2_Conversion2008 = @\"" + sOutputPlan2_Conversion2008 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan2_ProspectiveNDTRF = @\"" + sOutputPlan2_ProspectiveNDTRF + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan2_ProspectiveNDTRF_NDTSSNRA = @\"" + sOutputPlan2_ProspectiveNDTRF_NDTSSNRA + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan2_ProspectiveNDTRF_NDTContributions = @\"" + sOutputPlan2_ProspectiveNDTRF_NDTContributions + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan1_NDT2016_CopyofPFVS = @\"" + sOutputPlan1_NDT2016_CopyofPFVS + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan1_NDT2017_Baseline = @\"" + sOutputPlan1_NDT2017_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan1_NDT2017_DCOnly = @\"" + sOutputPlan1_NDT2017_DCOnly + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan1_NDT2017_DBOnly = @\"" + sOutputPlan1_NDT2017_DBOnly + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan1_NDT2017_DBandDCProspective = @\"" + sOutputPlan1_NDT2017_DBandDCProspective + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan2_conversion2016_CopyofPFVS = @\"" + sOutputPlan2_conversion2016_CopyofPFVS + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan2_update2016_updatevaldate = @\"" + sOutputPlan2_update2016_updatevaldate + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan2_update2016_NDT = @\"" + sOutputPlan2_update2016_NDT + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan2_NDT2016EOYand2017_Baseline = @\"" + sOutputPlan2_NDT2016EOYand2017_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan2_NDT2016EOYand2017_DCOnly = @\"" + sOutputPlan2_NDT2016EOYand2017_DCOnly + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan2_NDT2016EOYand2017_DBOnly = @\"" + sOutputPlan2_NDT2016EOYand2017_DBOnly + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs = @\"" + sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs + "\";" + Environment.NewLine;



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
        public void test_US017_RB()
        {


            this.GenerateReportOuputDir();

 
            #region Plan 1 - Funding - NDT 2016 - Copy_of_PFVS Node


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "NDT 2016");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("NDT 2016");


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
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("NDT 2016");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2016");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(sOutputPlan1_NDT2016_CopyofPFVS, "Parameter Print", "Conversion", true, true);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2016_CopyofPFVS, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2016_CopyofPFVS, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2016_CopyofPFVS, "Coverage Test", "Conversion", true, true);


                //_gLib._MsgBox("Manual Steps!", "Please manually download the only 3 General Test PDF reports : Summary; Current and Prior Testing Rate for each HCE; Current and Prior Testing Accrual Rates");


                pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan1_NDT2016_CopyofPFVS, "General Test", "Conversion", true, true, false, true, false, false, true, false, dic);



            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2016_CopyofPFVS, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2016_CopyofPFVS, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2016_CopyofPFVS, "Coverage Test", "Conversion", false, true);

                //_gLib._MsgBox("Manual Steps!", "Please manually download the only 3 General Test Excel reports : Summary; Current and Prior Testing Rate for each HCE; Current and Prior Testing Accrual Rates");

                pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan1_NDT2016_CopyofPFVS, "General Test", "Conversion", false, true, false, true, false, false, true, false, dic);



            }



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region Plan 1 - Funding - NDT 2017 - Baseline Node


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "NDT 2017");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("NDT 2017");


            _gLib._MsgBox("Manual Step", "please manually expand the Tree View zone as all nodes included.");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "271");
            dic.Add("iPosY", "88");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", "271");
            dic.Add("iPosY", "88");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", "271");
            dic.Add("iPosY", "88");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_Baseline, "Parameter Print", "RollForward", true, true);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_Baseline, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_Baseline, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_Baseline, "Coverage Test", "RollForward", true, true);


                //_gLib._MsgBox("Manual Steps!", "Please manually download the only 5 General Test PDF reports : Summary; Current Testing forEach HCE; Current and Prior Testing Rate for each HCE; Current Testing Accrual Rates; Current and Prior Testing Accrual Rates");

                pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan1_NDT2017_Baseline, "General Test", "RollForward", true, true, true, true, false, true, true, false, dic);



            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_Baseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_Baseline, "Coverage Test", "RollForward", false, true);

                ///_gLib._MsgBox("Manual Steps!", "Please manually download the only 5 General Test Excel reports : Summary; Current Testing for Each HCE; Current and Prior Testing Rate for each HCE; Current Testing Accrual Rates; Current and Prior Testing Accrual Rates");

                pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan1_NDT2017_Baseline, "General Test", "RollForward", false, true, true, true, false, true, true, false, dic);


            }

    

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Plan 1 - Funding - NDT 2017 - DC_Only Node
  

            pMain._SelectTab("NDT 2017");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", "108");
            dic.Add("iPosY", "154");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", "108");
            dic.Add("iPosY", "154");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", "108");
            dic.Add("iPosY", "154");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DCOnly, "Parameter Print", "RollForward", true, true);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DCOnly, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DCOnly, "Coverage Test", "RollForward", true, true);


                ///_gLib._MsgBox("Manual Steps!", "Please manually download the only 3 General Test PDF reports : Summary; Current Testing fo rEach HCE; Current Testing Accrual Rates");

                pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan1_NDT2017_DCOnly, "General Test", "RollForward", true, true, true, false, false, true, false, false, dic);


            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DCOnly, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DCOnly, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DCOnly, "Coverage Test", "RollForward", false, true);

                ///_gLib._MsgBox("Manual Steps!", "Please manually download the only 3 General Test Excel reports : Summary; Current Testing for Each HCE; Current Testing Accrual Rates");

                pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan1_NDT2017_DCOnly, "General Test", "RollForward", false, true, true, false, false, true, false, false, dic);


            }



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Plan 1 - Funding - NDT 2017 - DB_Only Node


            pMain._SelectTab("NDT 2017");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "0");
            dic.Add("iPosX", "219");
            dic.Add("iPosY", "157");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "0");
            dic.Add("iPosX", "219");
            dic.Add("iPosY", "157");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "0");
            dic.Add("iPosX", "219");
            dic.Add("iPosY", "157");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DBOnly, "Parameter Print", "RollForward", true, true);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DBOnly, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DBOnly, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DBOnly, "Coverage Test", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DBOnly, "General Test", "RollForward", true, true);




            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DBOnly, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DBOnly, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DBOnly, "Coverage Test", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DBOnly, "General Test", "RollForward", false, true);



            }



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Plan 1 - Funding - NDT 2017 - DB_and_DC_Prospective Node

       

            pMain._SelectTab("NDT 2017");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "425");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "425");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "425");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DBandDCProspective, "Parameter Print", "RollForward", true, true);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DBandDCProspective, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DBandDCProspective, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DBandDCProspective, "Coverage Test", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DBandDCProspective, "General Test", "RollForward", true, true);




            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DBandDCProspective, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DBandDCProspective, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DBandDCProspective, "Coverage Test", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_NDT2017_DBandDCProspective, "General Test", "RollForward", false, true);



            }



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("NDT 2017");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion



            #region Plan 2 - Funding - conversion 2016 - Copy_of_PFVS Node


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName2);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            _gLib._MsgBox("Manual Step!", "Please manually select on Plan2_FundingValuation in Home page tree view!");

          

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "conversion 2016");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("conversion 2016");


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
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "SalPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "Click");
            dic.Add("CashBanlance", "CashBalAccount");
            dic.Add("Pension", "PVinact");
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


            pMain._SelectTab("conversion 2016");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete with 7 NP", true);


            pMain._SelectTab("conversion 2016");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(sOutputPlan2_conversion2016_CopyofPFVS, "Parameter Print", "Conversion", true, true);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Common(sOutputPlan2_conversion2016_CopyofPFVS, "Detailed Results", "Conversion", true, true);

            }

            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_Common(sOutputPlan2_conversion2016_CopyofPFVS, "Detailed Results", "Conversion", false, true);

            }



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("conversion 2016");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Plan 2 - Funding - update 2016 - update_val_date Node


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName2);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            _gLib._MsgBox("Manual Step!", "Please manually select on Plan2_FundingValuation in Home page tree view!");

           
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "update 2016");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("update 2016");


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
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "SalPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "Click");
            dic.Add("CashBanlance", "CashBalAccount");
            dic.Add("Pension", "PVinact");
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


            pMain._SelectTab("update 2016");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete with 7 NP", true);


            pMain._SelectTab("update 2016");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(sOutputPlan2_update2016_updatevaldate, "Parameter Print", "RollForward", true, true);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Common(sOutputPlan2_update2016_updatevaldate, "Liabilities Detailed Results", "RollForward", true, true);

            }

            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_Common(sOutputPlan2_update2016_updatevaldate, "Liabilities Detailed Results", "RollForward", false, true);

            }
   

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion



            #region Plan 2 - Funding - update 2016 - NDT Node

         

            pMain._SelectTab("update 2016");


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
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("SelectRecords", "$emp.SalPriorYear1 > 1");
            dic.Add("Validate", "Click");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("update 2016");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);   //#116431 related to this node


            pMain._SelectTab("update 2016");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._Navigate("Plan Aggregation", "RollForward", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NoAggregation", "");
            dic.Add("SamePlansIncluded", "True");
            dic.Add("PlansDiffer", "");
            dic.Add("UpdateAggregation", "");
            dic.Add("Close", "");
            pOutputManager._PopVerify_PlanAggregation(dic);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2016");
            dic.Add("Level_4", "Copy of PFVS");
            pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName2);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "update 2016");
            dic.Add("Level_4", "NDT");
            pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UpdateAggregation", "Click");
            dic.Add("Close", "Click");
            pOutputManager._PopVerify_PlanAggregation(dic);


            pOutputManager._ExportReport_Others(sOutputPlan2_update2016_NDT, "Parameter Print", "RollForward", true, true);



            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Others(sOutputPlan2_update2016_NDT, "Individual Output", "RollForward", true, true);

                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPlan2_update2016_NDT, "Coverage Test", "RollForward", true, true, dic);


                ///_gLib._MsgBox("Manual Steps!", "Please manually open General Summary report tab then check off the check box \"CreateARateGroupForEachHCE\"");
                //_gLib._MsgBox("Manual Steps!", "Please manually download the only 4 General Test PDF reports : Summary; Current Testing Accrual Rates; Current and Prior Testing Accrual Rates; Current, Prior and Future Testing Accrual Rates");

                dic.Clear();
                dic.Add("CreateARateGroupForEachHCE", "False");
                dic.Add("GroupRates", "True");
                dic.Add("ForNormalAccrualRate", "");
                dic.Add("ForMostValuableAccrualRate", "");
                dic.Add("HighlyCompensated", "");
                dic.Add("NonHighlyCompensated", "");
                pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_update2016_NDT, "General Test", "RollForward", true, true, false, false, false, true, true, true, dic);




            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputPlan2_update2016_NDT, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan2_update2016_NDT, "Individual Output", "RollForward", false, true);

                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPlan2_update2016_NDT, "Coverage Test", "RollForward", false, true, dic);



                //_gLib._MsgBox("Manual Steps!", "Please manually open General Summary report tab then check off the check box \"CreateARateGroupForEachHCE\"");
                //_gLib._MsgBox("Manual Steps!", "Please manually download the only 4 General Test excel reports : Summary; Current Testing Accrual Rates; Current and Prior Testing Accrual Rates; Current, Prior and Future Testing Accrual Rates");


                dic.Clear();
                dic.Add("CreateARateGroupForEachHCE", "False");
                dic.Add("GroupRates", "True");
                dic.Add("ForNormalAccrualRate", "");
                dic.Add("ForMostValuableAccrualRate", "");
                dic.Add("HighlyCompensated", "");
                dic.Add("NonHighlyCompensated", "");
                pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_update2016_NDT, "General Test", "RollForward", false, true, false, false, false, true, true, true, dic);



            }
      

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion



            #region Plan 2 - Funding - NDT 2016 EOY and 2017 - Baseline Node


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName2);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);


            _gLib._MsgBox("Manual Step!", "Please manually select on Plan2_FundingValuation in Home page tree view!");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "NDT 2016 EOY and 2017");
            pMain._PopVerify_Home_RightPane(dic);


      
            pMain._SelectTab("NDT 2016 EOY and 2017");


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
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("SelectRecords", "$emp.DivisionCode != \"D\" and $emp.DivisionCode != \"S\"");
            dic.Add("Validate", "Click");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("NDT 2016 EOY and 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2016 EOY and 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._Navigate("Plan Aggregation", "RollForward", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NoAggregation", "");
            dic.Add("SamePlansIncluded", "True");
            dic.Add("PlansDiffer", "");
            dic.Add("UpdateAggregation", "");
            dic.Add("Close", "");
            pOutputManager._PopVerify_PlanAggregation(dic);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2017");
            dic.Add("Level_4", "Baseline");
            pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName2);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2016 EOY and 2017");
            dic.Add("Level_4", "Baseline");
            pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UpdateAggregation", "Click");
            dic.Add("Close", "Click");
            pOutputManager._PopVerify_PlanAggregation(dic);


            pOutputManager._ExportReport_Others(sOutputPlan2_NDT2016EOYand2017_Baseline, "Parameter Print", "RollForward", true, true);



            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Others(sOutputPlan2_NDT2016EOYand2017_Baseline, "Individual Output", "RollForward", true, true);

                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_Baseline, "Coverage Test", "RollForward", true, true, dic);


                //_gLib._MsgBox("Manual Steps!", "Please manually open General Summary report tab then check off the check box \"CreateARateGroupForEachHCE\"");
                //_gLib._MsgBox("Manual Steps!", "Please manually download the only 4 General Test PDF reports : Summary; Current Testing Accrual Rates; Current and Prior Testing Accrual Rates; Current, Prior and Future Testing Accrual Rates");


                dic.Clear();
                dic.Add("CreateARateGroupForEachHCE", "False");
                dic.Add("GroupRates", "True");
                dic.Add("ForNormalAccrualRate", "");
                dic.Add("ForMostValuableAccrualRate", "");
                dic.Add("HighlyCompensated", "");
                dic.Add("NonHighlyCompensated", "");
                pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_NDT2016EOYand2017_Baseline, "General Test", "RollForward", true, true, false, false, false, true, true, true, dic);




            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputPlan2_NDT2016EOYand2017_Baseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan2_NDT2016EOYand2017_Baseline, "Individual Output", "RollForward", false, true);

                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_Baseline, "Coverage Test", "RollForward", false, true, dic);


                ////_gLib._MsgBox("Manual Steps!", "Please manually open General Summary report tab then check off the check box \"CreateARateGroupForEachHCE\"");
                ////_gLib._MsgBox("Manual Steps!", "Please manually download the only 4 General Test excel reports : Summary; Current Testing Accrual Rates; Current and Prior Testing Accrual Rates; Current, Prior and Future Testing Accrual Rates");


                dic.Clear();
                dic.Add("CreateARateGroupForEachHCE", "False");
                dic.Add("GroupRates", "True");
                dic.Add("ForNormalAccrualRate", "");
                dic.Add("ForMostValuableAccrualRate", "");
                dic.Add("HighlyCompensated", "");
                dic.Add("NonHighlyCompensated", "");
                pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_NDT2016EOYand2017_Baseline, "General Test", "RollForward", false, true, false, false, false, true, true, true, dic);




            }

        

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Plan 2 - Funding - NDT 2016 EOY and 2017 - DC_Only Node
          

            pMain._SelectTab("NDT 2016 EOY and 2017");


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
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("NDT 2016 EOY and 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2016 EOY and 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._Navigate("Plan Aggregation", "RollForward", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NoAggregation", "");
            dic.Add("SamePlansIncluded", "True");
            dic.Add("PlansDiffer", "");
            dic.Add("UpdateAggregation", "");
            dic.Add("Close", "");
            pOutputManager._PopVerify_PlanAggregation(dic);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2017");
            dic.Add("Level_4", "DC Only");
            pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName2);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2016 EOY and 2017");
            dic.Add("Level_4", "DC Only");
            pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UpdateAggregation", "Click");
            dic.Add("Close", "Click");
            pOutputManager._PopVerify_PlanAggregation(dic);


            pOutputManager._ExportReport_Others(sOutputPlan2_NDT2016EOYand2017_DCOnly, "Parameter Print", "RollForward", true, true);



            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Others(sOutputPlan2_NDT2016EOYand2017_DCOnly, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan2_NDT2016EOYand2017_DCOnly, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_DCOnly, "Coverage Test", "RollForward", true, true, dic);



                //_gLib._MsgBox("Manual Steps!", "Please manually download the only 3 General Test PDF reports : Summary; Current Testing for each HCE; Current Testing Accrual Rates");


                pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_NDT2016EOYand2017_DCOnly, "General Test", "RollForward", true, true, true, false, false, true, false, false, dic);


            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputPlan2_NDT2016EOYand2017_DCOnly, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan2_NDT2016EOYand2017_DCOnly, "Individual Output", "RollForward", false, true);

                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_DCOnly, "Coverage Test", "RollForward", false, true, dic);


                //_gLib._MsgBox("Manual Steps!", "Please manually download the only 3 General Test Excel reports : Summary; Current Testing for each HCE; Current Testing Accrual Rates");

                pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_NDT2016EOYand2017_DCOnly, "General Test", "RollForward", false, true, true, false, false, true, false, false, dic);


            }


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region Plan 2 - Funding - NDT 2016 EOY and 2017 - DB_Only Node

    

            pMain._SelectTab("NDT 2016 EOY and 2017");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("NDT 2016 EOY and 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2016 EOY and 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._Navigate("Plan Aggregation", "RollForward", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NoAggregation", "");
            dic.Add("SamePlansIncluded", "True");
            dic.Add("PlansDiffer", "");
            dic.Add("UpdateAggregation", "");
            dic.Add("Close", "");
            pOutputManager._PopVerify_PlanAggregation(dic);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2017");
            dic.Add("Level_4", "DB Only");
            pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName2);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2016 EOY and 2017");
            dic.Add("Level_4", "DB Only");
            pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UpdateAggregation", "Click");
            dic.Add("Close", "Click");
            pOutputManager._PopVerify_PlanAggregation(dic);


            pOutputManager._ExportReport_Others(sOutputPlan2_NDT2016EOYand2017_DBOnly, "Parameter Print", "RollForward", true, true);



            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Others(sOutputPlan2_NDT2016EOYand2017_DBOnly, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan2_NDT2016EOYand2017_DBOnly, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_DBOnly, "Coverage Test", "RollForward", true, true, dic);



                //_gLib._MsgBox("Manual Steps!", "Please manually open General Summary report tab then check off the check box \"CreateARateGroupForEachHCE\"");
                //_gLib._MsgBox("Manual Steps!", "Please manually download the only 4 General Test PDF reports : Summary; Current Testing Accrual Rates; Current and Prior Testing Accrual Rates; Current, Prior and Future Testing Accrual Rates");


                dic.Clear();
                dic.Add("CreateARateGroupForEachHCE", "False");
                dic.Add("GroupRates", "True");
                dic.Add("ForNormalAccrualRate", "");
                dic.Add("ForMostValuableAccrualRate", "");
                dic.Add("HighlyCompensated", "");
                dic.Add("NonHighlyCompensated", "");
                pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_NDT2016EOYand2017_DBOnly, "General Test", "RollForward", true, true, false, false, false, true, true, true, dic);




            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputPlan2_NDT2016EOYand2017_DBOnly, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan2_NDT2016EOYand2017_DBOnly, "Individual Output", "RollForward", false, true);

                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_DBOnly, "Coverage Test", "RollForward", false, true, dic);


                ///_gLib._MsgBox("Manual Steps!", "Please manually open General Summary report tab then check off the check box \"CreateARateGroupForEachHCE\"");
                ///_gLib._MsgBox("Manual Steps!", "Please manually download the only 4 General Test excel reports : Summary; Current Testing Accrual Rates; Current and Prior Testing Accrual Rates; Current, Prior and Future Testing Accrual Rates");


                dic.Clear();
                dic.Add("CreateARateGroupForEachHCE", "False");
                dic.Add("GroupRates", "True");
                dic.Add("ForNormalAccrualRate", "");
                dic.Add("ForMostValuableAccrualRate", "");
                dic.Add("HighlyCompensated", "");
                dic.Add("NonHighlyCompensated", "");
                pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_NDT2016EOYand2017_DBOnly, "General Test", "RollForward", false, true, false, false, false, true, true, true, dic);


            }
          

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);





            #endregion


            #region Plan 2 - Funding - NDT 2016 EOY and 2017 - run_only_NHCEs Node


            pMain._SelectTab("NDT 2016 EOY and 2017");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("SelectRecords", "$emp.HighlyCompensatedCode = 0");
            dic.Add("Validate", "Click");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("NDT 2016 EOY and 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2016 EOY and 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._Navigate("Plan Aggregation", "RollForward", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NoAggregation", "");
            dic.Add("SamePlansIncluded", "");
            dic.Add("PlansDiffer", "True");
            dic.Add("UpdateAggregation", "");
            dic.Add("Close", "");
            pOutputManager._PopVerify_PlanAggregation(dic);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2017");
            dic.Add("Level_4", "DB Only");
            pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);

            dic.Clear();
            dic.Add("Level_1", Config.sPlanName2);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2016 EOY and 2017");
            dic.Add("Level_4", "DC Only");
            pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);

            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2016");
            dic.Add("Level_4", "Copy of PFVS");
            pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);

            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2017");
            dic.Add("Level_4", "Baseline");
            pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);

            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2017");
            dic.Add("Level_4", "DC Only");
            pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);

            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2017");
            dic.Add("Level_4", "DB Only");
            pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);

            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2017");
            dic.Add("Level_4", "DB and DC Prospective");
            pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);

            dic.Clear();
            dic.Add("Level_1", Config.sPlanName2);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2016 EOY and 2017");
            dic.Add("Level_4", "Baseline");
            pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName2);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2016 EOY and 2017");
            dic.Add("Level_4", "DC Only");
            pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName2);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2016 EOY and 2017");
            dic.Add("Level_4", "DB Only");
            pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName2);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "NDT 2016 EOY and 2017");
            dic.Add("Level_4", "run only NHCEs");
            pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);


            dic.Clear();
            dic.Add("Level_1", Config.sPlanName2);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "update 2016");
            dic.Add("Level_4", "NDT");
            pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UpdateAggregation", "Click");
            dic.Add("Close", "Click");
            pOutputManager._PopVerify_PlanAggregation(dic);


            pOutputManager._ExportReport_Others(sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "Parameter Print", "RollForward", true, true);



            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Others(sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "Individual Output", "RollForward", true, true);
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("HighlyCompensated", "100");
                dic.Add("NonHighlyCompensated", "1,000");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "Coverage Test", "RollForward", true, true, dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("CreateARateGroupForEachHCE", "");
                dic.Add("GroupRates", "");
                dic.Add("ForNormalAccrualRate", "");
                dic.Add("ForMostValuableAccrualRate", "");
                dic.Add("HighlyCompensated", "200");
                dic.Add("NonHighlyCompensated", "2,000");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "General Test", "RollForward", true, true, dic);

            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "Individual Output", "RollForward", false, true);
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("HighlyCompensated", "100");
                dic.Add("NonHighlyCompensated", "1,000");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "Coverage Test", "RollForward", false, true, dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("CreateARateGroupForEachHCE", "");
                dic.Add("GroupRates", "");
                dic.Add("ForNormalAccrualRate", "");
                dic.Add("ForMostValuableAccrualRate", "");
                dic.Add("HighlyCompensated", "200");
                dic.Add("NonHighlyCompensated", "2,000");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "General Test", "RollForward", false, true, dic);

            }



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("NDT 2016 EOY and 2017");
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
