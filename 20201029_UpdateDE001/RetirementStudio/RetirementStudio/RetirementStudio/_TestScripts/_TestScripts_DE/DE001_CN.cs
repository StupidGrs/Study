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


// CA Screens
using RetirementStudio._UIMaps.DefinedBenefitLimitIncreaseClasses;


// DE Screens
using RetirementStudio._UIMaps.AssumedRetirementAgeClasses;
using RetirementStudio._UIMaps.ContractualRetirementAgeClasses;
using RetirementStudio._UIMaps.JubileeBenefitClasses;
using RetirementStudio._UIMaps.PlanDefinition_DEClasses;
using RetirementStudio._UIMaps.SocialSecurityContributionRatesClasses;
using RetirementStudio._UIMaps.ServiceSelectionClasses;
using RetirementStudio._UIMaps.ProjectAndProrateClasses;
using RetirementStudio._UIMaps.CostOfLivingAdjustmentsClasses;
using RetirementStudio._UIMaps.FormOfPayment_DEClasses;
using RetirementStudio._UIMaps.IndividualOuputFieldDefinitionClasses;
using RetirementStudio._UIMaps.Methods_DEClasses;
using RetirementStudio._UIMaps.ReportBreaksClasses;
using RetirementStudio._UIMaps.BreakFieldTextSubstitutionClasses;
using System.Threading;



namespace RetirementStudio._TestScripts._TestScripts_DE
{
    /// <summary>
    /// Summary description for DE001_CN
    /// </summary>
    [CodedUITest]
    public class DE001_CN
    {
        public DE001_CN()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.DE;
            //////Config.sClientName = "QA DE Benchmark 001 Create New D";
            Config.sClientName = "QA DE Benchmark 001 Create New-20181011";
            Config.sPlanName = "Alle - QA DE Benchmark 001 Create New Plan";
        
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = false;
            Config.bCompareReports = false;
        }

        #region Report Output Directory
        

        public string sOutputPension_Conversion2008 = "";
        public string sOutputPension_Pension2009 = "";
        public string sOutputJubilee_JubileeConversion2008 = "";
        public string sOutputJubilee_Jubilee2009_Baseline = "";
        public string sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest = "";

        public string sOutputPension_Conversion2008_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_001\Existing DNT\VAL\Conversion 2008\000_7.4_Baseline\";
        public string sOutputPension_Pension2009_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_001\Existing DNT\VAL\Pension 2009\000_7.4_Baseline\";
        public string sOutputJubilee_JubileeConversion2008_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_001\Existing DNT\VAL\Jubilee Conversion 2008\000_7.4_Baseline\";
        public string sOutputJubilee_Jubilee2009_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_001\Existing DNT\VAL\Jubilee 2009\Baseline\000_7.4_Baseline\";
        public string sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_001\Existing DNT\VAL\Jubilee 2009\Change Trade and IA Interest\000_7.4_Baseline\";



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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_001\Create New\Val\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputPension_Conversion2008 = _gLib._CreateDirectory(sMainDir + "Conversion 2008\\" + sPostFix + "\\");
                    sOutputPension_Pension2009 = _gLib._CreateDirectory(sMainDir + "Pension 2009\\" + sPostFix + "\\");
                    sOutputJubilee_JubileeConversion2008 = _gLib._CreateDirectory(sMainDir + "Jubilee Conversion 2008\\" + sPostFix + "\\");
                    sOutputJubilee_Jubilee2009_Baseline = _gLib._CreateDirectory(sMainDir + "Jubilee 2009\\Baseline\\" + sPostFix + "\\");
                    sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest = _gLib._CreateDirectory(sMainDir + "Jubilee 2009\\Change Trade and IA Interest\\" + sPostFix + "\\");

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

