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
using System.Diagnostics;

namespace RetirementStudio._TestScripts_2019_cloud._TestScripts_US
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class US015_Cloud
    {
        public US015_Cloud()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 015 Cloud";
            Config.sPlanName = "QA US Benchmark 015 Cloud Plan";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
            //_gLib._Report(_PassFailStep.Header, "Testing Starts at: " + DateTime.Now + "\t" + Environment.UserName);
        }

        #region Report Output Directory


        public string sOutputFunding_Converson2010 = "";
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
        public string sOutputAccounting_Conversion2010 = "";
        public string sOutputAccounting_Accounting2011_Baseline = "";
        public string sOutputAccounting_Accounting2011_FVwithSVCamtCG = "";
        public string sOutputAccounting_Accounting2011_Projandvalassmptsdiff = "";
        public string sOutputAccounting_Accounting2011_AddNewEntrants = "";
        public string sOutputAccounting_Accounting2011_NEswithtestcriteria = "";


        public string sOutputFunding_Converson2010_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\CreateNew\Funding\Conversion 2010\20191020_QA1\";
        public string sOutputFunding_Valuation2011_Baseline_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\CreateNew\Funding\Valuation 2011\Baseline\20191020_QA1\";
        public string sOutputFunding_Valuation2011_FVclosedgroup_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\CreateNew\Funding\Valuation 2011\FV closed group\20191020_QA1\";
        public string sOutputFunding_Valuation2011_Countsonlyretirementdec_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\CreateNew\Funding\Valuation 2011\Counts only retirement dec\20191020_QA1\";
        public string sOutputFunding_Valuation2011_Projectwithgroup_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\CreateNew\Funding\Valuation 2011\Project with group\20191020_QA1\";
        public string sOutputFunding_Valuation2011_Groupsforreportsnotpop_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\CreateNew\Funding\Valuation 2011\Groups for reports not pop\20191020_QA1\";
        public string sOutputFunding_Valuation2011_Secondoptiongroups_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\CreateNew\Funding\Valuation 2011\Second option groups\20191020_QA1\";
        public string sOutputFunding_Valuation2011_LevelpopulationandMultipleDx_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\CreateNew\Funding\Valuation 2011\Level population and Multiple Dx\20191020_QA1\";
        public string sOutputFunding_Valuation2011_ClosedGroupregulardecrements_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\CreateNew\Funding\Valuation 2011\Closed Group regular decrements\20191020_QA1\";
        public string sOutputFunding_Valuation2011_Countsregrlardecrements_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\CreateNew\Funding\Valuation 2011\Counts regrlar decrements\20191020_QA1\";
        public string sOutputFunding_Valuation2011_Groupprojections_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\CreateNew\Funding\Valuation 2011\Group projections\20191020_QA1\";
        public string sOutputFunding_Valuation2011_Reportgroupsnotpop_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\CreateNew\Funding\Valuation 2011\Report groups not pop\20191020_QA1\";
        public string sOutputFunding_Valuation2011_SecondOptionforgroups_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\CreateNew\Funding\Valuation 2011\Second Option for groups\20191020_QA1\";
        public string sOutputFunding_Valuation2011_ChangeprovisionsforFV_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\CreateNew\Funding\Valuation 2011\Change provisions for FV\20191020_QA1\";
        public string sOutputAccounting_Conversion2010_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\CreateNew\Accounting\Conversion 2010\20191020_QA1\";
        public string sOutputAccounting_Accounting2011_Baseline_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\CreateNew\Accounting\Accounting 2011\Baseline\20191020_QA1\";
        public string sOutputAccounting_Accounting2011_FVwithSVCamtCG_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\CreateNew\Accounting\Accounting 2011\FV with SVC amt CG\20191020_QA1\";
        public string sOutputAccounting_Accounting2011_Projandvalassmptsdiff_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\CreateNew\Accounting\Accounting 2011\Proj and val assmpts diff\20191020_QA1\";
        public string sOutputAccounting_Accounting2011_AddNewEntrants_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\CreateNew\Accounting\Accounting 2011\Add New Entrants\20191020_QA1\";
        public string sOutputAccounting_Accounting2011_NEswithtestcriteria_Cloud = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\CreateNew\Accounting\Accounting 2011\NEs with test criteria\20191020_QA1\";



        public void GenerateReportOuputDir()
        {

            pMain._SetLanguageAndRegional();

            _BenchmarkUser sCurrentUser = _gLib._ReturnCurrentUser();
            if (sCurrentUser.ToString() == "Others")
            {
                _gLib._MsgBox("Warning !!!", "Your are NOT allowed to create folders in \\mercer.com\\US_Data\\Shared\\Dfl\\Data1\\RSS\\SQA drive, Please contact Cindy or Webber if you have to!");
                Environment.Exit(0);
            }
            else
            {
                string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Existing\";
                string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString() + "_Cloud";

                //////////
                //////////sPostFix = sPostFix + "_Franklin";
                /////////

                //////////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                sOutputFunding_Converson2010 = _gLib._CreateDirectory(sMainDir + "Funding\\Conversion 2010\\" + sPostFix + "\\");
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
                sOutputAccounting_Conversion2010 = _gLib._CreateDirectory(sMainDir + "Accounting\\Conversion 2010\\" + sPostFix + "\\");
                sOutputAccounting_Accounting2011_Baseline = _gLib._CreateDirectory(sMainDir + "Accounting\\Accounting 2011\\Baseline\\" + sPostFix + "\\");
                sOutputAccounting_Accounting2011_FVwithSVCamtCG = _gLib._CreateDirectory(sMainDir + "Accounting\\Accounting 2011\\FV with SVC amt CG\\" + sPostFix + "\\");
                sOutputAccounting_Accounting2011_Projandvalassmptsdiff = _gLib._CreateDirectory(sMainDir + "Accounting\\Accounting 2011\\Proj and val assmpts diff\\" + sPostFix + "\\");
                sOutputAccounting_Accounting2011_AddNewEntrants = _gLib._CreateDirectory(sMainDir + "Accounting\\Accounting 2011\\Add New Entrants\\" + sPostFix + "\\");
                sOutputAccounting_Accounting2011_NEswithtestcriteria = _gLib._CreateDirectory(sMainDir + "Accounting\\Accounting 2011\\NEs with test criteria\\" + sPostFix + "\\");



            }


            string sContent = "";
            sContent = sContent + "sOutputFunding_Converson2010 = @\"" + sOutputFunding_Converson2010 + "\";" + Environment.NewLine;
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
            sContent = sContent + "sOutputAccounting_Conversion2010 = @\"" + sOutputAccounting_Conversion2010 + "\";" + Environment.NewLine;
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
        public void test_US015_Cloud()
        {

            #region MultiThreads


            Thread thrd_Converson2010 = new Thread(() => new US015_Cloud().t_CompareRpt_Converson2010(sOutputFunding_Converson2010));
            Thread thrd_Valuation2011_Baseline = new Thread(() => new US015_Cloud().t_CompareRpt_Valuation2011_Baseline(sOutputFunding_Valuation2011_Baseline));
            Thread thrd_Valuation2011_FVclosedgroup = new Thread(() => new US015_Cloud().t_CompareRpt_Valuation2011_FVclosedgroup(sOutputFunding_Valuation2011_FVclosedgroup));
            Thread thrd_Valuation2011_Countsonlyretirementdec = new Thread(() => new US015_Cloud().t_CompareRpt_Valuation2011_Countsonlyretirementdec(sOutputFunding_Valuation2011_Countsonlyretirementdec));
            Thread thrd_Valuation2011_Projectwithgroup = new Thread(() => new US015_Cloud().t_CompareRpt_Valuation2011_Projectwithgroup(sOutputFunding_Valuation2011_Projectwithgroup));
            Thread thrd_Valuation2011_Groupsforreportsnotpop = new Thread(() => new US015_Cloud().t_CompareRpt_Valuation2011_Groupsforreportsnotpop(sOutputFunding_Valuation2011_Groupsforreportsnotpop));
            Thread thrd_Valuation2011_Secondoptiongroups = new Thread(() => new US015_Cloud().t_CompareRpt_Valuation2011_Secondoptiongroups(sOutputFunding_Valuation2011_Secondoptiongroups));
            Thread thrd_Valuation2011_LevelpopulationandMultipleDx = new Thread(() => new US015_Cloud().t_CompareRpt_Valuation2011_LevelpopulationandMultipleDx(sOutputFunding_Valuation2011_LevelpopulationandMultipleDx));
            Thread thrd_Valuation2011_ClosedGroupregulardecrements = new Thread(() => new US015_Cloud().t_CompareRpt_Valuation2011_ClosedGroupregulardecrements(sOutputFunding_Valuation2011_ClosedGroupregulardecrements));
            Thread thrd_Valuation2011_Countsregrlardecrements = new Thread(() => new US015_Cloud().t_CompareRpt_Valuation2011_Countsregrlardecrements(sOutputFunding_Valuation2011_Countsregrlardecrements));
            Thread thrd_Valuation2011_Groupprojections = new Thread(() => new US015_Cloud().t_CompareRpt_Valuation2011_Groupprojections(sOutputFunding_Valuation2011_Groupprojections));
            Thread thrd_Valuation2011_Reportgroupsnotpop = new Thread(() => new US015_Cloud().t_CompareRpt_Valuation2011_Reportgroupsnotpop(sOutputFunding_Valuation2011_Reportgroupsnotpop));
            Thread thrd_Valuation2011_SecondOptionforgroups = new Thread(() => new US015_Cloud().t_CompareRpt_Valuation2011_SecondOptionforgroups(sOutputFunding_Valuation2011_SecondOptionforgroups));
            Thread thrd_Valuation2011_ChangeprovisionsforFV = new Thread(() => new US015_Cloud().t_CompareRpt_Valuation2011_ChangeprovisionsforFV(sOutputFunding_Valuation2011_ChangeprovisionsforFV));
            Thread thrd_Accounting_Conversion2010 = new Thread(() => new US015_Cloud().t_CompareRpt_Accounting_Conversion2010(sOutputAccounting_Conversion2010));
            Thread thrd_Accounting2011_Baseline = new Thread(() => new US015_Cloud().t_CompareRpt_Accounting2011_Baseline(sOutputAccounting_Accounting2011_Baseline));
            Thread thrd_Accounting2011_FVwithSVCamtCG = new Thread(() => new US015_Cloud().t_CompareRpt_Accounting2011_FVwithSVCamtCG(sOutputAccounting_Accounting2011_FVwithSVCamtCG));
            Thread thrd_Accounting2011_Projandvalassmptsdiff = new Thread(() => new US015_Cloud().t_CompareRpt_Accounting2011_Projandvalassmptsdiff(sOutputAccounting_Accounting2011_Projandvalassmptsdiff));
            Thread thrd_Accounting2011_AddNewEntrants = new Thread(() => new US015_Cloud().t_CompareRpt_Accounting2011_AddNewEntrants(sOutputAccounting_Accounting2011_AddNewEntrants));
            Thread thrd_Accounting2011_NEswithtestcriteria = new Thread(() => new US015_Cloud().t_CompareRpt_Accounting2011_NEswithtestcriteria(sOutputAccounting_Accounting2011_NEswithtestcriteria));


            #endregion


            this.GenerateReportOuputDir();
                        

            #region sOutputFunding_Converson2010

            //////////pMain._SelectTab("Home");

            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sClientName);
            //////////dic.Add("Level_2", Config.sPlanName);
            //////////dic.Add("Level_3", "FundingValuations");
            //////////pMain._HomeTreeViewSelect(0, dic);

            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("AddServiceInstance", "");
            //////////dic.Add("ServiceToOpen", "Conversion 2010");
            //////////pMain._PopVerify_Home_RightPane(dic);

            //////////pMain._SelectTab("Conversion 2010");


            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "Run");
            //////////dic.Add("MenuItem_2", "Liabilities");
            //////////pMain._FlowTreeRightSelect(dic);


            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("GL_PPANAR_Min", "");
            //////////dic.Add("GL_PPANAR_Max", "");
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
            //////////dic.Add("Pension", "Benefit1DB");
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
            //////////dic.Add("PayoutProjectionCustomGroup", "");
            //////////dic.Add("RunValuation", "Click");
            //////////pMain._PopVerify_RunOptions(dic);


            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("OK", "Click");
            //////////pMain._PopVerify_EnterpriseRunSubmitted(dic);

            //////////pMain._SelectTab("Conversion 2010");

            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "View Run Status");
            //////////pMain._FlowTreeRightSelect(dic);


            //////////pMain._EnterpriseRun("Group Job Successfully Complete", true);


            //////////pMain._SelectTab("Conversion 2010");


            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "Run");
            //////////dic.Add("MenuItem_2", "Future Valuation Population Projection");
            //////////pMain._FlowTreeRightSelect(dic);


            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("IAgreeToUnlock", "True");
            //////////dic.Add("OK", "Click");
            //////////pMain._PopVerify_CascadingUnlock(dic);



            //////////pMain._SelectTab("Conversion 2010");


            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "View Run Status");
            //////////pMain._FlowTreeRightSelect(dic);


            //////////pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            //////////pMain._SelectTab("Conversion 2010");


            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "Run");
            //////////dic.Add("MenuItem_2", "Future Valuation Liabilities");
            //////////pMain._FlowTreeRightSelect(dic);


            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("GL_PPANAR_Min", "");
            //////////dic.Add("GL_PPANAR_Max", "");
            //////////dic.Add("GL_EAN", "");
            //////////dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            //////////dic.Add("PayoutProjection", "");
            //////////dic.Add("IncludeIOE", "True");
            //////////dic.Add("GenerateParameterPrint", "True");
            //////////dic.Add("GenerateTestCaseOutput", "");
            //////////dic.Add("IncludeGainLossResult", "");
            //////////dic.Add("Service", "VestingService");
            //////////dic.Add("Pay", "PayProjection1");
            //////////dic.Add("CurrentYear", "");
            //////////dic.Add("PriorYear", "True");
            //////////dic.Add("CashBanlance", "AccruedBenefit1");
            //////////dic.Add("Pension", "Benefit1DB");
            //////////dic.Add("AllLiabilityTypes", "True");
            //////////dic.Add("PPANotAtRiskLiabilityForMinimum", "");
            //////////dic.Add("PPANotAtRiskLiabilityForMaximum", "");
            //////////dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            //////////dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            //////////dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            //////////dic.Add("FAS35PresentValueOfVestedBenefits", "");
            //////////dic.Add("PPAAtRiskLiabilityForMinimum", "");
            //////////dic.Add("PPAAtRiskLiabilityForMaximum", "");
            //////////dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            //////////dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            //////////dic.Add("EntryAgeNormal", "");
            //////////dic.Add("PayoutProjectionCustomGroup", "");
            //////////dic.Add("RunValuation", "Click");
            //////////pMain._PopVerify_RunOptions(dic);

            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("OK", "Click");
            //////////pMain._PopVerify_EnterpriseRunSubmitted(dic);

            //////////pMain._SelectTab("Conversion 2010");

            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "View Run Status");
            //////////pMain._FlowTreeRightSelect(dic);


            //////////pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            //////////pMain._SelectTab("Conversion 2010");

            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "View Output");
            //////////pMain._FlowTreeRightSelect(dic);


            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Converson2010, "Liability Summary", "Conversion", true, true);
            //////////pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputFunding_Converson2010, "Liability Summary", "Conversion", true, true, 0);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Converson2010, "Member Statistics", "Conversion", true, true);
            //////////pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputFunding_Converson2010, "Conversion Diagnostic", "Conversion", true, true, 0);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Converson2010, "Test Case List", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Converson2010, "Detailed Results", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Converson2010, "Detailed Results by Plan Def", "Conversion", false, true);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Converson2010, "Valuation Summary", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Converson2010, "Individual Output", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Converson2010, "IOE", "Conversion", false, true);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Converson2010, "Parameter Print", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Converson2010, "Test Cases", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Converson2010, "Payout Projection", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Converson2010, "Future Valuation Population Projection", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Converson2010, "Future Valuation Summary", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Converson2010, "Future Valuation Parameter Print", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Converson2010, "Future Valuation Liabilities by Group", "Conversion", true, true);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Converson2010, "Future Valuation Liabilities by Year", "Conversion", true, true);
            //////////pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputFunding_Converson2010, "Conversion", true, true);


            //////////thrd_Converson2010.Start();


            //////////pMain._SelectTab("Output Manager");
            //////////pMain._Home_ToolbarClick_Top(true);
            //////////pMain._Home_ToolbarClick_Top(false);

            //////////pMain._SelectTab("Conversion 2010");
            //////////pMain._Home_ToolbarClick_Top(true);
            //////////pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region sOutputFunding_Valuation2011_Baseline


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2011");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Valuation 2011");

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


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

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



            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Detailed Results", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Status Reconciliation", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Member Statistics", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Individual Checking Template", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Age Service Matrix", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Data Matching Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Combined Status Code Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Gain / Loss Status Reconciliation", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Decrement Age", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Gain / Loss Participant Listing", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Liability Scenario", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Liability Scenario by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Individual Output", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "IOE", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Payout Projection", "RollForward", true, true);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Age Service Matrix", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Liability Set for FSM Export", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Future Valuation Population Projection", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Future Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Future Valuation Liabilities by Group", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Future Valuation Liabilities by Year", "RollForward", true, true);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "RollForward", true, true);


            thrd_Valuation2011_Baseline.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region sOutputFunding_Valuation2011_FVclosedgroup



            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
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
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);
            

            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_FVclosedgroup, "Future Valuation Population Projection", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_FVclosedgroup, "Future Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_FVclosedgroup, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_FVclosedgroup, "Future Valuation Liabilities by Group", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_FVclosedgroup, "Future Valuation Liabilities by Year", "RollForward", true, true);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_FVclosedgroup, "RollForward", true, true);


            thrd_Valuation2011_FVclosedgroup.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region sOutputFunding_Valuation2011_Countsonlyretirementdec



            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
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
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Countsonlyretirementdec, "Future Valuation Population Projection", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Countsonlyretirementdec, "Future Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Countsonlyretirementdec, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Countsonlyretirementdec, "Future Valuation Liabilities by Group", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Countsonlyretirementdec, "Future Valuation Liabilities by Year", "RollForward", true, true);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_Countsonlyretirementdec, "RollForward", true, true);


            thrd_Valuation2011_Countsonlyretirementdec.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region sOutputFunding_Valuation2011_Projectwithgroup



            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
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
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Projectwithgroup, "Future Valuation Population Projection", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Projectwithgroup, "Future Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Projectwithgroup, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Projectwithgroup, "Future Valuation Liabilities by Group", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Projectwithgroup, "Future Valuation Liabilities by Year", "RollForward", true, true);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_Projectwithgroup, "RollForward", true, true);


            thrd_Valuation2011_Projectwithgroup.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region sOutputFunding_Valuation2011_Groupsforreportsnotpop



            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
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
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Groupsforreportsnotpop, "Future Valuation Population Projection", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Groupsforreportsnotpop, "Future Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Groupsforreportsnotpop, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Groupsforreportsnotpop, "Future Valuation Liabilities by Group", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Groupsforreportsnotpop, "Future Valuation Liabilities by Year", "RollForward", true, true);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_Groupsforreportsnotpop, "RollForward", true, true);
 

            thrd_Valuation2011_Groupsforreportsnotpop.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region sOutputFunding_Valuation2011_Secondoptiongroups



            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
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
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Secondoptiongroups, "Future Valuation Population Projection", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Secondoptiongroups, "Future Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Secondoptiongroups, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Secondoptiongroups, "Future Valuation Liabilities by Group", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Secondoptiongroups, "Future Valuation Liabilities by Year", "RollForward", true, true);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_Secondoptiongroups, "RollForward", true, true);



            thrd_Valuation2011_Secondoptiongroups.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region sOutputFunding_Valuation2011_LevelpopulationandMultipleDx


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

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


            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_LevelpopulationandMultipleDx, "Future Valuation Population Projection", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_LevelpopulationandMultipleDx, "Future Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_LevelpopulationandMultipleDx, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_LevelpopulationandMultipleDx, "Future Valuation Liabilities by Group", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_LevelpopulationandMultipleDx, "Future Valuation Liabilities by Year", "RollForward", true, true);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_LevelpopulationandMultipleDx, "RollForward", true, true);
            

            thrd_Valuation2011_LevelpopulationandMultipleDx.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            #endregion
            


            #region sOutputFunding_Valuation2011_ClosedGroupregulardecrements



            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

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


            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_ClosedGroupregulardecrements, "Future Valuation Population Projection", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_ClosedGroupregulardecrements, "Future Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_ClosedGroupregulardecrements, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_ClosedGroupregulardecrements, "Future Valuation Liabilities by Group", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_ClosedGroupregulardecrements, "Future Valuation Liabilities by Year", "RollForward", true, true);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_ClosedGroupregulardecrements, "RollForward", true, true);


            thrd_Valuation2011_ClosedGroupregulardecrements.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region sOutputFunding_Valuation2011_Countsregrlardecrements



            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

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


            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Countsregrlardecrements, "Future Valuation Population Projection", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Countsregrlardecrements, "Future Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Countsregrlardecrements, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Countsregrlardecrements, "Future Valuation Liabilities by Group", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Countsregrlardecrements, "Future Valuation Liabilities by Year", "RollForward", true, true);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_Countsregrlardecrements, "RollForward", true, true);


            thrd_Valuation2011_Countsregrlardecrements.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region sOutputFunding_Valuation2011_Groupprojections



            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

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


            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Groupprojections, "Future Valuation Population Projection", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Groupprojections, "Future Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Groupprojections, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Groupprojections, "Future Valuation Liabilities by Group", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Groupprojections, "Future Valuation Liabilities by Year", "RollForward", true, true);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_Groupprojections, "RollForward", true, true);


            thrd_Valuation2011_Groupprojections.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region sOutputFunding_Valuation2011_Reportgroupsnotpop



            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);


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


            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Reportgroupsnotpop, "Future Valuation Population Projection", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Reportgroupsnotpop, "Future Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_Reportgroupsnotpop, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Reportgroupsnotpop, "Future Valuation Liabilities by Group", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_Reportgroupsnotpop, "Future Valuation Liabilities by Year", "RollForward", true, true);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_Reportgroupsnotpop, "RollForward", true, true);


            thrd_Valuation2011_Reportgroupsnotpop.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region sOutputFunding_Valuation2011_SecondOptionforgroups



            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

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


            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_SecondOptionforgroups, "Future Valuation Population Projection", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_SecondOptionforgroups, "Future Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_SecondOptionforgroups, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_SecondOptionforgroups, "Future Valuation Liabilities by Group", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_SecondOptionforgroups, "Future Valuation Liabilities by Year", "RollForward", true, true);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_SecondOptionforgroups, "RollForward", true, true);


            thrd_Valuation2011_SecondOptionforgroups.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region sOutputFunding_Valuation2011_ChangeprovisionsforFV



            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "8");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

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


            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_ChangeprovisionsforFV, "Future Valuation Population Projection", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_ChangeprovisionsforFV, "Future Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2011_ChangeprovisionsforFV, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_ChangeprovisionsforFV, "Future Valuation Liabilities by Group", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_Valuation2011_ChangeprovisionsforFV, "Future Valuation Liabilities by Year", "RollForward", true, true);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_ChangeprovisionsforFV, "RollForward", true, true);


            thrd_Valuation2011_ChangeprovisionsforFV.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion




            #region sOutputAccounting_Conversion2010

            //////////pMain._SelectTab("Home");

            //////////dic.Clear();
            //////////dic.Add("Level_1", Config.sClientName);
            //////////dic.Add("Level_2", Config.sPlanName);
            //////////dic.Add("Level_3", "AccountingValuations");
            //////////pMain._HomeTreeViewSelect(0, dic);

            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("AddServiceInstance", "");
            //////////dic.Add("ServiceToOpen", "Conversion 2010");
            //////////pMain._PopVerify_Home_RightPane(dic);

            //////////pMain._SelectTab("Conversion 2010");


            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "Run");
            //////////dic.Add("MenuItem_2", "Liabilities");
            //////////pMain._FlowTreeRightSelect(dic);


            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("GL_PPANAR_Min", "");
            //////////dic.Add("GL_PPANAR_Max", "");
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
            //////////dic.Add("Pension", "Benefit1DB");
            //////////dic.Add("AllLiabilityTypes", "");
            //////////dic.Add("PPANotAtRiskLiabilityForMinimum", "");
            //////////dic.Add("PPANotAtRiskLiabilityForMaximum", "");
            //////////dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            //////////dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            //////////dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            //////////dic.Add("FAS35PresentValueOfVestedBenefits", "");
            //////////dic.Add("PPAAtRiskLiabilityForMinimum", "");
            //////////dic.Add("PPAAtRiskLiabilityForMaximum", "");
            //////////dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            //////////dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            //////////dic.Add("EntryAgeNormal", "");
            //////////dic.Add("Acc_ProjectedBenefitObligation", "True");
            //////////dic.Add("Acc_AccumulatedBenefitObligation", "True");
            //////////dic.Add("PayoutProjectionCustomGroup", "");
            //////////dic.Add("RunValuation", "Click");
            //////////pMain._PopVerify_RunOptions(dic);


            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("OK", "Click");
            //////////pMain._PopVerify_EnterpriseRunSubmitted(dic);

            //////////pMain._SelectTab("Conversion 2010");

            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "View Run Status");
            //////////pMain._FlowTreeRightSelect(dic);


            //////////pMain._EnterpriseRun("Group Job Successfully Complete", true);


            //////////pMain._SelectTab("Conversion 2010");


            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "Run");
            //////////dic.Add("MenuItem_2", "Future Valuation Population Projection");
            //////////pMain._FlowTreeRightSelect(dic);

            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("IAgreeToUnlock", "True");
            //////////dic.Add("OK", "Click");
            //////////pMain._PopVerify_CascadingUnlock(dic);

            //////////pMain._SelectTab("Conversion 2010");


            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "View Run Status");
            //////////pMain._FlowTreeRightSelect(dic);


            //////////pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            //////////pMain._SelectTab("Conversion 2010");


            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "Run");
            //////////dic.Add("MenuItem_2", "Future Valuation Liabilities");
            //////////pMain._FlowTreeRightSelect(dic);


            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("GL_PPANAR_Min", "");
            //////////dic.Add("GL_PPANAR_Max", "");
            //////////dic.Add("GL_EAN", "");
            //////////dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            //////////dic.Add("PayoutProjection", "");
            //////////dic.Add("IncludeIOE", "True");
            //////////dic.Add("GenerateParameterPrint", "True");
            //////////dic.Add("GenerateTestCaseOutput", "");
            //////////dic.Add("IncludeGainLossResult", "");
            //////////dic.Add("Service", "VestingService");
            //////////dic.Add("Pay", "PayProjection1");
            //////////dic.Add("CurrentYear", "");
            //////////dic.Add("PriorYear", "True");
            //////////dic.Add("CashBanlance", "AccruedBenefit1");
            //////////dic.Add("Pension", "Benefit1DB");
            //////////dic.Add("AllLiabilityTypes", "True");
            //////////dic.Add("PPANotAtRiskLiabilityForMinimum", "");
            //////////dic.Add("PPANotAtRiskLiabilityForMaximum", "");
            //////////dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            //////////dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            //////////dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            //////////dic.Add("FAS35PresentValueOfVestedBenefits", "");
            //////////dic.Add("PPAAtRiskLiabilityForMinimum", "");
            //////////dic.Add("PPAAtRiskLiabilityForMaximum", "");
            //////////dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            //////////dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            //////////dic.Add("EntryAgeNormal", "");
            //////////dic.Add("PayoutProjectionCustomGroup", "");
            //////////dic.Add("RunValuation", "Click");
            //////////pMain._PopVerify_RunOptions(dic);

            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("OK", "Click");
            //////////pMain._PopVerify_EnterpriseRunSubmitted(dic);

            //////////pMain._SelectTab("Conversion 2010");

            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "View Run Status");
            //////////pMain._FlowTreeRightSelect(dic);


            //////////pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            //////////pMain._SelectTab("Conversion 2010");

            //////////dic.Clear();
            //////////dic.Add("iMaxRowNum", "");
            //////////dic.Add("iMaxColNum", "");
            //////////dic.Add("iSelectRowNum", "1");
            //////////dic.Add("iSelectColNum", "1");
            //////////dic.Add("MenuItem_1", "View Output");
            //////////pMain._FlowTreeRightSelect(dic);


            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Conversion2010, "Liability Summary", "Conversion", true, false);
            //////////pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputAccounting_Conversion2010, "Liability Summary", "Conversion", true, false, 0);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Conversion2010, "Member Statistics", "Conversion", true, false);
            //////////pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputAccounting_Conversion2010, "Conversion Diagnostic", "Conversion", true, false, 0);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Conversion2010, "Conversion Diagnostic", "Conversion", true, false);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Conversion2010, "Test Case List", "Conversion", true, false);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Conversion2010, "Detailed Results", "Conversion", true, false);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Conversion2010, "Detailed Results by Plan Def", "Conversion", false, false);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Conversion2010, "Valuation Summary", "Conversion", true, false);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Conversion2010, "Individual Output", "Conversion", true, false);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Conversion2010, "IOE", "Conversion", false, false);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Conversion2010, "Parameter Print", "Conversion", true, false);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Conversion2010, "Test Cases", "Conversion", true, false);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Conversion2010, "Payout Projection", "Conversion", true, false);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Conversion2010, "FAS Expected Benefit Pmts", "Conversion", true, false);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Conversion2010, "Future Valuation Population Projection", "Conversion", true, false);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Conversion2010, "Future Valuation Summary", "Conversion", true, false);
            //////////pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Conversion2010, "Future Valuation Parameter Print", "Conversion", true, false);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Conversion2010, "Future Valuation Liabilities by Group", "Conversion", true, false);
            //////////pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Conversion2010, "Future Valuation Liabilities by Year", "Conversion", true, false);
            //////////pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputAccounting_Conversion2010, "Conversion", true, false);


            //////////thrd_Accounting_Conversion2010.Start();


            //////////pMain._SelectTab("Output Manager");
            //////////pMain._Home_ToolbarClick_Top(true);
            //////////pMain._Home_ToolbarClick_Top(false);

            //////////pMain._SelectTab("Conversion 2010");
            //////////pMain._Home_ToolbarClick_Top(true);
            //////////pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region sOutputAccounting_Accounting2011_Baseline

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Accounting 2011");
            pMain._PopVerify_Home_RightPane(dic);

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
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

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


            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Reconciliation to Prior Year", "RollForward", true, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Detailed Results", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Detailed Results by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Status Reconciliation", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Member Statistics", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Individual Checking Template", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Age Service Matrix", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Data Matching Summary", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Combined Status Code Summary", "RollForward", true, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Liability Scenario", "RollForward", true, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Liability Scenario by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Valuation Summary", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Individual Output", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "IOE", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Test Cases", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Payout Projection", "RollForward", true, false);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_Valuation2012_ForAFN2012, "Age Service Matrix", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "FAS Expected Benefit Pmts", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Liability Set for Globe Export", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Future Valuation Population Projection", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Future Valuation Summary", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Future Valuation Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Future Valuation Liabilities by Group", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Baseline, "Future Valuation Liabilities by Year", "RollForward", true, false);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputAccounting_Accounting2011_Baseline, "RollForward", true, false);


            thrd_Valuation2011_Baseline.Start();
            

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            #endregion


            #region sOutputAccounting_Accounting2011_FVwithSVCamtCG



            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

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


            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_FVwithSVCamtCG, "Future Valuation Population Projection", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_FVwithSVCamtCG, "Future Valuation Summary", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_FVwithSVCamtCG, "Future Valuation Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_FVwithSVCamtCG, "Future Valuation Liabilities by Group", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_FVwithSVCamtCG, "Future Valuation Liabilities by Year", "RollForward", true, false);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputAccounting_Accounting2011_FVwithSVCamtCG, "RollForward", true, false);


            thrd_Accounting2011_FVwithSVCamtCG.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);





            #endregion


            #region sOutputAccounting_Accounting2011_Projandvalassmptsdiff



            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

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


            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Projandvalassmptsdiff, "Future Valuation Population Projection", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Projandvalassmptsdiff, "Future Valuation Summary", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_Projandvalassmptsdiff, "Future Valuation Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Projandvalassmptsdiff, "Future Valuation Liabilities by Group", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_Projandvalassmptsdiff, "Future Valuation Liabilities by Year", "RollForward", true, false);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputAccounting_Accounting2011_Projandvalassmptsdiff, "RollForward", true, false);


            thrd_Accounting2011_Projandvalassmptsdiff.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);





            #endregion


            #region sOutputAccounting_Accounting2011_AddNewEntrants



            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

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


            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_AddNewEntrants, "Future Valuation Population Projection", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_AddNewEntrants, "Future Valuation Summary", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_AddNewEntrants, "Future Valuation Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_AddNewEntrants, "Future Valuation Liabilities by Group", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_AddNewEntrants, "Future Valuation Liabilities by Year", "RollForward", true, false);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputAccounting_Accounting2011_AddNewEntrants, "RollForward", true, false);


            thrd_Accounting2011_AddNewEntrants.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);





            #endregion


            #region sOutputAccounting_Accounting2011_NEswithtestcriteria



            pMain._SelectTab("Accounting 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);

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


            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_NEswithtestcriteria, "Future Valuation Population Projection", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_NEswithtestcriteria, "Future Valuation Summary", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_Accounting2011_NEswithtestcriteria, "Future Valuation Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_NEswithtestcriteria, "Future Valuation Liabilities by Group", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_Accounting2011_NEswithtestcriteria, "Future Valuation Liabilities by Year", "RollForward", true, false);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputAccounting_Accounting2011_NEswithtestcriteria, "RollForward", true, false);
            

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015Cloud", sOutputAccounting_Accounting2011_NEswithtestcriteria_Cloud, sOutputAccounting_Accounting2011_NEswithtestcriteria);
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

            

            _gLib._MsgBox("Congratulations!", "Finished!");

            Environment.Exit(0);


            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }



        public void t_CompareRpt_Converson2010(string sOutputFunding_Converson2010)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015Cloud", sOutputFunding_Converson2010_Cloud, sOutputFunding_Converson2010);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Converson2010");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_ActiveMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_DeferredMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_Pensioners.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByNone.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByStatusCodes.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByCustom_Gender.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("TestCaseList.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2010.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        public void t_CompareRpt_Valuation2011_Baseline(string sOutputFunding_Valuation2011_Baseline)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015Cloud", sOutputFunding_Valuation2011_Baseline_Cloud, sOutputFunding_Valuation2011_Baseline);
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
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix_2.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforFSMExport.xlsx", 4, 0, 0, 0);
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
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015Cloud", sOutputFunding_Valuation2011_FVclosedgroup_Cloud, sOutputFunding_Valuation2011_FVclosedgroup);
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
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015Cloud", sOutputFunding_Valuation2011_Countsonlyretirementdec_Cloud, sOutputFunding_Valuation2011_Countsonlyretirementdec);
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
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015Cloud", sOutputFunding_Valuation2011_Projectwithgroup_Cloud, sOutputFunding_Valuation2011_Projectwithgroup);
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
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015Cloud", sOutputFunding_Valuation2011_Groupsforreportsnotpop_Cloud, sOutputFunding_Valuation2011_Groupsforreportsnotpop);
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
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015Cloud", sOutputFunding_Valuation2011_Secondoptiongroups_Cloud, sOutputFunding_Valuation2011_Secondoptiongroups);
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
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015Cloud", sOutputFunding_Valuation2011_LevelpopulationandMultipleDx_Cloud, sOutputFunding_Valuation2011_LevelpopulationandMultipleDx);
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
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015Cloud", sOutputFunding_Valuation2011_ClosedGroupregulardecrements_Cloud, sOutputFunding_Valuation2011_ClosedGroupregulardecrements);
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
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015Cloud", sOutputFunding_Valuation2011_Countsregrlardecrements_Cloud, sOutputFunding_Valuation2011_Countsregrlardecrements);
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
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015Cloud", sOutputFunding_Valuation2011_Groupprojections_Cloud, sOutputFunding_Valuation2011_Groupprojections);
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
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015Cloud", sOutputFunding_Valuation2011_Reportgroupsnotpop_Cloud, sOutputFunding_Valuation2011_Reportgroupsnotpop);
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
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015Cloud", sOutputFunding_Valuation2011_SecondOptionforgroups_Cloud, sOutputFunding_Valuation2011_SecondOptionforgroups);
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
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015Cloud", sOutputFunding_Valuation2011_ChangeprovisionsforFV_Cloud, sOutputFunding_Valuation2011_ChangeprovisionsforFV);
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

        public void t_CompareRpt_Accounting_Conversion2010(string sOutputAccounting_Conversion2010)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015Cloud", sOutputAccounting_Conversion2010_Cloud, sOutputAccounting_Conversion2010);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputAccounting_Conversion2010");
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
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2010.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2020.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2030.xlsx", 4, 0, 0, 0);
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
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015Cloud", sOutputAccounting_Accounting2011_Baseline_Cloud, sOutputAccounting_Accounting2011_Baseline);
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
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix_2.xlsx", 4, 0, 0, 0);
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
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015Cloud", sOutputAccounting_Accounting2011_FVwithSVCamtCG_Cloud, sOutputAccounting_Accounting2011_FVwithSVCamtCG);
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
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015Cloud", sOutputAccounting_Accounting2011_Projandvalassmptsdiff_Cloud, sOutputAccounting_Accounting2011_Projandvalassmptsdiff);
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
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015Cloud", sOutputAccounting_Accounting2011_AddNewEntrants_Cloud, sOutputAccounting_Accounting2011_AddNewEntrants);
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
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015Cloud", sOutputAccounting_Accounting2011_NEswithtestcriteria_Cloud, sOutputAccounting_Accounting2011_NEswithtestcriteria);
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
        //}

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
