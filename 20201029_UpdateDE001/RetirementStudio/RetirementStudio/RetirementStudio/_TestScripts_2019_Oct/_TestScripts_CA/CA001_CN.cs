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
using System.Threading;


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
using RetirementStudio._UIMaps.DefinedBenefitLimitIncreaseClasses;
using RetirementStudio._UIMaps.FromToAgeClasses;
using RetirementStudio._UIMaps.AverageYMPEClasses;
using RetirementStudio._UIMaps.FAEFormulaClasses;
using RetirementStudio._UIMaps.EmployeeContributionsFormulaClasses;
using RetirementStudio._UIMaps.CostOfLivingAdjustmentsClasses;
using RetirementStudio._UIMaps.EarlyRetirementFactorClasses;
using RetirementStudio._UIMaps.AdjustmentsClasses;
using RetirementStudio._UIMaps.MaxPensionDefinitionClasses;
using RetirementStudio._UIMaps.ExcessContributionDefinitionClasses;
using RetirementStudio._UIMaps.BenefitElectionsClasses;
using RetirementStudio._UIMaps.ITAMaximumPensionsClasses;


namespace RetirementStudio._TestScripts_2019_Oct_CA
{
    /// <summary>
    /// Summary description for CA001_CN
    /// </summary>
    [CodedUITest]
    public class CA001_CN
    {
        public CA001_CN()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.CA;
            Config.sDataCenter = "Dallas";
            Config.sClientName = "QA CA Benchmark 001 Create New D";
            Config.sPlanName = "QA CA Benchmark 001 Create New Plan";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }


        #region Report Output Directory

        public string sOutputFunding_Funding2011_Baseline = "";
        public string sOutputFunding_Funding2011_NewValuation = "";
        public string sOutputFunding_WindUpGL2011 = "";
        public string sOutputAccounting_Accounting2008 = "";

