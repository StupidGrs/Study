
////// ----------------------- ------------------------------------------------------------------------///////////
//////                           This test Based on USTiming Test Part-2                               ///////////
//////                        it begins from the rollforward valuation service                         ///////////
//////                                                                                                 ///////////
//////                          Webber.ling@mercer.com      2015-Aug-28                               ///////////
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
using RetirementStudio._UIMaps.SocialSecurityCoveredCompFormulaClasses;
using RetirementStudio._UIMaps.PayCreditClasses;
using RetirementStudio._UIMaps.CashBalanceClasses;



namespace RetirementStudio._TestScripts_2019_Oct_Timing
{
    /// <summary>
    /// Summary description for US_Timing_GainLoss
    /// </summary>
    [CodedUITest]
    public class US_Timing_GainLoss
    {
        public US_Timing_GainLoss()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            Config.sStudioLaunchDir = @"C:\Users\webber-ling\Desktop\QA1_20181211.1\Client\RetirementStudio.exe";

            //Config.sClientName = "US_Performance_Test_20140113_F"; //US Prod client (big data)
            ////Config.sPlanName = "US_Performance_Test_20140113_F Plan"; //US Prod plan (big data)
            //Config.sClientName = "QA_US_Performance_20140113_B"; //EU Prod client B (big data)
            //Config.sPlanName = "QA_US_Performance_20140113_B Plan"; //EU Prod plan B (big data)
            //Config.sClientName = "QA_US_Performance_20140113_E"; //EU Prod client E(big data)
            //Config.sPlanName = "QA_US_Performance_20140113_E Plan"; //EU Prod plan E(big data)
            //Config.sClientName = "US_Performance_Test_20140327"; //CA Prod client (big data)
            //Config.sPlanName = "US Plan"; //CA Prod plan (big data)


            Config.sClientName = "US_Performance_Test_20140113_F"; //QA1 client (small data)
            Config.sPlanName = "US_Performance_Test_20140113_F Plan"; // QA1 plan (small data)
            //Config.sClientName = "US_Performance_Test_Small_F"; //US Prod client (small data)
            //Config.sClientName = "US_Performance_Test_Small_D"; //US Prod client (small data)
            //Config.sClientName = "US_Performance_Test_Small_B"; //EU Prod client (small data)
            //Config.sClientName = "US_Performance_Test_20140330"; //CA Prod client (small data)
            //Config.sPlanName = "US Plan"; 
            ////Config.sDataCenter = "Exeter";
            ////Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = false;
            Config.bCompareReports = false;

        }

        #region Timing


        static string sCol_Time = "Time";
        static string sCol_Memory = "Memory";
        static string sLogFile = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Test\US_Timing_Test_CUIT.xls";
        static string sOutputDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Test\Reports_KeepUpdateOnRun\";
        MyTimer mTime = new MyTimer(sCol_Time, sLogFile);
        MyLog mLog = new MyLog(sCol_Memory, sLogFile);

        MyDictionary dicPosition = new MyDictionary();
        string sERDetail = "";


        #region Result Index

        static int iJobID_Baseline = 125;
        static int iJobID_ACLSConvFact425600675 = iJobID_Baseline + 1;


        static int iTimeStart = 2;
        static int iTimeEnd = iTimeStart + 1;
        static int iService_Create = iTimeEnd + 1;
        static int iService_Open = iService_Create + 1;
        static int iBaseline_Node_Add = iService_Open + 1;
        static int iBaseline_Data_Import = iBaseline_Node_Add + 1;
        static int iBaseline_Data_Save = iBaseline_Data_Import + 1;
        static int iBaseline_ER_RunOption_Launch = iBaseline_Data_Save + 1;
        static int iBaseline_ER_RunOption_Edit = iBaseline_ER_RunOption_Launch + 1;
        static int iBaseline_ER_RunSubmitted = iBaseline_ER_RunOption_Edit + 1;
        static int iBaseline_ER_ClickRun = iBaseline_ER_RunSubmitted + 1;
        static int iBaseline_ER_GroupID = iBaseline_ER_ClickRun + 1;
        static int iBaseline_ER_Persist = iBaseline_ER_GroupID + 1;
        static int iBaseline_ER_Post = iBaseline_ER_Persist + 1;
        static int iBaseline_ER_Detail = iBaseline_ER_Post + 1;
        static int iBaseline_NumOfCores = iBaseline_ER_Detail + 1;


        static int iADJProjectedPayAdjustment_Node_Add = iBaseline_NumOfCores + 1;
        static int iADJProjectedPayAdjustment_Data_Import = iADJProjectedPayAdjustment_Node_Add + 1;
        static int iADJProjectedPayAdjustment_PayProjection_Select = iADJProjectedPayAdjustment_Data_Import + 1;
        static int iADJProjectedPayAdjustment_PayProjection_Edit = iADJProjectedPayAdjustment_PayProjection_Select + 1;
        static int iADJProjectedPayAdjustment_PayProjection_Save = iADJProjectedPayAdjustment_PayProjection_Edit + 1;
        static int iADJProjectedPayAdjustment_PayAverage_Select = iADJProjectedPayAdjustment_PayProjection_Save + 1;
        static int iADJProjectedPayAdjustment_PayAverage_Edit = iADJProjectedPayAdjustment_PayAverage_Select + 1;
        static int iADJProjectedPayAdjustment_PayAverage_Save = iADJProjectedPayAdjustment_PayAverage_Edit + 1;
        static int iADJProjectedPayAdjustment_SSCC_Select = iADJProjectedPayAdjustment_PayAverage_Save + 1;
        static int iADJProjectedPayAdjustment_SSCC_Edit = iADJProjectedPayAdjustment_SSCC_Select + 1;
        static int iADJProjectedPayAdjustment_SSCC_Save = iADJProjectedPayAdjustment_SSCC_Edit + 1;
        static int iADJProjectedPayAdjustment_PayCredit_Select = iADJProjectedPayAdjustment_SSCC_Save + 1;
        static int iADJProjectedPayAdjustment_PayCredit_Edit = iADJProjectedPayAdjustment_PayCredit_Select + 1;
        static int iADJProjectedPayAdjustment_PayCredit_Save = iADJProjectedPayAdjustment_PayCredit_Edit + 1;


        static int iADJCBRetRateInactiveREA_Node_Add = iADJProjectedPayAdjustment_PayCredit_Save + 1;
        static int iADJCBRetRateInactiveREA_RetirementDecrement_Select = iADJCBRetRateInactiveREA_Node_Add + 1;
        static int iADJCBRetRateInactiveREA_RetirementDecrement_Edit = iADJCBRetRateInactiveREA_RetirementDecrement_Select + 1;
        static int iADJCBRetRateInactiveREA_RetirementDecrement_Save = iADJCBRetRateInactiveREA_RetirementDecrement_Edit + 1;
        static int iADJCBRetRateInactiveREA_Eligibility_Select = iADJCBRetRateInactiveREA_RetirementDecrement_Save + 1;
        static int iADJCBRetRateInactiveREA_Eligibility_Edit = iADJCBRetRateInactiveREA_Eligibility_Select + 1;
        static int iADJCBRetRateInactiveREA_Eligibility_Save = iADJCBRetRateInactiveREA_Eligibility_Edit + 1;
        static int iADJCBRetRateInactiveREA_FormOfPayment_Select = iADJCBRetRateInactiveREA_Eligibility_Save + 1;
        static int iADJCBRetRateInactiveREA_FormOfPayment_Edit = iADJCBRetRateInactiveREA_FormOfPayment_Select + 1;
        static int iADJCBRetRateInactiveREA_FormOfPayment_Save = iADJCBRetRateInactiveREA_FormOfPayment_Edit + 1;
        static int iADJCBRetRateInactiveREA_PlanDefinition_Select = iADJCBRetRateInactiveREA_FormOfPayment_Save + 1;
        static int iADJCBRetRateInactiveREA_PlanDefinition_Edit = iADJCBRetRateInactiveREA_PlanDefinition_Select + 1;
        static int iADJCBRetRateInactiveREA_PlanDefinition_Save = iADJCBRetRateInactiveREA_PlanDefinition_Edit + 1;



        static int iACCBIntRate_Node_Add = iADJCBRetRateInactiveREA_PlanDefinition_Save + 1;
        static int iACCBIntRate_CustomRate_Select = iACCBIntRate_Node_Add + 1;
        static int iACCBIntRate_CustomRate_Edit = iACCBIntRate_CustomRate_Select + 1;
        static int iACCBIntRate_CustomRate_Save = iACCBIntRate_CustomRate_Edit + 1;
        static int iACCBIntRate_PayIncrease_Select = iACCBIntRate_CustomRate_Save + 1;
        static int iACCBIntRate_PayIncrease_Edit = iACCBIntRate_PayIncrease_Select + 1;
        static int iACCBIntRate_PayIncrease_Save = iACCBIntRate_PayIncrease_Edit + 1;


        static int iQC2013MortalityUpdate_Node_Add = iACCBIntRate_PayIncrease_Save + 1;
        static int iQC2013MortalityUpdate_MortalityDecrement_Select = iQC2013MortalityUpdate_Node_Add + 1;
        static int iQC2013MortalityUpdate_MortalityDecrement_Edit = iQC2013MortalityUpdate_MortalityDecrement_Select + 1;
        static int iQC2013MortalityUpdate_MortalityDecrement_Save = iQC2013MortalityUpdate_MortalityDecrement_Edit + 1;
        static int iQC2013MortalityUpdate_ActuarialEquivalence_Select = iQC2013MortalityUpdate_MortalityDecrement_Save + 1;
        static int iQC2013MortalityUpdate_ActuarialEquivalence_Edit = iQC2013MortalityUpdate_ActuarialEquivalence_Select + 1;
        static int iQC2013MortalityUpdate_ActuarialEquivalence_Save = iQC2013MortalityUpdate_ActuarialEquivalence_Edit + 1;

        
        static int iICInterestRateUpdate_Node_Add = iQC2013MortalityUpdate_ActuarialEquivalence_Save + 1;
        static int iICInterestRateUpdate_InterestRate_Select = iICInterestRateUpdate_Node_Add + 1;
        static int iICInterestRateUpdate_InterestRate_Edit = iICInterestRateUpdate_InterestRate_Select + 1;
        static int iICInterestRateUpdate_InterestRate_Save = iICInterestRateUpdate_InterestRate_Edit + 1;


