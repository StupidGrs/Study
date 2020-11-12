////// ----------------------- ------------------------------------------------------------------------///////////
//////                                 US Data Performance Test 20K                                    ///////////
//////                                                                                                 ///////////
//////                          Webber.ling@mercer.com      2015-Aug-28                                ///////////
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


namespace RetirementStudio._TestScripts_2019_Oct_Timing
{
    /// <summary>
    /// Summary description for US_Data_20K
    /// </summary>
    [CodedUITest]
    public class US_Data_20K
    {
        public US_Data_20K()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            Config.sClientName = "US_Data_Timing_20K_20150818_F"; 
            Config.sPlanName = "US Plan";
            ////Config.sDataCenter = "Exeter";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = false;
            Config.bCompareReports = false;


        }

        #region Timing


        static string sCol_Time = "Time";
        static string sCol_Memory = "Memory";
        static string sLogFile = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\Data_PerformanceTest\Results_UpdatedVersion_CUIT.xls";
        static string sOutputDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\Data_PerformanceTest\TestOuput\";

        static string sDataFile_Conversion = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\Data_PerformanceTest\DataPerformanceData_Conversion.xls";
        static string sDataFile_Rollforward = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\Data_PerformanceTest\DataPerformanceData_RF.xls";
        static string sDataFile_Conversion_FileName = "DataPerformanceData_Conversion.xls";
        static string sDataFile_Rollforward_FileName = "DataPerformanceData_RF.xls";

        static string sCurrentViewFile_Conversion = @"\\mercer.com\US_Data\Shared\DFL\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\Data_PerformanceTest\SMALL_YUMFieldNames.xls";
        static string sCurrentViewFile_RF = @"\\mercer.com\US_Data\Shared\DFL\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\Data_PerformanceTest\YUMFieldNames_RF.xls";

        static string sQuery_ReadFile = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\Data_PerformanceTest\SimpleImportForQueries v2.xls";
        static string sQueryWriteFile = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\Data_PerformanceTest\TestOuput\Data2012_Query.xls";

        static int iConversion_UniqueMatchNum = 20000;
        static int iRF_UniqueMatchNum = 19212;
        static int iRF_NoMatchNum = 1035;
        static int iRF_WarehouseNoMatchNum = 788;




        MyTimer mTime = new MyTimer(sCol_Time, sLogFile);
        MyTimer mTimeTotal = new MyTimer(sCol_Time, sLogFile);
        MyLog mLog = new MyLog(sCol_Memory, sLogFile);

        MyDictionary dicPosition = new MyDictionary();



        #region Result Index

        static int iNumOfEE = 239;
        static int iTimeStart = iNumOfEE + 1;
        static int iTimeEnd = iTimeStart + 1;

        static int iConversion_CV_MultipleLabel_Open = 2;
        static int iConversion_CV_MultipleLabel_CopyPaste = iConversion_CV_MultipleLabel_Open + 1;
        static int iConversion_CV_MultipleLabel_Add = iConversion_CV_MultipleLabel_CopyPaste + 1;
        static int iConversion_CV_MultipleLabel_Total = iConversion_CV_MultipleLabel_Add + 1;

        static int iConversion_UL_Open = iConversion_CV_MultipleLabel_Total + 1;
        static int iConversion_UL_Upload = iConversion_UL_Open + 1;
        static int iConversion_UL_Total = iConversion_UL_Upload + 1;

        static int iConversion_IM_Add = iConversion_UL_Total + 1;
        static int iConversion_IM_SF_Open = iConversion_IM_Add + 1;
        static int iConversion_IM_SF_Select = iConversion_IM_SF_Open + 1;
        static int iConversion_IM_SF_Preview = iConversion_IM_SF_Select + 1;
        static int iConversion_IM_SF_Total = iConversion_IM_SF_Preview + 1;

        static int iConversion_IM_CL_Preview = iConversion_IM_SF_Total + 1;

        static int iConversion_IM_MP_Map = iConversion_IM_CL_Preview + 1;
        static int iConversion_IM_MP_USC = iConversion_IM_MP_Map + 1;
        static int iConversion_IM_MP_Preview = iConversion_IM_MP_USC + 1;
        static int iConversion_IM_MP_Total = iConversion_IM_MP_Preview + 1;

        static int iConversion_IM_ValidateAndLoad = iConversion_IM_MP_Total + 1;

        static int iConversion_IM_PMD_ImportName_Add = iConversion_IM_ValidateAndLoad + 1;
        static int iConversion_IM_PMD_ImportName_Edit = iConversion_IM_PMD_ImportName_Add + 1;
        static int iConversion_IM_PMD_DivisionCode_Add = iConversion_IM_PMD_ImportName_Edit + 1;
        static int iConversion_IM_PMD_DivisionCode_Edit = iConversion_IM_PMD_DivisionCode_Add + 1;
        static int iConversion_IM_PMD_CalcPreview = iConversion_IM_PMD_DivisionCode_Edit + 1;
        static int iConversion_IM_PMD_SaveWH = iConversion_IM_PMD_CalcPreview + 1;
        static int iConversion_IM_PMD_Total = iConversion_IM_PMD_SaveWH + 1;


        static int iConversion_IM_MC_ManualMatch_Open = iConversion_IM_PMD_Total + 1;
        static int iConversion_IM_MC_ManualMatch_Close = iConversion_IM_MC_ManualMatch_Open + 1;
        static int iConversion_IM_MC_FindMatch = iConversion_IM_MC_ManualMatch_Close + 1;
        static int iConversion_IM_MC_AcceptNew = iConversion_IM_MC_FindMatch + 1;
        static int iConversion_IM_MC_SaveWH = iConversion_IM_MC_AcceptNew + 1;
        static int iConversion_IM_MC_Total = iConversion_IM_MC_SaveWH + 1;


        static int iConversion_DG_DerivedGrp_USCDefDis1_Add = iConversion_IM_MC_Total + 1;
        static int iConversion_DG_DerivedGrp_USCDefDis1_Edit = iConversion_DG_DerivedGrp_USCDefDis1_Add + 1;
        static int iConversion_DG_DerivedGrp_USCDetDis1_Add = iConversion_DG_DerivedGrp_USCDefDis1_Edit + 1;
        static int iConversion_DG_DerivedGrp_USCDetDis1_Edit = iConversion_DG_DerivedGrp_USCDetDis1_Add + 1;
        static int iConversion_DG_DerivedGrp_Benefit1DB_Add = iConversion_DG_DerivedGrp_USCDetDis1_Edit + 1;
        static int iConversion_DG_DerivedGrp_Benefit1DB_Edit = iConversion_DG_DerivedGrp_Benefit1DB_Add + 1;
        static int iConversion_DG_DerivedGrp_CalcPreview = iConversion_DG_DerivedGrp_Benefit1DB_Edit + 1;
        static int iConversion_DG_DerivedGrp_SaveWH = iConversion_DG_DerivedGrp_CalcPreview + 1;
        static int iConversion_DG_DerivedGrp_Total = iConversion_DG_DerivedGrp_SaveWH + 1;

        static int iConversion_DG_CalcDates_EVESTLY_Add = iConversion_DG_DerivedGrp_Total + 1;
        static int iConversion_DG_CalcDates_EVESTLY_Edit = iConversion_DG_CalcDates_EVESTLY_Add + 1;
        static int iConversion_DG_CalcDates_ERETIRELY_Add = iConversion_DG_CalcDates_EVESTLY_Edit + 1;
        static int iConversion_DG_CalcDates_ERETIRELY_Edit = iConversion_DG_CalcDates_ERETIRELY_Add + 1;
        static int iConversion_DG_CalcDates_ECREDLY_Add = iConversion_DG_CalcDates_ERETIRELY_Edit + 1;
        static int iConversion_DG_CalcDates_ECREDLY_Edit = iConversion_DG_CalcDates_ECREDLY_Add + 1;
        static int iConversion_DG_CalcDates_NRDLY_Add = iConversion_DG_CalcDates_ECREDLY_Edit + 1;
        static int iConversion_DG_CalcDates_NRDLY_Edit = iConversion_DG_CalcDates_NRDLY_Add + 1;
        static int iConversion_DG_CalcDates_CalcPreview = iConversion_DG_CalcDates_NRDLY_Edit + 1;
        static int iConversion_DG_CalcDates_SaveWH = iConversion_DG_CalcDates_CalcPreview + 1;
        static int iConversion_DG_CalcDates_Total = iConversion_DG_CalcDates_SaveWH + 1;

        static int iConversion_DG_AgeCalc_AGELY_Add = iConversion_DG_CalcDates_Total + 1;
        static int iConversion_DG_AgeCalc_AGELY_Edit = iConversion_DG_AgeCalc_AGELY_Add + 1;
        static int iConversion_DG_AgeCalc_AGEGROUP_Add = iConversion_DG_AgeCalc_AGELY_Edit + 1;
        static int iConversion_DG_AgeCalc_AGEGROUP_Edit = iConversion_DG_AgeCalc_AGEGROUP_Add + 1;
        static int iConversion_DG_AgeCalc_BAGELY_Add = iConversion_DG_AgeCalc_AGEGROUP_Edit + 1;
        static int iConversion_DG_AgeCalc_BAGELY_Edit = iConversion_DG_AgeCalc_BAGELY_Add + 1;
        static int iConversion_DG_AgeCalc_CalcPreview = iConversion_DG_AgeCalc_BAGELY_Edit + 1;
        static int iConversion_DG_AgeCalc_SaveWH = iConversion_DG_AgeCalc_CalcPreview + 1;
        static int iConversion_DG_AgeCalc_Total = iConversion_DG_AgeCalc_SaveWH + 1;

        static int iConversion_DG_CreditBalance_TotalBalance_Add = iConversion_DG_AgeCalc_Total + 1;
        static int iConversion_DG_CreditBalance_TotalBalance_Edit = iConversion_DG_CreditBalance_TotalBalance_Add + 1;
        static int iConversion_DG_CreditBalance_ADCFROZ_Add = iConversion_DG_CreditBalance_TotalBalance_Edit + 1;
        static int iConversion_DG_CreditBalance_ADCFROZ_Edit = iConversion_DG_CreditBalance_ADCFROZ_Add + 1;
        static int iConversion_DG_CreditBalance_LIMPEPLY_Add = iConversion_DG_CreditBalance_ADCFROZ_Edit + 1;
        static int iConversion_DG_CreditBalance_LIMPEPLY_Edit = iConversion_DG_CreditBalance_LIMPEPLY_Add + 1;
        static int iConversion_DG_CreditBalance_CalcPreview = iConversion_DG_CreditBalance_LIMPEPLY_Edit + 1;
        static int iConversion_DG_CreditBalance_SaveWH = iConversion_DG_CreditBalance_CalcPreview + 1;
        static int iConversion_DG_CreditBalance_Total = iConversion_DG_CreditBalance_SaveWH + 1;

        static int iConversion_DG_PayAverage_PayAverage5_Add = iConversion_DG_CreditBalance_Total + 1;
        static int iConversion_DG_PayAverage_PayAverage5_Edit = iConversion_DG_PayAverage_PayAverage5_Add + 1;
        static int iConversion_DG_PayAverage_NDTPayAverage3_Add = iConversion_DG_PayAverage_PayAverage5_Edit + 1;
        static int iConversion_DG_PayAverage_NDTPayAverage3_Edit = iConversion_DG_PayAverage_NDTPayAverage3_Add + 1;
        static int iConversion_DG_PayAverage_W2PayAverage2Years_Add = iConversion_DG_PayAverage_NDTPayAverage3_Edit + 1;
        static int iConversion_DG_PayAverage_W2PayAverage2Years_Edit = iConversion_DG_PayAverage_W2PayAverage2Years_Add + 1;
        static int iConversion_DG_PayAverage_CalcPreview = iConversion_DG_PayAverage_W2PayAverage2Years_Edit + 1;
        static int iConversion_DG_PayAverage_SaveWH = iConversion_DG_PayAverage_CalcPreview + 1;
        static int iConversion_DG_PayAverage_Total = iConversion_DG_PayAverage_SaveWH + 1;

