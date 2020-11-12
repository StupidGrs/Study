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



namespace RetirementStudio._TestScripts._TestScripts_Timing
{
    /// <summary>
    /// Summary description for UK_Timing_Regular
    /// </summary>
    [CodedUITest]
    public class UK_Timing_Regular
    {
        public UK_Timing_Regular()
        {

            Config.eEnv = _TestingEnv.Prod_EU;
            Config.eCountry = _Country.UK;
            Config.sStudioLaunchDir = @"C:\Users\webber-ling\Desktop\Retirement Studio-Canada - 1 .appref-ms";
            //Config.sStudioLaunchDir = @"C:\Users\webber-ling\Desktop\EUProd7401\Client\RetirementStudio.exe";
            //Config.sClientName = "UK Performance Test 20131206 E"; // EU Prod Client
            //Config.sClientName = "UK Performance Test 20131206 B"; // EU Prod Client
            Config.sClientName = "UK Performance Client"; // CA Prod Client
            //Config.sClientName = "UK Performance Test D"; // US Prod Client

            //Config.sClientName = "UK_Performance_Test_COLA_MemoryLeak"; // QA1 client because "UK_Performance_Test_20131206" is broken....
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
        static string sLogFile = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\UK_Timing_Test\UK_Timing_Test_CUIT.xls";
        static string sOutputDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\UK_Timing_Test\Reports_KeepUpdateOnRun\";
        MyTimer mTime = new MyTimer(sCol_Time, sLogFile);
        MyLog mLog = new MyLog(sCol_Memory, sLogFile);

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
        public void test_UK_Timing_Regular()
        {





            _gLib._StudioClearCache();   //////////_gLib._MsgBox("Warning!", "Please Clear Cache!");

            pMain._SetLanguageAndRegional();


            #region User1 - Launch Studio & Open Service

            mLog.LogInfo(iTimeStart_Overall, DateTime.Now.ToString());


            mTime.StartTimer();

            _gLib._Cmd(Config.sStudioLaunchDir);

            pMain._SelectTab("Home");
            mTime.StopTimer(iLaunchStudio);
            mLog.LogInfo(iLaunchStudio, MyPerformanceCounter.Memory_Private);


            ////////////////////////_gLib._MsgBox("Warning!", "Please manually select the Client in Studio-> Home -> All Services -> " + Config.sClientName + Environment.NewLine + Environment.NewLine
            ////////////////////////    + "Click OK to keep testing!");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            _gLib._KillProcessByName("Mercer.RetirementStudio.Messaging.MessagingClientApp");



            mLog.LogInfo(iTimeStart_User1, DateTime.Now.ToString());

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation2012");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            mTime.StopTimer(iOpenService);
            mLog.LogInfo(iOpenService, MyPerformanceCounter.Memory_Private);

            _gLib._MsgBox("Warning!", "Please manually expand the flow tree to make it big enough to hold all nodes.");

            #endregion




            #region  User1 - 0 % Run for FSG Cashflow - Node 1

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


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("MenuItem", "Use Alternative Basis Folders");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDecrementRate", "");
            dic.Add("PreCommencementRate", "4.9");
            dic.Add("PostCommencementRate", "4.9");
            pInterestRate._PopVerify_PreDecrementPrePostCommencement(dic);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "RPIInflationAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            mTime.StopTimer(i0PercentRunForFSGCashflow_CustomRates_Select);
            mLog.LogInfo(i0PercentRunForFSGCashflow_CustomRates_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

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

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Assumptions");
            mTime.StopTimer(i0PercentRunForFSGCashflow_CustomRates_Save);
            mLog.LogInfo(i0PercentRunForFSGCashflow_CustomRates_Save, MyPerformanceCounter.Memory_Private);



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



            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryInflationAssumption");
            dic.Add("MenuItem", "Use Alternative Basis Folders");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryInflationAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Assumptions");
            mTime.StopTimer(i0PercentRunForFSGCashflow_PayIncrease_Add);
            mLog.LogInfo(i0PercentRunForFSGCashflow_PayIncrease_Add, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustment", "False");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "Click");
            dic.Add("btnT", "");
            dic.Add("txtRate", "1.0");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);

            pMain._SelectTab("Assumptions");
            mTime.StopTimer(i0PercentRunForFSGCashflow_PayIncrease_Edit);
            mLog.LogInfo(i0PercentRunForFSGCashflow_PayIncrease_Edit, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Assumptions");
            mTime.StopTimer(i0PercentRunForFSGCashflow_PayIncrease_Save);
            mLog.LogInfo(i0PercentRunForFSGCashflow_PayIncrease_Save, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("MenuItem", "Use Alternative Basis Folders");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            pMain._SelectTab("Assumptions");
            mTime.StopTimer(i0PercentRunForFSGCashflow_OtherEconomicAssumptions_Add);
            mLog.LogInfo(i0PercentRunForFSGCashflow_OtherEconomicAssumptions_Add, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


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

            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Assumptions");
            mTime.StopTimer(i0PercentRunForFSGCashflow_OtherEconomicAssumptions_Save);
            mLog.LogInfo(i0PercentRunForFSGCashflow_OtherEconomicAssumptions_Save, MyPerformanceCounter.Memory_Private);

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



            ////////////mTime.StartTimer();

            ////////////dic.Clear();
            ////////////dic.Add("Level_1", "A_80ths_Structure");
            ////////////dic.Add("Level_2", "Participant Info");
            ////////////dic.Add("Level_3", "Pay Projection");
            ////////////dic.Add("Level_4", "ContSalProjSPPadj");
            ////////////dic.Add("MenuItem", "Add Condition");
            ////////////pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            ////////////mTime.StopTimer(i0PercentRunForFSGCashflow_PayProjection_Add);
            ////////////mLog.LogInfo(i0PercentRunForFSGCashflow_PayProjection_Add, MyPerformanceCounter.Memory_Private);


            ////////////mTime.StartTimer();

            ////////////dic.Clear();
            ////////////dic.Add("PopVerify", "Pop");
            ////////////dic.Add("History", "");
            ////////////dic.Add("PresentYear", "");
            ////////////dic.Add("FunctionOfOtherProjections", "");
            ////////////dic.Add("CustomCode", "True");
            ////////////dic.Add("PlanPayLimitDefinition", "");
            ////////////dic.Add("ApplyDeduction", "");
            ////////////dic.Add("LegislatedPayLimitDefinition", "");
            ////////////pPayoutProjection._PopVerify_Main(dic);

            ////////////dic.Clear();
            ////////////dic.Add("PopVerify", "Pop");
            ////////////dic.Add("iRow", "");
            ////////////dic.Add("Name", "");
            ////////////dic.Add("Expression", "0");
            ////////////dic.Add("Validate", "Click");
            ////////////pAssumptions._PopVerify_Provision_CustomCode(dic);

            ////////////pAssumptions._SelectTab("Conditions");


            ////////////////////_gLib._Exists("Condition", pAssumptions.wRetirementStudio.wValidate, Config.iTimeout * 10, false);


            ////////////dic.Clear();
            ////////////dic.Add("PopVerify", "Pop");
            ////////////dic.Add("PreDefinedEligibility", "");
            ////////////dic.Add("cboPreDefinedEligibility", "");
            ////////////dic.Add("LocalEligibility", "");
            ////////////dic.Add("txtLocalEligibility", "FixForStudioAmends");
            ////////////dic.Add("AddToEligibilities", "");
            ////////////dic.Add("EligibilityCondition", "$emp.FTEfor80thsPriorYear1<=0");
            ////////////dic.Add("Validate", "Click");
            ////////////pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            ////////////mTime.StopTimer(i0PercentRunForFSGCashflow_PayProjection_Edit);
            ////////////mLog.LogInfo(i0PercentRunForFSGCashflow_PayProjection_Edit, MyPerformanceCounter.Memory_Private);



            ////////////mTime.StartTimer();

            ////////////pMain._Home_ToolbarClick_Top(true);

            ////////////pMain._SelectTab("Provisions");
            ////////////mTime.StopTimer(i0PercentRunForFSGCashflow_PayProjection_Save);
            ////////////mLog.LogInfo(i0PercentRunForFSGCashflow_PayProjection_Save, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "GMP Adjustment Factors");
            dic.Add("Level_4", "GMPrevaluation");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(i0PercentRunForFSGCashflow_GMPAdjustment_Select);
            mLog.LogInfo(i0PercentRunForFSGCashflow_GMPAdjustment_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


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
            mTime.StopTimer(i0PercentRunForFSGCashflow_GMPAdjustment_Edit);
            mLog.LogInfo(i0PercentRunForFSGCashflow_GMPAdjustment_Edit, MyPerformanceCounter.Memory_Private);

            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(i0PercentRunForFSGCashflow_GMPAdjustment_Save);
            mLog.LogInfo(i0PercentRunForFSGCashflow_GMPAdjustment_Save, MyPerformanceCounter.Memory_Private);



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



            mTime.StartTimer();
            mLog.LogInfo(i0PercentRunForFSGCashflow_ER_ClickRun, DateTime.Now.ToString());

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


            #region  User1 - 0 % Run for FSG Cashflow2 - Node 2 - No Timing

            pMain._SelectTab("Valuation2012");

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
            dic.Add("ValNodeName", "0 Pst run for FSG cashflows2");
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
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("Pay", "FTE80thsPayProj");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("PayoutProjectionCustomGroup", "BenefitSetShortName");
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
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            #endregion


            #region User1 - 2.5 % Run for FSG Cashflow - Node 3 - No Timing


            pMain._SelectTab("Valuation2012");

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
            dic.Add("ValNodeName", "2.5 Pst run for FSG cashflows");
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



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "280");
            dic.Add("iPosY", "380");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");

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

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryInflationAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustment", "False");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "Click");
            dic.Add("btnT", "");
            dic.Add("txtRate", "3.5");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);


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
            dic.Add("S148Inc_txt", "3.5");
            dic.Add("LimmGMPRate_txt", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_UK(dic);

            pMain._Home_ToolbarClick_Top(true);



            pMain._SelectTab("Valuation2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "280");
            dic.Add("iPosY", "380");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);

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
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);



            #endregion


            #region User1 - 3.0 % Run for FSG Cashflow - Node 4 - No Timing


            pMain._SelectTab("Valuation2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "280");
            dic.Add("iPosY", "380");
            dic.Add("MenuItem_1", "Add Valuation Node");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "3.0 Pst run for FSG cashflows");
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


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "200");
            dic.Add("iPosY", "430");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");


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
            dic.Add("Level_3", "Pst88GMPinPaymentAssumption");
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
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryInflationAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustment", "False");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "Click");
            dic.Add("btnT", "");
            dic.Add("txtRate", "4.0");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);


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
            dic.Add("S148Inc_txt", "4.0");
            dic.Add("LimmGMPRate_txt", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_UK(dic);

            pMain._Home_ToolbarClick_Top(true);




            pMain._SelectTab("Valuation2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "200");
            dic.Add("iPosY", "430");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


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
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            #endregion


            #region User1 - 6.0 % Run for FSG Cashflow - Node 5 - No Timing


            pMain._SelectTab("Valuation2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "200");
            dic.Add("iPosY", "430");
            dic.Add("MenuItem_1", "Add Valuation Node");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "6.0 Pst run for FSG cashflows");
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


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "200");
            dic.Add("iPosY", "490");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");


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
            dic.Add("txtRate", "7.0");
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
            dic.Add("txtRate", "6.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryInflationAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustment", "False");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "Click");
            dic.Add("btnT", "");
            dic.Add("txtRate", "7.0");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);


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
            dic.Add("S148Inc_txt", "3.5");
            dic.Add("LimmGMPRate_txt", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_UK(dic);

            pMain._Home_ToolbarClick_Top(true);




            pMain._SelectTab("Valuation2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "200");
            dic.Add("iPosY", "490");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


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
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            #endregion


            #region User1 - 6.0 % Run for FSG Cashflow2 - Node 6 - No Timing


            pMain._SelectTab("Valuation2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "200");
            dic.Add("iPosY", "490");
            dic.Add("MenuItem_1", "Add Valuation Node");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "6.0 Pst run for FSG cashflows2");
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


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "200");
            dic.Add("iPosY", "550");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


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
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            #endregion


            #region  User1 - RPM3 - Node 7 - No Timing


            pMain._SelectTab("Valuation2012");


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
            dic.Add("ValNodeName", "RPM3");
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


            pMain._SelectTab("Valuation2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "280");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Pay Projection");
            dic.Add("Level_4", "ContSalProjSPPadj");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "");
            dic.Add("CustomCode", "True");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "");
            dic.Add("LegislatedPayLimitDefinition", "");
            pPayoutProjection._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "FTEfor80thsPriorYear_LTE_Zero");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.FTEfor80thsPriorYear1<=0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");


