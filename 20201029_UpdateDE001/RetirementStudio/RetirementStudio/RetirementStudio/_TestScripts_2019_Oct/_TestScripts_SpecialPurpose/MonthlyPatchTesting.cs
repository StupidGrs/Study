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
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

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
using System.Reflection;


namespace RetirementStudio._TestScripts_2019_Oct_SpecialPurpose
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class MonthlyPatchTesting
    {
        public MonthlyPatchTesting()
        {


            Config.eCountry = _Country.US;
            //Config.eCountry = _Country.CA;
            //Config.eCountry = _Country.DE;

            Config.sClientName = "";
            Config.sPlanName = "";
            Config.sService = "";


            Config.sClientName_US = "QA US Benchmark 015";
            Config.sPlanName_US = "QA US Benchmark 015 Plan";
            Config.sService_US = "Conversion 2010";
                        
            Config.sClientName_CA = "QA Testing Client";
            Config.sPlanName_CA = "QA Citrix (D)";
            Config.sService_CA = "Retirement Income Plan";
                        
            Config.sClientName_DE = "QA Testing Client";
            Config.sPlanName_DE = "QA Citrix (D)";
            Config.sService_DE = "Retirement Income Plan";



        }

        static string sOuput_Main = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\000_MonthlyPatchTesting\";
        string sOutputDir = "";
        string sOutputDir_US = sOuput_Main + "US\\";
        string sOutputDir_CA = sOuput_Main + "CA\\";
        string sOutputDir_DE = sOuput_Main + "DE\\";
        string sSelectRowNum = "";
        string sSelectColNum = "";
        string sSelectRowNum_US = "1";
        string sSelectColNum_US = "1";

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
        public void testMonthlyPatchTesting()
        {

            _gLib._CreateDirectory(sOutputDir, false);

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", Config.sService);
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab(Config.sService);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", sSelectRowNum);
            dic.Add("iSelectColNum", sSelectColNum);
            dic.Add("MenuItem_1", "Validate");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            _gLib._SetSyncUDWin("wValidate", pMain.wValidationConfirm.wValidate.btn, "Click", 0);

            _gLib._Exists("wNodeName", pMain.wValidationResultsSummary.wNodeName.txt, 10);
            _gLib._Exists("wOverallValidateStatus", pMain.wValidationResultsSummary.wOverallValidateStatus.txt, 10);
            _gLib._Exists("wDataValidateStatus", pMain.wValidationResultsSummary.wDataValidateStatus.txt, 10);
            _gLib._Exists("wMethodValidateStatus", pMain.wValidationResultsSummary.wMethodValidateStatus.txt, 10);
            _gLib._Exists("wAssumptionValidateStatus", pMain.wValidationResultsSummary.wAssumptionValidateStatus.txt, 10);
            _gLib._Exists("wProvisionValidateStatus", pMain.wValidationResultsSummary.wProvisionValidateStatus.txt, 10);
            _gLib._Exists("wParamValidateStatus", pMain.wValidationResultsSummary.wParamValidateStatus.txt, 10);

            _gLib._SetSyncUDWin("wClose", pMain.wValidationResultsSummary.wClose.btn, "Click", 0);

            pMain._SelectTab(Config.sService);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", sSelectRowNum);
            dic.Add("iSelectColNum", sSelectColNum);
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", sSelectRowNum);
            dic.Add("iSelectColNum", sSelectColNum);
            dic.Add("MenuItem_1", "View Run Status");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("VerifyMsg", "True");
            pMain._PopVerify_GroupJobSuccessfullyComplete(dic);

            if (_gLib._Exists("wRetirementStudio_ERComplete", pMain.wRetirementStudio_ERComplete.wOK.btn, 3, 1, false))
                _gLib._SetSyncUDWin("OK", pMain.wRetirementStudio_ERComplete.wOK.btn, "Click", 0);

            pMain._SelectTab(Config.sService);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", sSelectRowNum);
            dic.Add("iSelectColNum", sSelectColNum);
            dic.Add("MenuItem_1", "Parameter Print");
            dic.Add("CheckOMSetupPopup", "");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Parameter Print Report");
            pOutputManager._WaitForLoading();
            pMain._SelectTab("Parameter Print Report");

            for (int i = 0; i <= 10; i++)
            {
                try
                {
                    _gLib._SetSyncUDWin("Export Button", pOutputManager.wRetirementStudio.wToolbar.miExport, "Click", 0, false, 10, 10);
                    _gLib._SendKeysUDWin("Export Menu", pOutputManager.wRetirementStudio.wToolbar.miExport, "{Down}{Enter}"); //// Prod
                    if (_gLib._Exists("pOutputManager.wSaveAs", pOutputManager.wSaveAs.wSave.btnSave, Config.iTimeout / 10, false))
                        break;
                }
                catch (Exception ex)
                { }
            }

            pOutputManager._SaveAs(sOutputDir + "ParameterPrint.pdf");
            _gLib._FileExists(sOutputDir + "ParameterPrint.pdf", Config.iTimeout, true);


            pMain._SelectTab(Config.sService);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", sSelectRowNum);
            dic.Add("iSelectColNum", sSelectColNum);
            dic.Add("MenuItem_1", "View Output");
            dic.Add("CheckOMSetupPopup", "");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");


            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputDir, "Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputDir, "IOE", "RollForward", false, true);

            pMain._SelectTab(Config.sService);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            //_gLib._MsgBox("Completed!", "Thank you!!!");
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            switch (Config.eCountry)
            {
                case _Country.US:
                    Config.sClientName = Config.sClientName_US;
                    Config.sPlanName = Config.sPlanName_US;
                    Config.sService = Config.sService_US;
                    sOutputDir = sOutputDir_US;
                    sSelectRowNum = sSelectRowNum_US;
                    sSelectColNum = sSelectColNum_US;
                    break;
                case _Country.CA:
                    Config.sClientName = Config.sClientName_CA;
                    Config.sPlanName = Config.sPlanName_CA;
                    Config.sService = Config.sService_CA;
                    sOutputDir = sOutputDir_CA;
                    break;
                case _Country.DE:
                    Config.sClientName = Config.sClientName_DE;
                    Config.sPlanName = Config.sPlanName_DE;
                    Config.sService = Config.sService_DE;
                    sOutputDir = sOutputDir_DE;
                    break;
                default:
                    _gLib._MsgBoxYesNo("Warning!", "Incorrect country setting, please double check!");
                    break;

            }
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
