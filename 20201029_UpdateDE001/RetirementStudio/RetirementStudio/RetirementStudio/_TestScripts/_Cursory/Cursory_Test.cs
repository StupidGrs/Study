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


// CA Screens
using RetirementStudio._UIMaps.DefinedBenefitLimitIncreaseClasses;


// DE Screens
using RetirementStudio._UIMaps.AssumedRetirementAgeClasses;
using RetirementStudio._UIMaps.ContractualRetirementAgeClasses;
using RetirementStudio._UIMaps.JubileeBenefitClasses;
using RetirementStudio._UIMaps.PlanDefinition_DEClasses;
using RetirementStudio._UIMaps.SocialSecurityContributionRatesClasses;
using RetirementStudio._UIMaps.ServiceSelectionClasses;
using RetirementStudio._UIMaps.ProjectAndProrateClasses;
using RetirementStudio._UIMaps.CostOfLivingAdjustmentsClasses;
using RetirementStudio._UIMaps.FormOfPayment_DEClasses;
using RetirementStudio._UIMaps.IndividualOuputFieldDefinitionClasses;
using RetirementStudio._UIMaps.Methods_DEClasses;
using RetirementStudio._UIMaps.ReportBreaksClasses;
using RetirementStudio._UIMaps.BreakFieldTextSubstitutionClasses;
using RetirementStudio._UIMaps.ActuarialReportClasses;
using System.Threading;


namespace RetirementStudio._TestScripts._Cursory
{
    /// <summary>
    /// Summary description for Cursory_Test
    /// </summary>
    [CodedUITest]
    public class Cursory_Test
    {
        public Cursory_Test()
        {

            //Config.eCountry = _Country.US;
            //Config.sClientName_F = "Build_Cursory_Client_Franklin";
            //Config.sClientName_D = "Build_Cursory_Client_Dallas";
            //Config.sClientName_F = "Build_Cursory_Client_Franklin_Backup";
            //Config.sClientName_D = "Build_Cursory_Client_Dallas_Backup";

            //Config.eCountry = _Country.US;
            //Config.sClientName = "Build_Cursory_Client_Canada";
            //Config.sClientName = "Build_Cursory_Client_Canada_Backup";
            //Config.sClientName = "Build_Cursory_Client_Canada_Backup_2";

            Config.eCountry = _Country.DE;
            Config.sClientName_B = "Build_Cursory_Client_Franklin";  /// this is for QA 
            //Config.sClientName_B = "Build_Cursory_Client_Bedford";
            //Config.sClientName_E = "Build_Cursory_Client_Exeter";
            //Config.sClientName_B = "Build_Cursory_Client_Bedford_Backup";
            //Config.sClientName_E = "Build_Cursory_Client_Exeter_Backup";



            Config.sPlanName_US = "US_Plan";
            Config.sPlanName_DE = "DE_Plan";
            ////Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;

            

        }


        static Boolean bPreprod = false;
        static string sPostFix = "_20200921";
        static string sData2012 = "Data2012" + sPostFix;
        static string sValuation2012 = "Valuation_2012" + sPostFix;
        static string sData2009 = "Pension_Data2009" + sPostFix;
        static string sPension2009 = "Pension_2009" + sPostFix;
        static string sDataFile_US, sSimpleImport_US, sDataFile_DE, sSimpleImport_DE;
        static string sDataFileName_US, sSimpleImportName_US, sDataFileName_DE, sSimpleImportName_DE;
        

        #region Result 


        
        Thread thrd_CA_Canada = new Thread(() => new Cursory_Test().t_CompareRpt_CA_Canada());
        Thread thrd_US_Franklin = new Thread(() => new Cursory_Test().t_CompareRpt_US_Franklin());
        Thread thrd_US_Dallas = new Thread(() => new Cursory_Test().t_CompareRpt_US_Dallas());
        Thread thrd_DE_Data_B = new Thread(() => new Cursory_Test().t_CompareRpt_DE_Data_B());
        Thread thrd_DE_Val_B = new Thread(() => new Cursory_Test().t_CompareRpt_DE_Val_B());
        Thread thrd_DE_Data_E = new Thread(() => new Cursory_Test().t_CompareRpt_DE_Data_E());
        Thread thrd_DE_Val_E = new Thread(() => new Cursory_Test().t_CompareRpt_DE_Val_E());



        static string sOuput_Main = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\Prod_Cursory_Output\Logs";
        static string sOuput_US_Franklin = sOuput_Main + "\\US_Franklin\\";
        static string sOuput_US_Dallas = sOuput_Main + "\\US_Dallas\\";
        static string sOuput_CA_Canada = sOuput_Main + "\\CA_Canada\\";
        static string sOuput_DE_Bedford = sOuput_Main + "\\DE_Bedford\\";
        static string sOuput_DE_Exeter = sOuput_Main + "\\DE_Exeter\\";
        static string sLogFile = sOuput_Main + "\\RetirementStudio_BuildCurosryTest_Output.xlsx";

        static int iLog_US_F = 3;
        static int iLog_US_D = 4;
        static int iLog_DE_B = 5;
        static int iLog_DE_E = 6;
        static int iLog_CA_C = 7;

        MyLog mLog_US_F = new MyLog(iLog_US_F, sLogFile, "Summary");
        MyLog mLog_US_D = new MyLog(iLog_US_D, sLogFile, "Summary");
        MyLog mLog_DE_B = new MyLog(iLog_DE_B, sLogFile, "Summary");
        MyLog mLog_DE_E = new MyLog(iLog_DE_E, sLogFile, "Summary");
        MyLog mLog_CA_C = new MyLog(iLog_CA_C, sLogFile, "Summary");


        static int iRollforwardData = 2;
        static int iUploadDataFile = iRollforwardData + 1;
        static int iImportSelectFile = iUploadDataFile + 1;
        static int iValidateAndLoad = iImportSelectFile + 1;
        static int iMatchingSTW = iValidateAndLoad + 1;
        static int iDerivationGrps = iMatchingSTW + 1;
        static int iSnapshots = iDerivationGrps + 1;
        static int iSimpleImport = iSnapshots + 1;
        static int iUndoSnapshot = iSimpleImport + 1;
        static int iRedoSnapshot = iUndoSnapshot + 1;
        static int iRollforwardValuation = iRedoSnapshot + 1;
        static int iImportDataApplyMap = iRollforwardValuation + 1;

        static int iEditAndSaveProvison = iImportDataApplyMap + 1;
        static int iRunValuation = iEditAndSaveProvison + 1;
        static int iRunTestCase = iRunValuation + 1;
        static int iViewTestCaseInXls = iRunTestCase + 1;
        static int iEditAndSaveAR_DE = iViewTestCaseInXls + 1;
        static int iEnterpriseRun = iEditAndSaveAR_DE + 1;
        static int iRunAR_DE = iEnterpriseRun + 1;
        static int iDownload_ValSum = iRunAR_DE + 1;
        static int iDownload_ParamPrint = iDownload_ValSum + 1;
        static int iDownload_IOE = iDownload_ParamPrint + 1;
        static int iDownload_AR_DE = iDownload_IOE + 1;
        static int iCompare_Snapshot = iDownload_AR_DE + 1;
        static int iCompare_MappingExport = iCompare_Snapshot + 1;
        static int iCompare_TC = iCompare_MappingExport + 1;
        static int iCompare_ValSum = iCompare_TC + 1;
        static int iCompare_IOE = iCompare_ValSum + 1;

        static int iTest_Start = iCompare_IOE + 1;
        static int iTest_End = iTest_Start + 1;

        #endregion



        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();
        public MyDictionary dic = new MyDictionary();
        public ActuarialReport pActuarialReport = new ActuarialReport();
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

        public DefinedBenefitLimitIncrease pDefinedBenefitLimitIncrease = new DefinedBenefitLimitIncrease();
        public AssumedRetirementAge pAssumedRetirementAge = new AssumedRetirementAge();
        public ContractualRetirementAge pContractualRetirementAge = new ContractualRetirementAge();
        public JubileeBenefit pJubileeBenefit = new JubileeBenefit();
        public PlanDefinition_DE pPlanDefinition_DE = new PlanDefinition_DE();
        public TableManager pTableManager = new TableManager();
        public UnitFormula pUnitFormula = new UnitFormula();
        public SocialSecurityContributionRates pSocialSecurityContributionRates = new SocialSecurityContributionRates();
        public ServiceSelection pServiceSelection = new ServiceSelection();
        public ProjectAndProrate pProjectAndProrate = new ProjectAndProrate();
        public CostOfLivingAdjustments pCostOfLivingAdjustments = new CostOfLivingAdjustments();
        public FormOfPayment_DE pFormOfPayment_DE = new FormOfPayment_DE();
        public IndividualOuputFieldDefinition pIndividualOuputFieldDefinition = new IndividualOuputFieldDefinition();
        public Methods_DE pMethods_DE = new Methods_DE();
        public ReportBreaks pReportBreaks = new ReportBreaks();
        public BreakFieldTextSubstitution pBreakFieldTextSubstitution = new BreakFieldTextSubstitution();

        #endregion