        static int iPCNewCBAt112014_Node_Add = iICInterestRateUpdate_InterestRate_Save + 1;
        static int iPCNewCBAt112014_Service_Select = iPCNewCBAt112014_Node_Add + 1;
        static int iPCNewCBAt112014_Service_Edit = iPCNewCBAt112014_Service_Select + 1;
        static int iPCNewCBAt112014_Service_Save = iPCNewCBAt112014_Service_Edit + 1;
        static int iPCNewCBAt112014_FromToAge_Select = iPCNewCBAt112014_Service_Save + 1;
        static int iPCNewCBAt112014_FromToAge_Edit = iPCNewCBAt112014_FromToAge_Select + 1;
        static int iPCNewCBAt112014_FromToAge_Save = iPCNewCBAt112014_FromToAge_Edit + 1;
        static int iPCNewCBAt112014_Eligibility_Select = iPCNewCBAt112014_FromToAge_Save + 1;
        static int iPCNewCBAt112014_Eligibility_Edit = iPCNewCBAt112014_Eligibility_Select + 1;
        static int iPCNewCBAt112014_Eligibility_Save = iPCNewCBAt112014_Eligibility_Edit + 1;
        static int iPCNewCBAt112014_PayAverage_Select = iPCNewCBAt112014_Eligibility_Save + 1;
        static int iPCNewCBAt112014_PayAverage_Edit = iPCNewCBAt112014_PayAverage_Select + 1;
        static int iPCNewCBAt112014_PayAverage_Save = iPCNewCBAt112014_PayAverage_Edit + 1;
        static int iPCNewCBAt112014_SSCC_Select = iPCNewCBAt112014_PayAverage_Save + 1;
        static int iPCNewCBAt112014_SSCC_Edit = iPCNewCBAt112014_SSCC_Select + 1;
        static int iPCNewCBAt112014_SSCC_Save = iPCNewCBAt112014_SSCC_Edit + 1;
        static int iPCNewCBAt112014_FAEFormula_Select = iPCNewCBAt112014_SSCC_Save + 1;
        static int iPCNewCBAt112014_FAEFormula_Edit = iPCNewCBAt112014_FAEFormula_Select + 1;
        static int iPCNewCBAt112014_FAEFormula_Save = iPCNewCBAt112014_FAEFormula_Edit + 1;
        static int iPCNewCBAt112014_PayCredit_Select = iPCNewCBAt112014_FAEFormula_Save + 1;
        static int iPCNewCBAt112014_PayCredit_Edit = iPCNewCBAt112014_PayCredit_Select + 1;
        static int iPCNewCBAt112014_PayCredit_Save = iPCNewCBAt112014_PayCredit_Edit + 1;
        static int iPCNewCBAt112014_CashBalance_Select = iPCNewCBAt112014_PayCredit_Save + 1;
        static int iPCNewCBAt112014_CashBalance_Edit = iPCNewCBAt112014_CashBalance_Select + 1;
        static int iPCNewCBAt112014_CashBalance_Save = iPCNewCBAt112014_CashBalance_Edit + 1;
        static int iPCNewCBAt112014_PlanDefinition_Select = iPCNewCBAt112014_CashBalance_Save + 1;
        static int iPCNewCBAt112014_PlanDefinition_Edit = iPCNewCBAt112014_PlanDefinition_Select + 1;
        static int iPCNewCBAt112014_PlanDefinition_Save = iPCNewCBAt112014_PlanDefinition_Edit + 1;
        static int iPCNewCBAt112014_Methods_View = iPCNewCBAt112014_PlanDefinition_Save + 1;


        static int iACLSConvFact425600675_Node_Add = iPCNewCBAt112014_Methods_View + 1;
        static int iACLSConvFact425600675_ConversionFactors_Select = iACLSConvFact425600675_Node_Add + 1;
        static int iACLSConvFact425600675_ConversionFactors_Edit = iACLSConvFact425600675_ConversionFactors_Select + 1;
        static int iACLSConvFact425600675_ConversionFactors_Save = iACLSConvFact425600675_ConversionFactors_Edit + 1;
        static int iACLSConvFact425600675_ParamPrint_Select = iACLSConvFact425600675_ConversionFactors_Save + 1;
        static int iACLSConvFact425600675_ParamPrint_Generate = iACLSConvFact425600675_ParamPrint_Select + 1;
        static int iACLSConvFact425600675_ParamPrintComparison_Select = iACLSConvFact425600675_ParamPrint_Generate + 1;
        static int iACLSConvFact425600675_ParamPrintComparison_Generate = iACLSConvFact425600675_ParamPrintComparison_Select + 1;
        static int iACLSConvFact425600675_ER_RunOption_Launch = iACLSConvFact425600675_ParamPrintComparison_Generate + 1;
        static int iACLSConvFact425600675_ER_RunOption_Edit = iACLSConvFact425600675_ER_RunOption_Launch + 1;
        static int iACLSConvFact425600675_ER_RunSubmitted = iACLSConvFact425600675_ER_RunOption_Edit + 1;
        static int iACLSConvFact425600675_ER_ClickRun = iACLSConvFact425600675_ER_RunSubmitted + 1;
        static int iACLSConvFact425600675_ER_GroupID = iACLSConvFact425600675_ER_ClickRun + 1;
        static int iACLSConvFact425600675_ER_Persist = iACLSConvFact425600675_ER_GroupID + 1;
        static int iACLSConvFact425600675_ER_Post = iACLSConvFact425600675_ER_Persist + 1;
        static int iACLSConvFact425600675_ER_Detail = iACLSConvFact425600675_ER_Post + 1;
        static int iACLSConvFact425600675_NumOfCores = iACLSConvFact425600675_ER_Detail + 1;
        static int iACLSConvFact425600675_OM_View = iACLSConvFact425600675_NumOfCores + 1;
        static int iACLSConvFact425600675_Export_GLParticipantListing = iACLSConvFact425600675_OM_View + 1;
        static int iACLSConvFact425600675_Export_GLSummaryOfLiabilityReconciliation = iACLSConvFact425600675_Export_GLParticipantListing + 1;
        static int iACLSConvFact425600675_Export_tGLSummaryOfLiabilityReconciliationDrilldown_Active = iACLSConvFact425600675_Export_GLSummaryOfLiabilityReconciliation + 1;
        static int iACLSConvFact425600675_Export_tGLSummaryOfLiabilityReconciliationDrilldown_SalaryGL = iACLSConvFact425600675_Export_tGLSummaryOfLiabilityReconciliationDrilldown_Active + 1;
        static int iACLSConvFact425600675_Export_tGLSummaryOfLiabilityReconciliationDrilldown_Inactive = iACLSConvFact425600675_Export_tGLSummaryOfLiabilityReconciliationDrilldown_SalaryGL + 1;
        static int iACLSConvFact425600675_Export_IOE = iACLSConvFact425600675_Export_tGLSummaryOfLiabilityReconciliationDrilldown_Inactive + 1;
        static int iACLSConvFact425600675_Export_PayoutProjection = iACLSConvFact425600675_Export_IOE + 1;
        static int iACLSConvFact425600675_Export_ValuationSummary = iACLSConvFact425600675_Export_PayoutProjection + 1;
        static int iACLSConvFact425600675_Export_ReconciliationToBaseline = iACLSConvFact425600675_Export_ValuationSummary + 1;
        static int iACLSConvFact425600675_Export_LiabilityDetailedResults = iACLSConvFact425600675_Export_ReconciliationToBaseline + 1;
        static int iService_ReOpen = iACLSConvFact425600675_Export_LiabilityDetailedResults + 1;


        static int iTest = 122;

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
        public SocialSecurityCoveredCompFormula pSocialSecurityCoveredCompFormula = new SocialSecurityCoveredCompFormula();
        public PayCredit pPayCredit = new PayCredit();
        public CashBalance pCashBalance = new CashBalance();



