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
using System.Reflection;


namespace RetirementStudio._TestScripts_2019_cloud._TestScripts_Timing
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class US_Time_Cloud_Custom
    {
        public US_Time_Cloud_Custom()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            ////Config.sStudioLaunchDir = @"C:\Users\webber-ling\Desktop\QA1_20181211.1\Client\RetirementStudio.exe";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
        }



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


            int iCoreNum = 0;

            string sql_Query = "select count(*) from computeclusterjobtask where jobid = " + sID;
            SqlCommand sql_command = new SqlCommand(sql_Query, sql_conn);
            sql_conn.Open();
            SqlDataReader sql_reader = sql_command.ExecuteReader();

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
        static string sLogFile = @"C:\Users\webber-ling\Desktop\_RTS\RetirementStudio\US_Timing_Test_Cloud_Custom.xls";
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


        ////////////public List<Node> nodelist = new List<Node>(){
        ////////////    new Node("QA US Benchmark 019 Existing DNT", "QA US Benchmark 019 Existing DNT Plan", "FundingValuations", "1.1.2017 Funding Valuation", "Baseline", "", "0", "1", "1", "Group Job Successfully Complete", 784, 159, "FV Proj"),

        ////////////};

        public static string CodeBase(TestContext testContext)
        {
            System.Type t = testContext.GetType();
            FieldInfo field = t.GetField("m_test", BindingFlags.NonPublic | BindingFlags.Instance);
            object fieldValue = field.GetValue(testContext);
            t = fieldValue.GetType();
            PropertyInfo property = fieldValue.GetType().GetProperty("CodeBase");
            return (string)property.GetValue(fieldValue, null);
        }


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_US_Time_Cloud_Custom()
        {

            //pMain._SetLanguageAndRegional(); /// has to be under United States


            List<Node> nodelist = new List<Node>();
            //nodelist.Add(new Node("QA US Benchmark 015 Existing DNT", "QA US Benchmark 015 Existing DNT Plan", "FundingValuations", "Valuation 2011", "Baseline", "", "", "2", "1", "Group Job Successfully Complete", 20, 53, ""));
            //nodelist.Add(new Node("QA US Benchmark 015 Existing DNT", "QA US Benchmark 015 Existing DNT Plan", "FundingValuations", "Valuation 2011", "Baseline", "", "2", "3", "1", "Group Job Successfully Complete", 20, 145, "FV Proj"));
            //nodelist.Add(new Node("QA US Benchmark 015 Existing DNT", "QA US Benchmark 015 Existing DNT Plan", "FundingValuations", "Valuation 2011", "Baseline", "", "2", "3", "2", "Group Job Successfully Complete", 20, 152, "FV Liab"));


            //nodelist.Add(new Node("QA US Benchmark 008 Existing DNT", "QA US Benchmark 008 Existing DNT Plan", "FundingValuations", "Conversion 2011", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 125, 18, ""));
            //nodelist.Add(new Node("QA US Benchmark 010 Existing DNT", "QA US Benchmark 010 Existing DNT Plan", "FundingValuations", "July 2006 Valuation", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 590, 32, ""));
            //nodelist.Add(new Node("QA US Benchmark 007 Existing DNT", "QA US Benchmark 007 Existing DNT Plan", "FundingValuations", "Funding 2005", "Baseline", "", "", "1", "1", "Group Job Successfully Complete with 2 NP", 1236, 4, ""));
            //nodelist.Add(new Node("QA US Benchmark 009 Existing DNT", "QA US Benchmark 009 Plan Existing DNT", "FundingValuations", "2005 Funding", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 9554, 25, ""));

            //nodelist.Add(new Node("QA US Benchmark 019 Existing DNT", "QA US Benchmark 019 Existing DNT Plan", "FundingValuations", "1.1.2017 Funding Valuation", "Baseline", "", "0", "1", "1", "Group Job Successfully Complete", 784, 159, "FV Proj"));
            //nodelist.Add(new Node("QA US Benchmark 019 Existing DNT", "QA US Benchmark 019 Existing DNT Plan", "FundingValuations", "1.1.2018 Funding Valuation", "Future Val Run", "", "0", "3", "1", "Group Job Successfully Complete", 784, 166, "FV Liab"));

            nodelist.Add(new Node("QA US Benchmark 009 Existing DNT_50000", "QA US Benchmark 009 Plan Existing DNT", "FundingValuations", "2005 Funding", "Baseline", "", "", "1", "1", "Group Job Successfully Complete", 50000, 25, ""));


            #region for Dev use only

            //////string sLogFile = CodeBase(TestContext).Replace("RetirementStudio.DLL", "000_Dev_US_Timing_Test_Cloud_Custom.xls");
            //////MyTimer mTime = new MyTimer(sCol_Time, sLogFile);
            //////MyLog mLog = new MyLog(sCol_Memory, sLogFile);
            //////MyLog mLogTime = new MyLog(sCol_Time, sLogFile);


            

            //////MyExcel _testData = new MyExcel(CodeBase(TestContext).Replace("RetirementStudio.DLL", "000_Dev_TestData_Cloud.xls"), false);

            ////////////_gLib._MsgBoxYesNo("Total Num of Clients to Run", CodeBase(TestContext).Replace("RetirementStudio.DLL", "000_Dev_TestData_Cloud.xls"));

            //////if (!_testData.OpenExcelFile("Sheet1"))
            //////{
            //////    _gLib._MsgBoxYesNo("Warning", "Fail to open excel: " + CodeBase(TestContext).Replace("RetirementStudio.dll", "000_Dev_TestData_Cloud.xls"));
            //////}

            //////int iTotalRow = _testData.getTotalRowCount();


            //////for (int i = 2; i <= iTotalRow; i++)
            //////{
            //////    string sRun = _testData.getOneCellValue(i, 1);
            //////    string sTotalEE = _testData.getOneCellValue(i, 2);
            //////    string sRunType = _testData.getOneCellValue(i, 3);
            //////    string sClientShortName = _testData.getOneCellValue(i, 4);
            //////    string sClient = _testData.getOneCellValue(i, 5);
            //////    string sPlan = _testData.getOneCellValue(i, 6);
            //////    string sServiceType = _testData.getOneCellValue(i, 7);
            //////    string sServiceName = _testData.getOneCellValue(i, 8);
            //////    string sNode = _testData.getOneCellValue(i, 9);
            //////    string sRowMax = _testData.getOneCellValue(i, 10);
            //////    string sColMax = _testData.getOneCellValue(i, 11);
            //////    string sRow = _testData.getOneCellValue(i, 12);
            //////    string sCol = _testData.getOneCellValue(i, 13);
            //////    string sRunStatus = _testData.getOneCellValue(i, 14);



            //////    if (sRun.ToUpper().Equals("YES"))
            //////    {
            //////        nodelist.Add(new Node(sClient, sPlan, sServiceType, sServiceName, sNode, sRowMax, sColMax, sRow, sCol, sRunStatus, 0, 0, sRunType));
            //////    }
            //////}            


            //////_testData.CloseExcelApplication();


            #endregion


            ////////_gLib._MsgBoxYesNo("Total Num of Clients to Run", nodelist.Count.ToString());

            mLog.LogInfo(iTimeStart, DateTime.Now.ToString());



            #region ER Run


            for (int i = 0; i < nodelist.Count; i++)
            {


                string sER_ClickRun_Time = null;
                int iBaseline_ER_RunSubmitted = i * 7 + 4;
                int iBaseline_ER_ClickRun = iBaseline_ER_RunSubmitted + 1;
                int iBaseline_ER_GroupID = iBaseline_ER_ClickRun + 1;
                int iBaseline_ER_Persist = iBaseline_ER_GroupID + 1;
                int iBaseline_ER_Post = iBaseline_ER_Persist + 1;
                int iBaseline_ER_Detail = iBaseline_ER_Post + 1;
                int iBaseline_NumOfCores = iBaseline_ER_Detail + 1;

                pMain._SelectTab("Home");

                dic.Clear();
                dic.Add("Country", Config.eCountry.ToString());
                dic.Add("Level_1", nodelist[i].sClientName);
                dic.Add("Level_2", nodelist[i].sPlanName);
                dic.Add("Level_3", nodelist[i].sValuationName);
                pMain._HomeTreeViewSelect_Favorites(0, dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("AddServiceInstance", "");
                dic.Add("ServiceToOpen", nodelist[i].sServiceName);
                pMain._PopVerify_Home_RightPane(dic);


                pMain._SelectTab(nodelist[i].sServiceName);


                if (nodelist[i].sRunType == "FV Proj")
                {
                    dic.Clear();
                    dic.Add("iMaxRowNum", nodelist[i].sMaxRowNum);
                    dic.Add("iMaxColNum", nodelist[i].sMaxColNum);
                    dic.Add("iSelectRowNum", nodelist[i].sRowNum);
                    dic.Add("iSelectColNum", nodelist[i].sColNum);
                    dic.Add("MenuItem_1", "Run");
                    dic.Add("MenuItem_2", "Future Valuation Population Projection");
                    pMain._FlowTreeRightSelect(dic);
                }
                else if (nodelist[i].sRunType == "FV Liab")
                {
                    dic.Clear();
                    dic.Add("iMaxRowNum", nodelist[i].sMaxRowNum);
                    dic.Add("iMaxColNum", nodelist[i].sMaxColNum);
                    dic.Add("iSelectRowNum", nodelist[i].sRowNum);
                    dic.Add("iSelectColNum", nodelist[i].sColNum);
                    dic.Add("MenuItem_1", "Run");
                    dic.Add("MenuItem_2", "Future Valuation Liabilities");
                    pMain._FlowTreeRightSelect(dic);
                }
                else if (nodelist[i].sPlanName == "QA US Benchmark 017 Cloud Plan" & nodelist[i].sServiceName == "NDT 2017")
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

                else
                {
                    dic.Clear();
                    dic.Add("iMaxRowNum", nodelist[i].sMaxRowNum);
                    dic.Add("iMaxColNum", nodelist[i].sMaxColNum);
                    dic.Add("iSelectRowNum", nodelist[i].sRowNum);
                    dic.Add("iSelectColNum", nodelist[i].sColNum);
                    dic.Add("MenuItem_1", "Run");
                    dic.Add("MenuItem_2", "Liabilities");
                    pMain._FlowTreeRightSelect(dic);
                }



                if (nodelist[i].sClientName == "QA US Benchmark 011 Cloud" & nodelist[i].sServiceName == "val 7.1.2019")
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
                else if (nodelist[i].sRunType == "FV Proj")
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

                if (nodelist[i].sRunType == "FV Proj")
                { }
                else
                {
                    dic.Clear();
                    dic.Add("PopVerify", "Pop");
                    dic.Add("OK", "Click");
                    pMain._PopVerify_EnterpriseRunSubmitted(dic);
                }

                mTime.StopTimer(iBaseline_ER_RunSubmitted);

                pMain._SelectTab(nodelist[i].sServiceName);


                int iCol_Memory;
                string _sER_ReturnRunStatus_ClickRun = null;
                MyExcel _excelLog = new MyExcel(sLogFile, true);
                _excelLog.OpenExcelFile("Sheet1");
                iCol_Memory = _excelLog.getColumnIndex(sCol_Memory);
                _sER_ReturnRunStatus_ClickRun = _excelLog.getOneCellValue(iBaseline_ER_ClickRun, iCol_Memory);
                _excelLog.CloseExcelApplication();
                DateTime _tER_ReturnRunStatus_ClickRun = Convert.ToDateTime(_sER_ReturnRunStatus_ClickRun);


                if (nodelist[i].sPlanName == "QA US Benchmark 017 Cloud Plan" & nodelist[i].sServiceName == "NDT 2017")
                {
                    dic.Clear();
                    dic.Add("iMaxRowNum", nodelist[i].sMaxRowNum);
                    dic.Add("iMaxColNum", nodelist[i].sMaxColNum);
                    dic.Add("iSelectRowNum", "");
                    dic.Add("iSelectColNum", "");
                    dic.Add("iPosX", "245");
                    dic.Add("iPosY", "90");
                    dic.Add("MenuItem_1", "View Run Status");
                    pMain._FlowTreeRightSelect(dic);
                }
                else
                {
                    dic.Clear();
                    dic.Add("iMaxRowNum", nodelist[i].sMaxRowNum);
                    dic.Add("iMaxColNum", nodelist[i].sMaxColNum);
                    dic.Add("iSelectRowNum", nodelist[i].sRowNum);
                    dic.Add("iSelectColNum", nodelist[i].sColNum);
                    dic.Add("MenuItem_1", "View Run Status");
                    pMain._FlowTreeRightSelect(dic);
                }

                if (nodelist[i].sRunType == "FV Proj")
                {
                    pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");
                }
                else if (nodelist[i].sRunType == "FV Liab")
                {
                    pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");
                }
                else pMain._EnterpriseRun(nodelist[i].sRunStatus, true);





                string _sER_ReturnRunStatus_BottomGrid_Persist = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5);
                string _sER_ReturnRunStatus_BottomGrid_Post = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5);
                DateTime _tER_ReturnRunStatus_BottomGrid_Persist = Convert.ToDateTime(_sER_ReturnRunStatus_BottomGrid_Persist);
                DateTime _tER_ReturnRunStatus_BottomGrid_Post = Convert.ToDateTime(_sER_ReturnRunStatus_BottomGrid_Post);

                string _sER_ReturnRunStatus_BottomGrid_JobSent = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5);
                string _sER_ReturnRunStatus_BottomGrid_JobStatus;
                if (nodelist[i].sRunType == "FV Proj")
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
                mLog.LogInfo(iBaseline_ER_Persist, _sER_ReturnRunStatus_BottomGrid_Persist);
                mLog.LogInfo(iBaseline_ER_Post, _sER_ReturnRunStatus_BottomGrid_Post);


                sERDetail = "";
                sERDetail = sERDetail + "Earliest Process: " + _sER_ReturnRunStatus_BottomGrid_JobSent + Environment.NewLine;
                sERDetail = sERDetail + "Job Success: " + _sER_ReturnRunStatus_BottomGrid_JobStatus + Environment.NewLine;
                sERDetail = sERDetail + "Group Job Success: " + _sER_ReturnRunStatus_BottomGrid_GroupJobStatus + Environment.NewLine;
                mLog.LogInfo(iBaseline_ER_Detail, sERDetail);

                sERDetail = "";
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



                pMain._SelectTab(nodelist[i].sServiceName);
                pMain._Home_ToolbarClick_Top(false);

                


            }



            #endregion



            mLog.LogInfo(iTimeEnd, DateTime.Now.ToString());



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
