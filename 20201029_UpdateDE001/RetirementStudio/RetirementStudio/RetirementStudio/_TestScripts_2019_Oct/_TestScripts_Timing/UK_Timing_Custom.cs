////// ----------------------- ------------------------------------------------------------------------///////////
//////                           This test Based on UKTiming Test Part-2                               ///////////
//////                                down to Node  CMI 1.5% new ret dec                               ///////////
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
using System.Diagnostics;


namespace RetirementStudio._TestScripts_2019_Oct_Timing
{
    /// <summary>
    /// Summary description for UK_Timing_Custom
    /// </summary>
    [CodedUITest]
    public class UK_Timing_Custom
    {
        public UK_Timing_Custom()
        {
            Config.eEnv = _TestingEnv.Prod_CA;
            Config.eCountry = _Country.UK;
            Config.sStudioLaunchDir = @"C:\Users\webber-ling\Desktop\Retirement Studio-Canada - 1 .appref-ms";
            //Config.sStudioLaunchDir = @"C:\Users\webber-ling\Desktop\EUProd7401\Client\RetirementStudio.exe";
            //Config.sClientName = "UK_Performance_Test_Custom"; //QA1 client
            //Config.sClientName = "UK Performance Test Custom B"; //EU Prod client
            //Config.sClientName = "UK Performance Test Custom E"; //EU Prod client
            Config.sClientName = "UK Performance Test Custom"; //CA Prod client
            //Config.sClientName = "UK Performance Test D"; //US Prod client
            Config.sPlanName = "UK Plan";
            ////Config.sDataCenter = "Exeter";
            ////Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = false;
            Config.bCompareReports = false;


        }

        Boolean bExportIOE = false; // CA production fields exceed maximum. set to false
        //Boolean bExportIOE = true;


        #region Timing



        static string sCol_Time = "Time";
        static string sCol_Memory = "Memory";
        static string sLogFile = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\UK_Timing_Test_Custom\UK_Timing_Test_Custom_CUIT.xls";
        static string sOutputDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\UK_Timing_Test_Custom\Reports_KeepUpdateOnRun\";
        MyTimer mTime = new MyTimer(sCol_Time, sLogFile);
        MyLog mLog = new MyLog(sCol_Memory, sLogFile);
        MyLog mLogTime = new MyLog(sCol_Time, sLogFile);

        MyDictionary dicPosition = new MyDictionary();
        string sERDetail = "";


        #region Result Index

        static int iJobID_0PercentRunForFSGCashflow_1 = 130;
        static int iJobID_0PercentRunForFSGCashflow_2 = iJobID_0PercentRunForFSGCashflow_1 + 1;
        static int iJobID_25PercentRunForFSGCashflow_1 = iJobID_0PercentRunForFSGCashflow_2 + 1;
        static int iJobID_25PercentRunForFSGCashflow_2 = iJobID_25PercentRunForFSGCashflow_1 + 1;
        static int iJobID_CMI15NewRet025Infl_1 = iJobID_25PercentRunForFSGCashflow_2 + 1;
        static int iJobID_CMI15NewRet025Infl_2 = iJobID_CMI15NewRet025Infl_1 + 1;
        static int iJobID_1PstRetAoA_1 = iJobID_CMI15NewRet025Infl_2 + 1;
        static int iJobID_1PstRetAoA_2 = iJobID_1PstRetAoA_1 + 1;
        static int iJobID_PPFAndSolvency_1 = iJobID_1PstRetAoA_2 + 1;
        static int iJobID_PPFAndSolvency_2 = iJobID_PPFAndSolvency_1 + 1;


        static int iTimeStart = 2;
        static int iTimeEnd = iTimeStart + 1;
        static int iLaunchStudio = iTimeEnd + 2;
        static int iLocateService = iLaunchStudio + 1;
        static int iOpenService = iLocateService + 1;


        static int i0PercentRunForFSGCashflow_AddNode = iOpenService + 1;
        static int i0PercentRunForFSGCashflow_InterestRate_Edit = i0PercentRunForFSGCashflow_AddNode + 1;
        static int i0PercentRunForFSGCashflow_PayIncrease_Edit = i0PercentRunForFSGCashflow_InterestRate_Edit + 1;
        static int i0PercentRunForFSGCashflow_OtherEconomicAssumptions_Add = i0PercentRunForFSGCashflow_PayIncrease_Edit + 1;
        static int i0PercentRunForFSGCashflow_CustomRates_Edit = i0PercentRunForFSGCashflow_OtherEconomicAssumptions_Add + 1;
        static int i0PercentRunForFSGCashflow_OtherEconomicAssumptions_Edit = i0PercentRunForFSGCashflow_CustomRates_Edit + 1;
        static int i0PercentRunForFSGCashflow_GMPAdjustmentFactor_Edit = i0PercentRunForFSGCashflow_OtherEconomicAssumptions_Edit + 1;
        static int i0PercentRunForFSGCashflow_PayProjection_Edit = i0PercentRunForFSGCashflow_GMPAdjustmentFactor_Edit + 1;
        static int i0PercentRunForFSGCashflow_Assumption_Save = i0PercentRunForFSGCashflow_PayProjection_Edit + 1;
        static int i0PercentRunForFSGCashflow_TestCaseLib_Open = i0PercentRunForFSGCashflow_Assumption_Save + 1;
        static int i0PercentRunForFSGCashflow_TestCase_NR793216D_Select = i0PercentRunForFSGCashflow_TestCaseLib_Open + 1;
        static int i0PercentRunForFSGCashflow_TestCase_NR793216D_Run = i0PercentRunForFSGCashflow_TestCase_NR793216D_Select + 1;
        static int i0PercentRunForFSGCashflow_TestCase_NR793216D_View = i0PercentRunForFSGCashflow_TestCase_NR793216D_Run + 1;
        static int i0PercentRunForFSGCashflow_TestCase_SC590570A_Select = i0PercentRunForFSGCashflow_TestCase_NR793216D_View + 1;
        static int i0PercentRunForFSGCashflow_TestCase_SC590570A_Run = i0PercentRunForFSGCashflow_TestCase_SC590570A_Select + 1;
        static int i0PercentRunForFSGCashflow_TestCase_SC590570A_View = i0PercentRunForFSGCashflow_TestCase_SC590570A_Run + 1;
        static int i0PercentRunForFSGCashflow_TestCase_Save = i0PercentRunForFSGCashflow_TestCase_SC590570A_View + 1;
        static int i0PercentRunForFSGCashflow_RunOption_Launch = i0PercentRunForFSGCashflow_TestCase_Save + 1;
        static int i0PercentRunForFSGCashflow_RunOption_Edit = i0PercentRunForFSGCashflow_RunOption_Launch + 1;
        static int i0PercentRunForFSGCashflow_RunSubmission = i0PercentRunForFSGCashflow_RunOption_Edit + 1;
        static int i0PercentRunForFSGCashflow_ER_ClickRun = i0PercentRunForFSGCashflow_RunSubmission + 1;
        static int i0PercentRunForFSGCashflow_GroupID = i0PercentRunForFSGCashflow_ER_ClickRun + 1;
        static int i0PercentRunForFSGCashflow_Persist_80 = i0PercentRunForFSGCashflow_GroupID + 1;
        static int i0PercentRunForFSGCashflow_Post_80 = i0PercentRunForFSGCashflow_Persist_80 + 1;
        static int i0PercentRunForFSGCashflow_Persist_60 = i0PercentRunForFSGCashflow_Post_80 + 1;
        static int i0PercentRunForFSGCashflow_Post_60 = i0PercentRunForFSGCashflow_Persist_60 + 1;
        static int i0PercentRunForFSGCashflow_ER_Detail = i0PercentRunForFSGCashflow_Post_60 + 1;
        static int i0PercentRunForFSGCashflow_NumOfCores = i0PercentRunForFSGCashflow_ER_Detail + 1;
        static int i0PercentRunForFSGCashflow_OpenOM = i0PercentRunForFSGCashflow_NumOfCores + 1;
        static int i0PercentRunForFSGCashflow_DetailResult_Load = i0PercentRunForFSGCashflow_OpenOM + 1;
        static int i0PercentRunForFSGCashflow_PayoutProject_Load = i0PercentRunForFSGCashflow_DetailResult_Load + 1;
        static int i0PercentRunForFSGCashflow_ExportIOE = i0PercentRunForFSGCashflow_PayoutProject_Load + 1;



        static int i25PercentRunForFSGCashflow_AddNode = i0PercentRunForFSGCashflow_ExportIOE + 1;
        static int i25PercentRunForFSGCashflow_CustomRates_Edit = i25PercentRunForFSGCashflow_AddNode + 1;
        static int i25PercentRunForFSGCashflow_OtherEconomicAssumptions_Edit = i25PercentRunForFSGCashflow_CustomRates_Edit + 1;
        static int i25PercentRunForFSGCashflow_Assumption_Save = i25PercentRunForFSGCashflow_OtherEconomicAssumptions_Edit + 1;
        static int i25PercentRunForFSGCashflow_RunOption_Launch = i25PercentRunForFSGCashflow_Assumption_Save + 1;
        static int i25PercentRunForFSGCashflow_RunOption_Edit = i25PercentRunForFSGCashflow_RunOption_Launch + 1;
        static int i25PercentRunForFSGCashflow_RunSubmission = i25PercentRunForFSGCashflow_RunOption_Edit + 1;
        static int i25PercentRunForFSGCashflow_ER_ClickRun = i25PercentRunForFSGCashflow_RunSubmission + 1;
        static int i25PercentRunForFSGCashflow_GroupID = i25PercentRunForFSGCashflow_ER_ClickRun + 1;
        static int i25PercentRunForFSGCashflow_Persist_80 = i25PercentRunForFSGCashflow_GroupID + 1;
        static int i25PercentRunForFSGCashflow_Post_80 = i25PercentRunForFSGCashflow_Persist_80 + 1;
        static int i25PercentRunForFSGCashflow_Persist_60 = i25PercentRunForFSGCashflow_Post_80 + 1;
        static int i25PercentRunForFSGCashflow_Post_60 = i25PercentRunForFSGCashflow_Persist_60 + 1;
        static int i25PercentRunForFSGCashflow_ER_Detail = i25PercentRunForFSGCashflow_Post_60 + 1;
        static int i25PercentRunForFSGCashflow_NumOfCores = i25PercentRunForFSGCashflow_ER_Detail + 1;
        static int i25PercentRunForFSGCashflow_OpenOM = i25PercentRunForFSGCashflow_NumOfCores + 1;
        static int i25PercentRunForFSGCashflow_DetailResult_Load = i25PercentRunForFSGCashflow_OpenOM + 1;
        static int i25PercentRunForFSGCashflow_PayoutProject_Load = i25PercentRunForFSGCashflow_DetailResult_Load + 1;
        static int i25PercentRunForFSGCashflow_ExportIOE = i25PercentRunForFSGCashflow_PayoutProject_Load + 1;


        static int iCMI15NewRet025Infl_AddNode = i25PercentRunForFSGCashflow_ExportIOE + 1;
        static int iCMI15NewRet025Infl_CustomRates_Edit = iCMI15NewRet025Infl_AddNode + 1;
        static int iCMI15NewRet025Infl_Assumption_Save = iCMI15NewRet025Infl_CustomRates_Edit + 1;
        static int iCMI15NewRet025Infl_RunOption_Launch = iCMI15NewRet025Infl_Assumption_Save + 1;
        static int iCMI15NewRet025Infl_RunOption_Edit = iCMI15NewRet025Infl_RunOption_Launch + 1;
        static int iCMI15NewRet025Infl_RunSubmission = iCMI15NewRet025Infl_RunOption_Edit + 1;
        static int iCMI15NewRet025Infl_ER_ClickRun = iCMI15NewRet025Infl_RunSubmission + 1;
        static int iCMI15NewRet025Infl_GroupID = iCMI15NewRet025Infl_ER_ClickRun + 1;
        static int iCMI15NewRet025Infl_Persist_80 = iCMI15NewRet025Infl_GroupID + 1;
        static int iCMI15NewRet025Infl_Post_80 = iCMI15NewRet025Infl_Persist_80 + 1;
        static int iCMI15NewRet025Infl_Persist_60 = iCMI15NewRet025Infl_Post_80 + 1;
        static int iCMI15NewRet025Infl_Post_60 = iCMI15NewRet025Infl_Persist_60 + 1;
        static int iCMI15NewRet025Infl_ER_Detail = iCMI15NewRet025Infl_Post_60 + 1;
        static int iCMI15NewRet025Infl_NumOfCores = iCMI15NewRet025Infl_ER_Detail + 1;
        static int iCMI15NewRet025Infl_OpenOM = iCMI15NewRet025Infl_NumOfCores + 1;
        static int iCMI15NewRet025Infl_DetailResult_Load = iCMI15NewRet025Infl_OpenOM + 1;
        static int iCMI15NewRet025Infl_PayoutProject_Load = iCMI15NewRet025Infl_DetailResult_Load + 1;
        static int iCMI15NewRet025Infl_ExportIOE = iCMI15NewRet025Infl_PayoutProject_Load + 1;
        static int iCMI15NewRet025Infl_RunFC = iCMI15NewRet025Infl_ExportIOE + 1;
        static int iCMI15NewRet025Infl_LaunchFC = iCMI15NewRet025Infl_RunFC + 1;


