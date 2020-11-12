
////// ----------------------- ------------------------------------------------------------------------///////////
//////                                                                                                 ///////////
//////                                                                                                 ///////////
//////                          Webber.ling@mercer.com      2015-Sep-18                              ///////////
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




namespace RetirementStudio._TestScripts._TestScripts_Timing
{
    /// <summary>
    /// Summary description for UK_Timing_Data
    /// </summary>
    [CodedUITest]
    public class UK_Timing_Data
    {
        public UK_Timing_Data()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.UK;
            //Config.sClientName = "UK_Performance_Test_WithData_201406";  ///// QA1
            //Config.sPlanName = "UK_Performance_Plan"; ///// QA1 Plan

            //Config.sClientName = "UK Performance Test_WithData_201408_F";  ///// US Prod F
            ////Config.sClientName = "UK Performance Test_WithData_201408_D";  ///// US Prod D
            Config.sClientName = "UK_Performance Test_WithData_201408";  ///// CA Prod 
            //////Config.sClientName = "UK Performance Test_WithData_201408_E";  ///// EU Prod 
            //Config.sClientName = "UK Performance Test_WithData_201408_B";  ///// EU Prod 
            //////Config.sClientName = "UK Performance Test With Data 201410 B";  ///// EU Prod backup client

            Config.sPlanName = "UK Plan";


            ////Config.sDataCenter = "Exeter";
            Config.sDataCenter = "Franklin";


        }


        static string sDataService = "ValuationData1/4/2014" + "_20190507";

        #region Timing

        static string sCol_Time = "Time";
        static string sCol_Memory = "Memory";
        static string sLogFile = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\UK_Timing_TestWithData\UK_Timing_TestWithData_CUIT.xls";
        static string sOutputDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\UK_Timing_TestWithData\Reports_KeepUpdateOnRun\";
        MyTimer mTime = new MyTimer(sCol_Time, sLogFile);
        MyLog mLog = new MyLog(sCol_Memory, sLogFile);


        //////////////////////////// clients used to copy check froms /////////////////////////////
        ////// QA1 client
        //static string sClient_CopyFrom = "UK_Performance_Test_WithData_201404";
        //static string sPlan_CopyFrom = "UK_Performance_Plan";

        ////////// US Prod client
        //static string sClient_CopyFrom = "UK Performance Test_WithData F";
        //static string sPlan_CopyFrom = "UK Plan";

        //// CA Prod client
        static string sClient_CopyFrom = "UK Performance Test_WithData";
        static string sPlan_CopyFrom = "UK Plan";

        ////////////// EU Prod client
        //static string sClient_CopyFrom = "UK Performance Test_WithData B";
        //static string sPlan_CopyFrom = "UK Plan";



        #region Result Index

        static int iTimeStart = 2;
        static int iTimeEnd = iTimeStart + 1;
        static int iUpLoad_PensionersData = iTimeEnd + 5;
        static int iUpLoad_Actives80Data = iUpLoad_PensionersData + 1;
        static int iUpLoad_Actives60Data = iUpLoad_Actives80Data + 1;
        static int iUpLoad_DeferredsData = iUpLoad_Actives60Data + 1;
        static int iUpLoad_ActivesUpdateERCodesData = iUpLoad_DeferredsData + 1;


        static int iIM_Actives80Data = iUpLoad_ActivesUpdateERCodesData + 1;
        static int iIM_Actives60Data = iIM_Actives80Data + 1;
        static int iIM_DeferredsData = iIM_Actives60Data + 1;
        static int iIM_PensionersData = iIM_DeferredsData + 1;
        static int iIM_UniqueMatch_Accept = iIM_PensionersData + 1;
        static int iIM_SaveToWarehouse = iIM_UniqueMatch_Accept + 1;

        static int iDG_SetBenefitSetShortName = iIM_SaveToWarehouse + 1;
        static int iDG_SetBeneficiaryFieldsforRetBene = iDG_SetBenefitSetShortName + 1;
        static int iDG_SetNPA = iDG_SetBeneficiaryFieldsforRetBene + 1;

        static int iCK_Apply = iDG_SetNPA + 1;
        static int iCK_SetQueryForFailChecks = iCK_Apply + 1;
        static int iRP_GenerateQueryReport = iCK_SetQueryForFailChecks + 1;
        static int iRP_ExportQueryReport = iRP_GenerateQueryReport + 1;

        static int iVU_Actives60ths_Apply = iRP_ExportQueryReport + 1;
        static int iVU_Actives60ths_GenerateSummary = iVU_Actives60ths_Apply + 1;
        static int iVU_Actives60ths_PrintToFile = iVU_Actives60ths_GenerateSummary + 1;
        static int iVU_Actives60ths_ExportExcel = iVU_Actives60ths_PrintToFile + 1;
        static int iVU_Actives80ths_Apply = iVU_Actives60ths_ExportExcel + 1;
        static int iVU_Actives80ths_GenerateSummary = iVU_Actives80ths_Apply + 1;
        static int iVU_Actives80ths_PrintToFile = iVU_Actives80ths_GenerateSummary + 1;
        static int iVU_Deferreds_Apply = iVU_Actives80ths_PrintToFile + 1;
        static int iVU_Deferreds_GenerateSummary = iVU_Deferreds_Apply + 1;
        static int iVU_Deferreds_PrintToFile = iVU_Deferreds_GenerateSummary + 1;
        static int iVU_Pensioners_Apply = iVU_Deferreds_PrintToFile + 1;
        static int iVU_Pensioners_GenerateSummary = iVU_Pensioners_Apply + 1;
        static int iVU_Pensioners_PrintToFile = iVU_Pensioners_GenerateSummary + 1;
        static int iVU_Beneficiaries_Apply = iVU_Pensioners_PrintToFile + 1;
        static int iVU_Beneficiaries_GenerateSummary = iVU_Beneficiaries_Apply + 1;
        static int iVU_Beneficiaries_PrintToFile = iVU_Beneficiaries_GenerateSummary + 1;

        static int iDG_Actives_CalcPreview = iVU_Beneficiaries_PrintToFile + 1;
        static int iDG_Actives_SaveWH = iDG_Actives_CalcPreview + 1;
        static int iDG_Deferreds_CalcPreview = iDG_Actives_SaveWH + 1;
        static int iDG_Deferreds_SaveWH = iDG_Deferreds_CalcPreview + 1;
        static int iDG_Penioners_CalcPreview = iDG_Deferreds_SaveWH + 1;
        static int iDG_Penioners_SaveWH = iDG_Penioners_CalcPreview + 1;
        static int iDG_Beneficiaries_CalcPreview = iDG_Penioners_SaveWH + 1;
        static int iDG_Beneficiaries_SaveWH = iDG_Beneficiaries_CalcPreview + 1;
        static int iDG_Reset_IH_PensionerUSC_for_PPF_CalcPreview = iDG_Beneficiaries_SaveWH + 1;
        static int iDG_Reset_IH_PensionerUSC_for_PPF_SaveWH = iDG_Reset_IH_PensionerUSC_for_PPF_CalcPreview + 1;


        static int iCK_ReApply = iDG_Reset_IH_PensionerUSC_for_PPF_SaveWH + 1;
        static int iSS_Preview = iCK_ReApply + 1;
        static int iSS_Navi_Next = iSS_Preview + 1;
        static int iSS_Navi_Last = iSS_Navi_Next + 1;
        static int iSS_Publish = iSS_Navi_Last + 1;
        static int iSS_Extract = iSS_Publish + 1;
        static int iUndo = iSS_Extract + 1;

        static int iIM_ActivesUpdatedERCodes = iUndo + 1;
        static int iIM_ActivesUpdatedERCodes_SaveToWarehouse = iIM_ActivesUpdatedERCodes + 1;
        static int iDG_SetNPA_ReCalcPreview = iIM_ActivesUpdatedERCodes_SaveToWarehouse + 1;
        static int iDG_SetNPA_ReSaveWH = iDG_SetNPA_ReCalcPreview + 1;
        static int iDG_Actives_ReCalcPreview = iDG_SetNPA_ReSaveWH + 1;
        static int iDG_Actives_ReSaveWH = iDG_Actives_ReCalcPreview + 1;
        static int iDG_Deferreds_ReCalcPreview = iDG_Actives_ReSaveWH + 1;
        static int iDG_Deferreds_ReSaveWH = iDG_Deferreds_ReCalcPreview + 1;
        static int iDG_Penioners_ReCalcPreview = iDG_Deferreds_ReSaveWH + 1;
        static int iDG_Penioners_ReSaveWH = iDG_Penioners_ReCalcPreview + 1;
        static int iDG_Beneficiaries_ReCalcPreview = iDG_Penioners_ReSaveWH + 1;
        static int iDG_Beneficiaries_ReSaveWH = iDG_Beneficiaries_ReCalcPreview + 1;
        static int iDG_Reset_IH_PensionerUSC_for_PPF_ReCalcPreview = iDG_Beneficiaries_ReSaveWH + 1;
        static int iDG_Reset_IH_PensionerUSC_for_PPF_ReSaveWH = iDG_Reset_IH_PensionerUSC_for_PPF_ReCalcPreview + 1;


