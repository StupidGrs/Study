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


namespace RetirementStudio._TestScripts._TestScripts_US
{
    /// <summary>
    /// Summary description for US017_DNT
    /// </summary>
    [CodedUITest]
    public class US017_DNT
    {
        public US017_DNT()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 017 Existing DNT";
            Config.sPlanName = "QA US Benchmark 017 Existing DNT Plan";
            Config.sPlanName2 = "QA US Benchmark 017 Existing DNT Plan 2";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;


            //////_gLib._Report(_PassFailStep.Header, "Testing Starts at: " + DateTime.Now + "\t" + Environment.UserName);

            //////_gLib._MsgBox("Warning!", "If you are running Existing or Re-opened Studio after crash, Please manually select the Client in Studio-> Home -> All Services -> "
            //////    + Config.sClientName + Environment.NewLine + Environment.NewLine + "If you are running CreateNew without any crash, Please ignore this msg!"
            //////    + Environment.NewLine + Environment.NewLine + "Click OK to keep testing!");
        }


        #region Report Output Directory



        public string sOutputPlan1_RetroNDT2011 = "";
        public string sOutputPlan2_Conversion2008 = "";
        public string sOutputPlan2_ProspectiveNDTRF_NDTContributions = "";
        public string sOutputPlan1_NDT2016_CopyofPFVS = "";
        public string sOutputPlan1_NDT2017_DBandDCProspective = "";
        public string sOutputPlan2_conversion2016_CopyofPFVS = "";
        public string sOutputPlan2_update2016_NDT = "";
        public string sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs = "";


        public string sOutputPlan1_RetroNDT2011_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\Retro NDT 2011\7.0.1.0_20170509_Franklin\";
        public string sOutputPlan2_Conversion2008_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\Conversion 2008\7.0.1.0_20170509_Franklin\";
        public string sOutputPlan2_ProspectiveNDTRF_NDTContributions_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\Prospective NDT RF\NDT_Contributions\7.0.1.0_20170518_Franklin\";
        public string sOutputPlan1_NDT2016_CopyofPFVS_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\NDT 2016\Copy of PFVS\7.1_20180223_Franklin\";
        public string sOutputPlan1_NDT2017_DBandDCProspective_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\NDT 2017\DB and DC Prospective\7.1_20180223_Franklin\";
        public string sOutputPlan2_conversion2016_CopyofPFVS_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\conversion 2016\Copy of PFVS\7.1_20180223_Franklin\";
        public string sOutputPlan2_update2016_NDT_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\update 2016\NDT\7.1_20180223_Franklin\";
        public string sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\NDT 2016 EOY and 2017\run only NHCEs\7.1_20180223_Franklin\";



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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Existing\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputPlan1_RetroNDT2011 = _gLib._CreateDirectory(sMainDir + "Retro NDT 2011\\" + sPostFix + "\\");
                    sOutputPlan2_Conversion2008 = _gLib._CreateDirectory(sMainDir + "Conversion 2008\\" + sPostFix + "\\");
                    sOutputPlan2_ProspectiveNDTRF_NDTContributions = _gLib._CreateDirectory(sMainDir + "Prospective NDT RF\\NDT_Contributions\\" + sPostFix + "\\");
                    sOutputPlan1_NDT2016_CopyofPFVS = _gLib._CreateDirectory(sMainDir + "NDT 2016\\Copy of PFVS\\" + sPostFix + "\\");
                    sOutputPlan1_NDT2017_DBandDCProspective = _gLib._CreateDirectory(sMainDir + "NDT 2017\\DB and DC Prospective\\" + sPostFix + "\\");
                    sOutputPlan2_conversion2016_CopyofPFVS = _gLib._CreateDirectory(sMainDir + "conversion 2016\\Copy of PFVS\\" + sPostFix + "\\");
                    sOutputPlan2_update2016_NDT = _gLib._CreateDirectory(sMainDir + "update 2016\\NDT\\" + sPostFix + "\\");
                    sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs = _gLib._CreateDirectory(sMainDir + "NDT 2016 EOY and 2017\\run only NHCEs\\" + sPostFix + "\\");



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