        #endregion


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_US_Timing_GainLoss()
        {

            
            

            _gLib._CreateDirectory(sOutputDir, false);

            _gLib._StudioClearCache();   //////////_gLib._MsgBox("Warning!", "Please Clear Cache!");

            pMain._SetLanguageAndRegional();

            _gLib._Cmd(Config.sStudioLaunchDir);

            pMain._SelectTab("Home");


            #region Initialize




            ////////////////////////////_gLib._MsgBox("Warning!", "Please manually select the Client in Studio-> Home -> All Services -> " + Config.sClientName + " >> " + Config.sPlanName + " >> FundingValuations" + Environment.NewLine + Environment.NewLine + "Click OK to keep testing!");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            _gLib._KillProcessByName("Mercer.RetirementStudio.Messaging.MessagingClientApp");

            #endregion


            #region Baseline

            mLog.LogInfo(iTimeStart, DateTime.Now.ToString());

            pMain._SelectTab("Home");


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "Funding 1.1.2013");
            dic.Add("Parent", "Funding 1.1 2012");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "2013");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);


            pMain._SelectTab("Home");
            mTime.StopTimer(iService_Create);
            mLog.LogInfo(iService_Create, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Funding 1.1.2013");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            mTime.StopTimer(iService_Open);
            mLog.LogInfo(iService_Open, MyPerformanceCounter.Memory_Private);

            mTime.StartTimer();


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


            pMain._SelectTab("Funding 1.1.2013");
            mTime.StopTimer(iBaseline_Node_Add);
            mLog.LogInfo(iBaseline_Node_Add, MyPerformanceCounter.Memory_Private);

            pMain._SelectTab("Funding 1.1.2013");

            mTime.StartTimer();


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
            dic.Add("Snapshot", "True");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "RSUnloadBaseline");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "True");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "Click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);


            pMain._SelectTab("Participant DataSet");



            dic.Clear();
            dic.Add("Level_1", "Custom Fields");
            dic.Add("Level_2", "ElectionActive");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "True");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "False");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("CompareData", "False");
            dic.Add("ImportDataandApplyMapping", "Click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._SelectTab("Participant DataSet");


            mTime.StopTimer(iBaseline_Data_Import);
            mLog.LogInfo(iBaseline_Data_Import, MyPerformanceCounter.Memory_Private);



            pMain._SelectTab("Funding 1.1.2013");

            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Funding 1.1.2013");
            mTime.StopTimer(iBaseline_Data_Save);
            mLog.LogInfo(iBaseline_Data_Save, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Funding 1.1.2013");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/16/1990\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"11/4/1991\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Funding 1.1.2013");


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("Object", "Main.RunOption");
            dic.Add("optiTimeout", "");
            pMain._ObjectExist(dic);


            mTime.StopTimer(iBaseline_ER_RunOption_Launch);
            mLog.LogInfo(iBaseline_ER_RunOption_Launch, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "True");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "PayfieldPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "ErAccountBalance1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "True");
            dic.Add("FAS35PresentValueOfVestedBenefits", "True");
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "ElectionActive");
            dic.Add("RunValuation", "");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);


            mTime.StopTimer(iBaseline_ER_RunOption_Edit);
            mLog.LogInfo(iBaseline_ER_RunOption_Edit, MyPerformanceCounter.Memory_Private);




            mTime.StartTimer();
            mLog.LogInfo(iBaseline_ER_ClickRun, DateTime.Now.ToString());

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            mTime.StopTimer(iBaseline_ER_RunSubmitted);
            mLog.LogInfo(iBaseline_ER_RunSubmitted, MyPerformanceCounter.Memory_Private);



            #endregion


            #region ADJ - Projected Pay Adjustment


            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "ADJ - Projected Pay Adjustment");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "True");
            dic.Add("Data_Name", "Revised Baseline Data");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "");
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


            pMain._SelectTab("Funding 1.1.2013");
            mTime.StopTimer(iADJProjectedPayAdjustment_Node_Add);
            mLog.LogInfo(iADJProjectedPayAdjustment_Node_Add, MyPerformanceCounter.Memory_Private);




            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Data");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Participant DataSet");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "True");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "RSUnloadRevisedBaseline");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "True");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "Click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);


            pMain._SelectTab("Participant DataSet");


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

            pMain._SelectTab("Participant DataSet");

            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Funding 1.1.2013");

            mTime.StopTimer(iADJProjectedPayAdjustment_Data_Import);
            mLog.LogInfo(iADJProjectedPayAdjustment_Data_Import, MyPerformanceCounter.Memory_Private);



            pMain._SelectTab("Funding 1.1.2013");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Provisions");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "SalaryProjection");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            mTime.StopTimer(iADJProjectedPayAdjustment_PayProjection_Select);
            mLog.LogInfo(iADJProjectedPayAdjustment_PayProjection_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "");
            dic.Add("CustomCode", "");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "");
            dic.Add("LegislatedPayLimitDefinition", "False");
            pPayoutProjection._PopVerify_Main(dic);

            mTime.StopTimer(iADJProjectedPayAdjustment_PayProjection_Edit);
            mLog.LogInfo(iADJProjectedPayAdjustment_PayProjection_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(iADJProjectedPayAdjustment_PayProjection_Save);
            mLog.LogInfo(iADJProjectedPayAdjustment_PayProjection_Save, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "UpdSalaryProjection");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "UpdSalaryProjection");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "True");
            dic.Add("CustomCode", "");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "");
            dic.Add("LegislatedPayLimitDefinition", "");
            pPayoutProjection._PopVerify_Main(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Function", "IF($Year<$ValYear)" + Environment.NewLine + "$SalaryProjection" + Environment.NewLine + "ELSE" + Environment.NewLine + "$SalaryProjection*(1+$SalaryScale[$ValAge-1])");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            pMain._SelectTab("Provisions");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("Level_3", "SalaryAverage");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            mTime.StopTimer(iADJProjectedPayAdjustment_PayAverage_Select);
            mLog.LogInfo(iADJProjectedPayAdjustment_PayAverage_Select, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "UpdSalaryProjection");
            dic.Add("AveragingMethod", "");
            dic.Add("M", "");
            dic.Add("RoundingForYearOfHire", "");
            dic.Add("DecimalPlacesForYearOfHire", "");
            dic.Add("Include", "");
            dic.Add("DropForCalculations", "");
            dic.Add("DropForCalculationAndPeriodConsidered", "");
            dic.Add("AdjustmentPeriodMonths", "");
            dic.Add("AdjustmentMethod", "");
            pPayAverage._PopVerify_Standard(dic);

            mTime.StopTimer(iADJProjectedPayAdjustment_PayAverage_Edit);
            mLog.LogInfo(iADJProjectedPayAdjustment_PayAverage_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(iADJProjectedPayAdjustment_PayAverage_Save);
            mLog.LogInfo(iADJProjectedPayAdjustment_PayAverage_Save, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Social Security Covered Comp Formula");
            dic.Add("Level_4", "SSCoveredComp");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            mTime.StopTimer(iADJProjectedPayAdjustment_SSCC_Select);
            mLog.LogInfo(iADJProjectedPayAdjustment_SSCC_Select, MyPerformanceCounter.Memory_Private);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TaxableWageBase", "");
            dic.Add("Final3Year_cbo", "UpdSalaryProjection");
            dic.Add("RoundResultToNearest12", "");
            pSocialSecurityCoveredCompFormula._PopVerify_Standard(dic);

            mTime.StopTimer(iADJProjectedPayAdjustment_SSCC_Edit);
            mLog.LogInfo(iADJProjectedPayAdjustment_SSCC_Edit, MyPerformanceCounter.Memory_Private);

            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(iADJProjectedPayAdjustment_SSCC_Save);
            mLog.LogInfo(iADJProjectedPayAdjustment_SSCC_Save, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Pay Credit");
            dic.Add("Level_4", "PayCreditAccrual");
            dic.Add("Level_5", "Actives");
            pAssumptions._TreeViewSelect(dic);

            mTime.StopTimer(iADJProjectedPayAdjustment_PayCredit_Select);
            mLog.LogInfo(iADJProjectedPayAdjustment_PayCredit_Select, MyPerformanceCounter.Memory_Private);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "UpdSalaryProjection");
            dic.Add("ServiceBasedOn", "");
            pPayCredit._PopVerify_Standard(dic);

            mTime.StopTimer(iADJProjectedPayAdjustment_PayCredit_Edit);
            mLog.LogInfo(iADJProjectedPayAdjustment_PayCredit_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(iADJProjectedPayAdjustment_PayCredit_Save);
            mLog.LogInfo(iADJProjectedPayAdjustment_PayCredit_Save, MyPerformanceCounter.Memory_Private);



            #endregion



            #region ADJ - CB Ret Rate & InactiveREA

            pMain._SelectTab("Funding 1.1.2013");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "ADJ - CB Ret Rate & InactiveREA");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "ADJ - Retirement Rates Assumptions");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "True");
            dic.Add("Provisions_Name", "ADJ - Retirement Rates Provisions");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab("Funding 1.1.2013");
            mTime.StopTimer(iADJCBRetRateInactiveREA_Node_Add);
            mLog.LogInfo(iADJCBRetRateInactiveREA_Node_Add, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");




            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("Level_4", "CashBalanceEligibility");
            pAssumptions._TreeViewSelect(dic);


            mTime.StopTimer(iADJCBRetRateInactiveREA_RetirementDecrement_Select);
            mLog.LogInfo(iADJCBRetRateInactiveREA_RetirementDecrement_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "RETARPCB1");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);


            mTime.StopTimer(iADJCBRetRateInactiveREA_RetirementDecrement_Edit);
            mLog.LogInfo(iADJCBRetRateInactiveREA_RetirementDecrement_Edit, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("Level_4", "CashBalanceEligibility");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "RETARPCB1");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iADJCBRetRateInactiveREA_RetirementDecrement_Save);
            mLog.LogInfo(iADJCBRetRateInactiveREA_RetirementDecrement_Save, MyPerformanceCounter.Memory_Private);



            pMain._SelectTab("Funding 1.1.2013");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Provisions");



            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "WithdrawalEligibilityCB");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "WithdrawalEligibilityCB");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            mTime.StopTimer(iADJCBRetRateInactiveREA_Eligibility_Select);
            mLog.LogInfo(iADJCBRetRateInactiveREA_Eligibility_Select, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$VestingService>=3 and $Age<$EarlyRetirementAge");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);

            mTime.StopTimer(iADJCBRetRateInactiveREA_Eligibility_Edit);
            mLog.LogInfo(iADJCBRetRateInactiveREA_Eligibility_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iADJCBRetRateInactiveREA_Eligibility_Save);
            mLog.LogInfo(iADJCBRetRateInactiveREA_Eligibility_Save, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "WithdrawalEligibilityCB");
            dic.Add("MenuItem", "Move Up");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "WithdrawalEligibilityCB");
            dic.Add("MenuItem", "Move Up");
            pAssumptions._TreeViewRightSelect(dic, "");


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "REAFOP");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            mTime.StopTimer(iADJCBRetRateInactiveREA_FormOfPayment_Select);
            mLog.LogInfo(iADJCBRetRateInactiveREA_FormOfPayment_Select, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Insurance benefit");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "Click");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            dic.Add("btnSurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "");
            dic.Add("SurvivorPercentOrAmount_txt", "");
            dic.Add("cboSurvivorPercentOrAmount_PercentOrAmount", "");
            dic.Add("btnPopupAmount_V", "");
            dic.Add("PopupAmount_cbo", "");
            dic.Add("btnPopupAmount_C", "Click");
            dic.Add("PopupAmount_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_V", "");
            dic.Add("NumberOfPaymentsPerYear_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_C", "Click");
            ////////////dic.Add("NumberOfPaymentsPerYear_txt", "1");
            pFormOfPayment._PopVerify_FormOfPayment(dic);



            mTime.StopTimer(iADJCBRetRateInactiveREA_FormOfPayment_Edit);
            mLog.LogInfo(iADJCBRetRateInactiveREA_FormOfPayment_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iADJCBRetRateInactiveREA_FormOfPayment_Save);
            mLog.LogInfo(iADJCBRetRateInactiveREA_FormOfPayment_Save, MyPerformanceCounter.Memory_Private);




            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "REAInactive");
            dic.Add("Level_4", "LumpSum");
            pAssumptions._TreeViewSelect(dic);

            mTime.StopTimer(iADJCBRetRateInactiveREA_PlanDefinition_Select);
            mLog.LogInfo(iADJCBRetRateInactiveREA_PlanDefinition_Select, MyPerformanceCounter.Memory_Private);




            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$CashBalanceAmount[$ExitAge][$PaymentAge]");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            dic.Add("MaximumBenefitLimitation_CA", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);



            mTime.StopTimer(iADJCBRetRateInactiveREA_PlanDefinition_Edit);
            mLog.LogInfo(iADJCBRetRateInactiveREA_PlanDefinition_Edit, MyPerformanceCounter.Memory_Private);




            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iADJCBRetRateInactiveREA_PlanDefinition_Save);
            mLog.LogInfo(iADJCBRetRateInactiveREA_PlanDefinition_Save, MyPerformanceCounter.Memory_Private);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WithdrawalBenefitLS");
            dic.Add("Level_4", "WithActivesCB");
            pAssumptions._TreeViewSelect(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$ActivesCB and $WithdrawalEligibilityCB");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            pMain._SelectTab("Funding 1.1.2013");

            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region AC - CB Int Rate

            pMain._SelectTab("Funding 1.1.2013");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "AC - CB Int Rate");
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
            dic.Add("Provisions_AddNew", "True");
            dic.Add("Provisions_Name", "");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab("Funding 1.1.2013");
            mTime.StopTimer(iACCBIntRate_Node_Add);
            mLog.LogInfo(iACCBIntRate_Node_Add, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CBInterestRate");
            dic.Add("Level_4", "AllOthers");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            mTime.StopTimer(iACCBIntRate_CustomRate_Select);
            mLog.LogInfo(iACCBIntRate_CustomRate_Select, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2.77");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            mTime.StopTimer(iACCBIntRate_CustomRate_Select);
            mLog.LogInfo(iACCBIntRate_CustomRate_Select, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Assumptions");
            mTime.StopTimer(iACCBIntRate_CustomRate_Save);
            mLog.LogInfo(iACCBIntRate_CustomRate_Save, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CBInterestRate");
            dic.Add("Level_4", "FAS_35");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "4.75");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryScale");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            mTime.StopTimer(iACCBIntRate_PayIncrease_Select);
            mLog.LogInfo(iACCBIntRate_PayIncrease_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustment", "");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "");
            dic.Add("btnT", "Click");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "");
            dic.Add("cboRate_T", "SALSCALE35");
            pPayIncrease._PopVerify_PayIncrease(dic);


            mTime.StopTimer(iACCBIntRate_PayIncrease_Edit);
            mLog.LogInfo(iACCBIntRate_PayIncrease_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Assumptions");
            mTime.StopTimer(iACCBIntRate_PayIncrease_Save);
            mLog.LogInfo(iACCBIntRate_PayIncrease_Save, MyPerformanceCounter.Memory_Private);




            pMain._SelectTab("Funding 1.1.2013");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Provisions");



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("Level_3", "LSFactorREA");
            dic.Add("Level_4", "FAS35Age60");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("T", "");
            dic.Add("C", "");
            dic.Add("txtTabularOrConstantFactor_M", "");
            dic.Add("txtTabularOrConstantFactor_F", "");
            dic.Add("cboTabularOrConstantFactor", "LSD6013_400_600_650");
            pConversionFactors._PopVerify_TabularOrConstantFactor(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("Level_3", "LSFactorREA");
            dic.Add("Level_4", "FAS35Age65");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("T", "");
            dic.Add("C", "");
            dic.Add("txtTabularOrConstantFactor_M", "");
            dic.Add("txtTabularOrConstantFactor_F", "");
            dic.Add("cboTabularOrConstantFactor", "LSD6013_400_600_650");
            pConversionFactors._PopVerify_TabularOrConstantFactor(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("Level_3", "LAtoLS");
            dic.Add("Level_4", "FAS35Elig");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("T", "");
            dic.Add("C", "");
            dic.Add("txtTabularOrConstantFactor_M", "");
            dic.Add("txtTabularOrConstantFactor_F", "");
            dic.Add("cboTabularOrConstantFactor", "LSIM13_400_600_650");
            pConversionFactors._PopVerify_TabularOrConstantFactor(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("Level_3", "DeathforFAS");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("T", "");
            dic.Add("C", "");
            dic.Add("txtTabularOrConstantFactor_M", "");
            dic.Add("txtTabularOrConstantFactor_F", "");
            dic.Add("cboTabularOrConstantFactor", "LSD6513_400_600_650");
            pConversionFactors._PopVerify_TabularOrConstantFactor(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Funding 1.1.2013");





            #endregion


            #region QC - 2013 Mortality Update

            pMain._SelectTab("Funding 1.1.2013");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "QC - 2013 Mortality Update");
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
            dic.Add("Provisions_AddNew", "True");
            dic.Add("Provisions_Name", "");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab("Funding 1.1.2013");
            mTime.StopTimer(iQC2013MortalityUpdate_Node_Add);
            mLog.LogInfo(iQC2013MortalityUpdate_Node_Add, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "_Death");
            dic.Add("Level_4", "FAS35");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic);




            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "_Death");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            mTime.StopTimer(iQC2013MortalityUpdate_MortalityDecrement_Select);
            mLog.LogInfo(iQC2013MortalityUpdate_MortalityDecrement_Select, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2013");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            mTime.StopTimer(iQC2013MortalityUpdate_MortalityDecrement_Edit);
            mLog.LogInfo(iQC2013MortalityUpdate_MortalityDecrement_Edit, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();


            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iQC2013MortalityUpdate_MortalityDecrement_Save);
            mLog.LogInfo(iQC2013MortalityUpdate_MortalityDecrement_Save, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Funding 1.1.2013");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Pay Credit");
            dic.Add("MenuItem", "Add Pay Credit");
            pAssumptions._TreeViewRightSelect(dic, "AdditPayCredit");



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Pay Credit");
            dic.Add("Level_4", "AdditPayCredit");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "UpdSalaryProjection");
            dic.Add("ServiceBasedOn", "VestingService");
            pPayCredit._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Service", "");
            dic.Add("LimitServiceTo", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccuralAt_C", "");
            dic.Add("StopAccuralAt_cbo", "");
            dic.Add("StopAccuralAt_txt", "");
            dic.Add("RateTiersBasedOn", "Service");
            dic.Add("NumberOfRateTiers", "20");
            pUnitFormula._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "1");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "20");
            dic.Add("sData", "1");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "1");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "20");
            dic.Add("sData", "0.0");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "2");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "20");
            dic.Add("sData", "2");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "20");
            dic.Add("sData", "0.0023");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "3");
            dic.Add("iRowMax", "3");
            dic.Add("iColMax", "20");
            dic.Add("sData", "3");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "3");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "20");
            dic.Add("sData", "0.0031");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "4");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "20");
            dic.Add("sData", "4");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "4");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "20");
            dic.Add("sData", "0.0038");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "5");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "20");
            dic.Add("sData", "5");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "5");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "20");
            dic.Add("sData", "0.0046");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "6");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "20");
            dic.Add("sData", "6");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "6");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "20");
            dic.Add("sData", "0.0004");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "7");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "20");
            dic.Add("sData", "7");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "7");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "20");
            dic.Add("sData", "0.0013");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);



            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "8");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "20");
            dic.Add("sData", "8");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "8");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "20");
            dic.Add("sData", "0.0022");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "9");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "20");
            dic.Add("sData", "9");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "9");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "20");
            dic.Add("sData", "0.003");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "10");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "20");
            dic.Add("sData", "10");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "10");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "20");
            dic.Add("sData", "0.004");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);

            for (int i = 11; i <= 20; i++)
            {
                dic.Clear();
                dic.Add("iRow", "1");
                dic.Add("iCol", i.ToString());
                dic.Add("iRowMax", "2");
                dic.Add("iColMax", "20");
                dic.Add("sData", i.ToString());
                dic.Add("bPayCredit", "True");
                pUnitFormula._FormulaTable(dic);

            }


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "True");
            dic.Add("txtLocalEligibility", "Actives_notFAS35");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.ParticipantStatus<>\"IN\" and $FAS35Flag<>1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Pay Credit");
            dic.Add("Level_4", "AdditPayCredit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "True");
            pUnitFormula._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Cash Balance");
            dic.Add("MenuItem", "Add Cash Balance");
            pAssumptions._TreeViewRightSelect(dic, "AdditCashBalAmount");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Cash Balance");
            dic.Add("Level_4", "AdditCashBalAmount");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "True");
            dic.Add("cboPreDefinedEligibility", "ActivesCB");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Cash Balance");
            dic.Add("Level_4", "AdditCashBalAmount");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StartingBalance", "Benefit1DB");
            dic.Add("PayCredits", "PayCreditAccrual");
            pCashBalance._PopVerify_Standard(dic);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("Level_3", "PPALSMortality");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            mTime.StopTimer(iQC2013MortalityUpdate_ActuarialEquivalence_Select);
            mLog.LogInfo(iQC2013MortalityUpdate_ActuarialEquivalence_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("txtInterestRate", "");
            dic.Add("Mortality", "PPA2013CMF");
            pActuarialEquivalence._PopVerify_SameStructureForAllPeriods(dic);

            mTime.StopTimer(iQC2013MortalityUpdate_ActuarialEquivalence_Edit);
            mLog.LogInfo(iQC2013MortalityUpdate_ActuarialEquivalence_Edit, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Provisions");

            mTime.StopTimer(iQC2013MortalityUpdate_ActuarialEquivalence_Save);
            mLog.LogInfo(iQC2013MortalityUpdate_ActuarialEquivalence_Save, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("Level_3", "ActEquivJS50");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValuationInterest", "True");
            dic.Add("ValuationMortality", "False");
            dic.Add("ValuationCOLA", "");
            dic.Add("ValuationSpouseAgeDiff", "");
            pActuarialEquivalence._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("txtInterestRate", "");
            dic.Add("Mortality", "PPA2013CMF");
            pActuarialEquivalence._PopVerify_SameStructureForAllPeriods(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("Level_3", "REAMortality");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("txtInterestRate", "");
            dic.Add("Mortality", "PPA2013N");
            pActuarialEquivalence._PopVerify_SameStructureForAllPeriods(dic);





            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "RetirementBenefitLS");
            dic.Add("Level_4", "CashBalanceEligible");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$CashBalanceAmount+$AdditCashBalAmount-$emp.QRDOOffsetBenefit");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WithdrawalBenefitLS");
            dic.Add("Level_4", "WithActivesCB");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$CashBalanceAmount+$AdditCashBalAmount-$emp.QRDOOffsetBenefit*$FactorDefToAge65");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "DeathBenefitLS");
            dic.Add("Level_4", "WithdrawalEligibility1");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$CashBalanceAmount+$AdditCashBalAmount-$emp.QRDOOffsetBenefit*$FactorDefToAge65");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "True");
            dic.Add("txtLocalEligibility", "DeathCB");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Provisions");





            #endregion


            #region IC - Interest Rate Update

            pMain._SelectTab("Funding 1.1.2013");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "IC - Interest Rate Update");
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


            pMain._SelectTab("Funding 1.1.2013");
            mTime.StopTimer(iICInterestRateUpdate_Node_Add);
            mLog.LogInfo(iICInterestRateUpdate_Node_Add, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "FAS_35");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            mTime.StopTimer(iICInterestRateUpdate_InterestRate_Select);
            mLog.LogInfo(iICInterestRateUpdate_InterestRate_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "7.75");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            mTime.StopTimer(iICInterestRateUpdate_InterestRate_Edit);
            mLog.LogInfo(iICInterestRateUpdate_InterestRate_Edit, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();


            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Assumptions");


            mTime.StopTimer(iICInterestRateUpdate_InterestRate_Save);
            mLog.LogInfo(iICInterestRateUpdate_InterestRate_Save, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "PBGC");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Funding 1.1.2013");


            #endregion


            #region PC - NewCB@1.1.2014

            pMain._SelectTab("Funding 1.1.2013");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "PC - NewCB@1.1.2014");
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
            dic.Add("Provisions_AddNew", "True");
            dic.Add("Provisions_Name", "");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab("Funding 1.1.2013");
            mTime.StopTimer(iPCNewCBAt112014_Node_Add);
            mLog.LogInfo(iPCNewCBAt112014_Node_Add, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Provisions");


            mTime.StartTimer();



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "FrozenVestingService");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "FrozenVestingService");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            mTime.StopTimer(iPCNewCBAt112014_Service_Select);
            mLog.LogInfo(iPCNewCBAt112014_Service_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "True");
            dic.Add("RulesBasedService", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProvidedInDataField", "VestingSVC");
            dic.Add("ServiceEndsAt_V", "");
            dic.Add("ServiceEndsAt_C", "Click");
            dic.Add("ServiceEndsAt_cbo", "");
            dic.Add("ServiceEndsAt_txt", "");
            dic.Add("MaximumService_UseServiceCap", "");
            dic.Add("FixedDate_UseServiceCap", "01/01/2014");
            dic.Add("Date_UseServiceCap", "");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncrement_V", "");
            dic.Add("ServiceIncrement_C", "");
            dic.Add("ServiceIncrement_cbo", "");
            dic.Add("ServiceIncrement_txt", "");
            pService._PopVerify_ServiceAtValuationDate_UseServiceCap(dic);



            mTime.StopTimer(iPCNewCBAt112014_Service_Edit);
            mLog.LogInfo(iPCNewCBAt112014_Service_Edit, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();


            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Provisions");


            mTime.StopTimer(iPCNewCBAt112014_Service_Save);
            mLog.LogInfo(iPCNewCBAt112014_Service_Save, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            pAssumptions._Collapse(dic);


            for (int i = 1; i <= 9; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Participant Info");
                dic.Add("Level_2", "Service");
                dic.Add("Level_3", "FrozenVestingService");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic);
            }



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Post78Service");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProvidedInDataField", "");
            dic.Add("ServiceEndsAt_V", "");
            dic.Add("ServiceEndsAt_C", "Click");
            dic.Add("ServiceEndsAt_cbo", "");
            dic.Add("ServiceEndsAt_txt", "");
            dic.Add("MaximumService_UseServiceCap", "");
            dic.Add("FixedDate_UseServiceCap", "01/01/2014");
            dic.Add("Date_UseServiceCap", "");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncrement_V", "");
            dic.Add("ServiceIncrement_C", "");
            dic.Add("ServiceIncrement_cbo", "");
            dic.Add("ServiceIncrement_txt", "");
            pService._PopVerify_ServiceAtValuationDate_UseServiceCap(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Post88Service");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProvidedInDataField", "");
            dic.Add("ServiceEndsAt_V", "");
            dic.Add("ServiceEndsAt_C", "Click");
            dic.Add("ServiceEndsAt_cbo", "");
            dic.Add("ServiceEndsAt_txt", "");
            dic.Add("MaximumService_UseServiceCap", "");
            dic.Add("FixedDate_UseServiceCap", "01/01/2014");
            dic.Add("Date_UseServiceCap", "");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncrement_V", "");
            dic.Add("ServiceIncrement_C", "");
            dic.Add("ServiceIncrement_cbo", "");
            dic.Add("ServiceIncrement_txt", "");
            pService._PopVerify_ServiceAtValuationDate_UseServiceCap(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "PriorService");
            dic.Add("Level_4", "PriorBenefitEligible");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "Max((Min($FrozenVestingService,28) - $Post78Service),0)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "NewService");
            dic.Add("Level_4", "NonGrandFathered");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "Min($Post88Service, Min($FrozenVestingService, 28))");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "NewService");
            dic.Add("Level_4", "PriorBenefitEligibility");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "Max((Min($FrozenVestingService, 28)-$Service7888-$PriorService),0)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "NewService");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "Min((Min($FrozenVestingService, 28)-$Service7888), $Post88Service)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "CreditedSvcPost88");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProvidedInDataField", "");
            dic.Add("ServiceEndsAt_V", "");
            dic.Add("ServiceEndsAt_C", "Click");
            dic.Add("ServiceEndsAt_cbo", "");
            dic.Add("ServiceEndsAt_txt", "");
            dic.Add("MaximumService_UseServiceCap", "");
            dic.Add("FixedDate_UseServiceCap", "01/01/2014");
            dic.Add("Date_UseServiceCap", "");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncrement_V", "");
            dic.Add("ServiceIncrement_C", "");
            dic.Add("ServiceIncrement_cbo", "");
            dic.Add("ServiceIncrement_txt", "");
            pService._PopVerify_ServiceAtValuationDate_UseServiceCap(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Post88ServiceNonFrozen");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Post88ServiceNonFrozen");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "True");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            dic.Add("ForInternationalAccounting_DE", "");
            dic.Add("ForTrade_DE", "");
            dic.Add("CalculateExactServiceAtReitermentAge_UK", "");
            pService._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProvidedInDataField", "Post88Svc");
            dic.Add("RoundingRule", "");
            dic.Add("V", "");
            dic.Add("C", "");
            dic.Add("T", "");
            dic.Add("txtServiceIncrement", "");
            dic.Add("cboServiceIncrement", "");
            pService._PopVerify_ServiceAtValuationDate(dic);




            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Post88ServiceForPayCredit");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Post88ServiceForPayCredit");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGruop1");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "True");
            dic.Add("UseServiceCa", "");
            dic.Add("ForInternationalAccounting_DE", "");
            dic.Add("ForTrade_DE", "");
            dic.Add("CalculateExactServiceAtReitermentAge_UK", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Min($Post88ServiceNonFrozen,$VestingService, 28)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "NonGrandfathered");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.BirthDate>=ToDate(1968,1,1) or $emp.ServiceBtw7888<=0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Post88ServiceForPayCredit");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGruop1");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "True");
            dic.Add("UseServiceCa", "");
            dic.Add("ForInternationalAccounting_DE", "");
            dic.Add("ForTrade_DE", "");
            dic.Add("CalculateExactServiceAtReitermentAge_UK", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max((Min($VestingService,28)-$Service7888-$PriorService),0)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "PriorBenefitEligibility");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.PriorSvcEligible=1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Post88ServiceForPayCredit");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "True");
            dic.Add("UseServiceCa", "");
            dic.Add("ForInternationalAccounting_DE", "");
            dic.Add("ForTrade_DE", "");
            dic.Add("CalculateExactServiceAtReitermentAge_UK", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Min((Min($VestingService,28)-$Service7888), $Post88ServiceNonFrozen)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Provisions");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "FreezeDate");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "FreezeDate");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            mTime.StopTimer(iPCNewCBAt112014_FromToAge_Select);
            mLog.LogInfo(iPCNewCBAt112014_FromToAge_Select, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "01/01/2014");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable(dic);

            mTime.StopTimer(iPCNewCBAt112014_FromToAge_Edit);
            mLog.LogInfo(iPCNewCBAt112014_FromToAge_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Provisions");

            mTime.StopTimer(iPCNewCBAt112014_FromToAge_Save);
            mLog.LogInfo(iPCNewCBAt112014_FromToAge_Save, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "EarliestOfFreezeOrExit");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "EarliestOfFreezeOrExit");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "True");
            pFromToAge._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Min($FreezeDate,$ExitAge)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            mTime.StartTimer();


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "BeforeFreeze");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "BeforeFreeze");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            mTime.StopTimer(iPCNewCBAt112014_Eligibility_Select);
            mLog.LogInfo(iPCNewCBAt112014_Eligibility_Select, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$Age < $FreezeDate");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            mTime.StopTimer(iPCNewCBAt112014_Eligibility_Edit);
            mLog.LogInfo(iPCNewCBAt112014_Eligibility_Edit, MyPerformanceCounter.Memory_Private);

            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Provisions");

            mTime.StopTimer(iPCNewCBAt112014_Eligibility_Save);
            mLog.LogInfo(iPCNewCBAt112014_Eligibility_Save, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "PayCreditEligible");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "PayCreditEligible");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.ParticipantStatus=\"AC\" and (Not $BeforeFreeze or $emp.ElectionActive =\"CB\")");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);




            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("Level_3", "SalaryAverage");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            mTime.StopTimer(iPCNewCBAt112014_PayAverage_Select);
            mLog.LogInfo(iPCNewCBAt112014_PayAverage_Select, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ApplyAveragePayLimit", "");
            dic.Add("ApplyPayAverageFreezeDefinition", "True");
            dic.Add("ApplyAverageAtFutureAge", "");
            pPayAverage._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "");
            dic.Add("AveragingMethod", "");
            dic.Add("M", "");
            dic.Add("RoundingForYearOfHire", "");
            dic.Add("DecimalPlacesForYearOfHire", "");
            dic.Add("Include", "");
            dic.Add("DropForCalculations", "");
            dic.Add("DropForCalculationAndPeriodConsidered", "");
            dic.Add("AdjustmentPeriodMonths", "");
            dic.Add("AdjustmentMethod", "");
            dic.Add("FreezePayAverageAtAge_V", "Click");
            dic.Add("FreezePayAverageAtAge_C", "");
            dic.Add("FreezePayAverageAtAge_cbo", "FreezeDate");
            pPayAverage._PopVerify_Standard(dic);



            mTime.StopTimer(iPCNewCBAt112014_PayAverage_Edit);
            mLog.LogInfo(iPCNewCBAt112014_PayAverage_Edit, MyPerformanceCounter.Memory_Private);




            mTime.StartTimer();


            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Provisions");


            mTime.StopTimer(iPCNewCBAt112014_PayAverage_Save);
            mLog.LogInfo(iPCNewCBAt112014_PayAverage_Save, MyPerformanceCounter.Memory_Private);




            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Social Security Covered Comp Formula");
            dic.Add("MenuItem", "Add Social Security Covered Comp Formula");
            pAssumptions._TreeViewRightSelect(dic, "SSCoveredCompFrozen");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Social Security Covered Comp Formula");
            dic.Add("Level_4", "SSCoveredCompFrozen");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);



            mTime.StopTimer(iPCNewCBAt112014_SSCC_Select);
            mLog.LogInfo(iPCNewCBAt112014_SSCC_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CustomCode", "True");
            dic.Add("TaxableWageBase", "");
            dic.Add("Final3Year_cbo", "");
            dic.Add("RoundResultToNearest12", "");
            pSocialSecurityCoveredCompFormula._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "");
            dic.Add("Expression", "$SSCoveredComp_SSCC[$EarliestOfFreezeOrExit]");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Name", "");
            dic.Add("Expression", "$SSCoveredComp_Final3YrAvg[$EarliestOfFreezeOrExit]");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Name", "");
            dic.Add("Expression", "$SSCoveredComp_TWB[$EarliestOfFreezeOrExit]");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            mTime.StopTimer(iPCNewCBAt112014_SSCC_Edit);
            mLog.LogInfo(iPCNewCBAt112014_SSCC_Edit, MyPerformanceCounter.Memory_Private);

            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(iPCNewCBAt112014_SSCC_Save);
            mLog.LogInfo(iPCNewCBAt112014_SSCC_Save, MyPerformanceCounter.Memory_Private);





            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "FAE Formula");
            dic.Add("Level_4", "NewRetBenefit2");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            mTime.StopTimer(iPCNewCBAt112014_FAEFormula_Select);
            mLog.LogInfo(iPCNewCBAt112014_FAEFormula_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iNumOfBreakpoints", "1");
            dic.Add("btnC", "");
            dic.Add("btnV", "Click");
            dic.Add("sData2", "SSCoveredCompFrozen_SSCC");
            dic.Add("sData3", "");
            pFAEFormula._TBL_Excess(dic);


            mTime.StopTimer(iPCNewCBAt112014_FAEFormula_Edit);
            mLog.LogInfo(iPCNewCBAt112014_FAEFormula_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(iPCNewCBAt112014_FAEFormula_Save);
            mLog.LogInfo(iPCNewCBAt112014_FAEFormula_Save, MyPerformanceCounter.Memory_Private);





            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Pay Credit");
            dic.Add("Level_4", "PayCreditAccrual");
            dic.Add("Level_5", "Actives");
            pAssumptions._TreeViewSelect(dic);

            mTime.StopTimer(iPCNewCBAt112014_PayCredit_Select);
            mLog.LogInfo(iPCNewCBAt112014_PayCredit_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "True");
            dic.Add("txtLocalEligibility", "BefFreeze");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$PayCreditEligible and $ActivesCB and $BeforeFreeze");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            mTime.StopTimer(iPCNewCBAt112014_PayCredit_Edit);
            mLog.LogInfo(iPCNewCBAt112014_PayCredit_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(iPCNewCBAt112014_PayCredit_Save);
            mLog.LogInfo(iPCNewCBAt112014_PayCredit_Save, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Pay Credit");
            dic.Add("Level_4", "PayCreditAccrual");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "UpdSalaryProjection");
            dic.Add("ServiceBasedOn", "VestingService");
            pPayCredit._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Service", "");
            dic.Add("LimitServiceTo", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccuralAt_C", "");
            dic.Add("StopAccuralAt_cbo", "");
            dic.Add("StopAccuralAt_txt", "");
            dic.Add("RateTiersBasedOn", "Service");
            dic.Add("NumberOfRateTiers", "3");
            pUnitFormula._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "1");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "3");
            dic.Add("sData", "5");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "1");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "3");
            dic.Add("sData", "0.03");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "2");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "3");
            dic.Add("sData", "15");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "3");
            dic.Add("sData", "0.04");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "3");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "3");
            dic.Add("sData", "100");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "3");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "3");
            dic.Add("sData", "0.05");
            dic.Add("bPayCredit", "True");
            pUnitFormula._FormulaTable(dic);

            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "True");
            dic.Add("cboPreDefinedEligibility", "PayCreditEligible");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Pay Credit");
            dic.Add("Level_4", "AdditPayCredit");
            dic.Add("Level_5", "Actives_notFAS35");
            pAssumptions._TreeViewSelect(dic);


            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "True");
            dic.Add("cboPreDefinedEligibility", "PayCreditEligible");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Pay Credit");
            dic.Add("MenuItem", "Add Pay Credit");
            pAssumptions._TreeViewRightSelect(dic, "ZeroPayCredit");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Pay Credit");
            dic.Add("Level_4", "ZeroPayCredit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "True");
            dic.Add("ApplyAveragePayLimit", "");
            dic.Add("ApplyPayAverageFreezeDefinition", "");
            dic.Add("ApplyAverageAtFutureAge", "");
            pPayAverage._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);





            mTime.StartTimer();


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Cash Balance");
            dic.Add("Level_4", "CashBalanceAmount");
            dic.Add("Level_5", "ActivesCB");
            pAssumptions._TreeViewSelect(dic);

            mTime.StopTimer(iPCNewCBAt112014_CashBalance_Select);
            mLog.LogInfo(iPCNewCBAt112014_CashBalance_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "True");
            dic.Add("cboPreDefinedEligibility", "PayCreditEligible");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            mTime.StopTimer(iPCNewCBAt112014_CashBalance_Edit);
            mLog.LogInfo(iPCNewCBAt112014_CashBalance_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Provisions");

            mTime.StopTimer(iPCNewCBAt112014_CashBalance_Save);
            mLog.LogInfo(iPCNewCBAt112014_CashBalance_Save, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Cash Balance");
            dic.Add("Level_4", "CashBalanceAmount");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StartingBalance", "");
            dic.Add("PayCredits", "ZeroPayCredit");
            pCashBalance._PopVerify_Standard(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Cash Balance");
            dic.Add("Level_4", "AdditCashBalAmount");
            dic.Add("Level_5", "ActivesCB");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StartingBalance", "");
            dic.Add("PayCredits", "ZeroPayCredit");
            pCashBalance._PopVerify_Standard(dic);


            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "True");
            dic.Add("cboPreDefinedEligibility", "PayCreditEligible");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Cash Balance");
            dic.Add("Level_4", "AdditCashBalAmount");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StartingBalance", "");
            dic.Add("PayCredits", "ZeroPayCredit");
            pCashBalance._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            pAssumptions._Collapse(dic);



            mTime.StartTimer();


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "RetirementBenefitCB");


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "RetirementBenefitCB");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            mTime.StopTimer(iPCNewCBAt112014_PlanDefinition_Select);
            mLog.LogInfo(iPCNewCBAt112014_PlanDefinition_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "LumpSumFOP");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Retirement");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "RetirementBenefitCB");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$CashBalanceAmount+$AdditCashBalAmount-$emp.QRDOOffsetBenefit");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "LumpSumFOP");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "ActivesCB");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "RetirementBenefitCB");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$CashBalanceAmount+$AdditCashBalAmount");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "LumpSumFOP");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "EarlyRetirementEligibility");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            mTime.StopTimer(iPCNewCBAt112014_PlanDefinition_Edit);
            mLog.LogInfo(iPCNewCBAt112014_PlanDefinition_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Provisions");


            mTime.StopTimer(iPCNewCBAt112014_PlanDefinition_Save);
            mLog.LogInfo(iPCNewCBAt112014_PlanDefinition_Save, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "RetirementBenefitCB");
            dic.Add("Level_4", "ActivesCB");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "RetirementBenefitCB");
            dic.Add("Level_4", "ActivesCB");
            dic.Add("MenuItem", "Move Up");
            pAssumptions._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "RetirementBenefitCB");
            pAssumptions._TreeViewSelect(dic);


            for (int i = 1; i <= 8; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Benefit Definition");
                dic.Add("Level_2", "Plan Definition");
                dic.Add("Level_3", "RetirementBenefitCB");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic);
            }


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "RetirementBenefitLS");
            dic.Add("Level_4", "CashBalanceEligible");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            pAssumptions._Collapse(dic);


            for (int i = 1; i <= 2; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Benefit Definition");
                dic.Add("Level_2", "Plan Definition");
                dic.Add("Level_3", "RetirementBenefitLS");
                dic.Add("Level_4", "CashBalanceEligible");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic);
            }

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "RetirementBenefitLS");
            dic.Add("Level_4", "FAS35Retirement");
            dic.Add("MenuItem", "Move Up");
            pAssumptions._TreeViewRightSelect(dic);




            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "WithdrawalBenefitCB");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WithdrawalBenefitCB");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "Actives");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "LumpSumFOP");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WithdrawalBenefitCB");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$CashBalanceAmount+$AdditCashBalAmount");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "LumpSumFOP");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "True");
            dic.Add("cboPreDefinedEligibility", "EarlyRetirementEligibility");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WithdrawalBenefitCB");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$CashBalanceAmount+$AdditCashBalAmount-$emp.QRDOOffsetBenefit*$FactorDefToAge65");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "LumpSumFOP");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "True");
            dic.Add("txtLocalEligibility", "ActiveCB");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$WithdrawalEligibilityCB and $ActivesCB");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WithdrawalBenefitCB");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$CashBalanceAmount+$AdditCashBalAmount");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "LumpSumFOP");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "True");
            dic.Add("cboPreDefinedEligibility", "WithdrawalEligibilityCB");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WithdrawalBenefitCB");
            dic.Add("Level_4", "EarlyRetirementEligibility");
            dic.Add("MenuItem", "Move Up");
            pAssumptions._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WithdrawalBenefitCB");
            dic.Add("Level_4", "EarlyRetirementEligibility");
            dic.Add("MenuItem", "Move Up");
            pAssumptions._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WithdrawalBenefitCB");
            dic.Add("Level_4", "ActiveCB");
            dic.Add("MenuItem", "Move Up");
            pAssumptions._TreeViewRightSelect(dic);


            for (int i = 1; i <= 5; i++)
            {

                dic.Clear();
                dic.Add("Level_1", "Benefit Definition");
                dic.Add("Level_2", "Plan Definition");
                dic.Add("Level_3", "WithdrawalBenefitCB");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic);
            }



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WithdrawalBenefitLS");
            dic.Add("Level_4", "WithActivesCB");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            pAssumptions._Collapse(dic);





            for (int i = 1; i <= 3; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Benefit Definition");
                dic.Add("Level_2", "Plan Definition");
                dic.Add("Level_3", "WithdrawalBenefitLS");
                dic.Add("Level_4", "Default");
                pAssumptions._TreeViewSelect(dic);

                dic.Clear();
                dic.Add("Level_1", "Benefit Definition");
                dic.Add("Level_2", "Plan Definition");
                dic.Add("Level_3", "WithdrawalBenefitLS");
                dic.Add("Level_4", "EarlyRetirementEligibility");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic);
            }

            for (int i = 1; i <= 2; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Benefit Definition");
                dic.Add("Level_2", "Plan Definition");
                dic.Add("Level_3", "WithdrawalBenefitLS");
                dic.Add("Level_4", "Default");
                pAssumptions._TreeViewSelect(dic);

                dic.Clear();
                dic.Add("Level_1", "Benefit Definition");
                dic.Add("Level_2", "Plan Definition");
                dic.Add("Level_3", "WithdrawalBenefitLS");
                dic.Add("Level_4", "WithActivesCB");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic);
            }

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WithdrawalBenefitLS");
            dic.Add("Level_4", "FAS35Withdrawal");
            dic.Add("MenuItem", "Move Up");
            pAssumptions._TreeViewRightSelect(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "RetirementBenefitCB");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "RetirementBenefitLS");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WithdrawalBenefitCB");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WithdrawalBenefitLS");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "DeathBenefitCB");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "DeathBenefitCB");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "Actives");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$CashBalanceAmount+$AdditCashBalAmount");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "VestingCriteria");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "LumpSumFOP");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Death");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "DeathBenefitCB");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$CashBalanceAmount+$AdditCashBalAmount-$emp.QRDOOffsetBenefit*$FactorDefToAge65");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "VestingCriteria");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "LumpSumFOP");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "True");
            dic.Add("cboPreDefinedEligibility", "ActivesCB");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "DeathBenefitCB");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$CashBalanceAmount+$AdditCashBalAmount");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "VestingCriteria");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "LumpSumFOP");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "True");
            dic.Add("txtLocalEligibility", "ActivesFAP");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.ParticipantStatus=\"AC\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "DeathBenefitCB");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "DeathBenefitCB");
            dic.Add("Level_4", "ActivesCB");
            dic.Add("MenuItem", "Move Up");
            pAssumptions._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "DeathBenefitCB");
            dic.Add("MenuItem", "Move Up");
            pAssumptions._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "DeathBenefitCB");
            dic.Add("MenuItem", "Move Up");
            pAssumptions._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "DeathBenefitLS");
            dic.Add("Level_4", "DeathCB");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);



            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "True");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$ActivesCB");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            for (int i = 1; i <= 3; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Benefit Definition");
                dic.Add("Level_2", "Plan Definition");
                dic.Add("Level_3", "DeathBenefitLS");
                dic.Add("Level_4", "Age70");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic);
            }

            for (int i = 1; i <= 4; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Benefit Definition");
                dic.Add("Level_2", "Plan Definition");
                dic.Add("Level_3", "DeathBenefitLS");
                dic.Add("Level_4", "DeathCB");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic);
            }



            pMain._SelectTab("Funding 1.1.2013");

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Funding 1.1.2013");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "View Read Only");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Methods");

            mTime.StopTimer(iPCNewCBAt112014_Methods_View);
            mLog.LogInfo(iPCNewCBAt112014_Methods_View, MyPerformanceCounter.Memory_Private);




            #endregion



            #region AC - LS Conv Fact 435_600_675

            pMain._SelectTab("Funding 1.1.2013");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "AC - LS Conv Fact 435_600_675");
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
            dic.Add("Provisions_AddNew", "True");
            dic.Add("Provisions_Name", "");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab("Funding 1.1.2013");
            mTime.StopTimer(iACLSConvFact425600675_Node_Add);
            mLog.LogInfo(iACLSConvFact425600675_Node_Add, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Funding 1.1.2013");

            dic.Clear();
            dic.Add("iMaxRowNum", "8");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Provisions");



            mTime.StartTimer();


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("Level_3", "LSFactorREA");
            dic.Add("Level_4", "FAS35Age60");
            pAssumptions._TreeViewSelect(dic);


            mTime.StopTimer(iACLSConvFact425600675_ConversionFactors_Select);
            mLog.LogInfo(iACLSConvFact425600675_ConversionFactors_Select, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("T", "");
            dic.Add("C", "");
            dic.Add("txtTabularOrConstantFactor_M", "");
            dic.Add("txtTabularOrConstantFactor_F", "");
            dic.Add("cboTabularOrConstantFactor", "LSD6013_425_600_675");
            pConversionFactors._PopVerify_TabularOrConstantFactor(dic);


            mTime.StopTimer(iACLSConvFact425600675_ConversionFactors_Edit);
            mLog.LogInfo(iACLSConvFact425600675_ConversionFactors_Edit, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();


            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Provisions");

            mTime.StopTimer(iACLSConvFact425600675_ConversionFactors_Save);
            mLog.LogInfo(iACLSConvFact425600675_ConversionFactors_Save, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("Level_3", "LSFactorREA");
            dic.Add("Level_4", "FAS35Age65");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("T", "");
            dic.Add("C", "");
            dic.Add("txtTabularOrConstantFactor_M", "");
            dic.Add("txtTabularOrConstantFactor_F", "");
            dic.Add("cboTabularOrConstantFactor", "LSD6513_425_600_675");
            pConversionFactors._PopVerify_TabularOrConstantFactor(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("Level_3", "LAtoLS");
            dic.Add("Level_4", "FAS35Elig");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("T", "");
            dic.Add("C", "");
            dic.Add("txtTabularOrConstantFactor_M", "");
            dic.Add("txtTabularOrConstantFactor_F", "");
            dic.Add("cboTabularOrConstantFactor", "LSIM13_425_600_675");
            pConversionFactors._PopVerify_TabularOrConstantFactor(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("Level_3", "DeathforFAS");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("T", "");
            dic.Add("C", "");
            dic.Add("txtTabularOrConstantFactor_M", "");
            dic.Add("txtTabularOrConstantFactor_F", "");
            dic.Add("cboTabularOrConstantFactor", "LSD6513_425_600_675");
            pConversionFactors._PopVerify_TabularOrConstantFactor(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Cash Balance");
            dic.Add("Level_4", "AdditCashBalAmount");
            dic.Add("Level_5", "ActivesCB");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StartingBalance", "");
            dic.Add("PayCredits", "AdditPayCredit");
            pCashBalance._PopVerify_Standard(dic);




            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Provisions");


            pMain._SelectTab("Funding 1.1.2013");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "8");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Parameter Print");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);



            mTime.StopTimer(iACLSConvFact425600675_ParamPrint_Select);
            mLog.LogInfo(iACLSConvFact425600675_ParamPrint_Select, MyPerformanceCounter.Memory_Private);

            mTime.StartTimer();

            _gLib._Exists("Parameter Print Report", pOutputManager.wRetirementStudio.wToolbar_btn.btnNextPage.btn, Config.iTimeout * 3, true);
            _gLib._Enabled("Parameter Print Report", pOutputManager.wRetirementStudio.wToolbar_btn.btnNextPage.btn, Config.iTimeout * 3, true);
            pMain._SelectTab("Parameter Print Report");

            mTime.StopTimer(iACLSConvFact425600675_ParamPrint_Generate);
            mLog.LogInfo(iACLSConvFact425600675_ParamPrint_Generate, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Funding 1.1.2013");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("MenuItem_1", "Tools");
            dic.Add("MenuItem_2", "Parameter Print Comparison");
            pMain._MenuSelect(dic);

            _gLib._Exists("Parameter Print Comparison", pMain.wParameterPrintComparison, 0, true);

            mTime.StopTimer(iACLSConvFact425600675_ParamPrintComparison_Select);
            mLog.LogInfo(iACLSConvFact425600675_ParamPrintComparison_Select, MyPerformanceCounter.Memory_Private);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Process", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_ParameterPrintComparison(dic);

            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "Funding 1.1.2013");
            dic.Add("Level_4", "Baseline");
            pMain._ParameterPrint_TreeviewSelect(dic, "Node1");

            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "Funding 1.1.2013");
            dic.Add("Level_4", "AC - LS Conv Fact 435_600_675");
            pMain._ParameterPrint_TreeviewSelect(dic, "Node2");


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Process", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_ParameterPrintComparison(dic);

            _gLib._Exists("BeyondCompare", pMain.wBeyondCompare, Config.iTimeout * 5, true);

            mTime.StopTimer(iACLSConvFact425600675_ParamPrintComparison_Generate);
            mLog.LogInfo(iACLSConvFact425600675_ParamPrintComparison_Generate, MyPerformanceCounter.Memory_Private);

            _gLib._SetSyncUDWin("BeyondCompare", pMain.wBeyondCompare.wTitleBar.btnClose, "Click", 0);




            pMain._SelectTab("Funding 1.1.2013");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "8");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("Object", "Main.RunOption");
            dic.Add("optiTimeout", "");
            pMain._ObjectExist(dic);

            mTime.StopTimer(iACLSConvFact425600675_ER_RunOption_Launch);
            mLog.LogInfo(iACLSConvFact425600675_ER_RunOption_Launch, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "PayfieldCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "CashBalanceAmount");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "True");
            dic.Add("FAS35PresentValueOfVestedBenefits", "True");
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "ElectionActive");
            dic.Add("RunValuation", "");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);

            mTime.StopTimer(iACLSConvFact425600675_ER_RunOption_Edit);
            mLog.LogInfo(iACLSConvFact425600675_ER_RunOption_Edit, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();
            mLog.LogInfo(iACLSConvFact425600675_ER_ClickRun, DateTime.Now.ToString());

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CheckPopup", "");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            mTime.StopTimer(iACLSConvFact425600675_ER_RunSubmitted);
            mLog.LogInfo(iACLSConvFact425600675_ER_RunSubmitted, MyPerformanceCounter.Memory_Private);





            #endregion



            #region ER & Reports

            pMain._SelectTab("Funding 1.1.2013");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);



            mLog.LogInfo(iBaseline_ER_GroupID, pMain._ER_ReturnRunStatus_TopGrid(2));
            mLog.LogInfo(iBaseline_ER_Persist, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            mLog.LogInfo(iBaseline_ER_Post, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));

            sERDetail = "";
            sERDetail = sERDetail + "Earliest Process: " + pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5) + Environment.NewLine;
            sERDetail = sERDetail + "Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 12) + Environment.NewLine;
            sERDetail = sERDetail + "Group Job Success: " + pMain._ER_ReturnRunStatus_TopGrid(11) + Environment.NewLine;
            mLog.LogInfo(iBaseline_ER_Detail, sERDetail);

            sERDetail = "";
            sERDetail = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3) + ": ";
            mLog.LogInfo(iBaseline_NumOfCores, sERDetail);

            mLog.LogInfo(iJobID_Baseline, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));


            pMain._SelectTab("Funding 1.1.2013");


            dic.Clear();
            dic.Add("iMaxRowNum", "8");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            mLog.LogInfo(iACLSConvFact425600675_ER_GroupID, pMain._ER_ReturnRunStatus_TopGrid(2));
            mLog.LogInfo(iACLSConvFact425600675_ER_Persist, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            mLog.LogInfo(iACLSConvFact425600675_ER_Post, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));

            sERDetail = "";
            sERDetail = sERDetail + "Earliest Process: " + pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5) + Environment.NewLine;
            sERDetail = sERDetail + "Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 12) + Environment.NewLine;
            sERDetail = sERDetail + "Group Job Success: " + pMain._ER_ReturnRunStatus_TopGrid(11) + Environment.NewLine;
            mLog.LogInfo(iACLSConvFact425600675_ER_Detail, sERDetail);

            sERDetail = "";
            sERDetail = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3) + ": ";
            mLog.LogInfo(iACLSConvFact425600675_NumOfCores, sERDetail);

            mLog.LogInfo(iJobID_ACLSConvFact425600675, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));


            pMain._SelectTab("Funding 1.1.2013");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "8");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Output");
            dic.Add("CheckOMSetupPopup", "False");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Output Manager");

            mTime.StopTimer(iACLSConvFact425600675_OM_View);
            mLog.LogInfo(iACLSConvFact425600675_OM_View, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Output Manager");
            mTime.StartTimer();

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputDir, "Gain / Loss Participant Listing", "RollForward", false, true);

            mTime.StopTimer(iACLSConvFact425600675_Export_GLParticipantListing);
            mLog.LogInfo(iACLSConvFact425600675_Export_GLParticipantListing, MyPerformanceCounter.Memory_Private);

            pMain._SelectTab("Output Manager");
            mTime.StartTimer();
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputDir, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);

            mTime.StopTimer(iACLSConvFact425600675_Export_GLSummaryOfLiabilityReconciliation);
            mLog.LogInfo(iACLSConvFact425600675_Export_GLSummaryOfLiabilityReconciliation, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Output Manager");
            mTime.StartTimer();

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputDir, "IOE", "RollForward", false, true);

            mTime.StopTimer(iACLSConvFact425600675_Export_IOE);
            mLog.LogInfo(iACLSConvFact425600675_Export_IOE, MyPerformanceCounter.Memory_Private);



            pMain._SelectTab("Output Manager");
            mTime.StartTimer();

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputDir, "Payout Projection", "RollForward", false, true);

            mTime.StopTimer(iACLSConvFact425600675_Export_PayoutProjection);
            mLog.LogInfo(iACLSConvFact425600675_Export_PayoutProjection, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Output Manager");
            mTime.StartTimer();

            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputDir, "Valuation Summary", "RollForward", false, true);

            mTime.StopTimer(iACLSConvFact425600675_Export_ValuationSummary);
            mLog.LogInfo(iACLSConvFact425600675_Export_ValuationSummary, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Output Manager");
            mTime.StartTimer();

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputDir, "Reconciliation to Baseline", "RollForward", false, true);

            mTime.StopTimer(iACLSConvFact425600675_Export_ReconciliationToBaseline);
            mLog.LogInfo(iACLSConvFact425600675_Export_ReconciliationToBaseline, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Output Manager");
            mTime.StartTimer();

            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputDir, "Liabilities Detailed Results", "RollForward", false, true);

            mTime.StopTimer(iACLSConvFact425600675_Export_LiabilityDetailedResults);
            mLog.LogInfo(iACLSConvFact425600675_Export_LiabilityDetailedResults, MyPerformanceCounter.Memory_Private);




            pMain._SelectTab("Funding 1.1.2013");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Home");



            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Funding 1.1.2013");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            mTime.StopTimer(iService_ReOpen);
            mLog.LogInfo(iService_ReOpen, MyPerformanceCounter.Memory_Private);





            #endregion




            mLog.LogInfo(iTimeEnd, DateTime.Now.ToString());

            _gLib._MsgBox("Congratulations!", "Finished!");

            Environment.Exit(0);



        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {

            ////mLog.LogInfo(iTest, MyPerformanceCounter.Memory_Private);
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
