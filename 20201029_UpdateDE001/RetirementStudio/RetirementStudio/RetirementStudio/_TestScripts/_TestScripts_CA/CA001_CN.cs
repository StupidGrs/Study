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
using RetirementStudio._UIMaps.DefinedBenefitLimitIncreaseClasses;
using RetirementStudio._UIMaps.FromToAgeClasses;
using RetirementStudio._UIMaps.AverageYMPEClasses;
using RetirementStudio._UIMaps.FAEFormulaClasses;
using RetirementStudio._UIMaps.EmployeeContributionsFormulaClasses;
using RetirementStudio._UIMaps.CostOfLivingAdjustmentsClasses;
using RetirementStudio._UIMaps.EarlyRetirementFactorClasses;
using RetirementStudio._UIMaps.AdjustmentsClasses;
using RetirementStudio._UIMaps.MaxPensionDefinitionClasses;
using RetirementStudio._UIMaps.ExcessContributionDefinitionClasses;
using RetirementStudio._UIMaps.BenefitElectionsClasses;
using RetirementStudio._UIMaps.ITAMaximumPensionsClasses;


namespace RetirementStudio._TestScripts._TestScripts_CA
{
    /// <summary>
    /// Summary description for CA001_CN
    /// </summary>
    [CodedUITest]
    public class CA001_CN
    {
        public CA001_CN()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.CA;
            Config.sDataCenter = "Dallas";
            Config.sClientName = "QA CA Benchmark 001 Create New";
            Config.sPlanName = "QA CA Benchmark 001 Create New Plan";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;


            //_gLib._Report(_PassFailStep.Header, "Testing Starts at: " + DateTime.Now + "\t" + Environment.UserName);

            //_gLib._MsgBox("Warning!", "If you are running Existing or Re-opened Studio after crash, Please manually select the Client in Studio-> Home -> All Services -> "
            //    + Config.sClientName + Environment.NewLine + Environment.NewLine + "If you are running CreateNew without any crash,\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA Please ignore this msg!"
            //    + Environment.NewLine + Environment.NewLine + "Click OK to keep testing!");
        }


        #region Report Output Directory

        public string sOutputFunding_Funding2008_Baseline = "";
        public string sOutputFunding_Funding2008_NewDAMP = "";
        public string sOutputFunding_Funding2011_Baseline = "";
        public string sOutputFunding_Funding2011_NewValuation = "";
        public string sOutputFunding_WindUpGL2011 = "";
        public string sOutputAccounting_Accounting2008 = "";

        public string sOutputFunding_Funding2008_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_CA_Benchmark_1\Production\Funding2008\Baseline\6.7.2_20151026\";
        public string sOutputFunding_Funding2008_NewDAMP_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_CA_Benchmark_1\Production\Funding2008\NewDAMP\6.7.2_20151026\";
        public string sOutputFunding_Funding2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_CA_Benchmark_1\Production\Funding2011\Baseline\6.7.2_20151026\";
        public string sOutputFunding_Funding2011_NewValuation_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_CA_Benchmark_1\Production\Funding2011\NewValuation\6.7.2_20151026\";
        public string sOutputFunding_WindUpGL2011_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_CA_Benchmark_1\Production\WindUpGL2011\6.7.2_20151026\";
        public string sOutputAccounting_Accounting2008_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_CA_Benchmark_1\Production\Accounting2008\6.7.2_20151026\";


        String sTable_RETNAC = "";
        String sTable_WTHNAC = "";


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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_CA_Benchmark_1\CreateNew\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputFunding_Funding2008_Baseline = _gLib._CreateDirectory(sMainDir + "Funding2008\\Baseline\\" + sPostFix + "\\");
                    sOutputFunding_Funding2008_NewDAMP = _gLib._CreateDirectory(sMainDir + "Funding2008\\NewDAMP\\" + sPostFix + "\\");
                    sOutputFunding_Funding2011_Baseline = _gLib._CreateDirectory(sMainDir + "Funding2011\\Baseline\\" + sPostFix + "\\");
                    sOutputFunding_Funding2011_NewValuation = _gLib._CreateDirectory(sMainDir + "Funding2011\\NewValuation\\" + sPostFix + "\\");
                    sOutputFunding_WindUpGL2011 = _gLib._CreateDirectory(sMainDir + "WindUpGL2011\\" + sPostFix + "\\");
                    sOutputAccounting_Accounting2008 = _gLib._CreateDirectory(sMainDir + "Accounting2008\\" + sPostFix + "\\");
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

                //////sDir = sDir + "\\_TestLog\\";