        [TestMethod]
        [Timeout(90 * 60 * 1000)]
        public void test_Cursory_Test()
        {



            #region Initialize - Create Test Ouput File/Dir 


            _gLib._CreateDirectory(sOuput_Main, false);

            if (!_gLib._FileExists(sLogFile, false))
                _gLib._CopyFile(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\Prod_Cursory_Output\Inputs\RetirementStudio_BuildCurosryTest_Output_Template.xlsx", sLogFile);

            if (!_gLib._DirExists(sOuput_CA_Canada, false))
                _gLib._CreateDirectory(sOuput_CA_Canada, false);

            if (!_gLib._DirExists(sOuput_US_Franklin, false))
                _gLib._CreateDirectory(sOuput_US_Franklin, false);

            if (!_gLib._DirExists(sOuput_US_Dallas, false))
                _gLib._CreateDirectory(sOuput_US_Dallas, false);

            if (!_gLib._DirExists(sOuput_DE_Bedford, false))
                _gLib._CreateDirectory(sOuput_DE_Bedford, false);

            if (!_gLib._DirExists(sOuput_DE_Exeter, false))
                _gLib._CreateDirectory(sOuput_DE_Exeter, false);



            #endregion



            if (bPreprod)
                _gLib._MsgBoxYesNo("Run in Preprod", "<Yes> to contiue, <No> to quite testing!");
            else
                _gLib._MsgBoxYesNo("Run in Non-Preprod", "<Yes> to contiue, <No> to quite testing!");



            #region Initialize - variables 

            if (bPreprod)
            {
                sDataFile_US = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\Prod_Cursory_Output\Inputs\US_Data2012_Masked.xls";
                sSimpleImport_US = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\Prod_Cursory_Output\Inputs\US_Data2012_SimpleImport_Masked.xls";
                sDataFile_DE = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\Prod_Cursory_Output\Inputs\DE_SmallData2009_Masked.xls";
                sSimpleImport_DE = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\Prod_Cursory_Output\Inputs\DE_SmallData2009_SimpleImport_Masked.xls";

                sDataFileName_US = "US_Data2012_Masked.xls".Replace(".xls", sPostFix + ".xls");
                sSimpleImportName_US = "US_Data2012_SimpleImport_Masked.xls".Replace(".xls", sPostFix + ".xls");
                sDataFileName_DE = "DE_SmallData2009_Masked.xls".Replace(".xls", sPostFix + ".xls");
                sSimpleImportName_DE = "DE_SmallData2009_SimpleImport_Masked.xls".Replace(".xls", sPostFix + ".xls");
            }
            else
            {
                sDataFile_US = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\Prod_Cursory_Output\Inputs\US_Data2012.xls";
                sSimpleImport_US = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\Prod_Cursory_Output\Inputs\US_Data2012_SimpleImport.xls";
                sDataFile_DE = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\Prod_Cursory_Output\Inputs\DE_SmallData2009.xls";
                sSimpleImport_DE = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\Prod_Cursory_Output\Inputs\DE_SmallData2009_SimpleImport.xls";

                sDataFileName_US = "US_Data2012.xls".Replace(".xls", sPostFix + ".xls");
                sSimpleImportName_US = "US_Data2012_SimpleImport.xls".Replace(".xls", sPostFix + ".xls");
                sDataFileName_DE = "DE_SmallData2009.xls".Replace(".xls", sPostFix + ".xls");
                sSimpleImportName_DE = "DE_SmallData2009_SimpleImport.xls".Replace(".xls", sPostFix + ".xls");
            }


            #endregion


            ///////////////////////////// CA Cursory Test ///////////////////////////////////////////
            
            if (Config.sClientName != null)
            {
                #region CA_Canada
                _gLib._KillProcessByName("AcroRd32");
                pMain._SetLanguageAndRegional();
                

                mLog_CA_C.LogInfo(iTest_Start, iLog_CA_C, DateTime.Now.ToString());



                pMain._SelectTab("Home");


                /////////////////////////// #Step_81_CA_Canada_Rollforward Data

                dic.Clear();
                dic.Add("Level_1", Config.sClientName);
                dic.Add("Level_2", Config.sPlanName_US);
                dic.Add("Level_3", "ParticipantData");
                pMain._HomeTreeViewSelect_Favorites(0, dic);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("AddServiceInstance", "Click");
                dic.Add("ServiceToOpen", "");
                pMain._PopVerify_Home_RightPane(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("Name", sData2012);
                dic.Add("EffectiveDate", "01/01/2012");
                dic.Add("Parent", "Data_2011");
                ////dic.Add("RSC", "True");
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
                dic.Add("ServiceToOpen", sData2012);
                dic.Add("CheckPopup", "False");
                pMain._PopVerify_Home_RightPane(dic);

                mLog_CA_C.LogPass(iRollforwardData);


                /////////////////////////// #Step_82_CA_Canada_Upload Data File

                dic.Clear();
                dic.Add("Level_1", sData2012);
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
                dic.Add("FileName", sDataFile_US);
                dic.Add("Open", "Click");
                dic.Add("Cancel", "");
                pMain._PopVerify_FileOpen(dic);

                _gLib._SetSyncUDWin("wUD_RepositoryFileName", pData.wRetirementStudio.wUD_RepositoryFileName.txt, sDataFileName_US, 0);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("LocalFile", "");
                dic.Add("GRSUnloadFile", "");
                dic.Add("SharepointFile", "");
                dic.Add("Browse", "");
                dic.Add("Upload", "Click");
                pData._PopVerify_UploadData(dic);

                if (_gLib._Exists("Upload", pData.wUL_Upload, 2, false))
                    _gLib._SetSyncUDWin("OK", pData.wUL_Upload.wOK.btn, "click", 0);

                pMain._SelectTab(sData2012);


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
                dic.Add("FileName", sSimpleImport_US);
                dic.Add("Open", "Click");
                dic.Add("Cancel", "");
                pMain._PopVerify_FileOpen(dic);


                _gLib._SetSyncUDWin("wUD_RepositoryFileName", pData.wRetirementStudio.wUD_RepositoryFileName.txt, sSimpleImportName_US, 0);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("LocalFile", "");
                dic.Add("GRSUnloadFile", "");
                dic.Add("SharepointFile", "");
                dic.Add("Browse", "");
                dic.Add("Upload", "Click");
                pData._PopVerify_UploadData(dic);


                if (_gLib._Exists("Upload", pData.wUL_Upload, 2, false))
                    _gLib._SetSyncUDWin("OK", pData.wUL_Upload.wOK.btn, "click", 0);

                pMain._SelectTab(sData2012);


                mLog_CA_C.LogPass(iUploadDataFile);

                /////////////////////////// #Step_83_CA_Canada_Import - Select File

                dic.Clear();
                dic.Add("Level_1", sData2012);
                dic.Add("Level_2", "Imports");
                dic.Add("Level_3", "ImportData");
                pData._TreeViewSelect(dic);

                pData._SelectTab("Select File");

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "Excel file");
                dic.Add("Browse", "Click");
                dic.Add("Preview", "");
                pData._PopVerify_IP_SelectFile(dic);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", sDataFileName_US);
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("Preview", "Click");
                pData._PopVerify_IP_SelectFile(dic);

                pData._SelectTab("Select File");

                mLog_CA_C.LogPass(iImportSelectFile);


                pData._SelectTab("Mapping");

                /////////////////////////// #Step_84_CA_Canada_Validate & Load

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

                mLog_CA_C.LogPass(iValidateAndLoad);


                /////////////////////////// #Step_85_CA_Canada_Matching & Save to Warehouse

                pData._SelectTab("Matching");

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("MatchManually", "");
                dic.Add("FindMatches", "Click");
                pData._PopVerify_IP_Matching(dic);

                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "10");
                dic.Add("Unique_UniqueMatch_Num", "125");
                dic.Add("Unique_MultipleMatches_Num", "0");
                dic.Add("Duplicate_NoMatch_Num", "0");
                dic.Add("Duplicate_UniqueMatch_Num", "0");
                dic.Add("Duplicate_MultipleMatches_Num", "0");
                dic.Add("Warehouse_NoMatch_Num", "10");
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
                dic.Add("PopVerify", "Verify");
                dic.Add("Message", "Are you sure that you want to accept all records with a status of Gone");
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
                dic.Add("Message", "All 'UnmatchedInWarehouse' records have been accepted");
                dic.Add("OK", "");
                pData._PopVerify_IP_Matching_RunResults_Popup(dic);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("OK", "Click");
                pData._PopVerify_IP_Matching_RunResults_Popup(dic);



                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Matched_Num", "125");
                dic.Add("New_Num", "10");
                dic.Add("Ignored_Num", "0");
                dic.Add("Gone_Num", "10");
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



                mLog_CA_C.LogPass(iMatchingSTW);

                /////////////////////////// #Step_86_CA_Canada_Derivation Groups

                dic.Clear();
                dic.Add("Level_1", sData2012);
                dic.Add("Level_2", "Derivation Groups");
                dic.Add("Level_3", "DeriveUSC");
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


                mLog_CA_C.LogPass(iDerivationGrps);


                /////////////////////////// #Step_87_CA_Canada_Snapshots

                dic.Clear();
                dic.Add("Level_1", sData2012);
                dic.Add("Level_2", "Snapshots");
                dic.Add("Level_3", "Valuation Data");
                pData._TreeViewSelect(dic);


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

                pMain._SelectTab(sData2012);

                pData._ts_SP_CreateExtract(sOuput_CA_Canada + "SnapshotExtract.xlsx");

                mLog_CA_C.LogPass(iSnapshots);


                pMain._Home_ToolbarClick_Top(true);


                /////////////////////////// #Step_88_CA_Canada_Simple Import

                dic.Clear();
                dic.Add("Level_1", sData2012);
                dic.Add("Level_2", "Simple Imports");
                dic.Add("MenuItem", "Add new file");
                pData._TreeViewRightSelect(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "SimpleImport");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("Preview", "");
                pData._PopVerify_IP_SelectFile(dic);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "Click");
                dic.Add("Preview", "");
                pData._PopVerify_IP_SelectFile(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", sSimpleImportName_US);
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                pMain._SelectTab(sData2012);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("Preview", "Click");
                dic.Add("Process", "Click");
                pData._PopVerify_SimpleImport(dic);

                pMain._SelectTab(sData2012);

                mLog_CA_C.LogPass(iSimpleImport);


                /////////////////////////// #Step_89_CA_Canada_Undo Snapshot

                dic.Clear();
                dic.Add("Level_1", sData2012);
                dic.Add("Level_2", "Undo");
                pData._TreeViewSelect(dic);



                pData._ts_Undo("Snapshot Publish", 0, "Test undo snapshot");

                pMain._Home_ToolbarClick_Top(true);

                pMain._SelectTab(sData2012);

                mLog_CA_C.LogPass(iUndoSnapshot);

                /////////////////////////// #Step_90_CA_Canada_Redo Snapshot

                dic.Clear();
                dic.Add("Level_1", sData2012);
                dic.Add("Level_2", "Snapshots");
                dic.Add("Level_3", "Valuation Data");
                pData._TreeViewSelect(dic);

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

                pMain._SelectTab(sData2012);

                mLog_CA_C.LogPass(iRedoSnapshot);

                pMain._SelectTab(sData2012);
                pMain._Home_ToolbarClick_Top(true);
                pMain._Home_ToolbarClick_Top(false);



                /////////////////////////////////////////////////////   Valuations    ///////////////////////////////////////////////////////


                pMain._SelectTab("Home");

                /////////////////////////// #Step_91_CA_Canada_Rollforward Valuation

                dic.Clear();
                dic.Add("Level_1", Config.sClientName);
                dic.Add("Level_2", Config.sPlanName_US);
                dic.Add("Level_3", "FundingValuations");
                pMain._HomeTreeViewSelect_Favorites(0, dic);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("AddServiceInstance", "Click");
                dic.Add("ServiceToOpen", "");
                pMain._PopVerify_Home_RightPane(dic);



                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ConversionService", "");
                dic.Add("Name", sValuation2012);
                dic.Add("Parent", "Conversion_2011");
                dic.Add("ParentFinalValuationSet", "");
                dic.Add("PlanYearBeginningIn", "2012");
                dic.Add("FirstYearPlanUnderPPA", "2008");
                //////dic.Add("RSC", "True");
                dic.Add("LocalMarket", "");
                dic.Add("Shared", "");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                dic.Add("Check_FundingCalculatorNotRunComplete", "False");
                pMain._PopVerify_Home_ServicePropeties(dic);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("AddServiceInstance", "");
                dic.Add("ServiceToOpen", sValuation2012);
                pMain._PopVerify_Home_RightPane(dic);


                pMain._SelectTab(sValuation2012);

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
                dic.Add("Assumptions_AddNew", "True");
                dic.Add("Assumptions_Name", "");
                dic.Add("Assumptions_Edit", "");
                dic.Add("MethodsLiabilities_AddNew", "True");
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

                pMain._SelectTab(sValuation2012);

                mLog_CA_C.LogPass(iRollforwardValuation);


                /////////////////////////// #Step_92_CA_Canada_Import and Apply Mappings

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
                dic.Add("SnapshotName", "Valuation Data");
                dic.Add("SnapshotName_Parent", sData2012);
                dic.Add("OK", "Click");
                dic.Add("RetainThePreviousUnload", "");
                dic.Add("SpecifyANewSnapshotRetainingPrevious", "True");
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
                dic.Add("CompareData", "False");
                dic.Add("ImportDataandApplyMapping", "");
                dic.Add("ViewMappedData", "");
                dic.Add("ExportMappingstoExcel", "");
                dic.Add("CheckVOImportPopup", "");
                pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

                pMain._SelectTab("Participant DataSet");

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


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("DataEffectiveDate", "");
                dic.Add("Snapshot", "");
                dic.Add("GRSUnload", "");
                dic.Add("GotoDataSystem", "");
                dic.Add("AddField", "");
                dic.Add("GRSInformation", "");
                dic.Add("CompareData", "");
                dic.Add("ImportDataandApplyMapping", "");
                dic.Add("ViewMappedData", "Click");
                dic.Add("ExportMappingsToExcel", "");
                dic.Add("CheckVOImportPopup", "");
                pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

                _gLib._SetSyncUDWin("ViewDataParameters_View", pParticipantDataSet.wViewDataParameters.btnView.btn, "Click", 0);
                _gLib._SetSyncUDWin("ViewData_ReturntoParameters", pParticipantDataSet.wViewData.btnReturntoParameters.btn, "Click", 0);
                _gLib._SetSyncUDWin("ViewDataParameters_Cancel", pParticipantDataSet.wViewDataParameters.btnCancel.btn, "Click", 0);

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
                dic.Add("ImportDataandApplyMapping", "");
                dic.Add("ViewMappedData", "");
                dic.Add("ExportMappingstoExcel", "Click");
                dic.Add("CheckVOImportPopup", "");
                pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


                pOutputManager._SaveAs(sOuput_CA_Canada + "ExportMappingToExcel.xlsx");
                _gLib._FileExists(sOuput_CA_Canada + "ExportMappingToExcel.xlsx", Config.iTimeout, true);


                mLog_CA_C.LogPass(iImportDataApplyMap);


                /////////////////////////// #Step_93_CA_Canada_Edit & Save a Provision

                pMain._SelectTab(sValuation2012);

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "2");
                dic.Add("iSelectColNum", "1");
                dic.Add("MenuItem_1", "Provisions");
                dic.Add("MenuItem_2", "Edit Parameters");
                pMain._FlowTreeRightSelect(dic);


                pMain._SelectTab("Provisions");

                dic.Clear();
                dic.Add("Level_1", "Participant Info");
                dic.Add("Level_2", "Service");
                dic.Add("Level_3", "BenefitService");
                dic.Add("Level_4", "Default");
                pAssumptions._TreeViewSelect(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ProvidedInDataField", "Benefit1DB");
                pService._PopVerify_ServiceAtValuationDate(dic);

                pMain._Home_ToolbarClick_Top(true);

                pMain._SelectTab("Provisions");

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ProvidedInDataField", "BenService");
                pService._PopVerify_ServiceAtValuationDate(dic);

                pMain._Home_ToolbarClick_Top(true);

                pMain._SelectTab("Provisions");

                mLog_CA_C.LogPass(iEditAndSaveProvison);

                /////////////////////////// #Step_94_CA_Canada_Run Valuation

                pMain._SelectTab(sValuation2012);


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
                dic.Add("GL_PPANAR_Min", "True");
                dic.Add("GL_PPANAR_Max", "True");
                dic.Add("GL_EAN", "");
                dic.Add("EstimateNextYearLiabilityForAFTAP", "");
                dic.Add("PayoutProjection", "True");
                dic.Add("IncludeIOE", "True");
                dic.Add("GenerateParameterPrint", "True");
                dic.Add("GenerateTestCaseOutput", "True");
                dic.Add("IncludeGainLossResult", "");
                dic.Add("Service", "VestingService");
                dic.Add("Pay", "PayProjection1");
                dic.Add("CurrentYear", "");
                dic.Add("PriorYear", "True");
                dic.Add("CashBanlance", "AccruedBenefit1");
                dic.Add("Pension", "BenefitInPayment");
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
                dic.Add("PayoutProjectionCustomGroup", "HourlyFlag");
                dic.Add("RunValuation", "Click");
                pMain._PopVerify_RunOptions(dic);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("OK", "Click");
                pMain._PopVerify_EnterpriseRunSubmitted(dic);


                mLog_CA_C.LogPass(iRunValuation);


                pMain._SelectTab(sValuation2012);

                /////////////////////////// #Step_95_CA_Canada_Run a test case from TestCaseLibrary

                dic.Clear();
                dic.Add("iSelectRowNum", "2");
                dic.Add("iSelectColNum", "1");
                dic.Add("iPosX", "");
                dic.Add("iPosY", "");
                dic.Add("MenuItem_1", "Test Case");
                dic.Add("MenuItem_2", "");
                pMain._FlowTreeRightSelect(dic);

                ////////////////////////if (_gLib._Exists("Save", pMain.wPrompttoSave, 1, false))
                ////////////////////////    _gLib._SetSyncUDWin("Save - Yes", pMain.wPrompttoSave.wYes.btn, "Click", 0);

                pMain._SelectTab("Test Case Library");

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("RunSelectedTestLife", "Click");
                pTestCaseLibrary._PopVerify_TestCaseLibrary(dic);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("AllLiabilityTypes", "True");
                dic.Add("PPA_NAR_Min", "");
                dic.Add("PPA_NAR_Max", "");
                dic.Add("PPA_NAR_PVVB", "");
                dic.Add("PBGC_NAR_PVVB", "");
                dic.Add("FAS35_PVAB", "");
                dic.Add("FAS35_PVVB", "");
                dic.Add("Funding", "");
                dic.Add("PayoutProjection", "");
                dic.Add("RunSelected", "Click");
                pTestCaseLibrary._PopVerify_TestCaseRunOption(dic);

                _gLib._Enabled("Recalculate", pTestCaseLibrary.wTestCaseViewer.wRecalculate, Config.iTimeout * 3, true);
                _gLib._Exists("Recalculate", pTestCaseLibrary.wTestCaseViewer.wViewTestCaseInExcel.txt.link, Config.iTimeout * 3, true);

                mLog_CA_C.LogPass(iRunTestCase);

                /////////////////////////// #Step_96_CA_Canada_View Test Case in Excel

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ViewTestCaseInExcel", "Click");
                dic.Add("Close", "");
                pTestCaseLibrary._PopVerify_TestCaseViewer(dic);

                _gLib._Exists("Excel", pOutputManager.wExcel, Config.iTimeout * 3, true);

                pOutputManager._Excel_SaveFile(sOuput_CA_Canada + "TestCaseOutput.xlsx");
                _gLib._FileExists(sOuput_CA_Canada + "TestCaseOutput.xlsx", true);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ViewTestCaseInExcel", "");
                dic.Add("Close", "Click");
                pTestCaseLibrary._PopVerify_TestCaseViewer(dic);


                pMain._SelectTab("Test Case Library");

                mLog_CA_C.LogPass(iViewTestCaseInXls);


                pMain._SelectTab(sValuation2012);
                pMain._Home_ToolbarClick_Top(true);



                /////////////////////////// #Step_93_CA_Canada_Enterprise Run Complete Successful

                pMain._SelectTab(sValuation2012);

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "2");
                dic.Add("iSelectColNum", "1");
                dic.Add("MenuItem_1", "View Run Status");
                pMain._FlowTreeRightSelect(dic);


                pMain._EnterpriseRun("Group Job Successfully Complete", true);

                mLog_CA_C.LogPass(iEnterpriseRun);




                pMain._SelectTab(sValuation2012);

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "2");
                dic.Add("iSelectColNum", "1");
                dic.Add("MenuItem_1", "View Output");
                pMain._FlowTreeRightSelect(dic);