            pMain._SelectTab("Valuation2012");


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
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "False");
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
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);





            #endregion


            #region  User1 - CNS - Node 8


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
            dic.Add("ValNodeName", "CNS");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "True");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "True");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "True");
            dic.Add("Provisions_Name", "CNS  Provisions");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);



            pMain._SelectTab("Valuation2012");

            mTime.StopTimer(iCNS_AddNode);
            mLog.LogInfo(iCNS_AddNode, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "400");
            dic.Add("iPosY", "320");
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
            dic.Add("SnapshotName", "2012 Snapshot CNS");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "True");
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

            pMain._SelectTab("Participant DataSet");

            mTime.StopTimer(iCNS_ImportData);
            mLog.LogInfo(iCNS_ImportData, MyPerformanceCounter.Memory_Private);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "400");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Provisions");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "EnhancedIHServ");
            dic.Add("Level_5", "EnhancementBand2");
            pAssumptions._TreeViewSelect(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "EnhancementBand2others");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$TotalQualServ>=5 and $TotalQualServ<10 and $emp.Employer<>\"CNS\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            mTime.StopTimer(iCNS_Service_Edit);
            mLog.LogInfo(iCNS_Service_Edit, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "EnhancedIHServ");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "True");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            dic.Add("ForInternationalAccounting_DE", "");
            dic.Add("ForTrade_DE", "");
            dic.Add("CalculateExactServiceAtReitermentAge_UK", "");
            pService._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Min($TotalQualServ*2,$ProjServiceTo65)-$emp.CPSreckServ+$ReckServPst10");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "EnhancementBand2CNS");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$TotalQualServ>=5 and $TotalQualServ<10 and $emp.Employer=\"CNS\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "ContsFor80ths");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(iCNS_EmployeeContributionsFormula_Select);
            mLog.LogInfo(iCNS_EmployeeContributionsFormula_Select, MyPerformanceCounter.Memory_Private);

            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);


            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "ContsFor80ths");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "Click");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "ContribsWInterest1");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "Click");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "2.5");
            dic.Add("ProjectedPay", "ContSalProjSPPadj");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.05");


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "CNSmembs");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Employer=\"CNS\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            mTime.StopTimer(iCNS_EmployeeContributionsFormula_Edit);
            mLog.LogInfo(iCNS_EmployeeContributionsFormula_Edit, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(iCNS_EmployeeContributionsFormula_Save);
            mLog.LogInfo(iCNS_EmployeeContributionsFormula_Save, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "PUemployeeConts");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);


            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "PUemployeeConts");
            dic.Add("Level_6", "EDTmembs");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "Click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);


            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "PUemployeeConts");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "Click");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "Click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "PUstopAge");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "Click");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "0.0");
            dic.Add("ProjectedPay", "ContSalProjSPPadj");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.05");


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "CNSmembs");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Employer=\"CNS\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "PU1pcPayroll");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);


            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "PU1pcPayroll");
            dic.Add("Level_6", "EDTmembs");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "Click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);


            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "PU1pcPayroll");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "Click");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "Click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "PUstopAge");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "Click");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "0.0");
            dic.Add("ProjectedPay", "ContSalProjSPPadj");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.01");


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "CNSmembs");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Employer=\"CNS\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "EDTemployeeConts");
            dic.Add("Level_6", "EDTmembs");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);




            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "UUKemployeeConts");
            dic.Add("Level_6", "UUKmembs");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "Click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);



            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "ETUKemployeeConts");
            dic.Add("Level_6", "ETUKmembs");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "Click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);



            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "CHEMemployeeConts");
            dic.Add("Level_6", "CHEMmembs");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "Click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);



            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "ULTDemployeeConts");
            dic.Add("Level_6", "ULTDmembs");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "Click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);



            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "EDT1pcPayroll");
            dic.Add("Level_6", "EDTmembs");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "Click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);



            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "UUK1pcPayroll");
            dic.Add("Level_6", "UUKmembs");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "Click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);




            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "ETUK1pcPayroll");
            dic.Add("Level_6", "ETUKmembs");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "Click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);


            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "CHEM1pcPayroll");
            dic.Add("Level_6", "CHEMmembs");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "Click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);



            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "ULTD1pcPayroll");
            dic.Add("Level_6", "ULTDmembs");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "Click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);



            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "UECemployeeConts");
            dic.Add("Level_6", "UECmembs");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "Click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);




            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "UEC1pcPayroll");
            dic.Add("Level_6", "UECmembs");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "Click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);


            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("MenuItem", "Add Employee Contributions Formula");
            pAssumptions._TreeViewRightSelect(dic, "CNSemployeeConts");

            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "CNSemployeeConts");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "True");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "CNSemployeeConts");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "Click");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "Click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "PUstopAge");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "Click");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "ContSalProjSPPadj");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.05");


            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "True");
            dic.Add("txtLocalEligibility", "CNSmembs");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Employer=\"CNS\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("MenuItem", "Add Employee Contributions Formula");
            pAssumptions._TreeViewRightSelect(dic, "CNS1pcPayroll");

            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "CNS1pcPayroll");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "True");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "CNS1pcPayroll");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "Click");
            dic.Add("StartingBalance_cbo", "");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "Click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "PUstopAge");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("ContributionsMade", "Monthly");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "Click");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "ContributionSalProj");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.01");


            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "True");
            dic.Add("txtLocalEligibility", "CNSmembs");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Employer=\"CNS\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "SpousesProportion");

            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "SpousesProportion");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(iCNS_CustomFormulaB_Select);
            mLog.LogInfo(iCNS_CustomFormulaB_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0.5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "SpousesProportion");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0.5714");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "True");
            dic.Add("txtLocalEligibility", "CNSmembs");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Employer=\"CNS\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            mTime.StopTimer(iCNS_CustomFormulaB_Edit);
            mLog.LogInfo(iCNS_CustomFormulaB_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();
            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(iCNS_CustomFormulaB_Save);
            mLog.LogInfo(iCNS_CustomFormulaB_Save, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "CNStotalDISLS");

            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "CNStotalDISLS");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "(2*$FTE80thsPayAverage)-0.95*(1.5/80*$FTE80thsPayAverage*($EnhancedIHServ-$ReckServPst10))");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "CNStotalDISLS");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "(2*$FTE80thsPayAverage)-0.92*(1.5/80*$FTE80thsPayAverage*($EnhancedIHServ-$ReckServPst10))");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "True");
            dic.Add("txtLocalEligibility", "Females");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"F\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "COLApst10");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            pMain._SelectTab("Provisions");
            mTime.StopTimer(iCNS_CostOfLiving_Select);
            mLog.LogInfo(iCNS_CostOfLiving_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

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
            dic.Add("Revaluation_Rate_V_cbo", "RPIInflationAssumption");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "Click");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "05/04/2012");
            dic.Add("Increase_Ends_YearsFrom", "");
            dic.Add("Increase_Ends_Date_V", "");
            dic.Add("Increase_Ends_Date_D", "");
            dic.Add("Increase_Ends_Date_V_cbo", "");
            dic.Add("Increase_Ends_Date_D_txt", "");
            dic.Add("Increase_Amount_Rate_V", "Click");
            dic.Add("Increase_Amount_Rate_P", "");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "RPIInflationAssumption");
            dic.Add("Increase_Amount_Rate_P_txt", "");
            dic.Add("Increase_Amount_Rate_T_cbo", "");
            dic.Add("Increase_Pension", "");
            pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic);


            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "True");
            dic.Add("txtLocalEligibility", "CNSmembs");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Employer=\"CNS\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            mTime.StopTimer(iCNS_CostOfLiving_Edit);
            mLog.LogInfo(iCNS_CostOfLiving_Edit, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();
            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(iCNS_CostOfLiving_Save);
            mLog.LogInfo(iCNS_CostOfLiving_Save, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActStandardRet");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            mTime.StopTimer(iCNS_TranchedBenefit_Select);
            mLog.LogInfo(iCNS_TranchedBenefit_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "4");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);

            mTime.StopTimer(iCNS_TranchedBenefit_Edit);
            mLog.LogInfo(iCNS_TranchedBenefit_Edit, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();
            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(iCNS_TranchedBenefit_Save);
            mLog.LogInfo(iCNS_TranchedBenefit_Save, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActWithdrawal");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "4");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);



            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActWithdrawalDID");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "4");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);



            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActIH");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "4");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);




            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActDIS");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "4");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);




            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "DefStandard");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "4");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Deferred(dic);




            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "DefDID");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "4");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Deferred(dic);



            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "PenStandard");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("BaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "PensionerStopAge");
            dic.Add("IncreasesInPayment", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Pensioner(dic);


            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "PensionerStopAge");
            dic.Add("IncreasesInPayment", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Pensioner(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("BaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "PensionerStopAge");
            dic.Add("IncreasesInPayment", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Pensioner(dic);


            /////////////////////_gLib._MsgBox("Manually Interaction, bug exists here!", "Please select <PenionerStopAge> for row BenefitStopAge, columns Pre1997 & Pst1997Pre2010 ");



            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActSpDARwithLoading");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "4");
            dic.Add("iCol_Total", "4");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Active(dic);





            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "DefSpDARwithLoading");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Deferred(dic);


            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Deferred(dic);


            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Deferred(dic);



            dic.Clear();
            dic.Add("iCol", "4");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "SpousesProportion");
            pTranchedBenefit._TBL_Deferred(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");



            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "ActDISLS");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");


            mTime.StopTimer(iCNS_NonTranchBenefitPlanDefinition_Select);
            mLog.LogInfo(iCNS_NonTranchBenefitPlanDefinition_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "");
            dic.Add("ParticipantType", "");
            dic.Add("NonTranchedBenefit", "CNStotalDISLS");
            dic.Add("DefineAccruedBenefitAsZero", "True");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "Lumpsum");
            dic.Add("Decrement", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);



            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "True");
            dic.Add("txtLocalEligibility", "CNSmembs");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Employer=\"CNS\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            mTime.StopTimer(iCNS_NonTranchBenefitPlanDefinition_Edit);
            mLog.LogInfo(iCNS_NonTranchBenefitPlanDefinition_Edit, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(iCNS_NonTranchBenefitPlanDefinition_Save);
            mLog.LogInfo(iCNS_NonTranchBenefitPlanDefinition_Save, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "400");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Methods");
            mTime.StopTimer(iCNS_Methods_Select);
            mLog.LogInfo(iCNS_Methods_Select, MyPerformanceCounter.Memory_Private);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "");
            dic.Add("PayProjection", "");
            dic.Add("EmployeeContribution", "CNS1pcPayroll");
            dic.Add("StopPVFuture", "");
            pMethods_UK._AdditionalCalcuationRequest_Grid(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "");
            dic.Add("PayProjection", "");
            dic.Add("EmployeeContribution", "CNSemployeeConts");
            dic.Add("StopPVFuture", "");
            pMethods_UK._AdditionalCalcuationRequest_Grid(dic);


            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("BenefitSet", "");
            dic.Add("PayProjection", "");
            dic.Add("EmployeeContribution", "ContsFor60ths");
            dic.Add("StopPVFuture", "");
            pMethods_UK._AdditionalCalcuationRequest_Grid(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("BenefitSet", "");
            dic.Add("PayProjection", "");
            dic.Add("EmployeeContribution", "PU1pcPayroll");
            dic.Add("StopPVFuture", "");
            pMethods_UK._AdditionalCalcuationRequest_Grid(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("BenefitSet", "");
            dic.Add("PayProjection", "");
            dic.Add("EmployeeContribution", "PUemployeeConts");
            dic.Add("StopPVFuture", "");
            pMethods_UK._AdditionalCalcuationRequest_Grid(dic);



            mTime.StopTimer(iCNS_Methods_Edit);
            mLog.LogInfo(iCNS_Methods_Edit, MyPerformanceCounter.Memory_Private);




            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Methods");
            mTime.StopTimer(iCNS_Methods_Save);
            mLog.LogInfo(iCNS_Methods_Save, MyPerformanceCounter.Memory_Private);


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



            mTime.StartTimer();
            mLog.LogInfo(iCNS_ER_ClickRun, DateTime.Now.ToString());

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



            #region User1 - CMI 1.5%, new ret, 2.25% infl - Node 9 - No Timing


            pMain._SelectTab("Valuation2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "270");
            dic.Add("iPosY", "265");
            dic.Add("MenuItem_1", "Add Valuation Node");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "CMI1.5, new ret, -0.25 infl");
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
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Assumptions");

            pMain._SelectTab("Valuation2012");


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
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "False");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "False");
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
            dic.Add("SelectRecords", "");
            dic.Add("Validate", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            #endregion


            #region User1 - CMI 1.5%, new ret, 0.5% RSG - Node 10 - No Timing


            pMain._SelectTab("Valuation2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "270");
            dic.Add("iPosY", "265");
            dic.Add("MenuItem_1", "Add Valuation Node");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "CMI1.5, new ret, 0.5 RSG");
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

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "600");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryInflationAssumption");
            dic.Add("Level_4", "AltFund3");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustment", "");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "");
            dic.Add("btnT", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "");
            dic.Add("Adjustment1_P", "Click");
            dic.Add("Adjustment1_txt_P", "0.5");
            pPayIncrease._PopVerify_Adjustment(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryInflationAssumption");
            dic.Add("Level_4", "AltFund2");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustment", "");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "");
            dic.Add("btnT", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "");
            dic.Add("Adjustment1_P", "Click");
            dic.Add("Adjustment1_txt_P", "0.5");
            pPayIncrease._PopVerify_Adjustment(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryInflationAssumption");
            dic.Add("Level_4", "AltFund1");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustment", "");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "");
            dic.Add("btnT", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "");
            dic.Add("Adjustment1_P", "Click");
            dic.Add("Adjustment1_txt_P", "0.5");
            pPayIncrease._PopVerify_Adjustment(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryInflationAssumption");
            dic.Add("Level_4", "Funding");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustment", "");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "");
            dic.Add("btnT", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "");
            dic.Add("Adjustment1_P", "Click");
            dic.Add("Adjustment1_txt_P", "0.5");
            pPayIncrease._PopVerify_Adjustment(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Funding");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("SalCapInc_P", "Click");
            dic.Add("S148Inc_P", "Click");
            dic.Add("LimmGMPRate_P", "Click");
            dic.Add("SalCapInc_txt", "");
            dic.Add("S148Inc_txt", "3.75");
            dic.Add("LimmGMPRate_txt", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_UK(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "AltFund1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("SalCapInc_P", "Click");
            dic.Add("S148Inc_P", "Click");
            dic.Add("LimmGMPRate_P", "Click");
            dic.Add("SalCapInc_txt", "");
            dic.Add("S148Inc_txt", "3.75");
            dic.Add("LimmGMPRate_txt", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_UK(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "AltFund2");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("SalCapInc_P", "Click");
            dic.Add("S148Inc_P", "Click");
            dic.Add("LimmGMPRate_P", "Click");
            dic.Add("SalCapInc_txt", "");
            dic.Add("S148Inc_txt", "3.75");
            dic.Add("LimmGMPRate_txt", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_UK(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "AltFund3");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("SalCapInc_P", "Click");
            dic.Add("S148Inc_P", "Click");
            dic.Add("LimmGMPRate_P", "Click");
            dic.Add("SalCapInc_txt", "");
            dic.Add("S148Inc_txt", "3.75");
            dic.Add("LimmGMPRate_txt", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_UK(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Assumptions");



            pMain._SelectTab("Valuation2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "600");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "False");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "False");
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
            dic.Add("AltFunding1", "True");
            dic.Add("AltFunding2", "True");
            dic.Add("AltFunding3", "True");
            dic.Add("Solvency", "False");
            dic.Add("PPFS179", "False");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VOOFF", "All Benefit Sets");
            dic.Add("SelectVOs_VO1", "B_60ths_Structure");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectRecords", "");
            dic.Add("Validate", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            #endregion


            #region User1 - 1% pst ret AoA - Node 11 - No Timing


            pMain._SelectTab("Valuation2012");



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "340");
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



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "740");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");

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


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryInflationAssumption");
            dic.Add("Level_4", "AltFund3");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustment", "");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "");
            dic.Add("btnT", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "");
            dic.Add("Adjustment1_P", "Click");
            dic.Add("Adjustment1_txt_P", "1.0");
            pPayIncrease._PopVerify_Adjustment(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "AltFund3");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("SalCapInc_P", "Click");
            dic.Add("S148Inc_P", "Click");
            dic.Add("LimmGMPRate_P", "Click");
            dic.Add("SalCapInc_txt", "");
            dic.Add("S148Inc_txt", "4.25");
            dic.Add("LimmGMPRate_txt", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_UK(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Valuation2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "740");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "False");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "False");
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
            dic.Add("AltFunding1", "True");
            dic.Add("AltFunding2", "True");
            dic.Add("AltFunding3", "True");
            dic.Add("Solvency", "False");
            dic.Add("PPFS179", "False");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "All Benefit Sets");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectRecords", "");
            dic.Add("Validate", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);




            #endregion


            #region User1 - 0.5% pst ret AoA - Node 12 - No Timing


            pMain._SelectTab("Valuation2012");



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "740");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Add Valuation Node");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "0.5 Pst ret AoA");
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



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "680");
            dic.Add("iPosY", "370");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Funding");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDecrementRate", "");
            dic.Add("PreCommencementRate", "6.4");
            dic.Add("PostCommencementRate", "3.9");
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
            dic.Add("PreCommencementRate", "6.9");
            dic.Add("PostCommencementRate", "3.9");
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
            dic.Add("PreCommencementRate", "7.4");
            dic.Add("PostCommencementRate", "3.9");
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
            dic.Add("PreCommencementRate", "7.9");
            dic.Add("PostCommencementRate", "3.9");
            pInterestRate._PopVerify_PreDecrementPrePostCommencement(dic);


            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Valuation2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "680");
            dic.Add("iPosY", "370");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "False");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "False");
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
            dic.Add("AltFunding1", "True");
            dic.Add("AltFunding2", "True");
            dic.Add("AltFunding3", "True");
            dic.Add("Solvency", "False");
            dic.Add("PPFS179", "False");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "All Benefit Sets");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectRecords", "");
            dic.Add("Validate", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);




            #endregion


            #region User1 - Test Individual Output - Node 13


            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "680");
            dic.Add("iPosY", "380");
            dic.Add("MenuItem_1", "Add Valuation Node");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Test Individual Output");
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


            pMain._SelectTab("Valuation2012");

            mTime.StopTimer(iTestIndividualOutput_AddNode);
            mLog.LogInfo(iTestIndividualOutput_AddNode, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "550");
            dic.Add("iPosY", "430");
            dic.Add("MenuItem_1", "Individual Output");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);

            _gLib._Exists("", pMain.wIndividualOutputFieldDefinition, Config.iTimeout * 3, true);

            mTime.StopTimer(iTestIndividualOutput_IndivdualOutput_Select);
            mLog.LogInfo(iTestIndividualOutput_IndivdualOutput_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllLiabilityTypes", "False");
            dic.Add("Funding", "True");
            dic.Add("AddRow", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_IndividualOutputFieldDefinition(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "All");
            dic.Add("OutputLabel", "PU1pcPayroll");
            pMain._TBL_IndividualOututFieldDefinition_OutputFields(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "");
            dic.Add("AddRow", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_IndividualOutputFieldDefinition(dic);


            pMain._SelectTab("Valuation2012");

            mTime.StopTimer(iTestIndividualOutput_IndivdualOutput_Edit);
            mLog.LogInfo(iTestIndividualOutput_IndivdualOutput_Edit, MyPerformanceCounter.Memory_Private);

            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Valuation2012");
            mTime.StopTimer(iTestIndividualOutput_IndivdualOutput_Save);
            mLog.LogInfo(iTestIndividualOutput_IndivdualOutput_Save, MyPerformanceCounter.Memory_Private);




            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "550");
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


            mTime.StartTimer();
            mLog.LogInfo(iTestIndividualOutput_ER_ClickRun, DateTime.Now.ToString());

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
            dic.Add("iPosX", "400");
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
            dic.Add("iPosX", "870");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");


            pAssumptions._SelectTab("Funding");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "DefermentIncreasesPre10");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "DefermentIncreasesPst10");

            pAssumptions._SelectTab("Solvency");


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            mTime.StopTimer(iPPFAndSolvency_InterestRates_Select);
            mLog.LogInfo(iPPFAndSolvency_InterestRates_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

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

            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Assumptions");
            mTime.StopTimer(iPPFAndSolvency_InterestRates_Save);
            mLog.LogInfo(iPPFAndSolvency_InterestRates_Save, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "RPIInflationAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            mTime.StopTimer(iPPFAndSolvency_CustomRates_Select);
            mLog.LogInfo(iPPFAndSolvency_CustomRates_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


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


            mTime.StopTimer(iPPFAndSolvency_CustomRates_Edit);
            mLog.LogInfo(iPPFAndSolvency_CustomRates_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Assumptions");
            mTime.StopTimer(iPPFAndSolvency_CustomRates_Save);
            mLog.LogInfo(iPPFAndSolvency_CustomRates_Save, MyPerformanceCounter.Memory_Private);




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

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Assumptions");


            pMain._SelectTab("Valuation2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "870");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Provisions");


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "COLApre10");
            dic.Add("MenuItem", "Add New Liability Type Folder");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "Solvency");
            dic.Add("Solvency", "True");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);

            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "COLApre10");
            dic.Add("Level_5", "Solvency");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            mTime.StopTimer(iPPFAndSolvency_CostOfLiving_Select);
            mLog.LogInfo(iPPFAndSolvency_CostOfLiving_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_DeferredPension", "");
            dic.Add("Revaluation_Rate_V", "Click");
            dic.Add("Revaluation_Rate_P", "");
            dic.Add("Revaluation_Rate_T", "");
            dic.Add("Revaluation_CumulativeMax", "");
            dic.Add("Revaluation_PensionIncrease", "");
            dic.Add("Revaluation_Rate_V_cbo", "DefermentIncreasesPre10");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "Click");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "05/04/2012");
            dic.Add("Increase_Ends_YearsFrom", "");
            dic.Add("Increase_Ends_Date_V", "");
            dic.Add("Increase_Ends_Date_D", "");
            dic.Add("Increase_Ends_Date_V_cbo", "");
            dic.Add("Increase_Ends_Date_D_txt", "");
            dic.Add("Increase_Amount_Rate_V", "");
            dic.Add("Increase_Amount_Rate_P", "");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "");
            dic.Add("Increase_Amount_Rate_P_txt", "");
            dic.Add("Increase_Amount_Rate_T_cbo", "");
            dic.Add("Increase_Pension", "");
            pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic);


            pMain._SelectTab("Provisions");
            mTime.StopTimer(iPPFAndSolvency_CostOfLiving_Edit);
            mLog.LogInfo(iPPFAndSolvency_CostOfLiving_Edit, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(iPPFAndSolvency_CostOfLiving_Save);
            mLog.LogInfo(iPPFAndSolvency_CostOfLiving_Save, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "COLApre10");
            dic.Add("Level_5", "AllOthers");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_DeferredPension", "");
            dic.Add("Revaluation_Rate_V", "");
            dic.Add("Revaluation_Rate_P", "");
            dic.Add("Revaluation_Rate_T", "");
            dic.Add("Revaluation_CumulativeMax", "");
            dic.Add("Revaluation_PensionIncrease", "");
            dic.Add("Revaluation_Rate_V_cbo", "");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "Click");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "05/04/2012");
            dic.Add("Increase_Ends_YearsFrom", "");
            dic.Add("Increase_Ends_Date_V", "");
            dic.Add("Increase_Ends_Date_D", "");
            dic.Add("Increase_Ends_Date_V_cbo", "");
            dic.Add("Increase_Ends_Date_D_txt", "");
            dic.Add("Increase_Amount_Rate_V", "");
            dic.Add("Increase_Amount_Rate_P", "");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "");
            dic.Add("Increase_Amount_Rate_P_txt", "");
            dic.Add("Increase_Amount_Rate_T_cbo", "");
            dic.Add("Increase_Pension", "");
            pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic);


            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "COLApst10");
            dic.Add("MenuItem", "Add New Liability Type Folder");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "Solvency");
            dic.Add("Solvency", "True");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);

            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "COLApst10");
            dic.Add("Level_5", "Solvency");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_DeferredPension", "");
            dic.Add("Revaluation_Rate_V", "Click");
            dic.Add("Revaluation_Rate_P", "");
            dic.Add("Revaluation_Rate_T", "");
            dic.Add("Revaluation_CumulativeMax", "");
            dic.Add("Revaluation_PensionIncrease", "");
            dic.Add("Revaluation_Rate_V_cbo", "DefermentIncreasesPst10");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "Click");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "05/04/2012");
            dic.Add("Increase_Ends_YearsFrom", "");
            dic.Add("Increase_Ends_Date_V", "");
            dic.Add("Increase_Ends_Date_D", "");
            dic.Add("Increase_Ends_Date_V_cbo", "");
            dic.Add("Increase_Ends_Date_D_txt", "");
            dic.Add("Increase_Amount_Rate_V", "");
            dic.Add("Increase_Amount_Rate_P", "");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "");
            dic.Add("Increase_Amount_Rate_P_txt", "");
            dic.Add("Increase_Amount_Rate_T_cbo", "");
            dic.Add("Increase_Pension", "");
            pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic);


            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "COLApst10");
            dic.Add("Level_5", "Solvency");
            dic.Add("Level_6", "EDTmembs");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_DeferredPension", "");
            dic.Add("Revaluation_Rate_V", "Click");
            dic.Add("Revaluation_Rate_P", "");
            dic.Add("Revaluation_Rate_T", "");
            dic.Add("Revaluation_CumulativeMax", "");
            dic.Add("Revaluation_PensionIncrease", "");
            dic.Add("Revaluation_Rate_V_cbo", "DefermentIncreasesPst10");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "Click");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "05/04/2012");
            dic.Add("Increase_Ends_YearsFrom", "");
            dic.Add("Increase_Ends_Date_V", "");
            dic.Add("Increase_Ends_Date_D", "");
            dic.Add("Increase_Ends_Date_V_cbo", "");
            dic.Add("Increase_Ends_Date_D_txt", "");
            dic.Add("Increase_Amount_Rate_V", "");
            dic.Add("Increase_Amount_Rate_P", "");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "");
            dic.Add("Increase_Amount_Rate_P_txt", "");
            dic.Add("Increase_Amount_Rate_T_cbo", "");
            dic.Add("Increase_Pension", "");
            pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic);


            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "COLApst10");
            dic.Add("Level_5", "AllOthers");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_DeferredPension", "");
            dic.Add("Revaluation_Rate_V", "");
            dic.Add("Revaluation_Rate_P", "");
            dic.Add("Revaluation_Rate_T", "");
            dic.Add("Revaluation_CumulativeMax", "");
            dic.Add("Revaluation_PensionIncrease", "");
            dic.Add("Revaluation_Rate_V_cbo", "");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "Click");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "05/04/2012");
            dic.Add("Increase_Ends_YearsFrom", "");
            dic.Add("Increase_Ends_Date_V", "");
            dic.Add("Increase_Ends_Date_D", "");
            dic.Add("Increase_Ends_Date_V_cbo", "");
            dic.Add("Increase_Ends_Date_D_txt", "");
            dic.Add("Increase_Amount_Rate_V", "");
            dic.Add("Increase_Amount_Rate_P", "");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "");
            dic.Add("Increase_Amount_Rate_P_txt", "");
            dic.Add("Increase_Amount_Rate_T_cbo", "");
            dic.Add("Increase_Pension", "");
            pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic);

            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "COLApst10");
            dic.Add("Level_5", "AllOthers");
            dic.Add("Level_6", "EDTmembs");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_DeferredPension", "");
            dic.Add("Revaluation_Rate_V", "");
            dic.Add("Revaluation_Rate_P", "");
            dic.Add("Revaluation_Rate_T", "");
            dic.Add("Revaluation_CumulativeMax", "");
            dic.Add("Revaluation_PensionIncrease", "");
            dic.Add("Revaluation_Rate_V_cbo", "");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "Click");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "05/04/2012");
            dic.Add("Increase_Ends_YearsFrom", "");
            dic.Add("Increase_Ends_Date_V", "");
            dic.Add("Increase_Ends_Date_D", "");
            dic.Add("Increase_Ends_Date_V_cbo", "");
            dic.Add("Increase_Ends_Date_D_txt", "");
            dic.Add("Increase_Amount_Rate_V", "");
            dic.Add("Increase_Amount_Rate_P", "");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "");
            dic.Add("Increase_Amount_Rate_P_txt", "");
            dic.Add("Increase_Amount_Rate_T_cbo", "");
            dic.Add("Increase_Pension", "");
            pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic);




            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "A_80ths_Structure");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "GMP Adjustment Factors");
            dic.Add("Level_4", "GMPrevaluation");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            mTime.StopTimer(iPPFAndSolvency_GMPAdjustmentFactor_Select);
            mLog.LogInfo(iPPFAndSolvency_GMPAdjustmentFactor_Select, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Act_FromValuation_S148Increases", "");
            dic.Add("Act_FromValuation_FixedRateAt", "");
            dic.Add("Act_FromValuation_FixedRateAt_V", "");
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


            mTime.StopTimer(iPPFAndSolvency_GMPAdjustmentFactor_Edit);
            mLog.LogInfo(iPPFAndSolvency_GMPAdjustmentFactor_Edit, MyPerformanceCounter.Memory_Private);

            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");
            mTime.StopTimer(iPPFAndSolvency_GMPAdjustmentFactor_Save);
            mLog.LogInfo(iPPFAndSolvency_GMPAdjustmentFactor_Save, MyPerformanceCounter.Memory_Private);



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
            dic.Add("Act_FromValuation_FixedRateAt_V", "");
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

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");


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



            mTime.StartTimer();
            mLog.LogInfo(iPPFAndSolvency_ER_ClickRun, DateTime.Now.ToString());

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
            dic.Add("iPosX", "870");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "Add Valuation Node");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Fix Solv age diff");
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

            mTime.StopTimer(iFixSolvAgeDiff_AddNode);
            mLog.LogInfo(iFixSolvAgeDiff_AddNode, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "815");
            dic.Add("iPosY", "370");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");



            pAssumptions._SelectTab("Solvency");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            mTime.StopTimer(iFixSolvAgeDiff_SolvencyOtherDemographic_Select);
            mLog.LogInfo(iFixSolvAgeDiff_SolvencyOtherDemographic_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("cboPercentMarried", "");
            dic.Add("txtPercentMarried_M", "");
            dic.Add("txtPercentMarried_F", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "-3");
            dic.Add("txtDifferenceInSpouseAge_F", "3");
            dic.Add("cboDifferenceInSpouseAge", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);


            mTime.StopTimer(iFixSolvAgeDiff_SolvencyOtherDemographic_Edit);
            mLog.LogInfo(iFixSolvAgeDiff_SolvencyOtherDemographic_Edit, MyPerformanceCounter.Memory_Private);

            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Assumptions");
            mTime.StopTimer(iFixSolvAgeDiff_SolvencyOtherDemographic_Save);
            mLog.LogInfo(iFixSolvAgeDiff_SolvencyOtherDemographic_Save, MyPerformanceCounter.Memory_Private);



            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "810");
            dic.Add("iPosY", "370");
            dic.Add("MenuItem_1", "Parameter Print");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);

            mTime.StopTimer(iFixSolvAgeDiff_ParamPrint_Select);
            mLog.LogInfo(iFixSolvAgeDiff_ParamPrint_Select, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            _gLib._Exists("Parameter Print Report", pOutputManager.wRetirementStudio.wToolbar_btn.btnNextPage.btn, Config.iTimeout * 3, true);
            _gLib._Enabled("Parameter Print Report", pOutputManager.wRetirementStudio.wToolbar_btn.btnNextPage.btn, Config.iTimeout * 3, true);
            pMain._SelectTab("Parameter Print Report");

            mTime.StopTimer(iFixSolvAgeDiff_ParamPrint_Load);
            mLog.LogInfo(iFixSolvAgeDiff_ParamPrint_Load, MyPerformanceCounter.Memory_Private);

            pMain._SelectTab("Valuation2012");

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Valuation2012");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("MenuItem_1", "Tools");
            dic.Add("MenuItem_2", "Parameter Print Comparison");
            pMain._MenuSelect(dic);

            _gLib._Exists("Parameter Print Comparison", pMain.wParameterPrintComparison, 0, true);

            mTime.StopTimer(iFixSolvAgeDiff_ParamComparison_Select);
            mLog.LogInfo(iFixSolvAgeDiff_ParamComparison_Select, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Process", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_ParameterPrintComparison(dic);

            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "Valuation2012");
            dic.Add("Level_4", "PPF and Solvency");
            pMain._ParameterPrint_TreeviewSelect(dic, "Node1");

            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "Valuation2012");
            dic.Add("Level_4", "Fix Solv age diff");
            pMain._ParameterPrint_TreeviewSelect(dic, "Node2");


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Process", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_ParameterPrintComparison(dic);

            _gLib._Exists("BeyondCompare", pMain.wBeyondCompare, Config.iTimeout * 5, true);

            mTime.StopTimer(iFixSolvAgeDiff_ParamComparison_Load);
            mLog.LogInfo(iFixSolvAgeDiff_ParamComparison_Load, MyPerformanceCounter.Memory_Private);

            _gLib._SetSyncUDWin("BeyondCompare", pMain.wBeyondCompare.wTitleBar.btnClose, "Click", 0);


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



            mTime.StartTimer();
            mLog.LogInfo(iFixSolvAgeDiff_ER_ClickRun, DateTime.Now.ToString());

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

            _gLib._CreateDirectory(sOutputDir, false);
            sERDetail = "";

            pMain._SelectTab("Valuation2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "80");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            mLog.LogInfo(i0PercentRunForFSGCashflow_GroupID, pMain._ER_ReturnRunStatus_TopGrid(2));
            mLog.LogInfo(i0PercentRunForFSGCashflow_Persist_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            mLog.LogInfo(i0PercentRunForFSGCashflow_Post_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));

            mLog.LogInfo(i0PercentRunForFSGCashflow_Persist_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5));
            mLog.LogInfo(i0PercentRunForFSGCashflow_Post_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5));

            sERDetail = sERDetail + "Earliest Process: " + pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5) + Environment.NewLine;
            sERDetail = sERDetail + "A_80 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12) + Environment.NewLine;
            sERDetail = sERDetail + "B_60 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 12) + Environment.NewLine;
            sERDetail = sERDetail + "Group Job Success: " + pMain._ER_ReturnRunStatus_TopGrid(11) + Environment.NewLine;
            mLog.LogInfo(i0PercentRunForFSGCashflow_ER_Detail, sERDetail);

            sERDetail = "";
            sERDetail = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3) + ": " + Environment.NewLine;
            sERDetail = sERDetail + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 3) + ": ";
            mLog.LogInfo(i0PercentRunForFSGCashflow_NumOfCores, sERDetail);


            mLog.LogInfo(iJobID_0PercentRunForFSGCashflow_1, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));
            mLog.LogInfo(iJobID_0PercentRunForFSGCashflow_2, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 3));



            pMain._SelectTab("Valuation2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "80");
            dic.Add("iPosY", "320");
            dic.Add("MenuItem_1", "View Output");
            dic.Add("CheckOMSetupPopup", "False");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");


            mTime.StartTimer();

            pOutputManager._ExportReport_Common(Config.eCountry, sOutputDir, "Valuation Summary", "Conversion", false, true);

            mTime.StopTimer(i0PercentRunForFSGCashflow_OutputValuationSummary);
            mLog.LogInfo(i0PercentRunForFSGCashflow_OutputValuationSummary, MyPerformanceCounter.Memory_Private);





            #endregion



            #region User1 - ER & Reports - CNS

            _gLib._CreateDirectory(sOutputDir, false);
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


            mLog.LogInfo(iCNS_GroupID, pMain._ER_ReturnRunStatus_TopGrid(2));
            mLog.LogInfo(iCNS_Persist_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            mLog.LogInfo(iCNS_Post_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));

            sERDetail = sERDetail + "Earliest Process: " + pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5) + Environment.NewLine;
            sERDetail = sERDetail + "A_80 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12) + Environment.NewLine;
            sERDetail = sERDetail + "Group Job Success: " + pMain._ER_ReturnRunStatus_TopGrid(11) + Environment.NewLine;
            mLog.LogInfo(iCNS_ER_Detail, sERDetail);

            sERDetail = "";
            sERDetail = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3) + ": ";
            mLog.LogInfo(iCNS_NumOfCores, sERDetail);

            mLog.LogInfo(iJobID_CNS, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));


            pMain._SelectTab("Valuation2012");





            #endregion



            #region User1 - ER & Reports - Test Individual Output

            _gLib._CreateDirectory(sOutputDir, false);
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


            mLog.LogInfo(iTestIndividualOutput_GroupID, pMain._ER_ReturnRunStatus_TopGrid(2));
            mLog.LogInfo(iTestIndividualOutput_Persist_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            mLog.LogInfo(iTestIndividualOutput_Post_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));

            mLog.LogInfo(iTestIndividualOutput_Persist_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5));
            mLog.LogInfo(iTestIndividualOutput_Post_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5));

            sERDetail = sERDetail + "Earliest Process: " + pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5) + Environment.NewLine;
            sERDetail = sERDetail + "A_80 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12) + Environment.NewLine;
            sERDetail = sERDetail + "B_60 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 12) + Environment.NewLine;
            sERDetail = sERDetail + "Group Job Success: " + pMain._ER_ReturnRunStatus_TopGrid(11) + Environment.NewLine;
            mLog.LogInfo(iTestIndividualOutput_ER_Detail, sERDetail);

            sERDetail = "";
            sERDetail = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3) + ": " + Environment.NewLine;
            sERDetail = sERDetail + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 3) + ": ";
            mLog.LogInfo(iTestIndividualOutput_NumOfCores, sERDetail);


            mLog.LogInfo(iJobID_TestIndividualOutput_1, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));
            mLog.LogInfo(iJobID_TestIndividualOutput_2, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 2, 3));


            pMain._SelectTab("Valuation2012");






            #endregion


            #region User1 - ER & Reports - PPF & Solvency

            _gLib._CreateDirectory(sOutputDir, false);
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


            mLog.LogInfo(iPPFAndSolvency_GroupID, pMain._ER_ReturnRunStatus_TopGrid(2));
            mLog.LogInfo(iPPFAndSolvency_Persist_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            mLog.LogInfo(iPPFAndSolvency_Post_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));

            mLog.LogInfo(iPPFAndSolvency_Persist_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5));
            mLog.LogInfo(iPPFAndSolvency_Post_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5));

            sERDetail = sERDetail + "Earliest Process: " + pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5) + Environment.NewLine;
            sERDetail = sERDetail + "A_80 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12) + Environment.NewLine;
            sERDetail = sERDetail + "B_60 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 5, 12) + Environment.NewLine;
            sERDetail = sERDetail + "Group Job Success: " + pMain._ER_ReturnRunStatus_TopGrid(11) + Environment.NewLine;
            mLog.LogInfo(iPPFAndSolvency_ER_Detail, sERDetail);

            sERDetail = "";
            sERDetail = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3) + ": " + Environment.NewLine;
            sERDetail = sERDetail + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 5, 3) + ": ";
            mLog.LogInfo(iPPFAndSolvency_NumOfCores, sERDetail);


            mLog.LogInfo(iJobID_PPFAndSolvency_1, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));
            mLog.LogInfo(iJobID_PPFAndSolvency_2, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 5, 3));

            pMain._SelectTab("Valuation2012");






            #endregion


            #region User1 - ER & Reports - Fix Slov Age Diff

            _gLib._CreateDirectory(sOutputDir, false);
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


            mLog.LogInfo(iFixSolvAgeDiff_GroupID, pMain._ER_ReturnRunStatus_TopGrid(2));
            mLog.LogInfo(iFixSolvAgeDiff_Persist_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            mLog.LogInfo(iFixSolvAgeDiff_Post_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));

            mLog.LogInfo(iFixSolvAgeDiff_Persist_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5));
            mLog.LogInfo(iFixSolvAgeDiff_Post_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5));

            sERDetail = sERDetail + "Earliest Process: " + pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5) + Environment.NewLine;
            sERDetail = sERDetail + "A_80 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12) + Environment.NewLine;
            sERDetail = sERDetail + "B_60 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 3, 12) + Environment.NewLine;
            sERDetail = sERDetail + "Group Job Success: " + pMain._ER_ReturnRunStatus_TopGrid(11) + Environment.NewLine;
            mLog.LogInfo(iFixSolvAgeDiff_ER_Detail, sERDetail);

            sERDetail = "";
            sERDetail = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3) + ": " + Environment.NewLine;
            sERDetail = sERDetail + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 3, 3) + ": ";
            mLog.LogInfo(iFixSolvAgeDiff_NumOfCores, sERDetail);


            mLog.LogInfo(iJobID_FixSolvAgeDiff_1, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));
            mLog.LogInfo(iJobID_FixSolvAgeDiff_2, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 3, 3));

            pMain._SelectTab("Valuation2012");



            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "810");
            dic.Add("iPosY", "380");
            dic.Add("MenuItem_1", "View Output");
            dic.Add("CheckOMSetupPopup", "False");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");

            mTime.StopTimer(iFixSolvAgeDiff_OutputManager_Open);
            mLog.LogInfo(iFixSolvAgeDiff_OutputManager_Open, MyPerformanceCounter.Memory_Private);

            pMain._SelectTab("Output Manager");
            mTime.StartTimer();

            pOutputManager._Navigate(Config.eCountry, "Valuation Summary", "RollForward", true);
            pOutputManager._WaitForLoading();
            pOutputManager._SelectTab("Valuation Summary");

            mTime.StopTimer(iFixSolvAgeDiff_ValSummary_Open);
            mLog.LogInfo(iFixSolvAgeDiff_ValSummary_Open, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Valuation Summary");

            mTime.StartTimer();

            pOutputManager._ExportItem(Config.eCountry, "Valuation Summary", true);

            pOutputManager._SaveAs(sOutputDir + "ValuationSummary.pdf");

            _gLib._FileExists(sOutputDir + "ValuationSummary.pdf", Config.iTimeout / 20, true);

            _gLib._SetSyncUDWin("Close", pOutputManager.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);


            mTime.StopTimer(iFixSolvAgeDiff_ValSummary_Export);
            mLog.LogInfo(iFixSolvAgeDiff_ValSummary_Export, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Output Manager");
            mTime.StartTimer();

            pOutputManager._Navigate(Config.eCountry, "Reconciliation to Prior Year", "RollForward", true);
            pOutputManager._WaitForLoading();
            pOutputManager._SelectTab("Reconciliation to Prior Year");

            WinWindow wWin = new WinWindow(pOutputManager.wRetirementStudio);
            wWin.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.STATIC", PropertyExpressionOperator.Contains);
            UITestControlCollection uiCollection = wWin.FindMatchingControls();
            WinText wText = new WinText((WinWindow)uiCollection[0]);
            wText.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);
            WinHyperlink wLink = new WinHyperlink(wText);
            wLink.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);

            _gLib._SetSyncUDWin(wLink.Name, wLink, "Click", 0);

            pOutputManager._SelectTab("Reconciliation to Prior Year - Funding");
            pOutputManager._WaitForLoading();


            mTime.StopTimer(iFixSolvAgeDiff_ReconciliationToPriorYear_Open);
            mLog.LogInfo(iFixSolvAgeDiff_ReconciliationToPriorYear_Open, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pOutputManager._ExportItem("Reconciliation to Prior Year", false);

            pOutputManager._SaveAs(sOutputDir + "ReconciliationToPriorYear_Funding.xls");

            _gLib._FileExists(sOutputDir + "ReconciliationToPriorYear_Funding.xlsx", Config.iTimeout / 20, true);

            _gLib._SetSyncUDWin("Close", pOutputManager.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);


            mTime.StopTimer(iFixSolvAgeDiff_ReconciliationToPriorYear_Export);
            mLog.LogInfo(iFixSolvAgeDiff_ReconciliationToPriorYear_Export, MyPerformanceCounter.Memory_Private);



            pMain._SelectTab("Output Manager");
            mTime.StartTimer();

            pOutputManager._Navigate(Config.eCountry, "Liabilities Detailed Results", "RollForward", true);
            pOutputManager._WaitForLoading();
            pOutputManager._SelectTab("Liabilities Detailed Results");

            mTime.StopTimer(iFixSolvAgeDiff_LiabilityDetailedResults_Open);
            mLog.LogInfo(iFixSolvAgeDiff_LiabilityDetailedResults_Open, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pOutputManager._ExportItem("Liabilities Detailed Results", false);

            pOutputManager._SaveAs(sOutputDir + "LiabilitiesDetailedResults.xls");

            _gLib._FileExists(sOutputDir + "LiabilitiesDetailedResults.xlsx", Config.iTimeout / 20, true);

            _gLib._SetSyncUDWin("Close", pOutputManager.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);


            mTime.StopTimer(iFixSolvAgeDiff_LiabilityDetailedResults_Export);
            mLog.LogInfo(iFixSolvAgeDiff_LiabilityDetailedResults_Export, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Valuation2012");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);
            _gLib._KillProcessByName("RetirementStudio");
            mLog.LogInfo(iTimeEnd_User1, DateTime.Now.ToString());

            #endregion




            #region User2 - Launch Studio & Open Service

            _gLib._StudioClearCache();   //////////_gLib._MsgBox("Warning!", "Please Clear Cache!");


            mLog.LogInfo(iTimeStart_User2, DateTime.Now.ToString());



            mTime.StartTimer();

            _gLib._Cmd(Config.sStudioLaunchDir);

            pMain._SelectTab("Home");
            mTime.StopTimer(iUser2_LaunchStudio);
            mLog.LogInfo(iUser2_LaunchStudio, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("Home");

            //////////////////////_gLib._MsgBox("Warning!", "Please manually select the Client in Studio-> Home -> All Services -> " + Config.sClientName + Environment.NewLine + Environment.NewLine
            //////////////////////    + "Click OK to keep testing!");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation2012");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            mTime.StopTimer(iUser2_OpenService);
            mLog.LogInfo(iUser2_OpenService, MyPerformanceCounter.Memory_Private);

            pMain._SelectTab("Valuation2012");
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region User2 - Fix Solv age diff - Node 15

            _gLib._MsgBox("Warning", "Please clolse Studio and manually launch it, open service, enlarge the new tree view to make sure all nodes are visible! and Select Node <FixSlovAgeDiff>");



            pMain._SelectTab("Valuation2012");

            _gLib._KillProcessByName("Mercer.RetirementStudio.Messaging.MessagingClientApp");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("MenuItem_1", "Tools");
            dic.Add("MenuItem_2", "Parameter Print Comparison");
            pMain._MenuSelect(dic);

            _gLib._Exists("Parameter Print Comparison", pMain.wParameterPrintComparison, 0, true);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Process", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_ParameterPrintComparison(dic);

            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "Valuation2012");
            dic.Add("Level_4", "PPF and Solvency");
            pMain._ParameterPrint_TreeviewSelect(dic, "Node1");

            dic.Clear();
            dic.Add("Level_1", Config.sPlanName);
            dic.Add("Level_2", "FundingValuations");
            dic.Add("Level_3", "Valuation2012");
            dic.Add("Level_4", "Fix Solv age diff");
            pMain._ParameterPrint_TreeviewSelect(dic, "Node2");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Process", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_ParameterPrintComparison(dic);

            _gLib._Exists("BeyondCompare", pMain.wBeyondCompare, Config.iTimeout * 5, true);

            mTime.StopTimer(iUser2_ParamComparison);
            mLog.LogInfo(iUser2_ParamComparison, MyPerformanceCounter.Memory_Private);


            _gLib._SetSyncUDWin("BeyondCompare", pMain.wBeyondCompare.wTitleBar.btnClose, "Click", 0);



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



            mTime.StartTimer();
            mLog.LogInfo(iUser2_FixSolvAgeDiff_ER_ClickRun, DateTime.Now.ToString());

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



            _gLib._CreateDirectory(sOutputDir, false);
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


            mLog.LogInfo(iUser2_FixSolvAgeDiff_GroupID, pMain._ER_ReturnRunStatus_TopGrid(2));
            mLog.LogInfo(iUser2_FixSolvAgeDiff_Persist_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            mLog.LogInfo(iUser2_FixSolvAgeDiff_Post_80, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));

            mLog.LogInfo(iUser2_FixSolvAgeDiff_Persist_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 7, 5));
            mLog.LogInfo(iUser2_FixSolvAgeDiff_Post_60, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 8, 5));

            sERDetail = sERDetail + "Earliest Process: " + pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5) + Environment.NewLine;
            sERDetail = sERDetail + "A_80 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 12) + Environment.NewLine;
            sERDetail = sERDetail + "B_60 Job Success: " + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 3, 12) + Environment.NewLine;
            sERDetail = sERDetail + "Group Job Success: " + pMain._ER_ReturnRunStatus_TopGrid(11) + Environment.NewLine;
            mLog.LogInfo(iUser2_FixSolvAgeDiff_ER_Detail, sERDetail);

            sERDetail = "";
            sERDetail = pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3) + ": " + Environment.NewLine;
            sERDetail = sERDetail + pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 3, 3) + ": ";
            mLog.LogInfo(iUser2_FixSolvAgeDiff_NumOfCores, sERDetail);



            mLog.LogInfo(iJobID_FixSolvAgeDiff_User2_1, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));
            mLog.LogInfo(iJobID_FixSolvAgeDiff_User2_2, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 3, 3));

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