        static int iConversion_CK_ApplyChecks = iConversion_DG_PayAverage_Total + 1;
        static int iConversion_VU_Add = iConversion_CK_ApplyChecks + 1;
        static int iConversion_VU_Apply = iConversion_VU_Add + 1;
        static int iConversion_VU_Total = iConversion_VU_Apply + 1;

        static int iConversion_SS_Add = iConversion_VU_Total + 1;
        static int iConversion_SS_PickUpFields = iConversion_SS_Add + 1;
        static int iConversion_SS_Preview = iConversion_SS_PickUpFields + 1;
        static int iConversion_SS_Publish = iConversion_SS_Preview + 1;
        static int iConversion_SS_Total = iConversion_SS_Publish + 1;

        static int iConversion_RP_Add = iConversion_SS_Total + 1;
        static int iConversion_RP_Generate = iConversion_RP_Add + 1;
        static int iConversion_RP_Total = iConversion_RP_Generate + 1;
        static int iConversion_Consume_Open = iConversion_RP_Total + 1;
        static int iConversion_Consume_Select = iConversion_Consume_Open + 1;
        static int iConversion_Consume_Import = iConversion_Consume_Select + 1;
        static int iConversion_Consume_Total = iConversion_Consume_Import + 1;



        static int iRF_Service_Add = iConversion_Consume_Total + 1;
        static int iRF_Service_Open = iRF_Service_Add + 1;
        static int iRF_CV_MultipleLabel_Open = iRF_Service_Open + 1;
        static int iRF_CV_MultipleLabel_CopyPaste = iRF_CV_MultipleLabel_Open + 1;
        static int iRF_CV_MultipleLabel_Add = iRF_CV_MultipleLabel_CopyPaste + 1;
        static int iRF_CV_MultipleLabel_Total = iRF_CV_MultipleLabel_Add + 1;
        static int iRF_UL_Open = iRF_CV_MultipleLabel_Total + 1;
        static int iRF_UL_Upload = iRF_UL_Open + 1;
        static int iRF_UL_Total = iRF_UL_Upload + 1;


        static int iRF_IM_SF_Open = iRF_UL_Total + 1;
        static int iRF_IM_SF_Select = iRF_IM_SF_Open + 1;
        static int iRF_IM_SF_Preview = iRF_IM_SF_Select + 1;
        static int iRF_IM_SF_Total = iRF_IM_SF_Preview + 1;
        static int iRF_IM_CL_Preview = iRF_IM_SF_Total + 1;
        static int iRF_IM_MP_Preview = iRF_IM_CL_Preview + 1;
        static int iRF_IM_ValidateAndLoad = iRF_IM_MP_Preview + 1;
        static int iRF_IM_PMD_CalcPreview = iRF_IM_ValidateAndLoad + 1;
        static int iRF_IM_PMD_SaveWH = iRF_IM_PMD_CalcPreview + 1;
        static int iRF_IM_PMD_Total = iRF_IM_PMD_SaveWH + 1;
        static int iRF_IM_MC_FindMatch = iRF_IM_PMD_Total + 1;
        static int iRF_IM_MC_ManualMatch_Open = iRF_IM_MC_FindMatch + 1;
        static int iRF_IM_MC_ManualMatch_Close = iRF_IM_MC_ManualMatch_Open + 1;
        static int iRF_IM_MC_AcceptNew = iRF_IM_MC_ManualMatch_Close + 1;
        static int iRF_IM_MC_AcceptMatch = iRF_IM_MC_AcceptNew + 1;
        static int iRF_IM_MC_AcceptNoMatch = iRF_IM_MC_AcceptMatch + 1;
        static int iRF_IM_MC_SaveWH = iRF_IM_MC_AcceptNoMatch + 1;
        static int iRF_IM_MC_Total = iRF_IM_MC_SaveWH + 1;


        static int iRF_FL_FrozenBenefitGroup_Open = iRF_IM_MC_Total + 1;
        static int iRF_FL_FrozenBenefitGroup_Edit = iRF_FL_FrozenBenefitGroup_Open + 1;
        static int iRF_FL_HighEarner_Open = iRF_FL_FrozenBenefitGroup_Edit + 1;
        static int iRF_FL_HighEarner_Edit = iRF_FL_HighEarner_Open + 1;
        static int iRF_FL_Males_Open = iRF_FL_HighEarner_Edit + 1;
        static int iRF_FL_Males_Edit = iRF_FL_Males_Open + 1;
        static int iRF_FL_OverAge55_Open = iRF_FL_Males_Edit + 1;
        static int iRF_FL_OverAge55_Edit = iRF_FL_OverAge55_Open + 1;
        static int iRF_FL_SalariedGroup_Open = iRF_FL_OverAge55_Edit + 1;
        static int iRF_FL_SalariedGroup_Edit = iRF_FL_SalariedGroup_Open + 1;
        static int iRF_FL_ServiceOver35_Open = iRF_FL_SalariedGroup_Edit + 1;
        static int iRF_FL_ServiceOver35_Edit = iRF_FL_ServiceOver35_Open + 1;
        static int iRF_FL_Total = iRF_FL_ServiceOver35_Edit + 1;

        static int iRF_DG_DerivedGrp_CalcPreview = iRF_FL_Total + 1;
        static int iRF_DG_DerivedGrp_SaveWH = iRF_DG_DerivedGrp_CalcPreview + 1;
        static int iRF_DG_DerivedGrp_Total = iRF_DG_DerivedGrp_SaveWH + 1;
        static int iRF_DG_CalcDates_CalcPreview = iRF_DG_DerivedGrp_Total + 1;
        static int iRF_DG_CalcDates_SaveWH = iRF_DG_CalcDates_CalcPreview + 1;
        static int iRF_DG_CalcDates_Total = iRF_DG_CalcDates_SaveWH + 1;

        static int iRF_DG_AgeCalc_AGELY_UpdateType = iRF_DG_CalcDates_Total + 1;
        static int iRF_DG_AgeCalc_AGELY_Edit = iRF_DG_AgeCalc_AGELY_UpdateType + 1;
        static int iRF_DG_AgeCalc_AGEGROUP_UpdateType = iRF_DG_AgeCalc_AGELY_Edit + 1;
        static int iRF_DG_AgeCalc_AGEGROUP_Edit = iRF_DG_AgeCalc_AGEGROUP_UpdateType + 1;
        static int iRF_DG_AgeCalc_BAGELY_UpdateType = iRF_DG_AgeCalc_AGEGROUP_Edit + 1;
        static int iRF_DG_AgeCalc_BAGELY_Edit = iRF_DG_AgeCalc_BAGELY_UpdateType + 1;
        static int iRF_DG_AgeCalc_AgeAtTermation_Add = iRF_DG_AgeCalc_BAGELY_Edit + 1;
        static int iRF_DG_AgeCalc_AgeAtTermation_Edit = iRF_DG_AgeCalc_AgeAtTermation_Add + 1;
        static int iRF_DG_AgeCalc_CalcPreview = iRF_DG_AgeCalc_AgeAtTermation_Edit + 1;
        static int iRF_DG_AgeCalc_SaveWH = iRF_DG_AgeCalc_CalcPreview + 1;
        static int iRF_DG_AgeCalc_Total = iRF_DG_AgeCalc_SaveWH + 1;


        static int iRF_DG_CreditBalance_TotalBalance_Edit = iRF_DG_AgeCalc_Total + 1;
        static int iRF_DG_CreditBalance_ADCFROZ_Add = iRF_DG_CreditBalance_TotalBalance_Edit + 1;
        static int iRF_DG_CreditBalance_ADCFROZ_Edit = iRF_DG_CreditBalance_ADCFROZ_Add + 1;
        static int iRF_DG_CreditBalance_CalcPreview = iRF_DG_CreditBalance_ADCFROZ_Edit + 1;
        static int iRF_DG_CreditBalance_SaveWH = iRF_DG_CreditBalance_CalcPreview + 1;
        static int iRF_DG_CreditBalance_Total = iRF_DG_CreditBalance_SaveWH + 1;

        static int iRF_DG_PayAverages_AverageBest10YearsPay_Add = iRF_DG_CreditBalance_Total + 1;
        static int iRF_DG_PayAverages_AverageBest10YearsPay_Edit = iRF_DG_PayAverages_AverageBest10YearsPay_Add + 1;
        static int iRF_DG_PayAverages_AvgBest5YearsW2Pay_Add = iRF_DG_PayAverages_AverageBest10YearsPay_Edit + 1;
        static int iRF_DG_PayAverages_AvgBest5YearsW2Pay_Edit = iRF_DG_PayAverages_AvgBest5YearsW2Pay_Add + 1;
        static int iRF_DG_PayAverages_AvgBest3YearsPensionPay_Add = iRF_DG_PayAverages_AvgBest5YearsW2Pay_Edit + 1;
        static int iRF_DG_PayAverages_AvgBest3YearsPensionPay_Edit = iRF_DG_PayAverages_AvgBest3YearsPensionPay_Add + 1;
        static int iRF_DG_PayAverages_Benefit1DB_Add = iRF_DG_PayAverages_AvgBest3YearsPensionPay_Edit + 1;
        static int iRF_DG_PayAverages_Benefit1DB_Edit = iRF_DG_PayAverages_Benefit1DB_Add + 1;
        static int iRF_DG_PayAverages_IndexedPension_Add = iRF_DG_PayAverages_Benefit1DB_Edit + 1;
        static int iRF_DG_PayAverages_IndexedPension_Edit = iRF_DG_PayAverages_IndexedPension_Add + 1;
        static int iRF_DG_PayAverages_BridgeAmount_Add = iRF_DG_PayAverages_IndexedPension_Edit + 1;
        static int iRF_DG_PayAverages_BridgeAmount_Edit = iRF_DG_PayAverages_BridgeAmount_Add + 1;
        static int iRF_DG_PayAverages_LumpSumTermBenefit1_Add = iRF_DG_PayAverages_BridgeAmount_Edit + 1;
        static int iRF_DG_PayAverages_LumpSumTermBenefit1_Edit = iRF_DG_PayAverages_LumpSumTermBenefit1_Add + 1;
        static int iRF_DG_PayAverages_CalcPreview = iRF_DG_PayAverages_LumpSumTermBenefit1_Edit + 1;
        static int iRF_DG_PayAverages_SaveWH = iRF_DG_PayAverages_CalcPreview + 1;
        static int iRF_DG_PayAverages_Total = iRF_DG_PayAverages_SaveWH + 1;

        static int iRF_DG_Others_ESTPBEN_Add = iRF_DG_PayAverages_Total + 1;
        static int iRF_DG_Others_ESTPBEN_Edit = iRF_DG_Others_ESTPBEN_Add + 1;
        static int iRF_DG_Others_BOGHEAL_Add = iRF_DG_Others_ESTPBEN_Edit + 1;
        static int iRF_DG_Others_BOGHEAL_Edit = iRF_DG_Others_BOGHEAL_Add + 1;
        static int iRF_DG_Others_PHHPRJ_Add = iRF_DG_Others_BOGHEAL_Edit + 1;
        static int iRF_DG_Others_PHHPRJ_Edit = iRF_DG_Others_PHHPRJ_Add + 1;
        static int iRF_DG_Others_CalcPreview = iRF_DG_Others_PHHPRJ_Edit + 1;
        static int iRF_DG_Others_SaveWH = iRF_DG_Others_CalcPreview + 1;
        static int iRF_DG_Others_Total = iRF_DG_Others_SaveWH + 1;


        static int iRF_CK_LIMBENChangeInvalid = iRF_DG_Others_Total + 1;
        static int iRF_CK_TransAmountChange = iRF_CK_LIMBENChangeInvalid + 1;
        static int iRF_CK_ForzenBemefitChange = iRF_CK_TransAmountChange + 1;
        static int iRF_CK_ForzenServiceChange = iRF_CK_ForzenBemefitChange + 1;
        static int iRF_CK_EditStandardInputs = iRF_CK_ForzenServiceChange + 1;
        static int iRF_CK_ApplyChecks = iRF_CK_EditStandardInputs + 1;
        static int iRF_CK_Total = iRF_CK_ApplyChecks + 1;