                string sMainDir = sDir + "DE001_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputPension_Conversion2008 = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Conversion2008\\");
                sOutputPension_Pension2009 = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Pension2009\\");
                sOutputJubilee_JubileeConversion2008 = _gLib._CreateDirectory(sMainDir + "\\sOutputJubilee_JubileeConversion2008\\");
                sOutputJubilee_Jubilee2009_Baseline = _gLib._CreateDirectory(sMainDir + "\\sOutputJubilee_Jubilee2009_Baseline\\");
                sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest = _gLib._CreateDirectory(sMainDir + "\\sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputPension_Conversion2008 = @\"" + sOutputPension_Conversion2008 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Pension2009 = @\"" + sOutputPension_Pension2009 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_JubileeConversion2008 = @\"" + sOutputJubilee_JubileeConversion2008 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Jubilee2009_Baseline = @\"" + sOutputJubilee_Jubilee2009_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest = @\"" + sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);


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

        public DefinedBenefitLimitIncrease pDefinedBenefitLimitIncrease = new DefinedBenefitLimitIncrease();
        public AssumedRetirementAge pAssumedRetirementAge = new AssumedRetirementAge();
        public ContractualRetirementAge pContractualRetirementAge = new ContractualRetirementAge();
        public JubileeBenefit pJubileeBenefit = new JubileeBenefit();
        public PlanDefinition_DE pPlanDefinition_DE = new PlanDefinition_DE();
        public TableManager pTableManager = new TableManager();
        public UnitFormula pUnitFormula = new UnitFormula();
        public SocialSecurityContributionRates pSocialSecurityContributionRates = new SocialSecurityContributionRates();
        public ServiceSelection pServiceSelection = new ServiceSelection();
        public ProjectAndProrate pProjectAndProrate = new ProjectAndProrate();
        public CostOfLivingAdjustments pCostOfLivingAdjustments = new CostOfLivingAdjustments();
        public FormOfPayment_DE pFormOfPayment_DE = new FormOfPayment_DE();
        public IndividualOuputFieldDefinition pIndividualOuputFieldDefinition = new IndividualOuputFieldDefinition();
        public Methods_DE pMethods_DE = new Methods_DE();
        public ReportBreaks pReportBreaks = new ReportBreaks();
        public BreakFieldTextSubstitution pBreakFieldTextSubstitution = new BreakFieldTextSubstitution();

        #endregion


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_DE001_CN()
        {
 

            #region MultiThreads

            Thread thrd_Conversion2008 = new Thread(() => new DE001_CN().t_CompareRpt_Conversion2008(sOutputPension_Conversion2008));
            Thread thrd_Pension2009 = new Thread(() => new DE001_CN().t_CompareRpt_Pension2009(sOutputPension_Pension2009));
            Thread thrd_JubileeConversion2008 = new Thread(() => new DE001_CN().t_CompareRpt_JubileeConversion2008(sOutputJubilee_JubileeConversion2008));
            Thread thrd_Jubilee2009_Baseline = new Thread(() => new DE001_CN().t_CompareRpt_Jubilee2009_Baseline(sOutputJubilee_Jubilee2009_Baseline));

            #endregion


            this.GenerateReportOuputDir();


            #region Create Client


            pMain._Initialize();

            pMain._DeleteClientIfExists(Config.sClientName, Config.iTimeout / 10);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TypeClientName", "");
            dic.Add("TreeViewClientName", "");
            dic.Add("AddClient", "Click");
            dic.Add("Title", "");
            dic.Add("DeleteClient", "");
            dic.Add("AddPlan", "");
            pMain._PopVerify_PMTool(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CustomClient", "True");
            dic.Add("MetrixClient", "");
            dic.Add("ClientName", Config.sClientName);
            dic.Add("ClientCode", "Germany BM1");
            dic.Add("FiscalYearEnd", "12/31");
            dic.Add("MeasurementDate", "09/30");
            dic.Add("Notes", "Client Owner: Karen. Original client: OGildemeister with Small Data File");
            dic.Add("DataCenter", Config.sDataCenter);
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_PMTool_Client(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TypeClientName", "");
            dic.Add("TreeViewClientName", Config.sClientName);
            dic.Add("AddClient", "");
            dic.Add("Title", "");
            dic.Add("DeleteClient", "");
            dic.Add("AddPlan", "Click");
            pMain._PopVerify_PMTool(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Country", "Germany");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_PMTool_CountrySelection(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TeilbereichName", Config.sPlanName);
            dic.Add("DefaultValuationDate", "31.12");
            dic.Add("Memo", "");
            dic.Add("Confidential", "");
            dic.Add("PublicSectorProjection", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_PMTool_TeilbereichAlle(dic);




            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            pMain._HomeTreeViewSelect(0, dic);

            _gLib._MsgBox("Mannual Interaction", "Please mannually click on plan: " + Config.sClientName + ">>" + Config.sPlanName);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("AddVOtoRegistry", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EnterVOShortName", "Jub1");
            dic.Add("ConfirmVOShortName", "Jub1");
            dic.Add("VOLongName", "Jubilee");
            dic.Add("VOClass", "Jubilee");
            dic.Add("FundingVehicle", "Direct Promise");
            dic.Add("TypeOfPromise", "Defined Benefit");
            dic.Add("Sponsor", "Employer");
            dic.Add("PSVCoverage", "");
            dic.Add("ExculdeWidowers", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccounting", "True");
            dic.Add("Apply30g", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_CreateNewVO(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("AddVOtoRegistry", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EnterVOShortName", "Pen1");
            dic.Add("ConfirmVOShortName", "Pen1");
            dic.Add("VOLongName", "Pension 1 - no exclude");
            dic.Add("VOClass", "Pension");
            dic.Add("FundingVehicle", "Direct Promise");
            dic.Add("TypeOfPromise", "Defined Benefit");
            dic.Add("Sponsor", "Employer");
            dic.Add("PSVCoverage", "True");
            dic.Add("ExculdeWidowers", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccounting", "True");
            dic.Add("Apply30g", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CreateNewVO(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("AddVOtoRegistry", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EnterVOShortName", "Pen2");
            dic.Add("ConfirmVOShortName", "Pen2");
            dic.Add("VOLongName", "Pension 2 - exclude");
            dic.Add("VOClass", "Pension");
            dic.Add("FundingVehicle", "Direct Promise");
            dic.Add("TypeOfPromise", "Defined Benefit");
            dic.Add("Sponsor", "Employer");
            dic.Add("PSVCoverage", "True");
            dic.Add("ExculdeWidowers", "True");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccounting", "True");
            dic.Add("Apply30g", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CreateNewVO(dic);


            #endregion


            #region Conversion Data service: Conversion 2008

            #region Add Data Service: Conversion 2008


            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "ParticipantData");
            pMain._HomeTreeViewSelect(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Conversion 2008");
            dic.Add("EffectiveDate", "31.12.2008");
            dic.Add("Parent", "");
            dic.Add("RSC", "");
            dic.Add("Shared", "True");
            dic.Add("GeneralUse", "");
            dic.Add("Conversion", "True");
            dic.Add("CopyDataService", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_DataServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Conversion 2008");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            #endregion


            #region Conversion 2008 - CurrentView

            pData._ts_UpdateIncludedVOs("Pen1", true);
            pData._ts_UpdateIncludedVOs("Pen2", true);


            dic.Clear();
            dic.Add("Level_1", "Conversion 2008");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);


            //Add Label : Personal Information - NetPay 
            pData._CV_ExpandPersonalInformation();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Pay");
            dic.Add("Label", "NetPay");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "01.01.2008");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            pMain._Home_ToolbarClick_Top(true);



            //Add Label : Beneficiary Information - GRSJSPct
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Beneficiary Information");
            dic.Add("Label", "GRSJSPct");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "6");
            dic.Add("DecimalPlaces", "5");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            //Add Label : Beneficiary Information - GRSJSPctFAS
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Beneficiary Information");
            dic.Add("Label", "GRSJSPctFAS");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "6");
            dic.Add("DecimalPlaces", "5");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            //Add Label : Beneficiary Information - Beneficiary1PercentFAS
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Beneficiary Information");
            dic.Add("Label", "Beneficiary1PercentFAS");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "6");
            dic.Add("DecimalPlaces", "3");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);



            //Add Label : DB Information - Exclude
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "Exclude");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Integer");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, false);

            //Add Label : DB Information - TPlan
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "TPlan");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Text");
            dic.Add("FieldLength", "10");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            //Add Label : DB Information - WaitEndDate
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "WaitEndDate");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "DateTime");
            dic.Add("FieldLength", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            //Add Label : DB Information - MNTelGRS
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "MNTelGRS");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "7");
            dic.Add("DecimalPlaces", "5");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);



            #endregion


            #region Conversion 2008 - Upload Data & Import - Import Data

            dic.Clear();
            dic.Add("Level_1", "Conversion 2008");
            dic.Add("Level_2", "Upload Data");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "Click");
            dic.Add("Upload", "");
            pData._PopVerify_UploadData(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE001\SmallData2008.XLs");
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);


            dic.Clear();
            dic.Add("Level_1", "Conversion 2008");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);


            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Import Data");
            dic.Add("FileType", "Excel file");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "SmallData2008.XLs");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("SingleTabPerRecordFile_cbo", "");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_SelectFile(dic);


            pData._SelectTab("Mapping");



            pData._IP_Mapping_Initialize("Personal Information", "DB Information", 1, 0, 1, "MembershipDate1");
            pData._IP_Mapping_Initialize("Personal Information", "Beneficiary Information", 1, 0, 1, "BeneficiaryIDNumber");
            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "IsEligible_VOParent");
            pData._IP_Mapping_Initialize("Personal Information", "Pay", 2, 10, 1, "NetPay");
            pData._IP_Mapping_Initialize("Personal Information", "NetPay", 3, 10, 1, "NetPayCurrentYear");

            pData._IP_Mapping_MapField("ParticipantStatus", "ETY", 0, false, 0);
            pData._IP_Mapping_MapField("PayStatus", "ETY", 0, true, 0);
            pData._IP_Mapping_MapField("HealthStatus", "EHEALTH", 0, true, 0);
            pData._IP_Mapping_MapField("AliveStatus", "ETY", 0, true, 0);
            pData._IP_Mapping_MapField("TerminationDate1", "PEXIT", 0, true, 0);
            pData._IP_Mapping_MapField("MaritalStatus", "ETY", 0, true, 0);
            pData._IP_Mapping_MapField("NetPayCurrentYear", "NETPAY", 0, true, 0);
            pData._IP_Mapping_MapField("GRSJSPct", "PJSPCTGE", 0, true, 0);
            pData._IP_Mapping_MapField("GRSJSPctFAS", "PJSPCT", 0, true, 0);
            pData._IP_Mapping_MapField("BenefitBeforeLastIncrease", "PRIBEN", 0, true, 0);
            pData._IP_Mapping_MapField("WaitEndDate", "WAITEND", 0, true, 0);
            pData._IP_Mapping_MapField("MNTelGRS", "MNTEL", 0, true, 0);

            //Format - ParticipantStatus
            pData._IP_Mapping_ClickEdit("ParticipantStatus", false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "AC");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "IN");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "IN");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "IN");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "IN");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "IN");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            //Format - PayStatus
            pData._IP_Mapping_ClickEdit("PayStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "DEF");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "DEF");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "PAY");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "PAY");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "PAY");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "PAY");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            //Format - AliveStatus
            pData._IP_Mapping_ClickEdit("AliveStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "XY");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "XY");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "XY");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "XY");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "XY");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "NO");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            //Format - MaritalStatus
            pData._IP_Mapping_ClickEdit("MaritalStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "M");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "M");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "M");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "M");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "S");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "S");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_Mapping(dic);


            pData._SelectTab("Validate & Load");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("ValidateData", "");
            dic.Add("LoadData", "");
            dic.Add("ValidateAndLoadData", "Click");
            pData._PopVerify_IP_ValidateAndLoad(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Data validate & load SUCCESS.");
            dic.Add("OK", "");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);


            pData._SelectTab("Matching");

            dic.Clear();
            dic.Add("Field", "EmployeeIDNumber");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "100");
            dic.Add("Unique_UniqueMatch_Num", "0");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "0");
            dic.Add("Duplicate_UniqueMatch_Num", "0");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
            dic.Add("Warehouse_NoMatch_Num", "0");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "Click");
            dic.Add("Unique_UniqueMatch", "");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "");
            dic.Add("AcceptAllRecordsAs_What", "New");
            dic.Add("AcceptSelectedRecordsAs_What", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Are you sure that you want to accept all records with a status of New");
            dic.Add("Yes", "");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "All 'UniqueNoMatch' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Matched_Num", "0");
            dic.Add("New_Num", "100");
            dic.Add("Ignored_Num", "0");
            dic.Add("Gone_Num", "0");
            dic.Add("Leaver_Num", "0");
            dic.Add("Unmatched_Num", "0");
            dic.Add("Unmerged_Num", "0");
            pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RefreshResults", "");
            dic.Add("UnacceptAllRecords", "");
            dic.Add("UnacceptSelectedRecords", "");
            dic.Add("SaveToWarehouse", "Click");
            dic.Add("MergeDuplicates", "");
            pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Once the matching results have been processed, all the Import parameters for this file will become read-only. Do you wish to proceed?");
            dic.Add("Yes", "");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "The matching results have now been processed. All the Import parameters for this file are now read-only.");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);


            #endregion


            #region Conversion 2008 - Derivation Groups - PreVal Derivations


            dic.Clear();
            dic.Add("Level_1", "Conversion 2008");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "PreVal Derivations");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            //Derivation - Benefit1DB
            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Benefit1DB");
            dic.Add("DerivedField_SearchFromIndex", "10");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PayAtTermination");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=PayAtTermination_C*12");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            //Derivation - NetPayCurrentYear
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "NetPayCurrentYear");
            dic.Add("DerivedField_SearchFromIndex", "1");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "NetPay");
            dic.Add("Level_5", "NetPayCurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=NetPayCurrentYear_C*12");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            //Derivation - Beneficiary1Percent1
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Beneficiary1Percent1");
            dic.Add("DerivedField_SearchFromIndex", "5");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "GRSJSPct");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=GRSJSPct_C*100");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            //Derivation - Beneficiary1PercentFAS
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Beneficiary1PercentFAS");
            dic.Add("DerivedField_SearchFromIndex", "6");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "GRSJSPctFAS");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=GRSJSPctFAS_C*100");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            //Derivation - LYOverwriteResults
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "5");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "LYOverwriteResults");
            dic.Add("DerivedField_SearchFromIndex", "22");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=1");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            //Derivation - IsEligible_Pen1
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "6");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "IsEligible_Pen1");
            dic.Add("DerivedField_SearchFromIndex", "2");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Exclude");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(Exclude_C<>1,1,0)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            //Derivation - IsEligible_Pen2
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "7");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "IsEligible_Pen2");
            dic.Add("DerivedField_SearchFromIndex", "2");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Exclude");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(Exclude_C=1,1,0)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);


            #endregion


            #region Conversion 2008 - Derivation Groups - DeriveUSC


            dic.Clear();
            dic.Add("Level_1", "Conversion 2008");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "DeriveUSC");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "USC");
            dic.Add("DerivedField_SearchFromIndex", "3");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ParticipantStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PayStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "HealthStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "AliveStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=DeriveUSC(ParticipantStatus_C,PayStatus_C,HealthStatus_C,AliveStatus_C)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);



            dic.Clear();
            dic.Add("Level_1", "Conversion 2008");
            dic.Add("Level_2", "Checks");
            pData._TreeViewSelect(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "Click");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);


            #endregion


            #region Conversion 2008 - Snapshots


            dic.Clear();
            dic.Add("Level_1", "Conversion 2008");
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "ValuationData");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "CashTransferTrade");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "NoPSV");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Last Year");
            dic.Add("Level_3", "LYUSC");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Last Year");
            dic.Add("Level_3", "LYTradeAL");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Last Year");
            dic.Add("Level_3", "LYTradeNC");
            pData._TreeViewSelect_Snapshots(dic, false);


            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "Click");
            dic.Add("PublishSnapshot", "Click");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_SP_Snapshots_Popup(dic);

            //pData._ts_SP_CreateExtract(sOutput_Data2012 + "Data2012_SnapshotExtract.xlsx");



            pMain._Home_ToolbarClick_Top(true);



            #endregion


            #endregion


            #region Pension Valuation - Conversion 2008



            #region Add Val Service

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "PensionValuations");
            pMain._HomeTreeViewSelect(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "True");
            dic.Add("Name", "Conversion 2008");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "2008");
            dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("SelectAllVO", "Click");
            dic.Add("DeselectAll", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Conversion 2008");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            #endregion


            #region ParticipantDataSet

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Data");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Participant DataSet");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "ValuationData");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "Click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._SelectTab("Participant DataSet");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region Add table


            pMain._Home_ToolbarClick_Top(true);




            pMain._SelectTab("Conversion 2008");

            dic.Clear();
            dic.Add("MenuItem_1", "File");
            dic.Add("MenuItem_2", "Table Manager");
            pMain._MenuSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "GildemeisterTerm");
            dic.Add("Type", "Withdrawal Decrements");
            dic.Add("Description", "");
            dic.Add("Ultimate", "");
            dic.Add("SelectAndUltimate", "");
            dic.Add("SelectPeriods", "");
            dic.Add("Generational", "");
            dic.Add("TwoDimensional", "");
            dic.Add("Index1", "");
            dic.Add("From1", "15");
            dic.Add("To1", "53");
            dic.Add("Index2", "");
            dic.Add("From2", "");
            dic.Add("To2", "");
            dic.Add("Extend", "");
            dic.Add("Zero", "True");
            dic.Add("SameRatesUsed", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("Use1000Separator", "");
            pTableManager._ts_AddTable(dic);


            string sGildemeisterTerm_Male = "";
            pTableManager._SelectTab("Male Rates");
            _gLib._KillProcessByName("EXCEL");
            MyExcel _excelRead = new MyExcel(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE001\GildemeisterTerm.xlsx", false);
            _excelRead.OpenExcelFile("Male Rates");
            for (int i = 2; i <= 40; i++)
                sGildemeisterTerm_Male = sGildemeisterTerm_Male + _excelRead.getOneCellValue(i, 2) + Environment.NewLine;
            _excelRead.SaveExcel();
            _excelRead.CloseExcelApplication();
            pTableManager._ts_PasteValue(sGildemeisterTerm_Male);

            pMain._Home_ToolbarClick_Top(true);


            string sGildemeisterTerm_Female = "";
            pTableManager._SelectTab("Female Rates");
            _gLib._KillProcessByName("EXCEL");
            _excelRead = new MyExcel(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE001\GildemeisterTerm.xlsx", false);
            _excelRead.OpenExcelFile("Female Rates");
            for (int i = 2; i <= 40; i++)
                sGildemeisterTerm_Female = sGildemeisterTerm_Female + _excelRead.getOneCellValue(i, 2) + Environment.NewLine;
            _excelRead.SaveExcel();
            _excelRead.CloseExcelApplication();
            pTableManager._ts_PasteValue(sGildemeisterTerm_Female);

            pMain._Home_ToolbarClick_Top(true);


            ////////////_gLib._MsgBox("Warning !!!", "Please Add table GildemeisterTerm, set as Withdrawal Decrements, From 15 to 53, Click on Zero and click OK");
            ////////////_gLib._MsgBox("Warning !!!", "Please open the file GildemeisterTerm.xlsx under \\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\\AUTs\\RetirementStudio\\DataFile\\DE001\\ . Copy the data of Male and Female into system");


            #endregion


            #region Assumptions


            pMain._SelectTab("Conversion 2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");


            //Conversion 2008 - Assumptions - Tax - Assumed Retirement Age

            pAssumptions._TreeView_SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Assumed Retirement Age");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FromData", "True");
            dic.Add("CustomCode", "");
            dic.Add("AssumedRetirementAge_V", "Click");
            dic.Add("AssumedRetirementAge_C", "");
            dic.Add("AssumedRetirementAge_cbo", "AssumedRetirementAge");
            dic.Add("AssumedRetirementAge_txt", "");
            pAssumedRetirementAge._PopVerify_FromData(dic);


            //Conversion 2008 - Assumptions - Tax - Social Security Contribution Rates
            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Social Security Contribution Rates");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("Other", "True");
            dic.Add("AsOfDate", "");
            dic.Add("HealthInsuranceContribionRate_Employer", "7,30");
            dic.Add("HealthInsuranceReducedRate_Employer", "7,00");
            dic.Add("CareInsuranceContributionRate_Employer", "0,975");
            dic.Add("SocialSecurityContributionRateRV_EE", "9,80");
            dic.Add("SocialSecurityContributionRateKnappschaft_EE", "9,80");
            dic.Add("HealthInsuranceContribionRate_EE", "8,20");
            dic.Add("HealthInsuranceReducedRate_EE", "7,30");
            dic.Add("UnemploymentInsuranceContributionRate_EE", "0,00");
            dic.Add("CareInsuranceContributionRate_EE", "1,225");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);


            //////////////////_gLib._MsgBox("Warning !!!", "Please Click Other, set SSCRRV_Employee as 9,80; SSCRKnappschaft_Employee as 9,80; HealthInsuranceContribution_Employer as 7,30");
            //////////////////_gLib._MsgBox("Warning !!!", "Please set HealthInsuranceContribution_Employee as 8,20; HealthInsuranceReduced_Employer as 7,00; HealthInsuranceReduced_Employee as 7,30");
            //////////////////_gLib._MsgBox("Warning !!!", "Please set UnemploymentInsuranceRate_Employee as 0,00; CareInsurance_Employer as 0,975; CareInsurance_Employee as 1,225");


            //Conversion 2008 - Assumptions - Tax - Other Economic Assumptions
            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("WorkingDaysPerYear", "");
            dic.Add("AdjustFactorrFromNextToGross", "");
            dic.Add("TaxTariff", "2010");
            dic.Add("SoliTaxRate", "");
            dic.Add("ChurchTaxRate", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_DE(dic);

            //Conversion 2008 - Assumptions - Trade - Assumed Retirement Age
            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Assumed Retirement Age");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FromData", "True");
            dic.Add("CustomCode", "");
            dic.Add("AssumedRetirementAge_V", "Click");
            dic.Add("AssumedRetirementAge_C", "");
            dic.Add("AssumedRetirementAge_cbo", "AssumedRetirementAge");
            dic.Add("AssumedRetirementAge_txt", "");
            pAssumedRetirementAge._PopVerify_FromData(dic);


            //Conversion 2008 - Assumptions - Trade - Social Security Contribution Rates
            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Social Security Contribution Rates");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("Other", "True");
            dic.Add("AsOfDate", "");
            dic.Add("HealthInsuranceContribionRate_Employer", "7,30");
            dic.Add("HealthInsuranceReducedRate_Employer", "7,00");
            dic.Add("CareInsuranceContributionRate_Employer", "0,975");
            dic.Add("SocialSecurityContributionRateRV_EE", "9,80");
            dic.Add("SocialSecurityContributionRateKnappschaft_EE", "9,80");
            dic.Add("HealthInsuranceContribionRate_EE", "8,20");
            dic.Add("HealthInsuranceReducedRate_EE", "7,30");
            dic.Add("UnemploymentInsuranceContributionRate_EE", "0,00");
            dic.Add("CareInsuranceContributionRate_EE", "1,225");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);


            ////////_gLib._MsgBox("Warning !!!", "Please Click Other, set SSCRRV_Employee as 9,80; SSCRKnappschaft_Employee as 9,80; HealthInsuranceContribution_Employer as 7,30");
            ////////_gLib._MsgBox("Warning !!!", "Please set HealthInsuranceContribution_Employee as 8,20; HealthInsuranceReduced_Employer as 7,00; HealthInsuranceReduced_Employee as 7,30");
            ////////_gLib._MsgBox("Warning !!!", "Please set UnemploymentInsuranceRate_Employee as 0,00; CareInsurance_Employer as 0,975; CareInsurance_Employee as 1,225");


            //Conversion 2008 - Assumptions - Trade - Other Economic Assumptions
            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("WorkingDaysPerYear", "");
            dic.Add("AdjustFactorrFromNextToGross", "");
            dic.Add("TaxTariff", "2010");
            dic.Add("SoliTaxRate", "");
            dic.Add("ChurchTaxRate", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_DE(dic);

            //Conversion 2008 - Assumptions - IntAccounting - Assumed Retirement Age

            pAssumptions._TreeView_SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Assumed Retirement Age");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FromData", "True");
            dic.Add("CustomCode", "");
            dic.Add("AssumedRetirementAge_V", "Click");
            dic.Add("AssumedRetirementAge_C", "");
            dic.Add("AssumedRetirementAge_cbo", "AssumedRetirementAge");
            dic.Add("AssumedRetirementAge_txt", "");
            pAssumedRetirementAge._PopVerify_FromData(dic);

            //Conversion 2008 - Assumptions - IntAccounting - Interest Rate
            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "6,2");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            //Conversion 2008 - Assumptions - IntAccounting - Pay Increase - SalaryScale

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("MenuItem", "Add Pay Increase");
            pAssumptions._TreeViewRightSelect(dic, "SalaryScale");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryScale");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "Click");
            dic.Add("btnT", "");
            dic.Add("txtRate", "3,0");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "");
            dic.Add("btnT", "");
            dic.Add("txtRate", "3,0");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);


            //////Conversion 2008 - Assumptions - IntAccounting - Cost of Living Increase

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Cost of Living Increase");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "Click");
            dic.Add("btnT", "");
            dic.Add("txtRate", "2,0");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "");
            dic.Add("btnT", "");
            dic.Add("txtRate", "2,0");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);



            //////Conversion 2008 - Assumptions - IntAccounting - Social Security Contribution Rates

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Social Security Contribution Rates");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("Other", "True");
            dic.Add("AsOfDate", "");
            dic.Add("HealthInsuranceContribionRate_Employer", "7,30");
            dic.Add("HealthInsuranceReducedRate_Employer", "7,00");
            dic.Add("CareInsuranceContributionRate_Employer", "0,975");
            dic.Add("SocialSecurityContributionRateRV_EE", "9,80");
            dic.Add("SocialSecurityContributionRateKnappschaft_EE", "9,80");
            dic.Add("HealthInsuranceContribionRate_EE", "8,20");
            dic.Add("HealthInsuranceReducedRate_EE", "7,30");
            dic.Add("UnemploymentInsuranceContributionRate_EE", "0,00");
            dic.Add("CareInsuranceContributionRate_EE", "1,225");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("Other", "True");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "GildemeisterTerm");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);


            pMain._Home_ToolbarClick_Top(true);


            ////////////////////////////////added/////


            //////pAssumptions._TreeView_SelectTab("Tax");

            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Other Demographic Assumptions");
            //////dic.Add("Level_3", "Default");
            //////pAssumptions._TreeViewSelect(dic);

            //////_gLib._MsgBox("", "set as ''Heubeck 2005 G''");


            //////pAssumptions._TreeView_SelectTab("Trade");

            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Other Demographic Assumptions");
            //////dic.Add("Level_3", "Default");
            //////pAssumptions._TreeViewSelect(dic);

            //////_gLib._MsgBox("", "set as ''Heubeck 2005 G''");



            //////pAssumptions._TreeView_SelectTab("IntAccounting");

            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Other Demographic Assumptions");
            //////dic.Add("Level_3", "Default");
            //////pAssumptions._TreeViewSelect(dic);

            //////_gLib._MsgBox("", "set as ''Heubeck 2005 G''");




            //////pAssumptions._TreeView_SelectTab("Tax");

            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Mortality Decrement");
            //////dic.Add("Level_3", "USC40");
            //////pAssumptions._TreeViewSelect(dic);


            //////_gLib._MsgBox("", "set values as: " + Environment.NewLine
            //////    + "Pre-decrement:      GesamtRetireeDeath_HB05QRX" + Environment.NewLine
            //////    + "Pre-commencement:   GesamtRetireeDeath_HB05QRX    " + Environment.NewLine
            //////    + "Post-commencement:  GesamtRetireeDeath_HB05QRX " + Environment.NewLine
            //////    + "Spouse:             WidowDeath_HB05QWX");


            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Mortality Decrement");
            //////dic.Add("Level_3", "Default");
            //////pAssumptions._TreeViewSelect(dic);

            //////_gLib._MsgBox("", "set values as: " + Environment.NewLine +
            //////  " ''Heubeck 2005 G''");



            //////pAssumptions._TreeView_SelectTab("Trade");


            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Mortality Decrement");
            //////dic.Add("Level_3", "USC40");
            //////pAssumptions._TreeViewSelect(dic);


            //////_gLib._MsgBox("", "set values as: " + Environment.NewLine
            //////    + "Pre-decrement:      GesamtRetireeDeath_HB05QRX" + Environment.NewLine
            //////    + "Pre-commencement:   GesamtRetireeDeath_HB05QRX    " + Environment.NewLine
            //////    + "Post-commencement:  GesamtRetireeDeath_HB05QRX " + Environment.NewLine
            //////    + "Spouse:             WidowDeath_HB05QWX");


            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Mortality Decrement");
            //////dic.Add("Level_3", "Default");
            //////pAssumptions._TreeViewSelect(dic);

            //////_gLib._MsgBox("", "set values as: " + Environment.NewLine +
            //////  " ''Heubeck 2005 G''");



            //////pAssumptions._TreeView_SelectTab("IntAccounting");

            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Mortality Decrement");
            //////dic.Add("Level_3", "USC40");
            //////pAssumptions._TreeViewSelect(dic);


            //////_gLib._MsgBox("", "set values as: " + Environment.NewLine
            //////    + "Pre-decrement:      GesamtRetireeDeath_HB05QRX" + Environment.NewLine
            //////    + "Pre-commencement:   GesamtRetireeDeath_HB05QRX    " + Environment.NewLine
            //////    + "Post-commencement:  GesamtRetireeDeath_HB05QRX " + Environment.NewLine
            //////    + "Spouse:             WidowDeath_HB05QWX");


            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Mortality Decrement");
            //////dic.Add("Level_3", "Default");
            //////pAssumptions._TreeViewSelect(dic);

            //////_gLib._MsgBox("", "set values as: " + Environment.NewLine +
            //////  " ''Heubeck 2005 G''");





            //////pAssumptions._TreeView_SelectTab("Tax");

            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Disability Decrement");
            //////dic.Add("Level_3", "Default");
            //////pAssumptions._TreeViewSelect(dic);


            //////_gLib._MsgBox("", "set values as: " + Environment.NewLine +
            //////  " ''Heubeck 2005 G''");


            //////pAssumptions._TreeView_SelectTab("Trade");



            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Disability Decrement");
            //////dic.Add("Level_3", "Default");
            //////pAssumptions._TreeViewSelect(dic);


            //////_gLib._MsgBox("", "set values as: " + Environment.NewLine +
            //////  " ''Heubeck 2005 G''");



            //////pAssumptions._TreeView_SelectTab("IntAccounting");


            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Disability Decrement");
            //////dic.Add("Level_3", "Default");
            //////pAssumptions._TreeViewSelect(dic);


            //////_gLib._MsgBox("", "set values as: " + Environment.NewLine +
            //////  " ''Heubeck 2005 G''");


            //////pMain._Home_ToolbarClick_Top(true);
            //////pMain._Home_ToolbarClick_Top(false);


            /////////////////////////////////////


            #endregion


            #region Conversion 2008 - Common Update Code for DE - Update Assumptions

            pMain._SelectTab("Assumptions");

            pAssumptions._TreeView_SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("cboPrescribedRates", "Heubeck 2005 G");
            dic.Add("ApplyPercentMarriedAt", "");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "");
            dic.Add("txtPercentMarried_F", "");
            dic.Add("cboPercentMarried", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "");
            dic.Add("txtDifferenceInSpouseAge_F", "");
            dic.Add("cboDifferenceInSpouseAge", "");
            dic.Add("DifferenceInOrphanAge", "");
            dic.Add("NumberOfChildren", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);


            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("cboPrescribedRates", "Heubeck 2005 G");
            dic.Add("ApplyPercentMarriedAt", "");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "");
            dic.Add("txtPercentMarried_F", "");
            dic.Add("cboPercentMarried", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "");
            dic.Add("txtDifferenceInSpouseAge_F", "");
            dic.Add("cboDifferenceInSpouseAge", "");
            dic.Add("DifferenceInOrphanAge", "");
            dic.Add("NumberOfChildren", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);


            pAssumptions._TreeView_SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("cboPrescribedRates", "Heubeck 2005 G");
            dic.Add("ApplyPercentMarriedAt", "");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "");
            dic.Add("txtPercentMarried_F", "");
            dic.Add("cboPercentMarried", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "");
            dic.Add("txtDifferenceInSpouseAge_F", "");
            dic.Add("cboDifferenceInSpouseAge", "");
            dic.Add("DifferenceInOrphanAge", "");
            dic.Add("NumberOfChildren", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);


            pAssumptions._TreeView_SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pAssumptions._TreeView_SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);



            pAssumptions._TreeView_SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Other", "True");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERODIS");
            dic.Add("Service", "");
            dic.Add("AdjustmentOperator", "");
            dic.Add("Adjustment_C", "");
            dic.Add("Adjustment_P", "");
            dic.Add("Adjustment_T", "");
            dic.Add("Adjustment_txt", "");
            dic.Add("Adjustment_Tcbo", "");
            dic.Add("Adjustment_Tcbo_extend", "");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Other", "True");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERODIS");
            dic.Add("Service", "");
            dic.Add("AdjustmentOperator", "");
            dic.Add("Adjustment_C", "");
            dic.Add("Adjustment_P", "");
            dic.Add("Adjustment_T", "");
            dic.Add("Adjustment_txt", "");
            dic.Add("Adjustment_Tcbo", "");
            dic.Add("Adjustment_Tcbo_extend", "");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pAssumptions._TreeView_SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Other", "True");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERODIS");
            dic.Add("Service", "");
            dic.Add("AdjustmentOperator", "");
            dic.Add("Adjustment_C", "");
            dic.Add("Adjustment_P", "");
            dic.Add("Adjustment_T", "");
            dic.Add("Adjustment_txt", "");
            dic.Add("Adjustment_Tcbo", "");
            dic.Add("Adjustment_Tcbo_extend", "");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);



            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region Provisions

            pMain._SelectTab("Conversion 2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Provisions");

            //Conversion 2008  - Global Provisions - Service - WaitingService - Default
            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "WaitingService");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "WaitingService");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("RulesBasedService", "True");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            pService._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Date", "WaitingPeriodStartDate");
            dic.Add("CalculationMethod", "Valuation date");
            dic.Add("RoundingPeriod", "Years");
            dic.Add("RoundingMethod", "Completed");
            pService._PopVerify_RulesBasedService_DE(dic);



            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "WaitingService");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "WithWaitEnd");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Date", "WaitEndDate");
            dic.Add("CalculationMethod", "Valuation date");
            dic.Add("RoundingPeriod", "Years");
            dic.Add("RoundingMethod", "Completed");
            pService._PopVerify_RulesBasedService_DE(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.TPlan = \"MAHO\" or $emp.TPlan = \"DECK\" or $emp.TPlan = \"GESA2\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "WaitingService");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Deferreds");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Date", "WaitingPeriodStartDate");
            dic.Add("CalculationMethod", "Valuation date");
            dic.Add("RoundingPeriod", "Years");
            dic.Add("RoundingMethod", "Completed");
            pService._PopVerify_RulesBasedService_DE(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.ParticipantStatus = \"IN\" and $emp.PayStatus = \"DEF\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "BenefitService");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BenefitService");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            pService._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "Click");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "Click");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "65");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Valuation date");
            dic.Add("RoundingPeriod", "");
            dic.Add("RoundingMethod", "Exact");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BenefitService");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "EINZEPlan");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "Click");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "Click");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "65");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Valuation date");
            dic.Add("RoundingPeriod", "Years");
            dic.Add("RoundingMethod", "");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.TPlan = \"EINZE\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BenefitService");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "GESA1Plan");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "Click");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "Click");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "65");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "");
            dic.Add("RoundingPeriod", "Years");
            dic.Add("RoundingMethod", "");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.TPlan = \"GESA1\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BenefitService");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "CompMos");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "Click");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "Click");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "65");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Valuation date");
            dic.Add("RoundingPeriod", "Months");
            dic.Add("RoundingMethod", "Completed");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.TPlan = \"GESAM\" or $emp.TPlan = \"GESMM\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "MNTelNumerator");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "MNTelNumerator");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "31.12.1994");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Valuation date");
            dic.Add("RoundingPeriod", "Months");
            dic.Add("RoundingMethod", "");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "MNTelNumerator");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "BALZ2");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "31.12.1996");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Valuation date");
            dic.Add("RoundingPeriod", "Months");
            dic.Add("RoundingMethod", "Commenced");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);



            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.TPlan = \"BALZ2\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "MNTelNumerator");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "GESMM");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "31.12.1993");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Valuation date");
            dic.Add("RoundingPeriod", "Months");
            dic.Add("RoundingMethod", "");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.TPlan = \"GESMM\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "MNTelNumerator");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Deferreds");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "HireDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "TerminationDate1");
            dic.Add("CalculationMethod", "Fixed date");
            dic.Add("RoundingPeriod", "");
            dic.Add("RoundingMethod", "");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.ParticipantStatus = \"IN\" and $emp.PayStatus = \"DEF\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "MNTelService");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "MNTelService");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Date", "");
            dic.Add("CalculationMethod", "Valuation date");
            dic.Add("RoundingPeriod", "Months");
            dic.Add("RoundingMethod", "Exact");
            pService._PopVerify_RulesBasedService_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "MNTelService");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "ForDeferreds");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Date", "HireDate1");
            dic.Add("CalculationMethod", "Fixed date");
            dic.Add("RoundingPeriod", "Months");
            dic.Add("RoundingMethod", "Completed");
            pService._PopVerify_RulesBasedService_DE(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.ParticipantStatus = \"IN\" and $emp.PayStatus = \"DEF\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "FASService");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "FASService");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            dic.Add("ForInternationalAccounting_DE", "True");
            dic.Add("ForTrade_DE", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "HireDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "31.12.1995");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Valuation date");
            dic.Add("RoundingPeriod", "");
            dic.Add("RoundingMethod", "Exact");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "FASService");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "BALZ2");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "HireDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "31.12.1996");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Valuation date");
            dic.Add("RoundingPeriod", "");
            dic.Add("RoundingMethod", "Exact");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.TPlan = \"BALZ2\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "FASService");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "GESA1orM");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            pService._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "HireDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "31.12.1994");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Valuation date");
            dic.Add("RoundingPeriod", "");
            dic.Add("RoundingMethod", "Exact");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.TPlan = \"GESA1\" or $emp.TPlan = \"GESAM\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "FASService");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "GESMM");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "HireDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "31.12.1993");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Valuation date");
            dic.Add("RoundingPeriod", "");
            dic.Add("RoundingMethod", "Exact");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.TPlan = \"GESMM\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "FASService");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "VORST");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "HireDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Valuation date");
            dic.Add("RoundingPeriod", "");
            dic.Add("RoundingMethod", "Exact");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "HireDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Valuation date");
            dic.Add("RoundingPeriod", "");
            dic.Add("RoundingMethod", "Exact");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);



            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.TPlan = \"VORST\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "ServiceFromHire");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "ServiceFromHire");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Date", "HireDate1");
            dic.Add("CalculationMethod", "Valuation date");
            dic.Add("RoundingPeriod", "");
            dic.Add("RoundingMethod", "Exact");
            pService._PopVerify_RulesBasedService_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "MembershipAge");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "MembershipAge");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "MembershipDate1");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "AgeEligible");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "AgeEligible");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "15");
            dic.Add("YearOfService", "0");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "WaitingPeriodStartDate");
            dic.Add("ServiceBasedOn", "WaitingService");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);

            dic.Clear();
            dic.Add("Comparison", "Later of");
            dic.Add("FromToAge", "MembershipAge");
            pFromToAge._Standard_CompareAboveResultsTable(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "AgeEligible");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "With10Years");

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "15");
            dic.Add("YearOfService", "10");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "WaitingService");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);

            dic.Clear();
            dic.Add("Comparison", "Later of");
            dic.Add("FromToAge", "MembershipAge");
            pFromToAge._Standard_CompareAboveResultsTable(dic);



            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.TPlan = \"GESA1\" or $emp.TPlan = \"BALZ1\" or $emp.TPlan = \"BALZ2\" or $emp.TPlan = \"GESAM\" or $emp.TPlan = \"GESMM\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "AgeEligible");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "WaitEnd");

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "15");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "WaitEndDate");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);

            dic.Clear();
            dic.Add("Comparison", "Later of");
            dic.Add("FromToAge", "MembershipAge");
            pFromToAge._Standard_CompareAboveResultsTable(dic);



            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.TPlan = \"MAHO\" or $emp.TPlan = \"DECK\" or $emp.TPlan = \"GESA2\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "LaterOf65ValAge");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "LaterOf65ValAge");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "65");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "$ValDate");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "BenefitEligible");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "BenefitEligible");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$Age >= $AgeEligible");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);



            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "WithdrawalElig");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "WithdrawalElig");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$_LegalVesting and $Age <= $_ContractualRetirementAge");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "ProjectedPay");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "ProjectedPay");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataFieldContainingPayHistory", "NetPay");
            dic.Add("PayIncreaseAssumption", "SalaryScale");
            dic.Add("UseOnlyDataFields", "");
            dic.Add("rdValuationYearPlus", "");
            dic.Add("txtValuationYearPlus", "");
            dic.Add("rdSpecifiedYear", "");
            dic.Add("txtSpecifiedYear", "");
            dic.Add("ApplyEGTRRALimits", "");
            pPayoutProjection._PopVerify_History(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service Selection");
            dic.Add("MenuItem", "Add Service Selection");
            pAssumptions._TreeViewRightSelect(dic, "BenService65");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service Selection");
            dic.Add("Level_3", "BenService65");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("BaseServiceProjection", "BenefitService");
            dic.Add("V", "Click");
            dic.Add("C", "");
            dic.Add("SelectServiceAtAge_cbo", "LaterOf65ValAge");
            dic.Add("SelectServiceAtAge_txt", "");
            pServiceSelection._PopVerify_ServiceSelection(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service Selection");
            dic.Add("MenuItem", "Add Service Selection");
            pAssumptions._TreeViewRightSelect(dic, "MNTelDenominator");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service Selection");
            dic.Add("Level_3", "MNTelDenominator");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("BaseServiceProjection", "MNTelService");
            dic.Add("V", "");
            dic.Add("C", "");
            dic.Add("SelectServiceAtAge_cbo", "");
            dic.Add("SelectServiceAtAge_txt", "");
            pServiceSelection._PopVerify_ServiceSelection(dic);



            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service Selection");
            dic.Add("Level_3", "MNTelDenominator");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "AtCRetage");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("BaseServiceProjection", "MNTelService");
            dic.Add("V", "Click");
            dic.Add("C", "");
            dic.Add("SelectServiceAtAge_cbo", "_ContractualRetirementAge");
            dic.Add("SelectServiceAtAge_txt", "");
            pServiceSelection._PopVerify_ServiceSelection(dic);



            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.ParticipantStatus = \"IN\" and $emp.PayStatus = \"DEF\" or $emp.TPlan = \"BALZ2\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service Selection");
            dic.Add("MenuItem", "Add Service Selection");
            pAssumptions._TreeViewRightSelect(dic, "ServiceCRet");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service Selection");
            dic.Add("Level_3", "ServiceCRet");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("BaseServiceProjection", "ServiceFromHire");
            dic.Add("V", "Click");
            dic.Add("C", "");
            dic.Add("SelectServiceAtAge_cbo", "_ContractualRetirementAge");
            dic.Add("SelectServiceAtAge_txt", "");
            pServiceSelection._PopVerify_ServiceSelection(dic);



            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Project and Prorate");
            dic.Add("MenuItem", "Add Project and Prorate");
            pAssumptions._TreeViewRightSelect(dic, "PlanMNTel");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Project and Prorate");
            dic.Add("Level_3", "PlanMNTel");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceForProration", "MNTelNumerator");
            dic.Add("ServiceSelectionForProration", "MNTelDenominator");
            pProjectAndProrate._PopVerify_ProjectAndProrate(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Project and Prorate");
            dic.Add("MenuItem", "Add Project and Prorate");
            pAssumptions._TreeViewRightSelect(dic, "ForFASWith");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Project and Prorate");
            dic.Add("Level_3", "ForFASWith");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceForProration", "ServiceFromHire");
            dic.Add("ServiceSelectionForProration", "ServiceCRet");
            pProjectAndProrate._PopVerify_ProjectAndProrate(dic);






            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            pAssumptions._Collapse(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Contractual Retirement Age");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("FixedAge_V", "Click");
            dic.Add("FixedAge_C", "");
            dic.Add("FixedAge_cbo", "ContractualRetAge");
            dic.Add("FixedAge_txt", "");
            pContractualRetirementAge._PopVerify_ContractualRetirementAge(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Participant Info");
            pAssumptions._Collapse(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "AccruedBenefit");


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "AccruedBenefit");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$ProjectedPay");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "AccruedBenefit");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "EINZE1");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "(Min($BenService65,5) * 0.08 + Min(Max($BenService65 - 5.0,0.0),10.0) * 0.04 + Min(Max($BenService65 - 15.0,0.0),10.0) * 0.02) * $ProjectedPay * $emp.MNTelGRS");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "($emp.TPlan=\"EINZE\"and $emp.MembershipDate1<ToDate(1995,1,1)) or ($emp.BirthDate=\"02/28/1950\"and $emp.HireDate1=\"04/01/1990\")");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "AccruedBenefit");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "BALZ2");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "3.07 * 12.0 * $BenefitService * $emp.MNTelGRS");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.TPlan = \"BALZ2\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "AccruedBenefit");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "BALZ2CashTrns");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "3.07 * 12.0 * $BenService65 * $emp.MNTelGRS");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.TPlan = \"BALZ2\" and $emp.CashTransfer = 0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "AccruedBenefit");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "VOSRT");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0.45 * $ProjectedPay");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.TPlan = \"VORST\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "AccruedBenefit");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "GESA1orM");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$ProjectedPay / 12.0 * Round($BenService65,0) * $emp.MNTelGRS");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.TPlan = \"GESA1\" or $emp.TPlan = \"GESAM\" or $emp.TPlan = \"GESMM\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "AccruedBenefit");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "InactDeferreds");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.PayAtTermination * 12.0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.ParticipantStatus = \"IN\" and $emp.PayStatus = \"DEF\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            pAssumptions._Collapse(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "BenCOLA");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Cost of Living Adjustments");
            dic.Add("Level_5", "BenCOLA");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("COLABegin_Active_PaymentsFrom", "");
            dic.Add("COLABegin_Active_Age", "15");
            dic.Add("COLABegin_Active_Date", "");
            dic.Add("COLADuring_V", "");
            dic.Add("COLADuring_P", "Click");
            dic.Add("COLADuring_T", "");
            dic.Add("COLADuring_Rate_cbo", "");
            dic.Add("COLADuring_Rate_txt", "");
            dic.Add("COLAAfter_V", "Click");
            dic.Add("COLAAfter_P", "");
            dic.Add("COLAAfter_T", "");
            dic.Add("COLAAfter_Rate_cbo", "CostOfLivingIncreaseAssumption");
            dic.Add("COLAAfter_Rate_txt", "");
            pCostOfLivingAdjustments._PopVerify_CostOfLivingAdjustments_DE(dic);


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "Life");


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "Reversionary");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "Reversionary");
            dic.Add("MenuItem", "Add New Liability Type Folder");
            pAssumptions._TreeViewRightSelect(dic, "");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "IntAcctRev");
            dic.Add("IntlAccountingABO", "True");
            dic.Add("IntlAccountingPBO", "True");
            dic.Add("Tax", "");
            dic.Add("Trade", "");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "Reversionary");
            dic.Add("Level_6", "IntAcctRev");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Reversionary");
            dic.Add("NumOfPayPerYear_V", "");
            dic.Add("NumOfPayPerYear_C", "");
            dic.Add("SurvivorPercentOrAmount_V", "Click");
            dic.Add("SurvivorPercentOrAmount_P", "");
            dic.Add("NumOfPayPerYear_cbo", "");
            dic.Add("NumOfPayPerYear_txt", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "Beneficiary1PercentFAS");
            dic.Add("SurvivorPercentOrAmount_txt", "");
            pFormOfPayment_DE._PopVerify_FormOfPayment(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "Reversionary");
            dic.Add("Level_6", "AllOthers");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Reversionary");
            dic.Add("NumOfPayPerYear_V", "");
            dic.Add("NumOfPayPerYear_C", "");
            dic.Add("SurvivorPercentOrAmount_V", "Click");
            dic.Add("SurvivorPercentOrAmount_P", "");
            dic.Add("NumOfPayPerYear_cbo", "");
            dic.Add("NumOfPayPerYear_txt", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "Beneficiary1Percent1");
            dic.Add("SurvivorPercentOrAmount_txt", "");
            pFormOfPayment_DE._PopVerify_FormOfPayment(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "Spouse");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "Spouse");
            dic.Add("MenuItem", "Add New Liability Type Folder");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "IntAcctSps");
            dic.Add("IntlAccountingABO", "True");
            dic.Add("IntlAccountingPBO", "True");
            dic.Add("Tax", "");
            dic.Add("Trade", "");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "Spouse");
            dic.Add("Level_6", "IntAcctSps");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Spouse's");
            dic.Add("NumOfPayPerYear_V", "");
            dic.Add("NumOfPayPerYear_C", "");
            dic.Add("SurvivorPercentOrAmount_V", "Click");
            dic.Add("SurvivorPercentOrAmount_P", "");
            dic.Add("NumOfPayPerYear_cbo", "");
            dic.Add("NumOfPayPerYear_txt", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "Beneficiary1PercentFAS");
            dic.Add("SurvivorPercentOrAmount_txt", "");
            pFormOfPayment_DE._PopVerify_FormOfPayment(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "Spouse");
            dic.Add("Level_6", "AllOthers");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Spouse's");
            dic.Add("NumOfPayPerYear_V", "");
            dic.Add("NumOfPayPerYear_C", "");
            dic.Add("SurvivorPercentOrAmount_V", "Click");
            dic.Add("SurvivorPercentOrAmount_P", "");
            dic.Add("NumOfPayPerYear_cbo", "");
            dic.Add("NumOfPayPerYear_txt", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "Beneficiary1Percent1");
            dic.Add("SurvivorPercentOrAmount_txt", "");
            pFormOfPayment_DE._PopVerify_FormOfPayment(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "OrphanFOP");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "OrphanFOP");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Immediate orphan annuity");
            dic.Add("NumOfPayPerYear_V", "");
            dic.Add("NumOfPayPerYear_C", "");
            dic.Add("NumOfPayPerYear_cbo", "");
            dic.Add("NumOfPayPerYear_txt", "");
            dic.Add("LastPaymentAge_V", "");
            dic.Add("LastPaymentAge_C", "Click");
            dic.Add("MaximumPaymentAge_V", "");
            dic.Add("MaximumPaymentAge_C", "Click");
            dic.Add("LastPaymentAge_txt", "26");
            dic.Add("MaximumPaymentAge_txt", "26");
            pFormOfPayment_DE._PopVerify_FormOfPayment(dic);



            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Provisions");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "RetLife");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "RetLife");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "AccruedBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("BenefitCommencementAge_V", "");
            dic.Add("BenefitCommencementAge_C", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("FirstStartAge_V", "");
            dic.Add("FirstStartAge_C", "");
            dic.Add("LastStartAge_V", "");
            dic.Add("LastStartAge_C", "");
            dic.Add("NumberOfPayments_V", "");
            dic.Add("NumberOfPayments_C", "");
            dic.Add("MaximumNumberOfPayments_V", "");
            dic.Add("MaximumNumberOfPayments_C", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("FirstStartAge_cbo", "");
            dic.Add("FirstStartAge_txt", "");
            dic.Add("LastStartAge_cbo", "");
            dic.Add("LastStartAge_txt", "");
            dic.Add("NumberOfPayments_cbo", "");
            dic.Add("NumberOfPayments_txt", "");
            dic.Add("MaximumNumberOfPayments_cbo", "");
            dic.Add("MaximumNumberOfPayments_txt", "");
            dic.Add("Eligibility", "BenefitEligible");
            dic.Add("VestedRatio", "");
            dic.Add("CostOfLivingAdjustment", "BenCOLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "Life");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "Retirement");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "RetReversionary");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "RetReversionary");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "AccruedBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("BenefitCommencementAge_V", "");
            dic.Add("BenefitCommencementAge_C", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("FirstStartAge_V", "");
            dic.Add("FirstStartAge_C", "");
            dic.Add("LastStartAge_V", "");
            dic.Add("LastStartAge_C", "");
            dic.Add("NumberOfPayments_V", "");
            dic.Add("NumberOfPayments_C", "");
            dic.Add("MaximumNumberOfPayments_V", "");
            dic.Add("MaximumNumberOfPayments_C", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("FirstStartAge_cbo", "");
            dic.Add("FirstStartAge_txt", "");
            dic.Add("LastStartAge_cbo", "");
            dic.Add("LastStartAge_txt", "");
            dic.Add("NumberOfPayments_cbo", "");
            dic.Add("NumberOfPayments_txt", "");
            dic.Add("MaximumNumberOfPayments_cbo", "");
            dic.Add("MaximumNumberOfPayments_txt", "");
            dic.Add("Eligibility", "BenefitEligible");
            dic.Add("VestedRatio", "");
            dic.Add("CostOfLivingAdjustment", "BenCOLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "Reversionary");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "Retirement");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "DisLife");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "DisLife");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "AccruedBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("BenefitCommencementAge_V", "");
            dic.Add("BenefitCommencementAge_C", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("FirstStartAge_V", "");
            dic.Add("FirstStartAge_C", "");
            dic.Add("LastStartAge_V", "");
            dic.Add("LastStartAge_C", "");
            dic.Add("NumberOfPayments_V", "");
            dic.Add("NumberOfPayments_C", "");
            dic.Add("MaximumNumberOfPayments_V", "");
            dic.Add("MaximumNumberOfPayments_C", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("FirstStartAge_cbo", "");
            dic.Add("FirstStartAge_txt", "");
            dic.Add("LastStartAge_cbo", "");
            dic.Add("LastStartAge_txt", "");
            dic.Add("NumberOfPayments_cbo", "");
            dic.Add("NumberOfPayments_txt", "");
            dic.Add("MaximumNumberOfPayments_cbo", "");
            dic.Add("MaximumNumberOfPayments_txt", "");
            dic.Add("Eligibility", "BenefitEligible");
            dic.Add("VestedRatio", "");
            dic.Add("CostOfLivingAdjustment", "BenCOLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "Life");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "Disability");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "DisReversionary");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "DisReversionary");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "AccruedBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("BenefitCommencementAge_V", "");
            dic.Add("BenefitCommencementAge_C", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("FirstStartAge_V", "");
            dic.Add("FirstStartAge_C", "");
            dic.Add("LastStartAge_V", "");
            dic.Add("LastStartAge_C", "");
            dic.Add("NumberOfPayments_V", "");
            dic.Add("NumberOfPayments_C", "");
            dic.Add("MaximumNumberOfPayments_V", "");
            dic.Add("MaximumNumberOfPayments_C", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("FirstStartAge_cbo", "");
            dic.Add("FirstStartAge_txt", "");
            dic.Add("LastStartAge_cbo", "");
            dic.Add("LastStartAge_txt", "");
            dic.Add("NumberOfPayments_cbo", "");
            dic.Add("NumberOfPayments_txt", "");
            dic.Add("MaximumNumberOfPayments_cbo", "");
            dic.Add("MaximumNumberOfPayments_txt", "");
            dic.Add("Eligibility", "BenefitEligible");
            dic.Add("VestedRatio", "");
            dic.Add("CostOfLivingAdjustment", "BenCOLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "Reversionary");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "Disability");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "DthSpouse");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "DthSpouse");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "AccruedBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("BenefitCommencementAge_V", "");
            dic.Add("BenefitCommencementAge_C", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("FirstStartAge_V", "");
            dic.Add("FirstStartAge_C", "");
            dic.Add("LastStartAge_V", "");
            dic.Add("LastStartAge_C", "");
            dic.Add("NumberOfPayments_V", "");
            dic.Add("NumberOfPayments_C", "");
            dic.Add("MaximumNumberOfPayments_V", "");
            dic.Add("MaximumNumberOfPayments_C", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("FirstStartAge_cbo", "");
            dic.Add("FirstStartAge_txt", "");
            dic.Add("LastStartAge_cbo", "");
            dic.Add("LastStartAge_txt", "");
            dic.Add("NumberOfPayments_cbo", "");
            dic.Add("NumberOfPayments_txt", "");
            dic.Add("MaximumNumberOfPayments_cbo", "");
            dic.Add("MaximumNumberOfPayments_txt", "");
            dic.Add("Eligibility", "BenefitEligible");
            dic.Add("VestedRatio", "");
            dic.Add("CostOfLivingAdjustment", "BenCOLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "Spouse");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "Death");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PensionerLife");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "PensionerLife");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "In pay inactives");
            dic.Add("SingleFormulaOrBenefit_cbo", "Benefit1DB");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("BenefitCommencementAge_V", "");
            dic.Add("BenefitCommencementAge_C", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("FirstStartAge_V", "");
            dic.Add("FirstStartAge_C", "");
            dic.Add("LastStartAge_V", "");
            dic.Add("LastStartAge_C", "");
            dic.Add("NumberOfPayments_V", "");
            dic.Add("NumberOfPayments_C", "");
            dic.Add("MaximumNumberOfPayments_V", "");
            dic.Add("MaximumNumberOfPayments_C", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("FirstStartAge_cbo", "");
            dic.Add("FirstStartAge_txt", "");
            dic.Add("LastStartAge_cbo", "");
            dic.Add("LastStartAge_txt", "");
            dic.Add("NumberOfPayments_cbo", "");
            dic.Add("NumberOfPayments_txt", "");
            dic.Add("MaximumNumberOfPayments_cbo", "");
            dic.Add("MaximumNumberOfPayments_txt", "");
            dic.Add("Eligibility", "");
            dic.Add("VestedRatio", "");
            dic.Add("CostOfLivingAdjustment", "BenCOLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "Life");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "PensionerLife");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Orphans");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "");
            dic.Add("UseAsWithdrawalBenefit", "");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaOrBenefit_cbo", "Benefit1DB");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("BenefitCommencementAge_V", "");
            dic.Add("BenefitCommencementAge_C", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("FirstStartAge_V", "");
            dic.Add("FirstStartAge_C", "");
            dic.Add("LastStartAge_V", "");
            dic.Add("LastStartAge_C", "");
            dic.Add("NumberOfPayments_V", "");
            dic.Add("NumberOfPayments_C", "");
            dic.Add("MaximumNumberOfPayments_V", "");
            dic.Add("MaximumNumberOfPayments_C", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("FirstStartAge_cbo", "");
            dic.Add("FirstStartAge_txt", "");
            dic.Add("LastStartAge_cbo", "");
            dic.Add("LastStartAge_txt", "");
            dic.Add("NumberOfPayments_cbo", "");
            dic.Add("NumberOfPayments_txt", "");
            dic.Add("MaximumNumberOfPayments_cbo", "");
            dic.Add("MaximumNumberOfPayments_txt", "");
            dic.Add("Eligibility", "");
            dic.Add("VestedRatio", "");
            dic.Add("CostOfLivingAdjustment", "BenCOLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "OrphanFOP");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);




            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.AliveStatus = \"NO\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PensionerReversionary");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "PensionerReversionary");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "In pay inactives");
            dic.Add("SingleFormulaOrBenefit_cbo", "Benefit1DB");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("BenefitCommencementAge_V", "");
            dic.Add("BenefitCommencementAge_C", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("FirstStartAge_V", "");
            dic.Add("FirstStartAge_C", "");
            dic.Add("LastStartAge_V", "");
            dic.Add("LastStartAge_C", "");
            dic.Add("NumberOfPayments_V", "");
            dic.Add("NumberOfPayments_C", "");
            dic.Add("MaximumNumberOfPayments_V", "");
            dic.Add("MaximumNumberOfPayments_C", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("FirstStartAge_cbo", "");
            dic.Add("FirstStartAge_txt", "");
            dic.Add("LastStartAge_cbo", "");
            dic.Add("LastStartAge_txt", "");
            dic.Add("NumberOfPayments_cbo", "");
            dic.Add("NumberOfPayments_txt", "");
            dic.Add("MaximumNumberOfPayments_cbo", "");
            dic.Add("MaximumNumberOfPayments_txt", "");
            dic.Add("Eligibility", "");
            dic.Add("VestedRatio", "");
            dic.Add("CostOfLivingAdjustment", "BenCOLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "Reversionary");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "PensionerReversionary");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Beneficiaries");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormular", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "");
            dic.Add("UseAsWithdrawalBenefit", "");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "Click");
            dic.Add("BenefitCommencementAge_V", "");
            dic.Add("BenefitCommencementAge_C", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("FirstStartAge_V", "");
            dic.Add("FirstStartAge_C", "");
            dic.Add("LastStartAge_V", "");
            dic.Add("LastStartAge_C", "");
            dic.Add("NumberOfPayments_V", "");
            dic.Add("NumberOfPayments_C", "");
            dic.Add("MaximumNumberOfPayments_V", "");
            dic.Add("MaximumNumberOfPayments_C", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("FirstStartAge_cbo", "");
            dic.Add("FirstStartAge_txt", "");
            dic.Add("LastStartAge_cbo", "");
            dic.Add("LastStartAge_txt", "");
            dic.Add("NumberOfPayments_cbo", "");
            dic.Add("NumberOfPayments_txt", "");
            dic.Add("MaximumNumberOfPayments_cbo", "");
            dic.Add("MaximumNumberOfPayments_txt", "");
            dic.Add("Eligibility", "");
            dic.Add("VestedRatio", "");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "Life");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);



            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.MaritalStatus = \"S\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "WthLife");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "WthLife");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormular", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "$AccruedBenefit * $ForFASWith");
            dic.Add("Validate", "Click");
            dic.Add("BenefitCommencementAge_V", "Click");
            dic.Add("BenefitCommencementAge_C", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("FirstStartAge_V", "");
            dic.Add("FirstStartAge_C", "");
            dic.Add("LastStartAge_V", "");
            dic.Add("LastStartAge_C", "");
            dic.Add("NumberOfPayments_V", "");
            dic.Add("NumberOfPayments_C", "");
            dic.Add("MaximumNumberOfPayments_V", "");
            dic.Add("MaximumNumberOfPayments_C", "");
            dic.Add("BenefitCommencementAge_cbo", "_AssumedRetirementAge");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("FirstStartAge_cbo", "");
            dic.Add("FirstStartAge_txt", "");
            dic.Add("LastStartAge_cbo", "");
            dic.Add("LastStartAge_txt", "");
            dic.Add("NumberOfPayments_cbo", "");
            dic.Add("NumberOfPayments_txt", "");
            dic.Add("MaximumNumberOfPayments_cbo", "");
            dic.Add("MaximumNumberOfPayments_txt", "");
            dic.Add("Eligibility", "WithdrawalElig");
            dic.Add("VestedRatio", "");
            dic.Add("CostOfLivingAdjustment", "BenCOLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "Life");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "WthReversionary");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "WthReversionary");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormular", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "$AccruedBenefit * $ForFASWith");
            dic.Add("Validate", "Click");
            dic.Add("BenefitCommencementAge_V", "");
            dic.Add("BenefitCommencementAge_C", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("FirstStartAge_V", "");
            dic.Add("FirstStartAge_C", "");
            dic.Add("LastStartAge_V", "");
            dic.Add("LastStartAge_C", "");
            dic.Add("NumberOfPayments_V", "");
            dic.Add("NumberOfPayments_C", "");
            dic.Add("MaximumNumberOfPayments_V", "");
            dic.Add("MaximumNumberOfPayments_C", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("FirstStartAge_cbo", "");
            dic.Add("FirstStartAge_txt", "");
            dic.Add("LastStartAge_cbo", "");
            dic.Add("LastStartAge_txt", "");
            dic.Add("NumberOfPayments_cbo", "");
            dic.Add("NumberOfPayments_txt", "");
            dic.Add("MaximumNumberOfPayments_cbo", "");
            dic.Add("MaximumNumberOfPayments_txt", "");
            dic.Add("Eligibility", "WithdrawalElig");
            dic.Add("VestedRatio", "");
            dic.Add("CostOfLivingAdjustment", "BenCOLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "Reversionary");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);



            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen1");
            pAssumptions._Collapse(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen2");
            dic.Add("MenuItem", "Copy VO From");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", Config.sClientName);
            dic.Add("Plan", Config.sPlanName);
            dic.Add("ServiceInstance", "Conversion 2008");
            dic.Add("ValuationNode", "Baseline");
            dic.Add("VOShortName", "Pen1");
            dic.Add("OK", "click");
            pMain._PopVerify_CopyProvisionSet_DE(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen2");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "Reversionary");
            dic.Add("Level_6", "IntAcctRev");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen2");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "Reversionary");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Reversionary");
            dic.Add("NumOfPayPerYear_V", "");
            dic.Add("NumOfPayPerYear_C", "");
            dic.Add("SurvivorPercentOrAmount_V", "Click");
            dic.Add("SurvivorPercentOrAmount_P", "");
            dic.Add("NumOfPayPerYear_cbo", "");
            dic.Add("NumOfPayPerYear_txt", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "Beneficiary1PercentFAS");
            dic.Add("SurvivorPercentOrAmount_txt", "");
            pFormOfPayment_DE._PopVerify_FormOfPayment(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen2");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "Spouse");
            dic.Add("Level_6", "IntAcctSps");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen2");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "Spouse");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Spouse's");
            dic.Add("NumOfPayPerYear_V", "");
            dic.Add("NumOfPayPerYear_C", "");
            dic.Add("SurvivorPercentOrAmount_V", "Click");
            dic.Add("SurvivorPercentOrAmount_P", "");
            dic.Add("NumOfPayPerYear_cbo", "");
            dic.Add("NumOfPayPerYear_txt", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "Beneficiary1PercentFAS");
            dic.Add("SurvivorPercentOrAmount_txt", "");
            pFormOfPayment_DE._PopVerify_FormOfPayment(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Pen2");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "PensionerReversionary");
            dic.Add("Level_6", "Beneficiaries");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("BenefitCommencementAge_V", "");
            dic.Add("BenefitCommencementAge_C", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("FirstStartAge_V", "");
            dic.Add("FirstStartAge_C", "");
            dic.Add("LastStartAge_V", "");
            dic.Add("LastStartAge_C", "");
            dic.Add("NumberOfPayments_V", "");
            dic.Add("NumberOfPayments_C", "");
            dic.Add("MaximumNumberOfPayments_V", "");
            dic.Add("MaximumNumberOfPayments_C", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("FirstStartAge_cbo", "");
            dic.Add("FirstStartAge_txt", "");
            dic.Add("LastStartAge_cbo", "");
            dic.Add("LastStartAge_txt", "");
            dic.Add("NumberOfPayments_cbo", "");
            dic.Add("NumberOfPayments_txt", "");
            dic.Add("MaximumNumberOfPayments_cbo", "");
            dic.Add("MaximumNumberOfPayments_txt", "");
            dic.Add("Eligibility", "");
            dic.Add("VestedRatio", "");
            dic.Add("CostOfLivingAdjustment", "BenCOLA");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);



            pMain._Home_ToolbarClick_Top(true);



            #endregion



            #region  Conversion2008 - Individual Output

            pMain._SelectTab("Conversion 2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Individual Output");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "Click");
            dic.Add("RemoveRow", "");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pIndividualOuputFieldDefinition._PopVerify_IndividualOuputFieldDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("VOShortName", "Pen1");
            dic.Add("OutputLabel", "AccruedBenefit");
            dic.Add("Index_V", "Click");
            dic.Add("Index", "$ValAge");
            pIndividualOuputFieldDefinition._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "");
            dic.Add("RemoveRow", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pIndividualOuputFieldDefinition._PopVerify_IndividualOuputFieldDefinition(dic);



            #endregion


            #region  Methods

            pMain._SelectTab("Conversion 2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Methods");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "Entry Age Normal");
            dic.Add("MembershipDate", "MembershipDate1");
            dic.Add("AnnualIncreaseRate", "SalaryScale");
            dic.Add("EarliestEntryAgeMethod", "");
            pMethods_DE._Table_TradeLiability(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AverageWorkingLifeTime", "True");
            dic.Add("AverageLifeTime", "True");
            dic.Add("AverageWorkingLifeTimeToVesting", "");
            dic.Add("AverageWorkingLifeTimeForBenefitingEE", "");
            pMethods._PopVerify_Methods_Accounting(dic);

            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region Report Breaks

            pMain._SelectTab("Conversion 2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Report Breaks");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BreakFields", "TPlan");
            dic.Add("TextSubstitution", "Click");
            dic.Add("OK", "");
            pReportBreaks._PopVerify_ReportBreaks(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BreakFieldValue", "REN2");
            dic.Add("SubstitutionText", "The Second Plan Ren");
            dic.Add("OK", "");
            pBreakFieldTextSubstitution._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("BreakFieldValue", "EINZE");
            dic.Add("SubstitutionText", "Plan one");
            dic.Add("OK", "");
            pBreakFieldTextSubstitution._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("BreakFieldValue", "VORST");
            dic.Add("SubstitutionText", "Plan named Vorst");
            dic.Add("OK", "");
            pBreakFieldTextSubstitution._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("BreakFieldValue", "REN");
            dic.Add("SubstitutionText", "Plan Ren");
            dic.Add("OK", "");
            pBreakFieldTextSubstitution._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("BreakFieldValue", "UVA");
            dic.Add("SubstitutionText", "Deferred Plan");
            dic.Add("OK", "");
            pBreakFieldTextSubstitution._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("BreakFieldValue", "GESAM");
            dic.Add("SubstitutionText", "Gesam Plan");
            dic.Add("OK", "");
            pBreakFieldTextSubstitution._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "7");
            dic.Add("BreakFieldValue", "MAHO");
            dic.Add("SubstitutionText", "Maho Plan");
            dic.Add("OK", "");
            pBreakFieldTextSubstitution._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "8");
            dic.Add("BreakFieldValue", "DECK");
            dic.Add("SubstitutionText", "Deck Plan");
            dic.Add("OK", "Click");
            pBreakFieldTextSubstitution._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BreakFields", "");
            dic.Add("TextSubstitution", "");
            dic.Add("OK", "Click");
            pReportBreaks._PopVerify_ReportBreaks(dic);

            pMain._Home_ToolbarClick_Top(true);


            #endregion

            #region Test Cases


            pMain._SelectTab("Conversion 2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12.15.1927\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"03.15.1937\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"03.15.1926\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"02.15.1955\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion

            #region ER & Output Manager

            pMain._SelectTab("Conversion 2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "NetPayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "Pen1");
            dic.Add("SelectVOs_VO2", "Pen2");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Conversion 2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Conversion 2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2008, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2008, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2008, "Conversion Diagnostic", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2008, "Test Case List", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2008, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2008, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2008, "Valuation Summary for Excel Export", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2008, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2008, "Parameter Print", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2008, "Parameter Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Conversion2008, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Conversion2008, "Payout Projection", "Conversion", true, true);

                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2008, "Member Statistics", "Conversion", true, false, 0, new string[8] { "DeckPlan", "DeferredPlan", "GesamPlan", "MahoPlan", "PlanNamedVorst", "PlanOne", "PlanRen", "TheSecondPlanRen" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2008, "Valuation Summary", "Conversion", true, false, 0, new string[8] { "DeckPlan", "DeferredPlan", "GesamPlan", "MahoPlan", "PlanNamedVorst", "PlanOne", "PlanRen", "TheSecondPlanRen" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Conversion2008, "Payout Projection", "Conversion", true, true, dic);

            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2008, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2008, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2008, "Conversion Diagnostic", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2008, "Test Case List", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2008, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2008, "Detailed Results by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2008, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2008, "Valuation Summary for Excel Export", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2008, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2008, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Conversion2008, "Payout Projection", "Conversion", false, true);

                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2008, "Member Statistics", "Conversion", false, true, 0, new string[8] { "DeckPlan", "DeferredPlan", "GesamPlan", "MahoPlan", "PlanNamedVorst", "PlanOne", "PlanRen", "TheSecondPlanRen" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2008, "Valuation Summary", "Conversion", false, true, 0, new string[8] { "DeckPlan", "DeferredPlan", "GesamPlan", "MahoPlan", "PlanNamedVorst", "PlanOne", "PlanRen", "TheSecondPlanRen" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Conversion2008, "Payout Projection", "Conversion", false, true, dic);

            }

            thrd_Conversion2008.Start();


            pMain._SelectTab("Conversion 2008");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #endregion


            #region RF Pension Data Service Pension 2009

            #region Pension 2009 - Import - Import Data



            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "ParticipantData");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Pension 2009");
            dic.Add("EffectiveDate", "31.12.2009");
            dic.Add("Parent", "Conversion 2008");
            dic.Add("RSC", "");
            dic.Add("Shared", "");
            dic.Add("GeneralUse", "");
            dic.Add("Conversion", "");
            dic.Add("CopyDataService", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_DataServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Pension 2009");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension 2009");
            dic.Add("Level_2", "Upload Data");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "Click");
            dic.Add("Upload", "");
            pData._PopVerify_UploadData(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE001\SmallData2009.xls");
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension 2009");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Import Data");
            pData._TreeViewSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "SmallData2009.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            pData._SelectTab("Mapping");

            pData._IP_Mapping_Initialize("Personal Information", "Beneficiary Information", 1, 0, 1, "BeneficiaryIDNumber");

            pData._IP_Mapping_MapField("Beneficiary1BirthDate", "BBIRTH", 0, false, 0);
            pData._IP_Mapping_MapField("Beneficiary1Gender", "BSEX", 0, true, 0);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_Mapping(dic);

            pData._SelectTab("Validate & Load");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "True");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("ValidateData", "");
            dic.Add("LoadData", "");
            dic.Add("ValidateAndLoadData", "Click");
            pData._PopVerify_IP_ValidateAndLoad(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Data validate & load SUCCESS.");
            dic.Add("OK", "");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);


            pData._SelectTab("Matching");


            dic.Clear();
            dic.Add("Field", "EmployeeIDNumber");
            dic.Add("Include", "False");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "Name");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "BirthDate");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "HireDate1");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "Gender");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "ParticipantStatus");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "PayStatus");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "");
            dic.Add("Unique_UniqueMatch_Num", "85");
            dic.Add("Unique_MultipleMatches_Num", "");
            dic.Add("Duplicate_NoMatch_Num", "");
            dic.Add("Duplicate_UniqueMatch_Num", "");
            dic.Add("Duplicate_MultipleMatches_Num", "");
            dic.Add("Warehouse_NoMatch_Num", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "");
            dic.Add("Unique_UniqueMatch", "Click");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "");
            dic.Add("AcceptAllRecordsAs_What", "Matched");
            dic.Add("AcceptSelectedRecordsAs_What", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "All 'UniqueUniqueMatch' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);


            dic.Clear();
            dic.Add("Field", "BirthDate");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "HireDate1");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "Gender");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "ParticipantStatus");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "");
            dic.Add("Unique_UniqueMatch_Num", "3");
            dic.Add("Unique_MultipleMatches_Num", "");
            dic.Add("Duplicate_NoMatch_Num", "");
            dic.Add("Duplicate_UniqueMatch_Num", "");
            dic.Add("Duplicate_MultipleMatches_Num", "");
            dic.Add("Warehouse_NoMatch_Num", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "");
            dic.Add("Unique_UniqueMatch", "Click");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "");
            dic.Add("AcceptAllRecordsAs_What", "Matched");
            dic.Add("AcceptSelectedRecordsAs_What", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "All 'UniqueUniqueMatch' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "Click");
            dic.Add("FindMatches", "");
            pData._PopVerify_IP_Matching(dic);




            dic.Clear();
            dic.Add("sDataFileRecords", "15.10.1947	01.09.1974");
            dic.Add("sWarehouseRecords", "15.03.1945	01.02.1970");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "15.03.1949	01.10.1972");
            dic.Add("sWarehouseRecords", "22.09.1947	01.10.1995");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "15.09.1951	01.04.1966");
            dic.Add("sWarehouseRecords", "3050	Jane Testgal	15.01.1924");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "15.09.1951	01.05.1977");
            dic.Add("sWarehouseRecords", "15.08.1942	01.07.1970");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "15.11.1948	01.07.1975");
            dic.Add("sWarehouseRecords", "15.05.1945	01.04.1960");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "15.11.1947	01.12.1970");
            dic.Add("sWarehouseRecords", "15.01.1945	01.12.1969");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "15.01.1924");
            dic.Add("sWarehouseRecords", "18.10.1922");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "15.07.1926");
            dic.Add("sWarehouseRecords", "15.04.1944");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "09.05.1928");
            dic.Add("sWarehouseRecords", "9183	Jane Testgal	15.01.1924");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "26.06.1929");
            dic.Add("sWarehouseRecords", "05.03.1928");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            //////////dic.Add("sDataFileRecords", "15.04.1944	01.07.1970	7	M	IN	DEF	H	XY	01.12.1982");
            dic.Add("sDataFileRecords", "01.12.1982");
            dic.Add("sWarehouseRecords", "15.02.1945	01.07.1965");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            //////////dic.Add("sDataFileRecords", "15.04.1944	01.07.1970	7	M	IN	DEF	H	XY	01.12.1983");
            dic.Add("sDataFileRecords", "01.12.1983");
            dic.Add("sWarehouseRecords", "15.07.1944");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("Close", "Click");
            pData._IP_MatchManually(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Matched_Num", "100");
            dic.Add("New_Num", "");
            dic.Add("Ignored_Num", "0");
            dic.Add("Gone_Num", "0");
            dic.Add("Leaver_Num", "0");
            dic.Add("Unmatched_Num", "0");
            dic.Add("Unmerged_Num", "0");
            pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RefreshResults", "");
            dic.Add("UnacceptAllRecords", "");
            dic.Add("UnacceptSelectedRecords", "");
            dic.Add("SaveToWarehouse", "Click");
            dic.Add("MergeDuplicates", "");
            pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);



            #endregion



            #region Pension 2009  - Derivation Groups - PreVal Derivations

            dic.Clear();
            dic.Add("Level_1", "Pension 2009");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "PreVal Derivations");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);

            #endregion


            #region Pension 2009  - Derivation Groups - DeriveUSC

            dic.Clear();
            dic.Add("Level_1", "Pension 2009");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "DeriveUSC");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);

            #endregion


            #region Pension 2009  - Derivation Groups - LYStatusCodes

            dic.Clear();
            dic.Add("Level_1", "Pension 2009");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "LYStatusCodes");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "LYParticipantStatus");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Formula", "");
            dic.Add("Accept", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ParticipantStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ParticipantStatus_P)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "LYHealthStatus");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Formula", "");
            dic.Add("Accept", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "HealthStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=HealthStatus_P)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "LYPayStatus");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Formula", "");
            dic.Add("Accept", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PayStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=PayStatus_P)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "LYAliveStatus");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Formula", "");
            dic.Add("Accept", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "AliveStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=AliveStatus_P)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension 2009");
            dic.Add("Level_2", "Checks");
            pData._TreeViewSelect(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "Click");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);

            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region Pension 2009  - Snapshots

            dic.Clear();
            dic.Add("Level_1", "Pension 2009");
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "ValuationData2009");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "NetPay");
            dic.Add("Level_5", "NetPayPriorYear1");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "CashTransferTrade");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "NoPSV");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Last Year");
            dic.Add("Level_3", "LYUSC");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Last Year");
            dic.Add("Level_3", "LYBookReserve");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Last Year");
            dic.Add("Level_3", "LYParticipantStatus");
            pData._TreeViewSelect_Snapshots(dic, false);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "Click");
            dic.Add("PublishSnapshot", "Click");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_SP_Snapshots_Popup(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion




            #endregion


            #region Pension RF Valuation - Pension 2009


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "PensionValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "Pension 2009");
            dic.Add("Parent", "Conversion 2008");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "2009");
            dic.Add("RSC", "");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "True");
            dic.Add("SelectAllVO", "Click");
            dic.Add("DeselectAll", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Pension 2009");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);



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
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "True");
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
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Data");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Participant DataSet");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "ValuationData2009");
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
            dic.Add("ImportDataandApplyMapping", "Click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._SelectTab("Participant DataSet");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #region Test Case


            pMain._SelectTab("Pension 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12.15.1927\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"03.15.1937\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"03.15.1926\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"02.15.1955\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion

            pMain._SelectTab("Pension 2009");

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
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "True");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "NetPayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "False");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "Pen1");
            dic.Add("SelectVOs_VO2", "Pen2");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Pension 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Pension 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Pension2009, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Pension2009, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Pension2009, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Pension2009, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Pension2009, "Individual Checking Template", "RollForward", true, true, 0, new string[2] { "Pen1", "Pen2" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Pension2009, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Pension2009, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Pension2009, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Pension2009, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Pension2009, "Parameter Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Pension2009, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Pension2009, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Pension2009, "FAS Expected Benefit Pmts", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Pension2009, "Member Statistics", "RollForward", true, true, 0, new string[10] { "DeckPlan", "DeferredPlan", "GesamPlan", "MahoPlan", "PlanNamedVorst", "PlanOne", "PlanRen", "TheSecondPlanRen", "UVA2", "UVA3" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Pension2009, "Valuation Summary", "RollForward", true, true, 0, new string[10] { "DeckPlan", "DeferredPlan", "GesamPlan", "MahoPlan", "PlanNamedVorst", "PlanOne", "PlanRen", "TheSecondPlanRen", "UVA2", "UVA3" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Pension2009, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[10] { "DeckPlan", "DeferredPlan", "GesamPlan", "MahoPlan", "PlanNamedVorst", "PlanOne", "PlanRen", "TheSecondPlanRen", "UVA2", "UVA3" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Pension2009, "Liability Set for Globe Export", "RollForward", true, true, 0, new string[10] { "DeckPlan", "DeferredPlan", "GesamPlan", "MahoPlan", "PlanNamedVorst", "PlanOne", "PlanRen", "TheSecondPlanRen", "UVA2", "UVA3" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Pension2009, "Payout Projection", "RollForward", true, true, dic);

            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Pension2009, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Pension2009, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Pension2009, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Pension2009, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Pension2009, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Pension2009, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Pension2009, "Individual Checking Template", "RollForward", false, true, 0, new string[2] { "Pen1", "Pen2" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Pension2009, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Pension2009, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Pension2009, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Pension2009, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Pension2009, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Pension2009, "FAS Expected Benefit Pmts", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Pension2009, "Member Statistics", "RollForward", false, true, 0, new string[10] { "DeckPlan", "DeferredPlan", "GesamPlan", "MahoPlan", "PlanNamedVorst", "PlanOne", "PlanRen", "TheSecondPlanRen", "UVA2", "UVA3" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Pension2009, "Valuation Summary", "RollForward", false, true, 0, new string[10] { "DeckPlan", "DeferredPlan", "GesamPlan", "MahoPlan", "PlanNamedVorst", "PlanOne", "PlanRen", "TheSecondPlanRen", "UVA2", "UVA3" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Pension2009, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[10] { "DeckPlan", "DeferredPlan", "GesamPlan", "MahoPlan", "PlanNamedVorst", "PlanOne", "PlanRen", "TheSecondPlanRen", "UVA2", "UVA3" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Pension2009, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[10] { "DeckPlan", "DeferredPlan", "GesamPlan", "MahoPlan", "PlanNamedVorst", "PlanOne", "PlanRen", "TheSecondPlanRen", "UVA2", "UVA3" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Pension2009, "Payout Projection", "RollForward", false, true, dic);

            }

            thrd_Pension2009.Start();


            pMain._SelectTab("Pension 2009");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            #endregion


            #region Frist Jubilee Data Service - Jubilee 2008

            #region create Jubilee 2008

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "ParticipantData");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Jubilee 2008");
            dic.Add("EffectiveDate", "31.12.2008");
            dic.Add("Parent", "");
            dic.Add("RSC", "True");
            dic.Add("Shared", "");
            dic.Add("GeneralUse", "");
            dic.Add("Conversion", "");
            dic.Add("CopyDataService", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_DataServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Jubilee 2008");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            #endregion


            #region Jubilee 2008 - CurrentView

            pData._ts_UpdateIncludedVOs("Jub1", true);

            dic.Clear();
            dic.Add("Level_1", "Jubilee 2008");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);

            pData._CV_Initialize("Personal Information", "DB Information", 1, 2, "MembershipDate1");

            pData._CV_ExpandPersonalInformation();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Pay");
            dic.Add("Label", "JubiPay");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "01.01.2008");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Pay");
            dic.Add("Label", "Bonus");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "01.01.2008");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, false);


            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region Jubilee 2008 - Upload Data & Import - Import Data

            dic.Clear();
            dic.Add("Level_1", "Jubilee 2008");
            dic.Add("Level_2", "Upload Data");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "Click");
            dic.Add("Upload", "");
            pData._PopVerify_UploadData(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE001\SmallJubiData2008.xls");
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee 2008");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);


            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Import Data");
            dic.Add("FileType", "Excel file");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "SmallJubiData2008.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("SingleTabPerRecordFile_cbo", "");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_SelectFile(dic);

            pData._SelectTab("Mapping");


            pData._IP_Mapping_Initialize("Personal Information", "Classification Codes", 1, 0, 1, "SubsidiaryCode");
            pData._IP_Mapping_Initialize("Personal Information", "DB Information", 1, 0, 1, "MembershipDate1");
            pData._IP_Mapping_Initialize("Personal Information", "Beneficiary Information", 1, 0, 1, "BeneficiaryIDNumber");
            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "IsEligible_VOParent");
            pData._IP_Mapping_Initialize("Personal Information", "Pay", 2, 6, 1, "JubiPay");
            pData._IP_Mapping_Initialize("Personal Information", "Bonus", 3, 6, 1, "BonusCurrentYear");
            pData._IP_Mapping_Initialize("Personal Information", "JubiPay", 3, 6, 1, "JubiPayCurrentYear");

            pData._IP_Mapping_MapField("ParticipantStatus", "ETY", 0, false, 0);
            pData._IP_Mapping_MapField("PayStatus", "ETY", 0, true, 0);
            pData._IP_Mapping_MapField("HealthStatus", "EHEALTH", 0, true, 0);
            pData._IP_Mapping_MapField("AliveStatus", "ETY", 0, true, 0);
            pData._IP_Mapping_MapField("JubiPayCurrentYear", "NETPAY", 0, true, 0);
            pData._IP_Mapping_MapField("BonusCurrentYear", "BONUS", 0, true, 0);
            pData._IP_Mapping_MapField("ContribsWOInterest1", "CNTBTION", 0, true, 0);
            pData._IP_Mapping_MapField("SalariedFlag", "SPLITTAR", 0, true, 0);



            pData._IP_Mapping_ClickEdit("ParticipantStatus", false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "AC");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "IN");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "IN");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "IN");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "IN");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "IN");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_ClickEdit("PayStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "DEF");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "DEF");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "PAY");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "PAY");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "PAY");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "PAY");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_ClickEdit("AliveStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "XY");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "XY");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "XY");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "XY");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "NY");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "NO");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_Mapping(dic);


            pData._SelectTab("Validate & Load");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("ValidateData", "");
            dic.Add("LoadData", "");
            dic.Add("ValidateAndLoadData", "Click");
            pData._PopVerify_IP_ValidateAndLoad(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Data validate & load SUCCESS.");
            dic.Add("OK", "");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);


            pData._SelectTab("Matching");

            dic.Clear();
            dic.Add("Field", "EmployeeIDNumber");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "100");
            dic.Add("Unique_UniqueMatch_Num", "0");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "0");
            dic.Add("Duplicate_UniqueMatch_Num", "0");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
            dic.Add("Warehouse_NoMatch_Num", "0");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "Click");
            dic.Add("Unique_UniqueMatch", "");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "");
            dic.Add("AcceptAllRecordsAs_What", "New");
            dic.Add("AcceptSelectedRecordsAs_What", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Are you sure that you want to accept all records with a status of New");
            dic.Add("Yes", "");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "All 'UniqueNoMatch' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Matched_Num", "0");
            dic.Add("New_Num", "100");
            dic.Add("Ignored_Num", "0");
            dic.Add("Gone_Num", "0");
            dic.Add("Leaver_Num", "0");
            dic.Add("Unmatched_Num", "0");
            dic.Add("Unmerged_Num", "0");
            pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RefreshResults", "");
            dic.Add("UnacceptAllRecords", "");
            dic.Add("UnacceptSelectedRecords", "");
            dic.Add("SaveToWarehouse", "Click");
            dic.Add("MergeDuplicates", "");
            pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Once the matching results have been processed, all the Import parameters for this file will become read-only. Do you wish to proceed?");
            dic.Add("Yes", "");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "The matching results have now been processed. All the Import parameters for this file are now read-only.");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);


            #endregion




            #region Jubilee 2008 - Derivation Groups - SetVO

            dic.Clear();
            dic.Add("Level_1", "Jubilee 2008");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "SetVO");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "IsEligible_Jub1");
            dic.Add("DerivedField_SearchFromIndex", "2");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "EmployeeIDNumber");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(EmployeeIDNumber_C>0,1,0)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee 2008");
            dic.Add("Level_2", "Checks");
            pData._TreeViewSelect(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "Click");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);

            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region Jubilee 2008 - Derivation Groups - DeriveUSC

            dic.Clear();
            dic.Add("Level_1", "Jubilee 2008");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "DeriveUSC");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "USC");
            dic.Add("DerivedField_SearchFromIndex", "3");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ParticipantStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PayStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "HealthStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "AliveStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=DeriveUSC(ParticipantStatus_C,PayStatus_C,HealthStatus_C,AliveStatus_C)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);



            #endregion



            #region Jubilee 2008 - Snapshots

            dic.Clear();
            dic.Add("Level_1", "Jubilee 2008");
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "JubileeData");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ParticipantStatus");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PayStatus");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "HealthStatus");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "AliveStatus");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "CashTransferTrade");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "NoPSV");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Last Year");
            dic.Add("Level_3", "LYUSC");
            pData._TreeViewSelect_Snapshots(dic, false);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "Click");
            dic.Add("PublishSnapshot", "Click");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_SP_Snapshots_Popup(dic);



            pMain._Home_ToolbarClick_Top(true);



            #endregion



            #endregion


            #region Jubilee Conversion 2008

            #region Add Val Service

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "JubileeValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "True");
            dic.Add("Name", "Jubilee Conversion 2008");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "2008");
            dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("SelectAllVO", "Click");
            dic.Add("DeselectAll", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Jubilee Conversion 2008");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            #endregion

            #region ParticipantDataSet

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Data");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Participant DataSet");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "JubileeData");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "Click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._SelectTab("Participant DataSet");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion



            #region Assumptions


            pMain._SelectTab("Jubilee Conversion 2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");


            pAssumptions._TreeView_SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Assumed Retirement Age");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FromData", "True");
            dic.Add("CustomCode", "");
            dic.Add("AssumedRetirementAge_V", "Click");
            dic.Add("AssumedRetirementAge_C", "");
            dic.Add("AssumedRetirementAge_cbo", "AssumedRetirementAge");
            dic.Add("AssumedRetirementAge_txt", "");
            pAssumedRetirementAge._PopVerify_FromData(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Social Security Contribution Rates");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("Other", "True");
            dic.Add("AsOfDate", "");
            dic.Add("SocialSecurityContributionRateRV_Employer", "9,80");
            dic.Add("SocialSecurityContributionRateKnappschaft_Employer", "9,95");
            dic.Add("HealthInsuranceContribionRate_Employer", "7,30");
            dic.Add("HealthInsuranceReducedRate_Employer", "7,00");
            dic.Add("UnemploymentInsuranceContributionRate_Employer", "0,00");
            dic.Add("CareInsuranceContributionRate_Employer", "0,975");
            dic.Add("AccidentInsuranceContributionRate_Employer", "0,00");
            dic.Add("SocialSecurityContributionRateRV_EE", "9,80");
            dic.Add("SocialSecurityContributionRateKnappschaft_EE", "9,80");
            dic.Add("HealthInsuranceContribionRate_EE", "8,20");
            dic.Add("HealthInsuranceReducedRate_EE", "7,90");
            dic.Add("UnemploymentInsuranceContributionRate_EE", "0,00");
            dic.Add("CareInsuranceContributionRate_EE", "1,225");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("WorkingDaysPerYear", "261,00");
            dic.Add("AdjustFactorrFromNextToGross", "1,00");
            dic.Add("TaxTariff", "2010");
            dic.Add("SoliTaxRate", "");
            dic.Add("ChurchTaxRate", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_DE(dic);


            pAssumptions._TreeView_SelectTab("Trade");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Assumed Retirement Age");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FromData", "True");
            dic.Add("CustomCode", "");
            dic.Add("AssumedRetirementAge_V", "Click");
            dic.Add("AssumedRetirementAge_C", "");
            dic.Add("AssumedRetirementAge_cbo", "AssumedRetirementAge");
            dic.Add("AssumedRetirementAge_txt", "");
            pAssumedRetirementAge._PopVerify_FromData(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Social Security Contribution Rates");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("Other", "True");
            dic.Add("AsOfDate", "");
            dic.Add("SocialSecurityContributionRateRV_Employer", "9,80");
            dic.Add("SocialSecurityContributionRateKnappschaft_Employer", "0,00");
            dic.Add("HealthInsuranceContribionRate_Employer", "7,30");
            dic.Add("HealthInsuranceReducedRate_Employer", "7,00");
            dic.Add("UnemploymentInsuranceContributionRate_Employer", "0,00");
            dic.Add("CareInsuranceContributionRate_Employer", "0,975");
            dic.Add("AccidentInsuranceContributionRate_Employer", "0,00");

            dic.Add("SocialSecurityContributionRateRV_EE", "9,80");
            dic.Add("SocialSecurityContributionRateKnappschaft_EE", "9,80");
            dic.Add("HealthInsuranceContribionRate_EE", "8,20");
            dic.Add("HealthInsuranceReducedRate_EE", "7,90");
            dic.Add("UnemploymentInsuranceContributionRate_EE", "0,00");
            dic.Add("CareInsuranceContributionRate_EE", "1,225");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);




            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("WorkingDaysPerYear", "261,00");
            dic.Add("AdjustFactorrFromNextToGross", "1,00");
            dic.Add("TaxTariff", "2010");
            dic.Add("SoliTaxRate", "");
            dic.Add("ChurchTaxRate", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_DE(dic);


            pAssumptions._TreeView_SelectTab("IntAccounting");



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Assumed Retirement Age");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FromData", "True");
            dic.Add("CustomCode", "");
            dic.Add("AssumedRetirementAge_V", "Click");
            dic.Add("AssumedRetirementAge_C", "");
            dic.Add("AssumedRetirementAge_cbo", "AssumedRetirementAge");
            dic.Add("AssumedRetirementAge_txt", "");
            pAssumedRetirementAge._PopVerify_FromData(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "6,2");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("MenuItem", "Add Pay Increase");
            pAssumptions._TreeViewRightSelect(dic, "SalaryScale");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryScale");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "");
            dic.Add("btnT", "");
            dic.Add("txtRate", "3,0");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Social Security Contribution Rates");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("Other", "True");
            dic.Add("AsOfDate", "");
            dic.Add("SocialSecurityContributionRateRV_Employer", "9,80");
            dic.Add("SocialSecurityContributionRateKnappschaft_Employer", "0,00");
            dic.Add("HealthInsuranceContribionRate_Employer", "7,30");
            dic.Add("HealthInsuranceReducedRate_Employer", "7,00");
            dic.Add("UnemploymentInsuranceContributionRate_Employer", "0,00");
            dic.Add("CareInsuranceContributionRate_Employer", "0,975");
            dic.Add("AccidentInsuranceContributionRate_Employer", "0,00");

            dic.Add("SocialSecurityContributionRateRV_EE", "9,80");
            dic.Add("SocialSecurityContributionRateKnappschaft_EE", "9,80");
            dic.Add("HealthInsuranceContribionRate_EE", "8,20");
            dic.Add("HealthInsuranceReducedRate_EE", "7,90");
            dic.Add("UnemploymentInsuranceContributionRate_EE", "0,00");
            dic.Add("CareInsuranceContributionRate_EE", "1,225");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("WorkingDaysPerYear", "261,00");
            dic.Add("AdjustFactorrFromNextToGross", "1,00");
            dic.Add("TaxTariff", "2010");
            dic.Add("SoliTaxRate", "");
            dic.Add("ChurchTaxRate", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_DE(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("Other", "True");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "GildemeisterTerm");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);



            pMain._Home_ToolbarClick_Top(true);




            ////////////////////////////////added/////


            //////pAssumptions._TreeView_SelectTab("Tax");

            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Other Demographic Assumptions");
            //////dic.Add("Level_3", "Default");
            //////pAssumptions._TreeViewSelect(dic);

            //////_gLib._MsgBox("", "set as ''Heubeck 2005 G''");




            //////pAssumptions._TreeView_SelectTab("Trade");

            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Other Demographic Assumptions");
            //////dic.Add("Level_3", "Default");
            //////pAssumptions._TreeViewSelect(dic);

            //////_gLib._MsgBox("", "set as ''Heubeck 2005 G''");



            //////pAssumptions._TreeView_SelectTab("IntAccounting");

            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Other Demographic Assumptions");
            //////dic.Add("Level_3", "Default");
            //////pAssumptions._TreeViewSelect(dic);

            //////_gLib._MsgBox("", "set as ''Heubeck 2005 G''");




            //////pAssumptions._TreeView_SelectTab("Tax");

            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Mortality Decrement");
            //////dic.Add("Level_3", "USC40");
            //////pAssumptions._TreeViewSelect(dic);


            //////_gLib._MsgBox("", "set values as: " + Environment.NewLine
            //////    + "Pre-decrement:      GesamtRetireeDeath_HB05QRX" + Environment.NewLine
            //////    + "Pre-commencement:   GesamtRetireeDeath_HB05QRX    " + Environment.NewLine
            //////    + "Post-commencement:  GesamtRetireeDeath_HB05QRX " + Environment.NewLine
            //////    + "Spouse:             WidowDeath_HB05QWX");


            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Mortality Decrement");
            //////dic.Add("Level_3", "Default");
            //////pAssumptions._TreeViewSelect(dic);

            //////_gLib._MsgBox("", "set values as: " + Environment.NewLine +
            //////  " ''Heubeck 2005 G''");



            //////pAssumptions._TreeView_SelectTab("Trade");


            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Mortality Decrement");
            //////dic.Add("Level_3", "USC40");
            //////pAssumptions._TreeViewSelect(dic);


            //////_gLib._MsgBox("", "set values as: " + Environment.NewLine
            //////    + "Pre-decrement:      GesamtRetireeDeath_HB05QRX" + Environment.NewLine
            //////    + "Pre-commencement:   GesamtRetireeDeath_HB05QRX    " + Environment.NewLine
            //////    + "Post-commencement:  GesamtRetireeDeath_HB05QRX " + Environment.NewLine
            //////    + "Spouse:             WidowDeath_HB05QWX");


            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Mortality Decrement");
            //////dic.Add("Level_3", "Default");
            //////pAssumptions._TreeViewSelect(dic);

            //////_gLib._MsgBox("", "set values as: " + Environment.NewLine +
            //////  " ''Heubeck 2005 G''");



            //////pAssumptions._TreeView_SelectTab("IntAccounting");

            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Mortality Decrement");
            //////dic.Add("Level_3", "USC40");
            //////pAssumptions._TreeViewSelect(dic);


            //////_gLib._MsgBox("", "set values as: " + Environment.NewLine
            //////    + "Pre-decrement:      GesamtRetireeDeath_HB05QRX" + Environment.NewLine
            //////    + "Pre-commencement:   GesamtRetireeDeath_HB05QRX    " + Environment.NewLine
            //////    + "Post-commencement:  GesamtRetireeDeath_HB05QRX " + Environment.NewLine
            //////    + "Spouse:             WidowDeath_HB05QWX");


            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Mortality Decrement");
            //////dic.Add("Level_3", "Default");
            //////pAssumptions._TreeViewSelect(dic);

            //////_gLib._MsgBox("", "set values as: " + Environment.NewLine +
            //////  " ''Heubeck 2005 G''");



            //////pAssumptions._TreeView_SelectTab("Tax");


            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Disability Decrement");
            //////dic.Add("Level_3", "USC40");
            //////pAssumptions._TreeViewSelect(dic);

            //////_gLib._MsgBox("", "check on other");


            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Disability Decrement");
            //////dic.Add("Level_3", "Default");
            //////pAssumptions._TreeViewSelect(dic);


            //////_gLib._MsgBox("", "set values as: " + Environment.NewLine +
            //////  " ''Heubeck 2005 G''");



            //////pAssumptions._TreeView_SelectTab("Trade");

            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Disability Decrement");
            //////dic.Add("Level_3", "USC40");
            //////pAssumptions._TreeViewSelect(dic);

            //////_gLib._MsgBox("", "check on other");

            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Disability Decrement");
            //////dic.Add("Level_3", "Default");
            //////pAssumptions._TreeViewSelect(dic);


            //////_gLib._MsgBox("", "set values as: " + Environment.NewLine +
            //////  " ''Heubeck 2005 G''");



            //////pAssumptions._TreeView_SelectTab("IntAccounting");

            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Disability Decrement");
            //////dic.Add("Level_3", "USC40");
            //////pAssumptions._TreeViewSelect(dic);

            //////_gLib._MsgBox("", "check on other");


            //////dic.Clear();
            //////dic.Add("Level_1", "Assumptions");
            //////dic.Add("Level_2", "Disability Decrement");
            //////dic.Add("Level_3", "Default");
            //////pAssumptions._TreeViewSelect(dic);

            //////_gLib._MsgBox("", "set values as: " + Environment.NewLine +
            //////  " ''Heubeck 2005 G''");

            //pMain._Home_ToolbarClick_Top(true);



            /////////////////////////////////////



            #endregion

            #region Jubiliee Conversion 2008 - Common Update Code for DE - Update Assumptions

            pMain._SelectTab("Assumptions");

            pAssumptions._TreeView_SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("cboPrescribedRates", "Heubeck 2005 G");
            dic.Add("ApplyPercentMarriedAt", "");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "");
            dic.Add("txtPercentMarried_F", "");
            dic.Add("cboPercentMarried", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "");
            dic.Add("txtDifferenceInSpouseAge_F", "");
            dic.Add("cboDifferenceInSpouseAge", "");
            dic.Add("DifferenceInOrphanAge", "");
            dic.Add("NumberOfChildren", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);


            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("cboPrescribedRates", "Heubeck 2005 G");
            dic.Add("ApplyPercentMarriedAt", "");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "");
            dic.Add("txtPercentMarried_F", "");
            dic.Add("cboPercentMarried", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "");
            dic.Add("txtDifferenceInSpouseAge_F", "");
            dic.Add("cboDifferenceInSpouseAge", "");
            dic.Add("DifferenceInOrphanAge", "");
            dic.Add("NumberOfChildren", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);


            pAssumptions._TreeView_SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("cboPrescribedRates", "Heubeck 2005 G");
            dic.Add("ApplyPercentMarriedAt", "");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "");
            dic.Add("txtPercentMarried_F", "");
            dic.Add("cboPercentMarried", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "");
            dic.Add("txtDifferenceInSpouseAge_F", "");
            dic.Add("cboDifferenceInSpouseAge", "");
            dic.Add("DifferenceInOrphanAge", "");
            dic.Add("NumberOfChildren", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);


            pAssumptions._TreeView_SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pAssumptions._TreeView_SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);



            pAssumptions._TreeView_SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Other", "True");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERODIS");
            dic.Add("Service", "");
            dic.Add("AdjustmentOperator", "");
            dic.Add("Adjustment_C", "");
            dic.Add("Adjustment_P", "");
            dic.Add("Adjustment_T", "");
            dic.Add("Adjustment_txt", "");
            dic.Add("Adjustment_Tcbo", "");
            dic.Add("Adjustment_Tcbo_extend", "");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Other", "True");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERODIS");
            dic.Add("Service", "");
            dic.Add("AdjustmentOperator", "");
            dic.Add("Adjustment_C", "");
            dic.Add("Adjustment_P", "");
            dic.Add("Adjustment_T", "");
            dic.Add("Adjustment_txt", "");
            dic.Add("Adjustment_Tcbo", "");
            dic.Add("Adjustment_Tcbo_extend", "");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pAssumptions._TreeView_SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Other", "True");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERODIS");
            dic.Add("Service", "");
            dic.Add("AdjustmentOperator", "");
            dic.Add("Adjustment_C", "");
            dic.Add("Adjustment_P", "");
            dic.Add("Adjustment_T", "");
            dic.Add("Adjustment_txt", "");
            dic.Add("Adjustment_Tcbo", "");
            dic.Add("Adjustment_Tcbo_extend", "");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);



            pMain._Home_ToolbarClick_Top(true);

            #endregion



            #region Provisions

            pMain._SelectTab("Jubilee Conversion 2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Provisions");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "EligibilityService");


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "ForProrate");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "ForProrate");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "True");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            dic.Add("ForInternationalAccounting_DE", "True");
            dic.Add("ForTrade_DE", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Date", "HireDate1");
            dic.Add("CalculationMethod", "");
            dic.Add("RoundingPeriod", "Months");
            dic.Add("RoundingMethod", "Completed");
            pService._PopVerify_RulesBasedService_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Years10");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Years10");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$EligibilityService >= 10");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Years25");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Years25");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$EligibilityService >= 25");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "JubiEligible");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "JubiEligible");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$Age >= 25");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "ProjectedPay");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "ProjectedPay");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataFieldContainingPayHistory", "JubiPay");
            dic.Add("PayIncreaseAssumption", "SalaryScale");
            dic.Add("UseOnlyDataFields", "");
            dic.Add("rdValuationYearPlus", "");
            dic.Add("txtValuationYearPlus", "");
            dic.Add("rdSpecifiedYear", "");
            dic.Add("txtSpecifiedYear", "");
            dic.Add("ApplyEGTRRALimits", "");
            pPayoutProjection._PopVerify_History(dic);

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "ProjectedBonus");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "ProjectedBonus");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataFieldContainingPayHistory", "Bonus");
            dic.Add("PayIncreaseAssumption", "SalaryScale");
            dic.Add("UseOnlyDataFields", "");
            dic.Add("rdValuationYearPlus", "");
            dic.Add("txtValuationYearPlus", "");
            dic.Add("rdSpecifiedYear", "");
            dic.Add("txtSpecifiedYear", "");
            dic.Add("ApplyEGTRRALimits", "");
            pPayoutProjection._PopVerify_History(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "JubiSalary");


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "JubiSalary");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$ProjectedPay + $ProjectedBonus + 12.0 * $emp.ContribRate1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "JubiSalary");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Splittar1");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$ProjectedPay * 1.042 + $ProjectedBonus + 12.0 * $emp.ContribRate1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.SalariedFlag = 1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "UpToPiece");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "UpToPiece");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$JubiSalary + 0.1145 * Min($_SocSecContribCeiling_RVTax, $JubiSalary) + 0.08275 * Min($_HealthInsContribCeiling, $JubiSalary)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "ExcessRet");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "ExcessRet");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max($_SocSecContribCeiling_RVTax - $JubiSalary, 0.0)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "ExcessHealth");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "ExcessHealth");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max($_HealthInsContribCeiling - $JubiSalary, 0.0)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "HolidayPiece");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "HolidayPiece");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$UpToPiece / 261.0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "JubiBen10");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "JubiBen10");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "1000.0 + 0.1145 * Min(1000.0, $ExcessRet) + 0.08275 * Min(1000.0, $ExcessHealth) + 3.0 * $HolidayPiece");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "JubiBen25");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "JubiBen25");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "3000.0 + 0.1145 * Min(3000.0, $ExcessRet) + 0.08275 * Min(3000.0, $ExcessHealth) + 3.0 * $HolidayPiece");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "JubiBen40");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "JubiBen40");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "4000.0 + 0.1145 * Min(4000.0, $ExcessRet) + 0.08275 * Min(4000.0, $ExcessHealth) + 3.0 * $HolidayPiece");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "JubiBen50");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "JubiBen50");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "5000.0 + 0.1145 * Min(5000.0, $ExcessRet) + 0.08275 * Min(5000.0, $ExcessHealth) + 3.0 * $HolidayPiece");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("MenuItem", "Add Jubilee Benefit");
            pAssumptions._TreeViewRightSelect(dic, "Benefit10");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("Level_6", "Benefit10");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FixedAmount", "True");
            dic.Add("SalaryBased", "");
            dic.Add("JubileeAmount_V", "");
            dic.Add("JubileeAmount_C", "");
            dic.Add("JubileeAmount_cbo", "JubiBen10");
            dic.Add("JubileeAmount_txt", "");
            dic.Add("NetAmtUsingTotal", "");
            dic.Add("NetAmtUsingSystem", "");
            dic.Add("YearSalary", "JubiSalary");
            dic.Add("TaxClass", "1");
            dic.Add("GrossAmount", "");
            dic.Add("FinalAmount", "True");
            pJubileeBenefit._PopVerify_FixedAmount(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("MenuItem", "Add Jubilee Benefit");
            pAssumptions._TreeViewRightSelect(dic, "Benefit25");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("Level_6", "Benefit25");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FixedAmount", "True");
            dic.Add("SalaryBased", "");
            dic.Add("JubileeAmount_V", "");
            dic.Add("JubileeAmount_C", "");
            dic.Add("JubileeAmount_cbo", "JubiBen25");
            dic.Add("JubileeAmount_txt", "");
            dic.Add("NetAmtUsingTotal", "");
            dic.Add("NetAmtUsingSystem", "");
            dic.Add("YearSalary", "JubiSalary");
            dic.Add("TaxClass", "1");
            dic.Add("GrossAmount", "");
            dic.Add("FinalAmount", "True");
            pJubileeBenefit._PopVerify_FixedAmount(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("MenuItem", "Add Jubilee Benefit");
            pAssumptions._TreeViewRightSelect(dic, "Benefit40");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("Level_6", "Benefit40");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FixedAmount", "True");
            dic.Add("SalaryBased", "");
            dic.Add("JubileeAmount_V", "");
            dic.Add("JubileeAmount_C", "");
            dic.Add("JubileeAmount_cbo", "JubiBen40");
            dic.Add("JubileeAmount_txt", "");
            dic.Add("NetAmtUsingTotal", "");
            dic.Add("NetAmtUsingSystem", "");
            dic.Add("YearSalary", "JubiSalary");
            dic.Add("TaxClass", "1");
            dic.Add("GrossAmount", "");
            dic.Add("FinalAmount", "True");
            pJubileeBenefit._PopVerify_FixedAmount(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("MenuItem", "Add Jubilee Benefit");
            pAssumptions._TreeViewRightSelect(dic, "Benefit50");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("Level_6", "Benefit50");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FixedAmount", "True");
            dic.Add("SalaryBased", "");
            dic.Add("JubileeAmount_V", "");
            dic.Add("JubileeAmount_C", "");
            dic.Add("JubileeAmount_cbo", "JubiBen50");
            dic.Add("JubileeAmount_txt", "");
            dic.Add("NetAmtUsingTotal", "");
            dic.Add("NetAmtUsingSystem", "");
            dic.Add("YearSalary", "JubiSalary");
            dic.Add("TaxClass", "1");
            dic.Add("GrossAmount", "");
            dic.Add("FinalAmount", "True");
            pJubileeBenefit._PopVerify_FixedAmount(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Jubi10Liab");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Jubi10Liab");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("YearsOfServiceForJubi", "10");
            dic.Add("BasedOn", "PensionableServiceDate");
            dic.Add("YearlySalary", "JubiSalary");
            dic.Add("ApplyPercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("JubileeBenefit", "Benefit10");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "1,00000");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "");
            dic.Add("Disability", "");
            dic.Add("Death", "");
            dic.Add("GraceYears", "");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Jubi25Liab");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Jubi25Liab");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("YearsOfServiceForJubi", "25");
            dic.Add("BasedOn", "PensionableServiceDate");
            dic.Add("YearlySalary", "JubiSalary");
            dic.Add("ApplyPercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("JubileeBenefit", "Benefit25");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "1,00000");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "");
            dic.Add("Disability", "");
            dic.Add("Death", "");
            dic.Add("GraceYears", "");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Jubi40Liab");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Jubi40Liab");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("YearsOfServiceForJubi", "40");
            dic.Add("BasedOn", "PensionableServiceDate");
            dic.Add("YearlySalary", "JubiSalary");
            dic.Add("ApplyPercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("JubileeBenefit", "Benefit40");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "1,00000");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "");
            dic.Add("Disability", "");
            dic.Add("Death", "");
            dic.Add("GraceYears", "");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Jubi50Liab");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Jubi50Liab");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("YearsOfServiceForJubi", "50");
            dic.Add("BasedOn", "PensionableServiceDate");
            dic.Add("YearlySalary", "JubiSalary");
            dic.Add("ApplyPercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("JubileeBenefit", "Benefit50");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "1,00000");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "");
            dic.Add("Disability", "");
            dic.Add("Death", "");
            dic.Add("GraceYears", "");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);

            pMain._Home_ToolbarClick_Top(true);



            #endregion

            #region  Methods

            pMain._SelectTab("Jubilee Conversion 2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Methods");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "Entry Age Normal");
            dic.Add("AnnualIncreaseRate", "SalaryScale");
            pMethods_DE._Table_TradeLiability_Jubilee(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "");
            dic.Add("CompareToAccrued", "");
            dic.Add("AllowNegativeNormal", "True");
            pMethods_DE._Table_InternationalAccounting(dic);


            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region Report Breaks

            pMain._SelectTab("Jubilee Conversion 2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Report Breaks");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BreakFields", "SalariedFlag");
            dic.Add("TextSubstitution", "Click");
            dic.Add("OK", "");
            pReportBreaks._PopVerify_ReportBreaks(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BreakFieldValue", "0");
            dic.Add("SubstitutionText", "Smaller Group");
            dic.Add("OK", "");
            pBreakFieldTextSubstitution._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("BreakFieldValue", "1");
            dic.Add("SubstitutionText", "Larger Group");
            dic.Add("OK", "Click");
            pBreakFieldTextSubstitution._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BreakFields", "");
            dic.Add("TextSubstitution", "");
            dic.Add("OK", "Click");
            pReportBreaks._PopVerify_ReportBreaks(dic);




            pMain._Home_ToolbarClick_Top(true);


            #endregion

            #region Test Case

            pMain._SelectTab("Jubilee Conversion 2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"05.29.1986\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"06.26.1947\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"02.28.1989\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion

            #region ER & Output Manager

            pMain._SelectTab("Jubilee Conversion 2008");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "True");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "JubiPayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "Jub1");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Jubilee Conversion 2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Jubilee Conversion 2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputJubilee_JubileeConversion2008, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_JubileeConversion2008, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputJubilee_JubileeConversion2008, "Conversion Diagnostic", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_JubileeConversion2008, "Test Case List", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_JubileeConversion2008, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_JubileeConversion2008, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_JubileeConversion2008, "Valuation Summary for Excel Export", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputJubilee_JubileeConversion2008, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputJubilee_JubileeConversion2008, "Parameter Print", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputJubilee_JubileeConversion2008, "Parameter Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_JubileeConversion2008, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_JubileeConversion2008, "Payout Projection", "Conversion", true, true);

                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_JubileeConversion2008, "Member Statistics", "Conversion", true, false, 0, new string[2] { "LargerGroup", "SmallerGroup" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_JubileeConversion2008, "Valuation Summary", "Conversion", true, false, 0, new string[2] { "LargerGroup", "SmallerGroup" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputJubilee_JubileeConversion2008, "Payout Projection", "Conversion", true, true, dic);

            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputJubilee_JubileeConversion2008, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_JubileeConversion2008, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputJubilee_JubileeConversion2008, "Conversion Diagnostic", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_JubileeConversion2008, "Test Case List", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_JubileeConversion2008, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_JubileeConversion2008, "Detailed Results by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_JubileeConversion2008, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_JubileeConversion2008, "Valuation Summary for Excel Export", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputJubilee_JubileeConversion2008, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputJubilee_JubileeConversion2008, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_JubileeConversion2008, "Payout Projection", "Conversion", false, true);

                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_JubileeConversion2008, "Member Statistics", "Conversion", false, true, 0, new string[2] { "LargerGroup", "SmallerGroup" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_JubileeConversion2008, "Valuation Summary", "Conversion", false, true, 0, new string[2] { "LargerGroup", "SmallerGroup" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputJubilee_JubileeConversion2008, "Payout Projection", "Conversion", false, true, dic);

            }

            thrd_JubileeConversion2008.Start();

            pMain._SelectTab("Jubilee Conversion 2008");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #endregion


            #region RF Data Serivce - Jubilee 2009

            #region Jubilee 2009 - Import

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "ParticipantData");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Jubilee 2009");
            dic.Add("EffectiveDate", "31.12.2009");
            dic.Add("Parent", "Jubilee 2008");
            dic.Add("RSC", "");
            dic.Add("Shared", "");
            dic.Add("GeneralUse", "");
            dic.Add("Conversion", "");
            dic.Add("CopyDataService", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_DataServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Jubilee 2009");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("Level_1", "Jubilee 2009");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Personal Information");
            dic.Add("Label", "OleEEID");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Integer");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Jubilee 2009");
            dic.Add("Level_2", "Upload Data");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "Click");
            dic.Add("Upload", "");
            pData._PopVerify_UploadData(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE001\SmallJubiData2009.xls");
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);



            dic.Clear();
            dic.Add("Level_1", "Jubilee 2009");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Import Data");
            pData._TreeViewSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "SmallJubiData2009.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._SelectTab("Mapping");

            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "IsEligible_VOParent");

            pData._IP_Mapping_MapField("EmployeeIDNumber", "EEID3", 0, true, 0);
            pData._IP_Mapping_MapField("OleEEID", "EEID", 0, true, 0);



            pData._SelectTab("Validate & Load");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "False");
            dic.Add("ValidateData", "");
            dic.Add("LoadData", "");
            dic.Add("ValidateAndLoadData", "Click");
            pData._PopVerify_IP_ValidateAndLoad(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Data validate & load SUCCESS.");
            dic.Add("OK", "");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);

            pData._SelectTab("Matching");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "14");
            dic.Add("Unique_UniqueMatch_Num", "88");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "0");
            dic.Add("Duplicate_UniqueMatch_Num", "0");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
            dic.Add("Warehouse_NoMatch_Num", "12");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "");
            dic.Add("Unique_UniqueMatch", "Click");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "");
            dic.Add("AcceptAllRecordsAs_What", "Matched");
            dic.Add("AcceptSelectedRecordsAs_What", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "All 'UniqueUniqueMatch' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "Click");
            dic.Add("Unique_UniqueMatch", "");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "");
            dic.Add("AcceptAllRecordsAs_What", "New");
            dic.Add("AcceptSelectedRecordsAs_What", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RefreshResults", "");
            dic.Add("UnacceptAllRecords", "");
            dic.Add("UnacceptSelectedRecords", "");
            dic.Add("SaveToWarehouse", "Click");
            dic.Add("MergeDuplicates", "");
            pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);



            #endregion

            #region Jubilee 2009 - Derivation Groups

            dic.Clear();
            dic.Add("Level_1", "Jubilee 2009");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "SetVO");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);

            dic.Clear();
            dic.Add("Level_1", "Jubilee 2009");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "DeriveUSC");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);

            #endregion

            #region Jubilee 2009 - Snapshots

            dic.Clear();
            dic.Add("Level_1", "Jubilee 2009");
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "JubileeData2009");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ParticipantStatus");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PayStatus");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "HealthStatus");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "AliveStatus");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Last Year");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Legacy System Results");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "Click");
            dic.Add("PublishSnapshot", "Click");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_SP_Snapshots_Popup(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #endregion


            #region Jubilee 2009 - Baseline

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "JubileeValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "Jubilee 2009");
            dic.Add("Parent", "Jubilee Conversion 2008");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "2009");
            dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("SelectAllVO", "Click");
            dic.Add("DeselectAll", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Jubilee 2009");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

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
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "True");
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
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Data");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Participant DataSet");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "JubileeData2009");
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
            dic.Add("ImportDataandApplyMapping", "Click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._SelectTab("Participant DataSet");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #region Test Case

            pMain._SelectTab("Jubilee 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"05.29.1986\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"06.26.1947\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"02.28.1989\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            pMain._SelectTab("Jubilee 2009");

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
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "True");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "JubiPayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "Jub1");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("Jubilee 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Jubilee 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Individual Checking Template", "RollForward", true, true, 0, new string[1] { "Jub1" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Parameter Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Member Statistics", "RollForward", true, true, 0, new string[2] { "LargerGroup", "SmallerGroup" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Valuation Summary", "RollForward", true, true, 0, new string[2] { "LargerGroup", "SmallerGroup" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Liability Set for Globe Export", "RollForward", true, false, 0, new string[2] { "LargerGroup", "SmallerGroup" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Payout Projection", "RollForward", true, true, dic);

            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Individual Checking Template", "RollForward", false, true, 0, new string[1] { "Jub1" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Member Statistics", "RollForward", false, true, 0, new string[2] { "LargerGroup", "SmallerGroup" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Valuation Summary", "RollForward", false, true, 0, new string[2] { "LargerGroup", "SmallerGroup" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Liability Set for Globe Export", "RollForward", false, false, 0, new string[2] { "LargerGroup", "SmallerGroup" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Payout Projection", "RollForward", false, true, dic);

            }

            thrd_Jubilee2009_Baseline.Start();


            pMain._SelectTab("Jubilee 2009");
            pMain._Home_ToolbarClick_Top(true);



            #endregion


            #region Jubilee RF service: Jubilee 2009 - Change Trade and IA Interest


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Change Trade and IA Interest");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
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
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pAssumptions._TreeView_SelectTab("Trade");

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
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "31.12.2009");
            pInterestRate._PopVerify_PrescribedRates(dic);



            pAssumptions._TreeView_SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "5,9");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);




            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #region Test Cases


            pMain._SelectTab("Jubilee 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"05.29.1986\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"06.26.1947\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"02.28.1989\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion

            pMain._SelectTab("Jubilee 2009");




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
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "True");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "JubiPayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "Jub1");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Jubilee 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Jubilee 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Liability Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Parameter Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Valuation Summary", "RollForward", true, true, 0, new string[2] { "LargerGroup", "SmallerGroup" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Liability Set for Globe Export", "RollForward", true, false, 0, new string[2] { "LargerGroup", "SmallerGroup" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Payout Projection", "RollForward", true, false, dic);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Reconciliation to Baseline", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Liabilities Detailed Results", "RollForward", true, false);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Liability Scenario by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Valuation Summary", "RollForward", false, true, 0, new string[2] { "LargerGroup", "SmallerGroup" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Liability Set for Globe Export", "RollForward", false, false, 0, new string[2] { "LargerGroup", "SmallerGroup" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Payout Projection", "RollForward", false, true, dic);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Reconciliation to Baseline", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Liabilities Detailed Results", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);

            }

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE001CN", sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest_Prod, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest");
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" }, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" }, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_LargerGroup.xlsx", 16, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_SmallerGroup.xlsx", 16, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                //////////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_LargerGroup.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_SmallerGroup.xlsx", 4, 0, 0, 0, true);

            }


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Jubilee 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Parameter Print");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ParameterPrint_Standalone(sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            _gLib._MsgBox("", "please manually compare parameter print for the last node, and this client is finished");

        }



        public void t_CompareRpt_Conversion2008(string sOutputPension_Conversion2008)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE001CN", sOutputPension_Conversion2008_Prod, sOutputPension_Conversion2008);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Conversion2008");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_DeckPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_DeferredPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_GesamPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_MahoPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_PlanNamedVorst.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_PlanOne.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_PlanRen.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_TheSecondPlanRen.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" });

                _compareReportsLib.CompareExcel_Exact("ValuationSummary_DeckPlan.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_DeferredPlan.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_GesamPlan.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_MahoPlan.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_PlanNamedVorst.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_PlanOne.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_PlanRen.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_TheSecondPlanRen.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                //////////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }

        }

        public void t_CompareRpt_Pension2009(string sOutputPension_Pension2009)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE001CN", sOutputPension_Pension2009_Prod, sOutputPension_Pension2009);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Pension2009");
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_DeckPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_DeferredPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_GesamPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_MahoPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_PlanNamedVorst.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_PlanOne.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_PlanRen.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_TheSecondPlanRen.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_UVA2.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_UVA3.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_Pen1.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_Pen1.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_Pen1.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_Pen2.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_Pen2.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_Pen2.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" });

                _compareReportsLib.CompareExcel_Exact("ValuationSummary_DeckPlan.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_DeferredPlan.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_GesamPlan.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_MahoPlan.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_PlanNamedVorst.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_PlanOne.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_PlanRen.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_TheSecondPlanRen.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_UVA2.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_UVA3.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                //////////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_DeckPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_DeferredPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_GesamPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_MahoPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_PlanNamedVorst.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_PlanOne.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_PlanRen.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_TheSecondPlanRen.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_UVA2.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_UVA3.xlsx", 4, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_DeckPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_DeferredPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_GesamPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_MahoPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_PlanNamedVorst.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_PlanOne.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_PlanRen.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_TheSecondPlanRen.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_UVA2.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_UVA3.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        public void t_CompareRpt_JubileeConversion2008(string sOutputJubilee_JubileeConversion2008)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE001CN", sOutputJubilee_JubileeConversion2008_Prod, sOutputJubilee_JubileeConversion2008);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputJubilee_JubileeConversion2008");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_LargerGroup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_SmallerGroup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_LargerGroup.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_SmallerGroup.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                //////////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }

        }

        public void t_CompareRpt_Jubilee2009_Baseline(string sOutputJubilee_Jubilee2009_Baseline)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE001CN", sOutputJubilee_Jubilee2009_Baseline_Prod, sOutputJubilee_Jubilee2009_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputJubilee_Jubilee2009_Baseline");
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_LargerGroup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_SmallerGroup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_Jub1.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_Jub1.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_Jub1.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_LargerGroup.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_SmallerGroup.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                //////////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                //////////////_compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                //////////////_compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_LargerGroup.xlsx", 4, 0, 0, 0);
                //////////////_compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_SmallerGroup.xlsx", 4, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_LargerGroup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_SmallerGroup.xlsx", 4, 0, 0, 0);
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

