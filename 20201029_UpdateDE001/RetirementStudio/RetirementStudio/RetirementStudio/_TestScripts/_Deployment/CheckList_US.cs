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
    public class CheckList_US
    {
        public CheckList_US()
        {
            ///////Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            Config.sClientName_F = "QA US Benchmark 008";
            Config.sPlanName_F = "QA US Benchmark 008 Plan";
            Config.sClientName_D = "QA US Benchmark 008 D";
            Config.sPlanName_D = "QA US Benchmark 008 D Plan";

            //Config.sClientName_F = "QA US Benchmark 008 Existing DNT";
            //Config.sPlanName_F = "QA US Benchmark 008 Existing DNT Plan";
            //Config.sClientName_D = "QA US Benchmark 008 Existing DNT";
            //Config.sPlanName_D = "QA US Benchmark 008 Existing DNT Plan";
            Config.sStudioLaunchDir = @"C:\Users\webber-ling\Desktop\USProd73\Client\RetirementStudio.exe";
            //Config.sDataCenter = "Franklin";
            Config.sDataCenter = "Dallas";
            Config.sTester = "WL";

        }



        static string sOuput_Main = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\000_DeploymentCheckList";
        static string sTemplate = sOuput_Main + "\\Templates\\Template_CheckList_US.xlsx";
        static string sOutput_US_F = sOuput_Main + "\\US_Franklin\\";
        static string sOutput_US_D = sOuput_Main + "\\US_Dallas\\";

        static string sLogFile_F = sOuput_Main + "\\CheckList_US_F.xlsx";
        static string sLogFile_D = sOuput_Main + "\\CheckList_US_D.xlsx";

        static int iLog_US_F = 5;
        static int iLog_US_D = 7;

        MyLog mLog_US_F = new MyLog(iLog_US_F, sLogFile_F, "Checklist");
        MyLog mLog_US_D = new MyLog(iLog_US_D, sLogFile_D, "Checklist");


        MyLog mLog_US;
        int iLog_US;
        string sOutput_US;




        #region result Index

        WinWindow wWin;
        WinText wText;
        UITestControlCollection uiCollection;
        WinHyperlink wLink;

        string sUpLoadDataFileName = "US_Data2013.xls";
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
        static int iVal_Rpt_GLSum_DrillDown = iVal_Rpt_ValSum_DrillDown + 1;
        static int iVal_Rpt_DetailedResults = iVal_Rpt_GLSum_DrillDown + 1;
        static int iVal_Rpt_TCLO = iVal_Rpt_DetailedResults + 1;
        static int iVal_Rpt_IOE = iVal_Rpt_TCLO + 1;
        static int iVal_AddNewValNode = iVal_Rpt_IOE + 1;
        static int iVal_ConsumeSnapshot = iVal_AddNewValNode + 1;
        static int iVal_ParamPrint_FromNode = iVal_ConsumeSnapshot + 1;
        static int iVal_RunITC = iVal_ParamPrint_FromNode + 1;
        static int iVal_RunITC_TCLO = iVal_RunITC + 1;
        static int iVal_FSMGlobe_Export = iVal_RunITC_TCLO + 1;
        static int iVal_FC = iVal_FSMGlobe_Export + 1;
        static int iVal_AR = iVal_FC + 1;

        static int iData_Open = iVal_AR + 3;
        static int iData_Upload = iData_Open + 1;
        static int iData_Import = iData_Upload + 1;
        static int iData_LV = iData_Import + 1;
        static int iData_Derivation = iData_LV + 1;
        static int iData_Snapshot = iData_Derivation + 1;
        static int iClickOnce = iData_Snapshot + 4;


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
        public void test_CheckList_US()
        {



            #region Initialize - Create Test Ouput File/Dir


            _gLib._CreateDirectory(sOutput_US, false);


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


            mLog_US.LogInfo(iGeneral_OnlineHelp, iLog_US, Config.sTester);





            #endregion


            #region Valuation


            ////////////////////////////////////////////////////   iVal_RunER


            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2012");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Valuation 2012");

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
            //////////dic.Add("GL_PPANAR_Min", "True");
            //////////dic.Add("GL_PPANAR_Max", "True");
            //////////dic.Add("GL_EAN", "");
            //////////dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            //////////dic.Add("PayoutProjection", "True");
            //////////dic.Add("IncludeIOE", "True");
            //////////dic.Add("GenerateParameterPrint", "True");
            //////////dic.Add("GenerateTestCaseOutput", "True");
            //////////dic.Add("IncludeGainLossResult", "");
            //////////dic.Add("Service", "VestingService");
            //////////dic.Add("Pay", "PayProjection1");
            //////////dic.Add("CurrentYear", "");
            //////////dic.Add("PriorYear", "True");
            //////////dic.Add("CashBanlance", "AccruedBenefit1");
            //////////dic.Add("Pension", "BenefitInPayment");
            //////////dic.Add("AllLiabilityTypes", "");
            //////////dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            //////////dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            //////////dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            //////////dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "True");
            //////////dic.Add("FAS35PresentValueOfAccumulatedBenefits", "True");
            //////////dic.Add("FAS35PresentValueOfVestedBenefits", "True");
            //////////dic.Add("PPAAtRiskLiabilityForMinimum", "");
            //////////dic.Add("PPAAtRiskLiabilityForMaximum", "");
            //////////dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            //////////dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            //////////dic.Add("EntryAgeNormal", "");
            //////////dic.Add("PayoutProjectionCustomGroup", "HourlyFlag");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);




            ////////////////////////////////////////////////////   iVal_FC
            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Funding Calculations");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_FundingCalculationRunCompleted(dic);



            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(sOutput_US, "Funding Calculator", "RollForward", false, true);

            mLog_US.LogInfo(iVal_FC, iLog_US, Config.sTester);





            ////////////////////////////////////////////////////   iVal_AR
            pMain._SelectTab("Valuation 2012");
            pMain._GenerateNewReport(sOutput_US, "PPA Funding Valuation Report", 3);
            _gLib._KillProcessByName("WINWORD");
            mLog_US.LogInfo(iVal_AR, iLog_US, Config.sTester);




            ////////////////////////////////////////////////////   iVal_ParamPrint_FromNode
            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
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

            mLog_US.LogInfo(iVal_ParamPrint_FromNode, iLog_US, Config.sTester);



            ////////////////////////////////////////////////////   iVal_RunER, iVal_RunCompleteMsg
            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
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

            _gLib._Wait(1);
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_GroupJobSuccessfullyComplete(dic);

            mLog_US.LogInfo(iVal_RunER, iLog_US, Config.sTester);
            mLog_US.LogInfo(iVal_RunCompleteMsg, iLog_US, Config.sTester);



            ////////////////////////////////////////////////////   iCloseAndReEnter
            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            _gLib._SetSyncUDWin("Close", pMain.wRetirementStudio.tbHome_TitleBar.btnClose, "Click", 0);
            _gLib._Cmd(Config.sStudioLaunchDir);
            pMain._SelectTab("Home");
            mLog_US.LogInfo(iGeneral_OpenStudio, iLog_US, Config.sTester);
            mLog_US.LogInfo(iGeneral_CloseAndReEnter, iLog_US, Config.sTester);




            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2012");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Valuation 2012");

            _gLib._KillProcessByName("Mercer.RetirementStudio.Messaging.MessagingClientApp");
            _gLib._KillProcessByName("Mercer.RetirementStudio.Messaging.MessagingClientApp");
            


            ////////////////////////////////////////////////////   iVal_ParamPrint
            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            dic.Add("CheckOMSetupPopup", "");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");

            pOutputManager._ExportReport_Others(sOutput_US, "Parameter Print", "RollForward", true, true);

            mLog_US.LogInfo(iVal_ParamPrint, iLog_US, Config.sTester);



            ////////////////////////////////////////////////////   iVal_Rpt_ValSum
            pMain._SelectTab("Output Manager");
            pOutputManager._ExportReport_Common(sOutput_US, "Valuation Summary", "RollForward", true, true);
            mLog_US.LogInfo(iVal_Rpt_ValSum, iLog_US, Config.sTester);


            ////////////////////////////////////////////////////   iVal_Rpt_ValSum_DrillDown

            pOutputManager._Navigate(Config.eCountry, "Valuation Summary", "Conversion", true);
            pOutputManager._SelectTab("Valuation Summary");
            pOutputManager._WaitForLoading();
            //////_gLib._SetSyncUDWin("ZeroLiabilities", pOutputManager.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, 278, 693); ////// QA
            _gLib._SetSyncUDWin("ZeroLiabilities", pOutputManager.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, 278, 680); ////// Prod
            pOutputManager._SelectTab("Valuation Summary");
            _gLib._SetSyncUDWin("None", pOutputManager.wRetirementStudio.wGroup_None.rdNone, "True", 0);
            _gLib._SetSyncUDWin("Process", pOutputManager.wRetirementStudio.wProcess.btnProcess, "Click", 0);
            pOutputManager._WaitForLoading();
            pOutputManager._SelectTab("Valuation Summary");
            _gLib._SetSyncUDWin("View", pOutputManager.wRetirementStudio.wView.btnView, "Click", 0);
            _gLib._SetSyncUDWin("Export", pOutputManager.wRetirementStudio.wExport.btnExport, "Click", 0);
            pOutputManager._SaveAs(sOutput_US + "zValuationSummary_ZeroLiabilities_byNone.xls");
            _gLib._SetSyncUDWin("OK", pOutputManager.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
            _gLib._FileExists(sOutput_US + "zValuationSummary_ZeroLiabilities_byNone.xlsx", Config.iTimeout, true);

            mLog_US.LogInfo(iVal_Rpt_ValSum_DrillDown, iLog_US, Config.sTester);


            ////////////////////////////////////////////////////   iVal_Rpt_GLSum_DrillDown
            pMain._SelectTab("Output Manager");
            pOutputManager._Navigate(Config.eCountry, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true);
            pOutputManager._SelectTab("Gain / Loss Summary of Liability Reconciliation");
            pOutputManager._WaitForLoading();
            wWin = new WinWindow(pOutputManager.wRetirementStudio);
            wWin.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.STATIC", PropertyExpressionOperator.Contains);
            UITestControlCollection uiCollection = wWin.FindMatchingControls();
            wText = new WinText((WinWindow)uiCollection[0]);
            wText.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);
            wLink = new WinHyperlink(wText);
            wLink.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);
            _gLib._SetSyncUDWin("PPA_NAR_Min", wLink, "Click", 0);
            pOutputManager._SelectTab("Gain / Loss Summary of Liability Reconciliation - PPA NAR Min");
            pOutputManager._WaitForLoading();
            _gLib._SetSyncUDWin("5,539", pOutputManager.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, 504, 331);
            _gLib._SetSyncUDWin("View", pOutputManager.wRetirementStudio.wView.btnView, "Click", 0);
            pOutputManager._SelectTab("Gain / Loss Summary of Liability Reconciliation - PPA NAR Min");
            mLog_US.LogInfo(iVal_Rpt_GLSum_DrillDown, iLog_US, Config.sTester);


            ////////////////////////////////////////////////////   iVal_Rpt_DetailedResults
            pMain._SelectTab("Output Manager");
            pOutputManager._ExportReport_Common(sOutput_US, "Detailed Results", "RollForward", true, true);
            mLog_US.LogInfo(iVal_Rpt_DetailedResults, iLog_US, Config.sTester);


            ////////////////////////////////////////////////////   iVal_Rpt_TCLO
            pMain._SelectTab("Output Manager");
            pOutputManager._ExportReport_Others(sOutput_US, "Test Cases", "RollForward", true, true);
            mLog_US.LogInfo(iVal_Rpt_TCLO, iLog_US, Config.sTester);


            ////////////////////////////////////////////////////   iVal_Rpt_IOE
            pMain._SelectTab("Output Manager");
            pOutputManager._ExportReport_Others(sOutput_US, "IOE", "RollForward", false, true);
            mLog_US.LogInfo(iVal_Rpt_IOE, iLog_US, Config.sTester);


            ////////////////////////////////////////////////////   iVal_FSMGlobe_Export
            pMain._SelectTab("Output Manager");
            pOutputManager._Navigate(Config.eCountry, "Liability Set for FSM Export", "RollForward", true);
            pOutputManager._SelectTab("Liability Set for FSM Export");
            _gLib._SetSyncUDWin("View", pOutputManager.wRetirementStudio.wProcess.btnProcess, "Click", 0);
            pOutputManager._SelectTab("Liability Set for FSM Export");
            pOutputManager._WaitForLoading();
            pOutputManager._SelectTab("Liability Set for FSM Export");
            _gLib._Enabled("Toolbar", pOutputManager.wRetirementStudio.wToolbar, Config.iTimeout);

            for (int i = 0; i <= 10; i++)
            {
                try
                {
                    _gLib._SetSyncUDWin("Export Button", pOutputManager.wRetirementStudio.wToolbar.miExport, "Click", 0, false, 10, 10);
                    //_gLib._SendKeysUDWin("Export Menu", pOutputManager.wRetirementStudio.wToolbar.miExport, "{Down}{Down}{Down}{Enter}"); //// QA
                    _gLib._SendKeysUDWin("Export Menu", pOutputManager.wRetirementStudio.wToolbar.miExport, "{Down}{Enter}"); //// Prod
                    if (_gLib._Exists("wReplaceExportedLiabSet", pOutputManager.wReplaceExportedLiabSet, Config.iTimeout / 10, false))
                        break;
                }
                catch (Exception ex)
                {}
            }

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("VerifyMsg", "True");
            pOutputManager._PopVerify_ReplaceExportedLiabilitySet(dic);

            mLog_US.LogInfo(iVal_FSMGlobe_Export, iLog_US, Config.sTester);

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            ////////////////////////////////////////////////////   iVal_AddNewValNode
            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
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

            pMain._SelectTab("Valuation 2012");

            mLog_US.LogInfo(iVal_AddNewValNode, iLog_US, Config.sTester);


            ////////////////////////////////////////////////////   iVal_ConsumeSnapshot
            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
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
            dic.Add("SnapshotName", "Valuation Data");
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

            pMain._SelectTab("Valuation 2012");

            mLog_US.LogInfo(iVal_ConsumeSnapshot, iLog_US, Config.sTester);




            ////////////////////////////////////////////////////   iVal_RunITC, iVal_RunITC_TCLO
            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            dic.Add("MenuItem_2", "");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"1/7/1987\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunSelectedTestLife", "Click");
            pTestCaseLibrary._PopVerify_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PPA_NAR_Min", "True");
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

            mLog_US.LogInfo(iVal_RunITC, iLog_US, Config.sTester);
            mLog_US.LogInfo(iVal_RunITC_TCLO, iLog_US, Config.sTester);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
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


            pMain._SelectTab("Valuation 2012");
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
            dic.Add("ServiceToOpen", "Data 2013");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Data 2013");
            mLog_US.LogInfo(iData_Open, iLog_US, Config.sTester);


            ////////////////////////////////////////////////////   iData_Upload
            
            dic.Clear();
            dic.Add("Level_1", "Data 2013");
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


            pMain._SelectTab("Data 2013");
            mLog_US.LogInfo(iData_Upload, iLog_US, Config.sTester);




            ////////////////////////////////////////////////////   iData_Import
            
            dic.Clear();
            dic.Add("Level_1", "Data 2013");
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

            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "EmployeeIDNumber");

            pData._IP_Mapping_ClickEdit("USC", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            mLog_US.LogInfo(iData_Import, iLog_US, Config.sTester);



            ////////////////////////////////////////////////////   iData_LV

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
            mLog_US.LogInfo(iData_LV, iLog_US, Config.sTester);


            ////////////////////////////////////////////////////   iData_Derivation


            dic.Clear();
            dic.Add("Level_1", "Data 2013");
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

            pMain._SelectTab("Data 2013");


            mLog_US.LogInfo(iData_Derivation, iLog_US, Config.sTester);



            ////////////////////////////////////////////////////   iData_Snapshot
            
            dic.Clear();
            dic.Add("Level_1", "Data 2013");
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

            pData._ts_SP_CreateExtract(sOutput_US + "Data2013_SnapshotExtract.xlsx");


            pMain._SelectTab("Data 2013");


            mLog_US.LogInfo(iData_Snapshot, iLog_US, Config.sTester);


            
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
            if (Config.sDataCenter == "Franklin")
            {
                Config.sClientName = Config.sClientName_F;
                Config.sPlanName = Config.sPlanName_F;
                mLog_US = mLog_US_F;
                iLog_US = iLog_US_F;
                sOutput_US = sOutput_US_F;

                if (!_gLib._FileExists(sLogFile_F, false))
                    _gLib._CopyFile(sTemplate, sLogFile_F);
            }
            else
            {
                Config.sClientName = Config.sClientName_D;
                Config.sPlanName = Config.sPlanName_D;
                mLog_US = mLog_US_D;
                iLog_US = iLog_US_D;
                sOutput_US = sOutput_US_D;

                if (!_gLib._FileExists(sLogFile_D, false))
                    _gLib._CopyFile(sTemplate, sLogFile_D);
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