        static int i1PstRetAoA_AddNode = iCMI15NewRet025Infl_LaunchFC + 1;
        static int i1PstRetAoA_InterestRates_Edit = i1PstRetAoA_AddNode + 1;
        static int i1PstRetAoA_Assumption_Save = i1PstRetAoA_InterestRates_Edit + 1;
        static int i1PstRetAoA_RunOption_Launch = i1PstRetAoA_Assumption_Save + 1;
        static int i1PstRetAoA_RunOption_Edit = i1PstRetAoA_RunOption_Launch + 1;
        static int i1PstRetAoA_RunSubmission = i1PstRetAoA_RunOption_Edit + 1;
        static int i1PstRetAoA_ER_ClickRun = i1PstRetAoA_RunSubmission + 1;
        static int i1PstRetAoA_GroupID = i1PstRetAoA_ER_ClickRun + 1;
        static int i1PstRetAoA_Persist_80 = i1PstRetAoA_GroupID + 1;
        static int i1PstRetAoA_Post_80 = i1PstRetAoA_Persist_80 + 1;
        static int i1PstRetAoA_Persist_60 = i1PstRetAoA_Post_80 + 1;
        static int i1PstRetAoA_Post_60 = i1PstRetAoA_Persist_60 + 1;
        static int i1PstRetAoA_ER_Detail = i1PstRetAoA_Post_60 + 1;
        static int i1PstRetAoA_NumOfCores = i1PstRetAoA_ER_Detail + 1;
        static int i1PstRetAoA_OpenOM = i1PstRetAoA_NumOfCores + 1;
        static int i1PstRetAoA_DetailResult_Load = i1PstRetAoA_OpenOM + 1;
        static int i1PstRetAoA_PayoutProject_Load = i1PstRetAoA_DetailResult_Load + 1;
        static int i1PstRetAoA_ExportIOE = i1PstRetAoA_PayoutProject_Load + 1;
        static int i1PstRetAoA_RunFC = i1PstRetAoA_ExportIOE + 1;
        static int i1PstRetAoA_LaunchFC = i1PstRetAoA_RunFC + 1;


        static int iPPFAndSolvency_AddNode = i1PstRetAoA_LaunchFC + 1;
        static int iPPFAndSolvency_InterestRates_Edit = iPPFAndSolvency_AddNode + 1;
        static int iPPFAndSolvency_CustomRates_Edit = iPPFAndSolvency_InterestRates_Edit + 1;
        static int iPPFAndSolvency_PayIncrease_Edit = iPPFAndSolvency_CustomRates_Edit + 1;
        static int iPPFAndSolvency_Infalation_Edit = iPPFAndSolvency_PayIncrease_Edit + 1;
        static int iPPFAndSolvency_OtherEconomicAssumptions_Edit = iPPFAndSolvency_Infalation_Edit + 1;
        static int iPPFAndSolvency_MortalityDecrement_Edit = iPPFAndSolvency_OtherEconomicAssumptions_Edit + 1;
        static int iPPFAndSolvency_Assumption_Save = iPPFAndSolvency_MortalityDecrement_Edit + 1;
        static int iPPFAndSolvency_GMPAdjustmentFactor80_Edit = iPPFAndSolvency_Assumption_Save + 1;
        static int iPPFAndSolvency_GMPAdjustmentFactor60_Edit = iPPFAndSolvency_GMPAdjustmentFactor80_Edit + 1;
        static int iPPFAndSolvency_Provision_Save = iPPFAndSolvency_GMPAdjustmentFactor60_Edit + 1;
        static int iPPFAndSolvency_RunOption_Launch = iPPFAndSolvency_Provision_Save + 1;
        static int iPPFAndSolvency_RunOption_Edit = iPPFAndSolvency_RunOption_Launch + 1;
        static int iPPFAndSolvency_RunSubmission = iPPFAndSolvency_RunOption_Edit + 1;
        static int iPPFAndSolvency_ER_ClickRun = iPPFAndSolvency_RunSubmission + 1;
        static int iPPFAndSolvency_GroupID = iPPFAndSolvency_ER_ClickRun + 1;
        static int iPPFAndSolvency_Persist_80 = iPPFAndSolvency_GroupID + 1;
        static int iPPFAndSolvency_Post_80 = iPPFAndSolvency_Persist_80 + 1;
        static int iPPFAndSolvency_Persist_60 = iPPFAndSolvency_Post_80 + 1;
        static int iPPFAndSolvency_Post_60 = iPPFAndSolvency_Persist_60 + 1;
        static int iPPFAndSolvency_ER_Detail = iPPFAndSolvency_Post_60 + 1;
        static int iPPFAndSolvency_NumOfCores = iPPFAndSolvency_ER_Detail + 1;
        static int iPPFAndSolvency_OpenOM = iPPFAndSolvency_NumOfCores + 1;
        static int iPPFAndSolvency_DetailResult_Load = iPPFAndSolvency_OpenOM + 1;
        static int iPPFAndSolvency_PayoutProject_Load = iPPFAndSolvency_DetailResult_Load + 1;
        static int iPPFAndSolvency_ExportIOE = iPPFAndSolvency_PayoutProject_Load + 1;
        static int iPPFAndSolvency_RunFC = iPPFAndSolvency_ExportIOE + 1;
        static int iPPFAndSolvency_LaunchFC = iPPFAndSolvency_RunFC + 1;


        static int iTest = 128;

        #endregion




        #endregion


        #region change date format

        public class DateTimeFormatbyCountry
        {
            public string changeDateTimeFormatbyCountry(string datetime, _Country eCountry)
            {

                if (eCountry == _Country.UK)
                {
                    string[] arrdatetime = datetime.Split('/');
                    datetime = arrdatetime[1] + "/" + arrdatetime[0] + "/" + arrdatetime[2];
                    return datetime;
                }
                else return datetime;
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
        public void test_UK_Timing_Custom()
        {


            DateTimeFormatbyCountry DateTimeFormat = new DateTimeFormatbyCountry();

            _gLib._MsgBoxYesNo("Warning", "ExportIOE = " + bExportIOE.ToString() + " , continue??? CA Prod should be False because of # of fields Limitation.");

            _gLib._StudioClearCache();   //////////_gLib._MsgBox("Warning!", "Please Clear Cache!");

            pMain._SetLanguageAndRegional();


            int iCol_Memory;
            string _sER_ReturnRunStatus_ClickRun;
            MyExcel _excelLog = new MyExcel(sLogFile, true);
            _excelLog.OpenExcelFile("Sheet1");
            iCol_Memory = _excelLog.getColumnIndex(sCol_Memory);
            _excelLog.CloseExcelApplication();


            #region Launch Studio/Open Service

            mLog.LogInfo(iTimeStart, DateTime.Now.ToString());

            mTime.StartTimer();

            _gLib._Cmd(Config.sStudioLaunchDir);

            pMain._SelectTab("Home");
            mTime.StopTimer(iLaunchStudio);
            mLog.LogInfo(iLaunchStudio, MyPerformanceCounter.Memory_Private);




            ////////////////////_gLib._MsgBox("Warning!", "Please manually select the Client in Studio-> Home -> All Services -> " + Config.sClientName + Environment.NewLine + Environment.NewLine
            ////////////////////    + "Click OK to keep testing!");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            _gLib._KillProcessByName("Mercer.RetirementStudio.Messaging.MessagingClientApp");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation2012");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            mTime.StopTimer(iOpenService);
            mLog.LogInfo(iOpenService, MyPerformanceCounter.Memory_Private);

            #endregion


            #region 0 % Run for FSG Cashflow

            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "170");
            dic.Add("iPosY", "265");
            dic.Add("MenuItem_1", "Add Valuation Node");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "0 Pst run for FSG cashflows");
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


            pMain._SelectTab("Valuation2012");

            mTime.StopTimer(i0PercentRunForFSGCashflow_AddNode);
            mLog.LogInfo(i0PercentRunForFSGCashflow_AddNode, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Valuation2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "170");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("MenuItem", "Use Alternative Basis Folders");
            pAssumptions._TreeViewRightSelect(dic, "");

