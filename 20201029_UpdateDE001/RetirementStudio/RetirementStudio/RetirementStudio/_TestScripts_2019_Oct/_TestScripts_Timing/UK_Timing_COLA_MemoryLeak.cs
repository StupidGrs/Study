////// ----------------------- ------------------------------------------------------------------------///////////
//////                           This test Based on UKTiming Test Part-2                               ///////////
//////                                down to Node  CMI 1.5% new ret dec                               ///////////
//////                         it begins from Valuation2012 - Baseline node                            ///////////
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
using RetirementStudio._UIMaps.FAEFormulaClasses;
using RetirementStudio._UIMaps.EarlyRetirementFactorClasses;
using RetirementStudio._UIMaps.BenefitElectionsClasses;
using RetirementStudio._UIMaps.TableManagerClasses;
using RetirementStudio._UIMaps.UnitFormulaClasses;
using RetirementStudio._UIMaps.AdjustmentsClasses;
// CA Screens
using RetirementStudio._UIMaps.DefinedBenefitLimitIncreaseClasses;
// UK screens
using RetirementStudio._UIMaps.InflationClasses;
using RetirementStudio._UIMaps.TrancheDefinitionClasses;
using RetirementStudio._UIMaps.ServiceSelectionClasses;
using RetirementStudio._UIMaps.EmployeeContributionsFormulaClasses;
using RetirementStudio._UIMaps.CostOfLivingAdjustments_UKClasses;
using RetirementStudio._UIMaps.GMPAdjustmentFactorsClasses;
using RetirementStudio._UIMaps.CommunicationFactorsClasses;
using RetirementStudio._UIMaps.TranchedBenefitClasses;
using RetirementStudio._UIMaps.TranchedBenefitPlanDefinitionClasses;
using RetirementStudio._UIMaps.NonTranchedBenefitPlanDefinitionClasses;
using RetirementStudio._UIMaps.Methods_UKClasses;


namespace RetirementStudio._TestScripts_2019_Oct_Timing
{
    /// <summary>
    /// Summary description for UK_Timing_COLA_MemoryLeak
    /// </summary>
    [CodedUITest]
    public class UK_Timing_COLA_MemoryLeak
    {
        public UK_Timing_COLA_MemoryLeak()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.UK;
            ////Config.sClientName = "UK Performance Test_COLA_MemoryLeak B"; //EU Prod client
            //Config.sClientName = "UK Performance Test_COLA_MemoryLeak E"; //EU Prod client
            //Config.sClientName = "UK_Performance_Test_COLA_MemoryLeak"; //QA1 client
            Config.sClientName = "UK Performance Test_COLA_MemoryLeak"; //CA Prod client
            //Config.sClientName = "UK Performance Test Custom D"; //US Prod client
            Config.sPlanName = "UK Plan";
            ////Config.sDataCenter = "Exeter";
            ////Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = false;
            Config.bCompareReports = false;


        }

        //static Boolean bDeleteNode = true;
        static Boolean bDeleteNode = false;


        #region Timing



        static string sCol_Time = "Time";
        static string sCol_Memory = "Memory";
        static string sLogFile = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\UK_Timing_Test_COLA_MemoryLeak\UK_Timing_Test_COLA_MemoryLeak_CUIT.xls";
        MyTimer mTime = new MyTimer(sCol_Time, sLogFile);
        MyLog mLog = new MyLog(sCol_Memory, sLogFile);


        MyDictionary dicResultIndex = new MyDictionary();
        MyDictionary dicPosition = new MyDictionary();
        MyDictionary dicPositionDel = new MyDictionary();
        MyDictionary dicPositionNoDel = new MyDictionary();

        MyDictionary dicPositionBaseline = new MyDictionary();
        MyDictionary dicPositionBaselineNoDel = new MyDictionary();
        MyDictionary dicPositionBaselineDel = new MyDictionary();



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
        public FromToAge pFromToAge = new FromToAge();
        public FAEFormula pFAEFormula = new FAEFormula();
        public EarlyRetirementFactor pEarlyRetirementFactor = new EarlyRetirementFactor();
        public BenefitElections pBenefitElections = new BenefitElections();
        public Adjustments pAdjustments = new Adjustments();

        public DefinedBenefitLimitIncrease pDefinedBenefitLimitIncrease = new DefinedBenefitLimitIncrease();
        public TableManager pTableManager = new TableManager();
        public UnitFormula pUnitFormula = new UnitFormula();