                string sMainDir = sDir + "CA001_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputFunding_Funding2008_Baseline = _gLib._CreateDirectory(sMainDir + "\\Funding2008\\Baseline\\");
                sOutputFunding_Funding2008_NewDAMP = _gLib._CreateDirectory(sMainDir + "\\Funding2008\\NewDAMP\\");
                sOutputFunding_Funding2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\Funding2011\\Baseline\\");
                sOutputFunding_Funding2011_NewValuation = _gLib._CreateDirectory(sMainDir + "\\Funding2011\\NewValuation\\");
                sOutputFunding_WindUpGL2011 = _gLib._CreateDirectory(sMainDir + "\\WindUpGL2011\\");
                sOutputAccounting_Accounting2008 = _gLib._CreateDirectory(sMainDir + "\\Accounting2008\\");


            }

            string sContent = "";
            sContent = sContent + "sOutputFunding_Funding2008_Baseline = @\"" + sOutputFunding_Funding2008_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Funding2008_NewDAMP = @\"" + sOutputFunding_Funding2008_NewDAMP + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Funding2011_Baseline = @\"" + sOutputFunding_Funding2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Funding2011_NewValuation = @\"" + sOutputFunding_Funding2011_NewValuation + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_WindUpGL2011 = @\"" + sOutputFunding_WindUpGL2011 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Accounting2008 = @\"" + sOutputAccounting_Accounting2008 + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);


        }


        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();

        public ITAMaximumPensions pITAMaximumPensions = new ITAMaximumPensions();
        public BenefitElections pBenefitElections = new BenefitElections();
        public ExcessContributionDefinition pExcessContributionDefinition = new ExcessContributionDefinition();
        public MaxPensionDefinition pMaxPensionDefinition = new MaxPensionDefinition();
        public Adjustments pAdjustments = new Adjustments();
        public EarlyRetirementFactor pEarlyRetirementFactor = new EarlyRetirementFactor();
        public CostOfLivingAdjustments pCostOfLivingAdjustments = new CostOfLivingAdjustments();
        public EmployeeContributionsFormula pEmployeeContributionsFormula = new EmployeeContributionsFormula();
        public FAEFormula pFAEFormula = new FAEFormula();
        public AverageYMPE pAverageYMPE = new AverageYMPE();
        public FromToAge pFromToAge = new FromToAge();
        public DefinedBenefitLimitIncrease pDefinedBenefitLimitIncrease = new DefinedBenefitLimitIncrease();
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

        #endregion


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_CA001_CN()
        {

            #region MultiThreads


            Thread thrd_Funding2008_Baseline = new Thread(() => new CA001_CN().t_CompareRpt_Funding_Funding2008_Baseline(sOutputFunding_Funding2008_Baseline));
            Thread thrd_Accounting2008 = new Thread(() => new CA001_CN().t_CompareRpt_Accounting_Accounting2008(sOutputAccounting_Accounting2008));
            Thread thrd_Funding2008_NewDAMP = new Thread(() => new CA001_CN().t_CompareRpt_Funding_Funding2008_NewDAMP(sOutputFunding_Funding2008_NewDAMP));
            Thread thrd_Funding2011_Baseline = new Thread(() => new CA001_CN().t_CompareRpt_Funding_Funding2011_Baseline(sOutputFunding_Funding2011_Baseline));
            Thread thrd_Funding2011_NewValuation = new Thread(() => new CA001_CN().t_CompareRpt_Funding_Funding2011_NewValuation(sOutputFunding_Funding2011_NewValuation));


            #endregion
         


            this.GenerateReportOuputDir();


            #region Funding - Funding2008 - ParticipantData

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
            dic.Add("ClientCode", "QACA1");
            dic.Add("FiscalYearEnd", "12/31");
            dic.Add("MeasurementDate", "12/31");
            dic.Add("Notes", "Client Owner: Cathy Pickering " + Environment.NewLine + "Cathy P Test Canada 3 / Final Test with Quebec Member" + Environment.NewLine + "Date Created:" + _gLib._ReturnDateStampYYYYMMDD() + Environment.NewLine + Environment.NewLine + "DO NOT TOUCH - BENCHMARK CLIENT");
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
            dic.Add("Country", "Canada");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_PMTool_CountrySelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanName", Config.sPlanName);
            dic.Add("PlanYearBegin", "");
            dic.Add("Jurisdiction", "Ontario");
            dic.Add("RevCanadaRegistrationNum", "286294");
            dic.Add("ProvincialRegistrationNum", "286294");
            dic.Add("Union", "");
            dic.Add("NonUnion", "");
            dic.Add("Salaried", "");
            dic.Add("Hourly", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_PMTool_Plan(dic);


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
            dic.Add("Name", "Funding2008");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "2008");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "Click");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Funding2008");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Funding2008");

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
            dic.Add("GRSUnload", "Click");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("CompareData", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GRSServer", "Deerfield");
            dic.Add("LoginID", "user1");
            dic.Add("Password", "user1");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pParticipantDataSet._PopVerify_GRSLogin(dic);


            dic.Clear();
            dic.Add("Level_1", "GRS Clients");
            dic.Add("Level_2", "L190 - QA CA Benchmark 1");
            dic.Add("Level_3", "QA CA Benchmark 1 Plan");
            dic.Add("Level_4", "Studio Data");
            dic.Add("Level_5", "Current Plan");
            dic.Add("Level_6", "Unload data");
            pParticipantDataSet._GRSDataInput_TreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pParticipantDataSet._PopVerify_GRSDataInput(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "01/01/2008");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("CompareData", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


            pParticipantDataSet._Initialzie();

            dic.Clear();
            dic.Add("Level_1", "Funding Results");
            dic.Add("Level_2", "GRSWindupAL");
            dic.Add("Data", "GRSSOLV");
            pParticipantDataSet._MapField(dic);

            dic.Clear();
            dic.Add("Level_1", "Classification Codes");
            dic.Add("Level_2", "DivisionCode");
            dic.Add("Level_3", "");
            dic.Add("Level_4", "");
            dic.Add("Data", "SHRTUNIT");
            pParticipantDataSet._MapField(dic);

            dic.Clear();
            dic.Add("Level_1", "Classification Codes");
            dic.Add("Level_2", "UnionCode");
            dic.Add("Data", "STATUS");
            pParticipantDataSet._MapField(dic);

            dic.Clear();
            dic.Add("Level_1", "Classification Codes");
            dic.Add("FieldName", "Designated");
            dic.Add("HistoryFields", "");
            pParticipantDataSet._ts_AddField(dic);

            dic.Clear();
            dic.Add("Level_1", "Classification Codes");
            dic.Add("Level_2", "Designated");
            dic.Add("Level_3", "");
            dic.Add("Level_4", "");
            dic.Add("Data", "DESFLAG");
            pParticipantDataSet._MapField(dic);


            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("FieldName", "Bridge");
            dic.Add("HistoryFields", "");
            pParticipantDataSet._ts_AddField(dic);

            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "Bridge");
            dic.Add("Level_3", "");
            dic.Add("Level_4", "");
            dic.Add("Data", "BRIDGE");
            pParticipantDataSet._MapField(dic);


            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("FieldName", "StopDate");
            dic.Add("HistoryFields", "");
            pParticipantDataSet._ts_AddField(dic);

            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "StopDate");
            dic.Add("Level_3", "");
            dic.Add("Level_4", "");
            dic.Add("Data", "STOPDATE");
            pParticipantDataSet._MapField(dic);


            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("FieldName", "PriorPension");
            dic.Add("HistoryFields", "");
            pParticipantDataSet._ts_AddField(dic);

            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "PriorPension");
            dic.Add("Data", "PPEN");
            pParticipantDataSet._MapField(dic);


            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "AccruedBenefit1");
            dic.Add("Data", "TOTPEN");
            pParticipantDataSet._MapField(dic);


            dic.Clear();
            dic.Add("Level_1", "Beneficiary Information");
            dic.Add("Level_2", "Beneficiary1Percent1");
            dic.Add("Data", "JSPCT");
            pParticipantDataSet._MapField(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("FieldName", "ValnPay");
            dic.Add("HistoryFields", "10");
            pParticipantDataSet._ts_AddField(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "ValnPay");
            dic.Add("Level_4", "ValnPayPriorYear1");
            pParticipantDataSet._Navigate(dic, false);

            for (int i = 1; i <= 10; i++)
            {

                dic.Clear();
                dic.Add("Level_1", "Personal Information");
                dic.Add("Level_2", "Pay");
                dic.Add("Level_3", "ValnPay");
                dic.Add("Level_4", "ValnPayPriorYear" + i.ToString());
                dic.Add("Data", "PAY" + (2008 - i).ToString());
                dic.Add("bServiceFirstSubItem", "false");
                dic.Add("bContinueWithoutCollapse", "true");
                pParticipantDataSet._MapField(dic);

            }


            pParticipantDataSet._ExpandOrCollapseFirstLevel("Personal Information");

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("FieldName", "ServiceToDate");
            dic.Add("HistoryFields", "");
            pParticipantDataSet._ts_AddField(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "ServiceToDate");
            dic.Add("Data", "SERTOVY");
            dic.Add("bServiceFirstSubItem", "true");
            dic.Add("bContinueWithoutCollapse", "false");
            pParticipantDataSet._MapField(dic);

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
            dic.Add("FundingAL", "11565238");
            dic.Add("FundingNC", "673555");
            dic.Add("AccountingAL", "");
            dic.Add("AccountingNC", "");
            dic.Add("Instance", "2");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_TotalsByDecrement(dic);

            dic.Clear();
            dic.Add("Decrement", "Withdrawal");
            dic.Add("FundingAL", "552093");
            dic.Add("FundingNC", "52859");
            dic.Add("AccountingAL", "");
            dic.Add("AccountingNC", "");
            dic.Add("Instance", "2");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_TotalsByDecrement(dic);


            dic.Clear();
            dic.Add("Decrement", "Death");
            dic.Add("FundingAL", "312145");
            dic.Add("FundingNC", "18696");
            dic.Add("AccountingAL", "");
            dic.Add("AccountingNC", "");
            dic.Add("Instance", "2");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_TotalsByDecrement(dic);


            dic.Clear();
            dic.Add("Row", "Number");
            dic.Add("Active", "70");
            dic.Add("Deferred", "42");
            dic.Add("Retired", "77");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

            dic.Clear();
            dic.Add("Row", "Average Age");
            dic.Add("Active", "46.78");
            dic.Add("Deferred", "48.38");
            dic.Add("Retired", "70.84");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

            dic.Clear();
            dic.Add("Row", "Average Service from Hire");
            dic.Add("Active", "16.40");
            dic.Add("Deferred", "");
            dic.Add("Retired", "");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

            dic.Clear();
            dic.Add("Row", "Average Pay");
            dic.Add("Active", "89004");
            dic.Add("Deferred", "");
            dic.Add("Retired", "");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

            dic.Clear();
            dic.Add("Row", "Annual Pension");
            dic.Add("Active", "");
            dic.Add("Deferred", "9769");
            dic.Add("Retired", "21513");
            dic.Add("OK", "Click");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

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


            pMain._SelectTab("Funding2008");


            sTable_RETNAC = sTable_RETNAC + "0.030000" + Environment.NewLine;
            sTable_RETNAC = sTable_RETNAC + "0.040000" + Environment.NewLine;
            sTable_RETNAC = sTable_RETNAC + "0.040000" + Environment.NewLine;

            sTable_RETNAC = sTable_RETNAC + "0.050000" + Environment.NewLine;
            sTable_RETNAC = sTable_RETNAC + "0.050000" + Environment.NewLine;
            sTable_RETNAC = sTable_RETNAC + "0.060000" + Environment.NewLine;

            sTable_RETNAC = sTable_RETNAC + "0.070000" + Environment.NewLine;
            sTable_RETNAC = sTable_RETNAC + "0.200000" + Environment.NewLine;
            sTable_RETNAC = sTable_RETNAC + "0.210000" + Environment.NewLine;
            sTable_RETNAC = sTable_RETNAC + "0.220000" + Environment.NewLine;

            for (int i = 1; i <= 7; i++)
                sTable_RETNAC = sTable_RETNAC + "1.000000" + Environment.NewLine;


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "RETNAC");
            dic.Add("Type", "Retirement Decrements");
            dic.Add("Description", "Cathy Pickering - QA CA Benchmark 1 Table");
            dic.Add("Ultimate", "");
            dic.Add("Generational", "");
            dic.Add("TwoDimensional", "");
            dic.Add("Index1_Index", "");
            dic.Add("Index1_From", "55");
            dic.Add("Index1_To", "71");
            dic.Add("Extend", "");
            dic.Add("Zero", "true");
            dic.Add("SameRatesUsed", "True");
            dic.Add("Format", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("OK", "Click");
            dic.Add("sUnisexRates", sTable_RETNAC);
            dic.Add("sMaleRates", "");
            dic.Add("sFemaleRates", "");
            pMain._ts_AddTable(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Funding2008");


            for (int i = 1; i <= 6; i++)
                sTable_WTHNAC = sTable_WTHNAC + "0.110000" + Environment.NewLine;


            sTable_WTHNAC = sTable_WTHNAC + "0.104000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.098000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.092000" + Environment.NewLine;

            sTable_WTHNAC = sTable_WTHNAC + "0.086000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.080000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.076000" + Environment.NewLine;

            sTable_WTHNAC = sTable_WTHNAC + "0.072000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.068000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.064000" + Environment.NewLine;

            sTable_WTHNAC = sTable_WTHNAC + "0.060000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.058000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.056000" + Environment.NewLine;

            sTable_WTHNAC = sTable_WTHNAC + "0.054000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.052000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.050000" + Environment.NewLine;

            sTable_WTHNAC = sTable_WTHNAC + "0.048000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.046000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.044000" + Environment.NewLine;

            sTable_WTHNAC = sTable_WTHNAC + "0.042000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.040000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.038000" + Environment.NewLine;

            sTable_WTHNAC = sTable_WTHNAC + "0.036000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.034000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.032000" + Environment.NewLine;

            sTable_WTHNAC = sTable_WTHNAC + "0.030000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.028000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.026000" + Environment.NewLine;

            sTable_WTHNAC = sTable_WTHNAC + "0.024000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.022000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.020000" + Environment.NewLine;

            sTable_WTHNAC = sTable_WTHNAC + "0.016000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.012000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.008000" + Environment.NewLine;
            sTable_WTHNAC = sTable_WTHNAC + "0.004000" + Environment.NewLine;

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "WTHNAC");
            dic.Add("Type", "Withdrawal Decrements");
            dic.Add("Description", "Cathy Pickering - QA CA Benchmark 1 Table");
            dic.Add("Ultimate", "");
            dic.Add("Generational", "");
            dic.Add("TwoDimensional", "");
            dic.Add("Index1_Index", "");
            dic.Add("Index1_From", "15");
            dic.Add("Index1_To", "55");
            dic.Add("Extend", "");
            dic.Add("Zero", "True");
            dic.Add("SameRatesUsed", "True");
            dic.Add("Format", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("OK", "Click");
            dic.Add("sUnisexRates", sTable_WTHNAC);
            dic.Add("sMaleRates", "");
            dic.Add("sFemaleRates", "");
            pMain._ts_AddTable(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Funding - Funding2008 - Assumptions & Provisions

            pMain._SelectTab("Funding2008");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "5.75");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "Accum");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "Accum");
            dic.Add("Level_4", "Default");
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
            dic.Add("Level_2", "Pay Increase");
            dic.Add("MenuItem", "Add Pay Increase");
            pAssumptions._TreeViewRightSelect(dic, "PayInc");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "PayInc");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "");
            dic.Add("btnT", "");
            dic.Add("txtRate", "4.0");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Cost of Living Increase");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "true");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "");
            pInterestRate._PopVerify_PrescribedRates(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AsOfDate", "01/01/2008");
            dic.Add("ForActuarialEquivalence", "");
            dic.Add("ForwardRate", "");
            dic.Add("SpotRate", "");
            dic.Add("AddRow", "click");
            pInterestRate._PopVerify_TimeBased(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("NumberOfYears", "99");
            dic.Add("Rate", "2.5");
            pInterestRate._TimeBased_Table(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Defined Benefit Limit Increase");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("V", "");
            dic.Add("Percent", "click");
            dic.Add("T", "");
            dic.Add("txtRate", "3.0");
            pDefinedBenefitLimitIncrease._PopVerify_DefinedBenefitLimitIncrease(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "YMPE");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("V", "");
            dic.Add("Percent", "click");
            dic.Add("T", "");
            dic.Add("txtRate", "3.0");
            pDefinedBenefitLimitIncrease._PopVerify_DefinedBenefitLimitIncrease(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ApplyPercentMarriedAt", "Primary decrement");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "75.0");
            dic.Add("txtPercentMarried_F", "75.0");
            dic.Add("cboPercentMarried", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "-3");
            dic.Add("txtDifferenceInSpouseAge_F", "3");
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
            dic.Add("Mortality", "UP94S15");
            dic.Add("Mortality_Setback_M", "");
            dic.Add("Mortality_Setback_F", "");
            dic.Add("Disabled", "");
            dic.Add("Disabled_Setback_M", "");
            dic.Add("Disabled_Setback_F", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            pAssumptions._Collapse(dic);


            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Funding2008");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Credited");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Credited");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "true");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            dic.Add("ForInternationalAccounting_DE", "");
            dic.Add("ForTrade_DE", "");
            dic.Add("CalculateExactServiceAtReitermentAge_UK", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProvidedInDataField", "ServiceToDate");
            dic.Add("RoundingRule", "");
            dic.Add("V", "");
            dic.Add("C", "");
            dic.Add("T", "");
            dic.Add("txtServiceIncrement", "");
            dic.Add("cboServiceIncrement", "");
            pService._PopVerify_ServiceAtValuationDate(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Continuous");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Post2001");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Post2001");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "");
            dic.Add("ServiceStarts_FixedDate", "01/01/2001");
            dic.Add("Date", "MembershipDate1");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "Age306080");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "Age306080");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "60");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "Earlier of");
            pFromToAge._StandardTable_NotUS(dic);


            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "click");
            dic.Add("iRow", "2");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "");
            dic.Add("YearOfService", "30");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "Continuous");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "Earlier of");
            pFromToAge._StandardTable_NotUS(dic);


            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "click");
            dic.Add("iRow", "3");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "80");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "Continuous");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "Age55");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "Age55");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "55");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "Age55");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "Age55");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);


            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "CurrentAge");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Province = \"PQ\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "NRA65");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "NRA65");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "65");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "Later of");
            pFromToAge._StandardTable_NotUS(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "click");
            dic.Add("iRow", "2");
            dic.Add("SSNRA_Exists", "false");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "From55");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "From55");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$age >= 55");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Quebec");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Quebec");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.Province = \"PQ\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Desig");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Desig");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.Designated = \"Y\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Ontario");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Ontario");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.province = \"ON\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "StopPension");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "StopPension");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FreezeAtValuationAge", "");
            dic.Add("Formula", "IsDate($emp.StopDate)");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "YMPE Projection");
            dic.Add("MenuItem", "Add YMPE Projection");
            pAssumptions._TreeViewRightSelect(dic, "YMPEProj");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "YMPE Projection");
            dic.Add("Level_3", "YMPEProj");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "ProjectedPay");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "ProjectedPay");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataFieldContainingPayHistory", "ValnPay");
            dic.Add("PayIncreaseAssumption", "PayInc");
            dic.Add("UseOnlyDataFields", "");
            dic.Add("rdValuationYearPlus", "");
            dic.Add("txtValuationYearPlus", "");
            dic.Add("rdSpecifiedYear", "");
            dic.Add("txtSpecifiedYear", "");
            dic.Add("ApplyEGTRRALimits", "");
            pPayoutProjection._PopVerify_History(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("MenuItem", "Add Pay Average");
            pAssumptions._TreeViewRightSelect(dic, "FAE3");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("Level_3", "FAE3");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "ProjectedPay");
            dic.Add("AveragingMethod", "");
            dic.Add("M", "3");
            dic.Add("RoundingForYearOfHire", "");
            dic.Add("DecimalPlacesForYearOfHire", "");
            dic.Add("Include", "");
            dic.Add("DropForCalculations", "");
            dic.Add("DropForCalculationAndPeriodConsidered", "");
            dic.Add("AdjustmentPeriodMonths", "");
            dic.Add("AdjustmentMethod", "");
            dic.Add("FreezePayAverageAtAge_V", "");
            dic.Add("FreezePayAverageAtAge_C", "");
            dic.Add("FreezePayAverageAtAge_cbo", "");
            pPayAverage._PopVerify_Standard(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Assumptions");


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

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "RETNAC");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "From55");
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
            dic.Add("RetWithdrawDis", "WTHNAC");
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

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "From55");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            pMain._Home_ToolbarClick_Top(true);


            pMethods._SelectTab("Solvency/ Wind-Up");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "CV Interest Rate");
            dic.Add("Level_3", "Solvency,WindUp");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "true");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "");
            pInterestRate._PopVerify_PrescribedRates(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AsOfDate", "01/01/2008");
            dic.Add("ForActuarialEquivalence", "");
            dic.Add("ForwardRate", "true");
            dic.Add("SpotRate", "");
            dic.Add("AddRow", "click");
            pInterestRate._PopVerify_TimeBased(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("NumberOfYears", "10");
            dic.Add("Rate", "4.5");
            pInterestRate._TimeBased_Table(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AsOfDate", "");
            dic.Add("ForActuarialEquivalence", "");
            dic.Add("ForwardRate", "");
            dic.Add("SpotRate", "");
            dic.Add("AddRow", "click");
            pInterestRate._PopVerify_TimeBased(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("NumberOfYears", "99");
            dic.Add("Rate", "5.0");
            pInterestRate._TimeBased_Table(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "CV Interest Rate");
            dic.Add("Level_3", "Solvency,WindUp");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "CV Interest Rate");
            dic.Add("Level_3", "Solvency,WindUp");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "4.5");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "click");
            dic.Add("txtLocalEligibility", "Over55orInactive");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$valage >= 55 or $emp.ParticipantStatus = \"IN\"");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Annuity Interest Rate");
            dic.Add("Level_3", "Solvency,WindUp");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "4.5");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "CV Cost of Living Increase");
            dic.Add("Level_3", "Solvency,WindUp");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "true");
            dic.Add("Rate", "");
            pInterestRate._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AsOfDate", "01/01/2008");
            dic.Add("ForActuarialEquivalence", "");
            dic.Add("ForwardRate", "");
            dic.Add("SpotRate", "");
            dic.Add("AddRow", "click");
            pInterestRate._PopVerify_TimeBased(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("NumberOfYears", "10");
            dic.Add("Rate", "1.94");
            pInterestRate._TimeBased_Table(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AsOfDate", "");
            dic.Add("ForActuarialEquivalence", "");
            dic.Add("ForwardRate", "");
            dic.Add("SpotRate", "");
            dic.Add("AddRow", "click");
            pInterestRate._PopVerify_TimeBased(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("NumberOfYears", "99");
            dic.Add("Rate", "2.13");
            pInterestRate._TimeBased_Table(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Defined Benefit Limit Increase");
            dic.Add("Level_3", "Solvency,WindUp");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("V", "");
            dic.Add("Percent", "click");
            dic.Add("T", "");
            dic.Add("txtRate", "3.0");
            pDefinedBenefitLimitIncrease._PopVerify_DefinedBenefitLimitIncrease(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Solvency,WindUp");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ApplyPercentMarriedAt", "Primary decrement");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "75.0");
            dic.Add("txtPercentMarried_F", "75.0");
            dic.Add("cboPercentMarried", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "-3");
            dic.Add("txtDifferenceInSpouseAge_F", "3");
            dic.Add("cboDifferenceInSpouseAge", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Lump Sum Election Rate");
            dic.Add("Level_3", "Solvency,WindUp");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("V", "");
            dic.Add("Percent", "click");
            dic.Add("T", "");
            dic.Add("txtRate", "100.00");
            pDefinedBenefitLimitIncrease._PopVerify_DefinedBenefitLimitIncrease(dic);

            pMain._Home_ToolbarClick_Top(true);


            pAssumptions._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            pAssumptions._Collapse(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Average YMPE");
            dic.Add("MenuItem", "Add Average YMPE");
            pAssumptions._TreeViewRightSelect(dic, "Avg3YMPE");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Average YMPE");
            dic.Add("Level_4", "Avg3YMPE");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("ReadAverageYMPEFromData", "");
            dic.Add("CustomCode", "");
            dic.Add("YMPEDefinitionToAverage", "YMPEProj");
            dic.Add("DataFieldContainAverageYMPE", "");
            dic.Add("AveragingPeriod", "");
            dic.Add("IncludeExitYearInAverage", "");
            pAverageYMPE._PopVerify_AverageYMPE(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "C/QPP");
            dic.Add("MenuItem", "Add C/QPP");
            pAssumptions._TreeViewRightSelect(dic, "NewCQPP1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "C/QPP");
            dic.Add("Level_4", "NewCQPP1");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            _gLib._MsgBox("", "please set 'Lay year opton' to 'Pre-2019 law'");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("ReadAverageYMPEFromData", "");
            dic.Add("CustomCode", "");
            dic.Add("YMPEDefinitionToAverage", "YMPEProj");
            dic.Add("DataFieldContainAverageYMPE", "");
            dic.Add("AveragingPeriod", "");
            dic.Add("IncludeExitYearInAverage", "");
            pAverageYMPE._PopVerify_AverageYMPE(dic);



            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "PlanFAE");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "FAE Formula");
            dic.Add("Level_4", "PlanFAE");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FAE3");
            dic.Add("Service", "Credited");
            dic.Add("ServiceLimitTo", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "click");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_TXT", "");
            dic.Add("RateTiersBasedOn", "");
            dic.Add("NumberOfRateTiers", "");
            dic.Add("IntegrationType", "Excess");
            dic.Add("NumberOfBreakPoints", "");
            pFAEFormula._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iNumOfBreakpoints", "1");
            dic.Add("btnC", "");
            dic.Add("btnV", "click");
            dic.Add("sData2", "Avg3YMPE");
            dic.Add("sData3", "0.013");
            pFAEFormula._TBL_Excess(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iNumOfBreakpoints", "1");
            dic.Add("btnC", "");
            dic.Add("btnV", "");
            dic.Add("sData2", "");
            dic.Add("sData3", "0.0175");
            pFAEFormula._TBL_Excess(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "FAE Formula");
            dic.Add("Level_4", "PlanFAE");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "FAE Formula");
            dic.Add("Level_4", "PlanFAE");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FAE3");
            dic.Add("Service", "Credited");
            dic.Add("ServiceLimitTo", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_TXT", "");
            dic.Add("RateTiersBasedOn", "");
            dic.Add("NumberOfRateTiers", "");
            dic.Add("IntegrationType", "Excess");
            dic.Add("NumberOfBreakPoints", "");
            pFAEFormula._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iNumOfBreakpoints", "1");
            dic.Add("btnC", "");
            dic.Add("btnV", "click");
            dic.Add("sData2", "Avg3YMPE");
            dic.Add("sData3", "0.014");
            pFAEFormula._TBL_Excess(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iNumOfBreakpoints", "1");
            dic.Add("btnC", "");
            dic.Add("btnV", "");
            dic.Add("sData2", "");
            dic.Add("sData3", "0.02");
            pFAEFormula._TBL_Excess(dic);

            ////////_gLib._MsgBox("Mannual Steps", "input <0.02> in row 2 and col 3");
            //////////////////  pFAEFormula._TBL_NonIntegrated(2, 2, 1, "0.02");

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "click");
            dic.Add("cboPreDefinedEligibility", "Desig");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "PlanFormula");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "FAE Formula");
            dic.Add("Level_4", "PlanFormula");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$PlanFAE - $emp.PriorPension");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Employee Contributions Formula");
            dic.Add("MenuItem", "Add Employee Contributions Formula");
            pAssumptions._TreeViewRightSelect(dic, "EEContributions");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Employee Contributions Formula");
            dic.Add("Level_4", "EEContributions");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "click");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "ContribsWInterest1");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "");
            dic.Add("StopContributionAt_C", "click");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "click");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "click");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "3500.00");
            dic.Add("RateForYear_V", "click");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "click");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "Accum");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "ProjectedPay");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "Excess");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);


            //////////////_gLib._MsgBox("Mannual Steps", "In BreakPoint1 click <V> and select <YMPEProj> ");

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iNumOfBreakpoints", "1");
            dic.Add("btnC", "");
            dic.Add("btnV", "click");
            dic.Add("sData2", "YMPEProj");
            dic.Add("sData3", "0.02");
            dic.Add("isEmployeeContributionsFormula", "true");
            pFAEFormula._TBL_Excess(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iNumOfBreakpoints", "1");
            dic.Add("btnC", "");
            dic.Add("btnV", "");
            dic.Add("sData2", "");
            dic.Add("sData3", "0.05");
            pFAEFormula._TBL_Excess(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "Post2001Benefit");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "Post2001Benefit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$PlanFormula*Min($Post2001,$Credited)/$Credited");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            pAssumptions._Collapse(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "HalfCOLA");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Cost of Living Adjustments");
            dic.Add("Level_3", "HalfCOLA");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Cost of Living Adjustments");
            dic.Add("Level_3", "HalfCOLA");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("COLA_End", "true");
            dic.Add("COLA_DuringDeferral", "true");
            dic.Add("COLA_End_Age", "true");
            dic.Add("COLA_End_Age_txt", "55");
            dic.Add("COLA_During_V", "Click");
            dic.Add("COLA_During_Rate_cbo_V", "CostOfLivingIncreaseAssumption");
            dic.Add("COLA_During_LoadingFactor", "50.00");
            pCostOfLivingAdjustments._COLAEnd_And_COLADuringDeferral_CA(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "Quebec");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("MenuItem", "Add Actuarial Equivalence");
            pAssumptions._TreeViewRightSelect(dic, "ValnBasis");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("Level_3", "ValnBasis");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValuationInterest", "");
            dic.Add("ValuationMortality", "");
            dic.Add("ValuationCOLA", "Click");
            dic.Add("ValuationSpouseAgeDiff", "");
            pActuarialEquivalence._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValuationInterest", "True");
            dic.Add("ValuationMortality", "True");
            dic.Add("ValuationCOLA", "false");
            dic.Add("ValuationSpouseAgeDiff", "");
            pActuarialEquivalence._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Early Retirement Factors");
            dic.Add("MenuItem", "Add Early Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "PlanRedn");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Early Retirement Factors");
            dic.Add("Level_3", "PlanRedn");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "");
            dic.Add("Button_C", "Click");
            dic.Add("AgeAtWhichReductionEnds_cbo", "");
            dic.Add("AgeAtWhichReductionEnds_txt", "62");
            pEarlyRetirementFactor._PopVerify_AgeYearInterval(dic);

            pEarlyRetirementFactor._TBL_ReductionDefinition(1, "55", "3.0");



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Early Retirement Factors");
            dic.Add("MenuItem", "Add Early Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "ITARedn");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Early Retirement Factors");
            dic.Add("Level_3", "ITARedn");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Early Retirement Factors");
            dic.Add("Level_3", "ITARedn");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "Click");
            dic.Add("Button_C", "");
            dic.Add("AgeAtWhichReductionEnds_cbo", "Age306080");
            dic.Add("AgeAtWhichReductionEnds_txt", "");
            pEarlyRetirementFactor._PopVerify_AgeYearInterval(dic);

            pEarlyRetirementFactor._TBL_ReductionDefinition(1, "55", "3.0");

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "From55");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Early Retirement Factors");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("MenuItem", "Add Conversion Factors");
            pAssumptions._TreeViewRightSelect(dic, "JS60to50");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("Level_3", "JS60to50");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType_From", "Joint and survivor");
            dic.Add("MortalityInDeferralPeriod_From", "");
            dic.Add("ActuarialEquivalence_From", "ValnBasis");
            dic.Add("ApplySpouseAgeDifference_From", "true");

            dic.Add("FormOfPaymentType_To", "Joint and survivor");
            dic.Add("MortalityInDeferralPeriod_To", "");
            dic.Add("ActuarialEquivalence_To", "ValnBasis");
            dic.Add("ApplySpouseAgeDifference_To", "true");

            dic.Add("btnGuaranteePeriod_From_V", "");
            dic.Add("GuaranteePeriod_From_cbo", "");
            dic.Add("btnGuaranteePeriod_From_C", "Click");
            dic.Add("GuaranteePeriod_From_txt", "");

            dic.Add("btnSurvivorPercentage_From_V", "");
            dic.Add("SurvivorPercentage_From_cbo", "");
            dic.Add("btnSurvivorPercentage_From_Percent", "click");
            dic.Add("SurvivorPercentage_From_txt", "60.0");

            dic.Add("btnPopupAmount_From_V", "");
            dic.Add("PopupAmount_From_cbo", "");
            dic.Add("btnPopupAmount_From_C", "Click");
            dic.Add("PopupAmount_From_txt", "");

            dic.Add("btnBenefitCommenceAge_From_V", "");
            dic.Add("BenefitCommenceAge_From_cbo", "");
            dic.Add("btnBenefitCommenceAge_From_C", "Click");
            dic.Add("BenefitCommenceAge_From_txt", "55");

            dic.Add("btnBenefitStopAge_From_V", "");
            dic.Add("BenefitStopAge_From_cbo", "");
            dic.Add("btnBenefitStopAge_From_C", "Click");
            dic.Add("BenefitStopAge_From_txt", "");

            dic.Add("btnNumberOfPaymentsPerYear_From_V", "");
            dic.Add("NumberOfPaymentsPerYear_From_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_From_C", "Click");
            dic.Add("NumberOfPaymentsPerYear_From_txt", "");

            dic.Add("btnGuaranteePeriod_To_V", "");
            dic.Add("GuaranteePeriod_To_cbo", "");
            dic.Add("btnGuaranteePeriod_To_C", "Click");
            dic.Add("GuaranteePeriod_To_txt", "");

            dic.Add("btnSurvivorPercentage_To_V", "");
            dic.Add("SurvivorPercentage_To_cbo", "");
            dic.Add("btnSurvivorPercentage_To_Percent", "Click");
            dic.Add("SurvivorPercentage_To_txt", "50.0");

            dic.Add("btnPopupAmount_To_V", "");
            dic.Add("PopupAmount_To_cbo", "");
            dic.Add("btnPopupAmount_To_C", "Click");
            dic.Add("PopupAmount_To_txt", "");

            dic.Add("btnBenefitCommenceAge_To_V", "");
            dic.Add("BenefitCommenceAge_To_cbo", "");
            dic.Add("btnBenefitCommenceAge_To_C", "Click");
            dic.Add("BenefitCommenceAge_To_txt", "55");

            dic.Add("btnBenefitStopAge_To_V", "");
            dic.Add("BenefitStopAge_To_cbo", "");
            dic.Add("btnBenefitStopAge_To_C", "Click");
            dic.Add("BenefitStopAge_To_txt", "");

            dic.Add("btnNumberOfPaymentsPerYear_To_V", "");
            dic.Add("NumberOfPaymentsPerYear_To_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_To_C", "");
            dic.Add("NumberOfPaymentsPerYear_To_txt", "");
            pConversionFactors._PopVerify_Standard(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "LifeOnly");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "JS60");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "JS60");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Joint and survivor");
            dic.Add("MortalityInReferralPeriod", "");


            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "click");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");

            dic.Add("btnSurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "click");
            dic.Add("SurvivorPercentOrAmount_txt", "60.0");
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
            pAssumptions._TreeViewRightSelect(dic, "LumpSum");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "LumpSum");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Lump sum");
            dic.Add("MortalityInReferralPeriod", "");

            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "click");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");

            dic.Add("btnSurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "");
            dic.Add("SurvivorPercentOrAmount_txt", "60.0");
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
            pAssumptions._TreeViewRightSelect(dic, "Spouse");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "Spouse");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Spouse's");
            dic.Add("MortalityInReferralPeriod", "");

            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "click");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");

            dic.Add("btnSurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "click");
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
            pAssumptions._TreeViewRightSelect(dic, "Inactive");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "Inactive");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Joint and survivor");
            dic.Add("MortalityInReferralPeriod", "");

            dic.Add("btnGuaranteePeriod_V", "click");
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



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "Inactive");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "Inactive");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "");
            dic.Add("MortalityInReferralPeriod", "");

            dic.Add("btnGuaranteePeriod_V", "click");
            dic.Add("GuaranteePeriod_cbo", "YearsCertain1");
            dic.Add("btnGuaranteePeriod_C", "");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");

            dic.Add("btnSurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
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
            dic.Add("LocalEligibility", "click");
            dic.Add("txtLocalEligibility", "Life");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.PayMentform1 = \"AN\"");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            pAssumptions._Collapse(dic);


            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "ITA Maximum Pensions");
            dic.Add("MenuItem", "Add ITA Maximum Pensions");
            pAssumptions._TreeViewRightSelect(dic, "MaxRet");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "ITA Maximum Pensions");
            dic.Add("Level_3", "MaxRet");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("StartingAmount_C", "");
            dic.Add("StartingAmount_T", "");
            dic.Add("StartingAmount_cbo", "");
            dic.Add("ProjectFrom_cbo", "");
            dic.Add("ProjectFrom_txt", "");
            dic.Add("PayAverage", "");
            dic.Add("MaximumBridge", "False");
            dic.Add("CQPPDefinition", "");
            dic.Add("UserDefinedProjection", "");
            dic.Add("CombinedMaximum", "False");
            dic.Add("3YearAverageYMPE", "");
            dic.Add("ServiceForCalculation", "Credited");
            dic.Add("DeferralOptions", "");
            pITAMaximumPensions._PopVerify_Standard(dic);


            ////////////////            oParam.Add "MaximumBridge" , "OFF"
            ////////////////oParam.Add "CombinedMaximum" , "OFF"
            ////////////////oParam.Add "ServiceForCalculations" , "Credited"

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "ITA Maximum Pensions");
            dic.Add("MenuItem", "Add ITA Maximum Pensions");
            pAssumptions._TreeViewRightSelect(dic, "MaxTerm");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "ITA Maximum Pensions");
            dic.Add("Level_3", "MaxTerm");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("StartingAmount_C", "");
            dic.Add("StartingAmount_T", "");
            dic.Add("StartingAmount_cbo", "");
            dic.Add("ProjectFrom_cbo", "");
            dic.Add("ProjectFrom_txt", "");
            dic.Add("PayAverage", "");
            dic.Add("MaximumBridge", "False");
            dic.Add("CQPPDefinition", "");
            dic.Add("UserDefinedProjection", "");
            dic.Add("CombinedMaximum", "False");
            dic.Add("3YearAverageYMPE", "");
            dic.Add("ServiceForCalculation", "Post2001");
            dic.Add("DeferralOptions", "Use values at commencement");
            dic.Add("DeferralOptions_C", "click");
            pITAMaximumPensions._PopVerify_Standard(dic);


            //////////////oParam.Add "MaximumBridge" , "OFF"
            //////////////oParam.Add "CombinedMaximum" , "OFF"
            //////////////oParam.Add "ServiceForCalculations" , "Post2001"
            //////////////oParam.Add "DeferralOptions" , "Use values at commencement"
            //////////////oParam.Add "DeferralOptions_C" , "Click"



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "ITA Maximum Pensions");
            dic.Add("MenuItem", "Add ITA Maximum Pensions");
            pAssumptions._TreeViewRightSelect(dic, "Post2001Max");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "ITA Maximum Pensions");
            dic.Add("Level_3", "Post2001Max");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "");
            dic.Add("Expression", "$MaxTerm*Min($Post2001,$Credited)/$Credited");
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
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Adjustments");
            dic.Add("MenuItem", "Add Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "Single");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Adjustments");
            dic.Add("Level_3", "Single");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LoadingFactor_V", "");
            dic.Add("LoadingFactor_C", "Click");
            dic.Add("LoadingFactor_T", "");
            dic.Add("LoadingFactor_cboV", "");
            dic.Add("LoadingFactor_txt", "0.25");
            dic.Add("LoadingFactor_cboT", "");
            dic.Add("ApplyTo", "");
            pAdjustments._PopVerify_Main(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Adjustments");
            dic.Add("MenuItem", "Add Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "Negative");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Adjustments");
            dic.Add("Level_3", "Negative");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LoadingFactor_V", "");
            dic.Add("LoadingFactor_C", "Click");
            dic.Add("LoadingFactor_T", "");
            dic.Add("LoadingFactor_cboV", "");
            dic.Add("LoadingFactor_txt", "-1.0");
            dic.Add("LoadingFactor_cboT", "");
            dic.Add("ApplyTo", "Benefit before maximum");
            pAdjustments._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            pAssumptions._Collapse(dic);


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Max Pension Definition");
            dic.Add("MenuItem", "Add Max Pension Definition");
            pAssumptions._TreeViewRightSelect(dic, "MaxPension");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Max Pension Definition");
            dic.Add("Level_3", "MaxPension");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("MaximumPensionFormula", "");
            dic.Add("EarlyRetirementFactors", "ITARedn");
            dic.Add("LifeConversionFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("ERFForAgeReduction", "");
            dic.Add("BridgeConversionFactors", "");
            dic.Add("AppliesToAllBenefits", "");
            pMaxPensionDefinition._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PVRet");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVRet");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "click");

            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
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
            dic.Add("FormOfPayment", "LumpSum");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single_CA", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Retirement");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVRet");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVRet");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "true");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "PlanFormula");
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
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "PlanRedn");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "JS60");
            dic.Add("FormOfPayment_Single", "LifeOnly");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single_CA", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "MaxPension");
            dic.Add("MaximumBenefitLimitation_Single", "MaxPension");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "From55");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PVPost2001l");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVPost2001l");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "true");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "Post2001Benefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");

            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");

            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "HalfCOLA");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "JS60");
            dic.Add("FormOfPayment_Single", "LifeOnly");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single_CA", "");
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
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PVPost2001Nl");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVPost2001Nl");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "true");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "Post2001Benefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");

            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "click");
            dic.Add("BenefitCommenceAge_txt", "65");

            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "Negative");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "JS60");
            dic.Add("FormOfPayment_Single", "LifeOnly");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single_CA", "");
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
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PVPost2001");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVPost2001");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "true");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "true");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "Max(0,$PVPost2001l+$PVPost2001Nl)");
            dic.Add("Validate", "click");

            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "click");
            dic.Add("BenefitCommenceAge_txt", "65");

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
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "JS60");
            dic.Add("FormOfPayment_Single", "LifeOnly");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single_CA", "");
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
            dic.Add("Level_3", "PVPost2001");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVPost2001");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "true");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "click");

            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
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
            dic.Add("FormOfPayment", "LumpSum");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single_CA", "");
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
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "From55");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);




            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PVTerm");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVTerm");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "true");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "PlanFormula");
            dic.Add("Function", "");
            dic.Add("Validate", "");

            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "click");
            dic.Add("BenefitCommenceAge_txt", "65");

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
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "JS60");
            dic.Add("FormOfPayment_Single", "LifeOnly");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single_CA", "");
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
            dic.Add("Level_3", "PVTerm");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVTerm");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "true");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "click");

            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
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
            dic.Add("FormOfPayment", "LumpSum");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single_CA", "");
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
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "From55");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PVDeathDefd");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVDeathDefd");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "true");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "PlanFormula");
            dic.Add("Function", "");
            dic.Add("Validate", "");

            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "click");
            dic.Add("BenefitCommenceAge_txt", "65");

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
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "JS60");
            dic.Add("FormOfPayment_Single", "LifeOnly");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single_CA", "");
            dic.Add("MaximumBenefitLimitation", "");
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
            dic.Add("Level_3", "PVDeathDefd");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVDeathDefd");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "true");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "PlanFormula");
            dic.Add("Function", "");
            dic.Add("Validate", "");

            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "click");
            dic.Add("BenefitCommenceAge_txt", "65");

            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "Single");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "JS60");
            dic.Add("FormOfPayment_Single", "LifeOnly");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single_CA", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "MaxPension");
            dic.Add("MaximumBenefitLimitation_Single", "MaxPension");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "From55");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PVPost2001Death");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVPost2001Death");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "true");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "true");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "Max(0,$PVPost2001l+$PVPost2001Nl)");
            dic.Add("Validate", "click");

            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "click");
            dic.Add("BenefitCommenceAge_txt", "65");

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
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "JS60");
            dic.Add("FormOfPayment_Single", "LifeOnly");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single_CA", "");
            dic.Add("MaximumBenefitLimitation", "");
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
            dic.Add("Level_3", "PVPost2001Death");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVPost2001Death");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "true");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "click");

            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
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
            dic.Add("FormOfPayment", "LumpSum");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single_CA", "");
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
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "From55");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PVSpouse");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVSpouse");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "true");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "click");

            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
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
            dic.Add("FormOfPayment", "LumpSum");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single_CA", "");
            dic.Add("MaximumBenefitLimitation", "");
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
            dic.Add("Level_3", "PVSpouse");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVSpouse");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "PlanFormula");
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
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "PlanRedn");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "JS60to50");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "Spouse");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single_CA", "");
            dic.Add("MaximumBenefitLimitation", "MaxPension");
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
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "From55");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Excess Contribution Definition");
            pAssumptions._TreeViewRightSelect(dic, "ExcessConts");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "ExcessConts");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayAsLumpSum", "");
            dic.Add("IncreaseBenefit", "");
            dic.Add("Actives", "");
            dic.Add("DeferredInactives", "");
            dic.Add("PercentCovered", "50.000");
            dic.Add("ContributionDefinition", "EEContributions");
            pExcessContributionDefinition._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("Name_1", "PVPost2001");
            dic.Add("Name_1_Status", "True");
            dic.Add("Name_2", "PVPost2001l");
            dic.Add("Name_2_Status", "");
            dic.Add("Name_3", "PVPost2001Nl");
            dic.Add("Name_3_Status", "");
            dic.Add("Name_4", "PVTerm");
            dic.Add("Name_4_Status", "true");
            pExcessContributionDefinition._Withdrawal(dic);

            dic.Clear();
            dic.Add("Name_1", "PVDeathDefd");
            dic.Add("Name_1_Status", "True");
            dic.Add("Name_2", "PVPost2001Death");
            dic.Add("Name_2_Status", "true");
            dic.Add("Name_3", "PVSpouse");
            dic.Add("Name_3_Status", "");
            pExcessContributionDefinition._Mortality(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "InactiveBridge");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "InactiveBridge");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "All inactives");
            dic.Add("SingleFormulaBenefit", "Bridge");
            dic.Add("Function", "");
            dic.Add("Validate", "");

            dic.Add("btnBenefitCommenceAge_V", "click");
            dic.Add("BenefitCommenceAge_cbo", "StartDate1");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");

            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "click");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "LifeOnly");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single_CA", "");
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
            pAssumptions._TreeViewRightSelect(dic, "Deferred");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Deferred");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "true");
            dic.Add("ParticipantType", "Deferred inactives");
            dic.Add("SingleFormulaBenefit", "AccruedBenefit1");
            dic.Add("Function", "");
            dic.Add("Validate", "");

            dic.Add("btnBenefitCommenceAge_V", "click");
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
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "JS60");
            dic.Add("FormOfPayment_Single", "LifeOnly");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single_CA", "");
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
            pAssumptions._TreeViewRightSelect(dic, "InPayInactives");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "InPayInactives");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "In pay inactives");
            dic.Add("SingleFormulaBenefit", "AccruedBenefit1");
            dic.Add("Function", "");
            dic.Add("Validate", "");

            dic.Add("btnBenefitCommenceAge_V", "click");
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
            dic.Add("FormOfPayment", "Inactive");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single_CA", "");
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
            dic.Add("Level_3", "InPayInactives");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "InPayInactives");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "AccruedBenefit1");
            dic.Add("Function", "");
            dic.Add("Validate", "");

            dic.Add("btnBenefitCommenceAge_V", "click");
            dic.Add("BenefitCommenceAge_cbo", "StartDate1");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");

            dic.Add("btnBenefitStopAge_V", "click");
            dic.Add("BenefitStopAge_cbo", "StopDate");
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
            dic.Add("FormOfPayment", "Inactive");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single_CA", "");
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
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "StopPension");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Excess Contribution Definition");
            pAssumptions._TreeViewRightSelect(dic, "SolvencyExcess");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "SolvencyExcess");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayAsLumpSum", "");
            dic.Add("IncreaseBenefit", "");
            dic.Add("Actives", "");
            dic.Add("DeferredInactives", "");
            dic.Add("PercentCovered", "50.000");
            dic.Add("ContributionDefinition", "EEContributions");
            pExcessContributionDefinition._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("Name_1", "PVRet");
            dic.Add("Name_1_Status", "True");
            dic.Add("Name_2", "");
            dic.Add("Name_2_Status", "");
            dic.Add("Name_3", "");
            dic.Add("Name_3_Status", "");
            pExcessContributionDefinition._Retirement(dic);

            dic.Clear();
            dic.Add("Name_1", "PVPost2001");
            dic.Add("Name_1_Status", "");
            dic.Add("Name_2", "PVPost2001l");
            dic.Add("Name_2_Status", "");
            dic.Add("Name_3", "PVPost2001Nl");
            dic.Add("Name_3_Status", "");
            dic.Add("Name_4", "PVTerm");
            dic.Add("Name_4_Status", "true");
            pExcessContributionDefinition._Withdrawal(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Funding - Funding2008 - Methods & TestCases & Reports

            pMain._SelectTab("Funding2008");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMethods._SelectTab("Going Concern");


            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("sName", "PVPost2001");
            dic.Add("sStatus", "False");
            pMethods._BenefitsToInclude_GoingConcern(dic);

            dic.Clear();
            dic.Add("iRow", "13");
            dic.Add("sName", "SolvencyExcess");
            dic.Add("sStatus", "False");
            pMethods._BenefitsToInclude_GoingConcern(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "");
            dic.Add("ServiceForServiceProrate", "Credited");
            dic.Add("CompareToAccrue", "false");
            dic.Add("AllowNegativeNormalCost", "true");
            dic.Add("NormalCostForCYTermination", "Yes");
            dic.Add("ProjectedPayToUseForCoveredPay", "ProjectedPay");
            dic.Add("AccumulationToUseForExepctedPVOfEmployee", "EEContributions");
            dic.Add("IncludeChangesInPVFutureEEGainLoss", "false");
            dic.Add("AccumulationToUseForExepctedPVOfEmployer", "");
            dic.Add("BeginningOfTheYearPVFuture", "false");
            dic.Add("StopPVFuture_V", "");
            dic.Add("StopPVFuture_cbo", "$FullRetAge");
            pMethods._PopVerify_Methods_Funding_GoningConcern(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMethods._SelectTab("Solvency");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CalculateGrowInAndMax", "");
            dic.Add("CalculateMax", "");
            dic.Add("NoGrowInOrMax", "");
            dic.Add("Age", "$ValAge");
            dic.Add("Service", "Continuous");
            dic.Add("AddtionalEligibilityCondition", "Ontario");
            dic.Add("StartAge", "Age55");
            dic.Add("StopAge", "NRA65");
            dic.Add("PerformMaximumValueTest", "");
            dic.Add("AdditionalOptionForExcessContribution", "");
            dic.Add("NumOfYearsIncrementalCost", "3");
            pMethods._PopVerify_Methods_Funding_SolvencyWindUp(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("sName", "PVRet");
            dic.Add("sBenefitForCalculation", "true");
            dic.Add("sImmediateVesting", "False");
            dic.Add("sCOLA", "true");
            pMethods._BenefitsToValueForSolvency(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("sName", "PVPost2001");
            dic.Add("sBenefitForCalculation", "false");
            dic.Add("sImmediateVesting", "");
            dic.Add("sCOLA", "");
            pMethods._BenefitsToValueForSolvency(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("sName", "PVPost2001l");
            dic.Add("sBenefitForCalculation", "true");
            dic.Add("sImmediateVesting", "False");
            dic.Add("sCOLA", "true");
            pMethods._BenefitsToValueForSolvency(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("sName", "PVPost2001Nl");
            dic.Add("sBenefitForCalculation", "true");
            dic.Add("sImmediateVesting", "False");
            dic.Add("sCOLA", "true");
            pMethods._BenefitsToValueForSolvency(dic);

            dic.Clear();
            dic.Add("iRow", "5");
            dic.Add("sName", "PVTerm");
            dic.Add("sBenefitForCalculation", "true");
            dic.Add("sImmediateVesting", "False");
            dic.Add("sCOLA", "true");
            pMethods._BenefitsToValueForSolvency(dic);

            dic.Clear();
            dic.Add("iRow", "6");
            dic.Add("sName", "Deferred");
            dic.Add("sBenefitForCalculation", "true");
            dic.Add("sImmediateVesting", "False");
            dic.Add("sCOLA", "true");
            pMethods._BenefitsToValueForSolvency(dic);

            dic.Clear();
            dic.Add("iRow", "7");
            dic.Add("sName", "InactiveBridge");
            dic.Add("sBenefitForCalculation", "true");
            dic.Add("sImmediateVesting", "False");
            dic.Add("sCOLA", "true");
            pMethods._BenefitsToValueForSolvency(dic);

            dic.Clear();
            dic.Add("iRow", "8");
            dic.Add("sName", "InPayInactives");
            dic.Add("sBenefitForCalculation", "true");
            dic.Add("sImmediateVesting", "False");
            dic.Add("sCOLA", "true");
            pMethods._BenefitsToValueForSolvency(dic);

            dic.Clear();
            dic.Add("iRow", "9");
            dic.Add("sName", "ExcessConts");
            dic.Add("sBenefitForCalculation", "False");
            dic.Add("sImmediateVesting", "");
            dic.Add("sCOLA", "");
            pMethods._BenefitsToValueForSolvency(dic);

            dic.Clear();
            dic.Add("iRow", "10");
            dic.Add("sName", "SolvencyExcess");
            dic.Add("sBenefitForCalculation", "true");
            dic.Add("sImmediateVesting", "False");
            dic.Add("sCOLA", "true");
            pMethods._BenefitsToValueForSolvency(dic);


            pMain._Home_ToolbarClick_Top(true);

            pMethods._SelectTab("Windup");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CalculateGrowInAndMax", "");
            dic.Add("CalculateMax", "");
            dic.Add("NoGrowInOrMax", "");
            dic.Add("Age", "");
            dic.Add("Service", "");
            dic.Add("AddtionalEligibilityCondition", "");
            dic.Add("StartAge", "Age55");
            dic.Add("StopAge", "NRA65");
            dic.Add("PerformMaximumValueTest", "");
            dic.Add("AdditionalOptionForExcessContribution", "");
            dic.Add("NumOfYearsIncrementalCost", "3");
            pMethods._PopVerify_Methods_Funding_SolvencyWindUp(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("sName", "PVRet");
            dic.Add("sBenefitForCalculation", "true");
            dic.Add("sImmediateVesting", "true");
            dic.Add("sCOLA", "true");
            pMethods._BenefitsToValueForWindUp(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("sName", "PVPost2001");
            dic.Add("sBenefitForCalculation", "False");
            dic.Add("sImmediateVesting", "");
            dic.Add("sCOLA", "");
            pMethods._BenefitsToValueForWindUp(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("sName", "PVPost2001l");
            dic.Add("sBenefitForCalculation", "true");
            dic.Add("sImmediateVesting", "False");
            dic.Add("sCOLA", "true");
            pMethods._BenefitsToValueForWindUp(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("sName", "PVPost2001Nl");
            dic.Add("sBenefitForCalculation", "true");
            dic.Add("sImmediateVesting", "False");
            dic.Add("sCOLA", "False");
            pMethods._BenefitsToValueForWindUp(dic);

            dic.Clear();
            dic.Add("iRow", "5");
            dic.Add("sName", "PVTerm");
            dic.Add("sBenefitForCalculation", "true");
            dic.Add("sImmediateVesting", "False");
            dic.Add("sCOLA", "False");
            pMethods._BenefitsToValueForWindUp(dic);

            dic.Clear();
            dic.Add("iRow", "6");
            dic.Add("sName", "Deferred");
            dic.Add("sBenefitForCalculation", "true");
            dic.Add("sImmediateVesting", "False");
            dic.Add("sCOLA", "False");
            pMethods._BenefitsToValueForWindUp(dic);

            dic.Clear();
            dic.Add("iRow", "7");
            dic.Add("sName", "InactiveBridge");
            dic.Add("sBenefitForCalculation", "true");
            dic.Add("sImmediateVesting", "False");
            dic.Add("sCOLA", "False");
            pMethods._BenefitsToValueForWindUp(dic);

            dic.Clear();
            dic.Add("iRow", "8");
            dic.Add("sName", "InPayInactives");
            dic.Add("sBenefitForCalculation", "true");
            dic.Add("sImmediateVesting", "False");
            dic.Add("sCOLA", "False");
            pMethods._BenefitsToValueForWindUp(dic);

            dic.Clear();
            dic.Add("iRow", "9");
            dic.Add("sName", "ExcessConts");
            dic.Add("sBenefitForCalculation", "False");
            dic.Add("sImmediateVesting", "");
            dic.Add("sCOLA", "");
            pMethods._BenefitsToValueForWindUp(dic);

            dic.Clear();
            dic.Add("iRow", "10");
            dic.Add("sName", "SolvencyExcess");
            dic.Add("sBenefitForCalculation", "true");
            dic.Add("sImmediateVesting", "False");
            dic.Add("sCOLA", "False");
            pMethods._BenefitsToValueForWindUp(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Funding2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"05/06/1966\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"08/15/1961\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Funding2008");


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
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("CalcIncreCostSolvencyWindup", "");
            dic.Add("Service", "Credited");
            dic.Add("Pay", "ProjectedPay");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "EEContributions");
            dic.Add("Pension", "AccruedBenefit1");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "True");
            dic.Add("SolvencyLiability", "True");
            dic.Add("WindUpLiability", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);



            pMain._SelectTab("Funding2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Funding2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Common(sOutputFunding_Funding2008_Baseline, "Valuation Summary", "Conversion", true, true);
            pOutputManager._ExportReport_Others(sOutputFunding_Funding2008_Baseline, "Parameter Print", "Conversion", true, true);



            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputFunding_Funding2008_Baseline, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Funding2008_Baseline, "Liability Summary", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Funding2008_Baseline, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Funding2008_Baseline, "Conversion Diagnostic", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Funding2008_Baseline, "Test Case List", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Funding2008_Baseline, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Funding2008_Baseline, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Payout Projection", "Conversion", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputFunding_Funding2008_Baseline, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Funding2008_Baseline, "Liability Summary", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Funding2008_Baseline, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Funding2008_Baseline, "Conversion Diagnostic", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Funding2008_Baseline, "Test Case List", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Funding2008_Baseline, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Funding2008_Baseline, "Detailed Results by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Funding2008_Baseline, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Funding2008_Baseline, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Funding2008_Baseline, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Payout Projection", "Conversion", false, true);
            }

            thrd_Funding2008_Baseline.Start();


            pMain._SelectTab("Funding2008");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Accounting - Accounting2008


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "Accounting2008");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "2008");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "");
            dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("SelectAllVO", "");
            dic.Add("DeselectAll", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Accounting2008");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Accounting2008");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Data");
            dic.Add("MenuItem_2", "Copy Data...");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceType", "FundingValuations");
            dic.Add("ServiceInstance", "Funding2008");
            dic.Add("iItemIndex", "1");
            dic.Add("OK", "Click");
            pMain._PopVerify_CopyParticipantDataSet(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Accounting2008");
            pMain._PopVerify_Home_RightPane(dic);


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
            dic.Add("ServiceInstance", "Funding2008");
            dic.Add("iTableItemIndex", "2");
            dic.Add("CopyAllParameters", "");
            dic.Add("CopyParameterChanges", "");
            dic.Add("OK", "click");
            pMain._PopVerify_CopyProvisionSet(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Accounting2008");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "AgePlus1");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "AgePlus1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "01/01/2009");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Accounting2008");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "6.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "Accum");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "Accum");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "6.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("MenuItem", "Add Pay Increase");
            pAssumptions._TreeViewRightSelect(dic, "PayInc");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "PayInc");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "click");
            dic.Add("btnT", "");
            dic.Add("txtRate", "4.0");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Cost of Living Increase");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2.5");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Defined Benefit Limit Increase");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("V", "");
            dic.Add("Percent", "click");
            dic.Add("T", "");
            dic.Add("txtRate", "3.0");
            pDefinedBenefitLimitIncrease._PopVerify_DefinedBenefitLimitIncrease(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "YMPE");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("V", "");
            dic.Add("Percent", "click");
            dic.Add("T", "");
            dic.Add("txtRate", "3.0");
            pDefinedBenefitLimitIncrease._PopVerify_DefinedBenefitLimitIncrease(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ApplyPercentMarriedAt", "Primary decrement");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "75.0");
            dic.Add("txtPercentMarried_F", "75.0");
            dic.Add("cboPercentMarried", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "-3");
            dic.Add("txtDifferenceInSpouseAge_F", "3");
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
            dic.Add("Mortality", "UP94S15");
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
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "RETNAC");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "From55");
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
            dic.Add("RetWithdrawDis", "WTHNAC");
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

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "From55");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Accounting2008");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("iRow", "6");
            dic.Add("sName", "PVPost2001");
            dic.Add("sStatus", "False");
            pMethods._BenefitsToInclude_GoingConcern(dic);

            dic.Clear();
            dic.Add("iRow", "13");
            dic.Add("sName", "SolvencyExcess");
            dic.Add("sStatus", "False");
            pMethods._BenefitsToInclude_GoingConcern(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "");
            dic.Add("ServiceForServiceProrate", "Credited");
            dic.Add("CompareToAccrue", "false");
            dic.Add("AllowNegativeNormalCost", "true");
            dic.Add("NormalCostForCYTermination", "Yes");
            dic.Add("GrowIn_Age", "");
            dic.Add("GrowIn_Service", "");
            dic.Add("MaxValue_StartAge", "");
            dic.Add("MaxValue_StopAge", "");
            pMethods._PopVerify_Methods_CA(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "");
            dic.Add("ServiceForServiceProrate", "");
            dic.Add("CompareToAccrue", "");
            dic.Add("AllowNegativeNormalCost", "");
            dic.Add("ProjectedpayToUse", "");
            dic.Add("ProjectedpayToUse_CA", "ProjectedPay");
            dic.Add("AccumulationToUse", "EEContributions");
            dic.Add("IncludeExitYearValue", "false");
            dic.Add("CalculatePresentValueOfFuture", "");
            dic.Add("CalculatePresentValueOfFuture_txt", "");
            dic.Add("VestingToUseForAgeFirstVested", "");
            dic.Add("AverageWorkingLifeTime", "true");
            dic.Add("AverageLifeTime", "");
            dic.Add("AverageWorkingLifeTimeToVesting", "");
            dic.Add("AverageWorkingLifeTimeForBenefitingEE", "false");
            pMethods._PopVerify_Methods_Accounting(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Accounting2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"05/06/1966\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"08/15/1961\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Accounting2008");


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
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "Credited");
            dic.Add("Pay", "ProjectedPay");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "EEContributions");
            dic.Add("Pension", "AccruedBenefit1");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "");
            dic.Add("SolvencyLiability", "");
            dic.Add("WindUpLiability", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Accounting2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Accounting2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Common(sOutputAccounting_Accounting2008, "Valuation Summary", "Conversion", true, false);
            pOutputManager._ExportReport_Others(sOutputAccounting_Accounting2008, "Parameter Print", "Conversion", true, false);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputAccounting_Accounting2008, "Liability Summary", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_Accounting2008, "Liability Summary", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Common(sOutputAccounting_Accounting2008, "Member Statistics", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_Accounting2008, "Conversion Diagnostic", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Others(sOutputAccounting_Accounting2008, "Conversion Diagnostic", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Accounting2008, "Test Case List", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Accounting2008, "Detailed Results", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Accounting2008, "Individual Output", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Accounting2008, "Test Cases", "Conversion", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Accounting2008, "Payout Projection", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Accounting2008, "FAS Expected Benefit Pmts", "Conversion", true, false);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputAccounting_Accounting2008, "Liability Summary", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_Accounting2008, "Liability Summary", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Common(sOutputAccounting_Accounting2008, "Member Statistics", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_Accounting2008, "Conversion Diagnostic", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Others(sOutputAccounting_Accounting2008, "Conversion Diagnostic", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Accounting2008, "Test Case List", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Accounting2008, "Detailed Results", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Accounting2008, "Detailed Results by Plan Def", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Accounting2008, "Valuation Summary", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Accounting2008, "Individual Output", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Accounting2008, "IOE", "Conversion", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Accounting2008, "Payout Projection", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Accounting2008, "FAS Expected Benefit Pmts", "Conversion", false, false);
            }

            thrd_Accounting2008.Start();



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Accounting2008");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            #region Data 2008

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
            dic.Add("Name", "2008 Data");
            dic.Add("EffectiveDate", "01/01/2008");
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
            dic.Add("ServiceToOpen", "2008 Data");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("Level_1", "2008 Data");
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
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\CA001\Data to Upload.xlsx");
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
            dic.Add("Level_1", "2008 Data");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);

            pData._CV_ExpandPersonalInformation();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Service");
            dic.Add("Label", "ServiceToDate");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "6");
            dic.Add("DecimalPlaces", "4");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Pay");
            dic.Add("Label", "ValnPay");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "10");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "Bridge");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "StopDate");
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

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "PriorPension");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Classification Codes");
            dic.Add("Label", "Designated");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Text");
            dic.Add("FieldLength", "20");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Custom Fields");
            dic.Add("Label", "HistoricalFAE3Solvency");
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

            dic.Clear();
            dic.Add("Level_1", "2008 Data");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "All Data");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "DatatoUpload.xlsx");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            //////////////            oParam.Add "SingleTabPerRecordFile_cbo" , "2008 Data"
            //////////////oParam.Add "Preview" , ""
            //////////////oParam.Add "optsReturnParameter" , ""
            //////////////PopVerify_PaticipantData_Imports_SelectFile oParam

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("SingleTabPerRecordFile_cbo", "2008 Data");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


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


            //////////////            Set oParam = CreateObject("Scripting.Dictionary")
            //////////////oParam.Add "optsPopVerify" , "Verify"
            //////////////oParam.Add "optsProperty" , ""
            //////////////oParam.Add "LoadAndValidate" , ""
            //////////////oParam.Add "LoadStatus" , "STAGED"
            //////////////oParam.Add "optsReturnParameter" , ""
            //////////////PopVerify_PaticipantData_Imports_LoadAndValidate oParam

            pMain._Home_ToolbarClick_Top(true);


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
            dic.Add("Unique_NoMatch_Num", "189");
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


            dic.Clear();
            dic.Add("Level_1", "2008 Data");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "USC_FAE");
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
            dic.Add("Level_3", "ParticipantStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PayStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "HealthStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "AliveStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInpuFtFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=DeriveUSC(ParticipantStatus_C,PayStatus_C,HealthStatus_C,AliveStatus_C)");
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
            dic.Add("DerivedField", "HistoricalFAE3Solvency");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Is Act");
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
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "ValnPay");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "ValnPay");
            dic.Add("Level_5", "ValnPayCurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, false, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "6");
            dic.Add("sData", "1");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "6");
            dic.Add("sData", "2");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "6");
            dic.Add("sData", "3");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LARGE(E2:E11,F2)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LARGE(E2:E11,F3)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=LARGE(E2:E11,F4)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "7");
            dic.Add("sData", "");
            dic.Add("sFormula", "=SUM(G2, G3, G4)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "8");
            dic.Add("sData", "");
            dic.Add("sFormula", "=IF(G2>0,1,0)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("iCol", "8");
            dic.Add("sData", "");
            dic.Add("sFormula", "=IF(G3>0,1,0)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("iCol", "8");
            dic.Add("sData", "");
            dic.Add("sFormula", "=IF(G4>0,1,0)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "8");
            dic.Add("sData", "");
            dic.Add("sFormula", "=SUM(H2, H3, H4)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("iCol", "5");
            dic.Add("sData", "");
            dic.Add("sFormula", "=IF(H1=0,0,ROUND(G1/H1,2)");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInpuFtFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            ////dic.Add("Formula", "=IF(H1=0,0,ROUND(G1/H1,2))");
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
            dic.Add("Level_1", "2008 Data");
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Revised ValuationData");
            dic.Add("Filter", "");
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
            dic.Add("Level_3", "ContribsWInterest1");
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
            dic.Add("Level_3", "BridgeAmount");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Bridge");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "StopDate");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "PriorPension");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "DivisionCode");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "Province");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "UnionCode");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "Designated");
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
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Custom Fields");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Revised ValuationData");
            dic.Add("Filter", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "Click");
            dic.Add("PublishSnapshot", "Click");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_SP_Snapshots_Popup(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region  Funding - Funding2008 - New DAMP Node

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Funding2008");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Funding2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "New DAMP Node");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "true");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "true");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "true");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "true");
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
            dic.Add("Snapshot", "true");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("CompareData", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Revised ValuationData");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "true");
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
            dic.Add("ImportDataandApplyMapping", "click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Funding2008");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Benefit Elections");
            dic.Add("MenuItem", "Add Benefit Elections");
            pAssumptions._TreeViewRightSelect(dic, "TerminationLumpSum");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Benefit Elections");
            dic.Add("Level_3", "TerminationLumpSum");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "");
            dic.Add("Button_Percent", "click");
            dic.Add("Button_T", "");
            dic.Add("ElectionPercentage_cbo", "");
            dic.Add("ElectionPercentage_txt", "70.0");
            dic.Add("ElectionTable_cbo", "");
            pBenefitElections._PopVerify_BenefitElections(dic);


            pMethods._SelectTab("Solvency/ Wind-Up");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "CV Interest Rate");
            dic.Add("MenuItem", "Windup same as Solvency");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "CV Interest Rate");
            dic.Add("Level_3", "Windup");
            dic.Add("Level_4", "Over55orInactive");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "CV Interest Rate");
            dic.Add("Level_3", "Windup");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("NumberOfYears", "10");
            dic.Add("Rate", "3.0");
            pInterestRate._TimeBased_Table(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("NumberOfYears", "99");
            dic.Add("Rate", "4.0");
            pInterestRate._TimeBased_Table(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Annuity Interest Rate");
            dic.Add("MenuItem", "Windup same as Solvency");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Annuity Interest Rate");
            dic.Add("Level_3", "WindUp");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Annuity Interest Rate");
            dic.Add("Level_3", "Solvency");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "4.5");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Lump Sum Election Rate");
            dic.Add("MenuItem", "Windup same as Solvency");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Lump Sum Election Rate");
            dic.Add("Level_3", "WindUp");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("V", "");
            dic.Add("Percent", "click");
            dic.Add("T", "");
            dic.Add("txtRate", "80.00");
            pDefinedBenefitLimitIncrease._PopVerify_DefinedBenefitLimitIncrease(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Lump Sum Election Rate");
            dic.Add("Level_3", "WindUp");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Lump Sum Election Rate");
            dic.Add("Level_3", "WindUp");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "20.00");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "From55");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Lump Sum Election Rate");
            dic.Add("Level_3", "Solvency");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "70.00");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Lump Sum Election Rate");
            dic.Add("Level_3", "Solvency");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Lump Sum Election Rate");
            dic.Add("Level_3", "Solvency");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "10.00");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "From55");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            pMain._SelectTab("Funding2008");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "Age306080");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("NoServiceGrowIn", "");
            dic.Add("FreezeServiceAtValuation", "True");
            pFromToAge._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("Level_3", "FAE3");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ApplyAveragePayLimit", "");
            dic.Add("ApplyPayAverageFreezeDefinition", "");
            dic.Add("ApplyAverageAtFutureAge", "");
            dic.Add("UsePayAverageFrom", "True");
            pPayAverage._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "");
            dic.Add("AveragingMethod", "");
            dic.Add("M", "3");
            dic.Add("RoundingForYearOfHire", "");
            dic.Add("DecimalPlacesForYearOfHire", "");
            dic.Add("Include", "");
            dic.Add("DropForCalculations", "");
            dic.Add("DropForCalculationAndPeriodConsidered", "");
            dic.Add("AdjustmentPeriodMonths", "");
            dic.Add("AdjustmentMethod", "");
            dic.Add("FreezePayAverageAtAge_V", "");
            dic.Add("FreezePayAverageAtAge_C", "");
            dic.Add("PayAveragefromdata_cbo", "HistoricalFAE3Solvency");
            pPayAverage._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("MenuItem", "Add Actuarial Equivalence");
            pAssumptions._TreeViewRightSelect(dic, "CVActuarialEquivalence");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("Level_3", "CVActuarialEquivalence");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            ////////////oParam.Add "InterestRate_cbo" , "CVInterestRatePreCommencement"
            ////////////oParam.Add "Mortality_Member" , "UP94S20"
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("cboInterestRate", "CVInterestRatePreCommencement");
            dic.Add("txtInterestRate", "");
            dic.Add("Mortality", "UP94S20");
            pActuarialEquivalence._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVPost2001l");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
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
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "TerminationLumpSum");
            dic.Add("BenefitElectionPercentage_Single_CA", "TerminationLumpSum");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            dic.Add("LumpSumCommutedValue", "true");
            dic.Add("ActuarialEquivalenceForLump", "CVActuarialEquivalence");
            pPlanDefinition._PopVerify_PlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVPost2001Nl");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
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
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "TerminationLumpSum");
            dic.Add("BenefitElectionPercentage_Single_CA", "TerminationLumpSum");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            dic.Add("LumpSumCommutedValue", "true");
            dic.Add("ActuarialEquivalenceForLump", "CVActuarialEquivalence");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVPost2001");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
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
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "TerminationLumpSum");
            dic.Add("BenefitElectionPercentage_Single_CA", "TerminationLumpSum");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            dic.Add("LumpSumCommutedValue", "true");
            dic.Add("ActuarialEquivalenceForLump", "CVActuarialEquivalence");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVTerm");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
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
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "TerminationLumpSum");
            dic.Add("BenefitElectionPercentage_Single_CA", "TerminationLumpSum");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            dic.Add("LumpSumCommutedValue", "true");
            dic.Add("ActuarialEquivalenceForLump", "CVActuarialEquivalence");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            pMain._Home_ToolbarClick_Top(true);




            pMain._SelectTab("Funding2008");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMethods._SelectTab("Solvency");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CalculateGrowInAndMax", "");
            dic.Add("CalculateMax", "");
            dic.Add("NoGrowInOrMax", "");
            dic.Add("Age", "");
            dic.Add("Service", "");
            dic.Add("AddtionalEligibilityCondition", "");
            dic.Add("StartAge", "");
            dic.Add("StopAge", "");
            dic.Add("PerformMaximumValueTest", "");
            dic.Add("AdditionalOptionForExcessContribution", "");
            dic.Add("NumOfYearsIncrementalCost", "3");
            dic.Add("AdditionalElibilityFor10Years", "From55");
            pMethods._PopVerify_Methods_Funding_SolvencyWindUp(dic);

            pMethods._SelectTab("Windup");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CalculateGrowInAndMax", "");
            dic.Add("CalculateMax", "");
            dic.Add("NoGrowInOrMax", "");
            dic.Add("Age", "");
            dic.Add("Service", "");
            dic.Add("AddtionalEligibilityCondition", "");
            dic.Add("StartAge", "");
            dic.Add("StopAge", "");
            dic.Add("PerformMaximumValueTest", "");
            dic.Add("AdditionalOptionForExcessContribution", "");
            dic.Add("NumOfYearsIncrementalCost", "3");
            dic.Add("AdditionalElibilityFor10Years", "From55");
            pMethods._PopVerify_Methods_Funding_SolvencyWindUp(dic);


            pMain._Home_ToolbarClick_Top(true);



            pMain._SelectTab("Funding2008");


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
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "ProjectedPay");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "ContribsWInterest1");
            dic.Add("Pension", "AccruedBenefit1");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "True");
            dic.Add("SolvencyLiability", "True");
            dic.Add("WindUpLiability", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Funding2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Funding2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Common(sOutputFunding_Funding2008_NewDAMP, "Valuation Summary", "Conversion", true, true);
            pOutputManager._ExportReport_Others(sOutputFunding_Funding2008_NewDAMP, "Parameter Print", "Conversion", true, true);



            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputFunding_Funding2008_NewDAMP, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_NewDAMP, "Payout Projection", "Conversion", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2008_NewDAMP, "Reconciliation to Baseline", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Funding2008_NewDAMP, "Liabilities Detailed Results", "Conversion", true, true);

            }

            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_Common(sOutputFunding_Funding2008_NewDAMP, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2008_NewDAMP, "Reconciliation to Baseline", "Conversion", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2008_NewDAMP, "Reconciliation to Baseline by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Funding2008_NewDAMP, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Funding2008_NewDAMP, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_NewDAMP, "Payout Projection", "Conversion", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_NewDAMP, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_NewDAMP, "Detailed Results by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_NewDAMP, "Liabilities Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_NewDAMP, "Liabilities Detailed Results by Plan Def", "Conversion", false, true);

            }

            thrd_Funding2008_NewDAMP.Start();



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Funding2008");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            #region Data2011

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
            dic.Add("Name", "2011 Data");
            dic.Add("EffectiveDate", "01/01/2011");
            dic.Add("Parent", "2008 Data");
            dic.Add("RSC", "True");
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
            dic.Add("ServiceToOpen", "2011 Data");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("Level_1", "2011 Data");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "All Data");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "DatatoUpload.xlsx");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            ////////////            oParam.Add "SingleTabPerRecordFile_cbo" , "2008 Data"
            ////////////oParam.Add "Preview" , ""
            ////////////oParam.Add "optsReturnParameter" , ""
            ////////////PopVerify_PaticipantData_Imports_SelectFile oParam

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("SingleTabPerRecordFile_cbo", "2011 Data");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

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


            //////////            Set oParam = CreateObject("Scripting.Dictionary")
            //////////oParam.Add "optsPopVerify" , "Verify"
            //////////oParam.Add "optsProperty" , ""
            //////////oParam.Add "LoadAndValidate" , ""
            //////////oParam.Add "LoadStatus" , "STAGED"
            //////////oParam.Add "optsReturnParameter" , ""
            //////////PopVerify_PaticipantData_Imports_LoadAndValidate oParam

            pMain._Home_ToolbarClick_Top(true);


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
            dic.Add("Unique_NoMatch_Num", "25");
            dic.Add("Unique_UniqueMatch_Num", "189");
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


            dic.Clear();
            dic.Add("Level_1", "2011 Data");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "USC_FAE");
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
            dic.Add("CalculateAndPreview", "click");
            dic.Add("SaveToWarehouse", "click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);


            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "2011 Data");
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "Revised ValuationData");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("Filter", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "click");
            dic.Add("PublishSnapshot", "click");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_SP_Snapshots_Popup(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Funding - Funding2011_Baseline

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
            dic.Add("Name", "Funding2011");
            dic.Add("Parent", "Funding2008");
            dic.Add("ParentFinalValuationSet", "New DAMP Node");
            dic.Add("PlanYearBeginningIn", "2011");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "Click");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Funding2011");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Funding2011");

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
            dic.Add("Snapshot", "true");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("CompareData", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Revised ValuationData");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "true");
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
            dic.Add("CompareData", "");
            dic.Add("ImportDataandApplyMapping", "Click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Funding2011");

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
            dic.Add("GL_GoingConcern", "True");
            dic.Add("GL_Solvency", "True");
            dic.Add("PayoutProjection", "false");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "true");
            dic.Add("CalcIncreCostSolvencyWindup", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "ProjectedPay");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "ContribsWInterest1");
            dic.Add("Pension", "AccruedBenefit1");
            dic.Add("AllLiabilityTypes", "false");
            dic.Add("GoingConcernLiability", "True");
            dic.Add("SolvencyLiability", "True");
            dic.Add("WindUpLiability", "false");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Funding2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete with 1 NP", true);


            pMain._SelectTab("Funding2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Valuation Summary", "RollForward", true, true);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Reconciliation to Prior Year", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Age Service Matrix", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Data Matching Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Combined Status Code Summary", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Gain / Loss Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Decrement Age", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Individual Output", "RollForward", true, true);

            }

            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Age Service Matrix", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Data Matching Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Combined Status Code Summary", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Decrement Age", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2011_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2011_Baseline, "IOE", "RollForward", false, true);
            }

            thrd_Funding2011_Baseline.Start();



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Funding2011");
            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region Funding - Funding2011_NewValuation

            pMain._SelectTab("Funding2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "New Valuation");
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
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("CalcIncreCostSolvencyWindup", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "ProjectedPay");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "ContribsWInterest1");
            dic.Add("Pension", "AccruedBenefit1");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "True");
            dic.Add("SolvencyLiability", "True");
            dic.Add("WindUpLiability", "true");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Funding2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete with 1 NP", true);


            pMain._SelectTab("Funding2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Common(sOutputFunding_Funding2011_NewValuation, "Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others(sOutputFunding_Funding2011_NewValuation, "Parameter Print", "RollForward", true, true);

            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2011_NewValuation, "Liability Scenario", "RollForward", true, true);
                ////////pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2011_NewValuation, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Funding2011_NewValuation, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2011_NewValuation, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Funding2011_NewValuation, "Age Service Matrix", "Roll Forward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2011_NewValuation, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Funding2011_NewValuation, "LiabilitiesDetailedResults", "RollForward", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2011_NewValuation, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2011_NewValuation, "Liability Scenario by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Funding2011_NewValuation, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Funding2011_NewValuation, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Funding2011_NewValuation, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2011_NewValuation, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Funding2011_NewValuation, "Age Service Matrix", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2011_NewValuation, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2011_NewValuation, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Funding2011_NewValuation, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2011_NewValuation, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);

            }


            thrd_Funding2011_NewValuation.Start();



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Funding2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Funding - WindUpGL2011


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
            dic.Add("Name", "WindUpGL 2011");
            dic.Add("Parent", "Funding2008");
            dic.Add("ParentFinalValuationSet", "New DAMP Node");
            dic.Add("PlanYearBeginningIn", "2011");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "Click");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "WindUpGL 2011");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("WindUpGL 2011");

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
            dic.Add("Data_AddNew", "true");
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
            dic.Add("Snapshot", "true");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("CompareData", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Revised ValuationData");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "true");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "click");
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
            dic.Add("ImportDataandApplyMapping", "click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("WindUpGL 2011");


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
            dic.Add("GL_GoingConcern", "True");
            dic.Add("GL_WindUp", "True");
            dic.Add("PayoutProjection", "false");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("CalcIncreCostSolvencyWindup", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "ProjectedPay");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "ContribsWInterest1");
            dic.Add("Pension", "AccruedBenefit1");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "True");
            dic.Add("SolvencyLiability", "false");
            dic.Add("WindUpLiability", "true");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("WindUpGL 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete with 1 NP", true);


            pMain._SelectTab("WindUpGL 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(sOutputFunding_WindUpGL2011, "Parameter Print", "RollForward", true, true);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_WindUpGL2011, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_WindUpGL2011, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_WindUpGL2011, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_WindUpGL2011, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_WindUpGL2011, "Age Service Matrix", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_WindUpGL2011, "Data Matching Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_WindUpGL2011, "Combined Status Code Summary", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_WindUpGL2011, "Gain / Loss Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_WindUpGL2011, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_WindUpGL2011, "Active Decrement Gain / Loss Detail", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_WindUpGL2011, "Decrement Age", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_WindUpGL2011, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_WindUpGL2011, "Individual Output", "RollForward", true, true);

            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_WindUpGL2011, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_WindUpGL2011, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_WindUpGL2011, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_WindUpGL2011, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_WindUpGL2011, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_WindUpGL2011, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_WindUpGL2011, "Age Service Matrix", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_WindUpGL2011, "Data Matching Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_WindUpGL2011, "Combined Status Code Summary", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_WindUpGL2011, "Gain / Loss Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_WindUpGL2011, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_WindUpGL2011, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_WindUpGL2011, "Decrement Age", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_WindUpGL2011, "Gain / Loss Participant Listing", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_WindUpGL2011, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_WindUpGL2011, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_WindUpGL2011, "IOE", "RollForward", false, true);
            }

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("CA001CN", sOutputFunding_WindUpGL2011_Prod, sOutputFunding_WindUpGL2011);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_WindUpGL2011");
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYear_GoingConcern.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYear_Windup.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_GoingConcern.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_Windup.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsByPlanDef.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainlossStatusReconciliation_GoingConcern.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainlossStatusReconciliation_Windup.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryOfLiabilityReconciliation_GoingConcern.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryOfLiabilityReconciliation_Windup.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_GoingConcern.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_Windup.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_GoingConcern.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_Windup.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);

            }


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("WindUpGL 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            _gLib._MsgBox("", "Finished!");

        }



        void t_CompareRpt_Funding_Funding2008_Baseline(string sOutputFunding_Funding2008_Baseline)
        {


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("CA001CN", sOutputFunding_Funding2008_Baseline_Prod, sOutputFunding_Funding2008_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_Funding2008_Baseline");
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
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_Wind-Up.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }



        }

        void t_CompareRpt_Accounting_Accounting2008(string sOutputAccounting_Accounting2008)
        {


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("CA001CN", sOutputAccounting_Accounting2008_Prod, sOutputAccounting_Accounting2008);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting_Accounting2008");
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
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
  

        }

        void t_CompareRpt_Funding_Funding2008_NewDAMP(string sOutputFunding_Funding2008_NewDAMP)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("CA001CN", sOutputFunding_Funding2008_NewDAMP_Prod, sOutputFunding_Funding2008_NewDAMP);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_Funding2008_NewDAMP");

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutPut.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_Wind-Up.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_Windup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_Windup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Funding_Funding2011_Baseline(string sOutputFunding_Funding2011_Baseline)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("CA001CN", sOutputFunding_Funding2011_Baseline_Prod, sOutputFunding_Funding2011_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_Funding2011_Baseline");

                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearByPlanDef_GoningConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearByPlanDef_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainlossStatusReconciliation_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainlossStatusReconciliation_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainlossSummaryOfLiabilityReconciliation_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainlossSummaryOfLiabilityReconciliation_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;

            }

        }

        void t_CompareRpt_Funding_Funding2011_NewValuation(string sOutputFunding_Funding2011_NewValuation)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("CA001CN", sOutputFunding_Funding2011_NewValuation_Prod, sOutputFunding_Funding2011_NewValuation);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_Funding2011_NewValuation");

                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Windup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenarioByPlanDef_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenarioByPlanDef_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenarioByPlanDef_Windup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_Wind-Up.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_Windup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_Windup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
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

