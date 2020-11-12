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


namespace RetirementStudio._TestScripts_2019_Oct_Timing
{
    /// <summary>
    /// Summary description for US010_CN_Time
    /// </summary>
    [CodedUITest]
    public class US010_CN_Time
    {



        public US010_CN_Time()
        {
            Config.eEnv = _TestingEnv.Dev2;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 010 Create New_20170412_F";
            Config.sPlanName = "US Plan";
            ////Config.sDataCenter = "Exeter";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = false;
            Config.bCompareReports = false;

        }


        #region Timing

        static Boolean bCreateClientPlan_TimingOnly = true;
        static Boolean bDownloadReports_EXCEL_TimingOnly = true;
        

        static string sCol_Time = "Time";
        static string sCol_Memory = "Memory";
        static string sLogFile = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_010_Drummond\US010_TimingLog.xls";
        MyTimer mTime = new MyTimer(sCol_Time, sLogFile);
        MyLog mLog = new MyLog(sCol_Memory, sLogFile);


        static int iJobID_July2006Val = 210;
        static int iJobID_July2007Val = iJobID_July2006Val + 1;
        static int iJobID_July2006FASVal = iJobID_July2007Val + 1;
        static int iJobID_July2007FASVal = iJobID_July2006FASVal + 1;


        #region Result Index - Data2006

        static int iTimeStart = 2;
        static int iTimeEnd = iTimeStart + 1;
        static int iData2006_AddService = iTimeEnd + 1;
        static int iData2006_OpenService = iData2006_AddService + 1;
        static int iData2006_Upload_SelectFile = iData2006_OpenService + 1;
        static int iData2006_Upload_Upload = iData2006_Upload_SelectFile + 1;
        static int iData2006_CV_AddLable_CredService = iData2006_Upload_Upload + 1;
        static int iData2006_CV_AddLable_VestService = iData2006_CV_AddLable_CredService + 1;
        static int iData2006_CV_AddLable_Benefit2DB = iData2006_CV_AddLable_VestService + 1;
        static int iData2006_CV_AddLable_Benefit3DB = iData2006_CV_AddLable_Benefit2DB + 1;
        static int iData2006_CV_Save = iData2006_CV_AddLable_Benefit3DB + 1;
        static int iData2006_IM_AddNewImport = iData2006_CV_Save + 1;
        static int iData2006_IM_Selectfile = iData2006_IM_AddNewImport + 1;
        static int iData2006_IM_SelectFile_Preview = iData2006_IM_Selectfile + 1;
        static int iData2006_MP_MapFields = iData2006_IM_SelectFile_Preview + 1;
        static int iData2006_MP_Preview = iData2006_MP_MapFields + 1;
        static int iData2006_ValidateAndLoad = iData2006_MP_Preview + 1;
        static int iData2006_PMD_Add = iData2006_ValidateAndLoad + 1;
        static int iData2006_PMD_CalcPreview = iData2006_PMD_Add + 1;
        static int iData2006_PMD_SaveToStage = iData2006_PMD_CalcPreview + 1;
        static int iData2006_Matching_FindMatch = iData2006_PMD_SaveToStage + 1;
        static int iData2006_Matching_AcceptAllNew = iData2006_Matching_FindMatch + 1;
        static int iData2006_Matching_SaveToWarehouse = iData2006_Matching_AcceptAllNew + 1;
        static int iData2006_SP_AddNew = iData2006_Matching_SaveToWarehouse + 1;
        static int iData2006_SP_Preview = iData2006_SP_AddNew + 1;
        static int iData2006_SP_Publish = iData2006_SP_Preview + 1;


        #endregion


        #region Result Index - July2006Valuation

        static int iJuly2006Val_AddService = iData2006_SP_Publish + 1;
        static int iJuly2006Val_OpenService = iJuly2006Val_AddService + 1;
        static int iJuly2006Val_Data_OpenDataSet = iJuly2006Val_OpenService + 1;
        static int iJuly2006Val_Data_SelectSnapshot = iJuly2006Val_Data_OpenDataSet + 1;
        static int iJuly2006Val_Data_Import = iJuly2006Val_Data_SelectSnapshot + 1;

        static int iJuly2006Val_Assump_OpenAssumptions = iJuly2006Val_Data_Import + 1;
        static int iJuly2006Val_Assump_InterestRate_AddFolder = iJuly2006Val_Assump_OpenAssumptions + 1;
        static int iJuly2006Val_Assump_InterestRate_Select = iJuly2006Val_Assump_InterestRate_AddFolder + 1;
        static int iJuly2006Val_Assump_InterestRate_Edit = iJuly2006Val_Assump_InterestRate_Select + 1;
        static int iJuly2006Val_Assump_InterestRate_Save = iJuly2006Val_Assump_InterestRate_Edit + 1;
        static int iJuly2006Val_Assump_OtherDemographicAssumptions_Select = iJuly2006Val_Assump_InterestRate_Save + 1;
        static int iJuly2006Val_Assump_OtherDemographicAssumptions_Edit = iJuly2006Val_Assump_OtherDemographicAssumptions_Select + 1;
        static int iJuly2006Val_Assump_OtherDemographicAssumptions_Save = iJuly2006Val_Assump_OtherDemographicAssumptions_Edit + 1;
        static int iJuly2006Val_Assump_MortalityDecrement_AddFolder = iJuly2006Val_Assump_OtherDemographicAssumptions_Save + 1;
        static int iJuly2006Val_Assump_MortalityDecrement_Select = iJuly2006Val_Assump_MortalityDecrement_AddFolder + 1;
        static int iJuly2006Val_Assump_MortalityDecrement_Edit = iJuly2006Val_Assump_MortalityDecrement_Select + 1;
        static int iJuly2006Val_Assump_MortalityDecrement_Save = iJuly2006Val_Assump_MortalityDecrement_Edit + 1;


        static int iJuly2006Val_Prov_OpenProvisions = iJuly2006Val_Assump_MortalityDecrement_Save + 1;
        static int iJuly2006Val_Prov_Service_Add = iJuly2006Val_Prov_OpenProvisions + 1;
        static int iJuly2006Val_Prov_Service_Select = iJuly2006Val_Prov_Service_Add + 1;
        static int iJuly2006Val_Prov_Service_Edit = iJuly2006Val_Prov_Service_Select + 1;
        static int iJuly2006Val_Prov_Service_Save = iJuly2006Val_Prov_Service_Edit + 1;

        static int iJuly2006Val_Prov_FromToAge_Add = iJuly2006Val_Prov_Service_Save + 1;
        static int iJuly2006Val_Prov_FromToAge_Select = iJuly2006Val_Prov_FromToAge_Add + 1;
        static int iJuly2006Val_Prov_FromToAge_Edit = iJuly2006Val_Prov_FromToAge_Select + 1;
        static int iJuly2006Val_Prov_FromToAge_Save = iJuly2006Val_Prov_FromToAge_Edit + 1;

        static int iJuly2006Val_Prov_Eligibilities_Add = iJuly2006Val_Prov_FromToAge_Save + 1;
        static int iJuly2006Val_Prov_Eligibilities_Select = iJuly2006Val_Prov_Eligibilities_Add + 1;
        static int iJuly2006Val_Prov_Eligibilities_Edit = iJuly2006Val_Prov_Eligibilities_Select + 1;
        static int iJuly2006Val_Prov_Eligibilities_Save = iJuly2006Val_Prov_Eligibilities_Edit + 1;

        static int iJuly2006Val_Prov_SpecialEligibilities_Select = iJuly2006Val_Prov_Eligibilities_Save + 1;
        static int iJuly2006Val_Prov_SpecialEligibilities_Edit = iJuly2006Val_Prov_SpecialEligibilities_Select + 1;
        static int iJuly2006Val_Prov_SpecialEligibilities_Save = iJuly2006Val_Prov_SpecialEligibilities_Edit + 1;

        static int iJuly2006Val_Prov_PayProjection_Add = iJuly2006Val_Prov_SpecialEligibilities_Save + 1;
        static int iJuly2006Val_Prov_PayProjection_Select = iJuly2006Val_Prov_PayProjection_Add + 1;
        static int iJuly2006Val_Prov_PayProjection_Edit = iJuly2006Val_Prov_PayProjection_Select + 1;
        static int iJuly2006Val_Prov_PayProjection_Save = iJuly2006Val_Prov_PayProjection_Edit + 1;



        static int iJuly2006Val_Assump_RetirementDecrement_Select = iJuly2006Val_Prov_PayProjection_Save + 1;
        static int iJuly2006Val_Assump_RetirementDecrement_Edit = iJuly2006Val_Assump_RetirementDecrement_Select + 1;
        static int iJuly2006Val_Assump_RetirementDecrement_Save = iJuly2006Val_Assump_RetirementDecrement_Edit + 1;
        static int iJuly2006Val_Assump_WithdrawalDecrement_Select = iJuly2006Val_Assump_RetirementDecrement_Save + 1;
        static int iJuly2006Val_Assump_WithdrawalDecrement_Edit = iJuly2006Val_Assump_WithdrawalDecrement_Select + 1;
        static int iJuly2006Val_Assump_WithdrawalDecrement_Save = iJuly2006Val_Assump_WithdrawalDecrement_Edit + 1;
        static int iJuly2006Val_Assump_DisabilityDecrement_Select = iJuly2006Val_Assump_WithdrawalDecrement_Save + 1;
        static int iJuly2006Val_Assump_DisabilityDecrement_Edit = iJuly2006Val_Assump_DisabilityDecrement_Select + 1;
        static int iJuly2006Val_Assump_DisabilityDecrement_Save = iJuly2006Val_Assump_DisabilityDecrement_Edit + 1;

        static int iJuly2006Val_Prov_UnitFormula_Add = iJuly2006Val_Assump_DisabilityDecrement_Save + 1;
        static int iJuly2006Val_Prov_UnitFormula_Select = iJuly2006Val_Prov_UnitFormula_Add + 1;
        static int iJuly2006Val_Prov_UnitFormula_Edit = iJuly2006Val_Prov_UnitFormula_Select + 1;
        static int iJuly2006Val_Prov_UnitFormula_Save = iJuly2006Val_Prov_UnitFormula_Edit + 1;

        static int iJuly2006Val_Prov_CustomFormulaB_Add = iJuly2006Val_Prov_UnitFormula_Save + 1;
        static int iJuly2006Val_Prov_CustomFormulaB_Select = iJuly2006Val_Prov_CustomFormulaB_Add + 1;
        static int iJuly2006Val_Prov_CustomFormulaB_Edit = iJuly2006Val_Prov_CustomFormulaB_Select + 1;
        static int iJuly2006Val_Prov_CustomFormulaB_Save = iJuly2006Val_Prov_CustomFormulaB_Edit + 1;

        static int iJuly2006Val_Prov_Vesting_Add = iJuly2006Val_Prov_CustomFormulaB_Save + 1;
        static int iJuly2006Val_Prov_Vesting_Select = iJuly2006Val_Prov_Vesting_Add + 1;
        static int iJuly2006Val_Prov_Vesting_Edit = iJuly2006Val_Prov_Vesting_Select + 1;
        static int iJuly2006Val_Prov_Vesting_Save = iJuly2006Val_Prov_Vesting_Edit + 1;

        static int iJuly2006Val_Prov_COLA_Add = iJuly2006Val_Prov_Vesting_Save + 1;
        static int iJuly2006Val_Prov_COLA_Select = iJuly2006Val_Prov_COLA_Add + 1;
        static int iJuly2006Val_Prov_COLA_Edit = iJuly2006Val_Prov_COLA_Select + 1;
        static int iJuly2006Val_Prov_COLA_Save = iJuly2006Val_Prov_COLA_Edit + 1;

        static int iJuly2006Val_Prov_ERF_Add = iJuly2006Val_Prov_COLA_Save + 1;
        static int iJuly2006Val_Prov_ERF_Select = iJuly2006Val_Prov_ERF_Add + 1;
        static int iJuly2006Val_Prov_ERF_Edit = iJuly2006Val_Prov_ERF_Select + 1;
        static int iJuly2006Val_Prov_ERF_Save = iJuly2006Val_Prov_ERF_Edit + 1;

        static int iJuly2006Val_Prov_FOP_Add = iJuly2006Val_Prov_ERF_Save + 1;
        static int iJuly2006Val_Prov_FOP_Select = iJuly2006Val_Prov_FOP_Add + 1;
        static int iJuly2006Val_Prov_FOP_Edit = iJuly2006Val_Prov_FOP_Select + 1;
        static int iJuly2006Val_Prov_FOP_Save = iJuly2006Val_Prov_FOP_Edit + 1;

        static int iJuly2006Val_Prov_415Limit_Add = iJuly2006Val_Prov_FOP_Save + 1;
        static int iJuly2006Val_Prov_415Limit_Select = iJuly2006Val_Prov_415Limit_Add + 1;
        static int iJuly2006Val_Prov_415Limit_Edit = iJuly2006Val_Prov_415Limit_Select + 1;
        static int iJuly2006Val_Prov_415Limit_Save = iJuly2006Val_Prov_415Limit_Edit + 1;

        static int iJuly2006Val_Prov_Adjustments_Add = iJuly2006Val_Prov_415Limit_Save + 1;
        static int iJuly2006Val_Prov_Adjustments_Select = iJuly2006Val_Prov_Adjustments_Add + 1;
        static int iJuly2006Val_Prov_Adjustments_Edit = iJuly2006Val_Prov_Adjustments_Select + 1;
        static int iJuly2006Val_Prov_Adjustments_Save = iJuly2006Val_Prov_Adjustments_Edit + 1;

