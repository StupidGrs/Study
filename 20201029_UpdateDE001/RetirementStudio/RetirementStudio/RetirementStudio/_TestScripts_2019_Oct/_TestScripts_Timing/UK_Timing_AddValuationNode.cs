﻿////// ----------------------- ------------------------------------------------------------------------///////////
//////                           This test Based on UKTiming Test Part-2                               ///////////
//////          it begins after the 8th node "CNS" finished with all 7 left nodes exist                ///////////
//////                                                                                                 ///////////
//////                          Webber.ling@mercer.com      2015-July-22                               ///////////
//////                                                                                                 ///////////
////// ----------------------------------------------------------------------------------------------- ///////////



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


namespace RetirementStudio._TestScripts_2019_Oct_Timing
{
    /// <summary>
    /// Summary description for UK_Timing_AddValuationNode
    /// </summary>
    [CodedUITest]
    public class UK_Timing_AddValuationNode
    {

        public UK_Timing_AddValuationNode()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.UK;
            //Config.sClientName = "UK_Performance_Test_20131206 AddValNode";  /// QA1 client
            //Config.sPlanName = "UK_Performance_Plan";  /// QA1 plan 
            //Config.sClientName = "UK Performance Test_AddNode E";  /// EU Prod client
            /// Config.sClientName = "UK Performance Test_AddNode B";  /// EU Prod client
            //Config.sClientName = "UK Performance Test_AddNode D";  /// US Prod client
            Config.sClientName = "UK Performance Test_AddNode";  /// CA Prod client
            Config.sPlanName = "UK Plan";
            ////Config.sDataCenter = "Exeter";
            ////Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = false;
            Config.bCompareReports = false;



        }


        #region Timing

    
        static string sCol_Time = "Time";
        static string sCol_Memory = "Memory";
        static string sLogFile = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\UK_Timing_Test_AddValuationNode\UK_Timing_Test_AddValuationNode_CUIT.xls";
        MyTimer mTime = new MyTimer(sCol_Time, sLogFile);
        MyLog mLog = new MyLog(sCol_Memory, sLogFile);

        MyDictionary dicResultIndex = new MyDictionary();

        MyDictionary dicPosition = new MyDictionary();

        #region Result Index 

        //////static int iTimeStart = 2;
        //////static int iTimeEnd = iTimeStart + 1;
        //////static int iLaunchNodeProperty_1 = iTimeEnd + 1;
        //////static int iLaunchNodeProperty_2 = iLaunchNodeProperty_1 + 1;
        //////static int iLaunchNodeProperty_3 = iLaunchNodeProperty_2 + 1;
        //////static int iLaunchNodeProperty_4 = iLaunchNodeProperty_3 + 1;
        //////static int iLaunchNodeProperty_5 = iLaunchNodeProperty_4 + 1;
        //////static int iLaunchNodeProperty_6 = iLaunchNodeProperty_5 + 1;
        //////static int iLaunchNodeProperty_7 = iLaunchNodeProperty_6 + 1;
        //////static int iLaunchNodeProperty_8 = iLaunchNodeProperty_7 + 1;
        //////static int iLaunchNodeProperty_9 = iLaunchNodeProperty_8 + 1;
        //////static int iLaunchNodeProperty_10 = iLaunchNodeProperty_9 + 1;

        //////static int iAddNodeSuccess_1 = iLaunchNodeProperty_10 + 1;
        //////static int iAddNodeSuccess_2 = iAddNodeSuccess_1 + 1;
        //////static int iAddNodeSuccess_3 = iAddNodeSuccess_2 + 1;
        //////static int iAddNodeSuccess_4 = iAddNodeSuccess_3 + 1;
        //////static int iAddNodeSuccess_5 = iAddNodeSuccess_4 + 1;
        //////static int iAddNodeSuccess_6 = iAddNodeSuccess_5 + 1;
        //////static int iAddNodeSuccess_7 = iAddNodeSuccess_6 + 1;
        //////static int iAddNodeSuccess_8 = iAddNodeSuccess_7 + 1;
        //////static int iAddNodeSuccess_9 = iAddNodeSuccess_8 + 1;
        //////static int iAddNodeSuccess_10 = iAddNodeSuccess_9 + 1;

        #endregion
        



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

