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
using System.Threading;
using System.Diagnostics;

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



namespace RetirementStudio._TestScripts._Deployment
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CheckList_EU
    {
        public CheckList_EU()
        {
            ///////Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.DE;
            Config.sClientName_B = "QA DE Benchmark 007";
            Config.sPlanName_B = "Alle - QA DE Benchmark 007";
            Config.sClientName_E = "QA DE Benchmark 007 E";
            Config.sPlanName_E = "Alle - QA DE Benchmark 007 E";

            //Config.sClientName_B = "QA DE Benchmark 007 Existing DNT";
            //Config.sPlanName_B = "QA DE Benchmark 007 Existing DNT Plan";
            //Config.sClientName_E = "QA DE Benchmark 007 Existing DNT";
            //Config.sPlanName_E = "QA DE Benchmark 007 Existing DNT Plan";
            Config.sStudioLaunchDir = @"C:\Users\webber-ling\Desktop\EUProd732\Client\RetirementStudio.exe";
            Config.sDataCenter = "Bedford";
            //Config.sDataCenter = "Exeter";
            Config.sTester = "WL";

        }



        static string sOuput_Main = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\000_DeploymentCheckList";
        static string sTemplate = sOuput_Main + "\\Templates\\Template_CheckList_EU.xlsx";
        static string sOutput_EU_B = sOuput_Main + "\\EU_Bedford\\";
        static string sOutput_EU_E = sOuput_Main + "\\EU_Exeter\\";

        static string sLogFile_B = sOuput_Main + "\\CheckList_EU_B.xlsx";
        static string sLogFile_E = sOuput_Main + "\\CheckList_EU_E.xlsx";


        static int iLog_EU_B = 5;
        static int iLog_EU_E = 7;

        MyLog mLog_EU_B = new MyLog(iLog_EU_B, sLogFile_B, "Checklist");
        MyLog mLog_EU_E = new MyLog(iLog_EU_E, sLogFile_E, "Checklist");


        MyLog mLog_EU;
        int iLog_EU;
        string sOutput_EU;




        #region result Index

        WinWindow wWin;
        WinText wText;
        UITestControlCollection uiCollection;
        WinHyperlink wLink;

        string sUpLoadDataFileName = "DE_SmallData2009.xls";
        string sImportName = "DPTest_Import_";
        string sDerivationName = "DPTest_Derivation_";
        string sSnapshotName = "DPTest_Snapshot_";


        static int iGeneral_OpenStudio = 6;
        static int iGeneral_CloseAndReEnter = iGeneral_OpenStudio + 1;
        static int iGeneral_OnlineHelp = iGeneral_CloseAndReEnter + 1;

        static int iVal_RunER = iGeneral_OnlineHelp + 3;
        static int iVal_RunCompleteMsg = iVal_RunER + 1;
        static int iVal_ParamPrint = iVal_RunCompleteMsg + 1;
        static int iVal_Rpt_ValSum = iVal_ParamPrint + 2;
        static int iVal_Rpt_ValSum_DrillDown = iVal_Rpt_ValSum + 1;
        static int iVal_Rpt_DetailedResults = iVal_Rpt_ValSum_DrillDown + 1;
        static int iVal_Rpt_TCLO = iVal_Rpt_DetailedResults + 1;
        static int iVal_Rpt_IOE = iVal_Rpt_TCLO + 1;
        static int iVal_AddNewValNode = iVal_Rpt_IOE + 1;
        static int iVal_ConsumeSnapshot = iVal_AddNewValNode + 1;
        static int iVal_ParamPrint_FromNode = iVal_ConsumeSnapshot + 1;
        static int iVal_RunITC = iVal_ParamPrint_FromNode + 1;
        static int iVal_RunITC_TCLO = iVal_RunITC + 1;
        static int iVal_GolbeExportWithBreaks = iVal_RunITC_TCLO + 1;
        static int iVal_IndividualListing = iVal_GolbeExportWithBreaks + 1;
        static int iLaunchReportBuilder = iVal_IndividualListing + 1;
        static int iCustomRptTmpAndAccessible = iLaunchReportBuilder + 1;


        static int iData_Open = iCustomRptTmpAndAccessible + 3;
        static int iData_Upload = iData_Open + 1;
        static int iData_Import = iData_Upload + 1;
        static int iData_LV = iData_Upload + 1;
        static int iData_Derivation = iData_LV + 1;
        static int iData_Snapshot = iData_Derivation + 1;
        static int iBencalx = iData_Snapshot + 3;



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
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_CheckListEU()
        {
            


            #region Initialize - Create Test Ouput File/Dir
            
            _gLib._CreateDirectory(sOutput_EU, false);


            #endregion


            #region General



            ////////////////////////////////////////////////////   iGeneral_OnlineHelp

            dic.Clear();
            dic.Add("MenuItem_1", "Help");
            dic.Add("MenuItem_2", "Retirement Studio Help");
            dic.Add("MenuItem_3", "");
            pMain._MenuSelect(dic);

            _gLib._SetSyncUDWin("US", pMain.wRetirementStudioHelp.wTreeView.tree.tvUS, "Click", 0);
            _gLib._SetSyncUDWin("FAQs", pMain.wRetirementStudioHelp.wTreeView.tree.tvUS.tvFAQs, "Click", 0);
            _gLib._SetSyncUDWin("AccessRetirementStudioFAQ", pMain.wRetirementStudioHelp.wTreeView.tree.tvUS.tvFAQs.tvAccessRetirementStudioFAQ, "Click", 0);
            _gLib._SetSyncUDWin("Word - Close", pMain.wWord.wTitleBar.btnClose, "Click", 0);


            _gLib._SetSyncUDWin("TitleBar", pMain.wRetirementStudioHelp.wTitleBar, "Click", 0);
            _gLib._SetSyncUDWin("Close", pMain.wRetirementStudioHelp.wTitleBar.btnClose, "Click", 0);
            _gLib._KillProcessByName("WINWORD");


            mLog_EU.LogInfo(iGeneral_OnlineHelp, iLog_EU, Config.sTester);





            #endregion


            #region Valuation


            ////////////////////////////////////////////////////   iVal_RunER


            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "PensionValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Stichtag 2011 Final");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Stichtag 2011 Final");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            

            ////////////////////////////////////////////////////   iVal_ParamPrint_FromNode
            pMain._SelectTab("Stichtag 2011 Final");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Parameter Print");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Parameter Print Report");
            pOutputManager._WaitForLoading();
            _gLib._Exists("Parameter Print Report", pOutputManager.wRetirementStudio.wToolbar_btn.btnNextPage.btn, Config.iTimeout * 3, true);
            _gLib._Enabled("Parameter Print Report", pOutputManager.wRetirementStudio.wToolbar_btn.btnNextPage.btn, Config.iTimeout * 3, true);
            pMain._SelectTab("Parameter Print Report");
            pMain._Home_ToolbarClick_Top(false);

            mLog_EU.LogInfo(iVal_ParamPrint_FromNode, iLog_EU, Config.sTester);



            ////////////////////////////////////////////////////   iVal_RunER, iVal_RunCompleteMsg
            pMain._SelectTab("Stichtag 2011 Final");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("VerifyMsg", "True");
            pMain._PopVerify_GroupJobSuccessfullyComplete(dic);

            ////////////////_gLib._Wait(1);
            ////////////////dic.Clear();
            ////////////////dic.Add("PopVerify", "Pop");
            ////////////////dic.Add("OK", "Click");
            ////////////////pMain._PopVerify_GroupJobSuccessfullyComplete(dic);

            mLog_EU.LogInfo(iVal_RunER, iLog_EU, Config.sTester);
            mLog_EU.LogInfo(iVal_RunCompleteMsg, iLog_EU, Config.sTester);



            ////////////////////////////////////////////////////   iCloseAndReEnter
            pMain._SelectTab("Stichtag 2011 Final");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            _gLib._SetSyncUDWin("Close", pMain.wRetirementStudio.tbHome_TitleBar.btnClose, "Click", 0);


            _gLib._Cmd(Config.sStudioLaunchDir);
            pMain._SelectTab("Home");
            mLog_EU.LogInfo(iGeneral_OpenStudio, iLog_EU, Config.sTester);
            mLog_EU.LogInfo(iGeneral_CloseAndReEnter, iLog_EU, Config.sTester);




            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "PensionValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Stichtag 2011 Final");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Stichtag 2011 Final");

            _gLib._KillProcessByName("Mercer.RetirementStudio.Messaging.MessagingClientApp");
            _gLib._KillProcessByName("Mercer.RetirementStudio.Messaging.MessagingClientApp");




            ////////////////////////////////////////////////////   iVal_ParamPrint
            pMain._SelectTab("Stichtag 2011 Final");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            dic.Add("CheckOMSetupPopup", "");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");

            pOutputManager._ExportReport_Others(sOutput_EU, "Parameter Print", "RollForward", true, true);

            mLog_EU.LogInfo(iVal_ParamPrint, iLog_EU, Config.sTester);



            ////////////////////////////////////////////////////   iVal_Rpt_ValSum
            pMain._SelectTab("Output Manager");
            pOutputManager._ExportReport_Common(sOutput_EU, "Valuation Summary", "RollForward", true, true);
            mLog_EU.LogInfo(iVal_Rpt_ValSum, iLog_EU, Config.sTester);


            ////////////////////////////////////////////////////   iVal_Rpt_ValSum_DrillDown

            pOutputManager._Navigate(Config.eCountry, "Valuation Summary", "RollForward", true);
            pOutputManager._SelectTab("Valuation Summary");
            pOutputManager._WaitForLoading();
            _gLib._SetSyncUDWin("ZeroLiabilities", pOutputManager.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, 88, 120);
            pOutputManager._SelectTab("Valuation Summary");
            pOutputManager._WaitForLoading();
            _gLib._SetSyncUDWin("ZeroLiabilities", pOutputManager.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, 470, 768);
            pOutputManager._SelectTab("Valuation Summary");
            _gLib._SetSyncUDWin("None", pOutputManager.wRetirementStudio.wGroup_None.rdNone, "True", 0);
            _gLib._SetSyncUDWin("Process", pOutputManager.wRetirementStudio.wProcess.btnProcess, "Click", 0);
            pOutputManager._WaitForLoading();
            pOutputManager._SelectTab("Valuation Summary");
            _gLib._SetSyncUDWin("View", pOutputManager.wRetirementStudio.wView.btnView, "Click", 0);
            _gLib._SetSyncUDWin("Export", pOutputManager.wRetirementStudio.wExport.btnExport, "Click", 0);
            pOutputManager._SaveAs(sOutput_EU + "zValuationSummary_ZeroLiabilities_byNone.xls");
            _gLib._SetSyncUDWin("OK", pOutputManager.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
            _gLib._FileExists(sOutput_EU + "zValuationSummary_ZeroLiabilities_byNone.xlsx", Config.iTimeout, true);

            mLog_EU.LogInfo(iVal_Rpt_ValSum_DrillDown, iLog_EU, Config.sTester);






            ////////////////////////////////////////////////////   iVal_Rpt_DetailedResults
            pMain._SelectTab("Output Manager");
            pOutputManager._ExportReport_Common(sOutput_EU, "Liabilities Detailed Results", "RollForward", true, true);
            mLog_EU.LogInfo(iVal_Rpt_DetailedResults, iLog_EU, Config.sTester);


            ////////////////////////////////////////////////////   iVal_Rpt_TCLO
            pMain._SelectTab("Output Manager");
            pOutputManager._ExportReport_Others(sOutput_EU, "Test Cases", "RollForward", true, true);
            mLog_EU.LogInfo(iVal_Rpt_TCLO, iLog_EU, Config.sTester);


            ////////////////////////////////////////////////////   iVal_Rpt_IOE
            pMain._SelectTab("Output Manager");
            pOutputManager._ExportReport_Others(sOutput_EU, "IOE", "RollForward", false, true);
            mLog_EU.LogInfo(iVal_Rpt_IOE, iLog_EU, Config.sTester);


            ////////////////////////////////////////////////////   iVal_GolbeExportWithBreaks
            pMain._SelectTab("Output Manager");
            pOutputManager._Navigate(Config.eCountry, "Liability Set for Globe Export", "RollForward", true);
            pOutputManager._SelectTab("Liability Set for Globe Export");
            pOutputManager._WaitForLoading();
            _gLib._SetSyncUDWin("Liability Set for Globe Export - ALL", pOutputManager.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, 88, 120);  // qa
            /////////_gLib._SetSyncUDWin("Liability Set for Globe Export - ALL", pOutputManager.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, 65, 120);  // prod
            _gLib._SetSyncUDWin("View", pOutputManager.wRetirementStudio.wProcess.btnProcess, "Click", 0);
            pOutputManager._SelectTab("Liability Set for Globe Export");
            pOutputManager._WaitForLoading();
            pOutputManager._SelectTab("Liability Set for Globe Export");
            _gLib._Enabled("Toolbar", pOutputManager.wRetirementStudio.wToolbar, Config.iTimeout);

            for (int i = 0; i <= 10; i++)
            {
                try
                {
                    _gLib._SetSyncUDWin("Export Button", pOutputManager.wRetirementStudio.wToolbar.miExport, "Click", 0, false, 10, 10);
                    _gLib._SendKeysUDWin("Export Menu", pOutputManager.wRetirementStudio.wToolbar.miExport, "{Down}{Down}{Down}{Enter}");
                    if (_gLib._Exists("wReplaceExportedLiabSet", pOutputManager.wReplaceExportedLiabSet, Config.iTimeout / 10, false))
                        break;
                }
                catch (Exception ex)
                { }
            }

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("VerifyMsg", "True");
            pOutputManager._PopVerify_ReplaceExportedLiabilitySet(dic);

            mLog_EU.LogInfo(iVal_GolbeExportWithBreaks, iLog_EU, Config.sTester);

   

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            ////////////////////////////////////////////////////   iVal_AddNewValNode
            pMain._SelectTab("Stichtag 2011 Final");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "DeploymentTest");
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

            pMain._SelectTab("Stichtag 2011 Final");

            mLog_EU.LogInfo(iVal_AddNewValNode, iLog_EU, Config.sTester);


            ////////////////////////////////////////////////////   iVal_ConsumeSnapshot
            pMain._SelectTab("Stichtag 2011 Final");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
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
            dic.Add("SnapshotName", "Val2011");
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

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Stichtag 2011 Final");

            mLog_EU.LogInfo(iVal_ConsumeSnapshot, iLog_EU, Config.sTester);




            ////////////////////////////////////////////////////   iVal_RunITC, iVal_RunITC_TCLO
            pMain._SelectTab("Stichtag 2011 Final");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"11/27/1946\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

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

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewTestCaseInExcel", "Click");
            dic.Add("Close", "");
            pTestCaseLibrary._PopVerify_TestCaseViewer(dic);

            _gLib._Exists("Excel", pOutputManager.wExcel, Config.iTimeout * 3, true);

            _gLib._KillProcessByName("EXCEL");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewTestCaseInExcel", "");
            dic.Add("Close", "Click");
            pTestCaseLibrary._PopVerify_TestCaseViewer(dic);


            pMain._SelectTab("Test Case Library");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            mLog_EU.LogInfo(iVal_RunITC, iLog_EU, Config.sTester);
            mLog_EU.LogInfo(iVal_RunITC_TCLO, iLog_EU, Config.sTester);



            ////////////////////////////////////////////////////   iVal_IndividualListing
            pMain._SelectTab("Stichtag 2011 Final");
            
            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Actuarial Report");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pActuarialReport._SelectTab("Report Contents");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Copy", "click");
            dic.Add("CopyAStandLayout", "true");
            dic.Add("Template", "Direct promise default");
            dic.Add("OK", "click");
            pActuarialReport._ManageIndividualListingLayouts(dic);

            pActuarialReport._SelectTab("Report Contents");



            mLog_EU.LogInfo(iVal_IndividualListing, iLog_EU, Config.sTester);



            ////////////////////////////////////////////////////   iLaunchReportBuilder, iCustomRptTmpAndAccessible
            pActuarialReport._SelectTab("Report Contents");

            _gLib._SetSyncUDWin("wIndividualListingLayouts", pActuarialReport.wRetirementStudio.wRC_IndividualListingLayouts.listSpd, "Click", 0, false, 20, 15);
            _gLib._SetSyncUDWin("Edit", pActuarialReport.wRetirementStudio.wRC_Edit.btn, "Click", 0);

            _gLib._SetSyncUDWin("wReportBuilderDataSource - OK", pMain.wReportBuilderDataSource.wOK.btn, "Click", 0);
            _gLib._SetSyncUDWin("wIE - Allow", pMain.wIE.wAllow.btn, "Click", 0);

            _gLib._SetSyncUDWin("Report Builder Title", pMain.wSQLReportBuilder.wTitle.toolbar, "Click", 0);
            _gLib._SetSyncUDWin("Report Builder - Close", pMain.wSQLReportBuilder.wClose.btn, "Click", 0);


            pActuarialReport._SelectTab("Report Contents");
            _gLib._SetSyncUDWin("wIndividualListingLayouts", pActuarialReport.wRetirementStudio.wRC_IndividualListingLayouts.listSpd, "Click", 0, false, 20, 15);
            _gLib._SetSyncUDWin("Delete", pActuarialReport.wRetirementStudio.wRC_Delete.btn, "Click", 0);
            

            pActuarialReport._SelectTab("Report Contents");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);
                        

            mLog_EU.LogInfo(iLaunchReportBuilder, iLog_EU, Config.sTester);
            mLog_EU.LogInfo(iCustomRptTmpAndAccessible, iLog_EU, Config.sTester);


                                   





            ////////////////////////////////////////////////////   Delete the added test node

            pMain._SelectTab("Stichtag 2011 Final");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("iPosX", "");
            dic.Add("iPosY", "");
            dic.Add("MenuItem_1", "Delete Valuation Node");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_DeleteValuationNode(dic);


            pMain._SelectTab("Stichtag 2011 Final");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);






            #endregion


            #region Data

            ////////////////////////////////////////////////////   iData_Open


            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "ParticipantData");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Stichtag2011");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Stichtag2011");
            mLog_EU.LogInfo(iData_Open, iLog_EU, Config.sTester);


            //////////////////////////////////////////////////   iData_Upload

            dic.Clear();
            dic.Add("Level_1", "Stichtag2011");
            dic.Add("Level_2", "Upload Data");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("RepositoryFileName", "");
            dic.Add("Browse", "Click");
            dic.Add("Upload", "");
            pData._PopVerify_UploadData(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", sOuput_Main + "\\Templates\\" + sUpLoadDataFileName);
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);


            sUpLoadDataFileName = sUpLoadDataFileName.Replace(".xlsx", _gLib._ReturnDateStampYYYYMMDDHHMMSS() + ".xls");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("RepositoryFileName", sUpLoadDataFileName);
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);


            pMain._SelectTab("Stichtag2011");
            mLog_EU.LogInfo(iData_Upload, iLog_EU, Config.sTester);




            //////////////////////////////////////////////////   iData_Import

            dic.Clear();
            dic.Add("Level_1", "Stichtag2011");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            sImportName = sImportName + _gLib._ReturnDateStampYYYYMMDDHHMMSS();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", sImportName);
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", sUpLoadDataFileName);
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._SelectTab("Mapping");


            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "IsEligible_VOParent");

            pData._IP_Mapping_ClickEdit("USC", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            mLog_EU.LogInfo(iData_Import, iLog_EU, Config.sTester);



            //////////////////////////////////////////////////   iData_LV

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

            pData._SelectTab("Validate & Load");
            mLog_EU.LogInfo(iData_LV, iLog_EU, Config.sTester);


            //////////////////////////////////////////////////   iData_Derivation


            dic.Clear();
            dic.Add("Level_1", "Stichtag2011");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);

            sDerivationName = sDerivationName + _gLib._ReturnDateStampYYYYMMDDHHMMSS();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", sDerivationName);
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
            dic.Add("DerivedField", "Name");
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
            dic.Add("Formula", "=\"DPTest\"");
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

            pMain._SelectTab("Stichtag2011");


            mLog_EU.LogInfo(iData_Derivation, iLog_EU, Config.sTester);



            //////////////////////////////////////////////////   iData_Snapshot

            dic.Clear();
            dic.Add("Level_1", "Stichtag2011");
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            pData._TreeViewSelect_Snapshots(dic, true);


            sSnapshotName = sSnapshotName + _gLib._ReturnDateStampYYYYMMDDHHMMSS();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", sSnapshotName);
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            pMain._Home_ToolbarClick_Top(true);

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

            pData._ts_SP_CreateExtract(sOutput_EU + "Data2013_SnapshotExtract.xlsx");


            pMain._SelectTab("Stichtag2011");


            mLog_EU.LogInfo(iData_Snapshot, iLog_EU, Config.sTester);





            #endregion


            _gLib._MsgBox("Completed!", "Please undo the DPTest Steps and delete Import/Derivation/Snapshot start with DPTest_");
            _gLib._MsgBox("Warning!", "Please save & close data service and click OK to complete this testing.");
            _gLib._MsgBox("Have a nice day!", "Greeting from WEBBER!");

        }






        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            if (Config.sDataCenter == "Bedford")
            {
                Config.sClientName = Config.sClientName_B;
                Config.sPlanName = Config.sPlanName_B;
                mLog_EU = mLog_EU_B;
                iLog_EU = iLog_EU_B;
                sOutput_EU = sOutput_EU_B;

                if (!_gLib._FileExists(sLogFile_B, false))
                    _gLib._CopyFile(sTemplate, sLogFile_B);

            }
            else
            {
                Config.sClientName = Config.sClientName_E;
                Config.sPlanName = Config.sPlanName_E;
                mLog_EU = mLog_EU_E;
                iLog_EU = iLog_EU_E;
                sOutput_EU = sOutput_EU_E;

                if (!_gLib._FileExists(sLogFile_E, false))
                    _gLib._CopyFile(sTemplate, sLogFile_E);
            }

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