        static int iRF_VU_NewViewUpdate1_Apply = iRF_CK_Total + 1;
        static int iRF_VU_ActiveBenefits_Add = iRF_VU_NewViewUpdate1_Apply + 1;
        static int iRF_VU_ActiveBenefits_Apply = iRF_VU_ActiveBenefits_Add + 1;
        static int iRF_VU_InactiveBenefits_Add = iRF_VU_ActiveBenefits_Apply + 1;
        static int iRF_VU_InactiveBenefits_Apply = iRF_VU_InactiveBenefits_Add + 1;
        static int iRF_VU_ActivePayAvgs_Add = iRF_VU_InactiveBenefits_Apply + 1;
        static int iRF_VU_ActivePayAvgs_Apply = iRF_VU_ActivePayAvgs_Add + 1;
        static int iRF_VU_Total = iRF_VU_ActivePayAvgs_Apply + 1;

        static int iRF_RP_CheckReport_Checks_Generate = iRF_VU_Total + 1;
        static int iRF_RP_CheckReport_Query_Add = iRF_RP_CheckReport_Checks_Generate + 1;
        static int iRF_RP_CheckReport_Query_Generate = iRF_RP_CheckReport_Query_Add + 1;
        static int iRF_RP_MembersStatus_Add = iRF_RP_CheckReport_Query_Generate + 1;
        static int iRF_RP_MembersStatus_Generate = iRF_RP_MembersStatus_Add + 1;
        static int iRF_RP_StatusMatrix_Generate = iRF_RP_MembersStatus_Generate + 1;
        static int iRF_RP_Total = iRF_RP_StatusMatrix_Generate + 1;


        static int iRF_SI_UploadFile = iRF_RP_Total + 1;
        static int iRF_SI_AddSimpleImport = iRF_SI_UploadFile + 1;
        static int iRF_SI_FileSelection = iRF_SI_AddSimpleImport + 1;
        static int iRF_SI_Preview = iRF_SI_FileSelection + 1;
        static int iRF_SI_Process = iRF_SI_Preview + 1;
        static int iRF_SI_Total = iRF_SI_Process + 1;

        static int iRF_CK_ReApply = iRF_SI_Total + 1;
        static int iRF_SS_Preview = iRF_CK_ReApply + 1;
        static int iRF_SS_Publish = iRF_SS_Preview + 1;
        static int iRF_SS_Total = iRF_SS_Publish + 1;

        static int iRF_Consume_Open = iRF_SS_Total + 19;
        static int iRF_Consume_Select = iRF_Consume_Open + 1;
        static int iRF_Consume_Import = iRF_Consume_Select + 1;
        static int iRF_Consume_Total = iRF_Consume_Import + 1;





        static int iTest = 243;

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


        #endregion




        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_US_Data_20K()
        {

            #region Initialize codes

            _gLib._CreateDirectory(sOutputDir, false);

            _gLib._MsgBox("Warning!", "Please Clear Cache!");

            pMain._SetLanguageAndRegional();

            mLog.LogInfo(iTimeStart, DateTime.Now.ToString());
            mLog.LogInfo(iNumOfEE, "20000");


            #endregion



            #region Create Client/Plan


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
            dic.Add("ClientCode", "001");
            dic.Add("FiscalYearEnd", "12/31");
            dic.Add("MeasurementDate", "10/30");
            dic.Add("Notes", "QTP Data Performance  testing");
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
            dic.Add("PlanYearBegin", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_PMTool_Plan(dic);






            #endregion


            #region Conversion - Current View & Upload


            pMain._SelectTab("Home");


            dic.Clear();
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
            dic.Add("Name", "Data2011");
            dic.Add("EffectiveDate", "01/01/2011");
            dic.Add("Parent", "");
            dic.Add("RSC", "True");
            dic.Add("Shared", "");
            dic.Add("GeneralUse", "");
            dic.Add("Conversion", "True");
            dic.Add("CopyDataService", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_DataServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Data2011");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            mTimeTotal.StartTimer();


            dic.Clear();
            dic.Add("Level_1", "Data2011");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EditSelection", "");
            dic.Add("AddSingleLabel", "");
            dic.Add("AddMultipleLabels", "Click");
            pData._PopVerify_CurrentView(dic);

            _gLib._Exists("Add Multiple Label", pData.wCV_AddLabels, 0, true);

            mTime.StopTimer(iConversion_CV_MultipleLabel_Open);
            ////////////////mLog.LogInfo(iConversion_CV_MultipleLabel_Open, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            _gLib._KillProcessByName("EXCEL");
            MyExcel _excel = new MyExcel(sCurrentViewFile_Conversion, true);
            _excel.OpenExcelFile(1);

            int iTotalRow = _excel.getTotalRowCount();
            int iTotalCol = _excel.getTotalColumnCount();
            string sContents = "";
            for (int i = 2; i <= iTotalRow; i++)
            {
                string sRow = "";
                for (int j = 1; j <= iTotalCol; j++)
                    sRow = sRow + _excel.getOneCellValue(i, j) + "\t";

                sContents = sContents + sRow + Environment.NewLine;
            }
            _excel.CloseExcelApplication();

            Clipboard.Clear();
            Clipboard.SetText(sContents);

            _fp._ClickFirstRow(pData.wCV_AddLabels.wFPGrid.grid, 5, 15);
            _gLib._SendKeysUDWin("FPGrid", pData.wCV_AddLabels.wFPGrid.grid, "v", 0, ModifierKeys.Control, false);

            _gLib._SendKeysUDWin("FPGrid", pData.wCV_AddLabels.wFPGrid.grid, "{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}");

            int iTotalRow_Act = _fp._ReturnSelectRowIndex(pData.wCV_AddLabels.wFPGrid.grid) + 1;

            if (iTotalRow != iTotalRow_Act)
            {
                _gLib._Report(_PassFailStep.Fail, "Going to add <" + (iTotalRow - 1).ToString() + "> labels. Actual <" + (iTotalRow_Act + 1).ToString() + "> labels added! ");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Going to add <" + (iTotalRow - 1).ToString() + "> labels. Actual <" + (iTotalRow_Act + 1).ToString() + "> labels added! ");
            }

            mTime.StopTimer(iConversion_CV_MultipleLabel_CopyPaste);
            ////////////////mLog.LogInfo(iConversion_CV_MultipleLabel_CopyPaste, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            _gLib._SetSyncUDWin("OK", pData.wCV_AddLabels.wOK.btnOK, "Click", 0);

            pMain._SelectTab("Data2011");

            mTime.StopTimer(iConversion_CV_MultipleLabel_Add);
            //////////////mLog.LogInfo(iConversion_CV_MultipleLabel_Add, MyPerformanceCounter.Memory_Private);

            mTimeTotal.StopTimer(iConversion_CV_MultipleLabel_Total);
            mLog.LogInfo(iConversion_CV_MultipleLabel_Total, MyPerformanceCounter.Memory_Private);



            pMain._Home_ToolbarClick_Top(true);



            pMain._SelectTab("Data2011");

            mTimeTotal.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2011");
            dic.Add("Level_2", "Upload Data");
            pData._TreeViewSelect(dic);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "Click");
            dic.Add("Upload", "");
            pData._PopVerify_UploadData(dic);

            _gLib._Exists("File Open", pMain.wFileOpen, 0, true);

            mTime.StopTimer(iConversion_UL_Open);
            ////////////mLog.LogInfo(iConversion_UL_Open, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", sDataFile_Conversion);
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);

            pMain._SelectTab("Data2011");

            mTime.StopTimer(iConversion_UL_Upload);
            //////////////mLog.LogInfo(iConversion_UL_Upload, MyPerformanceCounter.Memory_Private);

            mTimeTotal.StopTimer(iConversion_UL_Total);
            mLog.LogInfo(iConversion_UL_Total, MyPerformanceCounter.Memory_Private);



            #endregion


            #region Conversion - Imports - Select File & Columns

            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2011");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            pData._SelectTab("Select File");

            mTime.StopTimer(iConversion_IM_Add);
            mLog.LogInfo(iConversion_IM_Add, MyPerformanceCounter.Memory_Private);

            mTimeTotal.StartTimer();



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "ImportData");
            dic.Add("FileType", "Excel file");
            dic.Add("Browse", "");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            _gLib._Exists("File Selection", pData.wIP_SelectFile_FileSelection, Config.iTimeout, true);

            mTime.StopTimer(iConversion_IM_SF_Open);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", sDataFile_Conversion_FileName);
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            pData._SelectTab("Select File");

            mTime.StopTimer(iConversion_IM_SF_Select);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_SelectFile(dic);

            pData._SelectTab("Select File");

            mTime.StopTimer(iConversion_IM_SF_Preview);



            mTimeTotal.StopTimer(iConversion_IM_SF_Total);
            mLog.LogInfo(iConversion_IM_SF_Total, MyPerformanceCounter.Memory_Private);




            pData._SelectTab("Columns");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_Mapping(dic);

            pData._SelectTab("Columns");

            mTime.StopTimer(iConversion_IM_CL_Preview);
            mLog.LogInfo(iConversion_IM_CL_Preview, MyPerformanceCounter.Memory_Private);



            #endregion


            #region Conversion - Imports - Mapping
            mTimeTotal.StartTimer();



            pData._SelectTab("Mapping");