            pMain._SelectTab("Assumptions");
            mTime.StopTimer(i0PercentRunForFSGCashflow_InterestRate_Edit);
            mLog.LogInfo(i0PercentRunForFSGCashflow_InterestRate_Edit, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryInflationAssumption");
            dic.Add("MenuItem", "Use Alternative Basis Folders");
            pAssumptions._TreeViewRightSelect(dic, "");

            pMain._SelectTab("Assumptions");
            mTime.StopTimer(i0PercentRunForFSGCashflow_PayIncrease_Edit);
            mLog.LogInfo(i0PercentRunForFSGCashflow_PayIncrease_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("MenuItem", "Use Alternative Basis Folders");
            pAssumptions._TreeViewRightSelect(dic, "");

            pMain._SelectTab("Assumptions");
            mTime.StopTimer(i0PercentRunForFSGCashflow_OtherEconomicAssumptions_Add);
            mLog.LogInfo(i0PercentRunForFSGCashflow_OtherEconomicAssumptions_Add, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "RPIInflationAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "0.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "Pst88GMPinPaymentAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "0.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CappedPst10InflationAssumption");
            dic.Add("Level_4", "EDTmembers");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "0.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CappedPst10InflationAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "0.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            pMain._SelectTab("Assumptions");
            mTime.StopTimer(i0PercentRunForFSGCashflow_CustomRates_Edit);
            mLog.LogInfo(i0PercentRunForFSGCashflow_CustomRates_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SalCapInc_P", "Click");
            dic.Add("S148Inc_P", "Click");
            dic.Add("LimmGMPRate_P", "Click");
            dic.Add("SalCapInc_txt", "");
            dic.Add("S148Inc_txt", "1.0");
            dic.Add("LimmGMPRate_txt", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_UK(dic);

            pMain._SelectTab("Assumptions");
            mTime.StopTimer(i0PercentRunForFSGCashflow_OtherEconomicAssumptions_Edit);
            mLog.LogInfo(i0PercentRunForFSGCashflow_OtherEconomicAssumptions_Edit, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Valuation2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "170");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Provisions");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "GMP Adjustment Factors");
            dic.Add("Level_4", "GMPrevaluation");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Act_FromValuation_S148Increases", "");
            dic.Add("Act_FromValuation_FixedRateAt", "");
            dic.Add("Act_FromValuation_FixedRateAt_V", "Click");
            dic.Add("Act_FromValuation_FixedRateAt_D", "");
            dic.Add("Act_FromValuation_PensionIncrease", "");
            dic.Add("Act_FromValuation_FixedRateAt_V_cbo", "");
            dic.Add("Act_FromValuation_FixedRateAt_D_txt", "");
            dic.Add("Act_FromDate_S148Increases", "");
            dic.Add("Act_FromDate_FixedRateAt", "");
            dic.Add("Act_FromDate_FixedRateAt_V", "");
            dic.Add("Act_FromDate_FixedRateAt_D", "Click");
            dic.Add("Act_FromDate_PensionIncrease", "");
            dic.Add("Act_FromDate_FixedRateAt_V_cbo", "");
            dic.Add("Act_FromDate_FixedRateAt_D_txt", "05/04/2012");
            dic.Add("Inact_S148Increases", "");
            dic.Add("Inact_FixedRateAtDateOfLeaving", "");
            dic.Add("Inact_FixedRateAt", "");
            dic.Add("Inact_FixedDateAt_V", "");
            dic.Add("Inact_FixedDateAt_D", "");
            dic.Add("Inact_LimitedRate", "");
            dic.Add("Inact_PensionIncrease", "");
            dic.Add("Inact_FixedDateAt_V_cbo", "");
            dic.Add("Inact_FixedDateAt_D_txt", "");
            dic.Add("Increase_Pre88GMP_V", "");
            dic.Add("Increase_Pre88GMP_P", "");
            dic.Add("Increase_Pre88GMP_T", "");
            dic.Add("Increase_Post88GMP_V", "");
            dic.Add("Increase_Post88GMP_P", "");
            dic.Add("Increase_Post88GMP_T", "");
            dic.Add("Increase_Pre88GMPPension", "");
            dic.Add("Increase_Post88GMPPension", "");
            dic.Add("Increase_Pre88GMP_V_cbo", "");
            dic.Add("Increase_Pre88GMP_P_txt", "");
            dic.Add("Increase_Pre88GMP_T_cbo", "");
            dic.Add("Increase_Post88GMP_V_cbo", "");
            dic.Add("Increase_Post88GMP_P_txt", "");
            dic.Add("Increase_Post88GMP_T_cbo", "");
            pGMPAdjustmentFactors._PopVerify_GMPAdjustmentFactors(dic);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(i0PercentRunForFSGCashflow_GMPAdjustmentFactor_Edit);
            mLog.LogInfo(i0PercentRunForFSGCashflow_GMPAdjustmentFactor_Edit, MyPerformanceCounter.Memory_Private);

            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(i0PercentRunForFSGCashflow_Assumption_Save);
            mLog.LogInfo(i0PercentRunForFSGCashflow_Assumption_Save, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "170");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Test Case");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Test Case Library");

            mTime.StopTimer(i0PercentRunForFSGCashflow_TestCaseLib_Open);
            mLog.LogInfo(i0PercentRunForFSGCashflow_TestCaseLib_Open, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.EmployeeIDNumber=\"UK12345JW\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._SelectTab("Test Case Library");

            mTime.StopTimer(i0PercentRunForFSGCashflow_TestCase_NR793216D_Select);
            mLog.LogInfo(i0PercentRunForFSGCashflow_TestCase_NR793216D_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunSelectedTestLife", "Click");
            pTestCaseLibrary._PopVerify_TestCaseLibrary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PPA_NAR_Min", "");
            dic.Add("PPA_NAR_Max", "");
            dic.Add("PPA_NAR_PVVB", "");
            dic.Add("PBGC_NAR_PVVB", "");
            dic.Add("FAS35_PVAB", "");
            dic.Add("FAS35_PVVB", "");
            dic.Add("Funding", "True");
            dic.Add("PayoutProjection", "");
            dic.Add("RunSelected", "Click");
            pTestCaseLibrary._PopVerify_TestCaseRunOption(dic);

            _gLib._Enabled("Recalculate", pTestCaseLibrary.wTestCaseViewer.wRecalculate, Config.iTimeout * 3, true);
            _gLib._Exists("Recalculate", pTestCaseLibrary.wTestCaseViewer.wViewTestCaseInExcel.txt.link, Config.iTimeout * 3, true);

            mTime.StopTimer(i0PercentRunForFSGCashflow_TestCase_NR793216D_Run);
            mLog.LogInfo(i0PercentRunForFSGCashflow_TestCase_NR793216D_Run, MyPerformanceCounter.Memory_Private);




            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewTestCaseInExcel", "Click");
            dic.Add("Close", "");
            pTestCaseLibrary._PopVerify_TestCaseViewer(dic);

            _gLib._Exists("Excel", pOutputManager.wExcel, Config.iTimeout * 3, true);


            mTime.StopTimer(i0PercentRunForFSGCashflow_TestCase_NR793216D_View);
            mLog.LogInfo(i0PercentRunForFSGCashflow_TestCase_NR793216D_View, MyPerformanceCounter.Memory_Private);


            _gLib._KillProcessByName("EXCEL");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewTestCaseInExcel", "");
            dic.Add("Close", "Click");
            pTestCaseLibrary._PopVerify_TestCaseViewer(dic);


            pMain._SelectTab("Test Case Library");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.EmployeeIDNumber=\"UK12345KF\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._SelectTab("Test Case Library");

            mTime.StopTimer(i0PercentRunForFSGCashflow_TestCase_SC590570A_Select);
            mLog.LogInfo(i0PercentRunForFSGCashflow_TestCase_SC590570A_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunSelectedTestLife", "Click");
            pTestCaseLibrary._PopVerify_TestCaseLibrary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PPA_NAR_Min", "");
            dic.Add("PPA_NAR_Max", "");
            dic.Add("PPA_NAR_PVVB", "");
            dic.Add("PBGC_NAR_PVVB", "");
            dic.Add("FAS35_PVAB", "");
            dic.Add("FAS35_PVVB", "");
            dic.Add("Funding", "True");
            dic.Add("PayoutProjection", "");
            dic.Add("RunSelected", "Click");
            pTestCaseLibrary._PopVerify_TestCaseRunOption(dic);

            _gLib._Enabled("Recalculate", pTestCaseLibrary.wTestCaseViewer.wRecalculate, Config.iTimeout * 3, true);
            _gLib._Exists("Recalculate", pTestCaseLibrary.wTestCaseViewer.wViewTestCaseInExcel.txt.link, Config.iTimeout, true);

            mTime.StopTimer(i0PercentRunForFSGCashflow_TestCase_SC590570A_Run);
            mLog.LogInfo(i0PercentRunForFSGCashflow_TestCase_SC590570A_Run, MyPerformanceCounter.Memory_Private);




            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewTestCaseInExcel", "Click");
            dic.Add("Close", "");
            pTestCaseLibrary._PopVerify_TestCaseViewer(dic);

            _gLib._Exists("Excel", pOutputManager.wExcel, Config.iTimeout * 3, true);


            mTime.StopTimer(i0PercentRunForFSGCashflow_TestCase_SC590570A_View);
            mLog.LogInfo(i0PercentRunForFSGCashflow_TestCase_SC590570A_View, MyPerformanceCounter.Memory_Private);


            _gLib._KillProcessByName("EXCEL");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewTestCaseInExcel", "");
            dic.Add("Close", "Click");
            pTestCaseLibrary._PopVerify_TestCaseViewer(dic);


            pMain._SelectTab("Test Case Library");

            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Test Case Library");
            mTime.StopTimer(i0PercentRunForFSGCashflow_TestCase_Save);
            mLog.LogInfo(i0PercentRunForFSGCashflow_TestCase_Save, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "170");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Object", "Main.RunOption");
            dic.Add("optiTimeout", "");
            pMain._ObjectExist(dic);

            mTime.StopTimer(i0PercentRunForFSGCashflow_RunOption_Launch);
            mLog.LogInfo(i0PercentRunForFSGCashflow_RunOption_Launch, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "False");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("Pay", "FTE80thsPayProj");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("Major", "");
            dic.Add("Intermediate", "Gender");
            dic.Add("Minor", "");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "True");
            dic.Add("AltFunding1", "False");
            dic.Add("AltFunding2", "False");
            dic.Add("AltFunding3", "False");
            dic.Add("Solvency", "False");
            dic.Add("PPFS179", "False");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "All Benefit Sets");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectRecords", "");
            dic.Add("Validate", "");
            dic.Add("RunValuation", "");
            pMain._PopVerify_RunOptions(dic);

            mTime.StopTimer(i0PercentRunForFSGCashflow_RunOption_Edit);
            mLog.LogInfo(i0PercentRunForFSGCashflow_RunOption_Edit, MyPerformanceCounter.Memory_Private);



            //mTime.StartTimer();
            //mLog.LogInfo(i0PercentRunForFSGCashflow_ER_ClickRun, DateTime.Now.ToString());
            DateTime _t0PercentRunForFSGCashflow_ClickRun = DateTime.Now;
            mTime.StartTimer();
            mLog.LogInfo(i0PercentRunForFSGCashflow_ER_ClickRun, _t0PercentRunForFSGCashflow_ClickRun.ToString());


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            mTime.StopTimer(i0PercentRunForFSGCashflow_RunSubmission);
            mLog.LogInfo(i0PercentRunForFSGCashflow_RunSubmission, MyPerformanceCounter.Memory_Private);




            #endregion
            

            #region 2.5 % run for FSG cashflows

            pMain._SelectTab("Valuation2012");


            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "170");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Add Valuation Node");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "25 Pst run for FSG cashflows");
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


            pMain._SelectTab("Valuation2012");

            mTime.StopTimer(i25PercentRunForFSGCashflow_AddNode);
            mLog.LogInfo(i25PercentRunForFSGCashflow_AddNode, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Valuation2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "170");
            dic.Add("iPosY", "380");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "RPIInflationAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2.5");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "Pst88GMPinPaymentAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2.5");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CappedPst10InflationAssumption");
            dic.Add("Level_4", "EDTmembers");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2.5");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CappedPst10InflationAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2.5");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            pMain._SelectTab("Assumptions");

            mTime.StopTimer(i25PercentRunForFSGCashflow_CustomRates_Edit);
            mLog.LogInfo(i25PercentRunForFSGCashflow_CustomRates_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SalCapInc_P", "Click");
            dic.Add("S148Inc_P", "Click");
            dic.Add("LimmGMPRate_P", "Click");
            dic.Add("SalCapInc_txt", "");
            dic.Add("S148Inc_txt", "3.5");
            dic.Add("LimmGMPRate_txt", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_UK(dic);

            pMain._SelectTab("Assumptions");
            mTime.StopTimer(i25PercentRunForFSGCashflow_OtherEconomicAssumptions_Edit);
            mLog.LogInfo(i25PercentRunForFSGCashflow_OtherEconomicAssumptions_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Assumptions");
            mTime.StopTimer(i25PercentRunForFSGCashflow_Assumption_Save);
            mLog.LogInfo(i25PercentRunForFSGCashflow_Assumption_Save, MyPerformanceCounter.Memory_Private);



            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "170");
            dic.Add("iPosY", "380");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Object", "Main.RunOption");
            dic.Add("optiTimeout", "");
            pMain._ObjectExist(dic);

            mTime.StopTimer(i25PercentRunForFSGCashflow_RunOption_Launch);
            mLog.LogInfo(i25PercentRunForFSGCashflow_RunOption_Launch, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "False");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("Pay", "FTE80thsPayProj");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("Major", "");
            dic.Add("Intermediate", "Gender");
            dic.Add("Minor", "");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "True");
            dic.Add("AltFunding1", "False");
            dic.Add("AltFunding2", "False");
            dic.Add("AltFunding3", "False");
            dic.Add("Solvency", "False");
            dic.Add("PPFS179", "False");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "All Benefit Sets");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectRecords", "");
            dic.Add("Validate", "");
            dic.Add("RunValuation", "");
            pMain._PopVerify_RunOptions(dic);

            mTime.StopTimer(i25PercentRunForFSGCashflow_RunOption_Edit);
            mLog.LogInfo(i25PercentRunForFSGCashflow_RunOption_Edit, MyPerformanceCounter.Memory_Private);



            //mTime.StartTimer();
            //mLog.LogInfo(i25PercentRunForFSGCashflow_ER_ClickRun, DateTime.Now.ToString());
            DateTime _t25PercentRunForFSGCashflow_ClickRun = DateTime.Now;
            mTime.StartTimer();
            mLog.LogInfo(i25PercentRunForFSGCashflow_ER_ClickRun, _t25PercentRunForFSGCashflow_ClickRun.ToString());

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            mTime.StopTimer(i25PercentRunForFSGCashflow_RunSubmission);
            mLog.LogInfo(i25PercentRunForFSGCashflow_RunSubmission, MyPerformanceCounter.Memory_Private);



            #endregion


            #region CMI 1.5%, new ret, 0.25% infl


            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "175");
            dic.Add("iPosY", "265");
            dic.Add("MenuItem_1", "Add Valuation Node");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "CMI 1.5, new ret, 0.25 pst infl");
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


            pMain._SelectTab("Valuation2012");

            mTime.StopTimer(iCMI15NewRet025Infl_AddNode);
            mLog.LogInfo(iCMI15NewRet025Infl_AddNode, MyPerformanceCounter.Memory_Private);

