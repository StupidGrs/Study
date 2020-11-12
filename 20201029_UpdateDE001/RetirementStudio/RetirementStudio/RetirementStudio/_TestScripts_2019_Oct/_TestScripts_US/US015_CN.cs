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
using RetirementStudio._UIMaps.FAEFormulaClasses;

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
using RetirementStudio._UIMaps.FromToAgeClasses;
using RetirementStudio._UIMaps.EligibilitiesClasses;
using RetirementStudio._UIMaps.SpecialEligibilitiesClasses;
using RetirementStudio._UIMaps.PayoutProjectionClasses;
using RetirementStudio._UIMaps.PayAverageClasses;
using RetirementStudio._UIMaps.VestingClasses;
using RetirementStudio._UIMaps.UnitFormulaClasses;
using RetirementStudio._UIMaps.CostOfLivingAdjustmentsClasses;
using RetirementStudio._UIMaps.EarlyRetirementFactorClasses;
using RetirementStudio._UIMaps.ActuarialEquivalenceClasses;
using RetirementStudio._UIMaps.ConversionFactorsClasses;
using RetirementStudio._UIMaps.FormOfPaymentClasses;
using RetirementStudio._UIMaps.Item415LimitsClasses;
using RetirementStudio._UIMaps.AdjustmentsClasses;
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
using RetirementStudio._UIMaps.FutureValuationOptionClasses;
using RetirementStudio._UIMaps.ServiceSelectionClasses;
using RetirementStudio._UIMaps.FlatAmountAccumulationClasses;
using RetirementStudio._UIMaps.PayCreditClasses;
using System.Threading;


namespace RetirementStudio._TestScripts_2019_Oct_US
{
    /// <summary>
    /// Summary description for US015_CN
    /// </summary>
    [CodedUITest]
    public class US015_CN
    {
        public US015_CN()
        {


            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 015 Create New";
            Config.sPlanName = "QA US Benchmark 015 Create New Plan";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }


        #region Report Output Directory


        public string sOutputFunding_Valuation2011_Baseline = "";
        public string sOutputFunding_Valuation2011_FVclosedgroup = "";
        public string sOutputFunding_Valuation2011_Countsonlyretirementdec = "";
        public string sOutputFunding_Valuation2011_Projectwithgroup = "";
        public string sOutputFunding_Valuation2011_Groupsforreportsnotpop = "";
        public string sOutputFunding_Valuation2011_Secondoptiongroups = "";
        public string sOutputFunding_Valuation2011_LevelpopulationandMultipleDx = "";
        public string sOutputFunding_Valuation2011_ClosedGroupregulardecrements = "";
        public string sOutputFunding_Valuation2011_Countsregrlardecrements = "";
        public string sOutputFunding_Valuation2011_Groupprojections = "";
        public string sOutputFunding_Valuation2011_Reportgroupsnotpop = "";
        public string sOutputFunding_Valuation2011_SecondOptionforgroups = "";
        public string sOutputFunding_Valuation2011_ChangeprovisionsforFV = "";
        public string sOutputAccounting_Accounting2011_Baseline = "";
        public string sOutputAccounting_Accounting2011_FVwithSVCamtCG = "";
        public string sOutputAccounting_Accounting2011_Projandvalassmptsdiff = "";
        public string sOutputAccounting_Accounting2011_AddNewEntrants = "";
        public string sOutputAccounting_Accounting2011_NEswithtestcriteria = "";

        public string sOutputFunding_Valuation2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Baseline\7.5_20191110_Franklin\";
        public string sOutputFunding_Valuation2011_FVclosedgroup_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\FV closed group\7.5_20191110_Franklin\";
        public string sOutputFunding_Valuation2011_Countsonlyretirementdec_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Counts only retirement dec\7.5_20191110_Franklin\";
        public string sOutputFunding_Valuation2011_Projectwithgroup_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Project with group\7.5_20191110_Franklin\";
        public string sOutputFunding_Valuation2011_Groupsforreportsnotpop_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Groups for reports not pop\7.5_20191110_Franklin\";
        public string sOutputFunding_Valuation2011_Secondoptiongroups_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Second option groups\7.5_20191110_Franklin\";
        public string sOutputFunding_Valuation2011_LevelpopulationandMultipleDx_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Level population and Multiple Dx\7.4_20190417_Franklin\";
        public string sOutputFunding_Valuation2011_ClosedGroupregulardecrements_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Closed Group regular decrements\7.4_20190417_Franklin\";
        public string sOutputFunding_Valuation2011_Countsregrlardecrements_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Counts regrlar decrements\7.4_20190417_Franklin\";
        public string sOutputFunding_Valuation2011_Groupprojections_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Group projections\7.4_20190417_Franklin\";
        public string sOutputFunding_Valuation2011_Reportgroupsnotpop_Prod = @"\\mercer.com\US_Data\Shared\DFL\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Report groups not pop\7.5_20191110_Franklin\";
        public string sOutputFunding_Valuation2011_SecondOptionforgroups_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Second Option for groups\7.4_20190417_Franklin\";
        public string sOutputFunding_Valuation2011_ChangeprovisionsforFV_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Change provisions for FV\7.4_20190417_Franklin\";
        public string sOutputAccounting_Accounting2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Accounting\Accounting 2011\Baseline\7.4_20190417_Franklin\";
        public string sOutputAccounting_Accounting2011_FVwithSVCamtCG_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Accounting\Accounting 2011\FV with SVC amt CG\7.4_20190417_Franklin\";
        public string sOutputAccounting_Accounting2011_Projandvalassmptsdiff_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Accounting\Accounting 2011\Proj and val assmpts diff\7.4_20190417_Franklin\";
        public string sOutputAccounting_Accounting2011_AddNewEntrants_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Accounting\Accounting 2011\Add New Entrants\7.4_20190417_Franklin\";
        public string sOutputAccounting_Accounting2011_NEswithtestcriteria_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Accounting\Accounting 2011\NEs with test criteria\7.4_20190417_Franklin\";

        
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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\CreateNew\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);