        static int iJuly2006Val_Prov_PlanDefintion_Add = iJuly2006Val_Prov_Adjustments_Save + 1;
        static int iJuly2006Val_Prov_PlanDefintion_Select = iJuly2006Val_Prov_PlanDefintion_Add + 1;
        static int iJuly2006Val_Prov_PlanDefintion_Edit = iJuly2006Val_Prov_PlanDefintion_Select + 1;
        static int iJuly2006Val_Prov_PlanDefintion_Save = iJuly2006Val_Prov_PlanDefintion_Edit + 1;

        static int iJuly2006Val_Prov_Save = iJuly2006Val_Prov_PlanDefintion_Save + 1;

        static int iJuly2006Val_Methods_Open = iJuly2006Val_Prov_Save + 1;
        static int iJuly2006Val_Methods_Edit = iJuly2006Val_Methods_Open + 1;
        static int iJuly2006Val_Methods_Save = iJuly2006Val_Methods_Edit + 1;

        static int iJuly2006Val_TestCase_Open = iJuly2006Val_Methods_Save + 1;
        static int iJuly2006Val_TestCase_Edit = iJuly2006Val_TestCase_Open + 1;
        static int iJuly2006Val_TestCase_Save = iJuly2006Val_TestCase_Edit + 1;
        static int iJuly2006Val_TestCase_Run = iJuly2006Val_TestCase_Save + 1;
        static int iJuly2006Val_TestCase_View = iJuly2006Val_TestCase_Run + 1;

        static int iJuly2006Val_ER_LaunchOption = iJuly2006Val_TestCase_View + 1;
        static int iJuly2006Val_ER_CodeOption = iJuly2006Val_ER_LaunchOption + 1;
        static int iJuly2006Val_ER_RunSubmitted = iJuly2006Val_ER_CodeOption + 1;
        static int iJuly2006Val_ER_ClickRun = iJuly2006Val_ER_RunSubmitted + 1;
        static int iJuly2006Val_ER_GroupJobID = iJuly2006Val_ER_ClickRun + 1;
        static int iJuly2006Val_ER_EarliestToBeProcess = iJuly2006Val_ER_GroupJobID + 1;
        static int iJuly2006Val_ER_Persist = iJuly2006Val_ER_EarliestToBeProcess + 1;
        static int iJuly2006Val_ER_PostEngine = iJuly2006Val_ER_Persist + 1;
        static int iJuly2006Val_ER_GroupSuccess = iJuly2006Val_ER_PostEngine + 1;


        static int iJuly2006Val_OM_Open = iJuly2006Val_ER_GroupSuccess + 2;
        static int iJuly2006Val_OM_ValSummary = iJuly2006Val_OM_Open + 1;
        static int iJuly2006Val_OM_PayoutProjection = iJuly2006Val_OM_ValSummary + 1;
        static int iJuly2006Val_OM_IOE = iJuly2006Val_OM_PayoutProjection + 1;
        static int iJuly2006Val_OM_Save = iJuly2006Val_OM_IOE + 1;

        #endregion


        #region Result Index - Data2007

        static int iData2007_AddService = iJuly2006Val_OM_Save + 1;
        static int iData2007_OpenService = iData2007_AddService + 1;
        static int iData2007_Upload_SelectFile = iData2007_OpenService + 1;
        static int iData2007_Upload_Upload = iData2007_Upload_SelectFile + 1;
        static int iData2007_IM_Selectfile = iData2007_Upload_Upload + 1;
        static int iData2007_IM_SelectFile_Preview = iData2007_IM_Selectfile + 1;
        static int iData2007_MP_Preview = iData2007_IM_SelectFile_Preview + 1;
        static int iData2007_ValidateAndLoad = iData2007_MP_Preview + 1;
        static int iData2007_Matching_FindMatch = iData2007_ValidateAndLoad + 1;
        static int iData2007_Matching_AcceptNew = iData2007_Matching_FindMatch + 1;
        static int iData2007_Matching_AcceptMatched = iData2007_Matching_AcceptNew + 1;
        static int iData2007_Matching_SaveToWarehouse = iData2007_Matching_AcceptMatched + 1;
        static int iData2007_SP_Preview = iData2007_Matching_SaveToWarehouse + 1;
        static int iData2007_SP_Publish = iData2007_SP_Preview + 1;


        #endregion


        #region Result Index - July2007Valuation

        static int iJuly2007Val_AddService = iData2007_SP_Publish + 1;
        static int iJuly2007Val_OpenService = iJuly2007Val_AddService + 1;
        static int iJuly2007Val_Rollforward = iJuly2007Val_OpenService + 1;
        static int iJuly2007Val_Data_OpenDataSet = iJuly2007Val_Rollforward + 1;
        static int iJuly2007Val_Data_SelectSnapshot = iJuly2007Val_Data_OpenDataSet + 1;
        static int iJuly2007Val_Data_Import = iJuly2007Val_Data_SelectSnapshot + 1;


        static int iJuly2007Val_ER_LaunchOption = iJuly2007Val_Data_Import + 1;
        static int iJuly2007Val_ER_CodeOption = iJuly2007Val_ER_LaunchOption + 1;
        static int iJuly2007Val_ER_RunSubmitted = iJuly2007Val_ER_CodeOption + 1;
        static int iJuly2007Val_ER_ClickRun = iJuly2007Val_ER_RunSubmitted + 1;
        static int iJuly2007Val_ER_GroupJobID = iJuly2007Val_ER_ClickRun + 1;
        static int iJuly2007Val_ER_EarliestToBeProcess = iJuly2007Val_ER_GroupJobID + 1;
        static int iJuly2007Val_ER_Persist = iJuly2007Val_ER_EarliestToBeProcess + 1;
        static int iJuly2007Val_ER_PostEngine = iJuly2007Val_ER_Persist + 1;
        static int iJuly2007Val_ER_GroupSuccess = iJuly2007Val_ER_PostEngine + 1;


        static int iJuly2007Val_OM_Open = iJuly2007Val_ER_GroupSuccess + 2;
        static int iJuly2007Val_OM_ReconciliationToPriorYear = iJuly2007Val_OM_Open + 1;
        static int iJuly2007Val_OM_GLSummaryOfLiabilityReconciliation = iJuly2007Val_OM_ReconciliationToPriorYear + 1;
        static int iJuly2007Val_OM_GLParticipantListing = iJuly2007Val_OM_GLSummaryOfLiabilityReconciliation + 1;
        static int iJuly2007Val_OM_ValSummary = iJuly2007Val_OM_GLParticipantListing + 1;
        static int iJuly2007Val_OM_PayoutProjection = iJuly2007Val_OM_ValSummary + 1;
        static int iJuly2007Val_OM_IOE = iJuly2007Val_OM_PayoutProjection + 1;
        static int iJuly2007Val_OM_Save = iJuly2007Val_OM_IOE + 1;

        #endregion


        #region Result Index - July2006FASVal

        static int iJuly2006FAS_AddService = iJuly2007Val_OM_Save + 1;
        static int iJuly2006FAS_OpenService = iJuly2006FAS_AddService + 1;
        static int iJuly2006FAS_Data_OpenDataSet = iJuly2006FAS_OpenService + 1;
        static int iJuly2006FAS_Data_SelectSnapshot = iJuly2006FAS_Data_OpenDataSet + 1;
        static int iJuly2006FAS_Data_Import = iJuly2006FAS_Data_SelectSnapshot + 1;
        static int iJuly2006FAS_Prov_Copy = iJuly2006FAS_Data_Import + 1;


        static int iJuly2006FAS_ER_LaunchOption = iJuly2006FAS_Prov_Copy + 1;
        static int iJuly2006FAS_ER_CodeOption = iJuly2006FAS_ER_LaunchOption + 1;
        static int iJuly2006FAS_ER_RunSubmitted = iJuly2006FAS_ER_CodeOption + 1;
        static int iJuly2006FAS_ER_ClickRun = iJuly2006FAS_ER_RunSubmitted + 1;
        static int iJuly2006FAS_ER_GroupJobID = iJuly2006FAS_ER_ClickRun + 1;
        static int iJuly2006FAS_ER_EarliestToBeProcess = iJuly2006FAS_ER_GroupJobID + 1;
        static int iJuly2006FAS_ER_Persist = iJuly2006FAS_ER_EarliestToBeProcess + 1;
        static int iJuly2006FAS_ER_PostEngine = iJuly2006FAS_ER_Persist + 1;
        static int iJuly2006FAS_ER_GroupSuccess = iJuly2006FAS_ER_PostEngine + 1;
        static int iJuly2006FAS_Save = iJuly2006FAS_ER_GroupSuccess + 2;



        #endregion


        #region Result Index - July2007FASVal

        static int iJuly2007FAS_AddService = iJuly2006FAS_Save + 1;
        static int iJuly2007FAS_OpenService = iJuly2007FAS_AddService + 1;
        static int iJuly2007FAS_Rollforward = iJuly2007FAS_OpenService + 1;
        static int iJuly2007FAS_Data_OpenDataSet = iJuly2007FAS_Rollforward + 1;
        static int iJuly2007FAS_Data_SelectSnapshot = iJuly2007FAS_Data_OpenDataSet + 1;
        static int iJuly2007FAS_Data_Import = iJuly2007FAS_Data_SelectSnapshot + 1;


        static int iJuly2007FAS_ER_LaunchOption = iJuly2007FAS_Data_Import + 1;
        static int iJuly2007FAS_ER_CodeOption = iJuly2007FAS_ER_LaunchOption + 1;
        static int iJuly2007FAS_ER_RunSubmitted = iJuly2007FAS_ER_CodeOption + 1;
        static int iJuly2007FAS_ER_ClickRun = iJuly2007FAS_ER_RunSubmitted + 1;
        static int iJuly2007FAS_ER_GroupJobID = iJuly2007FAS_ER_ClickRun + 1;
        static int iJuly2007FAS_ER_EarliestToBeProcess = iJuly2007FAS_ER_GroupJobID + 1;
        static int iJuly2007FAS_ER_Persist = iJuly2007FAS_ER_EarliestToBeProcess + 1;
        static int iJuly2007FAS_ER_PostEngine = iJuly2007FAS_ER_Persist + 1;
        static int iJuly2007FAS_ER_GroupSuccess = iJuly2007FAS_ER_PostEngine + 1;
        static int iJuly2007FAS_Save = iJuly2007FAS_ER_GroupSuccess + 2;


        #endregion

        #endregion


        #region Report Output Directory



        public string sOutputFunding_July2006Valuation = "";
        public string sOutputFunding_July2007Valuation = "";
        public string sOutputAccounting_July2006FASVal = "";
        public string sOutputAccounting_July2007FASVal = "";


        public string sOutputFunding_July2006Valuation_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_010_Drummond\Production\July 2006 Valuation\6.4_20140702_Franklin\";
        public string sOutputFunding_July2007Valuation_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_010_Drummond\Production\July 2007 Valuation\6.4_20140702_Franklin\";
        public string sOutputAccounting_July2006FASVal_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_010_Drummond\Production\July 2006 FAS Val\6.4_20140702_Franklin\";
        public string sOutputAccounting_July2007FASVal_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_010_Drummond\Production\July 2007 FAS Val\6.4_20140702_Franklin\";


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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_010_Drummond\Create New\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputFunding_July2006Valuation = _gLib._CreateDirectory(sMainDir + "July 2006 Valuation\\" + sPostFix + "\\");
                    sOutputFunding_July2007Valuation = _gLib._CreateDirectory(sMainDir + "July 2007 Valuation\\" + sPostFix + "\\");
                    sOutputAccounting_July2006FASVal = _gLib._CreateDirectory(sMainDir + "July 2006 FAS Val\\" + sPostFix + "\\");
                    sOutputAccounting_July2007FASVal = _gLib._CreateDirectory(sMainDir + "July 2007 FAS Val\\" + sPostFix + "\\");

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

