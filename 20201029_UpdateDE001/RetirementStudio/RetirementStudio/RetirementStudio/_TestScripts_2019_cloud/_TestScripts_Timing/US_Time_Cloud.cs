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


namespace RetirementStudio._TestScripts_2019_cloud._TestScripts_Timing
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class US_Time_Cloud
    {
        public US_Time_Cloud()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            ////Config.sStudioLaunchDir = @"C:\Users\webber-ling\Desktop\QA1_20181211.1\Client\RetirementStudio.exe";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
        }


        #region Report Output Directory

        public string sOutputFunding_US008_Valuation2013_Baseline = "";
        public string sOutputFunding_US015_Valuation2011_Baseline = "";
        public string sOutputFunding_USPerformance_Funding2013_Baseline = "";

        public void GenerateReportOuputDir()
        {
            _BenchmarkUser sCurrentUser = _gLib._ReturnCurrentUser();
            if (sCurrentUser.ToString() == "Others")
            {
                _gLib._MsgBox("Warning !!!", "Your are NOT allowed to create folders in \\mercer.com\\US_Data\\Shared\\Dfl\\Data1\\RSS\\SQA drive, Please contact Cindy or Webber if you have to!");
                Environment.Exit(0);
            }
            else
            {
                string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString() + "_CloudPerformance";

                sOutputFunding_US008_Valuation2013_Baseline = _gLib._CreateDirectory(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\QA_BM_008_PAUL_SCHERER\" + sPostFix + "\\");
                sOutputFunding_US015_Valuation2011_Baseline = _gLib._CreateDirectory(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\QA_BM_015_FutVal\" + sPostFix + "\\");
                sOutputFunding_USPerformance_Funding2013_Baseline = _gLib._CreateDirectory(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Cloud\US_Performance_Test_2019_Big_F\" + sPostFix + "\\");
            }
            
            string sContent = "";
            sContent = sContent + "sOutputFunding_US008_Valuation2013_Baseline = @\"" + sOutputFunding_US008_Valuation2013_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_US015_Valuation2011_Baseline = @\"" + sOutputFunding_US015_Valuation2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_USPerformance_Funding2013_Baseline = @\"" + sOutputFunding_USPerformance_Funding2013_Baseline + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);
        }

        #endregion


        #region DB connection
        

        static string sql_connectionString = @"Data Source=usdfw14db36\dev_16CI1;Initial Catalog=RSRegional;;User ID=rs;Password=rspwd";
        SqlConnection sql_conn = new SqlConnection(sql_connectionString);


        /// <summary>
        ///              _gLib._MsgBoxYesNo("Congratulations!", this._ReturnCores("211800"));
        /// </summary>
        /// <param name="sID"></param>
        /// <returns></returns>
        public string _ReturnCores(string sID)
        {
            string sql_Query = "select count(*) from computeclusterjobtask where jobid = " + sID;
            SqlCommand sql_command = new SqlCommand(sql_Query, sql_conn);
            sql_conn.Open();
            SqlDataReader sql_reader = sql_command.ExecuteReader();

            int iCoreNum = 0;
            while (sql_reader.Read())
            {
                iCoreNum = sql_reader.GetInt32(0);
                /////////_gLib._MsgBox("Congratulations!", iCoreNum.ToString());

            }
            sql_reader.Close();

            sql_conn.Close();

            return iCoreNum.ToString();
        }

        #endregion

        #region Timing
        
        static string sCol_Time = "Time1";
        static string sCol_Memory = "Memory1";
        static string sLogFile = @"C:\Users\webber-ling\Desktop\_RTS\RetirementStudio\US_Timing_Test_Cloud.xls";
        MyTimer mTime = new MyTimer(sCol_Time, sLogFile);
        MyLog mLog = new MyLog(sCol_Memory, sLogFile);
        MyLog mLogTime = new MyLog(sCol_Time, sLogFile);

        MyDictionary dicPosition = new MyDictionary();
        string sERDetail = "";


        #region Result Index

        //static int iJobID_Baseline = 125;
        //static int iJobID_ACLSConvFact425600675 = iJobID_Baseline + 1;


        static int iTimeStart = 2;
        static int iTimeEnd = iTimeStart + 1;
   

        #endregion
        
        #endregion


        #region NodeClass

        public class Node: IComparable<Node>
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

            public Node(string _client, string _plan, string _valuation, string _service, string _node, string _maxrownum, string _maxcolnum, string _rownum, string _colnum, string _runstatus, int _recordcount, int _filenoderow, string _runtype)
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


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_US_Time_Cloud()
        {

            pMain._SetLanguageAndRegional(); /// has to be under United States
             
            /* control whether including - Run ER, Complete status log, download report, big data client */
            Boolean bRunER = true;
            Boolean bRunCompleteLog = true;
            Boolean bDownloadReport = false;
            Boolean bAddBigData = false;

            /* get the column number of "Memory1", for time cal*/
            //int iCol_Memory;
            //MyExcel _excelLog = new MyExcel(sLogFile, true);
            //_excelLog.OpenExcelFile("Sheet1");
            //iCol_Memory = _excelLog.getColumnIndex(sCol_Memory);
            //_excelLog.CloseExcelApplication();


            






            #region nodeList

            List<Node> nodelist = new List<Node>();


            //////////// --------------------------------------------------------    Load   -------------------------------------------------------- ///////////
            ///////////////////////// ------  DevCurrent Conversion ---------- /////////////////////////////////////
            //nodelist.Add(new Node("QA US Benchmark 009 Existing DNT_50000", "QA US Benchmark 009 Plan Existing DNT", "FundingValuations", "2005 Funding", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 50000, 173, ""));
            //nodelist.Add(new Node("QA US Benchmark 015 Existing DNT", "QA US Benchmark 015 Existing DNT Plan", "FundingValuations", "Conversion 2010", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 20, 53, ""));
            //nodelist.Add(new Node("QA US Benchmark 008 Existing DNT", "QA US Benchmark 008 Existing DNT Plan", "FundingValuations", "Conversion 2011", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 125, 18, ""));
            //nodelist.Add(new Node("QA US Benchmark 010 Existing DNT", "QA US Benchmark 010 Existing DNT Plan", "FundingValuations", "July 2006 Valuation", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 590, 32, ""));
            //nodelist.Add(new Node("QA US Benchmark 007 Existing DNT", "QA US Benchmark 007 Existing DNT Plan", "FundingValuations", "Funding 2005", "Baseline", "", "", "1", "1", "Group Job Successfully Complete with 2 NP", 1236, 4, ""));
            //nodelist.Add(new Node("QA US Benchmark 009 Existing DNT", "QA US Benchmark 009 Plan Existing DNT", "FundingValuations", "2005 Funding", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 9554, 25, ""));


            /////////////////////////// ------  DevCurrent Rollforward & FV ---------- /////////////////////////////////////
            //nodelist.Add(new Node("QA US Benchmark 009 Existing DNT_50000", "QA US Benchmark 009 Plan Existing DNT", "FundingValuations", "2006 Funding", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 50000, 173, ""));
            //nodelist.Add(new Node("QA US Benchmark 015 Existing DNT", "QA US Benchmark 015 Existing DNT Plan", "FundingValuations", "Valuation 2011", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 20, 53, ""));
            //nodelist.Add(new Node("QA US Benchmark 008 Existing DNT", "QA US Benchmark 008 Existing DNT Plan", "FundingValuations", "Valuation 2012", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 125, 18, ""));
            //nodelist.Add(new Node("QA US Benchmark 010 Existing DNT", "QA US Benchmark 010 Existing DNT Plan", "FundingValuations", "July 2007 Valuation", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 590, 32, ""));
            //nodelist.Add(new Node("QA US Benchmark 007 Existing DNT", "QA US Benchmark 007 Existing DNT Plan", "FundingValuations", "Funding 2006", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 1236, 4, ""));
            //nodelist.Add(new Node("QA US Benchmark 009 Existing DNT", "QA US Benchmark 009 Plan Existing DNT", "FundingValuations", "2006 Funding", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 9554, 25, ""));

            //nodelist.Add(new Node("QA US Benchmark 015 Existing DNT", "QA US Benchmark 015 Existing DNT Plan", "FundingValuations", "Valuation 2011", "Baseline", "", "2", "3", "1", "Group Job Successfully Complete", 20, 145, "FV Proj"));
            //nodelist.Add(new Node("QA US Benchmark 015 Existing DNT", "QA US Benchmark 015 Existing DNT Plan", "FundingValuations", "Valuation 2011", "Baseline", "", "2", "3", "2", "Group Job Successfully Complete", 20, 152, "FV Liab"));
            //nodelist.Add(new Node("QA US Benchmark 019 Existing DNT", "QA US Benchmark 019 Existing DNT Plan", "FundingValuations", "1.1.2017 Funding Valuation", "Baseline", "", "0", "1", "1", "Group Job Successfully Complete", 784, 159, "FV Proj"));
            //nodelist.Add(new Node("QA US Benchmark 019 Existing DNT", "QA US Benchmark 019 Existing DNT Plan", "FundingValuations", "1.1.2018 Funding Valuation", "Future Val Run", "", "0", "3", "1", "Group Job Successfully Complete", 784, 166, "FV Liab"));





            //////////// --------------------------------------------------------    Performance  -------------------------------------------------------- ///////////


            ///////////////////////// ------  DevCurrent Rollforward & FV ---------- /////////////////////////////////////
            nodelist.Add(new Node("QA US Benchmark 015 Existing DNT", "QA US Benchmark 015 Existing DNT Plan", "FundingValuations", "Valuation 2011", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 20, 53, ""));
            //nodelist.Add(new Node("QA US Benchmark 008 Existing DNT", "QA US Benchmark 008 Existing DNT Plan", "FundingValuations", "Valuation 2012", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 125, 18, ""));
            //nodelist.Add(new Node("QA US Benchmark 010 Existing DNT", "QA US Benchmark 010 Existing DNT Plan", "FundingValuations", "July 2007 Valuation", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 590, 32, ""));
            //nodelist.Add(new Node("QA US Benchmark 007 Existing DNT", "QA US Benchmark 007 Existing DNT Plan", "FundingValuations", "Funding 2006", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 1236, 4, ""));
            //nodelist.Add(new Node("QA US Benchmark 009 Existing DNT", "QA US Benchmark 009 Plan Existing DNT", "FundingValuations", "2006 Funding", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 9554, 25, ""));

            //nodelist.Add(new Node("QA US Benchmark 015 Existing DNT", "QA US Benchmark 015 Existing DNT Plan", "FundingValuations", "Valuation 2011", "Baseline", "", "2", "3", "1", "Group Job Successfully Complete", 20, 145, "FV Proj"));
            //nodelist.Add(new Node("QA US Benchmark 015 Existing DNT", "QA US Benchmark 015 Existing DNT Plan", "FundingValuations", "Valuation 2011", "Baseline", "", "2", "3", "2", "Group Job Successfully Complete", 20, 152, "FV Liab"));
            //nodelist.Add(new Node("QA US Benchmark 019 Existing DNT", "QA US Benchmark 019 Existing DNT Plan", "FundingValuations", "1.1.2017 Funding Valuation", "Baseline", "", "0", "1", "1", "Group Job Successfully Complete", 784, 159, "FV Proj"));
            //nodelist.Add(new Node("QA US Benchmark 019 Existing DNT", "QA US Benchmark 019 Existing DNT Plan", "FundingValuations", "1.1.2018 Funding Valuation", "Future Val Run", "", "0", "3", "1", "Group Job Successfully Complete", 784, 166, "FV Liab"));



            ///////////////////////// ------  DevCurrent Conversion ---------- /////////////////////////////////////
            //nodelist.Add(new Node("QA US Benchmark 015 Existing DNT", "QA US Benchmark 015 Existing DNT Plan", "FundingValuations", "Conversion 2010", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 20, 53, ""));
            //nodelist.Add(new Node("QA US Benchmark 008 Existing DNT", "QA US Benchmark 008 Existing DNT Plan", "FundingValuations", "Conversion 2011", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 125, 18, ""));
            //nodelist.Add(new Node("QA US Benchmark 010 Existing DNT", "QA US Benchmark 010 Existing DNT Plan", "FundingValuations", "July 2006 Valuation", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 590, 32, ""));
            //nodelist.Add(new Node("QA US Benchmark 007 Existing DNT", "QA US Benchmark 007 Existing DNT Plan", "FundingValuations", "Funding 2005", "Baseline", "", "", "1", "1", "Group Job Successfully Complete with 2 NP", 1236, 4, ""));
            //nodelist.Add(new Node("QA US Benchmark 009 Existing DNT", "QA US Benchmark 009 Plan Existing DNT", "FundingValuations", "2005 Funding", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 9554, 25, ""));




            #region   clients in QA1

            //if (bAddBigData == true)
            //{
            //    nodelist.Add(new Node("US_Performance_Test_2019_Big_F", "US_Performance_Test_2019_Big_F Plan", "FundingValuations", "Funding 1.1.2013", "Baseline", "", "", "2", "1", "Group Job Successfully Complete with 1 NP", 56852, 81, ""));
            //    nodelist.Add(new Node("US_Performance_Test_2019_Big_F", "US_Performance_Test_2019_Big_F Plan", "FundingValuations", "Funding 1.1.2013", "NewVal1", "", "", "3", "1", "Group Job Successfully Complete with 10 NP", 56852, 88, ""));
            //    nodelist.Add(new Node("US_Performance_Test_2019_Big_F", "US_Performance_Test_2019_Big_F Plan", "FundingValuations", "Funding 1.1.2013", "NewVal2", "", "", "3", "2", "Group Job Successfully Complete with 10 NP", 56852, 95, ""));
            //}


            //nodelist.Add(new Node("QA US Benchmark 007 Cloud", "QA US Benchmark 007 Cloud Plan", "FundingValuations", "Funding 2006", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 1236, 4, ""));
            //nodelist.Add(new Node("QA US Benchmark 007 Cloud", "QA US Benchmark 007 Cloud Plan", "AccountingValuations", "2005 Accounting", "Baseline", "", "", "1", "1", "Group Job Successfully Complete with 2 NP", 1236, 11, ""));
            //nodelist.Add(new Node("QA US Benchmark 008 Cloud", "QA US Benchmark 008 Cloud Plan", "FundingValuations", "Valuation 2013", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 132, 18, ""));

            //nodelist.Add(new Node("QA US Benchmark 009 Existing DNT", "QA US Benchmark 009 Plan Existing DNT", "FundingValuations", "2006 Funding", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 9554, 25, ""));

            //nodelist.Add(new Node("QA US Benchmark 010 Cloud", "QA US Benchmark 010 Cloud Plan", "FundingValuations", "July 2007 Valuation", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 616, 32, ""));
            //nodelist.Add(new Node("QA US Benchmark 011 Cloud", "QA US Benchmark 011 Cloud Plan", "FundingValuations", "val 7.1.2019", "Baseline", "", "", "2", "1", "Group Job Successfully Complete with 10 NP", 719, 39, ""));

            //nodelist.Add(new Node("QA US Benchmark 014 Cloud", "QA US Benchmark 014 Cloud Plan", "FundingValuations", "Conversion", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 450, 46, ""));

            //nodelist.Add(new Node("QA US Benchmark 015 Cloud", "QA US Benchmark 015 Cloud Plan", "FundingValuations", "Valuation 2011", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 20, 53, "Reg"));

            //nodelist.Add(new Node("QA US Benchmark 016 Existing DNT", "QA US Benchmark 016 Existing DNT Plan", "FundingValuations", "Val 2014", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 132, 60, ""));

            //nodelist.Add(new Node("QA US Benchmark 017 Cloud", "QA US Benchmark 017 Cloud Plan", "FundingValuations", "NDT 2017", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 473, 67, ""));
            //nodelist.Add(new Node("QA US Benchmark 017 Cloud", "QA US Benchmark 017 Cloud Plan 2", "FundingValuations", "NDT 2016 EOY and 2017", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 719, 74, ""));

            #endregion

            #endregion





            mLog.LogInfo(iTimeStart, DateTime.Now.ToString());


            #region ER Run

            _gLib._KillProcessByName("Mercer.RetirementStudio.Messaging.MessagingClientApp");

            if (bRunER == true)
            {
                foreach (Node node in nodelist)
                {
                    string sER_ClickRun_Time = null;

                    int iBaseline_ER_RunSubmitted = node.iFileNodeRow;
                    int iBaseline_ER_ClickRun = iBaseline_ER_RunSubmitted + 1;

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
                    else if (node.sPlanName == "QA US Benchmark 017 Cloud Plan" & node.sServiceName == "NDT 2017")
                    {
                        dic.Clear();
                        dic.Add("iMaxRowNum", "");
                        dic.Add("iMaxColNum", "");
                        dic.Add("iSelectRowNum", "");
                        dic.Add("iSelectColNum", "");
                        dic.Add("iPosX", "245");
                        dic.Add("iPosY", "90");
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


                    //mTime.StartTimer();

                    //mLog.LogInfo(iBaseline_ER_ClickRun, DateTime.Now.ToString());



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


                    mTime.StartTimer();

                    sER_ClickRun_Time = DateTime.Now.ToString();
                    //node.setClickRunTime(sER_ClickRun_Time);
                    mLog.LogInfo(iBaseline_ER_ClickRun, sER_ClickRun_Time);

                    if (node.sRunType == "FV Proj")
                    {   }
                    else
                    {
                        dic.Clear();
                        dic.Add("PopVerify", "Pop");
                        dic.Add("OK", "Click");
                        pMain._PopVerify_EnterpriseRunSubmitted(dic);
                    }

                    mTime.StopTimer(iBaseline_ER_RunSubmitted);

                    pMain._SelectTab(node.sServiceName);
                    pMain._Home_ToolbarClick_Top(false);


                    //////////Trace.WriteLine(node.sNodeName + "is finished");

                }
            }

            #endregion


            #region ER complete

            if (bRunCompleteLog == true)
            {
                nodelist.Sort();

                foreach (Node node in nodelist)
                {

                    int iBaseline_ER_ClickRun = node.iFileNodeRow + 1;
                    int iBaseline_ER_GroupID = iBaseline_ER_ClickRun + 1;
                    int iBaseline_ER_Persist = iBaseline_ER_GroupID + 1;
                    int iBaseline_ER_Post = iBaseline_ER_Persist + 1;
                    int iBaseline_ER_Detail = iBaseline_ER_Post + 1;
                    int iBaseline_NumOfCores = iBaseline_ER_Detail + 1;

                    
                    int iCol_Memory;
                    string _sER_ReturnRunStatus_ClickRun = null;
                    MyExcel _excelLog = new MyExcel(sLogFile, true);
                    _excelLog.OpenExcelFile("Sheet1");
                    iCol_Memory = _excelLog.getColumnIndex(sCol_Memory);
                    _sER_ReturnRunStatus_ClickRun = _excelLog.getOneCellValue(iBaseline_ER_ClickRun, iCol_Memory);
                    _excelLog.CloseExcelApplication();
                    DateTime _tER_ReturnRunStatus_ClickRun = Convert.ToDateTime(_sER_ReturnRunStatus_ClickRun);


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

                    if (node.sPlanName == "QA US Benchmark 017 Cloud Plan" & node.sServiceName == "NDT 2017")
                    {
                        dic.Clear();
                        dic.Add("iMaxRowNum", node.sMaxRowNum);
                        dic.Add("iMaxColNum", node.sMaxColNum);
                        dic.Add("iSelectRowNum", "");
                        dic.Add("iSelectColNum", "");
                        dic.Add("iPosX", "245");
                        dic.Add("iPosY", "90");
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


                    string _sER_ReturnRunStatus_BottomGrid_Persist = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5);
                    string _sER_ReturnRunStatus_BottomGrid_Post = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5);
                    DateTime _tER_ReturnRunStatus_BottomGrid_Persist = Convert.ToDateTime(_sER_ReturnRunStatus_BottomGrid_Persist);
                    DateTime _tER_ReturnRunStatus_BottomGrid_Post = Convert.ToDateTime(_sER_ReturnRunStatus_BottomGrid_Post);

                    string _sER_ReturnRunStatus_BottomGrid_JobSent = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5);
                    string _sER_ReturnRunStatus_BottomGrid_JobStatus;
                    if (node.sRunType == "FV Proj")
                    {
                        _sER_ReturnRunStatus_BottomGrid_JobStatus = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12);
                    }
                    else
                    {
                        _sER_ReturnRunStatus_BottomGrid_JobStatus = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 12);
                    }
                    string _sER_ReturnRunStatus_BottomGrid_GroupJobStatus = pMain._ER_ReturnRunStatus_TopGrid(11);
                    DateTime _tER_ReturnRunStatus_BottomGrid_JobSent = Convert.ToDateTime(_sER_ReturnRunStatus_BottomGrid_JobSent);
                    DateTime _tER_ReturnRunStatus_BottomGrid_JobStatus = Convert.ToDateTime(_sER_ReturnRunStatus_BottomGrid_JobStatus);
                    DateTime _tER_ReturnRunStatus_BottomGrid_GroupJobStatus = Convert.ToDateTime(_sER_ReturnRunStatus_BottomGrid_GroupJobStatus);



                    mLog.LogInfo(iBaseline_ER_GroupID, pMain._ER_ReturnRunStatus_TopGrid(2));
                    //mLog.LogInfo(iBaseline_ER_Persist, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
                    //mLog.LogInfo(iBaseline_ER_Post, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));
                    mLog.LogInfo(iBaseline_ER_Persist, _sER_ReturnRunStatus_BottomGrid_Persist);
                    mLog.LogInfo(iBaseline_ER_Post, _sER_ReturnRunStatus_BottomGrid_Post);


                    sERDetail = "";
                    //sERDetail = sERDetail + "Earliest Process: " + pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5) + Environment.NewLine;
                    //sERDetail = sERDetail + "Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 12) + Environment.NewLine;
                    //sERDetail = sERDetail + "Group Job Success: " + pMain._ER_ReturnRunStatus_TopGrid(11) + Environment.NewLine;
                    sERDetail = sERDetail + "Earliest Process: " + _sER_ReturnRunStatus_BottomGrid_JobSent + Environment.NewLine;
                    sERDetail = sERDetail + "Job Success: " + _sER_ReturnRunStatus_BottomGrid_JobStatus + Environment.NewLine;
                    sERDetail = sERDetail + "Group Job Success: " + _sER_ReturnRunStatus_BottomGrid_GroupJobStatus + Environment.NewLine;
                    mLog.LogInfo(iBaseline_ER_Detail, sERDetail);

                    sERDetail = "";
                    //sERDetail = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3) + ": ";
                    sERDetail = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3);
                    mLog.LogInfo(iBaseline_NumOfCores, sERDetail);


                    TimeSpan _tPersist = _tER_ReturnRunStatus_BottomGrid_Post - _tER_ReturnRunStatus_BottomGrid_Persist;
                    TimeSpan _tPost = _tER_ReturnRunStatus_BottomGrid_JobStatus - _tER_ReturnRunStatus_BottomGrid_Post;

                    TimeSpan _tJobSent_Persist = _tER_ReturnRunStatus_BottomGrid_Persist - _tER_ReturnRunStatus_BottomGrid_JobSent;
                    TimeSpan _tClickRun_GroupJobStatus = _tER_ReturnRunStatus_BottomGrid_GroupJobStatus - _tER_ReturnRunStatus_ClickRun;
                    int _tOverall = (_tClickRun_GroupJobStatus.Hours * 3600 + _tClickRun_GroupJobStatus.Minutes * 60 + _tClickRun_GroupJobStatus.Seconds) - (_tJobSent_Persist.Hours * 3600 + _tJobSent_Persist.Minutes * 60 + _tJobSent_Persist.Seconds);

                    mLogTime.LogInfo(iBaseline_ER_Persist, Convert.ToString(_tPersist.Hours * 3600 + _tPersist.Minutes * 60 + _tPersist.Seconds));
                    mLogTime.LogInfo(iBaseline_ER_Post, Convert.ToString(_tPost.Hours * 3600 + _tPost.Minutes * 60 + _tPost.Seconds));
                    mLogTime.LogInfo(iBaseline_ER_ClickRun, Convert.ToString(_tOverall));

                    mLogTime.LogInfo(iBaseline_NumOfCores, this._ReturnCores(sERDetail));
                    

                    //mLog.LogInfo(iJobID_Baseline, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));

                    pMain._SelectTab(node.sServiceName);
                    pMain._Home_ToolbarClick_Top(false);

                }
            }
                        
            #endregion


            mLog.LogInfo(iTimeEnd, DateTime.Now.ToString());


            #region Download Report

            if (bDownloadReport == true)
            {

                this.GenerateReportOuputDir();


                #region US008 – Valuation 2013 – Baseline

                int iUS008_Export_ReconciliationtoPriorYear = 102;
                int iUS008_Export_ReconciliationToPriorYearByPlanDef = iUS008_Export_ReconciliationtoPriorYear + 1;
                int iUS008_Export_DetailedResults = iUS008_Export_ReconciliationToPriorYearByPlanDef + 1;
                int iUS008_Export_DetailedResultsbyPlanDef = iUS008_Export_DetailedResults + 1;

                int iUS008_Export_StatusReconciliation = iUS008_Export_DetailedResultsbyPlanDef + 1;
                int iUS008_Export_MemberStatistics = iUS008_Export_StatusReconciliation + 1;
                int iUS008_Export_IndividualCheckingTemplate = iUS008_Export_MemberStatistics + 1;
                int iUS008_Export_AgeServiceMatrix = iUS008_Export_IndividualCheckingTemplate + 1;
                int iUS008_Export_DataComparison = iUS008_Export_AgeServiceMatrix + 1;

                int iUS008_Export_DataMatchingSummary = iUS008_Export_DataComparison + 1;
                int iUS008_Export_CombinedStatusCodeSummary = iUS008_Export_DataMatchingSummary + 1;
                int iUS008_Export_GainLossStatusReconciliation = iUS008_Export_CombinedStatusCodeSummary + 1;
                int iUS008_Export_GainLossSummaryofLiabilityReconciliation = iUS008_Export_GainLossStatusReconciliation + 1;
                int iUS008_Export_ActiveDecrementGainLossDetail = iUS008_Export_GainLossSummaryofLiabilityReconciliation + 1;
                int iUS008_Export_DecrementAge = iUS008_Export_ActiveDecrementGainLossDetail + 1;
                int iUS008_Export_GainLossParticipantListing = iUS008_Export_DecrementAge + 1;
                int iUS008_Export_LiabilityComparison = iUS008_Export_GainLossParticipantListing + 1;

                int iUS008_Export_LiabilityScenario = iUS008_Export_LiabilityComparison + 1;
                int iUS008_Export_LiabilityScenariobyPlanDef = iUS008_Export_LiabilityScenario + 1;

                int iUS008_Export_ValuationSummary = iUS008_Export_LiabilityScenariobyPlanDef + 1;
                int iUS008_Export_IOE = iUS008_Export_ValuationSummary + 1;
                int iUS008_Export_IndividualOutput = iUS008_Export_IOE + 1;
                int iUS008_Export_Parameter = iUS008_Export_IndividualOutput + 1;
                int iUS008_Export_TestCases = iUS008_Export_Parameter + 1;
                int iUS008_Export_PayoutProjection = iUS008_Export_TestCases + 1;
                int iUS008_Export_AgeServiceMatrix_2 = iUS008_Export_PayoutProjection + 1;
                int iUS008_Export_LiabilitySetforFSMExport = iUS008_Export_AgeServiceMatrix_2 + 1;

                pMain._SelectTab("Home");

                dic.Clear();
                dic.Add("Country", Config.eCountry.ToString());
                dic.Add("Level_1", "QA US Benchmark 008 Cloud");
                dic.Add("Level_2", "QA US Benchmark 008 Cloud Plan");
                dic.Add("Level_3", "FundingValuations");
                pMain._HomeTreeViewSelect_Favorites(0, dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("AddServiceInstance", "");
                dic.Add("ServiceToOpen", "Valuation 2013");
                pMain._PopVerify_Home_RightPane(dic);

                pMain._SelectTab("Valuation 2013");

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "2");
                dic.Add("iSelectColNum", "1");
                dic.Add("MenuItem_1", "View Output");
                pMain._FlowTreeRightSelect(dic);

                pMain._SelectTab("Output Manager");

                mTime.StartTimer();
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
                mTime.StopTimer(iUS008_Export_ReconciliationtoPriorYear);

                mTime.StartTimer();
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                mTime.StopTimer(iUS008_Export_ReconciliationToPriorYearByPlanDef);

                mTime.StartTimer();
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Detailed Results", "RollForward", true, true);
                mTime.StopTimer(iUS008_Export_DetailedResults);

                mTime.StartTimer();
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
                mTime.StopTimer(iUS008_Export_DetailedResultsbyPlanDef);

                mTime.StartTimer();
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Status Reconciliation", "RollForward", true, true);
                mTime.StopTimer(iUS008_Export_StatusReconciliation);

                mTime.StartTimer();
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Member Statistics", "RollForward", true, true);
                mTime.StopTimer(iUS008_Export_MemberStatistics);

                mTime.StartTimer();
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Individual Checking Template", "RollForward", true, true);
                mTime.StopTimer(iUS008_Export_IndividualCheckingTemplate);

                mTime.StartTimer();
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Age Service Matrix", "RollForward", true, true);
                mTime.StopTimer(iUS008_Export_AgeServiceMatrix);

                mTime.StartTimer();
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Data Comparison", "RollForward", false, true);
                mTime.StopTimer(iUS008_Export_DataComparison);

                mTime.StartTimer();
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Data Matching Summary", "RollForward", true, true);
                mTime.StopTimer(iUS008_Export_DataMatchingSummary);

                mTime.StartTimer();
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Combined Status Code Summary", "RollForward", true, true);
                mTime.StopTimer(iUS008_Export_CombinedStatusCodeSummary);

                mTime.StartTimer();
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Gain / Loss Status Reconciliation", "RollForward", true, true);
                mTime.StopTimer(iUS008_Export_GainLossStatusReconciliation);

                mTime.StartTimer();
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, true);
                mTime.StopTimer(iUS008_Export_GainLossSummaryofLiabilityReconciliation);

                mTime.StartTimer();
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", true, true);
                mTime.StopTimer(iUS008_Export_ActiveDecrementGainLossDetail);

                mTime.StartTimer();
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Decrement Age", "RollForward", true, true);
                mTime.StopTimer(iUS008_Export_DecrementAge);

                mTime.StartTimer();
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
                mTime.StopTimer(iUS008_Export_GainLossParticipantListing);

                mTime.StartTimer();
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Liability Comparison", "RollForward", false, true);
                mTime.StopTimer(iUS008_Export_LiabilityComparison);

                mTime.StartTimer();
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Liability Scenario", "RollForward", true, true);
                mTime.StopTimer(iUS008_Export_LiabilityScenario);

                mTime.StartTimer();
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Liability Scenario by Plan Def", "RollForward", false, true);
                mTime.StopTimer(iUS008_Export_LiabilityScenariobyPlanDef);

                mTime.StartTimer();
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Valuation Summary", "RollForward", true, true);
                mTime.StopTimer(iUS008_Export_ValuationSummary);

                #region IOE

                pMain._SelectTab("Output Manager");
                pOutputManager._Navigate(Config.eCountry, "IOE", "RollForward", true);
                pOutputManager._SelectTab("Individual Output");
                _gLib._SetSyncUDWin("Group - None", pOutputManager.wRetirementStudio.wGroup_None.rdNone, "True", 0);
                _gLib._SetSyncUDWin("Process", pOutputManager.wRetirementStudio.wProcess.btnProcess, "Click", 0);

                if (_gLib._Exists("NewIOEParameters1", pOutputManager.wRetirementStudio.tvNaviTree.tviIndividualOutput.tviNewIOEParameters1, Config.iTimeout / 30, false))
                {
                    _gLib._SetSyncUDWin("NewIOEParameters1", pOutputManager.wRetirementStudio.tvNaviTree.tviIndividualOutput.tviNewIOEParameters1, "Click", 0);
                }
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

                _gLib._SetSyncUDWin("wVerticalScrollBar", pOutputManager.wRetirementStudio.wVerticalScrollBar.pagedownButton, "Click", Config.iTimeout / 3, false, 6, 50);

                mTime.StartTimer();

                _gLib._SetSyncUDWin("Export", pOutputManager.wRetirementStudio.wExport.btnExport, "Click", 0);
                pOutputManager._SaveAs(sOutputFunding_US008_Valuation2013_Baseline + "IOE.xlsx");
                _gLib._SetSyncUDWin("OK", pOutputManager.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);

                pOutputManager._SelectTab("Individual Output");
                mTime.StopTimer(iUS008_Export_IOE);

                #endregion

                mTime.StartTimer();
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Individual Output", "RollForward", true, true);
                mTime.StopTimer(iUS008_Export_IndividualOutput);

                mTime.StartTimer();
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Parameter Print", "RollForward", true, true);
                mTime.StopTimer(iUS008_Export_Parameter);

                mTime.StartTimer();
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Test Cases", "RollForward", true, true);
                mTime.StopTimer(iUS008_Export_TestCases);

                mTime.StartTimer();
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Payout Projection", "RollForward", true, true);
                mTime.StopTimer(iUS008_Export_PayoutProjection);

                mTime.StartTimer();
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Age Service Matrix", "RollForward", true, true);
                mTime.StopTimer(iUS008_Export_AgeServiceMatrix_2);

                mTime.StartTimer();
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_US008_Valuation2013_Baseline, "Liability Set for FSM Export", "RollForward", true, false);
                mTime.StopTimer(iUS008_Export_LiabilitySetforFSMExport);


                pMain._Home_ToolbarClick_Top(true);
                pMain._SelectTab("Valuation 2013");
                pMain._Home_ToolbarClick_Top(false);

                #endregion



                #region US015 – Valuation 2011 – Baseline (FV Population Projection, FV Summary, FV Individual Output, FV Summary, FV Payouts, FV Liabilities by Group/Year)


                int iUS015_Export_FutureValuationPopulationProjection = 129;
                int iUS015_Export_FutureValuationSummary = iUS015_Export_FutureValuationPopulationProjection + 1;
                int iUS015_Export_FutureValuationIOE = iUS015_Export_FutureValuationSummary + 1;
                int iUS015_Export_FutureValuationParameterPrint = iUS015_Export_FutureValuationIOE + 1;
                int iUS015_Export_FutureValuationLiabilitiesbyGroup = iUS015_Export_FutureValuationParameterPrint + 1;
                int iUS015_Export_FutureValuationLiabilitiesbyYear = iUS015_Export_FutureValuationLiabilitiesbyGroup + 1;
                int iUS015_Export_FutureValuationPayouts = iUS015_Export_FutureValuationLiabilitiesbyYear + 1;

                pMain._SelectTab("Home");

                dic.Clear();
                dic.Add("Country", Config.eCountry.ToString());
                dic.Add("Level_1", "QA US Benchmark 015 Cloud");
                dic.Add("Level_2", "QA US Benchmark 015 Cloud Plan");
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
                dic.Add("iSelectRowNum", "2");
                dic.Add("iSelectColNum", "1");
                dic.Add("MenuItem_1", "View Output");
                pMain._FlowTreeRightSelect(dic);

                pMain._SelectTab("Output Manager");


                mTime.StartTimer();
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_US015_Valuation2011_Baseline, "Future Valuation Population Projection", "RollForward", true, true);
                mTime.StopTimer(iUS015_Export_FutureValuationPopulationProjection);

                mTime.StartTimer();
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_US015_Valuation2011_Baseline, "Future Valuation Summary", "RollForward", true, true);
                mTime.StopTimer(iUS015_Export_FutureValuationSummary);

                mTime.StartTimer();
                pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_US015_Valuation2011_Baseline, "Future Valuation Individual Output", "RollForward", true, true);
                mTime.StopTimer(iUS015_Export_FutureValuationIOE);
                
                mTime.StartTimer();
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_US015_Valuation2011_Baseline, "Future Valuation Parameter Print", "RollForward", true, true);
                mTime.StopTimer(iUS015_Export_FutureValuationParameterPrint);

                mTime.StartTimer();
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_US015_Valuation2011_Baseline, "Future Valuation Liabilities by Group", "RollForward", true, true);
                mTime.StopTimer(iUS015_Export_FutureValuationLiabilitiesbyGroup);

                mTime.StartTimer();
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_US015_Valuation2011_Baseline, "Future Valuation Liabilities by Year", "RollForward", true, true);
                mTime.StopTimer(iUS015_Export_FutureValuationLiabilitiesbyYear);

                mTime.StartTimer();
                pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputFunding_US015_Valuation2011_Baseline, "RollForward", true, true);
                mTime.StopTimer(iUS015_Export_FutureValuationPayouts);


                pMain._Home_ToolbarClick_Top(true);
                pMain._SelectTab("Valuation 2011");
                pMain._Home_ToolbarClick_Top(false);

                #endregion

                

                #region US_Performance_Test_2019_Big_F – Funding 1.1.2013 – Baseline (Gail / Loss Participant Listing, Valuation Summary, IOE)


                if (bAddBigData == true)
                {

                    int iUSPerformance_Export_DataMatchingSummary = 135;
                    int iUSPerformance_Export_CombinedStatusCodeSummary = iUSPerformance_Export_DataMatchingSummary + 1;
                    int iUSPerformance_Export_GainLossStatusReconciliation = iUSPerformance_Export_CombinedStatusCodeSummary + 1;
                    int iUSPerformance_Export_GainLossSummaryofLiabilityReconciliation = iUSPerformance_Export_GainLossStatusReconciliation + 1;
                    int iUSPerformance_Export_ActiveDecrementGainLossDetail = iUSPerformance_Export_GainLossSummaryofLiabilityReconciliation + 1;
                    int iUSPerformance_Export_DecrementAge = iUSPerformance_Export_ActiveDecrementGainLossDetail + 1;
                    int iUSPerformance_Export_GainLossParticipantListing = iUSPerformance_Export_DecrementAge + 1;
                    int iUSPerformance_Export_ValuationSummary = iUSPerformance_Export_GainLossParticipantListing + 1;
                    int iUSPerformance_Export_IOE = iUSPerformance_Export_ValuationSummary + 1;

                    pMain._SelectTab("Home");

                    dic.Clear();
                    dic.Add("Country", Config.eCountry.ToString());
                    dic.Add("Level_1", "US_Performance_Test_2019_Big_F");
                    dic.Add("Level_2", "US_Performance_Test_2019_Big_F Plan");
                    dic.Add("Level_3", "FundingValuations");
                    pMain._HomeTreeViewSelect_Favorites(0, dic);

                    dic.Clear();
                    dic.Add("PopVerify", "Pop");
                    dic.Add("AddServiceInstance", "");
                    dic.Add("ServiceToOpen", "Funding 1.1.2013");
                    pMain._PopVerify_Home_RightPane(dic);

                    pMain._SelectTab("Funding 1.1.2013");

                    dic.Clear();
                    dic.Add("iMaxRowNum", "");
                    dic.Add("iMaxColNum", "");
                    dic.Add("iSelectRowNum", "2");
                    dic.Add("iSelectColNum", "1");
                    dic.Add("MenuItem_1", "View Output");
                    pMain._FlowTreeRightSelect(dic);

                    pMain._SelectTab("Output Manager");

                    
                    mTime.StartTimer();
                    pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_USPerformance_Funding2013_Baseline, "Data Matching Summary", "RollForward", true, true);
                    mTime.StopTimer(iUSPerformance_Export_DataMatchingSummary);

                    mTime.StartTimer();
                    pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_USPerformance_Funding2013_Baseline, "Combined Status Code Summary", "RollForward", true, true);
                    mTime.StopTimer(iUSPerformance_Export_CombinedStatusCodeSummary);

                    mTime.StartTimer();
                    pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_USPerformance_Funding2013_Baseline, "Gain / Loss Status Reconciliation", "RollForward", true, true);
                    mTime.StopTimer(iUSPerformance_Export_GainLossStatusReconciliation);

                    mTime.StartTimer();
                    pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_USPerformance_Funding2013_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, true);
                    mTime.StopTimer(iUSPerformance_Export_GainLossSummaryofLiabilityReconciliation);

                    mTime.StartTimer();
                    pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_USPerformance_Funding2013_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", true, true);
                    mTime.StopTimer(iUSPerformance_Export_ActiveDecrementGainLossDetail);

                    mTime.StartTimer();
                    pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_USPerformance_Funding2013_Baseline, "Decrement Age", "RollForward", true, true);
                    mTime.StopTimer(iUSPerformance_Export_DecrementAge);

                    //mTime.StartTimer();
                    //pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_USPerformance_Funding2013_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
                    //mTime.StopTimer(iUSPerformance_Export_GainLossParticipantListing);

                    mTime.StartTimer();
                    pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_USPerformance_Funding2013_Baseline, "Valuation Summary", "RollForward", true, true);
                    mTime.StopTimer(iUSPerformance_Export_ValuationSummary);


                    #region IOE

                    pMain._SelectTab("Output Manager");
                    pOutputManager._Navigate(Config.eCountry, "IOE", "RollForward", true);
                    pOutputManager._SelectTab("Individual Output");
                    _gLib._SetSyncUDWin("Group - None", pOutputManager.wRetirementStudio.wGroup_None.rdNone, "True", 0);
                    _gLib._SetSyncUDWin("Process", pOutputManager.wRetirementStudio.wProcess.btnProcess, "Click", 0);

                    if (_gLib._Exists("NewIOEParameters1", pOutputManager.wRetirementStudio.tvNaviTree.tviIndividualOutput.tviNewIOEParameters1, Config.iTimeout / 30, false))
                    {
                        _gLib._SetSyncUDWin("NewIOEParameters1", pOutputManager.wRetirementStudio.tvNaviTree.tviIndividualOutput.tviNewIOEParameters1, "Click", 0);
                    }
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

                    _gLib._SetSyncUDWin("wVerticalScrollBar", pOutputManager.wRetirementStudio.wVerticalScrollBar.pagedownButton, "Click", Config.iTimeout / 3, false, 6, 50);

                    mTime.StartTimer();

                    _gLib._SetSyncUDWin("Export", pOutputManager.wRetirementStudio.wExport.btnExport, "Click", 0);
                    pOutputManager._SaveAs(sOutputFunding_USPerformance_Funding2013_Baseline + "IOE.xlsx");
                    _gLib._SetSyncUDWin("OK", pOutputManager.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);

                    pOutputManager._SelectTab("Individual Output");
                    mTime.StopTimer(iUSPerformance_Export_IOE);

                    #endregion

                    pMain._Home_ToolbarClick_Top(true);
                    pMain._SelectTab("Funding 1.1.2013");
                    pMain._Home_ToolbarClick_Top(false);

                }

                #endregion
                
            }


            #endregion
            
            
            mLog.LogInfo(iTimeEnd, DateTime.Now.ToString());


            _gLib._MsgBox("Congratulations!", "Finished!");


            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
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