                    sOutputFunding_Valuation2011_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation 2011\\Baseline\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2011_FVclosedgroup = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation 2011\\FV closed group\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2011_Countsonlyretirementdec = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation 2011\\Counts only retirement dec\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2011_Projectwithgroup = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation 2011\\Project with group\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2011_Groupsforreportsnotpop = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation 2011\\Groups for reports not pop\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2011_Secondoptiongroups = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation 2011\\Second option groups\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2011_LevelpopulationandMultipleDx = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation 2011\\Level population and Multiple Dx\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2011_ClosedGroupregulardecrements = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation 2011\\Closed Group regular decrements\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2011_Countsregrlardecrements = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation 2011\\Counts regrlar decrements\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2011_Groupprojections = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation 2011\\Group projections\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2011_Reportgroupsnotpop = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation 2011\\Report groups not pop\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2011_SecondOptionforgroups = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation 2011\\Second Option for groups\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2011_ChangeprovisionsforFV = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation 2011\\Change provisions for FV\\" + sPostFix + "\\");
                    sOutputAccounting_Accounting2011_Baseline = _gLib._CreateDirectory(sMainDir + "Accounting\\Accounting 2011\\Baseline\\" + sPostFix + "\\");
                    sOutputAccounting_Accounting2011_FVwithSVCamtCG = _gLib._CreateDirectory(sMainDir + "Accounting\\Accounting 2011\\FV with SVC amt CG\\" + sPostFix + "\\");
                    sOutputAccounting_Accounting2011_Projandvalassmptsdiff = _gLib._CreateDirectory(sMainDir + "Accounting\\Accounting 2011\\Proj and val assmpts diff\\" + sPostFix + "\\");
                    sOutputAccounting_Accounting2011_AddNewEntrants = _gLib._CreateDirectory(sMainDir + "Accounting\\Accounting 2011\\Add New Entrants\\" + sPostFix + "\\");
                    sOutputAccounting_Accounting2011_NEswithtestcriteria = _gLib._CreateDirectory(sMainDir + "Accounting\\Accounting 2011\\NEs with test criteria\\" + sPostFix + "\\");


                }

            }


            string sContent = "";
            sContent = sContent + "sOutputFunding_Valuation2011_Baseline = @\"" + sOutputFunding_Valuation2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2011_FVclosedgroup = @\"" + sOutputFunding_Valuation2011_FVclosedgroup + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2011_Countsonlyretirementdec = @\"" + sOutputFunding_Valuation2011_Countsonlyretirementdec + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2011_Projectwithgroup = @\"" + sOutputFunding_Valuation2011_Projectwithgroup + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2011_Groupsforreportsnotpop = @\"" + sOutputFunding_Valuation2011_Groupsforreportsnotpop + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2011_Secondoptiongroups = @\"" + sOutputFunding_Valuation2011_Secondoptiongroups + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2011_LevelpopulationandMultipleDx = @\"" + sOutputFunding_Valuation2011_LevelpopulationandMultipleDx + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2011_ClosedGroupregulardecrements = @\"" + sOutputFunding_Valuation2011_ClosedGroupregulardecrements + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2011_Countsregrlardecrements = @\"" + sOutputFunding_Valuation2011_Countsregrlardecrements + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2011_Groupprojections = @\"" + sOutputFunding_Valuation2011_Groupprojections + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2011_Reportgroupsnotpop = @\"" + sOutputFunding_Valuation2011_Reportgroupsnotpop + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2011_SecondOptionforgroups = @\"" + sOutputFunding_Valuation2011_SecondOptionforgroups + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2011_ChangeprovisionsforFV = @\"" + sOutputFunding_Valuation2011_ChangeprovisionsforFV + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Accounting2011_Baseline = @\"" + sOutputAccounting_Accounting2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Accounting2011_FVwithSVCamtCG = @\"" + sOutputAccounting_Accounting2011_FVwithSVCamtCG + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Accounting2011_Projandvalassmptsdiff = @\"" + sOutputAccounting_Accounting2011_Projandvalassmptsdiff + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Accounting2011_AddNewEntrants = @\"" + sOutputAccounting_Accounting2011_AddNewEntrants + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Accounting2011_NEswithtestcriteria = @\"" + sOutputAccounting_Accounting2011_NEswithtestcriteria + "\";" + Environment.NewLine;


            _gLib._PrintReportDirectory(sContent);
        }


        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();


        public PayCredit pPayCredit = new PayCredit();
        public FlatAmountAccumulation pFlatAmountAccumulation = new FlatAmountAccumulation();
        public ServiceSelection pServiceSelection = new ServiceSelection();
        public FutureValuationOption pFutureValuationOption = new FutureValuationOption();
        public EarlyRetirementFactor pEarlyRetirementFactor = new _UIMaps.EarlyRetirementFactorClasses.EarlyRetirementFactor();
        public FAEFormula pFAEFormula = new _UIMaps.FAEFormulaClasses.FAEFormula();
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
        public void test_US015_CN()
        {


            #region MultiThreads

            Thread thrd_Valuation2011_Baseline = new Thread(() => new US015_CN().t_CompareRpt_Valuation2011_Baseline(sOutputFunding_Valuation2011_Baseline));
            Thread thrd_Valuation2011_FVclosedgroup = new Thread(() => new US015_CN().t_CompareRpt_Valuation2011_FVclosedgroup(sOutputFunding_Valuation2011_FVclosedgroup));
            Thread thrd_Valuation2011_Countsonlyretirementdec = new Thread(() => new US015_CN().t_CompareRpt_Valuation2011_Countsonlyretirementdec(sOutputFunding_Valuation2011_Countsonlyretirementdec));
            Thread thrd_Valuation2011_Projectwithgroup = new Thread(() => new US015_CN().t_CompareRpt_Valuation2011_Projectwithgroup(sOutputFunding_Valuation2011_Projectwithgroup));
            Thread thrd_Valuation2011_Groupsforreportsnotpop = new Thread(() => new US015_CN().t_CompareRpt_Valuation2011_Groupsforreportsnotpop(sOutputFunding_Valuation2011_Groupsforreportsnotpop));
            Thread thrd_Valuation2011_Secondoptiongroups = new Thread(() => new US015_CN().t_CompareRpt_Valuation2011_Secondoptiongroups(sOutputFunding_Valuation2011_Secondoptiongroups));
            Thread thrd_Valuation2011_LevelpopulationandMultipleDx = new Thread(() => new US015_CN().t_CompareRpt_Valuation2011_LevelpopulationandMultipleDx(sOutputFunding_Valuation2011_LevelpopulationandMultipleDx));
            Thread thrd_Valuation2011_ClosedGroupregulardecrements = new Thread(() => new US015_CN().t_CompareRpt_Valuation2011_ClosedGroupregulardecrements(sOutputFunding_Valuation2011_ClosedGroupregulardecrements));
            Thread thrd_Valuation2011_Countsregrlardecrements = new Thread(() => new US015_CN().t_CompareRpt_Valuation2011_Countsregrlardecrements(sOutputFunding_Valuation2011_Countsregrlardecrements));
            Thread thrd_Valuation2011_Groupprojections = new Thread(() => new US015_CN().t_CompareRpt_Valuation2011_Groupprojections(sOutputFunding_Valuation2011_Groupprojections));
            Thread thrd_Valuation2011_Reportgroupsnotpop = new Thread(() => new US015_CN().t_CompareRpt_Valuation2011_Reportgroupsnotpop(sOutputFunding_Valuation2011_Reportgroupsnotpop));
            Thread thrd_Valuation2011_SecondOptionforgroups = new Thread(() => new US015_CN().t_CompareRpt_Valuation2011_SecondOptionforgroups(sOutputFunding_Valuation2011_SecondOptionforgroups));
            Thread thrd_Valuation2011_ChangeprovisionsforFV = new Thread(() => new US015_CN().t_CompareRpt_Valuation2011_ChangeprovisionsforFV(sOutputFunding_Valuation2011_ChangeprovisionsforFV));
            Thread thrd_Accounting2011_Baseline = new Thread(() => new US015_CN().t_CompareRpt_Accounting2011_Baseline(sOutputAccounting_Accounting2011_Baseline));
            Thread thrd_Accounting2011_FVwithSVCamtCG = new Thread(() => new US015_CN().t_CompareRpt_Accounting2011_FVwithSVCamtCG(sOutputAccounting_Accounting2011_FVwithSVCamtCG));
            Thread thrd_Accounting2011_Projandvalassmptsdiff = new Thread(() => new US015_CN().t_CompareRpt_Accounting2011_Projandvalassmptsdiff(sOutputAccounting_Accounting2011_Projandvalassmptsdiff));
            Thread thrd_Accounting2011_AddNewEntrants = new Thread(() => new US015_CN().t_CompareRpt_Accounting2011_AddNewEntrants(sOutputAccounting_Accounting2011_AddNewEntrants));
            Thread thrd_Accounting2011_NEswithtestcriteria = new Thread(() => new US015_CN().t_CompareRpt_Accounting2011_NEswithtestcriteria(sOutputAccounting_Accounting2011_NEswithtestcriteria));


            #endregion


            this.GenerateReportOuputDir();


            #region Funding - Valuation2011 - BaseLine


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);


            _gLib._MsgBox("", "please delete all RollForward service");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "Valuation 2011");
            dic.Add("Parent", "");
            dic.Add("PlanYearBeginningIn", "2011");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("FirstYearPlanUnderPPA", "2008");
            dic.Add("PlanYearEndingIn_DE", "");
            dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("SelectAllVO", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2011");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Roll forward");
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
            dic.Add("FundingInformation_AddNew", "true");
            dic.Add("FundingInformation_Name", "RollForwardFundingCalculator");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "click");
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
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Valuation Data");
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
            dic.Add("CompareData", "false");
            dic.Add("ImportDataandApplyMapping", "Click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Test Case Library");


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"10/13/1961\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"3/24/1976\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"8/15/1982\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2011");

            pMain._Home_ToolbarClick_Top(true);


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
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "true");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "false");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "false");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "false");
            dic.Add("FAS35PresentValueOfVestedBenefits", "false");
            dic.Add("PPAAtRiskLiabilityForMinimum", "false");
            dic.Add("PPAAtRiskLiabilityForMaximum", "false");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "false");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "false");
            dic.Add("EntryAgeNormal", "false");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "Val Liab");


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Future Valuation Options");
            pMain._FlowTreeRightSelect(dic);


            pFutureValuationOption._SelectTab("Population size");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ModelPopulationSizePerParticipantGroup", "");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("PopulationSizeOption", "Count");
            dic.Add("iColName", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._PropulationSize(dic);

            for (int i = 2027; i <= 2031; i++)
            {

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "1");
                dic.Add("ParticipantGroup", "All Actives");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2012 + 3).ToString());
                dic.Add("iColValue", "10.00");
                pFutureValuationOption._PropulationSize(dic);

            }


            pFutureValuationOption._SelectTab("New entrants");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAllFromLibrary", "click");
            dic.Add("iRowNum", "");
            dic.Add("ParticipantGroup", "");
            dic.Add("iColNum", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"3/24/1976\"");
            dic.Add("iResultRow", "1");
            pFutureValuationOption._AddTestCase(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "5");
            dic.Add("iColValue", "0.50");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "6");
            dic.Add("iColValue", "0.33");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "7");
            dic.Add("iColValue", "1.00");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "8");
            dic.Add("iColValue", "1.00");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "11");
            dic.Add("iColValue", "0.00");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "19");
            dic.Add("iColValue", "1.00");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "20");
            dic.Add("iColValue", "2.00");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "22");
            dic.Add("iColValue", "0.000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "23");
            dic.Add("iColValue", "0.000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "24");
            dic.Add("iColValue", "0.000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);



            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"3/24/1976\"");
            dic.Add("iResultRow", "1");
            pFutureValuationOption._AddTestCase(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "3");
            dic.Add("iColValue", "F");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "5");
            dic.Add("iColValue", "0.50");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "6");
            dic.Add("iColValue", "0.33");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "7");
            dic.Add("iColValue", "1.00");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "8");
            dic.Add("iColValue", "1.00");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "11");
            dic.Add("iColValue", "0.00");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "19");
            dic.Add("iColValue", "0.00");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "19");
            dic.Add("iColValue", "1.00");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "20");
            dic.Add("iColValue", "2.00");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "22");
            dic.Add("iColValue", "0.000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "23");
            dic.Add("iColValue", "0.000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "24");
            dic.Add("iColValue", "0.000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UsingRates_P", "click");
            dic.Add("UsingRates_T", "");
            dic.Add("UsingRates_txt", "5.0");
            dic.Add("UsingRates_cbo", "");
            pFutureValuationOption._NewEntrants_UsingRates(dic);


            pFutureValuationOption._SelectTab("Projection years");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EveryYearForTheFirst", "");
            dic.Add("AndEvery", "10");
            dic.Add("UpToincludingProjectionYear", "");
            dic.Add("ProjectionYears", "");
            pFutureValuationOption._ProjectionYears(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("EveryYearForTheFirst", "5");
            dic.Add("AndEvery", "10");
            dic.Add("UpToincludingProjectionYear", "20");
            dic.Add("ProjectionYears", "");
            pFutureValuationOption._ProjectionYears(dic);


            pFutureValuationOption._SelectTab("Future assumptions");

            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Verify");
            //////////dic.Add("AlignRatesWithCurrent", "");
            //////////dic.Add("AlignRatesWithEach", "");
            //////////dic.Add("EstimatedPPAMortality", "2008 Basis after 2017");
            //////////pFutureValuationOption._FutureAssumptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AlignRatesWithCurrent", "");
            dic.Add("AlignRatesWithEach", "");
            dic.Add("EstimatedPPAMortality", "2008 Basis for all years");
            pFutureValuationOption._FutureAssumptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pFutureValuationOption._PopVerify_OK(dic);


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Member Statistics", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Individual Checking Template", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Age Service Matrix", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Data Matching Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Combined Status Code Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Decrement Age", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Future Valuation Population Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Future Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Future Valuation Liabilities by Group", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Future Valuation Liabilities by Year", "RollForward", false, true);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "RollForward", false, true);


            thrd_Valuation2011_Baseline.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Funding - Valuation2011 - FVclosedgroup


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "FV closed group");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "true");
            dic.Add("Assumptions_Name", "Update Mort and Int 2011");
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
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);



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
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2011");
            pInterestRate._PopVerify_PrescribedRates(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "_Death");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("PrePostCommencement", "true");
            dic.Add("ProjectedStaticMortalit", "");
            dic.Add("DisabledVsHealthy", "");
            dic.Add("MemberVsSpouse", "");
            pMortalityDecrement._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreCommencement", "ZERODTH");
            dic.Add("PostCommencement", "CL07C");
            pMortalityDecrement._PrePostCommencement(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("Level_4", "Age60");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "FIXRET");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "true");
            dic.Add("txtLocalEligibility", "Age65");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$Age>=65");
            dic.Add("Validate", "click");
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
            dic.Add("RetWithdrawDis", "ZEROWTH");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "_Disability");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERODIS");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Future Valuation Options");
            pMain._FlowTreeRightSelect(dic);


            pFutureValuationOption._SelectTab("Population size");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("PopulationSizeOption", "Closed Group");
            dic.Add("iColName", "");
            dic.Add("iColValue", "");
            dic.Add("OK", "");
            pFutureValuationOption._PropulationSize(dic);


            pFutureValuationOption._SelectTab("New entrants");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UsingRates_P", "click");
            dic.Add("UsingRates_T", "");
            dic.Add("UsingRates_txt", "0.0");
            dic.Add("UsingRates_cbo", "");
            pFutureValuationOption._NewEntrants_UsingRates(dic);


            pFutureValuationOption._SelectTab("Annuity benefit grouping");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllBenfitDefinitionsInOneGroup", "");
            dic.Add("ByDecrement", "");
            dic.Add("CustomGroupingByBenefitDefinitions", "true");
            dic.Add("AddRow", "click");
            dic.Add("GroupName", "Voluntary");
            dic.Add("Includes_DeathLiab", "");
            dic.Add("Includes_DisabilityLiab", "");
            dic.Add("Includes_InactiveLiab", "");
            dic.Add("Includes_RetirementLiab", "true");
            dic.Add("Includes_WithDrawalLiab", "true");
            dic.Add("OK", "click");
            pFutureValuationOption._AnnuityBen_And_LumpSum(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllBenfitDefinitionsInOneGroup", "");
            dic.Add("ByDecrement", "");
            dic.Add("CustomGroupingByBenefitDefinitions", "true");
            dic.Add("AddRow", "click");
            dic.Add("GroupName", "Involuntary");
            dic.Add("Includes_DeathLiab", "true");
            dic.Add("Includes_DisabilityLiab", "true");
            dic.Add("Includes_InactiveLiab", "");
            dic.Add("Includes_RetirementLiab", "");
            dic.Add("Includes_WithDrawalLiab", "");
            dic.Add("OK", "click");
            pFutureValuationOption._AnnuityBen_And_LumpSum(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllBenfitDefinitionsInOneGroup", "");
            dic.Add("ByDecrement", "");
            dic.Add("CustomGroupingByBenefitDefinitions", "true");
            dic.Add("AddRow", "click");
            dic.Add("GroupName", "Inactive");
            dic.Add("Includes_DeathLiab", "");
            dic.Add("Includes_DisabilityLiab", "");
            dic.Add("Includes_InactiveLiab", "true");
            dic.Add("Includes_RetirementLiab", "");
            dic.Add("Includes_WithDrawalLiab", "");
            dic.Add("OK", "click");
            pFutureValuationOption._AnnuityBen_And_LumpSum(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pFutureValuationOption._PopVerify_OK(dic);



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_FVclosedgroup, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_FVclosedgroup, "Future Valuation Population Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_FVclosedgroup, "Future Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_FVclosedgroup, "Future Valuation Liabilities by Group", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_FVclosedgroup, "Future Valuation Liabilities by Year", "RollForward", false, true);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputFunding_Valuation2011_FVclosedgroup, "RollForward", false, true);


            thrd_Valuation2011_FVclosedgroup.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Funding - Valuation2011 - CountsOnlyRetirementDec


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Counts only retirement dec");
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


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Future Valuation Options");
            pMain._FlowTreeRightSelect(dic);

            pFutureValuationOption._SelectTab("Population size");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("PopulationSizeOption", "Count");
            dic.Add("iColName", "");
            dic.Add("iColValue", "");
            dic.Add("OK", "");
            pFutureValuationOption._PropulationSize(dic);


            pFutureValuationOption._SelectTab("New entrants");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UsingRates_P", "click");
            dic.Add("UsingRates_T", "");
            dic.Add("UsingRates_txt", "4.0");
            dic.Add("UsingRates_cbo", "");
            pFutureValuationOption._NewEntrants_UsingRates(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pFutureValuationOption._PopVerify_OK(dic);



            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "1");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "1");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "1");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "1");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Countsonlyretirementdec, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Countsonlyretirementdec, "Future Valuation Population Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Countsonlyretirementdec, "Future Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Countsonlyretirementdec, "Future Valuation Liabilities by Group", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Countsonlyretirementdec, "Future Valuation Liabilities by Year", "RollForward", false, true);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputFunding_Valuation2011_Countsonlyretirementdec, "RollForward", false, true);


            thrd_Valuation2011_Countsonlyretirementdec.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region  Funding - Valuation2011 - ProjectWithGroups


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Project with groups");
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


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Future Valuation Options");
            pMain._FlowTreeRightSelect(dic);


            pFutureValuationOption._SelectTab("Participant grouping");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GroupingByStatusCodes", "");
            dic.Add("CustomGroupingByBreakField", "");
            dic.Add("CustomGroupingByBreakField_Cbo", "");
            dic.Add("CustomGroupingBySelectionCriteria", "true");
            dic.Add("AddRow", "click");
            dic.Add("iRowNum", "1");
            dic.Add("Group", "TestCase");
            dic.Add("SelectionCriteria", "$emp.TestCaseFlag=1");
            dic.Add("Remove", "");
            dic.Add("Validate", "click");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            pFutureValuationOption._ParticipantGrouping(dic);


            pFutureValuationOption._SelectTab("Population size");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ModelPopulationSizePerParticipantGroup", "true");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "TestCase");
            dic.Add("PopulationSizeOption", "Count");
            dic.Add("iColName", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._PropulationSize(dic);



            for (int i = 2012; i <= 2031; i++)
            {

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "1");
                dic.Add("ParticipantGroup", "TestCase");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2012 + 3).ToString());
                dic.Add("iColValue", "4.00");
                pFutureValuationOption._PropulationSize(dic);

            }



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ModelPopulationSizePerParticipantGroup", "");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "All Others");
            dic.Add("PopulationSizeOption", "Growth rate %");
            dic.Add("iColName", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._PropulationSize(dic);


            for (int i = 2011; i <= 2030; i++)
            {

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "2");
                dic.Add("ParticipantGroup", "All Others");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2011 + 2).ToString());
                dic.Add("iColValue", "1.00");
                pFutureValuationOption._PropulationSize(dic);

            }


            pFutureValuationOption._SelectTab("New entrants");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "TestCase");
            dic.Add("iColNum", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "All Others");
            dic.Add("iColNum", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pFutureValuationOption._PopVerify_OK(dic);



            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Projectwithgroup, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Projectwithgroup, "Future Valuation Population Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Projectwithgroup, "Future Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Projectwithgroup, "Future Valuation Liabilities by Group", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Projectwithgroup, "Future Valuation Liabilities by Year", "RollForward", false, true);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputFunding_Valuation2011_Projectwithgroup, "RollForward", false, true);


            thrd_Valuation2011_Projectwithgroup.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Funding - Valuation2011 - GroupsForReportsNotPop


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Groups for reports not pop");
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



            pMain._SelectTab("Valuation 2011");



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Future Valuation Options");
            pMain._FlowTreeRightSelect(dic);



            pFutureValuationOption._SelectTab("Population size");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ModelPopulationSizePerParticipantGroup", "false");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("PopulationSizeOption", "Growth rate %");
            dic.Add("iColName", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._PropulationSize(dic);


            for (int i = 2012; i <= 2023; i++)
            {

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "1");
                dic.Add("ParticipantGroup", "All Actives");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2012 + 3).ToString());
                dic.Add("iColValue", "1.00");
                pFutureValuationOption._PropulationSize(dic);

            }


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ModelPopulationSizePerParticipantGroup", "");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("PopulationSizeOption", "");
            dic.Add("iColName", (2024 - 2012 + 3).ToString());
            dic.Add("iColValue", "5.00");
            pFutureValuationOption._PropulationSize(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ModelPopulationSizePerParticipantGroup", "");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("PopulationSizeOption", "");
            dic.Add("iColName", (2025 - 2012 + 3).ToString());
            dic.Add("iColValue", "10.00");
            pFutureValuationOption._PropulationSize(dic);


            for (int i = 2026; i <= 2030; i++)
            {

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "1");
                dic.Add("ParticipantGroup", "All Actives");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2012 + 3).ToString());
                dic.Add("iColValue", "0.00");
                pFutureValuationOption._PropulationSize(dic);
            }


            pFutureValuationOption._SelectTab("New entrants");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UsingRates_P", "click");
            dic.Add("UsingRates_T", "");
            dic.Add("UsingRates_txt", "0.0");
            dic.Add("UsingRates_cbo", "");
            pFutureValuationOption._NewEntrants_UsingRates(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pFutureValuationOption._PopVerify_OK(dic);


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Groupsforreportsnotpop, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Groupsforreportsnotpop, "Future Valuation Population Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Groupsforreportsnotpop, "Future Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Groupsforreportsnotpop, "Future Valuation Liabilities by Group", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Groupsforreportsnotpop, "Future Valuation Liabilities by Year", "RollForward", false, true);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputFunding_Valuation2011_Groupsforreportsnotpop, "RollForward", false, true);


            thrd_Valuation2011_Groupsforreportsnotpop.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Funding - Valuation2011 - SecondOptionGroup


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Second option groups");
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
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Future Valuation Options");
            pMain._FlowTreeRightSelect(dic);


            pFutureValuationOption._SelectTab("Participant grouping");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GroupingByStatusCodes", "");
            dic.Add("CustomGroupingByBreakField", "true");
            dic.Add("CustomGroupingByBreakField_Cbo", "TestCaseFlag");
            dic.Add("CustomGroupingBySelectionCriteria", "");
            dic.Add("AddRow", "");
            dic.Add("iRowNum", "1");
            dic.Add("Group", "");
            dic.Add("SelectionCriteria", "");
            dic.Add("Remove", "click");
            dic.Add("Validate", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            pFutureValuationOption._ParticipantGrouping(dic);


            pFutureValuationOption._SelectTab("Population size");


            pFutureValuationOption._SelectTab("New entrants");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UsingRates_P", "click");
            dic.Add("UsingRates_T", "");
            dic.Add("UsingRates_txt", "4.0");
            dic.Add("UsingRates_cbo", "");
            pFutureValuationOption._NewEntrants_UsingRates(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "");
            pFutureValuationOption._PopVerify_OK(dic);


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Secondoptiongroups, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Secondoptiongroups, "Future Valuation Population Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Secondoptiongroups, "Future Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Secondoptiongroups, "Future Valuation Liabilities by Group", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Secondoptiongroups, "Future Valuation Liabilities by Year", "RollForward", false, true);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputFunding_Valuation2011_Secondoptiongroups, "RollForward", false, true);


            thrd_Valuation2011_Secondoptiongroups.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Funding - Valuation2011 - LevelPopulationAndMultipleDx

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Level population and Multiple Dx");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "true");
            dic.Add("Assumptions_Name", "Level population and Multiple Dx Assumptions");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "true");
            dic.Add("Provisions_Name", "Change provisions for FV Provisions");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "T1");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("MenuItem", "Add Withdrawal Decrement");
            pAssumptions._TreeViewRightSelect(dic, "WithdrawalDecrement1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "WithdrawalDecrement1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "T11");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "WithdrawalDecrement1");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "WithdrawalDecrement1");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "Age60");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Career Average Earnings Formula");
            dic.Add("Level_4", "AccruedBenefit");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Career Average Earnings Formula");
            dic.Add("Level_4", "AccruedBenefit");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "PayProjection1");
            dic.Add("ServiceBasedOn", "BenefitService");
            pPayCredit._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceBasedOn", "");
            dic.Add("LimitServiceTo", "");
            dic.Add("StartingAccruedAmount", "AccruedBenefit1");
            dic.Add("AccrualRateTiersBasedOn", "");
            dic.Add("NumberOfAccrualRateTiers", "");
            pFlatAmountAccumulation._Standard(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.02");


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "true");
            dic.Add("txtLocalEligibility", "SevenYearsInFuture");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$FutValOffset>=7 and $Year>=$ValYear+7");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._Home_ToolbarClick_Top(false);

            #endregion




            #region Funding - Valuation2011 - ClosedGroupRegularDecrement


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Closed Group regular decrements");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "true");
            dic.Add("Assumptions_Name", "Closed Group regular decrements Assumptions");
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



            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


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
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2011");
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
            dic.Add("AsOfDate", "01/01/2011");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "01/01/2011");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Future Valuation Options");
            pMain._FlowTreeRightSelect(dic);


            pFutureValuationOption._SelectTab("Population size");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ModelPopulationSizePerParticipantGroup", "");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("PopulationSizeOption", "Closed Group");
            dic.Add("iColName", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._PropulationSize(dic);


            pFutureValuationOption._SelectTab("New entrants");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UsingRates_P", "click");
            dic.Add("UsingRates_T", "");
            dic.Add("UsingRates_txt", "4.0");
            dic.Add("UsingRates_cbo", "");
            pFutureValuationOption._NewEntrants_UsingRates(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pFutureValuationOption._PopVerify_OK(dic);

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_ClosedGroupregulardecrements, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_ClosedGroupregulardecrements, "Future Valuation Population Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_ClosedGroupregulardecrements, "Future Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_ClosedGroupregulardecrements, "Future Valuation Liabilities by Group", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_ClosedGroupregulardecrements, "Future Valuation Liabilities by Year", "RollForward", false, true);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputFunding_Valuation2011_ClosedGroupregulardecrements, "RollForward", false, true);


            thrd_Valuation2011_ClosedGroupregulardecrements.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Funding - Valuation2011 - CountRegularDecrements


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Counts regular decrements");
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


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Future Valuation Options");
            pMain._FlowTreeRightSelect(dic);

            pFutureValuationOption._SelectTab("Population size");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ModelPopulationSizePerParticipantGroup", "");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("PopulationSizeOption", "Count");
            dic.Add("iColName", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._PropulationSize(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pFutureValuationOption._PopVerify_OK(dic);


            pMain._SelectTab("Valuation 2011");



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Countsregrlardecrements, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Countsregrlardecrements, "Future Valuation Population Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Countsregrlardecrements, "Future Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Countsregrlardecrements, "Future Valuation Liabilities by Group", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Countsregrlardecrements, "Future Valuation Liabilities by Year", "RollForward", false, true);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputFunding_Valuation2011_Countsregrlardecrements, "RollForward", false, true);


            thrd_Valuation2011_Countsregrlardecrements.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion



            #region Funding - Valuation2011 - GroupProjections


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Group projections");
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


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Future Valuation Options");
            pMain._FlowTreeRightSelect(dic);


            pFutureValuationOption._SelectTab("Participant grouping");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GroupingByStatusCodes", "");
            dic.Add("CustomGroupingByBreakField", "");
            dic.Add("CustomGroupingByBreakField_Cbo", "");
            dic.Add("CustomGroupingBySelectionCriteria", "true");
            dic.Add("AddRow", "click");
            dic.Add("iRowNum", "1");
            dic.Add("Group", "Test Cases");
            dic.Add("SelectionCriteria", "$emp.TestCaseFlag=1");
            dic.Add("Remove", "");
            dic.Add("Validate", "click");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            pFutureValuationOption._ParticipantGrouping(dic);


            pFutureValuationOption._SelectTab("Population size");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ModelPopulationSizePerParticipantGroup", "true");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "Test Cases");
            dic.Add("PopulationSizeOption", "Count");
            dic.Add("iColName", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._PropulationSize(dic);


            for (int i = 2012; i <= 2031; i++)
            {

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "1");
                dic.Add("ParticipantGroup", "Test Cases");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2012 + 3).ToString());
                dic.Add("iColValue", "4.00");
                pFutureValuationOption._PropulationSize(dic);

            }


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ModelPopulationSizePerParticipantGroup", "");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "All Others");
            dic.Add("PopulationSizeOption", "Growth rate %");
            dic.Add("iColName", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._PropulationSize(dic);


            for (int i = 2011; i <= 2030; i++)
            {

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "2");
                dic.Add("ParticipantGroup", "All Others");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2011 + 2).ToString());
                dic.Add("iColValue", "1.00");
                pFutureValuationOption._PropulationSize(dic);

            }


            pFutureValuationOption._SelectTab("New entrants");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAllFromLibrary", "");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "Test Cases");
            dic.Add("iColNum", "5");
            dic.Add("iColValue", "1.00");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop"); ;
            dic.Add("RemoveAllFromLibrary", "");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "All Others");
            dic.Add("iColNum", "5");
            dic.Add("iColValue", "1.00");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop"); ;
            dic.Add("OK", "click");
            pFutureValuationOption._PopVerify_OK(dic);


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Groupprojections, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Groupprojections, "Future Valuation Population Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Groupprojections, "Future Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Groupprojections, "Future Valuation Liabilities by Group", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Groupprojections, "Future Valuation Liabilities by Year", "RollForward", false, true);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputFunding_Valuation2011_Groupprojections, "RollForward", false, true);


            thrd_Valuation2011_Groupprojections.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Funding - Valuation2011 - ReportGroupNotPop

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Report groups not pop");
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


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Future Valuation Options");
            pMain._FlowTreeRightSelect(dic);


            pFutureValuationOption._SelectTab("Population size");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ModelPopulationSizePerParticipantGroup", "false");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("PopulationSizeOption", "Growth rate %");
            dic.Add("iColName", "");
            dic.Add("iColValue", "");
            dic.Add("OK", "");
            pFutureValuationOption._PropulationSize(dic);


            for (int i = 2012; i <= 2020; i++)
            {

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "1");
                dic.Add("ParticipantGroup", "All Actives");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2012 + 3).ToString());
                dic.Add("iColValue", "1.00");
                pFutureValuationOption._PropulationSize(dic);

            }


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ModelPopulationSizePerParticipantGroup", "");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("PopulationSizeOption", "");
            dic.Add("iColName", (2021 - 2012 + 3).ToString());
            dic.Add("iColValue", "5.00");
            pFutureValuationOption._PropulationSize(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ModelPopulationSizePerParticipantGroup", "");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("PopulationSizeOption", "");
            dic.Add("iColName", (2022 - 2012 + 3).ToString());
            dic.Add("iColValue", "10.00");
            pFutureValuationOption._PropulationSize(dic);


            for (int i = 2023; i <= 2030; i++)
            {

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "1");
                dic.Add("ParticipantGroup", "All Actives");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2012 + 3).ToString());
                dic.Add("iColValue", "1.00");
                pFutureValuationOption._PropulationSize(dic);

            }


            pFutureValuationOption._SelectTab("New entrants");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pFutureValuationOption._PopVerify_OK(dic);



            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Reportgroupsnotpop, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Reportgroupsnotpop, "Future Valuation Population Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Reportgroupsnotpop, "Future Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Reportgroupsnotpop, "Future Valuation Liabilities by Group", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Reportgroupsnotpop, "Future Valuation Liabilities by Year", "RollForward", false, true);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputFunding_Valuation2011_Reportgroupsnotpop, "RollForward", false, true);


            thrd_Valuation2011_Reportgroupsnotpop.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Funding - Valuation2011 - SecondOptionForGroup


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Second Option for groups");
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


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Future Valuation Options");
            pMain._FlowTreeRightSelect(dic);


            pFutureValuationOption._SelectTab("Participant grouping");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GroupingByStatusCodes", "");
            dic.Add("CustomGroupingByBreakField", "true");
            dic.Add("CustomGroupingByBreakField_Cbo", "TestCaseFlag");
            dic.Add("CustomGroupingBySelectionCriteria", "");
            dic.Add("AddRow", "");
            dic.Add("iRowNum", "");
            dic.Add("Group", "");
            dic.Add("SelectionCriteria", "");
            dic.Add("Remove", "click");
            dic.Add("Validate", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            pFutureValuationOption._ParticipantGrouping(dic);


            pFutureValuationOption._SelectTab("New entrants");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAllFromLibrary", "");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "");
            dic.Add("iColNum", "5");
            dic.Add("iColValue", "0.50");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAllFromLibrary", "");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "");
            dic.Add("iColNum", "21");
            dic.Add("iColValue", "1");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAllFromLibrary", "");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "");
            dic.Add("iColNum", "5");
            dic.Add("iColValue", "0.50");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);



            pFutureValuationOption._SelectTab("Annuity benefit grouping");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllBenfitDefinitionsInOneGroup", "true");
            dic.Add("ByDecrement", "");
            dic.Add("CustomGroupingByBenefitDefinitions", "");
            pFutureValuationOption._AnnuityBen_And_LumpSum(dic);


            pFutureValuationOption._SelectTab("Lump sum benefit grouping");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllBenfitDefinitionsInOneGroup", "true");
            dic.Add("ByDecrement", "");
            dic.Add("CustomGroupingByBenefitDefinitions", "");
            pFutureValuationOption._AnnuityBen_And_LumpSum(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pFutureValuationOption._PopVerify_OK(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_SecondOptionforgroups, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_SecondOptionforgroups, "Future Valuation Population Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_SecondOptionforgroups, "Future Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_SecondOptionforgroups, "Future Valuation Liabilities by Group", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_SecondOptionforgroups, "Future Valuation Liabilities by Year", "RollForward", false, true);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputFunding_Valuation2011_SecondOptionforgroups, "RollForward", false, true);


            thrd_Valuation2011_SecondOptionforgroups.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Funding - Valuation2011 - ChangeProvisionsForFV


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Change provisions for FV");
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
            dic.Add("Provisions_Edit", "click");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "170");
            dic.Add("iY", "88");
            dic.Add("Index", "2");
            dic.Add("OK", "click");
            pMain._PopVerify_ProvisionsProperties(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "");
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
            dic.Add("OK", "click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Future Valuation Options");
            pMain._FlowTreeRightSelect(dic);


            pFutureValuationOption._SelectTab("Lump sum benefit grouping");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllBenfitDefinitionsInOneGroup", "");
            dic.Add("ByDecrement", "true");
            dic.Add("CustomGroupingByBenefitDefinitions", "");
            dic.Add("AddRow", "");
            dic.Add("GroupName", "");
            dic.Add("Includes_DeathLiab", "");
            dic.Add("Includes_DisabilitLiab", "");
            dic.Add("Includes_InactiveLiab", "");
            dic.Add("Includes_RetirementLiab", "");
            dic.Add("Includes_WithDrawalLiab", "");
            dic.Add("OK", "");
            pFutureValuationOption._AnnuityBen_And_LumpSum(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pFutureValuationOption._PopVerify_OK(dic);


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_ChangeprovisionsforFV, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_ChangeprovisionsforFV, "Future Valuation Population Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_ChangeprovisionsforFV, "Future Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_ChangeprovisionsforFV, "Future Valuation Liabilities by Group", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_ChangeprovisionsforFV, "Future Valuation Liabilities by Year", "RollForward", false, true);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputFunding_Valuation2011_ChangeprovisionsforFV, "RollForward", false, true);


            thrd_Valuation2011_ChangeprovisionsforFV.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Valuation Node Properties");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "");
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
            dic.Add("Provisions_Edit", "click");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "170");
            dic.Add("iY", "40");
            dic.Add("AddNode", "click");
            dic.Add("NodeName", "AddWithdrawalPlanDef Provision");
            dic.Add("OK", "");
            pMain._PopVerify_ProvisionsProperties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "275");
            dic.Add("iY", "90");
            dic.Add("AddNode", "");
            dic.Add("NodeName", "");
            dic.Add("OK", "click");
            pMain._PopVerify_ProvisionsProperties(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "");
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
            dic.Add("OK", "click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);



            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Career Average Earnings Formula");
            dic.Add("Level_4", "AccruedBenefit");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Career Average Earnings Formula");
            dic.Add("Level_4", "AccruedBenefit");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "PayProjection1");
            dic.Add("ServiceBasedOn", "BenefitService");
            pPayCredit._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceBasedOn", "");
            dic.Add("LimitServiceTo", "");
            dic.Add("StartingAccruedAmount", "AccruedBenefit1");
            dic.Add("AccrualRateTiersBasedOn", "");
            dic.Add("NumberOfAccrualRateTiers", "");
            pFlatAmountAccumulation._Standard(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.02");


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "true");
            dic.Add("txtLocalEligibility", "SevenYearsInFuture");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$FutValOffset>=7 and $Year>=$ValYear+7");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "WithDrawal2Liab");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "WithDrawal2Liab");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "AccruedBenefit");
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

            dic.Add("VestingDefinition", "VestingPct");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");

            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");

            dic.Add("FormOfPayment", "Life");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");

            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");

            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");

            dic.Add("Decrement", "WithdrawalDecrement1");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            pMain._Home_ToolbarClick_Top(true);



            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Future Valuation Options");
            pMain._FlowTreeRightSelect(dic);


            pFutureValuationOption._SelectTab("Projection years");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EveryYearForTheFirst", "11");
            dic.Add("AndEvery", "5");
            dic.Add("UpToincludingProjectionYear", "15");
            dic.Add("ProjectionYears", "");
            pFutureValuationOption._ProjectionYears(dic);


            pFutureValuationOption._SelectTab("Population size");


            for (int i = 2012; i <= 2025; i++)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "1");
                dic.Add("ParticipantGroup", "All Actives");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2012 + 3).ToString());
                dic.Add("iColValue", "");
                pFutureValuationOption._PropulationSize(dic);

            }


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pFutureValuationOption._PopVerify_OK(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "True");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_LevelpopulationandMultipleDx, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_LevelpopulationandMultipleDx, "Future Valuation Population Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_LevelpopulationandMultipleDx, "Future Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_LevelpopulationandMultipleDx, "Future Valuation Liabilities by Group", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_LevelpopulationandMultipleDx, "Future Valuation Liabilities by Year", "RollForward", false, true);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputFunding_Valuation2011_LevelpopulationandMultipleDx, "RollForward", false, true);


            thrd_Valuation2011_LevelpopulationandMultipleDx.Start();



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion





            #region Accounting - Accounting2011 - BaseLine

            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            _gLib._MsgBox("", "please delete all RollForward service");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "Accounting 2011");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "2011");
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
            dic.Add("ServiceToOpen", "Accounting 2011");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Accounting 2011");



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
            dic.Add("OK", "click");
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
            dic.Add("CompareData", "false");
            dic.Add("ImportDataandApplyMapping", "Click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Accounting 2011");


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
            dic.Add("Acc_GL_PBO", "");
            dic.Add("Acc_GL_ABO", "");
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
            dic.Add("Pay", "SalaryCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("Accounting 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Accounting 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Future Valuation Options");
            pMain._FlowTreeRightSelect(dic);


            pFutureValuationOption._SelectTab("Participant grouping");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GroupingByStatusCodes", "true");
            dic.Add("CustomGroupingByBreakField", "");
            dic.Add("CustomGroupingByBreakField_Cbo", "");
            dic.Add("CustomGroupingBySelectionCriteria", "");
            pFutureValuationOption._ParticipantGrouping(dic);


            pFutureValuationOption._SelectTab("Annuity benefit grouping");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllBenfitDefinitionsInOneGroup", "true");
            dic.Add("ByDecrement", "");
            dic.Add("CustomGroupingByBenefitDefinitions", "");
            pFutureValuationOption._AnnuityBen_And_LumpSum(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pFutureValuationOption._PopVerify_OK(dic);


            pMain._SelectTab("Accounting 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Accounting 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "SalaryCurrentYear");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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


            pMain._SelectTab("Accounting 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Accounting 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Reconciliation to Prior Year", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Detailed Results", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Detailed Results by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Status Reconciliation", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Member Statistics", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Individual Checking Template", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Age Service Matrix", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Data Matching Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Combined Status Code Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Valuation Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Individual Output", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "IOE", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Payout Projection", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Liability Set for Globe Export", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Future Valuation Population Projection", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Future Valuation Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Future Valuation Liabilities by Group", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Future Valuation Liabilities by Year", "RollForward", false, false);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputAccounting_Accounting2011_Baseline, "RollForward", false, false);


            thrd_Accounting2011_Baseline.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Accounting - Accounting2011 - FVWithSVCamtCGData


            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "FV with SVC amt CG");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "True");
            dic.Add("Data_Name", "FV with SVC amt CG Data");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "true");
            dic.Add("Assumptions_Name", "Change Ret Rates");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "true");
            dic.Add("Provisions_Name", "FV with SVC amt CG Provisions");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);



            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Data");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);



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
            dic.Add("SnapshotName", "Valuation Data with Service");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "click");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "Click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);


            pParticipantDataSet._Initialzie();


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("FieldName", "BenSvcAmt");
            dic.Add("HistoryFields", "");
            pParticipantDataSet._ts_AddField(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("FieldName", "VestSvcAmt");
            dic.Add("HistoryFields", "");
            pParticipantDataSet._ts_AddField(dic);


            dic.Clear();
            dic.Add("Level_1", "Persional Information");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BenSvcAmt");
            pParticipantDataSet._Navigate(dic, true, true, true, true);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BenSvcAmt");
            dic.Add("Data", "BenSvcAmt");
            pParticipantDataSet._MapField(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "VestSvcAmt");
            dic.Add("Data", "VestSvcAmt");
            pParticipantDataSet._MapField(dic);



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

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("Level_4", "Age65");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "RetRates");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);


            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "Age60");
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
            dic.Add("cboPreDefinedEligibility", "Age60");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);



            pMain._SelectTab("Accounting 2011");

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
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "BenefitService");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "true");
            dic.Add("RulesBasedService", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProvidedInDataField", "BenSvcAmt");
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
            dic.Add("Level_3", "VestingService");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "true");
            dic.Add("RulesBasedService", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProvidedInDataField", "VestSvcAmt");
            dic.Add("RoundingRule", "");
            dic.Add("V", "");
            dic.Add("C", "");
            dic.Add("T", "");
            dic.Add("txtServiceIncrement", "");
            dic.Add("cboServiceIncrement", "");
            pService._PopVerify_ServiceAtValuationDate(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Custom Provision");
            dic.Add("MenuItem", "Add Custom Provision");
            pAssumptions._TreeViewRightSelect(dic, "AccruedBenefitER");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Custom Provision");
            dic.Add("Level_3", "AccruedBenefitER");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$AccruedBenefit[$ExitAge]*$ERF[$ExitAge][$ExitAge]");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            pAssumptions._Collapse(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "RetirementLiab");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "AccruedBenefitER");
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
            dic.Add("EarlyRetirementFactor", "#1#");
            dic.Add("LateRetirementFactor", "");

            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");

            dic.Add("FormOfPayment", "Life");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");

            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");

            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");

            dic.Add("Decrement", "Retirement");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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

            pMain._SelectTab("Accounting 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Accounting 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_FVwithSVCamtCG, "Future Valuation Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_FVwithSVCamtCG, "Future Valuation Population Projection", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_FVwithSVCamtCG, "Future Valuation Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_FVwithSVCamtCG, "Future Valuation Liabilities by Group", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_FVwithSVCamtCG, "Future Valuation Liabilities by Year", "RollForward", false, false);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputAccounting_Accounting2011_FVwithSVCamtCG, "RollForward", false, false);


            thrd_Accounting2011_FVwithSVCamtCG.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Accounting - Accounting2011 - ProjAndValAssumptionDiff


            pMain._SelectTab("Accounting 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Proj and val assmpts diff");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "true");
            dic.Add("Assumptions_Name", "Proj and val assumptions diff Assumptions");
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
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("MenuItem", "Projection same as Valuation");
            pAssumptions._TreeViewRightSelect(dic, "");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("Level_4", "Projection");
            dic.Add("Level_5", "Age60");
            pAssumptions._TreeViewSelect(dic);

            pAssumptions._SelectTab("Conditions");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "true");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("MenuItem", "Projection same as Valuation");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("Level_4", "Projection");
            dic.Add("Level_5", "Age60");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("Level_4", "Projection");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZEROWTH");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "_Disability");
            dic.Add("MenuItem", "Projection same as Valuation");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "_Disability");
            dic.Add("Level_4", "Projection");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERODIS");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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

            pMain._SelectTab("Accounting 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Accounting 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_Projandvalassmptsdiff, "Future Valuation Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Projandvalassmptsdiff, "Future Valuation Population Projection", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Projandvalassmptsdiff, "Future Valuation Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Projandvalassmptsdiff, "Future Valuation Liabilities by Group", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Projandvalassmptsdiff, "Future Valuation Liabilities by Year", "RollForward", false, false);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputAccounting_Accounting2011_Projandvalassmptsdiff, "RollForward", false, false);


            thrd_Accounting2011_Projandvalassmptsdiff.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Accounting - Accounting2011 - AddNewEntrants


            pMain._SelectTab("Accounting 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Add New Entrants");
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


            pMain._SelectTab("Accounting 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Future Valuation Options");
            pMain._FlowTreeRightSelect(dic);


            pFutureValuationOption._SelectTab("Participant grouping");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GroupingByStatusCodes", "");
            dic.Add("CustomGroupingByBreakField", "click");
            dic.Add("CustomGroupingByBreakField_Cbo", "TestCaseFlag");
            dic.Add("CustomGroupingBySelectionCriteria", "");
            dic.Add("AddRow", "");
            dic.Add("iRowNum", "");
            dic.Add("Group", "");
            dic.Add("SelectionCriteria", "");
            dic.Add("Remove", "");
            dic.Add("Validate", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            pFutureValuationOption._ParticipantGrouping(dic);


            pFutureValuationOption._SelectTab("Population size");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ModelPopulationSizePerParticipantGroup", "");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("PopulationSizeOption", "Growth rate %");
            dic.Add("iColName", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._PropulationSize(dic);


            for (int i = 2011; i <= 2030; i++)
            {

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "1");
                dic.Add("ParticipantGroup", "All Actives");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2011 + 2).ToString());
                dic.Add("iColValue", "5.00");
                pFutureValuationOption._PropulationSize(dic);

            }


            pFutureValuationOption._SelectTab("New entrants");


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"3/24/1976\"");
            dic.Add("iResultRow", "1");
            pFutureValuationOption._AddTestCase(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UsingRates_P", "click");
            dic.Add("UsingRates_T", "");
            dic.Add("UsingRates_txt", "5.0");
            dic.Add("UsingRates_cbo", "");
            pFutureValuationOption._NewEntrants_UsingRates(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "9");
            dic.Add("iColValue", "1.0000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "10");
            dic.Add("iColValue", "1.0000");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "24");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "All Actives");
            dic.Add("iColNum", "25");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pFutureValuationOption._PopVerify_OK(dic);


            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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

            pMain._SelectTab("Accounting 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Accounting 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_AddNewEntrants, "Future Valuation Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_AddNewEntrants, "Future Valuation Population Projection", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_AddNewEntrants, "Future Valuation Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_AddNewEntrants, "Future Valuation Liabilities by Group", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_AddNewEntrants, "Future Valuation Liabilities by Year", "RollForward", false, false);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputAccounting_Accounting2011_AddNewEntrants, "RollForward", false, false);


            thrd_Accounting2011_AddNewEntrants.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Accounting - Accounting2011 - NEsWithTestCriteria


            pMain._SelectTab("Accounting 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "NEs with test criteria");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "true");
            dic.Add("MethodsLiabilities_Name", "With TUC Override");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "true");
            dic.Add("Provisions_Name", "With Projected Disability Ben");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service Selection");
            dic.Add("MenuItem", "Add Service Selection");
            pAssumptions._TreeViewRightSelect(dic, "ServiceAt65");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service Selection");
            dic.Add("Level_3", "ServiceAt65");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("BaseServiceProjection", "BenefitService");
            dic.Add("V", "");
            dic.Add("C", "");
            dic.Add("SelectServiceAtAge_cbo", "");
            dic.Add("SelectServiceAtAge_txt", "");
            pServiceSelection._PopVerify_ServiceSelection(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "DisabilityBen");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "DisabilityBen");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccruedBenefit1+0.01*$PayProjection1*Max($ServiceAt65-$emp.BenSvcAmt,0)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "DisabilityLiab");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "DisabilityBen");
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

            dic.Add("FormOfPayment", "Life");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");

            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");

            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");

            dic.Add("Decrement", "Disability");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Methods");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("BenefitDefinition", "DisabilityLiab");
            dic.Add("PUCOverrides", "");
            dic.Add("TUCOverrides", "Service Prorate");
            dic.Add("ServiceForProrate", "BenefitService");
            dic.Add("SpecialAttribute", "");
            pMethods._MethodOverrieds_BenefitDefinition(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Future Valuation Options");
            pMain._FlowTreeRightSelect(dic);

            pFutureValuationOption._SelectTab("Participant grouping");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GroupingByStatusCodes", "");
            dic.Add("CustomGroupingByBreakField", "true");
            dic.Add("CustomGroupingByBreakField_Cbo", "TestCaseFlag");
            dic.Add("CustomGroupingBySelectionCriteria", "");
            dic.Add("AddRow", "click");
            dic.Add("iRowNum", "1");
            dic.Add("Group", "1");
            dic.Add("SelectionCriteria", "");
            dic.Add("Remove", "");
            dic.Add("Validate", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            pFutureValuationOption._ParticipantGrouping(dic);


            pFutureValuationOption._SelectTab("Population size");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ModelPopulationSizePerParticipantGroup", "true");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "1");
            dic.Add("PopulationSizeOption", "Count");
            dic.Add("iColName", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._PropulationSize(dic);


            for (int i = 2012; i <= 2018; i++)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "1");
                dic.Add("ParticipantGroup", "1");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2012 + 3).ToString());
                dic.Add("iColValue", "7.00");
                pFutureValuationOption._PropulationSize(dic);
            }


            for (int i = 2019; i <= 2022; i++)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "1");
                dic.Add("ParticipantGroup", "1");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2012 + 3).ToString());
                dic.Add("iColValue", "8.00");
                pFutureValuationOption._PropulationSize(dic);
            }


            for (int i = 2023; i <= 2025; i++)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "1");
                dic.Add("ParticipantGroup", "1");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2012 + 3).ToString());
                dic.Add("iColValue", "9.00");
                pFutureValuationOption._PropulationSize(dic);
            }


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ModelPopulationSizePerParticipantGroup", "");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "1");
            dic.Add("PopulationSizeOption", "");
            dic.Add("iColName", (2026 - 2012 + 3).ToString());
            dic.Add("iColValue", "10.00");
            pFutureValuationOption._PropulationSize(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ModelPopulationSizePerParticipantGroup", "");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "All Others");
            dic.Add("PopulationSizeOption", "Growth rate %");
            dic.Add("iColName", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._PropulationSize(dic);


            for (int i = 2011; i <= 2012; i++)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "2");
                dic.Add("ParticipantGroup", "All Others");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2011 + 2).ToString());
                dic.Add("iColValue", "3.00");
                pFutureValuationOption._PropulationSize(dic);
            }


            for (int i = 2013; i <= 2014; i++)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "2");
                dic.Add("ParticipantGroup", "All Others");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2011 + 2).ToString());
                dic.Add("iColValue", "4.00");
                pFutureValuationOption._PropulationSize(dic);
            }


            for (int i = 2015; i <= 2016; i++)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "2");
                dic.Add("ParticipantGroup", "All Others");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2011 + 2).ToString());
                dic.Add("iColValue", "5.00");
                pFutureValuationOption._PropulationSize(dic);
            }

            for (int i = 2017; i <= 2018; i++)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "2");
                dic.Add("ParticipantGroup", "All Others");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2011 + 2).ToString());
                dic.Add("iColValue", "3.00");
                pFutureValuationOption._PropulationSize(dic);
            }


            for (int i = 2019; i <= 2020; i++)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "2");
                dic.Add("ParticipantGroup", "All Others");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2011 + 2).ToString());
                dic.Add("iColValue", "4.00");
                pFutureValuationOption._PropulationSize(dic);
            }


            for (int i = 2021; i <= 2022; i++)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "2");
                dic.Add("ParticipantGroup", "All Others");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2011 + 2).ToString());
                dic.Add("iColValue", "5.00");
                pFutureValuationOption._PropulationSize(dic);
            }


            for (int i = 2023; i <= 2024; i++)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "2");
                dic.Add("ParticipantGroup", "All Others");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2011 + 2).ToString());
                dic.Add("iColValue", "3.00");
                pFutureValuationOption._PropulationSize(dic);
            }


            for (int i = 2025; i <= 2026; i++)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("ModelPopulationSizePerParticipantGroup", "");
                dic.Add("iRowNum", "2");
                dic.Add("ParticipantGroup", "All Others");
                dic.Add("PopulationSizeOption", "");
                dic.Add("iColName", (i - 2011 + 2).ToString());
                dic.Add("iColValue", "4.00");
                pFutureValuationOption._PropulationSize(dic);
            }


            pFutureValuationOption._SelectTab("New entrants");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"3/24/1976\"");
            dic.Add("iResultRow", "1");
            pFutureValuationOption._AddTestCase(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "1");
            dic.Add("iColNum", "");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "SalaryPriorYear1");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "85000.00");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sColName", "SalaryPriorYear2");
            dic.Add("iRowNum", "1");
            dic.Add("iColValue", "75000.00");
            pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "All Others");
            dic.Add("iColNum", "24");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "");
            dic.Add("iColNum", "25");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "2");
            dic.Add("ParticipantGroup", "");
            dic.Add("iColNum", "26");
            dic.Add("iColValue", "");
            pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);



            pFutureValuationOption._SelectTab("Annuity benefit grouping");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllBenfitDefinitionsInOneGroup", "");
            dic.Add("ByDecrement", "");
            dic.Add("CustomGroupingByBenefitDefinitions", "true");
            dic.Add("AddRow", "click");
            dic.Add("GroupName", "Voluntary");
            dic.Add("Includes_DeathLiab", "");
            dic.Add("Includes_DisabilityLiab", "");
            dic.Add("Includes_InactiveLiab", "");
            dic.Add("Includes_RetirementLiab", "true");
            dic.Add("Includes_WithDrawalLiab", "true");
            dic.Add("OK", "click");
            pFutureValuationOption._AnnuityBen_And_LumpSum(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllBenfitDefinitionsInOneGroup", "");
            dic.Add("ByDecrement", "");
            dic.Add("CustomGroupingByBenefitDefinitions", "");
            dic.Add("AddRow", "click");
            dic.Add("GroupName", "Involuntary");
            dic.Add("Includes_DeathLiab", "true");
            dic.Add("Includes_DisabilityLiab", "true");
            dic.Add("Includes_InactiveLiab", "true");
            dic.Add("Includes_RetirementLiab", "");
            dic.Add("Includes_WithDrawalLiab", "");
            dic.Add("OK", "click");
            pFutureValuationOption._AnnuityBen_And_LumpSum(dic);



            pFutureValuationOption._SelectTab("Lump sum benefit grouping");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllBenfitDefinitionsInOneGroup", "true");
            dic.Add("ByDecrement", "");
            dic.Add("CustomGroupingByBenefitDefinitions", "");
            dic.Add("OK", "");
            pFutureValuationOption._AnnuityBen_And_LumpSum(dic);





            pFutureValuationOption._SelectTab("Projection years");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EveryYearForTheFirst", "7");
            dic.Add("AndEvery", "5");
            dic.Add("UpToincludingProjectionYear", "15");
            dic.Add("ProjectionYears", "");
            pFutureValuationOption._ProjectionYears(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pFutureValuationOption._PopVerify_OK(dic);



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
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

            pMain._SelectTab("Accounting 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Accounting 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_NEswithtestcriteria, "Future Valuation Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_NEswithtestcriteria, "Future Valuation Population Projection", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_NEswithtestcriteria, "Future Valuation Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_NEswithtestcriteria, "Future Valuation Liabilities by Group", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_NEswithtestcriteria, "Future Valuation Liabilities by Year", "RollForward", false, false);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputAccounting_Accounting2011_NEswithtestcriteria, "RollForward", false, false);



            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputAccounting_Accounting2011_NEswithtestcriteria_Prod, sOutputAccounting_Accounting2011_NEswithtestcriteria);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputAccounting_Accounting2011_NEswithtestcriteria");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" }, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" }, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2017.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2018.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2026.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" }, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" }, true);

            }



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Accounting 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            _gLib._MsgBoxYesNo("Congratulations!", "finished !");



        }




        public void t_CompareRpt_Valuation2011_Baseline(string sOutputFunding_Valuation2011_Baseline)
        {


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_Baseline_Prod, sOutputFunding_Valuation2011_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_Baseline");


                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossStatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                Config.bThreadFinsihed = true;


            }

        }

        public void t_CompareRpt_Valuation2011_FVclosedgroup(string sOutputFunding_Valuation2011_FVclosedgroup)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_FVclosedgroup_Prod, sOutputFunding_Valuation2011_FVclosedgroup);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_FVclosedgroup");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                Config.bThreadFinsihed = true;

            }

        }

        public void t_CompareRpt_Valuation2011_Countsonlyretirementdec(string sOutputFunding_Valuation2011_Countsonlyretirementdec)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_Countsonlyretirementdec_Prod, sOutputFunding_Valuation2011_Countsonlyretirementdec);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_Countsonlyretirementdec");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                Config.bThreadFinsihed = true;

            }

        }

        public void t_CompareRpt_Valuation2011_Projectwithgroup(string sOutputFunding_Valuation2011_Projectwithgroup)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_Projectwithgroup_Prod, sOutputFunding_Valuation2011_Projectwithgroup);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_Projectwithgroup");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                Config.bThreadFinsihed = true;

            }

        }

        public void t_CompareRpt_Valuation2011_Groupsforreportsnotpop(string sOutputFunding_Valuation2011_Groupsforreportsnotpop)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_Groupsforreportsnotpop_Prod, sOutputFunding_Valuation2011_Groupsforreportsnotpop);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_Groupsforreportsnotpop");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                Config.bThreadFinsihed = true;

            }

        }

        public void t_CompareRpt_Valuation2011_Secondoptiongroups(string sOutputFunding_Valuation2011_Secondoptiongroups)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_Secondoptiongroups_Prod, sOutputFunding_Valuation2011_Secondoptiongroups);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_Secondoptiongroups");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                Config.bThreadFinsihed = true;

            }

        }

        public void t_CompareRpt_Valuation2011_LevelpopulationandMultipleDx(string sOutputFunding_Valuation2011_LevelpopulationandMultipleDx)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_LevelpopulationandMultipleDx_Prod, sOutputFunding_Valuation2011_LevelpopulationandMultipleDx);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_LevelpopulationandMultipleDx");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2017.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2018.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2019.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2020.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2022.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2026.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                Config.bThreadFinsihed = true;

            }

        }

        public void t_CompareRpt_Valuation2011_ClosedGroupregulardecrements(string sOutputFunding_Valuation2011_ClosedGroupregulardecrements)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_ClosedGroupregulardecrements_Prod, sOutputFunding_Valuation2011_ClosedGroupregulardecrements);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_ClosedGroupregulardecrements");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                Config.bThreadFinsihed = true;

            }

        }

        public void t_CompareRpt_Valuation2011_Countsregrlardecrements(string sOutputFunding_Valuation2011_Countsregrlardecrements)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_Countsregrlardecrements_Prod, sOutputFunding_Valuation2011_Countsregrlardecrements);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_Countsregrlardecrements");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                Config.bThreadFinsihed = true;

            }

        }

        public void t_CompareRpt_Valuation2011_Groupprojections(string sOutputFunding_Valuation2011_Groupprojections)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_Groupprojections_Prod, sOutputFunding_Valuation2011_Groupprojections);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_Groupprojections");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                Config.bThreadFinsihed = true;

            }

        }

        public void t_CompareRpt_Valuation2011_Reportgroupsnotpop(string sOutputFunding_Valuation2011_Reportgroupsnotpop)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_Reportgroupsnotpop_Prod, sOutputFunding_Valuation2011_Reportgroupsnotpop);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_Reportgroupsnotpop");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                Config.bThreadFinsihed = true;

            }
        }

        public void t_CompareRpt_Valuation2011_SecondOptionforgroups(string sOutputFunding_Valuation2011_SecondOptionforgroups)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_SecondOptionforgroups_Prod, sOutputFunding_Valuation2011_SecondOptionforgroups);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_SecondOptionforgroups");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                Config.bThreadFinsihed = true;

            }

        }

        public void t_CompareRpt_Valuation2011_ChangeprovisionsforFV(string sOutputFunding_Valuation2011_ChangeprovisionsforFV)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_ChangeprovisionsforFV_Prod, sOutputFunding_Valuation2011_ChangeprovisionsforFV);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_ChangeprovisionsforFV");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                Config.bThreadFinsihed = true;
            }
        }



        public void t_CompareRpt_Accounting2011_Baseline(string sOutputAccounting_Accounting2011_Baseline)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputAccounting_Accounting2011_Baseline_Prod, sOutputAccounting_Accounting2011_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputAccounting_Accounting2011_Baseline");

                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0);
                ////////////////////////////_compareReportsLib.CompareExcel_Exact("LiabilityScenario_PBO.xlsx", 4, 0, 0, 0);
                ////////////////////////////_compareReportsLib.CompareExcel_Exact("LiabilityScenario_ABO.xlsx", 4, 0, 0, 0);
                ////////////////////////////_compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PBO.xlsx", 4, 0, 0, 0);
                ////////////////////////////_compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport.xlsx", 4, 0, 0, 0);


                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                Config.bThreadFinsihed = true;

            }

        }

        public void t_CompareRpt_Accounting2011_FVwithSVCamtCG(string sOutputAccounting_Accounting2011_FVwithSVCamtCG)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputAccounting_Accounting2011_FVwithSVCamtCG_Prod, sOutputAccounting_Accounting2011_FVwithSVCamtCG);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputAccounting_Accounting2011_FVwithSVCamtCG");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                Config.bThreadFinsihed = true;

            }
        }

        public void t_CompareRpt_Accounting2011_Projandvalassmptsdiff(string sOutputAccounting_Accounting2011_Projandvalassmptsdiff)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputAccounting_Accounting2011_Projandvalassmptsdiff_Prod, sOutputAccounting_Accounting2011_Projandvalassmptsdiff);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputAccounting_Accounting2011_Projandvalassmptsdiff");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                Config.bThreadFinsihed = true;

            }
        }

        public void t_CompareRpt_Accounting2011_AddNewEntrants(string sOutputAccounting_Accounting2011_AddNewEntrants)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputAccounting_Accounting2011_AddNewEntrants_Prod, sOutputAccounting_Accounting2011_AddNewEntrants);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputAccounting_Accounting2011_AddNewEntrants");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                Config.bThreadFinsihed = true;

            }
        }

        public void t_CompareRpt_Accounting2011_NEswithtestcriteria(string sOutputAccounting_Accounting2011_NEswithtestcriteria)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputAccounting_Accounting2011_NEswithtestcriteria_Prod, sOutputAccounting_Accounting2011_NEswithtestcriteria);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputAccounting_Accounting2011_NEswithtestcriteria");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2017.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2018.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2026.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
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