                string sMainDir = sDir + "US010_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputFunding_July2006Valuation = _gLib._CreateDirectory(sMainDir + "\\Funding_July2006Valuation\\");
                sOutputFunding_July2007Valuation = _gLib._CreateDirectory(sMainDir + "\\Funding_July2007Valuation\\");
                sOutputAccounting_July2006FASVal = _gLib._CreateDirectory(sMainDir + "\\Accounting_July2006FASVal\\");
                sOutputAccounting_July2007FASVal = _gLib._CreateDirectory(sMainDir + "\\Accounting_July2007FASVal\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputFunding_July2006Valuation = @\"" + sOutputFunding_July2006Valuation + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_July2007Valuation = @\"" + sOutputFunding_July2007Valuation + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_July2006FASVal = @\"" + sOutputAccounting_July2006FASVal + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_July2007FASVal = @\"" + sOutputAccounting_July2007FASVal + "\";" + Environment.NewLine;

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

        #endregion





        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_US010_Timing()
        {







            ///////// Below are necessary testing codes to make sure memory/time info can be successfully get/set into right cell.

            _gLib._MsgBox("Warning!", "Please Clear Cache!");
            mLog.LogInfo(iTimeStart, MyPerformanceCounter.Memory_Private);
            mLog.LogInfo(iTimeStart, DateTime.Now.ToString());
            //////////_gLib._MsgBox("Reminder!", "Please go to the timing log file to check if the results logged into expected cell!");


            this.GenerateReportOuputDir();



            #region Create Client/Plan

            if (bCreateClientPlan_TimingOnly)
            {
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
                dic.Add("ClientCode", "drum");
                dic.Add("FiscalYearEnd", "06/30");
                dic.Add("MeasurementDate", "09/30");
                dic.Add("Notes", "Client Owner: Karen Lanctot. Original client: KJL - QA US Benchmark 010");
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
                dic.Add("Country", "United States of America");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pMain._PopVerify_PMTool_CountrySelection(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("PlanName", Config.sPlanName);
                dic.Add("PlanYearBegin", "07/01");
                dic.Add("OK", "Click");
                pMain._PopVerify_PMTool_Plan(dic);

            }

            pMain._SelectTab("Home");


            #endregion

            _gLib._MsgBox("manual innput!", "please add the client into favorates view!");


            #region Data 2006

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "ParticipantData");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Data 2006");
            dic.Add("EffectiveDate", "07/01/2006");
            dic.Add("Parent", "");
            //dic.Add("RSC", "True");
            dic.Add("Shared", "");
            dic.Add("GeneralUse", "");
            dic.Add("Conversion", "True");
            dic.Add("CopyDataService", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_DataServicePropeties(dic);


            pMain._SelectTab("Home");
            mTime.StopTimer(iData2006_AddService);
            mLog.LogInfo(iData2006_AddService, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Data 2006");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            mTime.StopTimer(iData2006_OpenService);
            mLog.LogInfo(iData2006_OpenService, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data 2006");
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
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\US010\US0102006.XLs");
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            mTime.StopTimer(iData2006_Upload_SelectFile);
            mLog.LogInfo(iData2006_Upload_SelectFile, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);

            pMain._SelectTab("Data 2006");

            mTime.StopTimer(iData2006_Upload_Upload);
            mLog.LogInfo(iData2006_Upload_Upload, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", "Data 2006");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "CredService");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "DateTime");
            dic.Add("FieldLength", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, false);

            mTime.StopTimer(iData2006_CV_AddLable_CredService);
            mLog.LogInfo(iData2006_CV_AddLable_CredService, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "VestService");
            dic.Add("DisplayName", "");
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

            mTime.StopTimer(iData2006_CV_AddLable_VestService);
            mLog.LogInfo(iData2006_CV_AddLable_VestService, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "Benefit2DB");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            mTime.StopTimer(iData2006_CV_AddLable_Benefit2DB);
            mLog.LogInfo(iData2006_CV_AddLable_Benefit2DB, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "Benefit3DB");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            mTime.StopTimer(iData2006_CV_AddLable_Benefit3DB);
            mLog.LogInfo(iData2006_CV_AddLable_Benefit3DB, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Data 2006");

            mTime.StopTimer(iData2006_CV_Save);
            mLog.LogInfo(iData2006_CV_Save, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data 2006");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            mTime.StopTimer(iData2006_IM_AddNewImport);
            mLog.LogInfo(iData2006_IM_AddNewImport, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Get Data");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "US0102006.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            pData._SelectTab("Select File");

            mTime.StopTimer(iData2006_IM_Selectfile);
            mLog.LogInfo(iData2006_IM_Selectfile, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_SelectFile(dic);

            pData._SelectTab("Select File");

            mTime.StopTimer(iData2006_IM_SelectFile_Preview);
            mLog.LogInfo(iData2006_IM_SelectFile_Preview, MyPerformanceCounter.Memory_Private);



            pData._SelectTab("Mapping");

            mTime.StartTimer();

            pData._IP_Mapping_Initialize("Personal Information", "Accounting Results", 1, 0, 1, "GRSAccountingAL");
            pData._IP_Mapping_Initialize("Personal Information", "Funding Results", 1, 0, 1, "GRSFundingAL");
            pData._IP_Mapping_Initialize("Personal Information", "DC Information", 1, 0, 1, "MembershipDateDC1");
            pData._IP_Mapping_Initialize("Personal Information", "Classification Codes", 1, 0, 1, "DivisionCode");
            pData._IP_Mapping_Initialize("Personal Information", "DB Information", 1, 0, 1, "MembershipDate1");
            pData._IP_Mapping_Initialize("Personal Information", "Beneficiary Information", 1, 0, 1, "Beneficiary1ID");
            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "EmployeeIDNumber");


            pData._IP_Mapping_MapField("ParticipantStatus", "PARTSTAT", 0, false, 6);
            pData._IP_Mapping_MapField("PayStatus", "PAYSTAT", 0, true);
            pData._IP_Mapping_MapField("HealthStatus", "EHEALTH", 0, true);
            pData._IP_Mapping_MapField("Beneficiary1Percent1", "JSPCT", 0, true, 15);

            pData._IP_Mapping_MapField("AccruedBenefit1", "ADDACRUE", 0, true, 8);
            pData._IP_Mapping_MapField("CredService", "ESVC", 0, true, 13);
            pData._IP_Mapping_MapField("VestService", "ESVV", 0, true);
            pData._IP_Mapping_MapField("Benefit2DB", "PBEN2", 0, true);
            pData._IP_Mapping_MapField("Benefit3DB", "PBEN3", 0, true);

            pData._IP_Mapping_MapField("GRSFundingAL", "EPVBTY", 5, true, 20);
            pData._IP_Mapping_MapField("GRSFundingNC", "ECYCTY", 5, true);
            pData._IP_Mapping_MapField("GRSAccountingAL", "PBOTY", 5, true);
            pData._IP_Mapping_MapField("GRSAccountingNC", "PBOSCTY", 5, true);

            mTime.StopTimer(iData2006_MP_MapFields);
            mLog.LogInfo(iData2006_MP_MapFields, MyPerformanceCounter.Memory_Private);




            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_Mapping(dic);

            pData._SelectTab("Mapping");

            mTime.StopTimer(iData2006_MP_Preview);
            mLog.LogInfo(iData2006_MP_Preview, MyPerformanceCounter.Memory_Private);



            pData._SelectTab("Validate & Load");


            mTime.StartTimer();

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

            mTime.StopTimer(iData2006_ValidateAndLoad);
            mLog.LogInfo(iData2006_ValidateAndLoad, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Status", "STAGED");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("ValidateData", "");
            dic.Add("LoadData", "");
            dic.Add("ValidateAndLoadData", "");
            pData._PopVerify_IP_ValidateAndLoad(dic);




            pData._SelectTab("Pre Matching Derivations");

            mTime.StartTimer();

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
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "HealthStatus");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=\"H\"");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            pData._SelectTab("Pre Matching Derivations");

            mTime.StopTimer(iData2006_PMD_Add);
            mLog.LogInfo(iData2006_PMD_Add, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

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
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            pData._SelectTab("Pre Matching Derivations");

            mTime.StopTimer(iData2006_PMD_CalcPreview);
            mLog.LogInfo(iData2006_PMD_CalcPreview, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

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
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);

            mTime.StopTimer(iData2006_PMD_SaveToStage);
            mLog.LogInfo(iData2006_PMD_SaveToStage, MyPerformanceCounter.Memory_Private);




            pData._SelectTab("Matching");

            dic.Clear();
            dic.Add("Field", "EmployeeIDNumber");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);

            pData._SelectTab("Matching");

            mTime.StopTimer(iData2006_Matching_FindMatch);
            mLog.LogInfo(iData2006_Matching_FindMatch, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "590");
            dic.Add("Unique_UniqueMatch_Num", "0");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "0");
            dic.Add("Duplicate_UniqueMatch_Num", "0");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
            dic.Add("Warehouse_NoMatch_Num", "0");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);


            mTime.StartTimer();

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

            mTime.StopTimer(iData2006_Matching_AcceptAllNew);
            mLog.LogInfo(iData2006_Matching_AcceptAllNew, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Matched_Num", "0");
            dic.Add("New_Num", "590");
            dic.Add("Ignored_Num", "0");
            dic.Add("Gone_Num", "0");
            dic.Add("Leaver_Num", "0");
            dic.Add("Unmatched_Num", "0");
            dic.Add("Unmerged_Num", "0");
            pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic);

            mTime.StartTimer();

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


            mTime.StopTimer(iData2006_Matching_SaveToWarehouse);
            mLog.LogInfo(iData2006_Matching_SaveToWarehouse, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data 2006");
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            pMain._SelectTab("Data 2006");

            mTime.StopTimer(iData2006_SP_AddNew);
            mLog.LogInfo(iData2006_SP_AddNew, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "USC");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ExitDate");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "TerminationDate1");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "DeathDate");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "MaritalStatus");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ImportName");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1BirthDate");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1Gender");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1Percent1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "MembershipDate1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit1DB");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedBenefit1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "StartDate1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "PaymentForm1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "YearsCertain1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "CredService");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "VestService");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit2DB");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit3DB");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Funding Results");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Accounting Results");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Val Data");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            pMain._Home_ToolbarClick_Top(true);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "Click");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);


            pMain._SelectTab("Data 2006");

            mTime.StopTimer(iData2006_SP_Preview);
            mLog.LogInfo(iData2006_SP_Preview, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "Click");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_SP_Snapshots_Popup(dic);

            mTime.StopTimer(iData2006_SP_Publish);
            mLog.LogInfo(iData2006_SP_Publish, MyPerformanceCounter.Memory_Private);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion

            