        static int iBU_Add = iDG_Reset_IH_PensionerUSC_for_PPF_ReSaveWH + 1;
        static int iBU_Edit = iBU_Add + 1;
        static int iBU_SaveWH = iBU_Edit + 1;
        static int iVU_ViewAllManualChanges = iBU_SaveWH + 1;
        static int iSS_RePreview = iVU_ViewAllManualChanges + 1;
        static int iSS_ReNavi_Next = iSS_RePreview + 1;
        static int iSS_ReNavi_Last = iSS_ReNavi_Next + 1;
        static int iSS_RePublish = iSS_ReNavi_Last + 1;
        static int iSS_ReExtract = iSS_RePublish + 1;


        static int iTest = 83;

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
        public void test_UK_Timing_Data()
        {




            _gLib._StudioClearCache();   //////////_gLib._MsgBox("Warning!", "Please Clear Cache!");

            pMain._SetLanguageAndRegional();

            _gLib._CreateDirectory(sOutputDir, false);

            mLog.LogInfo(iTimeStart, DateTime.Now.ToString());

            //////////////_gLib._MsgBox("Warning!", "Please manually select the Client in Studio-> Home -> All Services -> "
            //////////////    + Config.sClientName + "->" + Config.sPlanName + "-> ParticipantData" + Environment.NewLine + "Click OK to keep testing!");


            #region ValuationData1/4/2014 - Create Rollforward data

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "ParticipantData");
            pMain._HomeTreeViewSelect_Favorites(0, dic);




            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", sDataService);
            dic.Add("EffectiveDate", "01/04/2014");
            dic.Add("Parent", "ConversionData1/4/2011");
            dic.Add("RSC", "");
            dic.Add("Shared", "");
            dic.Add("GeneralUse", "");
            dic.Add("Conversion", "");
            dic.Add("CopyDataService", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_DataServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", sDataService);
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);