        #endregion



        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_UK_Timing_AddValuationNode()
        {




            #region Initialize Codes

            _gLib._StudioClearCache();

            pMain._SetLanguageAndRegional();

            /////////////// Below are necessary testing codes to make sure memory/time info can be successfully get/set into right cell.
            mLog.LogInfo(Convert.ToInt32(dicResultIndex["iTimeStart"]), MyPerformanceCounter.Memory_Private);
            mLog.LogInfo(Convert.ToInt32(dicResultIndex["iTimeStart"]), DateTime.Now.ToString());
            ////////_gLib._MsgBox("Reminder!", "Please go to the timing log file to check if the results logged into expected cell!");


            //////////////////_gLib._MsgBox("Warning!", "Please manually select the Client in Studio-> Home -> All Services -> "
            //////////////////    + Config.sClientName + Environment.NewLine + Environment.NewLine + "Click OK to keep testing!");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            pMain._SelectTab("Home");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation2012");
            pMain._PopVerify_Home_RightPane(dic);



            #endregion 


      


            for (int i = 1; i <= 10;i++ )
            {

                mTime.StartTimer();

                pMain._SelectTab("Valuation2012");

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "");
                dic.Add("iSelectColNum", "");
                dic.Add("iPosX", dicPosition["X_" + i.ToString()]);
                dic.Add("iPosY", dicPosition["Y_" + i.ToString()]);
                dic.Add("MenuItem_1", "Add Valuation Node");
                dic.Add("MenuItem_2", "");
                pMain._FlowTreeRightSelect(dic);

                dic.Clear();
                dic.Add("Object", "Main.ValNodeProperties");
                dic.Add("optiTimeout", "");
                pMain._ObjectExist(dic); 

                
                mTime.StopTimer(Convert.ToInt32(dicResultIndex["iLaunchNodeProperty_" + i.ToString()]));
                mLog.LogInfo(Convert.ToInt32(dicResultIndex["iLaunchNodeProperty_" + i.ToString()]), MyPerformanceCounter.Memory_Private);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ValNodeName", "Node00" + i.ToString());
                dic.Add("LiabilityValuationDate", "");
                dic.Add("Data_AddNew", "True");
                dic.Add("Data_Name", "");
                dic.Add("Data_Edit", "");
                dic.Add("Assumptions_AddNew", "True");
                dic.Add("Assumptions_Name", "");
                dic.Add("Assumptions_Edit", "");
                dic.Add("MethodsLiabilities_AddNew", "True");
                dic.Add("MethodsLiabilities_Name", "");
                dic.Add("MethodsLiabilities_Edit", "");
                dic.Add("Provisions_AddNew", "True");
                dic.Add("Provisions_Name", "");
                dic.Add("Provisions_Edit", "");
                dic.Add("FundingInformation_AddNew", "");
                dic.Add("FundingInformation_Name", "");
                dic.Add("FundingInformation_Edit", "");
                dic.Add("OK", "");
                dic.Add("Cancel", "");
                pMain._PopVerify_ValuationNodeProperties(dic);


                mTime.StartTimer();


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pMain._PopVerify_ValuationNodeProperties(dic);

                pMain._SelectTab("Valuation2012");

                mTime.StopTimer(Convert.ToInt32(dicResultIndex["iAddNodeSuccess_" + i.ToString()]));
                mLog.LogInfo(Convert.ToInt32(dicResultIndex["iAddNodeSuccess_" + i.ToString()]), MyPerformanceCounter.Memory_Private);


            }


            pMain._SelectTab("Valuation2012");
            pMain._Home_ToolbarClick_Top(false);

            mLog.LogInfo(Convert.ToInt32(dicResultIndex["iTimeEnd"]), DateTime.Now.ToString());


            _gLib._MsgBox("Congratulations!", "Finished!");


            Environment.Exit(0);

        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            dicResultIndex.Clear();
            dicResultIndex.Add("iTimeStart", "2");
            dicResultIndex.Add("iTimeEnd", "3");
            dicResultIndex.Add("iLaunchNodeProperty_1", "4");
            dicResultIndex.Add("iLaunchNodeProperty_2", "5");
            dicResultIndex.Add("iLaunchNodeProperty_3", "6");
            dicResultIndex.Add("iLaunchNodeProperty_4", "7");
            dicResultIndex.Add("iLaunchNodeProperty_5", "8");
            dicResultIndex.Add("iLaunchNodeProperty_6", "9");
            dicResultIndex.Add("iLaunchNodeProperty_7", "10");
            dicResultIndex.Add("iLaunchNodeProperty_8", "11");
            dicResultIndex.Add("iLaunchNodeProperty_9", "12");
            dicResultIndex.Add("iLaunchNodeProperty_10", "13");
            dicResultIndex.Add("iAddNodeSuccess_1", "14");
            dicResultIndex.Add("iAddNodeSuccess_2", "15");
            dicResultIndex.Add("iAddNodeSuccess_3", "16");
            dicResultIndex.Add("iAddNodeSuccess_4", "17");
            dicResultIndex.Add("iAddNodeSuccess_5", "18");
            dicResultIndex.Add("iAddNodeSuccess_6", "19");
            dicResultIndex.Add("iAddNodeSuccess_7", "20");
            dicResultIndex.Add("iAddNodeSuccess_8", "21");
            dicResultIndex.Add("iAddNodeSuccess_9", "22");
            dicResultIndex.Add("iAddNodeSuccess_10", "23");


            dicPosition.Clear();
            dicPosition.Add("X_1", "400");
            dicPosition.Add("Y_1", "320");
            dicPosition.Add("X_2", "400");
            dicPosition.Add("Y_2", "378");
            dicPosition.Add("X_3", "350");
            dicPosition.Add("Y_3", "436");
            dicPosition.Add("X_4", "350");
            dicPosition.Add("Y_4", "490");
            dicPosition.Add("X_5", "350");
            dicPosition.Add("Y_5", "530");
            dicPosition.Add("X_6", "400");
            dicPosition.Add("Y_6", "320");
            dicPosition.Add("X_7", "470");
            dicPosition.Add("Y_7", "380");
            dicPosition.Add("X_8", "435");
            dicPosition.Add("Y_8", "435");
            dicPosition.Add("X_9", "435");
            dicPosition.Add("Y_9", "490");
            dicPosition.Add("X_10", "435");
            dicPosition.Add("Y_10", "530");
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