            #region sOutputFunding_July2006Valuation



            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "July 2006 Valuation");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "2006");
            dic.Add("FirstYearPlanUnderPPA", "");
            //dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            pMain._SelectTab("Home");

            mTime.StopTimer(iJuly2006Val_AddService);
            mLog.LogInfo(iJuly2006Val_AddService, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "July 2006 Valuation");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            mTime.StopTimer(iJuly2006Val_OpenService);
            mLog.LogInfo(iJuly2006Val_OpenService, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("July 2006 Valuation");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Data");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Participant DataSet");

            mTime.StopTimer(iJuly2006Val_Data_OpenDataSet);
            mLog.LogInfo(iJuly2006Val_Data_OpenDataSet, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

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
            dic.Add("SnapshotName", "Val Data");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);

            pMain._SelectTab("Participant DataSet");

            mTime.StopTimer(iJuly2006Val_Data_SelectSnapshot);
            mLog.LogInfo(iJuly2006Val_Data_SelectSnapshot, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "Click");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("Decrement", "Retirement");
            dic.Add("FundingAL", "8598183");
            dic.Add("FundingNC", "428354");
            dic.Add("AccountingAL", "8909671");
            dic.Add("AccountingNC", "446021");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_TotalsByDecrement(dic);

            dic.Clear();
            dic.Add("Decrement", "Withdrawal");
            dic.Add("FundingAL", "508171");
            dic.Add("FundingNC", "51280");
            dic.Add("AccountingAL", "532098");
            dic.Add("AccountingNC", "53778");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_TotalsByDecrement(dic);

            dic.Clear();
            dic.Add("Decrement", "Death");
            dic.Add("FundingAL", "231536");
            dic.Add("FundingNC", "13071");
            dic.Add("AccountingAL", "185780");
            dic.Add("AccountingNC", "10335");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_TotalsByDecrement(dic);


            dic.Clear();
            dic.Add("Liability", "PPA NAR PVVB Active");
            dic.Add("AL", "123456789");
            dic.Add("NC", "987654321");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_AdditionalLiabilityTotals(dic);


            dic.Clear();
            dic.Add("Liability", "PPA NAR PVVB Inactive");
            dic.Add("AL", "12345678");
            dic.Add("NC", "");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_AdditionalLiabilityTotals(dic);

            dic.Clear();
            dic.Add("Liability", "PPA NAR Max");
            dic.Add("AL", "1234567");
            dic.Add("NC", "7654321");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_AdditionalLiabilityTotals(dic);

            dic.Clear();
            dic.Add("Liability", "PBGC NAR PVVB");
            dic.Add("AL", "123456");
            dic.Add("NC", "654321");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_AdditionalLiabilityTotals(dic);

            dic.Clear();
            dic.Add("Liability", "FAS35 PVAB");
            dic.Add("AL", "12345");
            dic.Add("NC", "54321");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_AdditionalLiabilityTotals(dic);

            dic.Clear();
            dic.Add("Liability", "FAS35 PVVB");
            dic.Add("AL", "1234");
            dic.Add("NC", "4321");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_AdditionalLiabilityTotals(dic);

            dic.Clear();
            dic.Add("Row", "Number");
            dic.Add("Active", "284");
            dic.Add("Deferred", "65");
            dic.Add("Retired", "241");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

            dic.Clear();
            dic.Add("Row", "Average Age");
            dic.Add("Active", "42.47");
            dic.Add("Deferred", "48.14");
            dic.Add("Retired", "73.64");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

            dic.Clear();
            dic.Add("Row", "Average Service from Hire");
            dic.Add("Active", "12.80");
            dic.Add("Deferred", "");
            dic.Add("Retired", "");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

            dic.Clear();
            dic.Add("Row", "Average Pay");
            dic.Add("Active", "0");
            dic.Add("Deferred", "");
            dic.Add("Retired", "");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

            dic.Clear();
            dic.Add("Row", "Annual Pension");
            dic.Add("Active", "");
            dic.Add("Deferred", "1950");
            dic.Add("Retired", "11000");
            dic.Add("OK", "Click");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);


            mTime.StartTimer();

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

            mTime.StopTimer(iJuly2006Val_Data_Import);
            mLog.LogInfo(iJuly2006Val_Data_Import, MyPerformanceCounter.Memory_Private);


            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("July 2006 Valuation");

            dic.Clear();
            dic.Add("MenuItem_1", "File");
            dic.Add("MenuItem_2", "Import Tables");
            pMain._MenuSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("GRSServer", "Deerfield");
            dic.Add("LoginID", "user1");
            dic.Add("Password", "user1");
            dic.Add("OK", "Click");
            pParticipantDataSet._PopVerify_GRSLogin(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", "L063 - Drummond for UAT2");
            dic.Add("OK", "Click");
            pParticipantDataSet._PopVerify_GRSClientForTableImport(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectAll", "Click");
            dic.Add("Import", "Click");
            dic.Add("NumOfTablesImported", "12");
            pParticipantDataSet._PopVerify_SourceTable(dic);

            pMain._Home_ToolbarClick_Top(true);




            pMain._SelectTab("July 2006 Valuation");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iJuly2006Val_Assump_OpenAssumptions);
            mLog.LogInfo(iJuly2006Val_Assump_OpenAssumptions, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("MenuItem", "Add New Liability Type/Projection Folder");
            pAssumptions._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "FAS35Int");
            dic.Add("EAN", "");
            dic.Add("FAS35PVAB", "True");
            dic.Add("FAS35PVVB", "True");
            dic.Add("Nondiscrimination", "");
            dic.Add("PBGCARPVVB", "");
            dic.Add("PBGCNARPVVB", "");
            dic.Add("PBGCPlanTerm", "");
            dic.Add("PPAARMax", "");
            dic.Add("PPAARMin", "");
            dic.Add("PPAARPVVB", "");
            dic.Add("PPANARMax", "");
            dic.Add("PPANARMin", "");
            dic.Add("PPANARPVVB", "");
            dic.Add("Projection", "");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);


            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iJuly2006Val_Assump_InterestRate_AddFolder);
            mLog.LogInfo(iJuly2006Val_Assump_InterestRate_AddFolder, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "FAS35Int");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iJuly2006Val_Assump_InterestRate_Select);
            mLog.LogInfo(iJuly2006Val_Assump_InterestRate_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "8.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iJuly2006Val_Assump_InterestRate_Edit);
            mLog.LogInfo(iJuly2006Val_Assump_InterestRate_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iJuly2006Val_Assump_InterestRate_Save);
            mLog.LogInfo(iJuly2006Val_Assump_InterestRate_Save, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("MenuItem", "Add New Liability Type/Projection Folder");
            pAssumptions._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "PBGCInt");
            dic.Add("EAN", "");
            dic.Add("FAS35PVAB", "");
            dic.Add("FAS35PVVB", "");
            dic.Add("Nondiscrimination", "");
            dic.Add("PBGCARPVVB", "True");
            dic.Add("PBGCNARPVVB", "True");
            dic.Add("PBGCPlanTerm", "");
            dic.Add("PPAARMax", "");
            dic.Add("PPAARMin", "");
            dic.Add("PPAARPVVB", "");
            dic.Add("PPANARMax", "");
            dic.Add("PPANARMin", "");
            dic.Add("PPANARPVVB", "");
            dic.Add("Projection", "");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "PBGCInt");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "6.32");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AllOthers");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "5.77");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);



            mTime.StartTimer();


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iJuly2006Val_Assump_OtherDemographicAssumptions_Select);
            mLog.LogInfo(iJuly2006Val_Assump_OtherDemographicAssumptions_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "90.0");
            dic.Add("txtPercentMarried_F", "90.0");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "-2");
            dic.Add("txtDifferenceInSpouseAge_F", "2");
            dic.Add("cboDifferenceInSpouseAge", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);

            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iJuly2006Val_Assump_OtherDemographicAssumptions_Edit);
            mLog.LogInfo(iJuly2006Val_Assump_OtherDemographicAssumptions_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iJuly2006Val_Assump_OtherDemographicAssumptions_Save);
            mLog.LogInfo(iJuly2006Val_Assump_OtherDemographicAssumptions_Save, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "_Death");
            dic.Add("MenuItem", "Add New Liability Type/Projection Folder");
            pAssumptions._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "PPAMort");
            dic.Add("EAN", "");
            dic.Add("FAS35PVAB", "");
            dic.Add("FAS35PVVB", "");
            dic.Add("Nondiscrimination", "");
            dic.Add("PBGCARPVVB", "");
            dic.Add("PBGCNARPVVB", "");
            dic.Add("PBGCPlanTerm", "");
            dic.Add("PPAARMax", "True");
            dic.Add("PPAARMin", "True");
            dic.Add("PPAARPVVB", "True");
            dic.Add("PPANARMax", "True");
            dic.Add("PPANARMin", "True");
            dic.Add("PPANARPVVB", "True");
            dic.Add("Projection", "");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);

            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iJuly2006Val_Assump_MortalityDecrement_AddFolder);
            mLog.LogInfo(iJuly2006Val_Assump_MortalityDecrement_AddFolder, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "_Death");
            dic.Add("Level_4", "PPAMort");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iJuly2006Val_Assump_MortalityDecrement_Select);
            mLog.LogInfo(iJuly2006Val_Assump_MortalityDecrement_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "GA83");
            dic.Add("Mortality_Setback_M", "");
            dic.Add("Mortality_Setback_F", "");
            dic.Add("Disabled", "");
            dic.Add("Disabled_Setback_M", "");
            dic.Add("Disabled_Setback_F", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);

            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iJuly2006Val_Assump_MortalityDecrement_Edit);
            mLog.LogInfo(iJuly2006Val_Assump_MortalityDecrement_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iJuly2006Val_Assump_MortalityDecrement_Save);
            mLog.LogInfo(iJuly2006Val_Assump_MortalityDecrement_Save, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "_Death");
            dic.Add("Level_4", "AllOthers");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "GATT03");
            dic.Add("Mortality_Setback_M", "");
            dic.Add("Mortality_Setback_F", "");
            dic.Add("Disabled", "");
            dic.Add("Disabled_Setback_M", "");
            dic.Add("Disabled_Setback_F", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("July 2006 Valuation");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Provisions");


            mTime.StopTimer(iJuly2006Val_Prov_OpenProvisions);
            mLog.LogInfo(iJuly2006Val_Prov_OpenProvisions, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "CreditedService");

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_Service_Add);
            mLog.LogInfo(iJuly2006Val_Prov_Service_Add, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "CreditedService");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_Service_Select);
            mLog.LogInfo(iJuly2006Val_Prov_Service_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "True");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            pService._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Date", "CredService");
            dic.Add("RoundingRule", "Completed months");
            pService._PopVerify_RulesBasedService(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_Service_Edit);
            mLog.LogInfo(iJuly2006Val_Prov_Service_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_Service_Save);
            mLog.LogInfo(iJuly2006Val_Prov_Service_Save, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "VestingService");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "VestingService");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "True");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Date", "VestService");
            dic.Add("RoundingRule", "Nearest years");
            pService._PopVerify_RulesBasedService(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "ServiceOver15");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "ServiceOver15");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "True");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "Max($CreditedService - 15.0, 0.0)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "ServiceOver30");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "ServiceOver30");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "True");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "Max($CreditedService - 30.0, 0.0)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "Age55with30or65");


            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_FromToAge_Add);
            mLog.LogInfo(iJuly2006Val_Prov_FromToAge_Add, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "Age55with30or65");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_FromToAge_Select);
            mLog.LogInfo(iJuly2006Val_Prov_FromToAge_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "55");
            dic.Add("YearOfService", "30");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "CreditedService");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "Earlier of");
            pFromToAge._StandardTable(dic);


            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "Click");
            dic.Add("iRow", "2");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "65");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable(dic);


            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_FromToAge_Edit);
            mLog.LogInfo(iJuly2006Val_Prov_FromToAge_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_FromToAge_Save);
            mLog.LogInfo(iJuly2006Val_Prov_FromToAge_Save, MyPerformanceCounter.Memory_Private);





            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "AboveOr60with10");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "AboveOr60with10");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "60");
            dic.Add("YearOfService", "10");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable(dic);

            dic.Clear();
            dic.Add("Comparison", "Earlier of");
            dic.Add("FromToAge", "Age55with30or65");
            pFromToAge._Standard_CompareAboveResultsTable(dic);






            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "RetireElig");

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_Eligibilities_Add);
            mLog.LogInfo(iJuly2006Val_Prov_Eligibilities_Add, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "RetireElig");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_Eligibilities_Select);
            mLog.LogInfo(iJuly2006Val_Prov_Eligibilities_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$Age >= $AboveOr60with10");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_Eligibilities_Edit);
            mLog.LogInfo(iJuly2006Val_Prov_Eligibilities_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_Eligibilities_Save);
            mLog.LogInfo(iJuly2006Val_Prov_Eligibilities_Save, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Special Eligibilities");
            dic.Add("Level_3", "_ARRet");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_SpecialEligibilities_Select);
            mLog.LogInfo(iJuly2006Val_Prov_SpecialEligibilities_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Simple", "");
            dic.Add("Advanced", "True");
            pSpecialEligibilities._PopVerify_Main(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_SpecialEligibilities_Edit);
            mLog.LogInfo(iJuly2006Val_Prov_SpecialEligibilities_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_SpecialEligibilities_Save);
            mLog.LogInfo(iJuly2006Val_Prov_SpecialEligibilities_Save, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Special Eligibilities");
            dic.Add("Level_3", "_ARImmWth");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Simple", "");
            dic.Add("Advanced", "True");
            pSpecialEligibilities._PopVerify_Main(dic);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "PayFor415Limit");

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_PayProjection_Add);
            mLog.LogInfo(iJuly2006Val_Prov_PayProjection_Add, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "PayFor415Limit");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_PayProjection_Select);
            mLog.LogInfo(iJuly2006Val_Prov_PayProjection_Select, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "True");
            dic.Add("CustomCode", "");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("LegislatedPayLimitDefinition", "");
            pPayoutProjection._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("History", "");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "");
            dic.Add("CustomCode", "");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("LegislatedPayLimitDefinition", "True");
            pPayoutProjection._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "9999999");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_PayProjection_Edit);
            mLog.LogInfo(iJuly2006Val_Prov_PayProjection_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_PayProjection_Save);
            mLog.LogInfo(iJuly2006Val_Prov_PayProjection_Save, MyPerformanceCounter.Memory_Private);





            pMain._SelectTab("Assumptions");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iJuly2006Val_Assump_RetirementDecrement_Select);
            mLog.LogInfo(iJuly2006Val_Assump_RetirementDecrement_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERORET");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);


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

            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "RetireElig");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pAssumptions._SelectTab("Parameters");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "RETRATES");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iJuly2006Val_Assump_RetirementDecrement_Edit);
            mLog.LogInfo(iJuly2006Val_Assump_RetirementDecrement_Edit, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iJuly2006Val_Assump_RetirementDecrement_Save);
            mLog.LogInfo(iJuly2006Val_Assump_RetirementDecrement_Save, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iJuly2006Val_Assump_WithdrawalDecrement_Select);
            mLog.LogInfo(iJuly2006Val_Assump_WithdrawalDecrement_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "WTHDRAL");
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

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZEROWTH");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "RetireElig");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iJuly2006Val_Assump_WithdrawalDecrement_Edit);
            mLog.LogInfo(iJuly2006Val_Assump_WithdrawalDecrement_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iJuly2006Val_Assump_WithdrawalDecrement_Save);
            mLog.LogInfo(iJuly2006Val_Assump_WithdrawalDecrement_Save, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "_Disability");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iJuly2006Val_Assump_DisabilityDecrement_Select);
            mLog.LogInfo(iJuly2006Val_Assump_DisabilityDecrement_Select, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERODIS");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iJuly2006Val_Assump_DisabilityDecrement_Edit);
            mLog.LogInfo(iJuly2006Val_Assump_DisabilityDecrement_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Assumptions");

            mTime.StopTimer(iJuly2006Val_Assump_DisabilityDecrement_Save);
            mLog.LogInfo(iJuly2006Val_Assump_DisabilityDecrement_Save, MyPerformanceCounter.Memory_Private);





            pMain._SelectTab("Provisions");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            pAssumptions._Collapse(dic);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Unit Formula");
            dic.Add("MenuItem", "Add Unit Formula");
            pAssumptions._TreeViewRightSelect(dic, "UnitUnder15");

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_UnitFormula_Add);
            mLog.LogInfo(iJuly2006Val_Prov_UnitFormula_Add, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Unit Formula");
            dic.Add("Level_4", "UnitUnder15");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_UnitFormula_Select);
            mLog.LogInfo(iJuly2006Val_Prov_UnitFormula_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Service", "CreditedService");
            dic.Add("LimitServiceTo", "15");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccuralAt_C", "");
            dic.Add("StopAccuralAt_cbo", "");
            dic.Add("StopAccuralAt_txt", "");
            dic.Add("RateTiersBasedOn", "Plan Year");
            dic.Add("NumberOfRateTiers", "3");
            pUnitFormula._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "1");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "3");
            dic.Add("sData", "2007");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "2");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "3");
            dic.Add("sData", "2008");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "3");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "3");
            dic.Add("sData", "3000");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "1");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "3");
            dic.Add("sData", "288.00");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "3");
            dic.Add("sData", "306.00");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "3");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "3");
            dic.Add("sData", "354.00");
            pUnitFormula._FormulaTable(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_UnitFormula_Edit);
            mLog.LogInfo(iJuly2006Val_Prov_UnitFormula_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_UnitFormula_Save);
            mLog.LogInfo(iJuly2006Val_Prov_UnitFormula_Save, MyPerformanceCounter.Memory_Private);





            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Unit Formula");
            dic.Add("MenuItem", "Add Unit Formula");
            pAssumptions._TreeViewRightSelect(dic, "Unit15to30");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Unit Formula");
            dic.Add("Level_4", "Unit15to30");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Service", "ServiceOver15");
            dic.Add("LimitServiceTo", "15");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccuralAt_C", "");
            dic.Add("StopAccuralAt_cbo", "");
            dic.Add("StopAccuralAt_txt", "");
            dic.Add("RateTiersBasedOn", "Plan Year");
            dic.Add("NumberOfRateTiers", "3");
            pUnitFormula._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "1");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "3");
            dic.Add("sData", "2007");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "2");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "3");
            dic.Add("sData", "2008");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "3");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "3");
            dic.Add("sData", "3000");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "1");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "3");
            dic.Add("sData", "378.00");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "3");
            dic.Add("sData", "402.00");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "3");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "3");
            dic.Add("sData", "450.00");
            pUnitFormula._FormulaTable(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Unit Formula");
            dic.Add("MenuItem", "Add Unit Formula");
            pAssumptions._TreeViewRightSelect(dic, "UnitOver30");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Unit Formula");
            dic.Add("Level_4", "UnitOver30");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Service", "ServiceOver30");
            dic.Add("LimitServiceTo", "99");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccuralAt_C", "");
            dic.Add("StopAccuralAt_cbo", "");
            dic.Add("StopAccuralAt_txt", "");
            dic.Add("RateTiersBasedOn", "Plan Year");
            dic.Add("NumberOfRateTiers", "2");
            pUnitFormula._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "1");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "2");
            dic.Add("sData", "2008");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "2");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "2");
            dic.Add("sData", "3000");
            pUnitFormula._FormulaTable(dic);


            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "1");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "2");
            dic.Add("sData", "456.00");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "2");
            dic.Add("sData", "516.00");
            pUnitFormula._FormulaTable(dic);




            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            pAssumptions._Collapse(dic);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "FinalBenefit");

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_CustomFormulaB_Add);
            mLog.LogInfo(iJuly2006Val_Prov_CustomFormulaB_Add, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "FinalBenefit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_CustomFormulaB_Select);
            mLog.LogInfo(iJuly2006Val_Prov_CustomFormulaB_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccruedBenefit1 + $UnitUnder15 + $Unit15to30 + $UnitOver30");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_CustomFormulaB_Edit);
            mLog.LogInfo(iJuly2006Val_Prov_CustomFormulaB_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_CustomFormulaB_Save);
            mLog.LogInfo(iJuly2006Val_Prov_CustomFormulaB_Save, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            dic.Add("MenuItem", "Add Vesting");
            pAssumptions._TreeViewRightSelect(dic, "Vesting1");

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_Vesting_Add);
            mLog.LogInfo(iJuly2006Val_Prov_Vesting_Add, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            dic.Add("Level_3", "Vesting1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_Vesting_Select);
            mLog.LogInfo(iJuly2006Val_Prov_Vesting_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VestingServiceDefinition", "VestingService");
            dic.Add("AddRow", "");
            pVesting._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("YearsOfService", "5");
            dic.Add("VestingPercentage", "100.0");
            pVesting._ServiceTable(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            dic.Add("Level_3", "Vesting1");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Age55or30or65");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            dic.Add("Level_3", "Vesting1");
            dic.Add("Level_4", "Age55or30or65");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("YearsOfService", "0");
            dic.Add("VestingPercentage", "100.0");
            pVesting._ServiceTable(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$Age >= $Age55with30or65");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_Vesting_Edit);
            mLog.LogInfo(iJuly2006Val_Prov_Vesting_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_Vesting_Save);
            mLog.LogInfo(iJuly2006Val_Prov_Vesting_Save, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "GrowInCOLA");

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_COLA_Add);
            mLog.LogInfo(iJuly2006Val_Prov_COLA_Add, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Cost of Living Adjustments");
            dic.Add("Level_3", "GrowInCOLA");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_COLA_Select);
            mLog.LogInfo(iJuly2006Val_Prov_COLA_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("COLA_After_V", "");
            dic.Add("COLA_After_Percent", "");
            dic.Add("COLA_After_T", "Click");
            dic.Add("Rate_cbo", "GROWIN08");
            pCostOfLivingAdjustments._PopVerify_Main(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_COLA_Edit);
            mLog.LogInfo(iJuly2006Val_Prov_COLA_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_COLA_Save);
            mLog.LogInfo(iJuly2006Val_Prov_COLA_Save, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Early Retirement Factors");
            dic.Add("MenuItem", "Add Early Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "EarlyRetirementFactors1");

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_ERF_Add);
            mLog.LogInfo(iJuly2006Val_Prov_ERF_Add, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Early Retirement Factors");
            dic.Add("Level_3", "EarlyRetirementFactors1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_ERF_Select);
            mLog.LogInfo(iJuly2006Val_Prov_ERF_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("AgeInterval", "True");
            dic.Add("YearInterval", "");
            dic.Add("TabularOrActuarially", "");
            dic.Add("CustomCode", "");
            pEarlyRetirementFactor._PopVerify_Main(dic);


            pEarlyRetirementFactor._TBL_ReductionDefinition(1, "60", "6.0");



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Early Retirement Factors");
            dic.Add("Level_3", "EarlyRetirementFactors1");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Age55and30or65");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Early Retirement Factors");
            dic.Add("Level_3", "EarlyRetirementFactors1");
            dic.Add("Level_4", "Age55and30or65");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "");
            dic.Add("Button_C", "");
            dic.Add("AgeAtWhichReductionEnds_cbo", "");
            dic.Add("AgeAtWhichReductionEnds_txt", "50");
            pEarlyRetirementFactor._PopVerify_AgeYearInterval(dic);

            pEarlyRetirementFactor._TBL_ReductionDefinition(1, "40", "0.0");

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$Age >= $Age55with30or65");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_ERF_Edit);
            mLog.LogInfo(iJuly2006Val_Prov_ERF_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_ERF_Save);
            mLog.LogInfo(iJuly2006Val_Prov_ERF_Save, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            pAssumptions._TreeViewSelect(dic);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "JS50");

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_FOP_Add);
            mLog.LogInfo(iJuly2006Val_Prov_FOP_Add, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "JS50");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_FOP_Select);
            mLog.LogInfo(iJuly2006Val_Prov_FOP_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Joint and survivor");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "Click");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            dic.Add("btnSurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "Click");
            dic.Add("SurvivorPercentOrAmount_txt", "50.0");
            dic.Add("cboSurvivorPercentOrAmount_PercentOrAmount", "");
            dic.Add("btnPopupAmount_V", "");
            dic.Add("PopupAmount_cbo", "");
            dic.Add("btnPopupAmount_C", "");
            dic.Add("PopupAmount_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_V", "");
            dic.Add("NumberOfPaymentsPerYear_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_C", "");
            dic.Add("NumberOfPaymentsPerYear_txt", "");
            pFormOfPayment._PopVerify_FormOfPayment(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_FOP_Edit);
            mLog.LogInfo(iJuly2006Val_Prov_FOP_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_FOP_Save);
            mLog.LogInfo(iJuly2006Val_Prov_FOP_Save, MyPerformanceCounter.Memory_Private);





            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "Life");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "Life");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Straight life");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "Click");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            dic.Add("btnSurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "Click");
            dic.Add("SurvivorPercentOrAmount_txt", "");
            dic.Add("cboSurvivorPercentOrAmount_PercentOrAmount", "");
            dic.Add("btnPopupAmount_V", "");
            dic.Add("PopupAmount_cbo", "");
            dic.Add("btnPopupAmount_C", "");
            dic.Add("PopupAmount_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_V", "");
            dic.Add("NumberOfPaymentsPerYear_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_C", "");
            dic.Add("NumberOfPaymentsPerYear_txt", "");
            pFormOfPayment._PopVerify_FormOfPayment(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "SpouseLife50");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "SpouseLife50");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Spouse's");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "Click");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            dic.Add("btnSurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "Click");
            dic.Add("SurvivorPercentOrAmount_txt", "50.0");
            dic.Add("cboSurvivorPercentOrAmount_PercentOrAmount", "");
            dic.Add("btnPopupAmount_V", "");
            dic.Add("PopupAmount_cbo", "");
            dic.Add("btnPopupAmount_C", "");
            dic.Add("PopupAmount_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_V", "");
            dic.Add("NumberOfPaymentsPerYear_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_C", "");
            dic.Add("NumberOfPaymentsPerYear_txt", "");
            pFormOfPayment._PopVerify_FormOfPayment(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "SpouseDID");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "SpouseDID");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Spouse's annuity for death in deferral");
            dic.Add("MortalityInReferralPeriod", "");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "Click");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            dic.Add("btnSurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "Click");
            dic.Add("SurvivorPercentOrAmount_txt", "50.0");
            dic.Add("cboSurvivorPercentOrAmount_PercentOrAmount", "");
            dic.Add("btnPopupAmount_V", "");
            dic.Add("PopupAmount_cbo", "");
            dic.Add("btnPopupAmount_C", "");
            dic.Add("PopupAmount_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_V", "");
            dic.Add("NumberOfPaymentsPerYear_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_C", "");
            dic.Add("NumberOfPaymentsPerYear_txt", "");
            pFormOfPayment._PopVerify_FormOfPayment(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "ForInactives");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "ForInactives");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Straight life");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "Click");
            dic.Add("GuaranteePeriod_cbo", "YearsCertain1");
            dic.Add("btnGuaranteePeriod_C", "");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            dic.Add("btnSurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "Click");
            dic.Add("SurvivorPercentOrAmount_txt", "");
            dic.Add("cboSurvivorPercentOrAmount_PercentOrAmount", "");
            dic.Add("btnPopupAmount_V", "");
            dic.Add("PopupAmount_cbo", "");
            dic.Add("btnPopupAmount_C", "");
            dic.Add("PopupAmount_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_V", "");
            dic.Add("NumberOfPaymentsPerYear_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_C", "");
            dic.Add("NumberOfPaymentsPerYear_txt", "");
            pFormOfPayment._PopVerify_FormOfPayment(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "ForInactives");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "JSForm");


            //////dic.Clear();
            //////dic.Add("Level_1", "Provisions");
            //////dic.Add("Level_2", "Form of Payment");
            //////dic.Add("Level_3", "ForInactives");
            //////dic.Add("Level_4", "JSForm");
            //////pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Joint and survivor");
            dic.Add("MortalityInReferralPeriod", "Joint life mortality");
            dic.Add("btnGuaranteePeriod_V", "Click");
            dic.Add("GuaranteePeriod_cbo", "YearsCertain1");
            dic.Add("btnGuaranteePeriod_C", "");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            dic.Add("btnSurvivorPercentOrAmount_V", "Click");
            dic.Add("SurvivorPercentOrAmount_cbo", "Beneficiary1Percent1");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "");
            dic.Add("SurvivorPercentOrAmount_txt", "");
            dic.Add("cboSurvivorPercentOrAmount_PercentOrAmount", "");
            dic.Add("btnPopupAmount_V", "");
            dic.Add("PopupAmount_cbo", "");
            dic.Add("btnPopupAmount_C", "");
            dic.Add("PopupAmount_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_V", "");
            dic.Add("NumberOfPaymentsPerYear_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_C", "");
            dic.Add("NumberOfPaymentsPerYear_txt", "");
            pFormOfPayment._PopVerify_FormOfPayment(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.PaymentForm1=\"J&S\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            pAssumptions._Collapse(dic);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "415 Limits");
            dic.Add("MenuItem", "Add 415 Limits");
            pAssumptions._TreeViewRightSelect(dic, "ImmLA");

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_415Limit_Add);
            mLog.LogInfo(iJuly2006Val_Prov_415Limit_Add, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "415 Limits");
            dic.Add("Level_3", "ImmLA");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_415Limit_Select);
            mLog.LogInfo(iJuly2006Val_Prov_415Limit_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DeterminLimitBasedOn", "Valuation year");
            dic.Add("DeterminLimitBasedOn_Year", "");
            dic.Add("IncreaseAppliesUntil", "Employment termination");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "15");
            dic.Add("EarlyRetirementFator", "EarlyRetirementFactors1");
            dic.Add("LateRetirementFactor", "");
            dic.Add("PlanNormalFormOfPayment", "Life");
            dic.Add("ConversionFactorNormalFromToStraightLife", "");
            dic.Add("btnPlanNormalFromStopAge_V", "");
            dic.Add("PlanNormalFromStopAge_cbo", "");
            dic.Add("btnPlanNormalFromStopAge_C", "Click");
            dic.Add("PlanNormalFromStopAge_txt", "");
            dic.Add("PlanActuarialEquivalence", "");
            dic.Add("415LimitFormOfPayement", "Life");
            dic.Add("ConversionFactorNormalFromTo", "");
            dic.Add("btn415LimitFormStopAge_V", "");
            dic.Add("415LimitFormStopAge_cbo", "");
            dic.Add("btn415LimitFormStopAge_C", "");
            dic.Add("415LimitFormStopAge_txt", "");
            dic.Add("ParticipationService", "VestingService");
            dic.Add("MandatoryEmployeeContribution", "");
            dic.Add("ProjectedPayForAlternative", "PayFor415Limit");
            dic.Add("EmploymentService", "$Service");
            p415Limits._PopVerify_Standard(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_415Limit_Edit);
            mLog.LogInfo(iJuly2006Val_Prov_415Limit_Edit, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_415Limit_Save);
            mLog.LogInfo(iJuly2006Val_Prov_415Limit_Save, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "415 Limits");
            dic.Add("MenuItem", "Add 415 Limits");
            pAssumptions._TreeViewRightSelect(dic, "DefTo65LA");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "415 Limits");
            dic.Add("Level_3", "DefTo65LA");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DeterminLimitBasedOn", "Valuation year");
            dic.Add("DeterminLimitBasedOn_Year", "");
            dic.Add("IncreaseAppliesUntil", "Employment termination");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("EarlyRetirementFator", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("PlanNormalFormOfPayment", "Life");
            dic.Add("ConversionFactorNormalFromToStraightLife", "");
            dic.Add("btnPlanNormalFromStopAge_V", "");
            dic.Add("PlanNormalFromStopAge_cbo", "");
            dic.Add("btnPlanNormalFromStopAge_C", "Click");
            dic.Add("PlanNormalFromStopAge_txt", "");
            dic.Add("PlanActuarialEquivalence", "");
            dic.Add("415LimitFormOfPayement", "Life");
            dic.Add("ConversionFactorNormalFromTo", "");
            dic.Add("btn415LimitFormStopAge_V", "");
            dic.Add("415LimitFormStopAge_cbo", "");
            dic.Add("btn415LimitFormStopAge_C", "");
            dic.Add("415LimitFormStopAge_txt", "");
            dic.Add("ParticipationService", "VestingService");
            dic.Add("MandatoryEmployeeContribution", "");
            dic.Add("ProjectedPayForAlternative", "PayFor415Limit");
            dic.Add("EmploymentService", "$Service");
            p415Limits._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "415 Limits");
            dic.Add("MenuItem", "Add 415 Limits");
            pAssumptions._TreeViewRightSelect(dic, "DelTo60JS50");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "415 Limits");
            dic.Add("Level_3", "DelTo60JS50");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DeterminLimitBasedOn", "Valuation year");
            dic.Add("DeterminLimitBasedOn_Year", "");
            dic.Add("IncreaseAppliesUntil", "Employment termination");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "60");
            dic.Add("EarlyRetirementFator", "EarlyRetirementFactors1");
            dic.Add("LateRetirementFactor", "");
            dic.Add("PlanNormalFormOfPayment", "Life");
            dic.Add("ConversionFactorNormalFromToStraightLife", "");
            dic.Add("btnPlanNormalFromStopAge_V", "");
            dic.Add("PlanNormalFromStopAge_cbo", "");
            dic.Add("btnPlanNormalFromStopAge_C", "Click");
            dic.Add("PlanNormalFromStopAge_txt", "");
            dic.Add("PlanActuarialEquivalence", "");
            dic.Add("415LimitFormOfPayement", "SpouseLife50");
            dic.Add("ConversionFactorNormalFromTo", "");
            dic.Add("btn415LimitFormStopAge_V", "");
            dic.Add("415LimitFormStopAge_cbo", "");
            dic.Add("btn415LimitFormStopAge_C", "");
            dic.Add("415LimitFormStopAge_txt", "");
            dic.Add("ParticipationService", "VestingService");
            dic.Add("MandatoryEmployeeContribution", "");
            dic.Add("ProjectedPayForAlternative", "PayFor415Limit");
            dic.Add("EmploymentService", "$Service");
            p415Limits._PopVerify_Standard(dic);





            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Adjustments");
            dic.Add("MenuItem", "Add Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "DisabilityLoad");

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_Adjustments_Add);
            mLog.LogInfo(iJuly2006Val_Prov_Adjustments_Add, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Adjustments");
            dic.Add("Level_3", "DisabilityLoad");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_Adjustments_Select);
            mLog.LogInfo(iJuly2006Val_Prov_Adjustments_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LoadingFactor_V", "");
            dic.Add("LoadingFactor_C", "Click");
            dic.Add("LoadingFactor_T", "");
            dic.Add("LoadingFactor_cboV", "");
            dic.Add("LoadingFactor_txt", "1.05");
            dic.Add("LoadingFactor_cboT", "");
            dic.Add("ApplyTo", "Benefit after 415 application");
            pAdjustments._PopVerify_Main(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_Adjustments_Edit);
            mLog.LogInfo(iJuly2006Val_Prov_Adjustments_Edit, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_Adjustments_Save);
            mLog.LogInfo(iJuly2006Val_Prov_Adjustments_Save, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            pAssumptions._Collapse(dic);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "RetLiab");

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_PlanDefintion_Add);
            mLog.LogInfo(iJuly2006Val_Prov_PlanDefintion_Add, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "RetLiab");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_PlanDefintion_Select);
            mLog.LogInfo(iJuly2006Val_Prov_PlanDefintion_Select, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "True");
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
            dic.Add("CostOfLivingAdjustmentFactor", "GrowInCOLA");
            dic.Add("EarlyRetirementFactor", "EarlyRetirementFactors1");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "DisabilityLoad");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "JS50");
            dic.Add("FormOfPayment_Single", "Life");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "ImmLA");
            dic.Add("MaximumBenefitLimitation_Single", "ImmLA");
            dic.Add("Decrement", "Retirement");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "RetLiab");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "True");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "FinalBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "GrowInCOLA");
            dic.Add("EarlyRetirementFactor", "EarlyRetirementFactors1");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "DisabilityLoad");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "JS50");
            dic.Add("FormOfPayment_Single", "Life");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "ImmLA");
            dic.Add("MaximumBenefitLimitation_Single", "ImmLA");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "RetireElig");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_PlanDefintion_Edit);
            mLog.LogInfo(iJuly2006Val_Prov_PlanDefintion_Edit, MyPerformanceCounter.Memory_Private);




            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_PlanDefintion_Save);
            mLog.LogInfo(iJuly2006Val_Prov_PlanDefintion_Save, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "WthLiab");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WthLiab");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "True");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "Vesting1");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "JS50");
            dic.Add("FormOfPayment_Single", "Life");
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
            dic.Add("Level_3", "WthLiab");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "VestedNotRetireElig");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "True");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "FinalBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "Vesting1");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "JS50");
            dic.Add("FormOfPayment_Single", "Life");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "DefTo65LA");
            dic.Add("MaximumBenefitLimitation_Single", "DefTo65LA");
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
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$Vesting1 > 0 and not $RetireElig");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);





            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "WthDID");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WthDID");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

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
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("VestingDefinition", "Vesting1");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "SpouseDID");
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
            dic.Add("Level_3", "WthDID");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "VestedNotRetired");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "FinalBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("VestingDefinition", "Vesting1");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "SpouseDID");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "DelTo60JS50");
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
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$Vesting1 > 0 and not $RetireElig");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "DthLiab");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "DthLiab");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "FinalBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "60");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "Vesting1");
            dic.Add("CostOfLivingAdjustmentFactor", "GrowInCOLA");
            dic.Add("EarlyRetirementFactor", "EarlyRetirementFactors1");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "SpouseLife50");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "DelTo60JS50");
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
            dic.Add("Level_3", "DthLiab");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Age55w30or65");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "FinalBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "GrowInCOLA");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "SpouseLife50");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "DelTo60JS50");
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
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$Age >= $Age55with30or65");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);




            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "InactLiab");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "InactLiab");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "All inactives");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "If($PaymentAge = $ValAge) $emp.Benefit1DB;" + Environment.NewLine + "else if($PaymentAge = $ValAge+1)Max($emp.Benefit1DB, $emp.Benefit2DB)" + Environment.NewLine + "else Max($emp.Benefit1DB, $emp.Benefit2DB, $emp.Benefit3DB)");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "Click");
            dic.Add("BenefitCommenceAge_cbo", "StartDate1");
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
            dic.Add("FormOfPayment", "ForInactives");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "InactDID");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "InactDID");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "Deferred inactives");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "If($PaymentAge = $ValAge) $emp.Benefit1DB;" + Environment.NewLine + "else if($PaymentAge = $ValAge + 1) Max($emp.Benefit1DB, $emp.Benefit2DB);" + Environment.NewLine + "else Max($emp.Benefit1DB, $emp.Benefit2DB, $emp.Benefit3DB)");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "SpouseDID");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "InactDID");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "DeferredJS");

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
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "SpouseDID");
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
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.PaymentForm1 = \"J&S\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            mTime.StopTimer(iJuly2006Val_Prov_Save);
            mLog.LogInfo(iJuly2006Val_Prov_Save, MyPerformanceCounter.Memory_Private);



            pMain._Home_ToolbarClick_Top(false);




            pMain._SelectTab("July 2006 Valuation");



            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Methods");

            mTime.StopTimer(iJuly2006Val_Methods_Open);
            mLog.LogInfo(iJuly2006Val_Methods_Open, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "Projected Unit Credit No Prorate");
            dic.Add("ServiceForServiceProrate", "");
            dic.Add("CompareToAccrue", "");
            dic.Add("AllowNegativeNormalCost", "");
            dic.Add("ProjectedpayToUse", "");
            dic.Add("AccumulationToUse", "");
            dic.Add("IncludeExitYearValue", "");
            dic.Add("CalculatePresentValueOfFuture", "");
            dic.Add("CalculatePresentValueOfFuture_txt", "");
            dic.Add("VestingToUseForAgeFirstVested", "");
            dic.Add("AverageWorkingLifeTime", "");
            dic.Add("AverageLifeTime", "");
            dic.Add("AverageWorkingLifeTimeToVesting", "");
            dic.Add("AverageWorkingLifeTimeForBenefitingEE", "");
            pMethods._PopVerify_Methods_Accounting(dic);

            pMain._SelectTab("Methods");

            mTime.StopTimer(iJuly2006Val_Methods_Edit);
            mLog.LogInfo(iJuly2006Val_Methods_Edit, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Methods");

            mTime.StopTimer(iJuly2006Val_Methods_Save);
            mLog.LogInfo(iJuly2006Val_Methods_Save, MyPerformanceCounter.Memory_Private);






            pMain._SelectTab("July 2006 Valuation");


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            mTime.StopTimer(iJuly2006Val_TestCase_Open);
            mLog.LogInfo(iJuly2006Val_TestCase_Open, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"8/25/1973\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._SelectTab("Test Case Library");

            mTime.StopTimer(iJuly2006Val_TestCase_Edit);
            mLog.LogInfo(iJuly2006Val_TestCase_Edit, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"7/24/1913\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/24/1952\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"6/24/1940\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"11/15/1966\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Test Case Library");

            mTime.StopTimer(iJuly2006Val_TestCase_Save);
            mLog.LogInfo(iJuly2006Val_TestCase_Save, MyPerformanceCounter.Memory_Private);



            ////pTestCaseLibrary._FPGrid_TestCaseLibrary_SelectTestCase(1);

            ////dic.Clear();
            ////dic.Add("RunSelectedTestLife", "Click");
            ////pTestCaseLibrary._PopVerify_TestCaseLibrary(dic);

            ////dic.Clear();
            ////dic.Add("PPA_NAR_Min", "True");
            ////dic.Add("PPA_NAR_Max", "True");
            ////dic.Add("PPA_NAR_PVVB", "True");
            ////dic.Add("PBGC_NAR_PVVB", "True");
            ////dic.Add("FAS35_PVAB", "True");
            ////dic.Add("FAS35_PVVB", "True");
            ////dic.Add("PayoutProjection", "False");
            ////dic.Add("RunSelected", "Click");
            ////pTestCaseLibrary._PopVerify_TestCaseRunOption(dic);





            ////dic.Clear();
            ////dic.Add("ViewTestCaseInExcel", "Click");
            ////dic.Add("Close", "");
            ////pTestCaseLibrary._PopVerify_TestCaseViewer(dic); 






            pMain._SelectTab("July 2006 Valuation");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("Object", "Main.RunOption");
            dic.Add("optiTimeout", "");
            pMain._ObjectExist(dic);

            mTime.StopTimer(iJuly2006Val_ER_LaunchOption);
            mLog.LogInfo(iJuly2006Val_ER_LaunchOption, MyPerformanceCounter.Memory_Private);


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
            dic.Add("Service", "CreditedService");
            dic.Add("Pay", "N/A");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Beneficiary1Percent1");
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
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);

            mTime.StopTimer(iJuly2006Val_ER_CodeOption);
            mLog.LogInfo(iJuly2006Val_ER_CodeOption, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();
            mLog.LogInfo(iJuly2006Val_ER_ClickRun, DateTime.Now.ToString());

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            mTime.StopTimer(iJuly2006Val_ER_RunSubmitted);
            mLog.LogInfo(iJuly2006Val_ER_RunSubmitted, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            mLog.LogInfo(iJuly2006Val_ER_GroupJobID, pMain._ER_ReturnRunStatus_TopGrid(2));
            mLog.LogInfo(iJuly2006Val_ER_GroupSuccess, pMain._ER_ReturnRunStatus_TopGrid(11));

            mLog.LogInfo(iJuly2006Val_ER_EarliestToBeProcess, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5));
            mLog.LogInfo(iJuly2006Val_ER_Persist, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            mLog.LogInfo(iJuly2006Val_ER_PostEngine, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));

            mLog.LogInfo(iJobID_July2006Val, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));

            pMain._SelectTab("July 2006 Valuation");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            dic.Add("CheckOMSetupPopup", "False");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");

            mTime.StopTimer(iJuly2006Val_OM_Open);
            mLog.LogInfo(iJuly2006Val_OM_Open, MyPerformanceCounter.Memory_Private);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2006Valuation, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputFunding_July2006Valuation, "Liability Summary", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2006Valuation, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputFunding_July2006Valuation, "Conversion Diagnostic", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2006Valuation, "Test Case List", "Conversion", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2006Valuation, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2006Valuation, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2006Valuation, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2006Valuation, "Parameter Print", "Conversion", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2006Valuation, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2006Valuation, "Payout Projection", "Conversion", true, true);

            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2006Valuation, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputFunding_July2006Valuation, "Liability Summary", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2006Valuation, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputFunding_July2006Valuation, "Conversion Diagnostic", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2006Valuation, "Test Case List", "Conversion", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2006Valuation, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2006Valuation, "Detailed Results by Plan Def", "Conversion", false, true);
            }

            if (bDownloadReports_EXCEL_TimingOnly)
            {
                mTime.StartTimer();
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2006Valuation, "Valuation Summary", "Conversion", false, true);
                mTime.StopTimer(iJuly2006Val_OM_ValSummary);
                mLog.LogInfo(iJuly2006Val_OM_ValSummary, MyPerformanceCounter.Memory_Private);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2006Valuation, "Individual Output", "Conversion", false, true);
                mTime.StartTimer();
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2006Valuation, "Payout Projection", "Conversion", false, true);
                mTime.StopTimer(iJuly2006Val_OM_PayoutProjection);
                mLog.LogInfo(iJuly2006Val_OM_PayoutProjection, MyPerformanceCounter.Memory_Private);
                //mTime.StartTimer();
                //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2006Valuation, "IOE", "Conversion", false, true);
                //mTime.StopTimer(iJuly2006Val_OM_IOE);
                //mLog.LogInfo(iJuly2006Val_OM_IOE, MyPerformanceCounter.Memory_Private);
            }

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US010CN", sOutputFunding_July2006Valuation_Prod, sOutputFunding_July2006Valuation);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_July2006Valuation");
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
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);

            }


            pMain._SelectTab("July 2006 Valuation");

            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("July 2006 Valuation");
            mTime.StopTimer(iJuly2006Val_OM_Save);
            mLog.LogInfo(iJuly2006Val_OM_Save, MyPerformanceCounter.Memory_Private);

            pMain._Home_ToolbarClick_Top(false);


            #endregion
            
            
            #region Data 2007


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "ParticipantData");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Data 2007");
            dic.Add("EffectiveDate", "07/01/2007");
            dic.Add("Parent", "Data 2006");
            dic.Add("RSC", "");
            dic.Add("Shared", "");
            dic.Add("GeneralUse", "");
            dic.Add("Conversion", "");
            dic.Add("CopyDataService", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_DataServicePropeties(dic);

            pMain._SelectTab("Home");
            mTime.StopTimer(iData2007_AddService);
            mLog.LogInfo(iData2007_AddService, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Data 2007");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            mTime.StopTimer(iData2007_OpenService);
            mLog.LogInfo(iData2007_OpenService, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data 2007");
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
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\US010\US0102007.XLs");
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            mTime.StopTimer(iData2007_Upload_SelectFile);
            mLog.LogInfo(iData2007_Upload_SelectFile, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);


            pMain._SelectTab("Data 2007");

            mTime.StopTimer(iData2007_Upload_Upload);
            mLog.LogInfo(iData2007_Upload_Upload, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", "Data 2007");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Get Data");
            pData._TreeViewSelect(dic);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "Excel file");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "US0102007.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            pData._SelectTab("Select File");

            mTime.StopTimer(iData2007_IM_Selectfile);
            mLog.LogInfo(iData2007_IM_Selectfile, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_SelectFile(dic);

            pData._SelectTab("Select File");

            mTime.StopTimer(iData2007_IM_SelectFile_Preview);
            mLog.LogInfo(iData2007_IM_SelectFile_Preview, MyPerformanceCounter.Memory_Private);


            pData._SelectTab("Mapping");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_Mapping(dic);

            pData._SelectTab("Mapping");

            mTime.StopTimer(iData2007_MP_Preview);
            mLog.LogInfo(iData2007_MP_Preview, MyPerformanceCounter.Memory_Private);



            pData._SelectTab("Validate & Load");


            mTime.StartTimer();

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


            mTime.StopTimer(iData2007_ValidateAndLoad);
            mLog.LogInfo(iData2007_ValidateAndLoad, MyPerformanceCounter.Memory_Private);


            pData._SelectTab("Pre Matching Derivations");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "Click");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            pData._SelectTab("Matching");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);

            pData._SelectTab("Matching");

            mTime.StopTimer(iData2007_Matching_FindMatch);
            mLog.LogInfo(iData2007_Matching_FindMatch, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "26");
            dic.Add("Unique_UniqueMatch_Num", "590");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "0");
            dic.Add("Duplicate_UniqueMatch_Num", "0");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
            dic.Add("Warehouse_NoMatch_Num", "0");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);


            mTime.StartTimer();

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


            mTime.StopTimer(iData2007_Matching_AcceptNew);
            mLog.LogInfo(iData2007_Matching_AcceptNew, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

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
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Are you sure that you want to accept all records with a status of Matched");
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
            dic.Add("Message", "All 'UniqueUniqueMatch' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);


            mTime.StopTimer(iData2007_Matching_AcceptMatched);
            mLog.LogInfo(iData2007_Matching_AcceptMatched, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

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


            mTime.StopTimer(iData2007_Matching_SaveToWarehouse);
            mLog.LogInfo(iData2007_Matching_SaveToWarehouse, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", "Data 2007");
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "Val Data");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Funding Results");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Accounting Results");
            pData._TreeViewSelect_Snapshots(dic, false);


            pMain._Home_ToolbarClick_Top(true);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "Click");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);


            pMain._SelectTab("Data 2007");

            mTime.StopTimer(iData2007_SP_Preview);
            mLog.LogInfo(iData2007_SP_Preview, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "Click");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_SP_Snapshots_Popup(dic);

            mTime.StopTimer(iData2007_SP_Publish);
            mLog.LogInfo(iData2007_SP_Publish, MyPerformanceCounter.Memory_Private);



            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion



            #region sOutputFunding_July2007Valuation


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "July 2007 Valuation");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "2007");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            pMain._SelectTab("Home");

            mTime.StopTimer(iJuly2007Val_AddService);
            mLog.LogInfo(iJuly2007Val_AddService, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "July 2007 Valuation");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            mTime.StopTimer(iJuly2007Val_OpenService);
            mLog.LogInfo(iJuly2007Val_OpenService, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("July 2007 Valuation");

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
            dic.Add("LiabilityValuationDate", "07/01/2007");
            dic.Add("Data_AddNew", "True");
            dic.Add("Data_Name", "Baseline Data");
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


            pMain._SelectTab("July 2007 Valuation");

            mTime.StopTimer(iJuly2007Val_Rollforward);
            mLog.LogInfo(iJuly2007Val_Rollforward, MyPerformanceCounter.Memory_Private);


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


            mTime.StopTimer(iJuly2007Val_Data_OpenDataSet);
            mLog.LogInfo(iJuly2007Val_Data_OpenDataSet, MyPerformanceCounter.Memory_Private);

            mTime.StartTimer();

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
            dic.Add("SnapshotName", "Val Data");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "True");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "Click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);

            pMain._SelectTab("Participant DataSet");
            mTime.StopTimer(iJuly2007Val_Data_SelectSnapshot);
            mLog.LogInfo(iJuly2007Val_Data_SelectSnapshot, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("CompareData", "False");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._SelectTab("Participant DataSet");

            mTime.StartTimer();

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

            mTime.StopTimer(iJuly2007Val_Data_Import);
            mLog.LogInfo(iJuly2007Val_Data_Import, MyPerformanceCounter.Memory_Private);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab("July 2007 Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"8/25/1973\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"7/24/1913\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/24/1952\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"6/24/1940\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"11/15/1966\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("July 2007 Valuation");


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

            mTime.StopTimer(iJuly2007Val_ER_LaunchOption);
            mLog.LogInfo(iJuly2007Val_ER_LaunchOption, MyPerformanceCounter.Memory_Private);


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
            dic.Add("Pay", "N/A");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "N/A");
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
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);


            mTime.StopTimer(iJuly2007Val_ER_CodeOption);
            mLog.LogInfo(iJuly2007Val_ER_CodeOption, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();
            mLog.LogInfo(iJuly2007Val_ER_ClickRun, DateTime.Now.ToString());

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            mTime.StopTimer(iJuly2007Val_ER_RunSubmitted);
            mLog.LogInfo(iJuly2007Val_ER_RunSubmitted, MyPerformanceCounter.Memory_Private);



            pMain._SelectTab("July 2007 Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            mLog.LogInfo(iJuly2007Val_ER_GroupJobID, pMain._ER_ReturnRunStatus_TopGrid(2));
            mLog.LogInfo(iJuly2007Val_ER_GroupSuccess, pMain._ER_ReturnRunStatus_TopGrid(11));

            mLog.LogInfo(iJuly2007Val_ER_EarliestToBeProcess, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5));
            mLog.LogInfo(iJuly2007Val_ER_Persist, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            mLog.LogInfo(iJuly2007Val_ER_PostEngine, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));

            mLog.LogInfo(iJobID_July2007Val, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));

            pMain._SelectTab("July 2007 Valuation");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            dic.Add("CheckOMSetupPopup", "False");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");

            mTime.StopTimer(iJuly2007Val_OM_Open);
            mLog.LogInfo(iJuly2007Val_OM_Open, MyPerformanceCounter.Memory_Private);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_July2007Valuation, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2007Valuation, "Individual Checking Template", "RollForward", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Age Service Matrix", "RollForward", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Data Matching Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Combined Status Code Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Gain / Loss Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_July2007Valuation, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_July2007Valuation, "Active Decrement Gain / Loss Detail", "RollForward", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Decrement Age", "RollForward", true, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2007Valuation, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2007Valuation, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2007Valuation, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2007Valuation, "Payout Projection", "RollForward", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_July2007Valuation, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2007Valuation, "Individual Checking Template", "RollForward", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Age Service Matrix", "RollForward", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Data Matching Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Combined Status Code Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Gain / Loss Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_July2007Valuation, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Decrement Age", "RollForward", false, true);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2007Valuation, "Individual Output", "RollForward", false, true);
            }

            if (bDownloadReports_EXCEL_TimingOnly)
            {
                mTime.StartTimer();
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_July2007Valuation, "Reconciliation to Prior Year", "RollForward", false, true);
                mTime.StopTimer(iJuly2007Val_OM_ReconciliationToPriorYear);
                mLog.LogInfo(iJuly2007Val_OM_ReconciliationToPriorYear, MyPerformanceCounter.Memory_Private);

                mTime.StartTimer();
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_July2007Valuation, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
                mTime.StopTimer(iJuly2007Val_OM_GLSummaryOfLiabilityReconciliation);
                mLog.LogInfo(iJuly2007Val_OM_GLSummaryOfLiabilityReconciliation, MyPerformanceCounter.Memory_Private);

                mTime.StartTimer();
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_July2007Valuation, "Gain / Loss Participant Listing", "RollForward", false, true);
                mTime.StopTimer(iJuly2007Val_OM_GLParticipantListing);
                mLog.LogInfo(iJuly2007Val_OM_GLParticipantListing, MyPerformanceCounter.Memory_Private);
                mTime.StartTimer();
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_July2007Valuation, "Valuation Summary", "RollForward", false, true);
                mTime.StopTimer(iJuly2007Val_OM_ValSummary);
                mLog.LogInfo(iJuly2007Val_OM_ValSummary, MyPerformanceCounter.Memory_Private);

                mTime.StartTimer();
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2007Valuation, "Payout Projection", "RollForward", false, true);
                mTime.StopTimer(iJuly2007Val_OM_PayoutProjection);
                mLog.LogInfo(iJuly2007Val_OM_PayoutProjection, MyPerformanceCounter.Memory_Private);
                //mTime.StartTimer();
                //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_July2007Valuation, "IOE", "RollForward", false, true);
                //mTime.StopTimer(iJuly2007Val_OM_IOE);
                //mLog.LogInfo(iJuly2007Val_OM_IOE, MyPerformanceCounter.Memory_Private);

            }


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US010CN", sOutputFunding_July2007Valuation_Prod, sOutputFunding_July2007Valuation);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_July2007Valuation");
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossStatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
            }


            pMain._SelectTab("July 2007 Valuation");

            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("July 2007 Valuation");

            mTime.StopTimer(iJuly2007Val_OM_Save);
            mLog.LogInfo(iJuly2007Val_OM_Save, MyPerformanceCounter.Memory_Private);


            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region sOutputAccounting_July2006FASVal


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "July 2006 FAS Val");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "2006");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            pMain._SelectTab("Home");

            mTime.StopTimer(iJuly2006FAS_AddService);
            mLog.LogInfo(iJuly2006FAS_AddService, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "July 2006 FAS Val");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            mTime.StopTimer(iJuly2006FAS_OpenService);
            mLog.LogInfo(iJuly2006FAS_OpenService, MyPerformanceCounter.Memory_Private);

            pMain._SelectTab("July 2006 FAS Val");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Data");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Participant DataSet");


            mTime.StopTimer(iJuly2006FAS_Data_OpenDataSet);
            mLog.LogInfo(iJuly2006FAS_Data_OpenDataSet, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

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
            dic.Add("SnapshotName", "Val Data");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);

            pMain._SelectTab("Participant DataSet");

            mTime.StopTimer(iJuly2006FAS_Data_SelectSnapshot);
            mLog.LogInfo(iJuly2006FAS_Data_SelectSnapshot, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "Click");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("Decrement", "Retirement");
            dic.Add("FundingAL", "8598183");
            dic.Add("FundingNC", "428354");
            dic.Add("AccountingAL", "8909671");
            dic.Add("AccountingNC", "446021");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_TotalsByDecrement(dic);

            dic.Clear();
            dic.Add("Decrement", "Withdrawal");
            dic.Add("FundingAL", "508171");
            dic.Add("FundingNC", "51280");
            dic.Add("AccountingAL", "532098");
            dic.Add("AccountingNC", "53778");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_TotalsByDecrement(dic);

            dic.Clear();
            dic.Add("Decrement", "Death");
            dic.Add("FundingAL", "231536");
            dic.Add("FundingNC", "13071");
            dic.Add("AccountingAL", "185780");
            dic.Add("AccountingNC", "10335");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_TotalsByDecrement(dic);


            dic.Clear();
            dic.Add("Liability", "PPA NAR PVVB Active");
            dic.Add("AL", "123456789");
            dic.Add("NC", "987654321");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_AdditionalLiabilityTotals(dic);


            dic.Clear();
            dic.Add("Liability", "PPA NAR PVVB Inactive");
            dic.Add("AL", "12345678");
            dic.Add("NC", "");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_AdditionalLiabilityTotals(dic);

            dic.Clear();
            dic.Add("Liability", "PPA NAR Max");
            dic.Add("AL", "1234567");
            dic.Add("NC", "7654321");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_AdditionalLiabilityTotals(dic);

            dic.Clear();
            dic.Add("Liability", "PBGC NAR PVVB");
            dic.Add("AL", "123456");
            dic.Add("NC", "654321");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_AdditionalLiabilityTotals(dic);

            dic.Clear();
            dic.Add("Liability", "FAS35 PVAB");
            dic.Add("AL", "12345");
            dic.Add("NC", "54321");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_AdditionalLiabilityTotals(dic);

            dic.Clear();
            dic.Add("Liability", "FAS35 PVVB");
            dic.Add("AL", "1234");
            dic.Add("NC", "4321");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_AdditionalLiabilityTotals(dic);

            dic.Clear();
            dic.Add("Row", "Number");
            dic.Add("Active", "284");
            dic.Add("Deferred", "65");
            dic.Add("Retired", "241");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

            dic.Clear();
            dic.Add("Row", "Average Age");
            dic.Add("Active", "42.47");
            dic.Add("Deferred", "48.14");
            dic.Add("Retired", "73.64");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

            dic.Clear();
            dic.Add("Row", "Average Service from Hire");
            dic.Add("Active", "12.80");
            dic.Add("Deferred", "");
            dic.Add("Retired", "");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

            dic.Clear();
            dic.Add("Row", "Average Pay");
            dic.Add("Active", "0");
            dic.Add("Deferred", "");
            dic.Add("Retired", "");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

            dic.Clear();
            dic.Add("Row", "Annual Pension");
            dic.Add("Active", "");
            dic.Add("Deferred", "1950");
            dic.Add("Retired", "11000");
            dic.Add("OK", "Click");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

            mTime.StartTimer();

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

            mTime.StopTimer(iJuly2006FAS_Data_Import);
            mLog.LogInfo(iJuly2006FAS_Data_Import, MyPerformanceCounter.Memory_Private);



            pMain._Home_ToolbarClick_Top(true);



            pMain._SelectTab("July 2006 FAS Val");

            mTime.StartTimer();

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
            dic.Add("ServiceInstance", "July 2006 Valuation");
            dic.Add("iTableItemIndex", "1");
            dic.Add("CopyAllParameters", "");
            dic.Add("CopyParameterChanges", "");
            dic.Add("OK", "click");
            pMain._PopVerify_CopyProvisionSet(dic);

            pMain._SelectTab("Home");

            mTime.StopTimer(iJuly2006FAS_Prov_Copy);
            mLog.LogInfo(iJuly2006FAS_Prov_Copy, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "July 2006 FAS Val");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("July 2006 FAS Val");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

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
            dic.Add("txtRate", "5.75");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "90.0");
            dic.Add("txtPercentMarried_F", "90.0");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "-2");
            dic.Add("txtDifferenceInSpouseAge_F", "2");
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
            dic.Add("Mortality", "GATT03");
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
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "RETRATES");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "True");
            dic.Add("cboPreDefinedEligibility", "RetireElig");
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
            dic.Add("RetWithdrawDis", "WTHDRAL");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZEROWTH");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "True");
            dic.Add("cboPreDefinedEligibility", "RetireElig");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("July 2006 FAS Val");

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
            dic.Add("CostMethod", "Projected Unit Credit No Prorate");
            dic.Add("ServiceForServiceProrate", "");
            dic.Add("CompareToAccrue", "");
            dic.Add("AllowNegativeNormalCost", "");
            dic.Add("ProjectedpayToUse", "");
            dic.Add("AccumulationToUse", "");
            dic.Add("IncludeExitYearValue", "");
            dic.Add("CalculatePresentValueOfFuture", "");
            dic.Add("CalculatePresentValueOfFuture_txt", "");
            dic.Add("VestingToUseForAgeFirstVested", "Vesting1");
            dic.Add("AverageWorkingLifeTime", "");
            dic.Add("AverageLifeTime", "");
            dic.Add("AverageWorkingLifeTimeToVesting", "");
            dic.Add("AverageWorkingLifeTimeForBenefitingEE", "");
            pMethods._PopVerify_Methods_Accounting(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("July 2006 FAS Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"8/25/1973\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"7/24/1913\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/24/1952\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"6/24/1940\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"11/15/1966\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("July 2006 FAS Val");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("Object", "Main.RunOption");
            dic.Add("optiTimeout", "");
            pMain._ObjectExist(dic);

            mTime.StopTimer(iJuly2006FAS_ER_LaunchOption);
            mLog.LogInfo(iJuly2006FAS_ER_LaunchOption, MyPerformanceCounter.Memory_Private);


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
            dic.Add("Pay", "N/A");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "N/A");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);

            mTime.StopTimer(iJuly2006FAS_ER_CodeOption);
            mLog.LogInfo(iJuly2006FAS_ER_CodeOption, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();
            mLog.LogInfo(iJuly2006FAS_ER_ClickRun, DateTime.Now.ToString());

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            mTime.StopTimer(iJuly2006FAS_ER_RunSubmitted);
            mLog.LogInfo(iJuly2006FAS_ER_RunSubmitted, MyPerformanceCounter.Memory_Private);



            pMain._SelectTab("July 2006 FAS Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            mLog.LogInfo(iJuly2006FAS_ER_GroupJobID, pMain._ER_ReturnRunStatus_TopGrid(2));
            mLog.LogInfo(iJuly2006FAS_ER_GroupSuccess, pMain._ER_ReturnRunStatus_TopGrid(11));

            mLog.LogInfo(iJuly2006FAS_ER_EarliestToBeProcess, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5));
            mLog.LogInfo(iJuly2006FAS_ER_Persist, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            mLog.LogInfo(iJuly2006FAS_ER_PostEngine, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));

            mLog.LogInfo(iJobID_July2006FASVal, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));

            pMain._SelectTab("July 2006 FAS Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Liability Summary", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Liability Summary", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Member Statistics", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Conversion Diagnostic", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Conversion Diagnostic", "Conversion", true, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Test Case List", "Conversion", true, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Detailed Results", "Conversion", true, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Valuation Summary", "Conversion", true, false);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Individual Output", "Conversion", true, false);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Parameter Print", "Conversion", true, false);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Test Cases", "Conversion", true, false);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Payout Projection", "Conversion", true, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2006FASVal, "FAS Expected Benefit Pmts", "Conversion", true, false);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Liability Summary", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Liability Summary", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Member Statistics", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Conversion Diagnostic", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Conversion Diagnostic", "Conversion", false, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Test Case List", "Conversion", false, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Detailed Results", "Conversion", false, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Detailed Results by Plan Def", "Conversion", false, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Valuation Summary", "Conversion", false, false);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Individual Output", "Conversion", false, false);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2006FASVal, "IOE", "Conversion", false, false);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2006FASVal, "Payout Projection", "Conversion", false, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2006FASVal, "FAS Expected Benefit Pmts", "Conversion", false, false);
            }


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US010CN", sOutputAccounting_July2006FASVal_Prod, sOutputAccounting_July2006FASVal);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting_July2006FASVal");

                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_ActiveMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_DeferredMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_Pensioners.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByNone.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByStatusCodes.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByCustom_Gender.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("TestCaseList.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
            }


            pMain._SelectTab("July 2006 FAS Val");

            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("July 2006 FAS Val");

            mTime.StopTimer(iJuly2006FAS_Save);
            mLog.LogInfo(iJuly2006FAS_Save, MyPerformanceCounter.Memory_Private);

            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region sOutputAccounting_July2007FASVal


            pMain._SelectTab("Home");


            //////dic.Clear();
            //////dic.Add("Level_1", Config.sClientName);
            //////dic.Add("Level_2", Config.sPlanName);
            //////dic.Add("Level_3", "AccountingValuations");
            //////pMain._HomeTreeViewSelect_Favorites(0, dic);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "July 2007 FAS Val");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "2007");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            pMain._SelectTab("Home");

            mTime.StopTimer(iJuly2007FAS_AddService);
            mLog.LogInfo(iJuly2007FAS_AddService, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "July 2007 FAS Val");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            mTime.StopTimer(iJuly2007FAS_OpenService);
            mLog.LogInfo(iJuly2007FAS_OpenService, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("July 2007 FAS Val");

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
            dic.Add("LiabilityValuationDate", "07/01/2007");
            dic.Add("Data_AddNew", "True");
            dic.Add("Data_Name", "Baseline Data");
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

            pMain._SelectTab("July 2007 FAS Val");

            mTime.StopTimer(iJuly2007FAS_Rollforward);
            mLog.LogInfo(iJuly2007FAS_Rollforward, MyPerformanceCounter.Memory_Private);


            pMain._SelectTab("July 2007 FAS Val");

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

            mTime.StopTimer(iJuly2007FAS_Data_OpenDataSet);
            mLog.LogInfo(iJuly2007FAS_Data_OpenDataSet, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();


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
            dic.Add("SnapshotName", "Val Data");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "True");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "Click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);

            pMain._SelectTab("Participant DataSet");
            mTime.StopTimer(iJuly2007FAS_Data_SelectSnapshot);
            mLog.LogInfo(iJuly2007FAS_Data_SelectSnapshot, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("CompareData", "False");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._SelectTab("Participant DataSet");

            mTime.StartTimer();

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

            mTime.StopTimer(iJuly2007FAS_Data_Import);
            mLog.LogInfo(iJuly2007FAS_Data_Import, MyPerformanceCounter.Memory_Private);




            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("July 2007 FAS Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"8/25/1973\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"7/24/1913\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/24/1952\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"6/24/1940\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"11/15/1966\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("July 2007 FAS Val");

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

            mTime.StopTimer(iJuly2007FAS_ER_LaunchOption);
            mLog.LogInfo(iJuly2007FAS_ER_LaunchOption, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Acc_GL_PBO", "");
            dic.Add("Acc_GL_ABO", "");
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
            dic.Add("Pay", "N/A");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "N/A");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);

            mTime.StopTimer(iJuly2007FAS_ER_CodeOption);
            mLog.LogInfo(iJuly2007FAS_ER_CodeOption, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();
            mLog.LogInfo(iJuly2007FAS_ER_ClickRun, DateTime.Now.ToString());

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            mTime.StopTimer(iJuly2007FAS_ER_RunSubmitted);
            mLog.LogInfo(iJuly2007FAS_ER_RunSubmitted, MyPerformanceCounter.Memory_Private);



            pMain._SelectTab("July 2007 FAS Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            mLog.LogInfo(iJuly2007FAS_ER_GroupJobID, pMain._ER_ReturnRunStatus_TopGrid(2));
            mLog.LogInfo(iJuly2007FAS_ER_GroupSuccess, pMain._ER_ReturnRunStatus_TopGrid(11));

            mLog.LogInfo(iJuly2007FAS_ER_EarliestToBeProcess, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 2, 5));
            mLog.LogInfo(iJuly2007FAS_ER_Persist, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 3, 5));
            mLog.LogInfo(iJuly2007FAS_ER_PostEngine, pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5));


            mLog.LogInfo(iJobID_July2007FASVal, pMain._ER_ReturnRunStatus_BottomGrid("Job Status Info", 1, 3));

            pMain._SelectTab("July 2007 FAS Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Reconciliation to Prior Year", "RollForward", true, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Detailed Results", "RollForward", true, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Status Reconciliation", "RollForward", true, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Member Statistics", "RollForward", true, false);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Individual Checking Template", "RollForward", true, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Age Service Matrix", "RollForward", true, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Data Matching Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Combined Status Code Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Valuation Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Individual Output", "RollForward", true, false);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Parameter Print", "RollForward", true, false);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Test Cases", "RollForward", true, false);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Payout Projection", "RollForward", true, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "FAS Expected Benefit Pmts", "RollForward", true, false);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Liability Set for Globe Export", "RollForward", true, false);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Reconciliation to Prior Year", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Reconciliation to Prior Year by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Detailed Results", "RollForward", false, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Detailed Results by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Status Reconciliation", "RollForward", false, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Member Statistics", "RollForward", false, false);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Individual Checking Template", "RollForward", false, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Age Service Matrix", "RollForward", false, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Data Matching Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Combined Status Code Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Valuation Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Individual Output", "RollForward", false, false);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Payout Projection", "RollForward", false, false);
                pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2007FASVal, "FAS Expected Benefit Pmts", "RollForward", false, false);
                pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2007FASVal, "Liability Set for Globe Export", "RollForward", false, false);
            }


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US010CN", sOutputAccounting_July2007FASVal_Prod, sOutputAccounting_July2007FASVal);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting_July2007FASVal");
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport.xlsx", 4, 0, 0, 0);
            }



            pMain._SelectTab("July 2007 FAS Val");

            mTime.StartTimer();

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("July 2007 FAS Val");

            mTime.StopTimer(iJuly2007FAS_Save);
            mLog.LogInfo(iJuly2007FAS_Save, MyPerformanceCounter.Memory_Private);

            pMain._Home_ToolbarClick_Top(false);

            #endregion


            mLog.LogInfo(iTimeEnd, DateTime.Now.ToString());


            _gLib._MsgBox("Congratulations!", "Finished!");


            Environment.Exit(0);



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