                string sMainDir = sDir + "US017_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputPlan1_RetroNDT2011 = _gLib._CreateDirectory(sMainDir + "\\Plan1_RetroNDT2011\\");
                sOutputPlan2_Conversion2008 = _gLib._CreateDirectory(sMainDir + "\\Plan2_Conversion2008\\");
                sOutputPlan2_ProspectiveNDTRF_NDTContributions = _gLib._CreateDirectory(sMainDir + "\\Plan2_ProspectiveNDTRF_NDTContributions\\");
                sOutputPlan1_NDT2016_CopyofPFVS = _gLib._CreateDirectory(sMainDir + "\\Plan1_NDT2016\\CopyofPFVS\\");
                sOutputPlan1_NDT2017_DBandDCProspective = _gLib._CreateDirectory(sMainDir + "\\Plan2_NDT2017\\DBandDCProspective\\");
                sOutputPlan2_conversion2016_CopyofPFVS = _gLib._CreateDirectory(sMainDir + "\\Plan2_conversion2016\\CopyofPFVS\\");
                sOutputPlan2_update2016_NDT = _gLib._CreateDirectory(sMainDir + "\\Plan2_update2016\\NDT\\");
                sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs = _gLib._CreateDirectory(sMainDir + "\\Plan2_NDT2016EOYand2017\\runonlyNHCEs\\");


            }

            string sContent = "";
            sContent = sContent + "sOutputPlan1_RetroNDT2011 = @\"" + sOutputPlan1_RetroNDT2011 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan2_Conversion2008 = @\"" + sOutputPlan2_Conversion2008 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan2_ProspectiveNDTRF_NDTContributions = @\"" + sOutputPlan2_ProspectiveNDTRF_NDTContributions + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan1_NDT2016_CopyofPFVS = @\"" + sOutputPlan1_NDT2016_CopyofPFVS + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan1_NDT2017_DBandDCProspective = @\"" + sOutputPlan1_NDT2017_DBandDCProspective + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan2_conversion2016_CopyofPFVS = @\"" + sOutputPlan2_conversion2016_CopyofPFVS + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan2_update2016_NDT = @\"" + sOutputPlan2_update2016_NDT + "\";" + Environment.NewLine;
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
        public void test_US017_DNT()
        {


            //pOutputManager._ExportReport_Others(sOutputPlan1_RetroNDT2011, "Coverage Test", "RollForward", true, true);
            pOutputManager._Navigate(_Country.US, "General Test", "RollForward", true);




            _gLib._MsgBoxYesNo("Congratulations!", "Finished!");


            #region MultiThreads


            Thread thrd_Plan1_RetroNDT2011 = new Thread(() => new US017_DNT().t_CompareRpt_Plan1_RetroNDT2011(sOutputPlan1_RetroNDT2011));
            Thread thrd_Plan2_Conversion2008 = new Thread(() => new US017_DNT().t_CompareRpt_Plan2_Conversion2008(sOutputPlan2_Conversion2008));
            Thread thrd_Plan2_ProspectiveNDTRF_NDTContributions = new Thread(() => new US017_DNT().t_CompareRpt_Plan2_ProspectiveNDTRF_NDTContributions(sOutputPlan2_ProspectiveNDTRF_NDTContributions));
            Thread thrd_Plan1_NDT2016_CopyofPFVS = new Thread(() => new US017_DNT().t_CompareRpt_Plan1_NDT2016_CopyofPFVS(sOutputPlan1_NDT2016_CopyofPFVS));
            Thread thrd_Plan1_NDT2017_DBandDCProspective = new Thread(() => new US017_DNT().t_CompareRpt_Plan1_NDT2017_DBandDCProspective(sOutputPlan1_NDT2017_DBandDCProspective));
            Thread thrd_Plan2_conversion2016_CopyofPFVS = new Thread(() => new US017_DNT().t_CompareRpt_Plan2_conversion2016_CopyofPFVS(sOutputPlan2_conversion2016_CopyofPFVS));
            Thread thrd_Plan2_update2016_NDT = new Thread(() => new US017_DNT().t_CompareRpt_Plan2_update2016_NDT(sOutputPlan2_update2016_NDT));
            
            #endregion




            this.GenerateReportOuputDir();


            #region sOutputPlan1_RetroNDT2011

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            //////////////pMain._HomeTreeViewSelect_US017(Config.sClientName, 1, 2);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Retro NDT 2011");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Retro NDT 2011");

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
            dic.Add("Service", "");
            dic.Add("Pay", "");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "");
            dic.Add("Pension", "");
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
            dic.Add("Nondiscrimination", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Retro NDT 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Retro NDT 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Others(sOutputPlan1_RetroNDT2011, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_RetroNDT2011, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_RetroNDT2011, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_RetroNDT2011, "Coverage Test", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_RetroNDT2011, "General Test", "RollForward", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputPlan1_RetroNDT2011, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_RetroNDT2011, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_RetroNDT2011, "Coverage Test", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan1_RetroNDT2011, "General Test", "RollForward", false, true);
            }


            thrd_Plan1_RetroNDT2011.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Retro NDT 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion



            #region sOutputPlan2_Conversion2008

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName2);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            //////////////pMain._HomeTreeViewSelect_US017(Config.sClientName, 2, 2);

            _gLib._MsgBox("Manual Step!", "Please manually select on Plan2_FundingValuation in Home page tree view!");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Conversion 2008");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Conversion 2008");

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
            dic.Add("Pay", "SalPriorYear1");
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
            dic.Add("Nondiscrimination", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Conversion 2008");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Conversion 2008");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputPlan2_Conversion2008, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputPlan2_Conversion2008, "Liability Summary", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(sOutputPlan2_Conversion2008, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputPlan2_Conversion2008, "Conversion Diagnostic", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(sOutputPlan2_Conversion2008, "Test Case List", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPlan2_Conversion2008, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPlan2_Conversion2008, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan2_Conversion2008, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan2_Conversion2008, "Parameter Print", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan2_Conversion2008, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan2_Conversion2008, "Payout Projection", "Conversion", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputPlan2_Conversion2008, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputPlan2_Conversion2008, "Liability Summary", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(sOutputPlan2_Conversion2008, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputPlan2_Conversion2008, "Conversion Diagnostic", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(sOutputPlan2_Conversion2008, "Test Case List", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPlan2_Conversion2008, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPlan2_Conversion2008, "Detailed Results by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPlan2_Conversion2008, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan2_Conversion2008, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan2_Conversion2008, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan2_Conversion2008, "Payout Projection", "Conversion", false, true);

            }

            thrd_Plan2_Conversion2008.Start();



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Conversion 2008");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            #endregion



            #region sOutputPlan2_ProspectiveNDTRF_NDTContributions

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName2);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            //////////////pMain._HomeTreeViewSelect_US017(Config.sClientName, 2, 2);


            _gLib._MsgBox("Manual Step!", "Please manually select on Plan2_FundingValuation in Home page tree view!");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Prospective NDT RF");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Prospective NDT RF");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "2");
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
            dic.Add("Service", "");
            dic.Add("Pay", "");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "");
            dic.Add("Pension", "");
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
            dic.Add("Nondiscrimination", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Prospective NDT RF");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Prospective NDT RF");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(sOutputPlan2_ProspectiveNDTRF_NDTContributions, "Parameter Print", "RollForward", true, true);



            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Others(sOutputPlan2_ProspectiveNDTRF_NDTContributions, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan2_ProspectiveNDTRF_NDTContributions, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputPlan2_ProspectiveNDTRF_NDTContributions, "Coverage Test", "RollForward", true, true);
                
                ////_gLib._MsgBox("Manual Steps!", "Please manually download the only 3 General Test PDF reports : Summary; Current Testing for each HCE; Current Testing Accrual Rates");

                pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_ProspectiveNDTRF_NDTContributions, "General Test", "RollForward", true, true, true, false, false, true, false, false, dic);
  

            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputPlan2_ProspectiveNDTRF_NDTContributions, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan2_ProspectiveNDTRF_NDTContributions, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputPlan2_ProspectiveNDTRF_NDTContributions, "Coverage Test", "RollForward", false, true);
                
                ////_gLib._MsgBox("Suggestion!", "Webber may need to add tab selectable mode for Generla Test reports download!");
                ////_gLib._MsgBox("Manual Steps!", "Please manually download the only 3 General Test Excel reports : Summary; Current Testing for each HCE; Current Testing Accrual Rates");

                pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_ProspectiveNDTRF_NDTContributions, "General Test", "RollForward", false, true, true, false, false, true, false, false, dic);
  


            }


            thrd_Plan2_ProspectiveNDTRF_NDTContributions.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Prospective NDT RF");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion



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


            thrd_Plan1_NDT2016_CopyofPFVS.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("NDT 2016");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion



            #region Plan 1 - Funding - NDT 2017 - DB_and_DC_Prospective Node


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


            thrd_Plan1_NDT2017_DBandDCProspective.Start();


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


            thrd_Plan2_conversion2016_CopyofPFVS.Start();



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("conversion 2016");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion



            #region Plan 2 - Funding - update 2016 - NDT Node


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


            thrd_Plan2_update2016_NDT.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("update 2016");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion



            #region Plan 2 - Funding - NDT 2016 EOY and 2017 - run_only_NHCEs Node


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


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017DNT", sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs_Prod, sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan2_NDT2016EOYand2017_runonlyNHCEs");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0);


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



        void t_CompareRpt_Plan1_RetroNDT2011(string sOutputPlan1_RetroNDT2011)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017DNT", sOutputPlan1_RetroNDT2011_Prod, sOutputPlan1_RetroNDT2011);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan1_RetroNDT2011");

                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Plan2_Conversion2008(string sOutputPlan2_Conversion2008)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017DNT", sOutputPlan2_Conversion2008_Prod, sOutputPlan2_Conversion2008);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan2_Conversion2008");
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

        void t_CompareRpt_Plan2_ProspectiveNDTRF_NDTContributions(string sOutputPlan2_ProspectiveNDTRF_NDTContributions)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017DNT", sOutputPlan2_ProspectiveNDTRF_NDTContributions_Prod, sOutputPlan2_ProspectiveNDTRF_NDTContributions);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan2_ProspectiveNDTRF_NDTContributions");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0, true);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0, true);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0);

                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Plan1_NDT2016_CopyofPFVS(string sOutputPlan1_NDT2016_CopyofPFVS)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017DNT", sOutputPlan1_NDT2016_CopyofPFVS_Prod, sOutputPlan1_NDT2016_CopyofPFVS);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan1_NDT2016_CopyofPFVS");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0, true);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0);

                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Plan1_NDT2017_DBandDCProspective(string sOutputPlan1_NDT2017_DBandDCProspective)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017DNT", sOutputPlan1_NDT2017_DBandDCProspective_Prod, sOutputPlan1_NDT2017_DBandDCProspective);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan1_NDT2017_DBandDCProspective");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0);

                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Plan2_conversion2016_CopyofPFVS(string sOutputPlan2_conversion2016_CopyofPFVS)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017DNT", sOutputPlan2_conversion2016_CopyofPFVS_Prod, sOutputPlan2_conversion2016_CopyofPFVS);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan2_conversion2016_CopyofPFV");
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);

                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Plan2_update2016_NDT(string sOutputPlan2_update2016_NDT)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017DNT", sOutputPlan2_update2016_NDT_Prod, sOutputPlan2_update2016_NDT);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan2_update2016_NDT");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0, true);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0, true);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0);

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