            pData._CV_ExpandPersonalInformation();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Pay");
            dic.Add("Label", "Salary");
            dic.Add("DisplayName", "");
            dic.Add("SelectAnExistingWHField", "True");
            dic.Add("ExistingWHField", "Salary");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "4");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "01/04/2014");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);



            //////////////////dic.Clear();
            //////////////////dic.Add("PopVerify", "Pop");
            //////////////////dic.Add("Category", "Pay");
            //////////////////dic.Add("Label", "Salary");
            //////////////////dic.Add("DisplayName", "");
            //////////////////dic.Add("SelectAnExistingWHField", "");
            //////////////////dic.Add("ExistingWHField", "");
            //////////////////dic.Add("VariesbyVO", "");
            //////////////////dic.Add("HistoryLabels", "4");
            //////////////////dic.Add("Monthly", "");
            //////////////////dic.Add("Yearly", "");
            //////////////////dic.Add("WarehouseFieldType", "Decimal");
            //////////////////dic.Add("FieldLength", "13");
            //////////////////dic.Add("DecimalPlaces", "2");
            //////////////////dic.Add("FromDate", "01/04/2014");
            //////////////////dic.Add("OK", "Click");
            //////////////////dic.Add("Cancel", "");
            //////////////////pData._CV_AddSingleLabel(dic, true);



            //////////////////dic.Clear();
            //////////////////dic.Add("Level_1", sDataService);
            //////////////////dic.Add("Level_2", "Upload Data");
            //////////////////pData._TreeViewSelect(dic);

            //////////////////mTime.StartTimer();

            //////////////////dic.Clear();
            //////////////////dic.Add("PopVerify", "Pop");
            //////////////////dic.Add("LocalFile", "");
            //////////////////dic.Add("GRSUnloadFile", "");
            //////////////////dic.Add("SharepointFile", "");
            //////////////////dic.Add("Browse", "Click");
            //////////////////dic.Add("Upload", "");
            //////////////////pData._PopVerify_UploadData(dic);

            //////////////////dic.Clear();
            //////////////////dic.Add("PopVerify", "Pop");
            //////////////////dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\UK_Timing_TestWithData\PensionersData.xlsx");
            //////////////////dic.Add("Open", "Click");
            //////////////////dic.Add("Cancel", "");
            //////////////////pMain._PopVerify_FileOpen(dic);


            //////////////////dic.Clear();
            //////////////////dic.Add("PopVerify", "Pop");
            //////////////////dic.Add("LocalFile", "");
            //////////////////dic.Add("GRSUnloadFile", "");
            //////////////////dic.Add("SharepointFile", "");
            //////////////////dic.Add("Browse", "");
            //////////////////dic.Add("Upload", "Click");
            //////////////////pData._PopVerify_UploadData(dic);


            //////////////////pMain._SelectTab(sDataService);
            //////////////////mTime.StopTimer(iUpLoad_PensionersData);
            //////////////////mLog.LogInfo(iUpLoad_PensionersData, MyPerformanceCounter.Memory_Private);



            //////////////////mTime.StartTimer();

            //////////////////dic.Clear();
            //////////////////dic.Add("PopVerify", "Pop");
            //////////////////dic.Add("LocalFile", "");
            //////////////////dic.Add("GRSUnloadFile", "");
            //////////////////dic.Add("SharepointFile", "");
            //////////////////dic.Add("Browse", "Click");
            //////////////////dic.Add("Upload", "");
            //////////////////pData._PopVerify_UploadData(dic);

            //////////////////dic.Clear();
            //////////////////dic.Add("PopVerify", "Pop");
            //////////////////dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\UK_Timing_TestWithData\Actives80Data.xlsx");
            //////////////////dic.Add("Open", "Click");
            //////////////////dic.Add("Cancel", "");
            //////////////////pMain._PopVerify_FileOpen(dic);


            //////////////////dic.Clear();
            //////////////////dic.Add("PopVerify", "Pop");
            //////////////////dic.Add("LocalFile", "");
            //////////////////dic.Add("GRSUnloadFile", "");
            //////////////////dic.Add("SharepointFile", "");
            //////////////////dic.Add("Browse", "");
            //////////////////dic.Add("Upload", "Click");
            //////////////////pData._PopVerify_UploadData(dic);


            //////////////////pMain._SelectTab(sDataService);
            //////////////////mTime.StopTimer(iUpLoad_Actives80Data);
            //////////////////mLog.LogInfo(iUpLoad_Actives80Data, MyPerformanceCounter.Memory_Private);


            //////////////////mTime.StartTimer();

            //////////////////dic.Clear();
            //////////////////dic.Add("PopVerify", "Pop");
            //////////////////dic.Add("LocalFile", "");
            //////////////////dic.Add("GRSUnloadFile", "");
            //////////////////dic.Add("SharepointFile", "");
            //////////////////dic.Add("Browse", "Click");
            //////////////////dic.Add("Upload", "");
            //////////////////pData._PopVerify_UploadData(dic);

            //////////////////dic.Clear();
            //////////////////dic.Add("PopVerify", "Pop");
            //////////////////dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\UK_Timing_TestWithData\Actives60Data.xlsx");
            //////////////////dic.Add("Open", "Click");
            //////////////////dic.Add("Cancel", "");
            //////////////////pMain._PopVerify_FileOpen(dic);


            //////////////////dic.Clear();
            //////////////////dic.Add("PopVerify", "Pop");
            //////////////////dic.Add("LocalFile", "");
            //////////////////dic.Add("GRSUnloadFile", "");
            //////////////////dic.Add("SharepointFile", "");
            //////////////////dic.Add("Browse", "");
            //////////////////dic.Add("Upload", "Click");
            //////////////////pData._PopVerify_UploadData(dic);


            //////////////////pMain._SelectTab(sDataService);
            //////////////////mTime.StopTimer(iUpLoad_Actives60Data);
            //////////////////mLog.LogInfo(iUpLoad_Actives60Data, MyPerformanceCounter.Memory_Private);


            //////////////////mTime.StartTimer();

            //////////////////dic.Clear();
            //////////////////dic.Add("PopVerify", "Pop");
            //////////////////dic.Add("LocalFile", "");
            //////////////////dic.Add("GRSUnloadFile", "");
            //////////////////dic.Add("SharepointFile", "");
            //////////////////dic.Add("Browse", "Click");
            //////////////////dic.Add("Upload", "");
            //////////////////pData._PopVerify_UploadData(dic);

            //////////////////dic.Clear();
            //////////////////dic.Add("PopVerify", "Pop");
            //////////////////dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\UK_Timing_TestWithData\DeferredsData.xlsx");
            //////////////////dic.Add("Open", "Click");
            //////////////////dic.Add("Cancel", "");
            //////////////////pMain._PopVerify_FileOpen(dic);


            //////////////////dic.Clear();
            //////////////////dic.Add("PopVerify", "Pop");
            //////////////////dic.Add("LocalFile", "");
            //////////////////dic.Add("GRSUnloadFile", "");
            //////////////////dic.Add("SharepointFile", "");
            //////////////////dic.Add("Browse", "");
            //////////////////dic.Add("Upload", "Click");
            //////////////////pData._PopVerify_UploadData(dic);


            //////////////////pMain._SelectTab(sDataService);
            //////////////////mTime.StopTimer(iUpLoad_DeferredsData);
            //////////////////mLog.LogInfo(iUpLoad_DeferredsData, MyPerformanceCounter.Memory_Private);



            //////////////////mTime.StartTimer();

            //////////////////dic.Clear();
            //////////////////dic.Add("PopVerify", "Pop");
            //////////////////dic.Add("LocalFile", "");
            //////////////////dic.Add("GRSUnloadFile", "");
            //////////////////dic.Add("SharepointFile", "");
            //////////////////dic.Add("Browse", "Click");
            //////////////////dic.Add("Upload", "");
            //////////////////pData._PopVerify_UploadData(dic);

            //////////////////dic.Clear();
            //////////////////dic.Add("PopVerify", "Pop");
            //////////////////dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\UK_Timing_TestWithData\ActivesUpdateERCodesData.xlsx");
            //////////////////dic.Add("Open", "Click");
            //////////////////dic.Add("Cancel", "");
            //////////////////pMain._PopVerify_FileOpen(dic);


            //////////////////dic.Clear();
            //////////////////dic.Add("PopVerify", "Pop");
            //////////////////dic.Add("LocalFile", "");
            //////////////////dic.Add("GRSUnloadFile", "");
            //////////////////dic.Add("SharepointFile", "");
            //////////////////dic.Add("Browse", "");
            //////////////////dic.Add("Upload", "Click");
            //////////////////pData._PopVerify_UploadData(dic);


            //////////////////pMain._SelectTab(sDataService);
            //////////////////mTime.StopTimer(iUpLoad_ActivesUpdateERCodesData);
            //////////////////mLog.LogInfo(iUpLoad_ActivesUpdateERCodesData, MyPerformanceCounter.Memory_Private);



            #endregion


            #region ValuationData1/4/2014 - Imports

            mTime.StartTimer();


            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "ConversionData");
            pData._TreeViewSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Actives80thsCat");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "Actives80Data.xlsx");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._SelectTab("Mapping");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_Mapping(dic);


            pData._SelectTab("Validate & Load");

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

            mTime.StopTimer(iIM_Actives80Data);
            mLog.LogInfo(iIM_Actives80Data, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();



            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Actives80thsCat");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Actives60thsCat");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "Actives60Data.xlsx");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._SelectTab("Mapping");

            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "EmployeeIDNumber");

            pData._IP_Mapping_ClickEdit("USC", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "Act");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "Def");

            pData._IP_Mapping_Transformation(3, 1, "20");
            pData._IP_Mapping_Transformation(3, 2, "Ret");

            pData._IP_Mapping_Transformation(4, 1, "30");
            pData._IP_Mapping_Transformation(4, 2, "RetBene");

            pData._IP_Mapping_Transformation(5, 1, "40");
            pData._IP_Mapping_Transformation(5, 2, "RetBene");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_Mapping(dic);


            pData._SelectTab("Validate & Load");

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

            mTime.StopTimer(iIM_Actives60Data);
            mLog.LogInfo(iIM_Actives60Data, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();



            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Actives80thsCat");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Deferreds");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "DeferredsData.xlsx");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._SelectTab("Mapping");

            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "EmployeeIDNumber");

            pData._IP_Mapping_ClickEdit("USC", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "Act");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "Def");

            pData._IP_Mapping_Transformation(3, 1, "20");
            pData._IP_Mapping_Transformation(3, 2, "Ret");

            pData._IP_Mapping_Transformation(4, 1, "30");
            pData._IP_Mapping_Transformation(4, 2, "RetBene");

            pData._IP_Mapping_Transformation(5, 1, "40");
            pData._IP_Mapping_Transformation(5, 2, "RetBene");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_Mapping(dic);


            pData._SelectTab("Validate & Load");

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

            mTime.StopTimer(iIM_DeferredsData);
            mLog.LogInfo(iIM_DeferredsData, MyPerformanceCounter.Memory_Private);




            mTime.StartTimer();



            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Actives80thsCat");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Pensioners");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "PensionersData.xlsx");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._SelectTab("Mapping");

            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "EmployeeIDNumber");

            pData._IP_Mapping_ClickEdit("USC", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "Act");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "Def");

            pData._IP_Mapping_Transformation(3, 1, "20");
            pData._IP_Mapping_Transformation(3, 2, "Ret");

            pData._IP_Mapping_Transformation(4, 1, "30");
            pData._IP_Mapping_Transformation(4, 2, "RetBene");

            pData._IP_Mapping_Transformation(5, 1, "40");
            pData._IP_Mapping_Transformation(5, 2, "RetBene");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_Mapping(dic);


            pData._SelectTab("Validate & Load");

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

            mTime.StopTimer(iIM_PensionersData);
            mLog.LogInfo(iIM_PensionersData, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Actives80thsCat");
            pData._TreeViewSelect(dic);

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


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "17");
            dic.Add("Unique_UniqueMatch_Num", "965");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "8");
            dic.Add("Duplicate_UniqueMatch_Num", "0");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
            dic.Add("Warehouse_NoMatch_Num", "22");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);


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

            mTime.StopTimer(iIM_UniqueMatch_Accept);
            mLog.LogInfo(iIM_UniqueMatch_Accept, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("Field", "Name");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ImportFilter", "=USC_C=\"RetBene\"");
            dic.Add("WarehouseFilter", "");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "5");
            dic.Add("Unique_UniqueMatch_Num", "10");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "0");
            dic.Add("Duplicate_UniqueMatch_Num", "2");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
            dic.Add("Warehouse_NoMatch_Num", "11");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

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


            dic.Clear();
            dic.Add("Field", "Name");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ImportFilter", "");
            dic.Add("WarehouseFilter", "");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ImportFilter", "");
            dic.Add("WarehouseFilter", "");
            dic.Add("MatchManually", "Click");
            dic.Add("FindMatches", "");
            pData._PopVerify_IP_Matching(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "FC298277G");
            dic.Add("sWarehouseRecords", "");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("AcceptSelectedDataFile_AsNew", "Click");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "VS436323W");
            dic.Add("sWarehouseRecords", "");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("AcceptSelectedDataFile_AsNew", "Click");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "BY852536C");
            dic.Add("sWarehouseRecords", "");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("AcceptSelectedDataFile_AsNew", "Click");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "VS436323W");
            dic.Add("sWarehouseRecords", "");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("AcceptSelectedDataFile_AsNew", "Click");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);


            dic.Clear();
            dic.Add("sDataFileRecords", "WZ123456X");
            dic.Add("sWarehouseRecords", "");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("AcceptSelectedDataFile_AsNew", "Click");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "LI377315M");
            dic.Add("sWarehouseRecords", "");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("AcceptSelectedDataFile_AsNew", "Click");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "TV1234546Y");
            dic.Add("sWarehouseRecords", "");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("AcceptSelectedDataFile_AsNew", "Click");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "GL321654P");
            dic.Add("sWarehouseRecords", "");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("AcceptSelectedDataFile_AsNew", "Click");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "FU698745M");
            dic.Add("sWarehouseRecords", "");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("AcceptSelectedDataFile_AsNew", "Click");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "BY852536C");
            dic.Add("sWarehouseRecords", "");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("AcceptSelectedDataFile_AsNew", "Click");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);


            dic.Clear();
            dic.Add("sDataFileRecords", "LI377315M");
            dic.Add("sWarehouseRecords", "");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("AcceptSelectedDataFile_AsNew", "Click");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "FC298277G");
            dic.Add("sWarehouseRecords", "");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("AcceptSelectedDataFile_AsNew", "Click");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "HY987654P");
            dic.Add("sWarehouseRecords", "");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("AcceptSelectedDataFile_AsNew", "Click");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "TN111298M");
            dic.Add("sWarehouseRecords", "");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("AcceptSelectedDataFile_AsNew", "Click");
            dic.Add("Close", "");
            pData._IP_MatchManually(dic);

            dic.Clear();
            dic.Add("sDataFileRecords", "TN030803F");
            dic.Add("sWarehouseRecords", "");
            dic.Add("bExactMatch", "");
            dic.Add("iMaxSeachNum", "");
            dic.Add("AcceptSelectedDataFile_AsNew", "Click");
            dic.Add("Close", "Click");
            pData._IP_MatchManually(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "");
            dic.Add("Unique_UniqueMatch", "");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "Click");
            dic.Add("AcceptAllRecordsAs_What", "Gone");
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



            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Matched_Num", "975");
            dic.Add("New_Num", "15");
            dic.Add("Ignored_Num", "0");
            dic.Add("Gone_Num", "8");
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
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);

            mTime.StopTimer(iIM_SaveToWarehouse);
            mLog.LogInfo(iIM_SaveToWarehouse, MyPerformanceCounter.Memory_Private);




            #endregion


            #region ValuationData1/4/2014 - Filters & Derivations

            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Filters");
            pData._TreeViewSelect(dic);

            pData._FL_Grid("Custom", 16, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "CNS member flag");
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
            dic.Add("Level_3", "OrganizationCode");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=OrganizationCode_C=\"CNS\"");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            pData._FL_Grid("Custom", 16, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Continuing Deferred");
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
            dic.Add("Level_3", "USC");
            pData._TreeViewSelect_SelectInputFields_PriorView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=AND(E2=\"Def\",E3=\"Def\")");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            pData._FL_Grid("Custom", 16, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Continuing Pensioner Non Spouse");
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
            dic.Add("Level_3", "USC");
            pData._TreeViewSelect_SelectInputFields_PriorView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=AND(E2=\"Ret\",E3=\"Ret\")");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            pData._FL_Grid("Custom", 16, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Status changed since last time");
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
            dic.Add("Level_3", "USC");
            pData._TreeViewSelect_SelectInputFields_PriorView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=E2<>E3");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "SetBenefitSetShortName");
            pData._TreeViewSelect(dic);

            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "<No Filter>");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);


            mTime.StopTimer(iDG_SetBenefitSetShortName);
            mLog.LogInfo(iDG_SetBenefitSetShortName, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "SetBeneficiaryFieldsForRetBene");
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
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);


            mTime.StopTimer(iDG_SetBeneficiaryFieldsforRetBene);
            mLog.LogInfo(iDG_SetBeneficiaryFieldsforRetBene, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "SetActivesNPA");
            pData._TreeViewSelect(dic);

            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "SetNPA");
            dic.Add("Filter", "<No Filter>");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);


            mTime.StopTimer(iDG_SetNPA);
            mLog.LogInfo(iDG_SetNPA, MyPerformanceCounter.Memory_Private);



            #endregion


            #region ValuationData1/4/2014 - Checks & Reports


            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Checks");
            dic.Add("MenuItem", "Import Checks from ...");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", sClient_CopyFrom);
            dic.Add("Plan", sPlan_CopyFrom);
            dic.Add("Service", "ValuationData1/4/2014");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_CopyDerivations(dic);

            _gLib._Exists("", pData.wCopyValidationErrors, Config.iTimeout * 10, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Copy", "click");
            pData._PopVerify_CopyValidationErrors(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_DataAcquisitions(dic);


            _gLib._Enabled("", pData.wRetirementStudio.wCK_ApplyChecks.btnApplyChecks, Config.iTimeout * 10, true);

            pMain._SelectTab(sDataService);




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

            dic.Clear();
            dic.Add("CheckName", "All");
            dic.Add("Include", "False");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, true);

            pData._CK_CheckGrip_SendKeys("{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}");
            pData._CK_CheckGrip_SendKeys("{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}");

            dic.Clear();
            dic.Add("CheckName", "Active Checks");
            dic.Add("Include", "True");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, true);

            dic.Clear();
            dic.Add("CheckName", "Deferred Checks");
            dic.Add("Include", "True");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, true);

            dic.Clear();
            dic.Add("CheckName", "Pensioner Checks");
            dic.Add("Include", "True");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, true);

            dic.Clear();
            dic.Add("CheckName", "Dependant Checks");
            dic.Add("Include", "True");
            dic.Add("ViewCheck", "");
            dic.Add("Filter", "");
            dic.Add("EditFilter", "");
            dic.Add("#Failed", "");
            dic.Add("#Passed", "");
            dic.Add("#Error", "");
            dic.Add("#NA", "");
            pData._CK_CheckGrip(dic, true, true, true);

            dic.Clear();
            dic.Add("CheckName", "Post Derivation Checks");
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
            _gLib._Exists("", pData.wRetirementStudio.wCK_ApplyChecks.btnApplyChecks, Config.iTimeout * 15, true);
            _gLib._Enabled("", pData.wRetirementStudio.wCK_ApplyChecks.btnApplyChecks, Config.iTimeout * 15, true);

            pMain._SelectTab(sDataService);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "Click");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);

            _gLib._Exists("", pData.wRetirementStudio.wCK_ApplyChecks.btnApplyChecks, Config.iTimeout * 5, true);
            _gLib._Enabled("", pData.wRetirementStudio.wCK_ApplyChecks.btnApplyChecks, Config.iTimeout * 5, true);

            pMain._SelectTab(sDataService);
            mTime.StopTimer(iCK_Apply);
            mLog.LogInfo(iCK_Apply, MyPerformanceCounter.Memory_Private);


            //////////////mTime.StartTimer();

            //////////////_gLib._MsgBox("Active Checks => 80ths Sal Increase too high", "Please Click failed Number <291> in this Check and click OK to keep testing!");

            //////////////dic.Clear();
            //////////////dic.Add("PopVerify", "Pop");
            //////////////dic.Add("StandardInputs", "");
            //////////////dic.Add("AddCustomGroup", "");
            //////////////dic.Add("AddCheck", "");
            //////////////dic.Add("ApplyChecks", "");
            //////////////dic.Add("ClearAllResults", "");
            //////////////dic.Add("AllQuery", "True");
            //////////////dic.Add("AllPlug", "");
            //////////////dic.Add("AllOK", "");
            //////////////dic.Add("Notes", "");
            //////////////pData._PopVerify_Checks(dic);

            //////////////_gLib._MsgBox("Active Checks => 60ths Sal Increase too high", "Please Click failed Number <22> in this Check and click OK to keep testing!");

            //////////////dic.Clear();
            //////////////dic.Add("PopVerify", "Pop");
            //////////////dic.Add("StandardInputs", "");
            //////////////dic.Add("AddCustomGroup", "");
            //////////////dic.Add("AddCheck", "");
            //////////////dic.Add("ApplyChecks", "");
            //////////////dic.Add("ClearAllResults", "");
            //////////////dic.Add("AllQuery", "True");
            //////////////dic.Add("AllPlug", "");
            //////////////dic.Add("AllOK", "");
            //////////////dic.Add("Notes", "");
            //////////////pData._PopVerify_Checks(dic);


            //////////////mTime.StopTimer(iCK_SetQueryForFailChecks);
            //////////////mLog.LogInfo(iCK_SetQueryForFailChecks, MyPerformanceCounter.Memory_Private);

            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Reports");
            dic.Add("MenuItem", "Add new report");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Checks", "");
            dic.Add("Checks_Filter", "Query");
            dic.Add("StatusMatrix", "");
            dic.Add("StatusMatrix_Filter", "");
            dic.Add("ReportName", "SalaryQueries");
            dic.Add("GenerateReport", "");
            pData._PopVerify_Reports(dic);

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

            pMain._SelectTab(sDataService);


            mTime.StopTimer(iRP_GenerateQueryReport);
            mLog.LogInfo(iRP_GenerateQueryReport, MyPerformanceCounter.Memory_Private);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", sDataService);
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            //////////////dic.Clear();
            //////////////dic.Add("Level_1", sDataService);
            //////////////dic.Add("Level_2", "Output Manager");
            //////////////pData._TreeViewSelect(dic);



            ////////////////mTime.StartTimer();

            ////////////////pData._OM_ExportReport_SubReports(sOutputDir, "Reports Summary", "QueryReport", 130, 1, false);

            ////////////////mTime.StopTimer(iRP_ExportQueryReport);
            ////////////////mLog.LogInfo(iRP_ExportQueryReport, MyPerformanceCounter.Memory_Private);




            #endregion


            #region ValuationData1/4/2014 - View & Update


            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "View & Update");
            dic.Add("MenuItem", "Import view from ...");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", sClient_CopyFrom);
            dic.Add("Plan", sPlan_CopyFrom);
            dic.Add("Service", "ValuationData1/4/2014");
            dic.Add("OK", "");
            pData._PopVerify_DG_CopyDerivations(dic);


            dic.Clear();
            dic.Add("Level_1", "All");
            pData._TreeViewSelect_CopyDerivations(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", "");
            dic.Add("Plan", "");
            dic.Add("Service", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_CopyDerivations(dic);

            _gLib._Exists("", pData.wCopyValidationErrors, Config.iTimeout * 10, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Copy", "click");
            pData._PopVerify_CopyValidationErrors(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_DataAcquisitions(dic);


            _gLib._Enabled("", pData.wRetirementStudio.wVU_Apply, Config.iTimeout * 10, true);

            pMain._SelectTab(sDataService);




            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "View & Update");
            dic.Add("Level_3", "Actives60ths");
            pData._TreeViewSelect(dic);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Filter", "");
            dic.Add("Apply", "Click");
            pData._PopVerify_ViewUpdate(dic);

            _gLib._Enabled("", pData.wRetirementStudio.wVU_Apply, Config.iTimeout * 10, true);
            pMain._SelectTab(sDataService);

            mTime.StopTimer(iVU_Actives60ths_Apply);
            mLog.LogInfo(iVU_Actives60ths_Apply, MyPerformanceCounter.Memory_Private);


            pData._SelectTab_VU("Data Summary");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("Apply", "");
            dic.Add("GenerateSummary", "Click");
            pData._PopVerify_ViewUpdate(dic);

            pData._SelectTab_VU("Data Summary");

            mTime.StopTimer(iVU_Actives60ths_GenerateSummary);
            mLog.LogInfo(iVU_Actives60ths_GenerateSummary, MyPerformanceCounter.Memory_Private);


            pData._SelectTab_VU("Data Summary");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("Apply", "");
            dic.Add("GenerateSummary", "");
            dic.Add("PrintToFile", "Click");
            pData._PopVerify_ViewUpdate(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_VU_PrintToFile_Popup(dic);


            mTime.StopTimer(iVU_Actives60ths_PrintToFile);
            mLog.LogInfo(iVU_Actives60ths_PrintToFile, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Output Manager");
            pData._TreeViewSelect(dic);


            mTime.StartTimer();

            pData._OM_Navigate("View and Update");
            pOutputManager._Excel_SaveFile(sOutputDir + "Active60ths_PrintToFile.xls");

            mTime.StopTimer(iVU_Actives60ths_ExportExcel);
            mLog.LogInfo(iVU_Actives60ths_ExportExcel, MyPerformanceCounter.Memory_Private);



            pMain._SelectTab(sDataService);


            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "View & Update");
            dic.Add("Level_3", "Actives80ths");
            pData._TreeViewSelect(dic);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Filter", "");
            dic.Add("Apply", "Click");
            pData._PopVerify_ViewUpdate(dic);

            _gLib._Enabled("", pData.wRetirementStudio.wVU_Apply, Config.iTimeout * 10, true);
            pMain._SelectTab(sDataService);

            mTime.StopTimer(iVU_Actives80ths_Apply);
            mLog.LogInfo(iVU_Actives80ths_Apply, MyPerformanceCounter.Memory_Private);


            pData._SelectTab_VU("Data Summary");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("Apply", "");
            dic.Add("GenerateSummary", "Click");
            pData._PopVerify_ViewUpdate(dic);

            pData._SelectTab_VU("Data Summary");

            mTime.StopTimer(iVU_Actives80ths_GenerateSummary);
            mLog.LogInfo(iVU_Actives80ths_GenerateSummary, MyPerformanceCounter.Memory_Private);


            pData._SelectTab_VU("Data Summary");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("Apply", "");
            dic.Add("GenerateSummary", "");
            dic.Add("PrintToFile", "Click");
            pData._PopVerify_ViewUpdate(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_VU_PrintToFile_Popup(dic);


            mTime.StopTimer(iVU_Actives80ths_PrintToFile);
            mLog.LogInfo(iVU_Actives80ths_PrintToFile, MyPerformanceCounter.Memory_Private);



            pMain._SelectTab(sDataService);


            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "View & Update");
            dic.Add("Level_3", "Deferreds");
            pData._TreeViewSelect(dic);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Filter", "");
            dic.Add("Apply", "Click");
            pData._PopVerify_ViewUpdate(dic);

            _gLib._Enabled("", pData.wRetirementStudio.wVU_Apply, Config.iTimeout * 10, true);
            pMain._SelectTab(sDataService);

            mTime.StopTimer(iVU_Deferreds_Apply);
            mLog.LogInfo(iVU_Deferreds_Apply, MyPerformanceCounter.Memory_Private);


            pData._SelectTab_VU("Data Summary");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("Apply", "");
            dic.Add("GenerateSummary", "Click");
            pData._PopVerify_ViewUpdate(dic);

            pData._SelectTab_VU("Data Summary");

            mTime.StopTimer(iVU_Deferreds_GenerateSummary);
            mLog.LogInfo(iVU_Deferreds_GenerateSummary, MyPerformanceCounter.Memory_Private);


            pData._SelectTab_VU("Data Summary");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("Apply", "");
            dic.Add("GenerateSummary", "");
            dic.Add("PrintToFile", "Click");
            pData._PopVerify_ViewUpdate(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_VU_PrintToFile_Popup(dic);


            mTime.StopTimer(iVU_Deferreds_PrintToFile);
            mLog.LogInfo(iVU_Deferreds_PrintToFile, MyPerformanceCounter.Memory_Private);




            pMain._SelectTab(sDataService);


            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "View & Update");
            dic.Add("Level_3", "Pensioners");
            pData._TreeViewSelect(dic);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Filter", "");
            dic.Add("Apply", "Click");
            pData._PopVerify_ViewUpdate(dic);

            _gLib._Enabled("", pData.wRetirementStudio.wVU_Apply, Config.iTimeout * 10, true);
            pMain._SelectTab(sDataService);

            mTime.StopTimer(iVU_Pensioners_Apply);
            mLog.LogInfo(iVU_Pensioners_Apply, MyPerformanceCounter.Memory_Private);


            pData._SelectTab_VU("Data Summary");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("Apply", "");
            dic.Add("GenerateSummary", "Click");
            pData._PopVerify_ViewUpdate(dic);

            pData._SelectTab_VU("Data Summary");

            mTime.StopTimer(iVU_Pensioners_GenerateSummary);
            mLog.LogInfo(iVU_Pensioners_GenerateSummary, MyPerformanceCounter.Memory_Private);


            pData._SelectTab_VU("Data Summary");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("Apply", "");
            dic.Add("GenerateSummary", "");
            dic.Add("PrintToFile", "Click");
            pData._PopVerify_ViewUpdate(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_VU_PrintToFile_Popup(dic);


            mTime.StopTimer(iVU_Pensioners_PrintToFile);
            mLog.LogInfo(iVU_Pensioners_PrintToFile, MyPerformanceCounter.Memory_Private);




            pMain._SelectTab(sDataService);


            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "View & Update");
            dic.Add("Level_3", "Beneficiaries");
            pData._TreeViewSelect(dic);


            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Filter", "");
            dic.Add("Apply", "Click");
            pData._PopVerify_ViewUpdate(dic);

            _gLib._Enabled("", pData.wRetirementStudio.wVU_Apply, Config.iTimeout * 10, true);
            pMain._SelectTab(sDataService);

            mTime.StopTimer(iVU_Beneficiaries_Apply);
            mLog.LogInfo(iVU_Beneficiaries_Apply, MyPerformanceCounter.Memory_Private);


            pData._SelectTab_VU("Data Summary");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("Apply", "");
            dic.Add("GenerateSummary", "Click");
            pData._PopVerify_ViewUpdate(dic);

            pData._SelectTab_VU("Data Summary");

            mTime.StopTimer(iVU_Beneficiaries_GenerateSummary);
            mLog.LogInfo(iVU_Beneficiaries_GenerateSummary, MyPerformanceCounter.Memory_Private);


            pData._SelectTab_VU("Data Summary");

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("Apply", "");
            dic.Add("GenerateSummary", "");
            dic.Add("PrintToFile", "Click");
            pData._PopVerify_ViewUpdate(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_VU_PrintToFile_Popup(dic);


            mTime.StopTimer(iVU_Beneficiaries_PrintToFile);
            mLog.LogInfo(iVU_Beneficiaries_PrintToFile, MyPerformanceCounter.Memory_Private);



            #endregion


            #region ValuationData1/4/2014 - Derivaion Groups


            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Import Derivations from ...");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", sClient_CopyFrom);
            dic.Add("Plan", sPlan_CopyFrom);
            dic.Add("Service", "ValuationData1/4/2014");
            dic.Add("OK", "");
            pData._PopVerify_DG_CopyDerivations(dic);


            dic.Clear();
            dic.Add("Level_1", "All");
            dic.Add("Level_2", "Actives");
            pData._TreeViewSelect_CopyDerivations(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", "");
            dic.Add("Plan", "");
            dic.Add("Service", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_CopyDerivations(dic);

            _gLib._Exists("", pData.wCopyValidationErrors, Config.iTimeout * 10, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Copy", "click");
            pData._PopVerify_CopyValidationErrors(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_DataAcquisitions(dic);


            _gLib._Enabled("", pData.wRetirementStudio.wVU_Apply, Config.iTimeout * 10, true);

            pMain._SelectTab(sDataService);


            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Import Derivations from ...");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", sClient_CopyFrom);
            dic.Add("Plan", sPlan_CopyFrom);
            dic.Add("Service", "ValuationData1/4/2014");
            dic.Add("OK", "");
            pData._PopVerify_DG_CopyDerivations(dic);


            dic.Clear();
            dic.Add("Level_1", "All");
            dic.Add("Level_2", "Deferreds");
            pData._TreeViewSelect_CopyDerivations(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", "");
            dic.Add("Plan", "");
            dic.Add("Service", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_CopyDerivations(dic);

            _gLib._Exists("", pData.wCopyValidationErrors, Config.iTimeout * 10, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Copy", "click");
            pData._PopVerify_CopyValidationErrors(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_DataAcquisitions(dic);


            _gLib._Enabled("", pData.wRetirementStudio.wVU_Apply, Config.iTimeout * 10, true);

            pMain._SelectTab(sDataService);



            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Import Derivations from ...");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", sClient_CopyFrom);
            dic.Add("Plan", sPlan_CopyFrom);
            dic.Add("Service", "ValuationData1/4/2014");
            dic.Add("OK", "");
            pData._PopVerify_DG_CopyDerivations(dic);


            dic.Clear();
            dic.Add("Level_1", "All");
            dic.Add("Level_2", "Pensioners");
            pData._TreeViewSelect_CopyDerivations(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", "");
            dic.Add("Plan", "");
            dic.Add("Service", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_CopyDerivations(dic);

            _gLib._Exists("", pData.wCopyValidationErrors, Config.iTimeout * 10, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Copy", "click");
            pData._PopVerify_CopyValidationErrors(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_DataAcquisitions(dic);


            _gLib._Enabled("", pData.wRetirementStudio.wVU_Apply, Config.iTimeout * 10, true);

            pMain._SelectTab(sDataService);


            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Import Derivations from ...");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", sClient_CopyFrom);
            dic.Add("Plan", sPlan_CopyFrom);
            dic.Add("Service", "ValuationData1/4/2014");
            dic.Add("OK", "");
            pData._PopVerify_DG_CopyDerivations(dic);


            dic.Clear();
            dic.Add("Level_1", "All");
            dic.Add("Level_2", "Beneficiaries");
            pData._TreeViewSelect_CopyDerivations(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", "");
            dic.Add("Plan", "");
            dic.Add("Service", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_CopyDerivations(dic);

            _gLib._Exists("", pData.wCopyValidationErrors, Config.iTimeout * 10, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Copy", "click");
            pData._PopVerify_CopyValidationErrors(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_DataAcquisitions(dic);


            _gLib._Enabled("", pData.wRetirementStudio.wVU_Apply, Config.iTimeout * 10, true);

            pMain._SelectTab(sDataService);


            for (int i = 1; i <= 4; i++)
            {
                dic.Clear();
                dic.Add("Level_1", sDataService);
                dic.Add("Level_2", "Derivation Groups");
                dic.Add("Level_3", "Reset_IH_PensionerUSC_for_PPF");
                dic.Add("MenuItem", "Move Down");
                pData._TreeViewRightSelect(dic);

            }

            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Actives");
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
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            pMain._SelectTab(sDataService);

            mTime.StopTimer(iDG_Actives_CalcPreview);
            mLog.LogInfo(iDG_Actives_CalcPreview, MyPerformanceCounter.Memory_Private);


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


            mTime.StopTimer(iDG_Actives_SaveWH);
            mLog.LogInfo(iDG_Actives_SaveWH, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Deferreds");
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
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            pMain._SelectTab(sDataService);

            mTime.StopTimer(iDG_Deferreds_CalcPreview);
            mLog.LogInfo(iDG_Deferreds_CalcPreview, MyPerformanceCounter.Memory_Private);


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


            mTime.StopTimer(iDG_Deferreds_SaveWH);
            mLog.LogInfo(iDG_Deferreds_SaveWH, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Pensioners");
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
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            pMain._SelectTab(sDataService);

            mTime.StopTimer(iDG_Penioners_CalcPreview);
            mLog.LogInfo(iDG_Penioners_CalcPreview, MyPerformanceCounter.Memory_Private);


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


            mTime.StopTimer(iDG_Penioners_SaveWH);
            mLog.LogInfo(iDG_Penioners_SaveWH, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Beneficiaries");
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
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            pMain._SelectTab(sDataService);

            mTime.StopTimer(iDG_Beneficiaries_CalcPreview);
            mLog.LogInfo(iDG_Beneficiaries_CalcPreview, MyPerformanceCounter.Memory_Private);


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


            mTime.StopTimer(iDG_Beneficiaries_SaveWH);
            mLog.LogInfo(iDG_Beneficiaries_SaveWH, MyPerformanceCounter.Memory_Private);






            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Reset_IH_PensionerUSC_for_PPF");
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
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            pMain._SelectTab(sDataService);

            mTime.StopTimer(iDG_Reset_IH_PensionerUSC_for_PPF_CalcPreview);
            mLog.LogInfo(iDG_Reset_IH_PensionerUSC_for_PPF_CalcPreview, MyPerformanceCounter.Memory_Private);


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


            mTime.StopTimer(iDG_Reset_IH_PensionerUSC_for_PPF_SaveWH);
            mLog.LogInfo(iDG_Reset_IH_PensionerUSC_for_PPF_SaveWH, MyPerformanceCounter.Memory_Private);



            #endregion





            #region ValuationData1/4/2014 - Check, Snapshot, Undo


            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Checks");
            pData._TreeViewSelect(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab(sDataService);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StandardInputs", "");
            dic.Add("AddCustomGroup", "");
            dic.Add("AddCheck", "");
            dic.Add("ApplyChecks", "Click");
            dic.Add("ClearAllResults", "");
            pData._PopVerify_Checks(dic);


            pMain._SelectTab(sDataService);

            mTime.StopTimer(iCK_ReApply);
            mLog.LogInfo(iCK_ReApply, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "2011Data");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "2014Data");
            dic.Add("UseLatestDate", "");
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
            dic.Add("Level_3", "PostCode");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ImportName");
            pData._TreeViewSelect_Snapshots(dic, false);



            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "CPSreckServ");
            pData._TreeViewSelect_Snapshots(dic, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            pData._TreeViewSelect_Snapshots(dic, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "FTEfor60ths");
            dic.Add("Level_5", "FTEfor60thsCurrentYear");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "FTEfor80ths");
            dic.Add("Level_5", "FTEfor80thsCurrentYear");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "FTEfor80ths");
            dic.Add("Level_5", "FTEfor80thsPriorYear1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "ShiftPay");
            dic.Add("Level_5", "ShiftPayCurrentYear");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "ShiftPay");
            dic.Add("Level_5", "ShiftPayPriorYear1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "BeneficiaryIDNumber");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1Percent1");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1PaymentForm1");
            pData._TreeViewSelect_Snapshots(dic, false);


            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab(sDataService);

            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "Click");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            pMain._SelectTab(sDataService);

            mTime.StopTimer(iSS_Preview);
            mLog.LogInfo(iSS_Preview, MyPerformanceCounter.Memory_Private);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("Filter", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("Preview_Next", "Click");
            dic.Add("Preview_Last", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);


            pMain._SelectTab(sDataService);

            mTime.StopTimer(iSS_Navi_Next);
            mLog.LogInfo(iSS_Navi_Next, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("Filter", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("Preview_Next", "");
            dic.Add("Preview_Last", "Click");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);


            pMain._SelectTab(sDataService);

            mTime.StopTimer(iSS_Navi_Last);
            mLog.LogInfo(iSS_Navi_Last, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "Click");
            dic.Add("CreateExtract", "");
            dic.Add("CheckPopup", "False");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_SP_Snapshots_Popup(dic);

            pMain._SelectTab(sDataService);

            mTime.StopTimer(iSS_Publish);
            mLog.LogInfo(iSS_Publish, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            pData._ts_SP_CreateExtract(sOutputDir + "Data2014_SnapshotExtract.xlsx");


            mTime.StopTimer(iSS_Extract);
            mLog.LogInfo(iSS_Extract, MyPerformanceCounter.Memory_Private);



            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Undo");
            pData._TreeViewSelect(dic);

            mTime.StartTimer();

            pData._ts_Undo("PostMatchDerivations for SetNPA", 3, "new import required");

            pMain._SelectTab(sDataService);


            mTime.StopTimer(iUndo);
            mLog.LogInfo(iUndo, MyPerformanceCounter.Memory_Private);


            #endregion


            #region ValuationData1/4/2014 - New Import, Derivations


            mTime.StartTimer();


            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);


            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "ActivesUpdatedERCodes");
            dic.Add("FileType", "Excel file");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "ActivesUpdateERCodesData.xlsx");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._SelectTab("Mapping");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_Mapping(dic);


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
            dic.Add("PopVerify", "Pop");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);


            mTime.StopTimer(iIM_ActivesUpdatedERCodes);
            mLog.LogInfo(iIM_ActivesUpdatedERCodes, MyPerformanceCounter.Memory_Private);



            pData._SelectTab("Matching");



            dic.Clear();
            dic.Add("Field", "EmployeeIDNumber");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ImportFilter", "");
            dic.Add("WarehouseFilter", "=USC_C=\"Act\"");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);

            ////////////dic.Clear();
            ////////////dic.Add("PopVerify", "Verify");
            ////////////dic.Add("Unique_NoMatch_Num", "");
            ////////////dic.Add("Unique_UniqueMatch_Num", "431");
            ////////////dic.Add("Unique_MultipleMatches_Num", "");
            ////////////dic.Add("Duplicate_NoMatch_Num", "");
            ////////////dic.Add("Duplicate_UniqueMatch_Num", "");
            ////////////dic.Add("Duplicate_MultipleMatches_Num", "");
            ////////////dic.Add("Warehouse_NoMatch_Num", "");
            ////////////pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);


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


            pMain._SelectTab(sDataService);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RefreshResults", "");
            dic.Add("UnacceptAllRecords", "");
            dic.Add("UnacceptSelectedRecords", "");
            dic.Add("SaveToWarehouse", "Click");
            dic.Add("MergeDuplicates", "");
            pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic);


            if (_gLib._Exists("", pData.wIP_Matching_ProcessMatchingResultsContinue_Popup.wOK, 3, false))
                _gLib._SetSyncUDWin("OK", pData.wIP_Matching_ProcessMatchingResultsContinue_Popup.wOK.btn, "Click", 0);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);




            mTime.StopTimer(iIM_ActivesUpdatedERCodes_SaveToWarehouse);
            mLog.LogInfo(iIM_ActivesUpdatedERCodes_SaveToWarehouse, MyPerformanceCounter.Memory_Private);







            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "SetNPA");
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
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            pMain._SelectTab(sDataService);

            mTime.StopTimer(iDG_SetNPA_ReCalcPreview);
            mLog.LogInfo(iDG_SetNPA_ReCalcPreview, MyPerformanceCounter.Memory_Private);


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


            mTime.StopTimer(iDG_SetNPA_ReSaveWH);
            mLog.LogInfo(iDG_SetNPA_ReSaveWH, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Actives");
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
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            pMain._SelectTab(sDataService);

            mTime.StopTimer(iDG_Actives_ReCalcPreview);
            mLog.LogInfo(iDG_Actives_ReCalcPreview, MyPerformanceCounter.Memory_Private);


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


            mTime.StopTimer(iDG_Actives_ReSaveWH);
            mLog.LogInfo(iDG_Actives_ReSaveWH, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Deferreds");
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
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            pMain._SelectTab(sDataService);

            mTime.StopTimer(iDG_Deferreds_ReCalcPreview);
            mLog.LogInfo(iDG_Deferreds_ReCalcPreview, MyPerformanceCounter.Memory_Private);


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


            mTime.StopTimer(iDG_Deferreds_ReSaveWH);
            mLog.LogInfo(iDG_Deferreds_ReSaveWH, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Pensioners");
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
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            pMain._SelectTab(sDataService);

            mTime.StopTimer(iDG_Penioners_ReCalcPreview);
            mLog.LogInfo(iDG_Penioners_ReCalcPreview, MyPerformanceCounter.Memory_Private);


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


            mTime.StopTimer(iDG_Penioners_ReSaveWH);
            mLog.LogInfo(iDG_Penioners_ReSaveWH, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Beneficiaries");
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
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            pMain._SelectTab(sDataService);

            mTime.StopTimer(iDG_Beneficiaries_ReCalcPreview);
            mLog.LogInfo(iDG_Beneficiaries_ReCalcPreview, MyPerformanceCounter.Memory_Private);


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


            mTime.StopTimer(iDG_Beneficiaries_ReSaveWH);
            mLog.LogInfo(iDG_Beneficiaries_ReSaveWH, MyPerformanceCounter.Memory_Private);






            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Reset_IH_PensionerUSC_for_PPF");
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
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            pMain._SelectTab(sDataService);

            mTime.StopTimer(iDG_Reset_IH_PensionerUSC_for_PPF_ReCalcPreview);
            mLog.LogInfo(iDG_Reset_IH_PensionerUSC_for_PPF_ReCalcPreview, MyPerformanceCounter.Memory_Private);


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


            mTime.StopTimer(iDG_Reset_IH_PensionerUSC_for_PPF_ReSaveWH);
            mLog.LogInfo(iDG_Reset_IH_PensionerUSC_for_PPF_ReSaveWH, MyPerformanceCounter.Memory_Private);



            #endregion



            #region ValuationData1/4/2014 - BatchUpdate, Snapshot


            mTime.StartTimer();


            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Batch Update");
            dic.Add("MenuItem", "Add new batch update");
            pData._TreeViewRightSelect(dic);

            _gLib._Enabled("", pData.wRetirementStudio.wBU_Apply, Config.iTimeout * 3);

            mTime.StopTimer(iBU_Add);
            mLog.LogInfo(iBU_Add, MyPerformanceCounter.Memory_Private);

            mTime.StartTimer();



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "Change_Sal_for_FerryA1_and_EnoG19");
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
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "FTEfor80ths");
            dic.Add("Level_5", "FTEfor80thsPriorYear1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "True");
            dic.Add("CustomExpression_Formula", "=(OR(EmployeeIDNumber_C=\"AW129219B\",EmployeeIDNumber_C=\"SP149279T\"))");
            dic.Add("CustomExpression_Accept", "Click");
            dic.Add("Apply", "Click");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);



            pData._BU_FPGrid("AW129219B", 3, "43081.72", 4, "");

            pData._BU_FPGrid("SP149279T", 3, "29899.82", 4, "");


            pMain._SelectTab(sDataService);

            mTime.StopTimer(iBU_Edit);
            mLog.LogInfo(iBU_Edit, MyPerformanceCounter.Memory_Private);


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

            pMain._SelectTab(sDataService);

            mTime.StopTimer(iBU_SaveWH);
            mLog.LogInfo(iBU_SaveWH, MyPerformanceCounter.Memory_Private);


            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "View & Update");
            dic.Add("Level_3", "Actives80ths");
            pData._TreeViewSelect(dic);

            ////////////////////dic.Clear();
            ////////////////////dic.Add("PopVerify", "Pop");
            ////////////////////dic.Add("OK", "");
            ////////////////////dic.Add("Yes", "Click");
            ////////////////////pData._PopVerify_CK_Warning_Popup(dic);

            pMain._SelectTab(sDataService);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("Apply", "");
            dic.Add("GenerateSummary", "");
            dic.Add("PrintToFile", "");
            dic.Add("ViewAllManualChanges", "Click");
            pData._PopVerify_ViewUpdate(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_VU_ReportOnManualChanges(dic);

            mTime.StopTimer(iVU_ViewAllManualChanges);
            mLog.LogInfo(iVU_ViewAllManualChanges, MyPerformanceCounter.Memory_Private);




            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "2014Data");
            pData._TreeViewSelect(dic);



            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab(sDataService);

            mTime.StartTimer();


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "Click");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            pMain._SelectTab(sDataService);

            mTime.StopTimer(iSS_RePreview);
            mLog.LogInfo(iSS_RePreview, MyPerformanceCounter.Memory_Private);

            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("Filter", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("Preview_Next", "Click");
            dic.Add("Preview_Last", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);


            pMain._SelectTab(sDataService);

            mTime.StopTimer(iSS_ReNavi_Next);
            mLog.LogInfo(iSS_ReNavi_Next, MyPerformanceCounter.Memory_Private);


            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("Filter", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("Preview_Next", "");
            dic.Add("Preview_Last", "Click");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);


            pMain._SelectTab(sDataService);

            mTime.StopTimer(iSS_ReNavi_Last);
            mLog.LogInfo(iSS_ReNavi_Last, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "Click");
            dic.Add("CreateExtract", "");
            dic.Add("CheckPopup", "False");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_SP_Snapshots_Popup(dic);

            pMain._SelectTab(sDataService);

            mTime.StopTimer(iSS_RePublish);
            mLog.LogInfo(iSS_RePublish, MyPerformanceCounter.Memory_Private);



            mTime.StartTimer();

            pData._ts_SP_CreateExtract(sOutputDir + "Data2014_SnapshotExtract_Redo.xlsx");


            mTime.StopTimer(iSS_ReExtract);
            mLog.LogInfo(iSS_ReExtract, MyPerformanceCounter.Memory_Private);



            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            mLog.LogInfo(iTimeEnd, DateTime.Now.ToString());


            _gLib._MsgBox("Congratulations!", "Finished!");

            Environment.Exit(0);




            ////// below codes is to create conversion data service


            #region Create Client

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
            dic.Add("ClientCode", "Test UK Limit");
            dic.Add("FiscalYearEnd", "12/31");
            dic.Add("MeasurementDate", "09/30");
            dic.Add("Notes", "Original client in EUProd: ZZZZ-Testing_Jacqui_Exe");
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
            dic.Add("Country", "United Kingdom");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_PMTool_CountrySelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanName", Config.sPlanName);
            dic.Add("PlanYearBegin", "01/01");
            dic.Add("PSOReferenceNumber", "");
            dic.Add("SCON", "");
            dic.Add("TaxRegistrationStatus", "");
            dic.Add("FRS17", "");
            dic.Add("FAS87", "");
            dic.Add("IAS19", "");
            dic.Add("Works", "");
            dic.Add("Staff", "");
            dic.Add("Execs", "");
            dic.Add("PublicSectorProjection", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_PMTool_Plan_UK(dic);



            #endregion


            #region ConversionData - Current View & Upload

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            pMain._HomeTreeViewSelect(0, dic);

            _gLib._MsgBox("Mannual Interaction", "Please mannually click on plan: " + Config.sClientName + ">>" + Config.sPlanName);

            dic.Clear();
            dic.Add("EnterShortName", "Cat60ths");
            dic.Add("ConfirmShortName", "Cat60ths");
            dic.Add("LongName", "Category_60ths_Accrual");
            pMain._ts_CreateNewBenefitSet(dic);

            dic.Clear();
            dic.Add("EnterShortName", "Cat80ths");
            dic.Add("ConfirmShortName", "Cat80ths");
            dic.Add("LongName", "Category_80ths_Accrual");
            pMain._ts_CreateNewBenefitSet(dic);


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
            dic.Add("Name", "ConversionData1/4/2011");
            dic.Add("EffectiveDate", "01/04/2011");
            dic.Add("Parent", "");
            dic.Add("RSC", "");
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
            dic.Add("ServiceToOpen", "ConversionData1/4/2011");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("Level_1", "ConversionData1/4/2011");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "ContSpPre88GMP");
            dic.Add("DisplayName", "Contingent spouses pre 88 GMP");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "ContSpPst88GMP");
            dic.Add("DisplayName", "Contingent spouses post 88 GMP");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "DpPre88GMP2009");
            dic.Add("DisplayName", "Deferred Pre 88 GMP at 2009 val");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "DpPst88GMP2009");
            dic.Add("DisplayName", "Deferred Post 88 GMP at 2009 val");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "TVinPension");
            dic.Add("DisplayName", "TVin Pension granted");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "GMPRevType");
            dic.Add("DisplayName", "GMP revaluation type");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Text");
            dic.Add("FieldLength", "10");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "DefPre88GMP2009");
            dic.Add("DisplayName", "Deferred Pre 88 GMP at 2009");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "DefPst88GMP2009");
            dic.Add("DisplayName", "Deferred Post 88 GMP at 2009");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "Pre97XS2009");
            dic.Add("DisplayName", "Pre 97 XS at 2009");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "Post97Pen2009");
            dic.Add("DisplayName", "Post 97 pension at 2009");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "TotalDefPen2009");
            dic.Add("DisplayName", "Total Deferred pension at 2009");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "DpPre88GMPval");
            dic.Add("DisplayName", "Deferred Pre 88 GMP at val date");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "DpPst88GMPval");
            dic.Add("DisplayName", "Deferred post 88 GMP at val date");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "Pre97XSval");
            dic.Add("DisplayName", "Pre 97 XS at val date");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "Post97PenVal");
            dic.Add("DisplayName", "Post 9 pension at val date");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "TotalDefPenVal");
            dic.Add("DisplayName", "Total def pen val date");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "Post10PenVal");
            dic.Add("DisplayName", "Post 2010 pen at val date");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "Post10PenExit");
            dic.Add("DisplayName", "Post 2010 pension at DOL");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "GMPMembershipDate1");
            dic.Add("DisplayName", "GMPMembershipDate1");
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



            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Classification Codes");
            dic.Add("Label", "Employer");
            dic.Add("DisplayName", "Employer location code");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Text");
            dic.Add("FieldLength", "4");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Classification Codes");
            dic.Add("Label", "ShiftPayType");
            dic.Add("DisplayName", "Shift pay classification");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Text");
            dic.Add("FieldLength", "1");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Classification Codes");
            dic.Add("Label", "NPA");
            dic.Add("DisplayName", "Normal Pension Age");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Integer");
            dic.Add("FieldLength", "2");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Classification Codes");
            dic.Add("Label", "RetirementType");
            dic.Add("DisplayName", "Type of retirement");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Text");
            dic.Add("FieldLength", "100");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Classification Codes");
            dic.Add("Label", "ClassCode");
            dic.Add("DisplayName", "ClassCode");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Integer");
            dic.Add("FieldLength", "1");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            pData._CV_ExpandPersonalInformation();



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Personal Information");
            dic.Add("Label", "DCPS");
            dic.Add("DisplayName", "Date Commenced Pensionable Serv");
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


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Personal Information");
            dic.Add("Label", "BackdatedDJC");
            dic.Add("DisplayName", "Backdated Date Joined Company");
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



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Personal Information");
            dic.Add("Label", "ETY");
            dic.Add("DisplayName", "GRS ETY label");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Integer");
            dic.Add("FieldLength", "2");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Service");
            dic.Add("Label", "TotalTVinServ");
            dic.Add("DisplayName", "Total TVin Serv");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "5");
            dic.Add("DecimalPlaces", "3");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Service");
            dic.Add("Label", "AddedYrsServ");
            dic.Add("DisplayName", "Added years service");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "5");
            dic.Add("DecimalPlaces", "3");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Service");
            dic.Add("Label", "StrikeServ");
            dic.Add("DisplayName", "Strike Service");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "5");
            dic.Add("DecimalPlaces", "3");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Service");
            dic.Add("Label", "PTFR");
            dic.Add("DisplayName", "Part time fraction");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "8");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Service");
            dic.Add("Label", "SPPcredit");
            dic.Add("DisplayName", "SPP service credit");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "5");
            dic.Add("DecimalPlaces", "3");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Service");
            dic.Add("Label", "CPSreckServ");
            dic.Add("DisplayName", "SPP CPSreckServ");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "5");
            dic.Add("DecimalPlaces", "3");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Pay");
            dic.Add("Label", "FTEfor60ths");
            dic.Add("DisplayName", "FTE pay for 60ths ben CY");
            dic.Add("HistoryLabels", "3");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "01/04/2011");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Pay");
            dic.Add("Label", "FTEfor80ths");
            dic.Add("DisplayName", "FTE pay for 80ths ben CY");
            dic.Add("HistoryLabels", "4");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "01/04/2011");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Pay");
            dic.Add("Label", "ShiftPay");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "4");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "01/04/2011");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);



            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "ConversionData1/4/2011");
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
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\UK_Timing_TestWithData\ConversionData.xlsx");
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




            #endregion


            #region ConversionData - Imports

            dic.Clear();
            dic.Add("Level_1", "ConversionData1/4/2011");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "ConversionData");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "ConversionData.xlsx");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._IP_Mapping_Initialize("Personal Information", "Classification Codes", 1, 0, 1, "BenefitSetShortName");
            pData._IP_Mapping_MapField("ClassCode", "Class", 0, false, 18);

            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "EmployeeIDNumber");
            pData._IP_Mapping_MapField("ETY", "ETY", 0, false, 22);

            pData._IP_Mapping_ClickEdit("USC", false);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "Act");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "Def");

            pData._IP_Mapping_Transformation(3, 1, "20");
            pData._IP_Mapping_Transformation(3, 2, "Ret");

            pData._IP_Mapping_Transformation(4, 1, "30");
            pData._IP_Mapping_Transformation(4, 2, "RetBene");

            pData._IP_Mapping_Transformation(5, 1, "40");
            pData._IP_Mapping_Transformation(5, 2, "RetBene");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._SelectTab("Validate & Load");

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

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "987");
            dic.Add("Unique_UniqueMatch_Num", "0");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "8");
            dic.Add("Duplicate_UniqueMatch_Num", "0");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
            dic.Add("Warehouse_NoMatch_Num", "0");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);



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

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Matched_Num", "0");
            dic.Add("New_Num", "987");
            dic.Add("Ignored_Num", "0");
            dic.Add("Gone_Num", "0");
            dic.Add("Leaver_Num", "0");
            dic.Add("Unmatched_Num", "0");
            dic.Add("Unmerged_Num", "0");
            pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic);

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
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);






            #endregion


            #region ConversionData - Derivation Groups

            dic.Clear();
            dic.Add("Level_1", "ConversionData1/4/2011");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Import Derivations from ...");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", sClient_CopyFrom);
            dic.Add("Plan", sPlan_CopyFrom);
            dic.Add("Service", "ConversionData1/4/2011");
            dic.Add("OK", "");
            pData._PopVerify_DG_CopyDerivations(dic);

            dic.Clear();
            dic.Add("Level_1", "All");
            pData._TreeViewSelect_CopyDerivations(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", "");
            dic.Add("Plan", "");
            dic.Add("Service", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_CopyDerivations(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Copy", "click");
            pData._PopVerify_CopyValidationErrors(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_DataAcquisitions(dic);


            dic.Clear();
            dic.Add("Level_1", "ConversionData1/4/2011");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "SetBenefitSetShortName");
            pData._TreeViewSelect(dic);

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



            dic.Clear();
            dic.Add("Level_1", "ConversionData1/4/2011");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "SetBeneficiaryFieldsForRetBene");
            pData._TreeViewSelect(dic);

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



            dic.Clear();
            dic.Add("Level_1", "ConversionData1/4/2011");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "SetActivesNPA");
            pData._TreeViewSelect(dic);

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



            dic.Clear();
            dic.Add("Level_1", "ConversionData1/4/2011");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Reset_IH_PensionerUSC_for_PPF");
            pData._TreeViewSelect(dic);

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


            dic.Clear();
            dic.Add("Level_1", "ConversionData1/4/2011");
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            pData._TreeViewSelect_Snapshots(dic, true);

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
            dic.Add("Level_3", "PostCode");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ImportName");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "CPSreckServ");
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
            dic.Add("Level_3", "Beneficiary1Benefit1");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Ben1Ben1_Pre97");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Ben1Ben1_Post97PreA");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "Beneficiary1StartDate1");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "ContSpPre88GMP");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "ContSpPst88GMP");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "MembershipDate1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccruedBenefit1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccBen1_XSNonRev");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccBen1_XSRev");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccBen1_Post97PreA");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AccBen1_PostAPre09");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "ContribsWInterest1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "GMPPre88");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "GMPPost88");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit1DB");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit1DB_Pre97");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit1DB_Post97PreA");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit1DB_PostA");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "StartDate1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "YearsCertain1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "TVinPension");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "DpPre88GMPval");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "DpPst88GMPval");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Pre97XSval");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Post97PenVal");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "TotalDefPenVal");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Post10PenVal");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Post10PenExit");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "BenefitSetShortName");
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
            dic.Add("Level_3", "ClassCode");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "Employer");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "ShiftPayType");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "NPA");
            pData._TreeViewSelect_Snapshots(dic, true);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "2011Data");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "Click");
            dic.Add("PublishSnapshot", "Click");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_SP_Snapshots_Popup(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion

            _gLib._MsgBox("Congratulations!", "Conversion Finished!");

            Environment.Exit(0);




        }



        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            ////////mLog.LogInfo(iTest, MyPerformanceCounter.Memory_Private);
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