        public string sOutputFunding_Funding2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_CA_Benchmark_1\Production\Funding2011\Baseline\6.7.2_20151026\";
        public string sOutputFunding_Funding2011_NewValuation_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_CA_Benchmark_1\Production\Funding2011\NewValuation\6.7.2_20151026\";
        public string sOutputFunding_WindUpGL2011_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_CA_Benchmark_1\Production\WindUpGL2011\6.7.2_20151026\";
        public string sOutputAccounting_Accounting2008_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_CA_Benchmark_1\Production\Accounting2008\6.7.2_20151026\";




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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_CA_Benchmark_1\CreateNew\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputFunding_Funding2011_Baseline = _gLib._CreateDirectory(sMainDir + "Funding2011\\Baseline\\" + sPostFix + "\\");
                    sOutputFunding_Funding2011_NewValuation = _gLib._CreateDirectory(sMainDir + "Funding2011\\NewValuation\\" + sPostFix + "\\");
                    sOutputFunding_WindUpGL2011 = _gLib._CreateDirectory(sMainDir + "WindUpGL2011\\" + sPostFix + "\\");
                    sOutputAccounting_Accounting2008 = _gLib._CreateDirectory(sMainDir + "Accounting2008\\" + sPostFix + "\\");
                }

            }

            string sContent = "";
            sContent = sContent + "sOutputFunding_Funding2011_Baseline = @\"" + sOutputFunding_Funding2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Funding2011_NewValuation = @\"" + sOutputFunding_Funding2011_NewValuation + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_WindUpGL2011 = @\"" + sOutputFunding_WindUpGL2011 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Accounting2008 = @\"" + sOutputAccounting_Accounting2008 + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);


        }


        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();

        public ITAMaximumPensions pITAMaximumPensions = new ITAMaximumPensions();
        public BenefitElections pBenefitElections = new BenefitElections();
        public ExcessContributionDefinition pExcessContributionDefinition = new ExcessContributionDefinition();
        public MaxPensionDefinition pMaxPensionDefinition = new MaxPensionDefinition();
        public Adjustments pAdjustments = new Adjustments();
        public EarlyRetirementFactor pEarlyRetirementFactor = new EarlyRetirementFactor();
        public CostOfLivingAdjustments pCostOfLivingAdjustments = new CostOfLivingAdjustments();
        public EmployeeContributionsFormula pEmployeeContributionsFormula = new EmployeeContributionsFormula();
        public FAEFormula pFAEFormula = new FAEFormula();
        public AverageYMPE pAverageYMPE = new AverageYMPE();
        public FromToAge pFromToAge = new FromToAge();
        public DefinedBenefitLimitIncrease pDefinedBenefitLimitIncrease = new DefinedBenefitLimitIncrease();
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

        #endregion


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_CA001_CN()
        {



           
            #region MultiThreads


            Thread thrd_Accounting2008 = new Thread(() => new CA001_CN().t_CompareRpt_Accounting_Accounting2008(sOutputAccounting_Accounting2008));
            Thread thrd_Funding2011_Baseline = new Thread(() => new CA001_CN().t_CompareRpt_Funding_Funding2011_Baseline(sOutputFunding_Funding2011_Baseline));
            Thread thrd_Funding2011_NewValuation = new Thread(() => new CA001_CN().t_CompareRpt_Funding_Funding2011_NewValuation(sOutputFunding_Funding2011_NewValuation));


            #endregion


            this.GenerateReportOuputDir();


            #region Accounting - Accounting2008


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            _gLib._MsgBox("", "please delete Conversion service");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "Accounting2008");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "2008");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "");
            dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("SelectAllVO", "");
            dic.Add("DeselectAll", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Accounting2008");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Accounting2008");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Data");
            dic.Add("MenuItem_2", "Copy Data...");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceType", "FundingValuations");
            dic.Add("ServiceInstance", "Funding2008");
            dic.Add("iItemIndex", "1");
            dic.Add("OK", "Click");
            pMain._PopVerify_CopyParticipantDataSet(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Accounting2008");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Copy Provisions...");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", "");
            dic.Add("Plan", "");
            dic.Add("ServiceType", "FundingValuations");
            dic.Add("ServiceInstance", "Funding2008");
            dic.Add("iTableItemIndex", "2");
            dic.Add("CopyAllParameters", "");
            dic.Add("CopyParameterChanges", "");
            dic.Add("OK", "click");
            pMain._PopVerify_CopyProvisionSet(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Accounting2008");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "AgePlus1");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "AgePlus1");
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
            dic.Add("DateConstant", "01/01/2009");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Accounting2008");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "6.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "Accum");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "Accum");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "6.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("MenuItem", "Add Pay Increase");
            pAssumptions._TreeViewRightSelect(dic, "PayInc");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "PayInc");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "click");
            dic.Add("btnT", "");
            dic.Add("txtRate", "4.0");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Cost of Living Increase");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2.5");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Defined Benefit Limit Increase");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("V", "");
            dic.Add("Percent", "click");
            dic.Add("T", "");
            dic.Add("txtRate", "3.0");
            pDefinedBenefitLimitIncrease._PopVerify_DefinedBenefitLimitIncrease(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "YMPE");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("V", "");
            dic.Add("Percent", "click");
            dic.Add("T", "");
            dic.Add("txtRate", "3.0");
            pDefinedBenefitLimitIncrease._PopVerify_DefinedBenefitLimitIncrease(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ApplyPercentMarriedAt", "Primary decrement");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "75.0");
            dic.Add("txtPercentMarried_F", "75.0");
            dic.Add("cboPercentMarried", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "-3");
            dic.Add("txtDifferenceInSpouseAge_F", "3");
            dic.Add("cboDifferenceInSpouseAge", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "_Death");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "UP94S15");
            dic.Add("Mortality_Setback_M", "");
            dic.Add("Mortality_Setback_F", "");
            dic.Add("Disabled", "");
            dic.Add("Disabled_Setback_M", "");
            dic.Add("Disabled_Setback_F", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "RETNAC");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "From55");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "WTHNAC");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "From55");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Accounting2008");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("iRow", "6");
            dic.Add("sName", "PVPost2001");
            dic.Add("sStatus", "False");
            pMethods._BenefitsToInclude_GoingConcern(dic);

            dic.Clear();
            dic.Add("iRow", "13");
            dic.Add("sName", "SolvencyExcess");
            dic.Add("sStatus", "False");
            pMethods._BenefitsToInclude_GoingConcern(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "");
            dic.Add("ServiceForServiceProrate", "Credited");
            dic.Add("CompareToAccrue", "false");
            dic.Add("AllowNegativeNormalCost", "true");
            dic.Add("NormalCostForCYTermination", "Yes");
            dic.Add("GrowIn_Age", "");
            dic.Add("GrowIn_Service", "");
            dic.Add("MaxValue_StartAge", "");
            dic.Add("MaxValue_StopAge", "");
            pMethods._PopVerify_Methods_CA(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "");
            dic.Add("ServiceForServiceProrate", "");
            dic.Add("CompareToAccrue", "");
            dic.Add("AllowNegativeNormalCost", "");
            dic.Add("ProjectedpayToUse", "");
            dic.Add("ProjectedpayToUse_CA", "ProjectedPay");
            dic.Add("AccumulationToUse", "EEContributions");
            dic.Add("IncludeExitYearValue", "false");
            dic.Add("CalculatePresentValueOfFuture", "");
            dic.Add("CalculatePresentValueOfFuture_txt", "");
            dic.Add("VestingToUseForAgeFirstVested", "");
            dic.Add("AverageWorkingLifeTime", "true");
            dic.Add("AverageLifeTime", "");
            dic.Add("AverageWorkingLifeTimeToVesting", "");
            dic.Add("AverageWorkingLifeTimeForBenefitingEE", "false");
            pMethods._PopVerify_Methods_Accounting(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Accounting2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"05/06/1966\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"08/15/1961\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Accounting2008");


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
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "Credited");
            dic.Add("Pay", "ProjectedPay");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "EEContributions");
            dic.Add("Pension", "AccruedBenefit1");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "");
            dic.Add("SolvencyLiability", "");
            dic.Add("WindUpLiability", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Accounting2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Accounting2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2008, "Parameter Print", "Conversion", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2008, "Test Cases", "Conversion", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2008, "Liability Summary", "Conversion", false, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputAccounting_Accounting2008, "Liability Summary", "Conversion", false, false, 0);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2008, "Member Statistics", "Conversion", false, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputAccounting_Accounting2008, "Conversion Diagnostic", "Conversion", false, false, 0);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2008, "Conversion Diagnostic", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2008, "Test Case List", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2008, "Detailed Results", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2008, "Detailed Results by Plan Def", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2008, "Valuation Summary", "Conversion", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2008, "Individual Output", "Conversion", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2008, "IOE", "Conversion", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Accounting2008, "Payout Projection", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2008, "FAS Expected Benefit Pmts", "Conversion", false, false);

            thrd_Accounting2008.Start();



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Accounting2008");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            #region Funding - Funding2011_Baseline

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            _gLib._MsgBox("", "please delete all RollForward services");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "Funding2011");
            dic.Add("Parent", "Funding2008");
            dic.Add("ParentFinalValuationSet", "New DAMP Node");
            dic.Add("PlanYearBeginningIn", "2011");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "Click");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Funding2011");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Funding2011");

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
            dic.Add("Snapshot", "true");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("CompareData", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Revised ValuationData");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "true");
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
            dic.Add("CompareData", "");
            dic.Add("ImportDataandApplyMapping", "Click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Funding2011");

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
            dic.Add("GL_GoingConcern", "True");
            dic.Add("GL_Solvency", "True");
            dic.Add("PayoutProjection", "false");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "true");
            dic.Add("CalcIncreCostSolvencyWindup", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "ProjectedPay");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "ContribsWInterest1");
            dic.Add("Pension", "AccruedBenefit1");
            dic.Add("AllLiabilityTypes", "false");
            dic.Add("GoingConcernLiability", "True");
            dic.Add("SolvencyLiability", "True");
            dic.Add("WindUpLiability", "false");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Funding2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete with 1 NP", true);


            pMain._SelectTab("Funding2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Parameter Print", "RollForward", true, true);

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Member Statistics", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Age Service Matrix", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Data Matching Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Combined Status Code Summary", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Decrement Age", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_Baseline, "IOE", "RollForward", false, true);

            thrd_Funding2011_Baseline.Start();



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Funding2011");
            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region Funding - Funding2011_NewValuation

            pMain._SelectTab("Funding2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "New Valuation");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
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
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("CalcIncreCostSolvencyWindup", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "ProjectedPay");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "ContribsWInterest1");
            dic.Add("Pension", "AccruedBenefit1");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "True");
            dic.Add("SolvencyLiability", "True");
            dic.Add("WindUpLiability", "true");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Funding2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete with 1 NP", true);


            pMain._SelectTab("Funding2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Funding2011_NewValuation, "Parameter Print", "RollForward", true, true);

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_NewValuation, "Liability Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_NewValuation, "Liability Scenario by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Funding2011_NewValuation, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Funding2011_NewValuation, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Funding2011_NewValuation, "IOE", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_NewValuation, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Funding2011_NewValuation, "Age Service Matrix", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_NewValuation, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_NewValuation, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Funding2011_NewValuation, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2011_NewValuation, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);



            thrd_Funding2011_NewValuation.Start();



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Funding2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Funding - WindUpGL2011


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "WindUpGL 2011");
            dic.Add("Parent", "Funding2008");
            dic.Add("ParentFinalValuationSet", "New DAMP Node");
            dic.Add("PlanYearBeginningIn", "2011");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "Click");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "WindUpGL 2011");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("WindUpGL 2011");

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
            dic.Add("Data_AddNew", "true");
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
            dic.Add("Snapshot", "true");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("CompareData", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Revised ValuationData");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "true");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("CompareData", "");
            dic.Add("ImportDataandApplyMapping", "click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("WindUpGL 2011");


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
            dic.Add("GL_GoingConcern", "True");
            dic.Add("GL_WindUp", "True");
            dic.Add("PayoutProjection", "false");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("CalcIncreCostSolvencyWindup", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "ProjectedPay");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "ContribsWInterest1");
            dic.Add("Pension", "AccruedBenefit1");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "True");
            dic.Add("SolvencyLiability", "false");
            dic.Add("WindUpLiability", "true");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("WindUpGL 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete with 1 NP", true);


            pMain._SelectTab("WindUpGL 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_WindUpGL2011, "Parameter Print", "RollForward", true, true);

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Reconciliation to Prior Year", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Member Statistics", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Age Service Matrix", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Data Matching Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Combined Status Code Summary", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Gain / Loss Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Decrement Age", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Gain / Loss Participant Listing", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_WindUpGL2011, "IOE", "RollForward", false, true);

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("CA001CN", sOutputFunding_WindUpGL2011_Prod, sOutputFunding_WindUpGL2011);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_WindUpGL2011");
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYear_GoingConcern.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYear_Windup.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_GoingConcern.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_Windup.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsByPlanDef.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainlossStatusReconciliation_GoingConcern.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainlossStatusReconciliation_Windup.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryOfLiabilityReconciliation_GoingConcern.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryOfLiabilityReconciliation_Windup.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_GoingConcern.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_Windup.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_GoingConcern.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_Windup.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);

            }


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("WindUpGL 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            _gLib._MsgBox("", "Finished!");

        }







        void t_CompareRpt_Accounting_Accounting2008(string sOutputAccounting_Accounting2008)
        {


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("CA001CN", sOutputAccounting_Accounting2008_Prod, sOutputAccounting_Accounting2008);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting_Accounting2008");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_ActiveMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_DeferredMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_Pensioners.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByNone.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByStatusCodes.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByCustom_Gender.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }


        }

        void t_CompareRpt_Funding_Funding2011_Baseline(string sOutputFunding_Funding2011_Baseline)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("CA001CN", sOutputFunding_Funding2011_Baseline_Prod, sOutputFunding_Funding2011_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_Funding2011_Baseline");

                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearByPlanDef_GoningConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearByPlanDef_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainlossStatusReconciliation_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainlossStatusReconciliation_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainlossSummaryOfLiabilityReconciliation_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainlossSummaryOfLiabilityReconciliation_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;

            }

        }

        void t_CompareRpt_Funding_Funding2011_NewValuation(string sOutputFunding_Funding2011_NewValuation)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("CA001CN", sOutputFunding_Funding2011_NewValuation_Prod, sOutputFunding_Funding2011_NewValuation);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_Funding2011_NewValuation");

                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Windup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenarioByPlanDef_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenarioByPlanDef_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenarioByPlanDef_Windup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_Wind-Up.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_Windup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_Windup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
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

