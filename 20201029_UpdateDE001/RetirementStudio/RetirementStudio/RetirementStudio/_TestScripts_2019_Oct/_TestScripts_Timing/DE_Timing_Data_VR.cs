////// ----------------------- ------------------------------------------------------------------------///////////
//////                                 DEData Performance Test VR                                     ///////////
//////                                                                                                 ///////////
//////                          Webber.ling@mercer.com      2015-Oct-15                                ///////////
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
    /// Summary description for DE_Timing_Data_VR
    /// </summary>
    [CodedUITest]
    public class DE_Timing_Data_VR
    {
        public DE_Timing_Data_VR()
        {
            Config.eEnv = _TestingEnv.QA2;
            Config.eCountry = _Country.DE;
            Config.sClientName = "Data_Timing_VR_Baseline_Small"; //// QA1 QA4 
            //////Config.sClientName = "Data_Timing_VR_Baseline_Small_D"; //// QA1 QA4 

            //Config.sClientName = "Data_Timing_VR_Baseline_B"; //// EU Prod 
            //Config.sClientName = "Data_Timing_VR_Baseline_E"; //// EU Prod 
            //////////Config.sClientName = "Data_Timing_VR_Baseline_D"; //// QA1 QA4 

            //Config.sClientName = "Data_Timing_VR_Baseline"; //// QA1 QA4 
            //////Config.sClientName = "VR Performance Benchmark";
            Config.sPlanName = "Germany1";
            ////Config.sDataCenter = "Exeter";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = false;
            Config.bCompareReports = false;
        }


        static string sPostFix = "_20190717";
        static string sRF_DataServiceName = "Data2015RF" + sPostFix;
        static string sValServiceName = "PenVal2015" + sPostFix;

        //static Boolean bSmall_Data = false;
        static Boolean bSmall_Data = true;


        #region Timing


        static string sCol_Time = "Time";
        static string sCol_Memory = "Memory";
        static string sLogFile = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\DE_Timing_Data_VR\DE_Timing_Data_VR.xls";
        static string sOutputDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\DE_Timing_Data_VR\Reports_KeepUpdateOnRun\";
        static string sOutputDir_SnapshotExtract = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\DE_Timing_Data_VR\HistoryData_SnapshotExtract\";

        static string sCurrentViewFile_Conversion = @"\\mercer.com\US_Data\Shared\DFL\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE_Timing_Data_VR\CurrentView_Labels_2014Cnv.xls";

        MyTimer mTime = new MyTimer(sCol_Time, sLogFile);
        MyLog mLog = new MyLog(sCol_Memory, sLogFile);




        #region Result Index

        static int iTest = 73;

        static int iTimeStart = 2;
        static int iTimeEnd = iTimeStart + 1;
        static int iRollforward_Service_Add = iTimeEnd + 1;
        static int iPriorView_Preview = iRollforward_Service_Add + 1;
        static int iCurrentView_Preview = iPriorView_Preview + 1;
        static int iSelectFile_Preview_Imp1 = iCurrentView_Preview + 1;
        static int iValidateAndLoad_Imp1 = iSelectFile_Preview_Imp1 + 1;
        static int iPMD_CalcAndPreview_Imp1 = iValidateAndLoad_Imp1 + 1;
        static int iPMD_SaveToStaging_Imp1 = iPMD_CalcAndPreview_Imp1 + 1;
        static int iMatchManually_Open_Imp1 = iPMD_SaveToStaging_Imp1 + 1;
        static int iFindMatch_Imp1 = iMatchManually_Open_Imp1 + 1;
        static int iUniqueMatch_AcceptMatched_Imp1 = iFindMatch_Imp1 + 1;
        static int iSaveToWarehouse_Imp1 = iUniqueMatch_AcceptMatched_Imp1 + 1;
        
        static int iSelectFile_Preview_Imp2 = iSaveToWarehouse_Imp1 + 1;
        static int iValidateAndLoad_Imp2 = iSelectFile_Preview_Imp2 + 1;
        static int iPMD_CalcAndPreview_Imp2 = iValidateAndLoad_Imp2 + 1;
        static int iPMD_SaveToStaging_Imp2 = iPMD_CalcAndPreview_Imp2 + 1;
        static int iMatchManually_Open_Imp2 = iPMD_SaveToStaging_Imp2 + 1;
        static int iFindMatch_Imp2 = iMatchManually_Open_Imp2 + 1;
        static int iUniqueMatch_AcceptMatched_Imp2 = iFindMatch_Imp2 + 1;
        static int iSaveToWarehouse_Imp2 = iUniqueMatch_AcceptMatched_Imp2 + 1;
               
        static int iSelectFile_Preview_Imp3 = iSaveToWarehouse_Imp2 + 1;
        static int iValidateAndLoad_Imp3 = iSelectFile_Preview_Imp3 + 1;
        static int iPMD_CalcAndPreview_Imp3 = iValidateAndLoad_Imp3 + 1;
        static int iPMD_SaveToStaging_Imp3 = iPMD_CalcAndPreview_Imp3 + 1;
        static int iMatchManually_Open_Imp3 = iPMD_SaveToStaging_Imp3 + 1;
        static int iFindMatch_Imp3 = iMatchManually_Open_Imp3 + 1;
        static int iUniqueMatch_AcceptMatched_Imp3 = iFindMatch_Imp3 + 1;
        static int iSaveToWarehouse_Imp3 = iUniqueMatch_AcceptMatched_Imp3 + 1;
        
        static int iSelectFile_Preview_Imp4 = iSaveToWarehouse_Imp3 + 1;
        static int iValidateAndLoad_Imp4 = iSelectFile_Preview_Imp4 + 1;
        static int iPMD_CalcAndPreview_Imp4 = iValidateAndLoad_Imp4 + 1;
        static int iPMD_SaveToStaging_Imp4 = iPMD_CalcAndPreview_Imp4 + 1;
        static int iMatchManually_Open_Imp4 = iPMD_SaveToStaging_Imp4 + 1;
        static int iFindMatch_Imp4 = iMatchManually_Open_Imp4 + 1;
        static int iUniqueMatch_AcceptMatched_Imp4 = iFindMatch_Imp4 + 1;
        static int iSaveToWarehouse_Imp4 = iUniqueMatch_AcceptMatched_Imp4 + 1;
               
        static int iSelectFile_Preview_Imp5 = iSaveToWarehouse_Imp4 + 1;
        static int iValidateAndLoad_Imp5 = iSelectFile_Preview_Imp5 + 1;
        static int iMatchManually_Open_Imp5 = iValidateAndLoad_Imp5 + 1;
        static int iFindMatch_Imp5 = iMatchManually_Open_Imp5 + 1;
        static int iUniqueMatch_AcceptNew_Imp5 = iFindMatch_Imp5 + 1;
        static int iUniqueMatch_AcceptMatched_Imp5 = iUniqueMatch_AcceptNew_Imp5 + 1;
        static int iSaveToWarehouse_Imp5 = iUniqueMatch_AcceptMatched_Imp5 + 1;

        
        static int iSimpleImport_Process = iSaveToWarehouse_Imp5 + 1;
        static int iDerivation_RunBatch = iSimpleImport_Process + 1;
        static int iPrintToFile_Grp3 = iDerivation_RunBatch + 1;
        static int iPrintToFile_Grp4 = iPrintToFile_Grp3 + 1;
        static int iPrintAll_Grp4 = iPrintToFile_Grp4 + 1;
        static int iBatchUpdate_SaveToWarhouse = iPrintAll_Grp4 + 1;
        

   
        static int iCV_Preview_BeforeView1 = iBatchUpdate_SaveToWarhouse + 1;
        static int iVU_Apply_View1 = iCV_Preview_BeforeView1 + 1;
        static int iVU_PrintToFile_View1 = iVU_Apply_View1 + 1;
        static int iCV_Preview_BeforeView2 = iVU_PrintToFile_View1 + 1;
        static int iVU_Apply_View2 = iCV_Preview_BeforeView2 + 1;
        static int iVU_PrintToFile_View2 = iVU_Apply_View2 + 1;
        static int iVU_Apply_LastSession = iVU_PrintToFile_View2 + 1;
        static int iVU_PrintAll_LastSession = iVU_Apply_LastSession + 1;



        static int iCheck_ApplyAll = iVU_PrintAll_LastSession + 1;
        static int iGenerateReport_Plug = iCheck_ApplyAll + 1;
        static int iGenerateReport_Query = iGenerateReport_Plug + 1;
        static int iGenerateReport_StatusMetrix = iGenerateReport_Query + 1;


        static int iSnapshot_Preview_All = iGenerateReport_StatusMetrix + 1;
        static int iSnapshot_Publish_All = iSnapshot_Preview_All + 1;
        static int iSnapshot_Extract_All = iSnapshot_Publish_All + 1;
        static int iSnapshot_Preview_2015Consumption = iSnapshot_Extract_All + 1;
        static int iSnapshot_Publish_2015Consumption = iSnapshot_Preview_2015Consumption + 1;
        static int iSnapshot_Extract_2015Consumption = iSnapshot_Publish_2015Consumption + 1;

        static int iGenerateConsolidatedOuput = iSnapshot_Extract_2015Consumption + 1;
        static int iConsumeSnapshot = iGenerateConsolidatedOuput + 1;
        static int iUndo_All = iConsumeSnapshot + 1;


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
        public void test_DE_Timing_Data_VR()
        {





            _gLib._CheckScreenResolution(1366, 768);
            _gLib._MsgBox("Warning!", "You are going to run test with bSmallData = " + bSmall_Data.ToString() + ", and Rollforward data service name as: " + sRF_DataServiceName);

            _gLib._StudioClearCache();   //////////_gLib._MsgBox("Warning!", "Please Clear Cache!");

            _gLib._CreateDirectory(sOutputDir, false);

            pMain._SetLanguageAndRegional();


            #region Create Service & View


            pMain._SelectTab("Home");


            mLog.LogInfo(iTimeStart, MyPerformanceCounter.Memory_Private);
            mLog.LogInfo(iTimeStart, DateTime.Now.ToString());



            //////////////////_gLib._MsgBox("Warning!", "Please manually select the Client in Studio-> Home -> All Services -> " + Config.sClientName + "->" + Config.sPlanName + "->ParticipantData" + Environment.NewLine + Environment.NewLine
            //////////////////    + "Click OK to keep testing!");


            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "ParticipantData");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            pMain._SelectTab("Home");


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", sRF_DataServiceName);
            dic.Add("EffectiveDate", "31.12.2015");
            dic.Add("Parent", "D2014Cnv");
            dic.Add("RSC", "True");
            dic.Add("Shared", "");
            dic.Add("GeneralUse", "True");
            dic.Add("Conversion", "");
            dic.Add("CopyDataService", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_DataServicePropeties(dic);

            pMain._SelectTab("Home");

            mTime.StopTimer(iRollforward_Service_Add);
            mLog.LogInfo(iRollforward_Service_Add, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", sRF_DataServiceName);
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "Prior View");
            pData._TreeViewSelect(dic);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_SelectFile(dic);

            pMain._SelectTab(sRF_DataServiceName);

            mTime.StopTimer(iPriorView_Preview);
            mLog.LogInfo(iPriorView_Preview, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
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

            pMain._SelectTab(sRF_DataServiceName);

            mTime.StopTimer(iCurrentView_Preview);
            mLog.LogInfo(iCurrentView_Preview, MyPerformanceCounter.Memory_Private);


            #endregion


            #region Import1Actives


            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Import1Actives");
            pData._TreeViewSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "DEDataAdmin_2015RF2KTabs.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("SingleTabPerRecordFile_cbo", "Actives2015RF");
                dic.Add("Preview", "");
                pData._PopVerify_IP_SelectFile(dic);

            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "GBigDataAdmin_2015RFTabs.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                pData._SelectTab("Select File");

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("SingleTabPerRecordFile_cbo", "Actives2015RF");
                dic.Add("Preview", "");
                pData._PopVerify_IP_SelectFile(dic);

            }


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("SingleTabPerRecordFile_cbo", "");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_SelectFile(dic);

            pData._SelectTab("Select File");

            mTime.StopTimer(iSelectFile_Preview_Imp1);
            mLog.LogInfo(iSelectFile_Preview_Imp1, MyPerformanceCounter.Memory_Private);



            pData._SelectTab("Validate & Load");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("CorrectionImportForAdmin", "");
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
            mTime.StopTimer(iValidateAndLoad_Imp1);
            mLog.LogInfo(iValidateAndLoad_Imp1, MyPerformanceCounter.Memory_Private);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Status", "STAGED");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("CorrectionImportForAdmin", "");
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
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            pData._SelectTab("Pre Matching Derivations");

            mTime.StopTimer(iPMD_CalcAndPreview_Imp1);
            mLog.LogInfo(iPMD_CalcAndPreview_Imp1, MyPerformanceCounter.Memory_Private);


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

            mTime.StopTimer(iPMD_SaveToStaging_Imp1);
            mLog.LogInfo(iPMD_SaveToStaging_Imp1, MyPerformanceCounter.Memory_Private);



            pData._SelectTab("Matching");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "Click");
            dic.Add("FindMatches", "");
            pData._PopVerify_IP_Matching(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Yes", "");
            pData._PopVerify_CK_Warning_Popup(dic);

            _gLib._Exists("ManualMatching", pData.wIP_ManualMatching, Config.iTimeout * 3, true);

            mTime.StopTimer(iMatchManually_Open_Imp1);
            mLog.LogInfo(iMatchManually_Open_Imp1, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("sDataFileRecords", "100000001");
            dic.Add("sWarehouseRecords", "100000001");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("AcceptSelectedDataFile_AsNew", "");
            dic.Add("Close", "Click");
            pData._IP_MatchManually(dic);


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
            mTime.StopTimer(iFindMatch_Imp1);
            mLog.LogInfo(iFindMatch_Imp1, MyPerformanceCounter.Memory_Private);


            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "");
                dic.Add("Unique_UniqueMatch_Num", "1199");
                dic.Add("Unique_MultipleMatches_Num", "");
                dic.Add("Duplicate_NoMatch_Num", "");
                dic.Add("Duplicate_UniqueMatch_Num", "");
                dic.Add("Duplicate_MultipleMatches_Num", "");
                dic.Add("Warehouse_NoMatch_Num", "820");
                pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "");
                dic.Add("Unique_UniqueMatch_Num", "7999");
                dic.Add("Unique_MultipleMatches_Num", "");
                dic.Add("Duplicate_NoMatch_Num", "");
                dic.Add("Duplicate_UniqueMatch_Num", "");
                dic.Add("Duplicate_MultipleMatches_Num", "");
                dic.Add("Warehouse_NoMatch_Num", "5100");
                pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);
            }


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
            mTime.StopTimer(iUniqueMatch_AcceptMatched_Imp1);
            mLog.LogInfo(iUniqueMatch_AcceptMatched_Imp1, MyPerformanceCounter.Memory_Private);

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

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);


            pData._SelectTab("Matching");
            mTime.StopTimer(iSaveToWarehouse_Imp1);
            mLog.LogInfo(iSaveToWarehouse_Imp1, MyPerformanceCounter.Memory_Private);


            #endregion


            #region Import2Def


            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Import2Def");
            pData._TreeViewSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "DEDataAdmin_2015RF2KTabs.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("SingleTabPerRecordFile_cbo", "Def2015RF");
                dic.Add("Preview", "");
                pData._PopVerify_IP_SelectFile(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "GBigDataAdmin_2015RFTabs.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                pData._SelectTab("Select File");

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("SingleTabPerRecordFile_cbo", "Def2015RF");
                dic.Add("Preview", "");
                pData._PopVerify_IP_SelectFile(dic);
            }


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("SingleTabPerRecordFile_cbo", "");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_SelectFile(dic);

            pData._SelectTab("Select File");

            mTime.StopTimer(iSelectFile_Preview_Imp2);
            mLog.LogInfo(iSelectFile_Preview_Imp2, MyPerformanceCounter.Memory_Private);



            pData._SelectTab("Validate & Load");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("CorrectionImportForAdmin", "");
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
            mTime.StopTimer(iValidateAndLoad_Imp2);
            mLog.LogInfo(iValidateAndLoad_Imp2, MyPerformanceCounter.Memory_Private);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Status", "STAGED");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("CorrectionImportForAdmin", "");
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
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            pData._SelectTab("Pre Matching Derivations");

            mTime.StopTimer(iPMD_CalcAndPreview_Imp2);
            mLog.LogInfo(iPMD_CalcAndPreview_Imp2, MyPerformanceCounter.Memory_Private);


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

            mTime.StopTimer(iPMD_SaveToStaging_Imp2);
            mLog.LogInfo(iPMD_SaveToStaging_Imp2, MyPerformanceCounter.Memory_Private);



            pData._SelectTab("Matching");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "Click");
            dic.Add("FindMatches", "");
            pData._PopVerify_IP_Matching(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Yes", "");
            pData._PopVerify_CK_Warning_Popup(dic);

            _gLib._Exists("ManualMatching", pData.wIP_ManualMatching, Config.iTimeout * 3, true);

            mTime.StopTimer(iMatchManually_Open_Imp2);
            mLog.LogInfo(iMatchManually_Open_Imp2, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("sDataFileRecords", "");
            dic.Add("sWarehouseRecords", "");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("AcceptSelectedDataFile_AsNew", "");
            dic.Add("Close", "Click");
            pData._IP_MatchManually(dic);


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
            mTime.StopTimer(iFindMatch_Imp2);
            mLog.LogInfo(iFindMatch_Imp2, MyPerformanceCounter.Memory_Private);


            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "");
                dic.Add("Unique_UniqueMatch_Num", "300");
                dic.Add("Unique_MultipleMatches_Num", "");
                dic.Add("Duplicate_NoMatch_Num", "");
                dic.Add("Duplicate_UniqueMatch_Num", "");
                dic.Add("Duplicate_MultipleMatches_Num", "");
                dic.Add("Warehouse_NoMatch_Num", "1720");
                pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "");
                dic.Add("Unique_UniqueMatch_Num", "2000");
                dic.Add("Unique_MultipleMatches_Num", "");
                dic.Add("Duplicate_NoMatch_Num", "");
                dic.Add("Duplicate_UniqueMatch_Num", "");
                dic.Add("Duplicate_MultipleMatches_Num", "");
                dic.Add("Warehouse_NoMatch_Num", "11100");
                pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);
            }


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
            mTime.StopTimer(iUniqueMatch_AcceptMatched_Imp2);
            mLog.LogInfo(iUniqueMatch_AcceptMatched_Imp2, MyPerformanceCounter.Memory_Private);

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

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);


            pData._SelectTab("Matching");
            mTime.StopTimer(iSaveToWarehouse_Imp2);
            mLog.LogInfo(iSaveToWarehouse_Imp2, MyPerformanceCounter.Memory_Private);



            #endregion



            #region Import3Pen


            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Import3Pen");
            pData._TreeViewSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "DEDataAdmin_2015RF2KTabs.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("SingleTabPerRecordFile_cbo", "Pen2015RF");
                dic.Add("Preview", "");
                pData._PopVerify_IP_SelectFile(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "GBigDataAdmin_2015RFTabs.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                pData._SelectTab("Select File");

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("SingleTabPerRecordFile_cbo", "Pen2015RF");
                dic.Add("Preview", "");
                pData._PopVerify_IP_SelectFile(dic);
            }


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("SingleTabPerRecordFile_cbo", "");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_SelectFile(dic);

            pData._SelectTab("Select File");

            mTime.StopTimer(iSelectFile_Preview_Imp3);
            mLog.LogInfo(iSelectFile_Preview_Imp3, MyPerformanceCounter.Memory_Private);



            pData._SelectTab("Validate & Load");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("CorrectionImportForAdmin", "");
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
            mTime.StopTimer(iValidateAndLoad_Imp3);
            mLog.LogInfo(iValidateAndLoad_Imp3, MyPerformanceCounter.Memory_Private);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Status", "STAGED");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("CorrectionImportForAdmin", "");
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
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            pData._SelectTab("Pre Matching Derivations");

            mTime.StopTimer(iPMD_CalcAndPreview_Imp3);
            mLog.LogInfo(iPMD_CalcAndPreview_Imp3, MyPerformanceCounter.Memory_Private);


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

            mTime.StopTimer(iPMD_SaveToStaging_Imp3);
            mLog.LogInfo(iPMD_SaveToStaging_Imp3, MyPerformanceCounter.Memory_Private);



            pData._SelectTab("Matching");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "Click");
            dic.Add("FindMatches", "");
            pData._PopVerify_IP_Matching(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Yes", "");
            pData._PopVerify_CK_Warning_Popup(dic);

            _gLib._Exists("ManualMatching", pData.wIP_ManualMatching, Config.iTimeout * 3, true);

            mTime.StopTimer(iMatchManually_Open_Imp3);
            mLog.LogInfo(iMatchManually_Open_Imp3, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("sDataFileRecords", "");
            dic.Add("sWarehouseRecords", "");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("AcceptSelectedDataFile_AsNew", "");
            dic.Add("Close", "Click");
            pData._IP_MatchManually(dic);


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
            mTime.StopTimer(iFindMatch_Imp3);
            mLog.LogInfo(iFindMatch_Imp3, MyPerformanceCounter.Memory_Private);


            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "");
                dic.Add("Unique_UniqueMatch_Num", "400");
                dic.Add("Unique_MultipleMatches_Num", "");
                dic.Add("Duplicate_NoMatch_Num", "");
                dic.Add("Duplicate_UniqueMatch_Num", "");
                dic.Add("Duplicate_MultipleMatches_Num", "");
                dic.Add("Warehouse_NoMatch_Num", "1620");
                pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "");
                dic.Add("Unique_UniqueMatch_Num", "2400");
                dic.Add("Unique_MultipleMatches_Num", "");
                dic.Add("Duplicate_NoMatch_Num", "");
                dic.Add("Duplicate_UniqueMatch_Num", "");
                dic.Add("Duplicate_MultipleMatches_Num", "");
                dic.Add("Warehouse_NoMatch_Num", "10700");
                pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);
            }

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
            mTime.StopTimer(iUniqueMatch_AcceptMatched_Imp3);
            mLog.LogInfo(iUniqueMatch_AcceptMatched_Imp3, MyPerformanceCounter.Memory_Private);

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

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);


            pData._SelectTab("Matching");
            mTime.StopTimer(iSaveToWarehouse_Imp3);
            mLog.LogInfo(iSaveToWarehouse_Imp3, MyPerformanceCounter.Memory_Private);



            #endregion



            #region Import4Orphans


            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Import4Orphans");
            pData._TreeViewSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "DEDataAdmin_2015RF2KTabs.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("SingleTabPerRecordFile_cbo", "Orphans2015RF");
                dic.Add("Preview", "");
                pData._PopVerify_IP_SelectFile(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "GBigDataAdmin_2015RFTabs.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                pData._SelectTab("Select File");

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("SingleTabPerRecordFile_cbo", "Orphans2015RF");
                dic.Add("Preview", "");
                pData._PopVerify_IP_SelectFile(dic);
            }


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("SingleTabPerRecordFile_cbo", "");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_SelectFile(dic);

            pData._SelectTab("Select File");

            mTime.StopTimer(iSelectFile_Preview_Imp4);
            mLog.LogInfo(iSelectFile_Preview_Imp4, MyPerformanceCounter.Memory_Private);



            pData._SelectTab("Validate & Load");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("CorrectionImportForAdmin", "");
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
            mTime.StopTimer(iValidateAndLoad_Imp4);
            mLog.LogInfo(iValidateAndLoad_Imp4, MyPerformanceCounter.Memory_Private);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Status", "STAGED");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("CorrectionImportForAdmin", "");
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
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            pData._SelectTab("Pre Matching Derivations");

            mTime.StopTimer(iPMD_CalcAndPreview_Imp4);
            mLog.LogInfo(iPMD_CalcAndPreview_Imp4, MyPerformanceCounter.Memory_Private);


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

            mTime.StopTimer(iPMD_SaveToStaging_Imp4);
            mLog.LogInfo(iPMD_SaveToStaging_Imp4, MyPerformanceCounter.Memory_Private);



            pData._SelectTab("Matching");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "Click");
            dic.Add("FindMatches", "");
            pData._PopVerify_IP_Matching(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Yes", "");
            pData._PopVerify_CK_Warning_Popup(dic);

            _gLib._Exists("ManualMatching", pData.wIP_ManualMatching, Config.iTimeout * 3, true);

            mTime.StopTimer(iMatchManually_Open_Imp4);
            mLog.LogInfo(iMatchManually_Open_Imp4, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("sDataFileRecords", "");
            dic.Add("sWarehouseRecords", "");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("AcceptSelectedDataFile_AsNew", "");
            dic.Add("Close", "Click");
            pData._IP_MatchManually(dic);


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
            mTime.StopTimer(iFindMatch_Imp4);
            mLog.LogInfo(iFindMatch_Imp4, MyPerformanceCounter.Memory_Private);


            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "");
                dic.Add("Unique_UniqueMatch_Num", "100");
                dic.Add("Unique_MultipleMatches_Num", "");
                dic.Add("Duplicate_NoMatch_Num", "");
                dic.Add("Duplicate_UniqueMatch_Num", "");
                dic.Add("Duplicate_MultipleMatches_Num", "");
                dic.Add("Warehouse_NoMatch_Num", "1920");
                pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "");
                dic.Add("Unique_UniqueMatch_Num", "500");
                dic.Add("Unique_MultipleMatches_Num", "");
                dic.Add("Duplicate_NoMatch_Num", "");
                dic.Add("Duplicate_UniqueMatch_Num", "");
                dic.Add("Duplicate_MultipleMatches_Num", "");
                dic.Add("Warehouse_NoMatch_Num", "12600");
                pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);
            }


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
            mTime.StopTimer(iUniqueMatch_AcceptMatched_Imp4);
            mLog.LogInfo(iUniqueMatch_AcceptMatched_Imp4, MyPerformanceCounter.Memory_Private);

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

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);


            pData._SelectTab("Matching");
            mTime.StopTimer(iSaveToWarehouse_Imp4);
            mLog.LogInfo(iSaveToWarehouse_Imp4, MyPerformanceCounter.Memory_Private);



            #endregion



            #region Import5Others


            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Import5OtherRet");
            pData._TreeViewSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Import5Others");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "DEDataAdmin_2015RF2KTabs.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);



                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("SingleTabPerRecordFile_cbo", "InOtherStatus2015RF");
                dic.Add("Preview", "");
                pData._PopVerify_IP_SelectFile(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "GBigDataAdmin_2015RFTabs.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                pData._SelectTab("Select File");

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("SingleTabPerRecordFile_cbo", "D2015RF");
                dic.Add("Preview", "");
                pData._PopVerify_IP_SelectFile(dic);
            }


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("SingleTabPerRecordFile_cbo", "");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_SelectFile(dic);

            pData._SelectTab("Select File");

            mTime.StopTimer(iSelectFile_Preview_Imp5);
            mLog.LogInfo(iSelectFile_Preview_Imp5, MyPerformanceCounter.Memory_Private);



            pData._SelectTab("Validate & Load");

            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("CorrectionImportForAdmin", "");
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
            mTime.StopTimer(iValidateAndLoad_Imp5);
            mLog.LogInfo(iValidateAndLoad_Imp5, MyPerformanceCounter.Memory_Private);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Status", "STAGED");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("CorrectionImportForAdmin", "");
            dic.Add("ValidateData", "");
            dic.Add("LoadData", "");
            dic.Add("ValidateAndLoadData", "");
            pData._PopVerify_IP_ValidateAndLoad(dic);

            pData._SelectTab("Pre Matching Derivations");



            pData._SelectTab("Matching");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "Click");
            dic.Add("FindMatches", "");
            pData._PopVerify_IP_Matching(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Yes", "");
            pData._PopVerify_CK_Warning_Popup(dic);

            _gLib._Exists("ManualMatching", pData.wIP_ManualMatching, Config.iTimeout * 3, true);

            mTime.StopTimer(iMatchManually_Open_Imp5);
            mLog.LogInfo(iMatchManually_Open_Imp5, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("sDataFileRecords", "");
            dic.Add("sWarehouseRecords", "");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("AcceptSelectedDataFile_AsNew", "");
            dic.Add("Close", "Click");
            pData._IP_MatchManually(dic);


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
            mTime.StopTimer(iFindMatch_Imp5);
            mLog.LogInfo(iFindMatch_Imp5, MyPerformanceCounter.Memory_Private);


            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "");
                dic.Add("Unique_UniqueMatch_Num", "14");
                dic.Add("Unique_MultipleMatches_Num", "");
                dic.Add("Duplicate_NoMatch_Num", "");
                dic.Add("Duplicate_UniqueMatch_Num", "");
                dic.Add("Duplicate_MultipleMatches_Num", "");
                dic.Add("Warehouse_NoMatch_Num", "2006");
                pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "250");
                dic.Add("Unique_UniqueMatch_Num", "12970");
                dic.Add("Unique_MultipleMatches_Num", "");
                dic.Add("Duplicate_NoMatch_Num", "");
                dic.Add("Duplicate_UniqueMatch_Num", "");
                dic.Add("Duplicate_MultipleMatches_Num", "");
                dic.Add("Warehouse_NoMatch_Num", "130");
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
                mTime.StopTimer(iUniqueMatch_AcceptNew_Imp5);
                mLog.LogInfo(iUniqueMatch_AcceptNew_Imp5, MyPerformanceCounter.Memory_Private);


            }




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
            mTime.StopTimer(iUniqueMatch_AcceptMatched_Imp5);
            mLog.LogInfo(iUniqueMatch_AcceptMatched_Imp5, MyPerformanceCounter.Memory_Private);

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

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);


            pData._SelectTab("Matching");
            mTime.StopTimer(iSaveToWarehouse_Imp5);
            mLog.LogInfo(iSaveToWarehouse_Imp5, MyPerformanceCounter.Memory_Private);



            #endregion


            #region Simple Import & Derivations & BatchUpdate


            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "Simple Imports");
            dic.Add("Level_3", "SimpleImp1");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "DEDataAdmin2015RF2KSimple.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "GBigDataAdmin2015RFSimple.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);
            }


            pMain._SelectTab(sRF_DataServiceName);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "");
            dic.Add("Process", "Click");
            pData._PopVerify_SimpleImport(dic);

            pMain._SelectTab(sRF_DataServiceName);
            mTime.StopTimer(iSimpleImport_Process);
            mLog.LogInfo(iSimpleImport_Process, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Run Derivations in Batch");
            pData._TreeViewRightSelect(dic);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Derivation", "All");
            dic.Add("Calculate", "Click");
            pData._PopVerify_DG_RunDerivationsInBatch(dic);


            _gLib._Exists("DerivationBatchRun", pData.wDG_DerivationBatchRun, Config.iTimeout * 10, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationsBatchRun(dic);

            pMain._SelectTab(sRF_DataServiceName);
            mTime.StopTimer(iDerivation_RunBatch);
            mLog.LogInfo(iDerivation_RunBatch, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "(9)DerGrp3Extracts");
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
            dic.Add("SelectSampleRecords_Formula", "");
            dic.Add("SelectSampleRecords_Accept", "");
            dic.Add("SelectSampleRecords_Apply", "");
            dic.Add("PrintAll", "");
            dic.Add("PrintToFile", "Click");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_VU_PrintToFile_Popup(dic);

            mTime.StopTimer(iPrintToFile_Grp3);
            mLog.LogInfo(iPrintToFile_Grp3, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "(10)DerGrp4MixedSet");
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
            dic.Add("SelectSampleRecords_Formula", "");
            dic.Add("SelectSampleRecords_Accept", "");
            dic.Add("SelectSampleRecords_Apply", "");
            dic.Add("PrintAll", "");
            dic.Add("PrintToFile", "Click");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_VU_PrintToFile_Popup(dic);

            mTime.StopTimer(iPrintToFile_Grp4);
            mLog.LogInfo(iPrintToFile_Grp4, MyPerformanceCounter.Memory_Private);

            pMain._SelectTab(sRF_DataServiceName);

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

            pData.pOutputManager._SaveAs(sOutputDir + "PrintAll_Grp4.xlsx");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_Complete_Popup(dic);

            mTime.StopTimer(iPrintAll_Grp4);
            mLog.LogInfo(iPrintAll_Grp4, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "Batch Update");
            dic.Add("Level_3", "BatchUpdate1CreditsText");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "Click");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);


            _gLib._SetSyncUDWin("OK", pData.wSelectInputFields.wOK.btnOK, "Click", 0);




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

            pMain._SelectTab(sRF_DataServiceName);

            if (bSmall_Data)
                pData._BU_PasteValues(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\DE_Timing_Data_VR\BatchUpdateInput1DE500.xlsx");
                ////////////////_gLib._MsgBox("Warning", "Please copy/paste 500 rows value from " + Environment.NewLine + @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\DE_Timing_Data_VR\BatchUpdateInput1DE500.xlsx" + Environment.NewLine + "and Paste into BatchUpdate grid!");
            else
                pData._BU_PasteValues(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\DE_Timing_Data_VR\BatchUpdateInput1DE.xlsx");
                ////////////////////_gLib._MsgBox("Warning", "Please copy/paste 1000 rows value from " + Environment.NewLine + @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\DE_Timing_Data_VR\BatchUpdateInput1DE.xlsx" + Environment.NewLine + "and Paste into BatchUpdate grid!");


            pMain._SelectTab(sRF_DataServiceName);


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

            pMain._SelectTab(sRF_DataServiceName);
            mTime.StopTimer(iBatchUpdate_SaveToWarhouse);
            mLog.LogInfo(iBatchUpdate_SaveToWarhouse, MyPerformanceCounter.Memory_Private);



            #endregion



            #region CurrentView & ViewUpdate & Checks & Reports



            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
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

            pMain._SelectTab(sRF_DataServiceName);

            mTime.StopTimer(iCV_Preview_BeforeView1);
            mLog.LogInfo(iCV_Preview_BeforeView1, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "View & Update");
            dic.Add("Level_3", "View1ImportStatus");
            pData._TreeViewSelect(dic);

         

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Filter", "");
            dic.Add("Apply", "Click");
            pData._PopVerify_ViewUpdate(dic);

            pMain._SelectTab(sRF_DataServiceName);
            mTime.StopTimer(iVU_Apply_View1);
            mLog.LogInfo(iVU_Apply_View1, MyPerformanceCounter.Memory_Private); dic.Clear();


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("Apply", "");
            dic.Add("GenerateSummary", "");
            dic.Add("PrintAll", "");
            dic.Add("PrintToFile", "Click");
            dic.Add("ViewAllManualChanges", "");
            pData._PopVerify_ViewUpdate(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_VU_PrintToFile_Popup(dic);

            mTime.StopTimer(iVU_PrintToFile_View1);
            mLog.LogInfo(iVU_PrintToFile_View1, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
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

            pMain._SelectTab(sRF_DataServiceName);

            mTime.StopTimer(iCV_Preview_BeforeView2);
            mLog.LogInfo(iCV_Preview_BeforeView2, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "View & Update");
            dic.Add("Level_3", "View2SimpleQuery");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("SimpleQuery", "True");
            dic.Add("SimpleQuery_Field", "PayHistoryL1CurrentYear_C");
            dic.Add("SimpleQuery_Operator", "<");
            dic.Add("Simplequery_Value", "88888");
            dic.Add("Apply", "");
            dic.Add("GenerateSummary", "");
            dic.Add("PrintAll", "");
            dic.Add("PrintToFile", "");
            dic.Add("ViewAllManualChanges", "");
            pData._PopVerify_ViewUpdate(dic);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Filter", "");
            dic.Add("Apply", "Click");
            pData._PopVerify_ViewUpdate(dic);

            pMain._SelectTab(sRF_DataServiceName);
            mTime.StopTimer(iVU_Apply_View2);
            mLog.LogInfo(iVU_Apply_View2, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("Apply", "");
            dic.Add("GenerateSummary", "");
            dic.Add("PrintAll", "");
            dic.Add("PrintToFile", "Click");
            dic.Add("ViewAllManualChanges", "");
            pData._PopVerify_ViewUpdate(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_VU_PrintToFile_Popup(dic);

            mTime.StopTimer(iVU_PrintToFile_View2);
            mLog.LogInfo(iVU_PrintToFile_View2, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "View & Update");
            dic.Add("Level_3", "Last Session");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "True");
            dic.Add("StandardorCustomFilter_cbo", "<No Filter>");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);


            pMain._SelectTab(sRF_DataServiceName);
            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Filter", "");
            dic.Add("Apply", "Click");
            pData._PopVerify_ViewUpdate(dic);

            pMain._SelectTab(sRF_DataServiceName);
            mTime.StopTimer(iVU_Apply_LastSession);
            mLog.LogInfo(iVU_Apply_LastSession, MyPerformanceCounter.Memory_Private);


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


            pData.pOutputManager._SaveAs(sOutputDir + "VU_PrintAll_LastSession.xlsx");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_Complete_Popup(dic);

            mTime.StopTimer(iVU_PrintAll_LastSession);
            mLog.LogInfo(iVU_PrintAll_LastSession, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "Checks");
            pData._TreeViewSelect(dic);

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
            dic.Add("AnnuitantBenefit_T", "");
            dic.Add("BeneficiaryBenefit_T", "");
            dic.Add("Pay_T", "");
            dic.Add("Pay_L", "PayHistoryL1CurrentYear_P");
            dic.Add("Service_T", "");
            dic.Add("Service_L", "BSERVL_P");
            dic.Add("CertainPeriod_T", "");
            dic.Add("Continuation_T", "");
            dic.Add("OK", "Click");
            pData._PopVerify_CK_StandardInputs_Part1_DE(dic); 



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


            pMain._SelectTab(sRF_DataServiceName);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "Click");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);


            pMain._SelectTab(sRF_DataServiceName);
            mTime.StopTimer(iCheck_ApplyAll);
            mLog.LogInfo(iCheck_ApplyAll, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("CheckName", "Certain Period Invalid");
            dic.Add("iSearchDownNum", "10");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, false, false);

            //////////////////////////////if (bSmall_Data)
            //////////////////////////////    _gLib._MsgBox("Benefit Checks => Certain Period Invalid", "Please Click failed Number <1704> in this Check and click OK to keep testing!");
            //////////////////////////////else
            //////////////////////////////    _gLib._MsgBox("Benefit Checks => Certain Period Invalid", "Please Click failed Number <11070> in this Check and click OK to keep testing!");

            if (bSmall_Data)
                pData._CK_CheckGrip_ClickLink_Fail(sRF_DataServiceName, "Benefit Checks => Certain Period Invalid", "1704");
            else
                pData._CK_CheckGrip_ClickLink_Fail(sRF_DataServiceName, "Benefit Checks => Certain Period Invalid", "11070");



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
            dic.Add("CheckName", "DifferentHireMembershipD");
            dic.Add("iSearchDownNum", "10");
            dic.Add("Include", "");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, false);

            ////////////////////////////if (bSmall_Data)
            ////////////////////////////    _gLib._MsgBox("Custom Checks => DifferentHireMembershipD", "Please Click failed Number <2020> in this Check and click OK to keep testing!");
            ////////////////////////////else
            ////////////////////////////    _gLib._MsgBox("Custom Checks => DifferentHireMembershipD", "Please Click failed Number <13100> in this Check and click OK to keep testing!");


            if (bSmall_Data)
                pData._CK_CheckGrip_ClickLink_Fail(sRF_DataServiceName, "Custom Checks => DifferentHireMembershipD", "2020");
            else
                pData._CK_CheckGrip_ClickLink_Fail(sRF_DataServiceName, "Custom Checks => DifferentHireMembershipD", "13100");


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
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "Reports");
            dic.Add("Level_3", "Rep1Plugs");
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


            mTime.StopTimer(iGenerateReport_Plug);
            mLog.LogInfo(iGenerateReport_Plug, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "Reports");
            dic.Add("Level_3", "Rep2Query");
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


            mTime.StopTimer(iGenerateReport_Query);
            mLog.LogInfo(iGenerateReport_Query, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "Status Matrix");
            pData._TreeViewSelect(dic);

            pMain._SelectTab(sRF_DataServiceName);
            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CreateMatrix", "Click");
            pData._PopVerify_StatusMatrix(dic);

            pMain._SelectTab(sRF_DataServiceName);
            mTime.StopTimer(iGenerateReport_StatusMetrix);
            mLog.LogInfo(iGenerateReport_StatusMetrix, MyPerformanceCounter.Memory_Private);




            #endregion


            #region Snapshots & Consumption

            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "Snap1ULDAll");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "MemberSystemID");
            pData._TreeViewSelect_Snapshots(dic, false);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "Click");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            pMain._SelectTab(sRF_DataServiceName);
            mTime.StopTimer(iSnapshot_Preview_All);
            mLog.LogInfo(iSnapshot_Preview_All, MyPerformanceCounter.Memory_Private);

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

            pMain._SelectTab(sRF_DataServiceName);
            mTime.StopTimer(iSnapshot_Publish_All);
            mLog.LogInfo(iSnapshot_Publish_All, MyPerformanceCounter.Memory_Private);




            mTime.StartTimer();

            string sSnapshotHisotryFileName = "";

            if (bSmall_Data)
                sSnapshotHisotryFileName = sOutputDir_SnapshotExtract + _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString() + "_" + "SnapshotExtract_Snapshot2015ULDAll_Small.xlsx";
            else
                sSnapshotHisotryFileName = sOutputDir_SnapshotExtract + _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString() + "_" + "SnapshotExtract_Snapshot2015ULDAll_Large.xlsx";

            pData._ts_SP_CreateExtract(sSnapshotHisotryFileName);



            mTime.StopTimer(iSnapshot_Extract_All);
            mLog.LogInfo(iSnapshot_Extract_All, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Snapshot2015Consumption");
            dic.Add("UseLatestDate", "False");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);



            dic.Clear();
            dic.Add("Level_1", "Include all");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Administration");
            pData._TreeViewSelect_Snapshots(dic, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            pData._TreeViewSelect_Snapshots_PriorView(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Administration");
            pData._TreeViewSelect_Snapshots_PriorView(dic, false);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "Click");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            pMain._SelectTab(sRF_DataServiceName);
            mTime.StopTimer(iSnapshot_Preview_2015Consumption);
            mLog.LogInfo(iSnapshot_Preview_2015Consumption, MyPerformanceCounter.Memory_Private);

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

            pMain._SelectTab(sRF_DataServiceName);
            mTime.StopTimer(iSnapshot_Publish_2015Consumption);
            mLog.LogInfo(iSnapshot_Publish_2015Consumption, MyPerformanceCounter.Memory_Private);




            mTime.StartTimer();

            pData._ts_SP_CreateExtract(sOutputDir + "SnapshotExtract_Snapshot2015Consumption.xlsx");

            mTime.StopTimer(iSnapshot_Extract_2015Consumption);
            mLog.LogInfo(iSnapshot_Extract_2015Consumption, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "Output Manager");
            pData._TreeViewSelect(dic);

            if (_gLib._Exists("Save", pData.wOM_DataService_Popup, 3, 1, false))
                _gLib._SetSyncUDWin("NO", pData.wOM_DataService_Popup.wNO.btnNo, "Click", 0);

            pMain._SelectTab("Data Output Manager");


            mTime.StartTimer();

            _gLib._SetSyncUDWin("", pData.wRetirementStudio.wOM_ExportAll.btn, "Click", 0);

            pData.pOutputManager._SaveAs(sOutputDir + "GenerateConsolidatedOuput.xls");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_Complete_Popup(dic);

            mTime.StopTimer(iGenerateConsolidatedOuput);
            mLog.LogInfo(iGenerateConsolidatedOuput, MyPerformanceCounter.Memory_Private);

            pMain._SelectTab(sRF_DataServiceName);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Home");

        

            ////////////////////////_gLib._MsgBox("Warning!", "Please manually select the Client in Studio-> Home -> All Services -> " + Config.sClientName + "->" + Config.sPlanName + "->PensionValuations" + Environment.NewLine + Environment.NewLine
            ////////////////////////    + "Click OK to keep testing!");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "PensionValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "PensionValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            pMain._SelectTab("Home");




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "True");
            dic.Add("Name", sValServiceName);
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "2015");
            dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("SelectAllVO", "Click");
            dic.Add("DeselectAll", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", sValServiceName);
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab(sValServiceName);

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
            dic.Add("SnapshotName", "Snapshot2015Consumption");
            dic.Add("SnapshotName_Parent", sRF_DataServiceName);
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);


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
            dic.Add("ImportDataandApplyMapping", "Click");
            dic.Add("CheckVOImportPopup", "True");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);



            pMain._SelectTab("Participant DataSet");
            mTime.StopTimer(iConsumeSnapshot);
            mLog.LogInfo(iConsumeSnapshot, MyPerformanceCounter.Memory_Private);

            pMain._SelectTab(sValServiceName);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "ParticipantData");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", sRF_DataServiceName);
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("Level_1", sRF_DataServiceName);
            dic.Add("Level_2", "Undo");
            pData._TreeViewSelect(dic);



            pData._ts_SearchUndoItem("FileImportFinalizeMatching for Import1Actives", 0);

            _gLib._SetSyncUDWin("Undo", pData.wRetirementStudio.wUndo_Undo.btnUndo, "Click", 0);



            _gLib._SetSyncUDWin_ByClipboard("Undo comments", pData.wUndo_ConfirmUndo.wComments.txtComments, "undo all", 0);

            mTime.StartTimer();

            _gLib._SetSyncUDWin("OK", pData.wUndo_ConfirmUndo.wOK.btnOK, "Click", 0);


            pMain._SelectTab(sRF_DataServiceName);
            mTime.StopTimer(iUndo_All);
            mLog.LogInfo(iUndo_All, MyPerformanceCounter.Memory_Private);



            mLog.LogInfo(iTimeEnd, DateTime.Now.ToString());




            #endregion



            _gLib._MsgBox("Congratulations!", "Testing is Done!");
            _gLib._MsgBox("", "Please delete the valuation service manually!");


            Environment.Exit(0);



            _gLib._MsgBox("Warning!", "You are going to run test with bSmallData = " + bSmall_Data.ToString() + ", and Rollforward data service name as: " + sRF_DataServiceName);


            #region D2014Cnv - Add Plan/Data Service - No Timing



            pMain._SetLanguageAndRegional();

            pMain._Initialize();

            pMain._SelectTab("PM Tools");


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



            _gLib._MsgBox("Mannual Interaction", "Please mannually click on plan: " + Config.sClientName + ">>" + Config.sPlanName);

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("AddVOtoRegistry", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EnterVOShortName", "VO10Jubilee");
            dic.Add("ConfirmVOShortName", "VO10Jubilee");
            dic.Add("VOLongName", "VO10Jubilee");
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

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("AddVOtoRegistry", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EnterVOShortName", "VO1PenDirDB");
            dic.Add("ConfirmVOShortName", "VO1PenDirDB");
            dic.Add("VOLongName", "VO1PenDirDefinedDB");
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


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("AddVOtoRegistry", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EnterVOShortName", "VO2PenDirDBC");
            dic.Add("ConfirmVOShortName", "VO2PenDirDBC");
            dic.Add("VOLongName", "VO2PenDirDefinedBCntr");
            dic.Add("VOClass", "Pension");
            dic.Add("FundingVehicle", "Direct Promise");
            dic.Add("TypeOfPromise", "Defined Benefit with Contribution");
            dic.Add("Sponsor", "Employer");
            dic.Add("PSVCoverage", "True");
            dic.Add("ExculdeWidowers", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccounting", "True");
            dic.Add("Apply30g", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_CreateNewVO(dic);



            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("AddVOtoRegistry", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EnterVOShortName", "VO3PenDirDCMin");
            dic.Add("ConfirmVOShortName", "VO3PenDirDCMin");
            dic.Add("VOLongName", "VO3PenDirDefinedCntrMin");
            dic.Add("VOClass", "Pension");
            dic.Add("FundingVehicle", "Direct Promise");
            dic.Add("TypeOfPromise", "Defined Contribution with Minimum");
            dic.Add("Sponsor", "Mixed");
            dic.Add("PSVCoverage", "True");
            dic.Add("ExculdeWidowers", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccounting", "True");
            dic.Add("Apply30g", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_CreateNewVO(dic);


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("AddVOtoRegistry", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EnterVOShortName", "VO4SupportFDB");
            dic.Add("ConfirmVOShortName", "VO4SupportFDB");
            dic.Add("VOLongName", "VO4SupportFundDefinedBen");
            dic.Add("VOClass", "Pension");
            dic.Add("FundingVehicle", "Support Fund");
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


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("AddVOtoRegistry", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EnterVOShortName", "VO5SupportFDCM");
            dic.Add("ConfirmVOShortName", "VO5SupportFDCM");
            dic.Add("VOLongName", "VO5SupportFundDCM");
            dic.Add("VOClass", "Pension");
            dic.Add("FundingVehicle", "Support Fund");
            dic.Add("TypeOfPromise", "Defined Contribution with Minimum");
            dic.Add("Sponsor", "Employee");
            dic.Add("PSVCoverage", "");
            dic.Add("ExculdeWidowers", "True");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccounting", "True");
            dic.Add("Apply30g", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CreateNewVO(dic);



            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("AddVOtoRegistry", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EnterVOShortName", "VO6SupportFDBC");
            dic.Add("ConfirmVOShortName", "VO6SupportFDBC");
            dic.Add("VOLongName", "VO6SupportFundDBCM..");
            dic.Add("VOClass", "Pension");
            dic.Add("FundingVehicle", "Support Fund");
            dic.Add("TypeOfPromise", "Defined Benefit with Contribution");
            dic.Add("Sponsor", "Mixed");
            dic.Add("PSVCoverage", "True");
            dic.Add("ExculdeWidowers", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccounting", "True");
            dic.Add("Apply30g", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_CreateNewVO(dic);


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("AddVOtoRegistry", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EnterVOShortName", "VO7DeathSvc");
            dic.Add("ConfirmVOShortName", "VO7DeathSvc");
            dic.Add("VOLongName", "VO7DeathSvc");
            dic.Add("VOClass", "Death-In-Service");
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


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("AddVOtoRegistry", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EnterVOShortName", "VO8DeathSvc");
            dic.Add("ConfirmVOShortName", "VO8DeathSvc");
            dic.Add("VOLongName", "VO8DeathSvc");
            dic.Add("VOClass", "Death-In-Service");
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


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("AddVOtoRegistry", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EnterVOShortName", "VO9Jubilee");
            dic.Add("ConfirmVOShortName", "VO9Jubilee");
            dic.Add("VOLongName", "VO9Jubilee");
            dic.Add("VOClass", "Jubilee");
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

            _gLib._MsgBox("Warning!", "Please manually select the Client in Studio-> Home -> All Services -> " + Config.sClientName + "->" + Config.sPlanName + "->ParticipantData" + Environment.NewLine + Environment.NewLine
      + "Click OK to keep testing!");

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "D2014Cnv");
            dic.Add("EffectiveDate", "31.12.2014");
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
            dic.Add("ServiceToOpen", "D2014Cnv");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            pData._ts_UpdateIncludedVOs("VO10Jubilee", true);
            pData._ts_UpdateIncludedVOs("VO1PenDirDB", true);
            pData._ts_UpdateIncludedVOs("VO2PenDirDBC", true);
            pData._ts_UpdateIncludedVOs("VO3PenDirDCMin", true);
            pData._ts_UpdateIncludedVOs("VO4SupportFDB", true);
            pData._ts_UpdateIncludedVOs("VO5SupportFDCM", true);
            pData._ts_UpdateIncludedVOs("VO6SupportFDBC", true);
            pData._ts_UpdateIncludedVOs("VO7DeathSvc", true);
            pData._ts_UpdateIncludedVOs("VO8DeathSvc", true);
            pData._ts_UpdateIncludedVOs("VO9Jubilee", true);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("D2014Cnv");


            #endregion


            #region D2014Cnv - Current View & Upload - No Timing



            dic.Clear();
            dic.Add("Level_1", "D2014Cnv");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);

            pMain._SelectTab("D2014Cnv");

            pData._CV_Initialize("Personal Information", "Administration", 1, 6, "StatusHST");

            pData._CV_ClickEdit("StatusHST", true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("R1C1", "Act");
            dic.Add("R1C2", "10");
            dic.Add("R2C1", "ActDis");
            dic.Add("R2C2", "14");
            dic.Add("R3C1", "ActDis1");
            dic.Add("R3C2", "11");
            dic.Add("R4C1", "ActDis2");
            dic.Add("R4C2", "12");
            dic.Add("R5C1", "ActDis3");
            dic.Add("R5C2", "13");
            dic.Add("R6C1", "Def");
            dic.Add("R6C2", "20");
            dic.Add("R7C1", "DefDis");
            dic.Add("R7C2", "24");
            dic.Add("R8C1", "Orph");
            dic.Add("R8C2", "80");
            dic.Add("R9C1", "Ret");
            dic.Add("R9C2", "50");
            dic.Add("R10C1", "RetBen");
            dic.Add("R10C2", "70");
            dic.Add("R11C1", "RetDis");
            dic.Add("R11C2", "54");
            dic.Add("R12C1", "RetMBen");
            dic.Add("R12C2", "56");
            dic.Add("R13C1", "XDec");
            dic.Add("R13C2", "91");
            dic.Add("R14C1", "");
            dic.Add("R14C2", "");
            dic.Add("OK", "Click");
            pData._PopVerify_CV_StatusUSCTable(dic);

            pMain._SelectTab("D2014Cnv");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EditSelection", "");
            dic.Add("AddSingleLabel", "");
            dic.Add("AddMultipleLabels", "Click");
            pData._PopVerify_CurrentView(dic);

            _gLib._Exists("Add Multiple Label", pData.wCV_AddLabels, 0, true);



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


            _gLib._SetSyncUDWin("OK", pData.wCV_AddLabels.wOK.btnOK, "Click", 0);

            pMain._SelectTab("D2014Cnv");

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("D2014Cnv");
            pMain._Home_ToolbarClick_Top(false);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "D2014Cnv");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("D2014Cnv");

            dic.Clear();
            dic.Add("Level_1", "D2014Cnv");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);

            pMain._SelectTab("D2014Cnv");

            pData._CV_Initialize("Personal Information", "Work Fields", 1, 8, "WF1Dec");

            pData._CV_ClickEdit("WF1Dec", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Label", "");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "True");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_CV_AddLabel(dic);


            pData._CV_ClickEdit("WF2Int", true, 8);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Label", "");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "True");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_CV_AddLabel(dic);



            pData._CV_ClickEdit("WF3Date", true, 8);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Label", "");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "True");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_CV_AddLabel(dic);


            pData._CV_ClickEdit("WF4Text", true, 8);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Label", "");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "True");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_CV_AddLabel(dic);


            _gLib._MsgBox("Manual Interaction", "Please expand Personal Information -> Credits");

            pData._CV_ClickEdit("CreditsHistory1", true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Label", "");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "True");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_CV_AddLabel(dic);


            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("D2014Cnv");


            dic.Clear();
            dic.Add("Level_1", "D2014Cnv");
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

            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE_Timing_Data_VR\DEDataAdmin_2014Cnv2KTabs.xls");
                dic.Add("Open", "Click");
                dic.Add("Cancel", "");
                pMain._PopVerify_FileOpen(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE_Timing_Data_VR\GBigDataAdmin_2014CnvTabs.xls");
                dic.Add("Open", "Click");
                dic.Add("Cancel", "");
                pMain._PopVerify_FileOpen(dic);
            }


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);

            pMain._SelectTab("D2014Cnv");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "Click");
            dic.Add("Upload", "");
            pData._PopVerify_UploadData(dic);

            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE_Timing_Data_VR\DEDataAdmin_2014Cnv2KSimple.xls");
                dic.Add("Open", "Click");
                dic.Add("Cancel", "");
                pMain._PopVerify_FileOpen(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE_Timing_Data_VR\GBigDataAdmin_2014CnvSimple.xls");
                dic.Add("Open", "Click");
                dic.Add("Cancel", "");
                pMain._PopVerify_FileOpen(dic);
            }


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);

            pMain._SelectTab("D2014Cnv");




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "Click");
            dic.Add("Upload", "");
            pData._PopVerify_UploadData(dic);

            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE_Timing_Data_VR\DEDataAdmin_2015RF2KTabs.xls");
                dic.Add("Open", "Click");
                dic.Add("Cancel", "");
                pMain._PopVerify_FileOpen(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE_Timing_Data_VR\GBigDataAdmin_2015RFTabs.xls");
                dic.Add("Open", "Click");
                dic.Add("Cancel", "");
                pMain._PopVerify_FileOpen(dic);
            }


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);

            pMain._SelectTab("D2014Cnv");




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "Click");
            dic.Add("Upload", "");
            pData._PopVerify_UploadData(dic);

            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE_Timing_Data_VR\DEDataAdmin2015RF2KSimple.xls");
                dic.Add("Open", "Click");
                dic.Add("Cancel", "");
                pMain._PopVerify_FileOpen(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE_Timing_Data_VR\GBigDataAdmin2015RFSimple.xls");
                dic.Add("Open", "Click");
                dic.Add("Cancel", "");
                pMain._PopVerify_FileOpen(dic);
            }

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);

            pMain._SelectTab("D2014Cnv");




            #endregion


            #region D2014Cnv - Import1Actives - No Timing



            dic.Clear();
            dic.Add("Level_1", "D2014Cnv");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Import1Actives");
            dic.Add("FileType", "Excel file");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "DEDataAdmin_2014Cnv2KTabs.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("SingleTabPerRecordFile_cbo", "Actives2014_1200");
                dic.Add("Preview", "Click");
                pData._PopVerify_IP_SelectFile(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "GBigDataAdmin_2014CnvTabs.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("SingleTabPerRecordFile_cbo", "Actives2014_8K");
                dic.Add("Preview", "Click");
                pData._PopVerify_IP_SelectFile(dic);
            }


            pData._SelectTab("Mapping");

            pData._IP_Mapping_Initialize("Personal Information", "Custom Fields", 1, 0, 9, "CF1Decim");
            pData._IP_Mapping_MapField("CF1Decim", "SalaryPriorYear5", 12, true, 0);
            pData._IP_Mapping_MapField("CF2Integer", "ETY", 3, true, 0);
            pData._IP_Mapping_MapField("CustomF3Date", "BonusDate2", 19, true, 0);



            pData._IP_Mapping_Initialize("Personal Information", "Work Fields", 1, 0, 8, "WF1Dec_VOParent");
            pData._IP_Mapping_Initialize("Personal Information", "WF4Text_VOParent", 2, 0, 12, "WF4Text");
            pData._IP_Mapping_MapField("WF4Text_VO10Jubilee", "Division", 2, true, 0);
            pData._IP_Mapping_MapField("WF4Text_VO1PenDirDB", "Division", 2, true, 0);
            pData._IP_Mapping_MapField("WF4Text_VO2PenDirDBC", "OrgCode", 0, true, 0);
            pData._IP_Mapping_MapField("WF4Text_VO3PenDirDCMin", "Division", 2, true, 0);
            pData._IP_Mapping_MapField("WF4Text_VO4SupportFDB", "OrgCode", 0, true, 0);
            pData._IP_Mapping_MapField("WF4Text_VO5SupportFDCM", "Division", 2, true, 0);
            pData._IP_Mapping_MapField("WF4Text_VO6SupportFDBC", "OrgCode", 0, true, 0);
            pData._IP_Mapping_MapField("WF4Text_VO7DeathSvc", "Division", 2, true, 0);
            pData._IP_Mapping_MapField("WF4Text_VO8DeathSvc", "Division", 2, true, 0);
            pData._IP_Mapping_MapField("WF4Text_VO9Jubilee", "OrgCode", 0, true, 0);


            pData._IP_Mapping_Initialize("Personal Information", "WF3Date_VOParent", 2, 0, 11, "WF3Date");
            pData._IP_Mapping_MapField("WF3Date_VO10Jubilee", "BonusDate1", 11, true, 0);
            pData._IP_Mapping_MapField("WF3Date_VO1PenDirDB", "StatusDate1", 24, true, 0);
            pData._IP_Mapping_MapField("WF3Date_VO2PenDirDBC", "BonusDate10", 12, true, 0);
            pData._IP_Mapping_MapField("WF3Date_VO3PenDirDCMin", "BonusDate15", 17, true, 0);
            pData._IP_Mapping_MapField("WF3Date_VO4SupportFDB", "BonusDate16", 18, true, 0);
            pData._IP_Mapping_MapField("WF3Date_VO5SupportFDCM", "BonusDate2", 19, true, 0);
            pData._IP_Mapping_MapField("WF3Date_VO6SupportFDBC", "BonusDate3", 20, true, 0);
            pData._IP_Mapping_MapField("WF3Date_VO7DeathSvc", "StatusDate3", 26, true, 0);
            pData._IP_Mapping_MapField("WF3Date_VO8DeathSvc", "StatusDate5", 28, true, 0);
            pData._IP_Mapping_MapField("WF3Date_VO9Jubilee", "BonusDate4", 21, true, 0);


            pData._IP_Mapping_Initialize("Personal Information", "WF2Int_VOParent", 2, 0, 11, "WF2Int");
            pData._IP_Mapping_MapField("WF2Int_VO10Jubilee", "ELY", 0, true, 0);
            pData._IP_Mapping_MapField("WF2Int_VO1PenDirDB", "ETY", 3, true, 0);
            pData._IP_Mapping_MapField("WF2Int_VO2PenDirDBC", "ELY", 0, true, 0);
            pData._IP_Mapping_MapField("WF2Int_VO3PenDirDCMin", "ETY", 3, true, 0);
            pData._IP_Mapping_MapField("WF2Int_VO4SupportFDB", "ELY", 0, true, 0);
            pData._IP_Mapping_MapField("WF2Int_VO5SupportFDCM", "ETY", 3, true, 0);
            pData._IP_Mapping_MapField("WF2Int_VO6SupportFDBC", "ELY", 0, true, 0);
            pData._IP_Mapping_MapField("WF2Int_VO7DeathSvc", "ELY", 0, true, 0);
            pData._IP_Mapping_MapField("WF2Int_VO8DeathSvc", "ETY", 3, true, 0);
            pData._IP_Mapping_MapField("WF2Int_VO9Jubilee", "ELY", 21, true, 0);

            pData._IP_Mapping_Initialize("Personal Information", "WF1Dec_VOParent", 2, 0, 12, "WF1Dec");
            pData._IP_Mapping_MapField("WF1Dec_VO10Jubilee", "SalaryPriorYear12", 5, true, 0);
            pData._IP_Mapping_MapField("WF1Dec_VO1PenDirDB", "SalaryPriorYear11", 4, true, 0);
            pData._IP_Mapping_MapField("WF1Dec_VO2PenDirDBC", "SalaryPriorYear14", 7, true, 0);
            pData._IP_Mapping_MapField("WF1Dec_VO3PenDirDCMin", "SalaryPriorYear13", 6, true, 0);
            pData._IP_Mapping_MapField("WF1Dec_VO4SupportFDB", "SalaryPriorYear1", 2, true, 0);
            pData._IP_Mapping_MapField("WF1Dec_VO5SupportFDCM", "PAYPRYR1", 5, true, 0);
            pData._IP_Mapping_MapField("WF1Dec_VO6SupportFDBC", "PAYPRYR2", 6, true, 0);
            pData._IP_Mapping_MapField("WF1Dec_VO7DeathSvc", "SalaryPriorYear15", 8, true, 0);
            pData._IP_Mapping_MapField("WF1Dec_VO8DeathSvc", "SalaryPriorYear8", 15, true, 0);
            pData._IP_Mapping_MapField("WF1Dec_VO9Jubilee", "SalaryPriorYear9", 16, true, 0);


            pData._IP_Mapping_Initialize("Personal Information", "Administration", 1, 0, 6, "StatusHST");



            pData._IP_Mapping_ClickEdit("StatusHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("R1C1", "StatusDate1");
            dic.Add("R1C2", "Status1");
            dic.Add("R2C1", "StatusDate2");
            dic.Add("R2C2", "Status2");
            dic.Add("R3C1", "StatusDate3");
            dic.Add("R3C2", "Status3");
            dic.Add("R4C1", "StatusDate4");
            dic.Add("R4C2", "Status4");
            dic.Add("R5C1", "StatusDate5");
            dic.Add("R5C2", "Status5");
            dic.Add("R6C1", "StatusDate6");
            dic.Add("R6C2", "Status6");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_2Column(dic);


            pData._IP_Mapping_ClickEdit("DivHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("R1C1", "StatusDate1");
            dic.Add("R1C2", "Division");
            dic.Add("R2C1", "StatusDate2");
            dic.Add("R2C2", "OrgCode");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_2Column(dic);



            pData._IP_Mapping_ClickEdit("EarnHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("R1C1", "BonusDate1");
            dic.Add("R1C2", "SalaryCurrentYear");
            dic.Add("R1C3", "FTE1");
            dic.Add("R2C1", "BonusDate2");
            dic.Add("R2C2", "SalaryPriorYear1");
            dic.Add("R2C3", "FTE2");
            dic.Add("R3C1", "BonusDate3");
            dic.Add("R3C2", "SalaryPriorYear2");
            dic.Add("R3C3", "FTE3");
            dic.Add("R4C1", "BonusDate4");
            dic.Add("R4C2", "SalaryPriorYear3");
            dic.Add("R4C3", "FTE4");
            dic.Add("R5C1", "BonusDate5");
            dic.Add("R5C2", "SalaryPriorYear4");
            dic.Add("R5C3", "FTE5");
            dic.Add("R6C1", "");
            dic.Add("R6C2", "");
            dic.Add("R6C3", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_3Column(dic);

            pData._IP_Mapping_ClickEdit("Earn2HST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("R1C1", "BonusDate6");
            dic.Add("R1C2", "SalaryPriorYear5");
            dic.Add("R1C3", "FTE6");
            dic.Add("R2C1", "BonusDate7");
            dic.Add("R2C2", "SalaryPriorYear6");
            dic.Add("R2C3", "FTE7");
            dic.Add("R3C1", "BonusDate8");
            dic.Add("R3C2", "SalaryPriorYear7");
            dic.Add("R3C3", "FTE8");
            dic.Add("R4C1", "");
            dic.Add("R4C2", "");
            dic.Add("R4C3", "");
            dic.Add("R5C1", "");
            dic.Add("R5C2", "");
            dic.Add("R5C3", "");
            dic.Add("R6C1", "");
            dic.Add("R6C2", "");
            dic.Add("R6C3", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_3Column(dic);


            pData._IP_Mapping_ClickEdit("SrvHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("R1C1", "StatusDate1");
            dic.Add("R1C2", "OrgCode");
            dic.Add("R1C3", "FTE9");
            dic.Add("R2C1", "StatusDate2");
            dic.Add("R2C2", "Division");
            dic.Add("R2C3", "FTE10");
            dic.Add("R3C1", "");
            dic.Add("R3C2", "");
            dic.Add("R3C3", "");
            dic.Add("R4C1", "");
            dic.Add("R4C2", "");
            dic.Add("R4C3", "");
            dic.Add("R5C1", "");
            dic.Add("R5C2", "");
            dic.Add("R5C3", "");
            dic.Add("R6C1", "");
            dic.Add("R6C2", "");
            dic.Add("R6C3", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_3Column(dic);

            pData._IP_Mapping_ClickEdit("PenHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("R1C1", "StatusDate1");
            dic.Add("R1C2", "Benefit1DB");
            dic.Add("R1C3", "Benefit3DB");
            dic.Add("R2C1", "StatusDate2");
            dic.Add("R2C2", "Benefit2DB");
            dic.Add("R2C3", "BENEFICIARY1BENEFIT1");
            dic.Add("R3C1", "");
            dic.Add("R3C2", "");
            dic.Add("R3C3", "");
            dic.Add("R4C1", "");
            dic.Add("R4C2", "");
            dic.Add("R4C3", "");
            dic.Add("R5C1", "");
            dic.Add("R5C2", "");
            dic.Add("R5C3", "");
            dic.Add("R6C1", "");
            dic.Add("R6C2", "");
            dic.Add("R6C3", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_3Column(dic);


            pData._IP_Mapping_Initialize("Personal Information", "Last Year", 1, 0, 5, "LYOverwriteResults");
            pData._IP_Mapping_MapField("LYUSC", "USC_LastYear", 2, true, 0);


            pData._IP_Mapping_Initialize("Personal Information", "Classification Codes", 1, 0, 4, "SubsidiaryCode");
            pData._IP_Mapping_MapField("OrganizationCode", "OrgCode", 0, true, 7);
            pData._IP_Mapping_MapField("DivisionCode", "Division", 2, true, 2);

            pData._IP_Mapping_Initialize("Personal Information", "DB Information", 1, 0, 2, "MEMBERSHIPDATE1");
            pData._IP_Mapping_MapField("YearsCertain1", "ELY", 0, true, 10);
            pData._IP_Mapping_MapField("LumpSumDeathBenefit1", "AccruedBenefit1", 0, true, 0);
            pData._IP_Mapping_MapField("StartBenefit", "Benefit2DB", 8, true, 24);
            pData._IP_Mapping_MapField("VABenefit1DB", "Benefit1DB", 7, true, 9);





            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "IsEligible_VOParent");

            pData._IP_Mapping_Initialize("Personal Information", "Hours", 2, 14, 1, "HrsHistL1");
            pData._IP_Mapping_Initialize("Personal Information", "HrsHistL1", 3, 14, 1, "HrsHistL1CurrentYear");
            pData._IP_Mapping_MapField("HrsHistL1CurrentYear", "HrsCurrYear", 4, true, 0);
            pData._IP_Mapping_MapField("HrsHistL1PriorYear1", "HrsPriorYear1", 5, true, 0);
            pData._IP_Mapping_MapField("HrsHistL1PriorYear2", "HrsPriorYear1", 5, true, 0);


            pData._IP_Mapping_Initialize("Personal Information", "Pay", 2, 14, 1, "PayHistoryL1");
            pData._IP_Mapping_Initialize("Personal Information", "PayHistoryL1", 3, 14, 1, "PayHistoryL1CurrentYear");
            pData._IP_Mapping_MapField("PayHistoryL1CurrentYear", "PAYCURRYR", 3, true, 0);
            pData._IP_Mapping_MapField("PayHistoryL1PriorYear1", "PAYPRYR1", 5, true, 0);
            pData._IP_Mapping_MapField("PayHistoryL1PriorYear2", "PAYPRYR2", 6, true, 0);
            pData._IP_Mapping_MapField("PayHistoryL1PriorYear3", "PAYPRYR3", 7, true, 0);
            pData._IP_Mapping_MapField("PayHistoryL1PriorYear4", "PAYPRYR4", 8, true, 0);
            pData._IP_Mapping_MapField("PayHistoryL1PriorYear5", "PAYPRYR5", 9, true, 0);
            pData._IP_Mapping_MapField("PayHistoryL1PriorYear6", "PAYPRYR6", 10, true, 0);


            pData._IP_Mapping_Initialize("Personal Information", "Service", 2, 14, 1, "BSERVL");
            pData._IP_Mapping_MapField("BSERVL", "ETY", 1, true, 0);

            pData._IP_Mapping_MapField("VOGroup1", "VOGROUP", 0, false, 18);

            _gLib._MsgBox("Manual Interaction", "Please expand all categories under Credits and then select Crerdits to keep testing!");


            pData._IP_Mapping_MapField("CreditsHistory1CurrentYear_VO10Jubilee", "SalaryCurrentYear", 0, true, 4);
            pData._IP_Mapping_MapField("CreditsHistory1CurrentYear_VO1PenDirDB", "SalaryPriorYear1", 2, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1CurrentYear_VO2PenDirDBC", "SalaryPriorYear2", 9, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1CurrentYear_VO3PenDirDCMin", "PAYPRYR7", 11, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1CurrentYear_VO4SupportFDB", "PAYPRYR8", 12, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1CurrentYear_VO5SupportFDCM", "PAYPRYR9", 13, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1CurrentYear_VO6SupportFDBC", "SalaryPriorYear3", 10, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1CurrentYear_VO7DeathSvc", "SalaryPriorYear4", 11, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1CurrentYear_VO8DeathSvc", "SalaryPriorYear5", 12, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1CurrentYear_VO9Jubilee", "SalaryPriorYear6", 13, true, 0);



            pData._IP_Mapping_MapField("CreditsHistory1PriorYear1_VO10Jubilee", "SalaryPriorYear10", 3, true, 3);
            pData._IP_Mapping_MapField("CreditsHistory1PriorYear1_VO1PenDirDB", "SalaryPriorYear12", 5, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1PriorYear1_VO2PenDirDBC", "SalaryPriorYear11", 4, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1PriorYear1_VO3PenDirDCMin", "SalaryPriorYear7", 14, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1PriorYear1_VO4SupportFDB", "SalaryPriorYear8", 15, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1PriorYear1_VO5SupportFDCM", "SalaryPriorYear13", 6, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1PriorYear1_VO6SupportFDBC", "SalaryPriorYear9", 16, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1PriorYear1_VO7DeathSvc", "SalaryPriorYear14", 7, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1PriorYear1_VO8DeathSvc", "SalaryPriorYear15", 8, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1PriorYear1_VO9Jubilee", "SalaryPriorYear1", 2, true, 0);


            pData._IP_Mapping_MapField("CreditsHistory1PriorYear2_VO10Jubilee", "PAYPRYR1", 5, true, 3);
            pData._IP_Mapping_MapField("CreditsHistory1PriorYear2_VO1PenDirDB", "SalaryPriorYear1", 2, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1PriorYear2_VO2PenDirDBC", "PAYPRYR2", 6, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1PriorYear2_VO3PenDirDCMin", "PAYPRYR3", 7, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1PriorYear2_VO4SupportFDB", "SalaryPriorYear3", 10, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1PriorYear2_VO5SupportFDCM", "PAYPRYR4", 8, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1PriorYear2_VO6SupportFDBC", "SalaryPriorYear4", 11, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1PriorYear2_VO7DeathSvc", "PAYPRYR5", 9, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1PriorYear2_VO8DeathSvc", "SalaryPriorYear5", 12, true, 0);
            pData._IP_Mapping_MapField("CreditsHistory1PriorYear2_VO9Jubilee", "SalaryPriorYear12", 5, true, 0);










            pData._SelectTab("Validate & Load");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "True");
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

            pData._SelectTab("Pre Matching Derivations");

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
            dic.Add("DerivedField", "LumpSumDeathBenefit1");
            dic.Add("DerivedField_SearchFromIndex", "11");
            dic.Add("Type", "Age");
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
            dic.Add("Formula", "");
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
            dic.Add("DerivedField", "Beneficiary1StartDate1");
            dic.Add("DerivedField_SearchFromIndex", "7");
            dic.Add("Type", "Date");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Fixed age");
            dic.Add("sData", "53");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "28");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service Field");
            dic.Add("sData", "Beneficiary1BirthDate");
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
            dic.Add("DerivedField", "CreditsHistory1PriorYear2_VO9Jubilee");
            dic.Add("DerivedField_SearchFromIndex", "39");
            dic.Add("Type", "Service");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service starts at");
            dic.Add("sData", "Date Field");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Date Field");
            dic.Add("sData", "BirthDate");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service ends at");
            dic.Add("sData", "Date Field");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Date Field");
            dic.Add("sData", "MembershipDate1");
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

            pData._SelectTab("Matching");

            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "1200");
                dic.Add("Unique_UniqueMatch_Num", "0");
                dic.Add("Unique_MultipleMatches_Num", "0");
                dic.Add("Duplicate_NoMatch_Num", "0");
                dic.Add("Duplicate_UniqueMatch_Num", "0");
                dic.Add("Duplicate_MultipleMatches_Num", "0");
                dic.Add("Warehouse_NoMatch_Num", "0");
                pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "8000");
                dic.Add("Unique_UniqueMatch_Num", "0");
                dic.Add("Unique_MultipleMatches_Num", "0");
                dic.Add("Duplicate_NoMatch_Num", "0");
                dic.Add("Duplicate_UniqueMatch_Num", "0");
                dic.Add("Duplicate_MultipleMatches_Num", "0");
                dic.Add("Warehouse_NoMatch_Num", "0");
                pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);
            }


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


            pData._SelectTab("Matching");






            #endregion




            #region D2014Cnv - Import2Def - No Timing



            dic.Clear();
            dic.Add("Level_1", "D2014Cnv");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Import2Def");
            dic.Add("FileType", "Excel file");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "DEDataAdmin_2014Cnv2KTabs.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("SingleTabPerRecordFile_cbo", "Def2014_300");
                dic.Add("Preview", "Click");
                pData._PopVerify_IP_SelectFile(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "GBigDataAdmin_2014CnvTabs.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("SingleTabPerRecordFile_cbo", "Def2014_2K");
                dic.Add("Preview", "Click");
                pData._PopVerify_IP_SelectFile(dic);
            }


            pData._SelectTab("Mapping");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CopyMappings", "Click");
            dic.Add("ClearMappings", "");
            dic.Add("Preview", "");
            pData._PopVerify_IP_Mapping(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Import", "Import1Actives");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_CopyMappings(dic);


            pData._IP_Mapping_Initialize("Personal Information", "Administration", 1, 0, 6, "StatusHST");



            pData._IP_Mapping_ClickEdit("StatusHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_2Column(dic);


            pData._IP_Mapping_ClickEdit("DivHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_2Column(dic);



            pData._IP_Mapping_ClickEdit("EarnHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_3Column(dic);

            pData._IP_Mapping_ClickEdit("Earn2HST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_3Column(dic);


            pData._IP_Mapping_ClickEdit("SrvHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_3Column(dic);

            pData._IP_Mapping_ClickEdit("PenHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_3Column(dic);


            pData._SelectTab("Validate & Load");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "True");
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

            pData._SelectTab("Pre Matching Derivations");

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
            dic.Add("DerivedField", "WF1Dec_VO10Jubilee");
            dic.Add("DerivedField_SearchFromIndex", "2");
            dic.Add("Type", "Age");
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
            dic.Add("Formula", "");
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
            dic.Add("DerivedField", "WF3Date_VO1PenDirDB");
            dic.Add("DerivedField_SearchFromIndex", "23");
            dic.Add("Type", "Date");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Fixed age");
            dic.Add("sData", "54");
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
            dic.Add("DerivedField", "WF1Dec_VO6SupportFDBC");
            dic.Add("DerivedField_SearchFromIndex", "8");
            dic.Add("Type", "Service");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service starts at");
            dic.Add("sData", "Date Field");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Date Field");
            dic.Add("sData", "BirthDate");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service ends at");
            dic.Add("sData", "Date Field");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Date Field");
            dic.Add("sData", "EffectiveDate");
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

            pData._SelectTab("Matching");

            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "300");
                dic.Add("Unique_UniqueMatch_Num", "0");
                dic.Add("Unique_MultipleMatches_Num", "0");
                dic.Add("Duplicate_NoMatch_Num", "0");
                dic.Add("Duplicate_UniqueMatch_Num", "0");
                dic.Add("Duplicate_MultipleMatches_Num", "0");
                dic.Add("Warehouse_NoMatch_Num", "1200");
                pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "2000");
                dic.Add("Unique_UniqueMatch_Num", "0");
                dic.Add("Unique_MultipleMatches_Num", "0");
                dic.Add("Duplicate_NoMatch_Num", "0");
                dic.Add("Duplicate_UniqueMatch_Num", "0");
                dic.Add("Duplicate_MultipleMatches_Num", "0");
                dic.Add("Warehouse_NoMatch_Num", "8000");
                pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);
            }


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


            pData._SelectTab("Matching");






            #endregion


            #region D2014Cnv - Import3Pen - No Timing



            dic.Clear();
            dic.Add("Level_1", "D2014Cnv");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Import3Pen");
            dic.Add("FileType", "Excel file");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "DEDataAdmin_2014Cnv2KTabs.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("SingleTabPerRecordFile_cbo", "Pen2014_400");
                dic.Add("Preview", "Click");
                pData._PopVerify_IP_SelectFile(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "GBigDataAdmin_2014CnvTabs.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("SingleTabPerRecordFile_cbo", "Pen2014_2500");
                dic.Add("Preview", "Click");
                pData._PopVerify_IP_SelectFile(dic);
            }



            pData._SelectTab("Mapping");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CopyMappings", "Click");
            dic.Add("ClearMappings", "");
            dic.Add("Preview", "");
            pData._PopVerify_IP_Mapping(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Import", "Import1Actives");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_CopyMappings(dic);


            pData._IP_Mapping_Initialize("Personal Information", "Administration", 1, 0, 6, "StatusHST");



            pData._IP_Mapping_ClickEdit("StatusHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_2Column(dic);


            pData._IP_Mapping_ClickEdit("DivHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_2Column(dic);



            pData._IP_Mapping_ClickEdit("EarnHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_3Column(dic);

            pData._IP_Mapping_ClickEdit("Earn2HST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_3Column(dic);


            pData._IP_Mapping_ClickEdit("SrvHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_3Column(dic);

            pData._IP_Mapping_ClickEdit("PenHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_3Column(dic);


            pData._SelectTab("Validate & Load");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "True");
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

            pData._SelectTab("Pre Matching Derivations");

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
            dic.Add("DerivedField", "WF3Date_VO3PenDirDCMin");
            dic.Add("DerivedField_SearchFromIndex", "25");
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
            dic.Add("Level_2", "Custom Fields");
            dic.Add("Level_3", "CustomF3Date");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=CustomF3Date+14444");
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

            pData._SelectTab("Matching");

            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "400");
                dic.Add("Unique_UniqueMatch_Num", "0");
                dic.Add("Unique_MultipleMatches_Num", "0");
                dic.Add("Duplicate_NoMatch_Num", "0");
                dic.Add("Duplicate_UniqueMatch_Num", "0");
                dic.Add("Duplicate_MultipleMatches_Num", "0");
                dic.Add("Warehouse_NoMatch_Num", "1500");
                pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "2500");
                dic.Add("Unique_UniqueMatch_Num", "0");
                dic.Add("Unique_MultipleMatches_Num", "0");
                dic.Add("Duplicate_NoMatch_Num", "0");
                dic.Add("Duplicate_UniqueMatch_Num", "0");
                dic.Add("Duplicate_MultipleMatches_Num", "0");
                dic.Add("Warehouse_NoMatch_Num", "10000");
                pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);
            }


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


            pData._SelectTab("Matching");






            #endregion


            #region D2014Cnv - Import4Orphans - No Timing



            dic.Clear();
            dic.Add("Level_1", "D2014Cnv");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Import4Orphans");
            dic.Add("FileType", "Excel file");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "DEDataAdmin_2014Cnv2KTabs.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("SingleTabPerRecordFile_cbo", "Orphans2014_100");
                dic.Add("Preview", "Click");
                pData._PopVerify_IP_SelectFile(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "GBigDataAdmin_2014CnvTabs.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("SingleTabPerRecordFile_cbo", "Orphans2014_500");
                dic.Add("Preview", "Click");
                pData._PopVerify_IP_SelectFile(dic);
            }



            pData._SelectTab("Mapping");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CopyMappings", "Click");
            dic.Add("ClearMappings", "");
            dic.Add("Preview", "");
            pData._PopVerify_IP_Mapping(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Import", "Import1Actives");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_CopyMappings(dic);


            pData._IP_Mapping_Initialize("Personal Information", "Administration", 1, 0, 6, "StatusHST");



            pData._IP_Mapping_ClickEdit("StatusHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_2Column(dic);


            pData._IP_Mapping_ClickEdit("DivHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_2Column(dic);



            pData._IP_Mapping_ClickEdit("EarnHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_3Column(dic);

            pData._IP_Mapping_ClickEdit("Earn2HST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_3Column(dic);


            pData._IP_Mapping_ClickEdit("SrvHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_3Column(dic);

            pData._IP_Mapping_ClickEdit("PenHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_3Column(dic);


            pData._SelectTab("Validate & Load");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "True");
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

            pData._SelectTab("Pre Matching Derivations");

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
            dic.Add("DerivedField", "WF3Date_VO6SupportFDBC");
            dic.Add("DerivedField_SearchFromIndex", "28");
            dic.Add("Type", "Date");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Fixed age");
            dic.Add("sData", "58");
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

            pData._SelectTab("Matching");

            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "100");
                dic.Add("Unique_UniqueMatch_Num", "0");
                dic.Add("Unique_MultipleMatches_Num", "0");
                dic.Add("Duplicate_NoMatch_Num", "0");
                dic.Add("Duplicate_UniqueMatch_Num", "0");
                dic.Add("Duplicate_MultipleMatches_Num", "0");
                dic.Add("Warehouse_NoMatch_Num", "1900");
                pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "500");
                dic.Add("Unique_UniqueMatch_Num", "0");
                dic.Add("Unique_MultipleMatches_Num", "0");
                dic.Add("Duplicate_NoMatch_Num", "0");
                dic.Add("Duplicate_UniqueMatch_Num", "0");
                dic.Add("Duplicate_MultipleMatches_Num", "0");
                dic.Add("Warehouse_NoMatch_Num", "12500");
                pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);
            }




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


            pData._SelectTab("Matching");






            #endregion



            #region D2014Cnv - Import5OtherRet - No Timing



            dic.Clear();
            dic.Add("Level_1", "D2014Cnv");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Import5OtherRet");
            dic.Add("FileType", "Excel file");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "DEDataAdmin_2014Cnv2KTabs.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("SingleTabPerRecordFile_cbo", "InOtherStatus20");
                dic.Add("Preview", "Click");
                pData._PopVerify_IP_SelectFile(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "GBigDataAdmin_2014CnvTabs.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("SingleTabPerRecordFile_cbo", "InOtherStatus100");
                dic.Add("Preview", "Click");
                pData._PopVerify_IP_SelectFile(dic);
            }



            pData._SelectTab("Mapping");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CopyMappings", "Click");
            dic.Add("ClearMappings", "");
            dic.Add("Preview", "");
            pData._PopVerify_IP_Mapping(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Import", "Import1Actives");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_CopyMappings(dic);


            pData._IP_Mapping_Initialize("Personal Information", "Administration", 1, 0, 6, "StatusHST");



            pData._IP_Mapping_ClickEdit("StatusHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_2Column(dic);


            pData._IP_Mapping_ClickEdit("DivHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_2Column(dic);



            pData._IP_Mapping_ClickEdit("EarnHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_3Column(dic);

            pData._IP_Mapping_ClickEdit("Earn2HST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_3Column(dic);


            pData._IP_Mapping_ClickEdit("SrvHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_3Column(dic);

            pData._IP_Mapping_ClickEdit("PenHST", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_Status_3Column(dic);


            pData._SelectTab("Validate & Load");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "True");
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

            pData._SelectTab("Pre Matching Derivations");





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

            pData._SelectTab("Matching");


            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "20");
                dic.Add("Unique_UniqueMatch_Num", "0");
                dic.Add("Unique_MultipleMatches_Num", "0");
                dic.Add("Duplicate_NoMatch_Num", "0");
                dic.Add("Duplicate_UniqueMatch_Num", "0");
                dic.Add("Duplicate_MultipleMatches_Num", "0");
                dic.Add("Warehouse_NoMatch_Num", "2000");
                pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "100");
                dic.Add("Unique_UniqueMatch_Num", "0");
                dic.Add("Unique_MultipleMatches_Num", "0");
                dic.Add("Duplicate_NoMatch_Num", "0");
                dic.Add("Duplicate_UniqueMatch_Num", "0");
                dic.Add("Duplicate_MultipleMatches_Num", "0");
                dic.Add("Warehouse_NoMatch_Num", "13000");
                pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);
            }


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


            pData._SelectTab("Matching");






            #endregion



            #region D2014Cnv - Filters - No Timing



            dic.Clear();
            dic.Add("Level_1", "D2014Cnv");
            dic.Add("Level_2", "Filters");
            pData._TreeViewSelect(dic);



            pData._FL_Grid("Joint Form Of Payment", 12, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Joint&Survivor");
            dic.Add("sData", "JS");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "LastToSurvive");
            dic.Add("sData", "LTS");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "PopUp");
            dic.Add("sData", "POP");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Reversionary");
            dic.Add("sData", "REV");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "SpouseDeathInDeferment");
            dic.Add("sData", "DID");
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





            pData._FL_Grid("Custom", 15, false);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "BigPay1");
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
            dic.Add("Level_4", "PayHistoryL1");
            dic.Add("Level_5", "PayHistoryL1CurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=PayHistoryL1CurrentYear_C>100000");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            pData._FL_Grid("Custom", 15, false);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "SmallSvc");
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
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "BSERVL");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=BSERVL_C<5");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region D2014Cnv - DerGrp1EligJubilee - No Timing

            dic.Clear();
            dic.Add("Level_1", "D2014Cnv");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "DerGrp1EligJubilee");
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
            dic.Add("DerivedField", "IsEligible_VO10Jubilee");
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
            dic.Add("Level_3", "USC");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(USC_C=10,1,0)");
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
            dic.Add("DerivedField", "IsEligible_VO9Jubilee");
            dic.Add("DerivedField_SearchFromIndex", "12");
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
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=AND(USC_C>9,USC_C<15)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "5");
            dic.Add("sData", "");
            dic.Add("sFormula", "=IF(G1,1,0)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

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

            pMain._SelectTab("D2014Cnv");



            #endregion



            #region D2014Cnv - DerGrp2OtherElig - No Timing

            dic.Clear();
            dic.Add("Level_1", "D2014Cnv");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "DerGrp2OtherElig");
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
            dic.Add("DerivedField", "IsEligible_VO1PenDirDB");
            dic.Add("DerivedField_SearchFromIndex", "4");
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
            dic.Add("DerivedField", "IsEligible_VO2PenDirDBC");
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
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "PayHistoryL1");
            dic.Add("Level_5", "PayHistoryL1CurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(PayHistoryL1CurrentYear_C>99999,1,0)");
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
            dic.Add("DerivedField", "IsEligible_VO3PenDirDCMin");
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
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "BirthDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "MembershipDate1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=BirthDate_C");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=MembershipDate1_C");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=DATEVALUE(G1)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=DATEVALUE(G2)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=G4-G3");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=G5/365");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "5");
            dic.Add("sData", "");
            dic.Add("sFormula", "=IF(G6>45,1,0)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);



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
            dic.Add("DerivedField", "IsEligible_VO4SupportFDB");
            dic.Add("DerivedField_SearchFromIndex", "7");
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
            dic.Add("iRow", "1");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=YEAR(BirthDate_C)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "5");
            dic.Add("sData", "");
            dic.Add("sFormula", "=IF(G1>1980,1,0)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);



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
            dic.Add("DerivedField", "IsEligible_VO5SupportFDCM");
            dic.Add("DerivedField_SearchFromIndex", "8");
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
            dic.Add("iRow", "1");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=YEAR(HireDate1_C)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "5");
            dic.Add("sData", "");
            dic.Add("sFormula", "=IF(G1>2007,1,0)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);



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
            dic.Add("DerivedField", "IsEligible_VO6SupportFDBC");
            dic.Add("DerivedField_SearchFromIndex", "9");
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
            dic.Add("Level_3", "MaritalStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(MaritalStatus_C=\"M\",1,0)");
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
            dic.Add("iRow", "7");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "IsEligible_VO7DeathSvc");
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
            dic.Add("Level_3", "HireDate1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "MembershipDate1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(HireDate1_C<>MembershipDate1_C,1,0)");
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
            dic.Add("iRow", "8");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "IsEligible_VO8DeathSvc");
            dic.Add("DerivedField_SearchFromIndex", "11");
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
            dic.Add("Formula", "=IF(AliveStatus_C=\"XY\",1,0)");
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
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);



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

            pMain._SelectTab("D2014Cnv");



            #endregion



            #region D2014Cnv - DerGrp3Extracts - No Timing

            dic.Clear();
            dic.Add("Level_1", "D2014Cnv");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "DerGrp3Extracts");
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
            dic.Add("DerivedField", "WF4Text_VO9Jubilee");
            dic.Add("DerivedField_SearchFromIndex", "45");
            dic.Add("Type", "Extract");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Active Member");
            dic.Add("Filter_TrueFalse", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("ClientFieldValue", "Org1");
            dic.Add("AdminField", "SrvHST");
            dic.Add("Value", "Code");
            dic.Add("Date_V", "Click");
            dic.Add("Date_D", "");
            dic.Add("Date_cbo_V", "EffectiveDate");
            dic.Add("Date_txt_D", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition_Extract(dic);



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
            dic.Add("DerivedField", "PayAtTermination");
            dic.Add("DerivedField_SearchFromIndex", "4");
            dic.Add("Type", "Extract");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Active and Deferred Members");
            dic.Add("Filter_TrueFalse", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("ClientFieldValue", "81110,19");
            dic.Add("AdminField", "Earn2HST");
            dic.Add("Value", "AMT");
            dic.Add("Date_V", "Click");
            dic.Add("Date_D", "");
            dic.Add("Date_cbo_V", "EffectiveDate");
            dic.Add("Date_txt_D", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition_Extract(dic);






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
            dic.Add("DerivedField", "DivisionCode");
            dic.Add("DerivedField_SearchFromIndex", "3");
            dic.Add("Type", "Extract");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("Filter_TrueFalse", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("ClientFieldValue", "Div1");
            dic.Add("AdminField", "DivHST");
            dic.Add("Value", "Code");
            dic.Add("Date_V", "Click");
            dic.Add("Date_D", "");
            dic.Add("Date_cbo_V", "EffectiveDate");
            dic.Add("Date_txt_D", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition_Extract(dic);





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
            dic.Add("DerivedField", "BenefitBeforeLastIncrease");
            dic.Add("DerivedField_SearchFromIndex", "13");
            dic.Add("Type", "Extract");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "SmallSvc");
            dic.Add("Filter_TrueFalse", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("ClientFieldValue", "82549,13");
            dic.Add("AdminField", "EarnHST");
            dic.Add("Value", "AMT");
            dic.Add("Date_V", "");
            dic.Add("Date_D", "Click");
            dic.Add("Date_cbo_V", "");
            dic.Add("Date_txt_D", "02.10.2012");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition_Extract(dic);




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
            dic.Add("DerivedField", "WF4Text_VO10Jubilee");
            dic.Add("DerivedField_SearchFromIndex", "36");
            dic.Add("Type", "Extract");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("Filter_TrueFalse", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("ClientFieldValue", "Act");
            dic.Add("AdminField", "StatusHST");
            dic.Add("Value", "Code");
            dic.Add("Date_V", "Click");
            dic.Add("Date_D", "");
            dic.Add("Date_cbo_V", "EffectiveDate");
            dic.Add("Date_txt_D", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition_Extract(dic);





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
            dic.Add("DerivedField", "WF2Int_VO6SupportFDBC");
            dic.Add("DerivedField_SearchFromIndex", "20");
            dic.Add("Type", "Extract");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("Filter_TrueFalse", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("ClientFieldValue", "10");
            dic.Add("AdminField", "StatusHST");
            dic.Add("Value", "USC");
            dic.Add("Date_V", "Click");
            dic.Add("Date_D", "");
            dic.Add("Date_cbo_V", "EffectiveDate");
            dic.Add("Date_txt_D", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition_Extract(dic);



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
            dic.Add("DerivedField", "ErAccountBalance1");
            dic.Add("DerivedField_SearchFromIndex", "4");
            dic.Add("Type", "Extract");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("Filter_TrueFalse", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("ClientFieldValue", "2444,00");
            dic.Add("AdminField", "PenHST");
            dic.Add("Value", "AMTA");
            dic.Add("Date_V", "Click");
            dic.Add("Date_D", "");
            dic.Add("Date_cbo_V", "EffectiveDate");
            dic.Add("Date_txt_D", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition_Extract(dic);





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

            pMain._SelectTab("D2014Cnv");



            #endregion



            #region D2014Cnv - DerGrp4MixedSet - No Timing

            dic.Clear();
            dic.Add("Level_1", "D2014Cnv");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "DerGrp4MixedSet");
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
            dic.Add("DerivedField", "CF1Decim");
            dic.Add("DerivedField_SearchFromIndex", "4");
            dic.Add("Type", "Age");
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
            dic.Add("iRow", "3");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Fixed date");
            dic.Add("sData", "DELETE");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Date Field");
            dic.Add("sData", "MembershipDate1_C");
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
            dic.Add("DerivedField", "CF2Integer");
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
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "YearsCertain1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=YearsCertain1_C+1");
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
            dic.Add("DerivedField", "CustomF3Date");
            dic.Add("DerivedField_SearchFromIndex", "43");
            dic.Add("Type", "Date");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Fixed age");
            dic.Add("sData", "48");
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
            dic.Add("DerivedField", "ContribsWOInterest1");
            dic.Add("DerivedField_SearchFromIndex", "9");
            dic.Add("Type", "Service");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service starts at");
            dic.Add("sData", "Date Field");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Fixed date");
            dic.Add("sData", "Delete");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Date Field");
            dic.Add("sData", "BirthDate_C");
            pData._DG_DerivationDefinition_Grid_Date(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service ends at");
            dic.Add("sData", "Date Field");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Fixed date");
            dic.Add("sData", "Delete");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Date Field");
            dic.Add("sData", "PensionableServiceDate_C");
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
            dic.Add("DerivedField", "WF3Date_VO3PenDirDCMin");
            dic.Add("DerivedField_SearchFromIndex", "28");
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
            dic.Add("Formula", "=BirthDate_C+25000");
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
            dic.Add("iRow", "6");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "WF1Dec_VO7DeathSvc");
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
            dic.Add("Level_3", "Credits");
            dic.Add("Level_4", "CreditsHistory1");
            dic.Add("Level_5", "CreditsHistory1CurrentYear_VOParent");
            dic.Add("Level_6", "CreditsHistory1CurrentYear_VO10Jubilee");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(CreditsHistory1CurrentYear_VO10Jubilee_C/1.5,2)");
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
            dic.Add("iRow", "7");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "LYHealthStatus");
            dic.Add("DerivedField_SearchFromIndex", "16");
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
            dic.Add("Level_3", "HealthStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "True");
            dic.Add("CustomExpression_Formula", "=USC_C=20");
            dic.Add("Formula", "=HealthStatus_C");
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
            dic.Add("iRow", "8");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "PaymentForm1");
            dic.Add("DerivedField_SearchFromIndex", "12");
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
            dic.Add("Level_3", "PaymentForm1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(USC_C=80,\"JS\",PaymentForm1_C)");
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
            dic.Add("iRow", "9");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "BSERVL");
            dic.Add("DerivedField_SearchFromIndex", "15");
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
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "BSERVL");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Inactive Member");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(USC_C=80,ROUND(BSERVL_C/3,3),BSERVL_C/2)");
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
            dic.Add("iRow", "10");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "MatchStatus");
            dic.Add("DerivedField_SearchFromIndex", "2");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);


            _gLib._MsgBox("Manual Interaction", "Please click Edit button of MatchStatus and set custom expression as \"=EmployeeIDNumber_C=100000003\" and MatchStatus=Unmatched, click OK to close the dialog!");

            ////////////////////////////////dic.Clear();
            ////////////////////////////////dic.Add("PopVerify", "Pop");
            ////////////////////////////////dic.Add("Name", "");
            ////////////////////////////////dic.Add("SelectInputFields", "");
            ////////////////////////////////dic.Add("StandardorCustomFilter", "");
            ////////////////////////////////dic.Add("Filter", "");
            ////////////////////////////////dic.Add("CustomExpression", "True");
            ////////////////////////////////dic.Add("CustomExpression_Formula", "=EmployeeIDNumber_C=100000003");
            ////////////////////////////////dic.Add("Formula", "");
            ////////////////////////////////dic.Add("Previous", "");
            ////////////////////////////////dic.Add("Next", "");
            ////////////////////////////////dic.Add("OK", "");
            ////////////////////////////////pData._PopVerify_DG_DerivationDefinition(dic);



            ////////////////////////////////dic.Clear();
            ////////////////////////////////dic.Add("PopVerify", "Pop");
            ////////////////////////////////dic.Add("iRow", "1");
            ////////////////////////////////dic.Add("iCol", "2");
            ////////////////////////////////dic.Add("sLabel", "MatchStatus");
            ////////////////////////////////dic.Add("sData", "Unmatched");
            ////////////////////////////////pData._DG_DerivationDefinition_Grid_Date(dic);

            ////////////////////////////////dic.Clear();
            ////////////////////////////////dic.Add("PopVerify", "Pop");
            ////////////////////////////////dic.Add("Name", "");
            ////////////////////////////////dic.Add("SelectInputFields", "");
            ////////////////////////////////dic.Add("StandardorCustomFilter", "");
            ////////////////////////////////dic.Add("Filter", "");
            ////////////////////////////////dic.Add("CustomExpression", "");
            ////////////////////////////////dic.Add("CustomExpression_Formula", "");
            ////////////////////////////////dic.Add("Formula", ")");
            ////////////////////////////////dic.Add("Previous", "");
            ////////////////////////////////dic.Add("Next", "");
            ////////////////////////////////dic.Add("OK", "Click");
            ////////////////////////////////pData._PopVerify_DG_DerivationDefinition(dic);




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

            pMain._SelectTab("D2014Cnv");



            #endregion




            #region D2014Cnv - BatchUpdate & SimpleImport & ViewAndUpdate - No Timing

            dic.Clear();
            dic.Add("Level_1", "D2014Cnv");
            dic.Add("Level_2", "Batch Update");
            dic.Add("MenuItem", "Add new batch update");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "BatchUpdate1CreditsText");
            dic.Add("SelectFieldstoDisplay", "Click");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Credits");
            dic.Add("Level_4", "CreditsHistory1");
            dic.Add("Level_5", "CreditsHistory1PriorYear2_VOParent");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Work Fields");
            dic.Add("Level_3", "WF4Text_VOParent");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



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

            pMain._SelectTab("D2014Cnv");

            if (bSmall_Data)
                pData._BU_PasteValues(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\DE_Timing_Data_VR\BatchUpdateInput1DE500.xlsx");
            ////////////////_gLib._MsgBox("Warning", "Please copy/paste 500 rows value from " + Environment.NewLine + @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\DE_Timing_Data_VR\BatchUpdateInput1DE500.xlsx" + Environment.NewLine + "and Paste into BatchUpdate grid!");
            else
                pData._BU_PasteValues(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\DE_Timing_Data_VR\BatchUpdateInput1DE.xlsx");
            ////////////////////_gLib._MsgBox("Warning", "Please copy/paste 1000 rows value from " + Environment.NewLine + @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\DE_Timing_Data_VR\BatchUpdateInput1DE.xlsx" + Environment.NewLine + "and Paste into BatchUpdate grid!");


            pMain._SelectTab("D2014Cnv");

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
            dic.Add("Correction", "True");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_BatchUpdate(dic);


            pMain._SelectTab("D2014Cnv");
            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("D2014Cnv");



            dic.Clear();
            dic.Add("Level_1", "D2014Cnv");
            dic.Add("Level_2", "Simple Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "SimpleImp1");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            if (bSmall_Data)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "DEDataAdmin_2014Cnv2KSimple.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);
            }
            else
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", "GBigDataAdmin_2014CnvSimple.xls");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);
            }

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Plug", "");
            dic.Add("Correction", "True");
            dic.Add("NoFlag", "");
            dic.Add("Preview", "Click");
            dic.Add("Process", "Click");
            pData._PopVerify_SimpleImport(dic);


            pMain._SelectTab("D2014Cnv");







            dic.Clear();
            dic.Add("Level_1", "D2014Cnv");
            dic.Add("Level_2", "View & Update");
            dic.Add("MenuItem", "Add new view");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "View1ImportStatus");
            dic.Add("SelectLabelsToView", "Click");
            dic.Add("Filter", "");
            dic.Add("Apply", "");
            pData._PopVerify_ViewUpdate(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Administration");
            dic.Add("Level_3", "StatusHST");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Administration");
            dic.Add("Level_3", "DivHST");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Administration");
            dic.Add("Level_3", "EarnHST");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Administration");
            dic.Add("Level_3", "Earn2HST");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Administration");
            dic.Add("Level_3", "SrvHST");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Administration");
            dic.Add("Level_3", "PenHST");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, false, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "True");
            dic.Add("CustomExpression_Formula", "=ImportStatus(\"Import3Pen\",\"Unmatched\")");
            dic.Add("CustomExpression_Accept", "Click");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);

            pMain._SelectTab("D2014Cnv");
            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("D2014Cnv");



            dic.Clear();
            dic.Add("Level_1", "D2014Cnv");
            dic.Add("Level_2", "View & Update");
            dic.Add("MenuItem", "Add new view");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "View2SimpleQuery");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("Apply", "");
            pData._PopVerify_ViewUpdate(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("SimpleQuery", "True");
            dic.Add("SimpleQuery_Field", "PayHistoryL1CurrentYear_C");
            dic.Add("SimpleQuery_Operator", "<");
            dic.Add("Simplequery_Value", "88888");
            dic.Add("Apply", "");
            dic.Add("GenerateSummary", "");
            dic.Add("PrintAll", "");
            dic.Add("PrintToFile", "");
            dic.Add("ViewAllManualChanges", "");
            pData._PopVerify_ViewUpdate(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "Click");
            dic.Add("Filter", "");
            dic.Add("Apply", "");
            pData._PopVerify_ViewUpdate(dic);



            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            pMain._SelectTab("D2014Cnv");
            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("D2014Cnv");




            #endregion



            #region D2014Cnv - Checks & Reports & Snapshots & ValService- No Timing



            dic.Clear();
            dic.Add("Level_1", "D2014Cnv");
            dic.Add("Level_2", "Checks");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "Click");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);

            string sStandardInput = "Please fill below info in <This Year> column, and keep testing" + Environment.NewLine + Environment.NewLine;

            sStandardInput = sStandardInput + "Annuitant Benefit      = Benefit1DB_C" + Environment.NewLine;
            sStandardInput = sStandardInput + "Beneficiary Benefit    = Beneficiary1Benefit1_C" + Environment.NewLine;
            sStandardInput = sStandardInput + "Pay                    = PayHistoryL1CurrentYear_C" + Environment.NewLine;
            sStandardInput = sStandardInput + "Service                = BSERVL_C" + Environment.NewLine;
            sStandardInput = sStandardInput + "Certain Period         = YearsCertain1" + Environment.NewLine;
            sStandardInput = sStandardInput + "Continuation %         = Beneficiary1Percent1_C" + Environment.NewLine;


            _gLib._MsgBox("Manual Interaction", sStandardInput);



            sStandardInput = "Please fill below info in <Mininum> and <Maximum> column, and keep testing" + Environment.NewLine + Environment.NewLine;

            sStandardInput = sStandardInput + "Annuitant Benefit Range (&)   = 100 - 80.000" + Environment.NewLine;
            sStandardInput = sStandardInput + "Beneficiary Benefit Range (&) = 20 - 60.000" + Environment.NewLine;
            sStandardInput = sStandardInput + "Certain Period                = 5 - 10" + Environment.NewLine;
            sStandardInput = sStandardInput + "Continuation %                = 50 - 100" + Environment.NewLine;
            sStandardInput = sStandardInput + "Hire Age                      = 16 - 65" + Environment.NewLine;
            sStandardInput = sStandardInput + "Pay Range (&)                 = 2.000 - 100.000" + Environment.NewLine;
            sStandardInput = sStandardInput + "Pay Increase (%)              =  - 25" + Environment.NewLine;
            sStandardInput = sStandardInput + "Pay Decrease (%)              =  - 25" + Environment.NewLine;

            _gLib._MsgBox("Manual Interaction", sStandardInput);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_CK_StandardInputs_Part2(dic);





            dic.Clear();
            dic.Add("CheckName", "Custom Checks");
            dic.Add("iSearchDownNum", "41");
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
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "Click");
            dic.Add("ApplyChecks", "");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "EffectiveDateLessHireDate");
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
            dic.Add("Formula", "=E2<Pull(\"EffectiveDate_C\")");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



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
            dic.Add("Name", "DifferentHireMembershipD");
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
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "MembershipDate1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=HireDate1_C<>MembershipDate1_C");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);




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
            dic.Add("Name", "HireVsEffectiveDate2");
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
            dic.Add("iRow", "1");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=Pull(\"EffectiveDate\")");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "5");
            dic.Add("sData", "");
            dic.Add("sFormula", "=E2<G1");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

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
            dic.Add("Name", "EffectVsHire3");
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
            dic.Add("Formula", "=E2<EffectiveDate");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);





            pMain._SelectTab("D2014Cnv");
            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("D2014Cnv");


            dic.Clear();
            dic.Add("Level_1", "D2014Cnv");
            dic.Add("Level_2", "Reports");
            dic.Add("MenuItem", "Add new report");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "Plug");
            dic.Add("StatusMatrix", "");
            dic.Add("StatusMatrix_Filter", "");
            dic.Add("ReportName", "Rep1Plugs");
            dic.Add("GenerateReport", "");
            pData._PopVerify_Reports(dic);


            dic.Clear();
            dic.Add("Level_1", "D2014Cnv");
            dic.Add("Level_2", "Reports");
            dic.Add("MenuItem", "Add new report");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "Query");
            dic.Add("StatusMatrix", "");
            dic.Add("StatusMatrix_Filter", "");
            dic.Add("ReportName", "Rep2Query");
            dic.Add("GenerateReport", "");
            pData._PopVerify_Reports(dic);





            pMain._SelectTab("D2014Cnv");
            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab("D2014Cnv");


            dic.Clear();
            dic.Add("Level_1", "D2014Cnv");
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Snap1ULDAll");
            dic.Add("UseLatestDate", "True");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "OstWestKZ");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "OrganizationCode");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "DivisionCode");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "HighlyCompensatedCode");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DC Information");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Last Year");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Administration");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Legacy System Results");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Work Fields");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Custom Fields");
            pData._TreeViewSelect_Snapshots(dic, true);



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




            pMain._SelectTab("D2014Cnv");


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Home");

            _gLib._MsgBox("Warning!", "Please manually select the Client in Studio-> Home -> All Services -> " + Config.sClientName + "->" + Config.sPlanName + "->PensionValuations" + Environment.NewLine + Environment.NewLine
              + "Click OK to keep testing!");

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "True");
            dic.Add("Name", sValServiceName);
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "2015");
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
            dic.Add("ServiceToOpen", sValServiceName);
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab(sValServiceName);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Home");

            _gLib._MsgBox("Congrats!", "DE Timing Conversion D2014Cnv is generated!");

            Environment.Exit(0);

            #endregion



            Environment.Exit(0);


                

            Environment.Exit(0);




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