                /////////////////////////// #Step_94_CA_Canada_Download Valuation Summary
                pOutputManager._ExportReport_Common(sOuput_CA_Canada, "Valuation Summary", "RollForward", false, true);
                mLog_CA_C.LogPass(iDownload_ValSum);

                /////////////////////////// #Step_95_CA_Canada_Download Parameter Print
                pOutputManager._ExportReport_Others(sOuput_CA_Canada, "Parameter Print", "RollForward", true, true);
                mLog_CA_C.LogPass(iDownload_ParamPrint);

                /////////////////////////// #Step_96_CA_Canada_Download IOE
                pOutputManager._ExportReport_Others(sOuput_CA_Canada, "IOE", "RollForward", false, true);
                mLog_CA_C.LogPass(iDownload_IOE);


                pMain._SelectTab(sValuation2012);
                pMain._Home_ToolbarClick_Top(true);
                pMain._Home_ToolbarClick_Top(false);

                mLog_CA_C.LogInfo(iTest_End, iLog_CA_C, DateTime.Now.ToString());


                //////////////////////////thrd_CA_Canada.Start();
                

                #endregion

                t_CompareRpt_CA_Canada();
            }

            ///////////////////////////// US Cursory Test ///////////////////////////////////////////
            
            if (Config.sClientName_F != null)
            { 
                #region US_Franklin

                _gLib._KillProcessByName("AcroRd32");
                pMain._SetLanguageAndRegional();

                mLog_US_F.LogInfo(iTest_Start, iLog_US_F, DateTime.Now.ToString());



                pMain._SelectTab("Home");


                ///////////////////////////// #Step_1_US_Franklin_Rollforward Data

                dic.Clear();
                dic.Add("Level_1", Config.sClientName_F);
                dic.Add("Level_2", Config.sPlanName_US);
                dic.Add("Level_3", "ParticipantData");
                pMain._HomeTreeViewSelect_Favorites(0, dic);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("AddServiceInstance", "Click");
                dic.Add("ServiceToOpen", "");
                pMain._PopVerify_Home_RightPane(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("Name", sData2012);
                dic.Add("EffectiveDate", "01/01/2012");
                dic.Add("Parent", "Data_2011");
                //////////dic.Add("RSC", "True");
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
                dic.Add("ServiceToOpen", sData2012);
                dic.Add("CheckPopup", "False");
                pMain._PopVerify_Home_RightPane(dic);

                mLog_US_F.LogPass(iRollforwardData);


                ///////////////////////////// #Step_2_US_Franklin_Upload Data File

                dic.Clear();
                dic.Add("Level_1", sData2012);
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
                dic.Add("FileName", sDataFile_US);
                dic.Add("Open", "Click");
                dic.Add("Cancel", "");
                pMain._PopVerify_FileOpen(dic);

                _gLib._SetSyncUDWin("wUD_RepositoryFileName", pData.wRetirementStudio.wUD_RepositoryFileName.txt, sDataFileName_US, 0);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("LocalFile", "");
                dic.Add("GRSUnloadFile", "");
                dic.Add("SharepointFile", "");
                dic.Add("Browse", "");
                dic.Add("Upload", "Click");
                pData._PopVerify_UploadData(dic);

                if (_gLib._Exists("Upload", pData.wUL_Upload, 2, false))
                    _gLib._SetSyncUDWin("OK", pData.wUL_Upload.wOK.btn, "click", 0);

                pMain._SelectTab(sData2012);


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
                dic.Add("FileName", sSimpleImport_US);
                dic.Add("Open", "Click");
                dic.Add("Cancel", "");
                pMain._PopVerify_FileOpen(dic);

                _gLib._SetSyncUDWin("wUD_RepositoryFileName", pData.wRetirementStudio.wUD_RepositoryFileName.txt, sSimpleImportName_US, 0);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("LocalFile", "");
                dic.Add("GRSUnloadFile", "");
                dic.Add("SharepointFile", "");
                dic.Add("Browse", "");
                dic.Add("Upload", "Click");
                pData._PopVerify_UploadData(dic);


                if (_gLib._Exists("Upload", pData.wUL_Upload, 2, false))
                    _gLib._SetSyncUDWin("OK", pData.wUL_Upload.wOK.btn, "click", 0);

                pMain._SelectTab(sData2012);


                mLog_US_F.LogPass(iUploadDataFile);

                ///////////////////////////// #Step_3_US_Franklin_Import - Select File

                dic.Clear();
                dic.Add("Level_1", sData2012);
                dic.Add("Level_2", "Imports");
                dic.Add("Level_3", "ImportData");
                pData._TreeViewSelect(dic);

                pData._SelectTab("Select File");

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "Excel file");
                dic.Add("Browse", "Click");
                dic.Add("Preview", "");
                pData._PopVerify_IP_SelectFile(dic);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", sDataFileName_US);
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("Preview", "Click");
                pData._PopVerify_IP_SelectFile(dic);

                pData._SelectTab("Select File");

                mLog_US_F.LogPass(iImportSelectFile);


                pData._SelectTab("Mapping");

                ///////////////////////////// #Step_4_US_Franklin_Validate & Load

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

                mLog_US_F.LogPass(iValidateAndLoad);


                ///////////////////////////// #Step_5_US_Franklin_Matching & Save to Warehouse

                pData._SelectTab("Matching");

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("MatchManually", "");
                dic.Add("FindMatches", "Click");
                pData._PopVerify_IP_Matching(dic);

                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Unique_NoMatch_Num", "10");
                dic.Add("Unique_UniqueMatch_Num", "125");
                dic.Add("Unique_MultipleMatches_Num", "0");
                dic.Add("Duplicate_NoMatch_Num", "0");
                dic.Add("Duplicate_UniqueMatch_Num", "0");
                dic.Add("Duplicate_MultipleMatches_Num", "0");
                dic.Add("Warehouse_NoMatch_Num", "10");
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
                dic.Add("PopVerify", "Verify");
                dic.Add("Message", "Are you sure that you want to accept all records with a status of Gone");
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
                dic.Add("Message", "All 'UnmatchedInWarehouse' records have been accepted");
                dic.Add("OK", "");
                pData._PopVerify_IP_Matching_RunResults_Popup(dic);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("OK", "Click");
                pData._PopVerify_IP_Matching_RunResults_Popup(dic);



                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("Matched_Num", "125");
                dic.Add("New_Num", "10");
                dic.Add("Ignored_Num", "0");
                dic.Add("Gone_Num", "10");
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



                mLog_US_F.LogPass(iMatchingSTW);

                ///////////////////////////// #Step_6_US_Franklin_Derivation Groups

                dic.Clear();
                dic.Add("Level_1", sData2012);
                dic.Add("Level_2", "Derivation Groups");
                dic.Add("Level_3", "DeriveUSC");
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


                mLog_US_F.LogPass(iDerivationGrps);


                ///////////////////////////// #Step_7_US_Franklin_Snapshots

                dic.Clear();
                dic.Add("Level_1", sData2012);
                dic.Add("Level_2", "Snapshots");
                dic.Add("Level_3", "Valuation Data");
                pData._TreeViewSelect(dic);


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

                pMain._SelectTab(sData2012);

                pData._ts_SP_CreateExtract(sOuput_US_Franklin + "SnapshotExtract.xlsx");

                mLog_US_F.LogPass(iSnapshots);


                pMain._Home_ToolbarClick_Top(true);


                ///////////////////////////// #Step_8_US_Franklin_Simple Import

                dic.Clear();
                dic.Add("Level_1", sData2012);
                dic.Add("Level_2", "Simple Imports");
                dic.Add("MenuItem", "Add new file");
                pData._TreeViewRightSelect(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "SimpleImport");
                dic.Add("FileType", "");
                dic.Add("Browse", "");
                dic.Add("Preview", "");
                pData._PopVerify_IP_SelectFile(dic);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileDefinitionName", "");
                dic.Add("FileType", "");
                dic.Add("Browse", "Click");
                dic.Add("Preview", "");
                pData._PopVerify_IP_SelectFile(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("FileName", sSimpleImportName_US);
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                pData._PopVerify_IP_SelectFile_FileSelection(dic);

                pMain._SelectTab(sData2012);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("Preview", "Click");
                dic.Add("Process", "Click");
                pData._PopVerify_SimpleImport(dic);

                pMain._SelectTab(sData2012);

                mLog_US_F.LogPass(iSimpleImport);


                ///////////////////////////// #Step_9_US_Franklin_Undo Snapshot

                dic.Clear();
                dic.Add("Level_1", sData2012);
                dic.Add("Level_2", "Undo");
                pData._TreeViewSelect(dic);



                pData._ts_Undo("Snapshot Publish", 0, "Test undo snapshot");

                pMain._Home_ToolbarClick_Top(true);

                pMain._SelectTab(sData2012);

                mLog_US_F.LogPass(iUndoSnapshot);

                ///////////////////////////// #Step_10_US_Franklin_Redo Snapshot

                dic.Clear();
                dic.Add("Level_1", sData2012);
                dic.Add("Level_2", "Snapshots");
                dic.Add("Level_3", "Valuation Data");
                pData._TreeViewSelect(dic);

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

                pMain._SelectTab(sData2012);

                mLog_US_F.LogPass(iRedoSnapshot);

                pMain._SelectTab(sData2012);
                pMain._Home_ToolbarClick_Top(true);
                pMain._Home_ToolbarClick_Top(false);



                ///////////////////////////////////////////////////////   Valuations    ///////////////////////////////////////////////////////


                pMain._SelectTab("Home");

                ///////////////////////////// #Step_11_US_Franklin_Rollforward Valuation

                dic.Clear();
                dic.Add("Level_1", Config.sClientName_F);
                dic.Add("Level_2", Config.sPlanName_US);
                dic.Add("Level_3", "FundingValuations");
                pMain._HomeTreeViewSelect_Favorites(0, dic);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("AddServiceInstance", "Click");
                dic.Add("ServiceToOpen", "");
                pMain._PopVerify_Home_RightPane(dic);



                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ConversionService", "");
                dic.Add("Name", sValuation2012);
                dic.Add("Parent", "Conversion_2011");
                dic.Add("ParentFinalValuationSet", "");
                dic.Add("PlanYearBeginningIn", "2012");
                dic.Add("FirstYearPlanUnderPPA", "2008");
                ////////dic.Add("RSC", "True");
                dic.Add("LocalMarket", "");
                dic.Add("Shared", "");
                dic.Add("OK", "Click");
                dic.Add("Cancel", "");
                dic.Add("Check_FundingCalculatorNotRunComplete", "False");
                pMain._PopVerify_Home_ServicePropeties(dic);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("AddServiceInstance", "");
                dic.Add("ServiceToOpen", sValuation2012);
                pMain._PopVerify_Home_RightPane(dic);


                pMain._SelectTab(sValuation2012);

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
                dic.Add("Assumptions_AddNew", "True");
                dic.Add("Assumptions_Name", "");
                dic.Add("Assumptions_Edit", "");
                dic.Add("MethodsLiabilities_AddNew", "True");
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

                pMain._SelectTab(sValuation2012);

                mLog_US_F.LogPass(iRollforwardValuation);


                ///////////////////////////// #Step_12_US_Franklin_Import and Apply Mappings

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
                dic.Add("SnapshotName", "Valuation Data");
                dic.Add("SnapshotName_Parent", sData2012);
                dic.Add("OK", "Click");
                dic.Add("RetainThePreviousUnload", "");
                dic.Add("SpecifyANewSnapshotRetainingPrevious", "True");
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
                dic.Add("CompareData", "False");
                dic.Add("ImportDataandApplyMapping", "");
                dic.Add("ViewMappedData", "");
                dic.Add("ExportMappingstoExcel", "");
                dic.Add("CheckVOImportPopup", "");
                pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

                pMain._SelectTab("Participant DataSet");

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


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("DataEffectiveDate", "");
                dic.Add("Snapshot", "");
                dic.Add("GRSUnload", "");
                dic.Add("GotoDataSystem", "");
                dic.Add("AddField", "");
                dic.Add("GRSInformation", "");
                dic.Add("CompareData", "");
                dic.Add("ImportDataandApplyMapping", "");
                dic.Add("ViewMappedData", "Click");
                dic.Add("ExportMappingsToExcel", "");
                dic.Add("CheckVOImportPopup", "");
                pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

                _gLib._SetSyncUDWin("ViewDataParameters_View", pParticipantDataSet.wViewDataParameters.btnView.btn, "Click", 0);
                _gLib._SetSyncUDWin("ViewData_ReturntoParameters", pParticipantDataSet.wViewData.btnReturntoParameters.btn, "Click", 0);
                _gLib._SetSyncUDWin("ViewDataParameters_Cancel", pParticipantDataSet.wViewDataParameters.btnCancel.btn, "Click", 0);

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
                dic.Add("ImportDataandApplyMapping", "");
                dic.Add("ViewMappedData", "");
                dic.Add("ExportMappingstoExcel", "Click");
                dic.Add("CheckVOImportPopup", "");
                pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


                pOutputManager._SaveAs(sOuput_US_Franklin + "ExportMappingToExcel.xlsx");
                _gLib._FileExists(sOuput_US_Franklin + "ExportMappingToExcel.xlsx", Config.iTimeout, true);


                mLog_US_F.LogPass(iImportDataApplyMap);


                ///////////////////////////// #Step_13_US_Franklin_Edit & Save a Provision

                pMain._SelectTab(sValuation2012);

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "2");
                dic.Add("iSelectColNum", "1");
                dic.Add("MenuItem_1", "Provisions");
                dic.Add("MenuItem_2", "Edit Parameters");
                pMain._FlowTreeRightSelect(dic);


                pMain._SelectTab("Provisions");

                dic.Clear();
                dic.Add("Level_1", "Participant Info");
                dic.Add("Level_2", "Service");
                dic.Add("Level_3", "BenefitService");
                dic.Add("Level_4", "Default");
                pAssumptions._TreeViewSelect(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ProvidedInDataField", "Benefit1DB");
                pService._PopVerify_ServiceAtValuationDate(dic);

                pMain._Home_ToolbarClick_Top(true);

                pMain._SelectTab("Provisions");

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ProvidedInDataField", "BenService");
                pService._PopVerify_ServiceAtValuationDate(dic);

                pMain._Home_ToolbarClick_Top(true);

                pMain._SelectTab("Provisions");

                mLog_US_F.LogPass(iEditAndSaveProvison);

                ///////////////////////////// #Step_14_US_Franklin_Run Valuation

                pMain._SelectTab(sValuation2012);


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
                dic.Add("GL_PPANAR_Min", "True");
                dic.Add("GL_PPANAR_Max", "True");
                dic.Add("GL_EAN", "");
                dic.Add("EstimateNextYearLiabilityForAFTAP", "");
                dic.Add("PayoutProjection", "True");
                dic.Add("IncludeIOE", "True");
                dic.Add("GenerateParameterPrint", "True");
                dic.Add("GenerateTestCaseOutput", "True");
                dic.Add("IncludeGainLossResult", "");
                dic.Add("Service", "VestingService");
                dic.Add("Pay", "PayProjection1");
                dic.Add("CurrentYear", "");
                dic.Add("PriorYear", "True");
                dic.Add("CashBanlance", "AccruedBenefit1");
                dic.Add("Pension", "BenefitInPayment");
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
                dic.Add("PayoutProjectionCustomGroup", "HourlyFlag");
                dic.Add("RunValuation", "Click");
                pMain._PopVerify_RunOptions(dic);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("OK", "Click");
                pMain._PopVerify_EnterpriseRunSubmitted(dic);


                mLog_US_F.LogPass(iRunValuation);


                pMain._SelectTab(sValuation2012);

                ///////////////////////////// #Step_15_US_Franklin_Run a test case from TestCaseLibrary

                dic.Clear();
                dic.Add("iSelectRowNum", "2");
                dic.Add("iSelectColNum", "1");
                dic.Add("iPosX", "");
                dic.Add("iPosY", "");
                dic.Add("MenuItem_1", "Test Case");
                dic.Add("MenuItem_2", "");
                pMain._FlowTreeRightSelect(dic);

                ////////////////////////if (_gLib._Exists("Save", pMain.wPrompttoSave, 1, false))
                ////////////////////////    _gLib._SetSyncUDWin("Save - Yes", pMain.wPrompttoSave.wYes.btn, "Click", 0);

                pMain._SelectTab("Test Case Library");

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("RunSelectedTestLife", "Click");
                pTestCaseLibrary._PopVerify_TestCaseLibrary(dic);


                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("AllLiabilityTypes", "True");
                dic.Add("PPA_NAR_Min", "");
                dic.Add("PPA_NAR_Max", "");
                dic.Add("PPA_NAR_PVVB", "");
                dic.Add("PBGC_NAR_PVVB", "");
                dic.Add("FAS35_PVAB", "");
                dic.Add("FAS35_PVVB", "");
                dic.Add("Funding", "");
                dic.Add("PayoutProjection", "");
                dic.Add("RunSelected", "Click");
                pTestCaseLibrary._PopVerify_TestCaseRunOption(dic);

                _gLib._Enabled("Recalculate", pTestCaseLibrary.wTestCaseViewer.wRecalculate, Config.iTimeout * 3, true);
                _gLib._Exists("Recalculate", pTestCaseLibrary.wTestCaseViewer.wViewTestCaseInExcel.txt.link, Config.iTimeout * 3, true);

                mLog_US_F.LogPass(iRunTestCase);

                ///////////////////////////// #Step_16_US_Franklin_View Test Case in Excel

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ViewTestCaseInExcel", "Click");
                dic.Add("Close", "");
                pTestCaseLibrary._PopVerify_TestCaseViewer(dic);

                _gLib._Exists("Excel", pOutputManager.wExcel, Config.iTimeout * 3, true);

                pOutputManager._Excel_SaveFile(sOuput_US_Franklin + "TestCaseOutput.xlsx");
                _gLib._FileExists(sOuput_US_Franklin + "TestCaseOutput.xlsx", true);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ViewTestCaseInExcel", "");
                dic.Add("Close", "Click");
                pTestCaseLibrary._PopVerify_TestCaseViewer(dic);


                pMain._SelectTab("Test Case Library");

                mLog_US_F.LogPass(iViewTestCaseInXls);


                pMain._SelectTab(sValuation2012);
                pMain._Home_ToolbarClick_Top(true);
                //////////////////////////////pMain._Home_ToolbarClick_Top(false);


                ///////////////////// US Franklin  - Download & Compare Reports


                //////////////////////////////////pMain._SelectTab("Home");


                //////////////////////////////////dic.Clear();
                //////////////////////////////////dic.Add("Level_1", Config.sClientName_F);
                //////////////////////////////////dic.Add("Level_2", Config.sPlanName_US);
                //////////////////////////////////dic.Add("Level_3", "FundingValuations");
                //////////////////////////////////pMain._HomeTreeViewSelect_Favorites(0, dic);


                //////////////////////////////////dic.Clear();
                //////////////////////////////////dic.Add("PopVerify", "Pop");
                //////////////////////////////////dic.Add("AddServiceInstance", "");
                //////////////////////////////////dic.Add("ServiceToOpen", sValuation2012);
                //////////////////////////////////pMain._PopVerify_Home_RightPane(dic);



                ///////////////////////////// #Step_33_US_Franklin_Enterprise Run Complete Successful

                pMain._SelectTab(sValuation2012);

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "2");
                dic.Add("iSelectColNum", "1");
                dic.Add("MenuItem_1", "View Run Status");
                pMain._FlowTreeRightSelect(dic);


                pMain._EnterpriseRun("Group Job Successfully Complete", true);

                mLog_US_F.LogPass(iEnterpriseRun);




                pMain._SelectTab(sValuation2012);

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "2");
                dic.Add("iSelectColNum", "1");
                dic.Add("MenuItem_1", "View Output");
                pMain._FlowTreeRightSelect(dic);


