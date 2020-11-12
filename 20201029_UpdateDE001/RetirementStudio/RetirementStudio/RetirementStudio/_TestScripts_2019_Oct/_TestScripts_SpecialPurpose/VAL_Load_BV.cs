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


namespace RetirementStudio._TestScripts_2019_Oct_SpecialPurpose
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class VAL_Load_BV
    {
        public VAL_Load_BV()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;

            Config.sClientName = "QA Data Performance 20K 20140627_B"; 
            Config.sPlanName = "US Plan";

        }



        static string sValService = "Funding 2014 for Load testing Aug 20";

        MyDictionary dicBaselinePosition = new MyDictionary();
        MyDictionary dicNewNodePosition = new MyDictionary();





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


        #endregion

    
        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void testVAL_Load_BV()
        {


            _gLib._MsgBox("Warning!", "Make sure the Val serivce is opened <" + sValService + "> Click OK to start!");

            pMain._SelectTab(sValService);


            for (int i = 1; i <= 10; i++)
            {

                #region Step 1 - Add Node

                pMain._SelectTab("Valuation2012");

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "");
                dic.Add("iSelectColNum", "");
                dic.Add("iPosX", dicBaselinePosition["X_" + i.ToString()]);
                dic.Add("iPosY", dicBaselinePosition["Y_" + i.ToString()]);
                dic.Add("MenuItem_1", "Add Valuation Node");
                dic.Add("MenuItem_2", "");
                pMain._FlowTreeRightSelect(dic);



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
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pMain._PopVerify_ValuationNodeProperties(dic);
                

                pMain._SelectTab("Valuation2012");

                #endregion

                
            }


            pMain._SelectTab("Valuation2012");
            
            

            _gLib._MsgBox("Congratulations!", "Click OK to stop!");




        }




        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {

            dicBaselinePosition.Clear();
            dicBaselinePosition.Add("X_1", "170");
            dicBaselinePosition.Add("Y_1", "70");
            dicBaselinePosition.Add("X_2", "400");
            dicBaselinePosition.Add("Y_2", "378");
            dicBaselinePosition.Add("X_3", "350");
            dicBaselinePosition.Add("Y_3", "436");
            dicBaselinePosition.Add("X_4", "350");
            dicBaselinePosition.Add("Y_4", "490");
            dicBaselinePosition.Add("X_5", "350");
            dicBaselinePosition.Add("Y_5", "530");
            dicBaselinePosition.Add("X_6", "400");
            dicBaselinePosition.Add("Y_6", "320");
            dicBaselinePosition.Add("X_7", "470");
            dicBaselinePosition.Add("Y_7", "380");
            dicBaselinePosition.Add("X_8", "435");
            dicBaselinePosition.Add("Y_8", "435");
            dicBaselinePosition.Add("X_9", "435");
            dicBaselinePosition.Add("Y_9", "490");
            dicBaselinePosition.Add("X_10", "435");
            dicBaselinePosition.Add("Y_10", "530");


            dicNewNodePosition.Clear();
            dicNewNodePosition.Add("X_1", "170");
            dicNewNodePosition.Add("Y_1", "70");



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
