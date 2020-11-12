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
    public class US_Rollforward
    {
        public US_Rollforward()
        {
            Config.eEnv = _TestingEnv.DevCurrent;
            Config.eCountry = _Country.US;
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }



                       

        #region Report Output Directory

        public string sOutputFunding_US015_Valuation2011_Baseline = "";
        public string sOutputFunding_US008_Valuation2012_Baseline = "";
        public string sOutputAccounting_US008_FASVal2012_Baseline = "";
        public string sOutputFunding_US010_July2007Valuation_Baseline = "";
        public string sOutputAccounting_US010_July2007FASVal_Baseline = "";
        public string sOutputFunding_US007_Funding2006_Baseline = "";
        public string sOutputAccounting_US007_2006Accounting_Baseline = "";
        public string sOutputFunding_US009_2006Funding_Baseline = "";
        public string sOutputFunding_US019_112018FundingValuation_FutureValRun = "";


        public string sOutputFunding_US015_Valuation2011_Baseline_bsl = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Rollforward\sOutputFunding_US015_Valuation2011_Baseline\20200520_DevCurrent_Baseline\";
        public string sOutputFunding_US008_Valuation2012_Baseline_bsl = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Rollforward\sOutputFunding_US008_Valuation2012_Baseline\20200520_DevCurrent_Baseline\";
        public string sOutputAccounting_US008_FASVal2012_Baseline_bsl = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Rollforward\sOutputAccounting_US008_FASVal2012_Baseline\20200520_DevCurrent_Baseline\";
        public string sOutputFunding_US010_July2007Valuation_Baseline_bsl = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Rollforward\sOutputFunding_US010_July2007Valuation_Baseline\20200520_DevCurrent_Baseline\";
        public string sOutputAccounting_US010_July2007FASVal_Baseline_bsl = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Rollforward\sOutputAccounting_US010_July2007FASVal_Baseline\20200520_DevCurrent_Baseline\";
        public string sOutputFunding_US007_Funding2006_Baseline_bsl = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Rollforward\sOutputFunding_US007_Funding2006_Baseline\20200520_DevCurrent_Baseline\";
        public string sOutputAccounting_US007_2006Accounting_Baseline_bsl = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Rollforward\sOutputAccounting_US007_2006Accounting_Baseline\20200520_DevCurrent_Baseline\";
        public string sOutputFunding_US009_2006Funding_Baseline_bsl = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Rollforward\sOutputFunding_US009_2006Funding_Baseline\20200520_DevCurrent_Baseline\";
        public string sOutputFunding_US019_112018FundingValuation_FutureValRun_bsl = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Rollforward\sOutputFunding_US019_112018FundingValuation_FutureValRun\20200520_DevCurrent_Baseline\";


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



                sOutputFunding_US015_Valuation2011_Baseline = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Rollforward\sOutputFunding_US015_Valuation2011_Baseline\" + sPostFix + "\\";
                sOutputFunding_US008_Valuation2012_Baseline = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Rollforward\sOutputFunding_US008_Valuation2012_Baseline\" + sPostFix + "\\";
                sOutputAccounting_US008_FASVal2012_Baseline = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Rollforward\sOutputAccounting_US008_FASVal2012_Baseline\" + sPostFix + "\\";
                sOutputFunding_US010_July2007Valuation_Baseline = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Rollforward\sOutputFunding_US010_July2007Valuation_Baseline\" + sPostFix + "\\";
                sOutputAccounting_US010_July2007FASVal_Baseline = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Rollforward\sOutputAccounting_US010_July2007FASVal_Baseline\" + sPostFix + "\\";
                sOutputFunding_US007_Funding2006_Baseline = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Rollforward\sOutputFunding_US007_Funding2006_Baseline\" + sPostFix + "\\";
                sOutputAccounting_US007_2006Accounting_Baseline = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Rollforward\sOutputAccounting_US007_2006Accounting_Baseline\" + sPostFix + "\\";
                sOutputFunding_US009_2006Funding_Baseline = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Rollforward\sOutputFunding_US009_2006Funding_Baseline\" + sPostFix + "\\";
                sOutputFunding_US019_112018FundingValuation_FutureValRun = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\Rollforward\sOutputFunding_US019_112018FundingValuation_FutureValRun\" + sPostFix + "\\";

            }

            string sContent = "";
            sContent = sContent + "sOutputFunding_US015_Valuation2011_Baseline = @\"" + sOutputFunding_US015_Valuation2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_US008_Valuation2012_Baseline = @\"" + sOutputFunding_US008_Valuation2012_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_US008_FASVal2012_Baseline = @\"" + sOutputAccounting_US008_FASVal2012_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_US010_July2007Valuation_Baseline = @\"" + sOutputFunding_US010_July2007Valuation_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_US010_July2007FASVal_Baseline = @\"" + sOutputAccounting_US010_July2007FASVal_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_US007_Funding2006_Baseline = @\"" + sOutputFunding_US007_Funding2006_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_US007_2006Accounting_Baseline = @\"" + sOutputAccounting_US007_2006Accounting_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_US009_2006Funding_Baseline = @\"" + sOutputFunding_US009_2006Funding_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_US019_112018FundingValuation_FutureValRun = @\"" + sOutputFunding_US019_112018FundingValuation_FutureValRun + "\";" + Environment.NewLine;

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




            if (node.sRunType == "FV Liab")
            {
                pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Future Valuation Summary", "RollForward", true, true);
                ////pOutputManager._ExportReport_Others_PDF_EXCEL(node.sOputputDir, "Future Valuation Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(node.sOputputDir, "Future Valuation Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Future Valuation Liabilities by Group", "RollForward", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Future Valuation Liabilities by Year", "RollForward", true, true);
                pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, node.sOputputDir, "RollForward", true, true);

            }
            else
            {
                            
                if (node.sValuationName == "FundingValuations")
                {
                    
                    pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Status Reconciliation", "RollForward", false, true);
                    pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Member Statistics", "RollForward", false, true);
                    if (!node.sClientName.Contains("009"))
                        pOutputManager._ExportReport_Others_PDF_EXCEL(node.sOputputDir, "Individual Checking Template", "RollForward", false, true);
                    pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Age Service Matrix", "RollForward", false, true);
                    pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Data Matching Summary", "RollForward", false, true);
                    pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Combined Status Code Summary", "RollForward", false, true);
                    pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Gain / Loss Status Reconciliation", "RollForward", false, true);
                    pOutputManager._ExportReport_SubReports_PDF_EXCEL(node.sOputputDir, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
                    pOutputManager._ExportReport_SubReports_PDF_EXCEL(node.sOputputDir, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
                    pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Decrement Age", "RollForward", false, true);
                    pOutputManager._ExportReport_SubReports_PDF_EXCEL(node.sOputputDir, "Gain / Loss Participant Listing", "RollForward", false, true);

                    if (node.sClientName.Contains("008"))
                    {
                        //pOutputManager._ExportReport_SubReports_PDF_EXCEL(node.sOputputDir, "Liability Comparison", "RollForward", false, true);
                    }
                }
                if (node.sValuationName == "AccountingValuations")
                {

                    pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Status Reconciliation", "RollForward", false, false);
                    pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Member Statistics", "RollForward", false, false);
                    pOutputManager._ExportReport_Others_PDF_EXCEL(node.sOputputDir, "Individual Checking Template", "RollForward", false, false);
                    pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Age Service Matrix", "RollForward", false, false);
                    pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Data Matching Summary", "RollForward", false, false);
                    pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Combined Status Code Summary", "RollForward", false, false);
                    pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Gain / Loss Status Reconciliation", "RollForward", false, false);
                    pOutputManager._ExportReport_SubReports_PDF_EXCEL(node.sOputputDir, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, false);
                    pOutputManager._ExportReport_SubReports_PDF_EXCEL(node.sOputputDir, "Active Decrement Gain / Loss Detail", "RollForward", false, false);
                    pOutputManager._ExportReport_Common_PDF_EXCEL(node.sOputputDir, "Decrement Age", "RollForward", false, false);
                    pOutputManager._ExportReport_SubReports_PDF_EXCEL(node.sOputputDir, "Gain / Loss Participant Listing", "RollForward", false, false);
                    
                    if (node.sClientName.Contains("008"))
                    {
                        //pOutputManager._ExportReport_SubReports_PDF_EXCEL(node.sOputputDir, "Liability Comparison", "RollForward", false, false);
                    }
                }

                pMain._SelectTab("Output Manager");
                pMain._Home_ToolbarClick_Top(true);
                pMain._Home_ToolbarClick_Top(false);


            }


        }

        public void t_CompareRpt(Node node)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib(node.sClientName + "-" + node.sValuationName + " Rollforward -" + node.sNodeName, node.sBaselineDir, node.sOputputDir);
                _compareReportsLib._Report(_PassFailStep.Description, "", node.sClientName + "-" + node.sValuationName + " Rollforward -" + node.sNodeName);

                if (node.sServiceName.Equals("NDT 2017"))
                {
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
                else if (node.sServiceName == "Plan Termination Setup")
                {
                    _compareReportsLib.CompareExcel_Exact("PBGC4044LiabilitiesbyPlanDef.xlsx", 7, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                }
                else if (node.sRunType.Equals("FV Proj"))
                {
                    _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                }
                else if (node.sRunType.Equals("FV Liab"))
                {
                    _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                    _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
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
                    _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                    _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                    ////_compareReportsLib.CompareExcel_Exact("FutureValuationIndividualOutput.xlsx", 7, 0, 0, 0);
                }
                else
                {
                    _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                    if (!node.sClientName.Contains("009"))
                    {
                        _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward.xlsx", 4, 0, 0, 0);
                        _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary.xlsx", 4, 0, 0, 0);
                        _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics.xlsx", 4, 0, 0, 0);
                    }

                    _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                    ////////_compareReportsLib.CompareExcel_Exact("DataComparison.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("GainLossStatusReconciliation.xlsx", 4, 0, 0, 0);
                    if (node.sValuationName.Equals("FundingValuations"))
                    {
                        _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PPANARMin.xlsx", 4, 0, 0, 0);
                        _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PPANARMax.xlsx", 4, 0, 0, 0);
                        _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PPANARMin.xlsx", 4, 0, 0, 0);
                        _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PPANARMax.xlsx", 4, 0, 0, 0);
                        if (!node.sClientName.Contains("009"))
                        {
                            _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PPANARMin.xlsx", 4, 0, 0, 0);
                            _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PPANARMax.xlsx", 4, 0, 0, 0);
                        }

                    }
                    if (node.sValuationName.Equals("AccountingValuations"))
                    {
                        _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_ABO.xlsx", 4, 0, 0, 0);
                        _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PBO.xlsx", 4, 0, 0, 0);
                        _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_ABO.xlsx", 4, 0, 0, 0);
                        _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PBO.xlsx", 4, 0, 0, 0);
                        _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_ABO.xlsx", 4, 0, 0, 0);
                        _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PBO.xlsx", 4, 0, 0, 0);
                    }
                    
                    _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0);

                    if (node.sClientName.Contains("008"))
                    {
                        _compareReportsLib.CompareExcel_Exact("LiabilityComparison_PPANARMin.xlsx", 0, 0, 0, 0);
                        _compareReportsLib.CompareExcel_Exact("LiabilityComparison_PPANARMax.xlsx", 0, 0, 0, 0);
                    }

                }

                Config.bThreadFinsihed = true;

            }
        }


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void _test_Cloud_US_Rollforward()
        {
            Boolean bRunER = false;
            Boolean bRunCompleteLog = true;
            Boolean bDownloadReport = true;


            this.GenerateReportOuputDir_JustPrint();


            #region nodeList

            List<Node> nodelist = new List<Node>();



            /////////////////////////// ------  DevCurrent Rollforward & FV ---------- /////////////////////////////////////

            //nodelist.Add(new Node("QA US Benchmark 015 Existing DNT", "QA US Benchmark 015 Existing DNT Plan", "FundingValuations", "Valuation 2011", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 10, 20, "", sOutputFunding_US015_Valuation2011_Baseline, sOutputFunding_US015_Valuation2011_Baseline_bsl));
            //nodelist.Add(new Node("QA US Benchmark 008 Existing DNT", "QA US Benchmark 008 Existing DNT Plan", "FundingValuations", "Valuation 2012", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 20, 125, "", sOutputFunding_US008_Valuation2012_Baseline, sOutputFunding_US008_Valuation2012_Baseline_bsl));
            //nodelist.Add(new Node("QA US Benchmark 008 Existing DNT", "QA US Benchmark 008 Existing DNT Plan", "AccountingValuations", "FAS Val 2012", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 20, 125, "", sOutputAccounting_US008_FASVal2012_Baseline, sOutputAccounting_US008_FASVal2012_Baseline_bsl));
            //nodelist.Add(new Node("QA US Benchmark 010 Existing DNT", "QA US Benchmark 010 Existing DNT Plan", "FundingValuations", "July 2007 Valuation", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 30, 590, "", sOutputFunding_US010_July2007Valuation_Baseline, sOutputFunding_US010_July2007Valuation_Baseline_bsl));
            //nodelist.Add(new Node("QA US Benchmark 010 Existing DNT", "QA US Benchmark 010 Existing DNT Plan", "AccountingValuations", "July 2007 FAS Val", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 30, 590, "", sOutputAccounting_US010_July2007FASVal_Baseline, sOutputAccounting_US010_July2007FASVal_Baseline_bsl));
            //nodelist.Add(new Node("QA US Benchmark 007 Existing DNT", "QA US Benchmark 007 Existing DNT Plan", "FundingValuations", "Funding 2006", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 40, 1236, "", sOutputFunding_US007_Funding2006_Baseline, sOutputFunding_US007_Funding2006_Baseline_bsl));
            //nodelist.Add(new Node("QA US Benchmark 009 Existing DNT", "QA US Benchmark 009 Plan Existing DNT", "FundingValuations", "2006 Funding", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 50, 9554, "", sOutputFunding_US009_2006Funding_Baseline, sOutputFunding_US009_2006Funding_Baseline_bsl));
            //nodelist.Add(new Node("QA US Benchmark 019 Existing DNT", "QA US Benchmark 019 Existing DNT Plan", "FundingValuations", "1.1.2018 Funding Valuation", "Future Val Run", "", "", "3", "1", "Group Job Successfully Complete", 59, 80, "FV Liab", sOutputFunding_US019_112018FundingValuation_FutureValRun, sOutputFunding_US019_112018FundingValuation_FutureValRun_bsl));


            nodelist.Add(new Node("QA US Benchmark 015 Existing DNT Cloud", "QA US Benchmark 015 Existing DNT Plan", "FundingValuations", "Valuation 2011", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 10, 20, "", sOutputFunding_US015_Valuation2011_Baseline, sOutputFunding_US015_Valuation2011_Baseline_bsl));
            nodelist.Add(new Node("QA US Benchmark 008 Existing DNT Cloud", "QA US Benchmark 008 Existing DNT Plan", "FundingValuations", "Valuation 2012", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 20, 125, "", sOutputFunding_US008_Valuation2012_Baseline, sOutputFunding_US008_Valuation2012_Baseline_bsl));
            nodelist.Add(new Node("QA US Benchmark 008 Existing DNT Cloud", "QA US Benchmark 008 Existing DNT Plan", "AccountingValuations", "FAS Val 2012", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 20, 125, "", sOutputAccounting_US008_FASVal2012_Baseline, sOutputAccounting_US008_FASVal2012_Baseline_bsl));
            nodelist.Add(new Node("QA US Benchmark 010 Existing DNT Cloud", "QA US Benchmark 010 Existing DNT Plan", "FundingValuations", "July 2007 Valuation", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 30, 590, "", sOutputFunding_US010_July2007Valuation_Baseline, sOutputFunding_US010_July2007Valuation_Baseline_bsl));
            nodelist.Add(new Node("QA US Benchmark 010 Existing DNT Cloud", "QA US Benchmark 010 Existing DNT Plan", "AccountingValuations", "July 2007 FAS Val", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 30, 590, "", sOutputAccounting_US010_July2007FASVal_Baseline, sOutputAccounting_US010_July2007FASVal_Baseline_bsl));
            nodelist.Add(new Node("QA US Benchmark 007 Existing DNT Cloud", "QA US Benchmark 007 Existing DNT Plan", "FundingValuations", "Funding 2006", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 40, 1236, "", sOutputFunding_US007_Funding2006_Baseline, sOutputFunding_US007_Funding2006_Baseline_bsl));
            //nodelist.Add(new Node("QA US Benchmark 009 Existing DNT Cloud", "QA US Benchmark 009 Plan Existing DNT", "FundingValuations", "2006 Funding", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 50, 9554, "", sOutputFunding_US009_2006Funding_Baseline, sOutputFunding_US009_2006Funding_Baseline_bsl));
            nodelist.Add(new Node("QA US Benchmark 019 Existing DNT Cloud", "QA US Benchmark 019 Existing DNT Plan", "FundingValuations", "1.1.2018 Funding Valuation", "Future Val Run", "", "", "3", "1", "Group Job Successfully Complete", 59, 80, "FV Liab", sOutputFunding_US019_112018FundingValuation_FutureValRun, sOutputFunding_US019_112018FundingValuation_FutureValRun_bsl));
                       
     


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


                    Thread thrd_CompareRPT = new Thread(() => new US_Rollforward().t_CompareRpt(node));
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
