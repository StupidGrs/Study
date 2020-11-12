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
using RetirementStudio._UIMaps.SocialSecurityCoveredCompFormulaClasses;
using RetirementStudio._UIMaps.FAEFormulaClasses;
using RetirementStudio._UIMaps.PayCreditClasses;
using RetirementStudio._UIMaps.AdjustmentsClasses;
using RetirementStudio._UIMaps.CashBalanceClasses;
using RetirementStudio._UIMaps.UnitFormulaClasses;

using RetirementStudio._UIMaps.SocialSecurityPIAFormulaClasses;
using RetirementStudio._UIMaps.EmployeeContributionsFormulaClasses;
using RetirementStudio._UIMaps.CareerAverageEarmingsFormulaClasses;
using RetirementStudio._UIMaps.LateRetirementFactorsClasses;



namespace RetirementStudio._TestScripts_2019_Oct_US
{
    /// <summary>
    /// Summary description for US017_CN
    /// </summary>
    [CodedUITest]
    public class US017_CN
    {
        public US017_CN()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 017 Create New";
            Config.sPlanName = "QA US Benchmark 017 Create New Plan";
            Config.sPlanName2 = "QA US Benchmark 017 Create New Plan 2";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }


        #region Report Output Directory

        public string sOutputPlan1_NDT2017_Baseline = "";
        public string sOutputPlan1_NDT2017_DCOnly = "";
        public string sOutputPlan1_NDT2017_DBOnly = "";
        public string sOutputPlan1_NDT2017_DBandDCProspective = "";


        public string sOutputPlan2_update2016_updatevaldate = "";
        public string sOutputPlan2_update2016_NDT = "";
        public string sOutputPlan2_NDT2016EOYand2017_Baseline = "";
        public string sOutputPlan2_NDT2016EOYand2017_DCOnly = "";
        public string sOutputPlan2_NDT2016EOYand2017_DBOnly = "";
        public string sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs = "";


        public string sOutputPlan1_NDT2017_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\NDT 2017\Baseline\7.4_20190412_Franklin\";
        public string sOutputPlan1_NDT2017_DCOnly_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\NDT 2017\DC Only\7.4_20190412_Franklin\";
        public string sOutputPlan1_NDT2017_DBOnly_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\NDT 2017\DB Only\7.4_20190412_Franklin\";
        public string sOutputPlan1_NDT2017_DBandDCProspective_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\NDT 2017\DB and DC Prospective\7.4_20190412_Franklin\";

