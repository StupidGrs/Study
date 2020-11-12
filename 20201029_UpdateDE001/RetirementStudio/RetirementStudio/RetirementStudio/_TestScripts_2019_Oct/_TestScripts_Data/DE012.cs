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
using System.Threading;

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



// CA Screens
using RetirementStudio._UIMaps.DefinedBenefitLimitIncreaseClasses;


// DE Screens
using RetirementStudio._UIMaps.AssumedRetirementAgeClasses;
using RetirementStudio._UIMaps.ContractualRetirementAgeClasses;
using RetirementStudio._UIMaps.JubileeBenefitClasses;
using RetirementStudio._UIMaps.PlanDefinition_DEClasses;





namespace RetirementStudio._TestScripts_2019_Oct_Data
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class DE012
    {
        public DE012()
        {

            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.DE;
            Config.sClientName = "QA DE Benchmark 012 Create New_20190830_F";
            Config.sPlanName = "QA DE Benchmark 012 Create New Plan";
            Config.sDataCenter = "Franklin";
            //Config.sDataCenter = "Dallas";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;

            
        }


        #region Report Output Directory

        string sOutput_Data2012 = "";
        string sOutput_Data2013 = "";

        string sOutput_Data2012_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_012\20150401_QA1_CUIT_Baseline\2012\";
        string sOutput_Data2013_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_012\20150401_QA1_CUIT_Baseline\2013\";
        string sMsgInfo = "";


        List<string> allSheets = new List<string> {"DataOutputManager", "CurrentView", "Uploads", "ImportSummary", "ImportMapping1", "Import1Trans1", "ImportPreMatching1", 
            "ImportPre1Field1", "ImportPre1Field2", "ImportPre1Field3", "ImportMatching1", "ImportMapping2", "ImportPreMatching2", "ImportPre2Field1", "ImportMatching2", 
            "SimpleImportSummary", "FilterSummary", "CustomFilter1", "CustomFilter2", "CustomFilter3", "DerivationsSummary", "DerivGr1", "DerivGr1Field1", "DerivGr2", 
            "DerivGr2Field1", "DerivGr2Field2", "DerivGr2Field3", "DerivGr3", "DerivGr3Field1", "DerivGr3Field2", "DerivGr3Field3", "DerivGr4", "DerivGr4Field1", 
            "DerivGr4Field2", "DerivGr4Field3", "DerivGr5", "DerivGr5Field1", "DerivGr5Field2", "DerivGr5Field3", "DerivGr6", "DerivGr6Field1", "DerivGr6Field2", 
            "DerivGr6Field3", "SnapshotSummary", "Snapshot1", "ActivityLog"}; ////// 46 sheets in consolidated report





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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_012\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    _gLib._CreateDirectory(sMainDir + sPostFix + "\\");
                    sOutput_Data2012 = _gLib._CreateDirectory(sMainDir + sPostFix + "\\2012\\");
                    sOutput_Data2013 = _gLib._CreateDirectory(sMainDir + sPostFix + "\\2013\\");
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

                string sMainDir = sDir + "DE012_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutput_Data2012 = _gLib._CreateDirectory(sMainDir + "\\2012\\");
                sOutput_Data2013 = _gLib._CreateDirectory(sMainDir + "\\2013\\");


            }

            string sContent = "";
            sContent = sContent + "sOutput_Data2012 = @\"" + sOutput_Data2012 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutput_Data2013 = @\"" + sOutput_Data2013 + "\";" + Environment.NewLine;
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



        #endregion


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_DE012()
        {


            #region MultiThreads


            Thread thrd_Data2012 = new Thread(() => new DE012().t_CompareRpt_Data2012(sOutput_Data2012));
            Thread thrd_Data2012_Val = new Thread(() => new DE012().t_CompareRpt_Data2012_Val(sOutput_Data2012));
            Thread thrd_Data2013 = new Thread(() => new DE012().t_CompareRpt_Data2013(sOutput_Data2013));


            #endregion




            this.GenerateReportOuputDir();


            #region Create Client & Add Data2012


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
            dic.Add("ClientCode", "kjldedatab");
            dic.Add("FiscalYearEnd", "12/31");
            dic.Add("MeasurementDate", "09/30");
            dic.Add("Notes", "Client Owner: Karen. Original client: Original Client: KJL - DE Data BM");
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


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            pMain._HomeTreeViewSelect(0, dic);

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
            dic.Add("EnterVOShortName", "Jub1");
            dic.Add("ConfirmVOShortName", "Jub1");
            dic.Add("VOLongName", "Jubilee 1");
            dic.Add("VOClass", "Jubilee");
            dic.Add("FundingVehicle", "Direct Promise");
            dic.Add("TypeOfPromise", "Defined Benefit");
            dic.Add("Sponsor", "Employer");
            dic.Add("PSVCoverage", "True");
            dic.Add("ExculdeWidowers", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccounting", "True");
            dic.Add("Apply30g", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CreateNewVO(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("AddVOtoRegistry", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EnterVOShortName", "Jub2");
            dic.Add("ConfirmVOShortName", "Jub2");
            dic.Add("VOLongName", "Jubilee 2");
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

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("AddVOtoRegistry", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EnterVOShortName", "Jub3");
            dic.Add("ConfirmVOShortName", "Jub3");
            dic.Add("VOLongName", "Jubilee 3");
            dic.Add("VOClass", "Jubilee");
            dic.Add("FundingVehicle", "Direct Promise");
            dic.Add("TypeOfPromise", "Defined Benefit");
            dic.Add("Sponsor", "Employer");
            dic.Add("PSVCoverage", "False");
            dic.Add("ExculdeWidowers", "False");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccounting", "True");
            dic.Add("Apply30g", "False");
            dic.Add("OK", "Click");
            pMain._PopVerify_CreateNewVO(dic);


            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
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
            dic.Add("Name", "Data2012");
            dic.Add("EffectiveDate", "31.12.2012");
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
            dic.Add("ServiceToOpen", "Data2012");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            #endregion


            #region Data2012 - CurrentView

            pData._ts_UpdateIncludedVOs("Jub1", true);
            pData._ts_UpdateIncludedVOs("Jub2", true);
            pData._ts_UpdateIncludedVOs("Jub3", true);

            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "JBen01");
            dic.Add("DisplayName", "JBen01");
            dic.Add("VariesbyVO", "True");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, false);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "JBen02");
            dic.Add("DisplayName", "JBen02");
            dic.Add("VariesbyVO", "True");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "JubServDate");
            dic.Add("DisplayName", "JubServDate");
            dic.Add("VariesbyVO", "");
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
            dic.Add("Category", "DB Information");
            dic.Add("Label", "JubiCode");
            dic.Add("DisplayName", "JubiCode");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Integer");
            dic.Add("FieldLength", "5");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "JubiFlag");
            dic.Add("DisplayName", "JubiFlag");
            dic.Add("VariesbyVO", "");
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


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "JubiEligDate");
            dic.Add("DisplayName", "JubiEligDate");
            dic.Add("VariesbyVO", "");
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

            pData._CV_Initialize("Personal Information", "DB Information", 1, 2, "MembershipDate1");

            pData._CV_ExpandPersonalInformation();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Service");
            dic.Add("Label", "JubiService");
            dic.Add("DisplayName", "JubiService");
            dic.Add("VariesbyVO", "True");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "7");
            dic.Add("DecimalPlaces", "4");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Service");
            dic.Add("Label", "EligService");
            dic.Add("DisplayName", "EligService");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "7");
            dic.Add("DecimalPlaces", "4");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Pay");
            dic.Add("Label", "Bonus");
            dic.Add("DisplayName", "Bonus");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Pay");
            dic.Add("Label", "JubiPay");
            dic.Add("DisplayName", "JubiPay");
            dic.Add("VariesbyVO", "True");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Pay");
            dic.Add("Label", "Pay1");
            dic.Add("DisplayName", "Pay1");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);



            //////////////////_gLib._MsgBox("", "Please expand label  DB Information  and click OK to keep testing");
            _gLib._MsgBox("", "Please expand label  Pay -> Pay1  and click OK to keep testing");

            pMain._Home_ToolbarClick_Top(true);

            pData._CV_ClickEdit("Pay1", true);

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

            pData._CV_ClickEdit("Pay1", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Label", "");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "False");
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

            pData._CV_ClickEdit("JubiEligDate", true);

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

            pData._CV_ClickEdit("JubiEligDate_VOParent", true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Label", "");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "False");
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


            #endregion


            #region Data2012 - Upload Data & Import - Get Data

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

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE012\JubiData2012.xls");
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
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE012\PayBonus2012.xlsx");
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


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);


            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Get Data");
            dic.Add("FileType", "Excel file");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "JubiData2012.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("SingleTabPerRecordFile_cbo", "");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_SelectFile(dic);


            pData._SelectTab("Mapping");



            pData._IP_Mapping_Initialize("Personal Information", "DB Information", 1, 0, 1, "MembershipDate1");
            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "IsEligible_VOParent");

            pData._IP_Mapping_ClickEdit("USC", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(6, 1, "2");
            pData._IP_Mapping_Transformation(6, 2, "10");

            pData._IP_Mapping_Transformation(7, 1, "8");
            pData._IP_Mapping_Transformation(7, 2, "15");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_MapField("MembershipDate1", "EMEMB", 0, true, 16);
            pData._IP_Mapping_MapField("AssumedRetirementAge", "ARETAGE", 0, true, 0);
            pData._IP_Mapping_MapField("ContractualRetAge", "CRETAGE", 0, true, 0);
            pData._IP_Mapping_MapField("PensionableServiceDate", "ECOUNT", 0, true, 24);
            pData._IP_Mapping_MapField("PensionPromiseDate", "PENPROM", 0, true, 0);
            pData._IP_Mapping_MapField("WaitingPeriodStartDate", "EWAIT", 0, true, 14);
            pData._IP_Mapping_MapField("JubServDate", "JSERV", 0, true, 3);
            pData._IP_Mapping_MapField("JubiCode", "KZFIRMA", 0, true, 0);


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
            dic.Add("DerivedField", "JubiFlag");
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
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "JubiCode");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(JubiCode=40710,1,2)");
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
            dic.Add("DerivedField", "IsEligible_Jub1");
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
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "JubiFlag");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(JubiFlag=1,1,0)");
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
            dic.Add("DerivedField", "IsEligible_Jub2");
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
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "JubiFlag");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(JubiFlag=2,1,0)");
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

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "100");
            dic.Add("Unique_UniqueMatch_Num", "0");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "0");
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
            dic.Add("PopVerify", "Verify");
            dic.Add("Matched_Num", "0");
            dic.Add("New_Num", "100");
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





            #endregion


            #region Data2012 - Import - Get Pay and Bonus


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);


            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Get Pay and Bonus");
            dic.Add("FileType", "Excel file");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "PayBonus2012.xlsx");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("SingleTabPerRecordFile_cbo", "");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_SelectFile(dic);


            pData._SelectTab("Mapping");





            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "IsEligible_VOParent");
            pData._IP_Mapping_Initialize("Personal Information", "Pay", 2, 1, 1, "Bonus");
            pData._IP_Mapping_Initialize("Personal Information", "Pay1", 3, 1, 1, "Pay1CurrentYear_VOParent");
            pData._IP_Mapping_Initialize("Personal Information", "Pay1CurrentYear_VOParent", 4, 1, 1, "Pay1CurrentYear");
            pData._IP_Mapping_Initialize("Personal Information", "Bonus", 3, 1, 1, "BonusCurrentYear");


            pData._IP_Mapping_MapField("BonusCurrentYear", "BONUS", 0, true, 0);
            pData._IP_Mapping_MapField("Pay1CurrentYear", "NETPAY", 0, true, 3);


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
            dic.Add("DerivedField", "IsEligible_Jub3");
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
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Bonus");
            dic.Add("Level_5", "BonusCurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(BonusCurrentYear>0,1,0)");
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

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "0");
            dic.Add("Unique_UniqueMatch_Num", "100");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "0");
            dic.Add("Duplicate_UniqueMatch_Num", "0");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
            dic.Add("Warehouse_NoMatch_Num", "0");
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
            dic.Add("PopVerify", "Verify");
            dic.Add("Matched_Num", "100");
            dic.Add("New_Num", "0");
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





            #endregion


            #region Data2012 - Filters


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Filters");
            pData._TreeViewSelect(dic);

            pData._FL_Grid("Custom", 30, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "JubVO1");
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
            dic.Add("Level_3", "IsEligible_VOParent");
            dic.Add("Level_4", "IsEligible_Jub1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IsEligible_Jub1_C=1");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            pData._FL_Grid("Custom", 13, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "JubVO2");
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
            dic.Add("Level_3", "IsEligible_VOParent");
            dic.Add("Level_4", "IsEligible_Jub2");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IsEligible_Jub2_C=1");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);





            pData._FL_Grid("Custom", 13, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "JubVO3");
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
            dic.Add("Level_3", "IsEligible_VOParent");
            dic.Add("Level_4", "IsEligible_Jub3");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IsEligible_Jub3_C=1");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region Data2012 - Derivation Groups - Set Jubilee Pay


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "Set Jubilee Pay");
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
            dic.Add("DerivedField", "JubiPayCurrentYear_Jub1");
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
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Pay1");
            dic.Add("Level_5", "Pay1CurrentYear_VOParent");
            dic.Add("Level_6", "Pay1CurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=Pay1CurrentYear_C");
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
            dic.Add("DerivedField", "JubiPayCurrentYear_Jub2");
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
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Pay1");
            dic.Add("Level_5", "Pay1CurrentYear_VOParent");
            dic.Add("Level_6", "Pay1CurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=Pay1CurrentYear_C");
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
            dic.Add("DerivedField", "JubiPayCurrentYear_Jub3");
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
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Bonus");
            dic.Add("Level_5", "BonusCurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Pay1");
            dic.Add("Level_5", "Pay1CurrentYear_VOParent");
            dic.Add("Level_6", "Pay1CurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=Pay1CurrentYear_C+BonusCurrentYear_C");
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
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);


            #endregion

            #region Data2012 - Derivation Groups - Set Jubilee Benefit 1

            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "Set Jubilee Benefit 1");
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
            dic.Add("DerivedField", "JBen01_Jub1");
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
            dic.Add("Level_4", "JubiPay");
            dic.Add("Level_5", "JubiPayCurrentYear_VOParent");
            dic.Add("Level_6", "JubiPayCurrentYear_Jub1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "JubVO1");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(JubiPayCurrentYear_Jub1_C*0.01,2)");
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
            dic.Add("DerivedField", "JBen01_Jub2");
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
            dic.Add("Level_4", "JubiPay");
            dic.Add("Level_5", "JubiPayCurrentYear_VOParent");
            dic.Add("Level_6", "JubiPayCurrentYear_Jub2");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "JubVO2");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(JubiPayCurrentYear_Jub2_C*0.02,2)");
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
            dic.Add("DerivedField", "JBen01_Jub3");
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
            dic.Add("Level_4", "JubiPay");
            dic.Add("Level_5", "JubiPayCurrentYear_VOParent");
            dic.Add("Level_6", "JubiPayCurrentYear_Jub3");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "JubVO3");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(JubiPayCurrentYear_Jub3_C*0.03,2)");
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
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);



            #endregion

            #region Data2012 - Derivation Groups - Set Jubilee Benefit 2

            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Import Derivations from ...");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", Config.sClientName);
            dic.Add("Plan", Config.sPlanName);
            dic.Add("Service", "Data2012");
            dic.Add("OK", "");
            pData._PopVerify_DG_CopyDerivations(dic);

            dic.Clear();
            dic.Add("Level_1", "All");
            dic.Add("Level_2", "Set Jubilee Benefit 1");
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
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "Set Jubilee Benefit 2");
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
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "JBen02_Jub1");
            dic.Add("DerivedField_SearchFromIndex", "5");
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
            dic.Add("Formula", "=ROUND(JubiPayCurrentYear_Jub1_C*0.05,2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "JBen02_Jub2");
            dic.Add("DerivedField_SearchFromIndex", "6");
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
            dic.Add("Formula", "=ROUND(JubiPayCurrentYear_Jub2_C*0.06,2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "JBen02_Jub3");
            dic.Add("DerivedField_SearchFromIndex", "7");
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
            dic.Add("Formula", "=ROUND(JubiPayCurrentYear_Jub3_C*0.08,2)");
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


            #endregion

            #region Data2012 - Derivation Groups - Calculate Jubilee Service


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "Calculate Jubilee Service");
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
            dic.Add("DerivedField", "JubiService_Jub1");
            dic.Add("DerivedField_SearchFromIndex", "20");
            dic.Add("Type", "Service");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "JubVO1");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

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
            dic.Add("sData", "JubServDate_C");
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
            dic.Add("sData", "EffectiveDate_C");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "10");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Rounding Rule");
            dic.Add("sData", "Completed Months");
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
            dic.Add("DerivedField", "JubiService_Jub2");
            dic.Add("DerivedField_SearchFromIndex", "21");
            dic.Add("Type", "Service");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "JubVO2");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

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
            dic.Add("sData", "JubServDate_C");
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
            dic.Add("sData", "EffectiveDate_C");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "10");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Rounding Rule");
            dic.Add("sData", "Nearest Months");
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
            dic.Add("DerivedField", "JubiService_Jub3");
            dic.Add("DerivedField_SearchFromIndex", "22");
            dic.Add("Type", "Service");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "JubVO3");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

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
            dic.Add("sData", "JubServDate_C");
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
            dic.Add("sData", "EffectiveDate_C");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "10");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Rounding Rule");
            dic.Add("sData", "Nearest Years");
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


            #endregion

            #region Data2012 - Derivation Groups - Set Jubilee Eligibility Date


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "Set Jubilee Eligibility Date");
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
            dic.Add("DerivedField", "EligService");
            dic.Add("DerivedField_SearchFromIndex", "20");
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
            dic.Add("sData", "JubServDate_C");
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
            dic.Add("DerivedField", "JubiEligDate");
            dic.Add("DerivedField_SearchFromIndex", "10");
            dic.Add("Type", "Date");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service - Months");
            dic.Add("sData", "6");
            pData._DG_DerivationDefinition_Grid_Date(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "25");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service Rounding");
            dic.Add("sData", "First of Month Following or Coincident with");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "27");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Accrued Service Based On");
            dic.Add("sData", "Years");
            pData._DG_DerivationDefinition_Grid_Date(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "28");
            dic.Add("iCol", "2");
            dic.Add("sLabel", "Service Field");
            dic.Add("sData", "EligService_C");
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
            dic.Add("DerivedField", "JubiEligDate");
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
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "JubiEligDate_VOParent");
            dic.Add("Level_4", "JubiEligDate");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(YEAR(JubiEligDate_C)<1980, \"01.01.1981\", JubiEligDate_C)");
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
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);


            #endregion

            #region Data2012 - Snapshots


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Valuation Data");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

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
            dic.Add("Level_3", "Service");
            dic.Add("Level_4", "JubiService_VOParent");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "JubiPay");
            dic.Add("Level_5", "JubiPayCurrentYear_VOParent");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Pay1");
            dic.Add("Level_5", "Pay1CurrentYear_VOParent");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "MembershipDate1");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "AssumedRetirementAge");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "ContractualRetAge");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "JubiEligDate_VOParent");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "JBen01_VOParent");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "JBen02_VOParent");
            pData._TreeViewSelect_Snapshots(dic, true);


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

            pData._ts_SP_CreateExtract(sOutput_Data2012 + "Data2012_SnapshotExtract.xlsx");



            pMain._Home_ToolbarClick_Top(true);



            #endregion

            #region Data2012 - Output Manager


            dic.Clear();
            dic.Add("Level_1", "Data2012");
            dic.Add("Level_2", "Output Manager");
            pData._TreeViewSelect(dic);

            pMain._SelectTab("Data Output Manager");

            if (Config.bDownloadReports_PDF)
            {
                pData._OM_ExportReport_Common(sOutput_Data2012, "Current View", true);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Import Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Filter Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Derivations Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Snapshot Summary", true);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Derivations Summary", "Data2012_DerivationSummary_SetJubileePay", 130, 1, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Derivations Summary", "Data2012_DerivationSummary_SetJubileeBenefit1", 130, 2, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Derivations Summary", "Data2012_DerivationSummary_SetJubileeBenefit2", 130, 3, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Derivations Summary", "Data2012_DerivationSummary_CalculateJubileeService", 130, 4, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Derivations Summary", "Data2012_DerivationSummary_SetJubileeEligibilityDate", 130, 5, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Import Summary", "Data2012_ImportSummary", 130, 1, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pData._OM_ExportReport_Common(sOutput_Data2012, "Current View", false);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Import Summary", false);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Filter Summary", false, true);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Derivations Summary", false);
                pData._OM_ExportReport_Common(sOutput_Data2012, "Snapshot Summary", false);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Derivations Summary", "Data2012_DerivationSummary_SetJubileePay", 130, 1, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Derivations Summary", "Data2012_DerivationSummary_SetJubileeBenefit1", 130, 2, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Derivations Summary", "Data2012_DerivationSummary_SetJubileeBenefit2", 130, 3, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Derivations Summary", "Data2012_DerivationSummary_CalculateJubileeService", 130, 4, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Derivations Summary", "Data2012_DerivationSummary_SetJubileeEligibilityDate", 130, 5, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2012, "Import Summary", "Data2012_ImportSummary", 130, 1, false);

            }

            thrd_Data2012.Start();



            pMain._SelectTab("Data Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Data2012");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion




            #region Data2013 - Import - Get Data

            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Data2013");
            dic.Add("EffectiveDate", "31.12.2013");
            dic.Add("Parent", "Data2012");
            dic.Add("RSC", "");
            dic.Add("Shared", "");
            dic.Add("GeneralUse", "True");
            dic.Add("Conversion", "");
            dic.Add("CopyDataService", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_DataServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Data2013");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("Level_1", "Data2013");
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
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE012\JubiData2013.xls");
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
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE012\BonusData2013.xls");
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


            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Get Data");
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
            dic.Add("FileName", "JubiData2013.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._SelectTab("Mapping");



            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "IsEligible_VOParent");
            pData._IP_Mapping_Initialize("Personal Information", "Pay", 2, 1, 1, "Bonus");
            pData._IP_Mapping_Initialize("Personal Information", "Pay1", 3, 6, 1, "Pay1CurrentYear_VOParent");
            pData._IP_Mapping_Initialize("Personal Information", "Pay1CurrentYear_VOParent", 4, 6, 1, "Pay1CurrentYear");

            pData._IP_Mapping_ClickEdit("USC", false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(8, 1, "12");
            pData._IP_Mapping_Transformation(8, 2, "95");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_MapField("Pay1CurrentYear", "NETPAY", 0, true, 13);


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
            dic.Add("IgnoreGoneRecordsForMatching", "False");
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
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "5");
            dic.Add("Unique_UniqueMatch_Num", "100");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "0");
            dic.Add("Duplicate_UniqueMatch_Num", "0");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
            dic.Add("Warehouse_NoMatch_Num", "0");
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
            dic.Add("Matched_Num", "100");
            dic.Add("New_Num", "5");
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
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);



            #endregion

            #region Data2013 - Simple Import

            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Simple Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Get Bonus Data");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "BonusData2013.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            dic.Add("Process", "Click");
            pData._PopVerify_SimpleImport(dic);




            #endregion

            #region Data2013 - Derivation Groups

            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "Set IsEligible_Jub3");
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
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Set IsEligible_Jub3");
            dic.Add("MenuItem", "Move Up");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Set IsEligible_Jub3");
            dic.Add("MenuItem", "Move Up");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Set IsEligible_Jub3");
            dic.Add("MenuItem", "Move Up");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Set IsEligible_Jub3");
            dic.Add("MenuItem", "Move Up");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Set IsEligible_Jub3");
            dic.Add("MenuItem", "Move Up");
            pData._TreeViewRightSelect(dic);


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
            dic.Add("DerivedField", "IsEligible_Jub3");
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
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Bonus");
            dic.Add("Level_5", "BonusCurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(BonusCurrentYear_C>0,1,0)");
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




            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Set Jubilee Pay");
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
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Set Jubilee Benefit 1");
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
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Set Jubilee Benefit 2");
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
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Calculate Jubilee Service");
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
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Set Jubilee Eligibility Date");
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




            #endregion

            #region Data2013 - Snapshots

            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "Valuation Data");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("Filter", "Active Member");
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

            pData._ts_SP_CreateExtract(sOutput_Data2013 + "Data2013_SnapshotExtract.xlsx");

            pMain._Home_ToolbarClick_Top(true);


            #endregion

            #region Data2013 - Output Manager


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Data2013");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("Level_1", "Data2013");
            dic.Add("Level_2", "Output Manager");
            pData._TreeViewSelect(dic);

            pMain._SelectTab("Data Output Manager");

            _gLib._SetSyncUDWin("", pData.wRetirementStudio.wOM_ExportAll.btn, "Click", 0);

            pData.pOutputManager._SaveAs(sOutput_Data2013 + "GenerateConsolidatedOuput.xls");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_Complete_Popup(dic);

            _gLib._Cmd(sOutput_Data2013 + "GenerateConsolidatedOuput.xls");
            _gLib._SendKeysUDWin("Excel", pOutputManager.wExcel, "s", 0, ModifierKeys.Control, false);

            while (_gLib._Exists("Excel Compatiblity Check", pMain.wMicrosoftExcelCompatibility, 60))
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("CheckCompatibility", "False");
                dic.Add("Coninue", "Click");
                pMain._PopVerify_MicrosoftExcelCompatibility(dic);
                break;
            }
            _gLib._Wait(3);
            _gLib._SendKeysUDWin("Excel", pOutputManager.wExcel, "{F4}", 0, ModifierKeys.Alt, false);
            _gLib._Wait(3);
            _gLib._KillProcessByName("EXCEL");


            if (Config.bDownloadReports_PDF)
            {
                pData._OM_ExportReport_Common(sOutput_Data2013, "Prior View", true);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Current View", true);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Import Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Simple Import Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Filter Summary", true, true);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Derivations Summary", true);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Snapshot Summary", true);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_SetIsEligible_Jub3", 130, 1, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_SetJubileePay", 130, 2, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_SetJubileeBenefit1", 130, 3, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_SetJubileeBenefit2", 130, 4, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_CalculateJubileeService", 130, 5, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_SetJubileeEligibilityDate", 130, 6, true);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Import Summary", "Data2013_ImportSummary", 130, 1, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pData._OM_ExportReport_Common(sOutput_Data2013, "Prior View", false);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Current View", false);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Import Summary", false);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Simple Import Summary", false);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Filter Summary", false);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Derivations Summary", false);
                pData._OM_ExportReport_Common(sOutput_Data2013, "Snapshot Summary", false);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_SetIsEligible_Jub3", 130, 1, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_SetJubileePay", 130, 2, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_SetJubileeBenefit1", 130, 3, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_SetJubileeBenefit2", 130, 4, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_CalculateJubileeService", 130, 5, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Derivations Summary", "Data2013_DerivationSummary_SetJubileeEligibilityDate", 130, 6, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Simple Import Summary", "Data2013_SimpleImportSummary_SimpleImportDetail", 130, 1, false);
                pData._OM_ExportReport_SubReports(sOutput_Data2013, "Import Summary", "Data2013_ImportSummary", 130, 1, false);

            }




            thrd_Data2013.Start();



            pMain._SelectTab("Data Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Data2013");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion




            #region Val2012 - Add Val Service

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "JubileeValuations");
            pMain._HomeTreeViewSelect(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "True");
            dic.Add("Name", "Val2012");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "2012");
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
            dic.Add("ServiceToOpen", "Val2012");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            #endregion

            #region Val2012 - ParticipantDataSet

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
            dic.Add("SnapshotName", "Valuation Data");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);

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
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion

            #region Val2012 - Assumptions


            pMain._SelectTab("Val2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");

            pAssumptions._TreeView_SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Assumed Retirement Age");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FromData", "True");
            dic.Add("CustomCode", "");
            dic.Add("AssumedRetirementAge_V", "Click");
            dic.Add("AssumedRetirementAge_C", "");
            dic.Add("AssumedRetirementAge_cbo", "AssumedRetirementAge");
            dic.Add("AssumedRetirementAge_txt", "");
            pAssumedRetirementAge._PopVerify_FromData(dic);


            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Assumed Retirement Age");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FromData", "True");
            dic.Add("CustomCode", "");
            dic.Add("AssumedRetirementAge_V", "Click");
            dic.Add("AssumedRetirementAge_C", "");
            dic.Add("AssumedRetirementAge_cbo", "AssumedRetirementAge");
            dic.Add("AssumedRetirementAge_txt", "");
            pAssumedRetirementAge._PopVerify_FromData(dic);


            pAssumptions._TreeView_SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Assumed Retirement Age");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FromData", "True");
            dic.Add("CustomCode", "");
            dic.Add("AssumedRetirementAge_V", "Click");
            dic.Add("AssumedRetirementAge_C", "");
            dic.Add("AssumedRetirementAge_cbo", "AssumedRetirementAge");
            dic.Add("AssumedRetirementAge_txt", "");
            pAssumedRetirementAge._PopVerify_FromData(dic);


            pAssumptions._TreeView_SelectTab("IntAccounting");

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
            dic.Add("txtRate", "5,0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            pAssumptions._TreeView_SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("MenuItem", "Add Pay Increase");
            pAssumptions._TreeViewRightSelect(dic, "PayIncrease1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "PayIncrease1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "PayIncrease1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "");
            dic.Add("btnT", "");
            dic.Add("txtRate", "1,0");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);

            pAssumptions._TreeView_SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "PayIncrease1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "");
            dic.Add("btnT", "");
            dic.Add("txtRate", "2,0");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);


            pAssumptions._TreeView_SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("WorkingDaysPerYear", "260,00");
            dic.Add("AdjustFactorrFromNextToGross", "1,00");
            dic.Add("TaxTariff", "");
            dic.Add("SoliTaxRate", "");
            dic.Add("ChurchTaxRate", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_DE(dic);

            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("WorkingDaysPerYear", "260,00");
            dic.Add("AdjustFactorrFromNextToGross", "1,00");
            dic.Add("TaxTariff", "");
            dic.Add("SoliTaxRate", "");
            dic.Add("ChurchTaxRate", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_DE(dic);

            pAssumptions._TreeView_SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("WorkingDaysPerYear", "260,00");
            dic.Add("AdjustFactorrFromNextToGross", "1,00");
            dic.Add("TaxTariff", "");
            dic.Add("SoliTaxRate", "");
            dic.Add("ChurchTaxRate", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_DE(dic);

            pMain._Home_ToolbarClick_Top(true);


            #endregion

            #region Val2012 - Common Update Code for DE - Update Assumptions

            pMain._SelectTab("Assumptions");

            pAssumptions._TreeView_SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("cboPrescribedRates", "Heubeck 2005 G");
            dic.Add("ApplyPercentMarriedAt", "");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "");
            dic.Add("txtPercentMarried_F", "");
            dic.Add("cboPercentMarried", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "");
            dic.Add("txtDifferenceInSpouseAge_F", "");
            dic.Add("cboDifferenceInSpouseAge", "");
            dic.Add("DifferenceInOrphanAge", "");
            dic.Add("NumberOfChildren", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);


            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("cboPrescribedRates", "Heubeck 2005 G");
            dic.Add("ApplyPercentMarriedAt", "");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "");
            dic.Add("txtPercentMarried_F", "");
            dic.Add("cboPercentMarried", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "");
            dic.Add("txtDifferenceInSpouseAge_F", "");
            dic.Add("cboDifferenceInSpouseAge", "");
            dic.Add("DifferenceInOrphanAge", "");
            dic.Add("NumberOfChildren", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);


            pAssumptions._TreeView_SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("cboPrescribedRates", "Heubeck 2005 G");
            dic.Add("ApplyPercentMarriedAt", "");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "");
            dic.Add("txtPercentMarried_F", "");
            dic.Add("cboPercentMarried", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "");
            dic.Add("txtDifferenceInSpouseAge_F", "");
            dic.Add("cboDifferenceInSpouseAge", "");
            dic.Add("DifferenceInOrphanAge", "");
            dic.Add("NumberOfChildren", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);


            pAssumptions._TreeView_SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pAssumptions._TreeView_SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);



            pAssumptions._TreeView_SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Other", "True");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERODIS");
            dic.Add("Service", "");
            dic.Add("AdjustmentOperator", "");
            dic.Add("Adjustment_C", "");
            dic.Add("Adjustment_P", "");
            dic.Add("Adjustment_T", "");
            dic.Add("Adjustment_txt", "");
            dic.Add("Adjustment_Tcbo", "");
            dic.Add("Adjustment_Tcbo_extend", "");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Other", "True");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERODIS");
            dic.Add("Service", "");
            dic.Add("AdjustmentOperator", "");
            dic.Add("Adjustment_C", "");
            dic.Add("Adjustment_P", "");
            dic.Add("Adjustment_T", "");
            dic.Add("Adjustment_txt", "");
            dic.Add("Adjustment_Tcbo", "");
            dic.Add("Adjustment_Tcbo_extend", "");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pAssumptions._TreeView_SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Other", "True");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERODIS");
            dic.Add("Service", "");
            dic.Add("AdjustmentOperator", "");
            dic.Add("Adjustment_C", "");
            dic.Add("Adjustment_P", "");
            dic.Add("Adjustment_T", "");
            dic.Add("Adjustment_txt", "");
            dic.Add("Adjustment_Tcbo", "");
            dic.Add("Adjustment_Tcbo_extend", "");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);



            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region Val2012 - Provisions

            pMain._SelectTab("Val2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Provisions");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "JubileeService");


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "JubileeService");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("ServiceAsAFunction", "True");
            dic.Add("RulesBasedService", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Function", "$emp.JubiService+($Year-$ValYear)");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "PayProjection1");


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "PayProjection1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataFieldContainingPayHistory", "JubiPay");
            dic.Add("PayIncreaseAssumption", "PayIncrease1");
            dic.Add("UseOnlyDataFields", "");
            dic.Add("rdValuationYearPlus", "");
            dic.Add("txtValuationYearPlus", "");
            dic.Add("rdSpecifiedYear", "");
            dic.Add("txtSpecifiedYear", "");
            dic.Add("ApplyEGTRRALimits", "");
            pPayoutProjection._PopVerify_History(dic);

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Contractual Retirement Age");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("FixedAge_V", "Click");
            dic.Add("FixedAge_C", "");
            dic.Add("FixedAge_cbo", "ContractualRetAge");
            dic.Add("FixedAge_txt", "");
            pContractualRetirementAge._PopVerify_ContractualRetirementAge(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "JubBen04");


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "JubBen04");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$PayProjection1*$JubileeService*0.01");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("MenuItem", "Add Jubilee Benefit");
            pAssumptions._TreeViewRightSelect(dic, "JubileeBenefit1");


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("Level_6", "JubileeBenefit1");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FixedAmount", "");
            dic.Add("SalaryBased", "");
            dic.Add("JubileeAmount_V", "");
            dic.Add("JubileeAmount_C", "");
            dic.Add("JubileeAmount_cbo", "JBen01");
            dic.Add("JubileeAmount_txt", "");
            dic.Add("NetAmtUsingTotal", "");
            dic.Add("NetAmtUsingSystem", "");
            dic.Add("YearSalary", "");
            dic.Add("TaxClass", "");
            dic.Add("GrossAmount", "");
            dic.Add("FinalAmount", "");
            pJubileeBenefit._PopVerify_FixedAmount(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("MenuItem", "Add Jubilee Benefit");
            pAssumptions._TreeViewRightSelect(dic, "JubileeBenefit2");


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("Level_6", "JubileeBenefit2");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FixedAmount", "");
            dic.Add("SalaryBased", "");
            dic.Add("JubileeAmount_V", "");
            dic.Add("JubileeAmount_C", "");
            dic.Add("JubileeAmount_cbo", "JBen02");
            dic.Add("JubileeAmount_txt", "");
            dic.Add("NetAmtUsingTotal", "");
            dic.Add("NetAmtUsingSystem", "");
            dic.Add("YearSalary", "");
            dic.Add("TaxClass", "");
            dic.Add("GrossAmount", "");
            dic.Add("FinalAmount", "");
            pJubileeBenefit._PopVerify_FixedAmount(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("MenuItem", "Add Jubilee Benefit");
            pAssumptions._TreeViewRightSelect(dic, "JubileeBenefit3");


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("Level_6", "JubileeBenefit3");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FixedAmount", "");
            dic.Add("SalaryBased", "True");
            dic.Add("SalaryDefinition", "PayProjection1");
            dic.Add("DevideBy_V", "");
            dic.Add("DevideBy_C", "Click");
            dic.Add("DevideBy_cbo", "");
            dic.Add("DevideBy_txt", "10,00000000");
            pJubileeBenefit._PopVerify_SalaryBased(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("MenuItem", "Add Jubilee Benefit");
            pAssumptions._TreeViewRightSelect(dic, "JubileeBenefit4");


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("Level_6", "JubileeBenefit4");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FixedAmount", "");
            dic.Add("SalaryBased", "");
            dic.Add("JubileeAmount_V", "");
            dic.Add("JubileeAmount_C", "");
            dic.Add("JubileeAmount_cbo", "JubBen04");
            dic.Add("JubileeAmount_txt", "");
            dic.Add("NetAmtUsingTotal", "");
            dic.Add("NetAmtUsingSystem", "");
            dic.Add("YearSalary", "");
            dic.Add("TaxClass", "");
            dic.Add("GrossAmount", "");
            dic.Add("FinalAmount", "");
            pJubileeBenefit._PopVerify_FixedAmount(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Jub01");


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Jub01");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("YearsOfServiceForJubi", "5");
            dic.Add("BasedOn", "JubiEligDate");
            dic.Add("YearlySalary", "PayProjection1");
            dic.Add("ApplyPercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("JubileeBenefit", "JubileeBenefit1");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "");
            dic.Add("Disability", "");
            dic.Add("Death", "");
            dic.Add("GraceYears", "");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Jub02");


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Jub02");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("YearsOfServiceForJubi", "10");
            dic.Add("BasedOn", "JubiEligDate");
            dic.Add("YearlySalary", "PayProjection1");
            dic.Add("ApplyPercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("JubileeBenefit", "JubileeBenefit2");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "");
            dic.Add("Disability", "");
            dic.Add("Death", "");
            dic.Add("GraceYears", "");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);



            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Jub03");


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Jub03");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("YearsOfServiceForJubi", "20");
            dic.Add("BasedOn", "JubiEligDate");
            dic.Add("YearlySalary", "PayProjection1");
            dic.Add("ApplyPercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("JubileeBenefit", "JubileeBenefit3");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "");
            dic.Add("Disability", "");
            dic.Add("Death", "");
            dic.Add("GraceYears", "");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);



            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Jub04");


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Jub04");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("YearsOfServiceForJubi", "25");
            dic.Add("BasedOn", "JubiEligDate");
            dic.Add("YearlySalary", "PayProjection1");
            dic.Add("ApplyPercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("JubileeBenefit", "JubileeBenefit4");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "");
            dic.Add("Disability", "");
            dic.Add("Death", "");
            dic.Add("GraceYears", "");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);




            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub1");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub2");
            dic.Add("MenuItem", "Copy VO From");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", Config.sClientName);
            dic.Add("Plan", Config.sPlanName);
            dic.Add("ServiceInstance", "Val2012");
            dic.Add("ValuationNode", "Baseline");
            dic.Add("VOShortName", "Jub1");
            dic.Add("OK", "click");
            pMain._PopVerify_CopyProvisionSet_DE(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jub3");
            dic.Add("MenuItem", "Copy VO From");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", Config.sClientName);
            dic.Add("Plan", Config.sPlanName);
            dic.Add("ServiceInstance", "Val2012");
            dic.Add("ValuationNode", "Baseline");
            dic.Add("VOShortName", "Jub1");
            dic.Add("OK", "click");
            pMain._PopVerify_CopyProvisionSet_DE(dic);

            pMain._Home_ToolbarClick_Top(true);







            #endregion


            #region  Val2012 - Methods

            pMain._SelectTab("Val2012");

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
            dic.Add("AverageWorkingLifeTime", "True");
            dic.Add("AverageLifeTime", "True");
            dic.Add("AverageWorkingLifeTimeToVesting", "");
            dic.Add("AverageWorkingLifeTimeForBenefitingEE", "");
            pMethods._PopVerify_Methods_Accounting(dic);

            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region Val2012 - ER & Output Manager

            pMain._SelectTab("Val2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "False");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "Jub1");
            dic.Add("SelectVOs_VO2", "Jub2");
            dic.Add("SelectVOs_VO3", "Jub3");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Val2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Val2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            if (Config.bDownloadReports_PDF)
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutput_Data2012, "Valuation Summary", "Conversion", true, false, 0, new string[1] { "ALL" });

            if (Config.bDownloadReports_EXCEL)
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutput_Data2012, "Valuation Summary", "Conversion", false, false, 0, new string[1] { "ALL" });

            thrd_Data2012_Val.Start();


            pMain._SelectTab("Val2012");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Val2013




            pMain._SelectTab("Home");




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "Val2013");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "2013");
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
            dic.Add("ServiceToOpen", "Val2013");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);



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
            dic.Add("SnapshotName", "Valuation Data");
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
            dic.Add("ImportDataandApplyMapping", "Click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._SelectTab("Participant DataSet");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab("Val2013");

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
            dic.Add("PayoutProjection", "");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "False");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "Jub1");
            dic.Add("SelectVOs_VO2", "Jub2");
            dic.Add("SelectVOs_VO3", "Jub3");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Val2013");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Val2013");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            if (Config.bDownloadReports_PDF)
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutput_Data2013, "Valuation Summary", "RollForward", true, false, 0, new string[1] { "ALL" });

            if (Config.bDownloadReports_EXCEL)
                pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutput_Data2013, "Valuation Summary", "RollForward", false, false, 0, new string[1] { "ALL" });

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE012", sOutput_Data2013_Prod, sOutput_Data2013);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Val2013");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_ALL.xlsx", 16, 0, 0, 0, true);
            }

            pMain._SelectTab("Val2013");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);





            #endregion



            _gLib._MsgBox("Congratulations!", "Finally, you are done with DE012!");







        }




        void t_CompareRpt_Data2012(string sOutput_Data2012)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE012", sOutput_Data2012_Prod, sOutput_Data2012);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Data2012");
                _compareReportsLib.CompareExcel_Exact("CurrentView.xlsx", 9, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ImportSummary.xlsx", 7, new int[2, 2] { { 11, 6 }, { 12, 6 } }, new string[1] { "rptDataCheckingImportSummary" });
                _compareReportsLib.CompareExcel_Exact("Data2012_ImportSummary_DataFileMapping.xlsx", 9, 0, 0, 25, new int[1, 2] { { 13, 23 } }, new string[0] { }, new string[1] { "rptDataImportMapping" });
                _compareReportsLib.CompareExcel_Exact("Data2012_ImportSummary_DataFileMatching.xlsx", 9, new int[1, 2] { { 11, 33 } }, new string[1] { "rptDataImportMatching" });
                _compareReportsLib.CompareExcel_Exact("Data2012_ImportSummary_PMD.xlsx", 7, new int[6, 2] { { 12, 13 }, { 12, 14 }, { 13, 13 }, { 13, 14 }, { 14, 13 }, { 14, 14 } }, new string[1] { "rptDataImportPreMatching" });
                _compareReportsLib.CompareExcel_Exact("FilterSummary.xlsx", 9, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DerivationsSummary.xlsx", 9, new int[10, 2] { { 11, 3 }, { 12, 3 }, { 13, 3 }, { 14, 3 }, { 15, 3 }, { 11, 4 }, { 12, 4 }, { 13, 4 }, { 14, 4 }, { 15, 4 } }, new string[1] { "rptDataCheckingDerivationSummar" });
                _compareReportsLib.CompareExcel_Exact("Data2012_DerivationSummary_SetJubileePay.xlsx", 8, new int[18, 2] { { 15, 6 }, { 16, 6 }, { 17, 6 }, { 18, 6 }, { 19, 6 }, { 20, 6 }
                    ,{ 15, 13 }, { 16, 13 }, { 17, 13 }, { 18, 13 }, { 19, 13 }, { 20, 13 }
                    ,{ 15, 14 }, { 16, 14}, { 17, 14 }, { 18, 14 }, { 19, 14 }, { 20, 14 } }, new string[1] { "rptDataCheckingDerivationsSumma" });
                _compareReportsLib.CompareExcel_Exact("Data2012_DerivationSummary_SetJubileeBenefit1.xlsx", 8, new int[12, 2] { { 15, 6 }, { 16, 6 }, { 17, 6 }, { 18, 6 }
                    ,{ 15, 13 }, { 16, 13 }, { 17, 13 }, { 18, 13 }, { 15, 14 }, { 16, 14}, { 17, 14 }, { 18, 14 }}, new string[1] { "rptDataCheckingDerivationsSumma" });
                _compareReportsLib.CompareExcel_Exact("Data2012_DerivationSummary_SetJubileeBenefit2.xlsx", 8, new int[18, 2] { { 15, 6 }, { 16, 6 }, { 17, 6 }, { 18, 6 }, { 19, 6 }, { 20, 6 }
                    ,{ 15, 13 }, { 16, 13 }, { 17, 13 }, { 18, 13 }, { 19, 13 }, { 20, 13 }
                    ,{ 15, 14 }, { 16, 14}, { 17, 14 }, { 18, 14 }, { 19, 14 }, { 20, 14 } }, new string[1] { "rptDataCheckingDerivationsSumma" });
                _compareReportsLib.CompareExcel_Exact("Data2012_DerivationSummary_CalculateJubileeService.xlsx", 8, new int[9, 2] { { 15, 6 }, { 16, 6 }, { 17, 6 }, { 15, 13 }, { 16, 13 }, { 17, 13 }
                    , { 15, 14 }, { 16, 14}, { 17, 14 }}, new string[1] { "rptDataCheckingDerivationsSumma" });
                _compareReportsLib.CompareExcel_Exact("Data2012_DerivationSummary_SetJubileeEligibilityDate.xlsx", 8, new int[9, 2] { { 15, 6 }, { 16, 6 }, { 17, 6 }, { 15, 13 }, { 16, 13 }, { 17, 13 }
                    , { 15, 14 }, { 16, 14}, { 17, 14}}, new string[1] { "rptDataCheckingDerivationsSumma" });

                _compareReportsLib.CompareExcel_Exact("SnapshotSummary.xlsx", 8, new int[6, 2] { { 12, 3 }, { 13, 3 }, { 12, 4 }, { 13, 4 }, { 12, 5 }, { 13, 5 } }, new string[1] { "rptDataCheckingSnapshotSummary" });
                _compareReportsLib.CompareExcel_Exact("Data2012_SnapshotExtract.xlsx", 7, 0, 0, 0);

                Config.bThreadFinsihed = true;
            }
        }


        void t_CompareRpt_Data2013(string sOutput_Data2013)
        {


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE012", sOutput_Data2013_Prod, sOutput_Data2013);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Data2013");
                _compareReportsLib.CompareExcel_Exact("PriorView.xlsx", 9, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CurrentView.xlsx", 9, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ImportSummary.xlsx", 7, new int[2, 2] { { 11, 6 }, { 12, 6 } }, new string[1] { "rptDataCheckingImportSummary" });
                _compareReportsLib.CompareExcel_Exact("Data2013_ImportSummary_DataFileMapping.xlsx", 9, 0, 0, 25, new int[1, 2] { { 13, 23 } }, new string[0] { }, new string[1] { "rptDataImportMapping" });
                _compareReportsLib.CompareExcel_Exact("Data2013_ImportSummary_DataFileMatching.xlsx", 9, new int[1, 2] { { 11, 33 } }, new string[1] { "rptDataImportMatching" });
                _compareReportsLib.CompareExcel_Exact("Data2013_ImportSummary_PMD.xlsx", 7, new int[6, 2] { { 12, 13 }, { 12, 14 }, { 13, 13 }, { 13, 14 }, { 14, 13 }, { 14, 14 } }, new string[1] { "rptDataImportPreMatching" });
                _compareReportsLib.CompareExcel_Exact("SimpleImportSummary.xlsx", 7, new int[2, 2] { { 11, 3 }, { 11, 7 } }, new string[1] { "rptDataCheckingSimpleImportSumm" });
                _compareReportsLib.CompareExcel_Exact("Data2013_SimpleImportSummary_SimpleImportDetail.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FilterSummary.xlsx", 9, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DerivationsSummary.xlsx", 9, new int[12, 2] { { 11, 3 }, { 12, 3 }, { 13, 3 }, { 14, 3 }, { 15, 3 }, { 16, 3 }, { 11, 4 }, { 12, 4 }, { 13, 4 }, { 14, 4 }, { 15, 4 }, { 16, 4 } }, new string[1] { "rptDataCheckingDerivationSummar" });
                _compareReportsLib.CompareExcel_Exact("Data2013_DerivationSummary_SetIsEligible_Jub3.xlsx", 8, new int[12, 2] { { 15, 6 }, { 16, 6 }, { 17, 6 }, { 18, 6 }
                    ,{ 15, 13 }, { 16, 13 }, { 17, 13 }, { 18, 13 }, { 15, 14 }, { 16, 14}, { 17, 14 }, { 18, 14 }}, new string[1] { "rptDataCheckingDerivationsSumma" });
                _compareReportsLib.CompareExcel_Exact("Data2013_DerivationSummary_SetJubileePay.xlsx", 8, new int[18, 2] { { 15, 6 }, { 16, 6 }, { 17, 6 }, { 18, 6 }, { 19, 6 }, { 20, 6 }
                    ,{ 15, 13 }, { 16, 13 }, { 17, 13 }, { 18, 13 }, { 19, 13 }, { 20, 13 }
                    ,{ 15, 14 }, { 16, 14}, { 17, 14 }, { 18, 14 }, { 19, 14 }, { 20, 14 } }, new string[1] { "rptDataCheckingDerivationsSumma" });
                _compareReportsLib.CompareExcel_Exact("Data2013_DerivationSummary_SetJubileeBenefit1.xlsx", 8, new int[12, 2] { { 15, 6 }, { 16, 6 }, { 17, 6 }, { 18, 6 }
                    ,{ 15, 13 }, { 16, 13 }, { 17, 13 }, { 18, 13 }, { 15, 14 }, { 16, 14}, { 17, 14 }, { 18, 14 }}, new string[1] { "rptDataCheckingDerivationsSumma" });
                _compareReportsLib.CompareExcel_Exact("Data2013_DerivationSummary_SetJubileeBenefit2.xlsx", 8, new int[18, 2] { { 15, 6 }, { 16, 6 }, { 17, 6 }, { 18, 6 }, { 19, 6 }, { 20, 6 }
                    ,{ 15, 13 }, { 16, 13 }, { 17, 13 }, { 18, 13 }, { 19, 13 }, { 20, 13 }
                    ,{ 15, 14 }, { 16, 14}, { 17, 14 }, { 18, 14 }, { 19, 14 }, { 20, 14 } }, new string[1] { "rptDataCheckingDerivationsSumma" });
                _compareReportsLib.CompareExcel_Exact("Data2013_DerivationSummary_CalculateJubileeService.xlsx", 8, new int[9, 2] { { 15, 6 }, { 16, 6 }, { 17, 6 }, { 15, 13 }, { 16, 13 }, { 17, 13 }
                    , { 15, 14 }, { 16, 14}, { 17, 14 }}, new string[1] { "rptDataCheckingDerivationsSumma" });
                _compareReportsLib.CompareExcel_Exact("Data2013_DerivationSummary_SetJubileeEligibilityDate.xlsx", 8, new int[9, 2] { { 15, 6 }, { 16, 6 }, { 17, 6 }, { 15, 13 }, { 16, 13 }, { 17, 13 }
                    , { 15, 14 }, { 16, 14}, { 17, 14}}, new string[1] { "rptDataCheckingDerivationsSumma" });

                _compareReportsLib.CompareExcel_Exact("SnapshotSummary.xlsx", 8, new int[6, 2] { { 12, 3 }, { 13, 3 }, { 12, 4 }, { 13, 4 }, { 12, 5 }, { 13, 5 } }, new string[1] { "rptDataCheckingSnapshotSummary" });
                _compareReportsLib.CompareExcel_Exact("Data2013_SnapshotExtract.xlsx", 7, 0, 0, 0);




                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DataOutputManager", 10, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "CurrentView", 10, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "Uploads", 10, 0, 0, 0, new int[8, 2] { { 14, 3 }, { 15, 3 }, { 16, 3 }, { 17, 3 }, 
                { 14, 4 }, { 15, 4 }, { 16, 4 }, { 17, 4 } });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "ImportSummary", 7, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "ImportMapping1", 10, 0, 0, 0, new int[2, 2] { { 13, 23 }, { 13, 24 } });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "Import1Trans1", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "ImportPreMatching1", 8, 0, 0, 0, new int[3, 2] { { 12, 13 }, { 13, 13 }, { 14, 13 } });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "ImportPre1Field1", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "ImportPre1Field2", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "ImportPre1Field3", 0, 0, 0, 0, new int[0, 0] { });

                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "ImportMatching1", 14, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "ImportMapping2", 10, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "ImportPreMatching2", 8, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "ImportPre2Field1", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "ImportMatching2", 10, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "SimpleImportSummary", 10, 0, 0, 0, new int[1, 2] { { 11, 3 } });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "FilterSummary", 8, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "CustomFilter1", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "CustomFilter2", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "CustomFilter3", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivationsSummary", 10, 0, 0, 0, new int[12, 2] { { 11, 3 }, { 11, 4 },
                { 12, 3 }, { 12, 4 },{ 13, 3 }, { 13, 4 },{ 14, 3 }, { 14, 4 },{ 15, 3 }, { 15, 4 },{ 16, 3 }, { 16, 4 }});
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr1", 8, 0, 0, 0, new int[4, 2] { { 15, 6 }, { 15, 7 }, { 15, 8 }, { 15, 13 } });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr1Field1", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr2", 8, 0, 0, 0, new int[12, 2] { { 15, 6 }, { 15, 7 }, { 15, 8 }, { 15, 13 },
                { 16, 6 }, { 16, 7 }, { 16, 8 }, { 16, 13 },{ 17, 6 }, { 17, 7 }, { 17, 8 }, { 17, 13 }});
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr2Field1", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr2Field2", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr2Field3", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr3", 8, 0, 0, 0, new int[12, 2] { { 15, 6 }, { 15, 7 }, { 15, 8 }, { 15, 13 },
                { 16, 6 }, { 16, 7 }, { 16, 8 }, { 16, 13 },{ 17, 6 }, { 17, 7 }, { 17, 8 }, { 17, 13 }});
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr3Field1", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr3Field2", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr3Field3", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr4", 8, 0, 0, 0, new int[12, 2] { { 15, 6 }, { 15, 7 }, { 15, 8 }, { 15, 13 },
                { 16, 6 }, { 16, 7 }, { 16, 8 }, { 16, 13 },{ 17, 6 }, { 17, 7 }, { 17, 8 }, { 17, 13 }});
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr4Field1", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr4Field2", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr4Field3", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr5", 8, 0, 0, 0, new int[12, 2] { { 15, 6 }, { 15, 7 }, { 15, 8 }, { 15, 13 },
                { 16, 6 }, { 16, 7 }, { 16, 8 }, { 16, 13 },{ 17, 6 }, { 17, 7 }, { 17, 8 }, { 17, 13 }});
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr5Field1", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr5Field2", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr5Field3", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr6", 8, 0, 0, 0, new int[12, 2] { { 15, 6 }, { 15, 7 }, { 15, 8 }, { 15, 13 },
                { 16, 6 }, { 16, 7 }, { 16, 8 }, { 16, 13 },{ 17, 6 }, { 17, 7 }, { 17, 8 }, { 17, 13 }});
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr6Field1", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr6Field2", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "DerivGr6Field3", 0, 0, 0, 0, new int[0, 0] { });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "SnapshotSummary", 8, 0, 0, 0, new int[3, 2] { { 12, 3 }, { 12, 4 }, { 12, 5 } });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "Snapshot1", 8, 0, 0, 0, new int[3, 2] { { 13, 4 }, { 13, 5 }, { 13, 6 } });
                _compareReportsLib.CompareExcel_Exact_BySheetName("GenerateConsolidatedOuput.xlsx", "ActivityLog", 10, 0, 0, 0, new int[27, 2] { { 12, 2 }, { 12, 3 }, { 12, 6 }, 
                { 13, 2 }, { 13, 3 }, { 13, 6 }, { 14, 2 },{ 14, 3 }, { 14, 6 }, { 15, 2 },{ 15, 3 }, { 15, 6 },{ 16, 2 }, { 16, 3 },{ 16, 6 }, { 17, 2 },{ 17, 3}, { 17, 6 },
                { 18, 2 }, { 18, 3 }, { 18, 6 }, { 19, 2 },{ 19, 3 },{ 19, 6 }, { 20, 2 },{ 20, 3 }, { 20, 6 }});

                Config.bThreadFinsihed = true;

            }

        }


        void t_CompareRpt_Data2012_Val(string sOutput_Data2012)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE012", sOutput_Data2012_Prod, sOutput_Data2012);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Val2012");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_ALL.xlsx", 16, 0, 0, 0);

                Config.bThreadFinsihed = true;
            }

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
