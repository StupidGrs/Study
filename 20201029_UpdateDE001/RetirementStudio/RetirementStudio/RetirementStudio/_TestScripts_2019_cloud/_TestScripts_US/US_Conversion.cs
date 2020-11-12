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
using RetirementStudio._UIMaps.SocialSecurityCoveredCompFormulaClasses;
using RetirementStudio._UIMaps.PayCreditClasses;
using RetirementStudio._UIMaps.CashBalanceClasses;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Threading;


namespace RetirementStudio._TestScripts_2019_cloud._TestScripts_US
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class US_Conversion
    {
        public US_Conversion()
        {
            Config.eEnv = _TestingEnv.DevCurrent;
            Config.eCountry = _Country.US;
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }

        #region Report Output Directory

        public string sOutputFunding_US015_Conversion2010_Baseline = "";
        public string sOutputFunding_US008_Conversion2011_Baseline = "";
        public string sOutputFunding_US010_July2006Valuation_Baseline = "";
        public string sOutputFunding_US007_Funding2005_Baseline = "";
        public string sOutputFunding_US009_2005Funding_Baseline = "";
        public string sOutputFunding_US012_PlanTerminationSetup_PBGC_4044 = "";
        public string sOutputFunding_US014_Conversion_Baseline = "";
        public string sOutputFunding_US015_Valuation2011_FVClosedGroup = "";
        public string sOutputFunding_US015_Valuation2011_ClosedGroupRegularDecrements = "";
        public string sOutputFunding_US017_NDT2017_DBDCProspective = "";


        public string sOutputFunding_US015_Conversion2010_Baseline_bsl = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US015_Conversion2010_Baseline\20200513_DevCurrent_Baseline\";
        public string sOutputFunding_US008_Conversion2011_Baseline_bsl = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US008_Conversion2011_Baseline\20200513_DevCurrent_Baseline\";
        public string sOutputFunding_US010_July2006Valuation_Baseline_bsl = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US010_July2006Valuation_Baseline\20200513_DevCurrent_Baseline\";
        public string sOutputFunding_US007_Funding2005_Baseline_bsl = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US007_Funding2005_Baseline\20200513_DevCurrent_Baseline\";
        public string sOutputFunding_US009_2005Funding_Baseline_bsl = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US009_2005Funding_Baseline\20200513_DevCurrent_Baseline\";
        public string sOutputFunding_US012_PlanTerminationSetup_PBGC_4044_bsl = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US012_PlanTerminationSetup_PBGC_4044\20200513_DevCurrent_Baseline\";
        public string sOutputFunding_US014_Conversion_Baseline_bsl = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US014_Conversion_Baseline\20200513_DevCurrent_Baseline\";
        public string sOutputFunding_US015_Valuation2011_FVClosedGroup_bsl = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US015_Valuation2011_FVClosedGroup\20200513_DevCurrent_Baseline\";
        public string sOutputFunding_US015_Valuation2011_ClosedGroupRegularDecrements_bsl = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US015_Valuation2011_ClosedGroupRegularDecrements\20200513_DevCurrent_Baseline\";
        public string sOutputFunding_US017_NDT2017_DBDCProspective_bsl = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US017_NDT2017_DBDCProspective\20200513_DevCurrent_Baseline\";


        public void GenerateReportOuputDir_JustPrint()
        {
            _BenchmarkUser sCurrentUser = _gLib._ReturnCurrentUser();
            if (sCurrentUser.ToString() == "Others")
            {
                _gLib._MsgBox("Warning !!!", "Your are NOT allowed to create folders in \\mercer.com\\US_Data\\Shared\\Dfl\\Data1\\RSS\\SQA drive, Please contact Cindy or Webber if you have to!");
                Environment.Exit(0);
            }
            else
            {
                //string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString() + "_Baseline";
                string sPostFix = _gLib._ReturnDateStampYYYYMMDDHHMMSS() + "_" + Config.eEnv.ToString();
                //string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                //sOutputFunding_US015_Conversion2010_Baseline = _gLib._CreateDirectory(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US015_Conversion2010_Baseline\" + sPostFix + "\\");
                //sOutputFunding_US008_Conversion2011_Baseline = _gLib._CreateDirectory(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US008_Conversion2011_Baseline\" + sPostFix + "\\");
                //sOutputFunding_US010_July2006Valuation_Baseline = _gLib._CreateDirectory(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US010_July2006Valuation_Baseline\" + sPostFix + "\\");
                //sOutputFunding_US007_Funding2005_Baseline = _gLib._CreateDirectory(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US007_Funding2005_Baseline\" + sPostFix + "\\");
                //sOutputFunding_US009_2005Funding_Baseline = _gLib._CreateDirectory(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US009_2005Funding_Baseline\" + sPostFix + "\\");
                //sOutputFunding_US015_Valuation2011_FVClosedGroup = _gLib._CreateDirectory(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US015_Valuation2011_FVClosedGroup\" + sPostFix + "\\");
                //sOutputFunding_US015_Valuation2011_ClosedGroupRegularDecrements = _gLib._CreateDirectory(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US015_Valuation2011_ClosedGroupRegularDecrements\" + sPostFix + "\\");

                sOutputFunding_US015_Conversion2010_Baseline = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US015_Conversion2010_Baseline\" + sPostFix + "\\";
                sOutputFunding_US008_Conversion2011_Baseline = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US008_Conversion2011_Baseline\" + sPostFix + "\\";
                sOutputFunding_US010_July2006Valuation_Baseline = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US010_July2006Valuation_Baseline\" + sPostFix + "\\";
                sOutputFunding_US007_Funding2005_Baseline = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US007_Funding2005_Baseline\" + sPostFix + "\\";
                sOutputFunding_US009_2005Funding_Baseline = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US009_2005Funding_Baseline\" + sPostFix + "\\";
                sOutputFunding_US012_PlanTerminationSetup_PBGC_4044 = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US012_PlanTerminationSetup_PBGC_4044\" + sPostFix + "\\";
                sOutputFunding_US014_Conversion_Baseline = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US014_Conversion_Baseline\" + sPostFix + "\\";
                sOutputFunding_US015_Valuation2011_FVClosedGroup = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US015_Valuation2011_FVClosedGroup\" + sPostFix + "\\";
                sOutputFunding_US015_Valuation2011_ClosedGroupRegularDecrements = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US015_Valuation2011_ClosedGroupRegularDecrements\" + sPostFix + "\\";
                sOutputFunding_US017_NDT2017_DBDCProspective = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Conversion\sOutputFunding_US017_NDT2017_DBDCProspective\" + sPostFix + "\\";

            }

            string sContent = "";
            sContent = sContent + "sOutputFunding_US015_Conversion2010_Baseline = @\"" + sOutputFunding_US015_Conversion2010_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_US008_Conversion2011_Baseline = @\"" + sOutputFunding_US008_Conversion2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_US010_July2006Valuation_Baseline = @\"" + sOutputFunding_US010_July2006Valuation_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_US007_Funding2005_Baseline = @\"" + sOutputFunding_US007_Funding2005_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_US009_2005Funding_Baseline = @\"" + sOutputFunding_US009_2005Funding_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_US012_PlanTerminationSetup_PBGC_4044 = @\"" + sOutputFunding_US012_PlanTerminationSetup_PBGC_4044 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_US014_Conversion_Baseline = @\"" + sOutputFunding_US014_Conversion_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_US015_Valuation2011_FVClosedGroup = @\"" + sOutputFunding_US015_Valuation2011_FVClosedGroup + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_US015_Valuation2011_ClosedGroupRegularDecrements = @\"" + sOutputFunding_US015_Valuation2011_ClosedGroupRegularDecrements + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_US017_NDT2017_DBDCProspective = @\"" + sOutputFunding_US017_NDT2017_DBDCProspective + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);
        }


        public void GenerateReportOuputDir(Node node)
        {
            _BenchmarkUser sCurrentUser = _gLib._ReturnCurrentUser();
            if (sCurrentUser.ToString() == "Others")
            {
                _gLib._MsgBox("Warning !!!", "Your are NOT allowed to create folders in \\mercer.com\\US_Data\\Shared\\Dfl\\Data1\\RSS\\SQA drive, Please contact Cindy or Webber if you have to!");
                Environment.Exit(0);
            }
            else
            {
                _gLib._CreateDirectory(node.sOputputDir);

            }


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
        public SocialSecurityCoveredCompFormula pSocialSecurityCoveredCompFormula = new SocialSecurityCoveredCompFormula();
        public PayCredit pPayCredit = new PayCredit();
        public CashBalance pCashBalance = new CashBalance();



        #endregion

        #region NodeClass

        public class Node : IComparable<Node>
        {
            public string sClientName;
            public string sPlanName;
            public string sValuationName;
            public string sServiceName;
            public string sNodeName;
            public string sMaxRowNum;
            public string sMaxColNum;
            public string sRowNum;
            public string sColNum;
            public string sRunStatus;
            public int iRecordCount;
            public int iFileNodeRow;
            public string sRunType;
            public string sClickRunTime;
            public string sOputputDir;
            public string sBaselineDir;

            public Node(string _client, string _plan, string _valuation, string _service, string _node, string _maxrownum, string _maxcolnum, string _rownum, string _colnum, string _runstatus, int _recordcount, int _filenoderow, string _runtype, string _outputDir, string _baselineDir)
            {
                this.sClientName = _client;
                this.sPlanName = _plan;
                this.sValuationName = _valuation;
                this.sServiceName = _service;
                this.sNodeName = _node;
                this.sMaxRowNum = _maxrownum;
                this.sMaxColNum = _maxcolnum;
                this.sRowNum = _rownum;
                this.sColNum = _colnum;
                this.sRunStatus = _runstatus;
                this.iRecordCount = _recordcount;
                this.iFileNodeRow = _filenoderow;
                this.sRunType = _runtype;
                this.sOputputDir = _outputDir;
                this.sBaselineDir = _baselineDir;
            }

            //public void setClickRunTime(string _clickruntime)
            //{
            //    this.sClickRunTime = _clickruntime;
            //}

            public int CompareTo(Node other)
            {
                if (null == other)
                {
                    return 1;
                }
                return this.iRecordCount.CompareTo(other.iRecordCount);
            }
        }


        #endregion

        public void DownloadReport(Node node)
        {

            this.GenerateReportOuputDir(node);

            //////pMain._SelectTab("Home");

            //////dic.Clear();
            //////dic.Add("Country", Config.eCountry.ToString());
            //////dic.Add("Level_1", node.sClientName);
            //////dic.Add("Level_2", node.sPlanName);
            //////dic.Add("Level_3", node.sValuationName);
            //////pMain._HomeTreeViewSelect_Favorites(0, dic);

            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("AddServiceInstance", "");
            //////dic.Add("ServiceToOpen", node.sServiceName);
            //////pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab(node.sServiceName);

            if (node.sServiceName == "NDT 2017")
            {
                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "");
                dic.Add("iSelectColNum", "");
                dic.Add("iPosX", "400");
                dic.Add("iPosY", "150");
                dic.Add("MenuItem_1", "View Output");
                pMain._FlowTreeRightSelect(dic);
            }
            else if (node.sClientName == "US_Performance_Test_2019_Big_F" & node.sNodeName == "NewVal1")
            {
                dic.Clear();
                dic.Add("iMaxRowNum", node.sMaxRowNum);
                dic.Add("iMaxColNum", node.sMaxColNum);
                dic.Add("iSelectRowNum", "");
                dic.Add("iSelectColNum", "");
                dic.Add("iPosX", "110");
                dic.Add("iPosY", "150");
                dic.Add("MenuItem_1", "View Output");
                pMain._FlowTreeRightSelect(dic);
            }
            else if (node.sClientName == "US_Performance_Test_2019_Big_F" & node.sNodeName == "NewVal2")
            {
                dic.Clear();
                dic.Add("iMaxRowNum", node.sMaxRowNum);
                dic.Add("iMaxColNum", node.sMaxColNum);
                dic.Add("iSelectRowNum", "");
                dic.Add("iSelectColNum", "");
                dic.Add("iPosX", "280");
                dic.Add("iPosY", "150");
                dic.Add("MenuItem_1", "View Output");
                pMain._FlowTreeRightSelect(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("iMaxRowNum", node.sMaxRowNum);
                dic.Add("iMaxColNum", node.sMaxColNum);
                dic.Add("iSelectRowNum", node.sRowNum);
                dic.Add("iSelectColNum", node.sColNum);
                dic.Add("MenuItem_1", "View Output");
                pMain._FlowTreeRightSelect(dic);
            }

            if (node.sServiceName == "NDT 2017")
            {
                //pOutputManager._ExportReport_Others_PDF_EXCEL(node.sOputputDir, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(node.sOputputDir, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(node.sOputputDir, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(node.sOputputDir, "Coverage Test", "RollForward", false, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(node.sOputputDir, "General Test", "RollForward", false, true);

            }
            else if (node.sServiceName == "Plan Termination Setup")
            {
                pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "PBGC 4044 Liabilities by Plan Def", "RollForward", false, true);


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

                pOutputManager._SaveAs(node.sOputputDir + "IOE.xlsx");
                _gLib._SetSyncUDWin("OK", pOutputManager.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                _gLib._FileExists(node.sOputputDir + "IOE.xlsx", Config.iTimeout, true);

            }
            else if (node.sRunType == "FV Proj")
            {
                pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Future Valuation Population Projection", "RollForward", true, true);
            }
            else if (node.sRunType == "FV Liab")
            {
                pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Future Valuation Summary", "RollForward", true, true);
                ////////pOutputManager._ExportReport_Others_PDF_EXCEL(node.sOputputDir, "Future Valuation Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(node.sOputputDir, "Future Valuation Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Future Valuation Liabilities by Group", "RollForward", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Future Valuation Liabilities by Year", "RollForward", true, true);
                pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, node.sOputputDir, "RollForward", true, true);

            }
            else
            {

                pOutputManager._ExportReport_Others_PDF_EXCEL(node.sOputputDir, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(node.sOputputDir, "Liability Summary", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(node.sOputputDir, "Conversion Diagnostic", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Test Case List", "Conversion", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Detailed Results by Plan Def", "Conversion", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(node.sOputputDir, "Individual Output", "Conversion", true, true);
                //pOutputManager._ExportReport_Others_PDF_EXCEL(node.sOputputDir, "Parameter Print", "Conversion", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(node.sOputputDir, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(node.sOputputDir, "Payout Projection", "Conversion", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(node.sOputputDir, "IOE", "Conversion", true, true);

                pMain._SelectTab("Output Manager");
                pMain._Home_ToolbarClick_Top(true);
                pMain._Home_ToolbarClick_Top(false);


            }


        }

        public void t_CompareRpt(Node node)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib(node.sClientName + " Conversion -" + node.sNodeName, node.sBaselineDir, node.sOputputDir);
                _compareReportsLib._Report(_PassFailStep.Description, "", node.sClientName + " Conversion -" + node.sNodeName);

                if (node.sServiceName.Equals("NDT 2017"))
                {
                    _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 0, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("CoverageTest.xlsx", 0, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("GeneralTest_GeneralTestSummary.xlsx", 0, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingforEachHCE.xlsx", 0, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingforEachHCE.xlsx", 0, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingforEachHCE.xlsx", 0, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentTestingAccrualRates.xlsx", 0, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentAndPriorTestingAccrualRates.xlsx", 0, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("GeneralTest_CurrentPriorAndFutureTestingAccrualRates.xlsx", 0, 0, 0, 0);
                }
                else if (node.sServiceName == "Plan Termination Setup")
                {
                    _compareReportsLib.CompareExcel_Exact("PBGC4044LiabilitiesbyPlanDef.xlsx", 7, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                }
                else if (node.sRunType.Equals("FV Proj"))
                {
                    _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0, true);
                }
                else if (node.sRunType.Equals("FV Liab"))
                {
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
                    ////////_compareReportsLib.CompareExcel_Exact("FutureValuationIndividualOutput.xlsx", 7, 0, 0, 0);
                }
                else
                {
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
                    _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 7, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                    if(!node.sClientName.Contains("009"))
                        _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                }

                Config.bThreadFinsihed = true;

            }
        }



        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void _test_Cloud_US_Conversion()
        {
            Boolean bRunER = true;
            Boolean bRunCompleteLog = true;
            Boolean bDownloadReport = true;


            this.GenerateReportOuputDir_JustPrint();


            #region nodeList

            List<Node> nodelist = new List<Node>();



            /////////////////////// ------  DevCurrent Conversion ---------- /////////////////////////////////////

            //nodelist.Add(new Node("QA US Benchmark 015 Existing DNT", "QA US Benchmark 015 Existing DNT Plan", "FundingValuations", "Conversion 2010", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 10, 20, "", sOutputFunding_US015_Conversion2010_Baseline, sOutputFunding_US015_Conversion2010_Baseline_bsl));
            //nodelist.Add(new Node("QA US Benchmark 008 Existing DNT", "QA US Benchmark 008 Existing DNT Plan", "FundingValuations", "Conversion 2011", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 20, 125, "", sOutputFunding_US008_Conversion2011_Baseline, sOutputFunding_US008_Conversion2011_Baseline_bsl));
            //nodelist.Add(new Node("QA US Benchmark 010 Existing DNT", "QA US Benchmark 010 Existing DNT Plan", "FundingValuations", "July 2006 Valuation", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 30, 590, "", sOutputFunding_US010_July2006Valuation_Baseline, sOutputFunding_US010_July2006Valuation_Baseline_bsl));
            //nodelist.Add(new Node("QA US Benchmark 007 Existing DNT", "QA US Benchmark 007 Existing DNT Plan", "FundingValuations", "Funding 2005", "Baseline", "", "", "1", "1", "Group Job Successfully Complete with 2 NP", 40, 1236, "", sOutputFunding_US007_Funding2005_Baseline, sOutputFunding_US007_Funding2005_Baseline_bsl));
            //nodelist.Add(new Node("QA US Benchmark 009 Existing DNT", "QA US Benchmark 009 Plan Existing DNT", "FundingValuations", "2005 Funding", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 50, 9554, "", sOutputFunding_US009_2005Funding_Baseline, sOutputFunding_US009_2005Funding_Baseline_bsl));
            //nodelist.Add(new Node("QA US Benchmark 012 Existing DNT", "QA US Benchmark 012 Existing DNT Plan", "FundingValuations", "Plan Termination Setup", "PBGC_4044", "", "", "7", "1", "Group Job Successfully Complete", 59, 80, "", sOutputFunding_US012_PlanTerminationSetup_PBGC_4044, sOutputFunding_US012_PlanTerminationSetup_PBGC_4044_bsl));
            //nodelist.Add(new Node("QA US Benchmark 014 Existing DNT", "QA US Benchmark 014 Existing DNT Plan", "FundingValuations", "Conversion", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 60, 450, "", sOutputFunding_US014_Conversion_Baseline, sOutputFunding_US014_Conversion_Baseline_bsl));
            //nodelist.Add(new Node("QA US Benchmark 015 Existing DNT", "QA US Benchmark 015 Existing DNT Plan", "FundingValuations", "Valuation 2011", "FVClosedGroup", "", "2", "3", "1", "Group Job Successfully Complete", 70, 20, "FV Proj", sOutputFunding_US015_Valuation2011_FVClosedGroup, sOutputFunding_US015_Valuation2011_FVClosedGroup_bsl));
            //nodelist.Add(new Node("QA US Benchmark 015 Existing DNT", "QA US Benchmark 015 Existing DNT Plan", "FundingValuations", "Valuation 2011", "ClosedGroupRegularDecrements", "", "2", "3", "2", "Group Job Successfully Complete", 61, 20, "FV Liab", sOutputFunding_US015_Valuation2011_ClosedGroupRegularDecrements, sOutputFunding_US015_Valuation2011_ClosedGroupRegularDecrements_bsl));
            //nodelist.Add(new Node("QA US Benchmark 017 Existing DNT", "QA US Benchmark 017 Existing DNT Plan", "FundingValuations", "NDT 2017", "DBAndDCProspective", "", "", "", "", "Group Job Successfully Complete", 62, 719, "", sOutputFunding_US017_NDT2017_DBDCProspective, sOutputFunding_US017_NDT2017_DBDCProspective_bsl));


            nodelist.Add(new Node("QA US Benchmark 015 Existing DNT Cloud", "QA US Benchmark 015 Existing DNT Plan", "FundingValuations", "Conversion 2010", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 10, 20, "", sOutputFunding_US015_Conversion2010_Baseline, sOutputFunding_US015_Conversion2010_Baseline_bsl));
            nodelist.Add(new Node("QA US Benchmark 008 Existing DNT Cloud", "QA US Benchmark 008 Existing DNT Plan", "FundingValuations", "Conversion 2011", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 20, 125, "", sOutputFunding_US008_Conversion2011_Baseline, sOutputFunding_US008_Conversion2011_Baseline_bsl));
            nodelist.Add(new Node("QA US Benchmark 010 Existing DNT Cloud", "QA US Benchmark 010 Existing DNT Plan", "FundingValuations", "July 2006 Valuation", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 30, 590, "", sOutputFunding_US010_July2006Valuation_Baseline, sOutputFunding_US010_July2006Valuation_Baseline_bsl));
            nodelist.Add(new Node("QA US Benchmark 007 Existing DNT Cloud", "QA US Benchmark 007 Existing DNT Plan", "FundingValuations", "Funding 2005", "Baseline", "", "", "1", "1", "Group Job Successfully Complete with 2 NP", 40, 1236, "", sOutputFunding_US007_Funding2005_Baseline, sOutputFunding_US007_Funding2005_Baseline_bsl));
            nodelist.Add(new Node("QA US Benchmark 009 Existing DNT Cloud", "QA US Benchmark 009 Plan Existing DNT", "FundingValuations", "2005 Funding", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 50, 9554, "", sOutputFunding_US009_2005Funding_Baseline, sOutputFunding_US009_2005Funding_Baseline_bsl));
            nodelist.Add(new Node("QA US Benchmark 014 Existing DNT Cloud", "QA US Benchmark 014 Existing DNT Plan", "FundingValuations", "Conversion", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 60, 450, "", sOutputFunding_US014_Conversion_Baseline, sOutputFunding_US014_Conversion_Baseline_bsl));
            nodelist.Add(new Node("QA US Benchmark 015 Existing DNT Cloud", "QA US Benchmark 015 Existing DNT Plan", "FundingValuations", "Valuation 2011", "ClosedGroupRegularDecrements", "", "2", "3", "2", "Group Job Successfully Complete", 61, 20, "FV Liab", sOutputFunding_US015_Valuation2011_ClosedGroupRegularDecrements, sOutputFunding_US015_Valuation2011_ClosedGroupRegularDecrements_bsl));
            nodelist.Add(new Node("QA US Benchmark 017 Existing DNT Cloud", "QA US Benchmark 017 Existing DNT Plan", "FundingValuations", "NDT 2017", "DBAndDCProspective", "", "", "", "", "Group Job Successfully Complete", 62, 719, "", sOutputFunding_US017_NDT2017_DBDCProspective, sOutputFunding_US017_NDT2017_DBDCProspective_bsl));
            nodelist.Add(new Node("QA US Benchmark 012 Existing DNT Cloud", "QA US Benchmark 012 Existing DNT Plan", "FundingValuations", "Plan Termination Setup", "PBGC_4044", "", "", "7", "1", "Group Job Successfully Complete", 59, 80, "", sOutputFunding_US012_PlanTerminationSetup_PBGC_4044, sOutputFunding_US012_PlanTerminationSetup_PBGC_4044_bsl));
            nodelist.Add(new Node("QA US Benchmark 015 Existing DNT Cloud", "QA US Benchmark 015 Existing DNT Plan", "FundingValuations", "Valuation 2011", "FVClosedGroup", "", "2", "3", "1", "Group Job Successfully Complete", 70, 20, "FV Proj", sOutputFunding_US015_Valuation2011_FVClosedGroup, sOutputFunding_US015_Valuation2011_FVClosedGroup_bsl));


            #endregion

            

            #region ER Run

            _gLib._KillProcessByName("Mercer.RetirementStudio.Messaging.MessagingClientApp");

            if (bRunER == true)
            {
                foreach (Node node in nodelist)
                {


                    //Trace.WriteLine(node.sClientName + "+" + node.sPlanName + "+" + node.sValuationName + "+" + node.sServiceName + "+" + node.sNodeName + "+" + node.iRecordCount);


                    pMain._SelectTab("Home");

                    dic.Clear();
                    dic.Add("Country", Config.eCountry.ToString());
                    dic.Add("Level_1", node.sClientName);
                    dic.Add("Level_2", node.sPlanName);
                    dic.Add("Level_3", node.sValuationName);
                    pMain._HomeTreeViewSelect_Favorites(0, dic);

                    dic.Clear();
                    dic.Add("PopVerify", "Pop");
                    dic.Add("AddServiceInstance", "");
                    dic.Add("ServiceToOpen", node.sServiceName);
                    pMain._PopVerify_Home_RightPane(dic);


                    pMain._SelectTab(node.sServiceName);


                    if (node.sRunType == "FV Proj")
                    {
                        dic.Clear();
                        dic.Add("iMaxRowNum", node.sMaxRowNum);
                        dic.Add("iMaxColNum", node.sMaxColNum);
                        dic.Add("iSelectRowNum", node.sRowNum);
                        dic.Add("iSelectColNum", node.sColNum);
                        dic.Add("MenuItem_1", "Run");
                        dic.Add("MenuItem_2", "Future Valuation Population Projection");
                        pMain._FlowTreeRightSelect(dic);
                    }
                    else if (node.sRunType == "FV Liab")
                    {
                        dic.Clear();
                        dic.Add("iMaxRowNum", node.sMaxRowNum);
                        dic.Add("iMaxColNum", node.sMaxColNum);
                        dic.Add("iSelectRowNum", node.sRowNum);
                        dic.Add("iSelectColNum", node.sColNum);
                        dic.Add("MenuItem_1", "Run");
                        dic.Add("MenuItem_2", "Future Valuation Liabilities");
                        pMain._FlowTreeRightSelect(dic);
                    }
                    else if (node.sServiceName == "NDT 2017")
                    {
                        dic.Clear();
                        dic.Add("iMaxRowNum", "");
                        dic.Add("iMaxColNum", "");
                        dic.Add("iSelectRowNum", "");
                        dic.Add("iSelectColNum", "");
                        dic.Add("iPosX", "400");
                        dic.Add("iPosY", "150");
                        dic.Add("MenuItem_1", "Run");
                        dic.Add("MenuItem_2", "Liabilities");
                        pMain._FlowTreeRightSelect(dic);
                    }
                    else if (node.sClientName == "US_Performance_Test_2019_Big_F" & node.sNodeName == "NewVal1")
                    {
                        dic.Clear();
                        dic.Add("iMaxRowNum", "");
                        dic.Add("iMaxColNum", "");
                        dic.Add("iSelectRowNum", "");
                        dic.Add("iSelectColNum", "");
                        dic.Add("iPosX", "110");
                        dic.Add("iPosY", "150");
                        dic.Add("MenuItem_1", "Run");
                        dic.Add("MenuItem_2", "Liabilities");
                        pMain._FlowTreeRightSelect(dic);
                    }
                    else if (node.sClientName == "US_Performance_Test_2019_Big_F" & node.sNodeName == "NewVal2")
                    {
                        dic.Clear();
                        dic.Add("iMaxRowNum", "");
                        dic.Add("iMaxColNum", "");
                        dic.Add("iSelectRowNum", "");
                        dic.Add("iSelectColNum", "");
                        dic.Add("iPosX", "280");
                        dic.Add("iPosY", "150");
                        dic.Add("MenuItem_1", "Run");
                        dic.Add("MenuItem_2", "Liabilities");
                        pMain._FlowTreeRightSelect(dic);
                    }
                    else
                    {
                        dic.Clear();
                        dic.Add("iMaxRowNum", node.sMaxRowNum);
                        dic.Add("iMaxColNum", node.sMaxColNum);
                        dic.Add("iSelectRowNum", node.sRowNum);
                        dic.Add("iSelectColNum", node.sColNum);
                        dic.Add("MenuItem_1", "Run");
                        dic.Add("MenuItem_2", "Liabilities");
                        pMain._FlowTreeRightSelect(dic);
                    }






                    if (node.sClientName == "QA US Benchmark 011 Cloud" & node.sServiceName == "val 7.1.2019")
                    {
                        dic.Clear();
                        dic.Add("PopVerify", "Pop");
                        dic.Add("RunValuation", "Click");
                        dic.Add("OK", "");
                        pMain._PopVerify_RunOptions(dic);

                        if (_gLib._Exists("CascadingUnlock", pMain.wCascadingUnlock.wIAgreeToUnlock.chkIAgreeToUnlock, 10, false))
                        {
                            dic.Clear();
                            dic.Add("PopVerify", "Pop");
                            dic.Add("IAgreeToUnlock", "True");
                            dic.Add("OK", "Click");
                            pMain._PopVerify_CascadingUnlock(dic);
                        }
                    }
                    else if (node.sRunType == "FV Proj")
                    {
                        if (_gLib._Exists("CascadingUnlock", pMain.wCascadingUnlock.wIAgreeToUnlock.chkIAgreeToUnlock, 10, false))
                        {
                            dic.Clear();
                            dic.Add("PopVerify", "Pop");
                            dic.Add("IAgreeToUnlock", "True");
                            dic.Add("OK", "Click");
                            pMain._PopVerify_CascadingUnlock(dic);
                        }
                    }
                    else
                    {
                        dic.Clear();
                        dic.Add("PopVerify", "Pop");
                        dic.Add("RunValuation", "Click");
                        dic.Add("OK", "");
                        pMain._PopVerify_RunOptions(dic);
                    }


                    if (node.sRunType == "FV Proj")
                    { }
                    else
                    {
                        dic.Clear();
                        dic.Add("PopVerify", "Pop");
                        dic.Add("OK", "Click");
                        pMain._PopVerify_EnterpriseRunSubmitted(dic);
                    }


                    pMain._SelectTab(node.sServiceName);
                    pMain._Home_ToolbarClick_Top(false);


                    //////////Trace.WriteLine(node.sNodeName + "is finished");

                }
            }

            #endregion


            #region ER complete / Donwload Reports / Compare Reports

            if (bRunCompleteLog == true)
            {
                ////////nodelist.Sort();

                foreach (Node node in nodelist)
                {


                    pMain._SelectTab("Home");

                    dic.Clear();
                    dic.Add("Country", Config.eCountry.ToString());
                    dic.Add("Level_1", node.sClientName);
                    dic.Add("Level_2", node.sPlanName);
                    dic.Add("Level_3", node.sValuationName);
                    pMain._HomeTreeViewSelect_Favorites(0, dic);

                    dic.Clear();
                    dic.Add("PopVerify", "Pop");
                    dic.Add("AddServiceInstance", "");
                    dic.Add("ServiceToOpen", node.sServiceName);
                    pMain._PopVerify_Home_RightPane(dic);

                    pMain._SelectTab(node.sServiceName);

                    if (node.sServiceName == "NDT 2017")
                    {
                        dic.Clear();
                        dic.Add("iMaxRowNum", "");
                        dic.Add("iMaxColNum", "");
                        dic.Add("iSelectRowNum", "");
                        dic.Add("iSelectColNum", "");
                        dic.Add("iPosX", "400");
                        dic.Add("iPosY", "150");
                        dic.Add("MenuItem_1", "View Run Status");
                        pMain._FlowTreeRightSelect(dic);
                    }
                    else if (node.sClientName == "US_Performance_Test_2019_Big_F" & node.sNodeName == "NewVal1")
                    {
                        dic.Clear();
                        dic.Add("iMaxRowNum", node.sMaxRowNum);
                        dic.Add("iMaxColNum", node.sMaxColNum);
                        dic.Add("iSelectRowNum", "");
                        dic.Add("iSelectColNum", "");
                        dic.Add("iPosX", "110");
                        dic.Add("iPosY", "150");
                        dic.Add("MenuItem_1", "View Run Status");
                        pMain._FlowTreeRightSelect(dic);
                    }
                    else if (node.sClientName == "US_Performance_Test_2019_Big_F" & node.sNodeName == "NewVal2")
                    {
                        dic.Clear();
                        dic.Add("iMaxRowNum", node.sMaxRowNum);
                        dic.Add("iMaxColNum", node.sMaxColNum);
                        dic.Add("iSelectRowNum", "");
                        dic.Add("iSelectColNum", "");
                        dic.Add("iPosX", "280");
                        dic.Add("iPosY", "150");
                        dic.Add("MenuItem_1", "View Run Status");
                        pMain._FlowTreeRightSelect(dic);
                    }
                    else
                    {
                        dic.Clear();
                        dic.Add("iMaxRowNum", node.sMaxRowNum);
                        dic.Add("iMaxColNum", node.sMaxColNum);
                        dic.Add("iSelectRowNum", node.sRowNum);
                        dic.Add("iSelectColNum", node.sColNum);
                        dic.Add("MenuItem_1", "View Run Status");
                        pMain._FlowTreeRightSelect(dic);
                    }

                    if (node.sRunType == "FV Proj")
                    {
                        pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");
                    }
                    else if (node.sRunType == "FV Liab")
                    {
                        pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");
                    }
                    else pMain._EnterpriseRun(node.sRunStatus, true);

                    if (bDownloadReport)
                        this.DownloadReport(node);

                    pMain._SelectTab(node.sServiceName);
                    pMain._Home_ToolbarClick_Top(true);
                    pMain._Home_ToolbarClick_Top(false);


                    Thread thrd_CompareRPT = new Thread(() => new US_Conversion().t_CompareRpt(node));
                    thrd_CompareRPT.Start();

                }
            }

            #endregion



            _gLib._MsgBox("Congratulations!", "Finished!");


        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            _gLib._KillProcessByName("Mercer.RetirementStudio.Messaging.MessagingClientApp");
        }

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
