////// ----------------------- ------------------------------------------------------------------------///////////
//////                           This test Based on UKTiming Test Part-2                               ///////////
//////                                down to Node  CMI 1.5% new ret dec                               ///////////
//////                                                                                                 ///////////
//////                          Webber.ling@mercer.com      2015-July-28                               ///////////
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



namespace RetirementStudio._TestScripts_2019_cloud._TestScripts_Timing
{
    /// <summary>
    /// Summary description for UK_Timing_Regular
    /// </summary>
    [CodedUITest]
    public class UK_Timing_Regular_calculate
    {
        public UK_Timing_Regular_calculate()
        {

            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.UK;
            Config.sStudioLaunchDir = @"C:\Users\webber-ling\Desktop\Retirement Studio-Canada - 1 .appref-ms";
            //Config.sStudioLaunchDir = @"C:\Users\webber-ling\Desktop\EUProd7401\Client\RetirementStudio.exe";
            //Config.sClientName = "UK Performance Test 20131206 E"; // EU Prod Client
            //Config.sClientName = "UK Performance Test 20131206 B"; // EU Prod Client
            //Config.sClientName = "UK Performance Client"; // CA Prod Client
            //Config.sClientName = "UK Performance Test D"; // US Prod Client

            Config.sClientName = "UK_Performance_Test_COLA_MemoryLeak"; // QA1 client because "UK_Performance_Test_20131206" is broken....
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
        //static string sLogFile = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\UK_Timing_Test\UK_Timing_Test_CUIT.xls";
        static string sLogFile = @"C:\Users\lin-li3\Desktop\UK_Timing_Test_CUIT.xls";
        static string sOutputDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\UK_Timing_Test\Reports_KeepUpdateOnRun\";
        MyTimer mTime = new MyTimer(sCol_Time, sLogFile);
        MyLog mLog = new MyLog(sCol_Memory, sLogFile);
        MyLog mLogTime = new MyLog(sCol_Time, sLogFile);

        MyDictionary dicPosition = new MyDictionary();
        string sERDetail = "";
        string sSelectedRecords = "";

        #region Result Index

        static int iJobID_0PercentRunForFSGCashflow_1 = 176;
        static int iJobID_0PercentRunForFSGCashflow_2 = iJobID_0PercentRunForFSGCashflow_1 + 1;
        static int iJobID_CNS = iJobID_0PercentRunForFSGCashflow_2 + 1;
        static int iJobID_TestIndividualOutput_1 = iJobID_CNS + 1;
        static int iJobID_TestIndividualOutput_2 = iJobID_TestIndividualOutput_1 + 1;
        static int iJobID_PPFAndSolvency_1 = iJobID_TestIndividualOutput_2 + 1;
        static int iJobID_PPFAndSolvency_2 = iJobID_PPFAndSolvency_1 + 1;
        static int iJobID_FixSolvAgeDiff_1 = iJobID_PPFAndSolvency_2 + 1;
        static int iJobID_FixSolvAgeDiff_2 = iJobID_FixSolvAgeDiff_1 + 1;
        static int iJobID_FixSolvAgeDiff_User2_1 = iJobID_FixSolvAgeDiff_2 + 1;
        static int iJobID_FixSolvAgeDiff_User2_2 = iJobID_FixSolvAgeDiff_User2_1 + 1;



        static int iTimeStart_Overall = 2;
        static int iTimeEnd_Overall = iTimeStart_Overall + 1;
        static int iTimeStart_User1 = iTimeEnd_Overall + 1;
        static int iTimeEnd_User1 = iTimeStart_User1 + 1;
        static int iTimeStart_User2 = iTimeEnd_User1 + 1;
        static int iTimeEnd_User2 = iTimeStart_User2 + 1;
        static int iLaunchStudio = iTimeEnd_User2 + 2;
        static int iLocateService = iLaunchStudio + 1;
        static int iOpenService = iLocateService + 1;



        static int i0PercentRunForFSGCashflow_AddNode = iOpenService + 1;
        static int i0PercentRunForFSGCashflow_CustomRates_Select = i0PercentRunForFSGCashflow_AddNode + 1;
        static int i0PercentRunForFSGCashflow_CustomRates_Edit = i0PercentRunForFSGCashflow_CustomRates_Select + 1;
        static int i0PercentRunForFSGCashflow_CustomRates_Save = i0PercentRunForFSGCashflow_CustomRates_Edit + 1;
        static int i0PercentRunForFSGCashflow_PayIncrease_Add = i0PercentRunForFSGCashflow_CustomRates_Save + 1;
        static int i0PercentRunForFSGCashflow_PayIncrease_Edit = i0PercentRunForFSGCashflow_PayIncrease_Add + 1;
        static int i0PercentRunForFSGCashflow_PayIncrease_Save = i0PercentRunForFSGCashflow_PayIncrease_Edit + 1;
        static int i0PercentRunForFSGCashflow_OtherEconomicAssumptions_Add = i0PercentRunForFSGCashflow_PayIncrease_Save + 1;
        static int i0PercentRunForFSGCashflow_OtherEconomicAssumptions_Edit = i0PercentRunForFSGCashflow_OtherEconomicAssumptions_Add + 1;
        static int i0PercentRunForFSGCashflow_OtherEconomicAssumptions_Save = i0PercentRunForFSGCashflow_OtherEconomicAssumptions_Edit + 1;
        static int i0PercentRunForFSGCashflow_PayProjection_Add = i0PercentRunForFSGCashflow_OtherEconomicAssumptions_Save + 1;
        static int i0PercentRunForFSGCashflow_PayProjection_Edit = i0PercentRunForFSGCashflow_PayProjection_Add + 1;
        static int i0PercentRunForFSGCashflow_PayProjection_Save = i0PercentRunForFSGCashflow_PayProjection_Edit + 1;
        static int i0PercentRunForFSGCashflow_GMPAdjustment_Select = i0PercentRunForFSGCashflow_PayProjection_Save + 1;
        static int i0PercentRunForFSGCashflow_GMPAdjustment_Edit = i0PercentRunForFSGCashflow_GMPAdjustment_Select + 1;
        static int i0PercentRunForFSGCashflow_GMPAdjustment_Save = i0PercentRunForFSGCashflow_GMPAdjustment_Edit + 1;
                
        static int i0PercentRunForFSGCashflow_RunOption_Launch = i0PercentRunForFSGCashflow_GMPAdjustment_Save + 1;
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
        static int i0PercentRunForFSGCashflow_OutputValuationSummary = i0PercentRunForFSGCashflow_NumOfCores + 1;


        static int iCNS_AddNode = i0PercentRunForFSGCashflow_OutputValuationSummary + 1;
        static int iCNS_ImportData = iCNS_AddNode + 1;
        static int iCNS_Service_Edit = iCNS_ImportData + 1;
        static int iCNS_EmployeeContributionsFormula_Select = iCNS_Service_Edit + 1;
        static int iCNS_EmployeeContributionsFormula_Edit = iCNS_EmployeeContributionsFormula_Select + 1;
        static int iCNS_EmployeeContributionsFormula_Save = iCNS_EmployeeContributionsFormula_Edit + 1;
        static int iCNS_CustomFormulaB_Select = iCNS_EmployeeContributionsFormula_Save + 1;
        static int iCNS_CustomFormulaB_Edit = iCNS_CustomFormulaB_Select + 1;
        static int iCNS_CustomFormulaB_Save = iCNS_CustomFormulaB_Edit + 1;
        static int iCNS_CostOfLiving_Select = iCNS_CustomFormulaB_Save + 1;
        static int iCNS_CostOfLiving_Edit = iCNS_CostOfLiving_Select + 1;
        static int iCNS_CostOfLiving_Save = iCNS_CostOfLiving_Edit + 1;
        static int iCNS_TranchedBenefit_Select = iCNS_CostOfLiving_Save + 1;
        static int iCNS_TranchedBenefit_Edit = iCNS_TranchedBenefit_Select + 1;
        static int iCNS_TranchedBenefit_Save = iCNS_TranchedBenefit_Edit + 1;
        static int iCNS_NonTranchBenefitPlanDefinition_Select = iCNS_TranchedBenefit_Save + 1;
        static int iCNS_NonTranchBenefitPlanDefinition_Edit = iCNS_NonTranchBenefitPlanDefinition_Select + 1;
        static int iCNS_NonTranchBenefitPlanDefinition_Save = iCNS_NonTranchBenefitPlanDefinition_Edit + 1;
        static int iCNS_Methods_Select = iCNS_NonTranchBenefitPlanDefinition_Save + 1;
        static int iCNS_Methods_Edit = iCNS_Methods_Select + 1;
        static int iCNS_Methods_Save = iCNS_Methods_Edit + 1;
        static int iCNS_RunOption_Launch = iCNS_Methods_Save + 1;
        static int iCNS_RunOption_Edit = iCNS_RunOption_Launch + 1;
        static int iCNS_RunSubmission = iCNS_RunOption_Edit + 1;
        static int iCNS_ER_ClickRun = iCNS_RunSubmission + 1;
        static int iCNS_GroupID = iCNS_ER_ClickRun + 1;
        static int iCNS_Persist_80 = iCNS_GroupID + 1;
        static int iCNS_Post_80 = iCNS_Persist_80 + 1;
        static int iCNS_Persist_60 = iCNS_Post_80 + 1;
        static int iCNS_Post_60 = iCNS_Persist_60 + 1;
        static int iCNS_ER_Detail = iCNS_Post_60 + 1;
        static int iCNS_NumOfCores = iCNS_ER_Detail + 1;



        static int iTestIndividualOutput_AddNode = iCNS_NumOfCores + 1;
        static int iTestIndividualOutput_IndivdualOutput_Select = iTestIndividualOutput_AddNode + 1;
        static int iTestIndividualOutput_IndivdualOutput_Edit = iTestIndividualOutput_IndivdualOutput_Select + 1;
        static int iTestIndividualOutput_IndivdualOutput_Save = iTestIndividualOutput_IndivdualOutput_Edit + 1;
        static int iTestIndividualOutput_RunOption_Launch = iTestIndividualOutput_IndivdualOutput_Save + 1;
        static int iTestIndividualOutput_RunOption_Edit = iTestIndividualOutput_RunOption_Launch + 1;
        static int iTestIndividualOutput_RunSubmission = iTestIndividualOutput_RunOption_Edit + 1;
        static int iTestIndividualOutput_ER_ClickRun = iTestIndividualOutput_RunSubmission + 1;
        static int iTestIndividualOutput_GroupID = iTestIndividualOutput_ER_ClickRun + 1;
        static int iTestIndividualOutput_Persist_80 = iTestIndividualOutput_GroupID + 1;
        static int iTestIndividualOutput_Post_80 = iTestIndividualOutput_Persist_80 + 1;
        static int iTestIndividualOutput_Persist_60 = iTestIndividualOutput_Post_80 + 1;
        static int iTestIndividualOutput_Post_60 = iTestIndividualOutput_Persist_60 + 1;
        static int iTestIndividualOutput_ER_Detail = iTestIndividualOutput_Post_60 + 1;
        static int iTestIndividualOutput_NumOfCores = iTestIndividualOutput_ER_Detail + 1;


        static int iPPFAndSolvency_AddNode = iTestIndividualOutput_NumOfCores + 1;
        static int iPPFAndSolvency_CustomRates_Select = iPPFAndSolvency_AddNode + 1;
        static int iPPFAndSolvency_CustomRates_Edit = iPPFAndSolvency_CustomRates_Select + 1;
        static int iPPFAndSolvency_CustomRates_Save = iPPFAndSolvency_CustomRates_Edit + 1;
        static int iPPFAndSolvency_InterestRates_Select = iPPFAndSolvency_CustomRates_Save + 1;
        static int iPPFAndSolvency_InterestRates_Edit = iPPFAndSolvency_InterestRates_Select + 1;
        static int iPPFAndSolvency_InterestRates_Save = iPPFAndSolvency_InterestRates_Edit + 1;
        static int iPPFAndSolvency_OtherEconomicAssumptions_Edit = iPPFAndSolvency_InterestRates_Save + 1;
        static int iPPFAndSolvency_CostOfLiving_Select = iPPFAndSolvency_OtherEconomicAssumptions_Edit + 1;
        static int iPPFAndSolvency_CostOfLiving_Edit = iPPFAndSolvency_CostOfLiving_Select + 1;
        static int iPPFAndSolvency_CostOfLiving_Save = iPPFAndSolvency_CostOfLiving_Edit + 1;
        static int iPPFAndSolvency_GMPAdjustmentFactor_Select = iPPFAndSolvency_CostOfLiving_Save + 1;
        static int iPPFAndSolvency_GMPAdjustmentFactor_Edit = iPPFAndSolvency_GMPAdjustmentFactor_Select + 1;
        static int iPPFAndSolvency_GMPAdjustmentFactor_Save = iPPFAndSolvency_GMPAdjustmentFactor_Edit + 1;
        static int iPPFAndSolvency_RunOption_Launch = iPPFAndSolvency_GMPAdjustmentFactor_Save + 1;
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


        static int iFixSolvAgeDiff_AddNode = iPPFAndSolvency_NumOfCores + 1;
        static int iFixSolvAgeDiff_SolvencyOtherDemographic_Select = iFixSolvAgeDiff_AddNode + 1;
        static int iFixSolvAgeDiff_SolvencyOtherDemographic_Edit = iFixSolvAgeDiff_SolvencyOtherDemographic_Select + 1;
        static int iFixSolvAgeDiff_SolvencyOtherDemographic_Save = iFixSolvAgeDiff_SolvencyOtherDemographic_Edit + 1;
        static int iFixSolvAgeDiff_ParamPrint_Select = iFixSolvAgeDiff_SolvencyOtherDemographic_Save + 1;
        static int iFixSolvAgeDiff_ParamPrint_Load = iFixSolvAgeDiff_ParamPrint_Select + 1;
        static int iFixSolvAgeDiff_ParamComparison_Select = iFixSolvAgeDiff_ParamPrint_Load + 1;
        static int iFixSolvAgeDiff_ParamComparison_Load = iFixSolvAgeDiff_ParamComparison_Select + 1;
        static int iFixSolvAgeDiff_RunOption_Launch = iFixSolvAgeDiff_ParamComparison_Load + 1;
        static int iFixSolvAgeDiff_RunOption_Edit = iFixSolvAgeDiff_RunOption_Launch + 1;
        static int iFixSolvAgeDiff_RunSubmission = iFixSolvAgeDiff_RunOption_Edit + 1;
        static int iFixSolvAgeDiff_ER_ClickRun = iFixSolvAgeDiff_RunSubmission + 1;
        static int iFixSolvAgeDiff_GroupID = iFixSolvAgeDiff_ER_ClickRun + 1;
        static int iFixSolvAgeDiff_Persist_80 = iFixSolvAgeDiff_GroupID + 1;
        static int iFixSolvAgeDiff_Post_80 = iFixSolvAgeDiff_Persist_80 + 1;
        static int iFixSolvAgeDiff_Persist_60 = iFixSolvAgeDiff_Post_80 + 1;
        static int iFixSolvAgeDiff_Post_60 = iFixSolvAgeDiff_Persist_60 + 1;
        static int iFixSolvAgeDiff_ER_Detail = iFixSolvAgeDiff_Post_60 + 1;
        static int iFixSolvAgeDiff_NumOfCores = iFixSolvAgeDiff_ER_Detail + 1;

        static int iFixSolvAgeDiff_OutputManager_Open = iFixSolvAgeDiff_NumOfCores + 1;
        static int iFixSolvAgeDiff_ValSummary_Open = iFixSolvAgeDiff_OutputManager_Open + 1;
        static int iFixSolvAgeDiff_ValSummary_Export = iFixSolvAgeDiff_ValSummary_Open + 1;
        static int iFixSolvAgeDiff_ReconciliationToPriorYear_Open = iFixSolvAgeDiff_ValSummary_Export + 1;
        static int iFixSolvAgeDiff_ReconciliationToPriorYear_Export = iFixSolvAgeDiff_ReconciliationToPriorYear_Open + 1;
        static int iFixSolvAgeDiff_LiabilityDetailedResults_Open = iFixSolvAgeDiff_ReconciliationToPriorYear_Export + 1;
        static int iFixSolvAgeDiff_LiabilityDetailedResults_Export = iFixSolvAgeDiff_LiabilityDetailedResults_Open + 1;


        static int iUser2_LaunchStudio = iFixSolvAgeDiff_LiabilityDetailedResults_Export + 12;
        static int iUser2_LocateService = iUser2_LaunchStudio + 1;
        static int iUser2_OpenService = iUser2_LocateService + 1;
        static int iUser2_ParamComparison = iUser2_OpenService + 1;
        static int iUser2_FixSolvAgeDiff_RunOption_Launch = iUser2_ParamComparison + 1;
        static int iUser2_FixSolvAgeDiff_RunOption_Edit = iUser2_FixSolvAgeDiff_RunOption_Launch + 1;
        static int iUser2_FixSolvAgeDiff_RunSubmission = iUser2_FixSolvAgeDiff_RunOption_Edit + 1;
        static int iUser2_FixSolvAgeDiff_ER_ClickRun = iUser2_FixSolvAgeDiff_RunSubmission + 1;
        static int iUser2_FixSolvAgeDiff_GroupID = iUser2_FixSolvAgeDiff_ER_ClickRun + 1;
        static int iUser2_FixSolvAgeDiff_Persist_80 = iUser2_FixSolvAgeDiff_GroupID + 1;
        static int iUser2_FixSolvAgeDiff_Post_80 = iUser2_FixSolvAgeDiff_Persist_80 + 1;
        static int iUser2_FixSolvAgeDiff_Persist_60 = iUser2_FixSolvAgeDiff_Post_80 + 1;
        static int iUser2_FixSolvAgeDiff_Post_60 = iUser2_FixSolvAgeDiff_Persist_60 + 1;
        static int iUser2_FixSolvAgeDiff_ER_Detail = iUser2_FixSolvAgeDiff_Post_60 + 1;
        static int iUser2_FixSolvAgeDiff_NumOfCores = iUser2_FixSolvAgeDiff_ER_Detail + 1;

        static int iUser2_FixSolvAgeDiff_OpenNodeInEdit = iUser2_FixSolvAgeDiff_NumOfCores + 1;
        static int iUser2_FixSolvAgeDiff_InterestRate_Select = iUser2_FixSolvAgeDiff_OpenNodeInEdit + 1;
        static int iUser2_FixSolvAgeDiff_ProvisionOpenInEdit = iUser2_FixSolvAgeDiff_InterestRate_Select + 1;
        static int iUser2_FixSolvAgeDiff_TrancheBenefit_Select = iUser2_FixSolvAgeDiff_ProvisionOpenInEdit + 1;
        static int iUser2_FixSolvAgeDiff_Save = iUser2_FixSolvAgeDiff_TrancheBenefit_Select + 1;
        static int iUser2_FixSolvAgeDiff_OutputManager_Open = iUser2_FixSolvAgeDiff_Save + 1;
        static int iUser2_FixSolvAgeDiff_ReconciliationToPriorYear_Open = iUser2_FixSolvAgeDiff_OutputManager_Open + 1;
        static int iUser2_FixSolvAgeDiff_ReconciliationToPriorYear_Export = iUser2_FixSolvAgeDiff_ReconciliationToPriorYear_Open + 1;
        static int iUser2_OpenServiceAgain = iUser2_FixSolvAgeDiff_ReconciliationToPriorYear_Export + 1;

        static int iTest = 175;

        #endregion




        #endregion


        #region change date format

        public class DateTimeFormatbyCountry
        {
            public string changeDateTimeFormatbyCountry(string datetime, _Country eCountry)
            {
                if (eCountry == _Country.UK)
                {
                    string[] strdatetime = datetime.Split('/');
                    datetime = strdatetime[1] + "/" + strdatetime[0] + "/" + strdatetime[2];
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
        public void test_UK_Timing_Regular_calculate()
        {


            DateTimeFormatbyCountry DateTimeFormat = new DateTimeFormatbyCountry();


            _gLib._StudioClearCache();   //////////_gLib._MsgBox("Warning!", "Please Clear Cache!");

            pMain._SetLanguageAndRegional();


  




            #region  User1 - 0 % Run for FSG Cashflow - Node 1


            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "80");
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
            dic.Add("GenerateParameterPrint", "True");
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
            DateTime _t0PercentRunForFSGCashflow_ER_ClickRun = DateTime.Now;
            mTime.StartTimer();
            mLog.LogInfo(i0PercentRunForFSGCashflow_ER_ClickRun, _t0PercentRunForFSGCashflow_ER_ClickRun.ToString());



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


            #region  User1 - CNS - Node 8


            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "340");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Object", "Main.RunOption");
            dic.Add("optiTimeout", "");
            pMain._ObjectExist(dic);

            mTime.StopTimer(iCNS_RunOption_Launch);
            mLog.LogInfo(iCNS_RunOption_Launch, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "False");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("Pay", "FTE80thsPayProj");
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
            dic.Add("Solvency", "False");
            dic.Add("PPFS179", "False");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VOOFF", "All Benefit Sets");
            dic.Add("SelectVOs_VO1", "A_80ths_Structure");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectRecords", "");
            dic.Add("Validate", "");
            dic.Add("RunValuation", "");
            pMain._PopVerify_RunOptions(dic);

            mTime.StopTimer(iCNS_RunOption_Edit);
            mLog.LogInfo(iCNS_RunOption_Edit, MyPerformanceCounter.Memory_Private);



            //mTime.StartTimer();
            //mLog.LogInfo(iCNS_ER_ClickRun, DateTime.Now.ToString());
            DateTime _tCNS_ER_ClickRun = DateTime.Now;
            mTime.StartTimer();
            mLog.LogInfo(iCNS_ER_ClickRun, _tCNS_ER_ClickRun.ToString());


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            mTime.StopTimer(iCNS_RunSubmission);
            mLog.LogInfo(iCNS_RunSubmission, MyPerformanceCounter.Memory_Private);






            #endregion


            #region User1 - Test Individual Output - Node 13




            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "640");
            dic.Add("iPosY", "430");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Object", "Main.RunOption");
            dic.Add("optiTimeout", "");
            pMain._ObjectExist(dic);

            mTime.StopTimer(iTestIndividualOutput_RunOption_Launch);
            mLog.LogInfo(iTestIndividualOutput_RunOption_Launch, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            sSelectedRecords = "$emp.EmployeeIDNumber=\"UK12345AB\" OR $emp.EmployeeIDNumber=\"UK12345AC\" OR $emp.EmployeeIDNumber=\"UK12345AD\" OR ";
            sSelectedRecords = sSelectedRecords + "$emp.EmployeeIDNumber=\"UK12345AD\" OR $emp.EmployeeIDNumber=\"UK12345AE\" OR $emp.EmployeeIDNumber=\"UK12345AF\" OR ";
            sSelectedRecords = sSelectedRecords + "$emp.EmployeeIDNumber=\"UK12345AG\" OR $emp.EmployeeIDNumber=\"UK12345AH\" OR $emp.EmployeeIDNumber=\"UK12345AJ\" OR ";
            sSelectedRecords = sSelectedRecords + "$emp.EmployeeIDNumber=\"UK12345AK\" OR $emp.EmployeeIDNumber=\"UK12345AL\" OR $emp.EmployeeIDNumber=\"UK12345AM\" OR ";

            sSelectedRecords = sSelectedRecords + "$emp.EmployeeIDNumber=\"UK12345AA\" OR $emp.EmployeeIDNumber=\"UK12345AI\" OR $emp.EmployeeIDNumber=\"UK12345AP\" OR ";
            sSelectedRecords = sSelectedRecords + "$emp.EmployeeIDNumber=\"UK12345BA\" OR $emp.EmployeeIDNumber=\"UK12345BT\" OR $emp.EmployeeIDNumber=\"UK12345CJ\" OR ";
            sSelectedRecords = sSelectedRecords + "$emp.EmployeeIDNumber=\"UK12345CZ\" OR $emp.EmployeeIDNumber=\"UK12345DX\" OR $emp.EmployeeIDNumber=\"UK12345EL\" OR ";
            sSelectedRecords = sSelectedRecords + "$emp.EmployeeIDNumber=\"UK12345FH\" OR $emp.EmployeeIDNumber=\"UK12345FJ\" OR $emp.EmployeeIDNumber=\"UK12345FR\"";




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "False");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("Pay", "FTE80thsPayProj");
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
            dic.Add("Solvency", "False");
            dic.Add("PPFS179", "False");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "All Benefit Sets");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectRecords", sSelectedRecords);
            dic.Add("Validate", "Click");
            dic.Add("RunValuation", "");
            pMain._PopVerify_RunOptions(dic);



            mTime.StopTimer(iTestIndividualOutput_RunOption_Edit);
            mLog.LogInfo(iTestIndividualOutput_RunOption_Edit, MyPerformanceCounter.Memory_Private);


            //mTime.StartTimer();
            //mLog.LogInfo(iTestIndividualOutput_ER_ClickRun, DateTime.Now.ToString());
            DateTime _tTestIndividualOutput_ER_ClickRun = DateTime.Now;
            mTime.StartTimer();
            mLog.LogInfo(iTestIndividualOutput_ER_ClickRun, _tTestIndividualOutput_ER_ClickRun.ToString());

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            mTime.StopTimer(iTestIndividualOutput_RunSubmission);
            mLog.LogInfo(iTestIndividualOutput_RunSubmission, MyPerformanceCounter.Memory_Private);




            #endregion

            
            #region User1 - PPF and Solvency - Node 14

            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "870");
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
            dic.Add("PayoutProjection", "False");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("Pay", "FTE60thsPayProj");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("Major", "");
            dic.Add("Intermediate", "#1#");
            dic.Add("Minor", "");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "False");
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
            DateTime _tPPFAndSolvency_ER_ClickRun = DateTime.Now;
            mTime.StartTimer();
            mLog.LogInfo(iPPFAndSolvency_ER_ClickRun, _tPPFAndSolvency_ER_ClickRun.ToString());



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

            
            #region User1 - Fix Solv age diff - Node 15


            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "810");
            dic.Add("iPosY", "370");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Object", "Main.RunOption");
            dic.Add("optiTimeout", "");
            pMain._ObjectExist(dic);

            mTime.StopTimer(iFixSolvAgeDiff_RunOption_Launch);
            mLog.LogInfo(iFixSolvAgeDiff_RunOption_Launch, MyPerformanceCounter.Memory_Private);


            sSelectedRecords = "$emp.EmployeeIDNumber=\"UK12345AB\" OR $emp.EmployeeIDNumber=\"UK12345AC\" OR $emp.EmployeeIDNumber=\"UK12345AD\" OR ";
            sSelectedRecords = sSelectedRecords + "$emp.EmployeeIDNumber=\"UK12345AD\" OR $emp.EmployeeIDNumber=\"UK12345AE\" OR $emp.EmployeeIDNumber=\"UK12345AF\" OR ";
            sSelectedRecords = sSelectedRecords + "$emp.EmployeeIDNumber=\"UK12345AG\" OR $emp.EmployeeIDNumber=\"UK12345AH\" OR $emp.EmployeeIDNumber=\"UK12345AJ\" OR ";
            sSelectedRecords = sSelectedRecords + "$emp.EmployeeIDNumber=\"UK12345AK\" OR $emp.EmployeeIDNumber=\"UK12345AL\" OR $emp.EmployeeIDNumber=\"UK12345AM\" OR ";

            sSelectedRecords = sSelectedRecords + "$emp.EmployeeIDNumber=\"UK12345AA\" OR $emp.EmployeeIDNumber=\"UK12345AI\" OR $emp.EmployeeIDNumber=\"UK12345AP\" OR ";
            sSelectedRecords = sSelectedRecords + "$emp.EmployeeIDNumber=\"UK12345BA\" OR $emp.EmployeeIDNumber=\"UK12345BT\" OR $emp.EmployeeIDNumber=\"UK12345CJ\" OR ";
            sSelectedRecords = sSelectedRecords + "$emp.EmployeeIDNumber=\"UK12345CZ\" OR $emp.EmployeeIDNumber=\"UK12345DX\" OR $emp.EmployeeIDNumber=\"UK12345EL\" OR ";
            sSelectedRecords = sSelectedRecords + "$emp.EmployeeIDNumber=\"UK12345FH\" OR $emp.EmployeeIDNumber=\"UK12345FJ\" OR $emp.EmployeeIDNumber=\"UK12345FR\"";



            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "False");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "False");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("Pay", "FTE60thsPayProj");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("Major", "");
            dic.Add("Intermediate", "Gender");
            dic.Add("Minor", "");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "False");
            dic.Add("AltFunding1", "False");
            dic.Add("AltFunding2", "False");
            dic.Add("AltFunding3", "False");
            dic.Add("Solvency", "True");
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

            mTime.StopTimer(iFixSolvAgeDiff_RunOption_Edit);
            mLog.LogInfo(iFixSolvAgeDiff_RunOption_Edit, MyPerformanceCounter.Memory_Private);



            //mTime.StartTimer();
            //mLog.LogInfo(iFixSolvAgeDiff_ER_ClickRun, DateTime.Now.ToString());
            DateTime _tFixSolvAgeDiff_ER_ClickRun = DateTime.Now;
            mTime.StartTimer();
            mLog.LogInfo(iFixSolvAgeDiff_ER_ClickRun, _tFixSolvAgeDiff_ER_ClickRun.ToString());


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CheckPopup", "True");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            mTime.StopTimer(iFixSolvAgeDiff_RunSubmission);
            mLog.LogInfo(iFixSolvAgeDiff_RunSubmission, MyPerformanceCounter.Memory_Private);






            #endregion






            #region User1 - ER & Reports - 0% run for FSG cashflows

            ////_gLib._CreateDirectory(sOutputDir, false);
            //sERDetail = "";

            //pMain._SelectTab("Valuation2012");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "");
            //dic.Add("iSelectColNum", "");
            //dic.Add("iPosX", "80");
            //dic.Add("iPosY", "320");
            //dic.Add("MenuItem_1", "View Run Status");
            //pMain._FlowTreeRightSelect(dic);

            //pMain._EnterpriseRun("Group Job Successfully Complete", true);




            //string s0PercentRunForFSGCashflow_Persist_80 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5);
            //string s0PercentRunForFSGCashflow_Post_80 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5);
            //string s0PercentRunForFSGCashflow_Persist_60 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5);
            //string s0PercentRunForFSGCashflow_Post_60 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5);

            //DateTime _t0PercentRunForFSGCashflow_Persist_80 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(s0PercentRunForFSGCashflow_Persist_80, Config.eCountry));
            //DateTime _t0PercentRunForFSGCashflow_Post_80 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(s0PercentRunForFSGCashflow_Post_80, Config.eCountry));
            //DateTime _t0PercentRunForFSGCashflow_Persist_60 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(s0PercentRunForFSGCashflow_Persist_60, Config.eCountry));
            //DateTime _t0PercentRunForFSGCashflow_Post_60 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(s0PercentRunForFSGCashflow_Post_60, Config.eCountry));



            //string _s0PercentRunForFSGCashflow_EarliestProcess = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5);
            //string _s0PercentRunForFSGCashflow_80JobSuccess = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12);
            //string _s0PercentRunForFSGCashflow_60JobSuccess = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 12);
            //string _s0PercentRunForFSGCashflow_GroupJobSuccess = pMain._ER_ReturnRunStatus_TopGrid(11);
            //DateTime _t0PercentRunForFSGCashflow_EarliestProcess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_s0PercentRunForFSGCashflow_EarliestProcess, Config.eCountry));
            //DateTime _t0PercentRunForFSGCashflow_80JobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_s0PercentRunForFSGCashflow_80JobSuccess, Config.eCountry));
            //DateTime _t0PercentRunForFSGCashflow_60JobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_s0PercentRunForFSGCashflow_60JobSuccess, Config.eCountry));
            //DateTime _t0PercentRunForFSGCashflow_GroupJobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_s0PercentRunForFSGCashflow_GroupJobSuccess, Config.eCountry));



            //mLog.LogInfo(i0PercentRunForFSGCashflow_GroupID, pMain._ER_ReturnRunStatus_TopGrid(2));
            ////mLog.LogInfo(i0PercentRunForFSGCashflow_Persist_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            ////mLog.LogInfo(i0PercentRunForFSGCashflow_Post_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));
            //mLog.LogInfo(i0PercentRunForFSGCashflow_Persist_80, s0PercentRunForFSGCashflow_Persist_80);
            //mLog.LogInfo(i0PercentRunForFSGCashflow_Post_80, s0PercentRunForFSGCashflow_Post_80);

            ////mLog.LogInfo(i0PercentRunForFSGCashflow_Persist_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5));
            ////mLog.LogInfo(i0PercentRunForFSGCashflow_Post_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5));
            //mLog.LogInfo(i0PercentRunForFSGCashflow_Persist_60, s0PercentRunForFSGCashflow_Persist_60);
            //mLog.LogInfo(i0PercentRunForFSGCashflow_Post_60, s0PercentRunForFSGCashflow_Post_60);



            ////sERDetail = sERDetail + "Earliest Process: " + pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5) + Environment.NewLine;
            ////sERDetail = sERDetail + "A_80 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12) + Environment.NewLine;
            ////sERDetail = sERDetail + "B_60 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 12) + Environment.NewLine;
            ////sERDetail = sERDetail + "Group Job Success: " + pMain._ER_ReturnRunStatus_TopGrid(11) + Environment.NewLine;
            //sERDetail = sERDetail + "Earliest Process: " + _s0PercentRunForFSGCashflow_EarliestProcess + Environment.NewLine;
            //sERDetail = sERDetail + "A_80 Job Success: " + _s0PercentRunForFSGCashflow_80JobSuccess + Environment.NewLine;
            //sERDetail = sERDetail + "B_60 Job Success: " + _s0PercentRunForFSGCashflow_60JobSuccess + Environment.NewLine;
            //sERDetail = sERDetail + "Group Job Success: " + _s0PercentRunForFSGCashflow_GroupJobSuccess + Environment.NewLine;
            //mLog.LogInfo(i0PercentRunForFSGCashflow_ER_Detail, sERDetail);

            //sERDetail = "";
            //sERDetail = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3) + ": " + Environment.NewLine;
            //sERDetail = sERDetail + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 3) + ": ";
            //mLog.LogInfo(i0PercentRunForFSGCashflow_NumOfCores, sERDetail);


            //mLog.LogInfo(iJobID_0PercentRunForFSGCashflow_1, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));
            //mLog.LogInfo(iJobID_0PercentRunForFSGCashflow_2, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 3));



            //TimeSpan _t0Persist_80 = _t0PercentRunForFSGCashflow_Post_80 - _t0PercentRunForFSGCashflow_Persist_80;
            //TimeSpan _t0Post_80 = _t0PercentRunForFSGCashflow_80JobSuccess - _t0PercentRunForFSGCashflow_Post_80;
            //TimeSpan _t0Persist_60 = _t0PercentRunForFSGCashflow_Post_60 - _t0PercentRunForFSGCashflow_Persist_60;
            //TimeSpan _t0Post_60 = _t0PercentRunForFSGCashflow_60JobSuccess - _t0PercentRunForFSGCashflow_Post_60;

            //TimeSpan _t0JobSent_Persist = _t0PercentRunForFSGCashflow_Persist_80 - _t0PercentRunForFSGCashflow_EarliestProcess;
            //TimeSpan _t0ClickRun_GroupJobStatus = _t0PercentRunForFSGCashflow_GroupJobSuccess - _t0PercentRunForFSGCashflow_ER_ClickRun;
            //int _t0Overall = (_t0ClickRun_GroupJobStatus.Hours * 3600 + _t0ClickRun_GroupJobStatus.Minutes * 60 + _t0ClickRun_GroupJobStatus.Seconds) - (_t0JobSent_Persist.Hours * 3600 + _t0JobSent_Persist.Minutes * 60 + _t0JobSent_Persist.Seconds);

            //mLogTime.LogInfo(i0PercentRunForFSGCashflow_Persist_80, Convert.ToString(_t0Persist_80.Hours * 3600 + _t0Persist_80.Minutes * 60 + _t0Persist_80.Seconds));
            //mLogTime.LogInfo(i0PercentRunForFSGCashflow_Post_80, Convert.ToString(_t0Post_80.Hours * 3600 + _t0Post_80.Minutes * 60 + _t0Post_80.Seconds));
            //mLogTime.LogInfo(i0PercentRunForFSGCashflow_Persist_60, Convert.ToString(_t0Persist_60.Hours * 3600 + _t0Persist_60.Minutes * 60 + _t0Persist_60.Seconds));
            //mLogTime.LogInfo(i0PercentRunForFSGCashflow_Post_60, Convert.ToString(_t0Post_60.Hours * 3600 + _t0Post_60.Minutes * 60 + _t0Post_60.Seconds));

            //mLogTime.LogInfo(i0PercentRunForFSGCashflow_ER_ClickRun, Convert.ToString(_t0Overall));



            //pMain._SelectTab("Run Status");
            //pMain._Home_ToolbarClick_Top(false);





            #endregion
            

            #region User1 - ER & Reports - CNS

            //_gLib._CreateDirectory(sOutputDir, false);
            sERDetail = "";

            pMain._SelectTab("Valuation2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "340");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);




            string sCNS_Persist_80 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5);
            string sCNS_Post_80 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5);
            DateTime _tCNS_Persist_80 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sCNS_Persist_80, Config.eCountry));
            DateTime _tCNS_Post_80 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sCNS_Post_80, Config.eCountry));



            string _sCNS_EarliestProcess = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5);
            string _sCNS_80JobSuccess = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12);
            string _sCNS_GroupJobSuccess = pMain._ER_ReturnRunStatus_TopGrid(11);
            DateTime _tCNS_EarliestProcess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sCNS_EarliestProcess, Config.eCountry));
            DateTime _tCNS_80JobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sCNS_80JobSuccess, Config.eCountry));
            DateTime _tCNS_GroupJobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sCNS_GroupJobSuccess, Config.eCountry));



            mLog.LogInfo(iCNS_GroupID, pMain._ER_ReturnRunStatus_TopGrid(2));
            //mLog.LogInfo(iCNS_Persist_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            //mLog.LogInfo(iCNS_Post_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));
            mLog.LogInfo(iCNS_Persist_80, sCNS_Persist_80);
            mLog.LogInfo(iCNS_Post_80, sCNS_Post_80);

            //sERDetail = sERDetail + "Earliest Process: " + pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5) + Environment.NewLine;
            //sERDetail = sERDetail + "A_80 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12) + Environment.NewLine;
            //sERDetail = sERDetail + "Group Job Success: " + pMain._ER_ReturnRunStatus_TopGrid(11) + Environment.NewLine;
            sERDetail = sERDetail + "Earliest Process: " + _sCNS_EarliestProcess + Environment.NewLine;
            sERDetail = sERDetail + "A_80 Job Success: " + _sCNS_80JobSuccess + Environment.NewLine;
            sERDetail = sERDetail + "Group Job Success: " + _sCNS_GroupJobSuccess + Environment.NewLine;
            mLog.LogInfo(iCNS_ER_Detail, sERDetail);

            sERDetail = "";
            sERDetail = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3) + ": ";
            mLog.LogInfo(iCNS_NumOfCores, sERDetail);

            mLog.LogInfo(iJobID_CNS, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));



            TimeSpan _tCNSPersist_80 = _tCNS_Post_80 - _tCNS_Persist_80;
            TimeSpan _tCNSPost_80 = _tCNS_80JobSuccess - _tCNS_Post_80;

            TimeSpan _tCNSJobSent_Persist = _tCNS_Persist_80 - _tCNS_EarliestProcess;
            TimeSpan _tCNSClickRun_GroupJobStatus = _tCNS_GroupJobSuccess - _tCNS_ER_ClickRun;
            int _tCNSOverall = (_tCNSClickRun_GroupJobStatus.Hours * 3600 + _tCNSClickRun_GroupJobStatus.Minutes * 60 + _tCNSClickRun_GroupJobStatus.Seconds) - (_tCNSJobSent_Persist.Hours * 3600 + _tCNSJobSent_Persist.Minutes * 60 + _tCNSJobSent_Persist.Seconds);

            mLogTime.LogInfo(iCNS_Persist_80, Convert.ToString(_tCNSPersist_80.Hours * 3600 + _tCNSPersist_80.Minutes * 60 + _tCNSPersist_80.Seconds));
            mLogTime.LogInfo(iCNS_Post_80, Convert.ToString(_tCNSPost_80.Hours * 3600 + _tCNSPost_80.Minutes * 60 + _tCNSPost_80.Seconds));

            mLogTime.LogInfo(iCNS_ER_ClickRun, Convert.ToString(_tCNSOverall));



            pMain._SelectTab("Run Status");
            pMain._Home_ToolbarClick_Top(false);





            #endregion

            
            #region User1 - ER & Reports - Test Individual Output

            //_gLib._CreateDirectory(sOutputDir, false);
            sERDetail = "";

            pMain._SelectTab("Valuation2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "640");
            dic.Add("iPosY", "430");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);



            string sTestIndividualOutput_Persist_80 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5);
            string sTestIndividualOutput_Post_80 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5);
            string sTestIndividualOutput_Persist_60 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5);
            string sTestIndividualOutput_Post_60 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5);

            DateTime _tTestIndividualOutput_Persist_80 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sTestIndividualOutput_Persist_80, Config.eCountry));
            DateTime _tTestIndividualOutput_Post_80 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sTestIndividualOutput_Post_80, Config.eCountry));
            DateTime _tTestIndividualOutput_Persist_60 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sTestIndividualOutput_Persist_60, Config.eCountry));
            DateTime _tTestIndividualOutput_Post_60 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sTestIndividualOutput_Post_60, Config.eCountry));



            string _sTestIndividualOutput_EarliestProcess = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5);
            string _sTestIndividualOutput_80JobSuccess = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12);
            string _sTestIndividualOutput_60JobSuccess = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 12);
            string _sTestIndividualOutput_GroupJobSuccess = pMain._ER_ReturnRunStatus_TopGrid(11);
            DateTime _tTestIndividualOutput_EarliestProcess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sTestIndividualOutput_EarliestProcess, Config.eCountry));
            DateTime _tTestIndividualOutput_80JobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sTestIndividualOutput_80JobSuccess, Config.eCountry));
            DateTime _tTestIndividualOutput_60JobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sTestIndividualOutput_60JobSuccess, Config.eCountry));
            DateTime _tTestIndividualOutput_GroupJobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sTestIndividualOutput_GroupJobSuccess, Config.eCountry));



            mLog.LogInfo(iTestIndividualOutput_GroupID, pMain._ER_ReturnRunStatus_TopGrid(2));
            //mLog.LogInfo(iTestIndividualOutput_Persist_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            //mLog.LogInfo(iTestIndividualOutput_Post_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));
            mLog.LogInfo(iTestIndividualOutput_Persist_80, sTestIndividualOutput_Persist_80);
            mLog.LogInfo(iTestIndividualOutput_Post_80, sTestIndividualOutput_Post_80);

            //mLog.LogInfo(iTestIndividualOutput_Persist_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5));
            //mLog.LogInfo(iTestIndividualOutput_Post_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5));
            mLog.LogInfo(iTestIndividualOutput_Persist_60, sTestIndividualOutput_Persist_60);
            mLog.LogInfo(iTestIndividualOutput_Post_60, sTestIndividualOutput_Post_60);

            //sERDetail = sERDetail + "Earliest Process: " + pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5) + Environment.NewLine;
            //sERDetail = sERDetail + "A_80 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12) + Environment.NewLine;
            //sERDetail = sERDetail + "B_60 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 12) + Environment.NewLine;
            //sERDetail = sERDetail + "Group Job Success: " + pMain._ER_ReturnRunStatus_TopGrid(11) + Environment.NewLine;
            sERDetail = sERDetail + "Earliest Process: " + _sTestIndividualOutput_EarliestProcess + Environment.NewLine;
            sERDetail = sERDetail + "A_80 Job Success: " + _sTestIndividualOutput_80JobSuccess + Environment.NewLine;
            sERDetail = sERDetail + "B_60 Job Success: " + _sTestIndividualOutput_60JobSuccess + Environment.NewLine;
            sERDetail = sERDetail + "Group Job Success: " + _sTestIndividualOutput_GroupJobSuccess + Environment.NewLine;
            mLog.LogInfo(iTestIndividualOutput_ER_Detail, sERDetail);

            sERDetail = "";
            sERDetail = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3) + ": " + Environment.NewLine;
            sERDetail = sERDetail + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 3) + ": ";
            mLog.LogInfo(iTestIndividualOutput_NumOfCores, sERDetail);


            mLog.LogInfo(iJobID_TestIndividualOutput_1, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));
            mLog.LogInfo(iJobID_TestIndividualOutput_2, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 3));



            TimeSpan _tTestIndividualOutputPersist_80 = _tTestIndividualOutput_Post_80 - _tTestIndividualOutput_Persist_80;
            TimeSpan _tTestIndividualOutputPost_80 = _tTestIndividualOutput_80JobSuccess - _tTestIndividualOutput_Post_80;
            TimeSpan _tTestIndividualOutputPersist_60 = _tTestIndividualOutput_Post_60 - _tTestIndividualOutput_Persist_60;
            TimeSpan _tTestIndividualOutputPost_60 = _tTestIndividualOutput_60JobSuccess - _tTestIndividualOutput_Post_60;

            TimeSpan _tTestIndividualOutputJobSent_Persist = _tTestIndividualOutput_Persist_80 - _tTestIndividualOutput_EarliestProcess;
            TimeSpan _tTestIndividualOutputClickRun_GroupJobStatus = _tTestIndividualOutput_GroupJobSuccess - _tTestIndividualOutput_ER_ClickRun;
            int _tTestIndividualOutputOverall = (_tTestIndividualOutputClickRun_GroupJobStatus.Hours * 3600 + _tTestIndividualOutputClickRun_GroupJobStatus.Minutes * 60 + _tTestIndividualOutputClickRun_GroupJobStatus.Seconds) - (_tTestIndividualOutputJobSent_Persist.Hours * 3600 + _tTestIndividualOutputJobSent_Persist.Minutes * 60 + _tTestIndividualOutputJobSent_Persist.Seconds);

            mLogTime.LogInfo(iTestIndividualOutput_Persist_80, Convert.ToString(_tTestIndividualOutputPersist_80.Hours * 3600 + _tTestIndividualOutputPersist_80.Minutes * 60 + _tTestIndividualOutputPersist_80.Seconds));
            mLogTime.LogInfo(iTestIndividualOutput_Post_80, Convert.ToString(_tTestIndividualOutputPost_80.Hours * 3600 + _tTestIndividualOutputPost_80.Minutes * 60 + _tTestIndividualOutputPost_80.Seconds));
            mLogTime.LogInfo(iTestIndividualOutput_Persist_60, Convert.ToString(_tTestIndividualOutputPersist_60.Hours * 3600 + _tTestIndividualOutputPersist_60.Minutes * 60 + _tTestIndividualOutputPersist_60.Seconds));
            mLogTime.LogInfo(iTestIndividualOutput_Post_60, Convert.ToString(_tTestIndividualOutputPost_60.Hours * 3600 + _tTestIndividualOutputPost_60.Minutes * 60 + _tTestIndividualOutputPost_60.Seconds));

            mLogTime.LogInfo(iTestIndividualOutput_ER_ClickRun, Convert.ToString(_tTestIndividualOutputOverall));



            pMain._SelectTab("Run Status");
            pMain._Home_ToolbarClick_Top(false);






            #endregion


            #region User1 - ER & Reports - PPF & Solvency

            //_gLib._CreateDirectory(sOutputDir, false);
            sERDetail = "";

            pMain._SelectTab("Valuation2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "870");
            dic.Add("iPosY", "320");
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
            string _sPPFAndSolvency_60JobSuccess = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 5, 12);
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
            //sERDetail = sERDetail + "B_60 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 5, 12) + Environment.NewLine;
            //sERDetail = sERDetail + "Group Job Success: " + pMain._ER_ReturnRunStatus_TopGrid(11) + Environment.NewLine;
            sERDetail = sERDetail + "Earliest Process: " + _sPPFAndSolvency_EarliestProcess + Environment.NewLine;
            sERDetail = sERDetail + "A_80 Job Success: " + _sPPFAndSolvency_80JobSuccess + Environment.NewLine;
            sERDetail = sERDetail + "B_60 Job Success: " + _sPPFAndSolvency_60JobSuccess + Environment.NewLine;
            sERDetail = sERDetail + "Group Job Success: " + _sPPFAndSolvency_GroupJobSuccess + Environment.NewLine;
            mLog.LogInfo(iPPFAndSolvency_ER_Detail, sERDetail);

            sERDetail = "";
            sERDetail = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3) + ": " + Environment.NewLine;
            sERDetail = sERDetail + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 5, 3) + ": ";
            mLog.LogInfo(iPPFAndSolvency_NumOfCores, sERDetail);


            mLog.LogInfo(iJobID_PPFAndSolvency_1, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));
            mLog.LogInfo(iJobID_PPFAndSolvency_2, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 5, 3));


            TimeSpan _tPPFAndSolvencyPersist_80 = _tPPFAndSolvency_Post_80 - _tPPFAndSolvency_Persist_80;
            TimeSpan _tPPFAndSolvencyPost_80 = _tPPFAndSolvency_80JobSuccess - _tPPFAndSolvency_Post_80;
            TimeSpan _tPPFAndSolvencyPersist_60 = _tPPFAndSolvency_Post_60 - _tPPFAndSolvency_Persist_60;
            TimeSpan _tPPFAndSolvencyPost_60 = _tPPFAndSolvency_60JobSuccess - _tPPFAndSolvency_Post_60;

            TimeSpan _tPPFAndSolvencyJobSent_Persist = _tPPFAndSolvency_Persist_80 - _tPPFAndSolvency_EarliestProcess;
            TimeSpan _tPPFAndSolvencyClickRun_GroupJobStatus = _tPPFAndSolvency_GroupJobSuccess - _tPPFAndSolvency_ER_ClickRun;
            int _tPPFAndSolvencyOverall = (_tPPFAndSolvencyClickRun_GroupJobStatus.Hours * 3600 + _tPPFAndSolvencyClickRun_GroupJobStatus.Minutes * 60 + _tPPFAndSolvencyClickRun_GroupJobStatus.Seconds) - (_tPPFAndSolvencyJobSent_Persist.Hours * 3600 + _tPPFAndSolvencyJobSent_Persist.Minutes * 60 + _tPPFAndSolvencyJobSent_Persist.Seconds);

            mLogTime.LogInfo(iPPFAndSolvency_Persist_80, Convert.ToString(_tPPFAndSolvencyPersist_80.Hours * 3600 + _tPPFAndSolvencyPersist_80.Minutes * 60 + _tPPFAndSolvencyPersist_80.Seconds));
            mLogTime.LogInfo(iPPFAndSolvency_Post_80, Convert.ToString(_tPPFAndSolvencyPost_80.Hours * 3600 + _tPPFAndSolvencyPost_80.Minutes * 60 + _tPPFAndSolvencyPost_80.Seconds));
            mLogTime.LogInfo(iPPFAndSolvency_Persist_60, Convert.ToString(_tPPFAndSolvencyPersist_60.Hours * 3600 + _tPPFAndSolvencyPersist_60.Minutes * 60 + _tPPFAndSolvencyPersist_60.Seconds));
            mLogTime.LogInfo(iPPFAndSolvency_Post_60, Convert.ToString(_tPPFAndSolvencyPost_60.Hours * 3600 + _tPPFAndSolvencyPost_60.Minutes * 60 + _tPPFAndSolvencyPost_60.Seconds));

            mLogTime.LogInfo(iPPFAndSolvency_ER_ClickRun, Convert.ToString(_tPPFAndSolvencyOverall));


            pMain._SelectTab("Run Status");
            pMain._Home_ToolbarClick_Top(false);






            #endregion


            #region User1 - ER & Reports - Fix Slov Age Diff

            //_gLib._CreateDirectory(sOutputDir, false);
            sERDetail = "";

            pMain._SelectTab("Valuation2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "810");
            dic.Add("iPosY", "380");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);




            string sFixSolvAgeDiff_Persist_80 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5);
            string sFixSolvAgeDiff_Post_80 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5);
            string sFixSolvAgeDiff_Persist_60 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5);
            string sFixSolvAgeDiff_Post_60 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5);

            DateTime _tFixSolvAgeDiff_Persist_80 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sFixSolvAgeDiff_Persist_80, Config.eCountry));
            DateTime _tFixSolvAgeDiff_Post_80 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sFixSolvAgeDiff_Post_80, Config.eCountry));
            DateTime _tFixSolvAgeDiff_Persist_60 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sFixSolvAgeDiff_Persist_60, Config.eCountry));
            DateTime _tFixSolvAgeDiff_Post_60 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sFixSolvAgeDiff_Post_60, Config.eCountry));



            string _sFixSolvAgeDiff_EarliestProcess = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5);
            string _sFixSolvAgeDiff_80JobSuccess = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12);
            string _sFixSolvAgeDiff_60JobSuccess = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 3, 12);
            string _sFixSolvAgeDiff_GroupJobSuccess = pMain._ER_ReturnRunStatus_TopGrid(11);
            DateTime _tFixSolvAgeDiff_EarliestProcess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sFixSolvAgeDiff_EarliestProcess, Config.eCountry));
            DateTime _tFixSolvAgeDiff_80JobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sFixSolvAgeDiff_80JobSuccess, Config.eCountry));
            DateTime _tFixSolvAgeDiff_60JobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sFixSolvAgeDiff_60JobSuccess, Config.eCountry));
            DateTime _tFixSolvAgeDiff_GroupJobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sFixSolvAgeDiff_GroupJobSuccess, Config.eCountry));



            mLog.LogInfo(iFixSolvAgeDiff_GroupID, pMain._ER_ReturnRunStatus_TopGrid(2));
            //mLog.LogInfo(iFixSolvAgeDiff_Persist_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            //mLog.LogInfo(iFixSolvAgeDiff_Post_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));
            mLog.LogInfo(iFixSolvAgeDiff_Persist_80, sFixSolvAgeDiff_Persist_80);
            mLog.LogInfo(iFixSolvAgeDiff_Post_80, sFixSolvAgeDiff_Post_80);

            //mLog.LogInfo(iFixSolvAgeDiff_Persist_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5));
            //mLog.LogInfo(iFixSolvAgeDiff_Post_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5));
            mLog.LogInfo(iFixSolvAgeDiff_Persist_60, sFixSolvAgeDiff_Persist_60);
            mLog.LogInfo(iFixSolvAgeDiff_Post_60, sFixSolvAgeDiff_Post_60);

            //sERDetail = sERDetail + "Earliest Process: " + pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5) + Environment.NewLine;
            //sERDetail = sERDetail + "A_80 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12) + Environment.NewLine;
            //sERDetail = sERDetail + "B_60 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 3, 12) + Environment.NewLine;
            //sERDetail = sERDetail + "Group Job Success: " + pMain._ER_ReturnRunStatus_TopGrid(11) + Environment.NewLine;
            sERDetail = sERDetail + "Earliest Process: " + _sFixSolvAgeDiff_EarliestProcess + Environment.NewLine;
            sERDetail = sERDetail + "A_80 Job Success: " + _sFixSolvAgeDiff_80JobSuccess + Environment.NewLine;
            sERDetail = sERDetail + "B_60 Job Success: " + _sFixSolvAgeDiff_60JobSuccess + Environment.NewLine;
            sERDetail = sERDetail + "Group Job Success: " + _sFixSolvAgeDiff_GroupJobSuccess + Environment.NewLine;
            mLog.LogInfo(iFixSolvAgeDiff_ER_Detail, sERDetail);

            sERDetail = "";
            sERDetail = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3) + ": " + Environment.NewLine;
            sERDetail = sERDetail + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 3, 3) + ": ";
            mLog.LogInfo(iFixSolvAgeDiff_NumOfCores, sERDetail);


            mLog.LogInfo(iJobID_FixSolvAgeDiff_1, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));
            mLog.LogInfo(iJobID_FixSolvAgeDiff_2, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 3, 3));



            TimeSpan _tFixSolvAgeDiffPersist_80 = _tFixSolvAgeDiff_Post_80 - _tFixSolvAgeDiff_Persist_80;
            TimeSpan _tFixSolvAgeDiffPost_80 = _tFixSolvAgeDiff_80JobSuccess - _tFixSolvAgeDiff_Post_80;
            TimeSpan _tFixSolvAgeDiffPersist_60 = _tFixSolvAgeDiff_Post_60 - _tFixSolvAgeDiff_Persist_60;
            TimeSpan _tFixSolvAgeDiffPost_60 = _tFixSolvAgeDiff_60JobSuccess - _tFixSolvAgeDiff_Post_60;

            TimeSpan _tFixSolvAgeDiffJobSent_Persist = _tFixSolvAgeDiff_Persist_80 - _tFixSolvAgeDiff_EarliestProcess;
            TimeSpan _tFixSolvAgeDiffClickRun_GroupJobStatus = _tFixSolvAgeDiff_GroupJobSuccess - _tFixSolvAgeDiff_ER_ClickRun;
            int _tFixSolvAgeDiffOverall = (_tFixSolvAgeDiffClickRun_GroupJobStatus.Hours * 3600 + _tFixSolvAgeDiffClickRun_GroupJobStatus.Minutes * 60 + _tFixSolvAgeDiffClickRun_GroupJobStatus.Seconds) - (_tFixSolvAgeDiffJobSent_Persist.Hours * 3600 + _tFixSolvAgeDiffJobSent_Persist.Minutes * 60 + _tFixSolvAgeDiffJobSent_Persist.Seconds);

            mLogTime.LogInfo(iFixSolvAgeDiff_Persist_80, Convert.ToString(_tFixSolvAgeDiffPersist_80.Hours * 3600 + _tFixSolvAgeDiffPersist_80.Minutes * 60 + _tFixSolvAgeDiffPersist_80.Seconds));
            mLogTime.LogInfo(iFixSolvAgeDiff_Post_80, Convert.ToString(_tFixSolvAgeDiffPost_80.Hours * 3600 + _tFixSolvAgeDiffPost_80.Minutes * 60 + _tFixSolvAgeDiffPost_80.Seconds));
            mLogTime.LogInfo(iFixSolvAgeDiff_Persist_60, Convert.ToString(_tFixSolvAgeDiffPersist_60.Hours * 3600 + _tFixSolvAgeDiffPersist_60.Minutes * 60 + _tFixSolvAgeDiffPersist_60.Seconds));
            mLogTime.LogInfo(iFixSolvAgeDiff_Post_60, Convert.ToString(_tFixSolvAgeDiffPost_60.Hours * 3600 + _tFixSolvAgeDiffPost_60.Minutes * 60 + _tFixSolvAgeDiffPost_60.Seconds));

            mLogTime.LogInfo(iFixSolvAgeDiff_ER_ClickRun, Convert.ToString(_tFixSolvAgeDiffOverall));



            pMain._SelectTab("Valuation2012");


            #endregion




            #region User2 - Launch Studio & Open Service

            //_gLib._StudioClearCache();   //////////_gLib._MsgBox("Warning!", "Please Clear Cache!");


            //mLog.LogInfo(iTimeStart_User2, DateTime.Now.ToString());



            //mTime.StartTimer();

            //_gLib._Cmd(Config.sStudioLaunchDir);

            //pMain._SelectTab("Home");
            //mTime.StopTimer(iUser2_LaunchStudio);
            //mLog.LogInfo(iUser2_LaunchStudio, MyPerformanceCounter.Memory_Private);


            //pMain._SelectTab("Home");

            ////////////////////////_gLib._MsgBox("Warning!", "Please manually select the Client in Studio-> Home -> All Services -> " + Config.sClientName + Environment.NewLine + Environment.NewLine
            ////////////////////////    + "Click OK to keep testing!");

            //dic.Clear();
            //dic.Add("Country", Config.eCountry.ToString());
            //dic.Add("Level_1", Config.sClientName);
            //dic.Add("Level_2", Config.sPlanName);
            //dic.Add("Level_3", "FundingValuations");
            //pMain._HomeTreeViewSelect_Favorites(0, dic);



            //mTime.StartTimer();

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("AddServiceInstance", "");
            //dic.Add("ServiceToOpen", "Valuation2012");
            //dic.Add("CheckPopup", "False");
            //pMain._PopVerify_Home_RightPane(dic);

            //mTime.StopTimer(iUser2_OpenService);
            //mLog.LogInfo(iUser2_OpenService, MyPerformanceCounter.Memory_Private);

            //pMain._SelectTab("Valuation2012");
            //pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region User2 - Fix Solv age diff - Node 15

            //_gLib._MsgBox("Warning", "Please clolse Studio and manually launch it, open service, enlarge the new tree view to make sure all nodes are visible! and Select Node <FixSlovAgeDiff>");



            //pMain._SelectTab("Valuation2012");

            //_gLib._KillProcessByName("Mercer.RetirementStudio.Messaging.MessagingClientApp");

            //mTime.StartTimer();

            //dic.Clear();
            //dic.Add("MenuItem_1", "Tools");
            //dic.Add("MenuItem_2", "Parameter Print Comparison");
            //pMain._MenuSelect(dic);

            //_gLib._Exists("Parameter Print Comparison", pMain.wParameterPrintComparison, 0, true);




            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("Process", "Click");
            //dic.Add("OK", "");
            //pMain._PopVerify_ParameterPrintComparison(dic);

            //dic.Clear();
            //dic.Add("Level_1", Config.sPlanName);
            //dic.Add("Level_2", "FundingValuations");
            //dic.Add("Level_3", "Valuation2012");
            //dic.Add("Level_4", "PPF and Solvency");
            //pMain._ParameterPrint_TreeviewSelect(dic, "Node1");

            //dic.Clear();
            //dic.Add("Level_1", Config.sPlanName);
            //dic.Add("Level_2", "FundingValuations");
            //dic.Add("Level_3", "Valuation2012");
            //dic.Add("Level_4", "Fix Solv age diff");
            //pMain._ParameterPrint_TreeviewSelect(dic, "Node2");


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("Process", "");
            //dic.Add("OK", "Click");
            //pMain._PopVerify_ParameterPrintComparison(dic);

            //_gLib._Exists("BeyondCompare", pMain.wBeyondCompare, Config.iTimeout * 5, true);

            //mTime.StopTimer(iUser2_ParamComparison);
            //mLog.LogInfo(iUser2_ParamComparison, MyPerformanceCounter.Memory_Private);


            //_gLib._SetSyncUDWin("BeyondCompare", pMain.wBeyondCompare.wTitleBar.btnClose, "Click", 0);



            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "810");
            dic.Add("iPosY", "370");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Object", "Main.RunOption");
            dic.Add("optiTimeout", "");
            pMain._ObjectExist(dic);

            mTime.StopTimer(iUser2_FixSolvAgeDiff_RunOption_Launch);
            mLog.LogInfo(iUser2_FixSolvAgeDiff_RunOption_Launch, MyPerformanceCounter.Memory_Private);


            sSelectedRecords = "$emp.EmployeeIDNumber=\"UK12345AB\" OR $emp.EmployeeIDNumber=\"UK12345AC\" OR $emp.EmployeeIDNumber=\"UK12345AD\" OR ";
            sSelectedRecords = sSelectedRecords + "$emp.EmployeeIDNumber=\"UK12345AD\" OR $emp.EmployeeIDNumber=\"UK12345AE\" OR $emp.EmployeeIDNumber=\"UK12345AF\" OR ";
            sSelectedRecords = sSelectedRecords + "$emp.EmployeeIDNumber=\"UK12345AG\" OR $emp.EmployeeIDNumber=\"UK12345AH\" OR $emp.EmployeeIDNumber=\"UK12345AJ\" OR ";
            sSelectedRecords = sSelectedRecords + "$emp.EmployeeIDNumber=\"UK12345AK\" OR $emp.EmployeeIDNumber=\"UK12345AL\" OR $emp.EmployeeIDNumber=\"UK12345AM\" OR ";

            sSelectedRecords = sSelectedRecords + "$emp.EmployeeIDNumber=\"UK12345AA\" OR $emp.EmployeeIDNumber=\"UK12345AI\" OR $emp.EmployeeIDNumber=\"UK12345AP\" OR ";
            sSelectedRecords = sSelectedRecords + "$emp.EmployeeIDNumber=\"UK12345BA\" OR $emp.EmployeeIDNumber=\"UK12345BT\" OR $emp.EmployeeIDNumber=\"UK12345CJ\" OR ";
            sSelectedRecords = sSelectedRecords + "$emp.EmployeeIDNumber=\"UK12345CZ\" OR $emp.EmployeeIDNumber=\"UK12345DX\" OR $emp.EmployeeIDNumber=\"UK12345EL\" OR ";
            sSelectedRecords = sSelectedRecords + "$emp.EmployeeIDNumber=\"UK12345FH\" OR $emp.EmployeeIDNumber=\"UK12345FJ\" OR $emp.EmployeeIDNumber=\"UK12345FR\"";



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
            dic.Add("Funding", "False");
            dic.Add("AltFunding1", "False");
            dic.Add("AltFunding2", "False");
            dic.Add("AltFunding3", "False");
            dic.Add("Solvency", "True");
            dic.Add("PPFS179", "False");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "All Benefit Sets");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectRecords", sSelectedRecords);
            dic.Add("Validate", "");
            dic.Add("RunValuation", "");
            pMain._PopVerify_RunOptions(dic);

            mTime.StopTimer(iUser2_FixSolvAgeDiff_RunOption_Edit);
            mLog.LogInfo(iUser2_FixSolvAgeDiff_RunOption_Edit, MyPerformanceCounter.Memory_Private);



            //mTime.StartTimer();
            //mLog.LogInfo(iUser2_FixSolvAgeDiff_ER_ClickRun, DateTime.Now.ToString());
            DateTime _tUser2_FixSolvAgeDiff_ER_ClickRun = DateTime.Now;
            mTime.StartTimer();
            mLog.LogInfo(iUser2_FixSolvAgeDiff_ER_ClickRun, _tUser2_FixSolvAgeDiff_ER_ClickRun.ToString());



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            //////////////dic.Add("CheckPopup", "True");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            mTime.StopTimer(iUser2_FixSolvAgeDiff_RunSubmission);
            mLog.LogInfo(iUser2_FixSolvAgeDiff_RunSubmission, MyPerformanceCounter.Memory_Private);



            //_gLib._CreateDirectory(sOutputDir, false);
            sERDetail = "";

            pMain._SelectTab("Valuation2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "810");
            dic.Add("iPosY", "380");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);




            string sUser2_FixSolvAgeDiff_Persist_80 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5);
            string sUser2_FixSolvAgeDiff_Post_80 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5);
            string sUser2_FixSolvAgeDiff_Persist_60 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5);
            string sUser2_FixSolvAgeDiff_Post_60 = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5);

            DateTime _tUser2_FixSolvAgeDiff_Persist_80 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sUser2_FixSolvAgeDiff_Persist_80, Config.eCountry));
            DateTime _tUser2_FixSolvAgeDiff_Post_80 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sUser2_FixSolvAgeDiff_Post_80, Config.eCountry));
            DateTime _tUser2_FixSolvAgeDiff_Persist_60 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sUser2_FixSolvAgeDiff_Persist_60, Config.eCountry));
            DateTime _tUser2_FixSolvAgeDiff_Post_60 = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(sUser2_FixSolvAgeDiff_Post_60, Config.eCountry));



            string _sUser2_FixSolvAgeDiff_EarliestProcess = pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5);
            string _sUser2_FixSolvAgeDiff_80JobSuccess = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12);
            string _sUser2_FixSolvAgeDiff_60JobSuccess = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 3, 12);
            string _sUser2_FixSolvAgeDiff_GroupJobSuccess = pMain._ER_ReturnRunStatus_TopGrid(11);
            DateTime _tUser2_FixSolvAgeDiff_EarliestProcess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sUser2_FixSolvAgeDiff_EarliestProcess, Config.eCountry));
            DateTime _tUser2_FixSolvAgeDiff_80JobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sUser2_FixSolvAgeDiff_80JobSuccess, Config.eCountry));
            DateTime _tUser2_FixSolvAgeDiff_60JobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sUser2_FixSolvAgeDiff_60JobSuccess, Config.eCountry));
            DateTime _tUser2_FixSolvAgeDiff_GroupJobSuccess = Convert.ToDateTime(DateTimeFormat.changeDateTimeFormatbyCountry(_sUser2_FixSolvAgeDiff_GroupJobSuccess, Config.eCountry));



            mLog.LogInfo(iUser2_FixSolvAgeDiff_GroupID, pMain._ER_ReturnRunStatus_TopGrid(2));
            //mLog.LogInfo(iUser2_FixSolvAgeDiff_Persist_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            //mLog.LogInfo(iUser2_FixSolvAgeDiff_Post_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));
            mLog.LogInfo(iUser2_FixSolvAgeDiff_Persist_80, sUser2_FixSolvAgeDiff_Persist_80);
            mLog.LogInfo(iUser2_FixSolvAgeDiff_Post_80, sUser2_FixSolvAgeDiff_Post_80);

            //mLog.LogInfo(iUser2_FixSolvAgeDiff_Persist_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5));
            //mLog.LogInfo(iUser2_FixSolvAgeDiff_Post_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5));
            mLog.LogInfo(iUser2_FixSolvAgeDiff_Persist_60, sUser2_FixSolvAgeDiff_Persist_60);
            mLog.LogInfo(iUser2_FixSolvAgeDiff_Post_60, sUser2_FixSolvAgeDiff_Post_60);

            //sERDetail = sERDetail + "Earliest Process: " + pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5) + Environment.NewLine;
            //sERDetail = sERDetail + "A_80 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12) + Environment.NewLine;
            //sERDetail = sERDetail + "B_60 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 3, 12) + Environment.NewLine;
            //sERDetail = sERDetail + "Group Job Success: " + pMain._ER_ReturnRunStatus_TopGrid(11) + Environment.NewLine;
            sERDetail = sERDetail + "Earliest Process: " + _sUser2_FixSolvAgeDiff_EarliestProcess + Environment.NewLine;
            sERDetail = sERDetail + "A_80 Job Success: " + _sUser2_FixSolvAgeDiff_80JobSuccess + Environment.NewLine;
            sERDetail = sERDetail + "B_60 Job Success: " + _sUser2_FixSolvAgeDiff_60JobSuccess + Environment.NewLine;
            sERDetail = sERDetail + "Group Job Success: " + _sUser2_FixSolvAgeDiff_GroupJobSuccess + Environment.NewLine;
            mLog.LogInfo(iUser2_FixSolvAgeDiff_ER_Detail, sERDetail);

            sERDetail = "";
            sERDetail = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3) + ": " + Environment.NewLine;
            sERDetail = sERDetail + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 3, 3) + ": ";
            mLog.LogInfo(iUser2_FixSolvAgeDiff_NumOfCores, sERDetail);



            mLog.LogInfo(iJobID_FixSolvAgeDiff_User2_1, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));
            mLog.LogInfo(iJobID_FixSolvAgeDiff_User2_2, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 3, 3));



            TimeSpan _tUser2_FixSolvAgeDiffPersist_80 = _tUser2_FixSolvAgeDiff_Post_80 - _tUser2_FixSolvAgeDiff_Persist_80;
            TimeSpan _tUser2_FixSolvAgeDiffPost_80 = _tUser2_FixSolvAgeDiff_80JobSuccess - _tUser2_FixSolvAgeDiff_Post_80;
            TimeSpan _tUser2_FixSolvAgeDiffPersist_60 = _tUser2_FixSolvAgeDiff_Post_60 - _tUser2_FixSolvAgeDiff_Persist_60;
            TimeSpan _tUser2_FixSolvAgeDiffPost_60 = _tUser2_FixSolvAgeDiff_60JobSuccess - _tUser2_FixSolvAgeDiff_Post_60;

            TimeSpan _tUser2_FixSolvAgeDiffJobSent_Persist = _tUser2_FixSolvAgeDiff_Persist_80 - _tUser2_FixSolvAgeDiff_EarliestProcess;
            TimeSpan _tUser2_FixSolvAgeDiffClickRun_GroupJobStatus = _tUser2_FixSolvAgeDiff_GroupJobSuccess - _tUser2_FixSolvAgeDiff_ER_ClickRun;
            int _tUser2_FixSolvAgeDiffOverall = (_tUser2_FixSolvAgeDiffClickRun_GroupJobStatus.Hours * 3600 + _tUser2_FixSolvAgeDiffClickRun_GroupJobStatus.Minutes * 60 + _tUser2_FixSolvAgeDiffClickRun_GroupJobStatus.Seconds) - (_tUser2_FixSolvAgeDiffJobSent_Persist.Hours * 3600 + _tUser2_FixSolvAgeDiffJobSent_Persist.Minutes * 60 + _tUser2_FixSolvAgeDiffJobSent_Persist.Seconds);

            mLogTime.LogInfo(iUser2_FixSolvAgeDiff_Persist_80, Convert.ToString(_tUser2_FixSolvAgeDiffPersist_80.Hours * 3600 + _tUser2_FixSolvAgeDiffPersist_80.Minutes * 60 + _tUser2_FixSolvAgeDiffPersist_80.Seconds));
            mLogTime.LogInfo(iUser2_FixSolvAgeDiff_Post_80, Convert.ToString(_tUser2_FixSolvAgeDiffPost_80.Hours * 3600 + _tUser2_FixSolvAgeDiffPost_80.Minutes * 60 + _tUser2_FixSolvAgeDiffPost_80.Seconds));
            mLogTime.LogInfo(iUser2_FixSolvAgeDiff_Persist_60, Convert.ToString(_tUser2_FixSolvAgeDiffPersist_60.Hours * 3600 + _tUser2_FixSolvAgeDiffPersist_60.Minutes * 60 + _tUser2_FixSolvAgeDiffPersist_60.Seconds));
            mLogTime.LogInfo(iUser2_FixSolvAgeDiff_Post_60, Convert.ToString(_tUser2_FixSolvAgeDiffPost_60.Hours * 3600 + _tUser2_FixSolvAgeDiffPost_60.Minutes * 60 + _tUser2_FixSolvAgeDiffPost_60.Seconds));

            mLogTime.LogInfo(iUser2_FixSolvAgeDiff_ER_ClickRun, Convert.ToString(_tUser2_FixSolvAgeDiffOverall));


            pMain._SelectTab("Valuation2012");


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "810");
            dic.Add("iPosY", "370");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_UnlockFundingCalculator(dic);

            pMain._SelectTab("Assumptions");


            mTime.StopTimer(iUser2_FixSolvAgeDiff_OpenNodeInEdit);
            mLog.LogInfo(iUser2_FixSolvAgeDiff_OpenNodeInEdit, MyPerformanceCounter.Memory_Private);




            mTime.StartTimer();



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Funding");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            mTime.StopTimer(iUser2_FixSolvAgeDiff_InterestRate_Select);
            mLog.LogInfo(iUser2_FixSolvAgeDiff_InterestRate_Select, MyPerformanceCounter.Memory_Private);

            pMain._SelectTab("Valuation2012");


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "810");
            dic.Add("iPosY", "370");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

            pMain._SelectTab("Provisions");


            mTime.StopTimer(iUser2_FixSolvAgeDiff_ProvisionOpenInEdit);
            mLog.LogInfo(iUser2_FixSolvAgeDiff_ProvisionOpenInEdit, MyPerformanceCounter.Memory_Private);




            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActStandardRet");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            mTime.StopTimer(iUser2_FixSolvAgeDiff_TrancheBenefit_Select);
            mLog.LogInfo(iUser2_FixSolvAgeDiff_TrancheBenefit_Select, MyPerformanceCounter.Memory_Private);

            pMain._SelectTab("Valuation2012");


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Valuation2012");
            mTime.StopTimer(iUser2_FixSolvAgeDiff_Save);
            mLog.LogInfo(iUser2_FixSolvAgeDiff_Save, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "810");
            dic.Add("iPosY", "370");
            dic.Add("MenuItem_1", "View Output");
            dic.Add("CheckOMSetupPopup", "False");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");

            mTime.StopTimer(iUser2_FixSolvAgeDiff_OutputManager_Open);
            mLog.LogInfo(iUser2_FixSolvAgeDiff_OutputManager_Open, MyPerformanceCounter.Memory_Private);



            pMain._SelectTab("Output Manager");
            mTime.StartTimer();

            pOutputManager._Navigate(Config.eCountry, "Reconciliation to Prior Year", "RollForward", true);
            pOutputManager._WaitForLoading();
            pOutputManager._SelectTab("Reconciliation to Prior Year");

            WinWindow wWin1 = new WinWindow(pOutputManager.wRetirementStudio);
            wWin1.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);
            wWin1.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.STATIC", PropertyExpressionOperator.Contains);
            UITestControlCollection uiCollection1 = wWin1.FindMatchingControls();
            WinText wText1 = new WinText((WinWindow)uiCollection1[0]);
            wText1.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);
            WinHyperlink wLink1 = new WinHyperlink(wText1);
            wLink1.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);

            _gLib._SetSyncUDWin(wLink1.Name, wLink1, "Click", 0);

            pOutputManager._SelectTab("Reconciliation to Prior Year - Funding");
            pOutputManager._WaitForLoading();


            mTime.StopTimer(iUser2_FixSolvAgeDiff_ReconciliationToPriorYear_Open);
            mLog.LogInfo(iUser2_FixSolvAgeDiff_ReconciliationToPriorYear_Open, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pOutputManager._ExportItem("Reconciliation to Prior Year", false);

            pOutputManager._SaveAs(sOutputDir + "ReconciliationToPriorYear_Funding.xls");

            _gLib._FileExists(sOutputDir + "ReconciliationToPriorYear_Funding.xlsx", Config.iTimeout / 20, true);

            _gLib._SetSyncUDWin("Close", pOutputManager.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);


            mTime.StopTimer(iUser2_FixSolvAgeDiff_ReconciliationToPriorYear_Export);
            mLog.LogInfo(iUser2_FixSolvAgeDiff_ReconciliationToPriorYear_Export, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Valuation2012");

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation2012");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            mTime.StopTimer(iUser2_OpenServiceAgain);
            mLog.LogInfo(iUser2_OpenServiceAgain, MyPerformanceCounter.Memory_Private);

            mLog.LogInfo(iTimeEnd_User2, DateTime.Now.ToString());

            #endregion




            mLog.LogInfo(iTimeEnd_Overall, DateTime.Now.ToString());


            _gLib._MsgBox("Congratulations!", "Finished!");

            Environment.Exit(0);

        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {

            //mLog.LogInfo(iTest, MyPerformanceCounter.Memory_Private);

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