        public string sOutputPlan2_update2016_updatevaldate_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\update 2016\update val date\7.4_20190412_Franklin\";
        public string sOutputPlan2_update2016_NDT_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\update 2016\NDT\7.4_20190412_Franklin\";
        public string sOutputPlan2_NDT2016EOYand2017_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\NDT 2016 EOY and 2017\Baseline\7.4_20190412_Franklin\";
        public string sOutputPlan2_NDT2016EOYand2017_DCOnly_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\NDT 2016 EOY and 2017\DC Only\7.4_20190412_Franklin\";
        public string sOutputPlan2_NDT2016EOYand2017_DBOnly_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\NDT 2016 EOY and 2017\DB Only\7.4_20190412_Franklin\";
        public string sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Production\NDT 2016 EOY and 2017\run only NHCEs\7.4_20190412_Franklin\";




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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_017_NDT\Create New\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputPlan1_NDT2017_Baseline = _gLib._CreateDirectory(sMainDir + "NDT 2017\\Baseline\\" + sPostFix + "\\");
                    sOutputPlan1_NDT2017_DCOnly = _gLib._CreateDirectory(sMainDir + "NDT 2017\\DC Only\\" + sPostFix + "\\");
                    sOutputPlan1_NDT2017_DBOnly = _gLib._CreateDirectory(sMainDir + "NDT 2017\\DB Only\\" + sPostFix + "\\");
                    sOutputPlan1_NDT2017_DBandDCProspective = _gLib._CreateDirectory(sMainDir + "NDT 2017\\DB and DC Prospective\\" + sPostFix + "\\");
                    sOutputPlan2_update2016_updatevaldate = _gLib._CreateDirectory(sMainDir + "update 2016\\update val date\\" + sPostFix + "\\");
                    sOutputPlan2_update2016_NDT = _gLib._CreateDirectory(sMainDir + "update 2016\\NDT\\" + sPostFix + "\\");
                    sOutputPlan2_NDT2016EOYand2017_Baseline = _gLib._CreateDirectory(sMainDir + "NDT 2016 EOY and 2017\\Baseline\\" + sPostFix + "\\");
                    sOutputPlan2_NDT2016EOYand2017_DCOnly = _gLib._CreateDirectory(sMainDir + "NDT 2016 EOY and 2017\\DC Only\\" + sPostFix + "\\");
                    sOutputPlan2_NDT2016EOYand2017_DBOnly = _gLib._CreateDirectory(sMainDir + "NDT 2016 EOY and 2017\\DB Only\\" + sPostFix + "\\");
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
                sOutputPlan1_NDT2017_Baseline = _gLib._CreateDirectory(sMainDir + "\\Plan1_NDT2017\\Baseline\\");
                sOutputPlan1_NDT2017_DCOnly = _gLib._CreateDirectory(sMainDir + "\\Plan1_NDT2017\\DCOnly\\");
                sOutputPlan1_NDT2017_DBOnly = _gLib._CreateDirectory(sMainDir + "\\Plan1_NDT2017\\DBOnly\\");
                sOutputPlan1_NDT2017_DBandDCProspective = _gLib._CreateDirectory(sMainDir + "\\Plan2_NDT2017\\DBandDCProspective\\");
                sOutputPlan2_update2016_updatevaldate = _gLib._CreateDirectory(sMainDir + "\\Plan2_update2016\\updatevaldate\\");
                sOutputPlan2_update2016_NDT = _gLib._CreateDirectory(sMainDir + "\\Plan2_update2016\\NDT\\");
                sOutputPlan2_NDT2016EOYand2017_Baseline = _gLib._CreateDirectory(sMainDir + "\\Plan2_NDT2016EOYand2017\\Baseline\\");
                sOutputPlan2_NDT2016EOYand2017_DCOnly = _gLib._CreateDirectory(sMainDir + "\\Plan2_NDT2016EOYand2017\\DCOnly\\");
                sOutputPlan2_NDT2016EOYand2017_DBOnly = _gLib._CreateDirectory(sMainDir + "\\Plan2_NDT2016EOYand2017\\DBOnly\\");
                sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs = _gLib._CreateDirectory(sMainDir + "\\Plan2_NDT2016EOYand2017\\runonlyNHCEs\\");


            }

            string sContent = "";
            sContent = sContent + "sOutputPlan1_NDT2017_Baseline = @\"" + sOutputPlan1_NDT2017_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan1_NDT2017_DCOnly = @\"" + sOutputPlan1_NDT2017_DCOnly + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan1_NDT2017_DBOnly = @\"" + sOutputPlan1_NDT2017_DBOnly + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPlan1_NDT2017_DBandDCProspective = @\"" + sOutputPlan1_NDT2017_DBandDCProspective + "\";" + Environment.NewLine;
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


        public UnitFormula pUnitFormula = new UnitFormula();
        public CashBalance pCashBalance = new CashBalance();
        public Adjustments pAdjustments = new Adjustments();
        public PayCredit pPayCredit = new PayCredit();
        public FAEFormula pFAEFormula = new FAEFormula();
        public SocialSecurityCoveredCompFormula pSocialSecurityCoveredCompFormula = new SocialSecurityCoveredCompFormula();
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

        public SocialSecurityPIAFormula pSocialSecurityPIAFormula = new SocialSecurityPIAFormula();
        public EmployeeContributionsFormula pEmployeeContributionsFormula = new EmployeeContributionsFormula();
        public CareerAverageEarmingsFormula pCareerAverageEarmingsFormula = new CareerAverageEarmingsFormula();

        public LateRetirementFactors pLateRetirementFactors = new LateRetirementFactors();

        #endregion


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_US017_CN()
        {


            #region MultiThreads


            Thread thrd_Plan1_NDT2017_Baseline = new Thread(() => new US017_CN().t_CompareRpt_Plan1_NDT2017_Baseline(sOutputPlan1_NDT2017_Baseline));
            Thread thrd_Plan1_NDT2017_DCOnly = new Thread(() => new US017_CN().t_CompareRpt_Plan1_NDT2017_DCOnly(sOutputPlan1_NDT2017_DCOnly));
            Thread thrd_Plan1_NDT2017_DBOnly = new Thread(() => new US017_CN().t_CompareRpt_Plan1_NDT2017_DBOnly(sOutputPlan1_NDT2017_DBOnly));
            Thread thrd_Plan1_NDT2017_DBandDCProspective = new Thread(() => new US017_CN().t_CompareRpt_Plan1_NDT2017_DBandDCProspective(sOutputPlan1_NDT2017_DBandDCProspective));
            Thread thrd_Plan2_update2016_updatevaldate = new Thread(() => new US017_CN().t_CompareRpt_Plan2_update2016_updatevaldate(sOutputPlan2_update2016_updatevaldate));
            Thread thrd_Plan2_update2016_NDT = new Thread(() => new US017_CN().t_CompareRpt_Plan2_update2016_NDT(sOutputPlan2_update2016_NDT));
            Thread thrd_Plan2_NDT2016EOYand2017_Baseline = new Thread(() => new US017_CN().t_CompareRpt_Plan2_NDT2016EOYand2017_Baseline(sOutputPlan2_NDT2016EOYand2017_Baseline));
            Thread thrd_Plan2_NDT2016EOYand2017_DCOnly = new Thread(() => new US017_CN().t_CompareRpt_Plan2_NDT2016EOYand2017_DCOnly(sOutputPlan2_NDT2016EOYand2017_DCOnly));
            Thread thrd_Plan2_NDT2016EOYand2017_DBOnly = new Thread(() => new US017_CN().t_CompareRpt_Plan2_NDT2016EOYand2017_DBOnly(sOutputPlan2_NDT2016EOYand2017_DBOnly));


            #endregion


            this.GenerateReportOuputDir();


            #region Plan 1 - Funding - NDT 2017 - Baseline Node


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            _gLib._MsgBox("", "please delete RollForward service 2017");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "NDT 2017");
            dic.Add("Parent", "NDT 2016");
            dic.Add("ParentFinalValuationSet", "update for eoy test");
            dic.Add("PlanYearBeginningIn", "2017");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "true");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "NDT 2017");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("NDT 2017");

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
            dic.Add("LiabilityValuationDate", "01/01/2017");
            dic.Add("Data_AddNew", "True");
            dic.Add("Data_Name", "Baseline Data");
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
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab("NDT 2017");


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
            dic.Add("DataEffectiveDate", "01/01/2017");
            dic.Add("Snapshot", "True");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "datayr1");
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

            pMain._SelectTab("Participant DataSet");


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("NDT 2017");


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
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_Baseline, "Parameter Print", "RollForward", true, true);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_Baseline, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_Baseline, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_Baseline, "Coverage Test", "RollForward", false, true);
            pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan1_NDT2017_Baseline, "General Test", "RollForward", false, true, true, true, false, true, true, false, dic);





            thrd_Plan1_NDT2017_Baseline.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Plan 1 - Funding - NDT 2017 - DC_Only Node


            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "DC Only");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "true");
            dic.Add("MethodsLiabilities_Name", "DC Only Methods");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "true");
            dic.Add("Provisions_Name", "DC Only Provisions");
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
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Employee Contributions Formula");
            dic.Add("MenuItem", "Add Employee Contributions Formula");
            pAssumptions._TreeViewRightSelect(dic, "eec401k");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Employee Contributions Formula");
            dic.Add("Level_4", "eec401k");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "Click");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "");
            dic.Add("StopContributionAt_C", "Click");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "70");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "Click");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "Click");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "cbrate");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "SalProj");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "Service");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NumberOfRateTiers", "3");
            dic.Add("IntegrationType", "");
            dic.Add("NumberOfBreakPoints", "");
            pFAEFormula._PopVerify_Standard(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 3, "5");
            pFAEFormula._TBL_NonIntegrated(1, 3, 3, "15");
            pFAEFormula._TBL_NonIntegrated(1, 4, 3, "40");


            pFAEFormula._TBL_NonIntegrated(2, 2, 3, "0.01");
            pFAEFormula._TBL_NonIntegrated(2, 3, 3, "0.05");
            pFAEFormula._TBL_NonIntegrated(2, 4, 3, "0.02");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Employee Contributions Formula");
            dic.Add("Level_4", "eec401k");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Employee Contributions Formula");
            dic.Add("Level_4", "eec401k");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "Click");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "");
            dic.Add("StopContributionAt_C", "Click");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "Click");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "Click");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "cbrate");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "SalProj");
            dic.Add("Service", "CreditedSvc");
            dic.Add("RatesTiersBasedOn", "Service");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NumberOfRateTiers", "3");
            dic.Add("IntegrationType", "");
            dic.Add("NumberOfBreakPoints", "");
            pFAEFormula._PopVerify_Standard(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 3, "20");
            pFAEFormula._TBL_NonIntegrated(1, 3, 3, "30");
            pFAEFormula._TBL_NonIntegrated(1, 4, 3, "50");


            pFAEFormula._TBL_NonIntegrated(2, 2, 3, "0.015");
            pFAEFormula._TBL_NonIntegrated(2, 3, 3, "0.05");
            pFAEFormula._TBL_NonIntegrated(2, 4, 3, "0.055");


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "Union");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Employee Contributions Formula");
            dic.Add("Level_4", "eec401k");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Employee Contributions Formula");
            dic.Add("Level_4", "eec401k");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "Click");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "");
            dic.Add("StopContributionAt_C", "Click");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "Click");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "Click");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "cbrate");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "SalProj");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "Age + Service");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NumberOfRateTiers", "2");
            dic.Add("IntegrationType", "");
            dic.Add("NumberOfBreakPoints", "");
            pFAEFormula._PopVerify_Standard(dic);



            pFAEFormula._TBL_NonIntegrated(1, 2, 2, "50");
            pFAEFormula._TBL_NonIntegrated(1, 3, 2, "120");


            pFAEFormula._TBL_NonIntegrated(2, 2, 2, "0.02");
            pFAEFormula._TBL_NonIntegrated(2, 3, 2, "0.06");



            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "NonUnion");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Employee Contributions Formula");
            dic.Add("Level_4", "eec401k");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Employee Contributions Formula");
            dic.Add("Level_4", "eec401k");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "Click");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "");
            dic.Add("StopContributionAt_C", "Click");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "70");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "Click");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "Click");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "cbrate");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "SalProj");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "None");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.045");


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "SalEE");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("NDT 2017");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Methods");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValuationDateAccrued_TheBeginingOf", "true");
            dic.Add("ValuationDateAccrued_TheEndof", "");
            dic.Add("TestingBasis_BenefitBasis", "");
            dic.Add("TestingBasis_ContributionBasis", "");
            dic.Add("ForRatioPercentageTest_IncludeDB", "");
            dic.Add("ForRatioPercentageTest_IncludeDC", "");
            pMethods._Method_NonDiscriminationTesting(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllMeasurements", "");
            dic.Add("Current", "");
            dic.Add("CurrentAndPrior", "false");
            dic.Add("CurrentPriorAndFuture", "");
            pMethods._PopVerify_Methods_Measurement(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NormalRetirementAge_V", "");
            dic.Add("NormalRetirementAge_cbo", "");
            dic.Add("TestingAge_V", "");
            dic.Add("TestingAge_cbo", "");
            dic.Add("Testing_AveragePayDefinition", "");
            dic.Add("Testing_UseCurrentPay", "");
            dic.Add("DBTestingService_Service", "");
            dic.Add("PermittedDisparity_SocialSecurityConvered", "");
            dic.Add("PermittedDisparity_FreshStartService", "");
            dic.Add("IncludedefinedContribution_401kmAnnualAddition", "eec401k");
            dic.Add("IncludedefinedContribution_401kmBalance", "");
            dic.Add("IncludedefinedContribution_401kmService", "");
            dic.Add("IncludedefinedContribution_Non401kmAnnualAddition", "");
            dic.Add("IncludedefinedContribution_Non401kmBalance", "");
            dic.Add("IncludedefinedContribution_Non401kmService", "");
            pMethods._Method_NonDiscriminationTesting(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValuationDateAccrued_TheBeginingOf", "");
            dic.Add("ValuationDateAccrued_TheEndof", "");
            dic.Add("TestingBasis_BenefitBasis", "");
            dic.Add("TestingBasis_ContributionBasis", "true");
            dic.Add("ForRatioPercentageTest_IncludeDB", "true");
            dic.Add("ForRatioPercentageTest_IncludeDC", "");
            pMethods._Method_NonDiscriminationTesting(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("NDT 2017");


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
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DCOnly, "Parameter Print", "RollForward", true, true);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DCOnly, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DCOnly, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DCOnly, "Coverage Test", "RollForward", false, true);
            pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan1_NDT2017_DCOnly, "General Test", "RollForward", false, true, true, false, false, true, false, false, dic);



            thrd_Plan1_NDT2017_DCOnly.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Plan 1 - Funding - NDT 2017 - DB_Only Node


            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "DB Only");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "true");
            dic.Add("MethodsLiabilities_Name", "DB Only Methods");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "");
            dic.Add("Provisions_Name", "");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Methods");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllMeasurements", "true");
            dic.Add("Current", "");
            dic.Add("CurrentAndPrior", "");
            dic.Add("CurrentPriorAndFuture", "");
            pMethods._PopVerify_Methods_Measurement(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValuationDateAccrued_TheBeginingOf", "true");
            dic.Add("ValuationDateAccrued_TheEndof", "");
            dic.Add("TestingBasis_BenefitBasis", "");
            dic.Add("TestingBasis_ContributionBasis", "");
            dic.Add("ForRatioPercentageTest_IncludeDB", "");
            dic.Add("ForRatioPercentageTest_IncludeDC", "false");
            pMethods._Method_NonDiscriminationTesting(dic);


            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("NDT 2017");


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
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBOnly, "Parameter Print", "RollForward", true, true);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBOnly, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBOnly, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBOnly, "Coverage Test", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBOnly, "General Test", "RollForward", false, true);


            thrd_Plan1_NDT2017_DBOnly.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Plan 1 - Funding - NDT 2017 - DB_and_DC_Prospective Node


            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "DB and DC Prospective");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "true");
            dic.Add("MethodsLiabilities_Name", "DB and DC Prospective Methods");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "");
            dic.Add("Provisions_Name", "");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab("NDT 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "425");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Methods");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllMeasurements", "true");
            dic.Add("Current", "");
            dic.Add("CurrentAndPrior", "");
            dic.Add("CurrentPriorAndFuture", "");
            pMethods._PopVerify_Methods_Measurement(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValuationDateAccrued_TheBeginingOf", "true");
            dic.Add("ValuationDateAccrued_TheEndof", "");
            dic.Add("TestingBasis_BenefitBasis", "");
            dic.Add("TestingBasis_ContributionBasis", "");
            dic.Add("ForRatioPercentageTest_IncludeDB", "");
            dic.Add("ForRatioPercentageTest_IncludeDC", "");
            pMethods._Method_NonDiscriminationTesting(dic);


            pMain._Home_ToolbarClick_Top(true);


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


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBandDCProspective, "Parameter Print", "RollForward", true, true);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBandDCProspective, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBandDCProspective, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBandDCProspective, "Coverage Test", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan1_NDT2017_DBandDCProspective, "General Test", "RollForward", false, true);




            thrd_Plan1_NDT2017_DBandDCProspective.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("NDT 2017");
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

            _gLib._MsgBox("Manual Step!", "Please manually select on   Plan2 -> FundingValuation in Home page tree view!");
            _gLib._MsgBox("Manual Step!", "delete 2 RollForward node");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "update 2016");
            dic.Add("Parent", "conversion 2016");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "2016");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "true");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "update 2016");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("update 2016");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "update val date");
            dic.Add("LiabilityValuationDate", "08/01/2016");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "true");
            dic.Add("Assumptions_Name", "update val date");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "true");
            dic.Add("Provisions_Name", "update valdate");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab("update 2016");


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
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "True");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("Rate", "PPA 3-segment rates");
            dic.Add("AsOfDate", "08/01/2016");
            pInterestRate._PopVerify_PrescribedRates(dic);


            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("update 2016");


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
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("Level_3", "LSAE");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "True");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "08/01/2016");
            pInterestRate._PopVerify_PrescribedRates(dic);


            pMain._Home_ToolbarClick_Top(true);


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


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_update2016_updatevaldate, "Parameter Print", "RollForward", true, true);


            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputPlan2_update2016_updatevaldate, "Liabilities Detailed Results", "RollForward", false, true);


            thrd_Plan2_update2016_updatevaldate.Start();



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Plan 2 - Funding - update 2016 - NDT Node


            pMain._SelectTab("update 2016");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "NDT");
            dic.Add("LiabilityValuationDate", "08/01/2016");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "true");
            dic.Add("Assumptions_Name", "NDT Assumptions");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "true");
            dic.Add("MethodsLiabilities_Name", "NDT Methods");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "true");
            dic.Add("Provisions_Name", "NDT Provisions");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("update 2016");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Methods");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Funding", "Click");
            dic.Add("PBGCTermLiability", "");
            dic.Add("NondiscriminationTesting", "true");
            pMethods._PopVerify_Methods(dic);


            pMain._SelectTab("update 2016");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
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
            dic.Add("PrescribedRates", "true");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "8.5");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ApplyPercentMarriedAt", "");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "100.0");
            dic.Add("txtPercentMarried_F", "100.0");
            dic.Add("cboPercentMarried", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "0");
            dic.Add("txtDifferenceInSpouseAge_F", "0");
            dic.Add("cboDifferenceInSpouseAge", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "_Death");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("PrePostCommencement", "");
            dic.Add("PreDecrementPostCommencement", "");
            dic.Add("UnisexMortality", "");
            dic.Add("ProjectedStaticMortalit", "");
            dic.Add("GenerationalMortality", "");
            dic.Add("DisabledVsHealthy", "");
            dic.Add("MemberVsSpouse", "");
            pMortalityDecrement._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "PPA2016CMF");
            dic.Add("Mortality_Setback_M", "");
            dic.Add("Mortality_Setback_F", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);


            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("update 2016");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "FreshStartSvc");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "FreshStartSvc");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "Click");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "");
            dic.Add("ServiceStarts_FixedDate", "08/01/2010");
            dic.Add("Date", "HireDate1");
            dic.Add("RoundingRule", "Completed months");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "testingage");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "testingage");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("SSNRA", "true");
            dic.Add("FixedAge", "");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "$ValDate");
            dic.Add("ServiceBasedOn", "$Service");
            dic.Add("AgeBasedOn", "$Age");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Hourly");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Hourly");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.DivisionCode = \"H\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("MenuItem", "Add Pay Average");
            pAssumptions._TreeViewRightSelect(dic, "testingavg");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("Level_3", "testingavg");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "SalPrj");
            dic.Add("AveragingMethod", "M consecutive out of last N years");
            dic.Add("M", "3");
            dic.Add("N", "7");
            dic.Add("RoundingForYearOfHire", "");
            dic.Add("DecimalPlacesForYearOfHire", "");
            dic.Add("Include", "");
            dic.Add("DropForCalculations", "");
            dic.Add("DropForCalculationAndPeriodConsidered", "True");
            pPayAverage._PopVerify_Standard(dic);


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Unit Formula");
            dic.Add("Level_4", "UnionBen");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Service", "CreditedSvc");
            dic.Add("LimitServiceTo", "40");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccuralAt_C", "");
            dic.Add("StopAccuralAt_cbo", "");
            dic.Add("StopAccuralAt_txt", "");
            dic.Add("RateTiersBasedOn", "");
            dic.Add("NumberOfRateTiers", "");
            pUnitFormula._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "2");
            dic.Add("iRowMax", "1");
            dic.Add("iColMax", "2");
            dic.Add("sData", "175.00");
            dic.Add("bPayCredit", "");
            pUnitFormula._FormulaTable(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "Hourly");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Pay Credit");
            dic.Add("MenuItem", "Add Pay Credit");
            pAssumptions._TreeViewRightSelect(dic, "dcaccrual");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Pay Credit");
            dic.Add("Level_4", "dcaccrual");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "SalPrj");
            dic.Add("ServiceBasedOn", "$Service");
            pPayCredit._PopVerify_Standard(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.075");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Employee Contributions Formula");
            dic.Add("Level_4", "EEC");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "True");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "Click");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "dcaccrual");
            pEmployeeContributionsFormula._Standard_PreDefinedAmount(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Custom Provision");
            dic.Add("Level_3", "FinalBen");
            dic.Add("Level_4", "SalEE");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max($FAEBen,$UnionBen,$CABen,$CashBalAccount[$ExitAge][Max(65,$ValAge)]*$LStoSLA[Max(65,$ValAge)])");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Custom Provision");
            dic.Add("Level_3", "FinalBen");
            dic.Add("Level_4", "Union");
            pAssumptions._TreeViewSelect(dic);


            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "Click");
            dic.Add("txtLocalEligibility", "unionorhrly");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$Union or $Hourly");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Custom Provision");
            dic.Add("Level_3", "FinalBen");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$CABen + Max($FAEBen -$UnionBen,0)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVRet");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("NondiscriminationTestingBenefit", "false");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("PBGC4044Calculations", "");
            dic.Add("NormalFormofPayment", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "Click");
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
            dic.Add("ConversionFactor", "SLAtoJS");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "limits");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            dic.Add("MostValuableForm", "");
            dic.Add("MaximumBenefitLimitation_CA", "");
            dic.Add("LumpSumCommutedValue", "");
            dic.Add("ActuarialEquivalenceForLump", "");
            dic.Add("SpecialWithdrawalBenefit", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "NormalNDTBen");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "NormalNDTBen");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("NondiscriminationTestingBenefit", "true");
            dic.Add("ForTestingAccrualRate", "Normal");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("PBGC4044Calculations", "");
            dic.Add("NormalFormofPayment", "SLA");
            dic.Add("ParticipantType", "Actives");
            dic.Add("SingleFormulaBenefit", "FinalBen");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "Click");
            dic.Add("BenefitCommenceAge_cbo", "NRA");
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
            dic.Add("MaximumBenefitLimitation", "limits");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            dic.Add("MostValuableForm", "");
            dic.Add("MaximumBenefitLimitation_CA", "");
            dic.Add("LumpSumCommutedValue", "");
            dic.Add("ActuarialEquivalenceForLump", "");
            dic.Add("SpecialWithdrawalBenefit", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "MVNDTBen");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "MVNDTBen");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("NondiscriminationTestingBenefit", "true");
            dic.Add("ForTestingAccrualRate", "Most valuable");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("PBGC4044Calculations", "");
            dic.Add("NormalFormofPayment", "");
            dic.Add("ParticipantType", "Actives");
            dic.Add("SingleFormulaBenefit", "CABen");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "Click");
            dic.Add("BenefitCommenceAge_cbo", "ERA");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "cliff");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "ERF");
            dic.Add("LateRetirementFactor", "LRF");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "SLAtoJS");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "limits");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            dic.Add("MostValuableForm", "JS");
            dic.Add("MaximumBenefitLimitation_CA", "");
            dic.Add("LumpSumCommutedValue", "");
            dic.Add("ActuarialEquivalenceForLump", "");
            dic.Add("SpecialWithdrawalBenefit", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "MVNDTBen");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "MVNDTBen");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("NondiscriminationTestingBenefit", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("PBGC4044Calculations", "");
            dic.Add("NormalFormofPayment", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "CashBalAccount");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "Click");
            dic.Add("BenefitCommenceAge_cbo", "ERA");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "cliff");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "LStoSLA");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "limits");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            dic.Add("MostValuableForm", "JS");
            dic.Add("MaximumBenefitLimitation_CA", "");
            dic.Add("LumpSumCommutedValue", "");
            dic.Add("ActuarialEquivalenceForLump", "");
            dic.Add("SpecialWithdrawalBenefit", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "SalEE");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("update 2016");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Methods");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllMeasurements", "");
            dic.Add("Current", "true");
            dic.Add("CurrentAndPrior", "true");
            dic.Add("CurrentPriorAndFuture", "true");
            pMethods._PopVerify_Methods_Measurement(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NormalRetirementAge_V", "click");
            dic.Add("NormalRetirementAge_cbo", "$SSNRA");
            dic.Add("TestingAge_V", "click");
            dic.Add("TestingAge_cbo", "testingage");
            dic.Add("Testing_AveragePayDefinition", "testingavg");
            dic.Add("Testing_UseCurrentPay", "false");
            dic.Add("DBTestingService_Service", "CreditedSvc");
            dic.Add("PermittedDisparity_SocialSecurityConvered", "CovComp");
            dic.Add("PermittedDisparity_FreshStartService", "FreshStartSvc");
            dic.Add("PermittedDisparity_UseFixedPercentage_rd", "true");
            dic.Add("PermittedDisparity_UseFixedPercentage_txt", " 0.75");
            dic.Add("IncludedefinedContribution_401kmAnnualAddition", "");
            dic.Add("IncludedefinedContribution_401kmBalance", "");
            dic.Add("IncludedefinedContribution_401kmService", "");
            dic.Add("IncludedefinedContribution_Non401kmAnnualAddition", "dcaccrual");
            dic.Add("IncludedefinedContribution_Non401kmBalance", "ContribsWInterest1");
            dic.Add("IncludedefinedContribution_Non401kmService", "$Service");
            pMethods._Method_NonDiscriminationTesting(dic);



            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("update 2016");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.EmployeeIDNumber=1111111206");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.EmployeeIDNumber=1111111411");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.EmployeeIDNumber=1111111412");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            pMain._Home_ToolbarClick_Top(true);


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
            dic.Add("Level_4", "Baseline");
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


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_update2016_NDT, "Parameter Print", "RollForward", true, true);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_update2016_NDT, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_update2016_NDT, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPlan2_update2016_NDT, "Coverage Test", "RollForward", false, true, dic);




            dic.Clear();
            dic.Add("CreateARateGroupForEachHCE", "False");
            dic.Add("GroupRates", "True");
            dic.Add("ForNormalAccrualRate", "");
            dic.Add("ForMostValuableAccrualRate", "");
            dic.Add("HighlyCompensated", "");
            dic.Add("NonHighlyCompensated", "");
            pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_update2016_NDT, "General Test", "RollForward", false, true, false, false, false, true, true, true, dic);



            thrd_Plan2_update2016_NDT.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Plan 2 - Funding - update 2016 - update_EOY Node


            pMain._SelectTab("update 2016");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "update EOY");
            dic.Add("LiabilityValuationDate", "08/01/2016");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "true");
            dic.Add("MethodsLiabilities_Name", "update EOY Methods");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "");
            dic.Add("Provisions_Name", "");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("update 2016");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Methods");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NormalRetirementAge_V", "click");
            dic.Add("NormalRetirementAge_cbo", "");
            dic.Add("TestingAge_V", "click");
            dic.Add("TestingAge_cbo", "");
            dic.Add("ValuationDateAccrued_TheEndof", "True");
            dic.Add("Testing_AveragePayDefinition", "");
            dic.Add("Testing_UseCurrentPay", "true");
            dic.Add("DBTestingService_Service", "");
            dic.Add("PermittedDisparity_SocialSecurityConvered", "");
            dic.Add("PermittedDisparity_FreshStartService", "");
            dic.Add("IncludedefinedContribution_401kmAnnualAddition", "");
            dic.Add("IncludedefinedContribution_401kmBalance", "");
            dic.Add("IncludedefinedContribution_401kmService", "");
            dic.Add("IncludedefinedContribution_Non401kmAnnualAddition", "");
            dic.Add("IncludedefinedContribution_Non401kmBalance", "");
            dic.Add("IncludedefinedContribution_Non401kmService", "");
            pMethods._Method_NonDiscriminationTesting(dic);




            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("update 2016");


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion



            #region Plan 2 - Funding - NDT 2016 EOY and 2017 - Baseline Node


            pMain._SelectTab("Home");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "NDT 2016 EOY and 2017");
            dic.Add("Parent", "update 2016");
            dic.Add("ParentFinalValuationSet", "update EOY");
            dic.Add("PlanYearBeginningIn", "2017");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "true");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "NDT 2016 EOY and 2017");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("NDT 2016 EOY and 2017");

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
            dic.Add("LiabilityValuationDate", "08/01/2017");
            dic.Add("Data_AddNew", "True");
            dic.Add("Data_Name", "Baseline Data");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "True");
            dic.Add("MethodsLiabilities_Name", "Baseline Methods");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "");
            dic.Add("Provisions_Name", "");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab("NDT 2016 EOY and 2017");


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
            dic.Add("DataEffectiveDate", "08/01/2017");
            dic.Add("Snapshot", "True");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "valdata");
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

            pMain._SelectTab("Participant DataSet");


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("NDT 2016 EOY and 2017");


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
            dic.Add("NormalRetirementAge_V", "click");
            dic.Add("NormalRetirementAge_cbo", "");
            dic.Add("TestingAge_V", "click");
            dic.Add("TestingAge_cbo", "");
            dic.Add("Testing_AveragePayDefinition", "");
            dic.Add("Testing_UseCurrentPay", "false");
            dic.Add("DBTestingService_Service", "");
            dic.Add("PermittedDisparity_SocialSecurityConvered", "");
            dic.Add("PermittedDisparity_FreshStartService", "");
            dic.Add("IncludedefinedContribution_401kmAnnualAddition", "");
            dic.Add("IncludedefinedContribution_401kmBalance", "");
            dic.Add("IncludedefinedContribution_401kmService", "");
            dic.Add("IncludedefinedContribution_Non401kmAnnualAddition", "");
            dic.Add("IncludedefinedContribution_Non401kmBalance", "");
            dic.Add("IncludedefinedContribution_Non401kmService", "");
            pMethods._Method_NonDiscriminationTesting(dic);


            pMain._Home_ToolbarClick_Top(true);



            pMain._SelectTab("NDT 2016 EOY and 2017");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Test Case Library");


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.EmployeeIDNumber=1111111140");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.EmployeeIDNumber=1111111141");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.EmployeeIDNumber=1111111633");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            pMain._Home_ToolbarClick_Top(true);


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


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_Baseline, "Parameter Print", "RollForward", true, true);




            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_Baseline, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_Baseline, "Individual Output", "RollForward", false, true);

            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_Baseline, "Coverage Test", "RollForward", false, true, dic);



            dic.Clear();
            dic.Add("CreateARateGroupForEachHCE", "False");
            dic.Add("GroupRates", "True");
            dic.Add("ForNormalAccrualRate", "");
            dic.Add("ForMostValuableAccrualRate", "");
            dic.Add("HighlyCompensated", "");
            dic.Add("NonHighlyCompensated", "");
            pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_NDT2016EOYand2017_Baseline, "General Test", "RollForward", false, true, false, false, false, true, true, true, dic);


            thrd_Plan2_NDT2016EOYand2017_Baseline.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Plan 2 - Funding - NDT 2016 EOY and 2017 - DC_Only Node


            pMain._SelectTab("NDT 2016 EOY and 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "DC Only");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "true");
            dic.Add("MethodsLiabilities_Name", "DC Only Methods");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "true");
            dic.Add("Provisions_Name", "DC Only Provisions");
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
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "NRA");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "12/31/2017");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "testingage");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "12/31/2017");
            dic.Add("DateField", "#1#");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "DC");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "DC");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.DivisionCode = \"D\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Pay Credit");
            dic.Add("Level_4", "dcaccrual");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceLimitTo", "25");
            dic.Add("IntegrationType", "");
            dic.Add("NumberOfBreakPoints", "");
            pFAEFormula._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Pay Credit");
            dic.Add("Level_4", "dcaccrual");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "SalPrj");
            dic.Add("ServiceBasedOn", "$Service");
            pPayCredit._PopVerify_Standard(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.1");


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "DC");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Career Average Earnings Formula");
            dic.Add("Level_4", "CABen");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "SalPrj");
            dic.Add("ServiceBasedOn", "$Service");
            pPayCredit._PopVerify_Standard(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StrartingAccruedAmount_V", "click");
            dic.Add("StrartingAccruedAmount_C", "");
            dic.Add("StrartingAccruedAmount_cbo", "AccruedBenefit1");
            pCareerAverageEarmingsFormula._Formula(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.01");


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "true");
            dic.Add("txtLocalEligibility", "post65accrual");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$ValAge > 65");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "MVNDTBen");
            dic.Add("Level_4", "SalEE");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("NondiscriminationTestingBenefit", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("PBGC4044Calculations", "");
            dic.Add("NormalFormofPayment", "");
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
            dic.Add("LateRetirementFactor", "LRF");
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
            dic.Add("MaximumBenefitLimitation", "limits");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            dic.Add("MostValuableForm", "");
            dic.Add("MaximumBenefitLimitation_CA", "");
            dic.Add("LumpSumCommutedValue", "");
            dic.Add("ActuarialEquivalenceForLump", "");
            dic.Add("SpecialWithdrawalBenefit", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("NDT 2016 EOY and 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Methods");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllMeasurements", "");
            dic.Add("Current", "true");
            dic.Add("CurrentAndPrior", "false");
            dic.Add("CurrentPriorAndFuture", "false");
            pMethods._PopVerify_Methods_Measurement(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValuationDateAccrued_TheBeginingOf", "true");
            dic.Add("ValuationDateAccrued_TheEndof", "");
            dic.Add("TestingBasis_BenefitBasis", "");
            dic.Add("TestingBasis_ContributionBasis", "true");
            dic.Add("ForRatioPercentageTest_IncludeDB", "false");
            dic.Add("ForRatioPercentageTest_IncludeDC", "");
            pMethods._Method_NonDiscriminationTesting(dic);


            pMain._Home_ToolbarClick_Top(true);


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


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_DCOnly, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_DCOnly, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_DCOnly, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_DCOnly, "Coverage Test", "RollForward", false, true, dic);
            pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_NDT2016EOYand2017_DCOnly, "General Test", "RollForward", false, true, true, false, false, true, false, false, dic);



            thrd_Plan2_NDT2016EOYand2017_DCOnly.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region Plan 2 - Funding - NDT 2016 EOY and 2017 - DB_Only Node


            pMain._SelectTab("NDT 2016 EOY and 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "DB Only");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "true");
            dic.Add("MethodsLiabilities_Name", "DB Only Methods");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "true");
            dic.Add("Provisions_Name", "DB Only Provisions");
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
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("Level_3", "LSAE");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "True");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "08/01/2017");
            pInterestRate._PopVerify_PrescribedRates(dic);


            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("NDT 2016 EOY and 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Methods");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValuationDateAccrued_TheBeginingOf", "");
            dic.Add("ValuationDateAccrued_TheEndof", "");
            dic.Add("TestingBasis_BenefitBasis", "true");
            dic.Add("TestingBasis_ContributionBasis", "");
            dic.Add("ForRatioPercentageTest_IncludeDB", "true");
            dic.Add("ForRatioPercentageTest_IncludeDC", "false");
            pMethods._Method_NonDiscriminationTesting(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllMeasurements", "");
            dic.Add("Current", "true");
            dic.Add("CurrentAndPrior", "true");
            dic.Add("CurrentPriorAndFuture", "true");
            pMethods._PopVerify_Methods_Measurement(dic);


            pMain._Home_ToolbarClick_Top(true);


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


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_DBOnly, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_DBOnly, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_DBOnly, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_DBOnly, "Coverage Test", "RollForward", false, true, dic);


            dic.Clear();
            dic.Add("CreateARateGroupForEachHCE", "False");
            dic.Add("GroupRates", "True");
            dic.Add("ForNormalAccrualRate", "");
            dic.Add("ForMostValuableAccrualRate", "");
            dic.Add("HighlyCompensated", "");
            dic.Add("NonHighlyCompensated", "");
            pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_NDT2016EOYand2017_DBOnly, "General Test", "RollForward", false, true, false, false, false, true, true, true, dic);



            thrd_Plan2_NDT2016EOYand2017_DBOnly.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);





            #endregion


            #region Plan 2 - Funding - NDT 2016 EOY and 2017 - run_only_NHCEs Node


            pMain._SelectTab("NDT 2016 EOY and 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "run only NHCEs");
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
            dic.Add("Provisions_AddNew", "");
            dic.Add("Provisions_Name", "");
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
            dic.Add("Level_4", "Baseline");
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


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "Individual Output", "RollForward", false, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("HighlyCompensated", "100");
            dic.Add("NonHighlyCompensated", "1,000");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "Coverage Test", "RollForward", false, true, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CreateARateGroupForEachHCE", "");
            dic.Add("GroupRates", "");
            dic.Add("ForNormalAccrualRate", "");
            dic.Add("ForMostValuableAccrualRate", "");
            dic.Add("HighlyCompensated", "200");
            dic.Add("NonHighlyCompensated", "2,000");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs, "General Test", "RollForward", false, true, dic);


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017CN", sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs_Prod, sOutputPlan2_NDT2016EOYand2017_runonlyNHCEs);
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



        void t_CompareRpt_Plan1_NDT2017_Baseline(string sOutputPlan1_NDT2017_Baseline)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017CN", sOutputPlan1_NDT2017_Baseline_Prod, sOutputPlan1_NDT2017_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan1_NDT2017_Baseline");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0);

                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Plan1_NDT2017_DCOnly(string sOutputPlan1_NDT2017_DCOnly)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017CN", sOutputPlan1_NDT2017_DCOnly_Prod, sOutputPlan1_NDT2017_DCOnly);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan1_NDT2017_DCOnly");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0);

                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Plan1_NDT2017_DBOnly(string sOutputPlan1_NDT2017_DBOnly)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017CN", sOutputPlan1_NDT2017_DBOnly_Prod, sOutputPlan1_NDT2017_DBOnly);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan1_NDT2017_DBOnly");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);

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

        void t_CompareRpt_Plan1_NDT2017_DBandDCProspective(string sOutputPlan1_NDT2017_DBandDCProspective)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017CN", sOutputPlan1_NDT2017_DBandDCProspective_Prod, sOutputPlan1_NDT2017_DBandDCProspective);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan1_NDT2017_DBandDCProspective");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);

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

        void t_CompareRpt_Plan2_update2016_updatevaldate(string sOutputPlan2_update2016_updatevaldate)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017CN", sOutputPlan2_update2016_updatevaldate_Prod, sOutputPlan2_update2016_updatevaldate);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan2_update2016_updatevaldate");
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);

                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Plan2_update2016_NDT(string sOutputPlan2_update2016_NDT)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017CN", sOutputPlan2_update2016_NDT_Prod, sOutputPlan2_update2016_NDT);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan2_update2016_NDT");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0);

                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Plan2_NDT2016EOYand2017_Baseline(string sOutputPlan2_NDT2016EOYand2017_Baseline)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017CN", sOutputPlan2_NDT2016EOYand2017_Baseline_Prod, sOutputPlan2_NDT2016EOYand2017_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan2_NDT2016EOYand2017_Baseline");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0);

                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Plan2_NDT2016EOYand2017_DCOnly(string sOutputPlan2_NDT2016EOYand2017_DCOnly)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017CN", sOutputPlan2_NDT2016EOYand2017_DCOnly_Prod, sOutputPlan2_NDT2016EOYand2017_DCOnly);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan2_NDT2016EOYand2017_DCOnly");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0);

                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Plan2_NDT2016EOYand2017_DBOnly(string sOutputPlan2_NDT2016EOYand2017_DBOnly)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US017CN", sOutputPlan2_NDT2016EOYand2017_DBOnly_Prod, sOutputPlan2_NDT2016EOYand2017_DBOnly);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Plan2_NDT2016EOYand2017_DBOnly");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                ////_compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0);
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
