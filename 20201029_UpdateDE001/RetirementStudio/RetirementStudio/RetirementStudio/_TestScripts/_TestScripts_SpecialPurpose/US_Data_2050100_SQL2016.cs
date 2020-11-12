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


namespace RetirementStudio._TestScripts._TestScripts_SpecialPurpose
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class US_Data_2050100_SQL2016
    {
        public US_Data_2050100_SQL2016()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            //Config.sClientName = "QA Data Performance Test 001"; //   20K -   CA DR - Cindy
            //Config.sPlanName = "QA Data Performance Test 001";   //   20K -   CA DR - Cindy
            //Config.sClientName = "QA Data Performance Test 002"; //   50K -   CA DR - Cindy
            //Config.sPlanName = "QA Data Performance Test 002";   //   50K -   CA DR - Cindy

            //Config.sClientName = "QA Data Performance 20K 20140627_B"; //   20K -   EU Prod SQL2016
            //Config.sClientName = "QA Data Performance 20K 20140708_B"; //   50K -   EU Prod SQL2016


            Config.sClientName = "WB_Data_20K_201705"; //   20K -   CA PreProd
            //Config.sClientName = "WB_Data_50K_201705"; //   50K -   CA PreProd
            //Config.sClientName = "WB_Data_100K_201705"; //  100K -  CA PreProd
            //Config.sClientName = "WB_Data_20K_201706_E"; //   20K -   EU Prod
            //Config.sClientName = "WB_Data_50K_201706_E"; //   50K -   EU Prod
            //Config.sClientName = "WB_Data_100K_201706_E"; //  100K -  EU Prod
            Config.sPlanName = "US Plan";
            //Config.sDataCenter = "Exeter";
            //Config.sDataCenter = "Franklin";
            //Config.sDataCenter = "Dallas";
            //Config.bDownloadReports_PDF = true;
            //Config.bDownloadReports_EXCEL = false;
            //Config.bCompareReports = false;

            //Config.sClientName = "QA Data Performance 20K 20160901";  //// cindy CA prod 2016 client
            //Config.sPlanName = "US Plan";//// cindy CA prod 2016 client

            //Config.sClientName = "QA Data Performance 20K 20150202";  //// cindy CA prod 2008 client
            //Config.sPlanName = "US Plan";//// cindy CA prod 2008 client


        }


        static string sData_2012 = "Data2012_1";
        ////////static string sData_2012 = "Data2012_1";//// cindy CA prod 2016 client

        static string sEENum = "20K";
        //static string sEENum = "50K";
        //static string sEENum = "100K";

        static string sCol_Time = "Time_1";
        static string sCol_Time_2 = "Time_2";
        static string sCol_Memory = "Memory";
        static string sLogFile = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Data_2050100\Results_UpdatedVersion_CUIT_Phase2_SQL2016_WB.xls";
        static string sOutputDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\US_Timing_Data_2050100\TestOutput_SQL2016_WB\";



        #region Timing







        static string sDataFile_Conversion_20K = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\Data_PerformanceTest\DataPerformanceData_Conversion.xls";
        static string sDataFile_Rollforward_20K = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\Data_PerformanceTest\DataPerformanceData_RF.xls";
        static string sDataFile_Conversion_FileName_20K = "DataPerformanceData_Conversion.xls";
        static string sDataFile_Rollforward_FileName_20K = "DataPerformanceData_RF.xls";

        static string sDataFile_Conversion_50K = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\Data_PerformanceTest\RSD_UNLD_Spread_50_1.xls";
        static string sDataFile_Rollforward_50K = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\Data_PerformanceTest\RSD_UNLD_Spread_50_1RF.xls";
        static string sDataFile_Conversion_FileName_50K = "RSD_UNLD_Spread_50_1.xls";
        static string sDataFile_Rollforward_FileName_50K = "RSD_UNLD_Spread_50_1RF.xls";

        static string sDataFile_Conversion_100K = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\Data_PerformanceTest\RSD_UNLD_Spread_100.xlsx";
        static string sDataFile_Rollforward_100K = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\Data_PerformanceTest\RSD_UNLD_Spread_100_RF.xlsx";
        static string sDataFile_Conversion_FileName_100K = "RSD_UNLD_Spread_100.xlsx";
        static string sDataFile_Rollforward_FileName_100K = "RSD_UNLD_Spread_100_RF.xlsx";

        static string sDataFile_Conversion = "";
        static string sDataFile_Rollforward = "";
        static string sDataFile_Conversion_FileName = "";
        static string sDataFile_Rollforward_FileName = "";


        static string sCurrentViewFile_Conversion_20K = @"\\mercer.com\US_Data\Shared\DFL\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\Data_PerformanceTest\SMALL_YUMFieldNames.xls";
        static string sCurrentViewFile_RF = @"\\mercer.com\US_Data\Shared\DFL\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\Data_PerformanceTest\YUMFieldNames_RF.xls";
        static string sCurrentViewFile_Conversion_50100K = @"\\mercer.com\US_Data\Shared\DFL\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\Data_PerformanceTest\YUMFieldNames.xls";
        static string sCurrentViewFile_Conversion = "";


        static string sQuery_ReadFile = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\Data_PerformanceTest\SimpleImportForQueries v2.xls";
        //static string sQuery_ReadFile = @"C:\Users\webber-ling\Desktop\SQL_Testing\SimpleImportForQueries v2.xls";
        static string sQueryWriteFile = sOutputDir + "Data2012_Query.xls";



        static int iConversion_UniqueMatchNum_20K = 20000;
        static int iRF_UniqueMatchNum_20K = 19212;
        static int iRF_NoMatchNum_20K = 1035;
        static int iRF_WarehouseNoMatchNum_20K = 788;

        static int iConversion_UniqueMatchNum_50K = 49999;
        static int iRF_UniqueMatchNum_50K = 45825;
        static int iRF_NoMatchNum_50K = 1068;
        static int iRF_WarehouseNoMatchNum_50K = 4174;

        static int iConversion_UniqueMatchNum_100K = 99998;
        static int iRF_UniqueMatchNum_100K = 87848;
        static int iRF_NoMatchNum_100K = 5663;
        static int iRF_WarehouseNoMatchNum_100K = 12150;

        static int iConversion_UniqueMatchNum = 0;
        static int iRF_UniqueMatchNum = 0;
        static int iRF_NoMatchNum = 0;
        static int iRF_WarehouseNoMatchNum = 0;

        MyTimer mTime = new MyTimer(sCol_Time, sLogFile);
        MyTimer mTime_2 = new MyTimer(sCol_Time_2, sLogFile);
        MyTimer mTimeTotal = new MyTimer(sCol_Time, sLogFile);
        MyLog mLog = new MyLog(sCol_Memory, sLogFile);

        MyDictionary dicPosition = new MyDictionary();

        public void SetVariablesEENum()
        {
            if (sEENum.Equals("20K"))
            {
                sDataFile_Conversion = sDataFile_Conversion_20K;
                sDataFile_Rollforward = sDataFile_Rollforward_20K;
                sDataFile_Conversion_FileName = sDataFile_Conversion_FileName_20K;
                sDataFile_Rollforward_FileName = sDataFile_Rollforward_FileName_20K;

                sCurrentViewFile_Conversion = sCurrentViewFile_Conversion_20K;

                iConversion_UniqueMatchNum = iConversion_UniqueMatchNum_20K;
                iRF_UniqueMatchNum = iRF_UniqueMatchNum_20K;
                iRF_NoMatchNum = iRF_NoMatchNum_20K;
                iRF_WarehouseNoMatchNum = iRF_WarehouseNoMatchNum_20K;



            }
            else if (sEENum.Equals("50K"))
            {
                sDataFile_Conversion = sDataFile_Conversion_50K;
                sDataFile_Rollforward = sDataFile_Rollforward_50K;
                sDataFile_Conversion_FileName = sDataFile_Conversion_FileName_50K;
                sDataFile_Rollforward_FileName = sDataFile_Rollforward_FileName_50K;

                sCurrentViewFile_Conversion = sCurrentViewFile_Conversion_50100K;

                iConversion_UniqueMatchNum = iConversion_UniqueMatchNum_50K;
                iRF_UniqueMatchNum = iRF_UniqueMatchNum_50K;
                iRF_NoMatchNum = iRF_NoMatchNum_50K;
                iRF_WarehouseNoMatchNum = iRF_WarehouseNoMatchNum_50K;

            }
            else if (sEENum.Equals("100K"))
            {
                sDataFile_Conversion = sDataFile_Conversion_100K;
                sDataFile_Rollforward = sDataFile_Rollforward_100K;
                sDataFile_Conversion_FileName = sDataFile_Conversion_FileName_100K;
                sDataFile_Rollforward_FileName = sDataFile_Rollforward_FileName_100K;

                sCurrentViewFile_Conversion = sCurrentViewFile_Conversion_50100K;

                iConversion_UniqueMatchNum = iConversion_UniqueMatchNum_100K;
                iRF_UniqueMatchNum = iRF_UniqueMatchNum_100K;
                iRF_NoMatchNum = iRF_NoMatchNum_100K;
                iRF_WarehouseNoMatchNum = iRF_WarehouseNoMatchNum_100K;
            }
            else
            {
                _gLib._MsgBoxYesNo("Warning", "Incorrect sEENum, please verify, only 20K, 50K and 100K are valid input!");
            }


        }


        #region Result Index

        static int iNumOfEE = 300;
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

        static int iRF_CV_Preview = iRF_IM_MC_Total + 1;
        static int iRF_FL_FrozenBenefitGroup_Open = iRF_CV_Preview + 1;
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


        static int iRF_DG_RunBatch = iRF_FL_Total + 1;
        static int iRF_DG_Undo = iRF_DG_RunBatch + 1;
        static int iRF_DG_DerivedGrp_CalcPreview = iRF_DG_Undo + 1;
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
        static int iRF_DG_PayAverages_PrintAll = iRF_DG_PayAverages_Total + 1;


        static int iRF_DG_Others_ESTPBEN_Add = iRF_DG_PayAverages_PrintAll + 1;
        static int iRF_DG_Others_ESTPBEN_Edit = iRF_DG_Others_ESTPBEN_Add + 1;
        static int iRF_DG_Others_BOGHEAL_Add = iRF_DG_Others_ESTPBEN_Edit + 1;
        static int iRF_DG_Others_BOGHEAL_Edit = iRF_DG_Others_BOGHEAL_Add + 1;
        static int iRF_DG_Others_PHHPRJ_Add = iRF_DG_Others_BOGHEAL_Edit + 1;
        static int iRF_DG_Others_PHHPRJ_Edit = iRF_DG_Others_PHHPRJ_Add + 1;
        static int iRF_DG_Others_CalcPreview = iRF_DG_Others_PHHPRJ_Edit + 1;
        static int iRF_DG_Others_SaveWH = iRF_DG_Others_CalcPreview + 1;
        static int iRF_DG_Others_Total = iRF_DG_Others_SaveWH + 1;
        static int iRF_BatchUpdate_SaveToWarehouse = iRF_DG_Others_Total + 1;

        static int iRF_CK_LIMBENChangeInvalid = iRF_BatchUpdate_SaveToWarehouse + 1;
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
        static int iRF_VU_ActivePayAvgs_CustomFilter_Apply = iRF_VU_ActivePayAvgs_Apply + 1;
        static int iRF_VU_ActivePayAvgs_CustomFilter_PrintAll = iRF_VU_ActivePayAvgs_CustomFilter_Apply + 1;
        static int iRF_VU_Total = iRF_VU_ActivePayAvgs_CustomFilter_PrintAll + 1;

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
        static int iRF_SS_Extract = iRF_SS_Publish + 1;
        static int iRF_SS_Undo = iRF_SS_Extract + 1;
        static int iRF_SS_Republish = iRF_SS_Undo + 1;
        static int iRF_SS_Total = iRF_SS_Republish + 1;
        static int iRF_OM_ExportAll = iRF_SS_Total + 1;



        static int iRF_Undo_ReopenDataService = iRF_OM_ExportAll + 20 + 1;
        static int iRF_Undo_Undo = iRF_Undo_ReopenDataService + 1;
        static int iRF_Undo_ValidateAndLoad = iRF_Undo_Undo + 1;
        static int iRF_Undo_PMD_CalculateAndPreview = iRF_Undo_ValidateAndLoad + 1;
        static int iRF_Undo_PMD_SaveToStagingArea = iRF_Undo_PMD_CalculateAndPreview + 1;

        static int iRF_Undo_ManualMatch_Open = iRF_Undo_PMD_SaveToStagingArea + 1;
        static int iRF_Undo_ManualMatch_Close = iRF_Undo_ManualMatch_Open + 1;
        static int iRF_Undo_FindMatch = iRF_Undo_ManualMatch_Close + 1;
        static int iRF_Undo_AcceptNew = iRF_Undo_FindMatch + 1;
        static int iRF_Undo_AcceptMatch = iRF_Undo_AcceptNew + 1;
        static int iRF_Undo_AcceptNoMatch = iRF_Undo_AcceptMatch + 1;
        static int iRF_Undo_SaveWH = iRF_Undo_AcceptNoMatch + 1;

        static int iRF_Undo_CV_Preview = iRF_Undo_SaveWH + 1;
        static int iRF_Undo_RunDerivationsInBatch = iRF_Undo_CV_Preview + 1;
        static int iRF_Undo_UndoDerivations = iRF_Undo_RunDerivationsInBatch + 1;
        static int iRF_Undo_DerivedGrp_CalculateAndPreview = iRF_Undo_UndoDerivations + 1;
        static int iRF_Undo_DerivedGrp_SaveToWarehouse = iRF_Undo_DerivedGrp_CalculateAndPreview + 1;
        static int iRF_Undo_CalcDates_CalculateAndPreview = iRF_Undo_DerivedGrp_SaveToWarehouse + 1;
        static int iRF_Undo_CalcDates_SaveToWarehouse = iRF_Undo_CalcDates_CalculateAndPreview + 1;
        static int iRF_Undo_AgeVCalculations_CalculateAndPreview = iRF_Undo_CalcDates_SaveToWarehouse + 1;
        static int iRF_Undo_AgeCalculations_SaveToWarehouse = iRF_Undo_AgeVCalculations_CalculateAndPreview + 1;
        static int iRF_Undo_CreditBalance_CalculateAndPreview = iRF_Undo_AgeCalculations_SaveToWarehouse + 1;
        static int iRF_Undo_CreditBalance_SaveToWarehouse = iRF_Undo_CreditBalance_CalculateAndPreview + 1;
        static int iRF_Undo_PayAverages_CalculateAndPreview = iRF_Undo_CreditBalance_SaveToWarehouse + 1;
        static int iRF_Undo_PayAverages_SaveToWarehouse = iRF_Undo_PayAverages_CalculateAndPreview + 1;
        static int iRF_Undo_PayAverages_PrintAll = iRF_Undo_PayAverages_SaveToWarehouse + 1;
        static int iRF_Undo_Other_CalculateAndPreview = iRF_Undo_PayAverages_PrintAll + 1;
        static int iRF_Undo_Other_SaveToWarehouse = iRF_Undo_Other_CalculateAndPreview + 1;

        static int iRF_Undo_BatchUpdate_SaveToWarehouse = iRF_Undo_Other_SaveToWarehouse + 1;
        static int iRF_Undo_ApplyChecks = iRF_Undo_BatchUpdate_SaveToWarehouse + 1;
        static int iRF_Undo_Newview1_Apply = iRF_Undo_ApplyChecks + 1;
        static int iRF_Undo_ActiveBenefits_Apply = iRF_Undo_Newview1_Apply + 1;
        static int iRF_Undo_InactiveBenefits_Apply = iRF_Undo_ActiveBenefits_Apply + 1;
        static int iRF_Undo_ActivePayAvgs_CustomFilter_Apply = iRF_Undo_InactiveBenefits_Apply + 1;
        static int iRF_Undo_ActivePayAvgs_PrintAll = iRF_Undo_ActivePayAvgs_CustomFilter_Apply + 1;
        static int iRF_Undo_GenerateCheckReport_AllChecks = iRF_Undo_ActivePayAvgs_PrintAll + 1;
        static int iRF_Undo_GenerateCheckReport_Queries = iRF_Undo_GenerateCheckReport_AllChecks + 1;
        static int iRF_Undo_GenerateCheckReport_MembersStatus = iRF_Undo_GenerateCheckReport_Queries + 1;
        static int iRF_Undo_StatusMatrixReport = iRF_Undo_GenerateCheckReport_MembersStatus + 1;
        static int iRF_Undo_SimpleImport_Preview = iRF_Undo_StatusMatrixReport + 1;
        static int iRF_Undo_SimpleImport_Process = iRF_Undo_SimpleImport_Preview + 1;
        static int iRF_Undo_Checks_ReApply = iRF_Undo_SimpleImport_Process + 1;
        static int iRF_Undo_SnapshotPreview = iRF_Undo_Checks_ReApply + 1;
        static int iRF_Undo_SnapshotPublish = iRF_Undo_SnapshotPreview + 1;
        static int iRF_Undo_Snapshot_Extract = iRF_Undo_SnapshotPublish + 1;
        static int iRF_Undo_Snapshot_Undo = iRF_Undo_Snapshot_Extract + 1;
        static int iRF_Undo_Snapshot_RePublish = iRF_Undo_Snapshot_Undo + 1;
        static int iRF_Undo_Reports_ExportAll = iRF_Undo_Snapshot_RePublish + 1;



        static int iRF_Consume_Open = iRF_Undo_Reports_ExportAll + 1;
        static int iRF_Consume_Select = iRF_Consume_Open + 1;
        static int iRF_Consume_Import = iRF_Consume_Select + 1;
        static int iRF_Consume_Total = iRF_Consume_Import + 1;





        static int iTest = 305;

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
        public void testUS_Data_2050100_SQL2016()
        {


            #region initialize

            _gLib._CheckScreenResolution(1366, 768);
            _gLib._MsgBox("Warning!", "Your are going to test client: " + Config.sClientName + " with EE = " + sEENum);
            _gLib._StudioClearCache();
            pMain._SetLanguageAndRegional();
            mLog.LogInfo(iTimeStart, DateTime.Now.ToString());
            mLog.LogInfo(iNumOfEE, sEENum);



            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "ParticipantData");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            #endregion




            _gLib._CreateDirectory(sOutputDir, false);


            #region Iteration 1 - Undo - Import




            pMain._SelectTab("Home");
            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", sData_2012);
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            mTime.StopTimer(iRF_Undo_ReopenDataService);
            //mLog.LogInfo(iRF_Undo_ReopenDataService, MyPerformanceCounter.Memory_Private);





            dic.Clear();
            dic.Add("Level_1", sData_2012);
            dic.Add("Level_2", "Undo");
            pData._TreeViewSelect(dic);


            pData._ts_SearchUndoItem("Import - Finalize Matching", 0);

            _gLib._SetSyncUDWin("Undo", pData.wRetirementStudio.wUndo_Undo.btnUndo, "Click", 0);



            _gLib._SetSyncUDWin_ByClipboard("Undo comments", pData.wUndo_ConfirmUndo.wComments.txtComments, "undo all", 0);

            mTime.StartTimer();

            _gLib._SetSyncUDWin("OK", pData.wUndo_ConfirmUndo.wOK.btnOK, "Click", 0);


            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_Undo);
            //mLog.LogInfo(iRF_Undo_Undo, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("Level_1", sData_2012);
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "ImportData");
            pData._TreeViewSelect(dic);

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
            mTime.StopTimer(iRF_Undo_ValidateAndLoad);
            //mLog.LogInfo(iRF_Undo_ValidateAndLoad, MyPerformanceCounter.Memory_Private);


            pData._SelectTab("Pre Matching Derivations");

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
            mTime.StopTimer(iRF_Undo_PMD_CalculateAndPreview);


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

            mTime.StopTimer(iRF_Undo_PMD_SaveToStagingArea);




            pData._SelectTab("Matching");



            //////////////mTime.StartTimer();

            //////////////dic.Clear();
            //////////////dic.Add("PopVerify", "Pop");
            //////////////dic.Add("MatchManually", "Click");
            //////////////dic.Add("FindMatches", "");
            //////////////pData._PopVerify_IP_Matching(dic);

            //////////////dic.Clear();
            //////////////dic.Add("PopVerify", "Pop");
            //////////////dic.Add("OK", "Click");
            //////////////dic.Add("Yes", "");
            //////////////pData._PopVerify_CK_Warning_Popup(dic);

            //////////////_gLib._Exists("ManualMatching", pData.wIP_ManualMatching, Config.iTimeout * 3, true);

            //////////////mTime.StopTimer(iRF_Undo_ManualMatch_Open);

            //////////////mTime.StartTimer();

            //////////////dic.Clear();
            //////////////dic.Add("sDataFileRecords", "");
            //////////////dic.Add("sWarehouseRecords", "");
            //////////////dic.Add("bExactMatch", "");
            //////////////dic.Add("iMaxSeachNum", "");
            //////////////dic.Add("AcceptSelectedDataFile_AsNew", "");
            //////////////dic.Add("Close", "Click");
            //////////////pData._IP_MatchManually(dic);

            //////////////pData._SelectTab("Matching");
            //////////////mTime.StopTimer(iRF_Undo_ManualMatch_Close);



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
            mTime.StopTimer(iRF_Undo_FindMatch);

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
            mTime.StopTimer(iRF_Undo_AcceptNew);



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
            mTime.StopTimer(iRF_Undo_AcceptMatch);



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
            mTime.StopTimer(iRF_Undo_AcceptNoMatch);





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

            mTime.StopTimer(iRF_Undo_SaveWH);
            //mLog.LogInfo(iRF_Undo_SaveWH, MyPerformanceCounter.Memory_Private);

            #endregion


            #region Iteration 1 - Undo - Derivations

            dic.Clear();
            dic.Add("Level_1", sData_2012);
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_SelectFile(dic);

            pMain._SelectTab(sData_2012);

            mTime.StopTimer(iRF_Undo_CV_Preview);



            //////////////////////////dic.Clear();
            //////////////////////////dic.Add("Level_1", sData_2012);
            //////////////////////////dic.Add("Level_2", "Derivation Groups");
            //////////////////////////dic.Add("MenuItem", "Run Derivations in Batch");
            //////////////////////////pData._TreeViewRightSelect(dic);


            //////////////////////////mTime.StartTimer();

            //////////////////////////dic.Clear();
            //////////////////////////dic.Add("PopVerify", "Pop");
            //////////////////////////dic.Add("Derivation", "All");
            //////////////////////////dic.Add("Calculate", "Click");
            //////////////////////////pData._PopVerify_DG_RunDerivationsInBatch(dic);


            //////////////////////////_gLib._Exists("DerivationBatchRun", pData.wDG_DerivationBatchRun, Config.iTimeout * 10, false);

            //////////////////////////dic.Clear();
            //////////////////////////dic.Add("PopVerify", "Pop");
            //////////////////////////dic.Add("OK", "Click");
            //////////////////////////pData._PopVerify_DG_DerivationsBatchRun(dic);

            //////////////////////////pMain._SelectTab(sData_2012);
            //////////////////////////mTime.StopTimer(iRF_Undo_RunDerivationsInBatch);
            ////////////////////////////mLog.LogInfo(iRF_Undo_RunDerivationsInBatch, MyPerformanceCounter.Memory_Private);



            //////////////////////////dic.Clear();
            //////////////////////////dic.Add("Level_1", sData_2012);
            //////////////////////////dic.Add("Level_2", "Undo");
            //////////////////////////pData._TreeViewSelect(dic);



            //////////////////////////pData._ts_SearchUndoItem("PostMatchDerivations for DerivedGrp", 0);

            //////////////////////////_gLib._SetSyncUDWin("Undo", pData.wRetirementStudio.wUndo_Undo.btnUndo, "Click", 0);

            //////////////////////////if (_gLib._Exists("Undo", pData.wUndo_Popup.wYes, 1, false))
            //////////////////////////{
            //////////////////////////    dic.Clear();
            //////////////////////////    dic.Add("PopVerify", "Pop");
            //////////////////////////    dic.Add("Yes", "Click");
            //////////////////////////    pData._PopVerify_Undo_Popup(dic);
            //////////////////////////}

            //////////////////////////_gLib._SetSyncUDWin_ByClipboard("Undo comments", pData.wUndo_ConfirmUndo.wComments.txtComments, "undo derivations", 0);

            //////////////////////////mTime.StartTimer();

            //////////////////////////_gLib._SetSyncUDWin("OK", pData.wUndo_ConfirmUndo.wOK.btnOK, "Click", 0);


            //////////////////////////pMain._SelectTab(sData_2012);
            //////////////////////////mTime.StopTimer(iRF_Undo_UndoDerivations);
            ////////////////////////////mLog.LogInfo(iRF_Undo_UndoDerivations, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("Level_1", sData_2012);
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

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_DerivedGrp_CalculateAndPreview);


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

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_DerivedGrp_SaveToWarehouse);





            dic.Clear();
            dic.Add("Level_1", sData_2012);
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

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_CalcDates_CalculateAndPreview);


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

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_CalcDates_SaveToWarehouse);


            dic.Clear();
            dic.Add("Level_1", sData_2012);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "AgeCalculations");
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

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_AgeVCalculations_CalculateAndPreview);


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

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_AgeCalculations_SaveToWarehouse);


            dic.Clear();
            dic.Add("Level_1", sData_2012);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "CreditBalance");
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

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_CreditBalance_CalculateAndPreview);


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

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_CreditBalance_SaveToWarehouse);


            dic.Clear();
            dic.Add("Level_1", sData_2012);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "BenefitsPayAverages");
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

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_PayAverages_CalculateAndPreview);


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

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_PayAverages_SaveToWarehouse);



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
            dic.Add("SelectSampleRecords_Formula", "");
            dic.Add("SelectSampleRecords_Accept", "");
            dic.Add("SelectSampleRecords_Apply", "");
            dic.Add("PrintAll", "Click");
            dic.Add("PrintToFile", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            pData.pOutputManager._SaveAs(sOutputDir + "PrintAll_Undo_Derivations.xlsx");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_Complete_Popup(dic);

            mTime.StopTimer(iRF_Undo_PayAverages_PrintAll);
            //mLog.LogInfo(iRF_Undo_PayAverages_PrintAll, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("Level_1", sData_2012);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Other");
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

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_Other_CalculateAndPreview);


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

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_Other_SaveToWarehouse);
            //mLog.LogInfo(iRF_Undo_Other_SaveToWarehouse, MyPerformanceCounter.Memory_Private);

            #endregion


            #region Iteration 1 - Undo - BatchUpdate, View&Update, Reports, SimpleImport, Snapshot

            dic.Clear();
            dic.Add("Level_1", sData_2012);
            dic.Add("Level_2", "Batch Update");
            dic.Add("Level_3", "BatchUpdate1");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "Click");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);

            if (_gLib._Exists("Confrim", pData.wConfirm_Popup, 1, false))
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("Yes", "click");
                dic.Add("OK", "");
                pData._PopVerify_Confirm_Popup(dic);

            }

            pMain._SelectTab(sData_2012);

            pData._BU_PasteValues(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\Data_PerformanceTest\BatchUpdateInput.xlsx");

            pMain._SelectTab(sData_2012);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_BatchUpdate(dic);

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_BatchUpdate_SaveToWarehouse);
            //mLog.LogInfo(iRF_Undo_BatchUpdate_SaveToWarehouse, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", sData_2012);
            dic.Add("Level_2", "Checks");
            pData._TreeViewSelect(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab(sData_2012);

            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "Click");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);



            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_ApplyChecks);


            dic.Clear();
            dic.Add("Level_1", sData_2012);
            dic.Add("Level_2", "View & Update");
            dic.Add("Level_3", "{NewView1}");
            pData._TreeViewSelect(dic);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Filter", "");
            dic.Add("Apply", "Click");
            pData._PopVerify_ViewUpdate(dic);

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_Newview1_Apply);


            dic.Clear();
            dic.Add("Level_1", sData_2012);
            dic.Add("Level_2", "View & Update");
            dic.Add("Level_3", "ActiveBenefits");
            pData._TreeViewSelect(dic);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Filter", "");
            dic.Add("Apply", "Click");
            pData._PopVerify_ViewUpdate(dic);

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_ActiveBenefits_Apply);


            dic.Clear();
            dic.Add("Level_1", sData_2012);
            dic.Add("Level_2", "View & Update");
            dic.Add("Level_3", "InactiveBenefits");
            pData._TreeViewSelect(dic);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Filter", "");
            dic.Add("Apply", "Click");
            pData._PopVerify_ViewUpdate(dic);

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_InactiveBenefits_Apply);


            dic.Clear();
            dic.Add("Level_1", sData_2012);
            dic.Add("Level_2", "View & Update");
            dic.Add("Level_3", "ActivePayAvgs");
            pData._TreeViewSelect(dic);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Filter", "");
            dic.Add("Apply", "Click");
            pData._PopVerify_ViewUpdate(dic);

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_ActivePayAvgs_CustomFilter_Apply);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("Apply", "");
            dic.Add("GenerateSummary", "");
            dic.Add("PrintAll", "Click");
            dic.Add("PrintToFile", "");
            dic.Add("ViewAllManualChanges", "");
            pData._PopVerify_ViewUpdate(dic);


            pData.pOutputManager._SaveAs(sOutputDir + "VU_Undo_PrintAll_ActivePayAvgs_CustomFilter.xlsx");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_Complete_Popup(dic);

            mTime.StopTimer(iRF_Undo_ActivePayAvgs_PrintAll);
            //mLog.LogInfo(iRF_Undo_ActivePayAvgs_PrintAll, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", sData_2012);
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
            dic.Add("Yes", "Click");
            pData._PopVerify_RP_OverwriteReport_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_RP_ReportGenerated_Popup(dic);

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_GenerateCheckReport_AllChecks);



            dic.Clear();
            dic.Add("Level_1", sData_2012);
            dic.Add("Level_2", "Reports");
            dic.Add("Level_3", "Queries");
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
            dic.Add("Yes", "Click");
            pData._PopVerify_RP_OverwriteReport_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_RP_ReportGenerated_Popup(dic);

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_GenerateCheckReport_Queries);



            dic.Clear();
            dic.Add("Level_1", sData_2012);
            dic.Add("Level_2", "Reports");
            dic.Add("Level_3", "MembersStatus");
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
            dic.Add("Yes", "Click");
            pData._PopVerify_RP_OverwriteReport_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_RP_ReportGenerated_Popup(dic);

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_GenerateCheckReport_MembersStatus);


            dic.Clear();
            dic.Add("Level_1", sData_2012);
            dic.Add("Level_2", "Status Matrix");
            pData._TreeViewSelect(dic);

            pMain._SelectTab(sData_2012);
            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CreateMatrix", "Click");
            pData._PopVerify_StatusMatrix(dic);

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_StatusMatrixReport);
            //mLog.LogInfo(iRF_Undo_StatusMatrixReport, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("Level_1", sData_2012);
            dic.Add("Level_2", "Simple Imports");
            dic.Add("Level_3", "Query");
            pData._TreeViewSelect(dic);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            dic.Add("Process", "");
            pData._PopVerify_SimpleImport(dic);

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_SimpleImport_Preview);


            //mTime.StartTimer();

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("Preview", "");
            //dic.Add("Process", "Click");
            //pData._PopVerify_SimpleImport(dic);

            //pMain._SelectTab(sData_2012);
            //mTime.StopTimer(iRF_Undo_SimpleImport_Process);
            ////mLog.LogInfo(iRF_Undo_SimpleImport_Process, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", sData_2012);
            dic.Add("Level_2", "Checks");
            pData._TreeViewSelect(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab(sData_2012);

            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "Click");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);



            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_Checks_ReApply);
            //mLog.LogInfo(iRF_Undo_Checks_ReApply, MyPerformanceCounter.Memory_Private);





            dic.Clear();
            dic.Add("Level_1", sData_2012);
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

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_SnapshotPreview);


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

            pMain._SelectTab(sData_2012);
            mTime.StopTimer(iRF_Undo_SnapshotPublish);


            mTime.StartTimer();

            pData._ts_SP_CreateExtract(sOutputDir + "Undo_SnapshotExtract.xlsx");

            mTime.StopTimer(iRF_Undo_Snapshot_Extract);
            //mLog.LogInfo(iRF_Undo_Snapshot_Extract, MyPerformanceCounter.Memory_Private);



            ////////////////////////////dic.Clear();
            ////////////////////////////dic.Add("Level_1", sData_2012);
            ////////////////////////////dic.Add("Level_2", "Undo");
            ////////////////////////////pData._TreeViewSelect(dic);



            ////////////////////////////pData._ts_SearchUndoItem("Snapshot Publish", 0);

            ////////////////////////////_gLib._SetSyncUDWin("Undo", pData.wRetirementStudio.wUndo_Undo.btnUndo, "Click", 0);



            ////////////////////////////_gLib._SetSyncUDWin_ByClipboard("Undo comments", pData.wUndo_ConfirmUndo.wComments.txtComments, "undo snapshot", 0);

            ////////////////////////////mTime.StartTimer();

            ////////////////////////////_gLib._SetSyncUDWin("OK", pData.wUndo_ConfirmUndo.wOK.btnOK, "Click", 0);


            ////////////////////////////pMain._SelectTab(sData_2012);
            ////////////////////////////mTime.StopTimer(iRF_Undo_Snapshot_Undo);
            //////////////////////////////mLog.LogInfo(iRF_SS_Undo, MyPerformanceCounter.Memory_Private);



            ////////////////////////////dic.Clear();
            ////////////////////////////dic.Add("Level_1", sData_2012);
            ////////////////////////////dic.Add("Level_2", "Snapshots");
            ////////////////////////////dic.Add("Level_3", "ImportData");
            ////////////////////////////pData._TreeViewSelect(dic);

            ////////////////////////////pMain._SelectTab(sData_2012);

            ////////////////////////////mTime.StartTimer();

            ////////////////////////////dic.Clear();
            ////////////////////////////dic.Add("PopVerify", "Pop");
            ////////////////////////////dic.Add("SnapshotName", "");
            ////////////////////////////dic.Add("UseLatestDate", "");
            ////////////////////////////dic.Add("Preview", "");
            ////////////////////////////dic.Add("PublishSnapshot", "Click");
            ////////////////////////////dic.Add("CreateExtract", "");
            ////////////////////////////pData._PopVerify_Snapshots(dic);


            ////////////////////////////dic.Clear();
            ////////////////////////////dic.Add("PopVerify", "Pop");
            ////////////////////////////dic.Add("Yes", "click");
            ////////////////////////////pData._PopVerify_SP_RePublishSnapshot_Popup(dic);



            ////////////////////////////dic.Clear();
            ////////////////////////////dic.Add("PopVerify", "Pop");
            ////////////////////////////dic.Add("OK", "click");
            ////////////////////////////pData._PopVerify_SP_Snapshots_Popup(dic);

            ////////////////////////////pMain._SelectTab(sData_2012);
            ////////////////////////////mTime.StopTimer(iRF_Undo_Snapshot_RePublish);
            //////////////////////////////mLog.LogInfo(iRF_Undo_Snapshot_RePublish, MyPerformanceCounter.Memory_Private);


            //////////////dic.Clear();
            //////////////dic.Add("Level_1", sData_2012);
            //////////////dic.Add("Level_2", "Output Manager");
            //////////////pData._TreeViewSelect(dic);

            //////////////if (_gLib._Exists("Save", pData.wOM_DataService_Popup, 3, 1, false))
            //////////////    _gLib._SetSyncUDWin("NO", pData.wOM_DataService_Popup.wNO.btnNo, "Click", 0);

            //////////////pMain._SelectTab("Data Output Manager");


            ////////////////mTime.StartTimer();

            //////////////_gLib._SetSyncUDWin("", pData.wRetirementStudio.wOM_ExportAll.btn, "Click", 0);

            //////////////pData.pOutputManager._SaveAs(sOutputDir + "Undo_GenerateConsolidatedOuput.xls");

            //////////////dic.Clear();
            //////////////dic.Add("PopVerify", "Pop");
            //////////////dic.Add("OK", "Click");
            //////////////pData._PopVerify_Complete_Popup(dic);

            ////////////////mTime.StopTimer(iRF_Undo_Reports_ExportAll);
            ////////////////mLog.LogInfo(iRF_Undo_Reports_ExportAll, MyPerformanceCounter.Memory_Private);

            pMain._SelectTab(sData_2012);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion



            _gLib._CreateDirectory(sOutputDir, false);


            #region Iteration 2 - Undo - Import




            pMain._SelectTab("Home");
            mTime_2.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", sData_2012);
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            mTime_2.StopTimer(iRF_Undo_ReopenDataService);
            //mLog.LogInfo(iRF_Undo_ReopenDataService, MyPerformanceCounter.Memory_Private);





            dic.Clear();
            dic.Add("Level_1", sData_2012);
            dic.Add("Level_2", "Undo");
            pData._TreeViewSelect(dic);


            pData._ts_SearchUndoItem("Import - Finalize Matching", 0);

            _gLib._SetSyncUDWin("Undo", pData.wRetirementStudio.wUndo_Undo.btnUndo, "Click", 0);



            _gLib._SetSyncUDWin_ByClipboard("Undo comments", pData.wUndo_ConfirmUndo.wComments.txtComments, "undo all", 0);

            mTime_2.StartTimer();

            _gLib._SetSyncUDWin("OK", pData.wUndo_ConfirmUndo.wOK.btnOK, "Click", 0);


            pMain._SelectTab(sData_2012);
            mTime_2.StopTimer(iRF_Undo_Undo);
            //mLog.LogInfo(iRF_Undo_Undo, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("Level_1", sData_2012);
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "ImportData");
            pData._TreeViewSelect(dic);

            pData._SelectTab("Validate & Load");

            mTime_2.StartTimer();


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
            mTime_2.StopTimer(iRF_Undo_ValidateAndLoad);
            //mLog.LogInfo(iRF_Undo_ValidateAndLoad, MyPerformanceCounter.Memory_Private);


            pData._SelectTab("Pre Matching Derivations");

            mTime_2.StartTimer();

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
            mTime_2.StopTimer(iRF_Undo_PMD_CalculateAndPreview);


            mTime_2.StartTimer();

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

            mTime_2.StopTimer(iRF_Undo_PMD_SaveToStagingArea);




            pData._SelectTab("Matching");



            //////////////mTime_2.StartTimer();

            //////////////dic.Clear();
            //////////////dic.Add("PopVerify", "Pop");
            //////////////dic.Add("MatchManually", "Click");
            //////////////dic.Add("FindMatches", "");
            //////////////pData._PopVerify_IP_Matching(dic);

            //////////////dic.Clear();
            //////////////dic.Add("PopVerify", "Pop");
            //////////////dic.Add("OK", "Click");
            //////////////dic.Add("Yes", "");
            //////////////pData._PopVerify_CK_Warning_Popup(dic);

            //////////////_gLib._Exists("ManualMatching", pData.wIP_ManualMatching, Config.iTimeout * 3, true);

            //////////////mTime_2.StopTimer(iRF_Undo_ManualMatch_Open);

            //////////////mTime_2.StartTimer();

            //////////////dic.Clear();
            //////////////dic.Add("sDataFileRecords", "");
            //////////////dic.Add("sWarehouseRecords", "");
            //////////////dic.Add("bExactMatch", "");
            //////////////dic.Add("iMaxSeachNum", "");
            //////////////dic.Add("AcceptSelectedDataFile_AsNew", "");
            //////////////dic.Add("Close", "Click");
            //////////////pData._IP_MatchManually(dic);

            //////////////pData._SelectTab("Matching");
            //////////////mTime_2.StopTimer(iRF_Undo_ManualMatch_Close);



            dic.Clear();
            dic.Add("Field", "EmployeeIDNumber");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);



            mTime_2.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);

            pData._SelectTab("Matching");
            mTime_2.StopTimer(iRF_Undo_FindMatch);

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






            mTime_2.StartTimer();

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
            mTime_2.StopTimer(iRF_Undo_AcceptNew);



            mTime_2.StartTimer();

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
            mTime_2.StopTimer(iRF_Undo_AcceptMatch);



            mTime_2.StartTimer();

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
            mTime_2.StopTimer(iRF_Undo_AcceptNoMatch);





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


            mTime_2.StartTimer();


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

            mTime_2.StopTimer(iRF_Undo_SaveWH);
            //mLog.LogInfo(iRF_Undo_SaveWH, MyPerformanceCounter.Memory_Private);

            #endregion


            #region Iteration 2 - Undo - Derivations

                dic.Clear();
                dic.Add("Level_1", sData_2012);
                dic.Add("Level_2", "Current View");
                pData._TreeViewSelect(dic);


                mTime_2.StartTimer();

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("Preview", "Click");
                pData._PopVerify_IP_SelectFile(dic);

                pMain._SelectTab(sData_2012);

                mTime_2.StopTimer(iRF_Undo_CV_Preview);



                //////////////////////////dic.Clear();
                //////////////////////////dic.Add("Level_1", sData_2012);
                //////////////////////////dic.Add("Level_2", "Derivation Groups");
                //////////////////////////dic.Add("MenuItem", "Run Derivations in Batch");
                //////////////////////////pData._TreeViewRightSelect(dic);


                //////////////////////////mTime_2.StartTimer();

                //////////////////////////dic.Clear();
                //////////////////////////dic.Add("PopVerify", "Pop");
                //////////////////////////dic.Add("Derivation", "All");
                //////////////////////////dic.Add("Calculate", "Click");
                //////////////////////////pData._PopVerify_DG_RunDerivationsInBatch(dic);


                //////////////////////////_gLib._Exists("DerivationBatchRun", pData.wDG_DerivationBatchRun, Config.iTimeout * 10, false);

                //////////////////////////dic.Clear();
                //////////////////////////dic.Add("PopVerify", "Pop");
                //////////////////////////dic.Add("OK", "Click");
                //////////////////////////pData._PopVerify_DG_DerivationsBatchRun(dic);

                //////////////////////////pMain._SelectTab(sData_2012);
                //////////////////////////mTime_2.StopTimer(iRF_Undo_RunDerivationsInBatch);
                ////////////////////////////mLog.LogInfo(iRF_Undo_RunDerivationsInBatch, MyPerformanceCounter.Memory_Private);



                //////////////////////////dic.Clear();
                //////////////////////////dic.Add("Level_1", sData_2012);
                //////////////////////////dic.Add("Level_2", "Undo");
                //////////////////////////pData._TreeViewSelect(dic);



                //////////////////////////pData._ts_SearchUndoItem("PostMatchDerivations for DerivedGrp", 0);

                //////////////////////////_gLib._SetSyncUDWin("Undo", pData.wRetirementStudio.wUndo_Undo.btnUndo, "Click", 0);

                //////////////////////////if (_gLib._Exists("Undo", pData.wUndo_Popup.wYes, 1, false))
                //////////////////////////{
                //////////////////////////    dic.Clear();
                //////////////////////////    dic.Add("PopVerify", "Pop");
                //////////////////////////    dic.Add("Yes", "Click");
                //////////////////////////    pData._PopVerify_Undo_Popup(dic);
                //////////////////////////}

                //////////////////////////_gLib._SetSyncUDWin_ByClipboard("Undo comments", pData.wUndo_ConfirmUndo.wComments.txtComments, "undo derivations", 0);

                //////////////////////////mTime_2.StartTimer();

                //////////////////////////_gLib._SetSyncUDWin("OK", pData.wUndo_ConfirmUndo.wOK.btnOK, "Click", 0);


                //////////////////////////pMain._SelectTab(sData_2012);
                //////////////////////////mTime_2.StopTimer(iRF_Undo_UndoDerivations);
                ////////////////////////////mLog.LogInfo(iRF_Undo_UndoDerivations, MyPerformanceCounter.Memory_Private);


                dic.Clear();
                dic.Add("Level_1", sData_2012);
                dic.Add("Level_2", "Derivation Groups");
                dic.Add("Level_3", "DerivedGrp");
                pData._TreeViewSelect(dic);

                mTime_2.StartTimer();

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

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_DerivedGrp_CalculateAndPreview);


                mTime_2.StartTimer();

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

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_DerivedGrp_SaveToWarehouse);





                dic.Clear();
                dic.Add("Level_1", sData_2012);
                dic.Add("Level_2", "Derivation Groups");
                dic.Add("Level_3", "CalcDates");
                pData._TreeViewSelect(dic);

                mTime_2.StartTimer();

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

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_CalcDates_CalculateAndPreview);


                mTime_2.StartTimer();

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

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_CalcDates_SaveToWarehouse);


                dic.Clear();
                dic.Add("Level_1", sData_2012);
                dic.Add("Level_2", "Derivation Groups");
                dic.Add("Level_3", "AgeCalculations");
                pData._TreeViewSelect(dic);

                mTime_2.StartTimer();

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

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_AgeVCalculations_CalculateAndPreview);


                mTime_2.StartTimer();

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

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_AgeCalculations_SaveToWarehouse);


                dic.Clear();
                dic.Add("Level_1", sData_2012);
                dic.Add("Level_2", "Derivation Groups");
                dic.Add("Level_3", "CreditBalance");
                pData._TreeViewSelect(dic);

                mTime_2.StartTimer();

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

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_CreditBalance_CalculateAndPreview);


                mTime_2.StartTimer();

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

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_CreditBalance_SaveToWarehouse);


                dic.Clear();
                dic.Add("Level_1", sData_2012);
                dic.Add("Level_2", "Derivation Groups");
                dic.Add("Level_3", "BenefitsPayAverages");
                pData._TreeViewSelect(dic);

                mTime_2.StartTimer();

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

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_PayAverages_CalculateAndPreview);


                mTime_2.StartTimer();

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

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_PayAverages_SaveToWarehouse);



                mTime_2.StartTimer();

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
                dic.Add("SelectSampleRecords_Formula", "");
                dic.Add("SelectSampleRecords_Accept", "");
                dic.Add("SelectSampleRecords_Apply", "");
                dic.Add("PrintAll", "Click");
                dic.Add("PrintToFile", "");
                dic.Add("CalculateAndPreview", "");
                dic.Add("SaveToWarehouse", "");
                pData._PopVerify_DerivationGroups(dic);

                pData.pOutputManager._SaveAs(sOutputDir + "PrintAll_Undo_Derivations.xlsx");

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("OK", "Click");
                pData._PopVerify_Complete_Popup(dic);

                mTime_2.StopTimer(iRF_Undo_PayAverages_PrintAll);
                //mLog.LogInfo(iRF_Undo_PayAverages_PrintAll, MyPerformanceCounter.Memory_Private);




                dic.Clear();
                dic.Add("Level_1", sData_2012);
                dic.Add("Level_2", "Derivation Groups");
                dic.Add("Level_3", "Other");
                pData._TreeViewSelect(dic);

                mTime_2.StartTimer();

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

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_Other_CalculateAndPreview);


                mTime_2.StartTimer();

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

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_Other_SaveToWarehouse);
                //mLog.LogInfo(iRF_Undo_Other_SaveToWarehouse, MyPerformanceCounter.Memory_Private);

                #endregion


            #region Iteration 2 - Undo - BatchUpdate, View&Update, Reports, SimpleImport, Snapshot

                dic.Clear();
                dic.Add("Level_1", sData_2012);
                dic.Add("Level_2", "Batch Update");
                dic.Add("Level_3", "BatchUpdate1");
                pData._TreeViewSelect(dic);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("BatchUpdateName", "");
                dic.Add("SelectFieldstoDisplay", "");
                dic.Add("StandardorCustomFilter_rd", "");
                dic.Add("StandardorCustomFilter_cbo", "");
                dic.Add("CustomExpression_rd", "");
                dic.Add("CustomExpression_Formula", "");
                dic.Add("CustomExpression_Accept", "");
                dic.Add("Apply", "Click");
                dic.Add("Plug", "");
                dic.Add("Correction", "");
                dic.Add("SaveToWarehouse", "");
                pData._PopVerify_BatchUpdate(dic);

                if (_gLib._Exists("Confrim", pData.wConfirm_Popup, 1, false))
                {
                    dic.Clear();
                    dic.Add("PopVerify", "Pop");
                    dic.Add("Yes", "click");
                    dic.Add("OK", "");
                    pData._PopVerify_Confirm_Popup(dic);

                }

                pMain._SelectTab(sData_2012);

                pData._BU_PasteValues(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\Data_PerformanceTest\BatchUpdateInput.xlsx");

                pMain._SelectTab(sData_2012);

                mTime_2.StartTimer();

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("BatchUpdateName", "");
                dic.Add("SelectFieldstoDisplay", "");
                dic.Add("StandardorCustomFilter_rd", "");
                dic.Add("StandardorCustomFilter_cbo", "");
                dic.Add("CustomExpression_rd", "");
                dic.Add("CustomExpression_Formula", "");
                dic.Add("CustomExpression_Accept", "");
                dic.Add("Apply", "");
                dic.Add("Plug", "");
                dic.Add("Correction", "");
                dic.Add("SaveToWarehouse", "Click");
                pData._PopVerify_BatchUpdate(dic);

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_BatchUpdate_SaveToWarehouse);
                //mLog.LogInfo(iRF_Undo_BatchUpdate_SaveToWarehouse, MyPerformanceCounter.Memory_Private);



                dic.Clear();
                dic.Add("Level_1", sData_2012);
                dic.Add("Level_2", "Checks");
                pData._TreeViewSelect(dic);

                pMain._Home_ToolbarClick_Top(true);

                pMain._SelectTab(sData_2012);

                mTime_2.StartTimer();


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("StandardInputs", "");
                dic.Add("AddCustomGroup", "");
                dic.Add("AddCheck", "");
                dic.Add("ApplyChecks", "Click");
                dic.Add("ClearAllResults", "");
                pData._PopVerify_Checks(dic);



                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_ApplyChecks);


                dic.Clear();
                dic.Add("Level_1", sData_2012);
                dic.Add("Level_2", "View & Update");
                dic.Add("Level_3", "{NewView1}");
                pData._TreeViewSelect(dic);

                mTime_2.StartTimer();

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("Filter", "");
                dic.Add("Apply", "Click");
                pData._PopVerify_ViewUpdate(dic);

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_Newview1_Apply);


                dic.Clear();
                dic.Add("Level_1", sData_2012);
                dic.Add("Level_2", "View & Update");
                dic.Add("Level_3", "ActiveBenefits");
                pData._TreeViewSelect(dic);

                mTime_2.StartTimer();

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("Filter", "");
                dic.Add("Apply", "Click");
                pData._PopVerify_ViewUpdate(dic);

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_ActiveBenefits_Apply);


                dic.Clear();
                dic.Add("Level_1", sData_2012);
                dic.Add("Level_2", "View & Update");
                dic.Add("Level_3", "InactiveBenefits");
                pData._TreeViewSelect(dic);

                mTime_2.StartTimer();

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("Filter", "");
                dic.Add("Apply", "Click");
                pData._PopVerify_ViewUpdate(dic);

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_InactiveBenefits_Apply);


                dic.Clear();
                dic.Add("Level_1", sData_2012);
                dic.Add("Level_2", "View & Update");
                dic.Add("Level_3", "ActivePayAvgs");
                pData._TreeViewSelect(dic);

                mTime_2.StartTimer();

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("Filter", "");
                dic.Add("Apply", "Click");
                pData._PopVerify_ViewUpdate(dic);

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_ActivePayAvgs_CustomFilter_Apply);



                mTime_2.StartTimer();

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ViewSetName", "");
                dic.Add("SelectLabelsToView", "");
                dic.Add("Filter", "");
                dic.Add("Apply", "");
                dic.Add("GenerateSummary", "");
                dic.Add("PrintAll", "Click");
                dic.Add("PrintToFile", "");
                dic.Add("ViewAllManualChanges", "");
                pData._PopVerify_ViewUpdate(dic);


                pData.pOutputManager._SaveAs(sOutputDir + "VU_Undo_PrintAll_ActivePayAvgs_CustomFilter.xlsx");

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("OK", "Click");
                pData._PopVerify_Complete_Popup(dic);

                mTime_2.StopTimer(iRF_Undo_ActivePayAvgs_PrintAll);
                //mLog.LogInfo(iRF_Undo_ActivePayAvgs_PrintAll, MyPerformanceCounter.Memory_Private);



                dic.Clear();
                dic.Add("Level_1", sData_2012);
                dic.Add("Level_2", "Reports");
                dic.Add("Level_3", "ChecksReport");
                pData._TreeViewSelect(dic);

                mTime_2.StartTimer();

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
                dic.Add("Yes", "Click");
                pData._PopVerify_RP_OverwriteReport_Popup(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("OK", "Click");
                pData._PopVerify_RP_ReportGenerated_Popup(dic);

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_GenerateCheckReport_AllChecks);



                dic.Clear();
                dic.Add("Level_1", sData_2012);
                dic.Add("Level_2", "Reports");
                dic.Add("Level_3", "Queries");
                pData._TreeViewSelect(dic);

                mTime_2.StartTimer();


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
                dic.Add("Yes", "Click");
                pData._PopVerify_RP_OverwriteReport_Popup(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("OK", "Click");
                pData._PopVerify_RP_ReportGenerated_Popup(dic);

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_GenerateCheckReport_Queries);



                dic.Clear();
                dic.Add("Level_1", sData_2012);
                dic.Add("Level_2", "Reports");
                dic.Add("Level_3", "MembersStatus");
                pData._TreeViewSelect(dic);

                mTime_2.StartTimer();


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
                dic.Add("Yes", "Click");
                pData._PopVerify_RP_OverwriteReport_Popup(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("OK", "Click");
                pData._PopVerify_RP_ReportGenerated_Popup(dic);

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_GenerateCheckReport_MembersStatus);


                dic.Clear();
                dic.Add("Level_1", sData_2012);
                dic.Add("Level_2", "Status Matrix");
                pData._TreeViewSelect(dic);

                pMain._SelectTab(sData_2012);
                mTime_2.StartTimer();

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("CreateMatrix", "Click");
                pData._PopVerify_StatusMatrix(dic);

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_StatusMatrixReport);
                //mLog.LogInfo(iRF_Undo_StatusMatrixReport, MyPerformanceCounter.Memory_Private);


                dic.Clear();
                dic.Add("Level_1", sData_2012);
                dic.Add("Level_2", "Simple Imports");
                dic.Add("Level_3", "Query");
                pData._TreeViewSelect(dic);


                mTime_2.StartTimer();

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("Preview", "Click");
                dic.Add("Process", "");
                pData._PopVerify_SimpleImport(dic);

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_SimpleImport_Preview);


                //mTime_2.StartTimer();

                //dic.Clear();
                //dic.Add("PopVerify", "Pop");
                //dic.Add("Preview", "");
                //dic.Add("Process", "Click");
                //pData._PopVerify_SimpleImport(dic);

                //pMain._SelectTab(sData_2012);
                //mTime_2.StopTimer(iRF_Undo_SimpleImport_Process);
                ////mLog.LogInfo(iRF_Undo_SimpleImport_Process, MyPerformanceCounter.Memory_Private);



                dic.Clear();
                dic.Add("Level_1", sData_2012);
                dic.Add("Level_2", "Checks");
                pData._TreeViewSelect(dic);

                pMain._Home_ToolbarClick_Top(true);

                pMain._SelectTab(sData_2012);

                mTime_2.StartTimer();


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("StandardInputs", "");
                dic.Add("AddCustomGroup", "");
                dic.Add("AddCheck", "");
                dic.Add("ApplyChecks", "Click");
                dic.Add("ClearAllResults", "");
                pData._PopVerify_Checks(dic);



                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_Checks_ReApply);
                //mLog.LogInfo(iRF_Undo_Checks_ReApply, MyPerformanceCounter.Memory_Private);





                dic.Clear();
                dic.Add("Level_1", sData_2012);
                dic.Add("Level_2", "Snapshots");
                dic.Add("Level_3", "ImportData");
                pData._TreeViewSelect(dic);



                mTime_2.StartTimer();

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("SnapshotName", "");
                dic.Add("UseLatestDate", "");
                dic.Add("Preview", "Click");
                dic.Add("PublishSnapshot", "");
                dic.Add("CreateExtract", "");
                pData._PopVerify_Snapshots(dic);

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_SnapshotPreview);


                mTime_2.StartTimer();

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

                pMain._SelectTab(sData_2012);
                mTime_2.StopTimer(iRF_Undo_SnapshotPublish);


                mTime_2.StartTimer();

                pData._ts_SP_CreateExtract(sOutputDir + "Undo_SnapshotExtract.xlsx");

                mTime_2.StopTimer(iRF_Undo_Snapshot_Extract);
                //mLog.LogInfo(iRF_Undo_Snapshot_Extract, MyPerformanceCounter.Memory_Private);



                ////////////////////////////dic.Clear();
                ////////////////////////////dic.Add("Level_1", sData_2012);
                ////////////////////////////dic.Add("Level_2", "Undo");
                ////////////////////////////pData._TreeViewSelect(dic);



                ////////////////////////////pData._ts_SearchUndoItem("Snapshot Publish", 0);

                ////////////////////////////_gLib._SetSyncUDWin("Undo", pData.wRetirementStudio.wUndo_Undo.btnUndo, "Click", 0);



                ////////////////////////////_gLib._SetSyncUDWin_ByClipboard("Undo comments", pData.wUndo_ConfirmUndo.wComments.txtComments, "undo snapshot", 0);

                ////////////////////////////mTime_2.StartTimer();

                ////////////////////////////_gLib._SetSyncUDWin("OK", pData.wUndo_ConfirmUndo.wOK.btnOK, "Click", 0);


                ////////////////////////////pMain._SelectTab(sData_2012);
                ////////////////////////////mTime_2.StopTimer(iRF_Undo_Snapshot_Undo);
                //////////////////////////////mLog.LogInfo(iRF_SS_Undo, MyPerformanceCounter.Memory_Private);



                ////////////////////////////dic.Clear();
                ////////////////////////////dic.Add("Level_1", sData_2012);
                ////////////////////////////dic.Add("Level_2", "Snapshots");
                ////////////////////////////dic.Add("Level_3", "ImportData");
                ////////////////////////////pData._TreeViewSelect(dic);

                ////////////////////////////pMain._SelectTab(sData_2012);

                ////////////////////////////mTime_2.StartTimer();

                ////////////////////////////dic.Clear();
                ////////////////////////////dic.Add("PopVerify", "Pop");
                ////////////////////////////dic.Add("SnapshotName", "");
                ////////////////////////////dic.Add("UseLatestDate", "");
                ////////////////////////////dic.Add("Preview", "");
                ////////////////////////////dic.Add("PublishSnapshot", "Click");
                ////////////////////////////dic.Add("CreateExtract", "");
                ////////////////////////////pData._PopVerify_Snapshots(dic);


                ////////////////////////////dic.Clear();
                ////////////////////////////dic.Add("PopVerify", "Pop");
                ////////////////////////////dic.Add("Yes", "click");
                ////////////////////////////pData._PopVerify_SP_RePublishSnapshot_Popup(dic);



                ////////////////////////////dic.Clear();
                ////////////////////////////dic.Add("PopVerify", "Pop");
                ////////////////////////////dic.Add("OK", "click");
                ////////////////////////////pData._PopVerify_SP_Snapshots_Popup(dic);

                ////////////////////////////pMain._SelectTab(sData_2012);
                ////////////////////////////mTime_2.StopTimer(iRF_Undo_Snapshot_RePublish);
                //////////////////////////////mLog.LogInfo(iRF_Undo_Snapshot_RePublish, MyPerformanceCounter.Memory_Private);


                //////////////dic.Clear();
                //////////////dic.Add("Level_1", sData_2012);
                //////////////dic.Add("Level_2", "Output Manager");
                //////////////pData._TreeViewSelect(dic);

                //////////////if (_gLib._Exists("Save", pData.wOM_DataService_Popup, 3, 1, false))
                //////////////    _gLib._SetSyncUDWin("NO", pData.wOM_DataService_Popup.wNO.btnNo, "Click", 0);

                //////////////pMain._SelectTab("Data Output Manager");


                ////////////////mTime_2.StartTimer();

                //////////////_gLib._SetSyncUDWin("", pData.wRetirementStudio.wOM_ExportAll.btn, "Click", 0);

                //////////////pData.pOutputManager._SaveAs(sOutputDir + "Undo_GenerateConsolidatedOuput.xls");

                //////////////dic.Clear();
                //////////////dic.Add("PopVerify", "Pop");
                //////////////dic.Add("OK", "Click");
                //////////////pData._PopVerify_Complete_Popup(dic);

                ////////////////mTime_2.StopTimer(iRF_Undo_Reports_ExportAll);
                ////////////////mLog.LogInfo(iRF_Undo_Reports_ExportAll, MyPerformanceCounter.Memory_Private);

                pMain._SelectTab(sData_2012);


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
            SetVariablesEENum();
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