        public Inflation pInflation = new Inflation();
        public TrancheDefinition pTrancheDefinition = new TrancheDefinition();
        public ServiceSelection pServiceSelection = new ServiceSelection();
        public EmployeeContributionsFormula pEmployeeContributionsFormula = new EmployeeContributionsFormula();
        public CostOfLivingAdjustments_UK pCostOfLivingAdjustments_UK = new CostOfLivingAdjustments_UK();
        public GMPAdjustmentFactors pGMPAdjustmentFactors = new GMPAdjustmentFactors();
        public CommunicationFactors pCommunicationFactors = new CommunicationFactors();
        public TranchedBenefit pTranchedBenefit = new TranchedBenefit();
        public TranchedBenefitPlanDefinition pTranchedBenefitPlanDefinition = new TranchedBenefitPlanDefinition();
        public NonTranchedBenefitPlanDefinition pNonTranchedBenefitPlanDefinition = new NonTranchedBenefitPlanDefinition();
        public Methods_UK pMethods_UK = new Methods_UK();





        #endregion


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_UK_Timing_COLA_MemoryLeak()
        {



            #region Initialize

            _gLib._MsgBoxYesNo("Warning", "Delete Node = <" + bDeleteNode.ToString() + ">.    Are you sure to continue?");


            /////////////// Below are necessary testing codes to make sure memory/time info can be successfully get/set into right cell.
            _gLib._StudioClearCache();


            pMain._SetLanguageAndRegional();
            mLog.LogInfo(Convert.ToInt32(dicResultIndex["iTimeStart"]), MyPerformanceCounter.Memory_Private);
            mLog.LogInfo(Convert.ToInt32(dicResultIndex["iTimeStart"]), DateTime.Now.ToString());
            ////////////_gLib._MsgBox("Reminder!", "Please go to the timing log file to check if the results logged into expected cell!");


            ////////////////////////_gLib._MsgBox("Warning!", "Please manually select the Client in Studio-> Home -> All Services -> "
            ////////////////////////    + Config.sClientName + Environment.NewLine + Environment.NewLine + "Click OK to keep testing!");




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

            if (!bDeleteNode)
                _gLib._MsgBox("Warning", "Please manually expand the flow tree to make it large enough to hold 5 nodes!");


            #endregion 


            for (int i = 1; i <= 10; i++)
            {

                #region Add Val Node

                pMain._SelectTab("Valuation2012");

                mTime.StartTimer();

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "");
                dic.Add("iSelectColNum", "");
                dic.Add("iPosX", dicPositionBaseline["X_" + i.ToString()]);
                dic.Add("iPosY", dicPositionBaseline["Y_" + i.ToString()]);
                dic.Add("MenuItem_1", "Add Valuation Node");
                dic.Add("MenuItem_2", "");
                pMain._FlowTreeRightSelect(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ValNodeName", "Node10000" + i.ToString());
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
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pMain._PopVerify_ValuationNodeProperties(dic);


                pMain._SelectTab("Valuation2012");

                mTime.StopTimer(Convert.ToInt32(dicResultIndex["iAddNode_" + i.ToString()]));
                mLog.LogInfo(Convert.ToInt32(dicResultIndex["iAddNode_" + i.ToString()]), MyPerformanceCounter.Memory_Private);




                #endregion 


                #region Edit COLA

                pMain._SelectTab("Valuation2012");

                mTime.StartTimer();

                if (bDeleteNode)
                {
                    dic.Clear();
                    dic.Add("iMaxRowNum", "");
                    dic.Add("iMaxColNum", "");
                    dic.Add("iSelectRowNum", "");
                    dic.Add("iSelectColNum", "");
                    dic.Add("iPosX", dicPosition["X_11"]);
                    dic.Add("iPosY", dicPosition["Y_11"]);
                    dic.Add("MenuItem_1", "Provisions");
                    dic.Add("MenuItem_2", "Edit Parameters");
                    pMain._FlowTreeRightSelect(dic);
                }
                else
                {
                    dic.Clear();
                    dic.Add("iMaxRowNum", "");
                    dic.Add("iMaxColNum", "");
                    dic.Add("iSelectRowNum", "");
                    dic.Add("iSelectColNum", "");
                    dic.Add("iPosX", dicPosition["X_" + i.ToString()]);
                    dic.Add("iPosY", dicPosition["Y_" + i.ToString()]);
                    dic.Add("MenuItem_1", "Provisions");
                    dic.Add("MenuItem_2", "Edit Parameters");
                    pMain._FlowTreeRightSelect(dic);
                 }

                pMain._SelectTab("Provisions");

                dic.Clear();
                dic.Add("Level_1", "A_80ths_Structure");
                dic.Add("Level_2", "Provisions");
                dic.Add("Level_3", "Cost of Living Adjustments");
                dic.Add("MenuItem", "Add Cost of Living Adjustments");
                pAssumptions._TreeViewRightSelect(dic, "COLA_Loop"+i.ToString());

                dic.Clear();
                dic.Add("Level_1", "A_80ths_Structure");
                dic.Add("Level_2", "Provisions");
                dic.Add("Level_3", "Cost of Living Adjustments");
                dic.Add("Level_4", "COLA_Loop" + i.ToString());
                dic.Add("Level_5", "Default");
                pAssumptions._TreeViewSelect(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("StatutoryCPI", "");
                dic.Add("StatutoryRPI", "True");
                pCostOfLivingAdjustments_UK._PopVerify_Main(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("Revaluation_DeferredPension", "True");
                dic.Add("Revaluation_Rate_V", "Click");
                dic.Add("Revaluation_Rate_P", "");
                dic.Add("Revaluation_Rate_T", "");
                dic.Add("Revaluation_CumulativeMax", "");
                dic.Add("Revaluation_PensionIncrease", "");
                dic.Add("Revaluation_Rate_V_cbo", "#6#");
                dic.Add("Revaluation_Rate_P_txt", "");
                dic.Add("Revaluation_Rate_T_cbo", "");
                dic.Add("Increase_Starts_YearsFrom", "");
                dic.Add("Increase_Starts_Date_V", "");
                dic.Add("Increase_Starts_Date_D", "Click");
                dic.Add("Increase_Starts_Date_V_cbo", "");
                dic.Add("Increase_Starts_Date_D_txt", "05/04/2009");
                dic.Add("Increase_Ends_YearsFrom", "");
                dic.Add("Increase_Ends_Date_V", "");
                dic.Add("Increase_Ends_Date_D", "");
                dic.Add("Increase_Ends_Date_V_cbo", "");
                dic.Add("Increase_Ends_Date_D_txt", "");
                dic.Add("Increase_Amount_Rate_V", "Click");
                dic.Add("Increase_Amount_Rate_P", "");
                dic.Add("Increase_Amount_Rate_T", "");
                dic.Add("Increase_Amount_Rate_V_cbo", "#6#");
                dic.Add("Increase_Amount_Rate_P_txt", "");
                dic.Add("Increase_Amount_Rate_T_cbo", "");
                dic.Add("Increase_Pension", "");
                pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic);


                dic.Clear();
                dic.Add("Level_1", "A_80ths_Structure");
                dic.Add("Level_2", "Provisions");
                dic.Add("Level_3", "Cost of Living Adjustments");
                dic.Add("Level_4", "COLA_Loop" + i.ToString());
                dic.Add("MenuItem", "Rename");
                pAssumptions._TreeViewRightSelect(dic, "COLA_Loop_Rename" + i.ToString());



                dic.Clear();
                dic.Add("Level_1", "A_80ths_Structure");
                dic.Add("Level_2", "Provisions");
                dic.Add("Level_3", "Cost of Living Adjustments");
                dic.Add("Level_4", "COLA_Loop_Rename" + i.ToString());
                dic.Add("MenuItem", "Delete");
                pAssumptions._TreeViewRightSelect(dic, "");

                pMain._Home_ToolbarClick_Top(true);

                pMain._SelectTab("Provisions");

                mTime.StopTimer(Convert.ToInt32(dicResultIndex["iCOLA_" + i.ToString()]));
                mLog.LogInfo(Convert.ToInt32(dicResultIndex["iCOLA_" + i.ToString()]), MyPerformanceCounter.Memory_Private);


                if (bDeleteNode)
                {
                    pMain._SelectTab("Valuation2012");

                    dic.Clear();
                    dic.Add("iMaxRowNum", "");
                    dic.Add("iMaxColNum", "");
                    dic.Add("iSelectRowNum", "");
                    dic.Add("iSelectColNum", "");
                    dic.Add("iPosX", dicPosition["X_11"]);
                    dic.Add("iPosY", dicPosition["Y_11"]);
                    dic.Add("MenuItem_1", "Delete Valuation Node");
                    dic.Add("MenuItem_2", "");
                    pMain._FlowTreeRightSelect(dic);

                    dic.Clear();
                    dic.Add("PopVerify", "Pop");
                    dic.Add("OK", "Click");
                    pMain._PopVerify_DeleteValuationNode(dic);

                    pMain._SelectTab("Valuation2012");
                }


                #endregion 


            }


            pMain._SelectTab("Valuation2012");
            pMain._Home_ToolbarClick_Top(true);
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



            dicPositionDel.Clear();
            dicPositionDel.Add("X_1", "172");
            dicPositionDel.Add("Y_1", "95");
            dicPositionDel.Add("X_2", "172");
            dicPositionDel.Add("Y_2", "95");
            dicPositionDel.Add("X_3", "172");
            dicPositionDel.Add("Y_3", "95");
            dicPositionDel.Add("X_4", "172");
            dicPositionDel.Add("Y_4", "95");
            dicPositionDel.Add("X_5", "172");
            dicPositionDel.Add("Y_5", "95");
            dicPositionDel.Add("X_6", "172");
            dicPositionDel.Add("Y_6", "95");
            dicPositionDel.Add("X_7", "172");
            dicPositionDel.Add("Y_7", "95");
            dicPositionDel.Add("X_8", "172");
            dicPositionDel.Add("Y_8", "95");
            dicPositionDel.Add("X_9", "172");
            dicPositionDel.Add("Y_9", "95");
            dicPositionDel.Add("X_10", "172");
            dicPositionDel.Add("Y_10", "95");
            dicPositionDel.Add("X_11", "291");
            dicPositionDel.Add("Y_11", "150");


            dicPositionBaselineNoDel.Clear();
            dicPositionBaselineNoDel.Add("X_1", "172");
            dicPositionBaselineNoDel.Add("Y_1", "95");
            dicPositionBaselineNoDel.Add("X_2", "198");
            dicPositionBaselineNoDel.Add("Y_2", "96");
            dicPositionBaselineNoDel.Add("X_3", "250");
            dicPositionBaselineNoDel.Add("Y_3", "96");
            dicPositionBaselineNoDel.Add("X_4", "275");
            dicPositionBaselineNoDel.Add("Y_4", "96");
            dicPositionBaselineNoDel.Add("X_5", "340");
            dicPositionBaselineNoDel.Add("Y_5", "96");
            dicPositionBaselineNoDel.Add("X_6", "400");
            dicPositionBaselineNoDel.Add("Y_6", "200");
            dicPositionBaselineNoDel.Add("X_7", "400");
            dicPositionBaselineNoDel.Add("Y_7", "200");
            dicPositionBaselineNoDel.Add("X_8", "400");
            dicPositionBaselineNoDel.Add("Y_8", "200");
            dicPositionBaselineNoDel.Add("X_9", "400");
            dicPositionBaselineNoDel.Add("Y_9", "200");
            dicPositionBaselineNoDel.Add("X_10", "400");
            dicPositionBaselineNoDel.Add("Y_10", "200");


            dicPositionNoDel.Clear();
            dicPositionNoDel.Add("X_1", "291");
            dicPositionNoDel.Add("Y_1", "150");
            dicPositionNoDel.Add("X_2", "398");
            dicPositionNoDel.Add("Y_2", "150");
            dicPositionNoDel.Add("X_3", "476");
            dicPositionNoDel.Add("Y_3", "150");
            dicPositionNoDel.Add("X_4", "606");
            dicPositionNoDel.Add("Y_4", "150");
            dicPositionNoDel.Add("X_5", "737");
            dicPositionNoDel.Add("Y_5", "150");
            dicPositionNoDel.Add("X_6", "555");
            dicPositionNoDel.Add("Y_6", "266");
            dicPositionNoDel.Add("X_7", "638");
            dicPositionNoDel.Add("Y_7", "266");
            dicPositionNoDel.Add("X_8", "688");
            dicPositionNoDel.Add("Y_8", "266");
            dicPositionNoDel.Add("X_9", "699");
            dicPositionNoDel.Add("Y_9", "266");
            dicPositionNoDel.Add("X_10", "738");
            dicPositionNoDel.Add("Y_10", "266");

            if (bDeleteNode)
            {
                dicPosition = dicPositionDel;
                dicPositionBaseline = dicPositionDel;
            }
            else
            { 
                dicPosition = dicPositionNoDel;
                dicPositionBaseline = dicPositionBaselineNoDel;
            }

            dicResultIndex.Clear();
            dicResultIndex.Add("iTimeStart", "2");
            dicResultIndex.Add("iTimeEnd", "3");
            dicResultIndex.Add("iAddNode_1", "4");
            dicResultIndex.Add("iAddNode_2", "6");
            dicResultIndex.Add("iAddNode_3", "8");
            dicResultIndex.Add("iAddNode_4", "10");
            dicResultIndex.Add("iAddNode_5", "12");
            dicResultIndex.Add("iAddNode_6", "14");
            dicResultIndex.Add("iAddNode_7", "16");
            dicResultIndex.Add("iAddNode_8", "18");
            dicResultIndex.Add("iAddNode_9", "20");
            dicResultIndex.Add("iAddNode_10", "22");
            dicResultIndex.Add("iCOLA_1", "5");
            dicResultIndex.Add("iCOLA_2", "7");
            dicResultIndex.Add("iCOLA_3", "9");
            dicResultIndex.Add("iCOLA_4", "11");
            dicResultIndex.Add("iCOLA_5", "13");
            dicResultIndex.Add("iCOLA_6", "15");
            dicResultIndex.Add("iCOLA_7", "17");
            dicResultIndex.Add("iCOLA_8", "19");
            dicResultIndex.Add("iCOLA_9", "21");
            dicResultIndex.Add("iCOLA_10", "23");

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
