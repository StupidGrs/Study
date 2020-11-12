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
using System.Threading;



namespace RetirementStudio._TestScripts_2019_Oct_US
{


    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class US008_CN
    {
        public US008_CN()
        {

            Config.eEnv = _TestingEnv.Prod_US;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US 008 US Upgrade Franklin";
            Config.sPlanName = "QA US 008 US Upgrade Franklin Plan";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;

        }



        #region Report Output Directory



        public string sOutputFunding_Valuation2012_Baseline = "";
        public string sOutputFunding_Valuation2012_UpdateAssumptionDates = "";
        public string sOutputFunding_Valuation2012_ForAFN2012 = "";
        public string sOutputFunding_Valuation2012_ForAFTAPRange = "";
        public string sOutputFunding_Valuation2013_Baseline = "";
        public string sOutputFunding_Valuation2013_UpdateInterestAndMortality = "";
        public string sOutputFunding_Valuation2013_ForAFN2012 = "";
        public string sOutputFunding_ForAFTAPRangeTest_Baseline = "";
        public string sOutputAccounting_FASVal2012_Baseline = "";


        public string sOutputFunding_Valuation2012_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Valuation2012\Baseline\7.3.0.1_20190321_Franklin\";
        public string sOutputFunding_Valuation2012_UpdateAssumptionDates_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Valuation2012\UpdateAssumptionDates\7.3.0.1_20190321_Franklin\";
        public string sOutputFunding_Valuation2012_ForAFN2012_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Valuation2012\ForAFN2012\7.3.0.1_20190321_Franklin\";
        public string sOutputFunding_Valuation2012_ForAFTAPRange_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Valuation2012\ForAFTAPRange\7.3.0.1_20190321_Franklin\";
        public string sOutputFunding_Valuation2013_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Valuation2013\Baseline\7.3.0.1_20190321_Franklin\";
        public string sOutputFunding_Valuation2013_UpdateInterestAndMortality_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Valuation2013\UpdateInterestAndMortality\7.3.0.1_20190321_Franklin\";
        public string sOutputFunding_Valuation2013_ForAFN2012_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\Valuation2013\ForAFN2012\7.3.0.1_20190321_Franklin\";
        public string sOutputFunding_ForAFTAPRangeTest_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Funding\ForAFTAPRangeTest\Baseline\7.3.0.1_20190321_Franklin\";
        public string sOutputAccounting_FASVal2012_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\Accounting\FASVal2012\Baseline\7.3.0.1_20190321_Franklin\";


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

                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Create New\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();
                    sOutputFunding_Valuation2012_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2012\\Baseline\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2012_UpdateAssumptionDates = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2012\\UpdateAssumptionDates\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2012_ForAFN2012 = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2012\\ForAFN2012\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2012_ForAFTAPRange = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2012\\ForAFTAPRange\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2013_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2013\\Baseline\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2013_UpdateInterestAndMortality = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2013\\UpdateInterestAndMortality\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2013_ForAFN2012 = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2013\\ForAFN2012\\" + sPostFix + "\\");
                    sOutputFunding_ForAFTAPRangeTest_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\ForAFTAPRangeTest\\Baseline\\" + sPostFix + "\\");
                    sOutputAccounting_FASVal2012_Baseline = _gLib._CreateDirectory(sMainDir + "Accounting\\FASVal2012\\Baseline\\" + sPostFix + "\\");

                }

            }


            string sContent = "";
            sContent = sContent + "sOutputFunding_Valuation2012_Baseline = @\"" + sOutputFunding_Valuation2012_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2012_UpdateAssumptionDates = @\"" + sOutputFunding_Valuation2012_UpdateAssumptionDates + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2012_ForAFN2012 = @\"" + sOutputFunding_Valuation2012_ForAFN2012 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2012_ForAFN2012 = @\"" + sOutputFunding_Valuation2012_ForAFN2012 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2012_ForAFTAPRange = @\"" + sOutputFunding_Valuation2012_ForAFTAPRange + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2013_Baseline = @\"" + sOutputFunding_Valuation2013_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2013_UpdateInterestAndMortality = @\"" + sOutputFunding_Valuation2013_UpdateInterestAndMortality + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2013_ForAFN2012 = @\"" + sOutputFunding_Valuation2013_ForAFN2012 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_ForAFTAPRangeTest_Baseline = @\"" + sOutputFunding_ForAFTAPRangeTest_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_FASVal2012_Baseline = @\"" + sOutputAccounting_FASVal2012_Baseline + "\";" + Environment.NewLine;

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

        #endregion


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_US008_CN()
        {


            #region MultiThreads


            Thread thrd_Funding_Valuation2012_Baseline = new Thread(() => new US008_CN().t_CompareRpt_Funding_Valuation2012_Baseline(sOutputFunding_Valuation2012_Baseline));
            Thread thrd_Funding_Valuation2012_UpdateAssumptionDates = new Thread(() => new US008_CN().t_CompareRpt_Funding_Valuation2012_UpdateAssumptionDates(sOutputFunding_Valuation2012_UpdateAssumptionDates));
            Thread thrd_Funding_Valuation2012_ForAFN2012 = new Thread(() => new US008_CN().t_CompareRpt_Funding_Valuation2012_ForAFN2012(sOutputFunding_Valuation2012_ForAFN2012));
            Thread thrd_Funding_Valuation2012_ForAFTAPRange = new Thread(() => new US008_CN().t_CompareRpt_Funding_Valuation2012_ForAFTAPRange(sOutputFunding_Valuation2012_ForAFTAPRange));
            Thread thrd_Funding_Valuation2013_Baseline = new Thread(() => new US008_CN().t_CompareRpt_Funding_Valuation2013_Baseline(sOutputFunding_Valuation2013_Baseline));
            Thread thrd_Funding_Valuation2013_UpdateInterestAndMortality = new Thread(() => new US008_CN().t_CompareRpt_Funding_Valuation2013_UpdateInterestAndMortality(sOutputFunding_Valuation2013_UpdateInterestAndMortality));
            Thread thrd_Funding_Valuation2013_ForAFN2012 = new Thread(() => new US008_CN().t_CompareRpt_Funding_Valuation2013_ForAFN2012(sOutputFunding_Valuation2013_ForAFN2012));



            #endregion


            this.GenerateReportOuputDir();


            #region Valuation 2012 - Baseline


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            _gLib._MsgBox("", "please delete RollForward services");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "Valuation 2012");
            dic.Add("Parent", "Conversion 2011");
            dic.Add("ParentFinalValuationSet", "Baseline");
            dic.Add("PlanYearBeginningIn", "2012");
            dic.Add("FirstYearPlanUnderPPA", "2008");
            dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2012");
            pMain._PopVerify_Home_RightPane(dic);




            pMain._SelectTab("Valuation 2012");

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
            dic.Add("FundingInformation_AddNew", "True");
            dic.Add("FundingInformation_Name", "RollForwardFundingCalculator");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._ValuationNodeProperties_ChangeReasons_Initialize();


            dic.Clear();
            dic.Add("LiabilityType", "PPA");
            dic.Add("ReasonforChange", "Baseline");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "PBGC");
            dic.Add("ReasonforChange", "Baseline");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "FAS 35");
            dic.Add("ReasonforChange", "Baseline");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "EAN");
            dic.Add("ReasonforChange", "Baseline");
            dic.Add("OK", "Click");
            pMain._ValuationNodeProperties_ChangeReasons(dic);


            pMain._SelectTab("Valuation 2012");

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
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "True");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "Click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);





            pParticipantDataSet._Initialzie();

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "ParticipantStatus");
            pParticipantDataSet._Navigate(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "ParticipantStatus");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "PayStatus");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);



            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "HealthStatus");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "AliveStatus");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "ExitDate");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);



            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "TerminationDate1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "DeathDate");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "MaritalStatus");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            pParticipantDataSet._ExpandOrCollapseFirstLevel("Personal Information");

            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "MembershipDate1");
            pParticipantDataSet._Navigate(dic, true);


            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "MembershipDate1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "ContribRate1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "ContribsWInterest1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "ContribsWOInterest1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "BenefitInPayment");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "True");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "TestFlag");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "True");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            pParticipantDataSet._ExpandOrCollapseFirstLevel("DB Information");




            dic.Clear();
            dic.Add("Level_1", "DC Information");
            dic.Add("Level_2", "EeAccountBalance1");
            pParticipantDataSet._Navigate(dic, true);


            dic.Clear();
            dic.Add("Level_1", "DC Information");
            dic.Add("Level_2", "EeAccountBalance1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "DC Information");
            dic.Add("Level_2", "EeContribRate1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "DC Information");
            dic.Add("Level_2", "ErAccountBalance1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "DC Information");
            dic.Add("Level_2", "ErContribRate1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            pParticipantDataSet._ExpandOrCollapseFirstLevel("DC Information");


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BenService");
            pParticipantDataSet._Navigate(dic, true, false, true, false);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BenService");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "True");
            dic.Add("sComparisonType", "Absolute");
            dic.Add("bALL", "");
            dic.Add("bACT", "True");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "True");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BenServiceInc");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "False");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "");
            dic.Add("bACT", "True");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "VestService");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "True");
            dic.Add("sComparisonType", "Absolute");
            dic.Add("bALL", "");
            dic.Add("bACT", "True");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            pParticipantDataSet._ExpandOrCollapseFirstLevel("Personal Information");



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

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/26/1944\"  and $emp.HireDate1=\"6/2/1996\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12/26/1956\"  and $emp.HireDate1=\"7/25/1997\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"6/6/1982\"  and $emp.HireDate1=\"7/9/2004\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"1/7/1987\"  and $emp.HireDate1=\"8/21/2009\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"3/14/1966\"  and $emp.HireDate1=\"11/10/1986\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"6/30/1924\"  and $emp.HireDate1=\"6/20/1980\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12/14/1940\"  and $emp.HireDate1=\"8/22/1999\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"11/11/1932\"  and $emp.HireDate1=\"12/17/1978\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/18/1934\"  and $emp.HireDate1=\"1/15/1984\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"5/15/1963\"  and $emp.HireDate1=\"9/14/2001\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"5/7/1984\"  and $emp.HireDate1=\"2/23/2008\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"4/15/1954\"  and $emp.HireDate1=\"4/30/1977\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"8/2/1974\"  and $emp.HireDate1=\"6/23/2000\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/23/1980\"  and $emp.HireDate1=\"6/1/2008\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);



            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            dic.Clear();
            dic.Add("MenuItem_1", "Asset Snapshots");
            pMain._MenuSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pParticipantDataSet._PopVerify_AssetSnapshot(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Funding Information");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Contributions");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Category", "");
            dic.Add("PlanYear", "2010");
            dic.Add("TaxYear", "2010");
            dic.Add("MinimumRequiredContribution", "Yes");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "");
            pFundingInformation._Contributions_Employer(dic);

            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Actuarial Value of Assets");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "General Parameters");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanYearBeginDate", "01/01/2012");
            dic.Add("PlanYearEndDate", "12/31/2012");
            dic.Add("CurrentYareNumOfParcipants", "131");
            dic.Add("YearsForShortfallAmortization", "");
            pFundingInformation._PopVerify_GI_GeneralInformation(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VoluntaryCOB", "0");
            dic.Add("ApplyCalculated_Yes", "True");
            dic.Add("ApplyCalculated_No", "");
            dic.Add("ClientDecision_Yes", "");
            dic.Add("ClientDecision_No", "True");
            dic.Add("ClientDecision_Unknown", "");
            dic.Add("PBGCAgreement_Yes", "");
            dic.Add("PBGCAgreement_No", "True");
            dic.Add("PBGCAgreement_Unknown", "");
            pFundingInformation._PopVerify_GI_CarryoverBalance(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VoluntaryCOB", "0");
            dic.Add("ApplyCalculated_Yes", "True");
            dic.Add("ApplyCalculated_No", "");
            dic.Add("ClientDecision_Yes", "");
            dic.Add("ClientDecision_No", "True");
            dic.Add("ClientDecision_Unknown", "");
            dic.Add("PBGCAgreement_Yes", "");
            dic.Add("PBGCAgreement_No", "True");
            dic.Add("PBGCAgreement_Unknown", "");
            pFundingInformation._PopVerify_GI_PrefundingBalance(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanSponsor_Yes", "");
            dic.Add("PlanSponsor_No", "True");
            dic.Add("PlanSponsor_Unknown", "");
            dic.Add("IncreaseDueToPlanAmendment", "0");
            dic.Add("ExemptFrom_Yes", "");
            dic.Add("ExemptFrom_No", "True");
            dic.Add("ExemptFrom_Unknown", "");
            dic.Add("IncreaseDueToShutdown", "0");
            dic.Add("OriginalPlanEffectiveDate", "01/01/1978");
            dic.Add("PlanWasFrozen_Yes", "");
            dic.Add("PlanWasFrozen_No", "True");
            dic.Add("PlanWasFrozen_Unknown", "");
            pFundingInformation._PopVerify_GI_BenefitRestriction(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CompanyName", "");
            dic.Add("Telephone", "212-555-1234");
            dic.Add("AddressLine1", "123 Main Street");
            dic.Add("AddressLine2", "Deerfield, IL 60015");
            dic.Add("AddressLine3", "");
            dic.Add("Signer1Name", "Singer One");
            dic.Add("Signer1Credential", "Super Singer");
            dic.Add("Signer2Name", "Singer Two");
            dic.Add("Signer2Credential", "Special Singer");
            dic.Add("PeerReviewName", "Peer Reviewer");
            dic.Add("PeerReviewCredentials", "Super Reviewer");
            pFundingInformation._PopVerify_GI_ActuarialReport(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Prior Year Results");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SummaryView", "");
            dic.Add("DetailView", "True");
            dic.Add("TabName", "Preliminary Results and PBGC Premiums");
            pFundingInformation._PopVerify_PriorYearResults_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OriginalPlanEffectDate", "01/01/1978");
            dic.Add("BeginningOfPlanYear", "01/01/2011");
            dic.Add("EndOfPlanYear", "12/31/2011");
            dic.Add("ValuationDate", "01/01/2011");
            dic.Add("ValuationYear", "2012");
            dic.Add("PlanTotallyFrozen", "");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_PlanDates(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InactivesInPayStatus", "10");
            dic.Add("InactivesDeferredStatus", "62");
            dic.Add("VestedStatus", "35");
            dic.Add("NonVestedStatus", "18");
            dic.Add("Total", "125");
            dic.Add("TotalPlanParticipants", "125");
            dic.Add("NumOfParticipants", "125");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_Data(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PirorYearNum", "130");
            dic.Add("Prong1Determination", "75.16");
            dic.Add("Prong1Threshold", "65.00");
            dic.Add("Prong2Determination", "75.16");
            dic.Add("Prong2Threshold", "70.00");
            dic.Add("PlanIsAtRisk", "");
            dic.Add("IncludesExpenseLoad", "");
            dic.Add("ConsecutiveYears", "");
            dic.Add("FTReflects", "");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_AtRiskDetermination(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InPayStatus", "1,968,365");
            dic.Add("DeferredStatus", "2,831,941");
            dic.Add("VestedActives", "2,789,008");
            dic.Add("NonVestedActives", "16,512");
            dic.Add("Total", "7,605,826");
            dic.Add("NormalCost", "353,826");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_FTD_NotAtRisk(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InPayStatus", "");
            dic.Add("DeferredStatus", "");
            dic.Add("VestedActives", "");
            dic.Add("NonVestedActives", "");
            dic.Add("Total", "");
            dic.Add("NormalCost", "353,826");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_FTD_Final(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InPayStatus", "1,968,365");
            dic.Add("DeferredStatus", "2,831,941");
            dic.Add("VestedActives", "2,789,008");
            dic.Add("NonVestedActives", "16,512");
            dic.Add("Total", "7,605,826");
            dic.Add("Discounted", "");
            dic.Add("Expected", "");
            dic.Add("DiscountedExpected", "");
            dic.Add("NormalCost", "353,826");
            dic.Add("TotalNormalCost", "");
            dic.Add("EffectiveInterestRate", "6.44");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_FTD_FundingTarget(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NotAtRiskLiability", "9,516,552");
            dic.Add("ExpenseLoad", "");
            dic.Add("AtRiskLiabilityNoExpense", "");
            dic.Add("AtRiskLiabilityWithExpense", "");
            dic.Add("FinalAtRisk", "");
            dic.Add("FundingTarget", "9,516,552");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_MDC(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PBGCFlatRate_ParticipantCount", "125");
            dic.Add("PBGCFlatRate_PerParticipant", "33");
            dic.Add("PBGCFlatRate_FlatRatePremium", "4,125");
            dic.Add("NotAtRisk_InPayStatus", "2,193,447");
            dic.Add("NotAtRisk_DeferredStatus", "3,418,800");
            dic.Add("NotAtRisk_VestedActives", "3,381,352");
            dic.Add("NotAtRisk_Total", "8,993,599");
            dic.Add("ExpenseLoad_InPayStatus", "");
            dic.Add("ExpenseLoad_DeferredStatus", "");
            dic.Add("ExpenseLoad_VestedActives", "");
            dic.Add("ExpenseLoad_Total", "");
            dic.Add("AtRiskNoExpense_InPayStatus", "");
            dic.Add("AtRiskNoExpense_DeferredStatus", "");
            dic.Add("AtRiskNoExpense_VestedActives", "");
            dic.Add("AtRiskNoExpense_Total", "");
            dic.Add("AtRiskWithExpense_InPayStatus", "");
            dic.Add("AtRiskWithExpense_DeferredStatus", "");
            dic.Add("AtRiskWithExpense_VestedActives", "");
            dic.Add("AtRiskWithExpense_Total", "");
            dic.Add("FinalAtRisk_InPayStatus", "");
            dic.Add("FinalAtRisk_DeferredStatus", "");
            dic.Add("FinalAtRisk_VestedActives", "");
            dic.Add("FinalAtRisk_Total", "");
            dic.Add("PBGCTarget_InpayStatus", "2,193,447");
            dic.Add("PBGCTarget_DeferredStatus", "3,418,800");
            dic.Add("PBGCTarget_VestedActives", "3,381,352");
            dic.Add("PBGCTarget_Total", "8,993,599");
            dic.Add("PBGCTarget_MVofAssets", "6,449,268");
            dic.Add("PBGCVariable_Unfunded", "1,811,000");
            dic.Add("PBGCVariable_9Per1000", "16,299");
            dic.Add("PBGCVariable_NumOfEE", "125");
            dic.Add("PBGCVariable_ParticipantCount", "125");
            dic.Add("PBGCVariable_PerParticipant", "");
            dic.Add("PBGCVariable_PBGCVariable", "16,299");
            dic.Add("PBGCVariable_CombinedPBGC", "20,424");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_PGBCPremiums(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BalanceAtBegining", "");
            dic.Add("PortionUsed", "");
            dic.Add("InterestUsing", "");
            dic.Add("BalanceAtBOY", "");
            dic.Add("VoluntaryReduction", "100,000");
            dic.Add("DeemedWaivers", "60,279");
            dic.Add("BOYBalance", "");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_CarryoverBalance(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Liability_Actuarial", "7,684,952");
            dic.Add("Liability_NormalCost", "");
            dic.Add("Liability_Interest", "");
            dic.Add("Benefits_BenefitPayments", "");
            dic.Add("Benefits_Administrative", "");
            dic.Add("Benefits_EmployeeContrib", "");
            dic.Add("Benefits_Total", "");
            dic.Add("Benefits_ExpectedActuarial", "");
            dic.Add("Benefits_LiabilityGL", "");
            dic.Add("Asset_ActuarialAsset", "5,771,417");
            dic.Add("Asset_InterestOnActuarial", "333,572");
            dic.Add("Asset_ContributionsMade", "");
            dic.Add("Asset_InterestOnContrib", "");
            dic.Add("Asset_ExpectedActuarial", "");
            dic.Add("Asset_ActuarialAssetGL", "");
            dic.Add("Asset_ActuarialGL", "");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_DevelopmentOfExperienceGL(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SummaryView", "");
            dic.Add("DetailView", "");
            dic.Add("TabName", "FTAPs, Benefit Restrictions, and At-Risk Determination");
            pFundingInformation._PopVerify_PriorYearResults_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVOfAssets", "6,449,268");
            dic.Add("90ofMarketValue", "");
            dic.Add("110ofMarketValue", "");
            dic.Add("PreliminaryActuarial", "");
            dic.Add("ActuarialValue", "6,449,268");
            dic.Add("AVAPFB", "6,449,268");
            dic.Add("AVACOBPFB", "6,449,268");
            dic.Add("Prior2YearsNHC", "");
            dic.Add("AVANHCPurchase", "6,449,268");
            dic.Add("AVACOBPFBNHCPurchase", "6,449,268");
            dic.Add("NARFundLiabNHCPurchase", "7,855,033");
            pFundingInformation_FTAPs._PopVerify_AssetNumbers(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FTAP", "80.51");
            dic.Add("FTAP_PFB", "82.10");
            dic.Add("FTAP_Exempt", "82.10");
            dic.Add("FTAP_AtRisk", "80.51");
            dic.Add("FTAP_SB_PFB", "82.10");
            dic.Add("FTAP_SB_NoPFB", "82.10");
            pFundingInformation_FTAPs._PopVerify_FTAPs(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ElectionToUse", "");
            dic.Add("ShortfallFunded", "");
            dic.Add("EligibleForTransition", "");
            dic.Add("ExemptFrom2007AFC", "Yes");
            dic.Add("2008", "82.10");
            dic.Add("2009", "");
            dic.Add("2010", "");
            dic.Add("IsPlanExempt", "");
            pFundingInformation_FTAPs._PopVerify_ShortfallBaseExemption(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CurrentYearTop25", "");
            dic.Add("CurrentYear401", "");
            dic.Add("CanUseCOB", "82.10");
            dic.Add("QuarterlyContrib", "82.10");
            dic.Add("PBGC4010", "80.51");
            pFundingInformation_FTAPs._PopVerify_OtherFTAPChecks(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Prong1", "70.00");
            dic.Add("Prong2", "70.00");
            dic.Add("PlanIsAtRiskNextYear", "");
            dic.Add("PlanAtRiskPriorYear1", "");
            dic.Add("PlanAtRiskPriorYear2", "");
            dic.Add("NumOfYears", "");
            dic.Add("ExpenseLoad", "");
            dic.Add("NextYearConsecutive", "");
            dic.Add("FTNextYear", "");
            pFundingInformation_FTAPs._PopVerify_AtRiskDeterminatinForFollowingYear(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AFTAPBefore", "79.23");
            dic.Add("IncreaseTo60", "");
            dic.Add("IncreaseTo80", "60,279");
            dic.Add("RequiredCredit", "60,279");
            dic.Add("FinalAFTAP_TotalWaiver", "");
            dic.Add("FinalAFTAP_FinalAFTAP", "82.10");
            pFundingInformation_FTAPs._PopVerify_PreliminaryAFTAPCalcuations(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CurrentYear_TreatPlan", "");
            dic.Add("CurrentYear_In3Months", "75.14");
            dic.Add("CurrentYear_In6Months", "65.14");
            dic.Add("CurrentYear_After9Months", "");
            dic.Add("NextYear_In3Months", "82.10");
            dic.Add("NextYear_In6Months", "72.10");
            dic.Add("NextYear_After9Months", "");
            pFundingInformation_FTAPs._PopVerify_PresumedCurrentNextYear(dic);


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SummaryView", "");
            dic.Add("DetailView", "");
            dic.Add("TabName", "Shortfall");
            pFundingInformation._PopVerify_PriorYearResults_Main(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("COBAfter", "-125,545");
            dic.Add("PFBAfter", "");
            dic.Add("NetAssets", "6,323,723");
            dic.Add("FundingShortfall", "1,531,280");
            dic.Add("TransitionPercent", "");
            dic.Add("TransitionFundingTarget", "");
            dic.Add("TransitionFundingShortfall", "");
            pFundingInformation_Shortfall._PopVerify_NetAssets(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NewBaseAmount", "777,335");
            dic.Add("YearsForShortfall", "");
            dic.Add("AmortizationFactor", "5.98032");
            dic.Add("ShortfallAmortizationInstallment", "129,982");
            dic.Add("TotalSAI", "");
            dic.Add("ShortfallAmortizationCharge", "150,975");
            pFundingInformation_Shortfall._PopVerify_PVOfPriorYearsFundingWaiverBases(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CY", "2.06");
            dic.Add("CY1", "2.06");
            dic.Add("CY2", "2.06");
            dic.Add("CY3", "2.06");
            dic.Add("CY4", "2.06");
            dic.Add("CY5", "5.25");
            dic.Add("CY6", "5.25");
            dic.Add("CY7", "5.25");
            dic.Add("CY8", "5.25");
            dic.Add("CY9", "5.25");
            pFundingInformation_Shortfall._PopVerify_InterestRatesByYear(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CY", "0.97982");
            dic.Add("CY1", "0.96004");
            dic.Add("CY2", "0.94066");
            dic.Add("CY3", "0.92167");
            dic.Add("CY4", "0.90307");
            dic.Add("CY5", "0.77426");
            dic.Add("CY6", "0.73564");
            dic.Add("CY7", "0.69895");
            dic.Add("CY8", "0.66408");
            dic.Add("CY9", "0.63095");
            pFundingInformation_Shortfall._PopVerify_DiscountFactors(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Year1", "0.00000");
            dic.Add("Year2", "1.94959");
            dic.Add("Year3", "2.85128");
            dic.Add("Year4", "3.70751");
            dic.Add("Year5", "4.52075");
            dic.Add("Year6", "5.27136");
            dic.Add("Year7", "5.98032");
            dic.Add("Year8", "0.00000");
            dic.Add("Year9", "0.00000");
            dic.Add("Year10", "0.00000");
            pFundingInformation_Shortfall._PopVerify_AmortizationFactors(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SummaryView", "");
            dic.Add("DetailView", "");
            dic.Add("TabName", "Contribution Summary");
            pFundingInformation._PopVerify_PriorYearResults_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TargetNormalCost", "502,063");
            dic.Add("FullFundingLimit", "1,903,361");
            dic.Add("MininumBefore", "523,056");
            dic.Add("PriorYearFunded", "");
            dic.Add("COBUsed", "");
            dic.Add("PFBUsed", "");
            dic.Add("MinimumAfter", "523,056");
            dic.Add("MinimumAtEOY", "533,291");
            dic.Add("MinimumAtLast", "556,437");
            pFundingInformation_ContributionSummary._PopVerify_MinimumRequiredContribution(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Cushion_50ofFunding", "3,927,502");
            dic.Add("Cushion_FTIncrease", "1,661,549");
            dic.Add("Cushion_DeductionLimit", "7,366,867");
            dic.Add("Alternate_DeductionLimit", "");
            dic.Add("Alternate_MaximumDeductible", "7,366,867");
            dic.Add("Interest_EarlierOf", "");
            dic.Add("Interest_Fractional", "");
            dic.Add("Interest_InterestTo", "");
            dic.Add("Interest_MaximumDeductible", "");
            pFundingInformation_ContributionSummary._PopVerify_MaximumDeductibleContribution(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FundingShortfall", "");
            dic.Add("AmountPriorMRC", "698,429");
            dic.Add("AmountCurrentMRC", "451,857");
            dic.Add("QuaterlyAmount", "");
            dic.Add("ShortfallCurrentYear", "Yes");
            dic.Add("QuaterlyAmountNextYear", "125,516");
            dic.Add("ContribtionDates_FinalPayment", "09/15/2012");
            pFundingInformation_ContributionSummary._PopVerify_QuaterlyContributionRequirement(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


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


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Member Statistics", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Individual Checking Template", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Age Service Matrix", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Data Comparison", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Data Matching Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Combined Status Code Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Decrement Age", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Liability Comparison", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_Baseline, "Payout Projection", "RollForward", false, true);


            thrd_Funding_Valuation2012_Baseline.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            #endregion


            #region Valuation 2012 - Update Assumption Dates

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Update Assumption Dates");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "Update Assumption Dates Assumptions");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "True");
            dic.Add("Provisions_Name", "Update Assumption Dates Provisions");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._ValuationNodeProperties_ChangeReasons_Initialize();


            dic.Clear();
            dic.Add("LiabilityType", "PPA");
            dic.Add("ReasonforChange", "Other assumption changes");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "PBGC");
            dic.Add("ReasonforChange", "Other assumption changes");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "FAS 35");
            dic.Add("ReasonforChange", "Change in actuarial assumptions");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "EAN");
            dic.Add("ReasonforChange", "Other assumption changes");
            dic.Add("OK", "Click");
            pMain._ValuationNodeProperties_ChangeReasons(dic);



            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");


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
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "09/01/2011");
            pInterestRate._PopVerify_PrescribedRates(dic);


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
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "09/01/2011");
            pInterestRate._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "_Death");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2012");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);



            ////////////////_gLib._MsgBox("warining!", "Please manually check if As Of Date is <01/01/2012>!");

            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("Level_3", "ActuarialEquivalence1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("txtInterestRate", "");
            dic.Add("Mortality", "PPA2011CMF");
            pActuarialEquivalence._PopVerify_SameStructureForAllPeriods(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

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
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
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


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


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

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "ASC 960 Reconciliation");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Yes", "");
            dic.Add("No", "");
            dic.Add("Message", "ASC 960 reconciliation run completed.");
            dic.Add("OK", "");
            pMain._PopVerify_Home_Confrim(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "");
            dic.Add("No", "");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_Home_Confrim(dic);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "True");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "Click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "Click");
            dic.Add("AddAll", "Click");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "HourlyFlag");
            dic.Add("OK", "Click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Funding Calculator Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_UpdateAssumptionDates, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Reconciliation to Baseline with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Liabilities Detailed Results with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Funding Calculator", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_UpdateAssumptionDates, "ASC 960 Reconciliation", "RollForward", false, true);


            pMain._SelectTab("Valuation 2012");

            pMain._GenerateNewReport(sOutputFunding_Valuation2012_UpdateAssumptionDates, "PPA Funding Valuation Report", 3);
            pMain._GenerateNewReport(sOutputFunding_Valuation2012_UpdateAssumptionDates, "ASC 960 Letter", 3);


            thrd_Funding_Valuation2012_UpdateAssumptionDates.Start();


            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Valuation 2012");

            #endregion


            #region Valuation 2012 - For AFN 2012

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "For AFN 2012");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "For AFN 2012 Assumptions");
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


            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");

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
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2012");
            pInterestRate._PopVerify_PrescribedRates(dic);



            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


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
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFN2012, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFN2012, "Test Cases", "Conversion", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFN2012, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFN2012, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFN2012, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFN2012, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFN2012, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFN2012, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFN2012, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFN2012, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFN2012, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);


            thrd_Funding_Valuation2012_ForAFN2012.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            #endregion


            #region Valuation 2012 - For AFTAP Range

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "For AFTAP Range");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "For AFTAP Range Assumptions");
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


            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");

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
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2013");
            pInterestRate._PopVerify_PrescribedRates(dic);



            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "True");
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
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "False");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "False");
            dic.Add("FAS35PresentValueOfVestedBenefits", "False");
            dic.Add("PPAAtRiskLiabilityForMinimum", "True");
            dic.Add("PPAAtRiskLiabilityForMaximum", "True");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "False");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "False");
            dic.Add("EntryAgeNormal", "False");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFTAPRange, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFTAPRange, "Test Cases", "Conversion", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFTAPRange, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFTAPRange, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFTAPRange, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFTAPRange, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFTAPRange, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFTAPRange, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFTAPRange, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFTAPRange, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFTAPRange, "Liability Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFTAPRange, "Liability Scenario by Plan Def", "RollForward", false, true);


            thrd_Funding_Valuation2012_ForAFTAPRange.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion



            #region Valuation 2013 - Baseline


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
            dic.Add("Name", "Valuation 2013");
            dic.Add("Parent", "Valuation 2012");
            dic.Add("ParentFinalValuationSet", "Update Assumption Dates");
            dic.Add("PlanYearBeginningIn", "2013");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2013");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Valuation 2013");

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
            dic.Add("FundingInformation_AddNew", "True");
            dic.Add("FundingInformation_Name", "RollForwardFundingCalculator");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._ValuationNodeProperties_ChangeReasons_Initialize();


            dic.Clear();
            dic.Add("LiabilityType", "PPA");
            dic.Add("ReasonforChange", "Baseline");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "PBGC");
            dic.Add("ReasonforChange", "Baseline");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "FAS 35");
            dic.Add("ReasonforChange", "Baseline");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "EAN");
            dic.Add("ReasonforChange", "Baseline");
            dic.Add("OK", "Click");
            pMain._ValuationNodeProperties_ChangeReasons(dic);


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
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "True");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "Click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);



            //////////pParticipantDataSet._Initialzie();


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





            pMain._SelectTab("Valuation 2013");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/26/1944\"  and $emp.HireDate1=\"6/2/1996\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12/26/1956\"  and $emp.HireDate1=\"7/25/1997\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"6/6/1982\"  and $emp.HireDate1=\"7/9/2004\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"1/7/1987\"  and $emp.HireDate1=\"8/21/2009\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"3/14/1966\"  and $emp.HireDate1=\"11/10/1986\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"6/30/1924\"  and $emp.HireDate1=\"6/20/1980\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12/14/1940\"  and $emp.HireDate1=\"8/22/1999\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"11/11/1932\"  and $emp.HireDate1=\"12/17/1978\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/18/1934\"  and $emp.HireDate1=\"1/15/1984\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"5/15/1963\"  and $emp.HireDate1=\"9/14/2001\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"5/7/1984\"  and $emp.HireDate1=\"2/23/2008\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"4/15/1954\"  and $emp.HireDate1=\"4/30/1977\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"8/2/1974\"  and $emp.HireDate1=\"6/23/2000\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/23/1980\"  and $emp.HireDate1=\"6/1/2008\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);



            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2013");

            dic.Clear();
            dic.Add("MenuItem_1", "Asset Snapshots");
            pMain._MenuSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pParticipantDataSet._PopVerify_AssetSnapshot(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Funding Information");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Contributions");
            pFundingInformation._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Category", "");
            dic.Add("PlanYear", "2012");
            dic.Add("TaxYear", "2012");
            dic.Add("Year2013", "True");
            dic.Add("MinimumRequiredContribution", "Yes");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "");
            pFundingInformation._Contributions_Employer(dic);


            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Actuarial Value of Assets");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "General Parameters");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanYearBeginDate", "01/01/2013");
            dic.Add("PlanYearEndDate", "12/31/2013");
            dic.Add("CurrentYareNumOfParcipants", "130");
            dic.Add("YearsForShortfallAmortization", "");
            pFundingInformation._PopVerify_GI_GeneralInformation(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VoluntaryCOB", "0");
            dic.Add("ApplyCalculated_Yes", "");
            dic.Add("ApplyCalculated_No", "True");
            dic.Add("ClientDecision_Yes", "True");
            dic.Add("ClientDecision_No", "");
            dic.Add("ClientDecision_Unknown", "");
            dic.Add("PBGCAgreement_Yes", "True");
            dic.Add("PBGCAgreement_No", "");
            dic.Add("PBGCAgreement_Unknown", "");
            pFundingInformation._PopVerify_GI_CarryoverBalance(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VoluntaryCOB", "0");
            dic.Add("ApplyCalculated_Yes", "");
            dic.Add("ApplyCalculated_No", "True");
            dic.Add("ClientDecision_Yes", "");
            dic.Add("ClientDecision_No", "True");
            dic.Add("ClientDecision_Unknown", "");
            dic.Add("PBGCAgreement_Yes", "");
            dic.Add("PBGCAgreement_No", "True");
            dic.Add("PBGCAgreement_Unknown", "");
            pFundingInformation._PopVerify_GI_PrefundingBalance(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanSponsor_Yes", "");
            dic.Add("PlanSponsor_No", "True");
            dic.Add("PlanSponsor_Unknown", "");
            dic.Add("IncreaseDueToPlanAmendment", "0");
            dic.Add("ExemptFrom_Yes", "");
            dic.Add("ExemptFrom_No", "True");
            dic.Add("ExemptFrom_Unknown", "");
            dic.Add("IncreaseDueToShutdown", "0");
            dic.Add("OriginalPlanEffectiveDate", "");
            dic.Add("PlanWasFrozen_Yes", "");
            dic.Add("PlanWasFrozen_No", "True");
            dic.Add("PlanWasFrozen_Unknown", "");
            pFundingInformation._PopVerify_GI_BenefitRestriction(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            pMain._SelectTab("Valuation 2013");

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


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2013");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Member Statistics", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Individual Checking Template", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Age Service Matrix", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Data Comparison", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Data Matching Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Decrement Age", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Liability Comparison", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_Baseline, "Payout Projection", "RollForward", false, true);



            thrd_Funding_Valuation2013_Baseline.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            #region Valuation 2013 - Update Interest and Mortality

            pMain._SelectTab("Valuation 2013");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Update Interest and Mortality");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
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
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);



            pMain._ValuationNodeProperties_ChangeReasons_Initialize();


            dic.Clear();
            dic.Add("LiabilityType", "PPA");
            dic.Add("ReasonforChange", "Other assumption changes");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "PBGC");
            dic.Add("ReasonforChange", "Other assumption changes");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "FAS 35");
            dic.Add("ReasonforChange", "Change in actuarial assumptions");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "EAN");
            dic.Add("ReasonforChange", "Other assumption changes");
            dic.Add("OK", "Click");
            pMain._ValuationNodeProperties_ChangeReasons(dic);



            pMain._SelectTab("Valuation 2013");



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");


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
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2013");
            pInterestRate._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "_Death");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2013");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2013");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2013");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);




            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            pMain._SelectTab("Valuation 2013");

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
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
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


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);



            pMain._SelectTab("Valuation 2013");

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

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "ASC 960 Reconciliation");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Yes", "");
            dic.Add("No", "");
            dic.Add("Message", "ASC 960 reconciliation run completed.");
            dic.Add("OK", "");
            pMain._PopVerify_Home_Confrim(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "");
            dic.Add("No", "");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_Home_Confrim(dic);


            pMain._SelectTab("Valuation 2013");



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "True");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "Click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "Click");
            dic.Add("AddAll", "Click");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "HourlyFlag");
            dic.Add("OK", "Click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);



            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Funding Calculator Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Reconciliation to Baseline with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Liabilities Detailed Results with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Funding Calculator", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "ASC 960 Reconciliation", "RollForward", false, true);


            pMain._SelectTab("Valuation 2013");

            pMain._GenerateNewReport(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "PPA Funding Valuation Report", 3);
            pMain._GenerateNewReport(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "ASC 960 Letter", 3);


            thrd_Funding_Valuation2013_UpdateInterestAndMortality.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);





            #endregion


            #region Valuation 2013 - For AFN 2012



            pMain._SelectTab("Valuation 2013");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "For AFN 2012");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "For AFN 2012 Assumptions");
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

            pMain._SelectTab("Valuation 2013");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");

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
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2012");
            pInterestRate._PopVerify_PrescribedRates(dic);



            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2013");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


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
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "BenefitInPayment");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "False");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "False");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "False");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "False");
            dic.Add("FAS35PresentValueOfVestedBenefits", "False");
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2013");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_ForAFN2012, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_ForAFN2012, "Test Cases", "Conversion", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_ForAFN2012, "Liability Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_ForAFN2012, "Liability Scenario by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_ForAFN2012, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_ForAFN2012, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_ForAFN2012, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2013_ForAFN2012, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_ForAFN2012, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2013_ForAFN2012, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_ForAFN2012, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2013_ForAFN2012, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);


            thrd_Funding_Valuation2013_ForAFN2012.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2013");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Funding Valuation - For AFTAP Range Test

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
            dic.Add("Name", "For AFTAP Range Test");
            dic.Add("Parent", "Valuation 2012");
            dic.Add("ParentFinalValuationSet", "Update Assumption Dates");
            dic.Add("PlanYearBeginningIn", "2013");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "For AFTAP Range Test");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("For AFTAP Range Test");


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
            dic.Add("FundingInformation_AddNew", "True");
            dic.Add("FundingInformation_Name", "RollForwardFundingCalculator");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            pMain._SelectTab("For AFTAP Range Test");


            dic.Clear();
            dic.Add("MenuItem_1", "Asset Snapshots");
            pMain._MenuSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pParticipantDataSet._PopVerify_AssetSnapshot(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Funding Information");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "General Parameters");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanYearBeginDate", "01/01/2013");
            dic.Add("PlanYearEndDate", "12/31/2013");
            dic.Add("CurrentYareNumOfParcipants", "135");
            dic.Add("YearsForShortfallAmortization", "");
            pFundingInformation._PopVerify_GI_GeneralInformation(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VoluntaryCOB", "0");
            dic.Add("ApplyCalculated_Yes", "");
            dic.Add("ApplyCalculated_No", "True");
            dic.Add("ClientDecision_Yes", "");
            dic.Add("ClientDecision_No", "True");
            dic.Add("ClientDecision_Unknown", "");
            dic.Add("PBGCAgreement_Yes", "");
            dic.Add("PBGCAgreement_No", "True");
            dic.Add("PBGCAgreement_Unknown", "");
            pFundingInformation._PopVerify_GI_CarryoverBalance(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VoluntaryCOB", "0");
            dic.Add("ApplyCalculated_Yes", "");
            dic.Add("ApplyCalculated_No", "True");
            dic.Add("ClientDecision_Yes", "");
            dic.Add("ClientDecision_No", "True");
            dic.Add("ClientDecision_Unknown", "");
            dic.Add("PBGCAgreement_Yes", "");
            dic.Add("PBGCAgreement_No", "True");
            dic.Add("PBGCAgreement_Unknown", "");
            pFundingInformation._PopVerify_GI_PrefundingBalance(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanSponsor_Yes", "");
            dic.Add("PlanSponsor_No", "True");
            dic.Add("PlanSponsor_Unknown", "");
            dic.Add("IncreaseDueToPlanAmendment", "0");
            dic.Add("ExemptFrom_Yes", "");
            dic.Add("ExemptFrom_No", "True");
            dic.Add("ExemptFrom_Unknown", "");
            dic.Add("IncreaseDueToShutdown", "890");
            dic.Add("OriginalPlanEffectiveDate", "");
            dic.Add("PlanWasFrozen_Yes", "");
            dic.Add("PlanWasFrozen_No", "True");
            dic.Add("PlanWasFrozen_Unknown", "");
            pFundingInformation._PopVerify_GI_BenefitRestriction(dic);


            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Estimated Liabilities");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UseEstimatedLiabilities", "True");
            dic.Add("FundingService", "Valuation 2012");
            dic.Add("ValuationNode", "For AFTAP Range");
            dic.Add("EstimatedGL", "1.00");
            dic.Add("KnownWorkforceChanges", "2.00");
            dic.Add("Other", "0.50");
            pFundingInformation._PopVerify_EstimatedLiabilities(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("For AFTAP Range Test");

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2012");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Valuation 2012");



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liabilities for Funding");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Liabilities for Funding");

            dic.Clear();
            dic.Add("Level_1", "Funding Liabilities");
            dic.Add("Level_2", "Liability Results - General");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Funding Liabilities");
            dic.Add("Level_2", "Liability Results - Not-At-Risk");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Funding Liabilities");
            dic.Add("Level_2", "Liability Results - At-Risk");
            pFundingInformation._TreeViewSelect(dic);

            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "For AFTAP Range Test");
            pMain._PopVerify_Home_RightPane(dic);



            pMain._SelectTab("For AFTAP Range Test");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Funding Information");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Funding Information");


            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Estimated Liabilities");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UseEstimatedLiabilities", "");
            dic.Add("FundingService", "Valuation 2012");
            dic.Add("ValuationNode", "#1#");
            dic.Add("EstimatedGL", "");
            dic.Add("KnownWorkforceChanges", "");
            dic.Add("Other", "");
            pFundingInformation._PopVerify_EstimatedLiabilities(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UseEstimatedLiabilities", "");
            dic.Add("FundingService", "");
            dic.Add("ValuationNode", "For AFTAP Range");
            dic.Add("EstimatedGL", "");
            dic.Add("KnownWorkforceChanges", "");
            dic.Add("Other", "");
            pFundingInformation._PopVerify_EstimatedLiabilities(dic);

            pMain._SelectTab("Funding Information");

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("For AFTAP Range Test");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
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


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_ForAFTAPRangeTest_Baseline, "Funding Calculator", "RollForward", false, true);


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("For AFTAP Range Test");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            #region Accounting Valuation - FAS Val 2012 - Baseline

            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            _gLib._MsgBox("", "please delete RollForward services");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "FAS Val 2012");
            dic.Add("Parent", "Conversion 2011");
            dic.Add("ParentFinalValuationSet", "Baseline");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "2012");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "FAS Val 2012");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("FAS Val 2012");




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
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._ValuationNodeProperties_ChangeReasons_Initialize();


            dic.Clear();
            dic.Add("LiabilityType", "All Accounting Liability Types");
            dic.Add("ReasonforChange", "Baseline");
            dic.Add("OK", "Click");
            pMain._ValuationNodeProperties_ChangeReasons(dic);



            pMain._SelectTab("FAS Val 2012");

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
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "True");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "Click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);





            pParticipantDataSet._Initialzie();

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "ParticipantStatus");
            pParticipantDataSet._Navigate(dic, true);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "ParticipantStatus");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "PayStatus");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);



            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "HealthStatus");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "AliveStatus");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "ExitDate");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);



            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "TerminationDate1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "DeathDate");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "MaritalStatus");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            pParticipantDataSet._ExpandOrCollapseFirstLevel("Personal Information");

            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "MembershipDate1");
            pParticipantDataSet._Navigate(dic, true);


            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "MembershipDate1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "ContribRate1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "ContribsWInterest1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "ContribsWOInterest1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "False");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "BenefitInPayment");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "True");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "TestFlag");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "True");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            pParticipantDataSet._ExpandOrCollapseFirstLevel("DB Information");




            dic.Clear();
            dic.Add("Level_1", "DC Information");
            dic.Add("Level_2", "EeAccountBalance1");
            pParticipantDataSet._Navigate(dic, true);


            dic.Clear();
            dic.Add("Level_1", "DC Information");
            dic.Add("Level_2", "EeAccountBalance1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "DC Information");
            dic.Add("Level_2", "EeContribRate1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "DC Information");
            dic.Add("Level_2", "ErAccountBalance1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "DC Information");
            dic.Add("Level_2", "ErContribRate1");
            dic.Add("bIsIncludeInReport_Disabled", "True");
            dic.Add("bIncludeInReport", "");
            dic.Add("sComparisonType", "Ignore");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            pParticipantDataSet._ExpandOrCollapseFirstLevel("DC Information");


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BenService");
            pParticipantDataSet._Navigate(dic, true, false, true, false);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BenService");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "True");
            dic.Add("sComparisonType", "Absolute");
            dic.Add("bALL", "");
            dic.Add("bACT", "True");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "True");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BenServiceInc");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "False");
            dic.Add("sComparisonType", "Absolute");
            dic.Add("bALL", "");
            dic.Add("bACT", "True");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "VestService");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "True");
            dic.Add("sComparisonType", "Absolute");
            dic.Add("bALL", "");
            dic.Add("bACT", "True");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            pParticipantDataSet._ExpandOrCollapseFirstLevel("Personal Information");



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



            pMain._SelectTab("FAS Val 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/26/1944\"  and $emp.HireDate1=\"6/2/1996\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12/26/1956\"  and $emp.HireDate1=\"7/25/1997\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"6/6/1982\"  and $emp.HireDate1=\"7/9/2004\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"1/7/1987\"  and $emp.HireDate1=\"8/21/2009\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"3/14/1966\"  and $emp.HireDate1=\"11/10/1986\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"6/30/1924\"  and $emp.HireDate1=\"6/20/1980\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12/14/1940\"  and $emp.HireDate1=\"8/22/1999\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"11/11/1932\"  and $emp.HireDate1=\"12/17/1978\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/18/1934\"  and $emp.HireDate1=\"1/15/1984\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"5/15/1963\"  and $emp.HireDate1=\"9/14/2001\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"5/7/1984\"  and $emp.HireDate1=\"2/23/2008\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"4/15/1954\"  and $emp.HireDate1=\"4/30/1977\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"8/2/1974\"  and $emp.HireDate1=\"6/23/2000\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/23/1980\"  and $emp.HireDate1=\"6/1/2008\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);



            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab("FAS Val 2012");

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
            dic.Add("Acc_GL_PBO", "True");
            dic.Add("Acc_GL_ABO", "True");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
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
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "HourlyFlag");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("FAS Val 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Test Cases", "RollForward", true, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Reconciliation to Prior Year", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Detailed Results", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Detailed Results by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Status Reconciliation", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Member Statistics", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Individual Checking Template", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Age Service Matrix", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Data Comparison", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Data Matching Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Combined Status Code Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Decrement Age", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Gain / Loss Participant Listing", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Liability Comparison", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Valuation Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Individual Output", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "IOE", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Payout Projection", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_FASVal2012_Baseline, "Liability Set for Globe Export", "RollForward", false, false);



            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US008CN", sOutputAccounting_FASVal2012_Baseline_Prod, sOutputAccounting_FASVal2012_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting_FASVal2012_Baseline");
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_ABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_PBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_ABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DataComparison.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossStatusReconciliation.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_ABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_ABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PBO.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_ABO.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityComparison_PBO.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityComparison_ABO.xlsx", 0, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport.xlsx", 4, 0, 0, 0, true);
            }






            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("FAS Val 2012");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);





            #endregion



            _gLib._MsgBoxYesNo("Congratulations!", "Finnally, you are done with US008!");


        }




        void t_CompareRpt_Funding_Valuation2012_Baseline(string sOutputFunding_Valuation2012_Baseline)
        {

            if (Config.bCompareReports)
            {

                CompareReportsLib _compareReportsLib = new CompareReportsLib("US008CN", sOutputFunding_Valuation2012_Baseline_Prod, sOutputFunding_Valuation2012_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Valuation2012_Baseline");
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
                _compareReportsLib.CompareExcel_Exact("DataComparison.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossStatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityComparison_PPANARMin.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityComparison_PPANARMax.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }



        }

        void t_CompareRpt_Funding_Valuation2012_UpdateAssumptionDates(string sOutputFunding_Valuation2012_UpdateAssumptionDates)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US008CN", sOutputFunding_Valuation2012_UpdateAssumptionDates_Prod, sOutputFunding_Valuation2012_UpdateAssumptionDates);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_Valuation2012_UpdateAssumptionDates");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultswithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsByPlanDefwithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ASC960Reconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FundingCalculatorScenario.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }


        }

        void t_CompareRpt_Funding_Valuation2012_ForAFN2012(string sOutputFunding_Valuation2012_ForAFN2012)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US008CN", sOutputFunding_Valuation2012_ForAFN2012_Prod, sOutputFunding_Valuation2012_ForAFN2012);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_Valuation2012_ForAFN2012");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Funding_Valuation2012_ForAFTAPRange(string sOutputFunding_Valuation2012_ForAFTAPRange)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US008CN", sOutputFunding_Valuation2012_ForAFTAPRange_Prod, sOutputFunding_Valuation2012_ForAFTAPRange);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_Valuation2012_ForAFTAPRange");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPAARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPAARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPAARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPAARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPAARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPAARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPAARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPAARMin.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }


        }

        void t_CompareRpt_Funding_Valuation2013_Baseline(string sOutputFunding_Valuation2013_Baseline)
        {


            if (Config.bCompareReports)
            {

                CompareReportsLib _compareReportsLib = new CompareReportsLib("US008CN", sOutputFunding_Valuation2013_Baseline_Prod, sOutputFunding_Valuation2013_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Valuation2013_Baseline");
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
                _compareReportsLib.CompareExcel_Exact("DataComparison.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossStatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityComparison_PPANARMin.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityComparison_PPANARMax.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }



        }

        void t_CompareRpt_Funding_Valuation2013_UpdateInterestAndMortality(string sOutputFunding_Valuation2013_UpdateInterestAndMortality)
        {



            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US008CN", sOutputFunding_Valuation2013_UpdateInterestAndMortality_Prod, sOutputFunding_Valuation2013_UpdateInterestAndMortality);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_Valuation2013_UpdateInterestAndMortality");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefWithBreaks_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultswithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsByPlanDefwithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ASC960Reconciliation.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }





        }

        void t_CompareRpt_Funding_Valuation2013_ForAFN2012(string sOutputFunding_Valuation2013_ForAFN2012)
        {


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US008CN", sOutputFunding_Valuation2013_ForAFN2012_Prod, sOutputFunding_Valuation2013_ForAFN2012);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Funding_Valuation2013_ForAFN2012");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }





        #region HideByWebber

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

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;

        #endregion
    }
}