                ///////////////////////////// #Step_34_US_Franklin_Download Valuation Summary
                pOutputManager._ExportReport_Common(sOuput_US_Franklin, "Valuation Summary", "RollForward", false, true);
                mLog_US_F.LogPass(iDownload_ValSum);

                ///////////////////////////// #Step_35_US_Franklin_Download Parameter Print
                pOutputManager._ExportReport_Others(sOuput_US_Franklin, "Parameter Print", "RollForward", true, true);
                mLog_US_F.LogPass(iDownload_ParamPrint);

                ///////////////////////////// #Step_36_US_Franklin_Download IOE
                pOutputManager._ExportReport_Others(sOuput_US_Franklin, "IOE", "RollForward", false, true);
                mLog_US_F.LogPass(iDownload_IOE);


                pMain._SelectTab(sValuation2012);
                pMain._Home_ToolbarClick_Top(true);
                pMain._Home_ToolbarClick_Top(false);

                ///////////////////////////thrd_US_Franklin.Start();



                mLog_US_F.LogInfo(iTest_End, iLog_US_F, DateTime.Now.ToString());

                #endregion

                t_CompareRpt_US_Franklin();
            }

            if (Config.sClientName_D != null)
            { 
                #region US_Dallas

                _gLib._KillProcessByName("AcroRd32");
            pMain._SetLanguageAndRegional();

            mLog_US_D.LogInfo(iTest_Start, iLog_US_D, DateTime.Now.ToString());



            pMain._SelectTab("Home");


            ///////////////////////////// #Step_17_US_Dallas_Rollforward Data

            dic.Clear();
            dic.Add("Level_1", Config.sClientName_D);
            dic.Add("Level_2", Config.sPlanName_US);
            dic.Add("Level_3", "ParticipantData");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", sData2012);
            dic.Add("EffectiveDate", "01/01/2012");
            dic.Add("Parent", "Data_2011");
            ////////dic.Add("RSC", "True");
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
            dic.Add("ServiceToOpen", sData2012);
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            mLog_US_D.LogPass(iRollforwardData);

            ///////////////////////////// #Step_18_US_Dallas_Upload Data File

            dic.Clear();
            dic.Add("Level_1", sData2012);
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
            dic.Add("FileName", sDataFile_US);
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            _gLib._SetSyncUDWin("wUD_RepositoryFileName", pData.wRetirementStudio.wUD_RepositoryFileName.txt, sDataFileName_US, 0);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);



            if (_gLib._Exists("Upload", pData.wUL_Upload, 2, false))
                _gLib._SetSyncUDWin("OK", pData.wUL_Upload.wOK.btn, "click", 0);

            pMain._SelectTab(sData2012);


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
            dic.Add("FileName", sSimpleImport_US);
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            _gLib._SetSyncUDWin("wUD_RepositoryFileName", pData.wRetirementStudio.wUD_RepositoryFileName.txt, sSimpleImportName_US, 0);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);


            if (_gLib._Exists("Upload", pData.wUL_Upload, 2, false))
                _gLib._SetSyncUDWin("OK", pData.wUL_Upload.wOK.btn, "click", 0);

            pMain._SelectTab(sData2012);


            mLog_US_D.LogPass(iUploadDataFile);

            ///////////////////////////// #Step_19_US_Dallas_Import - Select File

            dic.Clear();
            dic.Add("Level_1", sData2012);
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "ImportData");
            pData._TreeViewSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "Excel file");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", sDataFileName_US);
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_SelectFile(dic);

            pData._SelectTab("Select File");

            mLog_US_D.LogPass(iImportSelectFile);

            pData._SelectTab("Mapping");

            ///////////////////////////// #Step_20_US_Dallas_Validate & Load

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

            mLog_US_D.LogPass(iValidateAndLoad);


            ///////////////////////////// #Step_21_US_Dallas_Matching & Save to Warehouse

            pData._SelectTab("Matching");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "10");
            dic.Add("Unique_UniqueMatch_Num", "125");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "0");
            dic.Add("Duplicate_UniqueMatch_Num", "0");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
            dic.Add("Warehouse_NoMatch_Num", "10");
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
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Are you sure that you want to accept all records with a status of Gone");
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
            dic.Add("Message", "All 'UnmatchedInWarehouse' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);



            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Matched_Num", "125");
            dic.Add("New_Num", "10");
            dic.Add("Ignored_Num", "0");
            dic.Add("Gone_Num", "10");
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



            mLog_US_D.LogPass(iMatchingSTW);


            ///////////////////////////// #Step_22_US_Dallas_Derivation Groups

            dic.Clear();
            dic.Add("Level_1", sData2012);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "DeriveUSC");
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


            mLog_US_D.LogPass(iDerivationGrps);

            ///////////////////////////// #Step_23_US_Dallas_Snapshots

            dic.Clear();
            dic.Add("Level_1", sData2012);
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "Valuation Data");
            pData._TreeViewSelect(dic);


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

            pMain._SelectTab(sData2012);

            pData._ts_SP_CreateExtract(sOuput_US_Dallas + "SnapshotExtract.xlsx");

            mLog_US_D.LogPass(iSnapshots);


            pMain._Home_ToolbarClick_Top(true);

            ///////////////////////////// #Step_24_US_Dallas_Simple Import

            dic.Clear();
            dic.Add("Level_1", sData2012);
            dic.Add("Level_2", "Simple Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "SimpleImport");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", sSimpleImportName_US);
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            pMain._SelectTab(sData2012);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            dic.Add("Process", "Click");
            pData._PopVerify_SimpleImport(dic);

            pMain._SelectTab(sData2012);

            mLog_US_D.LogPass(iSimpleImport);


            ///////////////////////////// #Step_25_US_Dallas_Undo Snapshot

            dic.Clear();
            dic.Add("Level_1", sData2012);
            dic.Add("Level_2", "Undo");
            pData._TreeViewSelect(dic);



            pData._ts_Undo("Snapshot Publish", 0, "Test undo snapshot");

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab(sData2012);

            mLog_US_D.LogPass(iUndoSnapshot);

            ///////////////////////////// #Step_26_US_Dallas_Redo Snapshot


            dic.Clear();
            dic.Add("Level_1", sData2012);
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "Valuation Data");
            pData._TreeViewSelect(dic);

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

            pMain._SelectTab(sData2012);

            mLog_US_D.LogPass(iRedoSnapshot);

            pMain._SelectTab(sData2012);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            /////////////////////////////////////////////////////   Valuations    ///////////////////////////////////////////////////////


            ///////////////////////////// #Step_27_US_Dallas_Rollforward Valuation

            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName_D);
            dic.Add("Level_2", Config.sPlanName_US);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", sValuation2012);
            dic.Add("Parent", "Conversion_2011");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "2012");
            dic.Add("FirstYearPlanUnderPPA", "2008");
            //////////dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            dic.Add("Check_FundingCalculatorNotRunComplete", "False");
            pMain._PopVerify_Home_ServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", sValuation2012);
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab(sValuation2012);

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
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "True");
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

            pMain._SelectTab(sValuation2012);

            mLog_US_D.LogPass(iRollforwardValuation);


            ///////////////////////////// #Step_28_US_Dallas_Import and Apply Mappings

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
            dic.Add("SnapshotName", "Valuation Data");
            dic.Add("SnapshotName_Parent", sData2012);
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "True");
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
            dic.Add("CompareData", "False");
            dic.Add("ImportDataandApplyMapping", "");
            dic.Add("ViewMappedData", "");
            dic.Add("ExportMappingstoExcel", "");
            dic.Add("CheckVOImportPopup", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._SelectTab("Participant DataSet");

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


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("CompareData", "");
            dic.Add("ImportDataandApplyMapping", "");
            dic.Add("ViewMappedData", "Click");
            dic.Add("ExportMappingsToExcel", "");
            dic.Add("CheckVOImportPopup", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            _gLib._SetSyncUDWin("ViewDataParameters_View", pParticipantDataSet.wViewDataParameters.btnView.btn, "Click", 0);
            _gLib._SetSyncUDWin("ViewData_ReturntoParameters", pParticipantDataSet.wViewData.btnReturntoParameters.btn, "Click", 0);
            _gLib._SetSyncUDWin("ViewDataParameters_Cancel", pParticipantDataSet.wViewDataParameters.btnCancel.btn, "Click", 0);

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
            dic.Add("ImportDataandApplyMapping", "");
            dic.Add("ViewMappedData", "");
            dic.Add("ExportMappingstoExcel", "Click");
            dic.Add("CheckVOImportPopup", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


            pOutputManager._SaveAs(sOuput_US_Dallas + "ExportMappingToExcel.xlsx");
            _gLib._FileExists(sOuput_US_Dallas + "ExportMappingToExcel.xlsx", Config.iTimeout, true);


            mLog_US_D.LogPass(iImportDataApplyMap);

            ///////////////////////////// #Step_29_US_Dallas_Edit & Save a Provision

            pMain._SelectTab(sValuation2012);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Provisions");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BenefitService");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProvidedInDataField", "Benefit1DB");
            pService._PopVerify_ServiceAtValuationDate(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProvidedInDataField", "BenService");
            pService._PopVerify_ServiceAtValuationDate(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            mLog_US_D.LogPass(iEditAndSaveProvison);


            ///////////////////////////// #Step_30_US_Dallas_Run Valuation

            pMain._SelectTab(sValuation2012);


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
            dic.Add("GL_PPANAR_Min", "True");
            dic.Add("GL_PPANAR_Max", "True");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "BenefitInPayment");
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
            dic.Add("PayoutProjectionCustomGroup", "HourlyFlag");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            mLog_US_D.LogPass(iRunValuation);


            ///////////////////////////// #Step_31_US_Dallas_Run a test case from TestCaseLibrary

            pMain._SelectTab(sValuation2012);



            dic.Clear();
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("iPosX", "");
            dic.Add("iPosY", "");
            dic.Add("MenuItem_1", "Test Case");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);

            ////////////////////////if (_gLib._Exists("Save", pMain.wPrompttoSave, 1, false))
            ////////////////////////    _gLib._SetSyncUDWin("Save - Yes", pMain.wPrompttoSave.wYes.btn, "Click", 0);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunSelectedTestLife", "Click");
            pTestCaseLibrary._PopVerify_TestCaseLibrary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllLiabilityTypes", "True");
            dic.Add("PPA_NAR_Min", "");
            dic.Add("PPA_NAR_Max", "");
            dic.Add("PPA_NAR_PVVB", "");
            dic.Add("PBGC_NAR_PVVB", "");
            dic.Add("FAS35_PVAB", "");
            dic.Add("FAS35_PVVB", "");
            dic.Add("Funding", "");
            dic.Add("PayoutProjection", "");
            dic.Add("RunSelected", "Click");
            pTestCaseLibrary._PopVerify_TestCaseRunOption(dic);

            _gLib._Enabled("Recalculate", pTestCaseLibrary.wTestCaseViewer.wRecalculate, Config.iTimeout * 3, true);
            _gLib._Exists("Recalculate", pTestCaseLibrary.wTestCaseViewer.wViewTestCaseInExcel.txt.link, Config.iTimeout * 3, true);

            mLog_US_D.LogPass(iRunTestCase);


            ///////////////////////////// #Step_32_US_Dallas_View Test Case in Excel

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewTestCaseInExcel", "Click");
            dic.Add("Close", "");
            pTestCaseLibrary._PopVerify_TestCaseViewer(dic);

            _gLib._Exists("Excel", pOutputManager.wExcel, Config.iTimeout * 3, true);

            pOutputManager._Excel_SaveFile(sOuput_US_Dallas + "TestCaseOutput.xlsx");
            _gLib._FileExists(sOuput_US_Dallas + "TestCaseOutput.xlsx", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewTestCaseInExcel", "");
            dic.Add("Close", "Click");
            pTestCaseLibrary._PopVerify_TestCaseViewer(dic);


            pMain._SelectTab("Test Case Library");

            mLog_US_D.LogPass(iViewTestCaseInXls);


            pMain._SelectTab(sValuation2012);
            pMain._Home_ToolbarClick_Top(true);
            ////////////////////////////////////////pMain._Home_ToolbarClick_Top(false);



            //////////////////////////////////// US Dallas - Download & Compare Reports


            ////////////////////////////////////pMain._SelectTab("Home");


            ////////////////////////////////////dic.Clear();
            ////////////////////////////////////dic.Add("Level_1", Config.sClientName_D);
            ////////////////////////////////////dic.Add("Level_2", Config.sPlanName_US);
            ////////////////////////////////////dic.Add("Level_3", "FundingValuations");
            ////////////////////////////////////pMain._HomeTreeViewSelect_Favorites(0, dic);


            ////////////////////////////////////dic.Clear();
            ////////////////////////////////////dic.Add("PopVerify", "Pop");
            ////////////////////////////////////dic.Add("AddServiceInstance", "");
            ////////////////////////////////////dic.Add("ServiceToOpen", sValuation2012);
            ////////////////////////////////////pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab(sValuation2012);

            ///////////////////////////// #Step_37_US_Dallas_Enterprise Run Complete Successful

            pMain._SelectTab(sValuation2012);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            mLog_US_D.LogPass(iEnterpriseRun);


            pMain._SelectTab(sValuation2012);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            ///////////////////////////// #Step_38_US_Dallas_Download Valuation Summary

            pOutputManager._ExportReport_Common(sOuput_US_Dallas, "Valuation Summary", "RollForward", false, true);
            mLog_US_D.LogPass(iDownload_ValSum);

            ///////////////////////////// #Step_39_US_Dallas_Download Parameter Print
            pOutputManager._ExportReport_Others(sOuput_US_Dallas, "Parameter Print", "RollForward", true, true);
            mLog_US_D.LogPass(iDownload_ParamPrint);

            ///////////////////////////// #Step_40_US_Dallas_Download IOE
            pOutputManager._ExportReport_Others(sOuput_US_Dallas, "IOE", "RollForward", false, true);
            mLog_US_D.LogPass(iDownload_IOE);

            pMain._SelectTab(sValuation2012);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            //////////////////thrd_US_Dallas.Start();



            mLog_US_D.LogInfo(iTest_End, iLog_US_D, DateTime.Now.ToString());



                #endregion

                t_CompareRpt_US_Dallas();
            }
            
            ///////////////////////////// EU Cursory Test ///////////////////////////////////////////
            
            if (Config.sClientName_B != null)
            {
                #region DE_Bedford
                _gLib._KillProcessByName("AcroRd32");
            Config.eCountry = _Country.DE;
            pMain._SetLanguageAndRegional();

            mLog_DE_B.LogInfo(iTest_Start, iLog_DE_B, DateTime.Now.ToString());



            ///////////////////////////// #Step_41_DE_Bedford_Rollforward Data
            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName_B);
            dic.Add("Level_2", Config.sPlanName_DE);
            dic.Add("Level_3", "ParticipantData");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", sData2009);
            dic.Add("EffectiveDate", "31.12.2009");
            dic.Add("Parent", "Conversion_2008");
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
            dic.Add("ServiceToOpen", sData2009);
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            mLog_DE_B.LogPass(iRollforwardData);


            ///////////////////////////// #Step_42_DE_Bedford_Upload Data File

            dic.Clear();
            dic.Add("Level_1", sData2009);
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
            dic.Add("FileName", sDataFile_DE);
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);


            _gLib._SetSyncUDWin("wUD_RepositoryFileName", pData.wRetirementStudio.wUD_RepositoryFileName.txt, sDataFileName_DE, 0);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);

            if (_gLib._Exists("Upload", pData.wUL_Upload, 2, false))
                _gLib._SetSyncUDWin("OK", pData.wUL_Upload.wOK.btn, "click", 0);

            pMain._SelectTab(sData2009);

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
            dic.Add("FileName", sSimpleImport_DE);
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            _gLib._SetSyncUDWin("wUD_RepositoryFileName", pData.wRetirementStudio.wUD_RepositoryFileName.txt, sSimpleImportName_DE, 0);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);

            if (_gLib._Exists("Upload", pData.wUL_Upload, 2, false))
                _gLib._SetSyncUDWin("OK", pData.wUL_Upload.wOK.btn, "click", 0);

            pMain._SelectTab(sData2009);
            mLog_DE_B.LogPass(iUploadDataFile);


            ///////////////////////////// #Step_43_DE_Bedford_Import - Select File

            dic.Clear();
            dic.Add("Level_1", sData2009);
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Import Data");
            pData._TreeViewSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", sDataFileName_DE);
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_SelectFile(dic);

            pData._SelectTab("Select File");
            mLog_DE_B.LogPass(iImportSelectFile);


            ///////////////////////////// #Step_44_DE_Bedford_Validate & Load

            pData._SelectTab("Validate & Load");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "True");
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

            mLog_DE_B.LogPass(iValidateAndLoad);


            ///////////////////////////// #Step_45_DE_Bedford_Matching & Save to Warehouse

            pData._SelectTab("Matching");


            dic.Clear();
            dic.Add("Field", "EmployeeIDNumber");
            dic.Add("Include", "False");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "Name");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "BirthDate");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "HireDate1");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "Gender");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "ParticipantStatus");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "PayStatus");
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
            dic.Add("Unique_NoMatch_Num", "");
            dic.Add("Unique_UniqueMatch_Num", "85");
            dic.Add("Unique_MultipleMatches_Num", "");
            dic.Add("Duplicate_NoMatch_Num", "");
            dic.Add("Duplicate_UniqueMatch_Num", "");
            dic.Add("Duplicate_MultipleMatches_Num", "");
            dic.Add("Warehouse_NoMatch_Num", "");
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
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "All 'UniqueUniqueMatch' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);



            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Matched_Num", "85");
            dic.Add("New_Num", "");
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
            pData._PopVerify_IP_Matching_ProcessMatchingResultsContinuePopup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);

            pMain._SelectTab(sData2009);
            mLog_DE_B.LogPass(iMatchingSTW);


            ///////////////////////////// #Step_46_DE_Bedford_Derivation Groups

            dic.Clear();
            dic.Add("Level_1", sData2009);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "PreVal Derivations");
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
            dic.Add("Level_1", sData2009);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "DeriveUSC");
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

            pMain._SelectTab(sData2009);
            mLog_DE_B.LogPass(iDerivationGrps);


            ///////////////////////////// #Step_47_DE_Bedford_Snapshots

            dic.Clear();
            dic.Add("Level_1", sData2009);
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "ValuationData");
            pData._TreeViewSelect(dic);

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

            pData._ts_SP_CreateExtract(sOuput_DE_Bedford + "SnapshotExtract.xlsx");

            mLog_DE_B.LogPass(iSnapshots);


            pMain._Home_ToolbarClick_Top(true);


            ///////////////////////////// #Step_48_DE_Bedford_Simple Import

            dic.Clear();
            dic.Add("Level_1", sData2009);
            dic.Add("Level_2", "Simple Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "SimpleImport");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", sSimpleImportName_DE);
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            pMain._SelectTab(sData2009);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            dic.Add("Process", "Click");
            pData._PopVerify_SimpleImport(dic);

            pMain._SelectTab(sData2009);

            mLog_DE_B.LogPass(iSimpleImport);


            ///////////////////////////// #Step_49_DE_Bedford_Undo Snapshot

            dic.Clear();
            dic.Add("Level_1", sData2009);
            dic.Add("Level_2", "Undo");
            pData._TreeViewSelect(dic);



            pData._ts_Undo("Snapshot Publish", 0, "Test undo snapshot");

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab(sData2009);

            mLog_DE_B.LogPass(iUndoSnapshot);


            ///////////////////////////// #Step_50_DE_Bedford_Redo Snapshot

            dic.Clear();
            dic.Add("Level_1", sData2009);
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "ValuationData");
            pData._TreeViewSelect(dic);

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

            pMain._SelectTab(sData2009);

            mLog_DE_B.LogPass(iRedoSnapshot);

            pMain._SelectTab(sData2009);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            thrd_DE_Data_B.Start();

            ///////////////////////////////////////////////////   Valuations    ///////////////////////////////////////////////////////


            ///////////////////////////// #Step_51_DE_Bedford_Rollforward Valuation

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName_B);
            dic.Add("Level_2", Config.sPlanName_DE);
            dic.Add("Level_3", "PensionValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", sPension2009);
            dic.Add("Parent", "Conversion_2008");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "2009");
            dic.Add("RSC", "");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "True");
            dic.Add("SelectAllVO", "Click");
            dic.Add("DeselectAll", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            dic.Add("Check_FundingCalculatorNotRunComplete", "False");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", sPension2009);
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);



            pMain._SelectTab(sPension2009);

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
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "True");
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

            pMain._SelectTab(sPension2009);

            mLog_DE_B.LogPass(iRollforwardValuation);


            ///////////////////////////// #Step_52_DE_Bedford_Import and Apply Mappings

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
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "ValuationData");
            dic.Add("SnapshotName_Parent", sData2009);
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
            dic.Add("ImportDataandApplyMapping", "Click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

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
            dic.Add("ImportDataandApplyMapping", "");
            dic.Add("ViewMappedData", "Click");
            dic.Add("ExportMappingsToExcel", "");
            dic.Add("CheckVOImportPopup", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            _gLib._SetSyncUDWin("ViewDataParameters_View", pParticipantDataSet.wViewDataParameters.btnView.btn, "Click", 0);
            _gLib._SetSyncUDWin("ViewData_ReturntoParameters", pParticipantDataSet.wViewData.btnReturntoParameters.btn, "Click", 0);
            _gLib._SetSyncUDWin("ViewDataParameters_Cancel", pParticipantDataSet.wViewDataParameters.btnCancel.btn, "Click", 0);

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
            dic.Add("ImportDataandApplyMapping", "");
            dic.Add("ViewMappedData", "");
            dic.Add("ExportMappingstoExcel", "Click");
            dic.Add("CheckVOImportPopup", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


            pOutputManager._SaveAs(sOuput_DE_Bedford + "ExportMappingToExcel.xlsx");
            _gLib._FileExists(sOuput_DE_Bedford + "ExportMappingToExcel.xlsx", Config.iTimeout, true);


            mLog_DE_B.LogPass(iImportDataApplyMap);


            ///////////////////////////// #Step_53_DE_Bedford_Edit & Save a Provision

            pMain._SelectTab(sPension2009);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Provisions");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "WaitingService");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Date", "DeathDate");
            dic.Add("RoundingRule", "");
            pService._PopVerify_RulesBasedService(dic);

            pMain._Home_ToolbarClick_Top(true);



            pMain._SelectTab("Provisions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Date", "WaitingPeriodStartDate");
            dic.Add("RoundingRule", "");
            pService._PopVerify_RulesBasedService(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            mLog_DE_B.LogPass(iEditAndSaveProvison);


            ///////////////////////////// #Step_54_DE_Bedford_Run Valuation

            pMain._SelectTab(sPension2009);


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
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "True");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "NetPayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "False");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "Pen1");
            dic.Add("SelectVOs_VO2", "Pen2");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab(sPension2009);
            mLog_DE_B.LogPass(iRunValuation);


            ///////////////////////////// #Step_55_DE_Bedford_Edit & Save Actuarial Report



            pMain._SelectTab(sPension2009);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Actuarial Report");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pActuarialReport._SelectTab("Tax and Trade");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Benefit Type Name");
            dic.Add("iCol", "1");
            dic.Add("sData", "Pensionen");
            dic.Add("sFieldType", "LIST");
            pActuarialReport._TaxAndTrade_TBL(dic);

            pMain._Home_ToolbarClick_Top(true);

            pActuarialReport._SelectTab("Tax and Trade");

            pActuarialReport._SelectTab("Report Contents");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Copy", "click");
            dic.Add("CopyAStandLayout", "true");
            dic.Add("Template", "Direct promise default");
            dic.Add("OK", "click");
            pActuarialReport._ManageIndividualListingLayouts(dic);

            pActuarialReport._SelectTab("Report Contents");

            _gLib._SetSyncUDWin("wIndividualListingLayouts", pActuarialReport.wRetirementStudio.wRC_IndividualListingLayouts.listSpd, "Click", 0, false, 20, 15);
            _gLib._SetSyncUDWin("Delete", pActuarialReport.wRetirementStudio.wRC_Delete.btn, "Click", 0);
            pActuarialReport._SelectTab("Report Contents");

            pMain._Home_ToolbarClick_Top(true);
            pActuarialReport._SelectTab("Report Contents");

            mLog_DE_B.LogPass(iEditAndSaveAR_DE);


            pMain._SelectTab(sPension2009);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", sPension2009);
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            ///////////////////////////// #Step_56_DE_Bedford_Enterprise Run Complete Successful
            pMain._SelectTab(sPension2009);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            ///////////////////////////// #Step_57_DE_Bedford_Run Actuarial Report

            pMain._SelectTab(sPension2009);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial Report");
            pMain._FlowTreeRightSelect(dic);

            if (_gLib._Exists("Confirm", pMain.wHome_Confirm, 2, false))
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("Yes", "Click");
                dic.Add("No", "");
                pMain._PopVerify_Home_Confrim(dic);
            }

            pMain._SelectTab(sPension2009);

            mLog_DE_B.LogPass(iRunAR_DE);





            pMain._SelectTab(sPension2009);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            mLog_DE_B.LogPass(iEnterpriseRun);

            pMain._SelectTab(sPension2009);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);




            ///////////////////////////// #Step_58_DE_Bedford_Download Valuation Summary
            Config.eCountry = _Country.DE;
            pOutputManager._ExportReport_Common(sOuput_DE_Bedford, "Valuation Summary for Excel Export", "RollForward", false, true);
            mLog_DE_B.LogPass(iDownload_ValSum);


            ///////////////////////////// #Step_59_DE_Bedford_Download IOE
            Config.eCountry = _Country.DE;
            pOutputManager._SelectTab("Output Manager");
            pOutputManager._ExportReport_Others(sOuput_DE_Bedford, "IOE", "RollForward", false, true);
            mLog_DE_B.LogPass(iDownload_IOE);



            ///////////////////////////// #Step_60_DE_Bedford_Download Actuarial Report
            Config.eCountry = _Country.DE;
            pOutputManager._SelectTab("Output Manager");
            pOutputManager._Navigate(Config.eCountry, "Direct Promise", "RollForward", true);
            pOutputManager._SelectTab("Direct Promise");

            _gLib._SetSyncUDWin("ExportAllToExcel", pOutputManager.wRetirementStudio.wExportAllCombinedReport.txt.link, "Click", 0);

            if (_gLib._Exists("Save As", pOutputManager.wSaveAs, Config.iTimeout * 3, true))
            {
                pOutputManager._SaveAs(sOuput_DE_Bedford + "DirerctPromise.zip");
                _gLib._FileExists(sOuput_DE_Bedford + "DirerctPromise.zip", Config.iTimeout, true);
            }

            mLog_DE_B.LogPass(iDownload_AR_DE);



            pMain._SelectTab(sPension2009);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            mLog_DE_B.LogInfo(iTest_End, iLog_DE_B, DateTime.Now.ToString());

            //////////////thrd_DE_Val_B.Start();

            #endregion

                t_CompareRpt_DE_Val_B();
            }

            if (Config.sClientName_E != null)
            {
                #region DE_Exeter
                _gLib._KillProcessByName("AcroRd32");
            Config.eCountry = _Country.DE;
            pMain._SetLanguageAndRegional();

            mLog_DE_E.LogInfo(iTest_Start, iLog_DE_E, DateTime.Now.ToString());



            ///////////////////////////// #Step_61_DE_Exeter_Rollforward Data
            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName_E);
            dic.Add("Level_2", Config.sPlanName_DE);
            dic.Add("Level_3", "ParticipantData");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", sData2009);
            dic.Add("EffectiveDate", "31.12.2009");
            dic.Add("Parent", "Conversion_2008");
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
            dic.Add("ServiceToOpen", sData2009);
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            mLog_DE_E.LogPass(iRollforwardData);


            ///////////////////////////// #Step_62_DE_Exeter_Upload Data File

            dic.Clear();
            dic.Add("Level_1", sData2009);
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
            dic.Add("FileName", sDataFile_DE);
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            _gLib._SetSyncUDWin("wUD_RepositoryFileName", pData.wRetirementStudio.wUD_RepositoryFileName.txt, sDataFileName_DE, 0);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);

            if (_gLib._Exists("Upload", pData.wUL_Upload, 2, false))
                _gLib._SetSyncUDWin("OK", pData.wUL_Upload.wOK.btn, "click", 0);

            pMain._SelectTab(sData2009);

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
            dic.Add("FileName", sSimpleImport_DE);
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            _gLib._SetSyncUDWin("wUD_RepositoryFileName", pData.wRetirementStudio.wUD_RepositoryFileName.txt, sSimpleImportName_DE, 0);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);

            if (_gLib._Exists("Upload", pData.wUL_Upload, 2, false))
                _gLib._SetSyncUDWin("OK", pData.wUL_Upload.wOK.btn, "click", 0);

            pMain._SelectTab(sData2009);
            mLog_DE_E.LogPass(iUploadDataFile);


            ///////////////////////////// #Step_63_DE_Exeter_Import - Select File

            dic.Clear();
            dic.Add("Level_1", sData2009);
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Import Data");
            pData._TreeViewSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", sDataFileName_DE);
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_SelectFile(dic);

            pData._SelectTab("Select File");
            mLog_DE_E.LogPass(iImportSelectFile);


            ///////////////////////////// #Step_64_DE_Exeter_Validate & Load

            pData._SelectTab("Validate & Load");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "True");
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

            mLog_DE_E.LogPass(iValidateAndLoad);


            ///////////////////////////// #Step_65_DE_Exeter_Matching & Save to Warehouse

            pData._SelectTab("Matching");


            dic.Clear();
            dic.Add("Field", "EmployeeIDNumber");
            dic.Add("Include", "False");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "Name");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "BirthDate");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "HireDate1");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "Gender");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "ParticipantStatus");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "PayStatus");
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
            dic.Add("Unique_NoMatch_Num", "");
            dic.Add("Unique_UniqueMatch_Num", "85");
            dic.Add("Unique_MultipleMatches_Num", "");
            dic.Add("Duplicate_NoMatch_Num", "");
            dic.Add("Duplicate_UniqueMatch_Num", "");
            dic.Add("Duplicate_MultipleMatches_Num", "");
            dic.Add("Warehouse_NoMatch_Num", "");
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
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "All 'UniqueUniqueMatch' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);



            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Matched_Num", "85");
            dic.Add("New_Num", "");
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
            pData._PopVerify_IP_Matching_ProcessMatchingResultsContinuePopup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);

            pMain._SelectTab(sData2009);
            mLog_DE_E.LogPass(iMatchingSTW);


            ///////////////////////////// #Step_66_DE_Exeter_Derivation Groups

            dic.Clear();
            dic.Add("Level_1", sData2009);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "PreVal Derivations");
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
            dic.Add("Level_1", sData2009);
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "DeriveUSC");
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

            pMain._SelectTab(sData2009);
            mLog_DE_E.LogPass(iDerivationGrps);


            ///////////////////////////// #Step_67_DE_Exeter_Snapshots

            dic.Clear();
            dic.Add("Level_1", sData2009);
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "ValuationData");
            pData._TreeViewSelect(dic);

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

            pData._ts_SP_CreateExtract(sOuput_DE_Exeter + "SnapshotExtract.xlsx");

            mLog_DE_E.LogPass(iSnapshots);


            pMain._Home_ToolbarClick_Top(true);


            ///////////////////////////// #Step_68_DE_Exeter_Simple Import

            dic.Clear();
            dic.Add("Level_1", sData2009);
            dic.Add("Level_2", "Simple Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "SimpleImport");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", sSimpleImportName_DE);
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            pMain._SelectTab(sData2009);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            dic.Add("Process", "Click");
            pData._PopVerify_SimpleImport(dic);

            pMain._SelectTab(sData2009);

            mLog_DE_E.LogPass(iSimpleImport);


            ///////////////////////////// #Step_69_DE_Exeter_Undo Snapshot

            dic.Clear();
            dic.Add("Level_1", sData2009);
            dic.Add("Level_2", "Undo");
            pData._TreeViewSelect(dic);



            pData._ts_Undo("Snapshot Publish", 0, "Test undo snapshot");

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab(sData2009);

            mLog_DE_E.LogPass(iUndoSnapshot);


            ///////////////////////////// #Step_70_DE_Exeter_Redo Snapshot

            dic.Clear();
            dic.Add("Level_1", sData2009);
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "ValuationData");
            pData._TreeViewSelect(dic);

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

            pMain._SelectTab(sData2009);

            mLog_DE_E.LogPass(iRedoSnapshot);

            pMain._SelectTab(sData2009);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            thrd_DE_Data_E.Start();

            ///////////////////////////////////////////////////   Valuations    ///////////////////////////////////////////////////////


            ///////////////////////////// #Step_71_DE_Exeter_Rollforward Valuation

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName_E);
            dic.Add("Level_2", Config.sPlanName_DE);
            dic.Add("Level_3", "PensionValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", sPension2009);
            dic.Add("Parent", "Conversion_2008");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "2009");
            dic.Add("RSC", "");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "True");
            dic.Add("SelectAllVO", "Click");
            dic.Add("DeselectAll", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            dic.Add("Check_FundingCalculatorNotRunComplete", "False");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", sPension2009);
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);



            pMain._SelectTab(sPension2009);

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
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "True");
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

            pMain._SelectTab(sPension2009);

            mLog_DE_E.LogPass(iRollforwardValuation);


            ///////////////////////////// #Step_72_DE_Exeter_Import and Apply Mappings

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
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "ValuationData");
            dic.Add("SnapshotName_Parent", sData2009);
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
            dic.Add("ImportDataandApplyMapping", "Click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

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
            dic.Add("ImportDataandApplyMapping", "");
            dic.Add("ViewMappedData", "Click");
            dic.Add("ExportMappingsToExcel", "");
            dic.Add("CheckVOImportPopup", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            _gLib._SetSyncUDWin("ViewDataParameters_View", pParticipantDataSet.wViewDataParameters.btnView.btn, "Click", 0);
            _gLib._SetSyncUDWin("ViewData_ReturntoParameters", pParticipantDataSet.wViewData.btnReturntoParameters.btn, "Click", 0);
            _gLib._SetSyncUDWin("ViewDataParameters_Cancel", pParticipantDataSet.wViewDataParameters.btnCancel.btn, "Click", 0);

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
            dic.Add("ImportDataandApplyMapping", "");
            dic.Add("ViewMappedData", "");
            dic.Add("ExportMappingstoExcel", "Click");
            dic.Add("CheckVOImportPopup", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


            pOutputManager._SaveAs(sOuput_DE_Exeter + "ExportMappingToExcel.xlsx");
            _gLib._FileExists(sOuput_DE_Exeter + "ExportMappingToExcel.xlsx", Config.iTimeout, true);


            mLog_DE_E.LogPass(iImportDataApplyMap);


            ///////////////////////////// #Step_73_DE_Exeter_Edit & Save a Provision

            pMain._SelectTab(sPension2009);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Provisions");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "WaitingService");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Date", "DeathDate");
            dic.Add("RoundingRule", "");
            pService._PopVerify_RulesBasedService(dic);

            pMain._Home_ToolbarClick_Top(true);



            pMain._SelectTab("Provisions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Date", "WaitingPeriodStartDate");
            dic.Add("RoundingRule", "");
            pService._PopVerify_RulesBasedService(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");

            mLog_DE_E.LogPass(iEditAndSaveProvison);


            ///////////////////////////// #Step_74_DE_Exeter_Run Valuation

            pMain._SelectTab(sPension2009);


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
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "True");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "NetPayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "False");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "Pen1");
            dic.Add("SelectVOs_VO2", "Pen2");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab(sPension2009);
            mLog_DE_E.LogPass(iRunValuation);


            ///////////////////////////// #Step_75_DE_Exeter_Edit & Save Actuarial Report



            pMain._SelectTab(sPension2009);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Actuarial Report");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pActuarialReport._SelectTab("Tax and Trade");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Benefit Type Name");
            dic.Add("iCol", "1");
            dic.Add("sData", "Pensionen");
            dic.Add("sFieldType", "LIST");
            pActuarialReport._TaxAndTrade_TBL(dic);

            pMain._Home_ToolbarClick_Top(true);

            pActuarialReport._SelectTab("Tax and Trade");

            pActuarialReport._SelectTab("Report Contents");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Copy", "click");
            dic.Add("CopyAStandLayout", "true");
            dic.Add("Template", "Direct promise default");
            dic.Add("OK", "click");
            pActuarialReport._ManageIndividualListingLayouts(dic);

            pActuarialReport._SelectTab("Report Contents");

            _gLib._SetSyncUDWin("wIndividualListingLayouts", pActuarialReport.wRetirementStudio.wRC_IndividualListingLayouts.listSpd, "Click", 0, false, 20, 15);
            _gLib._SetSyncUDWin("Delete", pActuarialReport.wRetirementStudio.wRC_Delete.btn, "Click", 0);
            pActuarialReport._SelectTab("Report Contents");

            pMain._Home_ToolbarClick_Top(true);
            pActuarialReport._SelectTab("Report Contents");

            mLog_DE_E.LogPass(iEditAndSaveAR_DE);


            pMain._SelectTab(sPension2009);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", sPension2009);
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            ///////////////////////////// #Step_76_DE_Exeter_Enterprise Run Complete Successful
            pMain._SelectTab(sPension2009);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            ///////////////////////////// #Step_77_DE_Exeter_Run Actuarial Report

            pMain._SelectTab(sPension2009);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial Report");
            pMain._FlowTreeRightSelect(dic);

            if (_gLib._Exists("Confirm", pMain.wHome_Confirm, 2, false))
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("Yes", "Click");
                dic.Add("No", "");
                pMain._PopVerify_Home_Confrim(dic);
            }

            pMain._SelectTab(sPension2009);

            mLog_DE_E.LogPass(iRunAR_DE);





            pMain._SelectTab(sPension2009);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            mLog_DE_E.LogPass(iEnterpriseRun);

            pMain._SelectTab(sPension2009);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);




            ///////////////////////////// #Step_78_DE_Exeter_Download Valuation Summary
            Config.eCountry = _Country.DE;
            pOutputManager._ExportReport_Common(sOuput_DE_Exeter, "Valuation Summary for Excel Export", "RollForward", false, true);
            mLog_DE_E.LogPass(iDownload_ValSum);


            ///////////////////////////// #Step_79_DE_Exeter_Download IOE
            Config.eCountry = _Country.DE;
            pOutputManager._SelectTab("Output Manager");
            pOutputManager._ExportReport_Others(sOuput_DE_Exeter, "IOE", "RollForward", false, true);
            mLog_DE_E.LogPass(iDownload_IOE);



            ///////////////////////////// #Step_80_DE_Exeter_Download Actuarial Report
            Config.eCountry = _Country.DE;
            pOutputManager._SelectTab("Output Manager");
            pOutputManager._Navigate(Config.eCountry, "Direct Promise", "RollForward", true);
            pOutputManager._SelectTab("Direct Promise");

            _gLib._SetSyncUDWin("ExportAllToExcel", pOutputManager.wRetirementStudio.wExportAllCombinedReport.txt.link, "Click", 0);

            if (_gLib._Exists("Save As", pOutputManager.wSaveAs, Config.iTimeout * 3, true))
            {
                pOutputManager._SaveAs(sOuput_DE_Exeter + "DirerctPromise.zip");
                _gLib._FileExists(sOuput_DE_Exeter + "DirerctPromise.zip", Config.iTimeout, true);
            }

            mLog_DE_E.LogPass(iDownload_AR_DE);



            pMain._SelectTab(sPension2009);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            mLog_DE_E.LogInfo(iTest_End, iLog_DE_E, DateTime.Now.ToString());

            //////////////////////thrd_DE_Val_E.Start();

            #endregion

                t_CompareRpt_DE_Val_E();
            }



            #region Delete ValService


            if (Config.sClientName != null)
            {
                dic.Clear();
                dic.Add("Level_1", Config.sClientName);
                dic.Add("Level_2", Config.sPlanName_US);
                dic.Add("Level_3", "FundingValuations");
                dic.Add("ServiceToDelete", sValuation2012);
                pMain._DeleteValService(dic);

            }

            if (Config.sClientName_D != null)
            {
                dic.Clear();
                dic.Add("Level_1", Config.sClientName_D);
                dic.Add("Level_2", Config.sPlanName_US);
                dic.Add("Level_3", "FundingValuations");
                dic.Add("ServiceToDelete", sValuation2012);
                pMain._DeleteValService(dic);

            }

            if (Config.sClientName_F != null)
            {
                dic.Clear();
                dic.Add("Level_1", Config.sClientName_F);
                dic.Add("Level_2", Config.sPlanName_US);
                dic.Add("Level_3", "FundingValuations");
                dic.Add("ServiceToDelete", sValuation2012);
                pMain._DeleteValService(dic);
            }

            

            if (Config.sClientName_B != null)
            {
                dic.Clear();
                dic.Add("Level_1", Config.sClientName_B);
                dic.Add("Level_2", Config.sPlanName_DE);
                dic.Add("Level_3", "PensionValuations");
                dic.Add("ServiceToDelete", sPension2009);
                pMain._DeleteValService(dic);
            }
            if (Config.sClientName_E != null)
            {
                dic.Clear();
                dic.Add("Level_1", Config.sClientName_E);
                dic.Add("Level_2", Config.sPlanName_DE);
                dic.Add("Level_3", "PensionValuations");
                dic.Add("ServiceToDelete", sPension2009);
                pMain._DeleteValService(dic);
            }



            #endregion



            ////////////////////////while (!Config.bThreadFinsihed)
            ////////////////////////    _gLib._Wait(3);


            _gLib._MsgBox("Congratulations!", "Cursory Test Completed!");




        }




        void t_CompareRpt_CA_Canada()
        {

            string sRes = "";
            string sBaseline_Dir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\Prod_Cursory_Output\Inputs\Baseline_Reports\US_Franklin\";


            CompareReportsLib _compareReportsLib = new CompareReportsLib("Cursory_Output", sBaseline_Dir, sOuput_CA_Canada);
            _compareReportsLib._Report(_PassFailStep.Description, "", "Cursory_Output_CA_Canada");

            if (!bPreprod)
            {
                sRes = _compareReportsLib.CompareExcel_Exact("SnapshotExtract.xlsx", 0, new int[3, 2] { { 1, 1 }, { 3, 1 }, { 4, 1 } }, new string[1] { "Member Data 1" });
                mLog_CA_C.LogInfo(iCompare_Snapshot, iLog_CA_C, sRes);
            }


            //////sRes = _compareReportsLib.CompareExcel_Exact("ExportMappingToExcel.xlsx", 0, new int[5, 2] { { 2, 1 }, { 40, 2 }, { 41, 2 }, { 71, 2 }, { 72, 2 } }, new string[1] { "Sheet1" });
            //////mLog_CA_C.LogInfo(iCompare_MappingExport, iLog_CA_C, sRes);
            mLog_CA_C.LogInfo(iCompare_MappingExport, iLog_CA_C, "NA");

            sRes = _compareReportsLib.CompareExcel_Exact("TestCaseOutput.xlsx", 0, new int[2, 2] { { 2, 1 }, { 5, 1 } }, new string[1] { "Summary" });
            mLog_CA_C.LogInfo(iCompare_TC, iLog_CA_C, sRes);

            sRes = _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 14, 0, 0, 0);
            mLog_CA_C.LogInfo(iCompare_ValSum, iLog_CA_C, sRes);

            if (!bPreprod)
            {
                sRes = _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                mLog_CA_C.LogInfo(iCompare_IOE, iLog_CA_C, sRes);
            }


            Config.bThreadFinsihed = true;
            

        }
        

        void t_CompareRpt_US_Franklin()
        {

            string sRes = "";
            string sBaseline_Dir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\Prod_Cursory_Output\Inputs\Baseline_Reports\US_Franklin\";


            CompareReportsLib _compareReportsLib = new CompareReportsLib("Cursory_Output", sBaseline_Dir, sOuput_US_Franklin);
            _compareReportsLib._Report(_PassFailStep.Description, "", "Cursory_Output_US_Franklin");

            if (!bPreprod)
            {
                sRes = _compareReportsLib.CompareExcel_Exact("SnapshotExtract.xlsx", 0, new int[3, 2] { { 1, 1 }, { 3, 1 }, { 4, 1 } }, new string[1] { "Member Data 1" });
                mLog_US_F.LogInfo(iCompare_Snapshot, iLog_US_F, sRes);
            }


            ////////////sRes = _compareReportsLib.CompareExcel_Exact("ExportMappingToExcel.xlsx", 0, new int[5, 2] { { 2, 1 }, { 40, 2 }, { 41, 2 }, { 71, 2 }, { 72, 2 } }, new string[1] { "Sheet1" });
            ////////////mLog_US_F.LogInfo(iCompare_MappingExport, iLog_US_F, sRes);
            mLog_US_F.LogInfo(iCompare_MappingExport, iLog_US_F, "NA");

            sRes = _compareReportsLib.CompareExcel_Exact("TestCaseOutput.xlsx", 0, new int[2, 2] { { 2, 1 }, { 5, 1 } }, new string[1] { "Summary" });
            mLog_US_F.LogInfo(iCompare_TC, iLog_US_F, sRes);

            sRes = _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 14, 0, 0, 0);
            mLog_US_F.LogInfo(iCompare_ValSum, iLog_US_F, sRes);

            if (!bPreprod)
            {
                sRes = _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                mLog_US_F.LogInfo(iCompare_IOE, iLog_US_F, sRes);
            }


            Config.bThreadFinsihed = true;



        }
        
        void t_CompareRpt_US_Dallas()
        {

            string sRes = "";
            string sBaseline_Dir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\Prod_Cursory_Output\Inputs\Baseline_Reports\US_Dallas\";


            CompareReportsLib _compareReportsLib = new CompareReportsLib("Cursory_Output", sBaseline_Dir, sOuput_US_Dallas);
            _compareReportsLib._Report(_PassFailStep.Description, "", "Cursory_Output_US_Dallas");

            if (!bPreprod)
            {
                sRes = _compareReportsLib.CompareExcel_Exact("SnapshotExtract.xlsx", 0, new int[3, 2] { { 1, 1 }, { 3, 1 }, { 4, 1 } }, new string[1] { "Member Data 1" });
                mLog_US_D.LogInfo(iCompare_Snapshot, iLog_US_D, sRes);
            }


            //////////////////sRes = _compareReportsLib.CompareExcel_Exact("ExportMappingToExcel.xlsx", 0, new int[5, 2] { { 2, 1 }, { 40, 2 }, { 41, 2 }, { 71, 2 }, { 72, 2 } }, new string[1] { "Sheet1" });
            //////////////////mLog_US_D.LogInfo(iCompare_MappingExport, iLog_US_D, sRes);
            mLog_US_D.LogInfo(iCompare_MappingExport, iLog_US_D, "NA");

            sRes = _compareReportsLib.CompareExcel_Exact("TestCaseOutput.xlsx", 0, new int[2, 2] { { 2, 1 }, { 5, 1 } }, new string[1] { "Summary" });
            mLog_US_D.LogInfo(iCompare_TC, iLog_US_D, sRes);

            sRes = _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 14, 0, 0, 0);
            mLog_US_D.LogInfo(iCompare_ValSum, iLog_US_D, sRes);

            if (!bPreprod)
            {
                sRes = _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                mLog_US_D.LogInfo(iCompare_IOE, iLog_US_D, sRes);
            }


            Config.bThreadFinsihed = true;



        }

        void t_CompareRpt_DE_Data_B()
        {

            string sRes = "";
            string sBaseline_Dir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\Prod_Cursory_Output\Inputs\Baseline_Reports\DE_Bedford\";


            CompareReportsLib _compareReportsLib = new CompareReportsLib("Cursory_Output", sBaseline_Dir, sOuput_DE_Bedford);
            _compareReportsLib._Report(_PassFailStep.Description, "", "Cursory_Output_DE_Bedford");

            if (!bPreprod)
            {
                sRes = _compareReportsLib.CompareExcel_Exact("SnapshotExtract.xlsx", 0, new int[3, 2] { { 1, 1 }, { 3, 1 }, { 4, 1 } }, new string[1] { "Member Data 1" });
                mLog_DE_B.LogInfo(iCompare_Snapshot, iLog_DE_B, sRes);
            }


            //sRes = _compareReportsLib.CompareExcel_Exact("ExportMappingToExcel.xlsx", 0, new int[5, 2] { { 2, 1 }, { 71, 2 }, { 72, 2 }, { 145, 2 }, { 146, 2 } }, new string[1] { "Sheet1" });
            //mLog_DE_B.LogInfo(iCompare_MappingExport, iLog_DE_B, sRes);
            mLog_DE_B.LogInfo(iCompare_MappingExport, iLog_DE_B, "NA");


            Config.bThreadFinsihed = true;
            
        }
        
        void t_CompareRpt_DE_Val_B()
        {

            string sRes = "";
            string sBaseline_Dir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\Prod_Cursory_Output\Inputs\Baseline_Reports\DE_Bedford\";


            CompareReportsLib _compareReportsLib = new CompareReportsLib("Cursory_Output", sBaseline_Dir, sOuput_DE_Bedford);
            ///////////////_compareReportsLib._Report(_PassFailStep.Description, "", "Cursory_Output_DE_Bedford");



            sRes = _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 2, new string[1] { "Tabellenblatt1" });
            mLog_DE_B.LogInfo(iCompare_ValSum, iLog_DE_B, sRes);

            if (!bPreprod)
            {
                sRes = _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                mLog_DE_B.LogInfo(iCompare_IOE, iLog_DE_B, sRes);
            }


            Config.bThreadFinsihed = true;

        }

        void t_CompareRpt_DE_Data_E()
        {

            string sRes = "";
            string sBaseline_Dir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\Prod_Cursory_Output\Inputs\Baseline_Reports\DE_Bedford\";


            CompareReportsLib _compareReportsLib = new CompareReportsLib("Cursory_Output", sBaseline_Dir, sOuput_DE_Exeter);
            _compareReportsLib._Report(_PassFailStep.Description, "", "Cursory_Output_DE_Exeter");

            if (!bPreprod)
            {
                sRes = _compareReportsLib.CompareExcel_Exact("SnapshotExtract.xlsx", 0, new int[3, 2] { { 1, 1 }, { 3, 1 }, { 4, 1 } }, new string[1] { "Member Data 1" });
                mLog_DE_E.LogInfo(iCompare_Snapshot, iLog_DE_E, sRes);
            }


            //sRes = _compareReportsLib.CompareExcel_Exact("ExportMappingToExcel.xlsx", 0, new int[5, 2] { { 2, 1 }, { 71, 2 }, { 72, 2 }, { 145, 2 }, { 146, 2 } }, new string[1] { "Sheet1" });
            //mLog_DE_E.LogInfo(iCompare_MappingExport, iLog_DE_E, sRes);
            mLog_DE_E.LogInfo(iCompare_MappingExport, iLog_DE_E, "NA");


            Config.bThreadFinsihed = true;

        }

        void t_CompareRpt_DE_Val_E()
        {

            string sRes = "";
            string sBaseline_Dir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\Prod_Cursory_Output\Inputs\Baseline_Reports\DE_Bedford\";


            CompareReportsLib _compareReportsLib = new CompareReportsLib("Cursory_Output", sBaseline_Dir, sOuput_DE_Exeter);
            ///////////////_compareReportsLib._Report(_PassFailStep.Description, "", "Cursory_Output_DE_Franklin");



            sRes = _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 2, new string[1] { "Tabellenblatt1" });
            mLog_DE_E.LogInfo(iCompare_ValSum, iLog_DE_E, sRes);

            if (!bPreprod)
            {
                sRes = _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                mLog_DE_E.LogInfo(iCompare_IOE, iLog_DE_E, sRes);
            }


            Config.bThreadFinsihed = true;

        }





        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            _gLib._KillProcessByName("excel");
            _gLib._KillProcessByName("Mercer.RetirementStudio.Messaging.MessagingClientApp");
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