            pMain._SelectTab("Valuation2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "280");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");



            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "RPIInflationAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CappedPst10InflationAssumption");
            dic.Add("Level_4", "EDTmembers");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CappedPst10InflationAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2.25");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iCMI15NewRet025Infl_CustomRates_Edit);
            mLog.LogInfo(iCMI15NewRet025Infl_CustomRates_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Assumptions");
            mTime.StopTimer(iCMI15NewRet025Infl_Assumption_Save);
            mLog.LogInfo(iCMI15NewRet025Infl_Assumption_Save, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "280");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Object", "Main.RunOption");
            dic.Add("optiTimeout", "");
            pMain._ObjectExist(dic);

            mTime.StopTimer(iCMI15NewRet025Infl_RunOption_Launch);
            mLog.LogInfo(iCMI15NewRet025Infl_RunOption_Launch, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "False");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("Pay", "FTE80thsPayProj");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("Major", "");
            dic.Add("Intermediate", "Gender");
            dic.Add("Minor", "");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "True");
            dic.Add("AltFunding1", "False");
            dic.Add("AltFunding2", "False");
            dic.Add("AltFunding3", "False");
            dic.Add("Solvency", "False");
            dic.Add("PPFS179", "False");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "All Benefit Sets");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectRecords", "");
            dic.Add("Validate", "");
            dic.Add("RunValuation", "");
            pMain._PopVerify_RunOptions(dic);

            mTime.StopTimer(iCMI15NewRet025Infl_RunOption_Edit);
            mLog.LogInfo(iCMI15NewRet025Infl_RunOption_Edit, MyPerformanceCounter.Memory_Private);

            
            //mTime.StartTimer();
            //mLog.LogInfo(iCMI15NewRet025Infl_ER_ClickRun, DateTime.Now.ToString());
            DateTime _tCMI15NewRet025Infl_ClickRun = DateTime.Now;
            mTime.StartTimer();
            mLog.LogInfo(iCMI15NewRet025Infl_ER_ClickRun, _tCMI15NewRet025Infl_ClickRun.ToString());

            

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            mTime.StopTimer(iCMI15NewRet025Infl_RunSubmission);
            mLog.LogInfo(iCMI15NewRet025Infl_RunSubmission, MyPerformanceCounter.Memory_Private);





            #endregion


            #region 1% pst ret AoA


            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "200");
            dic.Add("iPosY", "265");
            dic.Add("MenuItem_1", "Add Valuation Node");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "1 Pst ret AoA");
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


            pMain._SelectTab("Valuation2012");

            mTime.StopTimer(i1PstRetAoA_AddNode);
            mLog.LogInfo(i1PstRetAoA_AddNode, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Valuation2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "400");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Funding");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDecrementRate", "");
            dic.Add("PreCommencementRate", "5.9");
            dic.Add("PostCommencementRate", "4.4");
            pInterestRate._PopVerify_PreDecrementPrePostCommencement(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AltFund1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDecrementRate", "");
            dic.Add("PreCommencementRate", "6.0");
            dic.Add("PostCommencementRate", "4.4");
            pInterestRate._PopVerify_PreDecrementPrePostCommencement(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AltFund2");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDecrementRate", "");
            dic.Add("PreCommencementRate", "6.1");
            dic.Add("PostCommencementRate", "4.4");
            pInterestRate._PopVerify_PreDecrementPrePostCommencement(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AltFund3");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDecrementRate", "");
            dic.Add("PreCommencementRate", "6.3");
            dic.Add("PostCommencementRate", "4.4");
            pInterestRate._PopVerify_PreDecrementPrePostCommencement(dic);

            pMain._SelectTab("Assumptions");
            mTime.StopTimer(i1PstRetAoA_InterestRates_Edit);
            mLog.LogInfo(i1PstRetAoA_InterestRates_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Assumptions");
            mTime.StopTimer(i1PstRetAoA_Assumption_Save);
            mLog.LogInfo(i1PstRetAoA_Assumption_Save, MyPerformanceCounter.Memory_Private);



            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "400");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Object", "Main.RunOption");
            dic.Add("optiTimeout", "");
            pMain._ObjectExist(dic);

            mTime.StopTimer(i1PstRetAoA_RunOption_Launch);
            mLog.LogInfo(i1PstRetAoA_RunOption_Launch, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "False");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("Pay", "FTE80thsPayProj");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("Major", "");
            dic.Add("Intermediate", "Gender");
            dic.Add("Minor", "");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "True");
            dic.Add("AltFunding1", "False");
            dic.Add("AltFunding2", "False");
            dic.Add("AltFunding3", "False");
            dic.Add("Solvency", "False");
            dic.Add("PPFS179", "False");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "All Benefit Sets");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectRecords", "");
            dic.Add("Validate", "");
            dic.Add("RunValuation", "");
            pMain._PopVerify_RunOptions(dic);

            mTime.StopTimer(i1PstRetAoA_RunOption_Edit);
            mLog.LogInfo(i1PstRetAoA_RunOption_Edit, MyPerformanceCounter.Memory_Private);



            //mTime.StartTimer();
            //mLog.LogInfo(i1PstRetAoA_ER_ClickRun, DateTime.Now.ToString());
            DateTime _t1PstRetAoA_ClickRun = DateTime.Now;
            mTime.StartTimer();
            mLog.LogInfo(i1PstRetAoA_ER_ClickRun, _t1PstRetAoA_ClickRun.ToString());



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            mTime.StopTimer(i1PstRetAoA_RunSubmission);
            mLog.LogInfo(i1PstRetAoA_RunSubmission, MyPerformanceCounter.Memory_Private);




            #endregion


            #region PPF & Solvency




            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "250");
            dic.Add("iPosY", "260");
            dic.Add("MenuItem_1", "Add Valuation Node");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "PPF and Solvency");
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


            pMain._SelectTab("Valuation2012");

            mTime.StopTimer(iPPFAndSolvency_AddNode);
            mLog.LogInfo(iPPFAndSolvency_AddNode, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Valuation2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "470");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");



            mTime.StartTimer();


            pAssumptions._SelectTab("Solvency");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3.4");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDecrementRate", "");
            dic.Add("PreCommencementRate", "3.7");
            dic.Add("PostCommencementRate", "3.6");
            pInterestRate._PopVerify_PreDecrementPrePostCommencement(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "True");
            dic.Add("txtLocalEligibility", "ActDef");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.USC=\"Act\" or $emp.USC=\"Def\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            mTime.StopTimer(iPPFAndSolvency_InterestRates_Edit);
            mLog.LogInfo(iPPFAndSolvency_InterestRates_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "RPIInflationAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3.8");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "RPIInflationAssumption");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "");


            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "4.7");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "True");
            dic.Add("txtLocalEligibility", "ActDef");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.USC=\"Act\" or $emp.USC=\"Def\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "Pst88GMPinPaymentAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2.5");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "Pst88GMPinPaymentAssumption");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "");



            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2.8");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "True");
            dic.Add("txtLocalEligibility", "ActDef");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.USC=\"Act\" or $emp.USC=\"Def\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CappedPst10InflationAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2.4");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "DefermentIncreasesPre10");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "DefermentIncreasesPre10");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3.4");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "DefermentIncreasesPst10");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "DefermentIncreasesPst10");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2.5");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            mTime.StopTimer(iPPFAndSolvency_CustomRates_Edit);
            mLog.LogInfo(iPPFAndSolvency_CustomRates_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryInflationAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3.4");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            pMain._SelectTab("Assumptions");
            mTime.StopTimer(iPPFAndSolvency_PayIncrease_Edit);
            mLog.LogInfo(iPPFAndSolvency_PayIncrease_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Inflation");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CPIRate_V", "Click");
            dic.Add("CPIRate_P", "");
            dic.Add("CPIRate_T", "");
            dic.Add("CPIRate_cbo_V", "RPIInflationAssumption");
            dic.Add("CPIRate_txt", "");
            dic.Add("CPIRate_cbo_T", "");
            dic.Add("RPIRate_V", "Click");
            dic.Add("RPIRate_P", "");
            dic.Add("RPIRate_T", "");
            dic.Add("RPIRate_cbo_V", "RPIInflationAssumption");
            dic.Add("RPIRate_txt", "");
            dic.Add("RPIRate_cbo_T", "");
            pInflation._PopVerify_SameStructureForAll(dic);


            pMain._SelectTab("Assumptions");
            mTime.StopTimer(iPPFAndSolvency_Infalation_Edit);
            mLog.LogInfo(iPPFAndSolvency_Infalation_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("SalCapInc_P", "Click");
            dic.Add("S148Inc_P", "Click");
            dic.Add("LimmGMPRate_P", "Click");
            dic.Add("SalCapInc_txt", "");
            dic.Add("S148Inc_txt", "3.4");
            dic.Add("LimmGMPRate_txt", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_UK(dic);

            pMain._SelectTab("Assumptions");
            mTime.StopTimer(iPPFAndSolvency_OtherEconomicAssumptions_Edit);
            mLog.LogInfo(iPPFAndSolvency_OtherEconomicAssumptions_Edit, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("DisabledVsHealthy", "");
            dic.Add("MemberVsSpouse", "");
            pMortalityDecrement._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "NSC0915");
            dic.Add("Mortality_Setback_M", "-1");
            dic.Add("Mortality_Setback_F", "");
            dic.Add("Disabled", "");
            dic.Add("Disabled_Setback_M", "");
            dic.Add("Disabled_Setback_F", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("DisabledVsHealthy", "");
            dic.Add("MemberVsSpouse", "");
            pMortalityDecrement._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "NSC0915");
            dic.Add("Mortality_Setback_M", "-2");
            dic.Add("Mortality_Setback_F", "-1");
            dic.Add("Disabled", "");
            dic.Add("Disabled_Setback_M", "");
            dic.Add("Disabled_Setback_F", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "True");
            dic.Add("txtLocalEligibility", "Females60ths");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"F\" and $emp.BenefitSetShortName = \"B_60ths_Structure\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);




            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("DisabledVsHealthy", "");
            dic.Add("MemberVsSpouse", "");
            pMortalityDecrement._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "NSC0920");
            dic.Add("Mortality_Setback_M", "-1");
            dic.Add("Mortality_Setback_F", "");
            dic.Add("Disabled", "");
            dic.Add("Disabled_Setback_M", "");
            dic.Add("Disabled_Setback_F", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "True");
            dic.Add("txtLocalEligibility", "Males80ths");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"M\" and $emp.BenefitSetShortName = \"A_80ths_Structure\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("DisabledVsHealthy", "");
            dic.Add("MemberVsSpouse", "");
            pMortalityDecrement._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "NSC0920");
            dic.Add("Mortality_Setback_M", "-2");
            dic.Add("Mortality_Setback_F", "-1");
            dic.Add("Disabled", "");
            dic.Add("Disabled_Setback_M", "");
            dic.Add("Disabled_Setback_F", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "True");
            dic.Add("txtLocalEligibility", "Males60ths");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"M\" and $emp.BenefitSetShortName = \"B_60ths_Structure\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            pMain._SelectTab("Assumptions");
            mTime.StopTimer(iPPFAndSolvency_MortalityDecrement_Edit);
            mLog.LogInfo(iPPFAndSolvency_MortalityDecrement_Edit, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Assumptions");
            mTime.StopTimer(iPPFAndSolvency_Assumption_Save);
            mLog.LogInfo(iPPFAndSolvency_Assumption_Save, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Valuation2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "470");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Provisions");



            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "GMP Adjustment Factors");
            dic.Add("Level_4", "GMPrevaluation");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Act_FromValuation_S148Increases", "");
            dic.Add("Act_FromValuation_FixedRateAt", "");
            dic.Add("Act_FromValuation_FixedRateAt_V", "Click");
            dic.Add("Act_FromValuation_FixedRateAt_D", "");
            dic.Add("Act_FromValuation_PensionIncrease", "");
            dic.Add("Act_FromValuation_FixedRateAt_V_cbo", "");
            dic.Add("Act_FromValuation_FixedRateAt_D_txt", "");
            dic.Add("Act_FromDate_S148Increases", "");
            dic.Add("Act_FromDate_FixedRateAt", "");
            dic.Add("Act_FromDate_FixedRateAt_V", "");
            dic.Add("Act_FromDate_FixedRateAt_D", "Click");
            dic.Add("Act_FromDate_PensionIncrease", "");
            dic.Add("Act_FromDate_FixedRateAt_V_cbo", "");
            dic.Add("Act_FromDate_FixedRateAt_D_txt", "06/04/1978");
            dic.Add("Inact_S148Increases", "");
            dic.Add("Inact_FixedRateAtDateOfLeaving", "");
            dic.Add("Inact_FixedRateAt", "");
            dic.Add("Inact_FixedDateAt_V", "");
            dic.Add("Inact_FixedDateAt_D", "");
            dic.Add("Inact_LimitedRate", "");
            dic.Add("Inact_PensionIncrease", "");
            dic.Add("Inact_FixedDateAt_V_cbo", "");
            dic.Add("Inact_FixedDateAt_D_txt", "");
            dic.Add("Increase_Pre88GMP_V", "");
            dic.Add("Increase_Pre88GMP_P", "");
            dic.Add("Increase_Pre88GMP_T", "");
            dic.Add("Increase_Post88GMP_V", "");
            dic.Add("Increase_Post88GMP_P", "");
            dic.Add("Increase_Post88GMP_T", "");
            dic.Add("Increase_Pre88GMPPension", "");
            dic.Add("Increase_Post88GMPPension", "");
            dic.Add("Increase_Pre88GMP_V_cbo", "");
            dic.Add("Increase_Pre88GMP_P_txt", "");
            dic.Add("Increase_Pre88GMP_T_cbo", "");
            dic.Add("Increase_Post88GMP_V_cbo", "");
            dic.Add("Increase_Post88GMP_P_txt", "");
            dic.Add("Increase_Post88GMP_T_cbo", "");
            pGMPAdjustmentFactors._PopVerify_GMPAdjustmentFactors(dic);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(iPPFAndSolvency_GMPAdjustmentFactor80_Edit);
            mLog.LogInfo(iPPFAndSolvency_GMPAdjustmentFactor80_Edit, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "B_60ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "GMP Adjustment Factors");
            dic.Add("Level_4", "GMPrevaluation");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Act_FromValuation_S148Increases", "");
            dic.Add("Act_FromValuation_FixedRateAt", "");
            dic.Add("Act_FromValuation_FixedRateAt_V", "Click");
            dic.Add("Act_FromValuation_FixedRateAt_D", "");
            dic.Add("Act_FromValuation_PensionIncrease", "");
            dic.Add("Act_FromValuation_FixedRateAt_V_cbo", "");
            dic.Add("Act_FromValuation_FixedRateAt_D_txt", "");
            dic.Add("Act_FromDate_S148Increases", "");
            dic.Add("Act_FromDate_FixedRateAt", "");
            dic.Add("Act_FromDate_FixedRateAt_V", "");
            dic.Add("Act_FromDate_FixedRateAt_D", "Click");
            dic.Add("Act_FromDate_PensionIncrease", "");
            dic.Add("Act_FromDate_FixedRateAt_V_cbo", "");
            dic.Add("Act_FromDate_FixedRateAt_D_txt", "06/04/1978");
            dic.Add("Inact_S148Increases", "");
            dic.Add("Inact_FixedRateAtDateOfLeaving", "");
            dic.Add("Inact_FixedRateAt", "");
            dic.Add("Inact_FixedDateAt_V", "");
            dic.Add("Inact_FixedDateAt_D", "");
            dic.Add("Inact_LimitedRate", "");
            dic.Add("Inact_PensionIncrease", "");
            dic.Add("Inact_FixedDateAt_V_cbo", "");
            dic.Add("Inact_FixedDateAt_D_txt", "");
            dic.Add("Increase_Pre88GMP_V", "");
            dic.Add("Increase_Pre88GMP_P", "");
            dic.Add("Increase_Pre88GMP_T", "");
            dic.Add("Increase_Post88GMP_V", "");
            dic.Add("Increase_Post88GMP_P", "");
            dic.Add("Increase_Post88GMP_T", "");
            dic.Add("Increase_Pre88GMPPension", "");
            dic.Add("Increase_Post88GMPPension", "");
            dic.Add("Increase_Pre88GMP_V_cbo", "");
            dic.Add("Increase_Pre88GMP_P_txt", "");
            dic.Add("Increase_Pre88GMP_T_cbo", "");
            dic.Add("Increase_Post88GMP_V_cbo", "");
            dic.Add("Increase_Post88GMP_P_txt", "");
            dic.Add("Increase_Post88GMP_T_cbo", "");
            pGMPAdjustmentFactors._PopVerify_GMPAdjustmentFactors(dic);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(iPPFAndSolvency_GMPAdjustmentFactor60_Edit);
            mLog.LogInfo(iPPFAndSolvency_GMPAdjustmentFactor60_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(iPPFAndSolvency_Provision_Save);
            mLog.LogInfo(iPPFAndSolvency_Provision_Save, MyPerformanceCounter.Memory_Private);



            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "470");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Object", "Main.RunOption");
            dic.Add("optiTimeout", "");
            pMain._ObjectExist(dic);

            mTime.StopTimer(iPPFAndSolvency_RunOption_Launch);
            mLog.LogInfo(iPPFAndSolvency_RunOption_Launch, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "False");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("Pay", "FTE60thsPayProj");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("Major", "");
            dic.Add("Intermediate", "#1#");
            dic.Add("Minor", "");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "True");
            dic.Add("AltFunding1", "False");
            dic.Add("AltFunding2", "False");
            dic.Add("AltFunding3", "False");
            dic.Add("Solvency", "True");
            dic.Add("PPFS179", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "All Benefit Sets");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectRecords", "");
            dic.Add("Validate", "");
            dic.Add("RunValuation", "");
            pMain._PopVerify_RunOptions(dic);

            mTime.StopTimer(iPPFAndSolvency_RunOption_Edit);
            mLog.LogInfo(iPPFAndSolvency_RunOption_Edit, MyPerformanceCounter.Memory_Private);



            //mTime.StartTimer();
            //mLog.LogInfo(iPPFAndSolvency_ER_ClickRun, DateTime.Now.ToString());
            DateTime _tPPFAndSolvency_ClickRun = DateTime.Now;
            mTime.StartTimer();
            mLog.LogInfo(iPPFAndSolvency_ER_ClickRun, _tPPFAndSolvency_ClickRun.ToString());



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            mTime.StopTimer(iPPFAndSolvency_RunSubmission);
            mLog.LogInfo(iPPFAndSolvency_RunSubmission, MyPerformanceCounter.Memory_Private);



            #endregion






            #region ER & Reports - 0 % Run for FSG Cashflow



            _gLib._CreateDirectory(sOutputDir, false);
            sERDetail = "";


            pMain._SelectTab("Valuation2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", dicPosition["0PstRunForFSGCashflows_X"]);
            dic.Add("iPosY", dicPosition["0PstRunForFSGCashflows_Y"]);
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            string s0PercentRunForFSGCashflow_Persist_80 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5);
            string s0PercentRunForFSGCashflow_Post_80 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5);
            string s0PercentRunForFSGCashflow_Persist_60 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5);
            string s0PercentRunForFSGCashflow_Post_60 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5);

            DateTime _t0PercentRunForFSGCashflow_Persist_80 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(s0PercentRunForFSGCashflow_Persist_80, Config.eCountry));
            DateTime _t0PercentRunForFSGCashflow_Post_80 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(s0PercentRunForFSGCashflow_Post_80, Config.eCountry));
            DateTime _t0PercentRunForFSGCashflow_Persist_60 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(s0PercentRunForFSGCashflow_Persist_60, Config.eCountry));
            DateTime _t0PercentRunForFSGCashflow_Post_60 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(s0PercentRunForFSGCashflow_Post_60, Config.eCountry));



            string _s0PercentRunForFSGCashflow_EarliestProcess = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5);
            string _s0PercentRunForFSGCashflow_80JobSuccess = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12);
            string _s0PercentRunForFSGCashflow_60JobSuccess = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 12);
            string _s0PercentRunForFSGCashflow_GroupJobSuccess = pMain._ER_ReturnRunStatus_TopGrid(11);
            DateTime _t0PercentRunForFSGCashflow_EarliestProcess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_s0PercentRunForFSGCashflow_EarliestProcess, Config.eCountry));
            DateTime _t0PercentRunForFSGCashflow_80JobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_s0PercentRunForFSGCashflow_80JobSuccess, Config.eCountry));
            DateTime _t0PercentRunForFSGCashflow_60JobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_s0PercentRunForFSGCashflow_60JobSuccess, Config.eCountry));
            DateTime _t0PercentRunForFSGCashflow_GroupJobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_s0PercentRunForFSGCashflow_GroupJobSuccess, Config.eCountry));


            mLog.LogInfo(i0PercentRunForFSGCashflow_GroupID, pMain._ER_ReturnRunStatus_TopGrid(2));
            //mLog.LogInfo(i0PercentRunForFSGCashflow_Persist_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            //mLog.LogInfo(i0PercentRunForFSGCashflow_Post_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));
            mLog.LogInfo(i0PercentRunForFSGCashflow_Persist_80, s0PercentRunForFSGCashflow_Persist_80);
            mLog.LogInfo(i0PercentRunForFSGCashflow_Post_80, s0PercentRunForFSGCashflow_Post_80);

            //mLog.LogInfo(i0PercentRunForFSGCashflow_Persist_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5));
            //mLog.LogInfo(i0PercentRunForFSGCashflow_Post_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5));
            mLog.LogInfo(i0PercentRunForFSGCashflow_Persist_60, s0PercentRunForFSGCashflow_Persist_60);
            mLog.LogInfo(i0PercentRunForFSGCashflow_Post_60, s0PercentRunForFSGCashflow_Post_60);


            //sERDetail = sERDetail + "Earliest Process: " + pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5) + Environment.NewLine;
            //sERDetail = sERDetail + "A_80 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12) + Environment.NewLine;
            //sERDetail = sERDetail + "B_60 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 12) + Environment.NewLine;
            //sERDetail = sERDetail + "Group Job Success: " + pMain._ER_ReturnRunStatus_TopGrid(11) + Environment.NewLine;
            sERDetail = sERDetail + "Earliest Process: " + _s0PercentRunForFSGCashflow_EarliestProcess + Environment.NewLine;
            sERDetail = sERDetail + "A_80 Job Success: " + _s0PercentRunForFSGCashflow_80JobSuccess + Environment.NewLine;
            sERDetail = sERDetail + "B_60 Job Success: " + _s0PercentRunForFSGCashflow_60JobSuccess + Environment.NewLine;
            sERDetail = sERDetail + "Group Job Success: " + _s0PercentRunForFSGCashflow_GroupJobSuccess + Environment.NewLine;
            mLog.LogInfo(i0PercentRunForFSGCashflow_ER_Detail, sERDetail);

            sERDetail = "";
            sERDetail = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3) + ": " + Environment.NewLine;
            sERDetail = sERDetail + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 3) + ": " + Environment.NewLine;
            mLog.LogInfo(i0PercentRunForFSGCashflow_NumOfCores, sERDetail);


            mLog.LogInfo(iJobID_0PercentRunForFSGCashflow_1, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));
            mLog.LogInfo(iJobID_0PercentRunForFSGCashflow_2, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 3));


            TimeSpan _t0Persist_80 = _t0PercentRunForFSGCashflow_Post_80 - _t0PercentRunForFSGCashflow_Persist_80;
            TimeSpan _t0Post_80 = _t0PercentRunForFSGCashflow_80JobSuccess - _t0PercentRunForFSGCashflow_Post_80;
            TimeSpan _t0Persist_60 = _t0PercentRunForFSGCashflow_Post_60 - _t0PercentRunForFSGCashflow_Persist_60;
            TimeSpan _t0Post_60 = _t0PercentRunForFSGCashflow_60JobSuccess - _t0PercentRunForFSGCashflow_Post_60;

            TimeSpan _t0JobSent_Persist = _t0PercentRunForFSGCashflow_Persist_80 - _t0PercentRunForFSGCashflow_EarliestProcess;

            _sER_ReturnRunStatus_ClickRun = null;
            _excelLog.OpenExcelFile("Sheet1");
            _sER_ReturnRunStatus_ClickRun = _excelLog.getOneCellValue(i0PercentRunForFSGCashflow_ER_ClickRun, iCol_Memory);
            _excelLog.CloseExcelApplication();
            _t0PercentRunForFSGCashflow_ClickRun = Convert.ToDateTime(_sER_ReturnRunStatus_ClickRun);

            TimeSpan _t0ClickRun_GroupJobStatus = _t0PercentRunForFSGCashflow_GroupJobSuccess - _t0PercentRunForFSGCashflow_ClickRun;
            int _t0Overall = 1 + (_t0ClickRun_GroupJobStatus.Hours * 3600 + _t0ClickRun_GroupJobStatus.Minutes * 60 + _t0ClickRun_GroupJobStatus.Seconds) - (_t0JobSent_Persist.Hours * 3600 + _t0JobSent_Persist.Minutes * 60 + _t0JobSent_Persist.Seconds);

            mLogTime.LogInfo(i0PercentRunForFSGCashflow_Persist_80, Convert.ToString(_t0Persist_80.Hours * 3600 + _t0Persist_80.Minutes * 60 + _t0Persist_80.Seconds));
            mLogTime.LogInfo(i0PercentRunForFSGCashflow_Post_80, Convert.ToString(_t0Post_80.Hours * 3600 + _t0Post_80.Minutes * 60 + _t0Post_80.Seconds));
            mLogTime.LogInfo(i0PercentRunForFSGCashflow_Persist_60, Convert.ToString(_t0Persist_60.Hours * 3600 + _t0Persist_60.Minutes * 60 + _t0Persist_60.Seconds));
            mLogTime.LogInfo(i0PercentRunForFSGCashflow_Post_60, Convert.ToString(_t0Post_60.Hours * 3600 + _t0Post_60.Minutes * 60 + _t0Post_60.Seconds));

            mLogTime.LogInfo(i0PercentRunForFSGCashflow_ER_ClickRun, Convert.ToString(_t0Overall));



            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", dicPosition["0PstRunForFSGCashflows_X"]);
            dic.Add("iPosY", dicPosition["0PstRunForFSGCashflows_Y"]);
            dic.Add("MenuItem_1", "View Output");
            dic.Add("CheckOMSetupPopup", "False");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");

            mTime.StopTimer(i0PercentRunForFSGCashflow_OpenOM);
            mLog.LogInfo(i0PercentRunForFSGCashflow_OpenOM, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Output Manager");
            mTime.StartTimer();

            pOutputManager._Navigate(Config.eCountry, "Liabilities Detailed Results", "RollForward", true);
            pOutputManager._WaitForLoading();
            pOutputManager._SelectTab("Liabilities Detailed Results");

            mTime.StopTimer(i0PercentRunForFSGCashflow_DetailResult_Load);
            mLog.LogInfo(i0PercentRunForFSGCashflow_DetailResult_Load, MyPerformanceCounter.Memory_Private);

            pMain._SelectTab("Output Manager");
            pOutputManager._Navigate(Config.eCountry, "Payout Projection - Benefit Cashflows", "RollForward", true);
            pOutputManager._SelectTab("Benefit Cashflows");
            _gLib._SetSyncUDWin_ByClipboard("NumberOfYears", pOutputManager.wRetirementStudio.wBenefitCashFlow_NumberOfYears.txt, "99", 0);
            _gLib._SetSyncUDWin("GroupbyStatusCodes", pOutputManager.wRetirementStudio.wGroup_GroupbyStatusCodes.rdGrroupbyStatusCodes, "True", 0);
            _gLib._SetSyncUDWin("SplitbyBenefitTypeTranche", pOutputManager.wRetirementStudio.wBenefitCashFlow_SplitbyBenefitTypeTranche.chk, "True", 0);


            mTime.StartTimer();
            _gLib._SetSyncUDWin("SplitbyBenefitTypeTranche", pOutputManager.wRetirementStudio.wProcess.btnProcess, "Click", 0);
            _gLib._SetSyncUDWin("Cancel", pOutputManager.wSaveAs.wCancel.btnCancel, "Click", Config.iTimeout * 3);
            pOutputManager._SelectTab("Benefit Cashflows");

            mTime.StopTimer(i0PercentRunForFSGCashflow_PayoutProject_Load);
            mLog.LogInfo(i0PercentRunForFSGCashflow_PayoutProject_Load, MyPerformanceCounter.Memory_Private);



            if (bExportIOE)
            {
                pMain._SelectTab("Output Manager");
                pOutputManager._Navigate(Config.eCountry, "IOE", "RollForward", true);
                pOutputManager._SelectTab("Individual Output");
                _gLib._SetSyncUDWin("Group - None", pOutputManager.wRetirementStudio.wGroup_None.rdNone, "True", 0);
                _gLib._SetSyncUDWin("Process", pOutputManager.wRetirementStudio.wProcess.btnProcess, "Click", 0);

                dic.Clear();
                dic.Add("Level_1", "Individual Output");
                _gLib._TreeViewSelectWin(0, pOutputManager.wRetirementStudio.tvNaviTree, dic);

                dic.Clear();
                dic.Add("Level_1", "Individual Output");
                dic.Add("MenuItem", "Add IOE Parameters");
                _gLib._TreeViewRightSelectWin(0, pOutputManager.wRetirementStudio.tvNaviTree.tviIndividualOutput, dic, false);

                mTime.StartTimer();

                _gLib._SetSyncUDWin("Export", pOutputManager.wRetirementStudio.wExport.btnExport, "Click", 0);
                pOutputManager._SaveAs(sOutputDir + "IOE.xls");
                _gLib._SetSyncUDWin("OK", pOutputManager.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);

                pOutputManager._SelectTab("Individual Output");
                mTime.StopTimer(i0PercentRunForFSGCashflow_ExportIOE);
                mLog.LogInfo(i0PercentRunForFSGCashflow_ExportIOE, MyPerformanceCounter.Memory_Private);
            }

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);
            #endregion

            
            #region ER & Reports - 2.5 % run for FSG cashflows



            _gLib._CreateDirectory(sOutputDir, false);
            sERDetail = "";

            pMain._SelectTab("Valuation2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", dicPosition["25PstRunForFSGCashflows_X"]);
            dic.Add("iPosY", dicPosition["25PstRunForFSGCashflows_Y"]);
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            string s25PercentRunForFSGCashflow_Persist_80 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5);
            string s25PercentRunForFSGCashflow_Post_80 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5);
            string s25PercentRunForFSGCashflow_Persist_60 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5);
            string s25PercentRunForFSGCashflow_Post_60 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5);

            DateTime _t25PercentRunForFSGCashflow_Persist_80 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(s25PercentRunForFSGCashflow_Persist_80, Config.eCountry));
            DateTime _t25PercentRunForFSGCashflow_Post_80 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(s25PercentRunForFSGCashflow_Post_80, Config.eCountry));
            DateTime _t25PercentRunForFSGCashflow_Persist_60 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(s25PercentRunForFSGCashflow_Persist_60, Config.eCountry));
            DateTime _t25PercentRunForFSGCashflow_Post_60 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(s25PercentRunForFSGCashflow_Post_60, Config.eCountry));


            string _s25PercentRunForFSGCashflow_EarliestProcess = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5);
            string _s25PercentRunForFSGCashflow_80JobSuccess = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12);
            string _s25PercentRunForFSGCashflow_60JobSuccess = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 12);
            string _s25PercentRunForFSGCashflow_GroupJobSuccess = pMain._ER_ReturnRunStatus_TopGrid(11);
            DateTime _t25PercentRunForFSGCashflow_EarliestProcess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_s25PercentRunForFSGCashflow_EarliestProcess, Config.eCountry));
            DateTime _t25PercentRunForFSGCashflow_80JobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_s25PercentRunForFSGCashflow_80JobSuccess, Config.eCountry));
            DateTime _t25PercentRunForFSGCashflow_60JobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_s25PercentRunForFSGCashflow_60JobSuccess, Config.eCountry));
            DateTime _t25PercentRunForFSGCashflow_GroupJobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_s25PercentRunForFSGCashflow_GroupJobSuccess, Config.eCountry));



            mLog.LogInfo(i25PercentRunForFSGCashflow_GroupID, pMain._ER_ReturnRunStatus_TopGrid(2));
            //mLog.LogInfo(i25PercentRunForFSGCashflow_Persist_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            //mLog.LogInfo(i25PercentRunForFSGCashflow_Post_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));
            mLog.LogInfo(i25PercentRunForFSGCashflow_Persist_80, s25PercentRunForFSGCashflow_Persist_80);
            mLog.LogInfo(i25PercentRunForFSGCashflow_Post_80, s25PercentRunForFSGCashflow_Post_80);

            //mLog.LogInfo(i25PercentRunForFSGCashflow_Persist_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5));
            //mLog.LogInfo(i25PercentRunForFSGCashflow_Post_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5));
            mLog.LogInfo(i25PercentRunForFSGCashflow_Persist_60, s25PercentRunForFSGCashflow_Persist_60);
            mLog.LogInfo(i25PercentRunForFSGCashflow_Post_60, s25PercentRunForFSGCashflow_Post_60);

            //sERDetail = sERDetail + "Earliest Process: " + pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5) + Environment.NewLine;
            //sERDetail = sERDetail + "A_80 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12) + Environment.NewLine;
            //sERDetail = sERDetail + "B_60 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 12) + Environment.NewLine;
            //sERDetail = sERDetail + "Group Job Success: " + pMain._ER_ReturnRunStatus_TopGrid(11) + Environment.NewLine;
            sERDetail = sERDetail + "Earliest Process: " + _s25PercentRunForFSGCashflow_EarliestProcess + Environment.NewLine;
            sERDetail = sERDetail + "A_80 Job Success: " + _s25PercentRunForFSGCashflow_80JobSuccess + Environment.NewLine;
            sERDetail = sERDetail + "B_60 Job Success: " + _s25PercentRunForFSGCashflow_60JobSuccess + Environment.NewLine;
            sERDetail = sERDetail + "Group Job Success: " + _s25PercentRunForFSGCashflow_GroupJobSuccess + Environment.NewLine;
            mLog.LogInfo(i25PercentRunForFSGCashflow_ER_Detail, sERDetail);

            sERDetail = "";
            sERDetail = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3) + ": " + Environment.NewLine;
            sERDetail = sERDetail + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 3) + ": " + Environment.NewLine;
            mLog.LogInfo(i25PercentRunForFSGCashflow_NumOfCores, sERDetail);


            mLog.LogInfo(iJobID_25PercentRunForFSGCashflow_1, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));
            mLog.LogInfo(iJobID_25PercentRunForFSGCashflow_2, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 3));


            TimeSpan _t25Persist_80 = _t25PercentRunForFSGCashflow_Post_80 - _t25PercentRunForFSGCashflow_Persist_80;
            TimeSpan _t25Post_80 = _t25PercentRunForFSGCashflow_80JobSuccess - _t25PercentRunForFSGCashflow_Post_80;
            TimeSpan _t25Persist_60 = _t25PercentRunForFSGCashflow_Post_60 - _t25PercentRunForFSGCashflow_Persist_60;
            TimeSpan _t25Post_60 = _t25PercentRunForFSGCashflow_60JobSuccess - _t25PercentRunForFSGCashflow_Post_60;

            TimeSpan _t25JobSent_Persist = _t25PercentRunForFSGCashflow_Persist_80 - _t25PercentRunForFSGCashflow_EarliestProcess;

            _sER_ReturnRunStatus_ClickRun = null;
            _excelLog.OpenExcelFile("Sheet1");
            _sER_ReturnRunStatus_ClickRun = _excelLog.getOneCellValue(i25PercentRunForFSGCashflow_ER_ClickRun, iCol_Memory);
            _excelLog.CloseExcelApplication();
            _t25PercentRunForFSGCashflow_ClickRun = Convert.ToDateTime(_sER_ReturnRunStatus_ClickRun);

            TimeSpan _t25ClickRun_GroupJobStatus = _t25PercentRunForFSGCashflow_GroupJobSuccess - _t25PercentRunForFSGCashflow_ClickRun;
            int _t25Overall = 1 + (_t25ClickRun_GroupJobStatus.Hours * 3600 + _t25ClickRun_GroupJobStatus.Minutes * 60 + _t25ClickRun_GroupJobStatus.Seconds) - (_t25JobSent_Persist.Hours * 3600 + _t25JobSent_Persist.Minutes * 60 + _t25JobSent_Persist.Seconds);

            mLogTime.LogInfo(i25PercentRunForFSGCashflow_Persist_80, Convert.ToString(_t25Persist_80.Hours * 3600 + _t25Persist_80.Minutes * 60 + _t25Persist_80.Seconds));
            mLogTime.LogInfo(i25PercentRunForFSGCashflow_Post_80, Convert.ToString(_t25Post_80.Hours * 3600 + _t25Post_80.Minutes * 60 + _t25Post_80.Seconds));
            mLogTime.LogInfo(i25PercentRunForFSGCashflow_Persist_60, Convert.ToString(_t25Persist_60.Hours * 3600 + _t25Persist_60.Minutes * 60 + _t25Persist_60.Seconds));
            mLogTime.LogInfo(i25PercentRunForFSGCashflow_Post_60, Convert.ToString(_t25Post_60.Hours * 3600 + _t25Post_60.Minutes * 60 + _t25Post_60.Seconds));

            mLogTime.LogInfo(i25PercentRunForFSGCashflow_ER_ClickRun, Convert.ToString(_t25Overall));



            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", dicPosition["25PstRunForFSGCashflows_X"]);
            dic.Add("iPosY", dicPosition["25PstRunForFSGCashflows_Y"]);
            dic.Add("MenuItem_1", "View Output");
            dic.Add("CheckOMSetupPopup", "False");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");

            mTime.StopTimer(i25PercentRunForFSGCashflow_OpenOM);
            mLog.LogInfo(i25PercentRunForFSGCashflow_OpenOM, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Output Manager");
            mTime.StartTimer();

            pOutputManager._Navigate(Config.eCountry, "Liabilities Detailed Results", "RollForward", true);
            pOutputManager._WaitForLoading();
            pOutputManager._SelectTab("Liabilities Detailed Results");

            mTime.StopTimer(i25PercentRunForFSGCashflow_DetailResult_Load);
            mLog.LogInfo(i25PercentRunForFSGCashflow_DetailResult_Load, MyPerformanceCounter.Memory_Private);

            pMain._SelectTab("Output Manager");
            pOutputManager._Navigate(Config.eCountry, "Payout Projection - Benefit Cashflows", "RollForward", true);
            pOutputManager._SelectTab("Benefit Cashflows");
            _gLib._SetSyncUDWin_ByClipboard("NumberOfYears", pOutputManager.wRetirementStudio.wBenefitCashFlow_NumberOfYears.txt, "99", 0);
            _gLib._SetSyncUDWin("GroupbyStatusCodes", pOutputManager.wRetirementStudio.wGroup_GroupbyStatusCodes.rdGrroupbyStatusCodes, "True", 0);
            _gLib._SetSyncUDWin("SplitbyBenefitTypeTranche", pOutputManager.wRetirementStudio.wBenefitCashFlow_SplitbyBenefitTypeTranche.chk, "True", 0);


            mTime.StartTimer();
            _gLib._SetSyncUDWin("SplitbyBenefitTypeTranche", pOutputManager.wRetirementStudio.wProcess.btnProcess, "Click", 0);
            _gLib._SetSyncUDWin("Cancel", pOutputManager.wSaveAs.wCancel.btnCancel, "Click", Config.iTimeout * 3);
            pOutputManager._SelectTab("Benefit Cashflows");

            mTime.StopTimer(i25PercentRunForFSGCashflow_PayoutProject_Load);
            mLog.LogInfo(i25PercentRunForFSGCashflow_PayoutProject_Load, MyPerformanceCounter.Memory_Private);

            if (bExportIOE)
            {
                pMain._SelectTab("Output Manager");
                pOutputManager._Navigate(Config.eCountry, "IOE", "RollForward", true);
                pOutputManager._SelectTab("Individual Output");
                _gLib._SetSyncUDWin("Group - None", pOutputManager.wRetirementStudio.wGroup_None.rdNone, "True", 0);
                _gLib._SetSyncUDWin("Process", pOutputManager.wRetirementStudio.wProcess.btnProcess, "Click", 0);

                dic.Clear();
                dic.Add("Level_1", "Individual Output");
                _gLib._TreeViewSelectWin(0, pOutputManager.wRetirementStudio.tvNaviTree, dic);

                dic.Clear();
                dic.Add("Level_1", "Individual Output");
                dic.Add("MenuItem", "Add IOE Parameters");
                _gLib._TreeViewRightSelectWin(0, pOutputManager.wRetirementStudio.tvNaviTree.tviIndividualOutput, dic, false);

                mTime.StartTimer();

                _gLib._SetSyncUDWin("Export", pOutputManager.wRetirementStudio.wExport.btnExport, "Click", 0);
                pOutputManager._SaveAs(sOutputDir + "IOE.xls");
                _gLib._SetSyncUDWin("OK", pOutputManager.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);

                pOutputManager._SelectTab("Individual Output");
                mTime.StopTimer(i25PercentRunForFSGCashflow_ExportIOE);
                mLog.LogInfo(i25PercentRunForFSGCashflow_ExportIOE, MyPerformanceCounter.Memory_Private);
            }


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region ER & Reports - CMI 1.5%, new ret, 0.25% infl



            _gLib._CreateDirectory(sOutputDir, false);
            sERDetail = "";

            pMain._SelectTab("Valuation2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", dicPosition["CMI15NewRet025Infl_X"]);
            dic.Add("iPosY", dicPosition["CMI15NewRet025Infl_Y"]);
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);



            string sCMI15NewRet025Infl_Persist_80 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5);
            string sCMI15NewRet025Infl_Post_80 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5);
            string sCMI15NewRet025Infl_Persist_60 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5);
            string sCMI15NewRet025Infl_Post_60 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5);

            DateTime _tCMI15NewRet025Infl_Persist_80 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sCMI15NewRet025Infl_Persist_80, Config.eCountry));
            DateTime _tCMI15NewRet025Infl_Post_80 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sCMI15NewRet025Infl_Post_80, Config.eCountry));
            DateTime _tCMI15NewRet025Infl_Persist_60 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sCMI15NewRet025Infl_Persist_60, Config.eCountry));
            DateTime _tCMI15NewRet025Infl_Post_60 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sCMI15NewRet025Infl_Post_60, Config.eCountry));


            string _sCMI15NewRet025Infl_EarliestProcess = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5);
            string _sCMI15NewRet025Infl_80JobSuccess = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12);
            string _sCMI15NewRet025Infl_60JobSuccess = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 12);
            string _sCMI15NewRet025Infl_GroupJobSuccess = pMain._ER_ReturnRunStatus_TopGrid(11);
            DateTime _tCMI15NewRet025Infl_EarliestProcess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sCMI15NewRet025Infl_EarliestProcess, Config.eCountry));
            DateTime _tCMI15NewRet025Infl_80JobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sCMI15NewRet025Infl_80JobSuccess, Config.eCountry));
            DateTime _tCMI15NewRet025Infl_60JobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sCMI15NewRet025Infl_60JobSuccess, Config.eCountry));
            DateTime _tCMI15NewRet025Infl_GroupJobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sCMI15NewRet025Infl_GroupJobSuccess, Config.eCountry));

            

            mLog.LogInfo(iCMI15NewRet025Infl_GroupID, pMain._ER_ReturnRunStatus_TopGrid(2));
            //mLog.LogInfo(iCMI15NewRet025Infl_Persist_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            //mLog.LogInfo(iCMI15NewRet025Infl_Post_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));
            mLog.LogInfo(iCMI15NewRet025Infl_Persist_80, sCMI15NewRet025Infl_Persist_80);
            mLog.LogInfo(iCMI15NewRet025Infl_Post_80, sCMI15NewRet025Infl_Post_80);

            //mLog.LogInfo(iCMI15NewRet025Infl_Persist_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5));
            //mLog.LogInfo(iCMI15NewRet025Infl_Post_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5));
            mLog.LogInfo(iCMI15NewRet025Infl_Persist_60, sCMI15NewRet025Infl_Persist_60);
            mLog.LogInfo(iCMI15NewRet025Infl_Post_60, sCMI15NewRet025Infl_Post_60);

            //sERDetail = sERDetail + "Earliest Process: " + pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5) + Environment.NewLine;
            //sERDetail = sERDetail + "A_80 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12) + Environment.NewLine;
            //sERDetail = sERDetail + "B_60 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 12) + Environment.NewLine;
            //sERDetail = sERDetail + "Group Job Success: " + pMain._ER_ReturnRunStatus_TopGrid(11) + Environment.NewLine;
            sERDetail = sERDetail + "Earliest Process: " + _sCMI15NewRet025Infl_EarliestProcess + Environment.NewLine;
            sERDetail = sERDetail + "A_80 Job Success: " + _sCMI15NewRet025Infl_80JobSuccess + Environment.NewLine;
            sERDetail = sERDetail + "B_60 Job Success: " + _sCMI15NewRet025Infl_60JobSuccess + Environment.NewLine;
            sERDetail = sERDetail + "Group Job Success: " + _sCMI15NewRet025Infl_GroupJobSuccess + Environment.NewLine;
            mLog.LogInfo(iCMI15NewRet025Infl_ER_Detail, sERDetail);

            sERDetail = "";
            sERDetail = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3) + ": " + Environment.NewLine;
            sERDetail = sERDetail + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 3) + ": " + Environment.NewLine;
            mLog.LogInfo(iCMI15NewRet025Infl_NumOfCores, sERDetail);


            mLog.LogInfo(iJobID_CMI15NewRet025Infl_1, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));
            mLog.LogInfo(iJobID_CMI15NewRet025Infl_2, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 3));


            TimeSpan _tCMI15Persist_80 = _tCMI15NewRet025Infl_Post_80 - _tCMI15NewRet025Infl_Persist_80;
            TimeSpan _tCMI15Post_80 = _tCMI15NewRet025Infl_80JobSuccess - _tCMI15NewRet025Infl_Post_80;
            TimeSpan _tCMI15Persist_60 = _tCMI15NewRet025Infl_Post_60 - _tCMI15NewRet025Infl_Persist_60;
            TimeSpan _tCMI15Post_60 = _tCMI15NewRet025Infl_60JobSuccess - _tCMI15NewRet025Infl_Post_60;

            TimeSpan _tCMI15JobSent_Persist = _tCMI15NewRet025Infl_Persist_80 - _tCMI15NewRet025Infl_EarliestProcess;

            _sER_ReturnRunStatus_ClickRun = null;
            _excelLog.OpenExcelFile("Sheet1");
            _sER_ReturnRunStatus_ClickRun = _excelLog.getOneCellValue(iCMI15NewRet025Infl_ER_ClickRun, iCol_Memory);
            _excelLog.CloseExcelApplication();
            _tCMI15NewRet025Infl_ClickRun = Convert.ToDateTime(_sER_ReturnRunStatus_ClickRun);

            TimeSpan _tCMI15ClickRun_GroupJobStatus = _tCMI15NewRet025Infl_GroupJobSuccess - _tCMI15NewRet025Infl_ClickRun;
            int _tCMI15Overall = 1 + (_tCMI15ClickRun_GroupJobStatus.Hours * 3600 + _tCMI15ClickRun_GroupJobStatus.Minutes * 60 + _tCMI15ClickRun_GroupJobStatus.Seconds) - (_tCMI15JobSent_Persist.Hours * 3600 + _tCMI15JobSent_Persist.Minutes * 60 + _tCMI15JobSent_Persist.Seconds);

            mLogTime.LogInfo(iCMI15NewRet025Infl_Persist_80, Convert.ToString(_tCMI15Persist_80.Hours * 3600 + _tCMI15Persist_80.Minutes * 60 + _tCMI15Persist_80.Seconds));
            mLogTime.LogInfo(iCMI15NewRet025Infl_Post_80, Convert.ToString(_tCMI15Post_80.Hours * 3600 + _tCMI15Post_80.Minutes * 60 + _tCMI15Post_80.Seconds));
            mLogTime.LogInfo(iCMI15NewRet025Infl_Persist_60, Convert.ToString(_tCMI15Persist_60.Hours * 3600 + _tCMI15Persist_60.Minutes * 60 + _tCMI15Persist_60.Seconds));
            mLogTime.LogInfo(iCMI15NewRet025Infl_Post_60, Convert.ToString(_tCMI15Post_60.Hours * 3600 + _tCMI15Post_60.Minutes * 60 + _tCMI15Post_60.Seconds));

            mLogTime.LogInfo(iCMI15NewRet025Infl_ER_ClickRun, Convert.ToString(_tCMI15Overall));


            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", dicPosition["CMI15NewRet025Infl_X"]);
            dic.Add("iPosY", dicPosition["CMI15NewRet025Infl_Y"]);
            dic.Add("MenuItem_1", "View Output");
            dic.Add("CheckOMSetupPopup", "False");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");

            mTime.StopTimer(iCMI15NewRet025Infl_OpenOM);
            mLog.LogInfo(iCMI15NewRet025Infl_OpenOM, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Output Manager");
            mTime.StartTimer();

            pOutputManager._Navigate(Config.eCountry, "Liabilities Detailed Results", "RollForward", true);
            pOutputManager._WaitForLoading();
            pOutputManager._SelectTab("Liabilities Detailed Results");

            mTime.StopTimer(iCMI15NewRet025Infl_DetailResult_Load);
            mLog.LogInfo(iCMI15NewRet025Infl_DetailResult_Load, MyPerformanceCounter.Memory_Private);

            pMain._SelectTab("Output Manager");
            pOutputManager._Navigate(Config.eCountry, "Payout Projection - Benefit Cashflows", "RollForward", true);
            pOutputManager._SelectTab("Benefit Cashflows");
            _gLib._SetSyncUDWin_ByClipboard("NumberOfYears", pOutputManager.wRetirementStudio.wBenefitCashFlow_NumberOfYears.txt, "99", 0);
            _gLib._SetSyncUDWin("GroupbyStatusCodes", pOutputManager.wRetirementStudio.wGroup_GroupbyStatusCodes.rdGrroupbyStatusCodes, "True", 0);
            _gLib._SetSyncUDWin("SplitbyBenefitTypeTranche", pOutputManager.wRetirementStudio.wBenefitCashFlow_SplitbyBenefitTypeTranche.chk, "True", 0);


            mTime.StartTimer();
            _gLib._SetSyncUDWin("SplitbyBenefitTypeTranche", pOutputManager.wRetirementStudio.wProcess.btnProcess, "Click", 0);
            _gLib._SetSyncUDWin("Cancel", pOutputManager.wSaveAs.wCancel.btnCancel, "Click", Config.iTimeout * 3);
            pOutputManager._SelectTab("Benefit Cashflows");

            mTime.StopTimer(iCMI15NewRet025Infl_PayoutProject_Load);
            mLog.LogInfo(iCMI15NewRet025Infl_PayoutProject_Load, MyPerformanceCounter.Memory_Private);

            if (bExportIOE)
            {
                pMain._SelectTab("Output Manager");
                pOutputManager._Navigate(Config.eCountry, "IOE", "RollForward", true);
                pOutputManager._SelectTab("Individual Output");
                _gLib._SetSyncUDWin("Group - None", pOutputManager.wRetirementStudio.wGroup_None.rdNone, "True", 0);
                _gLib._SetSyncUDWin("Process", pOutputManager.wRetirementStudio.wProcess.btnProcess, "Click", 0);

                dic.Clear();
                dic.Add("Level_1", "Individual Output");
                _gLib._TreeViewSelectWin(0, pOutputManager.wRetirementStudio.tvNaviTree, dic);

                dic.Clear();
                dic.Add("Level_1", "Individual Output");
                dic.Add("MenuItem", "Add IOE Parameters");
                _gLib._TreeViewRightSelectWin(0, pOutputManager.wRetirementStudio.tvNaviTree.tviIndividualOutput, dic, false);

                mTime.StartTimer();

                _gLib._SetSyncUDWin("Export", pOutputManager.wRetirementStudio.wExport.btnExport, "Click", 0);
                pOutputManager._SaveAs(sOutputDir + "IOE.xls");
                _gLib._SetSyncUDWin("OK", pOutputManager.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);

                pOutputManager._SelectTab("Individual Output");
                mTime.StopTimer(iCMI15NewRet025Infl_ExportIOE);
                mLog.LogInfo(iCMI15NewRet025Infl_ExportIOE, MyPerformanceCounter.Memory_Private);
            }

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region ER & Reports - 1% pst ret AoA



            _gLib._CreateDirectory(sOutputDir, false);
            sERDetail = "";

            pMain._SelectTab("Valuation2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", dicPosition["1PstRetAoA_X"]);
            dic.Add("iPosY", dicPosition["1PstRetAoA_Y"]);
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);



            string s1PstRetAoA_Persist_80 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5);
            string s1PstRetAoA_Post_80 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5);
            string s1PstRetAoA_Persist_60 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5);
            string s1PstRetAoA_Post_60 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5);

            DateTime _t1PstRetAoA_Persist_80 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(s1PstRetAoA_Persist_80, Config.eCountry));
            DateTime _t1PstRetAoA_Post_80 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(s1PstRetAoA_Post_80, Config.eCountry));
            DateTime _t1PstRetAoA_Persist_60 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(s1PstRetAoA_Persist_60, Config.eCountry));
            DateTime _t1PstRetAoA_Post_60 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(s1PstRetAoA_Post_60, Config.eCountry));


            string _s1PstRetAoA_EarliestProcess = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5);
            string _s1PstRetAoA_80JobSuccess = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12);
            string _s1PstRetAoA_60JobSuccess = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 12);
            string _s1PstRetAoA_GroupJobSuccess = pMain._ER_ReturnRunStatus_TopGrid(11);
            DateTime _t1PstRetAoA_EarliestProcess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_s1PstRetAoA_EarliestProcess, Config.eCountry));
            DateTime _t1PstRetAoA_80JobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_s1PstRetAoA_80JobSuccess, Config.eCountry));
            DateTime _t1PstRetAoA_60JobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_s1PstRetAoA_60JobSuccess, Config.eCountry));
            DateTime _t1PstRetAoA_GroupJobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_s1PstRetAoA_GroupJobSuccess, Config.eCountry));



            mLog.LogInfo(i1PstRetAoA_GroupID, pMain._ER_ReturnRunStatus_TopGrid(2));
            //mLog.LogInfo(i1PstRetAoA_Persist_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            //mLog.LogInfo(i1PstRetAoA_Post_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));
            mLog.LogInfo(i1PstRetAoA_Persist_80, s1PstRetAoA_Persist_80);
            mLog.LogInfo(i1PstRetAoA_Post_80, s1PstRetAoA_Post_80);

            //mLog.LogInfo(i1PstRetAoA_Persist_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5));
            //mLog.LogInfo(i1PstRetAoA_Post_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5));
            mLog.LogInfo(i1PstRetAoA_Persist_60, s1PstRetAoA_Persist_60);
            mLog.LogInfo(i1PstRetAoA_Post_60, s1PstRetAoA_Post_60);

            //sERDetail = sERDetail + "Earliest Process: " + pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5) + Environment.NewLine;
            //sERDetail = sERDetail + "A_80 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12) + Environment.NewLine;
            //sERDetail = sERDetail + "B_60 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 12) + Environment.NewLine;
            //sERDetail = sERDetail + "Group Job Success: " + pMain._ER_ReturnRunStatus_TopGrid(11) + Environment.NewLine;
            sERDetail = sERDetail + "Earliest Process: " + _s1PstRetAoA_EarliestProcess + Environment.NewLine;
            sERDetail = sERDetail + "A_80 Job Success: " + _s1PstRetAoA_80JobSuccess + Environment.NewLine;
            sERDetail = sERDetail + "B_60 Job Success: " + _s1PstRetAoA_60JobSuccess + Environment.NewLine;
            sERDetail = sERDetail + "Group Job Success: " + _s1PstRetAoA_GroupJobSuccess + Environment.NewLine;
            mLog.LogInfo(i1PstRetAoA_ER_Detail, sERDetail);

            sERDetail = "";
            sERDetail = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3) + ": " + Environment.NewLine;
            sERDetail = sERDetail + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 3) + ": " + Environment.NewLine;
            mLog.LogInfo(i1PstRetAoA_NumOfCores, sERDetail);



            mLog.LogInfo(iJobID_1PstRetAoA_1, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));
            mLog.LogInfo(iJobID_1PstRetAoA_2, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 3));



            TimeSpan _t1Persist_80 = _t1PstRetAoA_Post_80 - _t1PstRetAoA_Persist_80;
            TimeSpan _t1Post_80 = _t1PstRetAoA_80JobSuccess - _t1PstRetAoA_Post_80;
            TimeSpan _t1Persist_60 = _t1PstRetAoA_Post_60 - _t1PstRetAoA_Persist_60;
            TimeSpan _t1Post_60 = _t1PstRetAoA_60JobSuccess - _t1PstRetAoA_Post_60;

            TimeSpan _t1JobSent_Persist = _t1PstRetAoA_Persist_80 - _t1PstRetAoA_EarliestProcess;

            _sER_ReturnRunStatus_ClickRun = null;
            _excelLog.OpenExcelFile("Sheet1");
            _sER_ReturnRunStatus_ClickRun = _excelLog.getOneCellValue(i1PstRetAoA_ER_ClickRun, iCol_Memory);
            _excelLog.CloseExcelApplication();
            _t1PstRetAoA_ClickRun = Convert.ToDateTime(_sER_ReturnRunStatus_ClickRun);

            TimeSpan _t1ClickRun_GroupJobStatus = _t1PstRetAoA_GroupJobSuccess - _t1PstRetAoA_ClickRun;
            int _t1Overall = 1 + (_t1ClickRun_GroupJobStatus.Hours * 3600 + _t1ClickRun_GroupJobStatus.Minutes * 60 + _t1ClickRun_GroupJobStatus.Seconds) - (_t1JobSent_Persist.Hours * 3600 + _t1JobSent_Persist.Minutes * 60 + _t1JobSent_Persist.Seconds);

            mLogTime.LogInfo(i1PstRetAoA_Persist_80, Convert.ToString(_t1Persist_80.Hours * 3600 + _t1Persist_80.Minutes * 60 + _t1Persist_80.Seconds));
            mLogTime.LogInfo(i1PstRetAoA_Post_80, Convert.ToString(_t1Post_80.Hours * 3600 + _t1Post_80.Minutes * 60 + _t1Post_80.Seconds));
            mLogTime.LogInfo(i1PstRetAoA_Persist_60, Convert.ToString(_t1Persist_60.Hours * 3600 + _t1Persist_60.Minutes * 60 + _t1Persist_60.Seconds));
            mLogTime.LogInfo(i1PstRetAoA_Post_60, Convert.ToString(_t1Post_60.Hours * 3600 + _t1Post_60.Minutes * 60 + _t1Post_60.Seconds));

            mLogTime.LogInfo(i1PstRetAoA_ER_ClickRun, Convert.ToString(_t1Overall));




            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", dicPosition["1PstRetAoA_X"]);
            dic.Add("iPosY", dicPosition["1PstRetAoA_Y"]);
            dic.Add("MenuItem_1", "View Output");
            dic.Add("CheckOMSetupPopup", "False");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");

            mTime.StopTimer(i1PstRetAoA_OpenOM);
            mLog.LogInfo(i1PstRetAoA_OpenOM, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Output Manager");
            mTime.StartTimer();

            pOutputManager._Navigate(Config.eCountry, "Liabilities Detailed Results", "RollForward", true);
            pOutputManager._WaitForLoading();
            pOutputManager._SelectTab("Liabilities Detailed Results");

            mTime.StopTimer(i1PstRetAoA_DetailResult_Load);
            mLog.LogInfo(i1PstRetAoA_DetailResult_Load, MyPerformanceCounter.Memory_Private);

            pMain._SelectTab("Output Manager");
            pOutputManager._Navigate(Config.eCountry, "Payout Projection - Benefit Cashflows", "RollForward", true);
            pOutputManager._SelectTab("Benefit Cashflows");
            _gLib._SetSyncUDWin_ByClipboard("NumberOfYears", pOutputManager.wRetirementStudio.wBenefitCashFlow_NumberOfYears.txt, "99", 0);
            _gLib._SetSyncUDWin("GroupbyStatusCodes", pOutputManager.wRetirementStudio.wGroup_GroupbyStatusCodes.rdGrroupbyStatusCodes, "True", 0);
            _gLib._SetSyncUDWin("SplitbyBenefitTypeTranche", pOutputManager.wRetirementStudio.wBenefitCashFlow_SplitbyBenefitTypeTranche.chk, "True", 0);


            mTime.StartTimer();
            _gLib._SetSyncUDWin("SplitbyBenefitTypeTranche", pOutputManager.wRetirementStudio.wProcess.btnProcess, "Click", 0);
            _gLib._SetSyncUDWin("Cancel", pOutputManager.wSaveAs.wCancel.btnCancel, "Click", Config.iTimeout * 3);
            pOutputManager._SelectTab("Benefit Cashflows");

            mTime.StopTimer(i1PstRetAoA_PayoutProject_Load);
            mLog.LogInfo(i1PstRetAoA_PayoutProject_Load, MyPerformanceCounter.Memory_Private);

            if (bExportIOE)
            {
                pMain._SelectTab("Output Manager");
                pOutputManager._Navigate(Config.eCountry, "IOE", "RollForward", true);
                pOutputManager._SelectTab("Individual Output");
                _gLib._SetSyncUDWin("Group - None", pOutputManager.wRetirementStudio.wGroup_None.rdNone, "True", 0);
                _gLib._SetSyncUDWin("Process", pOutputManager.wRetirementStudio.wProcess.btnProcess, "Click", 0);

                dic.Clear();
                dic.Add("Level_1", "Individual Output");
                _gLib._TreeViewSelectWin(0, pOutputManager.wRetirementStudio.tvNaviTree, dic);

                dic.Clear();
                dic.Add("Level_1", "Individual Output");
                dic.Add("MenuItem", "Add IOE Parameters");
                _gLib._TreeViewRightSelectWin(0, pOutputManager.wRetirementStudio.tvNaviTree.tviIndividualOutput, dic, false);

                mTime.StartTimer();

                _gLib._SetSyncUDWin("Export", pOutputManager.wRetirementStudio.wExport.btnExport, "Click", 0);
                pOutputManager._SaveAs(sOutputDir + "IOE.xls");
                _gLib._SetSyncUDWin("OK", pOutputManager.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);

                pOutputManager._SelectTab("Individual Output");
                mTime.StopTimer(i1PstRetAoA_ExportIOE);
                mLog.LogInfo(i1PstRetAoA_ExportIOE, MyPerformanceCounter.Memory_Private);
            }

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region ER & Reports - PPF & Solvency



            _gLib._CreateDirectory(sOutputDir, false);
            sERDetail = "";

            pMain._SelectTab("Valuation2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", dicPosition["PPFAndSolvency_X"]);
            dic.Add("iPosY", dicPosition["PPFAndSolvency_Y"]);
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);



            string sPPFAndSolvency_Persist_80 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5);
            string sPPFAndSolvency_Post_80 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5);
            string sPPFAndSolvency_Persist_60 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5);
            string sPPFAndSolvency_Post_60 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5);

            DateTime _tPPFAndSolvency_Persist_80 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sPPFAndSolvency_Persist_80, Config.eCountry));
            DateTime _tPPFAndSolvency_Post_80 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sPPFAndSolvency_Post_80, Config.eCountry));
            DateTime _tPPFAndSolvency_Persist_60 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sPPFAndSolvency_Persist_60, Config.eCountry));
            DateTime _tPPFAndSolvency_Post_60 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sPPFAndSolvency_Post_60, Config.eCountry));


            string _sPPFAndSolvency_EarliestProcess = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5);
            string _sPPFAndSolvency_80JobSuccess = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12);
            string _sPPFAndSolvency_60JobSuccess = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 6, 12);
            string _sPPFAndSolvency_GroupJobSuccess = pMain._ER_ReturnRunStatus_TopGrid(11);
            DateTime _tPPFAndSolvency_EarliestProcess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sPPFAndSolvency_EarliestProcess, Config.eCountry));
            DateTime _tPPFAndSolvency_80JobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sPPFAndSolvency_80JobSuccess, Config.eCountry));
            DateTime _tPPFAndSolvency_60JobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sPPFAndSolvency_60JobSuccess, Config.eCountry));
            DateTime _tPPFAndSolvency_GroupJobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sPPFAndSolvency_GroupJobSuccess, Config.eCountry));

                       
            mLog.LogInfo(iPPFAndSolvency_GroupID, pMain._ER_ReturnRunStatus_TopGrid(2));
            //mLog.LogInfo(iPPFAndSolvency_Persist_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            //mLog.LogInfo(iPPFAndSolvency_Post_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));
            mLog.LogInfo(iPPFAndSolvency_Persist_80, sPPFAndSolvency_Persist_80);
            mLog.LogInfo(iPPFAndSolvency_Post_80, sPPFAndSolvency_Post_80);

            //mLog.LogInfo(iPPFAndSolvency_Persist_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5));
            //mLog.LogInfo(iPPFAndSolvency_Post_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5));
            mLog.LogInfo(iPPFAndSolvency_Persist_60, sPPFAndSolvency_Persist_60);
            mLog.LogInfo(iPPFAndSolvency_Post_60, sPPFAndSolvency_Post_60);



            //sERDetail = sERDetail + "Earliest Process: " + pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5) + Environment.NewLine;
            //sERDetail = sERDetail + "A_80 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12) + Environment.NewLine;
            //sERDetail = sERDetail + "B_60 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 6, 12) + Environment.NewLine;
            //sERDetail = sERDetail + "Group Job Success: " + pMain._ER_ReturnRunStatus_TopGrid(11) + Environment.NewLine;
            sERDetail = sERDetail + "Earliest Process: " + _sPPFAndSolvency_EarliestProcess + Environment.NewLine;
            sERDetail = sERDetail + "A_80 Job Success: " + _sPPFAndSolvency_80JobSuccess + Environment.NewLine;
            sERDetail = sERDetail + "B_60 Job Success: " + _sPPFAndSolvency_60JobSuccess + Environment.NewLine;
            sERDetail = sERDetail + "Group Job Success: " + _sPPFAndSolvency_GroupJobSuccess + Environment.NewLine;
            mLog.LogInfo(iPPFAndSolvency_ER_Detail, sERDetail);

            sERDetail = "";
            sERDetail = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3) + ": " + Environment.NewLine;
            sERDetail = sERDetail + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 6, 3) + ": " + Environment.NewLine;
            mLog.LogInfo(iPPFAndSolvency_NumOfCores, sERDetail);


            mLog.LogInfo(iJobID_PPFAndSolvency_1, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));
            mLog.LogInfo(iJobID_PPFAndSolvency_2, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 6, 3));


            TimeSpan _tPPFAndSolvencyPersist_80 = _tPPFAndSolvency_Post_80 - _tPPFAndSolvency_Persist_80;
            TimeSpan _tPPFAndSolvencyPost_80 = _tPPFAndSolvency_80JobSuccess - _tPPFAndSolvency_Post_80;
            TimeSpan _tPPFAndSolvencyPersist_60 = _tPPFAndSolvency_Post_60 - _tPPFAndSolvency_Persist_60;
            TimeSpan _tPPFAndSolvencyPost_60 = _tPPFAndSolvency_60JobSuccess - _tPPFAndSolvency_Post_60;

            TimeSpan _tPPFAndSolvencyJobSent_Persist = _tPPFAndSolvency_Persist_80 - _tPPFAndSolvency_EarliestProcess;

            _sER_ReturnRunStatus_ClickRun = null;
            _excelLog.OpenExcelFile("Sheet1");
            _sER_ReturnRunStatus_ClickRun = _excelLog.getOneCellValue(iPPFAndSolvency_ER_ClickRun, iCol_Memory);
            _excelLog.CloseExcelApplication();
            _tPPFAndSolvency_ClickRun = Convert.ToDateTime(_sER_ReturnRunStatus_ClickRun);

            TimeSpan _tPPFAndSolvencyClickRun_GroupJobStatus = _tPPFAndSolvency_GroupJobSuccess - _tPPFAndSolvency_ClickRun;
            int _tPPFAndSolvencyOverall = 1 + (_tPPFAndSolvencyClickRun_GroupJobStatus.Hours * 3600 + _tPPFAndSolvencyClickRun_GroupJobStatus.Minutes * 60 + _tPPFAndSolvencyClickRun_GroupJobStatus.Seconds) - (_tPPFAndSolvencyJobSent_Persist.Hours * 3600 + _tPPFAndSolvencyJobSent_Persist.Minutes * 60 + _tPPFAndSolvencyJobSent_Persist.Seconds);

            mLogTime.LogInfo(iPPFAndSolvency_Persist_80, Convert.ToString(_tPPFAndSolvencyPersist_80.Hours * 3600 + _tPPFAndSolvencyPersist_80.Minutes * 60 + _tPPFAndSolvencyPersist_80.Seconds));
            mLogTime.LogInfo(iPPFAndSolvency_Post_80, Convert.ToString(_tPPFAndSolvencyPost_80.Hours * 3600 + _tPPFAndSolvencyPost_80.Minutes * 60 + _tPPFAndSolvencyPost_80.Seconds));
            mLogTime.LogInfo(iPPFAndSolvency_Persist_60, Convert.ToString(_tPPFAndSolvencyPersist_60.Hours * 3600 + _tPPFAndSolvencyPersist_60.Minutes * 60 + _tPPFAndSolvencyPersist_60.Seconds));
            mLogTime.LogInfo(iPPFAndSolvency_Post_60, Convert.ToString(_tPPFAndSolvencyPost_60.Hours * 3600 + _tPPFAndSolvencyPost_60.Minutes * 60 + _tPPFAndSolvencyPost_60.Seconds));

            mLogTime.LogInfo(iPPFAndSolvency_ER_ClickRun, Convert.ToString(_tPPFAndSolvencyOverall));



            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", dicPosition["PPFAndSolvency_X"]);
            dic.Add("iPosY", dicPosition["PPFAndSolvency_Y"]);
            dic.Add("MenuItem_1", "View Output");
            dic.Add("CheckOMSetupPopup", "False");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");

            mTime.StopTimer(iPPFAndSolvency_OpenOM);
            mLog.LogInfo(iPPFAndSolvency_OpenOM, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Output Manager");
            mTime.StartTimer();

            pOutputManager._Navigate(Config.eCountry, "Liabilities Detailed Results", "RollForward", true);
            pOutputManager._WaitForLoading();
            pOutputManager._SelectTab("Liabilities Detailed Results");

            mTime.StopTimer(iPPFAndSolvency_DetailResult_Load);
            mLog.LogInfo(iPPFAndSolvency_DetailResult_Load, MyPerformanceCounter.Memory_Private);

            pMain._SelectTab("Output Manager");
            pOutputManager._Navigate(Config.eCountry, "Payout Projection - Benefit Cashflows", "RollForward", true);
            pOutputManager._SelectTab("Benefit Cashflows");
            _gLib._SetSyncUDWin_ByClipboard("NumberOfYears", pOutputManager.wRetirementStudio.wBenefitCashFlow_NumberOfYears.txt, "99", 0);
            _gLib._SetSyncUDWin("GroupbyStatusCodes", pOutputManager.wRetirementStudio.wGroup_GroupbyStatusCodes.rdGrroupbyStatusCodes, "True", 0);
            _gLib._SetSyncUDWin("SplitbyBenefitTypeTranche", pOutputManager.wRetirementStudio.wBenefitCashFlow_SplitbyBenefitTypeTranche.chk, "True", 0);


            mTime.StartTimer();
            _gLib._SetSyncUDWin("SplitbyBenefitTypeTranche", pOutputManager.wRetirementStudio.wProcess.btnProcess, "Click", 0);
            _gLib._SetSyncUDWin("Cancel", pOutputManager.wSaveAs.wCancel.btnCancel, "Click", Config.iTimeout * 3);
            pOutputManager._SelectTab("Benefit Cashflows");

            mTime.StopTimer(iPPFAndSolvency_PayoutProject_Load);
            mLog.LogInfo(iPPFAndSolvency_PayoutProject_Load, MyPerformanceCounter.Memory_Private);

            if (bExportIOE)
            {
                pMain._SelectTab("Output Manager");
                pOutputManager._Navigate(Config.eCountry, "IOE", "RollForward", true);
                pOutputManager._SelectTab("Individual Output");
                _gLib._SetSyncUDWin("Group - None", pOutputManager.wRetirementStudio.wGroup_None.rdNone, "True", 0);
                _gLib._SetSyncUDWin("Process", pOutputManager.wRetirementStudio.wProcess.btnProcess, "Click", 0);

                dic.Clear();
                dic.Add("Level_1", "Individual Output");
                _gLib._TreeViewSelectWin(0, pOutputManager.wRetirementStudio.tvNaviTree, dic);

                dic.Clear();
                dic.Add("Level_1", "Individual Output");
                dic.Add("MenuItem", "Add IOE Parameters");
                _gLib._TreeViewRightSelectWin(0, pOutputManager.wRetirementStudio.tvNaviTree.tviIndividualOutput, dic, false);

                mTime.StartTimer();

                _gLib._SetSyncUDWin("Export", pOutputManager.wRetirementStudio.wExport.btnExport, "Click", 0);
                pOutputManager._SaveAs(sOutputDir + "IOE.xls");
                _gLib._SetSyncUDWin("OK", pOutputManager.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);

                pOutputManager._SelectTab("Individual Output");
                mTime.StopTimer(iPPFAndSolvency_ExportIOE);
                mLog.LogInfo(iPPFAndSolvency_ExportIOE, MyPerformanceCounter.Memory_Private);
            }

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

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


            dicPosition.Clear();
            dicPosition.Add("0PstRunForFSGCashflows_X", "80");
            dicPosition.Add("0PstRunForFSGCashflows_Y", "320");
            dicPosition.Add("25PstRunForFSGCashflows_X", "270");
            dicPosition.Add("25PstRunForFSGCashflows_Y", "380");
            dicPosition.Add("CMI15NewRet025Infl_X", "218");
            dicPosition.Add("CMI15NewRet025Infl_Y", "320");
            dicPosition.Add("1PstRetAoA_X", "340");
            dicPosition.Add("1PstRetAoA_Y", "320");
            dicPosition.Add("PPFAndSolvency_X", "470");
            dicPosition.Add("PPFAndSolvency_Y", "320");

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
