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


namespace RetirementStudio._TestScripts._TestScripts_SpecialPurpose
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class Data_Load_BV
    {
        public Data_Load_BV()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;

            Config.sClientName = "QA Data Performance 20K 20140627_B"; 
            Config.sPlanName = "US Plan";

        }


        static int iMaxLoopNum = 3;
        static string sDataService = "2012 Data for Load testing ";
        static string sViewAndUpdate_1 = "Males Only";
        static string sViewAndUpdate_2 = "DOHAfter2000";
        static string sViewAndUpdate_3 = "DOBBefore1958";
        static string sFileName = "2019 Data Final.xlsx";
        static string sFileDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\Common\Webber\";



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
        public void testData_Load_BV()
        {


            _gLib._MsgBox("Warning!", "Make sure the Data serivce is opened <" + sDataService + "> Click OK to start!");

            pMain._SelectTab(sDataService);


            for (int i = 0; i < iMaxLoopNum; i++)
            {

                #region Upload Data


                dic.Clear();
                dic.Add("Level_1", sDataService);
                dic.Add("Level_2", "Upload Data");
                pData._TreeViewSelect(dic);



                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("LocalFile", "");
                dic.Add("GRSUnloadFile", "");
                dic.Add("SharepointFile", "");
                dic.Add("RepositoryFileName", "");
                dic.Add("Browse", "Click");
                dic.Add("Upload", "");
                pData._PopVerify_UploadData(dic);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", sFileDir + sFileName);
                dic.Add("Open", "Click");
                dic.Add("Cancel", "");
                pMain._PopVerify_FileOpen(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("LocalFile", "");
                dic.Add("GRSUnloadFile", "");
                dic.Add("SharepointFile", "");
                dic.Add("RepositoryFileName", sFileName.Replace(".xlsx", _gLib._ReturnDateStampYYYYMMDDHHMMSS() + ".xls"));
                dic.Add("Browse", "");
                dic.Add("Upload", "Click");
                pData._PopVerify_UploadData(dic);

                pMain._SelectTab(sDataService);



                #endregion


                #region View & Update

                pMain._SelectTab(sDataService);

                dic.Clear();
                dic.Add("Level_1", sDataService);
                dic.Add("Level_2", "View & Update");
                dic.Add("Level_3", sViewAndUpdate_1);
                pData._TreeViewSelect(dic);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("Filter", "");
                dic.Add("Apply", "Click");
                pData._PopVerify_ViewUpdate(dic);


                pMain._SelectTab(sDataService);

                dic.Clear();
                dic.Add("Level_1", sDataService);
                dic.Add("Level_2", "View & Update");
                dic.Add("Level_3", sViewAndUpdate_2);
                pData._TreeViewSelect(dic);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("Filter", "");
                dic.Add("Apply", "Click");
                pData._PopVerify_ViewUpdate(dic);

                pMain._SelectTab(sDataService);

                dic.Clear();
                dic.Add("Level_1", sDataService);
                dic.Add("Level_2", "View & Update");
                dic.Add("Level_3", sViewAndUpdate_3);
                pData._TreeViewSelect(dic);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("Filter", "");
                dic.Add("Apply", "Click");
                pData._PopVerify_ViewUpdate(dic);

                pMain._SelectTab(sDataService);


                #endregion

            }


            
            

            _gLib._MsgBox("Congratulations!", "Click OK to stop!");




        }




        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
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