            pData._IP_Mapping_Initialize("Personal Information", "Classification Codes", 1, 0, 1, "DivisionCode");
            pData._IP_Mapping_Initialize("Personal Information", "DB Information", 1, 0, 1, "MembershipDate1");
            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "EmployeeIDNumber");


            mTime.StartTimer();

            pData._IP_Mapping_MapField("Gender", "SEX", 7, true, 3);
            pData._IP_Mapping_MapField("CredServiceDate", "SCRED", 6, true, 17);
            pData._IP_Mapping_MapField("VestServiceDate", "SVEST", 13, true, 13);
            pData._IP_Mapping_MapField("StartDate1", "ERETIRE", 20, true, 6);
            pData._IP_Mapping_MapField("DivisionCode", "DIV", 8, true, 37);
            pData._IP_Mapping_MapField("SubDivisionCode", "GROUP", 3, true, 8);

            mTime.StopTimer(iConversion_IM_MP_Map);


            mTime.StartTimer();

            pData._IP_Mapping_MapField("USC", "ETY", 25, false, 6);

            pData._IP_Mapping_ClickEdit("USC", true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_Transformation(1, 1, "1");
            pData._IP_Mapping_Transformation(1, 2, "XAct");

            pData._IP_Mapping_Transformation(2, 1, "2");
            pData._IP_Mapping_Transformation(2, 2, "Act");

            pData._IP_Mapping_Transformation(3, 1, "3");
            pData._IP_Mapping_Transformation(3, 2, "Act");

            pData._IP_Mapping_Transformation(4, 1, "11");
            pData._IP_Mapping_Transformation(4, 2, "Def");

            pData._IP_Mapping_Transformation(5, 1, "12");
            pData._IP_Mapping_Transformation(5, 2, "XNvt");

            pData._IP_Mapping_Transformation(6, 1, "13");
            pData._IP_Mapping_Transformation(6, 2, "Defdis1");

            pData._IP_Mapping_Transformation(7, 1, "14");
            pData._IP_Mapping_Transformation(7, 2, "Ret");

            pData._IP_Mapping_Transformation(8, 1, "15");
            pData._IP_Mapping_Transformation(8, 2, "DefTranOut");

            pData._IP_Mapping_Transformation(9, 1, "16");
            pData._IP_Mapping_Transformation(9, 2, "RetDis1");

            pData._IP_Mapping_Transformation(10, 1, "17");
            pData._IP_Mapping_Transformation(10, 2, "Xdec");

            pData._IP_Mapping_Transformation(11, 1, "18");
            pData._IP_Mapping_Transformation(11, 2, "RetBene");

            pData._IP_Mapping_Transformation(12, 1, "19");
            pData._IP_Mapping_Transformation(12, 2, "DefBene");

            pData._IP_Mapping_Transformation(13, 1, "34");
            pData._IP_Mapping_Transformation(13, 2, "Ret");

            pData._IP_Mapping_Transformation(14, 1, "92");
            pData._IP_Mapping_Transformation(14, 2, "XNvt");

            pData._IP_Mapping_Transformation(15, 1, "97");
            pData._IP_Mapping_Transformation(15, 2, "XLs");

            pData._IP_Mapping_Transformation(16, 1, "98");
            pData._IP_Mapping_Transformation(16, 2, "XLs");

            pData._IP_Mapping_Transformation(17, 1, "99");
            pData._IP_Mapping_Transformation(17, 2, "XAct");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            mTime.StopTimer(iConversion_IM_MP_USC);



            pData._SelectTab("Mapping");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_Mapping(dic);

            pData._SelectTab("Mapping");

            mTime.StopTimer(iConversion_IM_MP_Preview);


            mTimeTotal.StopTimer(iConversion_IM_MP_Total);
            mLog.LogInfo(iConversion_IM_MP_Total, MyPerformanceCounter.Memory_Private);
            #endregion


            #region Conversion - Imports - V&L, PMD, Matching

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

            _gLib._Exists("Validate & Load", pData.wIP_ValidateAndLoad_Popup, Config.iTimeout * 5, true);

            mTime.StopTimer(iConversion_IM_ValidateAndLoad);
            mLog.LogInfo(iConversion_IM_ValidateAndLoad, MyPerformanceCounter.Memory_Private);


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

            pData._SelectTab("Validate & Load");


            pData._SelectTab("Pre Matching Derivations");
            mTimeTotal.StartTimer();


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
            dic.Add("DerivedField", "DivisionCode");
            dic.Add("DerivedField_SearchFromIndex", "9");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iConversion_IM_PMD_DivisionCode_Add);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
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
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "EDSAL");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(EDSAL=1, \"Salaried\", \"Hourly\"");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            mTime.StopTimer(iConversion_IM_PMD_DivisionCode_Edit);


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
            mTime.StopTimer(iConversion_IM_PMD_CalcPreview);


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

            mTime.StopTimer(iConversion_IM_PMD_SaveWH);


            pData._SelectTab("Pre Matching Derivations");
            mTimeTotal.StopTimer(iConversion_IM_PMD_Total);
            mLog.LogInfo(iConversion_IM_PMD_Total, MyPerformanceCounter.Memory_Private);


            pData._SelectTab("Matching");
            mTimeTotal.StartTimer();

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
            mTime.StopTimer(iConversion_IM_MC_FindMatch);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", iConversion_UniqueMatchNum.ToString());
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

            pData._SelectTab("Matching");
            mTime.StopTimer(iConversion_IM_MC_AcceptNew);



            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Matched_Num", "0");
            dic.Add("New_Num", iConversion_UniqueMatchNum.ToString());
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

            //////////////dic.Clear();
            //////////////dic.Add("PopVerify", "Verify");
            //////////////dic.Add("Message", "Once the matching results have been processed, all the Import parameters for this file will become read-only. Do you wish to proceed?");
            //////////////dic.Add("Yes", "");
            //////////////dic.Add("No", "");
            //////////////pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);


            ////////////dic.Clear();
            ////////////dic.Add("PopVerify", "Verify");
            ////////////dic.Add("Message", "The matching results have now been processed. All the Import parameters for this file are now read-only.");
            ////////////dic.Add("OK", "");
            ////////////pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);

            _gLib._Exists("ProcessMatchingResultsComplete", pData.wIP_Matching_ProcessMatchingResultsComplete_Popup, Config.iTimeout * 3, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);

            mTime.StopTimer(iConversion_IM_MC_SaveWH);


            pData._SelectTab("Matching");
            mTimeTotal.StopTimer(iConversion_IM_MC_Total);
            mLog.LogInfo(iConversion_IM_MC_Total, MyPerformanceCounter.Memory_Private);
            #endregion


            #region Conversion - Derivation Groups - DerivedGrp
            mTimeTotal.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2011");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "DerivedGrp");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


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
            dic.Add("DerivedField", "USC");
            dic.Add("DerivedField_SearchFromIndex", "4");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iConversion_DG_DerivedGrp_USCDefDis1_Add);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_3", "HealthStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "USC");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "True");
            dic.Add("CustomExpression_Formula", "=USC_C=\"DefDis1\"");
            dic.Add("Formula", "=IF(HealthStatus_C=\"E\", \"DefDis2\", IF(HealthStatus_C=\"F\", \"DefDis3\", USC_C))");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iConversion_DG_DerivedGrp_USCDefDis1_Edit);


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
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "USC");
            dic.Add("DerivedField_SearchFromIndex", "4");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iConversion_DG_DerivedGrp_USCDetDis1_Add);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_3", "HealthStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "USC");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "True");
            dic.Add("CustomExpression_Formula", "=USC_C=\"DetDis1\"");
            dic.Add("Formula", "=IF(HealthStatus_C=\"E\", \"DetDis2\", IF(HealthStatus_C=\"F\", \"DetDis3\", USC_C");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iConversion_DG_DerivedGrp_USCDetDis1_Edit);



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
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Benefit1DB");
            dic.Add("DerivedField_SearchFromIndex", "13");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iConversion_DG_DerivedGrp_Benefit1DB_Add);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_3", "Benefit1DB");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=Benefit1DB_C*12.0");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iConversion_DG_DerivedGrp_Benefit1DB_Edit);

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

            pMain._SelectTab("Data2011");
            mTime.StopTimer(iConversion_DG_DerivedGrp_CalcPreview);


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

            pMain._SelectTab("Data2011");
            mTime.StopTimer(iConversion_DG_DerivedGrp_SaveWH);


            mTimeTotal.StopTimer(iConversion_DG_DerivedGrp_Total);
            mLog.LogInfo(iConversion_DG_DerivedGrp_Total, MyPerformanceCounter.Memory_Private);
            #endregion


            #region Conversion - Derivation Groups - CalcDates
            mTimeTotal.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2011");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "CalcDates");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);



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
            dic.Add("DerivedField", "EVESTLY");
            dic.Add("DerivedField_SearchFromIndex", "28");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iConversion_DG_CalcDates_EVESTLY_Add);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "Date");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "True");
            dic.Add("CustomExpression_Formula", "=HireDate1_C<>\"\"");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service - Years");
            dic.Add("sData", "5");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "28");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service Field");
            dic.Add("sData", "HireDate1_C");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            mTime.StopTimer(iConversion_DG_CalcDates_EVESTLY_Edit);


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
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "ERETIRELY");
            dic.Add("DerivedField_SearchFromIndex", "20");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iConversion_DG_CalcDates_ERETIRELY_Add);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "Date");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "True");
            dic.Add("CustomExpression_Formula", "=BirthDate_C<>\"\"");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service - Years");
            dic.Add("sData", "65");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "28");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service Field");
            dic.Add("sData", "BirthDate_C");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            mTime.StopTimer(iConversion_DG_CalcDates_ERETIRELY_Edit);




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
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "ECREDLY");
            dic.Add("DerivedField_SearchFromIndex", "2");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iConversion_DG_CalcDates_ECREDLY_Add);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "Date");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);





            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Fixed age");
            dic.Add("sData", "45");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "24");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Age Rounding");
            dic.Add("sData", "First of Month");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "28");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service Field");
            dic.Add("sData", "HireDate1_C");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            mTime.StopTimer(iConversion_DG_CalcDates_ECREDLY_Edit);


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
            dic.Add("iRow", "4");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "NRDLY");
            dic.Add("DerivedField_SearchFromIndex", "21");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iConversion_DG_CalcDates_NRDLY_Add);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "Date");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);





            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Fixed age");
            dic.Add("sData", "65");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "24");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Age Rounding");
            dic.Add("sData", "First of Next Month");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "28");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service Field");
            dic.Add("sData", "BirthDate_C");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Is Act");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            mTime.StopTimer(iConversion_DG_CalcDates_NRDLY_Edit);


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

            pMain._SelectTab("Data2011");
            mTime.StopTimer(iConversion_DG_CalcDates_CalcPreview);


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

            pMain._SelectTab("Data2011");
            mTime.StopTimer(iConversion_DG_CalcDates_SaveWH);

            mTimeTotal.StopTimer(iConversion_DG_CalcDates_Total);
            mLog.LogInfo(iConversion_DG_CalcDates_Total, MyPerformanceCounter.Memory_Private);
            #endregion


            #region Conversion - Derivation Groups - AgeCalculations
            mTimeTotal.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2011");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "AgeCalculations");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

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
            dic.Add("DerivedField", "AGELY");
            dic.Add("DerivedField_SearchFromIndex", "5");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iConversion_DG_AgeCalc_AGELY_Add);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_3", "BirthDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=YEAR(EffectiveDate)-YEAR(BirthDate_C)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iConversion_DG_AgeCalc_AGELY_Edit);



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
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "AGEGROUP");
            dic.Add("DerivedField_SearchFromIndex", "4");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iConversion_DG_AgeCalc_AGEGROUP_Add);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_3", "HireDate1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=YEAR(EffectiveDate)-YEAR(HireDate1_C)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iConversion_DG_AgeCalc_AGEGROUP_Edit);



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
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "BAGELY");
            dic.Add("DerivedField_SearchFromIndex", "1");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iConversion_DG_AgeCalc_BAGELY_Add);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_3", "Beneficiary1BirthDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=YEAR(EffectiveDate)-YEAR(Beneficiary1BirthDate_C)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iConversion_DG_AgeCalc_BAGELY_Edit);

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

            pMain._SelectTab("Data2011");
            mTime.StopTimer(iConversion_DG_AgeCalc_CalcPreview);


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

            pMain._SelectTab("Data2011");
            mTime.StopTimer(iConversion_DG_AgeCalc_SaveWH);

            mTimeTotal.StopTimer(iConversion_DG_AgeCalc_Total);
            mLog.LogInfo(iConversion_DG_AgeCalc_Total, MyPerformanceCounter.Memory_Private);
            #endregion


            #region Conversion - Derivation Groups - CreditBalance
            mTimeTotal.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2011");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "CreditBalance");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

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
            dic.Add("DerivedField", "TotalBalance");
            dic.Add("DerivedField_SearchFromIndex", "3");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iConversion_DG_CreditBalance_TotalBalance_Add);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_3", "CBAL02");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "CBAL08");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "CBAL09");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "CBAL10");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=CBAL02_C+CBAL08_C+CBAL09_C+CBAL10_C");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iConversion_DG_CreditBalance_TotalBalance_Edit);



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
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "ADCFROZ");
            dic.Add("DerivedField_SearchFromIndex", "3");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iConversion_DG_CreditBalance_ADCFROZ_Add);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Formula", "=1.10");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iConversion_DG_CreditBalance_ADCFROZ_Edit);



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
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "LIMPEPLY");
            dic.Add("DerivedField_SearchFromIndex", "4");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iConversion_DG_CreditBalance_LIMPEPLY_Add);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_2", "Custom Fields");
            dic.Add("Level_3", "TotalBalance");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "AGEGROUP");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=TotalBalance_C/AGEGROUP_C");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iConversion_DG_CreditBalance_LIMPEPLY_Edit);

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

            pMain._SelectTab("Data2011");
            mTime.StopTimer(iConversion_DG_CreditBalance_CalcPreview);


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

            pMain._SelectTab("Data2011");
            mTime.StopTimer(iConversion_DG_CreditBalance_SaveWH);

            mTimeTotal.StopTimer(iConversion_DG_CreditBalance_Total);
            mLog.LogInfo(iConversion_DG_CreditBalance_Total, MyPerformanceCounter.Memory_Private);
            #endregion


            #region Conversion - Derivation Groups - PayAverages
            mTimeTotal.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2011");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "PayAverages");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

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
            dic.Add("DerivedField", "PayAverage5");
            dic.Add("DerivedField_SearchFromIndex", "3");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iConversion_DG_PayAverage_PayAverage5_Add);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_4", "XPAY");
            dic.Add("Level_5", "XPAYPriorYear1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "XPAY");
            dic.Add("Level_5", "XPAYPriorYear2");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "XPAY");
            dic.Add("Level_5", "XPAYPriorYear3");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "XPAY");
            dic.Add("Level_5", "XPAYPriorYear4");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "XPAY");
            dic.Add("Level_5", "XPAYPriorYear5");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND((XPAYPriorYear1_C+XPAYPriorYear2_C+XPAYPriorYear3_C+XPAYPriorYear4_C+XPAYPriorYear5_C)/5,2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iConversion_DG_PayAverage_PayAverage5_Edit);



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
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "NDTPayAverage3");
            dic.Add("DerivedField_SearchFromIndex", "18");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iConversion_DG_PayAverage_NDTPayAverage3_Add);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_4", "NDPAY");
            dic.Add("Level_5", "NDPAYPriorYear1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "NDPAY");
            dic.Add("Level_5", "NDPAYPriorYear2");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "NDPAY");
            dic.Add("Level_5", "NDPAYPriorYear3");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND((NDPAYPriorYear1_C+NDPAYPriorYear2_C+NDPAYPriorYear3_C)/3,2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iConversion_DG_PayAverage_NDTPayAverage3_Edit);



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
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "W2PayAverage2Years");
            dic.Add("DerivedField_SearchFromIndex", "1");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iConversion_DG_PayAverage_W2PayAverage2Years_Add);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_4", "W2PAY");
            dic.Add("Level_5", "W2PAYPriorYear1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "W2PAY");
            dic.Add("Level_5", "W2PAYPriorYear2");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND((W2PAYPriorYear1_C+W2PAYPriorYear2_C)/2,2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iConversion_DG_PayAverage_W2PayAverage2Years_Edit);

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

            pMain._SelectTab("Data2011");
            mTime.StopTimer(iConversion_DG_PayAverage_CalcPreview);


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

            pMain._SelectTab("Data2011");
            mTime.StopTimer(iConversion_DG_PayAverage_SaveWH);

            mTimeTotal.StopTimer(iConversion_DG_PayAverage_Total);
            mLog.LogInfo(iConversion_DG_PayAverage_Total, MyPerformanceCounter.Memory_Private);
            #endregion


            #region Conversion - Checks, View&Update, Snapshots

            dic.Clear();
            dic.Add("Level_1", "Data2011");
            dic.Add("Level_2", "Checks");
            pData._TreeViewSelect(dic);


            pMain._Home_ToolbarClick_Top(true);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "Click");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);


            pMain._SelectTab("Data2011");
            mTime.StopTimer(iConversion_CK_ApplyChecks);
            mLog.LogInfo(iConversion_CK_ApplyChecks, MyPerformanceCounter.Memory_Private);


            mTimeTotal.StartTimer();


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2011");
            dic.Add("Level_2", "View & Update");
            dic.Add("MenuItem", "Add new view");
            pData._TreeViewRightSelect(dic);

            _gLib._Exists("View & Update", pData.wRetirementStudio.wVU_Apply, Config.iTimeout * 3);

            mTime.StopTimer(iConversion_VU_Add);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Filter", "");
            dic.Add("Apply", "Click");
            pData._PopVerify_ViewUpdate(dic);

            pMain._SelectTab("Data2011");
            mTime.StopTimer(iConversion_VU_Apply);


            mTimeTotal.StopTimer(iConversion_VU_Total);
            mLog.LogInfo(iConversion_VU_Total, MyPerformanceCounter.Memory_Private);


            mTimeTotal.StartTimer();

            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2011");
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "ImportData");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            mTime.StopTimer(iConversion_SS_Add);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "EmployeeIDNumber");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Name");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "BirthDate");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "HireDate1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Gender");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "USC");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ParticipantStatus");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PayStatus");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "HealthStatus");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "AliveStatus");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ExitDate");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "TerminationDate1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "DeathDate");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "MaritalStatus");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ImportName");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ReHireDate1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "CredServiceDate");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "VestServiceDate");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "NDPAY");
            dic.Add("Level_5", "NDPAYCurrentYear");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "NDPAY");
            dic.Add("Level_5", "NDPAYPriorYear1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "NDPAY");
            dic.Add("Level_5", "NDPAYPriorYear2");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "NDPAY");
            dic.Add("Level_5", "NDPAYPriorYear3");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "NDPAY");
            dic.Add("Level_5", "NDPAYPriorYear4");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "W2PAY");
            dic.Add("Level_5", "W2PAYCurrentYear");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "W2PAY");
            dic.Add("Level_5", "W2PAYPriorYear1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "W2PAY");
            dic.Add("Level_5", "W2PAYPriorYear2");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "W2PAY");
            dic.Add("Level_5", "W2PAYPriorYear3");
            pData._TreeViewSelect_Snapshots(dic, true);



            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "XPAY");
            dic.Add("Level_5", "XPAYCurrentYear");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "XPAY");
            dic.Add("Level_5", "XPAYPriorYear1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "XPAY");
            dic.Add("Level_5", "XPAYPriorYear2");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "XPAY");
            dic.Add("Level_5", "XPAYPriorYear3");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "XPAY");
            dic.Add("Level_5", "XPAYPriorYear4");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Hours");
            dic.Add("Level_4", "XHRS");
            dic.Add("Level_5", "XHRSCurrentYear");
            pData._TreeViewSelect_Snapshots(dic, true);




            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1ID");
            pData._TreeViewSelect_Snapshots(dic, true);

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
            dic.Add("Level_3", "Beneficiary1Name");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1Percent1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1Benefit1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1StartDate1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1PaymentForm1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1Type");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1DeathDate");
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
            dic.Add("Level_3", "ContribRate1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "ContribsWInterest1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "ContribsWOInterest1");
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
            dic.Add("Level_3", "LumpSumDeathBenefit1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "LumpSumPayDate1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "LumpSumTermBenefit1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "PartTimeFactor");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "BridgeAmount");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "BridgeStopDate");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "DivisionCode");
            pData._TreeViewSelect_Snapshots(dic, true);



            mTime.StopTimer(iConversion_SS_PickUpFields);


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

            pMain._SelectTab("Data2011");
            mTime.StopTimer(iConversion_SS_Preview);


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

            pMain._SelectTab("Data2011");
            mTime.StopTimer(iConversion_SS_Publish);



            mTimeTotal.StopTimer(iConversion_SS_Total);
            mLog.LogInfo(iConversion_SS_Total, MyPerformanceCounter.Memory_Private);

            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region Conversion - Report, Consume snapshot
            mTimeTotal.StartTimer();

            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2011");
            dic.Add("Level_2", "Reports");
            dic.Add("MenuItem", "Add new report");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "");
            dic.Add("StatusMatrix", "");
            dic.Add("StatusMatrix_Filter", "");
            dic.Add("ReportName", "ChecksReport");
            dic.Add("GenerateReport", "");
            pData._PopVerify_Reports(dic);

            mTimeTotal.StopTimer(iConversion_RP_Add);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "");
            dic.Add("StatusMatrix", "");
            dic.Add("StatusMatrix_Filter", "");
            dic.Add("ReportName", "");
            dic.Add("GenerateReport", "Click");
            pData._PopVerify_Reports(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_RP_ReportGenerated_Popup(dic);


            pMain._SelectTab("Data2011");
            mTimeTotal.StopTimer(iConversion_RP_Generate);




            mTimeTotal.StopTimer(iConversion_RP_Total);
            mLog.LogInfo(iConversion_RP_Total, MyPerformanceCounter.Memory_Private);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

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
            dic.Add("Name", "ValService2011");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "2011");
            dic.Add("FirstYearPlanUnderPPA", "2011");
            dic.Add("RSC", "");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "ValService2011");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("ValService2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Data");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            mTimeTotal.StartTimer();


            pMain._SelectTab("Participant DataSet");

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
            dic.Add("SnapshotName", "ImportData");
            dic.Add("OK", "");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);

            mTime.StopTimer(iConversion_Consume_Open);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);

            pMain._SelectTab("Participant DataSet");
            mTime.StopTimer(iConversion_Consume_Select);


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
            mTime.StopTimer(iConversion_Consume_Import);


            mTimeTotal.StopTimer(iConversion_Consume_Total);
            mLog.LogInfo(iConversion_Consume_Total, MyPerformanceCounter.Memory_Private);

            pMain._SelectTab("ValService2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region RF - Service, CurrentView, Upload

            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "ParticipantData");
            pMain._HomeTreeViewSelect(0, dic);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Data2012");
            dic.Add("EffectiveDate", "01/01/2012");
            dic.Add("Parent", "Data2011");
            dic.Add("RSC", "");
            dic.Add("Shared", "");
            dic.Add("GeneralUse", "");
            dic.Add("Conversion", "");
            dic.Add("CopyDataService", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_DataServicePropeties(dic);

            pMain._SelectTab("Home");
            mTime.StopTimer(iRF_Service_Add);
            mLog.LogInfo(iRF_Service_Add, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Data2012");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            mTime.StopTimer(iRF_Service_Open);
            mLog.LogInfo(iRF_Service_Open, MyPerformanceCounter.Memory_Private);




            mTimeTotal.StartTimer();


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EditSelection", "");
            dic.Add("AddSingleLabel", "");
            dic.Add("AddMultipleLabels", "Click");
            pData._PopVerify_CurrentView(dic);

            _gLib._Exists("Add Multiple Label", pData.wCV_AddLabels, 0, true);

            mTime.StopTimer(iRF_CV_MultipleLabel_Open);


            mTime.StartTimer();

            _gLib._KillProcessByName("EXCEL");
            MyExcel _excelRF = new MyExcel(sCurrentViewFile_RF, true);
            _excelRF.OpenExcelFile(1);

            int iTotalRowRF = _excelRF.getTotalRowCount();
            int iTotalColRF = _excelRF.getTotalColumnCount();
            string sContentsRF = "";
            for (int i = 2; i <= iTotalRowRF; i++)
            {
                string sRow = "";
                for (int j = 1; j <= iTotalColRF; j++)
                    sRow = sRow + _excelRF.getOneCellValue(i, j) + "\t";

                sContentsRF = sContentsRF + sRow + Environment.NewLine;
            }
            _excelRF.CloseExcelApplication();

            Clipboard.Clear();
            Clipboard.SetText(sContentsRF);

            _fp._ClickFirstRow(pData.wCV_AddLabels.wFPGrid.grid, 5, 15);
            _gLib._SendKeysUDWin("FPGrid", pData.wCV_AddLabels.wFPGrid.grid, "v", 0, ModifierKeys.Control, false);

            _gLib._SendKeysUDWin("FPGrid", pData.wCV_AddLabels.wFPGrid.grid, "{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}");

            int iTotalRow_ActRF = _fp._ReturnSelectRowIndex(pData.wCV_AddLabels.wFPGrid.grid) + 1;

            if (iTotalRowRF != iTotalRow_ActRF)
            {
                _gLib._Report(_PassFailStep.Fail, "Going to add <" + (iTotalRowRF - 1).ToString() + "> labels. Actual <" + (iTotalRow_ActRF + 1).ToString() + "> labels added! ");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Going to add <" + (iTotalRowRF - 1).ToString() + "> labels. Actual <" + (iTotalRow_ActRF + 1).ToString() + "> labels added! ");
            }

            mTime.StopTimer(iRF_CV_MultipleLabel_CopyPaste);


            mTime.StartTimer();

            _gLib._SetSyncUDWin("OK", pData.wCV_AddLabels.wOK.btnOK, "Click", 0);

            pMain._SelectTab("Data2012");

            mTime.StopTimer(iRF_CV_MultipleLabel_Add);

            mTimeTotal.StopTimer(iRF_CV_MultipleLabel_Total);
            mLog.LogInfo(iRF_CV_MultipleLabel_Total, MyPerformanceCounter.Memory_Private);



            pMain._Home_ToolbarClick_Top(true);



            pMain._SelectTab("Data2012");

            mTimeTotal.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Upload Data");
            pData._TreeViewSelect(dic);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "Click");
            dic.Add("Upload", "");
            pData._PopVerify_UploadData(dic);

            _gLib._Exists("File Open", pMain.wFileOpen, 0, true);

            mTime.StopTimer(iRF_UL_Open);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", sDataFile_Rollforward);
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);

            pMain._SelectTab("Data2012");

            mTime.StopTimer(iRF_UL_Upload);

            mTimeTotal.StopTimer(iRF_UL_Total);
            mLog.LogInfo(iRF_UL_Total, MyPerformanceCounter.Memory_Private);




            #endregion


            #region RF - Imports


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "ImportData");
            pData._TreeViewSelect(dic);

            mTimeTotal.StartTimer();

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            _gLib._Exists("File Selection", pData.wIP_SelectFile_FileSelection, Config.iTimeout, true);

            mTime.StopTimer(iRF_IM_SF_Open);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", sDataFile_Rollforward_FileName);
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            _gLib._Exists("Select File", pData.wRetirementStudio.wIP_Tabs, Config.iTimeout * 3, true);

            pData._SelectTab("Select File");

            mTime.StopTimer(iRF_IM_SF_Select);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_SelectFile(dic);

            pData._SelectTab("Select File");

            mTime.StopTimer(iRF_IM_SF_Preview);


            mTimeTotal.StopTimer(iRF_IM_SF_Total);
            mLog.LogInfo(iRF_IM_SF_Total, MyPerformanceCounter.Memory_Private);


            pData._SelectTab("Columns");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_SelectFile(dic);

            pData._SelectTab("Columns");
            mTime.StopTimer(iRF_IM_CL_Preview);
            mLog.LogInfo(iRF_IM_CL_Preview, MyPerformanceCounter.Memory_Private);


            pData._SelectTab("Mapping");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_SelectFile(dic);

            pData._SelectTab("Mapping");
            mTime.StopTimer(iRF_IM_MP_Preview);
            mLog.LogInfo(iRF_IM_MP_Preview, MyPerformanceCounter.Memory_Private);


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
            dic.Add("PopVerify", "Pop");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);

            pData._SelectTab("Validate & Load");
            mTime.StopTimer(iRF_IM_ValidateAndLoad);
            mLog.LogInfo(iRF_IM_ValidateAndLoad, MyPerformanceCounter.Memory_Private);



            pData._SelectTab("Pre Matching Derivations");
            mTimeTotal.StartTimer();

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
            mTime.StopTimer(iRF_IM_PMD_CalcPreview);


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

            mTime.StopTimer(iRF_IM_PMD_SaveWH);


            pData._SelectTab("Pre Matching Derivations");
            mTimeTotal.StopTimer(iRF_IM_PMD_Total);
            mLog.LogInfo(iRF_IM_PMD_Total, MyPerformanceCounter.Memory_Private);




            pData._SelectTab("Matching");
            mTimeTotal.StartTimer();

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
            mTime.StopTimer(iRF_IM_MC_FindMatch);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", iRF_NoMatchNum.ToString());
            dic.Add("Unique_UniqueMatch_Num", iRF_UniqueMatchNum.ToString());
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "0");
            dic.Add("Duplicate_UniqueMatch_Num", "0");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
            dic.Add("Warehouse_NoMatch_Num", iRF_WarehouseNoMatchNum.ToString());
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
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);

            pData._SelectTab("Matching");
            mTime.StopTimer(iRF_IM_MC_AcceptNew);



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
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);

            pData._SelectTab("Matching");
            mTime.StopTimer(iRF_IM_MC_AcceptMatch);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "");
            dic.Add("Unique_UniqueMatch", "");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "Click");
            dic.Add("AcceptAllRecordsAs_What", "Unmatched");
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

            pData._SelectTab("Matching");
            mTime.StopTimer(iRF_IM_MC_AcceptNoMatch);





            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Matched_Num", iRF_UniqueMatchNum.ToString());
            dic.Add("New_Num", iRF_NoMatchNum.ToString());
            dic.Add("Ignored_Num", "0");
            dic.Add("Gone_Num", "0");
            dic.Add("Leaver_Num", "0");
            dic.Add("Unmatched_Num", iRF_WarehouseNoMatchNum.ToString());
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
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);


            _gLib._Exists("ProcessMatchingResultsComplete", pData.wIP_Matching_ProcessMatchingResultsComplete_Popup, Config.iTimeout * 3, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);

            mTime.StopTimer(iRF_IM_MC_SaveWH);


            pData._SelectTab("Matching");
            mTimeTotal.StopTimer(iRF_IM_MC_Total);
            mLog.LogInfo(iRF_IM_MC_Total, MyPerformanceCounter.Memory_Private);

            #endregion


            #region RF - Filter

            mTimeTotal.StartTimer();


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Filters");
            pData._TreeViewSelect(dic);

            pData._FL_Grid("Custom", 53, false);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            _gLib._Exists("Filter Definition", pData.wDG_DerivationDefinition, Config.iTimeout * 3, true);
            mTime.StopTimer(iRF_FL_FrozenBenefitGroup_Open);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "FrozenBenefitGroup");
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
            dic.Add("Level_3", "FROZDV");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "FROZER");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=OR(FROZDV_C>0, FROZER_C>0)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_FL_FrozenBenefitGroup_Edit);



            pData._FL_Grid("Custom", 53, false);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            _gLib._Exists("Filter Definition", pData.wDG_DerivationDefinition, Config.iTimeout * 3, true);
            mTime.StopTimer(iRF_FL_HighEarner_Open);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "HighEarner");
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
            dic.Add("Level_4", "NDPAY");
            dic.Add("Level_5", "NDPAYCurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "NDPAY");
            dic.Add("Level_5", "NDPAYPriorYear1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "NDPAY");
            dic.Add("Level_5", "NDPAYPriorYear2");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=OR(NDPAYCurrentYear_C>250000, NDPAYPriorYear1_C>250000, NDPAYPriorYear2_C>250000)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_FL_HighEarner_Edit);




            pData._FL_Grid("Custom", 53, false);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            _gLib._Exists("Filter Definition", pData.wDG_DerivationDefinition, Config.iTimeout * 3, true);
            mTime.StopTimer(iRF_FL_Males_Open);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Males");
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
            dic.Add("Level_3", "Gender");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=Gender_C=\"M\"");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_FL_Males_Edit);



            pData._FL_Grid("Custom", 53, false);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            _gLib._Exists("Filter Definition", pData.wDG_DerivationDefinition, Config.iTimeout * 3, true);
            mTime.StopTimer(iRF_FL_OverAge55_Open);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "OverAge55");
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
            dic.Add("Level_3", "BirthDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=AND(YEAR(BirthDate_C<=1956), YEAR(BirthDate_C>1946))");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_FL_OverAge55_Edit);



            pData._FL_Grid("Custom", 53, false);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            _gLib._Exists("Filter Definition", pData.wDG_DerivationDefinition, Config.iTimeout * 3, true);
            mTime.StopTimer(iRF_FL_SalariedGroup_Open);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "SalariedGroup");
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
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "DATA1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=DATA1_C=\"SAL\"");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_FL_SalariedGroup_Edit);



            pData._FL_Grid("Custom", 53, false);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            _gLib._Exists("Filter Definition", pData.wDG_DerivationDefinition, Config.iTimeout * 3, true);
            mTime.StopTimer(iRF_FL_ServiceOver35_Open);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "ServiceOver35");
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
            dic.Add("Level_3", "CredServiceDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=YEAR(CredServiceDate_C)<=1976");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_FL_ServiceOver35_Edit);




            mTimeTotal.StopTimer(iRF_FL_Total);
            mLog.LogInfo(iRF_FL_Total, MyPerformanceCounter.Memory_Private);

            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region RF - Derivations - DerrivedGrp, CalcDates

            mTimeTotal.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "DerivedGrp");
            pData._TreeViewSelect(dic);

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
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_DG_DerivedGrp_CalcPreview);


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
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_DG_DerivedGrp_SaveWH);


            mTimeTotal.StopTimer(iRF_DG_DerivedGrp_Total);
            mLog.LogInfo(iRF_DG_DerivedGrp_Total, MyPerformanceCounter.Memory_Private);


            mTimeTotal.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "CalcDates");
            pData._TreeViewSelect(dic);

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
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_DG_CalcDates_CalcPreview);


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
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_DG_CalcDates_SaveWH);


            mTimeTotal.StopTimer(iRF_DG_CalcDates_Total);
            mLog.LogInfo(iRF_DG_CalcDates_Total, MyPerformanceCounter.Memory_Private);



            #endregion


            #region RF - Derivations - AgeCalculations
            mTimeTotal.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "AgeCalculations");
            pData._TreeViewSelect(dic);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "Age");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iRF_DG_AgeCalc_AGELY_UpdateType);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Calculation Date is:");
            dic.Add("sData", "Date Field");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Date Field");
            dic.Add("sData", "EffectiveDate_C");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iRF_DG_AgeCalc_AGELY_Edit);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "Age");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iRF_DG_AgeCalc_AGEGROUP_UpdateType);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Calculation Date is:");
            dic.Add("sData", "Date Field");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Date Field");
            dic.Add("sData", "HireDate1_C");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Is Act");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iRF_DG_AgeCalc_AGEGROUP_Edit);




            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "Age");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iRF_DG_AgeCalc_BAGELY_UpdateType);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Date Of Birth");
            dic.Add("sData", "Beneficiary1BirthDate_C");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Calculation Date is:");
            dic.Add("sData", "Date Field");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Date Field");
            dic.Add("sData", "EffectiveDate_C");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "True");
            dic.Add("CustomExpression_Formula", "=Beneficiary1BirthDate_C<>\"\"");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iRF_DG_AgeCalc_BAGELY_Edit);



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
            dic.Add("iRow", "4");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "AgeAtTermination");
            dic.Add("DerivedField_SearchFromIndex", "4");
            dic.Add("Type", "Age");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iRF_DG_AgeCalc_AgeAtTermation_Add);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Date Of Birth");
            dic.Add("sData", "BirthDate_C");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Calculation Date is:");
            dic.Add("sData", "Date Field");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Date Field");
            dic.Add("sData", "TerminationDate1_C");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "True");
            dic.Add("CustomExpression_Formula", "=TerminationDate1_C<>\"\"");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iRF_DG_AgeCalc_AgeAtTermation_Edit);



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
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_DG_AgeCalc_CalcPreview);


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
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_DG_AgeCalc_SaveWH);


            mTimeTotal.StopTimer(iRF_DG_AgeCalc_Total);
            mLog.LogInfo(iRF_DG_AgeCalc_Total, MyPerformanceCounter.Memory_Private);




            #endregion


            #region RF - Derivations - CreditBalance
            mTimeTotal.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "CreditBalance");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);


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

            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Is Act");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            mTime.StopTimer(iRF_DG_CreditBalance_TotalBalance_Edit);




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
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "ADCFROZ");
            dic.Add("DerivedField_SearchFromIndex", "3");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iRF_DG_CreditBalance_ADCFROZ_Add);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_3", "FROZDV");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "FROZER");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "FrozenBenefitGroup");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=(FROZDV_C+FROZER_C)*1.1");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iRF_DG_CreditBalance_ADCFROZ_Edit);

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

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_DG_CreditBalance_CalcPreview);


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

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_DG_CreditBalance_SaveWH);




            mTimeTotal.StopTimer(iRF_DG_CreditBalance_Total);
            mLog.LogInfo(iRF_DG_CreditBalance_Total, MyPerformanceCounter.Memory_Private);


            #endregion


            #region RF - Derivations - PayAverages
            mTimeTotal.StartTimer();


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "PayAverages");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "BenefitsPayAverages");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);



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
            dic.Add("iRow", "4");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "AverageBest10YearsPay");
            dic.Add("DerivedField_SearchFromIndex", "8");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iRF_DG_PayAverages_AverageBest10YearsPay_Add);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_3", "USC");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "XPAY");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "6");
            dic.Add("sData", "1");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "6");
            dic.Add("sData", "2");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("iCol", "6");
            dic.Add("sData", "3");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("iCol", "6");
            dic.Add("sData", "4");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "7");
            dic.Add("iCol", "6");
            dic.Add("sData", "5");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "8");
            dic.Add("iCol", "6");
            dic.Add("sData", "6");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "9");
            dic.Add("iCol", "6");
            dic.Add("sData", "7");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "10");
            dic.Add("iCol", "6");
            dic.Add("sData", "8");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "11");
            dic.Add("iCol", "6");
            dic.Add("sData", "9");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "12");
            dic.Add("iCol", "6");
            dic.Add("sData", "10");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LARGE(E3:E16,F3)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LARGE(E3:E16,F4)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LARGE(E3:E16,F5)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LARGE(E3:E16,F6)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "7");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LARGE(E3:E16,F7)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "8");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LARGE(E3:E16,F8)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "9");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LARGE(E3:E16,F9)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "10");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LARGE(E3:E16,F10)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "11");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LARGE(E3:E16,F11)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "12");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LARGE(E3:E16,F12)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "5");
            dic.Add("sData", "");
            dic.Add("sFormula", "=ROUND(AVERAGE(G3:G12),2");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Is Act");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iRF_DG_PayAverages_AverageBest10YearsPay_Edit);




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
            dic.Add("iRow", "5");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "AvgBest5YearsW2Pay");
            dic.Add("DerivedField_SearchFromIndex", "10");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iRF_DG_PayAverages_AvgBest5YearsW2Pay_Add);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "5");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_4", "W2PAY");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "6");
            dic.Add("sData", "1");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "6");
            dic.Add("sData", "2");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "6");
            dic.Add("sData", "3");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("iCol", "6");
            dic.Add("sData", "4");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("iCol", "6");
            dic.Add("sData", "5");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);






            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LARGE(E2:E13,F2)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LARGE(E2:E13,F3)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LARGE(E2:E13,F4)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LARGE(E2:E13,F5)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LARGE(E2:E13,F6)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "5");
            dic.Add("sData", "");
            dic.Add("sFormula", "=ROUND(AVERAGE(G2:G6),2)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Is Act");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iRF_DG_PayAverages_AvgBest5YearsW2Pay_Edit);



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
            dic.Add("iRow", "6");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "AvgBest3YearsPensionPay");
            dic.Add("DerivedField_SearchFromIndex", "9");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iRF_DG_PayAverages_AvgBest3YearsPensionPay_Add);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "6");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_4", "NDPAY");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);





            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "6");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LARGE(E2:E11,1)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "6");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LARGE(E2:E11,2)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "6");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LARGE(E2:E11,3)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "5");
            dic.Add("sData", "");
            dic.Add("sFormula", "=ROUND(AVERAGE(F2:F4),2)");
            dic.Add("sRange", "");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Is Act");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iRF_DG_PayAverages_AvgBest3YearsPensionPay_Edit);





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
            dic.Add("iRow", "7");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Benefit1DB");
            dic.Add("DerivedField_SearchFromIndex", "13");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iRF_DG_PayAverages_Benefit1DB_Add);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "7");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_3", "Benefit1DB");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedBenefit1");
            pData._TreeViewSelect_SelectInputFields_PriorView(dic, true, true);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "New Ret");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(Benefit1DB_C=0,AccruedBenefit1_P, Benefit1DB_C)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iRF_DG_PayAverages_Benefit1DB_Edit);





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
            dic.Add("iRow", "8");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "IndexedPension");
            dic.Add("DerivedField_SearchFromIndex", "2");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iRF_DG_PayAverages_IndexedPension_Add);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "8");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_3", "Benefit1DB");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit1DB");
            pData._TreeViewSelect_SelectInputFields_PriorView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Is Ret Bene");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Is Ret");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Is Ret Part");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=MAX(Benefit1DB_P*1.03,Benefit1DB_C)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iRF_DG_PayAverages_IndexedPension_Edit);





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
            dic.Add("iRow", "9");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "BridgeAmount");
            dic.Add("DerivedField_SearchFromIndex", "16");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iRF_DG_PayAverages_BridgeAmount_Add);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "9");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_3", "USC");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "BridgeAmount");
            pData._TreeViewSelect_SelectInputFields_PriorView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "OverAge55");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Is Ret");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(USC_C=\"Ret\", MAX(BridgeAmount_C,12000),0)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iRF_DG_PayAverages_BridgeAmount_Edit);






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
            dic.Add("iRow", "10");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "LumpSumTermBenefit1");
            dic.Add("DerivedField_SearchFromIndex", "8");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iRF_DG_PayAverages_LumpSumTermBenefit1_Add);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "10");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_3", "TerminationDate1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "XPAY");
            dic.Add("Level_5", "XPAYCurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "XPAY");
            dic.Add("Level_5", "XPAYPriorYear1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedBenefit1");
            pData._TreeViewSelect_SelectInputFields_PriorView(dic, true, true);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(YEAR(TerminationDate1_C)=EffectiveDate-1,MAX(XPAYCurrentYear_C,XPAYPriorYear1_C,AccruedBenefit1_P),0)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iRF_DG_PayAverages_LumpSumTermBenefit1_Edit);



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

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_DG_PayAverages_CalcPreview);


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

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_DG_PayAverages_SaveWH);



            mTimeTotal.StopTimer(iRF_DG_PayAverages_Total);
            mLog.LogInfo(iRF_DG_PayAverages_Total, MyPerformanceCounter.Memory_Private);
            #endregion


            #region RF - Derivation Groups - Others
            mTimeTotal.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "Other");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


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
            dic.Add("DerivedField", "ESTPBEN");
            dic.Add("DerivedField_SearchFromIndex", "23");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iRF_DG_Others_ESTPBEN_Add);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_3", "EST11");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "ESTPBENLY");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(EST11_C+ESTPBENLY_C>0,1,2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iRF_DG_Others_ESTPBEN_Edit);


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
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "BOGHEAL");
            dic.Add("DerivedField_SearchFromIndex", "15");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iRF_DG_Others_BOGHEAL_Add);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_3", "HealthStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(HealthStatus_C=\"H\",\"H\",\"\"");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iRF_DG_Others_BOGHEAL_Edit);



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
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "PHHPRJ");
            dic.Add("DerivedField_SearchFromIndex", "12");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            mTime.StopTimer(iRF_DG_Others_PHHPRJ_Add);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
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
            dic.Add("Level_3", "PHHPRJ");
            pData._TreeViewSelect_SelectInputFields_PriorView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=PHHPRJ_P*1.05");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iRF_DG_Others_PHHPRJ_Edit);

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

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_DG_Others_CalcPreview);


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

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_DG_Others_SaveWH);


            mTimeTotal.StopTimer(iRF_DG_Others_Total);
            mLog.LogInfo(iRF_DG_Others_Total, MyPerformanceCounter.Memory_Private);
            #endregion


            #region RF - Checks
            mTimeTotal.StartTimer();


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Checks");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("CheckName", "Custom Checks");
            dic.Add("iSearchDownNum", "57");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "Click");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "LIMBENChangeInvalid");
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
            dic.Add("Level_3", "LIMBEN");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "LIMBEN");
            pData._TreeViewSelect_SelectInputFields_PriorView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=LIMBEN_C>(LIMBEN_P*1.05)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iRF_CK_LIMBENChangeInvalid);



            pData._CK_CheckGrip_SendKeys("{Home}{Up}{Up}");


            dic.Clear();
            dic.Add("CheckName", "Custom Checks");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);



            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "Click");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "TransAmountChange");
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
            dic.Add("Level_3", "TRNBEN");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "TRNBEN");
            pData._TreeViewSelect_SelectInputFields_PriorView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=TRNBEN_C<>TRNBEN_P");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            mTime.StopTimer(iRF_CK_TransAmountChange);



            dic.Clear();
            dic.Add("CheckName", "All");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, false, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "Click");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NewGroupName", "FrozenMembers");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_Checks_AddCustomGroup(dic);


            dic.Clear();
            dic.Add("CheckName", "FrozenMembers");
            dic.Add("iSearchDownNum", "58");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);

            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "Click");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "FrozenBenefitChange");
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
            dic.Add("Level_3", "FROZDV");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "FROZDV");
            pData._TreeViewSelect_SelectInputFields_PriorView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "FROZER");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "FROZER");
            pData._TreeViewSelect_SelectInputFields_PriorView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=OR(FROZDV_C<>FROZDV_P,FROZER_C<>FROZER_P)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            mTime.StopTimer(iRF_CK_ForzenBemefitChange);


            pData._CK_CheckGrip_SendKeys("{Home}");


            dic.Clear();
            dic.Add("CheckName", "FrozenMembers");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "Click");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "FrozenServiceChange");
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
            dic.Add("Level_3", "ADCFROZ");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "CredServiceDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "CredServiceDate");
            pData._TreeViewSelect_SelectInputFields_PriorView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "VestServiceDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "VestServiceDate");
            pData._TreeViewSelect_SelectInputFields_PriorView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=AND(ADCFROZ_C>0,OR(CredServiceDate_C<>CredServiceDate_P,VestServiceDate_C<>VestServiceDate_P))");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            mTime.StopTimer(iRF_CK_ForzenServiceChange);



            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "Click");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Pay_C", "XPAYPriorYear1_C");
            dic.Add("Pay_P", "XPAYPriorYear1_P");
            dic.Add("AccruedBenefit_C", "");
            dic.Add("AccruedBenefit_P", "");
            dic.Add("CashBalanceBenefit_C", "CBAL_C");
            dic.Add("CashBalanceBenefit_P", "CBAL_P");
            dic.Add("BenefitService_C", "");
            dic.Add("BenefitService_P", "");
            dic.Add("VestingService_C", "");
            dic.Add("VestingService_P", "");
            dic.Add("Hours_C", "");
            dic.Add("Hours_P", "");
            dic.Add("InactiveBenefit_C", "");
            dic.Add("InactiveBenefit_P", "");
            dic.Add("StartDate_C", "");
            dic.Add("StartDate_P", "");
            dic.Add("HireDate_C", "");
            dic.Add("HireDate_P", "");
            dic.Add("MembershipDate_C", "");
            dic.Add("MembershipDate_P", "");
            dic.Add("TerminationDate_C", "");
            dic.Add("PaymentForm_C", "");
            dic.Add("PaymentForm_P", "");
            dic.Add("YearsCertain_C", "");
            dic.Add("YearsCertain_P", "");
            dic.Add("BeneficiaryPercent_C", "");
            dic.Add("BeneficiaryPercent_P", "");
            dic.Add("OK", "");
            pData._PopVerify_CK_StandardInputs_Part1(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayChange_Min", "3");
            dic.Add("PayChange_Max", "5");
            dic.Add("PayRange_Min", "25,000");
            dic.Add("PayRange_Max", "3,000,000");
            dic.Add("AccruedBenefitChange_Min", "0");
            dic.Add("AccruedBenefitChange_Max", "5");
            dic.Add("AccruedBenefitRange_Min", "0");
            dic.Add("AccruedBenefitRange_Max", "150,000");
            dic.Add("InactiveBenefitChange_Min", "0");
            dic.Add("InactiveBenefitChange_Max", "5");
            dic.Add("InactiveBenefitRange_Min", "0");
            dic.Add("InactiveBenefitRange_Max", "100,000");
            dic.Add("CashBalanceChange_Act_Min", "0");
            dic.Add("CashBalanceChange_Act_Max", "5");
            dic.Add("CashBalanceChange_InAct_Min", "0");
            dic.Add("CashBalanceChange_InAct_Max", "5");
            dic.Add("CashBalanceRange_Min", "0");
            dic.Add("CashBalanceRange_Max", "50,000");
            dic.Add("HoursRange_Min", "0");
            dic.Add("HoursRange_Max", "2,500");
            dic.Add("BenefitServiceRange_Min", "0");
            dic.Add("BenefitServiceRange_Max", "1");
            dic.Add("VestingServiceRange_Min", "0");
            dic.Add("VestingServiceRange_Max", "1");
            dic.Add("BenefitServiceForNewAct_Max", "1");
            dic.Add("VestServiceForNewAct_Max", "1");
            dic.Add("AgeForNewAct_Min", "18");
            dic.Add("AgeForNewAct_Max", "65");
            dic.Add("AgeForNewRetirees_Min", "50");
            dic.Add("YearsRequiredForVesting", "1");
            dic.Add("BirthDate_Threshold", "");
            dic.Add("HireDate_Threshold", "");
            dic.Add("MembershipDate_Threshold", "");
            dic.Add("StartDate_Threshold", "");
            dic.Add("OK", "Click");
            pData._PopVerify_CK_StandardInputs_Part2(dic);


            mTime.StopTimer(iRF_CK_EditStandardInputs);



            dic.Clear();
            dic.Add("CheckName", "All");
            dic.Add("Include", "True");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, false, false);


            dic.Clear();
            dic.Add("CheckName", "All");
            dic.Add("Include", "True");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);


            dic.Clear();
            dic.Add("CheckName", "All");
            dic.Add("Include", "True");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, true);


            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("Data2012");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "Click");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);


            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_CK_ApplyChecks);


            mTimeTotal.StopTimer(iRF_CK_Total);
            mLog.LogInfo(iRF_CK_Total, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("CheckName", "Invalid or no pay");
            dic.Add("iSearchDownNum", "11");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, false, false);



            _gLib._MsgBox("Earnings and Accrued Benefit Checks => Invalid or no pay", "Please Click failed Number <426> in this Check and click OK to keep testing!");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            dic.Add("AllQuery", "True");
            dic.Add("AllPlug", "");
            dic.Add("AllOK", "");
            dic.Add("Notes", "");
            pData._PopVerify_Checks(dic);



            dic.Clear();
            dic.Add("CheckName", "Accrued benefit change");
            dic.Add("iSearchDownNum", "3");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);


            _gLib._MsgBox("Earnings and Accrued Benefit Checks => Accrued benefit change", "Please Click failed Number <1504> in this Check and click OK to keep testing!");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            dic.Add("AllQuery", "");
            dic.Add("AllPlug", "");
            dic.Add("AllOK", "True");
            dic.Add("Notes", "");
            pData._PopVerify_Checks(dic);




            dic.Clear();
            dic.Add("CheckName", "Invalid or no pension amount, new inactive");
            dic.Add("iSearchDownNum", "11");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);



            _gLib._MsgBox("New Inactive Checks => Invalid or no pension amount, new inactive", "Please Click failed Number <64> in this Check and click OK to keep testing!");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            dic.Add("AllQuery", "True");
            dic.Add("AllPlug", "");
            dic.Add("AllOK", "");
            dic.Add("Notes", "");
            pData._PopVerify_Checks(dic);






            dic.Clear();
            dic.Add("CheckName", "Invalid or no retirement date, in pay inactive");
            dic.Add("iSearchDownNum", "1");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);



            _gLib._MsgBox("New Inactive Checks => Invalid or no retirement date, in pay inactive", "Please Click failed Number <40> in this Check and click OK to keep testing!");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            dic.Add("AllQuery", "True");
            dic.Add("AllPlug", "");
            dic.Add("AllOK", "");
            dic.Add("Notes", "");
            pData._PopVerify_Checks(dic);






            dic.Clear();
            dic.Add("CheckName", "No form of payment, new inactive");
            dic.Add("iSearchDownNum", "4");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);



            _gLib._MsgBox("New Inactive Checks => No form of payment, new inactive", "Please Click failed Number <7> in this Check and click OK to keep testing!");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            dic.Add("AllQuery", "");
            dic.Add("AllPlug", "True");
            dic.Add("AllOK", "");
            dic.Add("Notes", "");
            pData._PopVerify_Checks(dic);





            dic.Clear();
            dic.Add("CheckName", "Invalid or no Hire Date");
            dic.Add("iSearchDownNum", "2");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);



            _gLib._MsgBox("Service Checks => Invalid or no Hire Date", "Please Click failed Number <28> in this Check and click OK to keep testing!");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            dic.Add("AllQuery", "");
            dic.Add("AllPlug", "True");
            dic.Add("AllOK", "");
            dic.Add("Notes", "");
            pData._PopVerify_Checks(dic);



            #endregion


            #region RF - View & Update
            mTimeTotal.StartTimer();


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "View & Update");
            dic.Add("Level_3", "{NewView1}");
            pData._TreeViewSelect(dic);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Filter", "");
            dic.Add("Apply", "Click");
            pData._PopVerify_ViewUpdate(dic);

            pMain._SelectTab("Data2012");

            mTime.StopTimer(iRF_VU_NewViewUpdate1_Apply);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "View & Update");
            dic.Add("MenuItem", "Add new view");
            pData._TreeViewRightSelect(dic);

            _gLib._Exists("View & Update", pData.wRetirementStudio.wVU_Apply, Config.iTimeout * 3);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "ActiveBenefits");
            dic.Add("Filter", "Is Act");
            dic.Add("Apply", "");
            pData._PopVerify_ViewUpdate(dic);

            mTime.StopTimer(iRF_VU_ActiveBenefits_Add);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("Filter", "");
            dic.Add("Apply", "Click");
            pData._PopVerify_ViewUpdate(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_VU_ActiveBenefits_Apply);






            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "View & Update");
            dic.Add("MenuItem", "Add new view");
            pData._TreeViewRightSelect(dic);

            _gLib._Exists("View & Update", pData.wRetirementStudio.wVU_Apply, Config.iTimeout * 3);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "InactiveBenefits");
            dic.Add("Filter", "Is Inact");
            dic.Add("Apply", "");
            pData._PopVerify_ViewUpdate(dic);

            mTime.StopTimer(iRF_VU_InactiveBenefits_Add);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("Filter", "");
            dic.Add("Apply", "Click");
            pData._PopVerify_ViewUpdate(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_VU_InactiveBenefits_Apply);




            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "View & Update");
            dic.Add("MenuItem", "Add new view");
            pData._TreeViewRightSelect(dic);

            _gLib._Exists("View & Update", pData.wRetirementStudio.wVU_Apply, Config.iTimeout * 3);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "ActivePayAvgs");
            dic.Add("SelectLabelsToView", "Click");
            dic.Add("Filter", "");
            dic.Add("Apply", "");
            pData._PopVerify_ViewUpdate(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "NDPAY");
            dic.Add("Level_5", "NDPAYCurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "W2PAY");
            dic.Add("Level_5", "W2PAYCurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "XPAY");
            dic.Add("Level_5", "XPAYCurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Custom Fields");
            dic.Add("Level_3", "NDTPayAverage3");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Custom Fields");
            dic.Add("Level_3", "PayAverage5");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Custom Fields");
            dic.Add("Level_3", "TotalBalance");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Custom Fields");
            dic.Add("Level_3", "W2PayAverage2Years");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);




            mTime.StopTimer(iRF_VU_ActivePayAvgs_Add);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("Filter", "");
            dic.Add("Apply", "Click");
            pData._PopVerify_ViewUpdate(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_VU_ActivePayAvgs_Apply);


            mTimeTotal.StopTimer(iRF_VU_Total);
            mLog.LogInfo(iRF_VU_Total, MyPerformanceCounter.Memory_Private);








            #endregion


            #region RF - Reports

            mTimeTotal.StartTimer();


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Reports");
            dic.Add("Level_3", "ChecksReport");
            pData._TreeViewSelect(dic);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "");
            dic.Add("StatusMatrix", "");
            dic.Add("StatusMatrix_Filter", "");
            dic.Add("ReportName", "");
            dic.Add("GenerateReport", "Click");
            pData._PopVerify_Reports(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_RP_ReportGenerated_Popup(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_RP_CheckReport_Checks_Generate);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Reports");
            dic.Add("MenuItem", "Add new report");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "Query");
            dic.Add("StatusMatrix", "");
            dic.Add("StatusMatrix_Filter", "");
            dic.Add("ReportName", "Queries");
            dic.Add("GenerateReport", "");
            pData._PopVerify_Reports(dic);

            mTime.StopTimer(iRF_RP_CheckReport_Query_Add);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "");
            dic.Add("StatusMatrix", "");
            dic.Add("StatusMatrix_Filter", "");
            dic.Add("ReportName", "");
            dic.Add("GenerateReport", "Click");
            pData._PopVerify_Reports(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_RP_ReportGenerated_Popup(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_RP_CheckReport_Query_Generate);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Reports");
            dic.Add("MenuItem", "Add new report");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "");
            dic.Add("StatusMatrix", "True");
            dic.Add("StatusMatrix_Filter", "All");
            dic.Add("ReportName", "MembersStatus");
            dic.Add("GenerateReport", "");
            pData._PopVerify_Reports(dic);

            mTime.StopTimer(iRF_RP_MembersStatus_Add);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "");
            dic.Add("StatusMatrix", "");
            dic.Add("StatusMatrix_Filter", "");
            dic.Add("ReportName", "");
            dic.Add("GenerateReport", "Click");
            pData._PopVerify_Reports(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_RP_ReportGenerated_Popup(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_RP_MembersStatus_Generate);


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Status Matrix");
            pData._TreeViewSelect(dic);

            pMain._SelectTab("Data2012");
            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CreateMatrix", "Click");
            pData._PopVerify_StatusMatrix(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_RP_StatusMatrix_Generate);


            mTimeTotal.StopTimer(iRF_RP_Total);
            mLog.LogInfo(iRF_RP_Total, MyPerformanceCounter.Memory_Private);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Data2012");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Output Manager");
            pData._TreeViewSelect(dic);

            pData._OM_ExportReport_SubReports(sOutputDir, "Reports Summary", "Data2012_Query", 130, 2, false);

            pMain._SelectTab("Data2012");


            _gLib._KillProcessByName("EXCEL");
            MyExcel _excelRead = new MyExcel(sQuery_ReadFile, true);
            MyExcel _excelWrite = new MyExcel(sQueryWriteFile, true);
            _excelRead.OpenExcelFile("Earnings and Accrued Benefit Ch");
            _excelWrite.OpenExcelFile("Earnings and Accrued Benefit Ch");


            for (int i = 9; i <= 434; i++)
                _excelWrite.setOneCellValue(i, 7, _excelRead.getOneCellValue(i, 7));

            _excelRead.CloseExcelApplication();
            _excelWrite.SaveExcel();
            _excelWrite.CloseExcelApplication();

            _excelRead.OpenExcelFile("New Inactive Checks");
            _excelWrite.OpenExcelFile("New Inactive Checks");

            for (int i = 9; i <= 65; i++)
                _excelWrite.setOneCellValue(i, 7, _excelRead.getOneCellValue(i, 7));

            for (int i = 72; i <= 124; i++)
                _excelWrite.setOneCellValue(i + 7, 7, _excelRead.getOneCellValue(i, 7));


            _excelRead.CloseExcelApplication();
            _excelWrite.SaveExcel();
            _excelWrite.CloseExcelApplication();


            #endregion


            #region RF - Simple Import, Checks, Snapshots, Consume
            mTimeTotal.StartTimer();


            mTime.StartTimer();


            dic.Clear();
            dic.Add("Level_1", "Data2012");
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

            _gLib._Exists("File Open", pMain.wFileOpen, 0, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", sQueryWriteFile);
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

            pMain._SelectTab("Data2012");

            mTime.StopTimer(iRF_SI_UploadFile);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Simple Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Query");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            mTime.StopTimer(iRF_SI_AddSimpleImport);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "Data2012_Query.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_SI_FileSelection);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            dic.Add("Process", "");
            pData._PopVerify_SimpleImport(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_SI_Preview);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "");
            dic.Add("Process", "Click");
            pData._PopVerify_SimpleImport(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_SI_Process);


            mTimeTotal.StopTimer(iRF_SI_Total);
            mLog.LogInfo(iRF_SI_Total, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Checks");
            pData._TreeViewSelect(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Data2012");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "Click");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_CK_Warning_Popup(dic);


            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_CK_ReApply);



            mTimeTotal.StartTimer();



            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "ImportData");
            pData._TreeViewSelect(dic);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "Click");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_SS_Preview);


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

            pMain._SelectTab("Data2012");
            mTime.StopTimer(iRF_SS_Publish);




            mTimeTotal.StopTimer(iRF_SS_Total);
            mLog.LogInfo(iRF_SS_Total, MyPerformanceCounter.Memory_Private);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



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
            dic.Add("Name", "ValService2012");
            dic.Add("Parent", "ValService2011");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "2012");
            dic.Add("FirstYearPlanUnderPPA", "2012");
            dic.Add("RSC", "");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "ValService2012");
            pMain._PopVerify_Home_RightPane(dic);



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "");
            dic.Add("No", "");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_Home_Confrim(dic);


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


            pMain._SelectTab("ValService2012");

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
            dic.Add("DataEffectiveDate", "01/01/2012");
            dic.Add("Snapshot", "True");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);



            mTimeTotal.StartTimer();


            mTime.StartTimer();

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
            dic.Add("SnapshotName", "ImportData");
            dic.Add("OK", "");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);

            mTime.StopTimer(iRF_Consume_Open);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "True");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "Click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);

            pMain._SelectTab("Participant DataSet");
            mTime.StopTimer(iRF_Consume_Select);


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
            mTime.StopTimer(iRF_Consume_Import);


            mTimeTotal.StopTimer(iRF_Consume_Total);
            mLog.LogInfo(iRF_Consume_Total, MyPerformanceCounter.Memory_Private);

            pMain._SelectTab("ValService2012");

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
            mLog.LogInfo(iTest, MyPerformanceCounter.Memory_Private);
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
