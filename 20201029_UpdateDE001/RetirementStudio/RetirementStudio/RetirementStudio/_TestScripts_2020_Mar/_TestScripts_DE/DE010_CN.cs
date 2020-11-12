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
using RetirementStudio._UIMaps.ContributionsBasedFormulaClasses;
using RetirementStudio._UIMaps.FutureValuationOptionClasses;
using RetirementStudio._UIMaps.PayCreditClasses;
using RetirementStudio._UIMaps.ActuarialReportClasses;
using RetirementStudio._UIMaps.SocialSecurityContributionCeilingsClasses;
using RetirementStudio._UIMaps.OneYearProjectionClasses;
using RetirementStudio._UIMaps.SocialSecurityClasses;
using RetirementStudio._UIMaps.VersorgungsausgleichClasses;
using RetirementStudio._UIMaps.CashBalanceClasses;
using RetirementStudio._UIMaps.UserDefinedProjectionAClasses;
using System.Threading;



namespace RetirementStudio._TestScripts_2019_Apr
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class DE010_CN
    {
        public DE010_CN()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.DE;
            Config.sClientName = "QA DE Benchmark 010 Existing DNT";
            Config.sPlanName = "QA DE Benchmark 010 Existing DNT Plan";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = false;
            Config.bCompareReports = false;
        }

        #region Report Output Directory


        public string sOutputPension_Conversion2010 = "";

        public string sOutputPension_Valuation2011_Baseline = "";
        public string sOutputPension_Valuation2011_ConstantNumberOfPlanMembers = "";
        public string sOutputPension_Valuation2011_IndividualBeneficiaryMethod = "";
        public string sOutputPension_Valuation2011_MultiplePasses = "";
        public string sOutputPension_Valuation2012_Baseline = "";
        public string sOutputPension_Valuation2012_MethodScreenChange = "";
        public string sOutputPension_Valuation2012_SecondMethodScreenChance = "";
        public string sOutputPension_Valuation2012_V67Enhancements = "";

        public string sOutputJubilee_Conversion2010 = "";
        public string sOutputJubilee_Valuation2011_Baseline = "";
        public string sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers = "";
        public string sOutputJubilee_Valuation2012_Baseline = "";
        public string sOutputJubilee_Valuation2012_TradeEAN = "";
        public string sOutputJubilee_Valuation2012_TradePUC = "";
        public string sOutputJubilee_Valuation2012_V67Enhancements = "";
        public string sOutputJubilee_Valuation2012_V69Enhancements = "";

        public string sOutput_Data2013 = "";


        public string sOutputPension_Conversion2010_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.3.2_20181204_E\Conversion2010\";
        public string sOutputJubilee_Conversion2010_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.3.2_20181204_E\Jubilee_Conversion2010\";

        public string sOutputPension_Valuation2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.3.2_20181204_E\Valuation2011_Baseline\";
        public string sOutputPension_Valuation2011_ConstantNumberOfPlanMembers_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.3.2_20181204_E\Valuation2011_ConstantNumberOfPlanMembers\";
        public string sOutputPension_Valuation2011_IndividualBeneficiaryMethod_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.3.2_20181204_E\Valuation2011_IndividualBeneficiaryMethod\";
        public string sOutputPension_Valuation2011_MultiplePasses_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.3.2_20181204_E\Valuation2011_MultiplePasses\";

        public string sOutputPension_Valuation2012_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.3.2_20181204_E\Valuation2012_Baseline\";
        public string sOutputPension_Valuation2012_MethodScreenChange_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.3.2_20181204_E\Valuation2012_MethodScreenChange\";
        public string sOutputPension_Valuation2012_SecondMethodScreenChance_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.3.2_20181204_E\Valuation2012_SecondMethodScreenChance\";
        public string sOutputPension_Valuation2012_V67Enhancements_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.3.2_20181204_E\Valuation2012_V67Enhancements\";

        public string sOutputJubilee_Valuation2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.3.2_20181204_E\Jubilee_Valuation2011_Baseline\";
        public string sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.3.2_20181204_E\Jubilee_Valuation2011_ConstantNumberOfPlanMembers\";

        public string sOutputJubilee_Valuation2012_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.3.2_20181204_E\Jubilee_Valuation2012_Baseline\";
        public string sOutputJubilee_Valuation2012_TradeEAN_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.3.2_20181204_E\Jubilee_Valuation2012_TradeEAN\";
        public string sOutputJubilee_Valuation2012_TradePUC_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.3.2_20181204_E\Jubilee_Valuation2012_TradePUC\";
        public string sOutputJubilee_Valuation2012_V67Enhancements_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.3.2_20181204_E\Jubilee_Valuation2012_V67Enhancements\";

        public string sOutputJubilee_Valuation2012_V69Enhancements_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.3.2_20181204_E\Jubilee_Valuation2012_V69Enhancements\";

        public string sOutput_Data2013_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.3.2_20181204_E\Data2013\";



        public void GenerateReportOuputDir()
        {

            pMain._SetLanguageAndRegional();

            _BenchmarkUser sCurrentUser = _gLib._ReturnCurrentUser();

            if (sCurrentUser.ToString() == "Others")
            {
                _gLib._MsgBox("Warning !!!", "Your are NOT allowed to create folders in R: drive, Please contact Cindy or Webber if you have to!");
                Environment.Exit(0);
            }
            else
            {
                string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\CreateNew";
                string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                ////  _gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                sOutputPension_Conversion2010 = _gLib._CreateDirectory(sMainDir + "\\Conversion 2010\\" + sPostFix + "\\");
                sOutputPension_Valuation2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\Valuation 2011\\Baseline\\" + sPostFix + "\\");
                sOutputPension_Valuation2011_ConstantNumberOfPlanMembers = _gLib._CreateDirectory(sMainDir + "\\Valuation 2011\\ConstantNumberOfPlanMembers\\" + sPostFix + "\\");
                sOutputPension_Valuation2011_IndividualBeneficiaryMethod = _gLib._CreateDirectory(sMainDir + "\\Valuation 2011\\IndividualBeneficiaryMethod\\" + sPostFix + "\\");
                sOutputPension_Valuation2011_MultiplePasses = _gLib._CreateDirectory(sMainDir + "\\Valuation 2011\\MultiplePasses\\" + sPostFix + "\\");
                sOutputPension_Valuation2012_Baseline = _gLib._CreateDirectory(sMainDir + "\\Valuation 2012\\Baseline\\" + sPostFix + "\\");
                sOutputPension_Valuation2012_MethodScreenChange = _gLib._CreateDirectory(sMainDir + "\\Valuation 2012\\MethodScreenChange\\" + sPostFix + "\\");
                sOutputPension_Valuation2012_SecondMethodScreenChance = _gLib._CreateDirectory(sMainDir + "\\Valuation 2012\\SecondMethodScreenChance\\" + sPostFix + "\\");
                sOutputPension_Valuation2012_V67Enhancements = _gLib._CreateDirectory(sMainDir + "\\Valuation 2012\\V67Enhancements\\" + sPostFix + "\\");

                sOutputJubilee_Conversion2010 = _gLib._CreateDirectory(sMainDir + "\\Jubilee Conversion 2010\\" + sPostFix + "\\");
                sOutputJubilee_Valuation2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2011\\Baseline\\" + sPostFix + "\\");
                sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2011\\ConstantNumberOfPlanMembers\\" + sPostFix + "\\");
                sOutputJubilee_Valuation2012_Baseline = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2012\\Baseline\\" + sPostFix + "\\");
                sOutputJubilee_Valuation2012_TradeEAN = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2012\\TradeEAN\\" + sPostFix + "\\");
                sOutputJubilee_Valuation2012_TradePUC = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2012\\TradePUC\\" + sPostFix + "\\");
                sOutputJubilee_Valuation2012_V67Enhancements = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2012\\V67Enhancements\\" + sPostFix + "\\");
                sOutputJubilee_Valuation2012_V69Enhancements = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2012\\V69Enhancements\\" + sPostFix + "\\");

                sOutput_Data2013 = _gLib._CreateDirectory(sMainDir + "\\Data Valuation2013\\" + sPostFix + "\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputPension_Conversion2010 = @\"" + sOutputPension_Conversion2010 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2011_Baseline = @\"" + sOutputPension_Valuation2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2011_ConstantNumberOfPlanMembers = @\"" + sOutputPension_Valuation2011_ConstantNumberOfPlanMembers + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2011_IndividualBeneficiaryMethod = @\"" + sOutputPension_Valuation2011_IndividualBeneficiaryMethod + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2011_MultiplePasses = @\"" + sOutputPension_Valuation2011_MultiplePasses + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2012_Baseline = @\"" + sOutputPension_Valuation2012_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2012_MethodScreenChange = @\"" + sOutputPension_Valuation2012_MethodScreenChange + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2012_SecondMethodScreenChance = @\"" + sOutputPension_Valuation2012_SecondMethodScreenChance + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2012_V67Enhancements = @\"" + sOutputPension_Valuation2012_V67Enhancements + "\";" + Environment.NewLine + Environment.NewLine;

            sContent = sContent + "sOutputJubilee_Conversion2010 = @\"" + sOutputJubilee_Conversion2010 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2011_Baseline = @\"" + sOutputJubilee_Valuation2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers = @\"" + sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2012_Baseline = @\"" + sOutputJubilee_Valuation2012_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2012_TradeEAN = @\"" + sOutputJubilee_Valuation2012_TradeEAN + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2012_TradePUC = @\"" + sOutputJubilee_Valuation2012_TradePUC + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2012_V67Enhancements = @\"" + sOutputJubilee_Valuation2012_V67Enhancements + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2012_V69Enhancements = @\"" + sOutputJubilee_Valuation2012_V69Enhancements + "\";" + Environment.NewLine;

            sContent = sContent + "sOutput_Data2013 = @\"" + sOutput_Data2013 + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);

        }


        #endregion



        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();
        public FutureValuationOption pFutureValuationOption = new FutureValuationOption();
        public UserDefinedProjectionA pUserDefinedProjectionA = new UserDefinedProjectionA();
        public CashBalance pCashBalance = new CashBalance();
        public Versorgungsausgleich pVersorgungsausgleich = new Versorgungsausgleich();
        public SocialSecurity pSocialSecurity = new SocialSecurity();
        public OneYearProjection pOneYearProjection = new OneYearProjection();
        public SocialSecurityContributionCeilings pSocialSecurityContributionCeilings = new SocialSecurityContributionCeilings();
        public ActuarialReport pActuarialReport = new ActuarialReport();
        public PayCredit pPayCredit = new PayCredit();
        public MyDictionary dic = new MyDictionary();
        public ContributionsBasedFormula pContributionsBasedFormula = new ContributionsBasedFormula();
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
        public void _test_DE010_CN()
        {



            string sNodeName_MethodScreenChange = "MethodScreenChange_wb";
            string sNodeName_SecondMethodScreenChance = "SecondMethodScreenChance_wb";
            string sNodeName_Jubi_TradeEAN = "TradeEAN_wb";
            string sNodeName_Jubi_TradeTUC = "TradeTUC_wb";

            string sDir = @"R:\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\";
            string sPostfix = "20190509_QA2_CN\\";

            sOutputPension_Valuation2012_MethodScreenChange = sDir + "Valuation 2012\\MethodScreenChange\\" + sPostfix;
            sOutputPension_Valuation2012_SecondMethodScreenChance = sDir + "Valuation 2012\\SecondMethodScreenChance\\" + sPostfix;
            sOutputJubilee_Valuation2012_TradeEAN = sDir + "Jubilee Valuation 2012\\TradeEAN\\" + sPostfix;
            sOutputJubilee_Valuation2012_TradePUC = sDir + "Jubilee Valuation 2012\\TradePUC\\" + sPostfix;


            #region Pension RF - Valuation 2012 - MethodScreenChange


            pMain._SelectTab("Valuation 2012");


            _gLib._MsgBoxYesNo("Manual", "Right click Baseline Node and select <Add Valuation Node>");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", sNodeName_MethodScreenChange);
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "true");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "");
            dic.Add("Provisions_Name", "");
            dic.Add("Provisions_Edit", "");
            dic.Add("Need_ActuarialReport", "true");
            dic.Add("FundingInformation_AddNew", "false");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Need_ActuarialReport", "true");
            dic.Add("FundingInformation_AddNew", "true");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sNodeName_MethodScreenChange + "> and select <Liability Methods> - <Edit Parameters>");




            pMain._SelectTab("Methods");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("CostMethod", "Projected Unit Credit Service Prorate");
            dic.Add("MembershipDate", "");
            dic.Add("AnnualIncreaseRate", "");
            dic.Add("EarliestEntryAgeMethod", "");
            dic.Add("EarliestEntryAge_txt", "");
            dic.Add("AllowNegativeNormal", "");
            pMethods_DE._Table_TradeLiability(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "Projected Unit Credit No Prorate");
            dic.Add("CompareToAccrued", "");
            dic.Add("AllowNegativeNormal", "");
            pMethods_DE._Table_InternationalAccounting(dic);


            _gLib._MsgBoxYesNo("Manual", "Check on all 6 checkbox for Trade in MethodOverrides_Table");



            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sNodeName_MethodScreenChange + "> and select <Report Breaks>");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BreakFields", "");
            dic.Add("TextSubstitution", "");
            dic.Add("Remove", "Click");
            dic.Add("OK", "");
            pReportBreaks._PopVerify_ReportBreaks(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BreakFields", "");
            dic.Add("TextSubstitution", "");
            dic.Add("Remove", "Click");
            dic.Add("OK", "Click");
            pReportBreaks._PopVerify_ReportBreaks(dic);


            pMain._SelectTab("Valuation 2012");


            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sNodeName_MethodScreenChange + "> and select <Run - Liabilities>");



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
            dic.Add("Pay", "PP_ProjectedPay");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "false");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "true");
            dic.Add("SelectVOs_VO1", "");
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


            pMain._SelectTab("Valuation 2012");


            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sNodeName_MethodScreenChange + "> and select <View Run Status>");



            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._Home_ToolbarClick_Top(true);




            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sNodeName_MethodScreenChange + "> and select <Run - Future Valuation Population Projection>");





            pMain._SelectTab("Valuation 2012");


            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sNodeName_MethodScreenChange + "> and select <View Run Status>");



            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sNodeName_MethodScreenChange + "> and select <Run - Future Valuation Liabilities>");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PP_ProjectedPay");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "true");
            dic.Add("SelectVOs_VO1", "");
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


            pMain._SelectTab("Valuation 2012");


            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sNodeName_MethodScreenChange + "> and select <View Run Status>");

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sNodeName_MethodScreenChange + "> and select <View Output>");




            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Valuation Summary", "RollForward", true, true, 0, new string[1] { "All" });
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Liabilities Detailed Results", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Population Projection", "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Liabilities by Group", "RollForward", true, true, 0, new string[1] { "All" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Liabilities by Year", "RollForward", true, true, 0, new string[1] { "All" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Summary", "RollForward", true, true, 0, new string[1] { "All" });
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Individual Population Projection", "RollForward", true, true);

            _gLib._MsgBoxYesNo("sOutputPension_Valuation2012_MethodScreenChange", "Finished");



            #endregion


            #region  Pension RF - Valuation 2012 - SecondMethodScreenChance

            pMain._SelectTab("Valuation 2012");


            _gLib._MsgBoxYesNo("Manual", "Right click Baseline Node and select <Add Valuation Node>");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", sNodeName_SecondMethodScreenChance);
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "True");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "");
            dic.Add("Provisions_Name", "");
            dic.Add("Provisions_Edit", "");
            dic.Add("Need_ActuarialReport", "true");
            dic.Add("FundingInformation_AddNew", "false");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Need_ActuarialReport", "true");
            dic.Add("FundingInformation_AddNew", "true");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_SecondMethodScreenChance + "> and select <Liability Methods - Edit Parameters>");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("CostMethod", "Entry Age Normal");
            dic.Add("MembershipDate", "MembershipDate1");
            dic.Add("AnnualIncreaseRate", "#1#");
            dic.Add("EarliestEntryAgeMethod", "According to Tax Law");
            dic.Add("EarliestEntryAge_txt", "");
            dic.Add("AllowNegativeNormal", "");
            pMethods_DE._Table_TradeLiability(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "Traditional Unit Credit");
            dic.Add("CompareToAccrued", "");
            dic.Add("AllowNegativeNormal", "True");
            pMethods_DE._Table_InternationalAccounting(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab("Valuation 2012");


            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_SecondMethodScreenChance + "> and select <Run Methods - Liabilities>");


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
            dic.Add("Pay", "PP_ProjectedPay");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "true");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "");
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

            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_SecondMethodScreenChance + "> and select <View Run Status>");



            pMain._EnterpriseRun("Group Job Successfully Complete", true, "Val Liab");


            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_SecondMethodScreenChance + "> and select <Run - Future Valuation Population Projection>");



            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_SecondMethodScreenChance + "> and select <View Run Status>");



            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_SecondMethodScreenChance + "> and select <Future Valuation Liabilities>");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PP_ProjectedPay");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "true");
            dic.Add("SelectVOs_VO1", "");
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



            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_SecondMethodScreenChance + "> and select <View Run Status>");

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_SecondMethodScreenChance + "> and select <View Output>");

            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Valuation Summary", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Liabilities Detailed Results", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Population Projection", "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Summary", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Liabilities by Group", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Liabilities by Year", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Individual Population Projection", "RollForward", true, true);

            _gLib._MsgBoxYesNo("sOutputPension_Valuation2012_SecondMethodScreenChance", "Finished");


            #endregion

            
            #region Jubilee RF - Valuation 2012 - Trade EAN

            _gLib._MsgBoxYesNo("Manual", "Please open Jubiliee Valuation <Valuation 2012>");


            pMain._SelectTab("Valuation 2012");


            _gLib._MsgBoxYesNo("Manual", "Right click Baseline Node and select <Add Valuation Node>");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", sNodeName_Jubi_TradeEAN);
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "True");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "");
            dic.Add("Provisions_Name", "");
            dic.Add("Provisions_Edit", "");
            dic.Add("Need_ActuarialReport", "true");
            dic.Add("FundingInformation_AddNew", "false");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Need_ActuarialReport", "true");
            dic.Add("FundingInformation_AddNew", "true");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);



            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_Jubi_TradeEAN + "> and select <Liability Methods - Edit Parameters>");


            pMain._SelectTab("Methods");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "Entry Age Normal");
            dic.Add("AnnualIncreaseRate", "#1#");
            pMethods_DE._Table_TradeLiability_Jubilee(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_Jubi_TradeEAN + "> and select <Run - Liabilities>");



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
            dic.Add("Pay", "JubiSalaryCurrentYear");
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
            dic.Add("SelectVOs_VO1", "");
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


            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_Jubi_TradeEAN + "> and select <View Run Status>");


            pMain._EnterpriseRun("Group Job Completed With Errors", true);



            pMain._SelectTab("Valuation 2012");


            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_Jubi_TradeEAN + "> and select <Run - Future Valuation Population Projection>");


            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_Jubi_TradeEAN + "> and select <View Run Status>");


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_Jubi_TradeEAN + "> and select <Run - Future Valuation Liabilities>");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PP_JubileeSalary");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreaksBasedOnData", "Original");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_Jubi_TradeEAN + "> and select <View Run Status>");

            pMain._EnterpriseRun("Group Job Completed With Errors", true);


            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_Jubi_TradeEAN + "> and select <View output>");



            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Valuation Summary", "RollForward", true, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Liabilities Detailed Results", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Future Valuation Population Projection", "RollForward", true, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Future Valuation Liabilities by Group", "RollForward", true, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Future Valuation Liabilities by Year", "RollForward", true, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Future Valuation Summary", "RollForward", true, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Future Valuation Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Future Valuation Individual Population Projection", "RollForward", true, false);

            _gLib._MsgBoxYesNo("sOutputJubilee_Valuation2012_TradeEAN", "Finished");




            #endregion


            #region  Jubilee RF - Valuation 2012 - Trade PUC

            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click Baseline Node and select <Add Valuation Node>");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", sNodeName_Jubi_TradeTUC);
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
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
            dic.Add("Need_ActuarialReport", "true");
            dic.Add("FundingInformation_AddNew", "false");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Need_ActuarialReport", "true");
            dic.Add("FundingInformation_AddNew", "true");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_Jubi_TradeTUC + "> and select <Liability Methods - Edit Parameters>");

            

            pMain._SelectTab("Methods");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("CostMethod", "Projected Unit Credit Service Prorate");
            dic.Add("MembershipDate", "");
            dic.Add("AnnualIncreaseRate", "");
            dic.Add("EarliestEntryAgeMethod", "");
            dic.Add("EarliestEntryAge_txt", "");
            dic.Add("AllowNegativeNormal", "");
            pMethods_DE._Table_TradeLiability(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("VOShortName", "");
            dic.Add("BenefitDefinition", "");
            dic.Add("Trade", "True");
            dic.Add("IntAcctng", "");
            dic.Add("PUCOverride", "");
            dic.Add("TUCOverride", "");
            pMethods_DE._MethodOverrieds_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "");
            dic.Add("iRow", "2");
            dic.Add("VOShortName", "");
            dic.Add("BenefitDefinition", "");
            dic.Add("Trade", "True");
            dic.Add("IntAcctng", "");
            dic.Add("PUCOverride", "");
            dic.Add("TUCOverride", "");
            pMethods_DE._MethodOverrieds_Table(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_Jubi_TradeTUC + "> and select <Report Breaks>");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BreakFields", "");
            dic.Add("Remove", "Click");
            dic.Add("TextSubstitution", "");
            dic.Add("OK", "");
            pReportBreaks._PopVerify_ReportBreaks(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BreakFields", "");
            dic.Add("Remove", "Click");
            dic.Add("TextSubstitution", "");
            dic.Add("OK", "Click");
            pReportBreaks._PopVerify_ReportBreaks(dic);



            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_Jubi_TradeTUC + "> and select <Run - Liabilities>");


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
            dic.Add("Pay", "JubiSalaryCurrentYear");
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
            dic.Add("SelectVOs_VO1", "");
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


            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_Jubi_TradeTUC + "> and select <View Run Status>");


            pMain._EnterpriseRun("Group Job Completed With Errors", true);


            pMain._SelectTab("Valuation 2012");



            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_Jubi_TradeTUC + "> and select <Future Valuation Options>");



            pFutureValuationOption._SelectTab("Participant grouping");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GroupingByStatusCodes", "");
            dic.Add("CustomGroupingByBreakField", "");
            dic.Add("CustomGroupingByBreakField_Cbo", "");
            dic.Add("CustomGroupingBySelectionCriteria", "true");
            dic.Add("AddRow", "click");
            dic.Add("iRowNum", "1");
            dic.Add("Group", "Sub1");
            dic.Add("SelectionCriteria", "$emp.SubsidiaryCode=\"Sub1\"");
            dic.Add("Remove", "");
            dic.Add("Validate", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            pFutureValuationOption._ParticipantGrouping(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GroupingByStatusCodes", "");
            dic.Add("CustomGroupingByBreakField", "");
            dic.Add("CustomGroupingByBreakField_Cbo", "");
            dic.Add("CustomGroupingBySelectionCriteria", "");
            dic.Add("AddRow", "click");
            dic.Add("iRowNum", "2");
            dic.Add("Group", "Sub2");
            dic.Add("SelectionCriteria", "$emp.SubsidiaryCode=\"Sub2\"");
            dic.Add("Remove", "");
            dic.Add("Validate", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            pFutureValuationOption._ParticipantGrouping(dic);


            pFutureValuationOption._SelectTab("Population size");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ModelPopulationSizePerParticipantGroup", "true");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "");
            dic.Add("PopulationSizeOption", "Growth rate %");
            dic.Add("iColName", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._PropulationSize(dic);


            for (int i = 2012; i <= 2031; i++)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "1");
                dic.Add("ParticipantGroup", "");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2012 + 2).ToString());
                dic.Add("iColValue", "0,00");
                pFutureValuationOption._PropulationSize(dic);
            }



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ModelPopulationSizePerParticipantGroup", "true");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "");
            dic.Add("PopulationSizeOption", "Growth rate %");
            dic.Add("iColName", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._PropulationSize(dic);

            for (int i = 2012; i <= 2031; i++)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "2");
                dic.Add("ParticipantGroup", "");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2012 + 2).ToString());
                dic.Add("iColValue", "5,00");
                pFutureValuationOption._PropulationSize(dic);
            }



            pFutureValuationOption._SelectTab("New entrants");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectionCriteria", "$emp.EmployeeIDNumber=127 AND $emp.VOShortName=\"JUBI02\"");
            dic.Add("iResultRow", "1");
            pFutureValuationOption._AddTestCase(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectionCriteria", "$emp.EmployeeIDNumber=118 AND $emp.VOShortName=\"JUBI02\"");
            dic.Add("iResultRow", "1");
            pFutureValuationOption._AddTestCase(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectionCriteria", "$emp.EmployeeIDNumber=118 AND $emp.VOShortName=\"JUBI01\"");
            dic.Add("iResultRow", "1");
            pFutureValuationOption._AddTestCase(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectionCriteria", "$emp.EmployeeIDNumber=14 AND $emp.VOShortName=\"JUBI01\"");
            dic.Add("iResultRow", "1");
            pFutureValuationOption._AddTestCase(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAllFromLibrary", "");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "Sub2");
            dic.Add("iColNum", "");
            dic.Add("VOShortName", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAllFromLibrary", "");
            dic.Add("iRowNum", "3");
            dic.Add("ParticipantGroup", "Sub2");
            dic.Add("iColNum", "");
            dic.Add("VOShortName", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("iCount", "195");
            dic.Add("iColumn", "");
            dic.Add("sColumn", "");
            pFutureValuationOption._NewEntrants_VerifyColnum(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("iCount", "");
            dic.Add("iColumn", "2");
            dic.Add("sColumn", "NewEntrantID");
            pFutureValuationOption._NewEntrants_VerifyColnum(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("iCount", "");
            dic.Add("iColumn", "5");
            dic.Add("sColumn", "Gender");
            pFutureValuationOption._NewEntrants_VerifyColnum(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("iCount", "");
            dic.Add("iColumn", "10");
            dic.Add("sColumn", "MaritalStatus");
            pFutureValuationOption._NewEntrants_VerifyColnum(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("iCount", "");
            dic.Add("iColumn", "20");
            dic.Add("sColumn", "Pay1PriorYear2");
            pFutureValuationOption._NewEntrants_VerifyColnum(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("iCount", "");
            dic.Add("iColumn", "50");
            dic.Add("sColumn", "Benefit1DB");
            pFutureValuationOption._NewEntrants_VerifyColnum(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("iCount", "");
            dic.Add("iColumn", "80");
            dic.Add("sColumn", "Service (SVSocSecEndDate)");
            pFutureValuationOption._NewEntrants_VerifyColnum(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("iCount", "");
            dic.Add("iColumn", "100");
            dic.Add("sColumn", "UnionFlag");
            pFutureValuationOption._NewEntrants_VerifyColnum(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("iCount", "");
            dic.Add("iColumn", "120");
            dic.Add("sColumn", "LYBookReserve");
            pFutureValuationOption._NewEntrants_VerifyColnum(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("iCount", "");
            dic.Add("iColumn", "140");
            dic.Add("sColumn", "LYTeilwertTrade");
            pFutureValuationOption._NewEntrants_VerifyColnum(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("iCount", "");
            dic.Add("iColumn", "160");
            dic.Add("sColumn", "LYPensionBenRetAgeTrade");
            pFutureValuationOption._NewEntrants_VerifyColnum(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("iCount", "");
            dic.Add("iColumn", "190");
            dic.Add("sColumn", "gainLossParticipantReconciliationSubCodeDesc");
            pFutureValuationOption._NewEntrants_VerifyColnum(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("iCount", "");
            dic.Add("iColumn", "195");
            dic.Add("sColumn", "participantConsolidatedCodeId");
            pFutureValuationOption._NewEntrants_VerifyColnum(dic);


            //////////   set  Gender = F
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "Gender");
            dic.Add("iRowNum", "2");
            dic.Add("iColValue", "F");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "Gender");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "F");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            //////////   set  PSVLiabilityOther = 0,000
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "PSVLiabilityOther");
            dic.Add("iRowNum", "2");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "PSVLiabilityOther");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            //////////  set  SubsidiaryCode = Sub2
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "SubsidiaryCode");
            dic.Add("iRowNum", "2");
            dic.Add("iColValue", "Sub2");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "SubsidiaryCode");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "Sub2");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            //////////  set  WhatIsTested = Blank          
            for (int i = 1; i <= 3; i++)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("sColName", "WhatIsTested");
                dic.Add("iRowNum", i.ToString());
                dic.Add("iColValue", "");
                pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);
            }


            //////////  set  LYOverwriteResults = 1,0,0,0
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYOverwriteResults");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "1");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYOverwriteResults");
            dic.Add("iRowNum", "2");
            dic.Add("iColValue", "0");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYOverwriteResults");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "0");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYOverwriteResults");
            dic.Add("iRowNum", "4");
            dic.Add("iColValue", "0");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            //////////  set  LYAliveStatusResult = XY
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYAliveStatusResult");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "XY");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYAliveStatusResult");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYAliveStatusResult");
            dic.Add("iRowNum", "4");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            //////////  set  LYHealthStatusResult = H
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYHealthStatusResult");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "H");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYHealthStatusResult");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYHealthStatusResult");
            dic.Add("iRowNum", "4");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            //////////  set  LYParticipantStatusResult = AC
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYParticipantStatusResult");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "AC");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYParticipantStatusResult");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYParticipantStatusResult");
            dic.Add("iRowNum", "4");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            //////////  set  LYPayStatusResult = DEF
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYPayStatusResult");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "DEF");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYPayStatusResult");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYPayStatusResult");
            dic.Add("iRowNum", "4");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            //////////  set  LYPremiumTaxResult= 371,0000
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYPremiumTaxResult");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "371,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYPremiumTaxResult");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYPremiumTaxResult");
            dic.Add("iRowNum", "4");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            //////////  set  LYTeilwertNYTradeResult= 2730,060
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYTeilwertNYTradeResult");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "2730,060");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYTeilwertNYTradeResult");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYTeilwertNYTradeResult");
            dic.Add("iRowNum", "4");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            //////////  LYTeilwertNYResult= 391,657
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYTeilwertNYResult");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "391,657");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            ////////////  set  LYTradeALResult= 2272,000
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYTradeALResult");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "2272,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYTradeALResult");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYTradeALResult");
            dic.Add("iRowNum", "4");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            ////////////  set  LYTradeNCResult= 325,000
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYTradeNCResult");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "325,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYTradeNCResult");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYTradeNCResult");
            dic.Add("iRowNum", "4");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            ////////////  set  LYUSCResult= 10
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYUSCResult");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "10");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYUSCResult");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "0");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LYUSCResult");
            dic.Add("iRowNum", "4");
            dic.Add("iColValue", "0");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            ////////////  set  EeAccountBalance1= 5000,00
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "EeAccountBalance1");
            dic.Add("iRowNum", "2");
            dic.Add("iColValue", "0,00");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "EeAccountBalance1");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "0,00");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            ////////////  set  LegacyTaxNC= 385,910
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LegacyTaxNC");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "385,910");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LegacyTaxNC");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "0,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LegacyTaxNC");
            dic.Add("iRowNum", "4");
            dic.Add("iColValue", "0,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            ////////////  set  LegacyTradeAL= 1877,000
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LegacyTradeAL");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "1877,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LegacyTradeAL");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "0,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LegacyTradeAL");
            dic.Add("iRowNum", "4");
            dic.Add("iColValue", "0,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            ////////////  set  LegacyTradeNC= 313,000
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LegacyTradeNC");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "313,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LegacyTradeNC");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "0,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LegacyTradeNC");
            dic.Add("iRowNum", "4");
            dic.Add("iColValue", "0,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            ////////////  set  LegacyIntAccountingPBOAL= 1930,000
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LegacyIntAccountingPBOAL");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "1930,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LegacyIntAccountingPBOAL");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "0,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LegacyIntAccountingPBOAL");
            dic.Add("iRowNum", "4");
            dic.Add("iColValue", "0,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            ////////////  set  LegacyIntAccountingPBONC= 321,000
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LegacyIntAccountingPBONC");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "321,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LegacyIntAccountingPBONC");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "0,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LegacyIntAccountingPBONC");
            dic.Add("iRowNum", "4");
            dic.Add("iColValue", "0,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            ////////////  set  LegacyIntAccountingABOAL= 1094,000
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LegacyIntAccountingABOAL");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "1094,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LegacyIntAccountingABOAL");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "0,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LegacyIntAccountingABOAL");
            dic.Add("iRowNum", "4");
            dic.Add("iColValue", "0,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            ////////////  set  LegacyIntAccountingABONC= 182,000
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LegacyIntAccountingABONC");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "182,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LegacyIntAccountingABONC");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "0,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "LegacyIntAccountingABONC");
            dic.Add("iRowNum", "4");
            dic.Add("iColValue", "0,000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            ////////////  set  participantReconciliationcodeDesc= Continuing Actives
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "participantReconciliationcodeDesc");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "Continuing Actives");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "participantReconciliationcodeDesc");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "New Entrant");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "participantReconciliationcodeDesc");
            dic.Add("iRowNum", "4");
            dic.Add("iColValue", "New Entrant");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            ////////////  set  participantReconciliationCodeId= 2,1,1,1
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "participantReconciliationCodeId");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "2");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "participantReconciliationCodeId");
            dic.Add("iRowNum", "2");
            dic.Add("iColValue", "1");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "participantReconciliationCodeId");
            dic.Add("iRowNum", "3");
            dic.Add("iColValue", "1");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "participantReconciliationCodeId");
            dic.Add("iRowNum", "4");
            dic.Add("iColValue", "1");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UsingRates_P", "click");
            dic.Add("UsingRates_T", "");
            dic.Add("UsingRates_txt", "3,0");
            dic.Add("UsingRates_cbo", "");
            pFutureValuationOption._NewEntrants_UsingRates(dic);



            pFutureValuationOption._SelectTab("Annuity benefit grouping");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllBenfitDefinitionsInOneGroup", "");
            dic.Add("ByDecrement", "true");
            dic.Add("CustomGroupingByBenefitDefinitions", "");
            dic.Add("AddRow", "");
            dic.Add("GroupName", "");
            dic.Add("Includes_DeathLiab", "");
            dic.Add("Includes_DisabilitLiab", "");
            dic.Add("Includes_InactiveLiab", "");
            dic.Add("Includes_RetirementLiab", "");
            dic.Add("Includes_WithDrawalLiab", "");
            dic.Add("OK", "");
            pFutureValuationOption._AnnuityBen_And_LumpSum(dic);


            pFutureValuationOption._SelectTab("Lump sum benefit grouping");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllBenfitDefinitionsInOneGroup", "");
            dic.Add("ByDecrement", "true");
            dic.Add("CustomGroupingByBenefitDefinitions", "");
            dic.Add("AddRow", "");
            dic.Add("GroupName", "");
            dic.Add("Includes_DeathLiab", "");
            dic.Add("Includes_DisabilitLiab", "");
            dic.Add("Includes_InactiveLiab", "");
            dic.Add("Includes_RetirementLiab", "");
            dic.Add("Includes_WithDrawalLiab", "");
            dic.Add("OK", "");
            pFutureValuationOption._AnnuityBen_And_LumpSum(dic);



            pFutureValuationOption._SelectTab("Projection years");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EveryYearForTheFirst", "");
            dic.Add("AndEvery", "");
            dic.Add("UpToincludingProjectionYear", "");
            dic.Add("ProjectionYears", "");
            dic.Add("NumberOfRuns", "3");
            dic.Add("RandomNumDismissed", "5");
            pFutureValuationOption._ProjectionYears(dic);


            pFutureValuationOption._SelectTab("Future assumptions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AlignRatesWithCurrent", "");
            dic.Add("AlignRatesWithEach", "true");
            pFutureValuationOption._FutureAssumptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pFutureValuationOption._PopVerify_OK(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Valuation 2012");


            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_Jubi_TradeTUC + "> and select <Run - Future Valuation Population Projection>");

            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_Jubi_TradeTUC + "> and select <View Run Status>");



            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");



            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_Jubi_TradeTUC + "> and select <Run - Future Valuation Liabilities>");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PP_JubileeSalary");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreaksBasedOnData", "Original");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_Jubi_TradeTUC + "> and select <View Run Status>");

            pMain._EnterpriseRun("Group Job Completed With Errors", true);


            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBoxYesNo("Manual", "Right click newly added Node <" + sNodeName_Jubi_TradeTUC + "> and select <View Output>");


            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Valuation Summary", "RollForward", true, false, 0, new string[1] { "All" });
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Liabilities Detailed Results", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Population Projection", "RollForward", true, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Liabilities by Group", "RollForward", true, false, 0, new string[1] { "All" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Liabilities by Year", "RollForward", true, false, 0, new string[1] { "All" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Summary", "RollForward", true, false, 0, new string[1] { "All" });
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Individual Population Projection", "RollForward", true, false);

            _gLib._MsgBoxYesNo("sOutputJubilee_Valuation2012_TradePUC", "Finished");

            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);

            #endregion


            _gLib._MsgBoxYesNo("Congratulations!", "Finished");

        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

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
